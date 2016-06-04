using UnityEngine;
using System.Collections;

public class NumberButton : CalcButton {

    [SerializeField]
    int _number;


	// Use this for initialization
	void Start () {
        _pushActivator = GetComponent<PushActivator>();
        _calc.SetNumberButton(_number,this);
	}
	
	// Update is called once per frame
	void Update () {

	}

    public override void ButtonPressed()
    {
        StartCoroutine(EmitLight());
    }
}
