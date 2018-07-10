using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using TMPro;

public class SetControls : MonoBehaviour 
{
    [SerializeField] NavMeshAgent indyAgent;
    [SerializeField] Rigidbody indyRB;
    [SerializeField] PlayerController wasd;
    [SerializeField] PlayerControllerPAC pointAndClick;

    [Header("Action Manager UI Changes")]
    [SerializeField] Image walk_CancelButton;
    [SerializeField] Sprite walkSprite;
    [SerializeField] Sprite cancelSprite;
    [SerializeField] Sprite cancelHoverSprite;
    [SerializeField] Sprite cancelPressedSprite;
    [SerializeField] TMP_Text cancelWalkText;

    [SerializeField] bool debugPacBool = false;

    void Awake()
    {
        if (ControlsManager.instance != null)
        {
            if (ControlsManager.instance.isPointAndClick)
            {
                indyAgent.enabled = true;
                indyRB.useGravity = false;
                indyRB.isKinematic = true;
                wasd.enabled = false;
                pointAndClick.enabled = true;
                walk_CancelButton.sprite = walkSprite;
                cancelWalkText.text = "Walk";
            }
            else
            {
                indyAgent.enabled = false;
                indyRB.useGravity = true;
                indyRB.isKinematic = false;
                wasd.enabled = true;
                pointAndClick.enabled = false;
                walk_CancelButton.sprite = cancelSprite;
                SpriteState cancelState = walk_CancelButton.GetComponent<Button>().spriteState;
                cancelState.highlightedSprite = cancelHoverSprite;
                cancelState.pressedSprite = cancelPressedSprite;
                walk_CancelButton.GetComponent<Button>().spriteState = cancelState;
                cancelWalkText.text = "Cancel";
            }
        }
        // Remove the else - else if statement for production, debug checks and testing only
        else if (debugPacBool)
        {
            indyAgent.enabled = true;
            indyRB.useGravity = false;
            indyRB.isKinematic = true;
            wasd.enabled = false;
            pointAndClick.enabled = true;
        }
        else
        {
            indyAgent.enabled = false;
            indyRB.useGravity = true;
            indyRB.isKinematic = false;
            wasd.enabled = true;
            pointAndClick.enabled = false;
        }
    }
}
