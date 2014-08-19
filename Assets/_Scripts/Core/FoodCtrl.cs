using System.Linq;
using UnityEngine;

public class FoodCtrl : MonoBehaviour {
	// === Unity ======================================================================================================
	private void Update() {
		if (_gameData.FoodPos.Equals(new Vector2(-1, -1)) || !_gameData.FoodView) {
			GenerateFood();
		}
	}

	// === Public =====================================================================================================
	public static FoodCtrl GetInstance {
		get {
			if (_instance == null) {
				_instance = new GameObject(typeof(FoodCtrl).Name).AddComponent<FoodCtrl>();
			}
			return _instance;
		}
	}

	public void Initialize() {
		_gameData = GameData.GetInstance;
		GenerateFood();
	}

	public void Destroy() {
		var view = GameData.GetInstance.FoodView;
		if (view) {
			view.Destroy();
		}
		_instance = null;
		Destroy(gameObject);
	}

	// === Private ====================================================================================================
	private static FoodCtrl _instance;
	private GameData _gameData;

	private void GenerateFood() {
		var pointX = (int)Random.Range(0, _gameData.FieldSize.x - 1);
		var pointY = (int)Random.Range(0, _gameData.FieldSize.y - 1);
		var point = new Vector2(pointX, pointY);
		if (CheckCollisionWithElement(point)) {
			return;
		}
		FoodManager.GetInstance.CreateFood(point);
	}

	private bool CheckCollisionWithElement(Vector2 point) {
		foreach (var fieldElement in _gameData.Elements) {
			if (point.Equals(fieldElement.Position)) {
				return true;
			}
		}
		return false;
	}
}

