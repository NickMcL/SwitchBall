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
        print(InputManager.Devices[0].Meta);
        if (player < InputManager.Devices.Count) {
            return InputManager.Devices[player].LeftStickX.Value;
        }
        return 0f;
    }

    public float getRightStickX(int player) {
        //return Input.GetAxis("Microsoft_" + (player + 1) + "_Right_Joy_Horizontal");
        if (player < InputManager.Devices.Count) {
            return InputManager.Devices[player].RightStickX.Value;
        }
        return 0f;
    }

    public float getRightStickY(int player) {
        //return Input.GetAxis("Microsoft_" + (player + 1) + "_Right_Joy_Vertical");
        if (player < InputManager.Devices.Count) {
            return InputManager.Devices[player].RightStickY.Value;
        }
        return 0f;
    }

    public bool rightBumperPressed(int player) {
        //return Input.GetAxis("Microsoft_" + (player + 1) + "_Right_Trigger");
        if (player < InputManager.Devices.Count) {
            return InputManager.Devices[player].RightBumper.IsPressed;
        }
        return false;
    }

    public bool leftBumperPressed(int player) {
        //return Input.GetAxis("Microsoft_" + (player + 1) + "_Left_Trigger");
        if (player < InputManager.Devices.Count) {
            return InputManager.Devices[player].LeftBumper.IsPressed;
        }
        return false;
    }
}
