using UnityEngine;
using System.Collections;

public class OddBall : MonoBehaviour {

    public static OddBall Instance;

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
        Vector3 pos = new Vector3(0f, 0f, 0f);
        this.transform.position = pos;
        this.BelongTo = null;
        this.GetComponent<CircleCollider2D>().enabled = true;

    }
    public void OnHitPlayer(PlayerManager pm) {
        OddBall.Instance.BelongTo = pm;
        OddBall.Instance.transform.SetParent(pm.gameObject.transform);
        OddBall.Instance.GetComponent<CircleCollider2D>().enabled = false;
        OddBall.Instance.transform.localPosition = new Vector3(-0.1f, 4.5f, 0f);
    }

    void setupColor() {
        if (BelongTo == null || GameManager.Instance.Mode == GameManager.gameType.FFA) {
            this.GetComponent<SpriteRenderer>().color = TeamColors.NO_TEAM;
        } else {
            this.GetComponent<SpriteRenderer>().color = TeamColors.TEAM_COLOR_MAP[BelongTo.Team];
        }
    }

}
