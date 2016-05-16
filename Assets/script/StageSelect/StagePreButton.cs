using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StagePreButton : MonoBehaviour {
	private bool is_start_ = false;

	void OnMouseDown() {
		if (is_start_ == false) {
			Vector3 pos = gameObject.transform.position;
			pos.y -= 1.0f;
			gameObject.transform.position = pos;

			is_start_ = true;
		}
	}

	void OnMouseUp() {
		if (is_start_ == true) {
			Vector3 pos = gameObject.transform.position;
			pos.y += 1.0f;
			gameObject.transform.position = pos;

			OnPreClick ();
		}
	}


	public void OnPreClick() {			
		if (StartMusic.instance != null)
			StartMusic.instance.destroy ();
			
		SceneManager.LoadScene ("start");
	}
}
