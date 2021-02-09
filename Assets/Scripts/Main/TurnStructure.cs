using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnStructure : MonoBehaviour
{
    public static TurnStructure instance;
    public turnPhase currentPhase;
    private void Awake()
    {
        if(instance != null)
        {
            Debug.Log("Too many turn structure scripts!");
            return;
        }
        instance = this;
    } //Singleton loop

    public enum turnPhase
    {
        EnergyGen1,
        DrawPhase2,
        Strategy3,
        Recalibrate4,
        Resolution5,
        Discard6
    }

    public void NextPhase()
    {
        switch (currentPhase)
        {
            case turnPhase.EnergyGen1:
                currentPhase = turnPhase.DrawPhase2;
                break;
            case turnPhase.DrawPhase2:
                currentPhase = turnPhase.Strategy3;
                break;
            case turnPhase.Strategy3:
                currentPhase = turnPhase.Recalibrate4;
                break;
            case turnPhase.Recalibrate4:
                currentPhase = turnPhase.Resolution5;
                break;
            case turnPhase.Resolution5:
                currentPhase = turnPhase.Discard6;
                break;
            case turnPhase.Discard6:
                currentPhase = turnPhase.EnergyGen1;
                break;
        }    
        Debug.Log(currentPhase);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
