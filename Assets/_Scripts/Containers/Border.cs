using UnityEngine;

public class Border : IFieldElement {
	// === Public =====================================================================================================
	#region IFieldElement
	public FieldElementType FieldElementType { get { return FieldElementType.Border; } }
	public Vector2 Position { get; set; }
	public void DoCollision() {
		GameCtrl.GetInstance.Reset();
	}
	#endregion
}