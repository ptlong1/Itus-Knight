using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Damagable : MonoBehaviour
{
    public LayerMask takeDamageLayer;
    Health health;

    void Awake(){
        health = GetComponent<Health>();
        // Debug.Log((int)takeDamageLayer);
    }
    void OnCollisionEnter2D(Collision2D collision){
        Collider2D collider = collision.collider;
        DealDamage damage = collider.GetComponent<DealDamage>();
        // Debug.Log("Collide" + collider.gameObject);
        if (damage == null) return;
        // Debug.Log("Have DealDamage");
        int t = collider.gameObject.layer | takeDamageLayer;

        // Debug.Log("Layer: " + t);

        if (((1 << collider.gameObject.layer) | takeDamageLayer) == takeDamageLayer){
            // Debug.Log("LayerMask");
            health.UpdateHP(-damage.damage);
        }
    }
}
