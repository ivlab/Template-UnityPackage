using UnityEditor;
using UnityEngine;

/// <summary>
/// Demonstrates how to add a custom sub-menu to Unity's GameObject menu and use it to
/// instatiate a prefab in the scene.
/// </summary>
public class TemplateGameObjectMenu : MonoBehaviour
{
    [MenuItem("GameObject/Template/ExamplePrefab", false, 10)]
    static void CreateMinVRRoot(MenuCommand command)
    {
        InstatiatePrefabFromAsset(command, "t:Prefab ExamplePrefab");
    }

    // additional menu items can be added here..



    static void InstatiatePrefabFromAsset(MenuCommand command, string searchStr)
    {
        Object prefabAsset = null;
        string[] guids = AssetDatabase.FindAssets(searchStr);
        if (guids.Length > 0)
        {
            string fullPath = AssetDatabase.GUIDToAssetPath(guids[0]);
            prefabAsset = AssetDatabase.LoadAssetAtPath<Object>(fullPath);
        }

        Debug.Assert(prefabAsset != null, "Cannot find requested prefab in the AssetDatabase using search string '" + searchStr + "'.");
        GameObject go = (GameObject)PrefabUtility.InstantiatePrefab(prefabAsset);
        // Ensure it gets reparented if this was a context click (otherwise does nothing)
        GameObjectUtility.SetParentAndAlign(go, command.context as GameObject);
        // Register the creation in the undo system
        Undo.RegisterCreatedObjectUndo(go, "Create " + go.name);
        Selection.activeObject = go;
    }
}
