using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorBase : MonoBehaviour
{

	public VirtualCameraTarget cam;
	public Vector3 velocity;
	public CharacterController chara;

	public bool run;
	public Vector2 axes;
	public bool jump;
	public bool eventInteract;

	public float verticalSpeed;


    // Start is called before the first frame update
    void Start()
    {
        
    }

	[HideInInspector]
	public Vector2 smoothAxes;

    // Update is called once per frame
    public void Update()
    {
		if(chara.isGrounded) verticalSpeed = -0.12f;
		else verticalSpeed -= 9.81f * Time.deltaTime;

		if(jump && chara.isGrounded) verticalSpeed = 4;



			smoothAxes = Vector2.MoveTowards(smoothAxes, axes, Time.deltaTime*6);


		chara.Move(new Vector3 (smoothAxes.x, 0, smoothAxes.y)

			* (run ? 4 : 2)*Time.deltaTime);

		chara.Move(new Vector3 (0, verticalSpeed, 0)*Time.deltaTime);
    }
}
