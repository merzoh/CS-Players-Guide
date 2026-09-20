```mermaid
classDiagram
	class GameManager~T~
	{
		-Players~T~ Player1
		-Players~T~ Player2
		-ChoiceTuple PlayerChoices
		-RecordTuple Record
		-CheckWinner() : int
	}

```