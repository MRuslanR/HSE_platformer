using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void PlayGame() 
    {
        PlayerPrefs.SetInt("PlayerLevel", 1);
        PlayerPrefs.Save(); 
        SceneManager.LoadScene("Level_1");
    }

    public void ContinueGame()
    {

        if (PlayerPrefs.HasKey("PlayerLevel"))
        {
            print("Level_" + PlayerPrefs.GetInt("PlayerLevel").ToString());
            SceneManager.LoadScene("Level_" + PlayerPrefs.GetInt("PlayerLevel").ToString());
        }
        else
        {
            print("1 lvl");
            SceneManager.LoadScene("Level_1");
        }

    }

    public void ExitGame() 
    {
        Application.Quit();
    }
}