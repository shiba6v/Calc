using UnityEngine;
using System.Collections;

public class Calc : MonoBehaviour {

    int sum;
    int input;
    Enum.Operator ope;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
	
	}

    public void SetNumber(int n)
    {
        input = n;
    }

    public void SetOperator(Enum.Operator o)
    {
        ope = o;
    }
}
