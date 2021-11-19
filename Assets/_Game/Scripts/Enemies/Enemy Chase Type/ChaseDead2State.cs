
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseDead2State: ChaseBaseState
{
    ChaseEnemyManager ctx;

	public override void EnterState()
	{
		Debug.Log("Chase Dead");
		// ctx.animator.SetBool("isDead", true)
		if (ctx.deadEffect != null){
			Vector3 pos = ctx.transform.position + ctx.transform.up*0.2f;
			ParticleSystem effect = GameObject.Instantiate(ctx.deadEffect, pos, Quaternion.identity);
			effect.Play();
			GameObject.Destroy(effect.gameObject, 3f);
			// ctx.deadEffect.Play();
            for (int i = 0; i < 4; ++i){
                Vector2 randomPos = ctx.transform.position;
                randomPos += Random.insideUnitCircle*0.5f;
                GameObject.Instantiate(ctx.childPrefab, randomPos, Quaternion.identity);
            }
		}
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
