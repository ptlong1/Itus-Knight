using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chest_touch : MonoBehaviour
{
    public Sprite openedChest;
    public List<Object> dropItems;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            SpriteRenderer spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = openedChest;
            
            Destroy(this.gameObject.GetComponent<Collider2D>());
            Destroy(this.transform.GetChild(0).gameObject);

            //int random = Random.Range(0, dropItems.Count - 1);
            //Instantiate(dropItems[random], this.transform.position, this.transform.rotation);
        }    
    }
}
