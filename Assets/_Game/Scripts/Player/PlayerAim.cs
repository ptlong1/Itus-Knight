using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    Vector2 mousePosition;
    public Gun gun;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
	{
		Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		AimAtMouse(mousePosition);
        ShootAtMouse(mousePosition);
	}

	void AimAtMouse(Vector2 mousePosition)
	{
		if (mousePosition.x < transform.position.x)
		{
			// transform.localScale = new Vector3(-1, 1, 1);
            spriteRenderer.flipX = true;
		}
		else
		{
            spriteRenderer.flipX = false;
			// transform.localScale = new Vector3(1, 1, 1);
		}
        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - gun.transform.position;
        diff.Normalize();
 
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        gun.transform.rotation = Quaternion.Euler(0f, 0f, rot_z );
	}

    void ShootAtMouse(Vector2 mousePosition){
        if (Input.GetMouseButton(0)){
            Vector2 gunPosition = gun.transform.position;
            Vector2 dir = mousePosition - gunPosition;
            if (gun.ShootAtDirection(dir)){
                // rigidbody2D.AddForce(-gun.pullbackForce*dir,ForceMode2D.Impulse);
            };
        }
    }
}
