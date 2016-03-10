using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GoScript : MonoBehaviour {
    float startTime;
	// Use this for initialization
	void Start () {
        startTime = Time.time;

	}
	
	// Update is called once per frame
	void Update () {
	    if (Time.time - startTime >= 1.0f)
        {
            Destroy(this.gameObject);
        }
	}
}
