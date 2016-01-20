using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GUIHandeler : MonoBehaviour {

    // Cursor
    public Texture2D cursorTextureNormal;
    public Texture2D cursorTextureNoClick;
    public Texture2D cursorTextureUnit;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    // ToolTip
    public GameObject toolTipGO;
    private ToolTipScript toolTip;
    private bool useToolTip;

    //Info display
    public GameObject infoDisplayGO;
    private UnitInformation infoDisplay;
    public Text infoText;

    // Build Mode
    private bool isInBuildMode;
    public GameObject buildMenu;
    public Image buildingSpritePlane;
    public List<GameObject> buildings;
    public List<Sprite> buildingSprites;
    private int currentBuilding;

    void Start () {
        // Set private
        toolTip = toolTipGO.GetComponent<ToolTipScript>();
        infoDisplay = infoDisplayGO.GetComponent<UnitInformation>();

        currentBuilding = 0;
        isInBuildMode = false;
        useToolTip = true;
        DeActivateToolTip();
        ChangePointer("Normal");
        HideUnitInformation();
        buildMenu.SetActive(false);
    }
	
	void Update () {
        
	}

    public void SetToolTipEnabled(bool e)
    {
        useToolTip = e;
    }

    public bool GetToolTipEnabled()
    {
        return useToolTip;
    }

    public void ActivateToolTip(string n)
    {
        if (useToolTip)
        {
            toolTip.Activate(n);
        }
    }

    public void DeActivateToolTip()
    {
        toolTip.DeActivate();
    }

    public void ChangePointer(string type)
    {
        switch (type)
        {
            case "Normal": Cursor.SetCursor(cursorTextureNormal, hotSpot, cursorMode);
                break;
            case "Unit": Cursor.SetCursor(cursorTextureUnit, hotSpot, cursorMode);
                break;
            case "NoClick": Cursor.SetCursor(cursorTextureNoClick, hotSpot, cursorMode);
                break;
            default: print("Woops!");
                break;
        }
        
    }

    public void SetUnitInformation(UnitMainScript u)
    {
        infoDisplayGO.SetActive(true);
        StopCoroutine("InfoUpdate");
        StartCoroutine("InfoUpdate", u);
    }

    IEnumerator InfoUpdate(UnitMainScript u)
    {
        while (infoDisplayGO.activeSelf)
        {
            infoDisplay.SetInfo(u);
            yield return new WaitForSeconds(1.0f);
        }
    }

    public void HideUnitInformation()
    {
        infoDisplayGO.SetActive(false);
    }

    public void ActivateBuildMenu()
    {
        bool a = true;
        if (isInBuildMode)
        {
            a = false;
        }
        HideUnitInformation();
        buildMenu.SetActive(a);
        SetToolTipEnabled(!a);
        isInBuildMode = a;
        UpdateBuildingPlane();
    }

    public void SwitchBuilding(int i)
    {
        currentBuilding += i;
        UpdateBuildingPlane();
    }

    private void UpdateBuildingPlane()
    {
        buildingSpritePlane.sprite = buildingSprites[currentBuilding];
    }
}
