using UnityEngine;
using System.Collections;

public class PopUpMenu : MonoBehaviour {


	void OnMouseDown() {	
		
		if (gameObject.name.Equals ("Ok_button")) {			
			Application.Quit ();

		} else if (gameObject.name.Equals ("Cancel_button")) {			
			var scene = StartScene.Instance;
			scene.popUpMenu.SetActive (false);
		} 
	}
}
