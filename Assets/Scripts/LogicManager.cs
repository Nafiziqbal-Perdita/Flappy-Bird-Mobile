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
    public Pipe pipe;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreText.text = score.ToString();
        pipe=GameObject.FindGameObjectWithTag("Pipe").GetComponent<Pipe>();
    }

    public void scoreIncrement(int needToIncrement)
    {
        score += needToIncrement;
        scoreText.text = score.ToString();


    if (score % 10 == 0)
    {
        pipe.IncreaseSpeed();
    }
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