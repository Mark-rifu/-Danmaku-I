using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1UpItem : MonoBehaviour {

	public GameObject effectPrefab;
	public AudioClip getSound;
	private PlayerHealth PH;
	private int reward = 1;

	// Use this for initialization
	void Start () {

	// 「Player」についている「PlayerHealth」スクリプトにアクセスする。
		PH = GameObject.Find("Player").GetComponent<PlayerHealth>();

	}

	void OnTriggerEnter(Collider other){

		if (other.gameObject.CompareTag ("Missile")) {
			Instantiate (effectPrefab, transform.position, Quaternion.identity);

			//AudioSource.PlayClipAtPoint (getSound, Camera.main.transform.position);

			Destroy (this.gameObject);
			PH.Player1Up (reward);

		}

	}


}
