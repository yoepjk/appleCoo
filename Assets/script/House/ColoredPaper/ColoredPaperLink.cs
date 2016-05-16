using UnityEngine;
using System.Collections;

public class ColoredPaperLink : MonoBehaviour {
	public Canvas myCanvas;
	public GameObject src1, des1, src2, des2, src3, des3, src4, des4, src5, des5;
	public int all_len;
	protected int item_len;
	protected GameObject[] allObjs, desObjs;
	protected Item[] items;

	private static ColoredPaperLink instance_;
	public static ColoredPaperLink Instance {
		get	{ return instance_;	}
	}

	public int 		  	getLen() { return item_len;}
	public Item[] 		getItems() { return items;}
	public GameObject[] getEnds() { return desObjs; }

	void Awake() {
		instance_ = this;	
	}

	void Start () {	
		initObjs ();	
		initItems ();
		// 커버 시작
		GameScene scene = GameScene.Instance;
		scene.cover.SetActive (false);
	}

	protected void initObjs() {
		allObjs = new GameObject[all_len];
		allObjs [0] = src1;		allObjs [1] = des1;		allObjs [2] = src2;		allObjs [3] = des2;
		allObjs [4] = src3;		allObjs [5] = des3;		allObjs [6] = src4;		allObjs [7] = des4;
		allObjs [8] = src5;		allObjs [9] = des5;

		item_len = all_len / 2;
		desObjs = new GameObject[item_len];
		for (int i = 0; i < item_len; i++) {
			desObjs [i] = allObjs[i*2 + 1];
		}
	}


	protected void initItems() {
		items = new Item[item_len];
		for (int i = 0; i < item_len; i++) {
			items [i] = new Item ();
		}


		for (int i = 0, j=0; i < all_len; i+=2, j++) {
			items [j].src = allObjs [i];
			items[j].des = allObjs [i+1];
		}
	}

	void Update () {
	
	}


	public class Item {
		public GameObject src, des, cur;
		public bool isLinked = false;
	}

}
