using System;
using UnityEngine;

public class FoodManager : MonoBehaviour {
	// === Public =====================================================================================================
	public static FoodManager GetInstance {
		get {
			if (_instance == null) {
				_instance = new GameObject(typeof(FoodManager).Name).AddComponent<FoodManager>();
			}
			return _instance;
		}
	}

	public void CreateFood(Vector2 pos) {
		var food = CreateGameObject(GetFoodPrefab());
		food.transform.position = new Vector3(pos.x, 0, pos.y);
		var foodView = GetFoodView(food);
		GameData.GetInstance.SetFood(pos, foodView);
	}

	// === Private ====================================================================================================
	private static FoodManager _instance;

	private GameObject CreateGameObject(GameObject prefab) {
		return Instantiate(prefab) as GameObject;
	}

	private GameObject GetFoodPrefab() {
		return GetPrefabFromResources(Constants.Resources.Prefabs.FOOD);
	}

	private GameObject GetPrefabFromResources(string namePrefab) {
		var prefab = Resources.Load(namePrefab) as GameObject;
		if (prefab == null) {
			throw new ArgumentNullException(namePrefab);
		}
		return prefab;
	}

	private FoodView GetFoodView(GameObject go) {
		var foodView = go.GetComponent<FoodView>();
		if (foodView == null) {
			throw new ArgumentNullException("FoodView is null");
		}
		return foodView;
	}
}
