using UnityEngine;
using System.Collections;

public class NumberButton : MonoBehaviour {

    [SerializeField]
    int _number;

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
        _calc.SetNumber(_number);
    }
}
