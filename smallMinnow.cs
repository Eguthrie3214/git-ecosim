using UnityEngine;
using System.Collections;
using Assets; 

public class smallMinnow : MonoBehaviour {

    fish minnow = new fish();
    public Vector3 realsize;
    Transform flip;
    Rigidbody2D rig;


    public void OnTriggerEnter2D(Collider2D collision)
    {
        Collider2D mouth = GetComponent<BoxCollider2D>();
        minnow.eat(minnow.hunger, mouth, collision.gameObject.GetComponent<Collider2D>());
    }
    // Use this for initialization
    void Start () {
        minnow.name = "minnow" + GetInstanceID().ToString();
        rig = GetComponent<Rigidbody2D>();
        flip = GetComponent<Transform>();
        minnow.hunger = 0;
        realsize = GetComponent<SpriteRenderer>().bounds.size;
        minnow.spriteSizeX = realsize.x;
        minnow.spriteSizeY = realsize.y;
        name = minnow.name;
        minnow.hunger = 0;
        minnow.maxLifespan = 6;
        minnow.scaleMaxSize = Random.Range(.5f, .6f);
        minnow.scaleStartSize = Random.Range(.05f, .15f);
        flip.localScale = new Vector3(minnow.scaleStartSize, minnow.scaleStartSize);
    }
	
	// Update is called once per frame
	void Update () {
        minnow.interaction();
        minnow.grow(flip);
        minnow.swim(rig,flip);
	}
}
