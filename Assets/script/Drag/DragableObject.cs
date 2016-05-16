using UnityEngine;
using System.Collections;

public class DragableObject : MonoBehaviour {
	private Vector3 startPosForDraw_, curMousePos_, endPosForDraw_;
	private bool is_dragging_ = false;
	private float RADIUS;
	private float xInterval_, yInterval_;
	private Vector3 origin_pos_;

	void OnMouseDown() {
		is_dragging_ = true;

		startPosForDraw_ = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		startPosForDraw_.z = 0;
		curMousePos_ = gameObject.transform.position;
		xInterval_ = curMousePos_.x - startPosForDraw_.x;
		yInterval_ = curMousePos_.y - startPosForDraw_.y;

		gameObject.GetComponent<SpriteRenderer> ().sortingOrder = 4;
	}

	void OnMouseUp() {
		if (is_dragging_ == false) 
			return;
		
		// clear
		is_dragging_ = false;
		var dest_obj = checkDest ();

		// draw
		if(dest_obj != null)
			_drawDestObj();
		
		// put answer
		Solution solution = GameScene.Instance.solution;
		if (dest_obj != null)
			solution.putAnswer (gameObject.name, new DragAnswer (this, dest_obj));
		else
			solution.removeAnswer (gameObject.name);

		gameObject.GetComponent<SpriteRenderer> ().sortingOrder = 3;
	}

	private void _drawDestObj() {
		gameObject.transform.position = endPosForDraw_;
	}

	private GameObject checkDest() {
		var solution = GameScene.Instance.solution as DragSolution;
		foreach (var ds in solution.destObjs) {
			endPosForDraw_ = ds.transform.position;
			float distance = Vector2.Distance (curMousePos_, endPosForDraw_);
			if (distance <= RADIUS * 2) {				
				return ds;
			}
		}

		return null;
	}

	public void moveToOrigin() {
		gameObject.transform.position = origin_pos_;
	}

	void Awake() {
	}

	void Start () {
		RADIUS = GameScene.Instance.RADIUS;
		origin_pos_ = gameObject.transform.position;		
	}
	

	void Update () {
		if (Input.GetMouseButton (0) &&	is_dragging_) {
			startPosForDraw_ = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			drag();
		}
	}

	void drag() {		
		curMousePos_.x = startPosForDraw_.x + xInterval_;
		curMousePos_.y = startPosForDraw_.y + yInterval_;

		gameObject.transform.position = curMousePos_;
	}
}
