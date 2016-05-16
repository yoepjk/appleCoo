using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.IO;

public class GamePreButton : MonoBehaviour {

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

			GameScene scene = GameScene.Instance;
			scene.fadeOutScene (OnPreClick);			 
		}
	}

	public void OnPreClick() {			
		if (StartMusic.instance != null)
			StartMusic.instance.destroy ();

		SceneManager.LoadScene ("stageSelect");

		//var stage_name = _findPreStageScenarioName ();
		//SceneManager.LoadScene (stage_name);
	}
	/*
	private string _findPreStageScenarioName() {
		var cur_name = SceneManager.GetActiveScene ().name;
		var stage_no = int.Parse(cur_name.Substring(1));

		if (stage_no > 16)
			return null;

		string stage_name = ((stage_no < 10) ? "0" + stage_no.ToString() : stage_no.ToString());
		return "#" + stage_name;
	}
	*/
}
