using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;


public class ScoreManager : MonoBehaviour {


	 private int score = 0;
	 private Text scoreLabel;
	//数字を入れるための変数と、
	//UIのテキストコンポーネントをいじるための変数。


	// Use this for initialization
	void Start () {

		scoreLabel = this.gameObject.GetComponent<Text> ();

		scoreLabel.text = "Score " + score;

		//これで、テキストコンポーネントにアタッチして、テキストの変更が可能。

	}


	// スコアを加算するメソッド（命令ブロック）
	// 「public」をつけて外部からこのメソッドにアクセスできるようにする（重要ポイント）
	public void AddScore(int amount){

		score += amount;

		scoreLabel.text = "Score " + score;


	}
	

}
