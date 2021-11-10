using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderShootState : ShootBaseState
{
    EnemyShootManager ctx;
    Coroutine cr_RandomDirection;
    Vector2 direction;

	public override void EnterState()
	{
        cr_RandomDirection = ctx.StartCoroutine(CR_RandomDirection());
        ctx.animator.SetBool("isRunning", true);
	}

	public override void ExitState()
	{
        ctx.StopCoroutine(cr_RandomDirection);
        ctx.animator.SetBool("isRunning", false);
        ctx.rigidbody.velocity = Vector2.zero;
	}

	public override void FixedUpdateState()
	{
        ctx.rigidbody.velocity = direction*ctx.wanderSpeed;
	}

    IEnumerator CR_RandomDirection(){
        while (true){
            direction = RandomVector2();
            yield return new WaitForSeconds(2f);
        }
    }

	public override void SetContext(EnemyShootManager _ctx)
	{
        ctx = _ctx;      
	}
    Vector2 RandomVector2(){
        return Random.insideUnitCircle.normalized;
    }

	public override void UpdateState()
	{
        SearchForPlayer();
	}

    void SearchForPlayer(){
        Collider2D target = Physics2D.OverlapCircle(ctx.transform.position, ctx.detectRange, ctx.targetLayer);
        if (target != null){
            ctx.currentTarget = target.transform;
            ctx.SwitchState(ctx.shootingState);
        }
    }
}
