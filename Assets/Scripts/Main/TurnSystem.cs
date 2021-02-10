using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum TurnState {Start, Energy, Draw, Strategy, Recalibrate, Resolution, Discard }

//Energy Generation
//Draw Phase
//Strategy Phase
//Recalibrate
//Resolution Phase
//Discard Phase

public class TurnSystem : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public Text turnText; 
    public int temp;
    public int count = 0; 

    public TurnState state;

    public bool cityPicked = false; //use this to check if the turns can start 
   

    // Start is called before the first frame update
    void Start()
    {
        state = TurnState.Start;
        StartCoroutine(MainLoop());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator MainLoop()
    {


        yield return new WaitForSeconds(2f);
        Debug.Log("Energy State");
        state = TurnState.Energy;
        turnText.text = "Energy"; 
        Energy();

        yield return new WaitForSeconds(2f);
        Debug.Log("Draw State");
        state = TurnState.Draw;
        turnText.text = "Draw";
        Draw();

        yield return new WaitForSeconds(2f);
        Debug.Log("Strategy State");
        state = TurnState.Strategy;
        turnText.text = "Strategy";
        Strategy();

        yield return new WaitForSeconds(120f);
        Debug.Log("Discard State");
        state = TurnState.Discard;
        turnText.text = "Discard";

        Discard(); 
    }


    public void Energy()
    {
        //player1 and player2 gain Energy based on towers left
        
    }

    public void Draw()
    {
        //player1 and player2 draw cards

    }

    public void Strategy()
    {

        //player1 and player2 place cards 

    }

    public void Recalibrate()
    {


    }

    public void Resolution()
    {


    }

    public void Discard()
    {


    }




}
