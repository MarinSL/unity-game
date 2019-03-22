using UnityEngine;
using UnityEngine.SceneManagement;

public class Control : MonoBehaviour
{
    public string Scene1;
    public string Scene2;
    public string Scene3;
    public void NextScene1()
    {
        SceneManager.LoadScene(Scene1);
    }
    public void NextScene2() { SceneManager.LoadScene(Scene2); }
    public void NextScene3() { SceneManager.LoadScene(Scene3); }
}
