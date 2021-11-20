using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BarDoor : MonoBehaviour
{
    bool isOpen;
    public GameObject doorClose;
    public GameObject doorOpen;
    public string nextScene;

    // Start is called before the first frame update
    void Start()
    {
        isOpen = true;
        doorClose.SetActive(false);
        doorOpen.SetActive(true);
        GetComponent<Collider2D>().isTrigger = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!isOpen) return;
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Debug.Log("Activate");
            SceneManager.LoadScene(nextScene);
        }
    }
}
