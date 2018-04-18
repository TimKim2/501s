using UnityEngine;
#if UNITY_EDITOR 
using UnityEditor;
#endif 

[CustomEditor(typeof(FriendShipCondition))]
public class FriendShipConditionEditor : EditorWithSubEditors<ConditionEditor, Condition> {

	public SerializedProperty friendShipConditionProperty;

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
			Debug.Log ("Destroy");
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

	public override void OnInspectorGUI ()
	{
		serializedObject.Update ();

		CheckAndCreateSubEditors(friendShipCondition.addCondition);


		//

		EditorGUILayout.BeginVertical(GUI.skin.box);
		EditorGUI.indentLevel++;


		EditorGUILayout.BeginHorizontal();

		descriptionProperty.isExpanded = EditorGUILayout.Foldout(descriptionProperty.isExpanded, descriptionProperty.stringValue);
		//requireFriendlyProperty.isExpanded = EditorGUILayout.Foldout (requireFriendlyProperty.isExpanded, requireFriendlyProperty.intValue);

		if (GUILayout.Button("Remove Collection", GUILayout.Width(125f)))
		{
			friendShipConditionProperty.RemoveFromObjectArray (friendShipCondition);
		}

		EditorGUILayout.EndHorizontal();

		if (descriptionProperty.isExpanded)
		{
			ExpandedGUI ();
		}

		EditorGUI.indentLevel--;
		EditorGUILayout.EndVertical();

		serializedObject.ApplyModifiedProperties();
	}


	private void ExpandedGUI ()
	{
		EditorGUILayout.Space();

		EditorGUILayout.PropertyField(descriptionProperty);
		EditorGUILayout.Space();
		EditorGUILayout.PropertyField(requireFriendlyProperty);

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
		if (GUILayout.Button("+", GUILayout.Width(30f)))
		{
			Condition newCondition = ConditionEditor.CreateCondition();
			addConditionProperty.AddToObjectArray(newCondition);
		}
		EditorGUILayout.EndHorizontal();

		EditorGUILayout.Space();

	}


	public static FriendShipCondition CreateConditionCollection()
	{
		FriendShipCondition newConditionCollection = CreateInstance<FriendShipCondition>();
		newConditionCollection.description = "New condition collection";
		newConditionCollection.addCondition = new Condition[1];
		newConditionCollection.addCondition[0] = ConditionEditor.CreateCondition();
		return newConditionCollection;
	}
}
