using System.Collections;
using EJETAGame;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BaseMonster : MonoBehaviour, IInteractable
{
    public MonsterSO monsterSO;


    [SerializeField]
    private Object m_SceneAsset;

    public GameEvent StopPlayerMovement;

    private bool canInteractWith = true;

    private bool isLoaded = false;

    //Which button the user must press to initiate the Interaction;
    public KeyCode interactionKey;

    public MonsterContext monsterContext;

    
    public void Interact()
    {
        if (Input.GetKeyDown(interactionKey) && canInteractWith)
        {
            isLoaded = true;
            canInteractWith = false;

            monsterContext.monster = monsterSO;

            SceneManager.sceneLoaded += OnSceneLoaded;

            SceneManager.LoadScene(m_SceneAsset.name, LoadSceneMode.Additive);

            StopPlayerMovement.Raise();
        }

    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;

        SceneManager.SetActiveScene(scene);
        DialogueManager.GetInstance().EnterDialogueMode(monsterSO.inkJSON);
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
        canInteractWith = true;
        Debug.Log("Interaction Ended");
    }




}
