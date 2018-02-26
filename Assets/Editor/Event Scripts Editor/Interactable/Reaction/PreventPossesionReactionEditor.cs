#if UNITY_EDITOR 
using UnityEditor;
#endif 

[CustomEditor(typeof(PreventPossesionReaction))]
public class PreventPossesionReactionEditor : ReactionEditor
{
	protected override string GetFoldoutLabel()
	{
		return "Prevent Possesion Reaction";
	}
}