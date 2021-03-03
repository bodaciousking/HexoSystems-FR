using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameObject : MonoBehaviour
{
    Targetting targettingScript;
    TemplateSelection tS;
    public bool blocker;

    private void OnTriggerEnter(Collider other)
    {
        if(tS.size3 > 0 || tS.size4 > 0 || tS.size7 > 0)
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
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Main")
        {
            GameObject hextileObject = other.gameObject.transform.parent.gameObject;

            Hextile tileScript = hextileObject.GetComponent<Hextile>();

            if (!tileScript.isCity && !tileScript.blocked)
            {
                targettingScript.CancelCity();
            }
        }
    }

    private void Update()
    {
    }

    private void Start()
    {
        targettingScript = Targetting.instance;
        tS = TemplateSelection.instance;
    }
}
