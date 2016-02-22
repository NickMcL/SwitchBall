using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TeamColors {
    public static Color TEAM_A = Color.red;
    public static Color TEAM_B = Color.blue;
    public static Color NO_TEAM = Color.gray;

    public static Dictionary<GameManager.TeamType, Color> TEAM_COLOR_MAP =
        new Dictionary<GameManager.TeamType, Color>() {
            {GameManager.TeamType.A, TEAM_A},
            {GameManager.TeamType.B, TEAM_B},
            {GameManager.TeamType.NONE, NO_TEAM}
        };
}
