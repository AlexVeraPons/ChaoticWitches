using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR
public static class AddToChildren
{
    [MenuItem("Window/Addtochildre")]
        private static void AddEventClickerScriptToChildren()
        {
            GameObject[] selection = Selection.gameObjects;
            foreach (GameObject go in selection)
            {
                Transform child = go.transform.GetChild(0);
                if (child.GetComponent<EventClicker>() == null)
                {
                    child.gameObject.AddComponent<EventClicker>();
                }
            }
        }
}
#endif
