using GooglePlayGames;
using GooglePlayGames.BasicApi;
using GooglePlayGames.BasicApi.Multiplayer;
using UnityEngine.SocialPlatforms;
using UnityEngine;

[RequireComponent(typeof(PlayGamesListener))]
public class MultiplayerManager : MonoBehaviour, IManager
{
    private PlayGamesListener _playGamesListener;

    public void Startup()
    {
        _playGamesListener = GetComponent<PlayGamesListener>();
        PlayGamesPlatform.Activate();
    }

    public void SignIn()
    {
        //UI loading screen
        Social.localUser.Authenticate((bool success) => {
            if (success)
            {
                //Show PLAY button
            }
            else
            {
                //Show error and retry
            }
        });
    }

    //Play button
    public void SearchMatch()
    {
        PlayGamesPlatform.Instance.RealTime.CreateQuickGame(1, 1, 0, _playGamesListener);
    }

    public void SendMessage(byte[] data)
    {
        PlayGamesPlatform.Instance.RealTime.SendMessageToAll(true, data);
    }

    public void EndMatch()
    {
        PlayGamesPlatform.Instance.RealTime.LeaveRoom();
    }
}