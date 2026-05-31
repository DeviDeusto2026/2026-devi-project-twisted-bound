using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    [SerializeField] private TMP_Text healthText;
    [SerializeField] private Slider slider;

    [SerializeField] private string playerTag;

    public void Set(float maxHealth, float actualHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = actualHealth;
        healthText.text = (int)actualHealth + " / " + (int)maxHealth;
    }



    public string OwnerTag { get => playerTag; }
}
