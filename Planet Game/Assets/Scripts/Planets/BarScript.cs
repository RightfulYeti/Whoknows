﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarScript : MonoBehaviour
{
    public GameObject Water;
    public GameObject Food;
    public GameObject Money;
    Vector3 WaterLocalScale;
    Vector3 FoodLocalScale;
    Vector3 MoneyLocalScale;
    public Planet Planet;

    // Start is called before the first frame update
    void Start()
    {
        WaterLocalScale = Water.transform.localScale;
        FoodLocalScale = Food.transform.localScale;
        MoneyLocalScale = Money.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        WaterLocalScale.x = Planet.Water / 20;
        Water.transform.localScale = WaterLocalScale;

        FoodLocalScale.x = Planet.Food / 20;
        Food.transform.localScale = FoodLocalScale;

        MoneyLocalScale.x = Planet.Money / 20;
        Money.transform.localScale = MoneyLocalScale;
    }
}
