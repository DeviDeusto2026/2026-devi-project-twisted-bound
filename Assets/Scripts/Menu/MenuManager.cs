using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] string mainScene;
    public void Play()
    {
        SceneManager.LoadScene(mainScene);
    }

    public void Credits()
    {
        //TODO Menu de creditos
    }

    public void Exit()
    {
        Application.Quit();
    }
}
