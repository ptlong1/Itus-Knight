using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class EnemyShootManager : MonoBehaviour
{
    ShootBaseState currentState;
    public ShootBaseState wanderingState;
    public ShootBaseState shootingState;
    public ShootBaseState deadState;

    public int shootType;

    public float wanderSpeed;
    [HideInInspector]
     public Rigidbody2D rigidbody;
    [HideInInspector]
    public Animator animator;
    public float detectRange;
    public LayerMask targetLayer;
    public Transform currentTarget;
    public Gun gun; 
    public int numberBulletPerRound;
    Health health;
    public ParticleSystem deadEffect;
    public AudioClip dieSFX;
    void Awake()
	{
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        health = GetComponent<Health>();
        health.OnDeathTrigger += OnDeath;
		InitState();
	}

	private void InitState()
	{
		wanderingState = new WanderShootState();
		wanderingState.SetContext(this);
        if (shootType == 0){
            shootingState = new ShootShootState();
        }
        else if(shootType == 1){
            shootingState = new ShootShoot2State();
        }
		shootingState.SetContext(this);
		deadState = new DeadShootState();
		deadState.SetContext(this);
	}

	// Start is called before the first frame update
	void Start()
    {
        currentState = wanderingState;
        currentState.EnterState();
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState();
    }

    void FixedUpdate(){
        currentState.FixedUpdateState();
    }

    public void SwitchState(ShootBaseState state){
        currentState.ExitState();
        currentState = state;
        currentState.EnterState();
    }

    void OnDeath(){
        SwitchState(deadState);
        FindObjectOfType<AudioHitController>().Play(dieSFX);
        Destroy(gameObject, 0f);
    }
}
