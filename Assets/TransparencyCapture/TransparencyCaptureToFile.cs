using System.Collections;
using UnityEngine;

public class TransparencyCaptureToFile:MonoBehaviour
{
    private int scnshort;
    public IEnumerator capture()
    {

        yield return new WaitForEndOfFrame();
        //After Unity4,you have to do this function after WaitForEndOfFrame in Coroutine
        //Or you will get the error:"ReadPixels was called to read pixels from system frame buffer, while not inside drawing frame"
        zzTransparencyCapture.captureScreenshot("capture "+scnshort+".png");
        scnshort +=1;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
            StartCoroutine(capture());
    }
}