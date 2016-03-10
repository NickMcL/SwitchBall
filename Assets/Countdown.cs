using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Countdown : MonoBehaviour {
    int start = 3;	// Use this for initialization
    bool call = false;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKey&&!call)
        {   
            StartCoroutine(count());
        }
	
	}

    IEnumerator count() {
        call = true;
        while (start !=-1) {
           
            Debug.Log(start);
           
            if(start==0)
                this.gameObject.GetComponent<Text>().text = "Ready";
            else this.gameObject.GetComponent<Text>().text = start.ToString();

            yield return new WaitForSeconds(1);
            start--;



        }
        if (start == -1)
            SceneManager.LoadScene("Scene_Main");
    }
}
