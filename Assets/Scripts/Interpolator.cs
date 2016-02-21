using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Interpolator : MonoBehaviour {
    public float            u;
    public List<GameObject> points;
    [Header("This is a header")]
    public float            pow = 1;
    public float            sinStrength = 0.2f;

	// Update is called once per frame
	void Update () {
        u = Time.time % 1.0f;
//        u = Mathf.Pow(u,pow);
//        u = 1 - Mathf.Pow(1-u, pow);
        u = u + Mathf.Sin(2*Mathf.PI*u) * sinStrength; 
        Vector3 p = Interp(u, points);
        this.transform.position = p;
	}

    Vector3 Interp(float u, List<GameObject> pS, int i0=0, int i1=-1) {
        if (i1 == -1) {
            i1 = pS.Count-1;
        }
        if (i0 == i1) return pS[i0].transform.position;
        Vector3 pL = Interp(u, pS, i0, i1-1);
        Vector3 pR = Interp(u, pS, i0+1, i1);
        Vector3 pLR = (1-u)*pL + u*pR;
        return pLR;
    }
}
