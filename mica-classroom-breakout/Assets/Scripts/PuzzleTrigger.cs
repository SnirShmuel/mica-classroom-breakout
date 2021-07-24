using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PuzzleTrigger : MonoBehaviour
{
	public Text finishedText;

	private void OnTriggerEnter(Collider other) {
		if (! DragAndDropScript.isFinish) {
			SceneManager.LoadScene("PuzzleScene");
		} else {
			finishedText.text = "FINISHED PUZZLE";
		}
	}

	private void OnTriggerExit(Collider other) {
		finishedText.text = "";
	}
}
