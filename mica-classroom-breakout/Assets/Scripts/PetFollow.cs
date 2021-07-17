using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetFollow : MonoBehaviour
{
	
    public Transform transformToFollow;
    UnityEngine.AI.NavMeshAgent agent;
	private Animator m_Animator;
	
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
		m_Animator = GetComponent<Animator>();
    }

	bool hasReached() {
		if (!agent.pathPending) {
			if (agent.remainingDistance <= agent.stoppingDistance) {
				if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f) {
					return true;
				}
			}
		}
		
		return false;
	}
    void Update()
    {
		agent.SetDestination(transformToFollow.position);
		if (hasReached()) {
			m_Animator.SetBool("isWalking", false);
			m_Animator.SetBool("isRunning", false);
		} else {
			if (agent.remainingDistance >= agent.stoppingDistance * 4) {
				m_Animator.SetBool("isRunning", true);
			} else {
				m_Animator.SetBool("isWalking", true);
			}
		}
		
    }
}
