using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PeopleMovement : MonoBehaviour {
	NavMeshAgent agent;
	public Transform goal;
	public Transform P1;
	public Transform P2;
	bool partrol = true;
	bool left = true;
	float dist = 10000f;

	void Start () {
		agent = GetComponent<NavMeshAgent> ();
		agent.destination = P1.position;

	}

	void Update() {
		//calculate the distance of current enemy and hero
		dist = Vector3.Distance (agent.transform.position, goal.position);
		if (dist < 4) {
			partrol = false;
		} else {
			partrol = true;
		}

		//define the behavior of the partrol and move toward player
		if (partrol) {
			// Move to next Patrol Point using the NavMeshAgent
			if (agent.remainingDistance == 0) {
				if (!left) {
					agent.destination = P2.position;
					left = true;
				} else {
					agent.destination = P1.position;
					left = false;
				}
			}
		} else {
			agent.destination = goal.position;
		}
	}
}
