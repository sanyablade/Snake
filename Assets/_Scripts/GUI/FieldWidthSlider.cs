using UnityEngine;

public class FieldWidthSlider : MonoBehaviour {
	// === Unity ======================================================================================================
	private void Start() {
		_gameData = GameData.GetInstance;
	}

	// === Public =====================================================================================================
	public void ProgressBarChangeCallback() {
		_gameData.SetFieldWidth(UIProgressBar.current.value);
	}

	// === Private ====================================================================================================
	private GameData _gameData;
}