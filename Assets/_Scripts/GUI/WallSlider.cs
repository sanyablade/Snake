using UnityEngine;

public class WallSlider : MonoBehaviour {
	// === Unity ======================================================================================================
	private void Start() {
		_gameData = GameData.GetInstance;
	}

	// === Public =====================================================================================================
	public void ProgressBarChangeCallback() {
		_gameData.SetWallCount(UIProgressBar.current.value);
	}

	// === Private ====================================================================================================
	private GameData _gameData;
}