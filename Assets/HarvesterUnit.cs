using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HarvesterUnit : Unit
{
    [SerializeField] private Camera cam;
    [SerializeField] private NavMeshAgent agent;

    private GameManager gameManager;
    private GameObject selectedCrop;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        gameManager.UpdateHarvestorText("Harvester idle");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            ShootRay();
        }

        if (!agent.pathPending && agent.remainingDistance < 0.1f)
        {
            HarvestCrop();
        }
    }

    public virtual void ShootRay()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.CompareTag("Crop"))
            {
                CropBehaviour cropScript = hit.collider.gameObject.GetComponent<CropBehaviour>();

                if (cropScript != null && cropScript.isHarvesteable)
                {
                    selectedCrop = hit.collider.gameObject;
                    agent.SetDestination(hit.point);
                    gameManager.UpdateHarvestorText("Harvester on its way");
                }
            }
        }
    }

    public void HarvestCrop()
    {
        if (selectedCrop != null)
        {
            Destroy(selectedCrop);
            gameManager.AddToScore(1);
            gameManager.UpdateHarvestorText("Harvest complete. Harvestor idle");
        }

    }
}
