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


	private float intervaloBala =0.1f;
	private float controleBala= 0f;
	public Transform spawnBala;
	public GameObject bala;
	private Rigidbody2D corpoRigido2D;

	//Tiro



	// Use this for initialization
	void Start () {
		pontuacao = 0;
		PlayerPrefs.SetInt("pontuacao", pontuacao);
		corpoRigido2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown ("Jump") && chao == true) {
			PlayerRigidbody.AddForce (new Vector2 (0, forcaPulo));
			audio.PlayOneShot (soundJump);
		}

		chao = Physics2D.OverlapCircle (GroundCheck.position, 0.2f, whatIsGround);
		Anime.SetBool ("Pular", !chao);


		txtPontos.text = pontuacao.ToString ();

		//metodo predefinido pela unity, que atualiza frame a frame na cena.
		if (controleBala > 0) {
			controleBala -= Time.deltaTime;
			// Esta condição faz com que o controle da bala comece a se decrementar.
		}

		if (Input.GetKeyDown (KeyCode.LeftControl) && chao) {

			Tiro ();
			controleBala = intervaloBala;
			/* Esta condição permite que ao pressionar a tecla Control da parte esquerda do teclado, chame o metodo tiro e que a variavel controleBala 
			 seja igual a intervaloBala.*/
 		
		}
	}

	void OnTriggerEnter2D () {

		PlayerPrefs.SetInt("pontuacao", pontuacao);

		if(pontuacao > PlayerPrefs.GetInt("recorde")) {
			PlayerPrefs.SetInt("recorde", pontuacao);
		}
		Application.LoadLevel("GameOver");

	}

		void Tiro() {
			if (controleBala <= 0) {
				//Ao ser chamado, verifica se a variavel é igual ou menor que zero.
				if (bala != null) {
					//Esta condição verifica se a "bala" não está nula... ou seja, se há um projetil de bala definido pelo editor 
					var cloneBala = (GameObject) Instantiate (bala, spawnBala.localPosition, Quaternion.identity);
					cloneBala.transform.localScale = this.transform.localScale; //Aqui determina a posição dele na tela.

					/* Logo é declarado uma variavel do tipo GameObject que para ficar entendível, nomeado de cloneBala, pois será instanciado o projetil da "bala", na posição
				de onde a bala vai "spawnar" (Surgir) que será neutralizado pela predefinida "Quaternion.identy" da unity.
			*/
				}
			}


		}





}
