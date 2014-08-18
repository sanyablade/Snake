using System;
using UnityEngine;

public class InputHelper : MonoBehaviour {
	// === Unity ======================================================================================================
	private void Update() {
		var ver = (int)Input.GetAxisRaw("Vertical");
		var hor = (int)Input.GetAxisRaw("Horizontal");

		if (!_can && ver == 0 && hor == 0) {
			_can = true;
		}

		_direction = DirectionSnake.NONE;
		if (// multikeys?
			(ver != 0 && hor != 0) ||
			// no keys
			(ver == 0 && hor == 0)) {
			return;
		}
		if (_can) {
			_can = false;
			if (ver != 0) {
				_direction = ver > 0 ? DirectionSnake.UP : DirectionSnake.DOWN;
			} else {
				_direction = hor > 0 ? DirectionSnake.RIGHT : DirectionSnake.LEFT;
			}
			_ctrl.SetNextDirection(_direction);
		}
	}

	// === Public =====================================================================================================
	public static InputHelper GetInstance {
		get {
			if (_instance == null) {
				_instance = new GameObject(typeof(InputHelper).Name).AddComponent<InputHelper>();
			}
			return _instance;
		}
	}

	public void Initialize() {
		_ctrl = SnakeCtrl.GetInstance;
	}

	public void Destroy() {
		_instance = null;
		Destroy(gameObject);
	}

	// === Private ====================================================================================================
	private static InputHelper _instance;
	private SnakeCtrl _ctrl;
	private DirectionSnake _direction;
	private bool _can = true;
}

