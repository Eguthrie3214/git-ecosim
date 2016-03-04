using UnityEngine;
using System.Collections;
using Assets;

public class Largemouthbass : MonoBehaviour {
    fish largemouthbass = new fish();
    public Vector3 realsize;
    Transform flip;
    Rigidbody2D rig;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Collider2D mouth = GetComponent<BoxCollider2D>();
        largemouthbass.eat(largemouthbass.hunger, mouth, collision.gameObject.GetComponent<Collider2D>());
    }

    // Use this for initialization
    void Start () {
        largemouthbass.name = "largemouthbass" + GetInstanceID().ToString();
        rig = GetComponent<Rigidbody2D>();
        flip = GetComponent<Transform>();
        largemouthbass.hunger = 0;
        realsize = GetComponent<SpriteRenderer>().bounds.size;
        largemouthbass.spriteSizeX = realsize.x;
        largemouthbass.spriteSizeY = realsize.y;
        name = largemouthbass.name;
        largemouthbass.hunger = 0;
        largemouthbass.maxLifespan = 16;
        largemouthbass.scaleMaxSize = Random.Range(.7f, .8f);
        largemouthbass.scaleStartSize = Random.Range(.1f, .2f);
        flip.localScale = new Vector3(largemouthbass.scaleStartSize, largemouthbass.scaleStartSize);

    }
	
	// Update is called once per frame
	void Update () {
        largemouthbass.interaction();
        largemouthbass.grow(flip);
        largemouthbass.swim(rig, flip);
    }
}
