using UnityEngine;
using System.Collections;

public class ScoreLabel : MonoBehaviour {
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
	private const string SCORE = "Score:\n";
	private int _score;

	private void RefreshLabelText() {
		var scoreNew = _gameData.Score;
		if (_score != scoreNew) {
			_score = scoreNew;
			Label.text = SCORE + _score;
		}
	}
}
