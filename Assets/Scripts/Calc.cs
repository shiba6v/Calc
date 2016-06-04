using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Calc : MonoBehaviour {

    int sum =0;
    int input =0;
    Enum.Operator ope = Enum.Operator.None;

    [SerializeField]
    Text _text;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        _text.text = string.Format("sum: {0}\n input: {1}\n ope: {2}",sum,input,ope);
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
