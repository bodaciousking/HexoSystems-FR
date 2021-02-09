using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hextile : MonoBehaviour
{
    public Vector2 tileLocation;

    public bool isCity;
    public bool blocked;
    public GameObject myCity;
    public int owningPlayerID;

    private void Start()
    {
        
    }
    private void Update()
    {
        if (isCity)
        {
            myCity.SetActive(true);
        }
    }

}
