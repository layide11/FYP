using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text __ScoreText;
    public Text __HighScoreText;
    public int __HighScore;
    private int __CurrentScore;
    public float __ScoreIncreaseSpeed =0.2f;

    private void Start()
    {
        __HighScore = 2000;//load actual high score 
        __ScoreText.text = "0";
        __HighScoreText.text = "High Score: " + __HighScore.ToString();
        int.TryParse(__ScoreText.text, out __CurrentScore);
        InvokeRepeating("AddToScore", 1f, __ScoreIncreaseSpeed);
    }
   
    void AddToScore()
    {
        __CurrentScore++;
        __ScoreText.text = __CurrentScore.ToString();
    }

    public void UpdateHighScore(int score)
    {
        __HighScore = score;
    }
}
