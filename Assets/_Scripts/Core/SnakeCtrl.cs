using System;
using System.Linq;
using UnityEngine;

public class SnakeCtrl : MonoBehaviour {
	// === Unity ======================================================================================================
	private void Update() {
		RefreshSnakeBodyViewPosition(_gameData.SnakeSpeed * Time.deltaTime);
		UpdateDirection();

		CheckCollisionWithFood();
		CheckCollisionWithBody();
		CheckCollisionWithWall();
	}

	// === Public =====================================================================================================
	public static SnakeCtrl GetInstance {
		get {
			if (_instance == null) {
				_instance = new GameObject("SnakeCtrl").AddComponent<SnakeCtrl>();
			}
			return _instance;
		}
	}

	public void Initialize() {
		_gameData = GameData.GetInstance;
		_headData = _gameData.SnakeBodyDatas.First();
		UpdatePoint();
		UpdateRotation();
	}

	public void SetNextDirection(DirectionSnake direction) {
		if (_moveTimeRest > Constants.CELL_LENGTH_HALF) {
			return;
		}

		var newDirection = direction;
		if (newDirection == DirectionSnake.NONE) {
			return;
		}

		if (_gameData.IsCamera2D) {
			var isNewDirectionVertical = newDirection == DirectionSnake.UP || newDirection == DirectionSnake.DOWN;
			var isCurDirectionVertical = _headData.IsVecticalMoving();
			if (isCurDirectionVertical ^ isNewDirectionVertical) {
				_headData.SetNextDirection(newDirection);
			}
		} else {
			if (newDirection == DirectionSnake.LEFT) {
				switch (_headData.CurDirection) {
					case DirectionSnake.LEFT:
						_headData.SetNextDirection(DirectionSnake.DOWN);
						break;
					case DirectionSnake.UP:
						_headData.SetNextDirection(DirectionSnake.LEFT);
						break;
					case DirectionSnake.RIGHT:
						_headData.SetNextDirection(DirectionSnake.UP);
						break;
					case DirectionSnake.DOWN:
						_headData.SetNextDirection(DirectionSnake.RIGHT);
						break;
					default:
						throw new Exception("wtf");
				}
			} else if (newDirection == DirectionSnake.RIGHT) {
				switch (_headData.CurDirection) {
					case DirectionSnake.LEFT:
						_headData.SetNextDirection(DirectionSnake.UP);
						break;
					case DirectionSnake.UP:
						_headData.SetNextDirection(DirectionSnake.RIGHT);
						break;
					case DirectionSnake.RIGHT:
						_headData.SetNextDirection(DirectionSnake.DOWN);
						break;
					case DirectionSnake.DOWN:
						_headData.SetNextDirection(DirectionSnake.LEFT);
						break;
					default:
						throw new Exception("wtf");
				}
			}
		}
	}

	public void Destroy() {
		foreach (var snakeBodyView in GameData.GetInstance.SnakeBodyViews) {
			snakeBodyView.Destroy();
		}
		_instance = null;
		Destroy(gameObject);
	}

	// === Private ====================================================================================================
	private static SnakeCtrl _instance;
	private GameData _gameData;
	private SnakeBodyData _headData;
	private float _moveTimeRest;

	private void UpdatePoint() {
		var curPos = new Vector2(_headData.CurPoint.x, _headData.CurPoint.y);
		var moveVector = _headData.NextPoint - curPos;
		_moveTimeRest = moveVector.magnitude / _gameData.SnakeSpeed;
	}

	private void UpdateRotation() {
		for (int i = 0; i < _gameData.SnakeBodyViews.Count; i++) {
			var nextPoint = _gameData.SnakeBodyDatas[i].NextPoint;
			_gameData.SnakeBodyViews[i].SetNextPoint(nextPoint);
		}
	}

	private void UpdateDirection() {
		_moveTimeRest -= Time.deltaTime;
		if (_moveTimeRest > 0f) {
			return;
		}

		var offset = -_moveTimeRest;
		NormalizeSnakeBodyView();
		UpdatePointAndCurDirSnakeBodyView();
		UpdateNextDirectionForSnakeTail();
		UpdatePoint();
		UpdateRotation();
		RefreshSnakeBodyViewPosition(offset);
		_moveTimeRest -= offset;
	}

	private void RefreshSnakeBodyViewPosition(float deltaPosition) {
		for (int i = 0; i < _gameData.SnakeBodyViews.Count; i++) {
			if (_gameData.SnakeBodyDatas[i].IsPause) {
				continue;
			}
			_gameData.SnakeBodyViews[i].RefreshPosition(deltaPosition);
		}
	}

	private void NormalizeSnakeBodyView() {
		for (int i = 0; i < _gameData.SnakeBodyViews.Count; i++) {
			if (_gameData.SnakeBodyDatas[i].IsPause) {
				continue;
			}
			var endPoint = _gameData.SnakeBodyDatas[i].NextPoint;
			_gameData.SnakeBodyViews[i].NormalizePosition(endPoint);
		}
	}

	private void UpdatePointAndCurDirSnakeBodyView() {
		foreach (var snakeBodyData in _gameData.SnakeBodyDatas) {
			if (snakeBodyData.IsPause) {
				continue;
			}
			snakeBodyData.UpdatePointAndCurDirection();
		}
	}

	private void UpdateNextDirectionForSnakeTail() {
		for (int i = 1; i < _gameData.SnakeBodyDatas.Count; i++) {
			if (_gameData.SnakeBodyDatas[i].IsPause) {
				_gameData.SnakeBodyDatas[i].StartMove();
			}
			var nextDir = _gameData.SnakeBodyDatas[i - 1].CurDirection;
			_gameData.SnakeBodyDatas[i].SetNextDirection(nextDir);
		}
	}

	private void CheckCollisionWithFood() {
		if (_headData.CurPoint.Equals(_gameData.FoodPos)) {
			if (_gameData.FoodView != null) {
				_gameData.FoodView.Destroy();
			}
			_gameData.IncreaseScore(Constants.FOOD_POINTS);
			_gameData.DeleteFood();
			_gameData.IncreaseSnakeSpeed(Constants.POWER_SPEED);
			SnakeManager.GetInstance.CreateSnakeTail();
		}
	}

	private void CheckCollisionWithWall() {
		const float halfCell = Constants.CELL_LENGTH_HALF;
		if (_moveTimeRest > halfCell) {
			return;
		}

		foreach (var fieldElement in _gameData.Elements) {
			if (fieldElement.FieldElementType == FieldElementType.Border ||
				fieldElement.FieldElementType == FieldElementType.Wall) {
				if (_headData.NextPoint.Equals(fieldElement.Position)) {
					fieldElement.DoCollision();
				}
			}
		}
	}

	private void CheckCollisionWithBody() {
		const float halfCell = Constants.CELL_LENGTH_HALF;
		if (_moveTimeRest > halfCell) {
			return;
		}
		for (int i = 1; i < _gameData.SnakeBodyDatas.Count; i++) {
			if (_gameData.SnakeBodyDatas[i].IsPause) {
				continue;
			}
			if (_headData.NextPoint.Equals(_gameData.SnakeBodyDatas[i].NextPoint)) {
				GameCtrl.GetInstance.Reset();
				return;
			}
		}
	}
}
