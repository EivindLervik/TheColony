using UnityEngine;
using System.Collections;

public class Weather : MonoBehaviour {

    private float fogDensity;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        RenderSettings.fogDensity = Mathf.Lerp(RenderSettings.fogDensity, fogDensity, 0.01f);
	}

    public void SetRain(float magnitude)
    {
        fogDensity = magnitude;
    }

    public void SetNice()
    {
        fogDensity = 0.0f;
    }
}
