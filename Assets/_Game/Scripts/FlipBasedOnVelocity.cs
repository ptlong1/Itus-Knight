using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipBasedOnVelocity : MonoBehaviour
{
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<SpriteRenderer>().flipX = GetComponent<Rigidbody2D>().velocity.x < 0;
    }
}
