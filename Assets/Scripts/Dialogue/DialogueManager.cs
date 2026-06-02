using System.Collections;
using System.Collections.Generic;
using Ink.Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class DialogueManager : MonoBehaviour
{
    public GameEvent ExitDialogue;

    private static DialogueManager instance;

    public static DialogueManager GetInstance() => instance;

    //We create a state to easier handle the flow of the dialogue;
    private enum DialogueState
    {
        Inactive,
        ShowingText,
        WaitingForContinue,
        ShowingChoices
    }

    private DialogueState state;

    
    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialogueAnswer;
    [SerializeField] private TextMeshProUGUI dialogueAnswerText;

    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;

    private Story currentStory;
    private bool dialogueIsPlaying;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Found more than one DialogueManager instance");
        }

        instance = this;

        dialogueAnswer.SetActive(false);

        choicesText = new TextMeshProUGUI[choices.Length];

        for (int i = 0; i < choices.Length; i++)
        {
            choicesText[i] = choices[i].GetComponentInChildren<TextMeshProUGUI>();
        }

        state = DialogueState.Inactive;
    }

    private void Update()
    {
        if (!dialogueIsPlaying)
            return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnAdvancePressed();
        }
    }

    
    public void EnterDialogueMode(TextAsset inkJSON)
    {
        currentStory = new Story(inkJSON.text);

        dialogueIsPlaying = true;

        state = DialogueState.ShowingText;

        ContinueStory();
    }

    
    private void OnAdvancePressed()
    {
        switch (state)
        {
            case DialogueState.WaitingForContinue:
                ContinueStory();
                break;

            case DialogueState.ShowingText:
                ContinueStory();
                break;

            case DialogueState.ShowingChoices:
                break;
        }
    }

    
    private void ContinueStory()
    {
        HideChoices();

        if (currentStory.canContinue)
        {
            string text = currentStory.Continue().Trim();

            if (!string.IsNullOrEmpty(text))
            {
                ShowDialogue(text);
                return;
            }
        }

        //No more text means we check if there are choices
        if (currentStory.currentChoices.Count > 0)
        {
            ShowChoices();
            return;
        }

        ExitDialogueMode();
    }

    private void ShowDialogue(string text)
    {
        dialogueAnswerText.text = text;
        dialogueAnswer.SetActive(true);

        state = DialogueState.WaitingForContinue;
    }

    #region CHOICES
    private void ShowChoices()
    {
        dialogueAnswer.SetActive(false);

        DisplayChoices();

        state = DialogueState.ShowingChoices;
    }

    private void DisplayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;

        if (currentChoices.Count > choices.Length)
        {
            Debug.LogWarning("More choices than UI supports");
        }

        int index = 0;

        foreach (Choice choice in currentChoices)
        {
            choices[index].SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }

        for (int i = index; i < choices.Length; i++)
        {
            choices[i].SetActive(false);
        }

        StartCoroutine(SelectFirstChoice());
    }

    public void MakeChoice(int choiceIndex)
    {
        currentStory.ChooseChoiceIndex(choiceIndex);

        HideChoices();

        state = DialogueState.ShowingText;

        ContinueStory();
    }

    private void HideChoices()
    {
        foreach (var choice in choices)
        {
            choice.SetActive(false);
        }
    }

    private IEnumerator SelectFirstChoice()
    {
        EventSystem.current.SetSelectedGameObject(null);

        yield return new WaitForEndOfFrame();

        if (choices.Length > 0 && choices[0].activeInHierarchy)
        {
            EventSystem.current.SetSelectedGameObject(choices[0]);
        }
    }

    #endregion
   
    private void ExitDialogueMode()
    {
        dialogueIsPlaying = false;

        dialogueAnswer.SetActive(false);

        HideChoices();

        state = DialogueState.Inactive;

        ExitDialogue.Raise();

    }
}