﻿using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Cards : MonoBehaviour
{
    
}

public class Card
{
    public int cardID;
    public string cardName;
    public int energyCost;

    public TargetType targetType; 
    public int targetSize;
    public int numTargets;

    public virtual void PlayCard()
    {
        Debug.Log("Playing " + cardName + "...");
    }

    public enum TargetType
    {
        random, selectTarget, noTarget
    }
}

public class AttackCard : Card
{
    public int damageDealt;
}

public class DefenceCard : Card
{
    public int shieldsRestored;
    public int shieldType; // 0 = Decaying shield. 1 = Permanent shield.
}

public class ReconCard : Card
{
    public int visionDuration;
}

/////// ATTACK CARD LIST 
public class ScatterShot : AttackCard
{
    public ScatterShot()
    {
        cardID = 001;
        cardName = "Scatter Shot";
        energyCost = 2;
        targetType = TargetType.random;
        numTargets = 4;
        damageDealt = 1;
    }

    public override void PlayCard()
    {
        base.PlayCard();

        GameObject clientMaster = GameObject.Find("ClientMaster"); 
        GameObject enemyMapTransform = clientMaster.transform.Find("Player 1 Map").gameObject;
        GameObject enemyPlanetTransform = enemyMapTransform.transform.Find("Planet(Clone)").gameObject;
        Planet enemyPlanet = enemyPlanetTransform.GetComponent<Planet>();

        List<Hextile> enemyTileList = enemyPlanet.hextileList;
        List<Hextile> selectedTargets = new List<Hextile>();

        var rnd = new System.Random();
        var randomNumbers = Enumerable.Range(0, enemyTileList.Count).OrderBy(x => rnd.Next()).Take(4).ToList();

        for (int i = 0; i < randomNumbers.Count; i++)
        {
            selectedTargets.Add(enemyTileList[randomNumbers[i]]);
        }

        //Card Resolution

        for (int i = 0; i < selectedTargets.Count; i++)
        {
            GameObject hextileObject = selectedTargets[i].gameObject;
            Transform gfx = hextileObject.transform.Find("Main");
            Renderer hextileRenderer = gfx.GetComponent<Renderer>();
            FloorGfx hextileGfx = gfx.GetComponent<FloorGfx>();
            hextileRenderer.material.color = Color.red;
        }

    }
}

/////// DEFENCE CARD LIST
public class EmergencyShield : DefenceCard
{
    public EmergencyShield()
    {
        cardID = 101;
        cardName = "Emergency Shield";
        energyCost = 3;
        targetType = TargetType.selectTarget;
        numTargets = 1;
        shieldType = 0;
        shieldsRestored = 2;
    }
}

/////// RECON CARD LIST
public class BraveExplorers : ReconCard
{
    public BraveExplorers()
    {
        cardID = 201;
        cardName = "Brave Explorers";
        energyCost = 2;
        targetType = TargetType.selectTarget;
        numTargets = 4;
        visionDuration = 1;
    }
}

