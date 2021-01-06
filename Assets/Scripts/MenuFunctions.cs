/**************
 * Name: Thomas Allen
 * Date: 1/4/2021
 * Desc. Crontols menu functions
 ********************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuFunctions : MonoBehaviour
{
    public int NextLevel;

    public void PlayButton()
    {
        Debug.Log("Loading Level: " + NextLevel);
        SceneManager.LoadScene(NextLevel);
    }

    public void QuitButton()
    {
        Debug.Log("Quitting Game.");
        Application.Quit();
    }
}
