using UnityEngine;
using System.Collections;

public class StartPoint : MonoBehaviour {	
	private Vector3 startPosForDraw, curMousePos, endPosForDraw;
	private float RADIUS;
	private LineRenderer line_renderer_;
	private bool is_dragging_ = false;

	void OnMouseDown() {					
		is_dragging_ = true;
	}

	void OnMouseUp() {		
		if (is_dragging_ == false)
			return;
		
		// clear
		is_dragging_ = false;
		line_renderer_.enabled = false;

		var end_point = _checkEndPoint ();

		// draw
		if (end_point != null)
			_drawLineToEndPoint ();
		else
			_eraseLine ();

		// put answer
		Solution solution = GameScene.Instance.solution;
		if (end_point != null)
			solution.putAnswer(this.name, new LinkAnswer(gameObject, end_point));
		else
			solution.putAnswer(this.name, new LinkAnswer(gameObject, null));
	}

	private void _drawLineToEndPoint() {		
		line_renderer_.SetPosition (0, startPosForDraw);
		line_renderer_.SetPosition (1, endPosForDraw  );
		line_renderer_.SetWidth (0.5f, 0.5f);
		line_renderer_.enabled = true;
	}

	private void _eraseLine() {
		line_renderer_.enabled = false;
	}

	private GameObject _checkEndPoint() {
		var solution = GameScene.Instance.solution as LinkSolution;
		foreach (var ep in solution.endPoints) {
			endPosForDraw = ep.transform.position;
			float distance = Vector2.Distance (curMousePos, endPosForDraw);
			if (distance <= RADIUS * 4) {
				return ep;
			}
		}
		return null;
	}

	void Start () {		
		RADIUS = 1f;
		startPosForDraw = new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);

		Solution solution = GameScene.Instance.solution;
		solution.putAnswer(this.name, new LinkAnswer(gameObject, null));
	}


	void Update () {
		if (Input.GetMouseButton (0) &&	is_dragging_) {
			curMousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			drawLine ();
		}
	}

	void drawLine() {
		line_renderer_ = gameObject.GetComponent<LineRenderer> ();

		line_renderer_.enabled = true;
		line_renderer_.SetPosition (0, startPosForDraw);
		line_renderer_.SetPosition (1, curMousePos);
		line_renderer_.SetWidth (0.5f, 0.5f);
	}
}
