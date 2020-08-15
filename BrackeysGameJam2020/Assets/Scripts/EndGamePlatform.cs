using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGamePlatform : MonoBehaviour
{
    public float speed;
    public float maxHeight;
    void Update()
    {
        if(transform.position.y <= maxHeight)
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }
    }
}
