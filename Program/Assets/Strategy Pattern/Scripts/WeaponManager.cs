using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] List<Weapon> weapons;
    [SerializeField] int count;

    private void Start()
    {
        // 모든 무기 비활성화
        foreach (Weapon weapon in weapons)
        {
            weapon.gameObject.SetActive(false);
        }

        count = 0;
        weapons[count].gameObject.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Swap();
        }

        if (Input.GetMouseButtonDown(0))
        {
            weapons[count].Attack();
        }
    }

    public void Swap()
    {
        weapons[count].gameObject.SetActive(false);

        count = (count + 1) % weapons.Count;

        weapons[count].gameObject.SetActive(true);
    }
}
