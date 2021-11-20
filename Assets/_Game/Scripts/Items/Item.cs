using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public AudioClip sfx;
    public void PlaySound(){
        // GameObject go = Instantiate(typeof(GameObject), transform.position, Quaternion.identity);
        FindObjectOfType<AudioHitController>().Play(sfx);
    }
}
