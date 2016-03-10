using UnityEngine;
using System.Collections;
using InControl;

public class GamePadInput : MonoBehaviour {
    public static GamePadInput S;

    void Awake() {
        S = this;	
    }

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public float getLeftStickX(int player) {
        //return Input.GetAxis("Microsoft_" + (player + 1) + "_Left_Joy_Horizontal");
        return InputManager.Devices[player].LeftStickX.Value;
    }

    public float getRightStickX(int player) {
        //return Input.GetAxis("Microsoft_" + (player + 1) + "_Right_Joy_Horizontal");
        return InputManager.Devices[player].RightStickX.Value;
    }

    public float getRightStickY(int player) {
        //return Input.GetAxis("Microsoft_" + (player + 1) + "_Right_Joy_Vertical");
        return InputManager.Devices[player].RightStickY.Value;
    }

    public bool rightBumperPressed(int player) {
        //return Input.GetAxis("Microsoft_" + (player + 1) + "_Right_Trigger");
        return InputManager.Devices[player].RightBumper.IsPressed;
    }

    public bool leftBumperPressed(int player) {
        //return Input.GetAxis("Microsoft_" + (player + 1) + "_Left_Trigger");
        return InputManager.Devices[player].LeftBumper.IsPressed;
    }
}
