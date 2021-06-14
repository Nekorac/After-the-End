using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tentacle2 : MonoBehaviour
{
    public int length;
    public LineRenderer lineRend;
    public Vector3[] segmentPoses;
    private Vector3[] segmentV;

    public Transform targetDir;
    public float targetDist;
    public float smoothSpeed;

    public float wiggleSpeed;
    public float wiggleMagnitude;
    public Transform wiggleDir;


    private void Start()
    {
        lineRend.positionCount = length;
        segmentPoses = new Vector3[length];
        segmentV = new Vector3[length];

        //segmentPoses[0] = targetDir.position;
        //segmentPoses[1] = targetDir.position - new Vector3(10, 0, 0);
    }

    private void Update()
    {
        //wiggleDir.localRotation = Quaternion.Euler(0, 0, Mathf.Sin(Time.time * wiggleSpeed) * wiggleMagnitude);

        segmentPoses[0] = targetDir.position;

        for (int i = 1; i < segmentPoses.Length; i++)
        {
            Vector3 targetPos = segmentPoses[i - 1] + (segmentPoses[i] - segmentPoses[i - 1]).normalized * targetDist;
            //Vector3 targetPos = segmentPoses[i - 1] + (segmentPoses[i] - segmentPoses[i - 1]).normalized * targetDist + new Vector3(0, Mathf.Sin(Time.time * wiggleSpeed) * wiggleMagnitude, 0);
            segmentPoses[i] = Vector3.SmoothDamp(segmentPoses[i], targetPos, ref segmentV[i], smoothSpeed);
        }
        lineRend.SetPositions(segmentPoses);
    }
}
