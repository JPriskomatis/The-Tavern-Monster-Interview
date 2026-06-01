using Ink.Runtime;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    private static DialogueManager instance;

    [Header("Dialogue UI")]
    [SerializeField] private TextMeshProUGUI dialogueText;

    private Story currentStory;
    private bool dialogueIsPlaying;



    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("Found more than one instances");

        }

        instance = this;
    }

    private void Start()
    {
        dialogueIsPlaying = false;
    }

    public void EnterDialogueMode(TextAsset inkJSON)
    {
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;


        ContinueStory();


    }

    private void Update()
    {
        if (!dialogueIsPlaying)
        {
            return;
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("SPACE PRESSED");
                ContinueStory();
            }
        }
    }

    public void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            dialogueText.text = currentStory.Continue();

        }
        else
        {
            ExitDialogueMode();
        }
    }

    private void ExitDialogueMode()
    {
        dialogueIsPlaying = false;
        dialogueText.text = "";
    }

    public static DialogueManager GetInstance()
    {
        return instance;
    }
}
