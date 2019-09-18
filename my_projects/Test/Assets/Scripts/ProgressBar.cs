using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBar : MonoBehaviour
{
    public bool is_vertical = false;
    public int min_value = 0;
    public int max_value = 100;
    public float min_size = 0.2f;
    public float max_size = 5.0f;

    private float t_value = 0f;
    private float inc_value = 0.3f;

    void Start()
    {
        Vector2 new_scale;
        if(is_vertical) 
            new_scale = new Vector2(transform.localScale.x, min_size);
        else
            new_scale = new Vector2(min_size, transform.localScale.y);

        transform.localScale = new_scale;
    }

    public void set_value(float value)
    {
        if(value < min_value)   value = min_value;
        if(value > max_value)   value = max_value;

        /*
        max_size - min_size 100
        x value
         */
        float temp = value * (max_size - min_size) / 100f;

        Vector2 new_scale;
        if(is_vertical) 
            new_scale = new Vector2(transform.localScale.x, temp);
        else
            new_scale = new Vector2(temp, transform.localScale.y);

        transform.localScale = new_scale;
    }

    void Update2()
    {
        t_value += inc_value;
        if(t_value < min_value || t_value > max_value) inc_value *= -1;
        set_value(t_value);
    }
}
