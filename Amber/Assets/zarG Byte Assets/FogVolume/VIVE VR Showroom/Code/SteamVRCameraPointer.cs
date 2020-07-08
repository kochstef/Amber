using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Valve.VR.InteractionSystem;

[System.Serializable]
public class PlayerCameraSwitched 	: UnityEvent<Camera>	{};

public class SteamVRCameraPointer : MonoBehaviour
{
	public Camera gameCam;
	public Player 				player;
	public PlayerCameraSwitched playerCameraSwitched;

	void Start()
	{
		//Meatspace fixup to make sure the VR camera starts at the desired point (the player's location) no matter where in meatspace the HMD is
		if (player.rigSteamVR.activeSelf)
		{
			Vector3 headRoomOffsetFixup = player.transform.position - player.headCollider.transform.position;
			headRoomOffsetFixup.y = 0;
			player.transform.Translate (headRoomOffsetFixup);
		}
	}
		
	// Update is called once per frame
	void Update ()
	{
		//Figuring out SteamVr's active camera, no MainCamera tags for the fallback cam!!
		if (gameCam != player.hmdTransform.GetComponent<Camera>())
		{
			gameCam = player.hmdTransform.GetComponent<Camera>();
			playerCameraSwitched.Invoke(gameCam);
		}
	}
}
