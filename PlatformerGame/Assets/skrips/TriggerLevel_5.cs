using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerLevel_5 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerPrefs.SetInt("PlayerLevel", 5);
            PlayerPrefs.Save(); // Сохраняем изменения
            SceneManager.LoadScene("Menu");
        }
    }

}