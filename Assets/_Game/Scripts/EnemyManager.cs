using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public event System.Action OnClear;
    int enemyCount;
    void Awake(){
        enemyCount = 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void UpdateCount(int value){
        enemyCount +=  value;
        if (enemyCount == 0){
            if (OnClear != null){
                OnClear();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
