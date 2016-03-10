using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class P3Score : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        this.GetComponent<Text>().text = PlayerPrefs.GetInt("p3score").ToString();
    }
}
