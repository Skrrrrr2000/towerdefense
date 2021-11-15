using UnityEngine;

public class PlayerStats : MonoBehaviour
{

	public static int Money;
	public int startMoney = 400;

	public static float Lives = 10;
	public int startLives = 2;

	public static int Rounds;

	void Start()
	{
		Money = startMoney;
		Lives = startLives;

		Rounds = 0;
	}

}