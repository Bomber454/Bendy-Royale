using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicEvent : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void playJingle (AudioClip clip)	{

		MusicPlayer player = MusicPlayer.instance;


		player.musicClip = clip;
		player.m_audioData.looping = false;
		StartCoroutine (player.loadMusic ());

	}


	public void fadeOutMusic (float time)	{

		if(MusicPlayer.instance)MusicPlayer.instance.stop(time);

	}

}
