using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Health : MonoBehaviour
{
    public event System.Action OnDeathTrigger;
    public float maxHP;
    float currentHP;
    public Slider hpUI;
    bool isDead;
    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
        UpdateUI();
        isDead = false;
    }

    public void UpdateHP(float value){
        currentHP += value;
        currentHP = Mathf.Min(currentHP, maxHP);
        if (currentHP <= 0f && !isDead){
            if (OnDeathTrigger != null){
                OnDeathTrigger();
            }
            isDead = true;
        }
        UpdateUI();
    }

    void UpdateUI(){
        if (hpUI)
            hpUI.value = currentHP/maxHP;
    }
}
