using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Assets;


/**************************************************
animal is the base that all species of animal inheret from

**************************************************/

namespace Assets
{
    public class Animal
    {
        
        public string name;
        public float maxLifespan;
        public float scaleStartSize;
        public float scaleMaxSize;
        public float spriteSizeX;
        public float spriteSizeY;
        public float adjustedSpriteSize;
        public int yBorn;
        public int seasonBorn;

        
        public float size;
        public int age;
        public int foodNeeded;
        public int hunger;


        // default constructor
        public Animal()
        {
            
            yBorn = globalEnviroEng.environ.years;
            seasonBorn = globalEnviroEng.environ.season;
            
        }
        // to be called every frame to update varibles when conditions change
        public int interaction()
        {
            age = globalEnviroEng.environ.years - yBorn;
            if (age >= maxLifespan) { UnityEngine.Object.Destroy(GameObject.Find(name)); }
            adjustedSpriteSize = spriteSizeX * spriteSizeY ;
            return age;

        }

        public float grow(Transform objToEnlarge)
        {
            double time = globalEnviroEng.environ.time;
            float maxGrowth = scaleMaxSize - scaleStartSize;
            maxGrowth = maxGrowth / maxLifespan;
            
            if (time == 250 && hunger > 0 && objToEnlarge.localScale.x <= scaleMaxSize) { hunger -= 1; objToEnlarge.localScale += new Vector3(maxGrowth, maxGrowth); }
            if (time == 500 && hunger > 0 && objToEnlarge.localScale.x <= scaleMaxSize) { hunger -= 1; objToEnlarge.localScale += new Vector3(maxGrowth, maxGrowth); }
            if (time == 750 && hunger > 0 && objToEnlarge.localScale.x <= scaleMaxSize) { hunger -= 1; objToEnlarge.localScale += new Vector3(maxGrowth, maxGrowth); }
            if (time == 1000 && hunger > 0 && objToEnlarge.localScale.x <= scaleMaxSize) { hunger -= 1; objToEnlarge.localScale += new Vector3(maxGrowth, maxGrowth); }
            return maxGrowth;
        }

        

        public int eat(int hunger, Collider2D mouth, Collider2D other)
        {
            SpriteRenderer otherRen = other.GetComponent<SpriteRenderer>();
            
            
            
            if (hunger < 1&& other.gameObject.tag !="background"&& adjustedSpriteSize >= otherRen.bounds.size.x * otherRen.bounds.size.y * 3)
            {
                hunger += 1;
               
                UnityEngine.Object.Destroy(other.gameObject);
            }
            this.hunger = hunger;
            return this.hunger;
        }

        
    }

    public class fish : Animal
    {

        public fish()
        {
            
        }


        public void swim(Rigidbody2D body, Transform trans)
        {


            List<Vector2> swimpath = new List<Vector2>();
            swimpath.Add(new Vector2(UnityEngine.Random.Range(-24, 25), UnityEngine.Random.Range(-24, 25)));
            swimpath.Add(new Vector2(UnityEngine.Random.Range(-24, 25), UnityEngine.Random.Range(-24, 25)));
            swimpath.Add(new Vector2(UnityEngine.Random.Range(-24, 25), UnityEngine.Random.Range(-24, 25)));
            swimpath.Add(new Vector2(UnityEngine.Random.Range(-24, 25), UnityEngine.Random.Range(-24, 25)));

            for (int i = 0; i <= 4; i++)
            {
                if (i == globalEnviroEng.gameSeason)
                { body.AddForce(swimpath[i - 1]); }
                if (body.velocity.x < -1 && trans.rotation.eulerAngles.y >= 0 && trans.rotation.eulerAngles.y <= 1) { trans.Rotate(0, 180f, 0); }
                else if (body.velocity.x > 1 && trans.rotation.eulerAngles.y >= 180 && trans.rotation.eulerAngles.y <= 181) { trans.Rotate(0, 180, 0); }

            }




        }

    }
}
