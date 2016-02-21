using UnityEngine;
using System.Collections;

public class swapAttack : MonoBehaviour {
	private bool changed = false;
	private PlayerManager _fromPlayer;
	private PlayerManager _toPlayer;

	public PlayerManager FromPlayer{
		get{ return _fromPlayer;}
		set{ _fromPlayer = value;}
	}

	void OnCollisionEnter(Collision coll){
		if (coll.gameObject.tag == "Player"&&!changed) {
			_toPlayer = coll.gameObject.GetComponent<PlayerManager> ();
			//hit itself return nothing
			if (_toPlayer == _fromPlayer)
				return;
			changed = true; 
			//if hit enemy
			if (_toPlayer.Team != _fromPlayer.Team) {
				//when it's 1v1v1v1 changes it to 1v3
				if (GameManager.Instance.Mode == GameManager.gameType.FFA) {
					GameManager.Instance.changeToOvT (_toPlayer);
				} 
				else {
					_toPlayer.ChangeTeam (_fromPlayer.Team);
					if(GameManager.Instance.Mode==GameManager.gameType.TvT){
						
						GameManager.Instance.Mode = GameManager.gameType.OvT;
					}if (GameManager.Instance.Mode == GameManager.gameType.OvT) {
						
						//checkif there are 4 team
						if(!GameManager.Instance.returnToFFA()){
							GameManager.Instance.Mode = GameManager.gameType.TvT;
						}
					}
				}
			}
			//if hit teammate
			else {
				//make teammate to enemy
				if (_toPlayer.Team == GameManager.TeamType.A) 
					_toPlayer.ChangeTeam (GameManager.TeamType.B);
				

				else _toPlayer.Team = GameManager.TeamType.A;

				//change the gamemode
				if (GameManager.Instance.Mode == GameManager.gameType.TvT) {
					GameManager.Instance.Mode = GameManager.gameType.OvT;
				} else GameManager.Instance.Mode = GameManager.gameType.TvT;
			}

			Destroy (this.gameObject);
		}
			
	}
}
