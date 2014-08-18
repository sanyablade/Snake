using System;
using System.Linq;
using UnityEngine;

public class SnakeManager : MonoBehaviour {
	// === Unity ======================================================================================================
	public void Awake() {
		_instance = this;
	}

	// === Public =====================================================================================================
	public static SnakeManager GetInstance { get { return _instance; } }

	public void Initialize() {
		CreateSnakeHead();
		CreateSnakeTail();
	}

	public void CreateSnakeHead() {
		var snakeHead = CreateGameObject(GetSnakeHeadPrefab());
		if (snakeHead == null) {
			return;
		}
		var bodyData = new SnakeBodyData(new Vector2(0, 0), DirectionSnake.RIGHT, DirectionSnake.RIGHT);
		bodyData.StartMove();
		var bodyView = GetSnakeBodyView(snakeHead);
		bodyView.Initialize(bodyData.CurPoint, bodyData.NextPoint);
		GameData.GetInstance.AddSnakeBody(bodyData, bodyView);
	}

	public void CreateSnakeTail() {
		var snakeTail = CreateGameObject(GetSnakeTailPrefab());
		var target = GameData.GetInstance.SnakeBodyDatas.Last();
		var bodyData = new SnakeBodyData(target);
		var bodyView = GetSnakeBodyView(snakeTail);
		bodyView.Initialize(bodyData.CurPoint, bodyData.NextPoint);
		GameData.GetInstance.AddSnakeBody(bodyData, bodyView);
	}

	// === Private ====================================================================================================
	private static SnakeManager _instance;

	private GameObject GetSnakeHeadPrefab() {
		return GetPrefabFromResources(Constants.Resources.Prefabs.SNAKE_HEAD);
	}

	private GameObject GetSnakeTailPrefab() {
		return GetPrefabFromResources(Constants.Resources.Prefabs.SNAKE_TAIL);
	}

	private GameObject GetPrefabFromResources(string namePrefab) {
		var prefab = Resources.Load(namePrefab) as GameObject;
		if (prefab == null) {
			throw new ArgumentNullException(namePrefab);
		}
		return prefab;
	}

	private GameObject CreateGameObject(GameObject prefab) {
		return Instantiate(prefab) as GameObject;
	}

	private SnakeBodyView GetSnakeBodyView(GameObject go) {
		var bodyView = go.GetComponent<SnakeBodyView>();
		if (bodyView == null) {
			throw new ArgumentNullException("SnakeBodyView is null");
		}
		return bodyView;
	}
}
