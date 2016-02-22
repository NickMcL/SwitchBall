using UnityEngine;
using System.Collections;

public class Controls : MonoBehaviour {
	// Player 1 Axes
	const string kP1LeftHorizontal 	= "Player_1_Left_Joy_Horizontal";
	const string kP1LeftVertical 	= "Player_1_Left_Joy_Vertical";	
	const string kP1RightHorizontal = "Player_1_Right_Joy_Horizontal";
	const string kP1RightVertical 	= "Player_1_Right_Joy_Vertical";
	const string kP1LeftTrigger		= "Player_1_Left_Trigger";
	const string kP1RightTrigger	= "Player_1_Right_Trigger";

	// Player 1 Axes
	const string kMicP1LeftHorizontal 	= "Microsoft_1_Left_Joy_Horizontal";
	const string kMicP1LeftVertical 	= "Microsoft_1_Left_Joy_Vertical";	
	const string kMicP1RightHorizontal = "Microsoft_1_Right_Joy_Horizontal";
	const string kMicP1RightVertical 	= "Microsoft_1_Right_Joy_Vertical";
	const string kMicP1LeftTrigger		= "Microsoft_1_Left_Trigger";
	const string kMicP1RightTrigger	= "Microsoft_1_Right_Trigger";


	static public bool is_Microsoft = false;
	static public KeyCode[,] button_codes = {{
			KeyCode.Joystick1Button16,
			KeyCode.Joystick1Button17,
			KeyCode.Joystick1Button18,
			KeyCode.Joystick1Button19,
			KeyCode.Joystick1Button13,
			KeyCode.Joystick1Button14,
			KeyCode.Joystick1Button5,
			KeyCode.Joystick1Button6,
			KeyCode.Joystick1Button7,
			KeyCode.Joystick1Button8,
			KeyCode.Joystick1Button9,
			KeyCode.Joystick1Button10,
			KeyCode.Joystick1Button15,
			KeyCode.Joystick1Button11,
			KeyCode.Joystick1Button12
		}};

	static public KeyCode[,] windows_codes = {{
			KeyCode.Joystick1Button0,
			KeyCode.Joystick1Button1,
			KeyCode.Joystick1Button2,
			KeyCode.Joystick1Button3,
			KeyCode.Joystick1Button4,
			KeyCode.Joystick1Button5,
			KeyCode.Joystick1Button10,
			KeyCode.Joystick1Button11,
			KeyCode.Joystick1Button12,
			KeyCode.Joystick1Button13,
			KeyCode.Joystick1Button7,
			KeyCode.Joystick1Button6,
			KeyCode.Joystick1Button15,
			KeyCode.Joystick1Button8,
			KeyCode.Joystick1Button9
		}};


	static public string[,] axes_codes = {{
			kP1LeftHorizontal,
			kP1LeftVertical,
			kP1RightHorizontal,
			kP1RightVertical,
			kP1LeftTrigger,
			kP1RightTrigger
		}};

	static public string[,] axes_windows = {{
			kMicP1LeftHorizontal,
			kMicP1LeftVertical,
			kMicP1RightHorizontal,
			kMicP1RightVertical,
			kMicP1LeftTrigger,
			kMicP1RightTrigger
		},
		};


	// Players
	static public int player1 = 0;

	// Axes
	static public int axis_left_joy_hor = 0;
	static public int axis_left_joy_vert = 1;
	static public int axis_right_joy_hor = 2;
	static public int axis_right_joy_vert = 3;
	static public int axis_left_trigger = 4;
	static public int axis_right_trigger = 5;

	// Buttons
	static public int but_a = 0;
	static public int but_b = 1;
	static public int but_x = 2;
	static public int but_y = 3;
	static public int but_left_bumper = 4;
	static public int but_right_bumper = 5;
	static public int but_up = 6;
	static public int but_down = 7;
	static public int but_left = 8;
	static public int but_right = 9;
	static public int but_start = 10;
	static public int but_back = 11;
	static public int but_xbox = 12;
	static public int but_left_joy = 13;
	static public int but_right_joy = 14;

	static public int num_players = 1;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public static void SetMicrosoftMappings()
	{
		button_codes = windows_codes;
		axes_codes = axes_windows;
		is_Microsoft = true;
	} 
}
