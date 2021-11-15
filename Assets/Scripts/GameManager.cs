using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
	[SerializeField] TMP_Text WaveLevelGameOverScreen;
	[SerializeField] TMP_Text KillCountText;

	public static int KillCount;

	public TMP_Text money;
	public TMP_Text UpgradeCostText;

	private int UpgradeCost = 100;
	public GameObject gameOverUI;
	public GameObject Hud;

	void Start()
	{
		money.text = PlayerStats.Money.ToString();
		UpgradeCostText.text = UpgradeCost.ToString();
		Time.timeScale = 0;
	}

	// Update is called once per frame
	void Update()
	{

		if (PlayerStats.Lives <= 0)
		{
			EndGame();
		}
	}

	void EndGame()
	{
		gameOverUI.SetActive(true);
		Hud.SetActive(false);
		WaveLevelGameOverScreen.text = PlayerStats.Rounds.ToString();
		KillCountText.text = KillCount.ToString();
		Time.timeScale = 0;
	}

	public void UpgradeTowers()
    {
        if (PlayerStats.Money >= UpgradeCost)
        {
			PlayerStats.Money -= UpgradeCost;
			money.text = PlayerStats.Money.ToString();
			Towers.bulletDamage += 50;
			Towers.bulletSpeed += 2;
			UpgradeCost += 50;
			UpgradeCostText.text = UpgradeCost.ToString();
        }

    }

	public void RestartLevel()
    {
		PlayerStats.Lives = 10;
		KillCount = 0;
		WaveSpawner.EnemiesAlive = 0;
		Towers.bulletDamage = 50;
		Towers.bulletSpeed = 15;
		Towers.turretPlacementCount = 0;
		WaveSpawner.waveIndex = 1;
		SceneManager.LoadScene(0);
    }
}