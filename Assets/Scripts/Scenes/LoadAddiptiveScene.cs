using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadAddiptiveScene : MonoBehaviour
{
    [SerializeField]
    private Object m_SceneAsset;

    private bool isLoaded = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isLoaded)
        {
            isLoaded = true;
            SceneManager.LoadScene(m_SceneAsset.name, LoadSceneMode.Additive);
            
        }
    }
}
