using UnityEngine;

public class SnakeBodyView : MonoBehaviour {
	// === Public =====================================================================================================
	public void Initialize(Vector2 startPoint, Vector2 endPoint) {
		_transform = transform;
		_transform.position = new Vector3(startPoint.x, 0, startPoint.y);
		SetNextPoint(endPoint);
	}

	public void SetNextPoint(Vector2 position) {
		_transform.LookAt(new Vector3(position.x, 0, position.y));
	}

	public void RefreshPosition(float deltaPosition) {
		_transform.position += _transform.forward * deltaPosition;
	}

	public void NormalizePosition(Vector2 endPoint) {
		_transform.position = new Vector3(endPoint.x, 0, endPoint.y);
	}

	public void Destroy() {
		Destroy(gameObject);
	}

	// === Private ====================================================================================================
	private Transform _transform;
}

