﻿using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Segment _segmentTemplate;
    [SerializeField] private Block _blockTemplate;
    [SerializeField] private Finish _finishTemplate;
    [SerializeField] private int _towerSize;

    private void Start()
    {
        BuildTower();
    }

    private void BuildTower()
    {
        GameObject currentPoint = gameObject;

        for (int i = 0; i < _towerSize; i++)
        {
            currentPoint = BuildSegment(currentPoint, _segmentTemplate.gameObject);

            currentPoint = BuildSegment(currentPoint, _blockTemplate.gameObject);
        }

        BuildSegment(currentPoint, _finishTemplate.gameObject);
    }

    private GameObject BuildSegment(GameObject currentSegment, GameObject nextSegment)
    {
        return Instantiate(nextSegment, GetBuildPoint(currentSegment.transform, nextSegment.transform), Quaternion.identity, transform);
    }

    private Vector3 GetBuildPoint(Transform currentSegment, Transform nextSegment)
    {
        return new Vector3(transform.position.x, currentSegment.position.y + currentSegment.localScale.y / 2 + nextSegment.transform.localScale.y / 2, transform.position.z);
    }
}
