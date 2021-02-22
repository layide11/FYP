using System;
using System.Collections.Generic;
using System.Linq;

public class FisherShuffle
{
   
    public static IEnumerable<int> CreateShuffledList(int size)
    {
        IEnumerable<int> _UnShuffledList = Enumerable.Range(0, size).ToList();
        IEnumerable<int> _ShuffledList = Shuffle(_UnShuffledList);


        return _ShuffledList;
    }

    public static T[] Shuffle<T>(IEnumerable<T> items)
    {
        var result = items.ToArray();
        var r = new Random();
        for (int i = items.Count(); i > 1; i--)
        {
            int j = r.Next(i);
            var t = result[j];
            result[j] = result[i - 1];
            result[i - 1] = t;
        }

        return result;
    }


}
