using UnityEngine;
using System.Collections;

public class Controls : MonoBehaviour {
	//MAC CONTROLS
	// Player 1 Axes
	const string kP1LeftHorizontal 	= "Player_1_Left_Joy_Horizontal";
	const string kP1LeftVertical 	= "Player_1_Left_Joy_Vertical";	
	const string kP1RightHorizontal = "Player_1_Right_Joy_Horizontal";
	const string kP1RightVertical 	= "Player_1_Right_Joy_Vertical";
	const string kP1LeftTrigger		= "Player_1_Left_Trigger";
	const string kP1RightTrigger	= "Player_1_Right_Trigger";

	// Player 2 Axes
	const string kP2LeftHorizontal 	= "Player_2_Left_Joy_Horizontal";
	const string kP2LeftVertical 	= "Player_2_Left_Joy_Vertical";
	const string kP2RightHorizontal = "Player_2_Right_Joy_Horizontal";
	const string kP2RightVertical 	= "Player_2_Right_Joy_Vertical";
	const string kP2LeftTrigger		= "Player_2_Left_Trigger";
	const string kP2RightTrigger	= "Player_2_Right_Trigger";


	// Player 3 Axes
	const string kP3LeftHorizontal 	= "Player_3_Left_Joy_Horizontal";
	const string kP3LeftVertical 	= "Player_3_Left_Joy_Vertical";	
	const string kP3RightHorizontal = "Player_3_Right_Joy_Horizontal";
	const string kP3RightVertical 	= "Player_3_Right_Joy_Vertical";
	const string kP3LeftTrigger		= "Player_3_Left_Trigger";
	const string kP3RightTrigger	= "Player_3_Right_Trigger";

	// Player 4 Axes
	const string kP4LeftHorizontal 	= "Player_4_Left_Joy_Horizontal";
	const string kP4LeftVertical 	= "Player_4_Left_Joy_Vertical";
	const string kP4RightHorizontal = "Player_4_Right_Joy_Horizontal";
	const string kP4RightVertical 	= "Player_4_Right_Joy_Vertical";
	const string kP4LeftTrigger		= "Player_4_Left_Trigger";
	const string kP4RightTrigger	= "Player_4_Right_Trigger";

	//PC CONTROLS
	// Player 1 Axes
	const string kMicP1LeftHorizontal 	= "Microsoft_1_Left_Joy_Horizontal";
	const string kMicP1LeftVertical 	= "Microsoft_1_Left_Joy_Vertical";	
	const string kMicP1RightHorizontal  = "Microsoft_1_Right_Joy_Horizontal";
	const string kMicP1RightVertical 	= "Microsoft_1_Right_Joy_Vertical";
	const string kMicP1LeftTrigger		= "Microsoft_1_Left_Trigger";
	const string kMicP1RightTrigger		= "Microsoft_1_Right_Trigger";

	// Player 2 Axes
	const string kMicP2LeftHorizontal 	= "Microsoft_2_Left_Joy_Horizontal";
	const string kMicP2LeftVertical 	= "Microsoft_2_Left_Joy_Vertical";
	const string kMicP2RightHorizontal 	= "Microsoft_2_Right_Joy_Horizontal";
	const string kMicP2RightVertical 	= "Microsoft_2_Right_Joy_Vertical";
	const string kMicP2LeftTrigger		= "Microsoft_2_Left_Trigger";
	const string kMicP2RightTrigger		= "Microsoft_2_Right_Trigger";

	// Player 3 Axes
	const string kMicP3LeftHorizontal 	= "Microsoft_3_Left_Joy_Horizontal";
	const string kMicP3LeftVertical 	= "Microsoft_3_Left_Joy_Vertical";	
	const string kMicP3RightHorizontal 	= "Microsoft_3_Right_Joy_Horizontal";
	const string kMicP3RightVertical 	= "Microsoft_3_Right_Joy_Vertical";
	const string kMicP3LeftTrigger		= "Microsoft_3_Left_Trigger";
	const string kMicP3RightTrigger		= "Microsoft_3_Right_Trigger";

	// Player 4 Axes
	const string kMicP4LeftHorizontal 	= "Microsoft_4_Left_Joy_Horizontal";
	const string kMicP4LeftVertical 	= "Microsoft_4_Left_Joy_Vertical";
	const string kMicP4RightHorizontal 	= "Microsoft_4_Right_Joy_Horizontal";
	const string kMicP4RightVertical 	= "Microsoft_4_Right_Joy_Vertical";
	const string kMicP4LeftTrigger		= "Microsoft_4_Left_Trigger";
	const string kMicP4RightTrigger		= "Microsoft_4_Right_Trigger";


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
		},
		{
			KeyCode.Joystick2Button16,
			KeyCode.Joystick2Button17,
			KeyCode.Joystick2Button18,
			KeyCode.Joystick2Button19,
			KeyCode.Joystick2Button13,
			KeyCode.Joystick2Button14,
			KeyCode.Joystick2Button5,
			KeyCode.Joystick2Button6,
			KeyCode.Joystick2Button7,
			KeyCode.Joystick2Button8,
			KeyCode.Joystick2Button9,
			KeyCode.Joystick2Button10,
			KeyCode.Joystick2Button15,
			KeyCode.Joystick2Button11,
			KeyCode.Joystick2Button12
		},
		{
			KeyCode.Joystick3Button16,
			KeyCode.Joystick3Button17,
			KeyCode.Joystick3Button18,
			KeyCode.Joystick3Button19,
			KeyCode.Joystick3Button13,
			KeyCode.Joystick3Button14,
			KeyCode.Joystick3Button5,
			KeyCode.Joystick3Button6,
			KeyCode.Joystick3Button7,
			KeyCode.Joystick3Button8,
			KeyCode.Joystick3Button9,
			KeyCode.Joystick3Button10,
			KeyCode.Joystick3Button15,
			KeyCode.Joystick3Button11,
			KeyCode.Joystick3Button12
		},
		{
			KeyCode.Joystick4Button16,
			KeyCode.Joystick4Button17,
			KeyCode.Joystick4Button18,
			KeyCode.Joystick4Button19,
			KeyCode.Joystick4Button13,
			KeyCode.Joystick4Button14,
			KeyCode.Joystick4Button5,
			KeyCode.Joystick4Button6,
			KeyCode.Joystick4Button7,
			KeyCode.Joystick4Button8,
			KeyCode.Joystick4Button9,
			KeyCode.Joystick4Button10,
			KeyCode.Joystick4Button15,
			KeyCode.Joystick4Button11,
			KeyCode.Joystick4Button12
		}
	};

	static public KeyCode[,] windows_codes = {
		{
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
		},
		{
			KeyCode.Joystick2Button0,
			KeyCode.Joystick2Button1,
			KeyCode.Joystick2Button2,
			KeyCode.Joystick2Button3,
			KeyCode.Joystick2Button4,
			KeyCode.Joystick2Button5,
			KeyCode.Joystick2Button10,
			KeyCode.Joystick2Button11,
			KeyCode.Joystick2Button12,
			KeyCode.Joystick2Button13,
			KeyCode.Joystick2Button7,
			KeyCode.Joystick2Button6,
			KeyCode.Joystick2Button15,
			KeyCode.Joystick2Button8,
			KeyCode.Joystick2Button9
		},
		{
			KeyCode.Joystick3Button0,
			KeyCode.Joystick3Button1,
			KeyCode.Joystick3Button2,
			KeyCode.Joystick3Button3,
			KeyCode.Joystick3Button4,
			KeyCode.Joystick3Button5,
			KeyCode.Joystick3Button10,
			KeyCode.Joystick3Button11,
			KeyCode.Joystick3Button12,
			KeyCode.Joystick3Button13,
			KeyCode.Joystick3Button7,
			KeyCode.Joystick3Button6,
			KeyCode.Joystick3Button15,
			KeyCode.Joystick3Button8,
			KeyCode.Joystick3Button9
		},
		{
			KeyCode.Joystick4Button0,
			KeyCode.Joystick4Button1,
			KeyCode.Joystick4Button2,
			KeyCode.Joystick4Button3,
			KeyCode.Joystick4Button4,
			KeyCode.Joystick4Button5,
			KeyCode.Joystick4Button10,
			KeyCode.Joystick4Button11,
			KeyCode.Joystick4Button12,
			KeyCode.Joystick4Button13,
			KeyCode.Joystick4Button7,
			KeyCode.Joystick4Button6,
			KeyCode.Joystick4Button15,
			KeyCode.Joystick4Button8,
			KeyCode.Joystick4Button9
		}
	};


	static public string[,] axes_codes = {
		{
			kP1LeftHorizontal,
			kP1LeftVertical,
			kP1RightHorizontal,
			kP1RightVertical,
			kP1LeftTrigger,
			kP1RightTrigger
		},
		{
			kP2LeftHorizontal,
			kP2LeftVertical,
			kP2RightHorizontal,
			kP2RightVertical,
			kP2LeftTrigger,
			kP2RightTrigger
		},
		{
			kP3LeftHorizontal,
			kP3LeftVertical,
			kP3RightHorizontal,
			kP3RightVertical,
			kP3LeftTrigger,
			kP3RightTrigger
		},
		{
			kP4LeftHorizontal,
			kP4LeftVertical,
			kP4RightHorizontal,
			kP4RightVertical,
			kP4LeftTrigger,
			kP4RightTrigger
		}
	};

	static public string[,] axes_windows = {
		{
			kMicP1LeftHorizontal,
			kMicP1LeftVertical,
			kMicP1RightHorizontal,
			kMicP1RightVertical,
			kMicP1LeftTrigger,
			kMicP1RightTrigger
		},
		{
			kMicP2LeftHorizontal,
			kMicP2LeftVertical,
			kMicP2RightHorizontal,
			kMicP2RightVertical,
			kMicP2LeftTrigger,
			kMicP2RightTrigger
		},{
			kMicP3LeftHorizontal,
			kMicP3LeftVertical,
			kMicP3RightHorizontal,
			kMicP3RightVertical,
			kMicP3LeftTrigger,
			kMicP3RightTrigger
		},{
			kMicP4LeftHorizontal,
			kMicP4LeftVertical,
			kMicP4RightHorizontal,
			kMicP4RightVertical,
			kMicP4LeftTrigger,
			kMicP4RightTrigger
		},
	};


	// Players
	static public int player1 = 0;
	static public int player2 = 1;
	static public int player3 = 2;
	static public int player4 = 3;


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
