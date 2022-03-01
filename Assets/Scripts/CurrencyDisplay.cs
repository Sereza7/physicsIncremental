using System.Collections;
using System.Collections.Generic;
using System;
using TMPro;
using UnityEngine;

public class CurrencyDisplay : MonoBehaviour
{
	
	private static GameObject[] currencyLabels;
	private static TextMeshProUGUI[] currencyTexts;
	

    void Awake()
    {
		CurrencyDisplay.currencyLabels = new GameObject[8];
		CurrencyDisplay.currencyTexts = new TextMeshProUGUI[8];
		Debug.Log(transform.childCount);
		for (int i = 0; i < transform.childCount; i++)
		{
			CurrencyDisplay.currencyLabels[i] = transform.GetChild(i).gameObject;
			CurrencyDisplay.currencyTexts[i] = CurrencyDisplay.currencyLabels[i].GetComponent<TextMeshProUGUI>();
		}
    }

	internal static void updateDisplay()
	{
		for (int i = 0; i < currencyLabels.Length; i++)
		{
			CurrencyManager.Currency currency = CurrencyManager.currencyFromID[i];
			string currencyName = Enum.GetName(typeof(CurrencyManager.Currency), currency);
			string currencyValue = CurrencyManager.currencyValues[currency].ToString();
			currencyTexts[i].text = currencyName +  ": " + currencyValue;
		}
	}
	internal static void activateCurrencyDisplay(CurrencyManager.Currency currency) { activateCurrencyDisplay(currency, true); }
	internal static void activateCurrencyDisplay(CurrencyManager.Currency currency,bool setActive)
	{
		currencyLabels[CurrencyManager.IDFromCurrency[currency]].SetActive(setActive);
	}
}
