using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogSystemManager : MonoBehaviour
{
    #region Singleton
    public static DialogSystemManager instance;

    void Awake()
    {
        instance = this;
    }

    #endregion

    #region Variables

    [Header("Dialog Choices Related")]
    [SerializeField] GameObject dialogCanvas;
    [SerializeField] GameObject[] dialogChoices;
    List<TMP_Text> newChoices = new List<TMP_Text>();

    static TMP_Text currentChoice;

    [Header("Inventory and Action Canvas'")]
    [SerializeField] GameObject inventory;
    [SerializeField] GameObject actions;

    [Header("Character Speech")]
    [SerializeField] CharacterTalkText indy;
    public CharacterTalkText sophia;
    public CharacterTalkText sternhart;
    [SerializeField] CharacterTalkText parrot;

    public bool firstEncounter = true;
    bool canTellTitle = false;
    bool titleTold = false;
    public bool isSecondComplete = false;
    public bool isOccupied { get; private set; }

    [SerializeField] GameObject toTempleTransition;

    #endregion

    void Start()
    {
        isOccupied = false;

        foreach (GameObject choice in dialogChoices)
        {
            newChoices.Add(choice.GetComponentInChildren<TMP_Text>());
        }
            
        StartDialog();
    }

    #region Updating Dialog Choices and Dialog Choice Selection

    public void UpdateCurrentChoice(GameObject clickedButton)
    {
        currentChoice = clickedButton.GetComponentInChildren<TMP_Text>();
    }

    public void DialogChoices()
    {
        if (!isSecondComplete)
            SecondPuzzleDialogChoices();
        else
            ThirdPuzzleDialogChoices();
    }

    public void CasualDialogChoices()
    {
        switch (currentChoice.text)
        {
            case "What do we do now?":
                UpdateIndy();
                UpdateSophia("I don't know, keep looking around I guess.", 1f);
                EndEncounter();
                break;
            case "Let's keep looking.":
                UpdateIndy();
                UpdateSophia("Ok.", 1f);
                EndEncounter();
                break;
            case "":
                break;
            default:
                Debug.LogError("Something went wrong in CasualDialogChoices()");
                break;
                
        }
    }

    #endregion

    #region Puzzle Dialog Systems

    public void SecondPuzzleDialogChoices()
    {
    // This switch statement checks what the choice text was and updates things appropriately.
        switch (currentChoice.text)
        {
            case "Thanks. We'd just like to look around.":
            // Update Indy's speech text.
                UpdateIndy();

            // End the encounter.
                EndEncounter();
                break;
            case "No thanks, Mr... ?":
            // Ensures we don't go back to the dialog for the first encounter.
                firstEncounter = false;

            // Update Indy's speech text.
                UpdateIndy();

            // Update Sternhart's speech text.
                UpdateSternhart("Charles Sternhart, Phd., Independant thinker, researcher, and merchant.", 1.5f);

            // Update the choices past the first encounter choices.
                ContinuedEncounterDialog();
                break;
            case "What can you tell us about 'Plato's Lost Dialogue'?":
            // Update Indy's speech text.
                UpdateIndy();

            // Update Sternhart's speech text.
                UpdateSternhart("I'm the only one who translated it. I can tell you that. I'd worry you were here to steal my last copy, but someone called 'Mr. Smith' beat you to it.", 1.5f);

            // Update Indy's text again using overloaded Method.
                UpdateIndy("Oh, no!", 3f);

            // Reset the current choices' text to the new value.
                currentChoice.text = "What can you tell us about 'Mr. Smith'?";
                break;
            case "What can you tell us about the temple?":
                UpdateIndy();
                UpdateSternhart("Glad you asked! The locals claim it was built by an indian village. " +
                    "Now I ask, does this look like the work by primitive savages, or does it seem much too civilized?", 1.5f);

            // Reset the current choice's text to the new value.
                currentChoice.text = "Why aren't we allowed inside?";
                break;
            case "I'm hoping to find some evidence of Atlantis here.":
                UpdateIndy();
                UpdateSternhart("Look around my boy! It's everywhere!", 1.5f);
                break;
            case "What can you tell us about 'Mr. Smith'?":
                UpdateIndy();
                UpdateSternhart("Only that he stole my last copy of 'Plato's Lost Dialogue'.", 1.5f);
                break;
            case "Why aren't we allowed inside?":
                UpdateIndy();
                UpdateSternhart("How do I know you're not a pair of silly tourists? I only show the temple to REPUTABLE scholars.", 1.5f);
                currentChoice.text = "I'm Dr. Indiana Jones, is that scholarly enough?";
                break;
            case "I'm Dr. Indiana Jones, is that scholarly enough?":
                UpdateIndy();
                UpdateSternhart("Indiana? Sounds like the name of one of your states, or possibly a pet.", 1.5f);
                UpdateSophia("Actually, it was the name of a dog.", 2.5f);
                UpdateIndy("Sophia!", 6f);
                currentChoice.text = "I'd really like to explore the temple.";
                break;
            case "I'd really like to explore the temple.":
                UpdateIndy();
                UpdateSternhart("Tell me the name of the Lost Dialog of Plato.", 1.5f);

            // Update the dialog choices
                newChoices[0].text = "The Socrates.";
                newChoices[1].text = "The Gluteus Maximus.";
                newChoices[2].text = "The Hippocrates.";
                newChoices[3].text = "I don't know the title.";
                break;
            case "The Socrates.":
                UpdateIndy();
                UpdateParrot("Socrates!", 1f);
                UpdateSternhart("You're no student of Atlantis then.", 1f);

            // End the encounter
                EndEncounter();

            // Reset the dialog choices
                ResetDialog();
                break;
            case "The Gluteus Maximus":
                UpdateIndy();
                UpdateParrot("Maximus!", 1f);
                UpdateSternhart("You're no student of Atlantis then.", 1f);

            // End the encounter
                EndEncounter();

            // Reset the dialog choices
                ResetDialog();
                break;
            case "The Hippocrates.":
                UpdateIndy();
                UpdateParrot("Hippocrite!", 1f);
                UpdateSternhart("You're no student of Atlantis then.", 1f);

            // End the ecounter
                EndEncounter();

            // Reset the dialog choices
                ResetDialog();
                break;
            case "I don't know the title.":
                UpdateIndy();
                UpdateParrot("Title!", 1f);
                UpdateSternhart("You're no student of Atlantis then.", 1f);

            // End the encounter
                EndEncounter();

            // Set that the parrot can tell Indy the title.
                canTellTitle = true;

            // Reset the dialog choices
                ResetDialog();
                break;
            case "Polly wanna cracker?":
                UpdateIndy();
                UpdateParrot("Cracker!", 1f);

            // End the encounter
                EndEncounter();

            // Reset the dialog choices
                ResetDialog();
                break;
            case "Echo.":
                UpdateIndy();
                UpdateParrot("Echo!", 1f);

            // End the encounter
                EndEncounter();

            // Reset the dialog choices
                ResetDialog();
                break;
            case "Hullabaloo.":
                UpdateIndy();
                UpdateParrot("Hullabaloo!", 1f);

                EndEncounter();

                ResetDialog();
                break;
            case "Title?":
                UpdateIndy();
                if (canTellTitle)
                {
                    UpdateParrot("Hermocrates! A friend of Socrates!", 1.5f);
                    titleTold = true;
                }
                else
                    UpdateParrot("Sqwak!", 1.5f);

                EndEncounter();

                ResetDialog();
                break;
            case "About exploring the temple...":
                UpdateIndy();
                UpdateSternhart("Tell me the name of the Lost Dialog of Plato.", 1.5f);

                if (titleTold)
                {
                    newChoices[0].text = "The Hermocrates.";
                    newChoices[1].text = "The Persepolis.";
                    newChoices[2].text = "The Gluteus Maximus.";
                    newChoices[3].text = "I don't know the title.";
                }
                else
                {
                    newChoices[0].text = "The Socrates.";
                    newChoices[1].text = "The Gluteus Maximus.";
                    newChoices[2].text = "The Hippocrates.";
                    newChoices[3].text = "I don't know the title.";
                }
                break;
            case "The Hermocrates.":
                UpdateIndy();
                UpdateParrot("Socrates!", 1f);
                UpdateSternhart("That's it!", 2f);
                UpdateParrot("That's it! Squawk!", 2.5f);
                UpdateSternhart("Well, now perhaps I was wrong. You seem to know what you're doing. Walk this way please.", 3f);
                isSecondComplete = true;
                EndEncounter();
            // *Note: Start Cut scene to enter the temple.
                break;
            case "The Persepolis.":
                UpdateIndy();
                UpdateParrot("Maximus!", 1f);
                UpdateSternhart("You're no student of Atlantis then.", .75f);
                ResetDialog();
                break;
            default:
                if (currentChoice.text != "")
                    CasualDialogChoices();
                break;
        }
    }

    public void ThirdPuzzleDialogChoices()
    {
        switch (currentChoice.text)
        {
            case "What do we do now?":
                UpdateIndy();
                UpdateSophia("I don't know, you're the expert here.", 2f);
                break;
            case "Could you talk to Sternhart and keep him occupied?":
                UpdateIndy();
                UpdateSophia("Ok.", 1.5f);
                // Play animation of Sophia asking Sternhart to talk.
                UpdateSophia("Dr. Sternhart, I'd like to speak to you.", 3f);
                // Play animation of Sternhart and Sophia walking away to talk, and of them talking.
                isOccupied = true;

                EndEncounter();
                break;
            case "Let's keep looking.":
                UpdateIndy();
                UpdateSophia("Ok.", 1f);

                EndEncounter();
                break;
            case "Can I have your lamp?":
                UpdateIndy();
                UpdateSternhart("No! Unless you give me $50.", 2f);
                UpdateIndy("Fifty dollars! No thanks.", 3f);
                break;
            case "What've you found here?":
                UpdateIndy();
                UpdateSternhart("Not really a whole lot... YET!", 2f);
                break;
            case "I'd like to look around.":
                UpdateIndy();
                UpdateSternhart("Ok.", 1f);
                EndEncounter();
                break;
            default:
                if (currentChoice.text != "")
                    CasualDialogChoices();
                break;
        }
    }

    #endregion

    #region Helper Methods

    public void UpdateToParrotChoices()
    {
        newChoices[0].text = "Polly wanna cracker?";
        newChoices[1].text = "Echo.";
        newChoices[2].text = "Hullabaloo.";
        newChoices[3].text = "Title?";
    }

    public void UpdateToThirdPuzzleChoices()
    {
        newChoices[0].text = "What do we do now?";
        newChoices[1].text = "Could you talk to Sternhart and keep him occupied?";
        newChoices[2].text = "Let's keep looking.";
        newChoices[3].text = "";
    }

    public void UpdateToDefaultSophiaChoices()
    {
        newChoices[0].text = "What do we do now?";
        newChoices[1].text = "Let's keep looking.";
        newChoices[2].text = "";
        newChoices[3].text = "";
    }

    public void UpdateToSternhartThirdPuzzleChoices()
    {
        newChoices[0].text = "Can I have your lamp?";
        newChoices[1].text = "What've you found in here?";
        newChoices[2].text = "I'd like to look around.";
        newChoices[3].text = "";
    }

    public void StartDialog()
    {
        newChoices[0].text = "No thanks, Mr... ?";
        newChoices[1].text = "Thanks. We'd just like to look around.";
        newChoices[2].text = "";
        newChoices[3].text = "";
    }

    void ContinuedEncounterDialog()
    {
        newChoices[0].text = "What can you tell us about 'Plato's Lost Dialogue'?";
        newChoices[1].text = "What can you tell us about the temple?";
        newChoices[2].text = "I'm hoping to find some evidence of Atlantis here.";
        newChoices[3].text = "Thanks. We'd just like to look around.";
    }

    void ResetDialog()
    {
        newChoices[0].text = "What can you tell us about 'Mr. Smith'?";
        newChoices[1].text = "About exploring the temple...";
        newChoices[2].text = "I'm hoping to find some evidence of Atlantis here.";
        newChoices[3].text = "Thanks. We'd just like to look around.";
    }

    public void DisableOtherUI()
    {
        UIActionManager.instance.isTalking = true;
        dialogCanvas.SetActive(true);
        inventory.SetActive(false);
        actions.SetActive(false);
    }

    void UpdateIndy()
    {
        indy.TextUpdate(currentChoice.text);
        indy.isTextEnabled = true;
    }

    void UpdateIndy(string newText, float delay)
    {
        DoDelayedText(indy,newText, delay);

        //indy.TextUpdate(newText);
        //indy.isTextEnabled = true;
    }

    void UpdateSternhart(string newText,float delay)
    {
        DoDelayedText(sternhart, newText, delay);
    }

    void UpdateSophia(string newText, float delay)
    {
        DoDelayedText(sophia, newText, delay);
//        sophia.TextUpdate(newText);
//        sophia.isTextEnabled = true;
    }

    void UpdateParrot(string newText, float delay)
    {
        DoDelayedText(parrot, newText, delay);
//        parrot.TextUpdate(newText);
//        parrot.isTextEnabled = true;
    }

    void DoDelayedText(CharacterTalkText ctt,string newText,float delay)
    {
        StartCoroutine(DelayedText(ctt,newText,delay));
    }

    IEnumerator DelayedText(CharacterTalkText ctt,string text,float delay)
    {
        yield return new WaitForSeconds(delay);
        ctt.TextUpdate(text);
        ctt.isTextEnabled = true;
    }

    void EndEncounter()
    {
        if (currentChoice.text == "The Hermocrates.")
        {
            toTempleTransition.SetActive(true);
        }

        UIActionManager.instance.isTalking = false;
        dialogCanvas.SetActive(false);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        inventory.SetActive(true);
        actions.SetActive(true);
    }

    #endregion
}
