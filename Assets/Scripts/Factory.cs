using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour
{
	public Vector4 dimensions = Vector4.one;
	private GameObject[,,,] factoryCells;
	public GameObject emptyCell;
	public float sizeCells = 0.8f;

	// Start is called before the first frame update
	void Start()
    {
		updateSize();
		factoryCells = new GameObject[Mathf.RoundToInt(dimensions.x), 
			Mathf.RoundToInt(dimensions.y), 
			Mathf.RoundToInt(dimensions.z), 
			Mathf.RoundToInt(dimensions.w)];
		//Instantiate all the empty slots for the factory
		for (int i = 0; i < factoryCells.GetLength(0); i++)
		{
			for (int j = 0; j < factoryCells.GetLength(1); j++)
			{
				for (int k = 0; k < factoryCells.GetLength(2); k++)
				{
					for (int l = 0; l < factoryCells.GetLength(3); l++)
					{
						factoryCells[i, j, k, l] = GameObject.Instantiate(emptyCell, transform.position,transform.rotation,transform.parent);
						factoryCells[i, j, k, l].transform.position = transform.position-transform.localScale/2 + Vector3.one/2+ new Vector3(i, j, k);
						//position of the factory, shift for scales and adapt with coordinates
						factoryCells[i, j, k, l].transform.localScale = new Vector3(sizeCells, sizeCells, sizeCells);
					}
				}
			}
		}
	}

	private void updateSize()
	{
		this.transform.localScale = new Vector3(dimensions.x, dimensions.y, dimensions.z);
	}
}
