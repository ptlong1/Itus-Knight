using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
public class GameOverController : MonoBehaviour
{
    CanvasGroup canvasGroup;
    // Start is called before the first frame update
    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        FindObjectOfType<PlayerDead>().GetComponent<Health>().OnDeathTrigger += OpenGameOverMenu;
    }

    void OpenGameOverMenu(){
        canvasGroup.DOFade(1f, 0.5f).From(0f).OnComplete(()=>canvasGroup.interactable = true);
    }
    
    public void RestartScene(){
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
