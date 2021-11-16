using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HPItem : MonoBehaviour
{
    public float value;
    public LayerMask target;
    public AudioClip sfx;
    // Start is called before the first frame update
    void Start()
    {
         transform.DOMoveY(0.3f, 0.5f).SetRelative(true).SetLoops(-1, LoopType.Yoyo);
        transform.DORotate(Vector3.up*90, 1f, RotateMode.Fast).SetRelative(true).SetLoops(-1, LoopType.Incremental);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){
        if (((1 << other.gameObject.layer) | target) == target){
            Health health = other.GetComponent<Health>();
            if (health){
                health.UpdateHP(value);
                PlaySound();
                Destroy(gameObject);
            }
        }
    }

    void PlaySound(){
        // GameObject go = Instantiate(typeof(GameObject), transform.position, Quaternion.identity);
        FindObjectOfType<AudioHitController>().Play(sfx);
    }
}
