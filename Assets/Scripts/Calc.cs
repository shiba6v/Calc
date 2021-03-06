﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class Calc : MonoBehaviour {

    int sum =0;
    int input =0;
    Enum.Operator _ope = Enum.Operator.None;
    NumberButton[] _numberButtons = new NumberButton[10];
    OperatorButton[] _operatorButtons = new OperatorButton[System.Enum.GetNames(typeof(Enum.Operator)).Length];

    /** 可能な演算 */
    List<Enum.Operator> _operatorList;
    /** 使える数字 */
    List<int> _baseNumberList;
    /** 繰り返し回数 */
    int _repetition;
    /** ボタンを押す間隔 */
    float waitTime = 1f;


    [SerializeField]
    Button _startButton;

    [SerializeField]
    Text _text;

    [SerializeField]
    UI _ui;


    segRay _segRay;

    // Use this for initialization
	void Start () {
        _segRay = gameObject.GetComponent<segRay>();
	}

	
	// Update is called once per frame
	void Update () {
        _text.text = string.Format("sum: {0}\n input: {1}\n ope: {2}",sum,input,_ope);

	}

    public void StartGame()
    {
        sum = 0;
        _ope = Enum.Operator.None;
        waitTime = DifficultySelect.WaitTime();
        _baseNumberList = DifficultySelect.BaseNumberList();
        _operatorList = DifficultySelect.OperatorList();
        _repetition = DifficultySelect.Repetition();
        _startButton.gameObject.SetActive(false);
        StartCoroutine(RepeatCoroutine());
    }

    IEnumerator RepeatCoroutine()
    {
        yield return new WaitForSeconds(1f);
        _ui.SetImage(false);
        yield return new WaitForSeconds(0.5f);
        _ui.SetStartImage();
        yield return new WaitForSeconds(0.5f);
        _ui.SetImage(false);
        yield return new WaitForSeconds(1f);
        for(int i = 0;i<_repetition;i++)
        {
            int num  = RestrictedRand();
            int div10 = num / 10;
            int div1 = num - div10 *10;
            SetNumber(num);
            if(div10 != 0)
            {
                _numberButtons[div10].ButtonPressed();
                yield return new WaitForSeconds(waitTime);
            }
            _numberButtons[div1].ButtonPressed();
            yield return new WaitForSeconds(waitTime);
            if(i != _repetition -1)
            {
                PressOperator();
            }
            else
            {
                //最後の時はイコール
                _operatorButtons[(int)Enum.Operator.Equal].ButtonPressed();
            
            }
            yield return new WaitForSeconds(waitTime);
        }
        StartCoroutine(AnswerCoroutine());
    }

    void PressOperator()
    {
        _operatorButtons[(int)_operatorList[Random.Range(0,_operatorList.Count -1)]].ButtonPressed();
    }

    void Calculate()
    {
        switch(_ope)
        {
        case Enum.Operator.Add:
            Add();
            break;
        case Enum.Operator.Subtract:
            Subtract();
            break;
        case Enum.Operator.Multiply:
            Multiply();
            break;
        case Enum.Operator.Divide:
            Divide();
            break;
        case Enum.Operator.None:
            break;
        }
    }

    public void SetNumberButton(int n,NumberButton numberbutton)
    {
        _numberButtons[n] = numberbutton;
    }

    public void SetOperatorButton(Enum.Operator ope, OperatorButton operatorButton)
    {
        _operatorButtons[(int)ope] = operatorButton;
    }

    int RestrictedRand()
    {
        List<int> numberList = new List<int>();
        switch(_ope)
        {
        case Enum.Operator.Add:
            numberList = _baseNumberList;
            break;
        case Enum.Operator.Subtract:
            foreach (int num in _baseNumberList)
            {
                if(num < sum)
                {
                    numberList.Add(num);
                }
            }
            if(numberList.Count == 0)
            {
                numberList.Add(0);
            }
            break;
        case Enum.Operator.Multiply:
            numberList = _baseNumberList;
            break;
        case Enum.Operator.Divide:
            foreach (int num in _baseNumberList)
            {
                if(sum % num == 0)
                {
                    numberList.Add(num);
                }
            }
            break;
        case Enum.Operator.None:
            numberList = _baseNumberList;
            break;
        }
        return numberList[Random.Range(0,numberList.Count - 1)];
    }

    void Add()
    {
        sum += input;
        input = 0;
        _ope = Enum.Operator.None;
    }

    void Subtract()
    {
        sum -= input;
        input = 0;
        _ope = Enum.Operator.None;
    }

    void Multiply()
    {
        sum *= input;
        input = 0;
        _ope = Enum.Operator.None;
        
    }
        
    void Divide()
    {
        sum /= input;
        input = 0;
        _ope = Enum.Operator.None;
        
    }
        
    void SetNumber(int n)
    {
        if(_ope == Enum.Operator.None)
        {
            sum = n;
        }
        else
        {
            input = n;
        }
    }

    public void SetOperator(Enum.Operator o)
    {
        Calculate();
        _ope = o;
    }

    IEnumerator AnswerCoroutine()
    {
        int time = 0;
        while(UI.hp >0)
        {
            UI.hp -= 0.007f;
            time += 1;
            yield return new WaitForSeconds(0.1f);

            if(time > 50 && !_ui.isGameOver)
            {
                _ui._hint.enabled = true;
                _ui._hint.text = string.Format("答えの1の位は{0}",sum%10);
            }
            if(sum == _segRay.numberInDisplay)
            {
                _ui.Clear();
                break;
            }

        }
    }

    public void ResetSevenSeg()
    {
        int childCount = _segRay.transform.childCount;
        for(int i = 0; i < childCount; i++)
        {
            _segRay.sevenSeg.transform.GetChild(i).GetComponent<sevenSeg>().unPush();
        }
    }

    int Input()
    {
        return 1;
    }
    public void Stop()
    {
        StopCoroutine(RepeatCoroutine());
        StopCoroutine(AnswerCoroutine());
    }
}
