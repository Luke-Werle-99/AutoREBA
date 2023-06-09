using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class REBA_Score : MonoBehaviour
{
    public Transform Head;
    public Transform Torso;
    public Transform LeftLeg;
    public Transform RightLeg;
    public Transform Hip;
    public Transform upperRightArm;
    private int[,,] tableA;

    // Start is called before the first frame update
    void Start()
    {
        GetUpperBodyScore();
    }

    public void GetUpperBodyScore()
    {
        tableA = new int[,,] {
            { {1, 2, 3, 4}, {2, 3, 4, 5}, {2, 4, 5, 6}, {3, 5, 6, 7}, {4, 6, 7, 8} },
            { {1, 2, 3, 4}, {3, 4, 5, 6}, {4, 5, 6, 7}, {5, 6, 7, 8}, {6, 7, 8, 9} },
            { {3, 3, 5, 6}, {4, 5, 6, 7}, {5, 6, 7, 8}, {6, 7, 8, 9}, {7, 8, 9, 9} }
        };
    }

    // Update is called once per frame
    void Update()
    {
        // Get the rotation quaternion between the two objects
        Quaternion qNeckTorso = Quaternion.Inverse(Head.rotation) * Torso.rotation;
        Quaternion qTorsoHip = Quaternion.Inverse(Hip.rotation) * Torso.rotation;

        // Calculate the angle between the rotation quaternion and the identity quaternion
        float AngleHeadTorso = Quaternion.Angle(qNeckTorso, Quaternion.identity);
        float AngleHipTorso = Quaternion.Angle(qTorsoHip, Quaternion.identity);

        // Print the angle
        Debug.Log("Angle between Head and Torso: " + AngleHeadTorso);
        Debug.Log("Angle between Legs and Torso: " + AngleHipTorso);
    }
}
