using UnityEngine;

public class BuildManager : MonoBehaviour
{

	public static BuildManager instance;

	[SerializeField] GameObject TurretPlacementText;

	private GameObject turretToBuild;

	public GameObject[] TowerPrefab;
	void Awake()
	{
		if (instance != null)
		{
			return;
		}
		instance = this;
	}

    private void Start()
    {
		turretToBuild = TowerPrefab[0];
    }

    public GameObject GetTurretToBuild()
    {
        if (Towers.turretPlacementCount >= 5)
        {
			TurretPlacementText.SetActive(false);
			Time.timeScale = 1;
			turretToBuild = TowerPrefab[1];
        }
		return turretToBuild;
	}
}
