using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public abstract class CalcButton : MonoBehaviour {

    [SerializeField]
    internal Calc _calc;

    [SerializeField]
    internal Light _light;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public virtual void ButtonPressed()
    {
    }

    internal IEnumerator EmitLight()
    {
        for(int i=0;i<10;i++)
        {

            _light.intensity = i * 0.3f;
            yield return new WaitForSeconds(0.01f);
            
        }
        for(int i=10;i>=0;i--)
        {

            _light.intensity = i * 0.3f;
            yield return new WaitForSeconds(0.01f);

        }
    }
}
