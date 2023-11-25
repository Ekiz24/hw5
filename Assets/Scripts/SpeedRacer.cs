using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
    

public class SpeedRacer : MonoBehaviour
{
    public string carMaker;
    public string carModel = "GTR R35";
    public string engineType = "V6, Twin Turbo";

    public int carWeight = 1609;
    public int yearMade = 2009;

    public float maxAcceleration = 0.98f;

    public bool isCarTypeSedan = false;
    public bool hasFrontEngine = true;

    public TextMeshProUGUI carInfo;
    public TextMeshProUGUI yearInfo;
    public TextMeshProUGUI weightInfo;
    public TextMeshProUGUI ageInfo;
    public TextMeshProUGUI CheckInfo;
    public TextMeshProUGUI fuelInfo;
  

    public class Fuel
    {
        public int fuelLevel;

        public Fuel(int amount)
        {
            fuelLevel = amount;
        }
    }

    public Fuel carFuel = new Fuel(100);



    void Start()
    {
          

    print("The racer model is " + carModel + " by " + carMaker + ". It has a " + engineType + " engine.");
        carInfo.text = "The racer model is " + carModel + " by " + carMaker + ". It has a " + engineType + " engine.";


        CheckWeight();

        if (yearMade <= 2009)
        {
            print("It was first introduced in " + yearMade);
            yearInfo.text = "It was first introduced in " + yearMade;
            int carAge = CalculateAge(yearMade);
            print("That makes it " + carAge + " years old.");
            ageInfo.text = "That makes it " + carAge + " years old.";
        }
        else
        {
            print("It was introduced in the 2010's");
            yearInfo.text = "It was introduced in the 2010's";
            print("And its maximum acceleration is " + maxAcceleration + " m/s2");
            ageInfo.text = "It was introduced in the 2010's";
        }

        print(CheckCharacteristics());
        CheckInfo.text = CheckCharacteristics();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ConsumeFuel();
            CheckFuelLevel();
        }
    }

    public void ConsumeFuel()
    {

        carFuel.fuelLevel -= 10;

    }

    public void CheckFuelLevel()
    {
        switch (carFuel.fuelLevel)
        {
            case 70:
                print("Fuel level is nearing two-thirds.");
                fuelInfo.text= "Fuel level is nearing two - thirds.";
                break;
            case 50:
                print("Fuel level is at half amount.");
                fuelInfo.text = "Fuel level is at half amount.";
                break;
            case 10:
                print("Warning! Fuel level is critically low.");
                fuelInfo.text = "Warning! Fuel level is critically low.";
                break;
            default:
                print("Nothing to report.");
                fuelInfo.text = "Nothing to report.";
                break;
        }
    }

    void CheckWeight()
    {
        if (carWeight < 1500)
        {
            print("The " + carModel + " weighs less than 1500 kg.");
            weightInfo.text = "The " + carModel + " weighs less than 1500 kg.";
        }
        else
        {
            print("The " + carModel + " weighs over 1500 kg.");
            weightInfo.text = "The " + carModel + " weighs less than 1500 kg.";
        }
    }

    int CalculateAge(int yearMade)
    {
        return 2023 - yearMade;
    }

    string CheckCharacteristics()
    {
        if (isCarTypeSedan)
        {
            return "The car is a sedan type.";
        }
        else if (hasFrontEngine)
        {
            return "The car is not a sedan, but has a front engine.";
        }
        else
        {
            return "The car is neither a sedan, nor is its engine a front engine.";
        }
    }
}
