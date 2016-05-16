using UnityEngine;
using System.Collections;

public class ChoiceSolution : Solution {
	public ClickableObject[] clickableObjects;
	public ClickableObject correctAnswer;

	void Awake() {
		putCorrectAnswer (correctAnswer.name, new ChoiceAnswer(correctAnswer.gameObject));
	}

	override protected void prePutAnswer(string name, Answer answer) {
		foreach (var co in clickableObjects) {
			if (co.gameObject != (answer as ChoiceAnswer).choice_obj)
				co.marker.SetActive (false);
		}

		clearAnswers ();
	}
}

