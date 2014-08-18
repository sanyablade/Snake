using System.Linq;
using UnityEngine;

public class FoodCtrl : MonoBehaviour {
	// === Unity ======================================================================================================
	private void Update() {
		if (_data.FoodPos.Equals(new Vector2(-1, -1)) || !_data.FoodView) {
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
		_data = GameData.GetInstance;
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
	private GameData _data;

	private void GenerateFood() {
		var pointX = (int)Random.Range(0, _data.FieldSize.x - 1);
		var pointY = (int)Random.Range(0, _data.FieldSize.y - 1);
		var point = new Vector2(pointX, pointY);
		if (CheckCollisionWithBody(point) || CheckCollisionWithWall(point)) {
			return;
		}
		FoodManager.GetInstance.CreateFood(point);
	}

	private bool CheckCollisionWithBody(Vector2 point) {
		if (point.Equals(_data.SnakeBodyDatas.First().NextPoint)) {
			return true;
		}
		foreach (var snakeBodyData in _data.SnakeBodyDatas) {
			if (point.Equals(snakeBodyData.CurPoint)) {
				return true;
			}
		}
		return false;
	}

	private bool CheckCollisionWithWall(Vector2 point) {
		foreach (var fieldElement in _data.Elements) {
			if (fieldElement.FieldElementType == FieldElementType.Wall) {
				if (point.Equals(fieldElement.Position)) {
					return true;
				}
			}
		}
		return false;
	}
}

