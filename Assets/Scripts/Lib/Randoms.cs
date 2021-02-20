using System.Collections.Generic;
using UnityEngine;

public class DataRandom
{
    public int value { get; }
    public float percent { get; }

    public DataRandom(int value, float percent)
    {
        this.value = value;
        this.percent = percent;
    }
}

public class Randoms : MonoBehaviour
{
    /// <summary>
    /// You can make randoms by percent of all posibilities.
    /// </summary>
    public static int CustomRandom(DataRandom[] dataRandoms)
    {
        float randomValue = Random.Range(0, 100);
        float lastRange = 0;
        foreach (DataRandom rand in dataRandoms)
        {
            if (lastRange <= randomValue && randomValue < lastRange + rand.percent)
                return rand.value;
            else
                lastRange += rand.percent;
        }

        Debug.LogError("Ranges is not correct...");
        return -1;
    }

    public static int[] GetRandomsNotRepeated(int[] values, int numbersNeeds)
    {
        List<int> rands = new List<int>(values);
        int[] returns = new int[numbersNeeds];
        for (int i = 0; i < numbersNeeds; i++)
        {
            returns[i] = rands[Random.Range(i, rands.Count)];
            rands.Remove(returns[i]);
        }

        return returns;
    }
}
