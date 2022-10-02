using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.Database;

public class UpdateLeaderborad : MonoBehaviour
{
    public Text leaderboardName;
    public Text leaderboardTime;

    // Start is called before the first frame update
    void Start()
    {
        var lead = LeaderboardIO.GetLeaderboard(7);
        var res = "Leaders:\n\n";
        var resTime = "\n\n";

        foreach (var el in lead)
        {
            res += $"{el.PlayerName}\n";
            resTime += $"{el.WalkthroughTime.ToString("0.##")}\n";
        }

        leaderboardName.text = res;
        leaderboardTime.text = resTime;
    }
}
