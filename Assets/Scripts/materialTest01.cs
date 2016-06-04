

using UnityEngine;
using System.Collections;

public class materialTest01 : MonoBehaviour {

	bool effect; //イベント(色のフェード)を制御するboolean

	float tmpSpecAlpha; //変動するスペキュラの透明度
	float tmpColorAlpha;//変動する色の透明度

	float specAlpha; //マテリアルで設定されたスペキュラの透明度
	float colorAlpha;//マテリアルで設定された色の透明度

	float tmpColor;//変動する色 (スペキュラの色は1.0fから引けばOK)

	float feedSpeed;//フェードするスピード

	// 各パラメータ初期化
	void Start () {
		effect = false;
		tmpSpecAlpha = 0.0f;
		tmpColorAlpha = 0.0f;
		specAlpha = this.GetComponent<Renderer> ().material.GetColor ("_SpecColor").a;
		colorAlpha = this.GetComponent<Renderer> ().material.GetColor ("_Color").a;
		tmpColor = 0.0f;
		feedSpeed = 0.5f;
	}
	
	// Update is called once per frame
	void Update () {
		//this.transform.Rotate (Time.deltaTime*10f, 0, 0); //デバッグ用、オブジェクトを回す

		//***** イベントが終わればすぐ else 文でまたイベントを発火させボタンがチカチカする処理になっている。 *****

		if (effect) { //イベント中

			//tmpSpecAlphaが元の透明度に戻るまでくりかえす
			if(tmpSpecAlpha >= specAlpha) tmpSpecAlpha -= Time.deltaTime * feedSpeed;

			//tmpColorAlphaが元の透明度に戻るまでくりかえす
			if(tmpColorAlpha >= colorAlpha) tmpColorAlpha -= Time.deltaTime * feedSpeed;

			//tmpColorが黒になるまでくりかえす
			if(tmpColor >= 0.0f) tmpColor -= Time.deltaTime * feedSpeed;

			//もし、3つのtmpパラメータが元の色に戻ったら、明示的に色を元に戻し、イベントをやめる。
			if (tmpSpecAlpha <= specAlpha && tmpColorAlpha <= colorAlpha && tmpColor <= 0.0f) {
				effect = false;
				tmpSpecAlpha = specAlpha;
				tmpColorAlpha = colorAlpha;
				tmpColor = 0.0f;
			}

			this.setColor ();// フィールドのtmpColorをマテリアルに適用
			this.setAlpha();// フィールドのtmpSpecAlphaとtmpColorAlphaをマテリアルに適用

		} else { //イベント外ではイベントを発生させる

			this.pushed ();// ボタンのマテリアルを白くする
			effect = true; //イベント発火
			tmpSpecAlpha = 1.0f; //不透明スタート
			tmpColorAlpha = 1.0f;//不透明スタート
			tmpColor = 1.0f;     //白色にしたい

		}

	}

	// フィールドのtmpColorをマテリアルに適用
	void setColor() {

		Color spec = this.GetComponent<Renderer> ().material.GetColor("_SpecColor");
		Color color = this.GetComponent<Renderer> ().material.GetColor("_Color");

		spec.r = 1.0f - tmpColor;
		spec.g = 1.0f - tmpColor;
		spec.b = 1.0f - tmpColor;

		color.r = tmpColor;
		color.g = tmpColor;
		color.b = tmpColor;

		this.GetComponent<Renderer> ().material.SetColor("_SpecColor", spec);
		this.GetComponent<Renderer> ().material.SetColor("_Color", color);

	}

	// フィールドのtmpSpecAlphaとtmpColorAlphaをマテリアルに適用
	void setAlpha() {

		Color spec = this.GetComponent<Renderer> ().material.GetColor("_SpecColor");
		Color color = this.GetComponent<Renderer> ().material.GetColor("_Color");

		spec.a = tmpSpecAlpha;
		color.a = tmpColorAlpha;

		this.GetComponent<Renderer> ().material.SetColor("_SpecColor", spec);
		this.GetComponent<Renderer> ().material.SetColor("_Color", color);

	}

	// ボタンのマテリアルを白くする
	void pushed() {

		Color spec = this.GetComponent<Renderer> ().material.GetColor("_SpecColor");
		Color color = this.GetComponent<Renderer> ().material.GetColor("_Color");
		//float tmpSpecAlpha = spec.a;
		spec = Color.black;
		color = Color.white;

		this.GetComponent<Renderer> ().material.SetColor("_SpecColor", spec);
		this.GetComponent<Renderer> ().material.SetColor("_Color", color);

	}
}
