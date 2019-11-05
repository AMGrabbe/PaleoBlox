using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockDestroyedVFX;

    Level level;
    GameSession status;


    private void Start()
    {
        level=FindObjectOfType<Level>();

        level.CountBreakableBlocks();
    }

    private void DestroyBlock()
    {
        PlayAudioOnBlockDestroy();
        TriggerSparklesVFX();
        Destroy(gameObject);

        level.BlockDestroyed();


    }

    //Playing the clip on an AudioSource unattached to an object, and destroying it thereafter
    //Play the sound at camera position because that where the AudioListener is
    private void PlayAudioOnBlockDestroy()
    {
        FindObjectOfType<GameSession>().AddToScore();
        
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
    }

    private void OnCollisionEnter(Collision collection)
    {
        
        DestroyBlock();

    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockDestroyedVFX, transform.position, transform.rotation);
        Destroy(sparkles,1f);
    }

}
