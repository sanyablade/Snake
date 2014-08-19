using UnityEngine;

public class BodyView : MonoBehaviour {
	// === Unity ======================================================================================================
	private void Awake() {
		_transform = transform;
	}

	private void Update() {
		_moveTimeRest -= Time.deltaTime;
		if (_body == null || _body.IsPause) {
			return;
		}
		_transform.position += _transform.forward * GameData.GetInstance.SnakeSpeed * Time.deltaTime;
	}

	// === Public =====================================================================================================
	public void SetBody(Body body) {
		_body = body;
	}

	public void RefreshDirection() {
		var offset = -_moveTimeRest;
		NormalizePosition();
		RefreshRotate();
		RefreshPosition(offset);
		UpdatePoint();
		_moveTimeRest -= offset;
	}

	public void Destroy() {
		Destroy(gameObject);
	}

	// === Private ====================================================================================================
	private Transform _transform;
	private Body _body;
	private float _moveTimeRest;

	private void UpdatePoint() {
		var pos = new Vector2(_body.Position.x, _body.Position.y);
		var moveVector = _body.NextPosition - pos;
		_moveTimeRest = moveVector.magnitude / GameData.GetInstance.SnakeSpeed;
	}

	private void NormalizePosition() {
		_transform.position = new Vector3(_body.Position.x, 0, _body.Position.y);
	}

	private void RefreshRotate() {
		_transform.LookAt(new Vector3(_body.NextPosition.x, 0, _body.NextPosition.y));
	}

	private void RefreshPosition(float deltaPosition) {
		_transform.position += _transform.forward * deltaPosition;
	}
}

