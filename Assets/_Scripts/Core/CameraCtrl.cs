using System.Linq;
using UnityEngine;

public class CameraCtrl : MonoBehaviour {
	public void Update() {
		if (!_data.IsCamera2D) {
			return;
		}
		if (_screenSize.x.Equals(Screen.width) && _screenSize.y.Equals(Screen.height)) {
			return;
		}
		SetCamera2DSize();
	}

	// === Public =====================================================================================================
	public static CameraCtrl GetInstance {
		get {
			if (_instance == null) {
				_instance = new GameObject(typeof(CameraCtrl).Name).AddComponent<CameraCtrl>();
			}
			return _instance;
		}
	}

	public void Initialize() {
		_manager = CameraManager.GetInstance;
		_data = GameData.GetInstance;

		_manager.Initialize();
		_view = null;
		if (!_data.IsCamera2D) {
			_view = _manager.GetCamera3D().GetComponent<CameraView>();
			if (_view != null) {
				_view.SetTarget(SnakeCtrl.GetInstance.GetBodies().First().View.transform);
			}
		} else {
			SetCamera2DSize();
		}
	}

	public void Destroy() {
		if (_view != null) {
			_view.Destroy();
		}
		CameraManager.GetInstance.Destroy();
		_instance = null;
		Destroy(gameObject);
	}

	// === Private ====================================================================================================
	private static CameraCtrl _instance;
	private CameraManager _manager;
	private GameData _data;
	private CameraView _view;
	private Vector2 _screenSize;

	private void SetCamera2DSize() {
		_screenSize = new Vector2(Screen.width, Screen.height);
		var cam = _manager.GetCamera2D();
		const int height = 20;
		const float сellHalf = Constants.CELL_LENGTH_HALF;
		var pos = new Vector3(_data.FieldSize.x * .5f - сellHalf, height, _data.FieldSize.y * .5f - сellHalf);
		cam.transform.position = pos;

		const int borders = 2;
		var cellX = _screenSize.x / (_data.FieldSize.x + borders);
		var cellY = _screenSize.y / (_data.FieldSize.y + borders);
		if (cellX < cellY) {
			var screenRest = _screenSize.y - _screenSize.x;
			var offset = screenRest * .5f / cellX;
			cam.camera.orthographicSize = offset + (_data.FieldSize.x + borders) * .5f;
		} else {
			cam.camera.orthographicSize = (_data.FieldSize.y + borders) * .5f;
		}
	}
}
