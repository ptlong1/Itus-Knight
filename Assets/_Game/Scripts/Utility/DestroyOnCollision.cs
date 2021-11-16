using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    public LayerMask collisionMask;

    void Start(){
    }
    void OnCollisionEnter2D(Collision2D collision2D){
        Collider2D collider2D  =collision2D.collider;
        Debug.Log(collider2D.gameObject);
        if (((1 << collider2D.gameObject.layer) | collisionMask) == collisionMask){
            AudioHitController audioHit =  FindObjectOfType<AudioHitController>();
            audioHit.Play(audioHit.hitSFX);
            Destroy(gameObject);
        }
    }
}
