using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] InteractAction interactAction;
    // Start is called before the first frame update
    
    public void Interact(GameObject caller)
    {
        interactAction.TakeAction(caller, this.gameObject);
    }

}
