using UnityEngine;
using System.Collections;

public class BeingLookedAt : MonoBehaviour
{
	private Color actualColor;
	// Use this for initialization
	void Start ()
	{
		actualColor = (transform.GetComponent<MeshRenderer> () as MeshRenderer).material.color;
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
	
	void RayCastCollision ()
	{
		(transform.GetComponent<MeshRenderer> () as MeshRenderer).material.color = Color.green;
		Debug.Log ("COLLITION");
		
	}
	void RayCastCollisionEnded ()
	{
		(transform.GetComponent<MeshRenderer> () as MeshRenderer).material.color = actualColor;
		Debug.Log ("COLLITION ENDED");
	}
}
