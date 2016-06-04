using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public abstract class CalcButton : MonoBehaviour {

    [SerializeField]
    internal Calc _calc;

    internal PushActivator _pushActivator;

	// Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public virtual void ButtonPressed()
    {
        StartCoroutine(EmitLight());
    }

    internal IEnumerator EmitLight()
    {
        _pushActivator.Init();
        for(int i=0;i<10;i++)
        {
            yield return new WaitForSeconds(0.01f);
        }
        for(int i=10;i>=0;i--)
        {
            yield return new WaitForSeconds(0.01f);

        }
    }
}
