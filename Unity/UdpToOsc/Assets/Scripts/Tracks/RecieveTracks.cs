using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RecieveTracks : MonoBehaviour
{
    [SerializeField] OscIn _oscIn;

    const string address1 = "/test1";

    string _incomingText;
    bool first = true;
    int numOfTracks = 0;

    public List<string> tracks = new List<string>();

    public GameObject trackPrefab;
    public List<GameObject> instTracks = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        if (!_oscIn) _oscIn = gameObject.AddComponent<OscIn>();
        _oscIn.Open(7000);
        _oscIn.Map(address1, OnTest1);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTest1(OscMessage incomingMessage)
    {

        for (int i = 0; i < incomingMessage.Count(); i++)
        {
            if (incomingMessage.TryGet(i, ref _incomingText))
            {
                if (first)
                {
                    tracks.Add(_incomingText);
                    InstTrack(i);
                    instTracks[i].transform.Find("Name").GetComponent<TextMesh>().text = tracks[i];
                    numOfTracks++;
                } else
                {
                    if (tracks[i] != _incomingText && _incomingText != null)
                    {
                        tracks[i] = _incomingText;
                        instTracks[i].transform.Find("Name").GetComponent<TextMesh>().text = tracks[i];
                    }
                    else if (tracks.Count() > incomingMessage.Count())
                    {
                        for(int j = tracks.Count()-1; j >= incomingMessage.Count(); j--)
                        {
                            Destroy(instTracks[j]);
                            instTracks.RemoveAt(j);
                            tracks.RemoveAt(j);
                            numOfTracks--;
                        }
                    }
                    else if(tracks.Count() < incomingMessage.Count())
                    {
                        tracks.Add(_incomingText);
                        InstTrack(i);
                        instTracks[i].transform.Find("Name").GetComponent<TextMesh>().text = tracks[i];
                        numOfTracks++;
                    }

                    if (tracks[0] == tracks[1] && tracks.Count() > 1)
                    {
                        Debug.Log("Tracks have conflicting names");
                        return;
                    }
                }
            }

            
        }

        first = false;
        // We have now received a string that will only be
        // recreated (generate garbage) if it changes.

        // However, this Debug.Log call will generate garbage. Lots of it ;)


        // OPTIMISATION #4
        // Always recycle messages when you handle them yourself.
        OscPool.Recycle(incomingMessage);
    }

    void InstTrack(int i)
    {
        GameObject newTrack = (GameObject)Instantiate(trackPrefab, new Vector3(-10 + 2*numOfTracks, 1, 0), Quaternion.identity);
        instTracks.Add(newTrack);
    }
}
