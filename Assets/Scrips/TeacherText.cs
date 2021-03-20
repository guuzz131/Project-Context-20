using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeacherText : MonoBehaviour
{
    public Text teacherText;
    public Text teacherName;
    public Image teacherImage;
    public Image textWolk;
    public GameManager gameManager;
    public GameObject tekstWolk;
    public string[] allText;
    public string[] textAfterFinish;
    public float waitTime;
    public string teacherNameStrng;
    public Sprite teacherImageSprite;
    public int gameStatePosition;
    public bool isVictor;

    private bool hasTalked = false;
    private bool hasTalked2 = false;
    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        teacherText.text = "";
        teacherImage.sprite = teacherImageSprite;
        teacherName.text = teacherNameStrng;
        tekstWolk.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            if (gameManager.currentState == gameStatePosition && !hasTalked)
            {
                tekstWolk.SetActive(true);
                for (int i = 0; i < allText.Length; i++)
                {
                    StartCoroutine(NextTextCoroutine(waitTime * i, allText[i]));
                }
                float a = allText.Length * waitTime;
                Invoke("Stoptext", a);
                hasTalked = true;
            } else if (gameManager.currentState == gameStatePosition + 1 && !hasTalked2 && !isVictor)
            {
                tekstWolk.SetActive(true);
                for (int i = 0; i < textAfterFinish.Length; i++)
                {
                    StartCoroutine(NextTextCoroutine(waitTime * i, textAfterFinish[i]));
                }
                float a = allText.Length * waitTime;
                Invoke("Stoptext", a);
                hasTalked2 = true;
            }
            
        }
    }

    IEnumerator NextTextCoroutine(float seconds, string text)
    {

        yield return new WaitForSeconds(seconds);
        NewText(text);
    }

    private void NewText(string text)
    {
        teacherText.text = text;
    }
    private void Stoptext()
    {
        tekstWolk.SetActive(false);
        teacherText.text = "";
        if (hasTalked2)
        {
            gameManager.updateGameStatebool = true;
        }
    }
}
