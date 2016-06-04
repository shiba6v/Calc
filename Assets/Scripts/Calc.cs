using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class Calc : MonoBehaviour {

    int sum =0;
    int input =0;
    Enum.Operator _ope = Enum.Operator.None;
    NumberButton[] _numberButtons = new NumberButton[10];
    OperatorButton[] _operatorButtons = new OperatorButton[System.Enum.GetNames(typeof(Enum.Operator)).Length];
    List<int> _baseNumberList;
    List<Enum.Operator> _operatorList;

    [SerializeField]
    Button _startButton;

    [SerializeField]
    Text _text;



	// Use this for initialization
	void Start () {
        _baseNumberList = new List<int>(){ 0,1,2,3,4,5,6,7,8,9};
        _operatorList = new List<Enum.Operator>(){ Enum.Operator.Add , Enum.Operator.Subtract , Enum.Operator.Multiply };
	}
	
	// Update is called once per frame
	void Update () {
        _text.text = string.Format("sum: {0}\n input: {1}\n ope: {2}",sum,input,_ope);
        /*
        if (Input.GetMouseButtonDown(0)) {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();

            if (Physics.Raycast(ray, out hit)){
                GameObject obj = hit.collider.gameObject;
                Debug.Log(obj.name);
                CalcButton button = obj.GetComponent<CalcButton>();
                if(button is NumberButton)
                {
                    (button as NumberButton).ButtonPressed();
                }
                else if(button is OperatorButton)
                {
                    (button as OperatorButton).ButtonPressed();
                }
                    
            }

        }
        */
	}

    public void StartGame()
    {
        _startButton.gameObject.SetActive(false);
        StartCoroutine(RepeatCoroutine());
    }

    IEnumerator RepeatCoroutine()
    {
        int repetition = 5;
        for(int i = 0;i<repetition;i++)
        {
            int num = RestrictedRand();
            _numberButtons[num].ButtonPressed();
            yield return new WaitForSeconds(1f);
            PressButton();
            yield return new WaitForSeconds(1f);
        }
    }
        

    void PressButton()
    {
        _operatorButtons[(int)_operatorList[Random.Range(0,_operatorList.Count)]].ButtonPressed();
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




    public void SetNumber(int n)
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
}
