using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class normalGame
{
   public int Level;
   public int targetScore;
   public int kesempatanNembak;
    public normalGame(int Level, int target, int targetScore)
    {
        this.Level = Level;
        this.targetScore = targetScore;
        this.kesempatanNembak = target;
    }

}
public class LoadLevelDesign
{

    public static normalGame[] normalGame = {
          new normalGame(0,1,3),
        new normalGame(1,3,10),
        new normalGame(2,3,15),
        new normalGame(3,3,20),
        new normalGame(4,3,35),
        new normalGame(5,4,40),
        new normalGame(6,4,65)
    };
}
public class Comment
{

}

