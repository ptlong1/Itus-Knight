using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseDeadState: ChaseBaseState
{
    ChaseEnemyManager ctx;

	public override void EnterState()
	{
		Debug.Log("Chase Dead");
		// ctx.animator.SetBool("isDead", true);
	}

	public override void ExitState()
	{
	}

	public override void FixedUpdateState()
	{
	}

	public override void SetContext(ChaseEnemyManager _ctx)
	{
        ctx = _ctx;      
	}

	public override void UpdateState()
	{
	}
}
