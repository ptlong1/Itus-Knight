using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    EnemyManager enemyManager;
    // Start is called before the first frame update
    void Start()
    {
        enemyManager = FindObjectOfType<EnemyManager>();
        enemyManager.UpdateCount(1);
        GetComponent<Health>().OnDeathTrigger += OnDeathTrigger;
    }

    void OnDeathTrigger(){
        enemyManager.UpdateCount(-1);
    }

}
