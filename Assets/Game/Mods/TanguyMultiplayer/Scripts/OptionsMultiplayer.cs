﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMultiplayer : MonoBehaviour
{

	public static bool timeHost = true;
	public static bool displayName = true;
	public static bool useHighestLevel = false;
	
	
	public static void Import(string s)
	{
		string[] list = s.Split('#');
		timeHost = list[0] == "True";
		displayName = list[1] == "True";
		useHighestLevel = list[2] == "True";
	}
	
	public static string Export()
	{
		return timeHost + "#" + displayName + "#" + useHighestLevel;
	}
}
