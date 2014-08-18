using UnityEngine;

public class FieldWidthLabel : MonoBehaviour {
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
	private const string WIDTH = "Width: ";
	private int _width;

	private void RefreshLabelText() {
		var widthNew = (int)_gameData.FieldSize.x;
		if (_width != widthNew) {
			_width = widthNew;
			Label.text = WIDTH + _width;
		}
	}
}
