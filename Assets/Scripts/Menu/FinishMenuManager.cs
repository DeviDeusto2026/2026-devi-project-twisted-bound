using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishMenuManager : MonoBehaviour
{
    [SerializeField] string mainMenuScene;
    public void MainMenu()
    {
        SceneManager.LoadScene(mainMenuScene);
    }
}
