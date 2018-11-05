using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetDepthImage : MonoBehaviour {
    private KinectManager manager;
    private ushort[] depth;
    private int width;
    private int height;
    private Color[] pixelColor;
    public float nearThreshold;
    public float farThreshold;
    private int depthCount;
    private Texture2D te;
    public RawImage rimg;
    public RawImage img;

	// Use this for initialization
	void Start () {
        manager = KinectManager.Instance;
        width = manager.GetDepthImageWidth();
        height = manager.GetDepthImageHeight();
        depthCount = width * height;
        Debug.Log(width + "," + height);
        pixelColor = new Color[width * height];
        te = new Texture2D(512, 424);
    }
	
	// Update is called once per frame
	void Update () {
        Color[] c= GainDepthData();
       
        te.SetPixels(c);
        te.Apply();
        rimg.texture = te;
        img.texture = manager.GetUsersClrTex();

    }

    private Color[] GainDepthData()
    {
        depth=manager.GetRawDepthMap();
        for(int i=0;i< depthCount;i++)
        {
            if(depth[i]<nearThreshold||depth[i]>farThreshold)
            {
                pixelColor[i].a = 0;
            }
            else
            {
                pixelColor[i] = Color.green;
            }
        }
        return pixelColor;
        
    }
}
