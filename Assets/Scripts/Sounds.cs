using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
	static AudioSource audiosrc;
	public static AudioClip coinsound, jumpsound, enemysound, gamesound;
	// Start is called before the first frame update
	void Start()
	{
		audiosrc = GetComponent<AudioSource>();
		coinsound = Resources.Load<AudioClip>("coins");
		jumpsound = Resources.Load<AudioClip>("jump");
		enemysound = Resources.Load<AudioClip>("enemy");											// at start get audio source and load music
	}

	// Update is called once per frame
	void Update()
	{

	}
	public static void PlaySound(string Clip)
	{
		switch (Clip)
		{
			case "coins":																		// on coins case, play coins audio
				audiosrc.PlayOneShot(coinsound);
				break;
			case "jump":																		// on jump case, play jump audio
				audiosrc.PlayOneShot(jumpsound);
				break;
			case "enemy":																		// on enemy destroyed case, play enemy audio
				audiosrc.PlayOneShot(enemysound);
				break;
			
		}
	}
}

