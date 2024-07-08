using System;

[Serializable]
public class GameData
{
    public float[] position;
    public int score;
    public int coin;
    public BloodKnightHelmet helmet;
    

    public GameData(Player player)
    {
        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;

        this.coin = player.coin;
        this.helmet = player.Item;
        
        // score = player.score;
    }
}
