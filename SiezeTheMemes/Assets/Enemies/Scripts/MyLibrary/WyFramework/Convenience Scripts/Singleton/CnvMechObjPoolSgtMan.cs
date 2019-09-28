using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://www.raywenderlich.com/847-object-pooling-in-unity

[System.Serializable]
public class ObjectPoolItem {
	public GameObject objectToPool;
	public int amountToPool;
	public bool shouldExpand;
	public GameObject PoolItemParent;
}

public class CnvMechObjPoolSgtMan : MonoBehaviour
{
	public Vector3 hiddenPos = new Vector3(-99999,-99999,-99999); // position where objects that are not in world are placed/hidden
  	public List<ObjectPoolItem> itemsToPool;

    public  List<GameObject> Pool; // object that are in pool

    private GameObject objectToActivate;
	public static CnvMechObjPoolSgtMan instance = null;


	//Singelton
	void Awake() {
			instance = this;
	}

    // Start is called before the first frame update
	void Start () {
		Pool = new List<GameObject>();
		foreach (ObjectPoolItem item in itemsToPool) {
			item.objectToPool.transform.position = hiddenPos;
			for (int i = 0; i < item.amountToPool; i++) {
			GameObject obj = (GameObject)Instantiate(item.objectToPool);
			obj.SetActive(false);
			obj.transform.position = hiddenPos;
			Pool.Add(obj);
			}
		}
	}
	

	void Update() {

	}

	public GameObject GetPooledObject(string tag) {
		for (int i = 0; i < Pool.Count; i++) {
			if (!Pool[i].activeInHierarchy && Pool[i].tag == tag) {
				return Pool[i];
			}
		}
		foreach (ObjectPoolItem item in itemsToPool) {
			if (item.objectToPool.tag == tag) {
				if (item.shouldExpand) {
				GameObject obj = (GameObject)Instantiate(item.objectToPool);
				obj.SetActive(false);
				Pool.Add(obj);
				obj.transform.parent = item.PoolItemParent.transform;
				return obj;
				}
			}
		}
		return null;
	}
	public GameObject GetPooledObjectRandom() {
		ShuffleList(Pool);
		for (int i = 0; i < Pool.Count; i++) {
			if (!Pool[i].activeInHierarchy ) {
				return Pool[i];
			}
		}
		foreach (ObjectPoolItem item in itemsToPool) {
			// if (item.objectToPool.tag == tag) {
				if (item.shouldExpand) {
				GameObject obj = (GameObject)Instantiate(item.objectToPool);
				obj.SetActive(false);
				Pool.Add(obj);
				obj.transform.parent = item.PoolItemParent.transform;
				return obj;
				}
			// }
		}
		return null;
	}


	void ShuffleList(List<GameObject> list)
	{
		// Loops through array
		for (int i = list.Count-1; i > 0; i--)
		{
			// Randomize a number between 0 and i (so that the range decreases each time)
			int rnd = Random.Range(0,i);
			
			// Save the value of the current i, otherwise it'll overright when we swap the values
			GameObject temp = list[i];
			
			// Swap the new and old values
			list[i] = list[rnd];
			list[rnd] = temp;
		}
		
		// Print
		for (int i = 0; i < list.Count; i++)
		{
			Debug.Log (list[i]);
		}
	}
	/*
	
		public void PutObjectInWorld(int index, Vector3 position){
			// print(Pool[index].gameObject.name);		
			
				Pool[index].transform.position = position;
				Pool[index].SetActive(true);
		}
		public void AddObjects(GameObject obj){
			Pool.Add(obj);
			obj.transform.parent = transform;
			obj.SetActive(true);
		}
	*/
}
