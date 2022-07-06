using System.Collections.Generic;
using UnityEngine;
public abstract class StateController : MonoBehaviour
{
    protected Dictionary<int, State> stateDic;
    protected int currentState;

    public abstract void Init(int startState);

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
    public override void Init(int startState)
    {
        stateDic = new Dictionary<int, State>();

        stateDic.Add((int)EnemyState.FIND_ENEMY, new FindEnemy(this));
        stateDic.Add((int)EnemyState.LOCOMOTION, new Locomotion(this));
        stateDic.Add((int)EnemyState.ATTACK, new Attack(this));
        stateDic.Add((int)EnemyState.DEAD, new Dead(this));

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