using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void Play() => SceneManager.LoadScene(1);
    public void Quit() => Application.Quit();
}