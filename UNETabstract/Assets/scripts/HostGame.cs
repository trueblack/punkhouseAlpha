﻿using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;


public class HostGame : NetworkBehaviour {
	[SerializeField]
	private uint roomsize = 6;
	private string roomName;
	private NetworkManager networkManager;

	void Start(){
		networkManager = NetworkManager.singleton;
		if (networkManager.matchMaker == null) {
			networkManager.StartMatchMaker ();
		}
	}
	void Update(){
		if (Input.GetKey (KeyCode.Escape)) {
			leaveRoom ();
		}
	}
	public void setRoomName(string _name){
		roomName = _name;
	}
	public void createRoom(){
		if (roomName != "" && roomName != null) {
			Debug.Log("we are creating room:"+roomName+"at size:"+roomsize+"please wait");
			//create room
			networkManager.matchMaker.CreateMatch(roomName,roomsize,true,"", "", "", 0, 0, networkManager.OnMatchCreate);
		}
	}
	public void leaveRoom(){
		MatchInfo matchInfo = networkManager.matchInfo;
		networkManager.matchMaker.DropConnection (matchInfo.networkId,matchInfo.nodeId,0,networkManager.OnDropConnection);
		networkManager.StopHost ();
	}
}
