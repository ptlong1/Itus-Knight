using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ChaseBaseState  
{
    public abstract void EnterState();
    public abstract void UpdateState();
    public abstract void FixedUpdateState();
    public abstract void ExitState();
    public abstract void SetContext(ChaseEnemyManager ctx);
}
