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
        if (Input.anyKey && !call)
        {
            this.GetComponent<Text>().fontSize = 240;
            Announcer.S.announceStartCountdown();
            StartCoroutine(count());
        }
	
	}

    IEnumerator count() {
        call = true;
        while (start !=0) {
            this.gameObject.GetComponent<Text>().text = start.ToString();

            if (start == 1) {
                yield return new WaitForSeconds(0.4f);
            } else {
                yield return new WaitForSeconds(0.7f);
            }
            start--;
        }
        if (start == 0) SceneManager.LoadScene("Scene_Main");
    }
}
