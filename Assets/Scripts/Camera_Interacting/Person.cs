using UnityEngine;
using System.Collections;

public enum Work
{
    None, Lumberjack, Woodcrafter, Woodbuilder, Transporter
}

public class Person : UnitMainScript {

    // Pathfinding
    private NavMeshAgent agent;

    // General
    public string firstname;
    public string surename;
    public Work work;
    public int food;
    private UnitMainScript father;
    private UnitMainScript mother;
    public GameObject home;

    // XP
    public long loggingXP;
    public long woodcraftingXP;
    public long woodbuildingXP;


    void Start () {
        unitName = firstname + " " + surename;
        agent = GetComponent<NavMeshAgent>();
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            CheckWork();
        }
    }

    public void Birth(string unitName, int health, float solidity, UnitMainScript father, UnitMainScript mother)
    {
        Create(unitName, health, UnitType.Person);
        this.father = father;
        this.mother = mother;
    }


    // Workpart
    public void CheckWork()
    {
        switch (work)
        {
            case Work.Lumberjack: GetWood();
                break;
        }
    }

    private void GetWood()
    {
        TreeScript cT = UnitSystem.ClosestTree(transform.position);
        agent.SetDestination(cT.transform.position);
    }
}
