using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
  public LineRenderer line;
  public float lineWaveIntensity;
  public float activeWave;
  public float lineWaveSpeed;
  private float distance = 0;
  public int waveIndex = 0;
  private int baseDistance = 0;
  public float intensity;
  private float horizontalForce;
  private float maxInclinaison = 1;
  public float sens;
  private float horizontalWaveForce;

  // Use this for initialization
  void OnEnable()
  {
    baseDistance = waveIndex;
    intensity = 1;
    for (int i = 0; i < line.positionCount; i++)
    {
      line.SetPosition(i, new Vector3(0, line.GetPosition(i).y, line.GetPosition(i).z));
    }

  }

    // Update is called once per frame
    void Update()
  {
    if(intensity < 0)
    {
      enabled = false;
    }
    for (int i = 0; i < line.positionCount / 2; i++)
    {
      horizontalForce += .001f + horizontalForce * 0.1f * intensity;
    }
    maxInclinaison = horizontalForce;

    horizontalForce = 0;
    horizontalWaveForce = 0;
    for (int i = baseDistance; i >= 0; i--)
    {
      horizontalWaveForce += maxInclinaison/10 - horizontalForce;
      if (horizontalForce > maxInclinaison)
      {
        line.SetPosition(i, new Vector3((
          Mathf.Sin(horizontalWaveForce) * lineWaveIntensity * intensity
            + horizontalForce / 50 - maxInclinaison / 50
          ) * sens, line.GetPosition(i).y, line.GetPosition(i).z));
        continue;
      }
      line.SetPosition(i, new Vector3((
        Mathf.Sin(horizontalWaveForce) * lineWaveIntensity * intensity
 /*        Mathf.Sin(i - Time.time)
         * (lineWaveIntensity) * i / line.positionCount * intensity
  */       + horizontalForce / 50 - maxInclinaison / 50
        ) * sens, line.GetPosition(i).y, line.GetPosition(i).z));
      horizontalForce += .001f + horizontalForce * 0.1f * intensity;
    }
    horizontalForce = 0;
    horizontalWaveForce = 0;
    distance = baseDistance;
    for (int i = baseDistance; i < line.positionCount; i++)
    {
      horizontalWaveForce += maxInclinaison - horizontalForce;
      if (horizontalForce > maxInclinaison)
      {
        line.SetPosition(i, new Vector3((
          Mathf.Sin(horizontalWaveForce) * lineWaveIntensity * intensity
            + horizontalForce / 50 - maxInclinaison / 50
          ) * sens, line.GetPosition(i).y, line.GetPosition(i).z));
        continue;
      }
      line.SetPosition(i, new Vector3((
        Mathf.Sin((horizontalWaveForce)) * lineWaveIntensity * intensity
 /*        Mathf.Sin(i - Time.time)
         * (lineWaveIntensity) * distance / line.positionCount * intensity
  */       + horizontalForce / 50 - maxInclinaison / 50
        ) * sens, line.GetPosition(i).y, line.GetPosition(i).z));
      horizontalForce += .001f + horizontalForce * 0.1f * intensity;
      distance--;
    }
    horizontalForce = 0;
    if (baseDistance > 3)
    {
      if (line.GetPosition(baseDistance - 3).x > line.GetPosition(baseDistance - 2).x)
      {
        line.SetPosition(baseDistance - 1, new Vector3(line.GetPosition(baseDistance - 2).x, line.GetPosition(baseDistance - 1).y, line.GetPosition(baseDistance - 1).z));
      }
      else if (line.GetPosition(baseDistance - 3).x < line.GetPosition(baseDistance - 2).x)
      {
        line.SetPosition(baseDistance - 1, new Vector3(line.GetPosition(baseDistance - 2).x, line.GetPosition(baseDistance - 1).y, line.GetPosition(baseDistance - 1).z));
      }
    }
    else if (baseDistance > line.positionCount - 3)
    {
      if (line.GetPosition(baseDistance + 3).x > line.GetPosition(baseDistance + 2).x)
      {
        line.SetPosition(baseDistance + 1, new Vector3(line.GetPosition(baseDistance + 2).x, line.GetPosition(baseDistance + 1).y, line.GetPosition(baseDistance + 1).z));
      }
      else if (line.GetPosition(baseDistance + 3).x < line.GetPosition(baseDistance + 2).x)
      {
        line.SetPosition(baseDistance + 1, new Vector3(line.GetPosition(baseDistance + 2).x, line.GetPosition(baseDistance + 1).y, line.GetPosition(baseDistance + 1).z));
      }
    }
      intensity -= 0.01f;
  }
}
