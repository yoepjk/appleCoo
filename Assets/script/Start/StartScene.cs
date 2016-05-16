using UnityEngine;
using System.Collections;

public class StartScene : MonoBehaviour {
	public GameObject popUpMenu;

	private static StartScene  instance_;
	public static StartScene Instance {
		get	{ return instance_;	}
	}

	void Awake() {
		instance_ = this;
		Camera.main.aspect = 1280f / 800f;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Application.platform == RuntimePlatform.Android) {		
			if(Input.GetKey(KeyCode.Escape)) {
				popUpMenu.SetActive (true);
				return;
			}				
		}
	}
}
