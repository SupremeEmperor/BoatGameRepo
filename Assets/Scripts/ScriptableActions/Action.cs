using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Action : ScriptableObject
{
    [Tooltip("The Name of the Action")]
    [SerializeField] protected string actionName;
    [Tooltip("The Number of actions that will take place. (This is ussually one)")]
    [SerializeField] protected int numberOfActions;
    [Space]
    [Tooltip("How long the action takes in total")]
    [SerializeField] protected float totalActionTime;
    [SerializeField] AudioClip audioClip;
    protected Animator passedAnimator;
    [SerializeField] protected string animationCall = "Use";
    
    // Start is called before the first frame update
    public virtual float TakeAction(Transform reticlePosition)
    {
        if (audioClip != null)
        {
            SoundFXManager.instance.PlaySoundClip(audioClip, reticlePosition, 1f);
        }
        return totalActionTime;
    }

    public virtual float TakeAction(Transform reticlePosition, Animator animator)
    {
        passedAnimator = animator;
        return TakeAction(reticlePosition);
    }
}
