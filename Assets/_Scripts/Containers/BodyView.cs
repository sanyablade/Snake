using UnityEngine;

public class BodyView : MonoBehaviour {
	// === Unity ======================================================================================================
	private void Awake() {
		_transform = transform;
	}

	private void Update() {
		if (_flag) {
			return;
		}
		_transform.position += _transform.forward * GameData.GetInstance.SnakeSpeed * Time.deltaTime;
	}

	// === Public =====================================================================================================
	public void RefreshDirection(DirectionSnake direction) {
		if (_direction.Equals(direction)) {
			return;
		}
		_direction = direction;
	}

	public void Destroy() {
		Destroy(gameObject);
	}

	// === Private ====================================================================================================
	private Transform _transform;
	private DirectionSnake _direction;
	private bool _flag = true;
}

