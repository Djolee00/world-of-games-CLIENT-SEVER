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
        GameRejectedNotification
    }
}
