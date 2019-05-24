using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//コンポーネントではなく、スクリプトで5発の弾を発射する仕組みを作る場合。


public class NWay : MonoBehaviour {


	public GameObject enemyFireMissilePrefab;
	//どの弾を。

	public int wayNumber;
	//どの方向に打つか。



	// Use this for initialization
	void Start () {

		for(int i = 0;i < wayNumber;i++){

			// Instantiate()は、プレハブからクローンを産み出すメソッド（重要ポイント）
			// Quaternion.Euler(x, y, z)、Eulerは、回転を生み出す関数。
			// 今回は「i = 0の時 → y = -30」「i = 1の時 → y = -15」「i = 2の時 → y = 0」「i = 3の時 → y = 15」「i = 4の時 → y = 15」になるようにする。
			//y軸のiに数字を1ずつ代入していくと、上のような数字になる。
			GameObject enemyFireMissile = Instantiate(enemyFireMissilePrefab,transform.position,Quaternion.Euler(0,7.5f -(7.5f * i),0));

			// SetParent()は親子関係を作るメソッド（ポイント）
			// 『このスクリプトが付いているNWayオブジェクトをenemyFireMissileクローンの親に設定する。』
			enemyFireMissile.transform.SetParent(this.gameObject.transform);

			//this.gameObject.transformは、NwayクラスのgameObjectがもつ、transformを示す。
	}
	
	// Update is called once per frame
	
}
}
