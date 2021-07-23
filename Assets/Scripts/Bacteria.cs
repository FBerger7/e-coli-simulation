using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bacteria : MonoBehaviour
{

    [SerializeField]
    private int startEnergy;    
    private float nextIdleEnergyPayingTime = 0.0f;

    public float idleEnergyPayingPeriod;
    public int actualEnergy;

    // Start is called before the first frame update
    void Start()
    {
        nextIdleEnergyPayingTime = Time.time;
        actualEnergy = startEnergy;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PayEnergy();
    }

    private void PayEnergy()
    {
        if (Time.time > nextIdleEnergyPayingTime)
        {
            nextIdleEnergyPayingTime += idleEnergyPayingPeriod;
            PayEnergyForExisting();
        }
        if (GetEnergy() <= 0)
        {
            UIManager.globalBacteriaCount--;
            Destroy(gameObject);
        }

    }

    private void PayEnergyForExisting()
    {
        actualEnergy -= 17;
    }

    public int GetEnergy()
    {
        return actualEnergy;
    }

    public void SetEnergy(int energy)
    {
        this.actualEnergy = energy;
    }
}
