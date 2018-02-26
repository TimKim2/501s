#if UNITY_EDITOR 
using UnityEditor;
#endif 
using UnityEngine;

[CustomEditor(typeof(TutorialTextReaction))]
public class TutorialTextReactionEditor : ReactionEditor
{
	private SerializedProperty dialogueProperty;
	private SerializedProperty delayProperty;


	private const float messageGUILines = 3f;
	private const float areaWidthOffset = 19f;
	private const string textReactionPropDialogueName = "dialogue";
	private const string textReactionPropDelayName = "delay";


	protected override void Init ()
	{
		dialogueProperty = serializedObject.FindProperty (textReactionPropDialogueName);
		delayProperty = serializedObject.FindProperty (textReactionPropDelayName);
	}


	protected override void DrawReaction ()
	{
		EditorGUILayout.BeginHorizontal ();
		EditorGUILayout.LabelField ("Dialogue", GUILayout.Width (EditorGUIUtility.labelWidth - areaWidthOffset));
		dialogueProperty.stringValue = EditorGUILayout.TextArea (dialogueProperty.stringValue, GUILayout.Height (EditorGUIUtility.singleLineHeight * messageGUILines));
		EditorGUILayout.EndHorizontal ();

		EditorGUILayout.PropertyField (delayProperty);
	}


	protected override string GetFoldoutLabel ()
	{
		return "Tutorial Text Reaction";
	}
}
