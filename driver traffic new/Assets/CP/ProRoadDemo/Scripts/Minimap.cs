using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

using CP.Logger;

/// <summary>
/// Example class to show how to use minimap and how to display a position on it.
/// </summary>
public class Minimap : MonoBehaviour
{
	/// <summary>
	/// Use the values logged on the Unity Console after exporting the minimap to set minPos and maxPos in the Inspector.
	/// This will offset the player coordinates to the coordinate system of the minimap.
	/// </summary>
	public Vector2 minPos;
	public Vector2 maxPos;

	/// <summary>
	/// Droplink for the player gameobject. Its position will shown on the minimap 
	/// </summary>
	public GameObject player;

	/// <summary>
	/// playerIcon GameObject droplink. Use the provided object or create your own. Image Component is required!
	/// </summary>
	public Image playerIcon;

	private float sizeX;
	private float sizeY;
	private float deltaX;
	private float deltaY;
	
	void Awake()
	{
		Log.AssertNotNull(player, "Missing player GameObject Link !");
		Log.AssertNotNull(playerIcon, "Missing playerIcon GameObject Link !");
		
		Init();
	}

	/// <summary>
	/// Initializing size and delta values and activating the playerIcon to show it on the minimap
	/// </summary>
	public void Init()
	{
		sizeX = gameObject.GetComponent<RectTransform>().sizeDelta.x;
		sizeY = gameObject.GetComponent<RectTransform>().sizeDelta.y;
		deltaX = 0.5f + (minPos.x / (maxPos.x - minPos.x));
		deltaY = 0.5f + (minPos.y / (maxPos.y - minPos.y));
		if(playerIcon != null)
		{
			playerIcon.gameObject.SetActive(true);
		}
	}

	/// <summary>
	/// Offsetting player position to the minimap and updating playerIcon RectTransform with the new coordinates
	/// </summary>
	void Update()
	{
		if(player == null || playerIcon == null)
		{
			return;
		}
		
		Vector3 pos = player.transform.position;
		float x = (pos.x / (maxPos.x - minPos.x) - deltaX) * sizeX;
		float y = (pos.z / (maxPos.y - minPos.y) - deltaY) * sizeY;
		playerIcon.rectTransform.anchoredPosition = new Vector2(x , y);
	}

}//class