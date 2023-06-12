using UnityEngine;
using UnityEditor;

using CP.Logger;
using CP.ProRoad;

/// <summary>
/// Custom editor script of OSM2ProRoad
/// </summary>
[CustomEditor(typeof(OSM2ProRoad))]
public class OSM2ProRoadEditor : Editor
{
	/// <summary>
	/// Draw inspector and process OSM file
	/// </summary>
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();

		if (GUILayout.Button("Clear"))
		{
			ProRoad[] roads = FindObjectsOfType(typeof(ProRoad)) as ProRoad[];
			for (int i = 0; i < roads.Length; i++)
			{
				DeleteMeshes(roads[i].meshes);
				DestroyImmediate(roads[i].gameObject);
			}
			AssetDatabase.Refresh();
		}

		OSM2ProRoad osm2ProRoad = (OSM2ProRoad)target;

		//draw road network preview
		if (GUILayout.Button("Preview"))
		{
			OSMParser parser = new OSMParser(osm2ProRoad.osmFile);

			foreach (var way in parser.roads)
			{
				for (int i = 0; i < way.NodeIDs.Count - 1; i++)
				{
					OsmNode p1 = parser.nodes[way.NodeIDs[i]];
					OsmNode p2 = parser.nodes[way.NodeIDs[i + 1]];

					Vector3 s1 = (p1 - parser.center) * osm2ProRoad.scale;
					Vector3 s2 = (p2 - parser.center) * osm2ProRoad.scale;
					Debug.DrawLine(osm2ProRoad.GetTerrainPosition(s1), osm2ProRoad.GetTerrainPosition(s2), Color.blue, 4);
				}
			}
		}

		//create road network
		if (GUILayout.Button("Create ProRoad objects"))
		{
			osm2ProRoad.CreateRoads();
		}
	}

	/// <summary>
	/// Delete all mesh assets and gameobjects under transform
	/// </summary>
	void DeleteMeshes(Transform tr)
	{
		for (int i = tr.childCount - 1; i >= 0; i--)
		{
			GameObject obj = tr.GetChild(i).gameObject;
			MeshFilter meshFilter = obj.GetComponent<MeshFilter>();
			if (meshFilter != null)
			{
				string assetPath = AssetDatabase.GetAssetPath(meshFilter.sharedMesh);
				if (!string.IsNullOrEmpty(assetPath))
				{
					AssetDatabase.DeleteAsset(assetPath);
				}
			}
			GameObject.DestroyImmediate(obj);
		}
	}

} //class


