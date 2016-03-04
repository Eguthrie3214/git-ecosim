using UnityEngine;
using System.Collections;
using Assets;

public class Trout : MonoBehaviour
{

    fish trout = new fish();
    public int troutAge;
    public int hunger;
    Transform flip;
    Rigidbody2D rig;
    public Vector3 realSize;
    public float adjustedsize;
    public float growthperseason;



    

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Collider2D mouth = GetComponent<BoxCollider2D>();
        trout.eat(trout.hunger, mouth, collision.gameObject.GetComponent<Collider2D>());
    }

    
    



    // Use this for initialization
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        flip = GetComponent<Transform>();
        realSize = GetComponent<SpriteRenderer>().bounds.size;


        trout.name = "trout" + GetInstanceID().ToString();
        name = trout.name;

        trout.hunger = 0;
        trout.maxLifespan = 11;

        trout.scaleMaxSize = Random.Range(.60f,.90f);
        trout.scaleStartSize = Random.Range(.15f, .30f);
        flip.localScale = new Vector3(trout.scaleStartSize, trout.scaleStartSize);


        trout.spriteSizeX = realSize.x;
        trout.spriteSizeY = realSize.x;
        


        

    }

    // Update is called once per frame
    void Update()
    {

        
       
        adjustedsize = trout.adjustedSpriteSize;
        troutAge = trout.interaction();
        hunger = trout.hunger;
        growthperseason = trout.grow(flip);
        trout.swim(rig, flip);

    }
}
