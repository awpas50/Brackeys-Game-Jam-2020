using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOffset : MonoBehaviour
{
    public float min;
    public float max;

    public float offset;
    GameObject player;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //Camera.main.transform.position.y = Mathf.Clamp(min, max);
    }

    private void Update()
    {
        transform.position = new Vector3(transform.position.x,
            Mathf.Clamp(player.transform.position.y, min, max),
            transform.position.z);
    }
}
