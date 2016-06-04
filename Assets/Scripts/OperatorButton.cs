using UnityEngine;
using System.Collections;

public class OperatorButton : CalcButton {

    [SerializeField]
    Enum.Operator _ope;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void ButtonPressed()
    {
        StartCoroutine(EmitLight());
        _calc.SetOperator(_ope);
    }
}
