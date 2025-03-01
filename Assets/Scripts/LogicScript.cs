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
    public AudioSource titleBackgroundMusic;
    public AudioSource highScoreSound;

    public void Start()
    {
        titleScreen.SetActive(true);
        titleBackgroundMusic.Play();
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
        titleBackgroundMusic.Pause();
        backgroundMusic.Play();
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
    }

    public void updateHigh()
    {
        if (playerScore > highScore)
        {
            highScore = playerScore;
            PlayerPrefs.SetInt("HighScore", highScore);
            highText.text = "High: " + highScore.ToString();
            highScoreSound.Play();
        }
    }
}
