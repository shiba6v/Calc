using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UI : MonoBehaviour {

    [SerializeField]
    Sprite[] _sprites;

    [SerializeField]
    /** クリアイメージ */
    Image _image;

    [SerializeField]
    /** ゲームスタートボタン */
    Button _button;

    [SerializeField]
    /** スタートボタンテキスト */
    Text _buttonText;

    [SerializeField]
    Calc _calc;

    [SerializeField]
    GameObject _body;

    [SerializeField]
    Image _hpBar;

    bool _buttooshi;

    public static float hp = 1f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        _hpBar.fillAmount = hp;
        if(hp <= 0f)
        {
            GameOver();
        }
        else if(hp<0.2f)
        {
            _hpBar.color = Color.red;
        }
        else if(hp<0.5f)
        {
            _hpBar.color = Color.yellow;
        }
        else
        {
            _hpBar.color = Color.blue;
        }
	}


    public void OnPressButtooshi()
    {
        _buttooshi = true;
        DifficultySelect.difficulty = 1;
        _buttonText.text = "ぶっ通しモード";
        _body.SetActive(false);
        _button.gameObject.SetActive(true);
        _hpBar.gameObject.SetActive(true);
    }

    public void OnPressDifficulty()
    {
        _buttooshi = false;
        DifficultySelect.difficulty = 1;
        _buttonText.text = string.Format("難易度:{0}",DifficultySelect.difficulty);
        _hpBar.gameObject.SetActive(true);
    }
        

    public void Clear()
    {

        _hpBar.gameObject.SetActive(false);
        if(_buttooshi && DifficultySelect.difficulty != DifficultySelect.maxDifficulty)
        {
            DifficultySelect.difficulty += 1;
            _calc.StartGame();
        }
        else if (_buttooshi)
        {
            //ぶっ通しクリア
            _image.gameObject.SetActive(true);
            _image.sprite = _sprites[1];
        }
        else
        {
            _image.gameObject.SetActive(true);
            _image.sprite = _sprites[1];
        }
    }

    public void GameOver()
    {
        _image.gameObject.SetActive(true);
        _image.sprite = _sprites[0];
        
    }
}
