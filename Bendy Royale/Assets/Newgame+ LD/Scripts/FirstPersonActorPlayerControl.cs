using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonActorPlayerControl : MonoBehaviour {

	public ActorPlayerControl playerControl;
	public FirstPersonCharacter target;
	public float lookSensitivity = 1;
	bool connected;
	bool sustainInputsOnDisable;
	public VirtualCamera viewportTarget;

	public bool lockCursor;

	//public PointerEventKey interactorKey;

	[System.Serializable]
	public class inputs {

		public string horizontalLookAxis = "Look X";
		public string verticalLookAxis = "Look Y";
		//public string interactButton = "Check";

	}
	public inputs m_input;


		

	public void Update ()	{

		//if (!GameManager.instance || GameManager.instance.pause == false)
			UnpauseUpdate ();

		if(lockCursor)
			Cursor.lockState = CursorLockMode.Locked;

		else Cursor.lockState = CursorLockMode.None;

		if(Input.GetKey(KeyCode.Escape)) lockCursor = false;
	}


	// Update is called once per frame
	public new void UnpauseUpdate () {

		//if (!GameManager.instance || !GameManager.instance.playerControlLocked) 
		{

			connected = true;

			target.lookAxes += new Vector2 (playerControl.inputMod.GetAxisRaw (m_input.horizontalLookAxis, true), 

				playerControl.inputMod.GetAxisRaw (m_input.verticalLookAxis, true)) * lookSensitivity * Time.deltaTime * 60;

			//interactorKey.click = playerControl.inputMod.GetButtonDown(m_input.interactButton);
		}

		/*
		else {
			if (connected && !sustainInputsOnDisable) {
				target.lookAxes = Vector2.zero;
			}
			connected = false;
		}
*/
		//target.axes = new Vector2 (, );
	}

	public void OnDisable ()	{

		if (!sustainInputsOnDisable) {

			target.lookAxes = Vector2.zero;

		}

	}

}
