using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Bullet bulletPrefab;
    public Transform gunHead;
    public float pullbackForce;
    public float delayTime;
    float currentDelayTime;
    void Update(){
        if (currentDelayTime > 0){
            currentDelayTime -= Time.deltaTime;
        }
    }

    public bool ShootAtDirection(Vector2 dir){
        if (CanShoot()){
            Bullet bullet = Instantiate(bulletPrefab, gunHead.position, Quaternion.identity);
            bullet.SetDirection(dir);
            return true;
        }
        return false;
    }

    bool CanShoot(){
        if (currentDelayTime <= 0){
            currentDelayTime = delayTime;
            return true;
        }
        return false;
    }
}
