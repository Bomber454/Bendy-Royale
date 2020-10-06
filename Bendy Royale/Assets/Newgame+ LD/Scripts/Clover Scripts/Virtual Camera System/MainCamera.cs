/*
 * MainCamera.cs
 * Created by: Newgame+ LD
 * Created on: ??/??/???? (dd/mm/yy)
 * 
 * Always put this on the main scene camera
 */

using UnityEngine;

public class MainCamera : MonoBehaviour {
  public static MainCamera instance;
  public Camera cam;
  public VirtualCameraTarget vrCam;
	public Transform sunPivot;
	//public UnityStandardAssets.ImageEffects.SunShafts sunRays;

  void Awake () {
    if (MainCamera.instance == null)
      MainCamera.instance = this;
		else {

			print("DETECTED MAIN CAM! It's :" + MainCamera.instance.gameObject.name);
			Destroy (gameObject);

		}
  }

	public void Update ()	{

		//sunRays.sunTransform = sunPivot;

	}
}
