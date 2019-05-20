using UnityEngine;

public static class GameConstants
{
    public static int GroundLayer = 11;

    private static Vector3 _right = Vector3.right;        //0º swipe
    private static Vector3 _forward = Vector3.forward;    //90º swipe
    private static Vector3 _left = Vector3.left;          //180º swipe
    private static Vector3 _backwards = Vector3.back;     //270º swipe

    public static Vector3[] Directions = new Vector3[] {_right, _forward, _left, _backwards};
}