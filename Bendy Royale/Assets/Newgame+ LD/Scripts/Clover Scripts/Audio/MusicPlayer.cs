/*
 * MusicPlayer.cs
 * Created by: Newgame+ LD
 * Created on: 28/3/2020 (dd/mm/yy)
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent (typeof (AudioSource))]

public class MusicPlayer : MonoBehaviour {

  public static MusicPlayer instance;
	public bool isMaster;
  public AudioClip musicClip;

	[System.Serializable]
	public class audioData	{
		  public float tempo;
		  public Vector2 signature = new Vector2 (4, 4);
		  public float curMeasure;
		  public bool looping;
		  public Vector3 loopStart;
		  public Vector3 loopEnd;
	}

	public audioData m_audioData;
	public string identifier;

  public float debug;
  public bool debugSet;
  public float debugSetter;

  public int debugMusicChoice;
  public bool debugMusicSet;

  public int priority;
  //public bool playOnStart;

	AudioSource source;

  void Start () {

		source = GetComponent<AudioSource> ();

		/*
    //if(MusicPlayer.instance != this)target = GameObject.FindWithTag ("Music Player").GetComponent<MusicPlayer> ();


    if (instance != null && instance != this) {

      if (priority < MusicPlayer.instance.priority)
        Destroy (gameObject);
      else {

        Destroy (MusicPlayer.instance.gameObject);

      }

    }
*/

    if(isMaster) MusicPlayer.instance = this;


			
    //print ("instance set!");
    //if (playOnStart) refresh ();

  }

  void Update () {

		if(isMaster) {
    convertSecondsToBeatValue ();
		convertBeatValueToSeconds (m_audioData.curMeasure);
    loopCheck ();





    if (debugSet) {
      source.time = debugSetter;
      debugSet = false;
    }

    if (debugMusicSet) {

      StartCoroutine (loadMusic ());
      debugMusicSet = false;
    }
		}


		else if(MusicPlayer.instance && (!MusicPlayer.instance.source.isPlaying||identifier != MusicPlayer.instance.identifier))	{
			refresh();
			Destroy(gameObject);
		}
  }

  void refresh () {
		
		MusicPlayer.instance.m_audioData = m_audioData;
		MusicPlayer.instance.source.time = 0;
		MusicPlayer.instance.source.clip = musicClip;
		MusicPlayer.instance.source.Stop ();
		MusicPlayer.instance.source.PlayDelayed (0.25f);
		print("Refreshed!");
  }

  void convertSecondsToBeatValue () {

    debug = source.time;
		m_audioData.curMeasure = ((debug / m_audioData.signature.x) * m_audioData.tempo) / 60;
  }

  public float convertBeatValueToSeconds (float value) {

		return (m_audioData.signature.x * ((value * 60) / m_audioData.tempo));
  }

  void loopCheck () {

		if (m_audioData.curMeasure > (m_audioData.loopEnd.x + (m_audioData.loopEnd.y / m_audioData.signature.y))) {
			source.time -= convertBeatValueToSeconds ((m_audioData.loopEnd.x + (m_audioData.loopEnd.y / m_audioData.signature.y)) - 
				(m_audioData.loopStart.x + (m_audioData.loopStart.y / m_audioData.signature.y)));
    }

  }

  public IEnumerator loadMusic () {

    while (source.volume > 0) {

      if (!source.isPlaying)
        source.volume = 0;
      source.volume -= Time.deltaTime / 2;

      yield return new WaitForEndOfFrame ();
    }

    refresh ();

    source.volume = 1;

  }

  public void stop (float fadeTime) {

    StartCoroutine (istop (fadeTime));

  }

  public IEnumerator istop (float fadeTime) {

    while (source.volume > 0) {

      if (!source.isPlaying)
        source.volume = 0;
      source.volume -= (Time.deltaTime / fadeTime);

      yield return new WaitForEndOfFrame ();
    }

		source.Stop();

  }

}
