using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetReticleInputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerInput.TargetReticleActions tarRetActions;
    private PlayerInput.AsCharacterActions asChar;

    private TargetReticleMotor targetReticleMotor;

    // Start is called before the first frame update
    void Awake()
    {
        playerInput = new PlayerInput();
        tarRetActions = playerInput.TargetReticle;
        asChar = playerInput.AsCharacter;
        targetReticleMotor = GetComponent<TargetReticleMotor>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        targetReticleMotor.ProcessMove(tarRetActions.Target.ReadValue<Vector2>(),asChar.Movement.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        tarRetActions.Enable();
    }

    private void OnDisable()
    {
        tarRetActions.Disable();
    }

}
