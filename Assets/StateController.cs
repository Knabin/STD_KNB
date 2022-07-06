using System.Collections.Generic;
using UnityEngine;
public abstract class StateController
{
    protected Dictionary<int, State> stateDic;
    protected int currentState;

    public abstract void Init(GameObject root, int startState);

    public void SetState(int state)
    {
        State current, newCurrent;

        if (stateDic.TryGetValue(currentState, out current))
        {
            current.Exit();
        }

        if (stateDic.TryGetValue(state, out newCurrent))
        {
            newCurrent.Enter();
        }

        currentState = state;
    }

    public void StateUpdate()
    {
        if (stateDic.ContainsKey(currentState) && stateDic[currentState] != null)
        {
                stateDic[currentState].Update();
        }
    }
}

public class EnemyStateController : StateController
{
    public enum EnemyState {
        FIND_ENEMY = 0,
        LOCOMOTION,
        ATTACK,
        DEAD,
        NONE,
    }
    public override void Init(GameObject root, int startState)
    {
        stateDic.Add((int)EnemyState.FIND_ENEMY, new FindEnemy());
        stateDic.Add((int)EnemyState.LOCOMOTION, new Locomotion());
        stateDic.Add((int)EnemyState.ATTACK, new Attack());
        stateDic.Add((int)EnemyState.DEAD, new Dead());

        foreach (var item in stateDic)
        {
            item.Value.SetRootObject(root);
        }

        if (stateDic.ContainsKey(startState)) 
        {
            currentState = startState;
        }
        else
        {
            currentState = (int)EnemyState.FIND_ENEMY;
        }
            
        stateDic[currentState].Enter();
    }
}