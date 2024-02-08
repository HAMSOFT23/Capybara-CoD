#pragma warning disable
using UnityEngine;
using cowsins;
using MoreMountains.Feel;
using MoreMountains.Feedbacks;

public class detonation : MonoBehaviour {	
	[SerializeField]
	[Tooltip("The amount of  Damage inflicted to the Player")]
	[Header("Explosion FX")]
	[Range(0F, 100F)]
	private float damage;
	[SerializeField]
	[Range(0F, 4F)]
	private float deleteTime;
	[Range(0F, 4F)]
	public float shakeForce;
	[SerializeField]
	[Tooltip("Check if the damage has been set ")]
	private bool hasExploded;
	[SerializeField]
	[Tooltip("The Sound Effect of the Explosion")]
	private AudioClip explosionSFX;
	[Range(0F, 6F)]
	public int explosionVolume;
	[Header(" Game Obejects")]
	public GameObject capyTexture;
	public GameObject capyHelmet;
	public GameObject bigExplosion;
	public GameObject camera;
	[Header("Glitch Effects")]
	[Range(0F, 1F)]
	public float glitchBlock;
	[Range(0F, 1F)]
	public float glitchDrift;
	[Range(0F, 1F)]
	public float glitchJitter;
	
	private void Start() {
		var Node_4 = GameObject.FindGameObjectWithTag("MainCamera");
		camera = Node_4;
	}
	
	private void OnTriggerEnter(Collider other) {
		PlayerStats player = default(PlayerStats);
		if(!(other.CompareTag("Player"))) {
			return;
		}
		 else {
			player = other.GetComponent<cowsins.PlayerStats>();
			this.GetComponent<AudioSource>().PlayOneShot(explosionSFX, explosionVolume);
			player.Damage(damage);
			player.transform.root.GetComponent<playerEventController>().TakingDamage(damage);
			hasExploded = true;
			capyTexture.GetComponent<Component>().gameObject.SetActive(false);
			capyHelmet.GetComponent<Component>().gameObject.SetActive(false);
			bigExplosion.GetComponent<Component>().gameObject.SetActive(true);
			camera.GetComponent<CamShake>().ExplosionShake(shakeForce);
			base.StartCoroutine(DestroyObject());
		}
	}
	
	public System.Collections.IEnumerator DestroyObject() {
		if(hasExploded) {
			Debug.Log("Has Exploded");
			base.GetComponent<UnityEngine.BoxCollider>().enabled = false;
			base.GetComponent<UnityEngine.SphereCollider>().enabled = false;
			yield return new WaitForSeconds(deleteTime);
			Object.Destroy(this.gameObject);
		}
	}
}

