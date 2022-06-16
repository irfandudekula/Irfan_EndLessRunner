using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBar : MonoBehaviour
{
    public void Playgame()
    {
        SceneManager.LoadScene("Main");                     // on button click play the game
    }

    public void Quit()
    {
        Application.Quit();                         // on button click end the game
    }
}
