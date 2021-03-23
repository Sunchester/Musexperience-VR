using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxChange : MonoBehaviour
{
    public Material m_Skybox1;
    public Material m_Skybox2;
    public Material m_Skybox3;
    public Material m_Skybox4;
    public Material m_Skybox5;
    public Material m_Skybox6;
    public Material m_Skybox7;
    public Material m_SkyboxBeginning;
    public Material m_Post_Sky;
    public Material m_Beautiful;
    public Material Bang;
    public Material Bang2;
    public Material Bang3;
    public Material Bang4;
    public Material Bang5;

    public Material defaultSky;
    private void Start()
    {
        RenderSettings.skybox = defaultSky;
    }
    void Update()
    {
        if(!PickupItem.change)
            RenderSettings.skybox = defaultSky;

        if (PickupItem.change && PickupItem.triggerType == 1)
            RenderSettings.skybox = m_Skybox1;
        if (PickupItem.change && PickupItem.triggerType == 2)
            RenderSettings.skybox = m_Skybox2;
        if (PickupFinale.change && PickupFinale.triggerType == 3)
            RenderSettings.skybox = m_Skybox3;
        if (PickupFinale.change && PickupFinale.triggerType == 4)
            RenderSettings.skybox = m_Skybox4;
        if (PickupFinale.change && PickupFinale.triggerType == 5)
            RenderSettings.skybox = m_Skybox5;
        if (PickupFinale.change && PickupFinale.triggerType == 6)
            RenderSettings.skybox = m_SkyboxBeginning;
        if (PickupFinale.change && PickupFinale.triggerType == 7)
            RenderSettings.skybox = m_Skybox6;
        if (PickupFinale.change && PickupFinale.triggerType == 8)
            RenderSettings.skybox = m_Skybox7;
        if (PickupFinale.change && PickupFinale.triggerType == 9)
            RenderSettings.skybox = m_Post_Sky;
        if (PickupFinale.change && PickupFinale.triggerType == 10)
            RenderSettings.skybox = m_Beautiful;
        if (PickupFinale.change && PickupFinale.triggerType == 11)
            RenderSettings.skybox = Bang;
        if (PickupFinale.change && PickupFinale.triggerType == 12)
            RenderSettings.skybox = Bang2;
        if (PickupFinale.change && PickupFinale.triggerType == 13)
            RenderSettings.skybox = Bang3;
        if (PickupFinale.change && PickupFinale.triggerType == 14)
            RenderSettings.skybox = Bang4;
        if (PickupFinale.change && PickupFinale.triggerType == 15)
            RenderSettings.skybox = Bang5;
    }
}