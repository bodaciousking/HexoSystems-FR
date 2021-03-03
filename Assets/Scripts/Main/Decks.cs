using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decks : MonoBehaviour
{

    private GameObject[] AttackDeckArr;
    public List<GameObject> AttackDeck;
    public List<GameObject> AttackDiscard;

    private GameObject[] DefenceDeckArr;
    public List<GameObject> DefenceDeck;
    public List<GameObject> DefenceDiscard;

    private GameObject[] ReconDeckArr;
    public List<GameObject> ReconDeck;
    public List<GameObject> ReconDiscard;

    private GameObject temp;

    private int deckSizeAtt;
    private int deckSizeDef;
    private int deckSizeRec;


    // Start is called before the first frame update
    void Start()
    {
        AttackDeckArr = Resources.LoadAll<GameObject>("AttackDeck");
        DefenceDeckArr = Resources.LoadAll<GameObject>("DefenceDeck");
        ReconDeckArr = Resources.LoadAll<GameObject>("ReconDeck");
        loadDecks(AttackDeckArr, AttackDeck);
        loadDecks(DefenceDeckArr, DefenceDeck);
        loadDecks(ReconDeckArr, ReconDeck);
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void loadDecks(GameObject[] tempArr, List<GameObject> tempList)
    {
        for (int c = 0; c <= 8; c++)
        {
            for (int i = 0; i <= tempArr.Length - 1; i++)
            {
                temp = tempArr[i];
                tempList.Add(temp);

            }
        }
    }

    public void RemoveLast(string type)
    {
        switch (type)
        {
            case "Attack":
                deckSizeAtt = AttackDeck.Count; 
                AttackDeck.RemoveAt(deckSizeAtt - 1);
                deckSizeAtt--; 



                Debug.Log("Drawing from the attack deck");
                break;

            case "Defence":
                deckSizeDef = DefenceDeck.Count;
                DefenceDeck.RemoveAt(deckSizeDef - 1);
                deckSizeDef--;



                Debug.Log("Drawing from the attack deck");
                break;
            case "recon":
                deckSizeRec = ReconDeck.Count;
                ReconDeck.RemoveAt(deckSizeRec - 1);
                deckSizeRec--;



                Debug.Log("Drawing from the attack deck");
                break;
        }
    }


}
