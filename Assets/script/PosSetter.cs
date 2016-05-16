using UnityEngine;
using System.Collections;

public class PosSetter : MonoBehaviour {
	public Transform anchor;
	public float yInterval;
	private Vector3 offset, size;

	// Use this for initialization
	void Start () {		
	}

	// Update is called once per frame
	void Update () {
		if (anchor != null) {
			size = anchor.GetComponent<Renderer> ().bounds.size;
			offset.x = 0;
			offset.y = -size.y / 2 - yInterval;
			transform.position = anchor.position + offset;
		}
	}
}
