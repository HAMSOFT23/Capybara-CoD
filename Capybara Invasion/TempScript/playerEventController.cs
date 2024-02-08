#pragma warning disable
using UnityEngine;
using System.Collections.Generic;

public class playerEventController : MonoBehaviour {	
	public GameObject fPSPlayer;
	public float intenseGlitch;
	public float weakerGlitch;
	private float inflictedDamage;
	
	private void Awake() {
		fPSPlayer = base.GetComponentInChildren<cowsins.PlayerMovement>().gameObject;
	}
	
	public void TakingDamage(float damage) {
		float lessDamage = default(float);
		float playerHealth = default(float);
		playerHealth = fPSPlayer.GetComponent<cowsins.PlayerStats>().health;
		inflictedDamage = damage;
		if((inflictedDamage >= intenseGlitch)) {
			Debug.Log("Explosion Damage");
			dynamicVolumeChanger.volume.GetComponent<dynamicVolumeChanger>().GlitchTrigger(inflictedDamage);
		}
		 else if((inflictedDamage <= intenseGlitch)) {
			Debug.Log("Different Damage");
			dynamicVolumeChanger.volume.GetComponent<dynamicVolumeChanger>().GlitchTrigger(lessDamage);
		}
	}
	
	public void FallDamage() {
		float maxHealth = default(float);
		float healthDifference = default(float);
		float fallDamage = default(float);
		maxHealth = fPSPlayer.GetComponent<cowsins.PlayerStats>().maxHealth;
		fallDamage = (maxHealth - fPSPlayer.GetComponent<cowsins.PlayerStats>().health);
		dynamicVolumeChanger.volume.GetComponent<dynamicVolumeChanger>().GlitchTrigger(fallDamage);
	}
}

