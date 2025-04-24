using System.Collections.Generic;
using UnityEngine;

public class ParalaxBackground : MonoBehaviour
{
    public ParalaxCamera parallaxCamera;
    List<PralaxLayer> parallaxLayers = new List<PralaxLayer>();

    void Start()
    {
        if (parallaxCamera == null)
            parallaxCamera = Camera.main.GetComponent<ParalaxCamera>();

        if (parallaxCamera != null)
            parallaxCamera.onCameraTranslate += Move;

        SetLayers();
    }

    void SetLayers()
    {
        parallaxLayers.Clear();

        for (int i = 0; i < transform.childCount; i++)
        {
            PralaxLayer layer = transform.GetChild(i).GetComponent<PralaxLayer>();

            if (layer != null)
            {
                parallaxLayers.Add(layer);
            }
        }
    }

    void Move(float delta)
    {
        foreach (PralaxLayer layer in parallaxLayers)
        {
            layer.Move(delta);
        }
    }
}
