using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
	GameManager gameManager;

	private float health;

	public int worth = 50;

	public Image healthBar;

	private bool isDead = false;

	
	void Start()
	{
		gameManager = FindObjectOfType<GameManager>();
		
		health = WaveSpawner.EnemyHealth;
	}

	public void TakeDamage(float amount)
	{
		health -= amount;

		healthBar.fillAmount = health / WaveSpawner.EnemyHealth;

		if (health <= 0 && !isDead)
		{
			Die();
		}
	}


	void Die()
	{
		isDead = true;

		PlayerStats.Money += worth;
		gameManager.money.text =PlayerStats.Money.ToString();

		WaveSpawner.EnemiesAlive--;
		GameManager.KillCount++;
		Destroy(gameObject);
	}

}