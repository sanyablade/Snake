using System;
using AnimationOrTween;
using UnityEngine;

public class Body : IFieldElement {
	// === Public =====================================================================================================
	#region IFieldElement
	public FieldElementType FieldElementType { get { return FieldElementType.Body; } }
	public Vector2 Position { get; set; }
	public void DoCollision() {
		throw new System.NotImplementedException();
	}
	#endregion

	public BodyView View { get; private set; }
	public DirectionSnake Direction { get; private set; }
	public DirectionSnake NextDirection { get; private set; }
	public Vector2 NextPosition { get; set; }
	public bool IsPause { get; set; }

	public Body(BodyView view, Vector2 position, DirectionSnake direction) {
		View = view;
		IsPause = false;
		Position = position;
		Direction = NextDirection = direction;
		NextPosition = GetNextPosition();
	}

	public Body(BodyView view, Body target) {
		View = view;
		_target = target;
		IsPause = true;
		Position = target.Position;
		Direction = target.Direction;
		NextDirection = target.NextDirection;
		NextPosition = target.NextPosition;
	}

	public void SetNextDirection(DirectionSnake direction) {
		NextDirection = direction;
	}

	public void UpdatePointAndCurDirection() {
		if (_target == null) {
			Position = NextPosition;
			NextPosition = GetNextPosition();
			Direction = NextDirection;
		} else {
			Position = NextPosition;
			NextPosition = _target.Position;
			Direction = NextDirection;
			NextDirection = _target.Direction;
		}
	}

	public bool IsVecticalMoving() {
		return Direction == DirectionSnake.UP || Direction == DirectionSnake.DOWN;
	}

	public void StartMove() {
		IsPause = false;
	}

	// === Private ====================================================================================================
	private Body _target;

	private Vector2 GetNextPosition() {
		switch (NextDirection) {
			case DirectionSnake.LEFT:
				return new Vector2(Position.x - Constants.CELL_LENGTH, Position.y);
			case DirectionSnake.RIGHT:
				return new Vector2(Position.x + Constants.CELL_LENGTH, Position.y);
			case DirectionSnake.UP:
				return new Vector2(Position.x, Position.y + Constants.CELL_LENGTH);
			case DirectionSnake.DOWN:
				return new Vector2(Position.x, Position.y - Constants.CELL_LENGTH);
		}
		throw new Exception("WTF???");
	}
}