using UnityEngine;

public class WallLabel : MonoBehaviour {
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
	private const string WALL = "Wall: ";
	private int _wall;

	private void RefreshLabelText() {
		var wallNew = _gameData.WallCount;
		if (_wall != wallNew) {
			_wall = wallNew;
			Label.text = WALL + _wall;
		}
	}
}
