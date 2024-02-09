using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropBehaviour : MonoBehaviour
{
    public bool isHarvesteable;

    [SerializeField] GameObject dirtPilePrefab;
    [SerializeField] GameObject stage1prefab;
    [SerializeField] GameObject stage2prefab;
    [SerializeField] GameObject stage3prefab;

    private void Start()
    {
        isHarvesteable = false;

        dirtPilePrefab.SetActive(true);

        StartCoroutine("growthTimer");
        
    }

    public IEnumerator growthTimer()
    {
        yield return new WaitForSeconds(1);
        stage1prefab.SetActive(true);
        yield return new WaitForSeconds(1);
        stage1prefab.SetActive(false);
        stage2prefab.SetActive(true);
        yield return new WaitForSeconds(1);
        stage2prefab.SetActive(false);
        stage3prefab.SetActive(true);
        isHarvesteable = true;
    }

}
