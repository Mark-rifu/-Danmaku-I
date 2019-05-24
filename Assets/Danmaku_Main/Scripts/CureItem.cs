using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CureItem : MonoBehaviour {

	public GameObject effectPrefab;
	public AudioClip getSound;
	private PlayerHealth playerHealth;
	private int reward = 3;


	//回復アイテムを作るためには、
	//回復のエフェクト、回復サウンド、PlayerHealthスクリプトに接続するための変数、回復量を入れる変数。


	// Use this for initialization
	void Start () {

	    reward = 3;

		// 「Player」についている「PlayerHealth」スクリプトにアクセスする。
		//自分以外のオブジェクトの持つコンポーネントにアクセスする方法。
		//①Findメソッドでオブジェクトを探す。
		//②GetComponentメソッドで、そのオブジェクトの持つコンポーネントを取得。
	    //③コンポーネントの持つデータにアクセス。

	    playerHealth = GameObject.Find ("Player").GetComponent<PlayerHealth> ();

	}



	void OnTriggerEnter(Collider other){
		
		// プレーヤーのミサイルで破壊するとHPが回復する。
		if (other.gameObject.CompareTag ("Missile")) {

			Instantiate(effectPrefab, transform.position, Quaternion.identity);

			//AudioSource.PlayCilpAtPoint(getSound, Camera.main.transform.position);

			Destroy(this.gameObject);

			//this = CureItem。

			playerHealth.AddHP(reward);

		}

	}



}
