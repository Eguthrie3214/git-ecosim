using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets
{
    /****************************************************
    enivornment holds and manipulates the variables
    present in the current ecosystem

    *****************************************************/
    public class environment
    {
        
        public int season;
        public double time;
        public int years;

        public double startTime()
        {
            
            time += 1;
               
            if (time == 1000) { time = 0; years += 1; }
            if (years == int.MaxValue) { years = 0; }
             
            return time;
        }

        public int changeSeason(double time)
        {
            if (time >= 0 && time <= 250) { season = 1; }
            if (time > 250 && time < 500) { season = 2; }
            if (time > 500 && time < 750) { season = 3; }
            if (time > 750 && time <1000 ){ season = 4; }
            return season;



        }

        public int countAnimals()
        {
          var presentAnimals=  UnityEngine.Object.FindObjectsOfType<Rigidbody2D>();
            return presentAnimals.Length;
        }



    }
}
