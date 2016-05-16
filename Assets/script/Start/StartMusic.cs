using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartMusic : MonoBehaviour {	
	public static StartMusic instance;

	void Awake() {
		if (instance == null)
			instance = this;
		
		DontDestroyOnLoad (this.gameObject);
	}
		
	void Start() {		
	}


	void Update () {		
	}

	public void destroy() {		
		Destroy (this.gameObject);
	}
}
