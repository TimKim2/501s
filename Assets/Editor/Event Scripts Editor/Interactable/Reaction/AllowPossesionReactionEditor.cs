#if UNITY_EDITOR 
using UnityEditor;
#endif 

[CustomEditor(typeof(AllowPossesionReaction))]
public class AllowPossesionReactionEditor : ReactionEditor
{
	protected override string GetFoldoutLabel()
	{
		return "Allow Possesion Reaction";
	}
}