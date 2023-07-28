using System.Collections;
using UnityEngine;

public interface ICoroutineStarter
{
    Coroutine StartCoroutine(IEnumerator enumerator);
    void StopCoroutine(IEnumerator enumerator);
}