using UnityEngine;
using System.Collections;
using Assets;

public class globalEnviroEng : MonoBehaviour {
    public static double gameTime;
    public static double gameSeason;
    public int animalCount;
    public int gameyears;
    public static environment environ = new environment();
    
	// Use this for initialization
	void Start () {
        environ.time = 0;
        environ.years = 0;
	
	}
	
	// Update is called once per frame
	void Update () {
        gameyears = environ.years;
        animalCount = environ.countAnimals()-1;
        gameTime = environ.startTime();
        gameSeason = environ.changeSeason(gameTime);
	}
}
