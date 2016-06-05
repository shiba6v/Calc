using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class DifficultySelect : MonoBehaviour {

    [SerializeField]
    GameObject _prefab;

    [SerializeField]
    UI _ui;

  public static int difficulty;
    public static readonly int maxDifficulty = 16;

    /** 待ち時間0.8の難易度 */
    static readonly int[] wait08Difficulty = new int[4]{
        2,6,9,13
    };
    /** 待ち時間0.6の難易度 */
    static readonly int[] wait06Difficulty = new int[4]{
        3,7,10,14
    };
    /** 待ち時間0.4の難易度 */
    static readonly int[] wait04Difficulty = new int[4]{
        4,8,11,15
    };

    /** 一桁でやる難易度 */
    static readonly int[] oneDigitDifficulty = new int[16]{
        1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16
    };
    /** Addを使う難易度 */
    static readonly int[] usingAddDifficulty = new int[16]{
        1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16
    };
    /** Subtractを使う難易度 */
    static readonly int[] usingSubtractDifficulty = new int[12]{
        5,6,7,8,9,10,11,12,13,14,15,16
    };
    /** Multiplyを使う難易度 */
    static readonly int[] usingMultiplyDifficulty = new int[6]{
        9,10,11,12,15,16
    };
    /** Divisionを使う難易度 */
    static readonly int[] usingDivideDifficulty = new int[4]{
        13,14,15,16
    };

    /** 5回で終わる難易度 */
    static readonly int[] fiveTimesDifficulty = new int[16]{
        1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16
    };

    static List<int> oneDigit = new List<int>()
    { 
        0,1,2,3,4,5,6,7,8,9,
    };

    static List<int> twoDigit = new List<int>()
    { 
        0,1,2,3,4,5,6,7,8,9,
        10,11,12,13,14,15,16,17,18,19,
        /*
        20,21,22,23,24,25,26,27,28,29,
        30,31,32,33,34,35,36,37,38,39,
        40,41,42,43,44,45,46,47,48,49,
        50,51,52,53,54,55,56,57,58,59,
        60,61,62,63,64,65,66,67,68,69,
        70,71,72,73,74,75,76,77,78,79,
        80,81,82,83,84,85,86,87,88,89,
        90,91,92,93,94,95,96,97,98,99,
        */
    };

    public static float WaitTime()
    {

        if(Array.IndexOf(wait08Difficulty,difficulty) != -1)
        {
            return 0.8f;
        }
        else if(Array.IndexOf(wait06Difficulty,difficulty) != -1)
        {
            return 0.6f;
        }
        else if(Array.IndexOf(wait04Difficulty,difficulty) != -1)
        {
            return 0.4f;
        }
        else
        {
            return 1f;
        }
    }

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
            repetition = 3;
        }
        return repetition;
    }




	// Use this for initialization
	void Start () {
        for(int i=1; i<= DifficultySelect.maxDifficulty; i= i+4)
        {
            GameObject obj = GameObject.Instantiate(_prefab);
            obj.transform.SetParent(transform);
            obj.GetComponent<DifficultyItem>().SetText((i-1)/4 +1,_ui );
        }
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
