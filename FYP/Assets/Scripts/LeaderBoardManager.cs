﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;
using System.Linq;

public class LeaderBoardManager : MonoBehaviour
{
    private Dictionary<int, string> __LeaderBoard;
    public List<TextMeshProUGUI> _Names;
    public List<TextMeshProUGUI> _Scores;

    public void BackPressed()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    void Start()
    {
        __LeaderBoard = SaveSystem.LoadSavedData().__LeaderBoardScores;
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (__LeaderBoard != null)
        {
            List<int> _Keys = __LeaderBoard.Keys.ToList();
            _Keys.Sort();
            _Keys.Reverse();
            for(int i =0; i < _Keys.Count; i++)
            {
                _Names[i].text = __LeaderBoard[_Keys[i]];
                _Scores[i].text = _Keys[i].ToString();
            }

        }
    }

}
