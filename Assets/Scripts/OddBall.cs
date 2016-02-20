using UnityEngine;
using System.Collections;

public class OddBall : MonoBehaviour {

	public static OddBall Instance;

	private PlayerManager _belongTo;

	public PlayerManager BelongTo{
		get{return _belongTo;}
		set{ _belongTo = value;}
		
	}

	void Awake(){
		Instance = this;
	}


}
