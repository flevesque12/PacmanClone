using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//it execute in edit mode and see the effect form a varying point of view
[ExecuteInEditMode, ImageEffectAllowedInSceneView]
public class BloomEffect : MonoBehaviour
{
    [Range(1, 16)]
    public int m_Iteration = 1;

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        //by using a half-size intermediate texture means tht we downsampling the source texture to half resolution 
        int width = source.width / 2;
        int height = source.height / 2;
        RenderTextureFormat format = source.format;
        

        //bluring a temporary texture
        RenderTexture currentDestination = RenderTexture.GetTemporary(width, height,0,format);

        //first blit from the source to the temporary texture then from that to the destination
        Graphics.Blit(source, currentDestination);

        RenderTexture currentSource = currentDestination;



        Graphics.Blit(currentSource, destination);

        //release the temporary texture when we dont longer need it
        RenderTexture.ReleaseTemporary(currentSource);
    }

}

