using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugText : MonoBehaviour {

    [SerializeField]
    private Text m_TextUI = null;

    private int i = 0;
    
    private void Start() {
        m_TextUI = GetComponent<Text>();
        m_TextUI.color = new Color(255f / 255f, 255f / 255f, 0f);
    }

    private void OnEnable() {
        Application.logMessageReceived += HandleLog;
    }

    private void OnDisable() {
        Application.logMessageReceived -= HandleLog;
    }

    void HandleLog(string logString, string stackTrace, LogType type) {
        i += 1;
        m_TextUI.text += logString + System.Environment.NewLine;
    }
}
