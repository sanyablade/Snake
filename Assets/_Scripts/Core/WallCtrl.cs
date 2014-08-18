using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WallCtrl : MonoBehaviour {
	// === Public =====================================================================================================
	public static WallCtrl GetInstance {
		get {
			if (_instance == null) {
				_instance = new GameObject(typeof(WallCtrl).Name).AddComponent<WallCtrl>();
			}
			return _instance;
		}
	}

	public void Initialize() {
		_data = GameData.GetInstance;
		GenerateFreePoint();
	}

	public void Destroy() {
		foreach (var wall in _walls) {
			wall.View.Destroy();
		}
		_walls.Clear();
		_instance = null;
		Destroy(gameObject);
	}

	// === Private ====================================================================================================
	private static WallCtrl _instance;
	private List<Wall> _walls = new List<Wall>();
	private GameData _data;

	private void GenerateFreePoint() {
		for (int i = 0; i < _data.WallCount; i++) {
			bool isCreatedWall = false;
			do {
				var pointX = (int)Random.Range(1, _data.FieldSize.x - 2);
				var pointY = (int)Random.Range(1, _data.FieldSize.y - 2);
				var point = new Vector2(pointX, pointY);
				if (!CheckCollisionWithWall(point)) {
					var wall = WallManager.GetInstance.CreateWall(point);
					_walls.Add(wall);
					_data.AddElement(wall);
					isCreatedWall = true;
				}
			} while (!isCreatedWall);
		}
	}

	private bool CheckCollisionWithWall(Vector2 point) {
		return _walls.Any(wall => point.Equals(wall.Position));
	}
}

