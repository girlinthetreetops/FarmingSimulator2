using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TractorUnit : Unit
{
    [SerializeField] private Camera cam;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private GameObject cropPrefab;

    private GameManager gameManager;

    private bool isMoving = false;

    private bool readyToPlant = false;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        gameManager.UpdateTractorText("Tractor idle");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShootRay();
        }

        if (!agent.pathPending && agent.remainingDistance < 0.1f && readyToPlant)
        {
            PlantCrop();
            isMoving = false;
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
                gameManager.MakeNotification("there i a crop here already");
            }

            else
            {
                readyToPlant = true;
                isMoving = true;
                gameManager.UpdateTractorText("Tractor on way to plant");
                agent.SetDestination(hit.point);
            }
        }
    }

    public virtual void PlantCrop()
    {
        Instantiate(cropPrefab, transform.position, Quaternion.identity);
        readyToPlant = false;
        gameManager.UpdateTractorText("Planting complete, tractor idle");
    }
}
