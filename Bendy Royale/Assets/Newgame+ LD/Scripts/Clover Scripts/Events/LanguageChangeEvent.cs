using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageChangeEvent : MonoBehaviour
{
	public void changeLang (string target)	{

		if(GameManager.instance) GameManager.instance.lang = target;
		
		else Debug.LogError("LanguageChangeEvent Error: A GameManager is required!");

	}
}
