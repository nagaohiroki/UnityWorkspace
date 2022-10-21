using System.IO;
using UnityEditor;
using Unity.CodeEditor;
public class CodeSettingWindow : EditorWindow
{
	string mGUID;
	public const string vsPath = "VisualStudioPath";
	[MenuItem("Assets/CodeSettingWindow")]
	static void Open()
	{
		EditorWindow.GetWindow<CodeSettingWindow>(typeof(CodeSettingWindow).Name);
	}
	void OnGUI()
	{
		EditorGUILayout.LabelField(vsPath);
		EditorPrefs.SetString(vsPath,  EditorGUILayout.TextField(EditorPrefs.GetString(vsPath)));
	}
}
public class SyncSolution : AssetPostprocessor
{
	[MenuItem("Assets/Sync %#F5")]
	static void Sync()
	{
		var myEditor = EditorPrefs.GetString("kScriptsDefaultApp");
		var vsPath = EditorPrefs.GetString(CodeSettingWindow.vsPath);
		if(string.IsNullOrEmpty(vsPath) || myEditor == vsPath)
		{
			return;
		}
		CodeEditor.SetExternalScriptEditor(vsPath);
		CodeEditor.Editor.CurrentCodeEditor.SyncAll();
		CodeEditor.SetExternalScriptEditor(myEditor);
	}
	static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
	{
		if(IsCsFile(importedAssets) || IsCsFile(deletedAssets) || IsCsFile(movedAssets))
		{
			SyncSolution.Sync();
		}
	}
	static bool IsCsFile(string[] path)
	{
		foreach(string str in path)
		{
			if(Path.GetExtension(str) == ".cs")
			{
				return true;
			}
		}
		return false;
	}
}