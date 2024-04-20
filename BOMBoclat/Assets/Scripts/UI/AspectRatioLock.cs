using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AspectRatioLock : MonoBehaviour
{
    // We want to lock the aspect ratio
    public void Adjust(){
        float targetaspect = 16f / 9f;
        float currentaspect = (float)Screen.width / (float)Screen.height;

        float scaleheight = currentaspect / targetaspect;
        Debug.Log("Scaleheight: "+scaleheight);

        Camera camera = GetComponent<Camera>();
        Debug.Log(camera);

        if(scaleheight < 1f){
            Rect rect = camera.rect;

            rect.width = 1f;
            rect.height = scaleheight;

            rect.x = 0;
            rect.y = (1f - scaleheight) / 2f;


            Debug.Log("rect.x: " + rect.x + ", rect.y: " + rect.y);

            camera.rect = rect;
        }

        else{
            float scalewidth = 1f/scaleheight;
            Rect rect = camera.rect;

            rect.width = scalewidth;
            rect.height = 1f;

            rect.x = (1f - scalewidth) / 2f;
            rect.y = 0;

            Debug.Log("rect.x: " + rect.x + ", rect.y: " + rect.y);

            camera.rect = rect;
        
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        Adjust();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
