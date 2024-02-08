#pragma warning disable
using UnityEngine;
using System.Collections.Generic;
using System;

/// <summary>
/// All of FPS Engines Unity Events linked up to delegates
/// 
/// </summary>
public class FPS_Events : MonoBehaviour {	
	public event Action FPS_EquipWeapon;
	public event Action FPS_InventorySlotChanged;
	public event Action FPS_Hit;
	public event Action FPS_StopAim;
	public event Action FPS_Aiming;
	public event Action FPS_Aim;
	public event Action FPS_FinishReload;
	public event Action FPS_Reload;
	public event Action FPS_Shoot;
	public event Action FPS_Move;
	public event Action FPS_Jump;
	public event Action FPS_Land;
	public event Action FPS_Crouch;
	public event Action FPS_StopCrouch;
	public event Action FPS_Sprint;
	public event Action FPS_Spawn;
	public event Action FPS_Slide;
	public event Action FPS_StartWallRun;
	public event Action FPS_StopWallRun;
	public event Action FPS_WallBounce;
	public event Action FPS_StartDash;
	public event Action FPS_Dashing;
	public event Action FPS_EndDash;
	public event Action FPS_Death;
	public event Action FPS_Damage;
	public event Action FPS_Heal;
	public event Action FPS_FinishedInteraction;
	
	public void EquipWeapon() {
		if(!(FPS_EquipWeapon == null)) {
			FPS_EquipWeapon.Invoke();
		}
	}
	
	public void Hit() {
		if(!(FPS_Hit == null)) {
			FPS_Hit.Invoke();
		}
	}
	
	public void Shoot() {
		if(!(FPS_Shoot == null)) {
			FPS_Shoot.Invoke();
		}
	}
	
	public void Reload() {
		if(!(FPS_Reload == null)) {
			FPS_Reload.Invoke();
		}
	}
	
	public void FinishReload() {
		if(!(FPS_FinishReload == null)) {
			FPS_FinishReload.Invoke();
		}
	}
	
	public void Aim() {
		if(!(FPS_Aim == null)) {
			FPS_Aim.Invoke();
		}
	}
	
	public void Aiming() {
		if(!(FPS_Aiming == null)) {
			FPS_Aiming.Invoke();
		}
	}
	
	public void StopAim() {
		if(!(FPS_StopAim == null)) {
			FPS_StopAim.Invoke();
		}
	}
	
	public void InventorySlotChanged() {
		if(!(FPS_InventorySlotChanged == null)) {
			FPS_InventorySlotChanged.Invoke();
		}
	}
	
	public void Move() {
		if(!(FPS_Move == null)) {
			Debug.Log("Moving");
			FPS_Move.Invoke();
		}
	}
	
	public void Jump() {
		if(!(FPS_Jump == null)) {
			Debug.Log("Jumping");
			FPS_Jump.Invoke();
		}
	}
	
	public void Land() {
		if(!(FPS_Land == null)) {
			Debug.Log("Land");
			FPS_Land.Invoke();
		}
	}
	
	public void Crouch() {
		if(!(FPS_Crouch == null)) {
			Debug.Log("Crouch");
			FPS_Crouch.Invoke();
		}
	}
	
	public void StopCrouch() {
		if(!(FPS_StopCrouch == null)) {
			Debug.Log("StopCrouch");
			FPS_StopCrouch.Invoke();
		}
	}
	
	public void Sprint() {
		if(!(FPS_Sprint == null)) {
			Debug.Log("Sprint");
			FPS_Sprint.Invoke();
		}
	}
	
	public void Spawn() {
		if(!(FPS_Spawn == null)) {
			Debug.Log("Spawn");
			FPS_Spawn.Invoke();
		}
	}
	
	public void Slide() {
		if(!(FPS_Slide == null)) {
			Debug.Log("Slide");
			FPS_Slide.Invoke();
		}
	}
	
	public void StartWallRun() {
		if(!(FPS_StartWallRun == null)) {
			FPS_StartWallRun.Invoke();
		}
	}
	
	public void StopWallRun() {
		if(!(FPS_StopWallRun == null)) {
			FPS_StopWallRun.Invoke();
		}
	}
	
	public void WallBounce() {
		if(!(FPS_WallBounce == null)) {
			FPS_WallBounce.Invoke();
		}
	}
	
	public void StartDash() {
		if(!(FPS_StartDash == null)) {
			FPS_StartDash.Invoke();
		}
	}
	
	public void Dashing() {
		if(!(FPS_Dashing == null)) {
			FPS_Dashing.Invoke();
		}
	}
	
	public void EndDash() {
		if(!(FPS_EndDash == null)) {
			FPS_EndDash.Invoke();
		}
	}
	
	public void Heal() {
		if(!(FPS_Heal == null)) {
			FPS_Heal.Invoke();
		}
	}
	
	public void Damage() {
		if(!(FPS_Damage == null)) {
			FPS_Damage.Invoke();
		}
	}
	
	public void Death() {
		if(!(FPS_Death == null)) {
			FPS_Death.Invoke();
		}
	}
	
	public void FinishedInteraction() {
		if(!(FPS_FinishedInteraction == null)) {
			FPS_FinishedInteraction.Invoke();
		}
	}
}

