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


    public Text _hint;

    public bool isGameOver = false;

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
        if(hp <= 0f && !isGameOver)
        {
            isGameOver = true;
            GameOver();
            _calc.Stop();
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
            hp = 1f - (1f-hp)*0.5f;
            StartCoroutine(ClearCoroutine());
        }
        else if (_buttooshi)
        {
            _hpBar.gameObject.SetActive(false);
            //ぶっ通しクリア
            AllClear();

        }
        else if(kaisuu >= 3)
        {
            _hpBar.gameObject.SetActive(false);
            //4回やったら難易度選択モードクリア
            AllClear();

        }
        else
        {
            kaisuu++;
            DifficultySelect.difficulty += 1;
            hp = 1f - (1f-hp)*0.5f;
            StartCoroutine(ClearCoroutine());
        }
    }

    IEnumerator ClearCoroutine()
    {
        _hint.text = "";
        _image.gameObject.SetActive(true);
        _image.sprite = _sprites[1];
        yield return new WaitForSeconds(1f);
        _image.gameObject.SetActive(false);
        _calc.ResetSevenSeg();
        OnPressDifficulty();
        //スタートゲームをやる代わりにこのメソッドを読んでる。
    }



    public void GameOver()
    {
        StartCoroutine(GameOverCoroutine());
    }

    IEnumerator GameOverCoroutine()
    {
        _hint.text = "";
        _calc.ResetSevenSeg();
        _image.gameObject.SetActive(true);
        _image.sprite = _sprites[3];
        for (int i=0;i < 100; i++)
        {
            yield return new WaitForSeconds(0.01f);
            _image.transform.localScale = Vector3.one*Mathf.Clamp01(Mathf.Sin(i*0.1f*Mathf.PI));
                
        }
        _image.transform.localScale = Vector3.one;
        _image.sprite = _sprites[0];
        yield return new WaitForSeconds(0.3f);
        _image.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.3f);
        _image.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        _image.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.3f);
        _image.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        _image.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        _body.SetActive(true);
        kaisuu = 0;
        hp = 1f;
        isGameOver = false;
        StopCoroutine(GameOverCoroutine());
    }

    void AllClear()
    {
        kaisuu = 0;
        _image.gameObject.SetActive(true);
        _image.sprite = _sprites[1];
        StartCoroutine(GameClearCoroutine());
    }

    IEnumerator GameClearCoroutine()
    {
        _hint.text = "";
        _calc.ResetSevenSeg();
        _image.gameObject.SetActive(true);
        _image.sprite = _sprites[1];
        _calc.Stop();
        _image.transform.localScale = Vector3.zero;
        for (int i=0;i < 100; i++)
        {
            yield return new WaitForSeconds(0.01f);
            _image.transform.localScale = Vector3.one*Mathf.Clamp01(Mathf.Sin(i*0.1f*Mathf.PI));
        }
        _image.gameObject.SetActive(false);
        yield return new WaitForSeconds(2f);

        _body.SetActive(true);
        hp = 1f;
        _button.gameObject.SetActive(false);
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
