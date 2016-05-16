using UnityEngine;
using System.Collections;

public class MultiClickableObject : MonoBehaviour {
	public GameObject marker;

	void OnMouseDown() {		
		marker.SetActive (!marker.activeSelf);
		bool isChecked = marker.activeSelf;

		Solution solution = GameScene.Instance.solution;
		if(isChecked == true)
			solution.putAnswer (gameObject.name, new MultiChoiceAnswer (gameObject));
		else
			solution.putAnswer (gameObject.name, new MultiChoiceAnswer (null));
	}


	void Start() {
		Solution solution = GameScene.Instance.solution;
		solution.putAnswer (gameObject.name, new MultiChoiceAnswer (null));
	}
}
