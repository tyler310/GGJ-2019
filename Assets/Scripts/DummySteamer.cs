using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummySteamer : MonoBehaviour
{
    public delegate void OnSteamerDropCompleted();
    public event OnSteamerDropCompleted onSteamerDropCompleted;
    
    public bool collisionComplete = false;

    public int speed = 1;
    [SerializeField]
    private int maxDistance = 1;
    private Vector2 startPosition;
    private Vector2 newPosition;
    [SerializeField]
    private Rigidbody2D rigidbody;
    
    private bool isFalling = false;

    
    void Awake () {
        startPosition = transform.position;
        newPosition = transform.position;
//        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.gravityScale = 0;
    }
    
    void Update () {
        if (!isFalling)
        {
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
        rigidbody.gravityScale = 1;
    }
}
