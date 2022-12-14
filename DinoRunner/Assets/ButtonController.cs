using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public GameObject soundClick;
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
 


    public void QuitGame()
    {
        Application.Quit();
    }
    

    public void SoundClick()
    {
        Instantiate(soundClick);
    }
}
