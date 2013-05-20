using UnityEngine;
using UnityEditor;
using System.Collections;
using System.IO;
using System.Text.RegularExpressions;

/// <summary>
/// Exporter.
/// </summary>
public class Exporter : MonoBehaviour {
	
	private const string DEFAULT_PACKAGE = "INPUT_YOUR_BUNDLE_IDENTIFIER";
	
	[MenuItem("GCM-Dev/Export")]
	public static void Export () {
		
		Debug.Log ("*** Updating AndroidManifest ***");
		ManifestEditor.UpdateManifest (DEFAULT_PACKAGE);
		
		Debug.Log ("*** Updating MainScene.cs ***");
		ReplaceSenderId ();
		
		Debug.Log ("*** Exporting package ***");
		string[] pathNames = {
			"Assets/Plugins",
			"Assets/GCM-Sample",
			"Assets/readme.txt"
		};
		string dstFileName = "../Android-GCM-Plugin.unitypackage";
		AssetDatabase.ExportPackage (pathNames, dstFileName, ExportPackageOptions.Recurse);
		
		EditorUtility.DisplayDialog ("Android-GCM-Plugin", "Exported!", "OK");
		
		EditorApplication.Exit (0);
	}
	
	/// <summary>
	/// Replaces the sender identifier.
	/// </summary>
	static void ReplaceSenderId () {
		
		const string SCENE_PATH = "Assets/GCM-Sample/MainScene.cs";
		
		// Read text
		StreamReader sr = new StreamReader (SCENE_PATH);
		string body = sr.ReadToEnd ();
		sr.Close ();
		
		// Replace text
		Regex reg1 = new Regex ("SENDER_IDS = {(.*)};");
		body = reg1.Replace (body, "SENDER_IDS = {\"INPUT_YOUR_PROJECT_NUMBER\"};");
		
		// Write text
		StreamWriter sw = new StreamWriter (SCENE_PATH);
		sw.Write (body);
		sw.Flush ();
		sw.Close ();
	}
}
