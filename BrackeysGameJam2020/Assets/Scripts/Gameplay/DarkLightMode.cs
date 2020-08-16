using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkLightMode : MonoBehaviour
{
    public bool darkLightMode = false;
    public GameObject darkLight;

    public GameObject[] endPointList;

    // Update is called once per frame
    public int loopValue = 0;
    void Update()
    {
        if(darkLightMode)
        {
            if(endPointList[loopValue] != null)
            {
                endPointList[loopValue].SetActive(true);
            }
            for (int i = 0; i < endPointList.Length; i++)
            {
                darkLight.SetActive(true);
            }
            
        }
        if (!darkLightMode)
        {
            for (int i = 0; i < endPointList.Length; i++)
            {
                if(endPointList[i] == null)
                {
                    return;
                }
                endPointList[i].SetActive(false);
                darkLight.SetActive(false);
            }
        }
    }
}
