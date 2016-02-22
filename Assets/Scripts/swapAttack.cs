using UnityEngine;
using System.Collections;

public class swapAttack : MonoBehaviour {
    public float bullet_speed;
    public Vector2 movement_vector;
    public int source_player_id;
    public GameManager.TeamType bullet_team;
    public float rotations_per_minute;

//	public PlayerManager _fromPlayer;
//	private PlayerManager _toPlayer;
//	private bool changed;

    Rigidbody2D rb;

    // Use this for initialization
    void Start() {
        rb = this.GetComponent<Rigidbody2D>();
        rotations_per_minute = 20f;
    }

    // Update is called once per frame
    void Update() {
        rb.velocity = movement_vector * bullet_speed;
        transform.Rotate(0, 0, 6.0f * rotations_per_minute * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.gameObject.tag == "Boundary") {
            Destroy(this.gameObject);
        }
        if (coll.gameObject.tag == "Player" &&
                coll.gameObject.GetComponent<PlayerManager>().player_id != source_player_id) {
            print("Hit player");
        }
    }


//		if (coll.gameObject.tag == "Player"&&!changed) {
//			_toPlayer = coll.gameObject.GetComponent<PlayerManager> ();
//			//hit itself return nothing
//			if (_toPlayer == _fromPlayer)
//				return;
//			changed = true; 
//			//if hit enemy
//			if (_toPlayer.Team != _fromPlayer.Team) {
//				//when it's 1v1v1v1 changes it to 1v3
//				if (GameManager.Instance.Mode == GameManager.gameType.FFA) {
//					GameManager.Instance.changeToOvT (_toPlayer);
//				} 
//				else {
//					_toPlayer.ChangeTeam (_fromPlayer.Team);
//					if(GameManager.Instance.Mode==GameManager.gameType.TvT){
//						
//						GameManager.Instance.Mode = GameManager.gameType.OvT;
//					}if (GameManager.Instance.Mode == GameManager.gameType.OvT) {
//						
//						//checkif there are 4 team
//						if(!GameManager.Instance.returnToFFA()){
//							GameManager.Instance.Mode = GameManager.gameType.TvT;
//						}
//					}
//				}
//			}
//			//if hit teammate
//			else {
//				//make teammate to enemy
//				if (_toPlayer.Team == GameManager.TeamType.A) 
//					_toPlayer.ChangeTeam (GameManager.TeamType.B);
//				
//
//				else _toPlayer.Team = GameManager.TeamType.A;
//
//				//change the gamemode
//				if (GameManager.Instance.Mode == GameManager.gameType.TvT) {
//					GameManager.Instance.Mode = GameManager.gameType.OvT;
//				} else GameManager.Instance.Mode = GameManager.gameType.TvT;
//			}
//
//			Destroy (this.gameObject);
//		}


}
