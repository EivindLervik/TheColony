using UnityEngine;
using System.Collections;

public class InteractionScript : MonoBehaviour {

    public GUIHandeler gui;

    // Selected
    private UnitMainScript selected;
    private UnitMainScript hoverOver;

    public bool canInteract;

    private Camera kamera;
    private bool isOverUnit;

	void Start () {
        kamera = GetComponentInChildren<Camera>();
    }

	void Update () {
        Buttons();
        ClickOn();
    }

    private void Buttons()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (canInteract)
            {
                if (isOverUnit)
                {
                    selected = hoverOver;
                    gui.SetUnitInformation(selected);
                }
                else
                {
                    if (gui.GetToolTipEnabled())
                    {
                        selected = null;
                        gui.HideUnitInformation();
                    }
                    else
                    {
                        // Nothing, yet...
                    }
                }
            }
        }

        if (Input.GetButtonDown("Build"))
        {
            gui.ActivateBuildMenu();
        }
    }

    private void ClickOn()
    {
        RaycastHit hit;
        Ray ray = kamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.tag.Equals("Clickable"))
            {
                if (gui.GetToolTipEnabled())
                {
                    if (!isOverUnit)
                    {
                        isOverUnit = true;
                        hoverOver = hit.transform.gameObject.GetComponentInParent<UnitMainScript>();
                        gui.ActivateToolTip(hoverOver.unitName);
                        gui.ChangePointer("Unit");
                    }
                }
                else
                {
                    isOverUnit = false;
                    hoverOver = null;
                    gui.DeActivateToolTip();
                    gui.ChangePointer("Normal");
                }
            }
            else if (isOverUnit)
            {
                isOverUnit = false;
                hoverOver = null;
                gui.DeActivateToolTip();
                gui.ChangePointer("Normal");
            }
        }
    }
}
