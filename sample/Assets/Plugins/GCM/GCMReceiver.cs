using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// GCM receiver.
/// </summary>
public class GCMReceiver : MonoBehaviour {
	
	public static System.Action<string> _onError = null;
	public static System.Action<Dictionary<string, object>> _onMessage = null;
	public static System.Action<string> _onRegistered = null;
	public static System.Action<string> _onUnregistered = null;
	
	public static System.Action<int> _onDeleteMessages = null;
	
	void Awake() {
		// This receiver must not be destroyed on loading level
		DontDestroyOnLoad(transform.gameObject);
	}
	
	void OnError (string errorId) {
		Debug.Log ("Error: " + errorId);
		if (_onError != null) {
			_onError (errorId);
		}
	}
	
	void OnMessage (string message) {
		Debug.Log ("Message: " + message);
		if (_onMessage != null) {
			Dictionary<string, object> table = MiniJSON.Json.Deserialize (message) as Dictionary<string, object>;
			_onMessage (table);
		}
	}
	
	void OnRegistered (string registrationId) {
		Debug.Log ("Registered: " + registrationId);
		if (_onRegistered != null) {
			_onRegistered (registrationId);
		}
	}
	
	void OnUnregistered (string registrationId) {
		Debug.Log ("Unregistered: " + registrationId);
		if (_onUnregistered != null) {
			_onUnregistered (registrationId);
		}
	}
	
	void OnDeleteMessages (string total) {
		Debug.Log ("DeleteMessages: " + total);
		if (_onDeleteMessages != null) {
			int totalCnt = System.Convert.ToInt32 (total);
			_onDeleteMessages (totalCnt);
		}
	}
}
