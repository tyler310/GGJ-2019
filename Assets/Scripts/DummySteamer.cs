using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummySteamer : MonoBehaviour
{
    public delegate void OnSteamerDropCompleted();
    public event OnSteamerDropCompleted onSteamerDropCompleted;
    
    public float speed = 1;
    [SerializeField]
    private float maxDistance = 1;
    private Vector2 newPosition;
    [SerializeField]
    private Rigidbody2D rb2d;
    
    [SerializeField]
    private bool isFalling;
    private bool collisionComplete = false;
    
    void Awake () {
        newPosition = transform.position;
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.gravityScale = 0;
    }
    
    void Update () {
        if (!isFalling){
            newPosition.x = (maxDistance * Mathf.Sin(Time.time * speed));
            transform.position = newPosition;
        }
    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
        if (!collisionComplete && other.gameObject.CompareTag("Stack"))
        {            
            gameObject.tag = "Stack";
            
            if (onSteamerDropCompleted != null)
            {
                onSteamerDropCompleted();
                collisionComplete = true;
            }
        }
    }
        
    public void Drop() {
        isFalling = true;
        rb2d.gravityScale = 1;
    }
}
