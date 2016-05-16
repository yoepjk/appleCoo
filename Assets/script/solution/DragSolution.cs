using UnityEngine;
using System;
using System.Collections;

public class DragSolution : Solution {
	[System.Serializable]
	public struct PointPair {
		public DragableObject src;
		public GameObject dst;
	}

	public PointPair[]  correctAnswers;
	public GameObject[] destObjs;

	void Awake() {
		foreach (var ca in correctAnswers) {
			putCorrectAnswer (ca.src.name, new DragAnswer(ca.src, ca.dst));
		}	
	}

//	public GameObject isExistedDest(GameObject destObj) {  
//		foreach (var aw in answer_dict_) {
//			GameObject isExisted = (aw.Value as DragAnswer).isExistedInAnswer (destObj);
//			if (isExisted != null) {
//				return isExisted;
//			}
//		}		
//
//		return null;
//	}

	private DragAnswer _findAnswerByDstObj(GameObject dst_obj) {
		if (dst_obj == null)
			return null;

		foreach (var p in answer_dict_) {
			var a = p.Value as DragAnswer;
			if (a == null)
				continue;

			if (dst_obj == a.dst_obj) {
				return a;
			}
		}

		return null;
	}

	override protected void prePutAnswer(string name, Answer answer) {
		var new_answer = answer as DragAnswer;
		var old_answer = _findAnswerByDstObj (new_answer.dst_obj);
		if (old_answer == null || old_answer.src_obj == new_answer.src_obj)
			return;

		var old_src = old_answer.src_obj;
		old_src.moveToOrigin ();
		removeAnswer (old_src.name);
	}
}

