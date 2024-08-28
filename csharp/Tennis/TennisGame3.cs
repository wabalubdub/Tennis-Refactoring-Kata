using System;

namespace Tennis
{
    public class TennisGame3 : ITennisGame
    {
        private int pointsWonPlayer1;
        private int pointsWonPlayer2;
        
        private string player1Name;
        private string player2Name;

        

        public TennisGame3(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
        }

        public string GetScore()
        {
            string winningPlayer = pointsWonPlayer1 > pointsWonPlayer2 ? player1Name : player2Name;
            if (IsMatchOver())
                return "Win for " + winningPlayer;
            if (IsMatchInOvertime())
            {
                if (isTie())
                    return "Deuce";
                else
                    return "Advantage " + winningPlayer;
            }  
            return isTie() ? GetPointName(pointsWonPlayer1) + "-All" : GetPointName(pointsWonPlayer1) + "-" + GetPointName(pointsWonPlayer2);
        }

        private string GetPointName(int pointsScored)
        {
            string[] pointNames = { "Love", "Fifteen", "Thirty", "Forty" };
            return pointNames[pointsScored];
        }
        private bool isTie()
        {
            return pointsWonPlayer1 == pointsWonPlayer2;
        }

        private bool IsLeadByOnePoint()
        {
            return (pointsWonPlayer1 - pointsWonPlayer2) * (pointsWonPlayer1 - pointsWonPlayer2) == 1;
        }
        private bool IsMatchOver()
        {
            return (pointsWonPlayer1 >= 4 || pointsWonPlayer2 >= 4) && !isTie() && !IsLeadByOnePoint();
        }
        private bool IsMatchInOvertime()
        {
            return pointsWonPlayer1 >= 3 && pointsWonPlayer2 >= 3 && (isTie() || IsLeadByOnePoint());
        }

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
                this.pointsWonPlayer1 += 1;
            else
                this.pointsWonPlayer2 += 1;
        }

    }
}