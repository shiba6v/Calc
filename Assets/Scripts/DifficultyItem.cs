using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DifficultyItem : MonoBehaviour {
    [SerializeField]
    Text _text;

    UI _ui;

    public int number;

    public void SetText(int i,UI obj)
    {
        _text.text = string.Format("{0}",i);;
        number = i;
        _ui = obj;
    }

    public void OnPressButton()
    {
        DifficultySelect.difficulty = (number-1)*4 +1;
        _ui.OnPressDifficulty();

    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
