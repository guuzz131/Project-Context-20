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
    public GameObject tekstWolk;
    public string[] AllText;
    public float waitTime;
    public string teacherNameStrng;
    public Sprite teacherImageSprite;

    private void Start()
    {
        teacherText.text = "";
        teacherImage.sprite = teacherImageSprite;
        teacherName.text = teacherNameStrng;
        tekstWolk.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            tekstWolk.SetActive(true);
            for (int i = 0; i < AllText.Length; i++)
            {
                StartCoroutine(NextTextCoroutine(waitTime * i, AllText[i]));
            }
            int a = AllText.Length * 3;
            Invoke("Stoptext", a);
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
    }
}
