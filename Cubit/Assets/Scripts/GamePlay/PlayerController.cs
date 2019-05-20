using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private LayerMask collisionsMask;
    [SerializeField]
    private Transform player;

    private float _speed = 3f;
    private bool _moving = false;

    public void Move(Vector3 direction)
    {
        var newPos = GetNewPosition(direction);
        player.position = newPos;
        Managers.Multiplayer.SendMessage(PosToByte(newPos));
    }

    private Vector3 GetNewPosition(Vector3 movementDirection)
    {
        var newPos = new Vector3();

        RaycastHit hitInfo;

        if (Physics.Raycast(player.position, movementDirection, out hitInfo, 0.75f, collisionsMask))
        {
            if (!Physics.Raycast(hitInfo.transform.position, Vector3.up, 0.75f))
            {
                newPos = player.position + movementDirection;
                newPos.y = player.position.y + 1f; //1f => Size of a block
                return newPos;
            }
            else
            {
                return player.position;
            }
        }
        else
        {
            return player.position + movementDirection;
        }
    }

    private byte[] PosToByte(Vector3 pos)
    {
        List<byte> _container = new List<byte>();

        _container.AddRange(System.BitConverter.GetBytes(pos.x));
        _container.AddRange(System.BitConverter.GetBytes(pos.y));
        _container.AddRange(System.BitConverter.GetBytes(pos.z));

        return _container.ToArray();
    }
}