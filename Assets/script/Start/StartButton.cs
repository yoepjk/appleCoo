using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour {
	private bool isStart = false;

	void OnMouseDown() {
		if (isStart == false) {
			Vector3 pos = gameObject.transform.position;
			pos.y -= 3f;
			gameObject.transform.position = pos;

			isStart = true;
		}
	}

	void OnMouseUp() {
		if (isStart == true) {
			Vector3 pos = gameObject.transform.position;
			pos.y += 3f;
			gameObject.transform.position = pos;

			isStart = false;

			SceneManager.LoadScene ("stageSelect");
		}
	}

	void Awake() {
	}

	void Start () {
		
	}
	

	void Update () {
	
	}
}
