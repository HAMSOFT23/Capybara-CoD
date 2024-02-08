#pragma warning disable
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.Rendering;

public class dynamicVolumeChanger : MonoBehaviour {	
	public static Volume volume;
	public List<object> effects = new List<object>();
	
	private void Start() {
		volume = base.gameObject.GetComponent<Volume>();
		GlitchInitialize();
	}
	
	public void GlitchInitialize() {
		volume.profile.TryGet<IE.RichFX.Glitch>(out var component);
		component.block.value = 0F;
		component.drift.value = 0F;
		component.jitter.value = 0F;
	}
	
	public void GlitchReset() {
		volume.profile.TryGet<IE.RichFX.Glitch>(out var component1);
		component1.block.value = 0F;
		component1.drift.value = 0F;
		component1.jitter.value = 0F;
	}
	
	public void GlitchTrigger(float dmgInflected) {
		volume.profile.TryGet<IE.RichFX.Glitch>(out var component2);
		component2.block.value = dmgInflected;
		component2.drift.value = dmgInflected;
		component2.jitter.value = dmgInflected;
		base.StartCoroutine(FxDuration(dmgInflected));
	}
	
	public System.Collections.IEnumerator FxDuration(float damageTime) {
		Debug.Log("Damage Taken is :" + damageTime.ToString());
		Debug.Log("Damage Time :" + (damageTime / 60F).ToString());
		yield return new WaitForSeconds((damageTime / 60F));
		GlitchReset();
	}
}

