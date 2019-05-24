using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerHealth : MonoBehaviour {

	public GameObject effectPrefab;
	public AudioClip damageSound;
	public AudioClip destroySound;
	public int playerHP;
	private int maxHP;
	private Slider playerHPSlider;


	public GameObject[] playerIcons;
	//配列を使うと、playerIcon、一つ一つをインスペクタでいじれる。


	public int destroyCount = 0;
	//破壊された回数のデータ。

	void Start(){
		//playerHP = 4;
		maxHP = playerHP;
		playerHPSlider = GameObject.Find ("PlayerHPSlider").GetComponent<Slider> ();
		playerHPSlider.maxValue = playerHP;
		playerHPSlider.value = playerHP;

	}


	void OnTriggerEnter(Collider other){

		if (other.gameObject.CompareTag ("EnemyMissile")) {

			playerHP -= 1;
			AudioSource.PlayClipAtPoint (damageSound,Camera.main.transform.position);
			//PlayClipAtPoint（clip： AudioClip、 position：Vector3、 volume：float = 1.0F）

			playerHPSlider.value = playerHP;
			//HPの可変を管理するvalueに、playHP変数を代入。

			Destroy(other.gameObject);

			if (playerHP == 0) {

				destroyCount += 1;

				UpdatePlayerIcons ();


				GameObject effect = Instantiate (effectPrefab, transform.position, Quaternion.identity) as GameObject;
				Destroy (effect, 1.0f);
				AudioSource.PlayClipAtPoint (destroySound, Camera.main.transform.position);

				// プレーヤーを破壊するのではなく、非アクティブ状態にする（ポイント）
				this.gameObject.SetActive (false);


				// 破壊された回数によって場合分けを行います。
				if (destroyCount < 4) 
					
					// リトライの命令ブロック（メソッド）を１秒後に呼び出す。
					Invoke ("Retry", 1.0f);

					else
						//4を越えると、GameOverシーンに移動。
						SceneManager.LoadScene("GameOver");
					




			}
		}
	}

	void UpdatePlayerIcons(){

		for (int i = 0; i < playerIcons.Length; i++) {

			if (destroyCount <= i)
				playerIcons [i].SetActive (true);
			else
				playerIcons [i].SetActive (false);
		}
			
			
		}

	void Retry(){
		this.gameObject.SetActive (true);
		playerHP = maxHP;
		playerHPSlider.value = playerHP;

	}

	//HP回復アイテムの実装。

	public void AddHP(int amount){


		// 「amount」分だけHPを回復させる。
		playerHP += amount;

		// 最大HP以上には回復しないようにする。

		if (playerHP > maxHP) 
			playerHP = maxHP;

			playerHPSlider.value = playerHP;

		}


		// ★追加（自機1UPアイテム）
		// 「public」を付けること（ポイント）
		public void Player1Up(int amount){
			// amount分だけ自機の残機を回復させる。
			// （考え方）破壊された回数（「destroyCount」）をamount分だけ減少させる。

			destroyCount -= amount;

			// 最大残機数を超えないようにする（破壊された回数が０未満にならないようにする）

			if(destroyCount < 0)
			   destroyCount = 0;

				// 残機数を表示するUI（アイコン）

				for(int i = 0;i < playerIcons.Length; i++){
					if(destroyCount <= i)
						playerIcons[i].SetActive(true);
					else
						playerIcons[i].SetActive(false);
					

				}

			}

		}



