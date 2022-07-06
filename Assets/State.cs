using UnityEngine;

public abstract class State
{
    protected GameObject rootObject;

    public void SetRootObject(GameObject root)
    {
        rootObject = root;
    }

    public abstract void Enter();
    public abstract void Update();
    public abstract void Exit();

}