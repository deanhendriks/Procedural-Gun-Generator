using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPart : MonoBehaviour
{

    public enum WeaponStatType
    {
        Damage,
        Accuracy,
        AmmoPerClip,
        ReloadSpeed,
        FireRate
    }
    public WeaponStatType currentType;
    public class WeaponStatPair
    {
        public WeaponStatType stat;

        public float minStatValue;
        public float maxStatValue;
    }

    public List<WeaponStatPair> rawStats = new List<WeaponStatPair>();
    public Dictionary<WeaponStatType, float> stats = new Dictionary<WeaponStatType, float>();
    private void Awake()
    {
        foreach (WeaponStatPair statPair in rawStats)
        {
            float chosenValue = Random.Range(statPair.minStatValue, statPair.maxStatValue);
            Debug.Log(chosenValue);
        }
    }
}
