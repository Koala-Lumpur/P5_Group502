using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecieveTracks : MonoBehaviour
{
    [SerializeField] OscIn _oscIn;

    const string address1 = "/test1";

    string _incomingText;

    // Start is called before the first frame update
    void Start()
    {
        if (!_oscIn) _oscIn = gameObject.AddComponent<OscIn>();
        _oscIn.Open(9010);
    }

    // Update is called once per frame
    void Update()
    {
        _oscIn.Map(address1, OnTest1);

    }

    void OnTest1(OscMessage incomingMessage)
    {
        if (incomingMessage.TryGet(0, ref _incomingText))
        {
            // We have now received a string that will only be
            // recreated (generate garbage) if it changes.

            // However, this Debug.Log call will generate garbage. Lots of it ;)
            Debug.Log(_incomingText);
        }

        // OPTIMISATION #4
        // Always recycle messages when you handle them yourself.
        OscPool.Recycle(incomingMessage);
    }
}
