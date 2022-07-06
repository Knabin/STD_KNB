using UnityEngine;

public class State
{
    protected StateController controller;

    public State(StateController controller)
    {
        this.controller = controller;
    }

    public virtual void Enter() {}
    public virtual void Update() {}
    public virtual void Exit() {}

}