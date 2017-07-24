using UnityEngine;
using System.Collections;

public class TileScoreComponent : MonoBehaviour {

	public GameManager gameManager;
	public AudioClip hitSound;

	private AudioSource audioSource;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
	}

	void OnTriggerEnter(Collider other)
	{
		gameManager.AddScore();
		audioSource.PlayOneShot(hitSound);
	}
}
