using UnityEngine;
using System.Collections;

public class OperatorButton : CalcButton {

    [SerializeField]
    Enum.Operator _ope;


	// Use this for initialization
	void Start () {
        _calc.SetOperatorButton(_ope,this);
	}
	
	// Update is called once per frame
	void Update () {
	}

    public override void ButtonPressed()
    {
        StartCoroutine(EmitLight());
        _calc.SetOperator(_ope);
    }
}
