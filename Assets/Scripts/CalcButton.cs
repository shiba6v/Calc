using UnityEngine;
using System.Collections;

public abstract class CalcButton : MonoBehaviour {

    [SerializeField]
    internal Calc _calc;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public virtual void ButtonPressed()
    {
    }
}
