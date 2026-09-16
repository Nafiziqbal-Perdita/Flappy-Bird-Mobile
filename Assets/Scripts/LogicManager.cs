using TMPro;
using UnityEngine;

public class LogicManager : MonoBehaviour
{


    [SerializeField] TextMeshProUGUI scoreText;
    public int score { get; private set; }



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // scoreIncrement();
        scoreText.text = score.ToString();

    }
    public void scoreIncrement()
    {
        score++;
    }
}
