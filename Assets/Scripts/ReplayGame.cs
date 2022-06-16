using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ReplayGame : MonoBehaviour
{
    public void Replay()
    {
        SceneManager.LoadScene("Main");                         //button click load again game scene
    }
    public void Quit()
    {
        Application.Quit();                                         // button click end game
    }
}
