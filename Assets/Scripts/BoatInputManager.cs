using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatInputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerInput.InBoatActions inBoat;
    // stone edit
    public Transform boatVisual;
    //end of stone edit 

    private BoatMotor boatMotor;
    // Start is called before the first frame update
    void Awake()
    {
        playerInput = new PlayerInput();
        inBoat = playerInput.InBoat;
        boatMotor = GetComponent<BoatMotor>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        boatMotor.ProcessMove(inBoat.Movement.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        inBoat.Enable();
    }

    private void OnDisable()
    {
        inBoat.Disable();
    }
}
