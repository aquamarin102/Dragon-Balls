using UnityEditor;
using UnityEngine;

public class MyWindow : EditorWindow
{
    public static GameObject ObjectInstantiate;
    public string NameObject = "...";
    public bool _randomColor = true;
    public int _countObject = 1;
    public float _radius = 1;

    private void OnGUI()
    {
        GUILayout.Label("Options", EditorStyles.boldLabel);
        ObjectInstantiate =
            EditorGUILayout.ObjectField("Object to insert", ObjectInstantiate, typeof(GameObject), true) as GameObject;
        NameObject = EditorGUILayout.TextField("Name object", NameObject);
        _randomColor = EditorGUILayout.Toggle("Random color", _randomColor);
        _countObject = EditorGUILayout.IntSlider("Number of objects", _countObject, 1, 20);
        _radius = EditorGUILayout.Slider("Radius of objects", _radius, 1, 20);
        var button = GUILayout.Button("Create objects");

        if (button)
        {
            if (ObjectInstantiate)
            {
                GameObject root = new GameObject("Root");

                for (int i = 0; i < _countObject; i++)
                {
                    float angle = i * Mathf.PI * 2 / _countObject;
                    Vector3 pos = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * _radius;
                    GameObject temp = Instantiate(ObjectInstantiate, pos, Quaternion.identity);
                    temp.name = NameObject + "(" + i + ")";
                    temp.transform.parent = root.transform;
                    var tempRenderer = temp.GetComponent<Renderer>();
                    if (tempRenderer && _randomColor)
                    {
                        tempRenderer.material.color = Random.ColorHSV();
                    }

                }
            }
        }
        
    }
}
