using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    public int numberOfBounce;
    int currentNumber;
    public LayerMask bounceOnLayer;
    Bullet bullet;
    // Start is called before the first frame update
    void Start()
    {
        currentNumber = numberOfBounce;
        bullet = GetComponent<Bullet>();
    }


    void OnCollisionEnter2D(Collision2D collision2D){
        Collider2D collider = collision2D.collider;
        int layer = collider.gameObject.layer;
        if (numberOfBounce > 0){
            if (((1 << layer) | bounceOnLayer) == bounceOnLayer){
                numberOfBounce--;
                Vector2 dir = Vector2.Reflect(bullet.oldDirection, collision2D.contacts[0].normal);
                bullet.SetDirection(dir);
                return;
            }
        }
        Destroy(gameObject);
    }
}
