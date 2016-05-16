using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public class GameScene : MonoBehaviour {
	private static GameScene  instance_;
	public static GameScene Instance {
		get	{ return instance_;	}
	}

	public GameObject cover;
	public BlockScreen blockscreen;
	public Solution solution;
	public GameObject correctPanel, wrongPanel;
	public float RADIUS;
	public AudioSource bgm;

	void Awake() {
		instance_ = this;
		Camera.main.aspect = 1280f / 800f;

		blockscreen.gameObject.SetActive (true);

		if (StartMusic.instance == null) {
			bgm.Play ();
		}
	}

	public void fadeOutScene(Action on_end = null) {
		blockscreen.fadeOutScene (on_end);
	}

	public void OnSubmitClick() {
		var score = solution.calculateScore ();

		GameScene gameScene = GameScene.Instance;
		gameScene.cover.SetActive (true);

		if (score == 1) {
			gameScene.correctPanel.SetActive (true);
		}
		else {			
			gameScene.wrongPanel.SetActive (true);
		}
	}
}
