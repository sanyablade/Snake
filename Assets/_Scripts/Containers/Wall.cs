using UnityEngine;

public class Wall : IFieldElement {
	// === Public =====================================================================================================
	#region IFieldElement
	public FieldElementType FieldElementType { get { return FieldElementType.Wall; } }
	public Vector2 Position { get; private set; }
	public void DoCollision() {
		GameCtrl.GetInstance.Reset();
	}
	#endregion

	public WallView View { get; private set; }

	public Wall(WallView view, Vector2 position) {
		View = view;
		Position = position;
	}
}