using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class DifficultySelect : MonoBehaviour {

    public static int difficulty;
    public static readonly int maxDifficulty = 14;

    /** 一桁でやる難易度 */
    static readonly int[] oneDigitDifficulty = new int[10]{
        1,2,5,6,9,10,11,12,13,14
    };
    /** Addを使う難易度 */
    static readonly int[] usingAddDifficulty = new int[14]{
        1,2,3,4,5,6,7,8,9,10,11,12,13,14,
    };
    /** Subtractを使う難易度 */
    static readonly int[] usingSubtractDifficulty = new int[10]{
        5,6,7,8,9,10,11,12,13,14,
    };
    /** Multiplyを使う難易度 */
    static readonly int[] usingMultiplyDifficulty = new int[6]{
        9,10,11,12,13,14,
    };
    /** Divisionを使う難易度 */
    static readonly int[] usingDivideDifficulty = new int[2]{
        13,14,
    };

    /** 5回で終わる難易度 */
    static readonly int[] fiveTimesDifficulty = new int[7]{
        1,3,5,7,9,11,13,
    };

    static List<int> oneDigit = new List<int>()
    { 
        0,1,2,3,4,5,6,7,8,9,
    };

    static List<int> twoDigit = new List<int>()
    { 
        0,1,2,3,4,5,6,7,8,9,
        10,11,12,13,14,15,16,17,18,19,
        20,21,22,23,24,25,26,27,28,29,
        30,31,32,33,34,35,36,37,38,39,
        40,41,42,43,44,45,46,47,48,49,
        50,51,52,53,54,55,56,57,58,59,
        60,61,62,63,64,65,66,67,68,69,
        70,71,72,73,74,75,76,77,78,79,
        80,81,82,83,84,85,86,87,88,89,
        90,91,92,93,94,95,96,97,98,99,
    };

    public static List<Enum.Operator> OperatorList()
    {
        List<Enum.Operator> list = new List<Enum.Operator>();
        if(Array.IndexOf(usingAddDifficulty,difficulty) != -1)
        {
            list.Add(Enum.Operator.Add);
        }
        if(Array.IndexOf(usingSubtractDifficulty,difficulty) != -1)
        {
            list.Add(Enum.Operator.Subtract);
        }
        if(Array.IndexOf(usingMultiplyDifficulty,difficulty) != -1)
        {
            list.Add(Enum.Operator.Multiply);
        }
        if(Array.IndexOf(usingDivideDifficulty,difficulty) != -1)
        {
            list.Add(Enum.Operator.Divide);
        }
        return list;
    }

    public static List<int> BaseNumberList()
    {
        List<int> list = new List<int>();
        if(Array.IndexOf(oneDigitDifficulty,difficulty) != -1)
        {
            return oneDigit;
        }
        else
        {
            return twoDigit;
        }
    }

    public static int Repetition()
    {
        int repetition = 0;
        if(Array.IndexOf(fiveTimesDifficulty,difficulty) != -1)
        {
            repetition = 5;
        }
        else
        {
            repetition = 10;
        }
        return repetition;
    }




	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
