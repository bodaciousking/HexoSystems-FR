using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHand : MonoBehaviour
{

    public List<GameObject> Hand;
    private GameObject Decks;

    private GameObject temp;

    private int deckSize1;
    private int deckSize2;
    private int deckSize3;



    // Start is called before the first frame update
    void Start()
    {

        Decks = GameObject.Find("Decks");
        DrawCard(2, "Attack");
        DrawCard(2, "Defence");
        DrawCard(1, "Recon");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void DrawCard(int Amount, string type)
    {


        switch (type)
        {
            case "Attack":
                deckSize1 = Decks.GetComponent<Decks>().AttackDeck.Count;

                for (int i = deckSize1 - 1; i >= deckSize1 - Amount; i--)
                {

                    temp = Decks.GetComponent<Decks>().AttackDeck[i];

                    Hand.Add(temp);

                    Decks.GetComponent<Decks>().RemoveLast("Attack");

                }


                Debug.Log("Drawing from the attack deck");
                break;

            case "Defence":

                deckSize2 = Decks.GetComponent<Decks>().DefenceDeck.Count;

                for (int i = deckSize2 - 1; i >= deckSize2 - Amount; i--)
                {

                    temp = Decks.GetComponent<Decks>().DefenceDeck[i];

                    Hand.Add(temp);

                    Decks.GetComponent<Decks>().RemoveLast("Defence");

                }

                Debug.Log("Drawing from the defence deck");
                break;

            case "Recon":

                deckSize3 = Decks.GetComponent<Decks>().ReconDeck.Count;

                for (int i = deckSize3 - 1; i >= deckSize3 - Amount; i--)
                {

                    temp = Decks.GetComponent<Decks>().ReconDeck[i];

                    Hand.Add(temp);

                    Decks.GetComponent<Decks>().RemoveLast("Recon");

                }

                Debug.Log("Drawing from the recon deck");
                break;
        }
    }


   
}
