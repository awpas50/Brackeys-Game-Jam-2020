using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingShotLeft : MonoBehaviour
{
    public bool right;
    public float force;
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Box")
        {
            if(right)
            {
                other.GetComponent<Rigidbody2D>().velocity = Vector2.right * force;
            }
            else
            {
                other.GetComponent<Rigidbody2D>().velocity = Vector2.left * force;
            }
        }
    }
}
