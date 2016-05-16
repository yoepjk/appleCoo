using UnityEngine;
using System.Collections;

public class Choose : MonoBehaviour {

	public GameObject obj1, obj2, obj3, obj4;
	public Canvas myCanvas;
	private Item[] items; 
	private int item_len = 4;
	private int max_cnt = 1;
	private int cur_cnt = 0;

	private static Choose instance_;
	public static Choose Instance {
		get	{ return instance_;	}
	}

	public int getLen() { return item_len; } 
	public Item[] getItems() { return items; }
	public int getCurCnt() { return cur_cnt; }
	public int getMaxCnt() { return max_cnt; }

	public void incCnt() { ++cur_cnt; }
	public void decCnt() { --cur_cnt; }

	void Awake() { 
		instance_ = this;
	}

	void Start () {				
		initItems ();	
		// 커버 시작
		GameScene scene = GameScene.Instance;
		scene.cover.SetActive (false);
	}

	void initItems() {
		items = new Item[item_len];
		for (int i = 0; i < item_len; i++) {
			items [i] = new Item ();
		}

		items[0].gObject = obj1;
		items[1].gObject = obj2;
		items[2].gObject = obj3;
		items[3].gObject = obj4;

		items [0].isSatisfied = true;
	}


	

	void Update () {
		
	}

	public class Item {

		public GameObject gObject;
		public bool isSatisfied, isClicked;

		public Item() {
			isSatisfied = false;
			isClicked = false;
		}			
	}
}


