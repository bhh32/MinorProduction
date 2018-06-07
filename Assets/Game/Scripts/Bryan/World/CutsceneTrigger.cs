using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.Playables;

public class CutsceneTrigger : MonoBehaviour {

    public List<TimelineAsset> timelines;
    public List<PlayableDirector> playableDirectors;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Jungle Rodent") && RodentAI.instance.WasWhipped)
        {
            Play();
        }
    }

	public void Play()
    {
        foreach (PlayableDirector playableDirector in playableDirectors)
        {
            playableDirector.Play();
        }
    }

	public void PlayFromTimelines(int index)
    {
        TimelineAsset selectedAsset;

        if (timelines.Count <= index)
        {
            selectedAsset = timelines[timelines.Count - 1];
        }

        else
        {
            selectedAsset = timelines[index];
        }

        playableDirectors[0].Play(selectedAsset);
    }
}
