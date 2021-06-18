using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float Speed = 5;

	private Animator anim;
	private Rigidbody2D rigidBody;
	private bool olhandoParaDireita;

	void Start () {
		anim = GetComponent<Animator> ();
		rigidBody = GetComponent<Rigidbody2D> ();
		olhandoParaDireita = true;
	}

	void Update () {
		bool isRunning = false;
		rigidBody.velocity = new Vector2 (0, rigidBody.velocity.y);


		if (Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.RightArrow)) {//comando para ir para a direita
			Vector2 deltaPos = new Vector2 (Speed, rigidBody.velocity.y);
			rigidBody.velocity = deltaPos; //configurando o movimento 

			if (!olhandoParaDireita) {
				Flip();
			}

			isRunning = true;
		}

		if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow)) { //comando para ir para a esquerda
			Vector2 deltaPos = new Vector2 (-Speed, rigidBody.velocity.y);
			rigidBody.velocity = deltaPos; //configurando o movimento 

			if (olhandoParaDireita) {
				Flip();
			}

			isRunning = true;
		}
			
		anim.SetBool ("running", isRunning);
	}

	public void Flip()
	{
		Vector3 aux = transform.localScale;
		aux.x = aux.x * -1;
		transform.localScale = aux;
		if (olhandoParaDireita) {
			olhandoParaDireita = false;
		} else {
			olhandoParaDireita = true;
		}
	}
}
