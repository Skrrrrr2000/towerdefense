using UnityEngine;
public class Bullet : MonoBehaviour
{

	private Transform target;

	public float speed;

	public int damage;

	public GameObject impactEffect;

    private void Start()
    {
		damage = Towers.bulletDamage;
		speed = Towers.bulletSpeed;
    }

    void Update()
	{

		if (target == null)
		{
			Destroy(gameObject);
			return;
		}

		Vector3 dir = target.position - transform.position;
		float distanceThisFrame = speed * Time.deltaTime;

		if (dir.magnitude <= distanceThisFrame)
		{
			HitTarget();
			return;
		}

		transform.Translate(dir.normalized * distanceThisFrame, Space.World);;

	}

	public void Seek(Transform _target)
	{
		target = _target;
	}

	void HitTarget()
	{
		GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
		Destroy(effectIns, 5f);

		Destroy(gameObject);
		Damage(target);
	}

	

	void Damage(Transform enemy)
	{
		Enemy e = enemy.GetComponent<Enemy>();

		if (e != null)
		{
			e.TakeDamage(damage);
		}
	}
		  
}
