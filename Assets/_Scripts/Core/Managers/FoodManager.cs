using UnityEngine;

public class FoodManager : MonoBehaviour {
	// === Unity ======================================================================================================
	public void Awake() {
		_instance = this;
	}
	
	// === Public =====================================================================================================
	public static FoodManager GetInstance { get { return _instance; } }

	public void CreateFood(Vector2 pos) {
		var food = GameObjectTools.CreateGameObject(Constants.Resources.Prefabs.FOOD);
		var foodView = GameObjectTools.GetComponent<FoodView>(food);
		food.transform.position = new Vector3(pos.x, 0, pos.y);
		GameData.GetInstance.SetFood(pos, foodView);
	}

	// === Private ====================================================================================================
	private static FoodManager _instance;
}
