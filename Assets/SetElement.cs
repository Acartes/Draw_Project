using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetElement : MonoBehaviour
{
  RendData rendData;
  public MonoBehaviour nextStep;

  public GameObject ElementsButton;
  public List<ElementStats> avalaibleElements = new List<ElementStats>();

  public void OnEnable()
  {
    rendData = GetComponent<RendData>();
    ElementsButton.SetActive(true);
  }

  public void SearchElementData(string name)
  {
    foreach (ElementStats element in avalaibleElements)
    {
      if (element.name.Contains(name))
      {
        ApplyElementData(element);
        return;
      }
    }
  }

  // Update is called once per frame
  void ApplyElementData(ElementStats element)
  {
    rendData.rb2D.mass *= element.mass;
    rendData.rb2D.gravityScale = element.gravity;
    rendData.rend.colorGradient = element.colorGradient;
    rendData.aliveElement.resilience = element.resilience * rendData.instantiatiedPrefab.transform.childCount;
    rendData.aliveElement.resilience /= 10;
    rendData.aliveElement.minimumDamage = element.minimumDamage + rendData.rb2D.mass/100;

    EndEffect();
  }

  void MakeEachElementIndividual()
  {
    for (int i = 0; i < rendData.instantiatiedPrefab.transform.childCount; i++)
    {
      Rigidbody2D newRB = rendData.instantiatiedPrefab.transform.GetChild(i).gameObject.AddComponent<Rigidbody2D>();
      newRB.velocity = rendData.rb2D.velocity;
      newRB.mass = 1;

    }
  }

  void EndEffect()
  {
    ElementsButton.SetActive(false);

    rendData.rb2D.simulated = true;
    rendData.aliveElement.enabled = true;
    rendData.DestroyData();

    nextStep.enabled = true;
    enabled = false;
  }
}
