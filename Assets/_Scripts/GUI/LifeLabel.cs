using UnityEngine;
using System.Collections;

public class LifeLabel : MonoBehaviour {
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
	private const string LIFE = "Life: ";
	private int _life;

	private void RefreshLabelText() {
		var lifeNew = _gameData.Life;
		if (_life != lifeNew) {
			_life = lifeNew;
			Label.text = LIFE + _life;
		}
	}
}
