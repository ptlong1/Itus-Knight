using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropWhenDie : MonoBehaviour
{
    public GameObject item;
    public float probability;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Health>().OnDeathTrigger += DropItem;
    }

    void DropItem(){
        float t = Random.Range(0f, 1f);
        if (t <= probability){
            Instantiate(item, transform.position, Quaternion.identity);
            Debug.Log("Drop");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
