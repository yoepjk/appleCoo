using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.IO;

public class PopUpButton : MonoBehaviour {
	
	void OnMouseDown() {		
		GameScene scene = GameScene.Instance;

		if (gameObject.name.Equals ("Restart")) {
			scene.fadeOutScene (restartButtonClick);
		} else if (gameObject.name.Equals ("Exit")) {
			scene.fadeOutScene(exitButtonClick);
		} else if (gameObject.name.Equals ("Next")) {
			scene.fadeOutScene(nextButtonClick);
		}
	}

	public void nextButtonClick() {
		var next_scene_name = _findNextStageName ();
		if(next_scene_name == null)
			SceneManager.LoadScene ("stageSelect");
		
		SceneManager.LoadScene (next_scene_name);
	}

	public void exitButtonClick() {
		SceneManager.LoadScene ("stageSelect");
	}

	public void restartButtonClick() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);	
	}

	private string _findNextStageName() {
		var cur_name = SceneManager.GetActiveScene ().name;
		var stage_no = int.Parse(cur_name.Substring(1));
		var next_no = stage_no + 1;

		if (next_no > 16)
			return null;

		string stage_name = ((next_no < 10) ? "0" + next_no.ToString() : next_no.ToString());
		return "#" + stage_name;
	}

	void Start () {		
	}

	void Update () {
	
	}
}
