using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldItem : MonoBehaviour {


	public GameObject effectPrefab;
	public AudioClip getSound;
	public GameObject shieldPrefab;

	private GameObject player;
	private Vector3 pos;

	//プレイヤーの位置情報を取得するために、playerのオブジェクトと位置情報を取得する変数宣言。

	void OnTriggerEnter(Collider other){
		if (other.CompareTag ("Missile")) {

			// エフェクトと効果音を発生させる。
			Instantiate(effectPrefab,transform.position,Quaternion.identity);
			//AudioSource.PlayClipAtPoint (getSound, Camera.main.transform.position);


			// プレーヤーの位置情報を取得する。
			player = GameObject.Find("Player");
			pos = player.transform.position;


			// プレーヤーの側面の位置に２枚の防御シールドを発生させる。
			GameObject shieldA = (GameObject)Instantiate (shieldPrefab, new Vector3 (pos.x - 1, pos.y, pos.z), Quaternion.identity);
			GameObject shieldB = (GameObject)Instantiate (shieldPrefab, new Vector3 (pos.x + 1, pos.y, pos.z), Quaternion.identity);


			// 発生させた防御シールドをプレーヤーの子供に設定する（親子関係）
			// 親子関係にすることで一緒に動くようになる。
			shieldA.transform.SetParent(player.transform);
			shieldB.transform.SetParent(player.transform);
			//SetParentメソッドは、引数に指定したものを親要素とする。


			// 発生させた防御シールドを５秒後に消滅させる。
			Destroy(shieldA,5);
			Destroy(shieldB,5);

			//アイテムを破壊する。
			Destroy(gameObject);


		}

	}


}
