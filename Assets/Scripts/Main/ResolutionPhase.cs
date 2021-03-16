using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionPhase : MonoBehaviour
{
    public List<CardResolution> cardResolutionList = new List<CardResolution>();
}

public class CardResolution
{
    public int CardType; // 0 = Attack, 1 = Defence, 2 = Scouting

}
