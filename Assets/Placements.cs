using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Placements : MonoBehaviour {
    public Sprite[] playerSprites;
    int[] playerScores;

	// Use this for initialization
	void Start () {
        playerScores[0] = PlayerPrefs.GetInt("p1score");
        playerScores[1] = PlayerPrefs.GetInt("p2score");
        playerScores[2] = PlayerPrefs.GetInt("p3score");
        playerScores[3] = PlayerPrefs.GetInt("p4score");
        
        int first = PlayerPrefs.GetInt("winner");

        List<int> losers = new List<int>();
        for(int i = 0; i <= 3; i++)
        {
            if (i != first) {
                losers.Add(i);
            }
        }

        for (int i = 0; i <= 2; i++)
        {
            for (int j = i+1; j <= 2; j++)
            {
                if (losers[j] > losers[i]) {
                    int temp = losers[i];
                    losers[i] = losers[j];
                    losers[j] = temp;
                }
            }
        }

        this.transform.FindChild("1stPlace").GetComponent<SpriteRenderer>().sprite = playerSprites[first];
        this.transform.FindChild("2ndPlace").GetComponent<SpriteRenderer>().sprite = playerSprites[losers[0]];
        this.transform.FindChild("3rdPlace").GetComponent<SpriteRenderer>().sprite = playerSprites[losers[1]];
        this.transform.FindChild("4thPlace").GetComponent<SpriteRenderer>().sprite = playerSprites[losers[2]];
	}
}
