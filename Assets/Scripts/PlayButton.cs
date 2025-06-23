using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    [SerializeField] string nextScene;

    public void PressButton()
    {
        SceneManager.LoadScene(nextScene);
    }
}
