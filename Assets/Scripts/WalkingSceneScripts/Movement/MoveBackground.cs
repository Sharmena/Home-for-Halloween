using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour {



	public float speed;
	private float x;
	public float playerInput;
	public float PontoDeDestino;
	public float PontoOriginal;




	// Use this for initialization
	void Start () {
		//PontoOriginal = transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {

		playerInput = Input.GetAxis("Horizontal");

		if (Player.Instance.CanMove == true)
		{
			x = transform.position.x;
			x += speed * Time.deltaTime * playerInput;
			transform.position = new Vector3(x, transform.position.y, transform.position.z);
		}


		if (x <= PontoDeDestino){

			x = PontoOriginal;
			transform.position = new Vector3 (x, transform.position.y, transform.position.z);
		}


	}
}
