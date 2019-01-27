using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummySteamer : MonoBehaviour
{
    void Awake()
    {
        Collider2D collider = GetComponent<Collider2D>();
        float height = collider.bounds.size.y;
        Debug.Log(height);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Stack"))
        {
            gameObject.tag = "Stack";
        }
    }
}
