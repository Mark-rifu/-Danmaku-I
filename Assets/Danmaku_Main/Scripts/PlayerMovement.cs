using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float moveSpeed = 0.2f;

	private Vector3 pos;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


		float moveH = -Input.GetAxis ("Horizontal") * moveSpeed;
		float moveV = -Input.GetAxis ("Vertical") * moveSpeed;
		transform.Translate (moveH, 0.0f, moveV);


		Clamp ();
	}


	// プレーヤーの移動できる範囲を制限する命令ブロック

	void Clamp(){


       pos = transform.position;

		pos.x = Mathf.Clamp (pos.x, -20, 20);

		pos.z = Mathf.Clamp (pos.z, -20, 20);

		//場所の-10〜10の間に移動を制限。

		transform.position = pos;






	}

}
