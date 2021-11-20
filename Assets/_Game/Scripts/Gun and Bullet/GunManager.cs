using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{
    public Gun[] guns;
    int currentGuns;
    Bullet bulletMain;
    // Start is called before the first frame update
    void Start()
    {
        currentGuns = 0;
        SetGun(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetGun(int index){
        guns[currentGuns].gameObject.SetActive(false);
        currentGuns = index;
        guns[currentGuns].gameObject.SetActive(true);
        SetBullet(bulletMain);
    }

    public void SetBullet(Bullet bullet){
        if (bullet == null) return;
        guns[currentGuns].bulletPrefab = bullet;
        bulletMain = bullet;
    }

    public bool ShootAtDirection(){
        return guns[currentGuns].ShootAtDirection();
    }
}
