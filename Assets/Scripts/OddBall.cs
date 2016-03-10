using UnityEngine;
using System.Collections;

public class OddBall : MonoBehaviour {
    public GameObject burstPrefab;

    public Vector3[] spawnLocations;

    public static OddBall Instance;

    public GameObject playerColliderObject;
    
	CircleCollider2D playerCollider;

    private PlayerManager _belongTo;

    public PlayerManager BelongTo {
        get { return _belongTo; }
        set { _belongTo = value; }

    }

    void Awake() {
        Instance = this;
        Initial();
    }

    void Update() {
        setupColor();
    }

    public void Initial() {
        this.transform.SetParent(null);
        //Vector3 pos = new Vector3(0f, 0f, 0f);
        Vector3 pos = spawnLocations[Random.Range(0, spawnLocations.Length)];
        this.transform.position = pos;
        this.BelongTo = null;
        this.GetComponent<CircleCollider2D>().enabled = true;
		this.transform.GetChild(0).GetComponent<CircleCollider2D> ().enabled = true;

        GameObject burst = Instantiate(burstPrefab) as GameObject;
        burst.GetComponent<Transform>().position = pos;


    }

    public void OnHitPlayer(PlayerManager pm) {
        OddBall.Instance.BelongTo = pm;
        OddBall.Instance.transform.SetParent(pm.gameObject.transform);
        OddBall.Instance.GetComponent<CircleCollider2D>().enabled = false;

		this.transform.GetChild(0).GetComponent<CircleCollider2D> ().enabled = false;

        OddBall.Instance.transform.localPosition = new Vector3(-0.1f, 4.5f, 0f);
		AudioSource GrabGold = this.GetComponent<AudioSource>();
		GrabGold.Play();

    }

    void setupColor() {
        /*if (BelongTo == null || GameManager.Instance.Mode == GameManager.gameType.FFA) {
            this.GetComponent<SpriteRenderer>().color = TeamColors.NO_TEAM;
        } else {
            this.GetComponent<SpriteRenderer>().color = TeamColors.TEAM_COLOR_MAP[BelongTo.Team];
        }*/
    }

}
