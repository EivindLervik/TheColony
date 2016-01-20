using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UnitSystem : MonoBehaviour {


    public GameObject treeModelP;
    public static GameObject treeModel;
    private static List<SkogScript> skoger;

	// Use this for initialization
	void Start () {

        // Forest
        treeModel = treeModelP;
        print("GENERERER: Skog");
        skoger = new List<SkogScript>();
        GameObject skog = new GameObject("Skog");
        skog.transform.position = new Vector3(-25.0f, 0.0f, 25.0f);
        SkogScript ss = skog.AddComponent<SkogScript>();
        ss.Generate(treeModel, skog.transform);
        skog.transform.SetParent(transform);
        skoger.Add(ss);
    }

    public static TreeScript ClosestTree(Vector3 pos)
    {
        float minDist = Mathf.Infinity;
        SkogScript skog = null;
        foreach (SkogScript curr in skoger)
        {
            float dist = Vector3.Distance(curr.transform.position, pos);
            if (dist < minDist)
            {
                minDist = dist;
                skog = curr;
            }
        }

        return skog.ClosestTree(pos);
    }

    public static TreeScript ClosestBuilding(Vector3 pos)
    {
        float minDist = Mathf.Infinity;
        SkogScript skog = null;
        foreach (SkogScript curr in skoger)
        {
            float dist = Vector3.Distance(curr.transform.position, pos);
            if (dist < minDist)
            {
                minDist = dist;
                skog = curr;
            }
        }

        return skog.ClosestTree(pos);
    }
}
