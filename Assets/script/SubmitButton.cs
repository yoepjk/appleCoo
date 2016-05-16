using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SubmitButton : MonoBehaviour {
	private bool is_start_ = false;

	void OnMouseDown() {
		if (is_start_ == false) {
			Vector3 pos = gameObject.transform.position;
			pos.y -= 2f;
			gameObject.transform.position = pos;

			is_start_ = true;
		}
	}

	void OnMouseUp() {
		if (is_start_ == true) {
			Vector3 pos = gameObject.transform.position;
			pos.y += 2f;
			gameObject.transform.position = pos;

			if(StartMusic.instance != null)
				StartMusic.instance.destroy ();
		
			GameScene scene = GameScene.Instance;
			scene.bgm.Stop ();
			scene.OnSubmitClick();
		}
	}

	void Awake() {
		
	}

	void Start () {

	}

	void Update () {
	
	}


}
