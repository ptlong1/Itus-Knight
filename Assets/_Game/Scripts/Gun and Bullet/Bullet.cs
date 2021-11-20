using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Vector2 moveDirection;
    public float speed;
    public ParticleSystem hitEffect;
    AudioSource audioSource;
    Rigidbody2D rigidbody2D;
    public Vector2 oldDirection;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Vector2 deltaPosition = moveDirection.normalized*speed*Time.deltaTime;
        // transform.position += new Vector3(deltaPosition.x, deltaPosition.y, 0f);
        // transform.right = moveDirection.normalized;
        rigidbody2D.velocity = moveDirection.normalized*speed;
        transform.right = moveDirection.normalized;
        oldDirection = moveDirection.normalized;
    }

    public void SetDirection(Vector2 dir){
        moveDirection = dir;
    }

    void OnCollisionEnter2D(Collision2D collision2D){
        // audioSource.Play();
        TriggerHitEffect(collision2D.contacts[0].point);
    }

    void TriggerHitEffect(Vector3 point){
        if (hitEffect == null) return;
        ParticleSystem hit = Instantiate(hitEffect, point, Quaternion.identity);
        Destroy(hit.gameObject, 0.5f);
    }
}
