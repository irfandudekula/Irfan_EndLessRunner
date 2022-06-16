using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
	public GameObject pausebutton, resumebutton;
	
	void Start()													
	{
		pausebutton.gameObject.SetActive(true);
		resumebutton.gameObject.SetActive(false);
	}

	
	public void PauseResumeButtons(bool ispause)
	{
		if (ispause)																	//if game in pause, on button click resume the game
		{
			Time.timeScale = 0;
			pausebutton.gameObject.SetActive(false);
			resumebutton.gameObject.SetActive(true);
		}
		else
		{
			Time.timeScale = 1;															// if game in resume, on button click pause the game
			pausebutton.gameObject.SetActive(true);
			resumebutton.gameObject.SetActive(false);
		}
	}

}
