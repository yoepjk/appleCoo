using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.IO;
using System;

public class ScenarioScene : MonoBehaviour {
	public BlockScreen blockscreen;
	public string nextStageName;

	private static ScenarioScene  instance_;
	public static ScenarioScene Instance {
		get	{ return instance_;	}
	}

	void Awake() {
		instance_ = this;
		Camera.main.aspect = 1280f / 800f;

		blockscreen.gameObject.SetActive (true);
		nextStageName = _findStageName ();
	}

	void Start () {
	
	}

	void Update () {
		
	}

	public void fadeOutScene(Action on_end = null) {
		blockscreen.fadeOutScene (on_end);
	}

	private string _findStageName() {
		var cur_name = SceneManager.GetActiveScene ().name;
		var stage_no = int.Parse(cur_name.Substring(1));

		string stage_name = ((stage_no < 10) ? "0" + stage_no.ToString() : stage_no.ToString());
		return "$" + stage_name;
	}
}