using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bacteria : MonoBehaviour
{

    public float spawnRate;
    public BacteriaReproducer bacteriaMother;
    public float idleEnergyPayingPeriod;
    public int startingEnergy;
    public RectTransform healthBar;

    [SerializeField]
    private int energy;    
    private float nextIdleEnergyPayingTime = 0.0f; 
    private float spawnProbability;     

    // Start is called before the first frame update
    void Start()
    {
        nextIdleEnergyPayingTime = Time.time;
        energy = startingEnergy;
        UnityEngine.Random.InitState(System.DateTime.Now.Millisecond);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PayEnergy();
        TryToReproduce();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (energy + 10 > 100)
            energy = 100;
        else
            energy += 30;
        healthBar.sizeDelta = new Vector2(energy * 2, healthBar.sizeDelta.y);
    }

    private void TryToReproduce()
    {
        spawnProbability += 0.01f;
        float a = UnityEngine.Random.Range(5.0f, 100.0f);
        if (a < spawnProbability)
        {
            spawnProbability = 0.0f;
            bacteriaMother.Reproduce(gameObject.transform.position);
            UIManager.globalBacteriaCount++;
        }
    }

    private void PayEnergy()
    {
        PayEnergyForExisting();

    }

    private void PayEnergyForExisting()
    {
        if (Time.time > nextIdleEnergyPayingTime)
        {
            nextIdleEnergyPayingTime += idleEnergyPayingPeriod;
            energy -= 17;
        }
        if (GetEnergy() <= 0)
        {
            UIManager.globalBacteriaCount--;
            Destroy(gameObject);
        }
        healthBar.sizeDelta = new Vector2(energy * 2, healthBar.sizeDelta.y);
    }

    public int GetEnergy()
    {
        return energy;
    }

    public void SetEnergy(int energy)
    {
        this.energy = energy;
    }
}
