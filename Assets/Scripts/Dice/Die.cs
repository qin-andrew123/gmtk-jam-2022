using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = Unity.Mathematics.Random;

public class Die
{
    public static int[] RollDice(int faces, int diceNumber)
    {
        System.Random dice = new System.Random();

        int[] results = new int[diceNumber];

        for (int i = 0; i < diceNumber; ++i)
            results[i] = dice.Next(faces);

        return results;
    }
}
