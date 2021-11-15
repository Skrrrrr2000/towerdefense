using UnityEngine;

public class Node : MonoBehaviour
{

	public Color hoverColor;
	public Vector3 positionOffset;

	[HideInInspector]
	public GameObject turret;

	private Renderer rend;
	private Color startColor;


	void Start()
	{
		rend = GetComponent<Renderer>();
		
		startColor = rend.material.color;
	}

	public Vector3 GetBuildPosition()
	{
		return transform.position + positionOffset;
	}

	void OnMouseDown()
	{
		if (turret != null)
		{
			return;
		}
        if (Towers.turretPlacementCount <= 5)	
        {
			Towers.turretPlacementCount++;
			GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
			turret = (GameObject)Instantiate(turretToBuild, GetBuildPosition(), Quaternion.identity);
        }
	}

	
	void OnMouseEnter()
	{
        if (Towers.turretPlacementCount <=5)
        {
		rend.material.color = hoverColor;
        }
	}

	void OnMouseExit()
	{
		rend.material.color = startColor;
	}

}
