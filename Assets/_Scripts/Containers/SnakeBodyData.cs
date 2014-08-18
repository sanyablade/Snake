using System;
using UnityEngine;

public class SnakeBodyData {
	// === Public =====================================================================================================
	public DirectionSnake CurDirection { get; private set; }
	public DirectionSnake NextDirection { get; private set; }
	public Vector2 CurPoint { get; private set; }
	public Vector2 NextPoint { get; private set; }
	public bool IsPause{ get; private set; }

	public bool IsVecticalMoving() {
		return CurDirection == DirectionSnake.UP || CurDirection == DirectionSnake.DOWN;
	}

	public SnakeBodyData(Vector2 curPoint, DirectionSnake curDirection, DirectionSnake nextDirection) {
		IsPause = false;
		CurDirection = curDirection;
		NextDirection = nextDirection;
		CurPoint = curPoint;
		NextPoint = GetNewPointOfMovement();
	}

	public SnakeBodyData(SnakeBodyData bodyData) {
		IsPause = true;
		CurDirection = bodyData.CurDirection;
		NextDirection = bodyData.NextDirection;
		CurPoint = bodyData.CurPoint;
		NextPoint = bodyData.NextPoint;
	}

	public void SetNextDirection(DirectionSnake direction) {
		NextDirection = direction;
	}

	public void UpdatePointAndCurDirection() {
		CurPoint = NextPoint;
		NextPoint = GetNewPointOfMovement();
		CurDirection = NextDirection;
	}

	public void StartMove() {
		IsPause = false;
	}

	// === Private ====================================================================================================
	private Vector2 GetNewPointOfMovement() {
		switch (NextDirection) {
			case DirectionSnake.LEFT:
				return new Vector2(CurPoint.x - 1, CurPoint.y);
			case DirectionSnake.RIGHT:
				return new Vector2(CurPoint.x + 1, CurPoint.y);
			case DirectionSnake.UP:
				return new Vector2(CurPoint.x, CurPoint.y + 1);
			case DirectionSnake.DOWN:
				return new Vector2(CurPoint.x, CurPoint.y - 1);
		}
		throw new Exception("WTF???");
	}
}
