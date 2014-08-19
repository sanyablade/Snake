using UnityEngine;

public class GameManager : MonoBehaviour {
	// === Public =====================================================================================================
	public void Play() {
		GameBoard.GetInstance.Initialize();
		StoneCtrl.GetInstance.Initialize();
		SnakeCtrl.GetInstance.Initialize();
		InputHelper.GetInstance.Initialize();
		CameraCtrl.GetInstance.Initialize();
		FoodCtrl.GetInstance.Initialize();
		GUIManager.GetInstance.ShowInfoPanel();
	}

	public void Stop() {
		GameBoard.GetInstance.Destroy();
		StoneCtrl.GetInstance.Destroy();
		InputHelper.GetInstance.Destroy();
		CameraCtrl.GetInstance.Destroy();
		FoodCtrl.GetInstance.Destroy();
		WallCtrl.GetInstance.Destroy();
		GameData.GetInstance.ResetGame();
	}
}
