using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DangerZone : MonoBehaviour
{
    [SerializeField] List<string> encounterNames;
    [SerializeField] float encounterRate;
    [SerializeField] float timeBetweenChecks;
    float lastTimeChecked;

    private void Start()
    {
        lastTimeChecked = Time.time;
    }

    /// <summary>
    /// When a game object is moving inside the field it attempts to send the player into a battle scene.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.GetComponent<Rigidbody>().velocity.magnitude <= .5)
        {

            return;
        }
        Debug.Log("The velocity is: " + other.gameObject.GetComponent<Rigidbody>().velocity.magnitude);

        if(Time.time - lastTimeChecked > timeBetweenChecks)
        {
            if (Random.Range(0,100) > encounterRate)
            {
                lastTimeChecked = Time.time;
                return;
            }
            
            int encounter = (int)Random.Range(0, encounterNames.Count);
            SceneManager.LoadSceneAsync(encounterNames[encounter]);

            lastTimeChecked = Time.time;
        }
    }
}
