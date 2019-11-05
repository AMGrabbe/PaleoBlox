using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;

    Level level;
    GameSession status;


    private void Start()
    {
        level=FindObjectOfType<Level>();

        level.CountBreakableBlocks();
    }

    private void DestroyBlock()
    {
        status= FindObjectOfType<GameSession>();
        //Playing the clip on an AudioSource unattached to an object, and destroying it thereafter
        //Play the sound at camera position because that where the AudioListener is
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        
        Destroy(gameObject);

        level.BlockDestroyed();

        //Update the Players score
        status.AddToScore();
    }
    private void OnCollisionEnter(Collision collection)
    {
        
        DestroyBlock();

    }
}
