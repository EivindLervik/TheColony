using UnityEngine;
using System.Collections;

public enum TreeTypes
{
    Birch
}

public class TreeScript : UnitMainScript {

    public float richness;
    private bool down;

	// Use this for initialization
	void Start () {
        down = false;
	}

    public bool Chop()
    {
        health--;
        if(health <= 0)
        {
            down = true;
        }

        return down;
    }

    public float GetRichness(float quantity)
    {
        float retur = quantity;

        if (richness - quantity < 0)
        {
            retur = richness;
            richness = 0.0f;
            Destroy(gameObject, 0.5f);
        }
        else
        {
            richness -= quantity;
        }

        return retur;
    }

    public override string HentInfo()
    {
        return "Health: " + health + "\n"
            + "Richness: " + richness;
    }
}
