using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public int PPU = 100;
    float w_sprite = 1024;
    float h_sprite = 768;

    // public enum BoundaryLocation 
	// { 
	// 	LEFT, TOP, RIGHT, BOTTOM
	// };
	// public BoundaryLocation direction;

    public Rigidbody2D sprite_R;
    public Rigidbody2D sprite_G;
    public Rigidbody2D sprite_B;

    private Vector2 pos_R;
    private Vector2 pos_G;
    private Vector2 pos_B;

    void debug_print(string text)
    {
        print(text);
    }

    void Start()
    {
        //debug_print("W: " + w_sprite / PPU);
        //debug_print("H: " + h_sprite / PPU);

        float temp_h = h_sprite / PPU;
        float R_h = -temp_h;
        float G_h = 0;
        float B_h = temp_h;

        sprite_R.MovePosition(new Vector2(0, R_h));
        sprite_G.MovePosition(new Vector2(0, G_h));
        sprite_B.MovePosition(new Vector2(0, B_h));

        pos_R = sprite_R.position;
        pos_G = sprite_G.position;
        pos_B = sprite_B.position;

        debug_print("R: pos_x " + sprite_R.transform.position.x);
        debug_print("G: pos_x " + sprite_G.transform.position.x);
        debug_print("B: pos_x " + sprite_B.transform.position.x);

        debug_print("R: pos_y " + sprite_R.transform.position.y);
        debug_print("G: pos_y " + sprite_G.transform.position.y);
        debug_print("B: pos_y " + sprite_B.transform.position.y);

        debug_print("W: " + Camera.main.pixelWidth);
        debug_print("H: " + Camera.main.pixelHeight);
    }

    void Update()
    {

    }
}
