using UnityEngine;

public class PartnerController : MonoBehaviour
{
    [SerializeField]
    private Transform partner;

    public void Move(Vector3 newPosition)
    {
        partner.position = newPosition;
    }
}