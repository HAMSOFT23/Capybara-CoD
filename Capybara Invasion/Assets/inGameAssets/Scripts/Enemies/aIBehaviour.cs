#pragma warning disable
using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

public class aIBehaviour : MonoBehaviour {	
	public aIStates states;
	public List<AudioClip> list = new List<AudioClip>() { null, null, null, null };
	public AudioClip newVariable;
	
	private void Start() {
		states = aIStates.idle;
		list.Add(newVariable);
	}
	
	private void Update() {
		switch(states) {
			case aIStates.idle: {
				idleState();
			}
			break;
			case aIStates.patrol: {
			}
			break;
			case aIStates.sight: {
			}
			break;
			case aIStates.attack: {
			}
			break;
			case aIStates.dead: {
			}
			break;
		}
	}
	
	public void idleState() {
	}
}

