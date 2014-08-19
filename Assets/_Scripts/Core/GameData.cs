using System;
using System.Collections.Generic;
using UnityEngine;

public class GameData {
	// === Public =====================================================================================================
	public Vector2 FieldSize { get; private set; }
	public List<IFieldElement> Elements { get; private set; }
	public float SnakeSpeed { get; private set; }
	public Vector2 FoodPos { get; private set; }
	public FoodView FoodView { get; private set; }
	public int Score { get; private set; }
	public int WallCount { get; private set; }
	public int Life { get; private set; }
	public bool IsCamera2D { get; private set; }

	public static GameData GetInstance {
		get { return _instance ?? (_instance = new GameData()); }
	}

	public void SetFieldWidth(float value) {
		var width = (int)(value * (Constants.MAX_FIELD - Constants.MIN_FIELD)) + Constants.MIN_FIELD;
		FieldSize = new Vector2(width, FieldSize.y);
		CreateBorderList();
	}

	public void SetFielHeight(float value) {
		var height = (int)(value * (Constants.MAX_FIELD - Constants.MIN_FIELD)) + Constants.MIN_FIELD;
		FieldSize = new Vector2(FieldSize.x, height);
		CreateBorderList();
	}

	public void AddElement(IFieldElement element) {
		Elements.Add(element);
	}

	public void RemoveElement(IFieldElement element) {
		Elements.Remove(element);
	}

	public void SetCamera(bool isCamera2D) {
		IsCamera2D = isCamera2D;
	}

	public void SetWallCount(float value) {
		WallCount = (int)(value * Constants.MAX_WALLS);
	}

	public void SetSnakeSpeed(float value) {
		_startSpeed = SnakeSpeed = (int)(value * (Constants.MAX_SPEED - Constants.MIN_SPEED)) + Constants.MIN_SPEED;
	}

	public void IncreaseSnakeSpeed(float value) {
		SnakeSpeed += value;
	}

	public void SetFood(Vector2 pos, FoodView foodView) {
		FoodPos = pos;
		FoodView = foodView;
	}

	public void DeleteFood() {
		FoodPos = new Vector2(-1, -1);
		FoodView = null;
	}

	public void IncreaseScore(int value) {
		Score += value;
	}

	public void ReduceLife(int value) {
		Life -= value;
	}

	public void ResetScore() {
		Score = 0;
	}

	public void ResetLife() {
		Life = 3;
	}

	public void ResetLevelData() {
		SnakeSpeed = _startSpeed;
		FoodPos = new Vector2(-1, -1);
	}

	public void ResetGame() {
		ResetLevelData();
		ResetScore();
		ResetLife();
		CreateBorderList();
	}

	// === Private ====================================================================================================
	private static GameData _instance;
	private float _startSpeed;

	private GameData() {
		const int fieldWidth = 10;
		const int fieldHeight = 10;
		FieldSize = new Vector2(fieldWidth, fieldHeight);
		Elements = new List<IFieldElement>();
		FoodPos = new Vector2(-1, -1);

		_startSpeed = SnakeSpeed = Constants.MIN_SPEED;
		Score = 0;
		WallCount = 0;
		Life = 3;
		IsCamera2D = true;

		CreateBorderList();
	}

	private void CreateBorderList() {
		Elements.Clear();
		// Left wall
		for (int y = 0; y < FieldSize.y; y++) {
			var border = new Border(new Vector2(-1, y));
			AddElement(border);
		}
		// Right wall
		for (int y = (int)FieldSize.y - 1; -1 < y; y--) {
			var border = new Border(new Vector2(FieldSize.x, y));
			AddElement(border);
		}
		// Up wall
		for (int x = 0; x < FieldSize.x; x++) {
			var border = new Border(new Vector2(x, FieldSize.y));
			AddElement(border);
		}
		// Down wall
		for (int x = (int)FieldSize.x - 1; -1 < x; x--) {
			var border = new Border(new Vector2(x, -1));
			AddElement(border);
		}
	}
}
