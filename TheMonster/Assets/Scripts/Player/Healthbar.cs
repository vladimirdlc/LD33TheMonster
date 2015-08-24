using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour {
    public Text fillLabel;
    public Image fillImage;
    public float currentHealth;
    public float maxHealth = 100;
    public static Healthbar Instance;
    public float inmuneTime;
    public float currentInmuneTime;

    void Start()
    {
        Instance = this;
    }

    void Update()
    {
        currentInmuneTime -= Time.deltaTime;
    }

    public void damage(float amount)
    {
        if (currentInmuneTime < 0)
        {
            currentHealth -= amount;
            if (currentHealth < 0)
            {
                currentHealth = 0;
                //Dead
            }
            fillUpdate(currentHealth);
            currentInmuneTime = inmuneTime;
        }
    }

    public void heal(float amount)
    {
        if (currentHealth + amount < maxHealth)
            currentHealth += amount;

        fillUpdate(currentHealth);
    }
    
    public void fillUpdate(float amount)
    {
        fillImage.fillAmount = amount/100f;
        fillLabel.text = (amount).ToString();
    }
}
