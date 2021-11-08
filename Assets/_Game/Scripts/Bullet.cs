using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Vector2 moveDirection;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 deltaPosition = moveDirection.normalized*speed*Time.deltaTime;
        transform.position += new Vector3(deltaPosition.x, deltaPosition.y, 0f);
        transform.right = moveDirection.normalized;
    }

    public void SetDirection(Vector2 dir){
        moveDirection = dir;
    }
}
