using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Run : MonoBehaviour
{
    [SerializeField] string combatController = "CombatController";


    /// <summary>
    /// Runs from scene when called.
    /// </summary>
    public void PressButton()
    {
        GameObject.Find(combatController).GetComponent<CombatController>().EndScene();
    }
}
