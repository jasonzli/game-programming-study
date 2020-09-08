using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeClassState : MonoBehaviour
{
    private CubeState _state;
    // Start is called before the first frame update
    void Start()
    {
        _state = new IdleState();
        _state.Enter();
    }

    // Update is called once per frame
    void Update()
    {
        _state.Update();
    }
}

public class State
{
    public virtual void Enter() {}
    public virtual void Exit() {}
}