using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Communication
{
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
        QuestionAnswered,
        CorrectAnwer,
        FalseAnswer,
        DisablePlayerAfterFalseAnswer
    }
}
