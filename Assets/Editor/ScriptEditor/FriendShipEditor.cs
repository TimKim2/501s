using UnityEngine;
#if UNITY_EDITOR 
using UnityEditor;
#endif 

[CustomEditor(typeof(FriendShip))]
public class FriendShipEditor : EditorWithSubEditors<FriendShipConditionEditor, FriendShipCondition> {

	private FriendShip friendShip;
	private SerializedProperty friendlyProperty;
	private SerializedProperty friendShipConditionProperty;

	private const float collectionButtonWidth = 125f;
	private const string friendlyPropertyName = "friendly";
	private const string friendShipConditionPropertyName = "friendShipCondition";

	private void OnEnable ()
	{
		friendShip = (FriendShip)target;

		friendlyProperty = serializedObject.FindProperty(friendlyPropertyName);
		friendShipConditionProperty = serializedObject.FindProperty(friendShipConditionPropertyName);

		CheckAndCreateSubEditors(friendShip.friendShipCondition);
	}


	private void OnDisable ()
	{
		CleanupEditors ();
	}


	protected override void SubEditorSetup(FriendShipConditionEditor editor)
	{
		editor.friendShipConditionProperty = friendShipConditionProperty;
	}



	public override void OnInspectorGUI ()
	{
		serializedObject.Update ();

		CheckAndCreateSubEditors(friendShip.friendShipCondition);

		EditorGUILayout.PropertyField (friendlyProperty);

		for (int i = 0; i < subEditors.Length; i++)
		{
			subEditors[i].OnInspectorGUI ();
			EditorGUILayout.Space ();
		}

		EditorGUILayout.BeginHorizontal();
		GUILayout.FlexibleSpace ();
		if (GUILayout.Button("Add Collection", GUILayout.Width(collectionButtonWidth)))
		{
			FriendShipCondition newCollection = FriendShipConditionEditor.CreateConditionCollection ();
			friendShipConditionProperty.AddToObjectArray (newCollection);
		}
		EditorGUILayout.EndHorizontal ();

		EditorGUILayout.Space ();;

		serializedObject.ApplyModifiedProperties ();
	}
}
