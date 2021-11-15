using System.Collections;
using UnityEngine;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
	string[] tags = new string[] { "simple", "heavy", "fast", "flyin" };

	ObjectPooler objectPooler;

	public static int EnemiesAlive = 0;

	public static int EnemyDamage;
	public static int EnemyHealth;
	public static int EnemySpeed;

	public Wave[] waves;

	public Transform spawnPoint;

	public float timeBetweenWaves = 3f;
	private float countdown = 2f;

	[SerializeField] TMP_Text WaveLevelHud;
	public TMP_Text lives;
	[SerializeField] TMP_Text lifeBonusText;
	[SerializeField] TMP_Text lifeBonusCostText;

	public static int waveIndex = 1;

	private float LifeBonus = 1f;
	private int LifeBonusCost = 100;

	GameManager gameManager;
    private void Start()
    {
		objectPooler = ObjectPooler.Instance;
		WaveLevelHud.text = waveIndex.ToString();
		lives.text = PlayerStats.Lives.ToString();
		lifeBonusText.text = LifeBonus.ToString();
		lifeBonusCostText.text = LifeBonusCost.ToString();
		gameManager = GetComponent<GameManager>();

	}

    void Update()
	{

        if (EnemiesAlive > 0)
        {
			return;
        }
		if (countdown <= 0f)
		{
			StartCoroutine(SpawnWave());
			countdown = timeBetweenWaves;
			return;
		}

		countdown -= Time.deltaTime;

	}

	IEnumerator SpawnWave()
	{
        if (PlayerStats.Lives < 10)
        {
			PlayerStats.Lives += LifeBonus;
			lives.text = PlayerStats.Lives.ToString();
		}
		PlayerStats.Rounds++;
		WaveLevelHud.text = waveIndex.ToString();
		Wave wave = waves[Random.Range(0,4)];
		EnemyDamage = wave.enemyDamage;
		EnemySpeed = wave.enemySpeed;
		EnemyHealth = wave.enemyHealth;

		for (int i = 0; i < Random.Range(waveIndex, waveIndex + 10); i++)
		{
			SpawnEnemy(wave.enemy);
			yield return new WaitForSeconds(1f / wave.rate);
		}
		waveIndex++;
		wave.enemyDamage += 1;
		wave.enemyHealth += Random.Range(1,4) * 25;
		wave.enemySpeed += Random.Range(1,3);
	}

	void SpawnEnemy(GameObject enemy)
	{
		objectPooler.SpawnFromPool(tags[Random.Range(0, tags.Length)], spawnPoint.position, Quaternion.identity);
		EnemiesAlive++;
	}

	public void UpgradeLife()
    {
        if (PlayerStats.Money >= LifeBonusCost)
        {
		PlayerStats.Money -= LifeBonusCost;
		gameManager.money.text = PlayerStats.Money.ToString();
		LifeBonus += 0.5f;
		lifeBonusText.text = LifeBonus.ToString();
		LifeBonusCost += 100;
        }
	}
}
