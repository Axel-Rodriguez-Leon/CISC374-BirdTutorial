using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using JetBrains.Annotations;

public class LogicScript : MonoBehaviour
{

    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;
    public GameObject titleScreen;
    public int highScore;
    public Text highText;
    public AudioSource deathSound;
    public AudioSource backgroundMusic;

    public void Start()
    {
        titleScreen.SetActive(true);
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highText.text = "High: " + highScore.ToString();
        Time.timeScale = 0;
    }

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        scoreText.text = "Score: " + playerScore.ToString();
    }

    public void startGame()
    {
        titleScreen.SetActive(false);
        Time.timeScale = 1;
    }
    
    public void gameOver()
    {
        gameOverScreen.SetActive(true);
        deathSound.Play();
        backgroundMusic.Pause();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    public void updateHigh()
    {
        if (playerScore > highScore)
        {
            highScore = playerScore;
            PlayerPrefs.SetInt("HighScore", highScore);
            highText.text = "High: " + highScore.ToString();
        }
    }
}
