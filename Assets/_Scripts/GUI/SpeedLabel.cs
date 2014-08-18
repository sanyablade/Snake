using UnityEngine;

public class SpeedLabel : MonoBehaviour {
	// === Unity ======================================================================================================
	public UILabel Label;

	private void Start() {
		_gameData = GameData.GetInstance;
		RefreshLabelText();
	}

	private void Update() {
		RefreshLabelText();
	}

	// === Private ====================================================================================================
	private GameData _gameData;
	private const string SPEED = "Speed: ";
	private int _speed;

	private void RefreshLabelText() {
		var speedNew = (int)_gameData.SnakeSpeed;
		if (_speed != speedNew) {
			_speed = speedNew;
			Label.text = SPEED + _speed;
		}
	}
}
