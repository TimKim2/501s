﻿using System.Collections;
#if UNITY_EDITOR 
using UnityEditor;
#endif 

[CustomEditor(typeof(SetFriendlyReaction))]
public class SetFriendlyReactionEditor : ReactionEditor
{
	protected override string GetFoldoutLabel()
	{
		return "Set Button Enable Reaction";
	}
}

