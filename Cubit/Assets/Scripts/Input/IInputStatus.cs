public interface IInputStatus
{
    void Initialize();
    void FirstCall(UnityEngine.Vector2 firstUserInput);
    void UpdateStatus(UnityEngine.Vector2 userInput);
}