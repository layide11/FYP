using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;
using System;
using System.Collections.Generic;

public static class SaveSystem
{
    static string GetFilePath()
    {
        return Application.persistentDataPath + "/player.txt";
    }

    public static SavedData LoadSavedData()
    {
        String _Path = GetFilePath();

        if (File.Exists(_Path))
        {
            BinaryFormatter _Formatter = new BinaryFormatter();
            SavedData _Data;
            FileStream _Stream = new FileStream(_Path, FileMode.Open);

            if (_Stream.Length == 0)
            {
                _Data = new SavedData(new Dictionary<int, string>());
            }
            else
            {
                _Data = _Formatter.Deserialize(_Stream) as SavedData;
                //extra null check for secuirity
                if (_Data.__LeaderBoardScores == null)
                {
                    _Data.__LeaderBoardScores = new Dictionary<int, string>();
                }
            }
            _Stream.Close();

            return _Data;
        }
        else
        {
            Debug.Log("Save file not found at path" + _Path);
            return null;

        }
    }

    public static void SavePlayerData(Dictionary<int, string> leaderBoardScores)
    {
        BinaryFormatter _Formatter = new BinaryFormatter();

        FileStream stream = new FileStream(GetFilePath(), FileMode.Create);


        SavedData _Data = new SavedData(leaderBoardScores);

        _Formatter.Serialize(stream, _Data);
        stream.Close();
    }

}
