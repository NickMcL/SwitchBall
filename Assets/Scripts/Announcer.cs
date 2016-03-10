using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Announcer : MonoBehaviour {
	public List<PlayerManager> players;
	public GameObject player;
	AudioSource sound;
	// Use this for initialization
	void Start () {
		players = GameManager.Instance.players;
		sound = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		/*foreach (PlayerManager pm in players) {
			if (pm.currentStreak == 10) {
				int id = pm.GetComponent<PlayerManager> ().player_id + 1;
				print ("AnnouncerSounds/p" + id + "_10p_spree");

				sound.PlayOneShot(Resources.Load("AnnouncerSounds/p" + id + "_10p_spree") as AudioClip);
			}
			if (pm.currentStreak == 20) {
				sound.PlayOneShot(Resources.Load("AnnouncerSounds/p" + pm.GetComponent<PlayerManager>().player_id + 1 + "_20p_spree") as AudioClip);
			}
			if (pm.currentStreak == 30) {
				sound.PlayOneShot(Resources.Load("AnnouncerSounds/p" + pm.GetComponent<PlayerManager>().player_id + 1 + "_30p_spree") as AudioClip);
			}
			if (pm.currentStreak == 40) {
				sound.PlayOneShot(Resources.Load("AnnouncerSounds/p" + pm.GetComponent<PlayerManager>().player_id + 1 + "_40p_spree") as AudioClip);
			}
			if (pm.currentStreak == 50) {
				sound.PlayOneShot(Resources.Load("AnnouncerSounds/p" + pm.GetComponent<PlayerManager>().player_id + 1 + "_50p_spree") as AudioClip);
			}
		}
		*/
	}
	public void AnnouncerStreak(PlayerManager pm, int points) {
		int id = pm.GetComponent<PlayerManager> ().player_id + 1;
		if ((points == 10) || (points == 20) || (points == 30) || (points == 40) || (points == 50)) {
			sound.PlayOneShot (Resources.Load ("AnnouncerSounds/p" + id + "_" + points + "p_spree") as AudioClip);
		}
	}
}
