using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreKeeper
{
    private static int score = 0;

    public static void Add()
    {
        score += 10;
    }

    public static void Subtract()
    {
        score -= 10;
    }

    public static int GetScore()
    {
        return score;
    }
}
