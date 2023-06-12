using System;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

/// <summary>
/// Simple OSM parser
/// based on: https://github.com/SimonCuddihy/osm-unity
/// </summary>
public class OSMParser
{
	public Dictionary<ulong, OsmNode> nodes;
	public List<OsmWay> roads;
	public Vector3 center;

	/// <summary>
	/// ctor
	/// </summary>
	public OSMParser(TextAsset osmFile)
	{
		nodes = new Dictionary<ulong, OsmNode>();
		roads = new List<OsmWay>();

		if (osmFile == null)
		{
			return;
		}

		XmlDocument doc = new XmlDocument();
		doc.LoadXml(osmFile.text);

		GetNodes(doc.SelectNodes("/osm/node"));
		GetWays(doc.SelectNodes("/osm/way"));

		if (nodes.Count > 0 && roads.Count > 0 && roads[0].NodeIDs.Count > 0 && nodes.ContainsKey(roads[0].NodeIDs[0]))
		{
			OsmNode n = nodes[roads[0].NodeIDs[0]];

			Bounds bounds = new Bounds(n, Vector3.zero);
			foreach(OsmWay road in roads)
			{
				foreach (ulong id in road.NodeIDs)
				{
					bounds.Encapsulate(nodes[id]);
				}
			}
			center = bounds.center;
		}
	}

	/// <summary>
	/// Parse roads
	/// </summary>
	void GetWays(XmlNodeList xmlNodeList)
	{
		foreach (XmlNode node in xmlNodeList)
		{
			OsmWay way = new OsmWay(node);
			if (way.isRoad)
			{
				roads.Add(way);
			}
		}
	}

	/// <summary>
	/// Parse nodes
	/// </summary>
	void GetNodes(XmlNodeList xmlNodeList)
	{
		foreach (XmlNode n in xmlNodeList)
		{
			OsmNode node = new OsmNode(n);
			nodes[node.ID] = node;
		}
	}

} //class

public class BaseOsm
{
	/// <summary>
	/// gets the attributes of type string in the osm xml(txt) file
	/// and converts and returns the type specified by the function call
	/// </summary>
	protected T GetAttribute<T>(string attrName, XmlAttributeCollection attributes)
	{
		string strValue = attributes[attrName].Value;
		return (T)Convert.ChangeType(strValue, typeof(T));
	}
}

public class OsmWay : BaseOsm
{
	public ulong ID { get; private set; }

	public List<ulong> NodeIDs { get; private set; }

	public string roadType;

	public bool isRoad = false;

	public OsmWay(XmlNode node)
	{
		NodeIDs = new List<ulong>();

		ID = GetAttribute<ulong>("id", node.Attributes);

		XmlNodeList nds = node.SelectNodes("nd");
		foreach (XmlNode n in nds)
		{
			ulong refNo = GetAttribute<ulong>("ref", n.Attributes);
			NodeIDs.Add(refNo);
		}

		XmlNodeList tags = node.SelectNodes("tag");
		foreach (XmlNode t in tags)
		{
			string key = GetAttribute<string>("k", t.Attributes);
			if (key == "highway")
			{
				isRoad = true;
				roadType = GetAttribute<string>("v", t.Attributes);
			}
		}
	}
}

public class OsmNode : BaseOsm
{
	public ulong ID { get; private set; }

	public float X { get; private set; }

	public float Y { get; private set; }

	// implicit conversion between OsmNode and Vector3
	public static implicit operator Vector3(OsmNode node)
	{
		return new Vector3(node.X, 0, node.Y);
	}

	public OsmNode(XmlNode node)
	{
		ID = GetAttribute<ulong>("id", node.Attributes);
		float latitude = GetAttribute<float>("lat", node.Attributes);
		float longitude = GetAttribute<float>("lon", node.Attributes);

		X = (float)MercatorProjection.lonToX(longitude);
		Y = (float)MercatorProjection.latToY(latitude);
	}
}
