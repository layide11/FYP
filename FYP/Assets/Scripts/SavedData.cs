using System;
using System.Collections.Generic;
using System.Linq;

[System.Serializable]
public class SavedData
{
    public Dictionary<int, string> __LeaderBoardScores;

    public SavedData(Dictionary<int, string>  leaderBoardScores)
    {
        __LeaderBoardScores = leaderBoardScores;
    }

}
