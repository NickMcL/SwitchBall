using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LerpPlatform : MonoBehaviour {
    Vector2 start;
    public Vector2 end;
    float startTime;
    public float duration = 2f;

    void Start()
    {
        start = (Vector2)this.transform.position;
        startTime = Time.time;
    }

    void Update() {
        float u = (Time.time - startTime) / duration;
        this.transform.position = Vector2.Lerp(start, end, (Time.time - startTime) / duration);
        
        if (u >= 1.0f)
        {
            Vector2 temp = end;
            end = start;
            start = temp;
            startTime = Time.time;
        }
    }
}
