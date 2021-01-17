using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int objet;
    public float cooldown;
    private float counter;
    public Text ObjetText;
    public List<string> Names = new List<string>();
    public List<int> Numbers = new List<int>();
    public List<int> Costs= new List<int>();
    public List<int> Cooldowns = new List<int>();
    public List<int> Rates = new List<int>();

    public Text OneButtonText;
    public Text TwoButtonText;
    public Text ThreeButtonText;

    

    private List<float> Counters = new List<float> { 0, 0, 0 };
    private int buff;
    


    
    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
        objet = 0;
        ObjetText.text = "0";

    }

    public void ManualIncrement()
    {
        objet = Increment(1);
    }

    public void BuyUpgrade(int upgrade)
    {
        if (objet >= Costs[upgrade])
        {
            objet -= Costs[upgrade];
            UpdateObjetDisplay(objet);
            Numbers[upgrade]++;
            switch (upgrade)
            {
                case 0:
                    OneButtonText.text = Names [upgrade] + "  " + "(" + Costs[upgrade] + ")" + "  " + Numbers[upgrade].ToString(); 
                    break;
                case 1:
                    TwoButtonText.text = Names [upgrade] + "  " + "(" + Costs[upgrade] + ")" + "  " + Numbers[upgrade].ToString(); 
                    break;
                case 2:
                    ThreeButtonText.text = Names [upgrade] + "  " + "(" + Costs[upgrade] + ")" + "  " + Numbers[upgrade].ToString(); 
                    break;

            }
            

        }

    }

   
    public int Increment(int value) 
    {
        int total = objet + value;
        UpdateObjetDisplay(total);
       
        return total;
    
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;

        if (counter >= cooldown)
        {
            objet = Increment(1);
            counter -= cooldown;

        }

        for ( int i=0; i<3; i++)
        {
            Counters[i] += Time.deltaTime;
            if (Counters[i] >= Cooldowns[i])
            {
                objet = Increment(Rates[i]*Numbers[i]);
                Counters[i] -= Cooldowns[i];
            }

        }
        
        
 
    }

    private void UpdateObjetDisplay(int newNumber)
    {
        ObjetText.text = objet.ToString();

    }
}


