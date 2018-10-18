using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadAnimation : StateMachineBehaviour {

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (WeaponController.instance.currentAmmo < WeaponController.instance.AmmoSettings.ammo && WeaponController.instance.AmmoSettings.totalAmmo > 0)
        {
            if (!animator.GetBool("stopReload"))
            {
                WeaponController.instance.currentAmmo += 1;
                // Remove 1 ammo
                WeaponController.instance.AmmoSettings.totalAmmo -= 1;
                //Debug.Log("0");
            }

            if (WeaponController.instance.currentAmmo >= WeaponController.instance.AmmoSettings.ammo || WeaponController.instance.AmmoSettings.totalAmmo <= 0)
            {
                animator.SetBool("stopReload", true);
            }
        }
    }
}
