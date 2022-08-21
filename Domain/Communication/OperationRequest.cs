using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Communication
{
    [Serializable]
    public enum OperationRequest
    {
        None,
        CreateANewPlayer,
        MakeANewLobbyGame,
        GameRejected,
        CreateGameRequest,
        BreakThread,
        WelcomeLobby,
        LobbyRefresh,
        GameAccepted,
        TriviaGameStart,
        DummyRequest,
        UserDiscconected,
        PlayerLeftGame
    }
}
