using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogUIManager : MonoBehaviour 
{
	[SerializeField] TMP_Text choiceOne;
	[SerializeField] TMP_Text choiceTwo;
	[SerializeField] TMP_Text choiceThree;
	[SerializeField] TMP_Text choiceFour;

	string choiceText;

	bool isCorrect = false;

	// Use this for initialization
	void Start () 
	{
		choiceOne.SetText("Hey There!");
		choiceTwo.SetText ("What cha want?!");
		choiceThree.SetText("Why!?!?");
		choiceFour.SetText("Yup!");
	}

	void Update()
	{
		Selection (choiceText);
	}
	
	void CorrectAnswer()
	{
		isCorrect = true;
		choiceText = choiceOne.text;
	}

	void Selection(string choiceString)
	{
		if (isCorrect) {
			switch (choiceString) 
			{
			case "No thanks, Mr...?":
				break;
			case "What can you tell us about 'Plato's Lost Dialog'?":
				break;
			case "Why aren't we allowed inside?":
				break;
			case "I'm Dr. Indiana Jones, is that scholarly enough?":
				break;
			case "I'd really like to explore the temple.":
			case "About exploring the temple...":
				break;
			case "Title?":
				break;
			case "The Hermocrates.":
				break;
			}
		} 
		else
		{
			switch (choiceString)
			{
			case "Thanks. We'd just like to look around.":
				break;
			case "What can you tell us about the temple?":
				break;
			case "I'm hoping to find some evidence of Atlantis here.":
				break;
			case "I'm Dr. Indiana Jones, is that scholarly enough?":
				break;
			case "Thanks. We'd just like like to look around.":
				break;
			case "What can you tell us about 'Mr. Smith'?":
				break;
			}
		}
	}
}
