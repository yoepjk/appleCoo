using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.IO;
using System;

public class GameSelectButton : MonoBehaviour {
		
	void OnMouseDown() {
		if(StartMusic.instance != null)
			StartMusic.instance.destroy();

		var scene = StageSelectScene.Instance;
		scene.fadeOutScene ((Action)(() => {
			SceneManager.LoadScene (gameObject.name);
		}));
	}

}
