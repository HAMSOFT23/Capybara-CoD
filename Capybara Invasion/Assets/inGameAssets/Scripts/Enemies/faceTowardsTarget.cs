#pragma warning disable
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cowsins;

public class faceTowardsTarget : MonoBehaviour {	
	[SerializeField]
	[Tooltip("The Target the Enemy will look at")]
	private Transform target;
	[SerializeField]
	[Tooltip("Looking Speed")]
	private float speed;
	
	private void Awake() {
		target = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	private void Update() {
		Vector3 targetDirection = default(Vector3);
		float singleStep = default(float);
		Vector3 newDirection = default(Vector3);
		//Determine which direction to rotate towards
		targetDirection = (target.position - this.transform.position);
		//The step size is equal to speed times frame time.
		singleStep = (speed * Time.deltaTime);
		//Rotate the forward vector towards the target direction by one step
		newDirection = Vector3.RotateTowards(this.transform.forward, targetDirection, singleStep, 0F);
		//Draw a ray pointing at our target in
		Debug.DrawRay(this.transform.position, newDirection, new Color() { r = 1F, g = 1F, a = 1F });
		//Calculate a rotation a step closer to the target and applies rotation to this object
		this.transform.rotation = Quaternion.LookRotation(newDirection);
	}
}

