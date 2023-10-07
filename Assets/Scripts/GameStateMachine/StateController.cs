using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController 
{
    private GameState _currentState;
    private GameController _gameController;

    public StateController(GameController gameController)
    {
        _gameController = gameController;
    }

    public void ChangeState(GameState newState)
    {
        _currentState = newState;
        _currentState.EnterState();
    }

    public void UpdateState(bool active)
    {
        _currentState.UpdateState(active);
    }
}
