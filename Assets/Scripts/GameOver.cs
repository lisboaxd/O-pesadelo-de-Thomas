using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {
	
	public UnityEngine.UI.Text pontos;
	public UnityEngine.UI.Text recorde;


	// Use this for initialization
	void Start () {
		pontos.text = PlayerPrefs.GetInt ("pontuacao").ToString ();
		recorde.text = PlayerPrefs.GetInt ("recorde").ToString ();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown (0))  {
			Application.LoadLevel ("ThomasCena1");
		}
		
	}
}
