using UnityEngine;

[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(PartnerController))]
public class GamePlayManager : MonoBehaviour, IManager
{
    private PlayerController _playerController;
    private PartnerController _partnerController;

    public void Startup()
    {
        _playerController = GetComponent<PlayerController>();
        _partnerController = GetComponent<PartnerController>();
    }

    public void UpdatePlayer(Vector3 direction)
    {
        _playerController.Move(direction);
    }

    public void UpdatePartner(Vector3 newPosition)
    {
        _partnerController.Move(newPosition);
    }
}