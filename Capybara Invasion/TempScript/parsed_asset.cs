#pragma warning disable
using UnityEngine;
using cowsins;

public class TurretProjectile : MonoBehaviour {	
	public float damage;
	
	private void OnTriggerEnter(Collider other) {
		PlayerStats player = default(PlayerStats);
		if(!(other.CompareTag("Player"))) {
			return;
		}
		player = other.GetComponent<cowsins.PlayerStats>();
		player.Damage(damage);
		Object.Destroy(this.gameObject);
	}
}

