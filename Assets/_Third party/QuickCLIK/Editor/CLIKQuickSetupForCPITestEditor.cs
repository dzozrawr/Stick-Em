using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using System.Linq;

namespace CrazyLabsHubs.Editor
{
    public class CLIKQuickSetupForCPITestEditor : MonoBehaviour
    {
        // Start is called before the first frame update
        [MenuItem("CLIK/Quick setup for CPI test")]
        static void QuickSetup()
        {

            //Create the empty scene with tt plugin
            var scenePath = @"Assets/QuickSetupScene.unity";
            var scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);

            //Create a GameObject that will contain loader script for ttplugins
            GameObject go = new GameObject();
            go.name = "QuickSetupManager";
            go.AddComponent<QuickLoadCLIK>();

            //Add component here for the activating the tt plugins
            EditorSceneManager.SaveScene(scene, scenePath);

            //Add created Scene to the build settings
            var existingScenes = EditorBuildSettings.scenes;
            var withoutDuplicates = existingScenes.GroupBy(x => x.path).Select(y => y.First()).ToList();

            var alreadyContainsScene = withoutDuplicates.Any(x => string.Equals(x.path, scenePath));

            if (alreadyContainsScene)
            {
                var sceneToRemove = withoutDuplicates.SingleOrDefault(x => string.Equals(x.path, scenePath));
                if (sceneToRemove != null)
                {
                    withoutDuplicates.Remove(sceneToRemove);
                }
            }

            List<EditorBuildSettingsScene> newScenes = new List<EditorBuildSettingsScene>(withoutDuplicates.Count + 1);
            newScenes.Add(new EditorBuildSettingsScene(scenePath, true));
            for (int i = 0; i < withoutDuplicates.Count; i++)
            {
                newScenes.Add(withoutDuplicates[i]);
            }
            EditorBuildSettings.scenes = newScenes.ToArray();

            //Change the unity build settings for android
            //Unity supported versions as per https://sites.google.com/tabtale.com/clhelpcenter/clik-plugin
            //2019.2.17, 2019.3.15, 2019.4.28, 2020.1.14 

#if UNITY_ANDROID

            PlayerSettings.SetScriptingBackend(BuildTargetGroup.Android, ScriptingImplementation.IL2CPP);
            PlayerSettings.SetManagedStrippingLevel(BuildTargetGroup.Android, 0);
            PlayerSettings.stripEngineCode = false;

            PlayerSettings.Android.minSdkVersion = AndroidSdkVersions.AndroidApiLevel23;
            PlayerSettings.Android.targetArchitectures = AndroidArchitecture.All;

#if UNITY_2020_1_OR_NEWER

            PlayerSettings.Android.minifyWithR8 = false;
            PlayerSettings.Android.minifyDebug = false;

            PlayerSettings.Android.targetSdkVersion = AndroidSdkVersions.AndroidApiLevel30;
#endif

#if UNITY_2019_4
            PlayerSettings.Android.targetSdkVersion = AndroidSdkVersions.AndroidApiLevel30;
#endif

#if UNITY_2019_2 || UNITY_2019_3
            PlayerSettings.Android.targetSdkVersion = AndroidSdkVersions.AndroidApiLevel28;
#endif

#endif
        }
    }
}