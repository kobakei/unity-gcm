using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class SubScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI () {
		
		float x = 50.0f;
		float y = 50.0f;
		float width = Screen.width - x * 2;
		float height = 100.0f;
		float margin = 25.0f;
		
		GUI.Label (new Rect(x, y, width, height), "GCM can be received even when Application.LoadLevel is called");
		
		y += margin;
		
		if (GUI.Button (new Rect (x, y, width, height), "Back")) {
			Application.LoadLevel ("MainScene");
		}
	}
}
