using UnityEngine;
using System.Collections;

public class ClickableObject : MonoBehaviour {
	public GameObject marker;

	void OnMouseDown() {
		marker.SetActive (!marker.activeSelf);
		Solution solution = GameScene.Instance.solution;
		solution.putAnswer (gameObject.name, new ChoiceAnswer (gameObject));
	}
}
