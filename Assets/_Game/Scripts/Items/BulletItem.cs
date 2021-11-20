using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletItem : Item
{
    public Bullet bullet;
    void OnTriggerEnter2D(Collider2D other){
        GunManager gun = other.GetComponentInChildren<GunManager>();
        gun.SetBullet(bullet);
        PlaySound();
        Destroy(gameObject);
    }
}
