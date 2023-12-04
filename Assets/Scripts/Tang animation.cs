using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tanganimation : MonoBehaviour
{
{
    //This is the Tentacle script changed


    public int length;
    //Determines the number of segments in the tentacle. (is adjustet in the inspector)
    public LineRenderer lineRend;
    //A reference to the LineRenderer component that will draw the tentacle.
    public Vector3[] segmentPoses;
    //An array to store the positions of the individual segments of the tentacle.
    private Vector3[] segmentV;
    //An array to store the velocities(speeds) of the individual segments.

    public Transform targetDir;
    // The target direction that the tentacle will follow.(Is marked with an empty(red arrow))
    public float targetDist;
    // The distance between the segments/points of the tentacle.
    public float smoothSpeed;
    // this just smoothes the movement


    // WIGGELING
    public float wiggleSpeed;
    //The speed of the wiggle (is adjustet in the inspector)
    public float wiggleMagnitude;
    // the amount of wiggle (is adjustet in the inspector)
    public Transform wiggleDir;
    // Represents the direction in which the tentacle wiggles. (Is marked with an empty(red arrow))



    void Start()
    {
        lineRend.positionCount = length;
        //Sets the number of positions/points in the LineRenderer to the specified length. (Length is adjustet in the inspector)
        segmentPoses = new Vector3[length];
        // Makes the array that stores segment positions/list of all the points in the line.
        segmentV = new Vector3[length];
        //Initializes the array for storing segment velocities/list of all the speeds of the points.
    }

    private void Update()
    {
        wiggleDir.localRotation = Quaternion.Euler(0, 0, Mathf.Sin(Time.time * wiggleSpeed) * wiggleMagnitude);
        //Causes the tentacle to wiggle in a specified direction based on time.

        //Time.time is the time elapsed since the start of the game.
        //Mathf.Sin(Time.time * wiggleSpeed) (the Math makes a wave between points based on elapsed time * wiggle speed)
        //^ is then scaled by wiggle magnitude
        //^ Quaternion.Euler is fancy math that calculates roations and converts above to into rotation along the z-axis of the Wiggledirection (wiggleDir)

        segmentPoses[0] = targetDir.position;
        //The base of the tentacle (point 0) follows the target direction.

        for (int i = 1; i < segmentPoses.Length; i++)
        //This is a 'for' loop, a control flow statement in programming that allows you to repeat a block of code a certain number of times

        //int i = 1 :This initializes the loop control variable i with the value of 1

        //i < segmentPoses.Length: This is the condition part. The loop will continue iterating as long as this condition is true.
        //^ the loop will continue as long as the value of i is less than the length of the array segmentPoses.

        //i++: This is the iteration part. It increments the value of i by 1 after each iteration of the loop

        //This loop is updating the positions of the tentacle segments/points.
        //It ensures that each segment follows the movement of the previous one
        {
            segmentPoses[i] = Vector3.SmoothDamp(segmentPoses[i], segmentPoses[i - 1] + targetDir.right * targetDist, ref segmentV[i], smoothSpeed);
            //segmentPoses[i - 1] represents the position of the previous segment.
            //targetDir.right * targetDist calculates the target position for the current segment. It uses the right direction of the targetDir multiplied by targetDist to determine the spacing between segments.
            //Vector3.SmoothDamp is a fancy way to make it smooth between the points
        }
        lineRend.SetPositions(segmentPoses);
        //updates the position of the (lineRend) to match the calculated segmentPoses/points.
    }


    //source https://www.youtube.com/watch?v=9hTnlp9_wX8 (also, the //explanation is part me, part chatGPT and part the tutorial.) 