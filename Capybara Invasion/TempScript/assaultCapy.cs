#pragma warning disable
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {	
	[SerializeField]
	[Tooltip("Max Speed of the Enemy")]
	private float maxSpeed;
	[Tooltip("Current Speed of the Enemy")]
	private float Speed;
	private Collider[] hitColliders;
	private RaycastHit Hit;
	[SerializeField]
	[Tooltip("Distance in which the Enemy can see the player")]
	private float sightRange;
	[SerializeField]
	[Tooltip("Distance in which the Enemy will detect the player")]
	private float detectionRange;
	[SerializeField]
	[Tooltip("Rigidbody of the Enemy ")]
	private Rigidbody rb;
	[SerializeField]
	[Tooltip("The target the Capybara is aiming at")]
	private GameObject Target;
	[SerializeField]
	[Tooltip("Check if the player has been spotted")]
	private bool seePlayer;
	private Vector3 Heading;
	private Vector3 Direction;
	private Vector3 Move;
	private float Distance;
	
	private void Start() {
		Speed = maxSpeed;
	}
	
	private void OnDrawGizmos() {
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(this.transform.position, detectionRange);
		Gizmos.color = new Color() { r = 0.1573993F, g = 1F, a = 1F };
		Gizmos.DrawLine(this.transform.position, Vector3.ClampMagnitude((Target.transform.position - this.transform.position), sightRange));
	}
	
	private void FixedUpdate() {
		ChasePlayer();
	}
	
	public void ChasePlayer() {
		if(!(seePlayer)) {
			hitColliders = Physics.OverlapSphere(this.transform.position, detectionRange);
			foreach(Collider loopValue in hitColliders) {
				if((loopValue.tag == "Player")) {
					Target = loopValue.gameObject;
					seePlayer = true;
				}
			}
		}
		 else if(Physics.Raycast(this.transform.position, (Target.transform.position - this.transform.position), out Hit, sightRange)) {
			if((Hit.collider.tag != "Player")) {
				seePlayer = false;
			}
			 else {
				//calculate the direction
				Heading = (Target.transform.position - this.transform.position);
				Distance = Heading.magnitude;
				Direction = (Heading / Distance);
				//move enemy towards Player
				Move = new Vector3((Direction.x * Speed), 0, (Direction.z * Speed));
				rb.velocity = Move;
				this.transform.forward = Move;
			}
		}
	}
}

