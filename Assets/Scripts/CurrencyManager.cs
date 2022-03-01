using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
	public enum Currency { time=0,
		length=1,
		mass =2,
		temperature =3,
		current=4,
		moles=5,
		luminousIntensity=6,
		mana=7
	}
	internal static Dictionary<int, Currency> currencyFromID = new Dictionary<int, Currency>() {
		[0] = Currency.time ,
		[1] = Currency.length ,
		[2] = Currency.mass ,
		[3] = Currency.temperature ,
		[4] = Currency.current ,
		[5] = Currency.moles ,
		[6] = Currency.luminousIntensity ,
		[7] = Currency.mana };
	internal static Dictionary<Currency,int> IDFromCurrency = currencyFromID.ToDictionary(x => x.Value, x => x.Key);
	internal static Dictionary<Currency, long> currencyValues = new Dictionary<Currency, long>();
	internal static Dictionary<Currency, long> currencyIncrements =  new Dictionary<Currency, long>();

	

	void Awake()
    {
		foreach (Currency currency in Enum.GetValues(typeof(Currency)))
		{
			CurrencyManager.currencyValues.Add(currency, 0);
			CurrencyManager.currencyIncrements.Add(currency, 0);
		}

		CurrencyManager.currencyIncrements[Currency.time] += 1;
		CurrencyDisplay.activateCurrencyDisplay(Currency.time);
	}

	internal static void tickPasses() { tickPasses(1); }
	internal static void tickPasses( int amountOfTicks)
	{
		foreach (Currency currency in Enum.GetValues(typeof(Currency)))
		{
			currencyValues[currency] += currencyIncrements[currency]* amountOfTicks;
		}
		CurrencyDisplay.updateDisplay();
	}
}
