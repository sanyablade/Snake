using UnityEngine;

public class FieldHeightSlider : MonoBehaviour {
	// === Unity ======================================================================================================
	private void Start() {
		_gameData = GameData.GetInstance;
	}

	// === Public =====================================================================================================
	public void ProgressBarChangeCallback() {
		_gameData.SetFielHeight(UIProgressBar.current.value);
	}

	// === Private ====================================================================================================
	private GameData _gameData;
}