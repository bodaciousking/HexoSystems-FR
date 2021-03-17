using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hextile : MonoBehaviour
{
    public Vector2 tileLocation;

    public bool isCity;
    public bool shielded;
    public bool blocked;
    public GameObject myCity;
    public GameObject myShield;
    public City containingCity;
    public int owningPlayerID;
    public int shields;
    public int health;

    public bool visible = false; //Edit by Erik 

    private void Start()
    {
        //tileLocation = gameObject.transform.position;
        myShield.transform.localScale = new Vector3(myShield.transform.localScale.x, myCity.transform.localScale.y + myCity.transform.localScale.y/8f, myShield.transform.localScale.z);
    }
    private void Update()
    {
        if (isCity)
        {
            myCity.SetActive(true);
        } 
        if (shielded)
        {
            myShield.SetActive(true);
        }
        else
        {
            myShield.SetActive(false);
        }
    }

}
