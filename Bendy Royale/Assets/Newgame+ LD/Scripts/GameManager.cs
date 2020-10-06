using UnityEngine;

public class GameManager : CommonBase {

	public static GameManager instance;

	public string lang = "ENG";


	void OnEnable ()	{

		if (GameManager.instance != null)	{
			if(GameManager.instance != this)	{
			Destroy (gameObject);
			return;
			}
		}

		GameManager.instance = this;
		DontDestroyOnLoad(this.gameObject);
	}



}
