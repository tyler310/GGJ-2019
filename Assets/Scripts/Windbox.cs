using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Windbox : MonoBehaviour
{
    public AreaEffector2D windbox;
    public float variant;
    public float magnitude;
    
    void FixedUpdate()
    {
//        Mathf.Clamp(magnitude, 0, 20f);
        windbox.forceMagnitude = Mathf.Sin(Time.time * variant) * magnitude;
    }
}
