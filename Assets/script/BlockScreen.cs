using UnityEngine;
using System.Collections;
using System;

public class BlockScreen : MonoBehaviour {
	private const float DURATION = 0.8f;

	void Start () {
		StartCoroutine("FadeIn");
	}

	IEnumerator FadeIn()
	{
		Renderer rend = this.GetComponent<Renderer> ();
		float start_time = Time.time;

		while (true) {
			float elapsed_time = Time.time - start_time;
			float ratio = elapsed_time / DURATION;
			rend.material.color = new Color(1f, 1f, 1f, 1f-ratio);

			if (ratio > 1f)
				break;
			
			yield return 0;
		}
	}

	public void fadeOutScene(Action on_end = null) {
		StartCoroutine (FadeOut(on_end));
	}

	IEnumerator FadeOut(Action on_end = null)
	{
		Renderer rend = this.GetComponent<Renderer> ();
		float start_time = Time.time;

		while (true) {
			float elapsed_time = Time.time - start_time;
			float ratio = elapsed_time / DURATION;
			rend.material.color = new Color(1f, 1f, 1f, ratio);

			if (ratio > 1f)
				break;

			yield return 0;
		}

		if (on_end != null)
			on_end ();
	}

	void Update () {

	}

}
