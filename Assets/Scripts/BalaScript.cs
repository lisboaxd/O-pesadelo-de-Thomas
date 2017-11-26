using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaScript : MonoBehaviour {

	// Use this for initialization
	public Vector2 velocidade = new Vector2 (15,0);
	private Rigidbody2D rbBala;
	/* Este é script da bala, no qual de forma resumida ela é adicionada ao projetil que irá funcionar como uma bala reage ao tiro, aqui é definido a veloicida da bala.	
	 Um vetor de 2 posição para determinar a projeção de qual eixo a bala irá ganhar velocidade, no qual "X".
	 E um rigidbody para ter acesso via codigo.

	 */
	void Start() {
		rbBala = GetComponent<Rigidbody2D> ();// recebe o componente;
	}

	void Update () {
		//Será utilizado no metodo start, pois ao ser instanciado ja recebe a velocidade.

		rbBala.velocity = velocidade * this.transform.localScale.x;
		//Destroy (gameObject, 2f);
		/* E através da classe velocidade que é predefinida pela unity, recebe velocidade multiplicado por ela mesmo na posição X.
		*/

	}

	void OnTriggerEnter2D () {

		Debug.Log ("teste");


		Application.LoadLevel ("GameOver");
	
	}
}
