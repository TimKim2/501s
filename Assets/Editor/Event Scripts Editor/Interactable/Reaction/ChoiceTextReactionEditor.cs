﻿#if UNITY_EDITOR 
using UnityEditor;
#endif 
using UnityEngine;

[CustomEditor(typeof(ChoiceTextReaction))]
public class ChoiceTextReactionEditor : ReactionEditor
{
	private SerializedProperty dialogueProperty;
	private SerializedProperty characterNameProperty;
	private SerializedProperty characterImageProperty;
	private SerializedProperty delayProperty;

	private SerializedProperty firstChoiceProperty;
	private SerializedProperty firstReactionCollectionProperty;

	private SerializedProperty secondChoiceProperty;
	private SerializedProperty secondReactionCollectionProperty;


	private const float messageGUILines = 3f;
	private const float areaWidthOffset = 19f;
	private const string textReactionPropDialogueName = "dialogue";
	private const string textReactionPropCharacterName = "characterName";
	private const string textReactionPropCharacterImage = "characterImage";
	private const string textReactionPropDelayName = "delay";

	private const string firstChoiceName = "firstChoice";
	private const string firstReactionCollectionName = "firstReactionCollection";

	private const string secondChoiceName = "secondChoice";
	private const string secondReactionCollectionName = "secondReactionCollection";


	protected override void Init ()
	{
		dialogueProperty = serializedObject.FindProperty (textReactionPropDialogueName);
		characterNameProperty = serializedObject.FindProperty(textReactionPropCharacterName);
		characterImageProperty = serializedObject.FindProperty (textReactionPropCharacterImage);
		delayProperty = serializedObject.FindProperty (textReactionPropDelayName);

		firstChoiceProperty = serializedObject.FindProperty (firstChoiceName);
		firstReactionCollectionProperty = serializedObject.FindProperty (firstReactionCollectionName);

		secondChoiceProperty = serializedObject.FindProperty (secondChoiceName);
		secondReactionCollectionProperty = serializedObject.FindProperty (secondReactionCollectionName);
	}


	protected override void DrawReaction ()
	{
		EditorGUILayout.BeginHorizontal ();
		EditorGUILayout.LabelField ("Dialogue", GUILayout.Width (EditorGUIUtility.labelWidth - areaWidthOffset));
		dialogueProperty.stringValue = EditorGUILayout.TextArea (dialogueProperty.stringValue, GUILayout.Height (EditorGUIUtility.singleLineHeight * messageGUILines));
		EditorGUILayout.EndHorizontal ();

		EditorGUILayout.BeginHorizontal();
		EditorGUILayout.LabelField("Name", GUILayout.Width(EditorGUIUtility.labelWidth - areaWidthOffset));
		characterNameProperty.stringValue = EditorGUILayout.TextArea(characterNameProperty.stringValue, GUILayout.Height(EditorGUIUtility.singleLineHeight));
		EditorGUILayout.EndHorizontal();

		EditorGUILayout.PropertyField (characterImageProperty);
		EditorGUILayout.PropertyField (delayProperty);

		EditorGUILayout.PropertyField (firstChoiceProperty);
		EditorGUILayout.PropertyField (firstReactionCollectionProperty);

		EditorGUILayout.PropertyField (secondChoiceProperty);
		EditorGUILayout.PropertyField (secondReactionCollectionProperty);
	}


	protected override string GetFoldoutLabel()
	{
		return "Choice Text Reaction";
	}
}