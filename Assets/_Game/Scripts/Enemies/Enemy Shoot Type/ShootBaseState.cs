using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShootBaseState  
{
    public abstract void EnterState();
    public abstract void UpdateState();
    public abstract void FixedUpdateState();
    public abstract void ExitState();
    public abstract void SetContext(EnemyShootManager _ctx);
}
