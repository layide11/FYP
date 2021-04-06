using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{  

    // called when play button is clicked to load game 
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +2);
    }


    public void ViewLeaderBoard()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
   

    // called when QUit button is clicked
    public void QuitGame()
    {
        Application.Quit();
    }

}
