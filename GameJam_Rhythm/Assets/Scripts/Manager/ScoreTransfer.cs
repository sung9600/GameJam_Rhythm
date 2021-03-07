using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTransfer : MonoBehaviour
{
    public int[] sum; // perfect good bad 순서
    public int score;
    public bool success;
    public ScoreTransfer(int[] sums, int _score)
    {
        sum = new int[sums.Length];
        for (int i = 0; i < sum.Length; i++)
        {
            sum[i] = sums[i];
        }
        this.score = _score;
    }
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
