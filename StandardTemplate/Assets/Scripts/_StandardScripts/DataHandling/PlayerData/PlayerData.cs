
[System.Serializable]
public class PlayerData
{
    // insert savable data here!!
    public int achievementScore;
    public int[] achievementProgress;
    public PlayerData(PlayerProfile player)
    {
        // ensure that all the player data can be mapped here!!
        achievementScore = player.achievementScore;
        achievementProgress = player.achievementProgress;
    }
}
