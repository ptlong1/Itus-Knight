using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Bullet bulletPrefab;
    public Transform[] gunHeads;
    public float pullbackForce;
    public float delayTime;
    float currentDelayTime;
    public ParticleSystem flashPrefab;
    AudioSource gunShoot;

    void Awake(){
        gunShoot = GetComponent<AudioSource>();
    }
    void Update(){
        if (currentDelayTime > 0){
            currentDelayTime -= Time.deltaTime;
        }
    }

    public bool ShootAtDirection(Vector2 dir){
        if (CanShoot()){
            foreach(Transform gunHead in gunHeads){
                Bullet bullet = Instantiate(bulletPrefab, gunHead.position, Quaternion.identity);
                bullet.SetDirection(dir);
                Flash(gunHead.position);
            }
            gunShoot?.Play();
            return true;
        }
        return false;
    }
    public bool ShootAtDirection(){
        if (CanShoot()){
            foreach(Transform gunHead in gunHeads){
                Bullet bullet = Instantiate(bulletPrefab, gunHead.position, Quaternion.identity);
                bullet.SetDirection(gunHead.right);
                Flash(gunHead.position);
            }
            gunShoot?.Play();
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

    void Flash(Vector2 position){
        if (flashPrefab == null) return;
        ParticleSystem flash = Instantiate(flashPrefab, position, Quaternion.identity);
        flash.transform.parent = transform;
        Destroy(flash.gameObject, 0.2f);
    }
}
