using UnityEngine.SceneManagement;
using UnityEngine;

public class startPlay : MonoBehaviour
{
    public void startGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void quitGame()
    {
        Application.Quit();
    }

}
