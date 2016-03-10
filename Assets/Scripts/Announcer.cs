using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Announcer : MonoBehaviour {
    public static Announcer S;

    AudioSource sound;
    Queue<AudioClip> play_queue = new Queue<AudioClip>();
    bool close_game_announced;
    List<int> STREAKS = new List<int> { 10, 20, 30, 40, 50 };
    List<int> POINTS_TO_WIN = new List<int> { 5, 10, 20 };
    List<string> BALL_DROPPED_SOUDNS = new List<string> { "shutdown", "denied", "combo_broken", "buzzkill", "defeated" };

    void Awake() {
        S = this;
		sound = GetComponent<AudioSource>();
    }
    
	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this.gameObject);
        close_game_announced = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (sound.isPlaying) {
            return;
        }

        if (play_queue.Count > 0) {
            sound.PlayOneShot(play_queue.Dequeue());
        }
	}

	public void announceStreaks(PlayerManager pm, int spree) {
		int id = pm.GetComponent<PlayerManager>().player_id + 1;
		if (STREAKS.Contains(spree)) {
            print("AnnouncerSounds/p" + id + "_" + spree + "p_spree");
			play_queue.Enqueue(Resources.Load("AnnouncerSounds/p" + id + "_" + spree + "p_spree") as AudioClip);
		}
        if (POINTS_TO_WIN.Contains(GameManager.Instance.winning_score - pm.Score)) {
			play_queue.Enqueue(Resources.Load("AnnouncerSounds/p" + id + "_" +
                    (GameManager.Instance.winning_score - spree) + "p_to_win") as AudioClip);
        }
    }

    public void announceBallDropped() {
        play_queue.Enqueue(Resources.Load("AnnouncerSounds/" + 
            BALL_DROPPED_SOUDNS[Random.Range(0, BALL_DROPPED_SOUDNS.Count)]) as AudioClip);
    }

    public void announceCloseGame() {
        if (!close_game_announced) {
            play_queue.Enqueue(Resources.Load("AnnouncerSounds/close_game") as AudioClip);
            close_game_announced = true;
        }
    }

    public void announceWinner(int winner_id) {
        play_queue.Enqueue(Resources.Load("AnnouncerSounds/p" + winner_id + "_wins") as AudioClip);
    }

    public void announceStartCountdown() {
        play_queue.Enqueue(Resources.Load("AnnouncerSounds/lets_begin") as AudioClip);
    }
}
