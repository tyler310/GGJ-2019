using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Windbox : MonoBehaviour
{
    public AreaEffector2D windbox;
    public int variant;
    public int magnitude;
    void Awake()
    {
        
    }
    
    void FixedUpdate()
    {
        windbox.forceMagnitude = Mathf.Sin(Time.time * variant) * magnitude;
    }
}
