using System;
using UnityEngine;
using System.Collections;

public class GUIManager : MonoBehaviour {
	// === Unity ======================================================================================================
	public PanelCtrl InfoPanel;
	public PanelCtrl GameOverPanel;

	public void Awake() {
		GetInstance = this;

		if (InfoPanel == null) {
			throw new NullReferenceException("InfoPanel");
		}
		if (GameOverPanel == null) {
			throw new NullReferenceException("GameOverPanel");
		}
	}

	// === Public =====================================================================================================
	public static GUIManager GetInstance;

	public void ShowGameOverPanel() {
		GameOverPanel.ActivatePanel();
	}

	public void HideGameOverPanel() {
		GameOverPanel.DeactivatePanel();
	}

	public void ShowInfoPanel() {
		InfoPanel.ActivatePanel();
	}

	public void HideInfoPanel() {
		InfoPanel.DeactivatePanel();
	}
}
