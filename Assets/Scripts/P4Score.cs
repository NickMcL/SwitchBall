using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class P4Score : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        this.GetComponent<Text>().text = PlayerPrefs.GetInt("p4score").ToString();
    }
}
