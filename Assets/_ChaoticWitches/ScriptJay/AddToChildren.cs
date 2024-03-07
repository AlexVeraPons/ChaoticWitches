using UnityEditor;
using UnityEngine;

public static class AddToChildren
{
    [MenuItem("Window/Addtochildre")]
        private static void AddEventClickerScriptToChildren()
        {
            GameObject[] selection = Selection.gameObjects;
            foreach (GameObject go in selection)
            {
                var child = go.transform.GetChild(0);
                if (child.GetComponent<EventClicker>() == null)
                {
                    child.gameObject.AddComponent<EventClicker>();
                }
            }
        }
}
