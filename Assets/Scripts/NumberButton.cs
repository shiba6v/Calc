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
        if (Input.GetMouseButtonDown(0)) {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();

            if (Physics.Raycast(ray, out hit)){
                GameObject obj = hit.collider.gameObject;
                Debug.Log(obj.name);
                ButtonPressed();
            }
        }
	}

    public void ButtonPressed()
    {
        _calc.SetNumber(_number);
    }
}
