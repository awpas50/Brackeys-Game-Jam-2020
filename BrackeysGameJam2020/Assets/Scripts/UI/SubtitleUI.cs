using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SubtitleUI : MonoBehaviour
{
    public bool subtitleState = true;
    GameObject[] allSubtitle;

    public Sprite sprite1;
    public Sprite sprite2;

    private void Start()
    {
        allSubtitle = GameObject.FindGameObjectsWithTag("Subtitle");
    }
    void Update()
    {
        
        if (subtitleState)
        {
            for(int i = 0; i < allSubtitle.Length; i++)
            {
                allSubtitle[i].SetActive(true);
            }
        }
        if(!subtitleState)
        {
            for (int i = 0; i < allSubtitle.Length; i++)
            {
                allSubtitle[i].SetActive(false);
            }
        }
    }

    public void Click()
    {
        subtitleState = !subtitleState;
    }
    public void UISwitch()
    {
        if(subtitleState)
        {
            GetComponent<Image>().sprite = sprite2;
        }
        if (!subtitleState)
        {
            GetComponent<Image>().sprite = sprite1;
        }
    }
}
