using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.Database;

public class EnterName : MonoBehaviour
{
    public Text playerName;

    public void SaveRecord() 
    {
        // TODO: save actual time
        LeaderboardIO.Write(new LeaderboardRow {PlayerName=playerName.text, MapId=1, WalkthroughTime=3.14}); 
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
