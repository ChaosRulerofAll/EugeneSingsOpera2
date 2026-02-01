using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public void Opera()
    {
        Debug.Log("*Warm Ups*");
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Debug.Log("*Voice Crack*");
        Application.Quit();
    }
}
