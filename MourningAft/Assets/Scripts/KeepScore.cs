using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepScore : MonoBehaviour
{
    public static int totalScore = 0;

    void onGUI(){
        GUI.Box (new Rect (100, 100, 100, 100), "Score: " + totalScore.ToString());
    }
}
