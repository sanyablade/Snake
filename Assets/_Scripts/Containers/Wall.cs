using UnityEngine;

public class Wall : IFieldElement {
	// === Public =====================================================================================================
	#region IFieldElement
	public FieldElementType FieldElementType { get { return FieldElementType.Wall; } }
	public Vector2 Position { get; set; }
	public void DoCollision() {
		GameCtrl.GetInstance.Reset();
	}
	#endregion

	public WallView View { get; set; }
}