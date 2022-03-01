using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
	public double tickLength = 0.2f;
	private System.DateTime lastTickTime = System.DateTime.Now;

	private static Clock _instance;
	public static Clock Instance { get { return _instance; } }

	private void Awake()
	{
		if (_instance != null && _instance != this)
		{
			Destroy(this.gameObject);
		}
		else
		{
			_instance = this;
			InvokeRepeating("tickPasses", 0f, (float)tickLength);
		}
	}
	private void tickPasses() { tickPasses(1); }
	private void tickPasses(int tickCount)
	{
		CurrencyManager.tickPasses(tickCount);
	}
	internal void Pause()
	{
		Debug.Log("Paused Game");
		this.CancelInvoke();
	}
	internal void Unpause()
	{
		Debug.Log("Unpaused Game");
		if (!this.IsInvoking())
		{
			InvokeRepeating("tickPasses", 0f, (float)tickLength);
		}
	}
	void OnApplicationPause(bool pauseStatus)
	{
		if (pauseStatus)
		{
			lastTickTime = System.DateTime.Now;
			Pause();
		}
		else
		{
			int afkTicks = Mathf.RoundToInt((float)(System.DateTime.Now.Subtract(lastTickTime).TotalSeconds / tickLength));
			Debug.Log("Played "+ afkTicks + " afk time ticks.");
			tickPasses(afkTicks);
			Unpause();
		}
	}
}
