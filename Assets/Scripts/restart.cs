using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class restart : MonoBehaviour {
    private Text content;
    // Use this for initialization
    void Start() {
        content = this.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update() {
        float alphavalue = Mathf.Abs(Mathf.Sin(Time.time));
        Vector4 color = new Vector4(1.0f, 1.0f, 1.0f, alphavalue);
        content.color = color;
        if (Input.GetKeyDown(KeyCode.R)) {
            SceneManager.LoadScene("Scene_Main");
        }
    }
}
