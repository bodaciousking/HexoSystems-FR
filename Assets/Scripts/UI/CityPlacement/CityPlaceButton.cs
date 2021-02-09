using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityPlaceButton : MonoBehaviour
{
    public int citySize;
    public int actualSize;
    Targetting targettingScript;

    private void Start()
    {
        targettingScript = Targetting.instance;
    }
    public void SelectSize()
    {
        targettingScript.EnableCityPlacementPrefab(citySize);
        targettingScript.intendedSize = actualSize;
    }
}
