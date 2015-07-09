using UnityEngine;
using System.Collections;

public class lookingAt : MonoBehaviour
{
 
	private RaycastHit hit;
	private GameObject lastGameObjectLookedAt;
	private GameObject gameObjectLookingAt;
	
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{

		LookAtAnObject ();
		
	
	}
	
	//Para controlar el raycast colisionando con la caja exterior que contiene el scenario he tenido que poner esta en otra
	//layer para que no hubiera problemas de colision con los collider del interior (me expulsaba al exterior al controller cuando comenzaba el movimiento
	void LookAtAnObject ()
	{
//	+ transform.TransformDirection ((Vector3.forward) * 100f)
		//Debug.DrawRay (transform.position + transform.TransformDirection ((Vector3.forward) * 100f), Vector3.forward, Color.green);
		Debug.DrawLine (transform.position + transform.TransformDirection ((Vector3.forward) * 100f), transform.position, Color.green);
		if (Physics.Raycast (transform.position, transform.TransformDirection (Vector3.forward), out hit)) {
			Debug.DrawLine (transform.position, hit.point, Color.blue);
			HandleCollision ();
		} else if (Physics.Raycast (transform.position + transform.TransformDirection ((Vector3.forward) * 100f), (-1.0f) * transform.TransformDirection (Vector3.forward), out hit)) {
		
			Debug.DrawLine (transform.position, hit.point, Color.red);
			HandleCollision ();
		}
		
	}
	
	void HandleCollision ()
	{
		gameObjectLookingAt = hit.collider.gameObject as GameObject;
		gameObjectLookingAt.SendMessage ("RayCastCollision", SendMessageOptions.DontRequireReceiver);
		if (lastGameObjectLookedAt != gameObjectLookingAt) {
			if (lastGameObjectLookedAt != null)
				lastGameObjectLookedAt.SendMessage ("RayCastCollisionEnded", SendMessageOptions.DontRequireReceiver);
			lastGameObjectLookedAt = gameObjectLookingAt;
		}
	}
}
//			if (hit.collider.CompareTag ("Sphere") || hit.collider.CompareTag ("Cube")) {
//				gameObjectLookingAt = hit.collider.gameObject as GameObject;
////				MeshRenderer meshRenderer = gameObjectLookingAt.GetComponent ("MeshRenderer") as MeshRenderer;
////				meshRenderer.material.SetColor ("Albedo", Color.green);		
//				(gameObjectLookingAt.GetComponent<MeshRenderer> () as MeshRenderer).material.color = Color.green;
//				Debug.Log ("COLLITION");
//			}

