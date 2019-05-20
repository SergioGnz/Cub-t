using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MultiplayerManager))]
[RequireComponent(typeof(UpdateManager))]
[RequireComponent(typeof(GamePlayManager))]
[RequireComponent(typeof(InputManager))]
public class Managers : MonoBehaviour
{
    public static MultiplayerManager Multiplayer;
    public static UpdateManager Update;
    public static GamePlayManager Gameplay;
    public static InputManager Input;

    private List<IManager> _managers = new List<IManager>();

    void Start()
    {
        Multiplayer.Startup();
    }

    public void StartManagers()
    {
        GetManagers();
        AddManagers();
        StartupManagers();
    }

    private void GetManagers()
    {
        Update = GetComponent<UpdateManager>();
        Gameplay = GetComponent<GamePlayManager>();
        Input = GetComponent<InputManager>();
    }

    private void AddManagers()
    {
        _managers.Add(Update);
        _managers.Add(Gameplay);
        _managers.Add(Input);
    }

    private void StartupManagers()
    {
        _managers.ForEach(manager => manager.Startup());
    }
}