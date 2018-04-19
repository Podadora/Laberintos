using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPlayer : MonoBehaviour {



public CharacterController script;
GameObject playerBody;
Rigidbody player;
Vector3 PosIni;
Vector3 PosFin = new Vector3(-138f,0.5f,-10f);
Vector3 PosPerd = new Vector3 ( -230f, 0.5f, 0f) ;
public float velocidad = 4f;
public float burst = 1f;
// Use this for initialization
void Start () 
{
	PosIni = transform.position;
	player = GetComponent<Rigidbody> ();
	playerBody = gameObject;
}

// Update is called once per frame
void Update () 
{
	if(Input.GetKey(KeyCode.A))
	{
			player.transform.Translate (-velocidad*Time.deltaTime, 0,0);
		}
		if(Input.GetKey (KeyCode.D)){
			player.transform.Translate(velocidad* Time.deltaTime, 0,0);
		}
		if (Input.GetKey(KeyCode.W)){
			player.transform.Translate(0,0,velocidad* Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.S)){
			player.transform.Translate(0,0, -velocidad * Time.deltaTime);
		}
	}
	void OnTriggerEnter(Collider otro)
{
		if (otro.CompareTag("Finish"))
		{
			transform.position = PosFin;
			Debug.Log ("Ganaste Mastercapomafia");
		}
		if(otro.CompareTag("Enemy"))
		{
			transform.position = PosIni;
			Debug.Log("Perdiste Gato");
			Destroy(playerBody);
			GameObject playerClon = Instantiate(playerBody, PosPerd, transform.rotation) as GameObject;
			script = playerClon.GetComponent<MovimientoPlayer> ();
			script.enabled = true;

		}
		if(otro.CompareTag("PlayAgain"))
		{
			transform.position = PosIni;
			Debug.Log("Volviste a jugar");
		}
}
		 
}
