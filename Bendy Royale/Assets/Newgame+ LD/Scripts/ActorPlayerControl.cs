//Special thanks to OhiraKyou. Developer of Nytro

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorPlayerControl : MonoBehaviour {

	public ActorBase target;
	public CustomInputModule inputMod;
	public bool cameraRelative = true;
	public VirtualCameraTarget cam;
	bool sustainInputsOnDisable;
	bool connected;

	[System.Serializable]
	public class inputs {

		public string horizontalAxis = "Horizontal";
		public string verticalAxis = "Vertical";
		public string runButton = "Run";
		public string actionButton = "Menu Confirm";
		public string jumpButton = "Jump";

	}
	public inputs m_input;

	// Use this for initialization
	void Start () {

	}

	Quaternion _screenMovementSpace;

	public void Update ()	{

		//if (!GameManager.instance || GameManager.instance.pause == false)
			UnpauseUpdate ();

	}

	// Update is called once per frame
	public new void UnpauseUpdate () {

		target.cam = cam;
		//if (//!GameManager.instance || 
			//!GameManager.instance.playerControlLocked) 
		{

			connected = true;

			if (cameraRelative) {
				Vector3 _screenForward = _screenMovementSpace * Vector3.forward;
				Vector3 _screenRight = _screenMovementSpace * Vector3.right;

				_screenMovementSpace = Quaternion.Euler (0f, cam.transform.eulerAngles.y, 0f); // yaw only

				Vector3 movementRight = (inputMod.GetAxis (m_input.horizontalAxis)) * _screenRight;
				Vector3 movementForward = (inputMod.GetAxis (m_input.verticalAxis)) * _screenForward;

				Vector3 overallCalculation = (movementRight + movementForward);

				target.axes = new Vector2 (overallCalculation.x, overallCalculation.z);
			} else
				target.axes = new Vector2 (inputMod.GetAxis (m_input.horizontalAxis), inputMod.GetAxis (m_input.verticalAxis));



			//print ("Right " + movementRight);
			//print ("Forward " + movementForward);

			if (target) {
				target.eventInteract = inputMod.GetButtonDown (m_input.actionButton);
				target.run = inputMod.GetButton (m_input.runButton);
				target.jump = inputMod.GetButton (m_input.jumpButton);
			}
		} 

		/*
		else {
			if (connected && !sustainInputsOnDisable) {
				target.axes = Vector2.zero;
				target.run = false;
				target.jump = false;
				target.eventInteract = false;

			}
			connected = false;
		}
		*/

		//target.axes = new Vector2 (, );
	}

	public void OnDisable ()	{

		if (!sustainInputsOnDisable) {

			target.axes = Vector2.zero;

		}

	}

}
