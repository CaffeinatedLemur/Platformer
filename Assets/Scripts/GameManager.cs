/*****************
 * Name: Thomas ALlen
 * Date: 1/7/2021
 * Desc: Basic game manager and store variable between levels
 * ***********************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    private static int score = 0;
    public static UnityEvent OnScoreChange = new UnityEvent();

    //score property (in c# this is a thing)
    public static int Score
    {
        get => score;
        set
        {
            score = value;
            OnScoreChange.Invoke();
        }
    }
}
