using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoorController : MonoBehaviour
{
    [SerializeField] private Animator myDoor = null;
	private bool openTrigger = true;
	
	
	private void OnTriggerEnter(Collider other) {
		if (other.CompareTag("Player")) {
			myDoor.Play("DoorOpen", 0, 0.0f);
		}
	}
	
	private void OnTriggerExit(Collider other) {
		if (other.CompareTag("Player")) {
			myDoor.Play("DoorClose", 0, 0.0f);
		}
	}
}
