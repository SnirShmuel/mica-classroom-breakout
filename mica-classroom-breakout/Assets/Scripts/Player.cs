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
           SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
		}
		
		if (kills >= 10) {
			isFinish = true;
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
		}
	}

	void OnControllerColliderHit(ControllerColliderHit hit) {
		if(hit.gameObject.tag == "BulletCase") {
			Physics.IgnoreCollision(GetComponent<Collider>(), hit.gameObject.GetComponent<Collider>());
		}
	}
}
