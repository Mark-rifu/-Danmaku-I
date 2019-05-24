using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireMissileB : MonoBehaviour {

	public GameObject enemyMissilePrefab;
	public float missileSpeed;
	private int timeCount = 0;

	void Update () {

		timeCount += 1;

		// 発射間隔を短くする。
		// 「%」と「==」の意味を復習しましょう！（ポイント）;

		if (timeCount % 5 == 0) {
			GameObject enemyMissile = Instantiate (enemyMissilePrefab, transform.position, Quaternion.identity) as GameObject;
			Rigidbody enemyMissileRb = enemyMissile.GetComponent<Rigidbody> ();
			enemyMissileRb.AddForce (transform.forward * missileSpeed);

			// 10秒後に敵のミサイルを削除する。
			Destroy (enemyMissile, 10.0f);
		}

		if(timeCount == 500){

			// timeCountが500になった時、このオブジェクトにRotateスクリプトを付加する。
			//gameObject.AddComponentは、そのクラスのゲームオブジェクトにアタッチされているスクリプトを付与する関数。

			this.gameObject.AddComponent<Rotate> ().pos = new Vector3 (0, 90, 0);
			//this = enemyMissilePrefab
	}
}
}
