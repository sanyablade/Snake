using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StoneCtrl : MonoBehaviour {
	// === Public =====================================================================================================
	public static StoneCtrl GetInstance {
		get {
			if (_instance == null) {
				_instance = new GameObject(typeof(StoneCtrl).Name).AddComponent<StoneCtrl>();
			}
			return _instance;
		}
	}

	public void Initialize() {
		_data = GameData.GetInstance;
		GenerateStone();
	}

	public void Destroy() {
		foreach (var wall in _stones) {
			wall.View.Destroy();
		}
		_stones.Clear();
		_instance = null;
		Destroy(gameObject);
	}

	// === Private ====================================================================================================
	private static StoneCtrl _instance;
	private readonly List<Stone> _stones = new List<Stone>();
	private GameData _data;

	private void GenerateStone() {
		for (int i = 0; i < _data.WallCount; i++) {
			bool isCreatedStone = false;
			do {
				var pointX = (int)Random.Range(1, _data.FieldSize.x - 1);
				var pointY = (int)Random.Range(1, _data.FieldSize.y - 1);
				var point = new Vector2(pointX, pointY);
				if (!CheckCollisionWitStone(point)) {
					var element = StoneManager.GetInstance.CreateStone(point);
					_stones.Add(element);
					_data.AddElement(element);
					isCreatedStone = true;
				}
			} while (!isCreatedStone);
		}
	}

	private bool CheckCollisionWitStone(Vector2 point) {
		return _stones.Any(stone => point.Equals(stone.Position));
	}
}

