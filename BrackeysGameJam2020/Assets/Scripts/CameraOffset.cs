using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOffset : MonoBehaviour
{
    public float min;
    public float max;
    
    void Start()
    {
        //Camera.main.transform.position.y = Mathf.Clamp(min, max);
    }
    
    void Update()
    {
        
    }
}
