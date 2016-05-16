using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartPreButton : MonoBehaviour {
	private bool isStart_ = false;

	void OnMouseDown() {
		if (isStart_ == false) {
			Vector3 pos = gameObject.transform.position;
			pos.y -= 1f;
			gameObject.transform.position = pos;

			isStart_ = true;
		}
	}

	void OnMouseUp() {
		if (isStart_ == true) {
			Vector3 pos = gameObject.transform.position;
			pos.y += 1f;
			gameObject.transform.position = pos;

			isStart_ = false;

			var scene = StartScene.Instance;
			scene.popUpMenu.SetActive (true);
		}
	}
}
