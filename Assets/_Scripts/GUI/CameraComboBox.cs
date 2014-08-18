using UnityEngine;
using System.Collections;

public class CameraComboBox : MonoBehaviour {
	// === Unity ======================================================================================================
	private void Start() {
		_gameData = GameData.GetInstance;
	}

	// === Public =====================================================================================================
	public void OnChange() {
		if(UIPopupList.current.value.Equals("Camera 2D")) {
			_gameData.SetCamera(true);
		}

		if (UIPopupList.current.value.Equals("Camera 3D")) {
			_gameData.SetCamera(false);
		}
	}

	// === Private ====================================================================================================
	private GameData _gameData;
}
