using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{

    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;
    public int highScore;
    public Text highText;
    public AudioSource deathSound;
    public AudioSource backgroundMusic;

    public void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highText.text = "High: " + highScore.ToString();
    }

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        scoreText.text = "Score: " + playerScore.ToString();
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
