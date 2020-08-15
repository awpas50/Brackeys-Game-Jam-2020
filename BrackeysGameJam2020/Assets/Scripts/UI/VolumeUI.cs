using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeUI : MonoBehaviour
{
    private Image volumeUI;
    public Scrollbar scrollBar;
    public Sprite volume1;
    public Sprite volume2;
    public Sprite volume3;
    // Start is called before the first frame update
    void Start()
    {
        volumeUI = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(scrollBar.value >= 0.5f)
        {
            volumeUI.sprite = volume1;
        }
        else if (scrollBar.value > 0f)
        {
            volumeUI.sprite = volume2;
        }
        else if (scrollBar.value <= 0f)
        {
            volumeUI.sprite = volume3;
        }
    }
}
