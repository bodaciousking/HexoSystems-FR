using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartPhases : MonoBehaviour
{
    public initPhase currentPhase;
    MsgDisplay msgD;
    CameraControll cC;
    TemplateSelection tS;
    public static GameStartPhases instance;
    float phaseTimer, phaseDelay = 3;
    public int currentPlayerTurn;
    public void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Too many message initPhase scripts!");
            return;
        }
        instance = this;
    } //singleton
    public enum initPhase
    {
        Welcome,
        PlaceCities,
        Prepare
    }

    private void Start()
    {
        currentPlayerTurn = 1;
        msgD = MsgDisplay.instance;
        cC = CameraControll.instance;
        tS = TemplateSelection.instance;
        currentPhase = initPhase.Welcome;
        msgD.DisplayMessage("Welcome", 2f);
    }

    public void Update()
    {
        if(currentPhase == initPhase.Welcome)
        {
            phaseTimer += Time.deltaTime;
            if(phaseTimer >= phaseDelay)
            {
                PlaceCities();
            }
        }
    }

    public void PlaceCities()
    {
        msgD.DisplayMessage("Choose Your Layout", 2f);
        currentPhase = initPhase.PlaceCities;
        tS.FadeInImage();
        //cC.GoToPos(cC.camSpots[0]);
    }

    public void PreparePhase()
    {
        msgD.DisplayMessage("Prepare Yourself", 4f);
        currentPhase = initPhase.Prepare;
    }

    public void Delay(float timeToDelay)
    {
        StartCoroutine(DelayTime(timeToDelay));
    }

    public IEnumerator DelayTime(float delayForTime)
    {
        yield return new WaitForSeconds(delayForTime);
    }
}
