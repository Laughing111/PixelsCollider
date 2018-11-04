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
    Texture2D playerTe;
    private int playerWidth;
    private int playerHeight;
    public ParticleSystem par;
    // Use this for initialization
    void Start () {
        rts = gameObject.GetComponent<RectTransform>();
        te = bg.texture as Texture2D;
        playerTe = (rts.GetComponent<RawImage>().texture) as Texture2D;
        playerWidth =playerTe.width;
        playerHeight = playerTe.height;
        //Debug.Log(playerWidth+playerHeight);

    }
	
	// Update is called once per frame
	void Update () {
        old = rts.anchoredPosition;
        if (canControl)
        {
            if (Input.GetKey(KeyCode.W))
            {
                rts.anchoredPosition += new Vector2(0, 1) * speed;
                if(!par.isPlaying)
                {
                    par.Play();
                }
                
            }
            if (Input.GetKey(KeyCode.S))
            {
                rts.anchoredPosition -= new Vector2(0, 1) * speed;
                if (!par.isPlaying)
                {
                    par.Play();
                }
            }
            if (Input.GetKey(KeyCode.A))
            {
                rts.anchoredPosition -= new Vector2(1, 0) * speed;
                rts.localScale = new Vector3(-1, 1, 1);
                if (!par.isPlaying)
                {
                    par.Play();
                }
            }
            if (Input.GetKey(KeyCode.D))
            {
                rts.anchoredPosition += new Vector2(1, 0) * speed;
                rts.localScale = new Vector3(1, 1, 1);
                if (!par.isPlaying)
                {
                    par.Play();
                }
            }
            
        }

        
        PixelsDetected();

    }





    private void PixelsDetected()
    {
        int rowStart =(int) rts.anchoredPosition.x - playerWidth / 2;
        int columnStart = (int)rts.anchoredPosition.y - playerHeight / 2;
        int rowEnd = (int)rts.anchoredPosition.x + playerWidth / 2;
        int columnEnd = (int)rts.anchoredPosition.y + playerHeight / 2;
        for(int row=rowStart;row<=rowEnd;row++)
        {
            for(int column= columnStart;column<= columnEnd;column++)
            {
                Color color = te.GetPixel(row, column);
                if (color.a >0)
                {
                    if (color == new Color(0, 1, 0))
                    {
                        canControl = false;
                        rts.anchoredPosition = old;
                        return;
                    }
                }
                
            }
        }
        canControl = true;
    }
}
