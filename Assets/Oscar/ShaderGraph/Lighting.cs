using UnityEngine;


public class Lighting : MonoBehaviour
{
    public Material lightMaterial; // Assign your material with the shader here
    public Light mainLight; // Assign the main directional light in the Inspector

    [System.Obsolete]
    void Update()
    {
        if (mainLight != null && lightMaterial != null)
        {
            // Pass Main Light Direction
            Vector3 lightDirection = -mainLight.transform.forward; // Unity lights point in the opposite direction
            lightMaterial.SetVector("_MainLightDirection", new Vector4(lightDirection.x, lightDirection.y, lightDirection.z, 0));

            // Pass Main Light Color
            Color lightColor = mainLight.color * mainLight.intensity;
            lightMaterial.SetColor("_MainLightColor", lightColor);
        }

        // Optionally handle additional lights
        Light[] additionalLights = FindObjectsOfType<Light>();
        foreach (var light in additionalLights)
        {
            if (light != mainLight && light.type != LightType.Directional)
            {
                // Example: Pass the first additional light color
                lightMaterial.SetColor("_AdditionalLightColor", light.color * light.intensity);
                break;
            }
        }
    }
}
