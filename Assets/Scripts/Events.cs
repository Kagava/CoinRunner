using UnityEngine.SceneManagement;
using UnityEngine;

public class Events : MonoBehaviour
{
   public void restartGame()
   {
        SceneManager.LoadScene("SampleScene");
   }

    public void qiitGame()
    {
        Application.Quit();
    }
}
