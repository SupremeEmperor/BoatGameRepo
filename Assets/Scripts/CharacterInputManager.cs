using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerInput.AsCharacterActions asChar;

    private CharacterMotor characterMotor;
    private SpellCastMotor spellCastMotor;
    private SecondaryActionMotor secondaryActionMotor;
    // Start is called before the first frame update
    void Awake()
    {
        playerInput = new PlayerInput();
        asChar = playerInput.AsCharacter;
        characterMotor = GetComponent<CharacterMotor>();
        spellCastMotor = GetComponent<SpellCastMotor>();
        secondaryActionMotor = GetComponent<SecondaryActionMotor>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        characterMotor.ProcessMove(asChar.Movement.ReadValue<Vector2>());
        spellCastMotor.Fire(asChar.Fire.ReadValue<float>());
        secondaryActionMotor.Action(asChar.SecondaryAction.ReadValue<float>());
        secondaryActionMotor.Release(asChar.Release.ReadValue<float>());

    }

    private void OnEnable()
    {
        asChar.Enable();
    }

    private void OnDisable()
    {
        asChar.Disable();
    }
}
