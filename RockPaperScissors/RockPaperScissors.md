```mermaid
classDiagram
	class GameManager
	{
		-Players~T~ player1
		-Players~T~ player2
		-(var player1Choice, var player2Choice) playerChoices
		-(int player1Wins, int player2Wins, int draws) record
		-CheckWinner()
	}

```