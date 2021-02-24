using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

namespace Mirror.Example.Pong
{
    public class Player : NetworkBehaviour
    {
        public int energy = 0;
        public int cardsInHand = 0;

        public int baseEnergy = 10; //This is better off in some sort of "gamesettings" script
        CityHandler cH;

        //other player stats
        private void Start()
        {
            cH = GetComponent<CityHandler>();
        }
        public void GenerateEnergy()
        {
            energy = 0;
            energy = cH.DetermineEnergyGeneratedByCities() + baseEnergy;
        }

        void Update()
        {

            if (isLocalPlayer)
            {
                //checks if this player is the owner 
            }

        }

    }
}
