using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraFollow : MonoBehaviour {
	float minX = Mathf.Infinity;
	float maxX = -Mathf.Infinity;
	float minY = Mathf.Infinity;
	float maxY = Mathf.Infinity;
	float minCamSize=8.0f;
	float cameraSpeed=1.5f;
	float camSize;
	float delay =0.05f;

	public bool zoom=false;
	static public CameraFollow Instance;
	public Camera cameraMain;
	public Transform cameraTx;
	public float camSpeed=5f;

	public Vector2 cameraBuffer=new Vector2(0,4);

	public static class CoroutineUtil
	{
		public static IEnumerator WaitForRealSeconds(float time)
		{
			float start = Time.realtimeSinceStartup;
			while (Time.realtimeSinceStartup < start + time)
			{
				yield return null;
			}
		}
	}
	// Use this for initialization
	void Awake () {
		Instance = this;
		cameraMain = Camera.main;
		cameraTx = cameraMain.transform;
	}


	
	// Update is called once per frame
	void FixedUpdate () {
		if (!zoom) {
			calculateBound ();
			positionCamera ();
		}
	}

	void calculateBound(){
		bool alldown = true;
		foreach (GameObject player in GameManager.Instance.playeringame) {
			if (!player.GetComponent<PlayerManager>().death)
				alldown = false;	
		}
		if (alldown) {
			return;
		}
		minX = Mathf.Infinity;
		maxX = -Mathf.Infinity;
		minY = Mathf.Infinity;
		maxY = -Mathf.Infinity;

	foreach (GameObject player in GameManager.Instance.playeringame ) {
			
			Vector3 pos = player.transform.position;
			if (player.GetComponent<PlayerManager>().death)
				continue;
		
			if (pos.x < minX)
				minX = pos.x;
			if (pos.x > maxX)
				maxX = pos.x;
			if (pos.y < minY)
				minY = pos.y;
			if (pos.y > maxY)
				maxY = pos.y;
		}

	}
	float  positionCamera(){
		float sizeX, sizeY;
		Vector3 cameraPosition = Vector3.zero;

//		if (OddBall.Instance.BelongTo != null&& OddBall.Instance.BelongTo.gameObject.transform.position.y>-6) {
//			Vector3 oddpos = OddBall.Instance.BelongTo.gameObject.transform.position;
//			cameraPosition.x = oddpos.x;
//			cameraPosition.y = oddpos.y;	
//			cameraPosition.z = cameraTx.position.z;
//			sizeX = (maxX - oddpos.x) > (oddpos.x - minX) ? (maxX - oddpos.x) * 2.0f : (oddpos.x - minX) * 2.0f;
//			sizeY = (maxY - oddpos.y) > (oddpos.y - minY) ? (maxY - oddpos.y) * 2.0f : (oddpos.y - minY) * 2.0f;
//
//
//		} else {
			cameraPosition.x = (minX + maxX) / 2;
			cameraPosition.y = (minY + maxY) / 2;
			cameraPosition.z = cameraTx.position.z;
			sizeX = maxX - minX + cameraBuffer.x;
			sizeY = maxY - minY + cameraBuffer.y;

		//}

		transform.position = Vector3.Lerp (transform.position, cameraPosition, delay*cameraSpeed);



		camSize = (sizeX > sizeY ? sizeX : sizeY);
		if (camSize < minCamSize)
			camSize = minCamSize;
		cameraMain.orthographicSize = Mathf.Lerp(cameraMain.orthographicSize,camSize*0.6f,delay*cameraSpeed) ;
		return camSize * 0.6f;

	}


	IEnumerator focus(PlayerManager pm){
		zoom = true;
		Time.timeScale = 0.0f;
		Vector3 cameraPosition = Vector3.zero;
		while (true) {
			
			Vector3 pmpos = pm.gameObject.transform.position;
			cameraPosition.x = pmpos.x;
			cameraPosition.y = pmpos.y;
			cameraPosition.z = cameraTx.position.z;
			transform.position = Vector3.Lerp (transform.position, cameraPosition, delay);
			cameraMain.orthographicSize = Mathf.Lerp (cameraMain.orthographicSize, 2, delay);
			if (cameraMain.orthographicSize <= 2.1) {
				
				break;
			}
			yield return StartCoroutine(CoroutineUtil.WaitForRealSeconds(0.1f*delay));
		}
		while (true) {
			calculateBound ();
			positionCamera ();
		
			if (cameraMain.orthographicSize >= positionCamera ()-0.2) {
				Time.timeScale = 0.7f;
				zoom = false;
				yield break;

			} else
				
				yield return StartCoroutine(CoroutineUtil.WaitForRealSeconds(0.1f*delay));
		}

	}
	public void onHitOddBall(PlayerManager pm){
		StartCoroutine (focus (pm));
	}
}
