using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class Player : MonoBehaviour {
	HealthManager healthManager;
	bool isDestroyed = false;
	public int kills;
    public static bool isFinish = false;

	void Start() {
		healthManager = GetComponent<HealthManager>();
		kills = 0;
	}

	void Update() {
		if(healthManager.IsDead && !isDestroyed) {
           SceneManager.LoadScene("GameScene");
		}
		
		if (kills >= 1) {
			isFinish = true;
			SceneManager.LoadScene("GameScene");
		}
	}

	void OnControllerColliderHit(ControllerColliderHit hit) {
		if(hit.gameObject.tag == "BulletCase") {
			Physics.IgnoreCollision(GetComponent<Collider>(), hit.gameObject.GetComponent<Collider>());
		}
	}
}
