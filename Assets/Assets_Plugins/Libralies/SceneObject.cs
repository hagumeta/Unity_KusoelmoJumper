using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

[System.Serializable]
public class SceneObject
{
    [SerializeField]
    private string m_SceneName;
    [SerializeField]
    private string m_path;

    public static implicit operator string(SceneObject sceneObject)
    {
        return sceneObject.m_SceneName;
    }

    public static implicit operator SceneObject(string sceneName)
    {
        return new SceneObject() { m_SceneName = sceneName };
    }

    public static implicit operator SceneObject(Scene scene)
    {
        return new SceneObject() { m_SceneName = scene.name };
    }

    public string Path
    {
        get => this.m_path;
    }

    public static implicit operator int(SceneObject sceneObject)
    {
        return  SceneUtility.GetBuildIndexByScenePath(sceneObject.Path);
    }
}

#if UNITY_EDITOR
[CustomPropertyDrawer(typeof(SceneObject))]
public class SceneObjectEditor : PropertyDrawer
{
    protected SceneAsset GetSceneObject(string sceneObjectName)
    {
        if (string.IsNullOrEmpty(sceneObjectName))
            return null;

        for (int i = 0; i < EditorBuildSettings.scenes.Length; i++)
        {
            EditorBuildSettingsScene scene = EditorBuildSettings.scenes[i];
            if (scene.path.IndexOf(sceneObjectName) != -1)
            {
                return AssetDatabase.LoadAssetAtPath(scene.path, typeof(SceneAsset)) as SceneAsset;
            }
        }

        Debug.Log("Scene [" + sceneObjectName + "] cannot be used. Add this scene to the 'Scenes in the Build' in the build settings.");
        return null;
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        var sceneObj = GetSceneObject(property.FindPropertyRelative("m_SceneName").stringValue);
        var newScene = EditorGUI.ObjectField(position, label, sceneObj, typeof(SceneAsset), false);
        if (newScene == null)
        {
            var prop = property.FindPropertyRelative("m_SceneName");
            var prop2 = property.FindPropertyRelative("m_path");
            prop.stringValue = "";
            prop2.stringValue = "";
        }
        else
        {
            if (newScene.name != property.FindPropertyRelative("m_SceneName").stringValue)
            {
                var scnObj = GetSceneObject(newScene.name);
                if (scnObj == null)
                {
                    Debug.LogWarning("The scene " + newScene.name + " cannot be used. To use this scene add it to the build settings for the project.");
                }
                else
                {
                    var prop = property.FindPropertyRelative("m_SceneName");
                    var prop2 = property.FindPropertyRelative("m_path");
                    prop.stringValue = newScene.name;
                    prop2.stringValue = AssetDatabase.GetAssetPath(newScene);
                }
            }
        }
    }
}
#endif