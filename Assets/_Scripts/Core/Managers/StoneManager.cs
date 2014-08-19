using System.Collections.Generic;
using UnityEngine;

public class StoneManager : MonoBehaviour {
	// === Unity ======================================================================================================
	public void Awake() {
		_instance = this;
		FillListPrefabs();
	}

	// === Public =====================================================================================================
	public static StoneManager GetInstance { get { return _instance; } }

	public Stone CreateStone(Vector2 pos) {
		var go = GameObjectTools.CreateGameObject(_prefabs[Random.Range(0, _prefabs.Count)]);
		var view = GameObjectTools.GetComponent<StoneView>(go);
		go.transform.position = new Vector3(pos.x, 0, pos.y);
		return new Stone(view, pos);
	}

	// === Private ====================================================================================================
	private static StoneManager _instance;
	private readonly List<string> _prefabs = new List<string>();

	private void FillListPrefabs() {
		_prefabs.Add(Constants.Resources.Prefabs.Stones.STONE_1);
		_prefabs.Add(Constants.Resources.Prefabs.Stones.STONE_2);
		_prefabs.Add(Constants.Resources.Prefabs.Stones.STONE_3);
		_prefabs.Add(Constants.Resources.Prefabs.Stones.STONE_4);
		_prefabs.Add(Constants.Resources.Prefabs.Stones.STONE_5);
	}
}
