using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementKiller : MonoBehaviour {

	public float RunSPD = 3.0f;
	public float JumpPOW = 3.0f;
	

	public Animator Animat;
	public bool ATTACK = false;
	public bool MoveControll = true;
	public int ActionState;

	public AudioSource attacksound;
	
	public int DashSPD = 20;


	Transform ChaseTarget;
	bool Chase = false;
	AudioSource audio;


	GameObject soundtmp;
	AudioSource walksound;
	
	void Start()
	{
		soundtmp = new GameObject("soundtmp");
		walksound = soundtmp.AddComponent<AudioSource>();
		walksound.clip = AudioManager.Self.sound[Sound.Walk];
		walksound.volume = 0.5f;


		ActionState = ActionSTATE.MOVE_STATE;
		Animat = GameObject.Find("TheTrapper_rig").GetComponent<Animator>();
		audio = GetComponent<AudioSource>();

		Animat.SetInteger("ANI_STATE", ANI_STATE.IDLE_STATE);

	}

	void Update()
	{
		Debug.DrawRay(transform.position, transform.forward*30, Color.red);

		if(MoveControll)
			Movement();
		Attack();

		RaycastHit hit;
		if(!Chase && Physics.Raycast(transform.position, transform.forward, out hit, 10f))
		{
			if (hit.transform.CompareTag("Survivor"))
			{
				ControlAI info = hit.transform.GetComponent<ControlAI>();
				if (!info.Down && !info.Hook)
				{
					ChaseTarget = hit.transform;
					Chase = true;
					int index = Random.RandomRange(0, 6);
					audio.clip = AudioManager.Self.sound[index];
					audio.loop = true;
					audio.Play();
				}
			}
		}

		if(Chase)
		{
			
			if (Vector3.Distance(transform.position,ChaseTarget.position)>10f||
				ChaseTarget.GetComponent<ControlAI>().Down)
			{
				if(!IsChaseSoundDonw)
				StartCoroutine("ChaseSoundDonw");
			}
		}
		
	}

	bool IsChaseSoundDonw = false;
	IEnumerator ChaseSoundDonw()
	{
		IsChaseSoundDonw = true;
		while (true)
		{
			if (audio.volume == 0)
				break;
			audio.volume -= 0.01f;
			yield return new WaitForSeconds(0.1f);
		}
		audio.Stop();
		Chase = false;
		audio.volume = 0.5f;
		IsChaseSoundDonw = false;
	}

	void Attack()
	{
		if(!Animat.GetCurrentAnimatorStateInfo(0).IsName("ATTACK")&& ATTACK)
		{
			Animat.SetInteger("ANI_STATE", ANI_STATE.IDLE_STATE);
			MainCamera.Self.SetCameraMoveState(CameraState.START);
			Machete.Self.col.enabled = false;
			ATTACK = false;
			MoveControll = true;
			ActionState = ActionSTATE.MOVE_STATE;
		}
		if (Input.GetMouseButtonDown(0)&& MoveControll && 
			ActionState == ActionSTATE.MOVE_STATE)
		{
			if(!IsDash)
				StartCoroutine("Dash");
			Animat.SetInteger("ANI_STATE", ANI_STATE.ATTACK_STATE);
			attacksound.Play();
			Machete.Self.col.enabled = true;
			ATTACK = true;
			//MainCamera.Self.SetCameraMoveState(CameraState.STOP);
			//MoveControll = false;
			ActionState = ActionSTATE.ATTACK_STATE;
		}
	}

	void Movement()
	{
		float horizon = Input.GetAxis("Horizontal");
		float verti = Input.GetAxis("Vertical");
		
		if (verti > 0.1)
		{
			if(!walksound.isPlaying)
			{
				walksound.Play();
			}
			Animat.SetInteger("ANI_STATE", ANI_STATE.WALK_STATE);
			transform.Translate(0, 0, verti * RunSPD * Time.deltaTime);
		}
		else if (verti < -0.1)
		{
			if (!walksound.isPlaying)
			{
				walksound.Play();
			}
			Animat.SetInteger("ANI_STATE", ANI_STATE.WALK_STATE);
			transform.Translate(0, 0, verti * Time.deltaTime);
		}
		else if (horizon == (int)ANI_STATE.IDLE_STATE && verti == ANI_STATE.IDLE_STATE)
		{
			if (walksound.isPlaying)
			{
				walksound.Stop();
			}
			Animat.SetInteger("ANI_STATE", ANI_STATE.IDLE_STATE);
		}

		if (horizon != 0)
		{
			{
				if (!walksound.isPlaying)
				{
					walksound.Play();
				}
				transform.Translate(horizon * Time.deltaTime, 0, 0);
				Animat.SetInteger("ANI_STATE", ANI_STATE.WALK_STATE);
			}
		}

	}

	private static PlayerMovementKiller _Self;
	public static PlayerMovementKiller Self
	{
		get
		{
			if(!_Self)
			{
				_Self = GameObject.FindObjectOfType(typeof(PlayerMovementKiller))as PlayerMovementKiller;
			}
			return _Self;
		}
	}

	bool IsDash = false;
	IEnumerator Dash()
	{
		IsDash = true;
		int count = 0;
		float savespd;
		savespd = RunSPD;
		RunSPD = RunSPD*2;

		while (true)
		{
			if(count>= DashSPD)
			{
				MainCamera.Self.SetCameraMoveState(CameraState.STOP);
				MoveControll = false;
				RunSPD = savespd;
				break;
			}
			count++;
			yield return null;
		}

		IsDash = false;
	}
}


static class ANI_STATE
{
	public const int IDLE_STATE = 0;
	public const int WALK_STATE = 1;

	public const int KICK_STATE = 2;
	public const int ATTACK_STATE = 3;
	public const int SPECIAL_STATE = 4;
}

static class ActionSTATE
{
	public const int MOVE_STATE = 0;
	public const int ATTACK_STATE = 1;
	public const int SEPCIAL_STATE = 2;
	public const int GETS_STATE = 3;
	public const int KICK_STATE = 4;

}