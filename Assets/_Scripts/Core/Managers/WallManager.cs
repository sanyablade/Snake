using UnityEngine;

public class WallManager : MonoBehaviour {
	// === Unity ======================================================================================================
	public void Awake() {
		_instance = this;
	}

	// === Public =====================================================================================================
	public static WallManager GetInstance { get { return _instance; } }

	public Wall CreateWall(Vector2 pos) {
		var wallGo = GameObjectTools.CreateGameObject(Constants.Resources.Prefabs.WALL);
		var wallView = GameObjectTools.GetComponent<WallView>(wallGo);
		wallGo.transform.position = new Vector3(pos.x, 0, pos.y);
		return new Wall { Position = pos, View = wallView };
	}

	// === Private ====================================================================================================
	private static WallManager _instance;
}
