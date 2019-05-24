using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMissile : MonoBehaviour {

	public GameObject missilePrefab;
	public float missileSpeed;
	public AudioClip fireSound;


	private int timeCount;
	//長押しで連続的に発射するための数字を管理する変数。

	// Use this for initialization
	//void Start () { }
		
	
	// Update is called once per framet
	void Update () {

		timeCount += 1;

		// ★改良（長押し連射）
		// 「GetButtonDown」を「GetButton」に変更する（ポイント）


	if (Input.GetButton("Fire1")) {


			// ★改良（長押し連射）
			// 「5」の部分の数字を変えると「連射の間隔」を変更することができます（ポイント）
			// 「%」と「==」の意味合いを復習しましょう。
			if( timeCount % 5 == 0){

			GameObject missile = Instantiate (missilePrefab, transform.position, Quaternion.identity)as GameObject;
			
			Rigidbody missileRb = missile.GetComponent<Rigidbody> ();


			missileRb.AddForce (transform.forward * missileSpeed);

			AudioSource.PlayClipAtPoint (fireSound, transform.position);


			Destroy (missile, 2.0f);

		}
	//Instantiate(オブジェクト、位置、角度)

	}
}
}
