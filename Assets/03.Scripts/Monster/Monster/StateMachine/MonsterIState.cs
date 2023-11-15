using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface MonsterIState
{    public void Enter();
    public void Exit();
    public void HandleInput();
    public void Update();
    public void PhysicsUpdate();
}
