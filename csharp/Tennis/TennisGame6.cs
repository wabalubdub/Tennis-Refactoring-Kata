namespace Tennis;

public class TennisGame6 : ITennisGame
{
    private int player1Score;
    private int player2Score;
    private string player1Name;
    private string player2Name;

    public TennisGame6(string player1Name, string player2Name)
    {
        this.player1Name = player1Name;
        this.player2Name = player2Name;
    }

    public void WonPoint(string playerName)
    {
        if (playerName == player1Name)
            player1Score++;
        else
            player2Score++;
    }

    public string GetScore()
    {
        string result;

        if (player1Score == player2Score)
        {
            result = GetTieMessage();
        }
        else if (player1Score >= 4 || player2Score >= 4)
        {
            result = GetEndGameScore();
        }
        else
        {
            result = GetRegularScore();
        }

        return result;
    }
    private string GetTieMessage()
    {
        // tie score
        string tieScore;
        switch (player1Score)
        {
            case 0:
                tieScore = "Love-All";
                break;
            case 1:
                tieScore = "Fifteen-All";
                break;
            case 2:
                tieScore = "Thirty-All";
                break;
            default:
                tieScore = "Deuce";
                break;
        }
        return tieScore;
    }
    private string GetEndGameScore()
    {
        // end-game score

        switch (player1Score - player2Score)
        {
            case 1:
                return $"Advantage {player1Name}";
            case -1:
                return $"Advantage {player2Name}";
            case >= 2:
                return $"Win for {player1Name}";
            default:
                return $"Win for {player2Name}";
        }
    }


    private string GetRegularScore()
    {
        // regular score
        string regularScore;

        string score1 = GetRegularScorePoint( player1Score);
        string score2 = GetRegularScorePoint( player2Score);

        regularScore = $"{score1}-{score2}";

        return regularScore;
    }

    private string GetRegularScorePoint(int score)
    {
        return score switch
        {
            0 => "Love",
            1 => "Fifteen",
            2 => "Thirty",
            _ => "Forty"
        };
    }
}