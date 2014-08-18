using System;
using UnityEngine;

public class CameraManager : MonoBehaviour {
	// === Public =====================================================================================================
	public static CameraManager GetInstance {
		get {
			if (_instance == null) {
				_instance = new GameObject(typeof(CameraManager).Name).AddComponent<CameraManager>();
			}
			return _instance;
		}
	}

	public void Initialize() {
		DestroyAllCameras();
		if (GameData.GetInstance.IsCamera2D) {
			GetCamera2D();
		} else {
			GetCamera3D();
		}
	}

	public GameObject GetCamera2D() {
		if (_camera3D != null) {
			DestroyGameObject(_camera3D);
		}
		if (_camera2D == null) {
			CreateCamera2D();
		}
		return _camera2D;
	}

	public GameObject GetCamera3D() {
		if (_camera2D != null) {
			DestroyGameObject(_camera2D);
		}
		if (_camera3D == null) {
			CreateCamera3D();
		}
		return _camera3D;
	}

	public void Destroy() {
		DestroyGameObject(_camera2D);
		DestroyGameObject(_camera3D);
	}

	// === Private ====================================================================================================
	private static CameraManager _instance;
	private GameObject _camera2D;
	private GameObject _camera3D;

	private void CreateCamera2D() {
		_camera2D = CreateGameObject(GetCamera2DPrefab());
	}

	private void CreateCamera3D() {
		_camera3D = CreateGameObject(GetCamera3DPrefab());
	}

	private GameObject GetCamera2DPrefab() {
		return GetPrefabFromResources(Constants.Resources.Prefabs.Camera.CAMERA_2D);
	}

	private GameObject GetCamera3DPrefab() {
		return GetPrefabFromResources(Constants.Resources.Prefabs.Camera.CAMERA_3D);
	}

	private GameObject GetPrefabFromResources(string namePrefab) {
		var prefab = Resources.Load(namePrefab) as GameObject;
		if (prefab == null) {
			throw new ArgumentNullException(namePrefab);
		}
		return prefab;
	}

	private GameObject CreateGameObject(GameObject prefab) {
		return Instantiate(prefab) as GameObject;
	}

	private void DestroyGameObject(GameObject _camera) {
		if (_camera == null) {
			return;
		}
		Destroy(_camera);
	}

	private void DestroyAllCameras() {
		DestroyGameObject(_camera2D);
		_camera2D = null;
		DestroyGameObject(_camera3D);
		_camera3D = null;
	}
}
