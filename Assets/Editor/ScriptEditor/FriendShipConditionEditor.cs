using UnityEngine;
#if UNITY_EDITOR 
using UnityEditor;
#endif 

[CustomEditor(typeof(FriendShipCondition))]
public class FriendShipConditionEditor : EditorWithSubEditors<ConditionEditor, Condition> {

	public SerializeField condition;

	private FriendShipCondition friendShipCondition;

	private SerializedProperty descriptionProperty;
	private SerializedProperty requireFriendlyProperty;
	private SerializedProperty addConditionProperty;

	private const string descriptionPropertyName = "description";
	private const string requireFriendlyPropertyName = "requireFriendly";
	private const string addConditionPropertyName = "addCondition";

	private void OnEnable()
	{
		friendShipCondition = (FriendShipCondition)target;

		if (target == null)
		{
			DestroyImmediate (this);
			return;
		}

		descriptionProperty = serializedObject.FindProperty (descriptionPropertyName);
		requireFriendlyProperty = serializedObject.FindProperty (requireFriendlyPropertyName);
		addConditionProperty = serializedObject.FindProperty (addConditionPropertyName);

		CheckAndCreateSubEditors (friendShipCondition.addCondition);

	}

	private void OnDisable ()
	{
		CleanupEditors ();
	}

	protected override void SubEditorSetup (ConditionEditor editor)
	{
		editor.editorType = ConditionEditor.EditorType.ConditionCollection;
		editor.conditionsProperty = addConditionProperty;
	}

	public override void OnInspectorGUI(){
		EditorGUILayout.Space();

		EditorGUILayout.PropertyField(descriptionProperty);

		EditorGUILayout.Space();

		float space = EditorGUIUtility.currentViewWidth / 3f;

		EditorGUILayout.BeginHorizontal();
		EditorGUILayout.LabelField("Condition", GUILayout.Width(space));
		EditorGUILayout.LabelField("Satisfied?", GUILayout.Width(space));
		EditorGUILayout.LabelField("Add/Remove", GUILayout.Width(space));
		EditorGUILayout.EndHorizontal();

		EditorGUILayout.BeginVertical(GUI.skin.box);
		for (int i = 0; i < subEditors.Length; i++)
		{
			subEditors[i].OnInspectorGUI();
		}
		EditorGUILayout.EndHorizontal();

		EditorGUILayout.BeginHorizontal();
		GUILayout.FlexibleSpace ();
		if (GUILayout.Button("+", GUILayout.Width(125f)))
		{
			Condition newCondition = ConditionEditor.CreateCondition();
			addConditionProperty.AddToObjectArray(newCondition);
		}
		EditorGUILayout.EndHorizontal();
	}

	private void ExpandedGUI(){

	}
}
