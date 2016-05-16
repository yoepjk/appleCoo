using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Solution : MonoBehaviour {
	protected Dictionary <string, Answer> answer_dict_ = new Dictionary<string, Answer> ();
	protected Dictionary <string, Answer> correct_answer_dict_ = new Dictionary<string, Answer> ();

	protected void putCorrectAnswer(string name, Answer answer) {
		correct_answer_dict_[name] = answer;
	}

	public void clearAnswers() {
		answer_dict_.Clear ();
	}

public void putAnswer(string name, Answer answer) {
		prePutAnswer (name, answer);

		answer_dict_[name] = answer;
	}

	public void removeAnswer(string name) {
		answer_dict_.Remove (name);
	}

	public Answer getAnswer(string name) {
		if (answer_dict_.ContainsKey (name) == false)
			return null;
		
		return answer_dict_ [name];
	}

	virtual protected void prePutAnswer(string name, Answer answer) {	}

	public double calculateScore() {
		double sum = 0;

		foreach (var p in correct_answer_dict_) {
			if (answer_dict_.ContainsKey (p.Key) == false) {				
				continue;
			}

			var ua = answer_dict_ [p.Key];
			sum += ua.calcualteAnswerScore (p.Value);
		}
		return sum / correct_answer_dict_.Count;
	}	
}
