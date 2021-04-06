using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public Text __ScoreText;
    public Text __HighScoreText;
    private int __HighScore;
    private Dictionary<int, string> __LeaderBoardScores;
    private int __CurrentScore;
    public float __ScoreIncreaseSpeed = 0.2f;

    public float __Slowness = 10f;
    private int __AppleScore = 10;

    public GameObject __InputCanvas;
    public InputField __Name;
    public GameObject __Canvas;
    public GameObject __Player;
    public GameObject __ObnstacleSpawner;

    private void EndGame(bool withRestart)
    {
        if (withRestart)
        {
            StartCoroutine(RestartLevel());
        }
        else
        {
            SceneManager.LoadScene("Menu");

        }

    }

    private IEnumerator RestartLevel()
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
        __HighScore = 0;
        __CurrentScore = 0;
        __LeaderBoardScores = new Dictionary<int, string>();
        SavedData _SavedData = SaveSystem.LoadSavedData();
        if (_SavedData != null)
        {
            __LeaderBoardScores = _SavedData.__LeaderBoardScores;
            if (__LeaderBoardScores.Count > 0)
            {
                __HighScore = __LeaderBoardScores.Keys.Max();
            }
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

    public void UpdateHighScores()
    {
        CancelInvoke();
        bool _HasNewEntry = false;
        if (__LeaderBoardScores.Count < 3)
        {
            if (!__LeaderBoardScores.ContainsKey(__CurrentScore))
            {
                ShowNameCollectionScreen(true);
                _HasNewEntry = true;
            }
        }
        else
        {
            int _LowestLeaderBoardScore = __LeaderBoardScores.Keys.Min();
            
            if (__CurrentScore > _LowestLeaderBoardScore)
            {
                __LeaderBoardScores.Remove(_LowestLeaderBoardScore);
                ShowNameCollectionScreen(true);
                _HasNewEntry = true;
            }
        }
        if (!_HasNewEntry)
        {
            EndGame(true);
        }
    }

    public void AddAppleScore()
    {
        __CurrentScore += __AppleScore;
        __ScoreText.text = __CurrentScore.ToString();
    }

    public void ReturnHome()
    {
        EndGame(false);

    }

    public void UpdateLeaderBoard()
    {
        __LeaderBoardScores.Add(__CurrentScore, __Name.text);
        SaveSystem.SavePlayerData(__LeaderBoardScores);
    }

    public void ShowNameCollectionScreen(bool shouldShow)
    {
        __InputCanvas.SetActive(shouldShow);
        __Canvas.SetActive(!shouldShow);
        __ObnstacleSpawner.SetActive(!shouldShow);
        __Player.SetActive(!shouldShow);
    }

    public void RestartGame()
    {
        StartCoroutine(RestartLevel());
    }
}
