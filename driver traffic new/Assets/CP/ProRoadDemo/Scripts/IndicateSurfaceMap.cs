using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

using CP.Logger;
using CP.SurfaceMap;
public class IndicateSurfaceMap : MonoBehaviour {

	/// <summary>
	/// Droplink of UI Text showing the actual SUrfaceType
	/// </summary>
	public Text outText;

	public Transform player;

	private SurfaceMap surfaceMap;

	// Use this for initialization
	void Start () 
	{
		Log.AssertNotNull(player, "Missing player reference.");
		Log.AssertNotNull(outText, "Missing outText reference.");
		surfaceMap = FindObjectOfType<SurfaceMap>();
		Log.AssertNotNull(surfaceMap, "Unable to find SurfaceMap component!");
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(surfaceMap == null || outText == null || player == null)
		{
			return;
		}
		SurfaceType type =	surfaceMap.GetSurfaceType(player.position);
 		string label = type.ToString();
		if(type == SurfaceType.CUSTOM01)
		{
			label = "WATER";
		}
		outText.text = label;
	}
}
