using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneListner : ListnerPrototype
{
    // Fields
    [SerializeField] private string sceneName;

    // Methods
    protected override void OnClickListner()
    {
        SceneManager.LoadScene(sceneName);
    }
}