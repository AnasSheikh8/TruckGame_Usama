using UnityEngine;

using CP.ProRoad;
using CP.Logger;

/// <summary>
/// Simple example script for converting OSM file to ProRoad
/// </summary>
public class OSM2ProRoad : MonoBehaviour
{
	// osm file
	public TextAsset osmFile = null;
	
	// scale of the map
	public float scale = 1;
	
	// width of the road(s)
	public float width = 2;
	
	// elevation samples frequency (in meters)
	public float elevation = 50;
	
	// road material
	public Material material = null;

#if UNITY_EDITOR
	/// <summary>
	/// Parse OSM file and create road network
	/// </summary>
	public void CreateRoads()
	{
		if (osmFile == null)
		{
			Log.Warning("Missing OSM file");
			return;
		}
		OSMParser parser = new OSMParser(osmFile);

		int order = 1;
		foreach (var way in parser.roads)
		{
			if (way.NodeIDs.Count < 2)
			{
				continue;
			}

			// create proroad object
			GameObject go = new GameObject(string.Format("ProRoad_{0} ({1})", order, way.roadType));
			// GameObject go = new GameObject(string.Format("ProRoad_{0}", n));
			ProRoad road = go.AddComponent<ProRoad>();

			Transform markers = go.transform.Find("Markers");

			//delete automatically generated markers
			for (int i = markers.childCount - 1; i >= 0; i--)
			{
				DestroyImmediate(markers.GetChild(i).gameObject);
			}

			// set basic parameters
			road.width = width;
			road.indentation = road.width * 2;
			road.shoulder = 1;
			road.detailClearence = road.width + 1;
			road.treeClearence = road.width + 4;

			// add higher order to the less important roads
			if (way.roadType == "motorway")
			{
				road.order = order;
			}
			else if (way.roadType == "trunk")
			{
				road.order = order + 1000;
			}
			else if (way.roadType == "primary")
			{
				road.order = order + 2000;
			}
			else if (way.roadType == "secondary")
			{
				road.order = order + 3000;
			}
			else if (way.roadType == "tertiary")
			{
				road.order = order + 4000;
			}
			else if (way.roadType == "unclassified")
			{
				road.order = order + 5000;
			}
			else if (way.roadType == "residential")
			{
				road.order = order + 6000;
			}
			else
			{
				road.order = order + 7000;
			}
			order++;

			//set road material
			road.SetBaseMaterial(material);

			//if the first and last node is same, the road is circular
			bool closed = (way.NodeIDs.Count > 2 && way.NodeIDs[0] == way.NodeIDs[way.NodeIDs.Count - 1]);

			// create road path based on nodes
			for (int i = 0; i < way.NodeIDs.Count - 1; i++)
			{
				OsmNode p1 = parser.nodes[way.NodeIDs[i]];
				OsmNode p2 = parser.nodes[way.NodeIDs[i + 1]];

				Vector3 s1 = (p1 - parser.center) * scale;
				Vector3 s2 = (p2 - parser.center) * scale;

				//move points for better junctions
				Vector3 v = (s1 - s2);
				Vector3 delta = v.normalized * (width / 2.0f);
				if (v.magnitude > width * 2)
				{
					if (i > 0)
					{
						s1 -= delta;
					}
					if (i < way.NodeIDs.Count - 2)
					{
						s2 += delta;
					}
				}
				if (!closed)
				{
					if (i == 0)
					{
						s1 += delta;
					}
					if (i == (way.NodeIDs.Count - 2))
					{
						s2 -= delta;
					}
				}

				GameObject marker1 = new GameObject("Marker");
				marker1.transform.position = GetTerrainPosition(s1);
				marker1.transform.SetParent(markers, true);
				Marker m1 = marker1.GetComponent<Marker>();
				if (m1 == null)
				{
					m1 = marker1.AddComponent<Marker>();
				}
				m1.start = true; //straight line start point
				m1.elevationResolution = Mathf.RoundToInt((s1 - s2).magnitude / elevation);

				GameObject marker2 = new GameObject("Marker");
				marker2.transform.position = GetTerrainPosition(s2);
				marker2.transform.SetParent(markers, true);
				Marker m2 = marker2.GetComponent<Marker>();
				if (m2 == null)
				{
					m2 = marker2.AddComponent<Marker>();
				}
				m2.end = true; //straight line end point

				//set transform rotations for straight line
				marker1.transform.LookAt(marker2.transform.position);
				marker1.transform.rotation = Quaternion.Euler(0, marker1.transform.eulerAngles.y + 270, 0);
				marker2.transform.rotation = marker1.transform.rotation;
			}

			//set closed flag after the markers
			road.closed = closed;
		}
	}

	/// <summary>
	/// Get terrain height
	/// </summary>
	public Vector3 GetTerrainPosition(Vector3 position)
	{
		Terrain[] activeTerrains = Terrain.activeTerrains;
		for (int i = 0; i < activeTerrains.Length; i++)
		{
			Terrain t = activeTerrains[i];

			Vector3 pos = t.transform.position;
			Vector3 size = t.terrainData.size;

			if (position.x >= pos.x && position.z >= pos.z
				&& position.x <= (pos.x + size.x) && position.z <= (pos.z + size.z))
			{
				position.y = t.SampleHeight(position);
			}
		}
		return position;
	}
	
#endif

} //class
