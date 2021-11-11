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
    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
        UpdateUI();
    }

    public void UpdateHP(float value){
        currentHP += value;
        currentHP = Mathf.Min(currentHP, maxHP);
        if (currentHP <= 0f){
            if (OnDeathTrigger != null){
                OnDeathTrigger();
            }
        }
        UpdateUI();
    }

    void UpdateUI(){
        if (hpUI)
            hpUI.value = currentHP/maxHP;
    }
}
