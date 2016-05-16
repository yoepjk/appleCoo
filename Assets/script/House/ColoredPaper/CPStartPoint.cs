using UnityEngine;
using System.Collections;

public class CPStartPoint : MonoBehaviour {
	private ColoredPaperLink myLink;
	private int itemIdx;
	private Vector3 startPos, mousePos, endPos;
	private float radius;
	private LineRenderer lineRenderer;
	private bool isStart = false;

	void OnMouseDown() {			
		for (int i = 0; i < myLink.getLen(); i++) {
			if (myLink.getItems () [i].src.Equals (gameObject)) {	
				itemIdx = i;
				isStart = true;
				break;
			}
		}

	}

	void OnMouseUp() {		
		if (isStart == true) {
			isStart = false;
			lineRenderer.enabled = false;

			checkEndPoint ();
		}

	}

	void checkEndPoint() {
		GameObject endPoint;
		for (int i = 0; i < myLink.getLen (); i++) {
			endPoint = myLink.getEnds () [i];
			endPos = endPoint.transform.position;
			float distance = Vector2.Distance (mousePos, endPos);
			if (distance <= radius * 4) {
				endPos.y += radius; 
				lineRenderer.SetPosition (0, startPos);
				lineRenderer.SetPosition (1, endPos);
				lineRenderer.enabled = true;

				myLink.getItems () [itemIdx].cur = endPoint;
				myLink.getItems () [itemIdx].isLinked = true;
				break;					

			} else {				
				myLink.getItems () [itemIdx].isLinked = false;
			}
		}
	}

	void Start () {		
		myLink = ColoredPaperLink.Instance;
		radius = 1f;
	}


	void Update () {
		if (Input.GetMouseButton (0) &&	isStart) {
			drawLine ();
		}
	}

	void drawLine() {
		startPos = new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y-radius, gameObject.transform.position.z);
		mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		lineRenderer = gameObject.GetComponent<LineRenderer> ();

		if (startPos.y - mousePos.y < 0) {
			lineRenderer.enabled = false;	


		} else {
			lineRenderer.enabled = true;
			lineRenderer.SetPosition (0, startPos);
			lineRenderer.SetPosition (1, mousePos);
		}
	}
}
