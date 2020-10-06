/*
 * RandomSound.cs
 * Created by: Newgame+ LD
 * Created on: 27/4/2019 (dd/mm/yy)
 */

using UnityEngine;

[RequireComponent (typeof (AudioSource))]

public class RandomSound : MonoBehaviour {

	public AudioSource source;
  public AudioClip[] sounds;
	public bool playOnAwake = true;


  // Use this for initialization
  void OnEnable () {

		source = GetComponent<AudioSource> ();
    if(playOnAwake)source.PlayOneShot (sounds[Random.Range (0, sounds.Length)]);

  }

	public void playSound ()	{

		source.PlayOneShot (sounds[Random.Range (0, sounds.Length)]);

	}

}
