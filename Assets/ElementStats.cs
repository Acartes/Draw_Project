using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "ElementStats", menuName = "Inventory/Element", order = 1)]
public class ElementStats : ScriptableObject
{
  public float mass = 0;
  public float gravity = 0;
  public float minimumDamage;
  public float resilience;
  public Gradient colorGradient;
  /*
   * Conductivite
Conductivite explosion
Max conductivite

Masse
Gravite

Persistance sur le temps
Disparité par rapport au centre
Vie face aux chocs physiques
*/
}
