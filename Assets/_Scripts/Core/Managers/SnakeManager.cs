using System.Linq;
using UnityEngine;

public class SnakeManager : MonoBehaviour {
	// === Unity ======================================================================================================
	public void Awake() {
		_instance = this;
	}

	// === Public =====================================================================================================
	public static SnakeManager GetInstance { get { return _instance; } }

	public Body CreateSnakeHead() {
		var snakeHead = GameObjectTools.CreateGameObject(Constants.Resources.Prefabs.SNAKE_HEAD);
		var bodyView = GameObjectTools.GetComponent<BodyView>(snakeHead);
		return new Body(bodyView, new Vector2(0, 0), DirectionSnake.RIGHT);
	}

	public Body CreateSnakeTail(Body target) {
		var snakeTail = GameObjectTools.CreateGameObject(Constants.Resources.Prefabs.SNAKE_TAIL);
		var bodyView = GameObjectTools.GetComponent<BodyView>(snakeTail);
		return new Body(bodyView, target);
	}

	// === Private ====================================================================================================
	private static SnakeManager _instance;
}
