using UnityEngine;
using System.Collections;

public class MagnetLink : MonoBehaviour {
	public Canvas myCanvas;
	public GameObject src1, src2, src3, src4, src5, des;
	public int item_len;
	public Item[] items;

	private static MagnetLink instance_;
	public static MagnetLink Instance {
		get	{ return instance_;	}
	}

	public int 		  	getLen() { return item_len;}
	public Item[] 		getItems() { return items;}
	public GameObject 	getEnd() { return des; }

	void Awake() {
		instance_ = this;	
	}

	void Start () {	
		initItems ();
		// 커버 시작
		GameScene scene = GameScene.Instance;
		scene.cover.SetActive (false);
	}

	protected void initItems() {
		items = new Item[item_len];
		for (int i = 0; i < item_len; i++) {
			items [i] = new Item ();
		}

		items [0].src = src1;
		items [1].src = src2;
		items [2].src = src3;
		items [3].src = src4;
		items [4].src = src5;

		items [0].isSatisfied = true;
		items [2].isSatisfied = true;
		items [3].isSatisfied = true;
	}

	void Update () {

	}


	public class Item {
		public GameObject src;
		public bool isLinked = false;
		public bool isSatisfied = false;
	}

}
