using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionPhase : MonoBehaviour
{
    public List<AttackAction> attackActions = new List<AttackAction>();
    public List<DefenceAction> defenceActions = new List<DefenceAction>();
    public List<ReconAction> reconActions = new List<ReconAction>();

    public AttackAction storedAttackAction;
    public DefenceAction storedDefenceAction;
    public ReconAction storedReconAction;

    public static ResolutionPhase instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Too many ResolutionPhase scripts!");
            return;
        }
        instance = this;
    }

    public void CompleteAction()
    {
        if (storedAttackAction!= null) 
        {
            Debug.Log("Finishing an Attack action.");
            attackActions.Add(storedAttackAction);
            storedAttackAction = null;
        }
        if (storedDefenceAction!= null) 
        {
            Debug.Log("Finishing a Defence action.");
            defenceActions.Add(storedDefenceAction);
            storedDefenceAction = null;
        }
        if (storedReconAction!= null) 
        {
            Debug.Log("Finishing a Recon action.");
            reconActions.Add(storedReconAction);
            storedReconAction = null;
        }
    }
    public void BeginPlayActions()
    {
        StopCoroutine(ActionLoop());
        StartCoroutine(ActionLoop());
    }

    public IEnumerator ActionLoop()
    {
        for (int i = 0; i < attackActions.Count; i++)
        {
            AttackAction aA = attackActions[i];
            aA.ExecuteAction();
        }
        yield return new WaitForSeconds(1f);

        for (int i = 0; i < defenceActions.Count; i++)
        {
            DefenceAction dA = defenceActions[i];
            dA.ExecuteAction();
        }
        yield return new WaitForSeconds(1f);

        for (int i = 0; i < reconActions.Count; i++)
        {
            ReconAction rA = reconActions[i];
            rA.ExecuteAction();

        }
        yield return new WaitForSeconds(1f);

    }
}

public class CardAction
{
    public int actionType; // 0 = Attack, 1 = Defence, 2 = Scouting
    public string actionName;
    public Hextile target;

    public virtual void ExecuteAction()
    {
        Debug.Log("Executing " + actionName + ".");
    }
}

public class AttackAction : CardAction
{
    public int damage;
}

public class DefenceAction : CardAction
{
    public int shieldStrength;
    public City effectedCity;
}

public class ReconAction : CardAction
{

}

public class EmergencyShieldAction : DefenceAction
{
    public override void ExecuteAction()
    {
        base.ExecuteAction();

        target.shielded = true;
        target.shields += shieldStrength;
    }
}
