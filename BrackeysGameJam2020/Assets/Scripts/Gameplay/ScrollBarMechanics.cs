using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollBarMechanics : MonoBehaviour
{
    public Image redImage;
    public Scrollbar scrollBar;

    // Update is called once per frame
    void Update()
    {
        // Visual
        scrollBar.value = redImage.fillAmount;
    }
}
