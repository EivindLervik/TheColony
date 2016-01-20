using UnityEngine;
using System.Collections;

public class Envirnoment : MonoBehaviour {

    private Weather weather;
    private TOD tod;

	// Use this for initialization
	void Start () {
        weather = GetComponent<Weather>();
        tod = GetComponentInChildren<TOD>();
	}
	
	// Update is called once per frame
	void Update () {
        ManualWeather();
	}

    private void ManualWeather()
    {
        if (Input.GetKey(KeyCode.C))
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                weather.SetRain(0.1f);
            }
            else if (Input.GetKeyDown(KeyCode.N))
            {
                weather.SetNice();
            }
        }
    }
}
