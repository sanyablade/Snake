using UnityEngine;

public class CameraView : MonoBehaviour {
	// === Unity ======================================================================================================
	private void Awake() {
		_transform = transform;
	}

	private void Update() {
		if (_targetTransform == null) {
			return;
		}
		_transform.LookAt(_targetTransform);
		var virtualTarget = _targetTransform.position + _targetTransform.up * 1f - _targetTransform.forward * 4f;
		_transform.position = Vector3.Lerp(_transform.position, virtualTarget, GameData.GetInstance.SnakeSpeed * Time.deltaTime);
	}

	// === Public =====================================================================================================
	public void SetTarget(Transform targetTransform) {
		_targetTransform = targetTransform;
	}

	public void Destroy() {
		Destroy(gameObject);
	}

	// === Private ====================================================================================================
	private Transform _transform;
	private Transform _targetTransform;
}
