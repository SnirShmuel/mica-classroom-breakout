using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleTrigger : MonoBehaviour
{
	private bool finished = false;

	private void OnTriggerEnter(Collider other) {
		if (! DragAndDropScript.isFinish) {
			SceneManager.LoadScene("PuzzleScene");
		} else {
			Debug.Log("Puzzle was finished");
		}
	}
}
