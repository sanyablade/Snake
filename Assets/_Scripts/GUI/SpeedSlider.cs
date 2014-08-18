using UnityEngine;

public class SpeedSlider : MonoBehaviour {
	// === Unity ======================================================================================================
	private void Start() {
		_gameData = GameData.GetInstance;
	}

	// === Public =====================================================================================================
	public void ProgressBarChangeCallback() {
		_gameData.SetSnakeSpeed(UIProgressBar.current.value);
	}

	// === Private ====================================================================================================
	private GameData _gameData;
}