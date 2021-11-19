
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootShoot2State : ShootBaseState
{
    EnemyShootManager ctx;
    Coroutine cr_Shoot;
	public override void EnterState()
	{
        Debug.Log("Enter Shoot State");
        ctx.animator.SetBool("isRunning", false);
        cr_Shoot = ctx.StartCoroutine(CR_Shoot());
	}

    IEnumerator CR_Shoot(){
        while (true){
            yield return ctx.StartCoroutine(Shoot());
            yield return new WaitForSeconds(2f);
            if (!SearchForPlayer()){
                break;
            }
        }
    }

    IEnumerator Shoot(){
        for (int i = 0; i < ctx.numberBulletPerRound; ++i){
            float rad = i*2f*Mathf.PI/ctx.numberBulletPerRound;
            Vector2 dir = new Vector2(Mathf.Cos(rad), Mathf.Sin(rad));
            ctx.gun.ShootAtDirection(dir);
            yield return new WaitForSeconds(0.1f);
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
    bool SearchForPlayer(){
        Collider2D target = Physics2D.OverlapCircle(ctx.transform.position, ctx.detectRange, ctx.targetLayer);
        if (target != null){
            ctx.currentTarget = target.transform;
            return true;
        }else
        {
            ctx.currentTarget = null;
            ctx.SwitchState(ctx.wanderingState);
            return false;
        }
    }
}
