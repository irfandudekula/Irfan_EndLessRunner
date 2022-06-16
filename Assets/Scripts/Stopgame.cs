using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stopgame : MonoBehaviour
{
	public static bool Gameover;
	public GameObject GameOverPanel;						// game over panel

	void Start()
	{

		Gameover = false;						// at start panel is in false state
		Time.timeScale = 1;

	}

	// Update is called once per frame
	void Update()
	{


		if (Gameover)
		{
			Time.timeScale = 0;										// if gameover of any condition then panel will be on
			GameOverPanel.SetActive(true);
		}

	}
}
