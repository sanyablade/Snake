using UnityEngine;

public class SnakeLengthLabel : MonoBehaviour {
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
	private const string SNAKE_LENGTH = "Length of Snake: ";
	private int _snakeLength;

	private void RefreshLabelText() {
		var snakeLengthNew = _gameData.SnakeBodyDatas.Count;
		if (_snakeLength != snakeLengthNew) {
			_snakeLength = snakeLengthNew;
			Label.text = SNAKE_LENGTH + _snakeLength;
		}
	}
}
