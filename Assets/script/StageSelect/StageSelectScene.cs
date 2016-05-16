using UnityEngine;
using System.Collections;
using System;

public class StageSelectScene : MonoBehaviour {

	public BlockScreen blockscreen;
	public AudioSource bgm;
	public GameObject[] gameSelect;
	public GameObject cover;

	private static StageSelectScene  instance_;
	public static StageSelectScene Instance {
		get	{ return instance_;	}
	}


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


	void Start () {				
	}
	

	void Update () {
	
	}


}
