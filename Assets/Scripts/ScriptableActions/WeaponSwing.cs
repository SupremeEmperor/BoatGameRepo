using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Actions/WeaponSwing")]
public class WeaponSwing : Action
{
    [SerializeField] GameObject weapon;

    public override float TakeAction(Transform reticlePosition, Animator animator)
    {

        animator.SetTrigger(animationCall);
        //animator.ResetTrigger(animationCall);
        return base.TakeAction(reticlePosition, animator);
    }
}
