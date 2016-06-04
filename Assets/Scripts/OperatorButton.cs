using UnityEngine;
using System.Collections;

public class OperatorButton : MonoBehaviour {


    [SerializeField]
    Enum.Operator _ope;

    [SerializeField]
    Calc _calc;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ButtonPressed()
    {
        _calc.SetOperator(_ope);
    }
}
