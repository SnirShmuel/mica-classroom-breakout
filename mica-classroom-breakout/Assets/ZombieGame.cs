using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZombieGame : MonoBehaviour
{
	private void OnTriggerEnter(Collider other) {
		if (! Player.isFinish) {
			SceneManager.LoadScene("SurvivalGameScene");
		} else {
			Debug.Log("ZombieGame was finished");
		}
	}
}
