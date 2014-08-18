using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using System.Collections;

public class PanelCtrl : MonoBehaviour {
	// === Public =====================================================================================================
	public void ActivatePanel() {
		NGUITools.SetActive(gameObject, true);
	}

	public void DeactivatePanel() {
		NGUITools.SetActive(gameObject, false);
	}

	public void Destroy() {
		Destroy(gameObject);
	}
}
