using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SwipeCard : MonoBehaviour
{
    public GameObject closeButton;
    [SerializeField] private Image cardImage;
    [SerializeField] private TextMeshProUGUI minigameText;
    public float deltaValue=0.005f;
    public float maxTime = 1.72f;
    public float minTime = 1.5f;
    private float counter;
    private bool isDone;
    public GameObject interactObject;
    private bool isStartCount;
    Vector3 cardImagePosStart;
    Vector3 mousePos;
    Vector3 mouseStartPos;
    void Start()
    {
        cardImagePosStart = cardImage.rectTransform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDone)
            return;
        if (isStartCount)
        {
            counter += Time.deltaTime;
            mousePos = Input.mousePosition;
            Vector3 v = cardImage.rectTransform.anchoredPosition;
            v.z = 0;
            mousePos.z = 0;
            //print("V" + v);
            //print("mousePos"+mousePos);
            float f = (mouseStartPos.x - mousePos.x)* deltaValue;
            f = Mathf.Clamp(f, -30, 30);
            v.x -= f;
            cardImage.rectTransform.anchoredPosition = v;
            if (Time.frameCount % 12==0)
            {
                mouseStartPos = Input.mousePosition;
            }
            CheckCard();
        }
    }
    private void CheckCard()
    {
        Vector3 v = cardImage.rectTransform.anchoredPosition;
        if (v.x < -250)
        {
            v.x = -250;
        }
        else if(v.x>=250)
        {
            SoundManager.singleton.PlayButtonSound();
            if (counter >= maxTime)
            {
                minigameText.text = "TOO SLOW!";
                SoundManager.singleton.PlayWrongSound();
                isStartCount = false;
                ResetCard();
            }
            else if(counter<= minTime)
            {
                minigameText.text = "TOO FAST!";
                SoundManager.singleton.PlayWrongSound();
                isStartCount = false;
                ResetCard();
            }
            else if( counter > minTime && counter < maxTime)
            {
                minigameText.text = "DONE! Get a bluekey";
                SoundManager.singleton.PlayCorrectSound();
                StartCoroutine(WaitAndBlueKey());
                isDone = true;
                v.x = 250;
            }
        }
        cardImage.rectTransform.anchoredPosition =v;
    }
    public void OnClickCard()
    {
        if (isDone)
            return;
        isStartCount = true;
        mouseStartPos = Input.mousePosition;

    }
    public void OnCancleCard()
    {
        if (isDone)
            return;
        isStartCount = false;
        minigameText.text = "Cancelled";
        ResetCard();
    }
    private void ResetCard()
    {
        cardImage.rectTransform.localPosition = cardImagePosStart;
        counter = 0;
    }
    private IEnumerator WaitAndBlueKey()
    {
        interactObject.SetActive(false);
        closeButton.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        GameManager.singletion.AddKey(2);
        GameManager.singletion.interactionManager.RemoveInteract();
        CanvasSetting.singleton.DisableSwipeCard();
        yield return null;
    }
}
