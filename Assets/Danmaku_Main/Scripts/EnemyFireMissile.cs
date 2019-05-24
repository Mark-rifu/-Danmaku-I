using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireMissile : MonoBehaviour {


	public GameObject enemyMissilePrefab;
	public float missileSpeed;
	private int timeCount = 0;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


		timeCount += 1;

		// 「%」と「==」の意味を復習しましょう！（ポイント）
		if (timeCount % 60 == 0) {

			// 敵のミサイルを生成する

			GameObject enemyMissile = Instantiate (enemyMissilePrefab, transform.position, Quaternion.identity) as GameObject;

			Rigidbody enemyMissileRb = enemyMissile.GetComponent<Rigidbody> ();

			// ミサイルを飛ばす方向を決める。「forward」は「z軸」方向をさす（ポイント）

			enemyMissileRb.AddForce (transform.forward * missileSpeed);


			// ３秒後に敵のミサイルを削除する。
			Destroy (enemyMissile, 3.0f);
		}
	}
}

