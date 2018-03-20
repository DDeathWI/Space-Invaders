using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition: MonoBehaviour {

    /// <summary>
    /// Change Scene By Name
    /// </summary>
    /// <param name="scene_name"></param>
    public void ChangeScene(string scene_name)
    {
        SceneManager.LoadScene(scene_name);
    }

    /// <summary>
    /// Change Scene By ID in Build Settings
    /// </summary>
    /// <param name="scene_id"></param>
    public void ChangeScene(int scene_id)
    {
        SceneManager.LoadScene(scene_id);
    }

}
