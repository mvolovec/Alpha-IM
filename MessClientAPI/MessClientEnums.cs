using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MessClientAPI
{
    #region enums
    public enum UsrState
    {
        aktivni,
        blokovany,
        neaktivni
    }

    public enum UsrStatus
    {
        online,
        offline,
        invisible
    }

    public enum MsgState
    {
        New,
        Old
    }
    #endregion
}
