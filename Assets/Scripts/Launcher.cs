using UnityEngine;
using System.Collections;

public class Launcher : MonoBehaviour {
	public float maxLauncherSpeed;
	public AudioClip windUp, launch;
	public PhysicsEngine ballToLaunch;

	private float launchSpeed;
	private AudioSource audioSource;
	private float extraSpeedPerFrame;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
		audioSource.clip = windUp;
		extraSpeedPerFrame = (maxLauncherSpeed * Time.fixedDeltaTime) / audioSource.clip.length;
	}

	void OnMouseDown () {
		launchSpeed = 0;
		InvokeRepeating ("IncreaseLaunchSpeed", 0.5f, Time.fixedDeltaTime);
		audioSource.clip = windUp;
		audioSource.Play ();
	}

	void OnMouseUp () {
		CancelInvoke ("IncreaseLaunchSpeed");
		audioSource.Stop ();
		audioSource.clip = launch;
		audioSource.Play ();
		PhysicsEngine newBall = Instantiate (ballToLaunch) as PhysicsEngine;
		newBall.transform.parent = GameObject.Find ("Launched Balls").transform;
		Vector3 launchVelocity = new Vector3 (1, 1, 0).normalized * launchSpeed;
		newBall.velocityVector = launchVelocity;
	}

	void IncreaseLaunchSpeed () {
		if (launchSpeed <= maxLauncherSpeed) {
			launchSpeed += extraSpeedPerFrame;
		}
	}
}