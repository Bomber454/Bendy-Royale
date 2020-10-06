using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCharacter : ActorBase
{
	public static FirstPersonCharacter instance;
	public Animator m_animator;
	public Vector2 lookAxes;
	public Transform viewport;
	public Transform viewportWobble;
	public ParticleSystem.MinMaxCurve wobbleCurve;
	public float wobbleProgression;


    // Start is called before the first frame update
    void Start()
    {
		FirstPersonCharacter.instance = this;
    }

    // Update is called once per frame
    void Update()
    {

		Vector3 lastPosition = transform.position;

		base.Update();

		if(m_animator)	{
		m_animator.SetFloat("Walk Speed", Mathf.Clamp((lastPosition - transform.position).magnitude*16,0,1) * (run?1.375f:1));
		m_animator.SetBool("Airborne", !chara.isGrounded);
		}
			
			transform.eulerAngles += new Vector3(0, lookAxes.x, 0);
			viewport.transform.localEulerAngles += new Vector3(-lookAxes.y, 0, 0);

			Vector3 helper = viewport.transform.localEulerAngles;

			if(helper.x > 180) 
			helper.x -= 360;

			helper.x = Mathf.Clamp(helper.x,-75, 75);



			viewport.transform.localEulerAngles = new Vector3(helper.x,0,0);


		lookAxes = Vector2.zero;

		wobbleProgression += Time.deltaTime * Mathf.Clamp(smoothAxes.magnitude,0,1) * (run?1.5f:1);


		viewportWobble.localPosition = Vector3.Lerp(Vector3.zero, 
			new Vector3(wobbleCurve.Evaluate(wobbleProgression,1),wobbleCurve.Evaluate(wobbleProgression,0)), 
			Mathf.Clamp(smoothAxes.magnitude,0,1) * (chara.isGrounded?1:0));
    }
}
