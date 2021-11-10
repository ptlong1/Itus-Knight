using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadShootState : ShootBaseState
{
	public override void EnterState()
	{
		Debug.Log("Shoot Dead");
	}

	public override void ExitState()
	{
	}

	public override void FixedUpdateState()
	{
	}

	public override void SetContext(EnemyShootManager _ctx)
	{
	}

	public override void UpdateState()
	{
	}
}
