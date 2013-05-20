using UnityEngine;
using UnityEditor;
using System.Collections;
using System.IO;
using System.Text.RegularExpressions;

/// <summary>
/// Manifest editor.
/// </summary>
public class ManifestEditor : MonoBehaviour {
	
	private const string TITLE = "Android GCM Plugin";
	
	private const string MANIFEST_PATH = "Assets/Plugins/Android/AndroidManifest.xml";
	
	public static void UpdateManifest () {
		string packageName = PlayerSettings.bundleIdentifier;
		Debug.Log ("Bundle identifier (package name): " + packageName);
		UpdateManifest (packageName);
		EditorUtility.DisplayDialog (TITLE, "Updated Assets/Plugins/Android/AndroidManifest.xml", "OK");
	}
	
	public static void UpdateManifest (string packageName) {
		// Read text
		StreamReader sr = new StreamReader (MANIFEST_PATH);
		string body = sr.ReadToEnd ();
		sr.Close ();
		
		// Replace text
		Regex reg1 = new Regex ("\"(.*).permission.C2D_MESSAGE\"");
		body = reg1.Replace (body, "\"" + packageName + ".permission.C2D_MESSAGE\"");
		Regex reg2 = new Regex ("(?!<category android:name=\"android.intent.category.LAUNCHER\" />)<category android:name=\"(.*)\" />");
		body = reg2.Replace (body, "<category android:name=\"" + packageName + "\" />");
		
		// Write text
		StreamWriter sw = new StreamWriter (MANIFEST_PATH);
		sw.Write (body);
		sw.Flush ();
		sw.Close ();
	}
	
}
