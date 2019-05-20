using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateManager : MonoBehaviour, IManager
{
    private List<IUpdatable> _toUpdate = new List<IUpdatable>();

    public void Startup()
    {
        StartCoroutine(UpdateCycle());
    }

    private IEnumerator UpdateCycle()
    {
        while (true)
        {
            _toUpdate.ForEach(updateable => updateable.UpdateObject());
            yield return null;
        }
    }

    public void AddUpdateableObject(IUpdatable updateabelObject)
    {
        _toUpdate.Add(updateabelObject);
    }

    public void RemoveUpdateableObject(IUpdatable updateabelObject)
    {
        _toUpdate.Remove(updateabelObject);
    }
}