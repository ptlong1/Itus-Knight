using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadShootState : ShootBaseState
{
	EnemyShootManager ctx;
	public override void EnterState()
	{
		Debug.Log("Shoot Dead");
		ctx.animator.SetBool("isDead", true);
	}

	public override void ExitState()
	{
	}

	public override void FixedUpdateState()
	{
	}

	public override void SetContext(EnemyShootManager _ctx)
	{
		ctx = _ctx;
	}

	public override void UpdateState()
	{
	}
}
