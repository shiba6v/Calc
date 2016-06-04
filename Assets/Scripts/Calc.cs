using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Calc : MonoBehaviour {

    int sum;
    int input;
    Enum.Operator ope;

    [SerializeField]
    Text _text;


	// Use this for initialization
	void Start () {
        sum = 0;
        input = 0;
        ope = Enum.Operator.None;
	}
	
	// Update is called once per frame
	void Update () {
        _text.text = string.Format("sum: {0}\n input: {1}\n ope: {2}",sum,input,ope);
        
	}

    void Calculate()
    {
        switch(ope)
        {
        case Enum.Operator.Add:
            Add();
            break;
        case Enum.Operator.None:
            break;
        }
    }

    void Add()
    {
        sum += input;
        input = 0;
        ope = Enum.Operator.None;
    }

    public void SetNumber(int n)
    {
        input = n;
    }

    public void SetOperator(Enum.Operator o)
    {
        Calculate();
        ope = o;
    }
}
