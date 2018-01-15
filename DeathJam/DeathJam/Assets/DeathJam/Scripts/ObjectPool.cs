using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour 
{
//	public static ObjectPool Instance
//	{
//		get
//		{
//			if(!instance)
//			{
//				instance = new ObjectPool();
//			}
//
//			return instance;
//		}
//
//	}
//	static ObjectPool instance;
	static Dictionary <string, GameObject[]> ObjectDictionary = new Dictionary<string, GameObject[]>();

//	static ObjectPool()
//	{
//		ObjectPool.ObjectDictionary = new Dictionary<string, GameObject[]>();
//	}
	public static void CreatePool(string name, int amount, GameObject obj)
	{
		GameObject[] newPool = new GameObject[amount];
		for(int p = 0; p<amount;p++)
		{
			newPool[p] = (GameObject)Instantiate(obj);
			newPool[p].SetActive(false);
		}
		ObjectPool.ObjectDictionary.Add(name, newPool);
	}
	public static void DestroyPool(string name)
	{
		if(ObjectPool.ObjectDictionary.ContainsKey(name))
		{
			ObjectPool.ObjectDictionary.Remove(name);
		}
	}
	public static void CloseDictionary()
	{
		ObjectPool.ObjectDictionary.Clear();
	}
	public static GameObject DrawFromPool(string pool)
	{
		GameObject[] objectPool;
		GameObject obj = null;
		if(ObjectPool.ObjectDictionary.TryGetValue(pool, out objectPool))
		{
			for(int i = 0; i<objectPool.Length;i++)
			{
				if(!objectPool[i].activeSelf)
				{
					obj = objectPool[i];
				}
			}
		}
		return obj;
	}

	public static GameObject[] DrawFromPool(int amount, string pool)
	{
		GameObject[] objectPool;
		if(ObjectPool.ObjectDictionary.TryGetValue(pool, out objectPool))
		{
			GameObject[] returnPool = new GameObject[amount];
			int counter = 0;
			for(int i = 0; i<objectPool.Length&&counter<amount;i++)
			{
				if(!objectPool[i].activeSelf)
				{
					returnPool[counter] = objectPool[i];
					counter++;
				}
			}
			return returnPool;

		}else return null;
	}
}
