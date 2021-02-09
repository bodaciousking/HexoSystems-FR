using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameObject : MonoBehaviour
{
    Targetting targettingScript;
    public bool blocker;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Main")
        {
            GameObject hextileObject = other.gameObject.transform.parent.gameObject;

            Hextile tileScript = hextileObject.GetComponent<Hextile>();

            if (!tileScript.isCity && !tileScript.blocked)
            {
                Renderer hextileRenderer = hextileObject.transform.Find("Main").GetComponent<Renderer>();

                if (!blocker)
                {
                    hextileRenderer.material.color = Color.blue;
                    targettingScript.AddTileToCity(tileScript);
                }
                else
                {
                    hextileRenderer.material.color = Color.yellow;
                    targettingScript.AddTileToBlockedArea(tileScript);
                }
            }


        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Main")
        {
            GameObject hextileObject = other.gameObject.transform.parent.gameObject;

            Hextile tileScript = hextileObject.GetComponent<Hextile>();

            if (!tileScript.isCity && !tileScript.blocked)
            {
                Renderer hextileRenderer = hextileObject.transform.Find("Main").GetComponent<Renderer>();

                if (!blocker)
                {
                    hextileRenderer.material.color = Color.blue;
                    targettingScript.AddTileToCity(tileScript);
                }
                else
                {
                    hextileRenderer.material.color = Color.yellow;
                    targettingScript.AddTileToBlockedArea(tileScript);
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Main")
        {
            GameObject hextileObject = other.gameObject.transform.parent.gameObject;

            Hextile tileScript = hextileObject.GetComponent<Hextile>();

            if (!tileScript.isCity && !tileScript.blocked)
            {
                Transform gfx = hextileObject.transform.Find("Main");
                Renderer hextileRenderer = gfx.GetComponent<Renderer>();
                FloorGfx hextileGfx = gfx.GetComponent<FloorGfx>();
                hextileRenderer.material.color = hextileGfx.myColor;
                targettingScript.ClearCity();
            }
        }
    }

    private void Update()
    {
    }

    private void Start()
    {
        targettingScript = Targetting.instance;
    }
}
