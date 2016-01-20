using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SkogScript : MonoBehaviour {

    public Transform treesParent;
    public GameObject treeModel;
    public List<TreeScript> trees;
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Generate(GameObject tM, Transform tP)
    {
        treeModel = tM;
        treesParent = tP;
        trees = new List<TreeScript>();

        int forestWidth = 25;
        int forestLength = 25;

        for (int x = -forestWidth; x <= forestWidth; x=x+2)
        {
            for (int z = -forestLength; z <= forestLength; z=z+2)
            {
                if (Mathf.Floor(Random.Range(0.0f, 20.0f)) == 0.0f)
                {
                    GameObject nytTre = (GameObject)Instantiate(treeModel, new Vector3(treesParent.position.x + x, 0.0f, treesParent.position.z + z), Quaternion.identity);
                    nytTre.transform.SetParent(treesParent);
                    trees.Add(nytTre.GetComponent<TreeScript>());
                }
            }
        }
    }

    public TreeScript ClosestTree (Vector3 pos){
        float minDist = Mathf.Infinity;
        TreeScript tree = null;
        foreach(TreeScript tre in trees)
        {
            float dist = Vector3.Distance(tre.transform.position, pos);
            if (dist < minDist)
            {
                minDist = dist;
                tree = tre;
            }
        }

        return tree;
    }
}
