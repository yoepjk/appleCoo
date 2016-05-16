using UnityEngine;
using System.Collections;

public class LinkSolution : Solution {

	[System.Serializable]
	public struct PointPair {
		public GameObject start;
		public GameObject end;
	}

	public GameObject[] endPoints;
	public PointPair[]  correctAnswers;

	void Awake() {
		foreach (var ca in correctAnswers) {
			putCorrectAnswer (ca.start.name, new LinkAnswer(ca.start, ca.end));
		}
	}
}