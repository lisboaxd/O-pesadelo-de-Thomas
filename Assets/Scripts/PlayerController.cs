using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	[Range(1,20)]
	public float forcaDoPulo = 5.0f;
	[Range(0.5f,10.0f)]
	public float DistanciaDoChao = 1;
	[Range(0.5f,5.0f)]
	public float TempoPorPulo = 1.5f;
	public LayerMask LayersNaoIgnoradas = -1;
	private bool estaNoChao, contar = false;
	private float cronometro = 0;
	private Rigidbody2D corpoRigido2D;

	/* As variáveis acima determinam o pulo do personagem.
	 Declarado valores do tipo float que já é pode variar entre os valores, através do "Range", mas todos são editavéis, pois estão públicos.
	Declarado também, uma outra váriavel do tipo "layerMask" (é uma classe da unity), que tem uma função de verificar se o player está no chão, dois boleanos para determinar 
	a condição de pulo e tempo para evitar flutuar no pulo.
	O cronometro para disparar o tempo e um rigidbody para ser controlado via codigo.
   	*/

	private float intervaloBala =0.1f;
	private float controleBala= 0f;
	public Transform spawnBala;
	public GameObject bala;
	/*
	As variáveis acima determina o tiro.
	Duas variáveis do tipo float privadas, que determinar o controle e intervalo para evitar uma bala dentro da outra, o que seria surreal.
	Uma variável do tipo Transform que no editor foi colocado para ser a posição onde a bala vai ser projetada e uma variável do tipo GameObject para
	instanciar no momento do tiro.

	*/

	// Use this for initialization
	void Start () {
		//metodo predefinido pela unity, que apenas inicia.
		
		corpoRigido2D = GetComponent<Rigidbody2D>();
        //Iniciar o corpoRigido para que possa ser acessado.
	}
	
	// Update is called once per frame

	void Update () {
		//metodo predefinido pela unity, que atualiza frame a frame na cena.
		if (controleBala > 0) {
			controleBala -= Time.deltaTime;
			// Esta condição faz com que o controle da bala comece a se decrementar.
		}

		if (Input.GetKeyDown(KeyCode.LeftControl)){
			
			Tiro();
			controleBala = intervaloBala;
			/* Esta condição permite que ao pressionar a tecla Control da parte esquerda do teclado, chame o metodo tiro e que a variavel controleBala 
			 seja igual a intervaloBala.*/
	
		}


		estaNoChao = Physics2D.Linecast (transform.position, transform.position - Vector3.up*DistanciaDoChao, LayersNaoIgnoradas).transform;
		// Este é o momento que a variavél estaNoChao verifica se o personagem está no chão.

		if(Input.GetKeyDown(KeyCode.Space) && estaNoChao == true && contar == false){
			
			/*Condição que ao pressionar espaço e estaNochao for verdadeiro e contar falso, será declarado um Vetor de 3 posição nomeado de "jump" que recebe apenas 
			 no valor x e y. Através do corpoRigido2D, é adicionado uma força, pelo "AddForce" que é predefinido pela unity onde recebe um valor de vetor multiplicado pela força
			 que dará a projeção e é usado também predefinido pela unity que a força do pulo é um impulso, através do "ForceMode2D.Impulse.
			*/
			Vector3 jump = new Vector2(0.0f, 1.0f);
			corpoRigido2D.AddForce(jump * forcaDoPulo, ForceMode2D.Impulse);
			//animator.SetTrigger("jump"); está oculto, usar apenas se houver uma animação de pulo.
			//Ao pular, o estaNoChao será falso e o contar verdadeiro.
			estaNoChao = false;
			contar = true;
		}

		if (contar == true) {
			cronometro += Time.deltaTime;
			//Condição começa a incrementar o cronometro;
		}
		if (cronometro >= TempoPorPulo) {
			/*Condição que verifica se o cronometro passou do tempo permitido, a variável contar passa ser falso e é zerado o cronometro.
			Todas essas condições limita o pulo do personagem, pois se não ao pressionar varias vezes a tecla espaço, o player iria flutuar.
			*/
			contar = false;

			cronometro = 0;
		}

    }

	void Tiro(){
		
		if (controleBala <= 0) {
			//Ao ser chamado, verifica se a variavel é igual ou menor que zero.
			if (bala != null) {
				//Esta condição verifica se a "bala" não está nula... ou seja, se há um projetil de bala definido pelo editor 
				var cloneBala = (GameObject) Instantiate (bala, spawnBala.position, Quaternion.identity);
				cloneBala.transform.localScale = this.transform.localScale; //Aqui determina a posição dele na tela.

				/* Logo é declarado uma variavel do tipo GameObject que para ficar entendível, nomeado de cloneBala, pois será instanciado o projetil da "bala", na posição
				de onde a bala vai "spawnar" (Surgir) que será neutralizado pela predefinida "Quaternion.identy" da unity.
			*/
			}
		}


	}

}
