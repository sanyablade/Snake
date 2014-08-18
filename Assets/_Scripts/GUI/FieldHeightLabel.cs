using UnityEngine;

public class FieldHeightLabel : MonoBehaviour {
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
	private const string HEIGHT = "Height: ";
	private int _height;

	private void RefreshLabelText() {
		var heightNew = (int)_gameData.FieldSize.y;
		if (_height != heightNew) {
			_height = heightNew;
			Label.text = HEIGHT + _height;
		}
	}
}
