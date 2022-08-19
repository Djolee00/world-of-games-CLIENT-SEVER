using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Communication
{
    [Serializable]
    public enum OperationResponse
    {
        None,
        RefreshLobby,
        ReceivedGameRequest,
        GameRejectedNotification,
        GameAcceptedOpponent,
        DiceGameStarted,
        DisablePlayer,
        EnablePlayer,
        ChangeScores,
        RollADiceGameFinished,
        TriviaGameStart,
        QuestionReceived,
        CorrectAnwer,
        FalseAnswer,
        DisablePlayerAfterFalseAnswer,
        TimerOperation,
        TriviaGameFinished,
        DummyResponse
    }
}
