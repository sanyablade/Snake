using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SnakeCtrl : MonoBehaviour {
	// === Unity ======================================================================================================
	private void Update() {
		UpdateDirection();

		CheckCollisionWithElement();
		CheckCollisionWithFood();
	}

	// === Public =====================================================================================================
	public static SnakeCtrl GetInstance {
		get {
			if (_instance == null) {
				_instance = new GameObject(typeof(SnakeCtrl).Name).AddComponent<SnakeCtrl>();
			}
			return _instance;
		}
	}

	public void Initialize() {
		_gameData = GameData.GetInstance;
		CreateHead();
		CreateTail();
		UpdatePoint();
	}

	public List<Body> GetBodies() {
		return _bodies;
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
				switch (_headData.Direction) {
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
				switch (_headData.Direction) {
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
		foreach (var body in _bodies) {
			body.View.Destroy();
			_gameData.RemoveElement(body);
		}
		_bodies.Clear();
		_instance = null;
		Destroy(gameObject);
	}

	// === Private ====================================================================================================
	private static SnakeCtrl _instance;
	private readonly List<Body> _bodies = new List<Body>();
	private GameData _gameData;
	private Body _headData;
	private float _moveTimeRest;

	private void CreateHead() {
		var body = SnakeManager.GetInstance.CreateSnakeHead();
		body.View.SetBody(body);
		body.View.RefreshDirection();
		_bodies.Add(body);
		_gameData.AddElement(body);
		_headData = body;
	}

	private void CreateTail() {
		var body = SnakeManager.GetInstance.CreateSnakeTail(_bodies.Last());
		body.View.SetBody(body);
		body.View.RefreshDirection();
		_bodies.Add(body);
		_gameData.AddElement(body);
	}

	private void UpdatePoint() {
		var pos = new Vector2(_headData.Position.x, _headData.Position.y);
		var moveVector = _headData.NextPosition - pos;
		_moveTimeRest = moveVector.magnitude / _gameData.SnakeSpeed;
	}

	private void UpdateDirection() {
		_moveTimeRest -= Time.deltaTime;
		if (_moveTimeRest > 0f) {
			return;
		}

		var offset = -_moveTimeRest;
		UpdatePoint();
		_moveTimeRest -= offset;

		foreach (var body in _bodies) {
			if (body.IsPause) {
				body.StartMove();
				body.View.RefreshDirection();
				continue;
			}
			body.UpdatePositionAndDirection();
			body.View.RefreshDirection();
		}
	}

	private void CheckCollisionWithElement() {
		foreach (var fieldElement in _gameData.Elements) {
			if (fieldElement.FieldElementType == FieldElementType.Border ||
				fieldElement.FieldElementType == FieldElementType.Wall ||
				fieldElement.FieldElementType == FieldElementType.Body) {
				if (_headData.NextPosition.Equals(fieldElement.Position)) {
					fieldElement.DoCollision();
					return;
				}
			}
		}
	}

	private void CheckCollisionWithFood() {
		if (_headData.Position.Equals(_gameData.FoodPos)) {
			if (_gameData.FoodView != null) {
				_gameData.FoodView.Destroy();
			}
			_gameData.IncreaseScore(Constants.FOOD_POINTS);
			_gameData.DeleteFood();
			_gameData.IncreaseSnakeSpeed(Constants.POWER_SPEED);
			CreateTail();
		}
	}
}
