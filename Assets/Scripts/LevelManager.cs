using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
   public GameObject hintScreen;
   public GameObject gameOverScreen;

    public int loadCount=0;
    private void Start()
    {
        Time.timeScale = 0;
        loadCount++;
    }
    public void LevelLoad()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void GameOver()
    {
        gameOverScreen.SetActive(true);
    }
    public void Restart()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void GameStart()
    {
        Time.timeScale = 1;
        hintScreen.SetActive(false);
    }
}
