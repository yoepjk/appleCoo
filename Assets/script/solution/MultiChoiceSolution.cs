using UnityEngine;
using System.Collections;

public class MultiChoiceSolution : Solution {
	[System.Serializable]
	public struct AnswerPair {
		public string name;
		public GameObject obj;
	}

	public AnswerPair[]  correctAnswers;

	void Awake() {
		foreach (var ca in correctAnswers) {
			putCorrectAnswer (ca.name, new MultiChoiceAnswer (ca.obj));
		}
	}
}

