using UnityEngine;

public interface IFieldElement {
	FieldElementType FieldElementType { get; }
	Vector2 Position { get; set; }
	void DoCollision();
}