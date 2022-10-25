using UnityEditor;
using UnityEngine;
using System.IO;
public class MultiUnitySettingWindow : EditorWindow
{
	string mPath = "../MultiUnity/UnityProjectServer";
	[MenuItem("Assets/MultiUnitySettingWindow")]
	static void Open()
	{
		EditorWindow.GetWindow<MultiUnitySettingWindow>(typeof(MultiUnitySettingWindow).Name);
	}
	void OnGUI()
	{
		EditorGUILayout.BeginVertical();
		mPath = EditorGUILayout.TextField(mPath);
		var linkDir = Path.GetFullPath(mPath);
		var prjDir = Path.GetDirectoryName(Application.dataPath);
		EditorGUILayout.LabelField($"prj {prjDir}");
		EditorGUILayout.LabelField($"link {linkDir}");
		if(GUILayout.Button("generate"))
		{
			var dirs = new[] { "Assets", "ProjectSettings", "Packages" };
			foreach(var dir in dirs)
			{
				var prjPath = Path.Join(prjDir, dir);
				var linkPath = Path.Join(linkDir, dir);
				Directory.CreateDirectory(linkDir);
				var procInfo = new System.Diagnostics.ProcessStartInfo("cmd.exe", $"/c mklink /j \"{linkPath}\" \"{prjPath}\"");
				var proc = System.Diagnostics.Process.Start(procInfo);
				proc.WaitForExit();
				proc.Close();
			}
		}
		EditorGUILayout.EndVertical();
	}
}
