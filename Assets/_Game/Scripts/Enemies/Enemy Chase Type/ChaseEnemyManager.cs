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

    void Awake()
	{
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
		InitState();
	}

	private void InitState()
	{
		wanderingState = new ChaseWanderState();
		wanderingState.SetContext(this);
		chasingState = new ChaseChaseState();
		chasingState.SetContext(this);
		deadState = new ChaseDeadState();
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
