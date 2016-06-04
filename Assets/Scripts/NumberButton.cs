using UnityEngine;
using System.Collections;

public class NumberButton : CalcButton {

    [SerializeField]
    int _number;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void ButtonPressed()
    {
        StartCoroutine(EmitLight());
        _calc.SetNumber(_number);
    }
}
