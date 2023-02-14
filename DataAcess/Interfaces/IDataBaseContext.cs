using System;
using System.Data.Common;

namespace apidotnetwiwthdapper.DataAcess.Interfaces {
    public interface IDataBaseContext {

        DbConnection Connection { get; }

    }
}
