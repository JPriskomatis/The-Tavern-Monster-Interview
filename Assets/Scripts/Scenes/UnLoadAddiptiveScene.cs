using UnityEngine;
using UnityEngine.SceneManagement;
public class UnLoadAddiptiveScene : MonoBehaviour
{
    [SerializeField]
    private Object m_SceneAsset;

    

    // Update is called once per frame
    public void UnloadScene()
    {
        SceneManager.UnloadSceneAsync(m_SceneAsset.name);
    }
}
