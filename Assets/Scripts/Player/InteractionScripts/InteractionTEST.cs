

namespace EJETAGame
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.SceneManagement;

    /**
     * Interactable test case where we change the color of a sphere gameobject
     * into a random color;
     */
    public class InteractionTEST : MonoBehaviour, IInteractable
    {

        [SerializeField]
        private Object m_SceneAsset;

        private bool isLoaded = false;

        //Which button the user must press to initiate the Interaction;
        public KeyCode interactionKey;
        public void Interact()
        {
            if (Input.GetKeyDown(interactionKey) && !isLoaded)
            {
                isLoaded = true;
                SceneManager.LoadScene(m_SceneAsset.name, LoadSceneMode.Additive);
            }
            
        }

        //When our interaction begin, we set the UI text to prompt the user to
        //press a button to interact with the gameobject;
        public void OnInteractEnter()
        {
            InteractionText.instance.SetText("Press "+interactionKey+" to interact");
        }


        //We can debug a statement to let us know when the interaction ends;
        public void OnInteractExit()
        {
            Debug.Log("Interaction Ended");
        }
    }

}
