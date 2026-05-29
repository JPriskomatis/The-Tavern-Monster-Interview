using EJETAGame;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BaseMonster : MonoBehaviour, IInteractable
{
    public MonsterSO monsterSO;

    public CurrentMonsterSO currentMonsterSO;

    [SerializeField]
    private Object m_SceneAsset;

    public GameEvent StopPlayerMovement;

    private bool isLoaded = false;

    //Which button the user must press to initiate the Interaction;
    public KeyCode interactionKey;
    public void Interact()
    {
        if (Input.GetKeyDown(interactionKey))
        {
            currentMonsterSO.monsterName = monsterSO.monsterName;
            isLoaded = true;

            SceneManager.LoadScene(m_SceneAsset.name, LoadSceneMode.Additive);
            StopPlayerMovement.Raise();
        }

    }

    //When our interaction begin, we set the UI text to prompt the user to
    //press a button to interact with the gameobject;
    public void OnInteractEnter()
    {
        InteractionText.instance.SetText("Press " + interactionKey + " to interact");
    }


    //We can debug a statement to let us know when the interaction ends;
    public void OnInteractExit()
    {
        Debug.Log("Interaction Ended");
    }
}
