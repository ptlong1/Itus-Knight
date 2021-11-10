using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public event System.Action OnDeathTrigger;
    public float maxHP;
    float currentHP;
    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
    }

    public void UpdateHP(float value){
        currentHP += value;
        currentHP = Mathf.Min(currentHP, maxHP);
        if (currentHP <= 0f){
            if (OnDeathTrigger != null){
                OnDeathTrigger();
            }
        }
    }

}
