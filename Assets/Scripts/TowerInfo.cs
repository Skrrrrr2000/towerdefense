using UnityEngine;
using System.Collections;

[System.Serializable]
public class TowerInfo
{

	public GameObject prefab;
	public int cost;

	public GameObject upgradedPrefab;
	public int upgradeCost;

	public int GetSellAmount()
	{
		return cost / 2;
	}

}
