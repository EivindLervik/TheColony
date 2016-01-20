using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UnitInformation : MonoBehaviour {

    public Text unitName;
    public Text infoText;

    private GUIHandeler gui;

	// Use this for initialization
	void Start () {
        gui = GetComponentInParent<GUIHandeler>();
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public void SetInfo(UnitMainScript u)
    {
        unitName.text = u.unitName;
        infoText.text = u.HentInfo();
    }
}
