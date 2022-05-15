using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyCameraMove : MonoBehaviour {

	public float MoveSpeed = 2f;

	GameObject Spoint;

    GameObject Epoint;
    

	Vector3 pos;
	float speed;

    private void Awake()
	{
		Spoint = GameObject.FindGameObjectWithTag("Start");

       
		Epoint = GameObject.FindGameObjectWithTag("End");
	}

	void Start ()
	{
		transform.position = Spoint.transform.position;
		pos = Spoint.transform.position - Epoint.transform.position;
		pos = pos.normalized;
		speed = 0.01f * MoveSpeed;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(Vector3.Distance(transform.position,Epoint.transform.position)>1f)
		    transform.Translate(-pos*speed);

	}
}
