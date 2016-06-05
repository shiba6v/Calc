using UnityEngine;
using System.Collections;

public class sevenSeg : MonoBehaviour {

	
	private Color spec;
	private Color color;
	public bool p;

	// Use this for initialization
	void Start () {
		spec = this.GetComponent<Renderer> ().material.GetColor ("_SpecColor");
		color = this.GetComponent<Renderer> ().material.GetColor ("_Color");
		p = false;
	}
	
	// Update is called once per frame
	void Update () {


	}

    public void Toggle()
    {
        if(p)
        {
            unPush();
        }
        else
        {
            push();
        }
    }

	public void push() {
        this.GetComponent<Renderer> ().material.SetColor("_SpecColor", Color.white);//black にする
        this.GetComponent<Renderer> ().material.SetColor("_Color", Color.black);
		p = true;
	}

	public void unPush() {
		this.GetComponent<Renderer> ().material.SetColor("_SpecColor", spec);
		this.GetComponent<Renderer> ().material.SetColor("_Color", color);
		p = false;
	}
}
