using UnityEngine;
using System.Collections;

public class BurstSpawn : MonoBehaviour {
    int x = 0;
	
	// Update is called once per frame
	void FixedUpdate () {
        if (x == 30) Destroy(this.gameObject);
        if (x % 5 == 0) this.gameObject.GetComponent<Renderer>().enabled = !this.gameObject.GetComponent<Renderer>().enabled;
        x++;
    }
}
