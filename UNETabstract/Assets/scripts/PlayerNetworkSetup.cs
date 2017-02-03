﻿using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerNetworkSetup : NetworkBehaviour {

	[SerializeField]Camera FollowCamera;

	// Use this for initialization
	void Start () {

		if (isLocalPlayer) {
			//GameObject.Find ("SceneCamera").SetActive (false);
			GetComponent<PnetController> ().enabled = true;
			GetComponentInChildren<movelook> ().enabled = true;
			//FollowCamera.enabled=true;
			GetComponent<NetworkAnimator>().SetParameterAutoSend(0,true);
		}
	}
	public override void PreStartClient(){
			GetComponent<NetworkAnimator>().SetParameterAutoSend(0,true);
	}
	

}
