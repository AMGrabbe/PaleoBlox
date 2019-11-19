using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockDestroyedVFX;
    [SerializeField] int maxHits;
    [SerializeField] Sprite[] damageLevelSprites;

    Level level;
    [SerializeField] int timesHit;


    private void Start()
    {
        CountBreakableBlocks();
    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
        {
            level.CountBlocks();
        }
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
        if(tag == "Breakable")
        {
            HandleHit();
        }


    }

    private void HandleHit()
    {
        timesHit++;
        
        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
        else
        {
            ShowNextSprite();
        }
    }

    private void ShowNextSprite()
    {
        //first state is not in the array
        int spriteIndex = timesHit - 1;
        GetComponent<SpriteRenderer>().sprite = damageLevelSprites[spriteIndex];
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockDestroyedVFX, transform.position, transform.rotation);
        Destroy(sparkles,1f);
    }

}
