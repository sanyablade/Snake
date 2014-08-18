using System;
using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	// === Public =====================================================================================================
	public void Play() {
		GameBoard.GetInstance.Initialize();
		WallCtrl.GetInstance.Initialize();
		SnakeManager.GetInstance.Initialize();
		SnakeCtrl.GetInstance.Initialize();
		InputHelper.GetInstance.Initialize();
		CameraCtrl.GetInstance.Initialize();
		FoodCtrl.GetInstance.Initialize();
		GUIManager.GetInstance.ShowInfoPanel();
	}

	public void Stop() {
		GameBoard.GetInstance.Destroy();
		SnakeCtrl.GetInstance.Destroy();
		InputHelper.GetInstance.Destroy();
		CameraCtrl.GetInstance.Destroy();
		FoodCtrl.GetInstance.Destroy();
		WallCtrl.GetInstance.Destroy();
		GameData.GetInstance.ResetGame();
	}
}
