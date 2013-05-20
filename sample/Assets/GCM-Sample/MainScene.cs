using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class MainScene : MonoBehaviour {
	
	// Project Number on Google API Console
	private string[] SENDER_IDS = {"367705816737", "396557365576"};
	
	private string _text = "(null)";
	
	// Use this for initialization
	void Start () {
		
		// Create receiver game object
		GCM.Initialize ();
		
		// Set callbacks
		GCM.SetErrorCallback ((string errorId) => {
			Debug.Log ("Error!!! " + errorId);
			GCM.ShowToast ("Error!!!");
			_text = "Error: " + errorId;
		});
		
		GCM.SetMessageCallback ((Dictionary<string, object> table) => {
			Debug.Log ("Message!!!");
			GCM.ShowToast ("Message!!!");
			_text = "Message: " + System.Environment.NewLine;
			foreach (var key in  table.Keys) {
				_text += key + "=" + table[key] + System.Environment.NewLine;
			}
		});
		
		GCM.SetRegisteredCallback ((string registrationId) => {
			Debug.Log ("Registered!!! " + registrationId);
			GCM.ShowToast ("Registered!!!");
			_text = "Register: " + registrationId; 
		});
		
		GCM.SetUnregisteredCallback ((string registrationId) => {
			Debug.Log ("Unregistered!!! " + registrationId);
			GCM.ShowToast ("Unregistered!!!");
			_text = "Unregister: " + registrationId;
		});
		
		GCM.SetDeleteMessagesCallback ((int total) => {
			Debug.Log ("DeleteMessages!!! " + total);
			GCM.ShowToast ("DeleteMessaged!!!");
			_text = "DeleteMessages: " + total;
		});
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI () {
		float x = 50.0f;
		float y = 50.0f;
		float width = Screen.width / 2 - x - 25.0f;
		float height = 100.0f;
		float margin = 25.0f;
		
		if (GUI.Button (new Rect(x, y, width, height), "Register")) {
			GCM.Register (SENDER_IDS);
		}
		
		x += width + margin * 2;
		
		if (GUI.Button (new Rect(x, y, width, height), "Unregister")) {
			GCM.Unregister ();
		}
		
		x -= width + margin * 2;
		y += height + margin;
		
		if (GUI.Button (new Rect(x, y, width, height), "IsRegistered")) {
			_text = "IsRegistered = " + GCM.IsRegistered ();
		}
		
		x += width + margin * 2;
		
		if (GUI.Button (new Rect(x, y, width, height), "GetRegisterationId")) {
			_text = "GetRegistrationId = " + GCM.GetRegistrationId ();
		}
		
		x -= width + margin * 2;
		y += height + margin;
		
		if (GUI.Button (new Rect(x, y, width, height), "IsRegisteredOnServer")) {
			_text = "IsRegisteredOnServer = " + GCM.IsRegisteredOnServer ();
		}
		
		x += width + margin * 2;
		
		if (GUI.Button (new Rect(x, y, width, height), "SetRegisteredOnServer")) {
			GCM.SetRegisteredOnServer (true);
			_text = "SetRegisteredOnServer";
		}
		
		x -= width + margin * 2;
		y += height + margin;
		
		if (GUI.Button (new Rect(x, y, width, height), "GetRegisterOnServerLifespan")) {
			_text = "GetRegisterOnServerLifespan = " + GCM.GetRegisterOnServerLifespan ();
		}
		
		x += width + margin * 2;
		
		if (GUI.Button (new Rect(x, y, width, height), "SetRegisterOnServerLifespan")) {
			GCM.SetRegisterOnServerLifespan (30 * 1000);	// 30 sec
			_text = "SetRegisterOnServerLifespan";
		}
		
		x -= width + margin * 2;
		y += height + margin;
		
		GUI.TextArea (new Rect(x, y, width * 2 + margin * 2, height), _text);
		
		y += height + margin;
		
		if (GUI.Button (new Rect (x, y, width, height), "Next")) {
			Application.LoadLevel ("SubScene");
		}
	}
}
