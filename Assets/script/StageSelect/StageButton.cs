using UnityEngine;
using System.Collections;

public class StageButton : MonoBehaviour {
	public GameObject gameSelect;

	void OnMouseDown() {
		if (gameSelect.activeSelf == true) {
			gameSelect.SetActive (false);		
			return;
		}

		_clearGameSelect ();
		gameSelect.SetActive (true);	
	}

	private void _clearGameSelect() {
		var scene = StageSelectScene.Instance;

		foreach (var gs in scene.gameSelect) {			
			gs.SetActive (false);
		}
	}
}
