using System;
using UnityEngine;

public class GameObjectTools : MonoBehaviour {
	// === Public =====================================================================================================
	public static GameObject CreateGameObject(GameObject prefab) {
		return Instantiate(prefab) as GameObject;
	}

	public static GameObject CreateGameObject(string namePrefab) {
		return Instantiate(GetPrefabFromResources(namePrefab)) as GameObject;
	}

	public static GameObject GetPrefabFromResources(string namePrefab) {
		var prefab = Resources.Load(namePrefab) as GameObject;
		if (prefab == null) {
			throw new ArgumentNullException(namePrefab);
		}
		return prefab;
	}

	public static T GetComponent<T>(GameObject obj) where T : Component {
		var component = obj.GetComponent<T>();
		if (component == null) {
			throw new ArgumentNullException(typeof(T).Name);
		}
		return component;
	}
}