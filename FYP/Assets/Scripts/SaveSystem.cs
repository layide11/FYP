using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;
using System;

public static class SaveSystem 
{
   public static void SavePlayerData(GameManager gameManager)
    {
        BinaryFormatter _Formatter = new BinaryFormatter();
       
        FileStream stream = new FileStream(GetFilePath(), FileMode.Create);


        SavedData _Data = new SavedData(gameManager.__HighScore);

        _Formatter.Serialize(stream, _Data);
        stream.Close();
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
                _Data = new SavedData(0);
            }
            else
            {
                _Data = _Formatter.Deserialize(_Stream) as SavedData;
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

    static string GetFilePath()
    {
        return Application.persistentDataPath + "/player.txt";
    }
}
