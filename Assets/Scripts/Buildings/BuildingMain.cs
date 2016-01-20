using UnityEngine;
using System.Collections;

public enum BuildingType
{
    // Wood
    Woodstorage,
    PlankStorage,
    FirewoodStorage,
    Sawmill,
    House
}

public abstract class BuildingMain : UnitMainScript {

    public float solidity;
    public BuildingType buildingType;

    public void Build(string unitName, int health, float solidity, BuildingType buildingType)
    {
        Create(unitName, health, UnitType.Building);
        this.solidity = solidity;
        this.buildingType = buildingType;
    }

    public override string HentInfo()
    {
        return "Mangler infometode!";
    }
}
