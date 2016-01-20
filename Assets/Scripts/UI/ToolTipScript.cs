using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ToolTipScript : MonoBehaviour {

    public Vector2 offset;

    private Text tekst;
    private bool hidden;
    private Vector2 hidePos;

    // Use this for initialization
    void Start () {
        tekst = GetComponentInChildren<Text>();
        hidden = true;
        hidePos = new Vector2(0.0f, 10000.0f);
    }
	
	// Update is called once per frame
	void Update () {
        if (!hidden)
        {
            transform.position = ((Vector2)Input.mousePosition) + offset;
        }else
        {
            transform.position = hidePos;
        }
    }

    public void Activate(string t)
    {
        hidden = false;
        tekst.text = t;
    }

    public void DeActivate()
    {
        hidden = true;
        
    }
}
