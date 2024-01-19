#pragma warning disable
using UnityEngine;
using cowsins;
using MoreMountains.Feel;
using MoreMountains.Feedbacks;

public class detonation : MonoBehaviour {	
	[SerializeField]
	[Tooltip("The amount of  Damage inflicted to the Player")]
	private float damage;
	[SerializeField]
	[Tooltip("The Sound Effect of the Explosion")]
	private AudioClip explosionFX;
	public int explosionVolume;
	[SerializeField]
	[Tooltip("Check if the damage has been set ")]
	private bool hasExploded;
	[SerializeField]
	private float deleteTime;
	public float shakeForce;
	public GameObject capyTexture;
	public GameObject capyHelmet;
	public GameObject bigExplosion;
	public GameObject camera;
	
	private void OnTriggerEnter(Collider other) {
		PlayerStats player = default(PlayerStats);
		if(!(other.CompareTag("Player"))) {
			return;
		}
		player = other.GetComponent<cowsins.PlayerStats>();
		this.GetComponent<AudioSource>().PlayOneShot(explosionFX, explosionVolume);
		player.Damage(damage);
		hasExploded = true;
		capyTexture.GetComponent<Component>().gameObject.SetActive(false);
		capyHelmet.GetComponent<Component>().gameObject.SetActive(false);
		bigExplosion.GetComponent<Component>().gameObject.SetActive(true);
		camera.GetComponent<CamShake>().ExplosionShake(shakeForce);
		base.StartCoroutine(DestroyObject());
	}
	
	public System.Collections.IEnumerator DestroyObject() {
		if(hasExploded) {
			Debug.Log("Has Exploded");
			yield return new WaitForSeconds(deleteTime);
			Object.Destroy(this.gameObject);
		}
	}
}

