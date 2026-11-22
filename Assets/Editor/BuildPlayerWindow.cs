using UnityEngine;
using UnityEditor;
using System.IO;

public class BuildPlayerWindow : MonoBehaviour
{
    [MenuItem("Build/Build Android")]
    public static void BuildAndroid()
    {
        // Путь для сохранения сборки
        string path = Path.Combine(Application.dataPath, "../Builds/BananaToss.apk");
        
        // Настройки сборки
        BuildPlayerOptions options = new BuildPlayerOptions();
        options.scenes = new string[] 
        { 
            "Assets/Scenes/MainScene.unity",
            "Assets/Scenes/DemoScene.unity"
        };
        options.locationPathName = path;
        options.target = BuildTarget.Android;
        options.options = BuildOptions.None;
        
        // Сборка
        BuildPipeline.BuildPlayer(options);
        
        Debug.Log("Build complete: " + path);
    }
}