﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DaggerfallWorkshop.Game;
using UnityEngine.UI;

public class HudMultiplayer : MonoBehaviour
{
	public Canvas canvas;
	public GraphicRaycaster raycaster;
	public GameObject[] checks;
	public static SteamLobby steamLobby;
	public Text status;
	public GameObject options;
	
	DaggerfallUI gameUI;
	
	
    void Start()
    {
		StartCoroutine(Check());
    }
	
	
	IEnumerator Check()
	{
		InputManager inputManager = GameObject.Find("InputManager").GetComponent<InputManager>();
		gameUI = GameObject.Find("DaggerfallUI").GetComponent<DaggerfallUI>();
		while (true)
		{
			canvas.enabled = (inputManager != null && inputManager.IsPaused);
			raycaster.enabled = canvas.enabled;
			setStatus();
			options.SetActive(!(PlayerMultiplayer.state == 2));
			yield return new WaitForSecondsRealtime(0.42f);
		}
	}
	
	void setStatus()
	{
		
		switch (PlayerMultiplayer.state){
			case 0:
				status.text = "Not connected";
				status.color = Color.red;
				break;
			case 1:
				status.text = "Connected as Host";
				status.color = Color.green;
				break;
			case 2:
				status.text = "Connected as Client";
				status.color = Color.green;
				break;
			default:
				status.text = "Unknown state";
				status.color = Color.blue;
				break;
			
		}
	}
	
	public void enableGameUI(bool b)
	{
		gameUI.enabled = b;
	}
	
	public void toggleTimeHost()
	{
		OptionsMultiplayer.timeHost = !OptionsMultiplayer.timeHost;
		checks[0].SetActive(OptionsMultiplayer.timeHost);
	}
	
	public void toggleName()
	{
		OptionsMultiplayer.displayName = !OptionsMultiplayer.displayName;
		checks[1].SetActive(OptionsMultiplayer.displayName);
	}
	
	public void refreshAllChecks()
	{
		checks[0].SetActive(OptionsMultiplayer.timeHost);
		checks[1].SetActive(OptionsMultiplayer.displayName);
	}
	
	public void hostButton()
	{
		steamLobby.HostLobby();
	}
}
