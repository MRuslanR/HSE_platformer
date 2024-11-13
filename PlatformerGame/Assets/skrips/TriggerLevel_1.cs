using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerLevel_1 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerPrefs.SetInt("PlayerLevel", 2);
            PlayerPrefs.Save(); // Сохраняем изменения
            SceneManager.LoadScene("Level_2");
        }
    }

}
