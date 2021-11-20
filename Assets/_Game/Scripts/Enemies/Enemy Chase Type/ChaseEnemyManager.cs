using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseEnemyManager : MonoBehaviour
{
    ChaseBaseState currentState;
    public ChaseBaseState wanderingState;
    public ChaseBaseState chasingState;
    public ChaseBaseState deadState;

    public float wanderSpeed;
    public float runSpeed;
    [HideInInspector]
     public Rigidbody2D rigidbody;
    [HideInInspector]
    public Animator animator;
    public float detectRange;
    public LayerMask targetLayer;
    public Transform currentTarget;
    Health health;
    public ParticleSystem deadEffect;
    public AudioClip dieSFX;
    public int deathType;
    public GameObject childPrefab;
    void Awake()
	{
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        health = GetComponent<Health>();
        health.OnDeathTrigger += OnDeath;
		InitState();
	}
    void OnDeath(){
        SwitchState(deadState);
        FindObjectOfType<AudioHitController>().Play(dieSFX);
        Destroy(gameObject, 0f);
    }

	private void InitState()
	{
		wanderingState = new ChaseWanderState();
		wanderingState.SetContext(this);
		chasingState = new ChaseChaseState();
		chasingState.SetContext(this);
        if (deathType == 0){
            deadState = new ChaseDeadState();
        }
        else if (deathType == 1){
            deadState = new ChaseDead2State();
        }
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

    public void SwitchState(ChaseBaseState state){
        currentState.ExitState();
        currentState = state;
        currentState.EnterState();
    }
}
