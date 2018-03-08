using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventMaster : MonoBehaviour {

	private static EventMaster m_instance;
	private const string loadPath = "EventMaster";

	public ReactionCollection currentReactionCollection;

	public static EventMaster Instance{
		get{
			if (!m_instance)
				m_instance = FindObjectOfType<EventMaster>();
			return m_instance;
		}
		set{
			m_instance = value;
		}
	}
}
