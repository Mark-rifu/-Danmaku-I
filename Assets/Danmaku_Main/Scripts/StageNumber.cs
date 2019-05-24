using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// ★追加
using UnityEngine.SceneManagement;


public class StageNumber : MonoBehaviour {

	private Text stageNumberText;
	//classの中で使っているので、これはメンバ変数。



	// Use this for initialization
	void Start () {

		stageNumberText = this.gameObject.GetComponent<Text> ();
			//メンバ変数であるstageNumberText = this
		   //Textコンポーネントにアクセスする。

		// ★追加
		// 現在のシーンの名前を取得してtextプロパティにセットする（ポイント）
		stageNumberText.text = SceneManager.GetActiveScene().name;
		//アクティブなシーンの名前を取得、つまりstage2。

	}

	
	// Update is called once per frame
	void Update () {
	stageNumberText.color = Color.Lerp (stageNumberText.color, new Color (1, 1, 1, 0), 1.5f * Time.deltaTime);
	}
	// Lerp（a： Color、 b：Color、 t：float）
	//色aとの間を直線的に補間bします。aとbを統合するためのフロートがt。

}
