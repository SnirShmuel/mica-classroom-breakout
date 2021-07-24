using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoorController : MonoBehaviour
{
    [SerializeField] private Animator myDoor = null;
	public AudioClip openSound;
	public AudioClip closeSound;

	private AudioSource audioSource;
	private bool openTrigger = true;
	
	void Start() {
		audioSource = GetComponent<AudioSource>();
	}
	
	private void OnTriggerEnter(Collider other) {
		if (other.CompareTag("Player")) {
			audioSource.PlayOneShot(openSound);
			myDoor.Play("DoorOpen", 0, 0.0f);
		}
	}
	
	private void OnTriggerExit(Collider other) {
		if (other.CompareTag("Player")) {
			audioSource.PlayOneShot(closeSound);
			myDoor.Play("DoorClose", 0, 0.0f);
		}
	}
}
