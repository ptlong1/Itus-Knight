using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseChaseState: ChaseBaseState
{    ChaseEnemyManager ctx;

	public override void EnterState()
	{
        ctx.animator.SetBool("isRunning", true);
	}

	public override void ExitState()
	{
        ctx.animator.SetBool("isRunning", false);
	}

	public override void FixedUpdateState()
	{
        Vector2 dir = ctx.currentTarget.position - ctx.transform.position;
        ctx.rigidbody.velocity = dir.normalized*ctx.runSpeed;
	}

	public override void SetContext(ChaseEnemyManager _ctx)
	{
        ctx = _ctx;      
	}

	public override void UpdateState()
	{
	}
}
