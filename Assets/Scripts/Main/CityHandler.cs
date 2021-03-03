using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityHandler : MonoBehaviour
{
    public List<City> myCities = new List<City>();
    public int generatedEnergy = 0;

    public int DetermineEnergyGeneratedByCities()
    {
        int allCityEnergy = 0;
        for (int i = 0; i < myCities.Count; i++)
        {
            allCityEnergy += myCities[i].cityEnergy;
        }

        return allCityEnergy;
    }

    private void Awake()
    {

    }

    private void Update()
    {

    }
}

public class City
{
    public List<Hextile> cityTiles;
    public int cityEnergy;


    public int DetermineCityEnergy()
    {
        int energy = 0;
        switch (cityTiles.Count)
        {
            case 3:
                energy = 1;
                break;
            case 4:
                energy = 2;
                break;
            case 7:
                energy = 3;
                break;
        }
        return energy;
    }
}