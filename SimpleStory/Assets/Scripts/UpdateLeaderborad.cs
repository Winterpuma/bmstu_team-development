using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.Database;

public class UpdateLeaderborad : MonoBehaviour
{
    public Text changingText;

    public void ChangeText() 
    {
        //LeaderboardIO.Write(new LeaderboardRow { PlayerName="Hellofr231", MapId=1, WalkthroughTime=111});
        //LeaderboardIO.Write(new LeaderboardRow { PlayerName="Heladjoj", MapId=1, WalkthroughTime=222});
        //LeaderboardIO.Write(new LeaderboardRow { PlayerName="Aaaa", MapId=1, WalkthroughTime=777});

        var lead = LeaderboardIO.GetLeaderboard(7);
        var res = "Лидеры:\n\n";

        foreach (var el in lead)
        {
            res += $"{el.PlayerName} {el.WalkthroughTime}\n";
        }

        changingText.text = res;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
