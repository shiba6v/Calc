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

    int kaisuu= 0;

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

        if(_buttooshi && DifficultySelect.difficulty != DifficultySelect.maxDifficulty)
        {
            DifficultySelect.difficulty += 1;
        }
        else if (_buttooshi)
        {
            _hpBar.gameObject.SetActive(false);
            //ぶっ通しクリア

        }
        else if(kaisuu >= 4)
        {
            _hpBar.gameObject.SetActive(false);
            //4回やったら難易度選択モードクリア

        }
        else
        {
            DifficultySelect.difficulty += 1;
        }
        hp = 1f - (1f-hp)*0.5f;
        StartCoroutine(ClearCoroutine());
    }

    IEnumerator ClearCoroutine()
    {
        _image.gameObject.SetActive(true);
        _image.sprite = _sprites[1];
        yield return new WaitForSeconds(1f);
        _image.gameObject.SetActive(false);
        OnPressDifficulty();
        //スタートゲームをやる代わりにこのメソッドを読んでる。
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

    public void SetStartImage()
    {
        _image.sprite = _sprites[2];
        _image.gameObject.SetActive(true);
    }
}
