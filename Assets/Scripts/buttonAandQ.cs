using UnityEngine.SceneManagement;
using UnityEngine;

public class buttonAandQ : MonoBehaviour
{
    public void restartGame()
    {
        
        SceneManager.LoadScene("SampleScene");
       
    }

    public void quitGame()
    {
        Application.Quit();
    }

}
