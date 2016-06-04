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

    [SerializeField]
    GameObject _bombRoot;

    [SerializeField]
    DifficultySelect _difficultySelect;

    bool _buttooshi;

    public static float hp = 1f;

	// Use this for initialization
    void Start () {
        _bombRoot.SetActive(false);

        _hpBar.gameObject.SetActive(false);
        _difficultySelect.gameObject.SetActive(false);
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
        _bombRoot.SetActive(true);
    }

    public void OnPressDifficultySelect()
    {
        _buttooshi = false;
        DifficultySelect.difficulty = 1;
        _difficultySelect.gameObject.SetActive(true);
        _body.SetActive(false);

    }
        
    public void OnPressDifficulty()
    {
        
        _difficultySelect.gameObject.SetActive(false);
        _button.gameObject.SetActive(true);
        _buttonText.text = string.Format("難易度:{0}",DifficultySelect.difficulty);
        _hpBar.gameObject.SetActive(true);
        _bombRoot.SetActive(true);
        _button.gameObject.SetActive(true);
    }

    public void Clear()
    {

        _hpBar.gameObject.SetActive(false);
        if(_buttooshi && DifficultySelect.difficulty != DifficultySelect.maxDifficulty)
        {
            _image.gameObject.SetActive(true);
            _image.sprite = _sprites[1];
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

    public void SetImage(bool b)
    {
        _image.gameObject.SetActive(b);
    }
}
