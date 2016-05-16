using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.IO;
using System;

public class ScenarioButton : MonoBehaviour {
	private bool is_start_ = false, is_pre_button_ = false;
	private string next_scene_name_;

	void OnMouseDown() {
		if (is_start_ == false) {
			Vector3 pos = gameObject.transform.position;
			pos.y -= 1f;
			gameObject.transform.position = pos;

			is_start_ = true;

			if (gameObject.name.Equals ("preButton"))
				is_pre_button_ = true;			
		}
	}

	void OnMouseUp() {
		if (is_start_ == true) {
			Vector3 pos = gameObject.transform.position;
			pos.y += 1f;
			gameObject.transform.position = pos;
			is_start_ = false;

			var scene = ScenarioScene.Instance;

			if(is_pre_button_ == true)
				scene.fadeOutScene (OnPreClick);			
			else
				scene.fadeOutScene (OnNextClick);
		}
	}

	void Awake() {
	}

	public void OnPreClick() {			
		if (StartMusic.instance != null)
			StartMusic.instance.destroy ();

		SceneManager.LoadScene ("stageSelect");
	}
	
	public void OnNextClick() {	
		var scene = ScenarioScene.Instance;			
		SceneManager.LoadScene (scene.nextStageName);	
	}
}
