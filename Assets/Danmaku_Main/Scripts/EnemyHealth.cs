using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;


public class EnemyHealth : MonoBehaviour {


	public GameObject effectPrefab;
	public AudioClip destroySound;
	public int enemyHP;

	private Slider slider;

	public int scoreValue;
	private ScoreManager sm;
	//破壊された際の得点を入れる変数と、スコアを管理するスクリプトとつなげるための変数。

	public GameObject[] itemPrefab;
	//配列ver
	//publicで配列にすると、インスペクタで指定できる数をいじれる。


	//public GameObject itemPrefab;
	//敵を倒すとアイテム出現。itemPrefabをインスペクタでいじって、
	//Instantiateメソッドでインスタンスを呼び出す。



	void Start(){
		
		
		// （ポイント）GameObject.Find ("○○")の使い方を覚えよう。名前でオブジェクトを指定できる。
		slider = GameObject.Find ("EnemyHPSlider").GetComponent<Slider> ();
	
		// スライダーの最大値の設定
		slider.maxValue = enemyHP;

		// スライダーの現在値の設定
		slider.value = enemyHP;

		// 「ScoreLabel」オブジェクトについている「ScoreManager」スクリプトにアクセスして取得する（ポイント）
		sm = GameObject.Find ("ScoreLabel").GetComponent<ScoreManager> ();

	}


	void OnTriggerEnter(Collider other){

		if (other.gameObject.CompareTag ("Missile")) {

			// エフェクトを発生させる
		    GameObject effect = Instantiate (effectPrefab, transform.position, Quaternion.identity) as GameObject;


			Destroy (effect, 0.5f);

			enemyHP -= 1;

			slider.value = enemyHP;

			// 敵のHPが０になったら敵オブジェクトを破壊する。
			Destroy (other.gameObject);


			if(enemyHP == 0){
				
				// 親オブジェクトを破壊する（ポイント；この使い方を覚えよう！）
				Destroy (transform.root.gameObject);


				// ★追加（アイテム出現）
				// 敵を破壊した瞬間＝敵のHPが0になった瞬間にアイテムプレハブを実体化させる。
				//Instantiate(itemPrefab,transform.position,Quaternion.identity);
			

				//配列ver
				// ★追加（ランダム出現）
				// ランダムメソッドの活用（ポイント）
				GameObject dropItem = itemPrefab[Random.Range(0,itemPrefab.Length)];
				//0〜インスタンスで設定した数の中から、ランダムに呼び出すメソッドを
				//変数に入れる。

				// ★改良（ランダム出現）
				// ランダムに選んだアイテムを実体化する。
				Instantiate(dropItem,transform.position,Quaternion.identity);



				// 破壊の効果音を出す
				//ワールド空間内の指定された位置でAudioClipを再生します。

				//この関数はAudioSourceを作成しますクリップの再生が終了したらそれを自動的に破棄します。
				AudioSource.PlayClipAtPoint(destroySound,transform.position);

				// 敵を破壊した瞬間にスコアを加算するメソッドを呼び出す。
				// 引数には「scoreValue」を入れる。
				sm.AddScore (scoreValue);


		}

		

	}


}
}
