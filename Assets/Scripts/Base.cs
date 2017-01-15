using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour {
	public bool isDead { get; private set; }

	public int health;

	private Animator animator;

	void Start()
	{
		isDead = false;

		animator = this.GetComponent<Animator>();
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.tag == "enemy")
		{
			health--;
		}

		if(health <= 0)
		{
			isDead = true;
			animator.SetBool("isDead", true);
			this.GetComponent<Collider2D>().enabled = false;
			Destroy(gameObject, animator.GetCurrentAnimatorStateInfo(0).length);
		}
	}
}
