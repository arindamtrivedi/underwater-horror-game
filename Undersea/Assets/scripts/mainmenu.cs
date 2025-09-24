using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{
    public void start_Game()
    {
        SceneManager.LoadScene(1);
    }

    public void end_Game()
    {
        Application.Quit();
    }
}
