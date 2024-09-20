using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayerDied : MonoBehaviour
{
    public GameObject deathPanel;

    public static bool gameIsPaused;

    public int health = 0;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 1;

            SceneManager.LoadScene("Menu");
        }
    }

    public void PlayerDeath()
    {
        PlayerHealth playerHealth = new PlayerHealth();
        

        
        
            // stop music

            // play win music

            deathPanel.SetActive(true);

            gameIsPaused = !gameIsPaused;
            PauseGame();
        
    }

    private void PauseGame()
    {
        if (gameIsPaused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}
