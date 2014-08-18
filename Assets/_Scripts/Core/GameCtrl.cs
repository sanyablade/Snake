using UnityEngine;

public class GameCtrl : MonoBehaviour {
	// === Public =====================================================================================================
	public static GameCtrl GetInstance {
		get {
			if (_instance == null) {
				_instance = new GameObject(typeof(GameCtrl).Name).AddComponent<GameCtrl>();
			}
			return _instance;
		}
	}

	public void Reset() {
		GameData.GetInstance.ReduceLife(1);

		SnakeCtrl.GetInstance.Destroy();
		InputHelper.GetInstance.Destroy();
		FoodCtrl.GetInstance.Destroy();
		CameraCtrl.GetInstance.Destroy();
		GameData.GetInstance.ResetLevelData();

		if (GameData.GetInstance.Life > 0) {
			SnakeManager.GetInstance.Initialize();
			SnakeCtrl.GetInstance.Initialize();
			InputHelper.GetInstance.Initialize();

			CameraCtrl.GetInstance.Initialize();
			FoodCtrl.GetInstance.Initialize();
		} else {
			GameBoard.GetInstance.Destroy();
			WallCtrl.GetInstance.Destroy();

			GUIManager.GetInstance.HideInfoPanel();
			GUIManager.GetInstance.ShowGameOverPanel();
		}
	}

	// === Private ====================================================================================================
	private static GameCtrl _instance;
}
