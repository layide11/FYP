using System.Collections.Generic;

[System.Serializable]
public class SavedData
{
    public Dictionary<int, string> __LeaderBoardScores;

    public SavedData(Dictionary<int, string>  leaderBoardScores)
    {
        __LeaderBoardScores = leaderBoardScores;
    }

}
