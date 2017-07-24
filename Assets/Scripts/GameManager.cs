using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	private int selectedZombieIndex;
	private GameObject selectedZombie;
	private int score = 0;

	public Text scoreText;

	public List<GameObject> zombieList;

	public Vector3 selectedSize;
	public Vector3 defaultSize;

	public Vector3 forceToApply;

	// Use this for initialization
	void Start ()
	{
		if (zombieList.Count > 0)
		{
			selectedZombieIndex = 0;
			SelectZombie(zombieList[selectedZombieIndex]);
		}

		if (scoreText != null)
			scoreText.text = "Score: " + score;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown("left"))
		{
			GetZombieLeft();
		}
		else if (Input.GetKeyDown("right"))
		{
			GetZombieRight();
		}

		if (Input.GetKeyDown("up"))
		{
			PushUpSelectedZombie();
		}
	}

	void GetZombieLeft()
	{
		/* Find the current Left Zombie index */
		if (selectedZombieIndex == 0)
			selectedZombieIndex = zombieList.Count - 1;
		else
			selectedZombieIndex--;

		SelectZombie(zombieList[selectedZombieIndex]);
	}

	void GetZombieRight()
	{
		/* Find the current Right Zombie index */
		selectedZombieIndex++;
		selectedZombieIndex = selectedZombieIndex % zombieList.Count;

		SelectZombie(zombieList[selectedZombieIndex]);
	}

	void SelectZombie(GameObject NewZombie)
	{
		if (selectedZombie != null)
			selectedZombie.transform.localScale = defaultSize;
		
		selectedZombie = NewZombie;
		selectedZombie.transform.localScale = selectedSize;
	}

	void PushUpSelectedZombie()
	{
		Rigidbody rb = selectedZombie.GetComponent<Rigidbody>();
		rb.AddForce(forceToApply, ForceMode.Impulse);
	}

	public void AddScore()
	{
		score++;
		scoreText.text = "Score: " + score;
	}
	
}
