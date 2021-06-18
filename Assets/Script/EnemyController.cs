using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	public Vector2 direction = Vector2.left;
	public float Speed = 7;
	public float JumpForce;

	private Rigidbody2D rigidBody;
	private float timeJump;
	private Animator anim;

	void Start () {
		rigidBody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		timeJump = 0;
	}

	/*
	 * O inimigo irá de um lado a outro e pulará a cada 3 segundos.
	 * */
	void Update () {
		rigidBody.velocity = new Vector2 (direction.x * Speed, rigidBody.velocity.y); //movimentação usa a direção (direita/esquerda) e a velocidade.

		timeJump = timeJump + Time.deltaTime; //contador de tempo soma a quantidade de tempo entre o último update e o atual

		if (timeJump > 3) { //quando o tempo chegou a 3 segundos, pula
			rigidBody.AddForce (new Vector2 (0, JumpForce), ForceMode2D.Impulse);

			if (anim != null) {
				anim.SetTrigger ("jump");
			}

			timeJump = 0; //volta o tempo pra zero (isso é importante)
		}
	}

	/*
	 * Trocar a direção do inimigo quando ele bater em alguma coisa. 
	 * */
	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag != "Chao") {
			direction = direction * -1;
			Flip();
		}
	}

	public void Flip()
	{
		Vector3 aux = transform.localScale;
		aux.x = aux.x * -1;
		transform.localScale = aux;
	}

}
