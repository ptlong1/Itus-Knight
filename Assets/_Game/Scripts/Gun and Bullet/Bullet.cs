using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Vector2 moveDirection;
    public float speed;
    public ParticleSystem hitEffect;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 deltaPosition = moveDirection.normalized*speed*Time.deltaTime;
        transform.position += new Vector3(deltaPosition.x, deltaPosition.y, 0f);
        transform.right = moveDirection.normalized;
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
