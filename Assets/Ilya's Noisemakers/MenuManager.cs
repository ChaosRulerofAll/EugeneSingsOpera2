using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public void Opera()
    {
        Debug.Log("*Warm Ups*");
        //SceneManager.LoadScene("Don't Know the Name of the Scene Yet");
    }

    public void Exit()
    {
        Debug.Log("*Voice Crack*");
        Application.Quit();
    }
}
