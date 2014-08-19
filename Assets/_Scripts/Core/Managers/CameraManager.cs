using UnityEngine;

public class CameraManager : MonoBehaviour {
	// === Unity ======================================================================================================
	public void Awake() {
		_instance = this;
	}

	// === Public =====================================================================================================
	public static CameraManager GetInstance { get { return _instance; } }

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
		_camera2D = GameObjectTools.CreateGameObject(Constants.Resources.Prefabs.Camera.CAMERA_2D);
	}

	private void CreateCamera3D() {
		_camera3D = GameObjectTools.CreateGameObject(Constants.Resources.Prefabs.Camera.CAMERA_3D);
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
