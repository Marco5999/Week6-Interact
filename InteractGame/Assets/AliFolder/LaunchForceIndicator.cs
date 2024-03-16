using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaunchForceIndicator : MonoBehaviour
{
    public Slider launchForceSlider;
    public Launcher launcher;

    void Update()
    {
        // Update the slider value based on the current launch force
        launchForceSlider.value = launcher.CurrentLaunchForce / launcher.MaxLaunchForce;
    }
}
