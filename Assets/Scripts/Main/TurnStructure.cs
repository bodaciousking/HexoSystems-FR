using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnStructure : MonoBehaviour
{
    public static TurnStructure instance;
    MsgDisplay msgD;
    CityHandler cH;
    public turnPhase currentPhase = turnPhase.Standby;
    public int numTurns = 0;

    public bool cameraTest;


    public float testPhaseTime = 2f;
    public float standbyPhaseTime = 2f;
    public float titlePhaseTime = 3f;
    public float energyPhaseTime = 3f;
    public float recalibratePhaseTime = 5f;
    public float drawPhaseTime = 30f;
    public float strategyPhaseTime = 120f;
    public float resolutionPhaseTime = 30f;
    public float discardPhaseTime = 3f;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Too many turn structure scripts!");
            return;
        }
        instance = this;
    } //Singleton loop

    private void Start()
    {
        msgD = MsgDisplay.instance;
        cH = GetComponent<CityHandler>();
    }
    public enum turnPhase
    {
        Standby,
        TurnTitle,
        EnergyGen,
        DrawPhase,
        Strategy,
        Recalibrate,
        Resolution,
        Discard
    }

    public void NextPhase()
    {
        switch (currentPhase)
        {
            case turnPhase.Standby:
                currentPhase = turnPhase.TurnTitle;
                BeginPhaseTitle();
                break;
            case turnPhase.TurnTitle:
                currentPhase = turnPhase.EnergyGen;
                BeginPhaseEnergy();
                break;
            case turnPhase.EnergyGen:
                currentPhase = turnPhase.Recalibrate;
                BeginPhaseRecalibrate();
                break;
            case turnPhase.Recalibrate:
                currentPhase = turnPhase.DrawPhase;
                BeginPhaseDraw();
                break;
            case turnPhase.DrawPhase:
                currentPhase = turnPhase.Strategy;
                BeginPhaseStrategy();
                break;
            case turnPhase.Strategy:
                currentPhase = turnPhase.Resolution;
                BeginPhaseResolution();
                break;
            case turnPhase.Resolution:
                currentPhase = turnPhase.Discard;
                BeginPhaseDiscard();
                break;
            case turnPhase.Discard:
                currentPhase = turnPhase.Standby;
                BeginPhaseStandby();
                break;
        }
        //Debug.Log(currentPhase);
    }
    public void BeginPhaseStandby()
    {
        SetNextTurnTimer(standbyPhaseTime);
    }
    public void BeginPhaseTitle()
    {
        numTurns++;
        msgD.DisplayMessage("Eon " + numTurns, 1f);

        if (cameraTest)
        {
            FindCamSpot();
            SetNextTurnTimer(testPhaseTime);
        }
        else
            SetNextTurnTimer(titlePhaseTime);
    }
    public void BeginPhaseEnergy()
    {
        int generatedEnergy = 0;
        generatedEnergy = cH.DetermineEnergyGeneratedByCities() + 10 /* 10 = baseEnergy */;
        msgD.DisplayMessage("Energy Generated: " + generatedEnergy, 1f);

        if (cameraTest)
        {
            FindCamSpot();
            SetNextTurnTimer(testPhaseTime);
        }
        else
            SetNextTurnTimer(energyPhaseTime);
    }
    public void BeginPhaseRecalibrate()
    {
        msgD.DisplayMessage("Recalibrate Phase", 1f);
        //Code for regenerating/decaying shields, etc. goes here.

        if (cameraTest)
        {
            FindCamSpot();
            SetNextTurnTimer(testPhaseTime);
        }
        else
            SetNextTurnTimer(recalibratePhaseTime);
    }
    public void BeginPhaseDraw()
    {
        msgD.DisplayMessage("Draw Phase", 1f);
        //Code for drawing cards goes here.

        if (cameraTest)
        {
            FindCamSpot();
            SetNextTurnTimer(testPhaseTime);
        }
        else
            SetNextTurnTimer(drawPhaseTime);

    }
    public void BeginPhaseStrategy()
    {
        msgD.DisplayMessage("Strategy Phase", 1f);
        //Code for strategy phase goes here.

        if (cameraTest)
        {
            FindCamSpot();
            SetNextTurnTimer(testPhaseTime);
        }
        else
            SetNextTurnTimer(strategyPhaseTime);
    }
    public void BeginPhaseResolution()
    {
        msgD.DisplayMessage("Resolution Phase", 1f);
        //Code for playing out cards and actions goes here.

        if (cameraTest)
        {
            FindCamSpot();
            SetNextTurnTimer(testPhaseTime);
        }
        else
            SetNextTurnTimer(resolutionPhaseTime);
    }
    public void BeginPhaseDiscard()
    {
        msgD.DisplayMessage("Discard Phase", 1f);
        //Code for discarding cards goes here.

        if (cameraTest)
        {
            FindCamSpot();
            SetNextTurnTimer(testPhaseTime);
        }
        else
            SetNextTurnTimer(discardPhaseTime);
    }

    public void SetNextTurnTimer(float time)
    {
        StopCoroutine(TimeNextTurn(time));
        StartCoroutine(TimeNextTurn(time));
    }

    IEnumerator TimeNextTurn(float time)
    {
        yield return new WaitForSeconds(time);
        NextPhase();
    }

    public void FindCamSpot()
    {
        CameraControll cC = Camera.main.GetComponent<CameraControll>();
        cC.FindCoolSpot();
    }

    public void ToggleTest()
    {
        cameraTest = !cameraTest;
    }
}