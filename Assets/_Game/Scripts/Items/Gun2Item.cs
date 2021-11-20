using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun2Item : Item
{
    public int gunIndex;

    void OnTriggerEnter2D(Collider2D other){
        GunManager gun = other.GetComponentInChildren<GunManager>();
        gun.SetGun(gunIndex);
        PlaySound();
        Destroy(gameObject);
    }
}
