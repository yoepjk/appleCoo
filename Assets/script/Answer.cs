using UnityEngine;
using System.Collections;
using System.Collections.Generic;

abstract public class Answer {
	abstract public double calcualteAnswerScore (Answer correct_answer);
}

public class ChoiceAnswer : Answer {
	private GameObject choice_obj_;
	public GameObject choice_obj { get { return choice_obj_; } }

	public ChoiceAnswer (GameObject obj) {
		choice_obj_ = obj;
	}

	override public double calcualteAnswerScore(Answer correct_answer) {
		if (choice_obj == (correct_answer as ChoiceAnswer).choice_obj) 
			return 1;
		else
			return 0;
	}
}

public class MultiChoiceAnswer : Answer {
	private GameObject multi_choice_obj_;
	public GameObject multi_choice_obj { get { return multi_choice_obj_; } }

	public MultiChoiceAnswer (GameObject obj) {
		multi_choice_obj_ = obj;
	}

	override public double calcualteAnswerScore(Answer correct_answer) {
		if (multi_choice_obj_ == (correct_answer as MultiChoiceAnswer).multi_choice_obj_) 
			return 1;
		else
			return 0;
	}
}

public class LinkAnswer : Answer {
	private GameObject start_obj_, end_obj_;
	public GameObject start_obj{ get { return start_obj_; } }
	public GameObject end_obj  { get { return end_obj_;   } }

	public LinkAnswer (GameObject start_obj, GameObject end_obj) {
		start_obj_ = start_obj;
		end_obj_   = end_obj;
	}

	override public double calcualteAnswerScore(Answer correct_answer) {
		if (	start_obj_ == (correct_answer as LinkAnswer).start_obj_ && 
				end_obj_   == (correct_answer as LinkAnswer).end_obj_ ) 
			return 1;
		else
			return 0;
	}
}


public class DragAnswer : Answer {
	private DragableObject src_obj_;
	public  DragableObject src_obj{ get { return src_obj_; } }

	private GameObject dst_obj_;
	public  GameObject dst_obj{ get { return dst_obj_; } }

	public DragAnswer (DragableObject src_obj, GameObject des_obj) {
		src_obj_ = src_obj;
		dst_obj_ = des_obj;
	}

	override public double calcualteAnswerScore(Answer correct_answer) {
		var da = correct_answer as DragAnswer;
		if (	src_obj_ == da.src_obj_ &&
		   		dst_obj_ == da.dst_obj_ )
			return 1;
		else
			return 0;
	}
}
