using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ZombieGame : MonoBehaviour
{
	public AudioClip startSound;
	public AudioClip finishedSound;
	private AudioSource audioSource;
	public Text finishedText;

	void Start() {
		audioSource = GetComponent<AudioSource>();
	}

	private void OnTriggerEnter(Collider other) {
		if (! Player.isFinish) {
			audioSource.PlayOneShot(startSound);
			PlayerPrefs.SetFloat("Timer", TimerScript.currentTime);
			SceneManager.LoadScene("SurvivalGameScene");
		} else {
			audioSource.PlayOneShot(finishedSound);
			finishedText.text = "FINISHED ZOMBIES ARCADE";
		}
	}

	private void OnTriggerExit(Collider other) {
			finishedText.text = "";
	}
}
