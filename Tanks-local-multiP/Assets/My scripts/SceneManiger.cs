using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManiger: MonoBehaviour
{
    public int sceneNameToLoad;

    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneNameToLoad);
        print("hi");
    }
}