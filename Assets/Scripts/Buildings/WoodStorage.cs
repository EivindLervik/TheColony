using UnityEngine;
using System.Collections;

public class WoodStorage : BuildingMain {

    public float capacity;
    public float currentInventory;

	public void Build(string unitName, int health, float solidity, BuildingType buildingType, float capacity)
    {
        Build(unitName, health, solidity, buildingType);
        this.capacity = capacity;
        currentInventory = 0.0f;
    }

    public float Insert(float inn)
    {
        float retur = 0.0f;

        if(currentInventory+inn > capacity)
        {
            retur = currentInventory+inn - capacity;
            currentInventory = capacity;
        }
        else
        {
            currentInventory += inn;
        }

        return retur;
    }

    public float Withdraw(float ut)
    {
        float retur = ut;

        if(currentInventory-ut < 0)
        {
            retur = currentInventory;
            currentInventory = 0.0f;
        }
        else
        {
            currentInventory -= ut;
        }

        return retur;
    }

    public override string HentInfo()
    {
        return "Health: " + health + "\n"
            + "Solidity: " + solidity + "\n"
            + "Building type: " + buildingType + "\n\n"
            + "Capacity: " + capacity + "\n"
            + "Current inventory: " + currentInventory;
    }
}
