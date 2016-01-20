using UnityEngine;
using System.Collections;

public enum UnitType{
    Building, Person, Tree
}

public abstract class UnitMainScript : MonoBehaviour {

    public string unitName;
    public int health;
    public UnitType type;

    public void Create(string unitName, int health, UnitType type)
    {
        this.unitName = unitName;
        this.health = health;
        this.type = type;
    }

    public virtual string HentInfo()
    {
        return "Mangler infometode!";
    }
}
