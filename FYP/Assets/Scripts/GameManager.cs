using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public Text __ScoreText;
    public Text __HighScoreText;
    public int __HighScore;
    private int __CurrentScore;
    public float __ScoreIncreaseSpeed = 0.2f;

    public float __Slowness = 10f;

	public void EndGame()
	{
        UpdateHighScore();
        SaveSystem.SavePlayerData(this);

        StartCoroutine(RestartLevel());
	}

	IEnumerator RestartLevel()
	{
		Time.timeScale = 1f / __Slowness;
		Time.fixedDeltaTime = Time.fixedDeltaTime / __Slowness;

		yield return new WaitForSeconds(1f / __Slowness);

		Time.timeScale = 1f;
		Time.fixedDeltaTime = Time.fixedDeltaTime * __Slowness;

		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}


    private void Start()
    {
        SavedData _SavedData = SaveSystem.LoadSavedData();

        if(_SavedData !=null)
        {
            __HighScore = _SavedData.__HighScore;
        }
        else
        {
            __HighScore = 0; 
        }
        
        __ScoreText.text = "0";
        __HighScoreText.text = __HighScore.ToString();

        int.TryParse(__ScoreText.text, out __CurrentScore);
        InvokeRepeating("AddToScore", 1f, __ScoreIncreaseSpeed);
    }

    void AddToScore()
    {
        __CurrentScore++;
        __ScoreText.text = __CurrentScore.ToString();
    }

    public void UpdateHighScore()
    {
        if(__CurrentScore > __HighScore)
        {
            __HighScore = __CurrentScore;
        }
    }
}
