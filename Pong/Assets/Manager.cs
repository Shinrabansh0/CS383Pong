using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Manager : MonoBehaviour {

    public static int Player1Score = 0;
    public static int Player2Score = 0;
    public GUISkin layout;

    GameObject theBall;

    public static void Score(string wallID)
    {
        //When ball passes a side wall, increase a players score
        if (wallID == "RightWall")
        {
            Player1Score++;
        }
        else
        {
            Player2Score++;
        }
    }

    //Add GUI for points and reset button
    void OnGUI()
    {
        GUI.skin = layout;
        GUI.Label(new Rect(Screen.width / 2 - 150 - 12, 20, 100, 100), "" + Player1Score);
        GUI.Label(new Rect(Screen.width / 2 + 150 + 12, 20, 100, 100), "" + Player2Score);

        //When restart button is clicked, set scores back to 0
        if(GUI.Button(new Rect(Screen.width / 2-60,35,120,53), "RESTART"))
        {
            Player1Score = 0;
            Player2Score = 0;
            theBall.SendMessage("Restart", 0.5f, SendMessageOptions.RequireReceiver); //SendMessage tells program to go find specific function with specific name
        }

        //When score limit of 5 is met announce winner
        if(Player1Score == 5)
        {
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "Player 1 Wins");
            theBall.SendMessage("BallReset", null, SendMessageOptions.RequireReceiver);
        }
        else if(Player2Score == 5)
        {
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "Player 2 Wins");
            theBall.SendMessage("BallReset", null, SendMessageOptions.RequireReceiver); 
        }
    }

    // Use this for initialization
    void Start()
    {
        theBall = GameObject.FindGameObjectWithTag("Ball");
    }
}
