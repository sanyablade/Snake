using UnityEngine;

public class FoodView : MonoBehaviour {
	// === Unity ======================================================================================================
	private void Awake() {
		_transform = transform;
	}
	private void Update() {
		_transform.Rotate(Vector3.up, Constants.View.ROTATION_SPEED * Time.deltaTime);
	}

	// === Public =====================================================================================================
	public void Destroy() {
		Destroy(gameObject);
	}

	// === Private ====================================================================================================
	private Transform _transform;
}
