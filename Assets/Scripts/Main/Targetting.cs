using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Targetting : MonoBehaviour
{
    public GameObject target;
    public GameObject selectedCityObject;
    public List<GameObject> cityPlaceObjects = new List<GameObject>();
    public static Targetting instance;
    TemplateSelection tS;
    CityHandler cH;
    public int intendedSize;
    List<Hextile> possibleCity = new List<Hextile>();
    List<Hextile> possibleBlockedArea = new List<Hextile>();

    Ray ray;
    RaycastHit hit;


    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Too many targetting scripts!");
            return;
        }
        instance = this;
    }

    public void Start()
    {
        tS = TemplateSelection.instance;
        cH = GetComponent<CityHandler>();

        for (int i = 0; i < cityPlaceObjects.Count; i++)
        {
            GameObject newObject = Instantiate(cityPlaceObjects[i]);
            cityPlaceObjects[i] = newObject;
            if (target)
            {
                cityPlaceObjects[i].transform.position = target.transform.position;
            }
            cityPlaceObjects[i].SetActive(false);
        }
    }
    public void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        int layerMask = 1 << 8;
        if (Physics.Raycast(ray, out hit, 5000, layerMask))
        {
            if (selectedCityObject)
            {
                selectedCityObject.SetActive(true);
                selectedCityObject.transform.position = hit.transform.position;
            }
        }
        else if (selectedCityObject)
        {
            DisableCityPlacementPrefab();
        }
        if (selectedCityObject)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                selectedCityObject.transform.Rotate(0, 60, 0);
            }
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (!EventSystem.current.IsPointerOverGameObject())
                    CreateCity();
            }
        }
    }

    public void AddTileToCity(Hextile tile)
    {
        if (!possibleCity.Contains(tile))
        {
            possibleCity.Add(tile);
        }
    }
    public void AddTileToBlockedArea(Hextile tile)
    {
        if (!possibleBlockedArea.Contains(tile))
        {
            possibleBlockedArea.Add(tile);
        }
    }

    public void CreateCity()
    {
        if (possibleCity.Count < intendedSize)
        {
            Debug.Log("City too small!");
            return;
        }
        int owningPlayer;
        for (int i = 0; i < possibleCity.Count; i++)
        {
            Hextile tileScript = possibleCity[i];
            tileScript.isCity = !tileScript.isCity;
            owningPlayer = tileScript.owningPlayerID;
            tileScript.transform.Find("Main").GetComponent<Renderer>().material.color = Color.gray;
        }

        City newCity = new City();
        List<Hextile> newList = new List<Hextile>(possibleCity);
        newCity.cityTiles = newList;
        newCity.cityEnergy = newCity.DetermineCityEnergy();
        cH.myCities.Add(newCity);

        possibleCity.Clear();

        for (int i = 0; i < possibleBlockedArea.Count; i++)
        {
            Hextile tileScript = possibleBlockedArea[i];
            tileScript.blocked = !tileScript.blocked;
            owningPlayer = tileScript.owningPlayerID;
            tileScript.transform.Find("Main").GetComponent<Renderer>().material.color = Color.green;
        }
        possibleBlockedArea.Clear();

        tS.DecrementRemainingCities(intendedSize);
    }
    public void CancelCity()
    {
        for (int i = 0; i < possibleCity.Count; i++)
        {
            FloorGfx gfx = possibleCity[i].gameObject.GetComponentInChildren<FloorGfx>();
            gfx.ReturnToOgColor();
        }
        possibleCity.Clear();

        for (int i = 0; i < possibleBlockedArea.Count; i++)
        {
            FloorGfx gfx = possibleBlockedArea[i].GetComponentInChildren<FloorGfx>();
            gfx.ReturnToOgColor();
        }
        possibleBlockedArea.Clear();
    }
    public void EnableCityPlacementPrefab(int listIndex)
    {
        switch (listIndex)
        {
            case 0:
                intendedSize = 7;
                break;
            case 1:
                intendedSize = 4;
                break;
            case 2:
                intendedSize = 3;
                break;
            default:
                Debug.Log("invalid city size recieved! Size recieved: " + listIndex);
                break;
        }
        if (selectedCityObject)
        {
            selectedCityObject.SetActive(false);
        }
        cityPlaceObjects[listIndex].SetActive(true); 
        selectedCityObject = cityPlaceObjects[listIndex];
    }

    public void DisableCityPlacementPrefab()
    {
        selectedCityObject.SetActive(false);
        CancelCity();
    }
}
