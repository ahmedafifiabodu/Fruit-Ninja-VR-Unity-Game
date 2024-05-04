using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(FruitPooler))]
public class FruitPoolingEditor : Editor
{
    public override void OnInspectorGUI()
    {
        FruitPooler fruitPooler = (FruitPooler)target;

        fruitPooler.poolSize = EditorGUILayout.IntField("Pool Size", fruitPooler.poolSize);
        fruitPooler.bombSize = EditorGUILayout.IntField("Bomb Size", fruitPooler.bombSize);
        fruitPooler.fruitParent = (GameObject)EditorGUILayout.ObjectField("Fruit Parent", fruitPooler.fruitParent, typeof(GameObject), true);

        SerializedProperty fruitsProperty = serializedObject.FindProperty("fruits");
        EditorGUILayout.PropertyField(fruitsProperty, true);

        if (fruitPooler.fruits.Length > 0 && fruitPooler.fruits[0].prefab != null)
        {
            if (fruitPooler.fruits[0].prefab.layer == LayerMask.NameToLayer("Bomb"))
                EditorGUILayout.HelpBox("The first fruit is a Bomb.", MessageType.Info);
            else
                EditorGUILayout.HelpBox("The first fruit is not a Bomb.", MessageType.Warning);
        }

        serializedObject.ApplyModifiedProperties();
    }
}