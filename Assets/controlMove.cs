using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controlMove : MonoBehaviour {

    private RectTransform rts;
    public float speed = 2.0f;
    public RawImage bg;
    private Texture2D te;
    public bool canControl;
    private Vector2 old;
    private Vector2 current;
	// Use this for initialization
	void Start () {
        rts = gameObject.GetComponent<RectTransform>();
        te = bg.texture as Texture2D;
        
    }
	
	// Update is called once per frame
	void Update () {
        old = rts.anchoredPosition;
        if (canControl)
        {
            if (Input.GetKey(KeyCode.W))
            {
                rts.anchoredPosition += new Vector2(0, 1) * speed;
            }
            if (Input.GetKey(KeyCode.S))
            {
                rts.anchoredPosition -= new Vector2(0, 1) * speed;
            }
            if (Input.GetKey(KeyCode.A))
            {
                rts.anchoredPosition -= new Vector2(1, 0) * speed;
            }
            if (Input.GetKey(KeyCode.D))
            {
                rts.anchoredPosition += new Vector2(1, 0) * speed;
            }
            
        }

        
        PixelsDetected();

    }





    private void PixelsDetected()
    {
        int x;
        int y;
        Color color=te.GetPixel((int)rts.anchoredPosition.x, (int)rts.anchoredPosition.y);
        if (color == new Color(0, 1, 0))
        {
            canControl = false;
            //while (true)
            //{
            //    float r = 1.5f;
            //    for (int i = 0; i < 359; i++)
            //    {
            //        x = (int)(Mathf.Cos(i) * r + rts.anchoredPosition.x);
            //        y = (int)(Mathf.Sin(i) * r + rts.anchoredPosition.y);
            //        if (te.GetPixel(x, y) != new Color(0, 1, 0))
            //        {
            //            rts.anchoredPosition = new Vector2(x, y);
            //            canControl = true;
            //            return;
            //        }
            //    }
            //    r += 0.5f;
            //} 
            rts.anchoredPosition = old;
        }
        else
        {
            canControl = true;
        }

        
    }
}
