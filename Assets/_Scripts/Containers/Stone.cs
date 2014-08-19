using UnityEngine;

public class Stone : IFieldElement {
	// === Public =====================================================================================================
	#region IFieldElement
	public FieldElementType FieldElementType { get { return FieldElementType.Stone; } }
	public Vector2 Position { get; private set; }
	public void DoCollision() {
		GameCtrl.GetInstance.Reset();
	}
	#endregion

	public StoneView View { get; private set; }

	public Stone(StoneView view, Vector2 position) {
		View = view;
		Position = position;
	}
}