using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpItem : MonoBehaviour {


	public GameObject effectPrefab;
	public AudioClip getSound;
    private GameObject fireMissilePod1;
	private GameObject fireMissilePod2;

	//有効化させるので、発射口二つも変数宣言。


	// Use this for initialization
	void Start () {
		fireMissilePod1 = GameObject.Find("FireMissileB");
		fireMissilePod2 = GameObject.Find("FireMissileC");

		//２つの発射口のオブジェクトを特定。
	}

	void OnTriggerEnter(Collider other){


		if (other.gameObject.CompareTag ("Missile")) {

			Instantiate (effectPrefab, transform.position, Quaternion.identity);

			//AudioSource.PlayClipAtPoint(getSound,Camera.main.transform.position);

			// アイテムを画面から消す（非アクティブ状態にする）（ポイント）
			// ここでアイテムを破壊（Destror）するとメモリ上から消えて「Nomalメソッド」が実行されなくなるので注意！
			this.gameObject.SetActive(false);
			//this = PowerUpItem

			// 「FireMissile」スクリプトを有効にする。（ポイント）
			fireMissilePod1.GetComponent<FireMissile>().enabled = true;
			fireMissilePod2.GetComponent<FireMissile>().enabled = true;


			// 3秒後に元の状態（攻撃力）に戻す。
			Invoke("Normal",3);
		}
	}


	// プレーヤーの攻撃力を元に戻すメソッド



	void Normal(){

		// 「FireMissile」スクリプトを無効にする。（ポイント）
		fireMissilePod1.GetComponent<FireMissile>().enabled = false;
		fireMissilePod2.GetComponent<FireMissile>().enabled = false;

		Destroy (this.gameObject);
	}



}
