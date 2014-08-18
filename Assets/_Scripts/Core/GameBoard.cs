using System;
using UnityEngine;

public class GameBoard : MonoBehaviour {
	// === Public =====================================================================================================
	public static GameBoard GetInstance {
		get {
			if (_instance == null) {
				_instance = new GameObject(typeof(GameBoard).Name).AddComponent<GameBoard>();
			}
			return _instance;
		}
	}

	public void Initialize() {
		CreateField();
		CreateBorder();
	}

	public void Destroy() {
		Destroy(_field);
		Destroy(_borderUp);
		Destroy(_borderDown);
		Destroy(_borderLeft);
		Destroy(_borderRight);
	}

	// === Private ====================================================================================================
	private static GameBoard _instance;
	private GameObject _field;
	private GameObject _borderUp;
	private GameObject _borderDown;
	private GameObject _borderLeft;
	private GameObject _borderRight;

	private void CreateField() {
		_field = CreateGameObject(GetFieldPrefab());
		if (_field == null) {
			return;
		}

		const float cellLength = Constants.CELL_LENGTH;
		const float cellLengthHalf = Constants.CELL_LENGTH_HALF;
		var fieldSize = GameData.GetInstance.FieldSize;
		var centerPosX = cellLength * fieldSize.x * .5f - cellLengthHalf;
		var centerPosY = cellLength * fieldSize.y * .5f - cellLengthHalf;
		_field.transform.position = new Vector3(centerPosX, -0.5f, centerPosY);
		_field.transform.localScale = new Vector3(cellLength * fieldSize.x, cellLength * fieldSize.y, 1);
		_field.renderer.material.mainTextureScale = fieldSize;
	}

	private GameObject GetFieldPrefab() {
		return GetPrefabFromResources(Constants.Resources.Prefabs.GameBoard.FIELD);
	}

	private void CreateBorder() {
		CreateBorderUp();
		CreateBorderDown();
		CreateBorderLeft();
		CreateBorderRight();
	}

	private void CreateBorderUp() {
		_borderUp = CreateGameObject(GetBorderUpPrefab());
		if (_borderUp == null) {
			return;
		}

		const float cellInUnity = Constants.CELL_LENGTH;
		var fieldSize = GameData.GetInstance.FieldSize;
		var posX = cellInUnity * fieldSize.x * .5f;
		var posY = cellInUnity * fieldSize.y;
		_borderUp.transform.position = new Vector3(posX, 0, posY);
		_borderUp.transform.localScale = new Vector3(fieldSize.x + 1, 1, 1);
		_borderUp.renderer.material.mainTextureScale = new Vector2(fieldSize.x + 1, 1);
	}

	private GameObject GetBorderUpPrefab() {
		return GetPrefabFromResources(Constants.Resources.Prefabs.GameBoard.BORDER_UP);
	}

	private void CreateBorderDown() {
		_borderDown = CreateGameObject(GetBorderDownPrefab());
		if (_borderDown == null) {
			return;
		}

		const float cellInUnity = Constants.CELL_LENGTH;
		var fieldSize = GameData.GetInstance.FieldSize;
		var posX = cellInUnity * fieldSize.x * .5f - 1;
		var posY = cellInUnity * -1;
		_borderDown.transform.position = new Vector3(posX, 0, posY);
		_borderDown.transform.localScale = new Vector3(fieldSize.x + 1, 1, 1);
		_borderDown.renderer.material.mainTextureScale = new Vector2(fieldSize.x + 1, 1);
	}

	private GameObject GetBorderDownPrefab() {
		return GetPrefabFromResources(Constants.Resources.Prefabs.GameBoard.BORDER_DOWN);
	}

	private void CreateBorderLeft() {
		_borderLeft = CreateGameObject(GetBorderLeftPrefab());
		if (_borderLeft == null) {
			return;
		}

		const float cellInUnity = Constants.CELL_LENGTH;
		var fieldSize = GameData.GetInstance.FieldSize;
		var posX = cellInUnity * -1;
		var posY = cellInUnity * fieldSize.y * .5f;
		_borderLeft.transform.position = new Vector3(posX, 0, posY);
		_borderLeft.transform.localScale = new Vector3(fieldSize.y + 1, 1, 1);
		_borderLeft.renderer.material.mainTextureScale = new Vector2(fieldSize.y + 1, 1);
	}

	private GameObject GetBorderLeftPrefab() {
		return GetPrefabFromResources(Constants.Resources.Prefabs.GameBoard.BORDER_LEFT);
	}

	private void CreateBorderRight() {
		_borderRight = CreateGameObject(GetBorderRightPrefab());
		if (_borderRight == null) {
			return;
		}

		const float cellInUnity = Constants.CELL_LENGTH;
		var fieldSize = GameData.GetInstance.FieldSize;
		var posX = cellInUnity * fieldSize.x;
		var posY = cellInUnity * fieldSize.y * .5f - 1;
		_borderRight.transform.position = new Vector3(posX, 0, posY);
		_borderRight.transform.localScale = new Vector3(fieldSize.y + 1, 1, 1);
		_borderRight.renderer.material.mainTextureScale = new Vector2(fieldSize.y + 1, 1);
	}

	private GameObject GetBorderRightPrefab() {
		return GetPrefabFromResources(Constants.Resources.Prefabs.GameBoard.BORDER_RIGHT);
	}

	private GameObject GetPrefabFromResources(string namePrefab) {
		var prefab = Resources.Load(namePrefab) as GameObject;
		if (prefab == null) {
			throw new ArgumentNullException(namePrefab);
		}
		return prefab;
	}

	private GameObject CreateGameObject(GameObject prefab) {
		var go = Instantiate(prefab) as GameObject;
		if (go) {
			go.transform.parent = transform;
		}
		return go;
	}
}
