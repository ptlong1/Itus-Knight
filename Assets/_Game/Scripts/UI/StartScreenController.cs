using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class StartScreenController : MonoBehaviour
{
    [Header("Title Animation")]
    public RectTransform titlePivot;
    public TMP_Text title1;
    public TMP_Text title2;
    public RectTransform targetPosForTitle;
    Vector3 oldTitlePos;
    Vector3 oldTitleScale;

    [Header("Character Animation")]
    public Image charSprite;
    [Header("Audio")]
    public AudioSource bgm;
    public AudioSource sliceSFX;

    [Header("VFX")]
    public Transform trail;
    public ParticleSystem sparkles;
    public ParticleSystem textSpark;
    [Header("Menu")]
    public CanvasGroup menu;
    public CanvasGroup startScreen;
    public CanvasGroup mapSelection;
    [Header("Scene")]
    public string[] scenes;
    // Start is called before the first frame update
    void Start()
    {
        DOTween.defaultEaseType = Ease.InQuint;
        oldTitlePos = titlePivot.position;
        // oldTitlePos = Vector3.zero;
        oldTitleScale = titlePivot.localScale;
        mapSelection.gameObject.SetActive(false);
    }

    public void PlayTrigger(){
        mapSelection.gameObject.SetActive(true);
        startScreen.DOFade(0f, 0.2f).From(1f).OnComplete(() => startScreen.gameObject.SetActive(false));
        mapSelection.DOFade(1f, 0.5f).From(0f);
    }

    public void LoadScene(int index){
        SceneManager.LoadScene(scenes[index]);
    }

    void EnableMenu(){
        menu.DOFade(1f, 0.3f).From(0f);
    }

    void ChangeTitleColor(){
        title1.DOFade(0f, 0.5f).From(1f);
        title2.DOFade(1f, 0.5f).From(0f);
    }


    void TitleAnimation(){
        ChangeTitleColor();
        // titlePivot = oldTitleTransform;
        titlePivot.DOMove(targetPosForTitle.position, 0.5f).From(oldTitlePos);
        titlePivot.DOScale(0.8f, 0.5f).From(oldTitleScale).OnComplete(() => EnableMenu());
    }

    IEnumerator CR_CombineAnimation(){
        yield return new WaitForSeconds(0.5f);
        TitleAnimation();
        CharacterAnimation();
        sparkles?.Play();
    }

    void CharacterAnimation(){
        charSprite.DOFade(1f, 0.5f).From(0f);
        // charSprite.DOFillAmount(1f, 0.3f).From(0f);
        charSprite.rectTransform.DOMoveX(-3f, 0.3f).From(true);
    }

    void InitTitle(){
        var tmpColor = title1.color;
        tmpColor.a = 1f;
        title1.color = tmpColor;
        tmpColor = title2.color;
        tmpColor.a = 0f;
        title2.color = tmpColor;
        titlePivot.position = oldTitlePos;
        titlePivot.localScale = oldTitleScale;
        // trail.transform.position -= Vector3.right*30f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){
            InitTitle();
            // ChangeTitleColor();
            // TitleAnimation();
            FlashVerticle();
            PlayBGM();
        }
    }

    void FlashVerticle(){
        sliceSFX.Play();
        textSpark.Play();
        titlePivot.position = oldTitlePos;
        trail.DOMoveX(40f, 0.1f).SetRelative(true);
        titlePivot.GetComponent<CanvasGroup>().DOFade(1f, 0.5f).From(0f);
        titlePivot.DOMoveX(-1, 0.5f).From(true).OnComplete(() => StartCoroutine(CR_CombineAnimation()));
        // titlePivot.DOMoveX(-50, 0.5f).OnComplete(() => TitleAnimation());
    }

    void PlayBGM(){
        bgm.Play();
    }
}
