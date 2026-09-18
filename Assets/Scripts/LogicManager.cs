using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogicManager : MonoBehaviour
{
    [SerializeField] AudioManager audioManager;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] GameObject gameOverScreen;

    public int score { get; private set; }

    void Start()
    {
        scoreText.text = score.ToString();
    }

    public void scoreIncrement()
    {
        score++;
        scoreText.text = score.ToString();
    }

    public void gameOver()
    {
        audioManager.StopBackgroundMusic();
        audioManager.PlayGameOver();
        gameOverScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    public void restartGame()
    {
        StartCoroutine(RestartWithSound());//restart game with sound
    }

    IEnumerator RestartWithSound()
    {
        audioManager.PlayButtonClick();

        yield return new WaitForSecondsRealtime(0.2f);

        Time.timeScale = 1f;

        SceneManager.LoadScene(
            SceneManager.GetActiveScene().name
        );
    }
}