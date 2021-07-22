using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneListner : ListnerPrototype
{
    // Fields________________________________________________________
    [SerializeField] private string sceneName;

    // Methods_____________________________________________________
    protected override void OnClickListner()
    {
        SceneManager.LoadScene(sceneName);
    }
}