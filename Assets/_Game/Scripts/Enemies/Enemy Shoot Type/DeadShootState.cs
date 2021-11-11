using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadShootState : ShootBaseState
{
	EnemyShootManager ctx;
	public override void EnterState()
	{
		Debug.Log("Shoot Dead");
		// ctx.animator.SetBool("isDead", true);
		if (ctx.deadEffect != null){
			Vector3 pos = ctx.transform.position + ctx.transform.up*0.2f;
			ParticleSystem effect = GameObject.Instantiate(ctx.deadEffect, pos, Quaternion.identity);
			effect.Play();
			GameObject.Destroy(effect.gameObject, 3f);
			// ctx.deadEffect.Play();
		}
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
