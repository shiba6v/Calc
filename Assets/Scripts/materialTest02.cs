using UnityEngine;
using System.Collections;

public class materialTest02 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Color spec = this.GetComponent<Renderer> ().material.GetColor("_SpecColor");
		spec = Color.red;
		this.GetComponent<Renderer> ().material.SetColor("_SpecColor", spec);
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Rotate (Time.deltaTime * 10f, 0, 0);

		if (Input.GetMouseButtonDown (0)) {

			Vector3 pos = Input.mousePosition;
			Ray ray = Camera.main.ScreenPointToRay (pos);
			RaycastHit hit;

			if (Physics.Raycast (ray, out hit, 100f)) {

				Debug.Log ("a");
				this.transform.Rotate (10f, 0, 0);

			}

		}

	}
}
