using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

public partial class UserDefinedFunctions
{
    [SqlFunction(IsDeterministic = true, IsPrecise = true)]
    public static SqlString jsDecrypt(string cryptedText)
    {
        var clearText = Cryptor.Decrypt(cryptedText);
        return new SqlString(clearText);
    }

    [SqlFunction(IsDeterministic = true, IsPrecise = true)]
    public static SqlString jsEncrypt(string clearText)
    {
        var cryptedText = Cryptor.Encrypt(clearText);
        return new SqlString(cryptedText);
    }
}
