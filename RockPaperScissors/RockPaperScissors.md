```mermaid
classDiagram
	class GameManager
	{
		-Players~T~ Player1
		-Players~T~ Player2
		-(var player1Choice, var player2Choice) PlayerChoices
		-(int player1Wins, int player2Wins, int draws) Record
		-CheckWinner()
	}

```