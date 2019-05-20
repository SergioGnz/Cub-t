using GooglePlayGames;
using GooglePlayGames.BasicApi.Multiplayer;
using UnityEngine;

public class PlayGamesListener : MonoBehaviour, RealTimeMultiplayerListener
{
    public void OnLeftRoom()
    {

    }

    public void OnParticipantLeft(Participant participant)
    {

    }

    public void OnPeersConnected(string[] participantIds)
    {

    }

    public void OnPeersDisconnected(string[] participantIds)
    {

    }

    public void OnRealTimeMessageReceived(bool isReliable, string senderId, byte[] data)
    {
        float x = System.BitConverter.ToSingle(data, 0);
        float y = System.BitConverter.ToSingle(data, 4);
        float z = System.BitConverter.ToSingle(data, 8);
        Vector3 newPos = new Vector3(x, y, z);
        Managers.Gameplay.UpdatePartner(newPos);
    }

    public void OnRoomConnected(bool success)
    {
        GetComponent<Managers>().StartManagers();
    }

    public void OnRoomSetupProgress(float percent)
    {

    }
}