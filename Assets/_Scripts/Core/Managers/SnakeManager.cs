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
		var snakeHead = GameObjectTools.CreateGameObject(Constants.Resources.Prefabs.SNAKE_HEAD);
		var snakeBodyView = GameObjectTools.GetComponent<SnakeBodyView>(snakeHead);

		var bodyView = GameObjectTools.GetComponent<BodyView>(snakeHead);
		var body = new Body(bodyView, new Vector2(0, 0), DirectionSnake.RIGHT);

		var bodyData = new SnakeBodyData(new Vector2(0, 0), DirectionSnake.RIGHT, DirectionSnake.RIGHT);
		bodyData.StartMove();
		snakeBodyView.Initialize(bodyData.CurPoint, bodyData.NextPoint);
		GameData.GetInstance.AddSnakeBody(bodyData, snakeBodyView);
	}

	public void CreateSnakeTail() {
		var snakeTail = GameObjectTools.CreateGameObject(Constants.Resources.Prefabs.SNAKE_TAIL);
		var bodyView = GameObjectTools.GetComponent<SnakeBodyView>(snakeTail);
		var target = GameData.GetInstance.SnakeBodyDatas.Last();
		var bodyData = new SnakeBodyData(target);
		bodyView.Initialize(bodyData.CurPoint, bodyData.NextPoint);
		GameData.GetInstance.AddSnakeBody(bodyData, bodyView);
	}

	// === Private ====================================================================================================
	private static SnakeManager _instance;
}
