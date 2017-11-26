using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour {

	public Animator 	Anime;
	public Rigidbody2D	PlayerRigidbody;
	public int 			forcaPulo;
	public bool			Morrer;

	//Verificar o chão

	public Transform GroundCheck;
	public bool chao;
	public LayerMask whatIsGround;


	//Audio
	public AudioSource audio;
	public AudioClip soundJump;

	//PONTUACAO
	public UnityEngine.UI.Text txtPontos;
	public static int pontuacao;

	// Use this for initialization
	void Start () {
		pontuacao = 0;
		PlayerPrefs.SetInt("pontuacao", pontuacao);
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetButtonDown("Jump") && chao ==true) {
			PlayerRigidbody.AddForce(new Vector2(0,forcaPulo));
			audio.PlayOneShot(soundJump);
		}

		chao = Physics2D.OverlapCircle (GroundCheck.position, 0.2f, whatIsGround);
		Anime.SetBool ("Pular", !chao);


		txtPontos.text = pontuacao.ToString();
 		
	}

	void OnTriggerEnter2D () {

		PlayerPrefs.SetInt("pontuacao", pontuacao);

		if(pontuacao > PlayerPrefs.GetInt("recorde")) {
			PlayerPrefs.SetInt("recorde", pontuacao);
		}
		Application.LoadLevel("GameOver");

	}
}
