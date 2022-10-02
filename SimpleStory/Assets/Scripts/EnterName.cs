using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.Database;

public class EnterName : MonoBehaviour
{
    public Text playerName;
    public static DateTime roundStart;
    public static DateTime roundEnd;

    public void SaveRecord() 
    {
        TimeSpan ts = roundEnd - roundStart;
        LeaderboardIO.Write(new LeaderboardRow {PlayerName=playerName.text, MapId=1, WalkthroughTime=ts.TotalSeconds}); 
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
