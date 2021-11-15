using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
	private Transform target;
	private int wavepointIndex = 0;
	private float speed = 5;
	WaveSpawner waveSpawner;
	[SerializeField] GameObject DamagePalaceParticle;
	[SerializeField] int nextWaveIndex;

	void Start()
	{
		waveSpawner = FindObjectOfType<WaveSpawner>();
		target = Waypoints.points[0];
		speed = WaveSpawner.EnemySpeed;
	}

	void Update()
	{
		Vector3 dir = target.position - transform.position;
		transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

		if (Vector3.Distance(transform.position, target.position) <= 0.4f)
		{
			GetNextWaypoint();
		}
	}

	void GetNextWaypoint()
	{
		if (wavepointIndex >= Waypoints.points.Length - 1)
		{
			EndPath();
			waveSpawner.lives.text = PlayerStats.Lives.ToString();
			
			return;
		}
		
		wavepointIndex+= nextWaveIndex;
		target = Waypoints.points[wavepointIndex];
	}

	void EndPath()
	{
		Instantiate(DamagePalaceParticle, transform.position, transform.rotation);
		PlayerStats.Lives -= WaveSpawner.EnemyDamage;
		WaveSpawner.EnemiesAlive--;
		Destroy(gameObject);
	}
}
