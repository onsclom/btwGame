using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speedPowerup : MonoBehaviour
{
    public playerController player;
    // Start is called before the first frame update
    private Color activeColor;
    public Color inactiveColor;
    private bool active = true;
    public float resetTime = 3f;
    private float curTime = 0f;
    void Start()
    {
        activeColor = GetComponent<SpriteRenderer>().color;
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
            GetComponent<SpriteRenderer>().color = activeColor;
        else
            GetComponent<SpriteRenderer>().color = inactiveColor;

        if (!active)
        {
            curTime += Time.deltaTime;
            if (curTime > resetTime)
            {
                curTime = 0;
                active = true;
            }
        }
    }

    private void OnMouseEnter() 
    {
        if (active)
        {
            player.speedup();
            active = false;
        }
    }
}
