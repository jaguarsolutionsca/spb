using System;

namespace Gestion_Paie.DataClasses.Parameters {

	/// <summary>
	/// This class allows a developer to specify the parameters expected by the
	/// stored procedure 'jag_Facture'. It allows also to specify specific connection
	/// information such as the ConnectionString to be use, the command time-out and so forth.
	/// </summary>
	[Serializable()]
	public sealed class jag_Facture : MarshalByRefObject, IDisposable, IParameter {

		private ErrorSource errorSource = ErrorSource.NotAvailable;
		private System.Data.SqlClient.SqlException sqlException = null;
		private System.Exception otherException = null;
		private string connectionString = String.Empty;
		private System.Data.SqlClient.SqlConnection sqlConnection = null;
		private System.Data.SqlClient.SqlTransaction sqlTransaction = null;
		private ConnectionType lastKnownConnectionType = ConnectionType.None;
		private int commandTimeOut = 30;

		internal void internal_UpdateExceptionInformation(System.Data.SqlClient.SqlException sqlException) {

			this.sqlException = sqlException;
		}

		internal void internal_UpdateExceptionInformation(System.Exception otherException) {

			this.otherException = otherException;
		}

		private CurrentExecution currentExecution = CurrentExecution.None;
		
		private System.Data.SqlClient.SqlCommand sqlCommand = null;
		internal void internal_Set_SqlCommand(ref System.Data.SqlClient.SqlCommand sqlCommand) {
		
			this.sqlCommand = sqlCommand;
		}

		/// <summary>
		/// Returns the System.Data.SqlClient.SqlCommand that has been used.
		/// </summary>
		public System.Data.SqlClient.SqlCommand SqlCommand {
		
			get {
			
				return(this.sqlCommand);
			}
		}
		
		private System.Data.SqlClient.SqlDataReader sqlDataReader = null;
		internal void internal_Set_SqlDataReader(ref System.Data.SqlClient.SqlDataReader sqlDataReader) {
		
			this.currentExecution = CurrentExecution.SqlDataReader;
			this.sqlDataReader = sqlDataReader;
		}

		internal void internal_SetErrorSource(ErrorSource errorSource) {

			this.errorSource = errorSource;
		}

		private bool useDefaultValue = true;

		/// <summary>
		/// Initializes a new instance of the jag_Facture class. If you use this constructor version,
		/// not assigning parameter values implies using the parameter default values.
		/// </summary>
		public jag_Facture() : this(true) {

		}

		/// <summary>
		/// Initializes a new instance of the jag_Facture class.
		/// </summary>
		/// <param name="useDefaultValue">If True, this parameter indicates that "not assigning parameter values" implies "using the parameter default values". If False, this parameter indicates that "not assigning parameter values" implies "using the SQL Server Null value".</param>
		public jag_Facture(bool useDefaultValue) {

			this.useDefaultValue = useDefaultValue;

			this.internal_Param_FactureID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_AjustementResume_UseDefaultValue = this.useDefaultValue;
		}

		private bool returnValueAvailable = true;

		internal void internal_Set_ReturnValue_Available(bool value) {

			this.returnValueAvailable = value;
		}

		/// <summary>
		/// Sets the connection string to be used against the 
		/// SQL Server database.
		/// </summary>
		/// <param name="connectionString">A valid connection string to the database.</param>
		public void SetUpConnection(string connectionString) {

			if (connectionString == null) {

				throw new ArgumentNullException("connectionString", "connectionString can be an empty string but can not be null.");
			}

			this.connectionString = connectionString;
			this.lastKnownConnectionType = ConnectionType.ConnectionString;

#if OLYMARS_DEBUG
			object olymarsDebugCheck = System.Configuration.ConfigurationSettings.AppSettings["OlymarsDebugCheck"];
			if (olymarsDebugCheck == null || (string)olymarsDebugCheck == "True") {

				string DebugConnectionString = connectionString;

				if (DebugConnectionString.Length == 0) {

					DebugConnectionString = Information.GetConnectionStringFromConfigurationFile;
				}

				if (DebugConnectionString.Length == 0) {

					DebugConnectionString = Information.GetConnectionStringFromRegistry;
				}

				if (DebugConnectionString.Length != 0) {

					System.Data.SqlClient.SqlConnection sqlConnection = new System.Data.SqlClient.SqlConnection(DebugConnectionString);

					sqlConnection.Open();

					System.Data.SqlClient.SqlCommand sqlCommand = sqlConnection.CreateCommand();

					sqlCommand.CommandType = System.Data.CommandType.Text;
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'jag_Facture'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

						throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "jag_Facture", CurrentRevision, OriginalRevision, System.Environment.NewLine));
					}
				}
			}
#endif
		}

		/// <summary>
		/// Sets the System.Data.SqlClient.SqlConnection to be used
		/// against the SQL Server database.
		/// </summary>
		/// <param name="sqlConnection">A valid System.Data.SqlClient.SqlConnection object. It can be opened or not. If it is not opened, it will be opened when used then closed again after the job is done.</param>
		public void SetUpConnection(System.Data.SqlClient.SqlConnection sqlConnection) {

			if (sqlConnection == null) {
				throw new ArgumentNullException("sqlConnection", "Invalid connection!");
			}

			this.sqlConnection = sqlConnection;
			this.lastKnownConnectionType = ConnectionType.SqlConnection;

#if OLYMARS_DEBUG
			object olymarsDebugCheck = System.Configuration.ConfigurationSettings.AppSettings["OlymarsDebugCheck"];
			if (olymarsDebugCheck == null || (string)olymarsDebugCheck == "True") {

				bool NotAlreadyOpened = false;
				if (sqlConnection.State == System.Data.ConnectionState.Closed) {

					NotAlreadyOpened = true;
					sqlConnection.Open();
				}

				System.Data.SqlClient.SqlCommand sqlCommand = sqlConnection.CreateCommand();

				sqlCommand.CommandType = System.Data.CommandType.Text;
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'jag_Facture'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlConnection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "jag_Facture", CurrentRevision, OriginalRevision, System.Environment.NewLine));
				}
			}
#endif
		}

		/// <summary>
		/// Sets the System.Data.SqlClient.SqlTransaction to be used
		/// against the SQL Server database.
		/// </summary>
		/// <param name="sqlTransaction">A valid System.Data.SqlClient.SqlTransaction object.</param>
		public void SetUpConnection(System.Data.SqlClient.SqlTransaction sqlTransaction) {

			if (sqlTransaction == null || sqlTransaction.Connection == null) {
				throw new ArgumentNullException("sqlTransaction", "Invalid connection!");
			}

			this.sqlTransaction= sqlTransaction;
			this.lastKnownConnectionType = ConnectionType.SqlTransaction;

#if OLYMARS_DEBUG
			object olymarsDebugCheck = System.Configuration.ConfigurationSettings.AppSettings["OlymarsDebugCheck"];
			if (olymarsDebugCheck == null || (string)olymarsDebugCheck == "True") {

				bool NotAlreadyOpened = false;
				if (sqlTransaction.Connection.State == System.Data.ConnectionState.Closed) {

					NotAlreadyOpened = true;
					sqlTransaction.Connection.Open();
				}

				System.Data.SqlClient.SqlCommand sqlCommand = sqlTransaction.Connection.CreateCommand();

				sqlCommand.CommandType = System.Data.CommandType.Text;
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'jag_Facture'";
				sqlCommand.Transaction = sqlTransaction;

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlTransaction.Connection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "jag_Facture", CurrentRevision, OriginalRevision, System.Environment.NewLine));
				}
			}
#endif
		}

		/// <summary>
		/// Disposes the current instance of this object.
		/// </summary>
		public void Dispose() {

			Dispose(true);
			GC.SuppressFinalize(this);
		}

		private void Dispose(bool disposing) {

			if (disposing) {

				this.internal_Param_RETURN_VALUE = System.Data.SqlTypes.SqlInt32.Null;
				this.internal_Param_FactureID = System.Data.SqlTypes.SqlInt32.Null;
				this.internal_Param_AjustementResume = System.Data.SqlTypes.SqlBoolean.Null;

				this.sqlException = null;
				this.otherException = null;
				this.connectionString = null;
				this.sqlConnection = null;
				this.sqlTransaction = null;

				this.sqlCommand = null;
				this.sqlDataReader = null;
			}
		}

		/// <summary>
		/// This member overrides 'Object.Finalize'.
		/// </summary>
		~jag_Facture() {

			Dispose(false);
		}

		/// <summary>
		/// Returns the stored procedure name for which this class was built, i.e. 'jag_Facture'.
		/// </summary>
		public string StoredProcedureName {

			get {

				return("jag_Facture");
			}
		}

		private System.Data.SqlTypes.SqlInt32 internal_Param_RETURN_VALUE;

		private System.Data.SqlTypes.SqlInt32 internal_Param_FactureID;
		internal bool internal_Param_FactureID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_AjustementResume;
		internal bool internal_Param_AjustementResume_UseDefaultValue = true;


		/// <summary>
		/// Allows you to know at which step did the error occured if one occured. See <see cref="ErrorSource" />
		/// for more information.
		/// </summary>
		public ErrorSource ErrorSource {

			get {

				return(this.errorSource);
			}
		}

		/// <summary>
		/// This method allows you to reset the parameter object. Please note that this
		/// method resets all the parameters members except the connection information and
		/// the command time-out which are left in their current state.
		/// </summary>
		public void Reset() {

			this.currentExecution = CurrentExecution.None;
			this.sqlCommand = null;
			this.sqlDataReader = null;

			this.internal_Param_RETURN_VALUE = System.Data.SqlTypes.SqlInt32.Null;

			this.internal_Param_FactureID = System.Data.SqlTypes.SqlInt32.Null;
			this.internal_Param_FactureID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_AjustementResume = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_AjustementResume_UseDefaultValue = this.useDefaultValue;

			this.errorSource = ErrorSource.NotAvailable;
			this.sqlException = null;
			this.otherException = null;
		}

		/// <summary>
		/// Returns the connection string to be used against the 
		/// SQL Server database.
		/// </summary>
		public System.String ConnectionString {

			get {

				return(this.connectionString);
			}
		}
            
		/// <summary>
		/// Returns the System.Data.SqlClient.SqlConnection to be used
		/// against the SQL Server database.
		/// </summary>
		public System.Data.SqlClient.SqlConnection SqlConnection {

			get {

				return(this.sqlConnection);
			}
		}

		/// <summary>
		/// Returns the System.Data.SqlClient.SqlTransaction to be used
		/// against the SQL Server database.
		/// </summary>
		public System.Data.SqlClient.SqlTransaction SqlTransaction {

			get {

				return(this.sqlTransaction);
			}
		}

		/// <summary>
		/// Returns the current type of connection that is going or has been used
		/// against the Sql Server database. It can be: ConnectionString, SqlConnection
		/// or SqlTransaction
		/// </summary>
		public ConnectionType ConnectionType {

			get {

				return(this.lastKnownConnectionType );
			}
		}

		/// <summary>
		/// In case of an ADO exception, returns the SqlException exception (System.Data.SqlClient.SqlException)
		/// that has occured.
		/// </summary>
		public System.Data.SqlClient.SqlException SqlException {

			get {

				return(this.sqlException);
			}
		}

		/// <summary>
		/// In case of a System exception, returns the standard exception (System.Exception) that 
		/// has occured.
		/// </summary>
		public System.Exception OtherException {

			get {

				return(this.otherException);
			}
		}

		/// <summary>
		/// Sets or returns the time-out (in seconds) to be use by the ADO command object
		/// (System.Data.SqlClient.SqlCommand).
		/// <remarks>
		/// Default value is 30 seconds.
		/// </remarks>
		/// </summary>
		public int CommandTimeOut {

			get {

				return(this.commandTimeOut);
			}

			set {

				this.commandTimeOut = value;
				if (this.commandTimeOut <= 0) {

					this.commandTimeOut = 30;
				}
			}
		}

		private void RetrieveOutputParameters() {
		
			if (this.sqlCommand.Parameters["@RETURN_VALUE"].Value != System.DBNull.Value) {

				this.internal_Set_RETURN_VALUE ((System.Int32)this.sqlCommand.Parameters["@RETURN_VALUE"].Value);
			}
			else {

				this.internal_Set_RETURN_VALUE (System.Data.SqlTypes.SqlInt32.Null);
			}


			this.returnValueAvailable = true;
		}

		/// <summary>
		/// Returns the value returned back by the stored procedure execution.
		/// </summary>
		public System.Data.SqlTypes.SqlInt32 Param_RETURN_VALUE {

			get {

				if (!returnValueAvailable) {

					switch (this.currentExecution) {
					
						case CurrentExecution.SqlDataReader:
							if (this.sqlDataReader.IsClosed) {

								RetrieveOutputParameters();
							}
							else {
							
								throw new System.InvalidOperationException("The stored procedure return value has not been populated. You must close the underlying SqlDataReader first !");
							}
							break;

					}
				}
				return(this.internal_Param_RETURN_VALUE);
			}
		}
            
		internal void internal_Set_RETURN_VALUE(System.Data.SqlTypes.SqlInt32 value) {

			this.internal_Param_RETURN_VALUE = value;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@FactureID'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [int]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_FactureID_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlInt32 Param_FactureID {

			get {

				if (this.internal_Param_FactureID_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_FactureID);
			}

			set {

				this.internal_Param_FactureID_UseDefaultValue = false;
				this.internal_Param_FactureID = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@FactureID' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_FactureID_UseDefaultValue() {

			this.internal_Param_FactureID_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@AjustementResume'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_AjustementResume_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_AjustementResume {

			get {

				if (this.internal_Param_AjustementResume_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_AjustementResume);
			}

			set {

				this.internal_Param_AjustementResume_UseDefaultValue = false;
				this.internal_Param_AjustementResume = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@AjustementResume' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_AjustementResume_UseDefaultValue() {

			this.internal_Param_AjustementResume_UseDefaultValue = true;
		}

  	}
}

namespace Gestion_Paie.DataClasses.StoredProcedures {

	/// <summary>
	/// This class allows you to execute the 'jag_Facture' stored procedure;
	/// it gives you the ability to:
	/// <list type="bullet">
	/// <item><description>Set all the necessary parameters to execute the stored procedure</description></item>
	/// <item><description>To execute the stored procedure</description></item>
	/// <item><description>To get back after the execution the return value and all the output parameters value</description></item>
	/// </list>
	/// </summary>
	public sealed class jag_Facture : MarshalByRefObject, IDisposable {


		private bool throwExceptionOnExecute = false;

		/// <summary>
		/// Initializes a new instance of the jag_Facture class.
		/// By default, no exception will be thrown when you call the Execute method. Instead, a Boolean return status will be returned.
		/// </summary>
		public jag_Facture() : this(false) {

		}

		/// <summary>
		/// Initializes a new instance of the jag_Facture class.
		/// </summary>
		/// <param name="throwExceptionOnExecute">True if an exception has to be thrown if the Execute call fails.</param>
		public jag_Facture(bool throwExceptionOnExecute) {

			this.throwExceptionOnExecute = throwExceptionOnExecute;
		}

		private System.Data.SqlClient.SqlConnection sqlConnection;
		/// <summary>
		/// The <see cref="System.Data.SqlClient.SqlConnection">System.Data.SqlClient.SqlConnection</see> that was actually used by this class.
		/// </summary>
		public System.Data.SqlClient.SqlConnection Connection {

			get {

				return(this.sqlConnection);
			}
		}

		/// <summary>
		/// Disposes the current instance of this object.
		/// </summary>
		public void Dispose() {

			Dispose(true);
			GC.SuppressFinalize(this);
		}

		/// <summary>
		/// This member supports the .NET Framework infrastructure and is not intended to be used directly from your code.
		/// </summary>
		private void Dispose(bool disposing) {

			if (disposing) {

			}
		}

		/// <summary>
		/// This member overrides 'Object.Finalize'.
		/// </summary>
		~jag_Facture() {

			Dispose(false);
		}

		private void ResetParameter(ref Gestion_Paie.DataClasses.Parameters.jag_Facture parameters) {

			parameters.internal_Set_RETURN_VALUE (System.Data.SqlTypes.SqlInt32.Null);
		}

		private bool InitializeConnection(ref Gestion_Paie.DataClasses.Parameters.jag_Facture parameters, out System.Data.SqlClient.SqlCommand sqlCommand, ref bool connectionMustBeClosed) {

			try {

				this.sqlConnection = null;
				sqlCommand = null;
				connectionMustBeClosed = true;

				if (parameters.ConnectionType == ConnectionType.None) {

					throw new InvalidOperationException("No connection information was supplied. Consider calling the 'SetUpConnection' method of the Gestion_Paie.DataClasses.Parameters.jag_Facture object before doing this call.");
				}

				if (parameters.ConnectionType == ConnectionType.SqlConnection && parameters.SqlConnection == null) {

					throw new InvalidOperationException("No connection information was supplied (SqlConnection == null). Consider calling the 'SetUpConnection' method of the Gestion_Paie.DataClasses.Parameters.jag_Facture object before doing this call.");
				}

				if (parameters.ConnectionType == ConnectionType.SqlTransaction && parameters.SqlTransaction== null) {

					throw new InvalidOperationException("No connection information was supplied (SqlTransaction == null). Consider calling the 'SetUpConnection' method of the Gestion_Paie.DataClasses.Parameters.jag_Facture object before doing this call.");
				}

				switch (parameters.ConnectionType) {

					case ConnectionType.ConnectionString:

						string connectionString;
				
						if (parameters.ConnectionString.Length == 0) {

							connectionString = Information.GetConnectionStringFromConfigurationFile;
							if (connectionString.Length == 0) {

								connectionString = Information.GetConnectionStringFromRegistry;
							}
						}

						else {

							connectionString = parameters.ConnectionString;
						}

						if (connectionString.Length == 0) {

							throw new System.InvalidOperationException("No connection information was supplied (ConnectionString == \"\")! (Gestion_Paie.DataClasses.Parameters.jag_Facture)");
						}

						parameters.internal_SetErrorSource(ErrorSource.ConnectionOpening);
						this.sqlConnection = new System.Data.SqlClient.SqlConnection(connectionString);
						this.sqlConnection.Open();

						sqlCommand = sqlConnection.CreateCommand();
						break;

					case ConnectionType.SqlConnection:

						sqlConnection = parameters.SqlConnection;

						if (this.sqlConnection.State != System.Data.ConnectionState.Open) {

							this.sqlConnection.Open();
						}
						else {

							connectionMustBeClosed = false;
						}
						sqlCommand = sqlConnection.CreateCommand();
						break;

					case ConnectionType.SqlTransaction:

						sqlCommand = new System.Data.SqlClient.SqlCommand();
						this.sqlConnection = parameters.SqlTransaction.Connection;
						if (this.sqlConnection == null) {

							throw new InvalidOperationException("The transaction is no longer valid.");
						}

						if (this.sqlConnection.State != System.Data.ConnectionState.Open) {
						
							this.sqlConnection.Open();
						}
						else {

							connectionMustBeClosed = false;
						}
						sqlCommand.Connection = sqlConnection;
						sqlCommand.Transaction = parameters.SqlTransaction;						break;
				}

				sqlCommand.CommandTimeout = parameters.CommandTimeOut;
				sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
				sqlCommand.CommandText = "jag_Facture";

				return(true);
			}

			catch (System.Data.SqlClient.SqlException sqlException) {

				sqlConnection = null;
				sqlCommand = null;
				parameters.internal_UpdateExceptionInformation(sqlException);
				return(false);
			}

			catch (System.Exception exception) {

				sqlConnection = null;
				sqlCommand = null;
				parameters.internal_UpdateExceptionInformation(exception);
				return(false);
			}
		}

		private bool DeclareParameters(ref Gestion_Paie.DataClasses.Parameters.jag_Facture parameters, ref System.Data.SqlClient.SqlCommand sqlCommand) {

			try {

				System.Data.SqlClient.SqlParameter sqlParameter;

				sqlParameter = new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4);
				sqlParameter.Direction = System.Data.ParameterDirection.ReturnValue;
				sqlParameter.IsNullable = true;
				sqlParameter.Value = System.DBNull.Value;
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@FactureID", System.Data.SqlDbType.Int, 4);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_FactureID_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_FactureID.IsNull) {

					sqlParameter.Value = parameters.Param_FactureID;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@AjustementResume", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_AjustementResume_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_AjustementResume.IsNull) {

					sqlParameter.Value = parameters.Param_AjustementResume;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);


				return(true);

			}

			catch (System.Data.SqlClient.SqlException sqlException) {

				parameters.internal_UpdateExceptionInformation(sqlException);
				return(false);
			}

			catch (System.Exception exception) {

				parameters.internal_UpdateExceptionInformation(exception);
				return(false);
			}
		}

		private bool RetrieveParameters(ref Gestion_Paie.DataClasses.Parameters.jag_Facture parameters, ref System.Data.SqlClient.SqlCommand sqlCommand) {

			try {

				if (sqlCommand.Parameters["@RETURN_VALUE"].Value != System.DBNull.Value) {

					parameters.internal_Set_RETURN_VALUE ((System.Int32)sqlCommand.Parameters["@RETURN_VALUE"].Value);
				}
				else {

					parameters.internal_Set_RETURN_VALUE (System.Data.SqlTypes.SqlInt32.Null);
				}

				return(true);
			}

			catch (System.Data.SqlClient.SqlException sqlException) {

				parameters.internal_UpdateExceptionInformation(sqlException);
				return(false);
			}

			catch (System.Exception exception) {

				parameters.internal_UpdateExceptionInformation(exception);
				return(false);
			}
		}

		/// <summary>
		/// This method allows you to execute the [jag_Facture] stored procedure and retrieve back the data
		/// accessible via a SqlDataReader (System.Data.SqlClient.SqlDataReader).
		/// </summary>
		/// <param name="parameters">
		/// Contains all the necessary information to execute correctly the stored procedure, i.e. 
		/// the database connection to use and all the necessary input parameters to be supplied
		/// for this stored procedure execution. After the execution, this object will allow you
		/// to retrieve back the stored procedure return value and all the output parameters.
		/// </param>
		/// <param name="sqlDataReader">
		/// Will be created after execution. Don't forget to close it after usage.
		/// </param>
		/// <returns>True if the call was successful. Otherwise, it returns False.</returns>
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.jag_Facture parameters, out System.Data.SqlClient.SqlDataReader sqlDataReader) {

			return(Execute(ref parameters, out sqlDataReader, System.Data.CommandBehavior.Default));
		}

		/// <summary>
		/// This method allows you to execute the [jag_Facture] stored procedure and retrieve back the data
		/// accessible via a SqlDataReader (System.Data.SqlClient.SqlDataReader).
		/// </summary>
		/// <param name="parameters">
		/// Contains all the necessary information to execute correctly the stored procedure, i.e. 
		/// the database connection to use and all the necessary input parameters to be supplied
		/// for this stored procedure execution. After the execution, this object will allow you
		/// to retrieve back the stored procedure return value and all the output parameters.
		/// </param>
		/// <param name="sqlDataReader">
		/// Will be created after execution. Don't forget to close it after usage.
		/// </param>
		/// <param name="commandBehavior">
		/// One of the CommandBehavior values. 
		/// </param>
		/// <returns>True if the call was successful. Otherwise, it returns False.</returns>
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.jag_Facture parameters, out System.Data.SqlClient.SqlDataReader sqlDataReader, System.Data.CommandBehavior commandBehavior) {

			System.Data.SqlClient.SqlCommand sqlCommand = null;
			System.Boolean returnStatus = false;
			System.Boolean connectionMustBeClosed = true;

			try {

				sqlDataReader = null;
				ResetParameter(ref parameters);

				parameters.internal_SetErrorSource(ErrorSource.ConnectionInitialization);
				returnStatus = InitializeConnection(ref parameters, out sqlCommand, ref connectionMustBeClosed);
				if (!returnStatus) {

					return(false);
				}

				parameters.internal_SetErrorSource(ErrorSource.ParametersSetting);
				returnStatus = DeclareParameters(ref parameters, ref sqlCommand);
				if (!returnStatus) {

					return(false);
				}

				parameters.internal_SetErrorSource(ErrorSource.QueryExecution);
				sqlDataReader = sqlCommand.ExecuteReader(commandBehavior);
                
				parameters.internal_Set_ReturnValue_Available(false);

				parameters.internal_Set_SqlDataReader(ref sqlDataReader);
				parameters.internal_Set_SqlCommand(ref sqlCommand);
			}

			catch (System.Data.SqlClient.SqlException sqlException) {

				sqlDataReader = null;
				parameters.internal_UpdateExceptionInformation(sqlException);
				returnStatus = false;

				if (this.throwExceptionOnExecute) {

					throw sqlException;
				}
			}

			catch (System.Exception exception) {

				sqlDataReader = null;
				parameters.internal_UpdateExceptionInformation(exception);
				returnStatus = false;
				parameters.internal_SetErrorSource(ErrorSource.Other);

				if (this.throwExceptionOnExecute) {

					throw exception;
				}
			}

			finally {

				if (sqlCommand != null) {

					sqlCommand.Dispose();
				}

				// We do not close the SqlConnection because the SqlReader object needs it.
				// It is the responsability of the caller to close it by calling: SqlDataReader.Close();

				if (returnStatus) {

					parameters.internal_SetErrorSource(ErrorSource.NoError);
				}
				else {

					if (this.throwExceptionOnExecute) {

						if (parameters.SqlException != null) {

							throw parameters.SqlException;
						}
						else {

							throw parameters.OtherException;
						}
					}
				}
			}
			return(returnStatus);        
		}

		/// <summary>
		/// This method allows you to execute the [jag_Facture] stored procedure and retrieve back the data
		/// populated in a DataSet (System.Data.DataSet).
		/// </summary>
		/// <param name="parameters">
		/// Contains all the necessary information to execute correctly the stored procedure, i.e. 
		/// the database connection to use and all the necessary input parameters to be supplied
		/// for this stored procedure execution. After the execution, this object will allow you
		/// to retrieve back the stored procedure return value and all the output parameters.
		/// </param>
		/// <param name="dataset">
		/// Will be populated with the data after execution. The table based name used will be: 'jag_Facture'.
		/// </param>
		/// <returns>True if the call was successful. Otherwise, it returns False.</returns>
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.jag_Facture parameters, ref System.Data.DataSet dataset) {

			return(Execute(ref parameters, ref dataset, "jag_Facture", -1, -1));
		}

		/// <summary>
		/// This method allows you to execute the [jag_Facture] stored procedure and retrieve back the data
		/// populated in a DataSet (System.Data.DataSet).
		/// </summary>
		/// <param name="parameters">
		/// Contains all the necessary information to execute correctly the stored procedure, i.e. 
		/// the database connection to use and all the necessary input parameters to be supplied
		/// for this stored procedure execution. After the execution, this object will allow you
		/// to retrieve back the stored procedure return value and all the output parameters.
		/// </param>
		/// <param name="dataset">
		/// Will be populated with the data after execution. The table based name used will be: 'jag_Facture'.
		/// </param>
		/// <param name="startRecord">The zero-based record number to start with.</param>
		/// <param name="maxRecords">The maximum number of records to retrieve.</param>
		/// <returns>True if the call was successful. Otherwise, it returns False.</returns>
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.jag_Facture parameters, ref System.Data.DataSet dataset, int startRecord, int maxRecords) {

			return(Execute(ref parameters, ref dataset, "jag_Facture", startRecord, maxRecords));
		}

		/// <summary>
		/// This method allows you to execute the [jag_Facture] stored procedure and retrieve back the data
		/// populated in a DataSet (System.Data.DataSet).
		/// </summary>
		/// <param name="parameters">
		/// Contains all the necessary information to execute correctly the stored procedure, i.e. 
		/// the database connection to use and all the necessary input parameters to be supplied
		/// for this stored procedure execution. After the execution, this object will allow you
		/// to retrieve back the stored procedure return value and all the output parameters.
		/// </param>
		/// <param name="dataset">
		/// Will be populated with the data after execution.
		/// </param>
		/// <param name="tableName">
		/// Will be the based name of the table in the database.
		/// </param>
		/// <returns>True if the call was successful. Otherwise, it returns False.</returns>
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.jag_Facture parameters, ref System.Data.DataSet dataset, string tableName) {

			return(Execute(ref parameters, ref dataset, tableName, -1, -1));
		}

		/// <summary>
		/// This method allows you to execute the [jag_Facture] stored procedure and retrieve back the data
		/// populated in a DataSet (System.Data.DataSet).
		/// </summary>
		/// <param name="parameters">
		/// Contains all the necessary information to execute correctly the stored procedure, i.e. 
		/// the database connection to use and all the necessary input parameters to be supplied
		/// for this stored procedure execution. After the execution, this object will allow you
		/// to retrieve back the stored procedure return value and all the output parameters.
		/// </param>
		/// <param name="dataset">
		/// Will be populated with the data after execution.
		/// </param>
		/// <param name="tableName">
		/// Will be the based name of the table in the database.
		/// </param>
		/// <param name="startRecord">The zero-based record number to start with.</param>
		/// <param name="maxRecords">The maximum number of records to retrieve.</param>
		/// <returns>True if the call was successful. Otherwise, it returns False.</returns>
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.jag_Facture parameters, ref System.Data.DataSet dataset, string tableName, int startRecord, int maxRecords) {

			System.Data.SqlClient.SqlCommand sqlCommand = null;
			System.Data.SqlClient.SqlDataAdapter sqlDataAdapter = null;
			System.Boolean returnStatus = false;
			System.Boolean connectionMustBeClosed = true;

			try {

				if (dataset == null) {

					dataset = new System.Data.DataSet();
				}
				ResetParameter(ref parameters);

				parameters.internal_SetErrorSource(ErrorSource.ConnectionInitialization);
				returnStatus = InitializeConnection(ref parameters, out sqlCommand, ref connectionMustBeClosed);
				if (!returnStatus) {

					return(false);
				}

				parameters.internal_SetErrorSource(ErrorSource.ParametersSetting);
				returnStatus = DeclareParameters(ref parameters, ref sqlCommand);
				if (!returnStatus) {

					return(false);
				}

				parameters.internal_SetErrorSource(ErrorSource.QueryExecution);
				sqlDataAdapter = new System.Data.SqlClient.SqlDataAdapter();
				sqlDataAdapter.SelectCommand = sqlCommand;

				if (startRecord == -1) {

					sqlDataAdapter.Fill(dataset, tableName);
				}
				else {

					sqlDataAdapter.Fill(dataset, startRecord, maxRecords, tableName);
				}
				sqlDataAdapter.Dispose();

				parameters.internal_SetErrorSource(ErrorSource.ParametersRetrieval);
				returnStatus = RetrieveParameters(ref parameters, ref sqlCommand);
			}

			catch (System.Data.SqlClient.SqlException sqlException) {

				dataset = null;
				parameters.internal_UpdateExceptionInformation(sqlException);
				returnStatus = false;

				if (this.throwExceptionOnExecute) {

					throw sqlException;
				}
			}

			catch (System.Exception exception) {

				dataset = null;
				parameters.internal_UpdateExceptionInformation(exception);
				returnStatus = false;
				parameters.internal_SetErrorSource(ErrorSource.Other);

				if (this.throwExceptionOnExecute) {

					throw exception;
				}
			}

			finally {

				if (sqlCommand != null) {

					sqlCommand.Dispose();
				}

				if (parameters.SqlTransaction == null) {

					if (this.sqlConnection != null && connectionMustBeClosed && this.sqlConnection.State == System.Data.ConnectionState.Open) {

						this.sqlConnection.Close();
						this.sqlConnection.Dispose();
					}
				}

				if (returnStatus) {

					parameters.internal_SetErrorSource(ErrorSource.NoError);
				}
				else {

					if (this.throwExceptionOnExecute) {

						if (parameters.SqlException != null) {

							throw parameters.SqlException;
						}
						else {

							throw parameters.OtherException;
						}
					}
				}
			}
			return(returnStatus);
		}

		/// <summary>
		/// This class allows to easily retrieve the name or index of all the fields
		/// of the resulset #1 existing in the Dataset or the SqlDatReader returned by
		/// the Execute method of the 'jag_Facture' class.
		/// </summary>
		public sealed class Resultset1 {


			/// <summary>
			/// This collection provides the fields collection for this resultset.
			/// </summary>
			public sealed class Fields {

				/// <summary>
				/// Allows to get the Index and Name of the field TypeFactureFournisseur via shared members
				/// </summary>
				public sealed class Column_TypeFactureFournisseur {

					/// <summary>
					/// Returns "TypeFactureFournisseur"
					/// </summary>
					public const System.String ColumnName = "TypeFactureFournisseur";
					/// <summary>
					/// Returns 0
					/// </summary>
					public const System.Int32 ColumnIndex = 0;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Facture via shared members
				/// </summary>
				public sealed class Column_Facture {

					/// <summary>
					/// Returns "Facture"
					/// </summary>
					public const System.String ColumnName = "Facture";
					/// <summary>
					/// Returns 1
					/// </summary>
					public const System.Int32 ColumnIndex = 1;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field DateFacture via shared members
				/// </summary>
				public sealed class Column_DateFacture {

					/// <summary>
					/// Returns "DateFacture"
					/// </summary>
					public const System.String ColumnName = "DateFacture";
					/// <summary>
					/// Returns 2
					/// </summary>
					public const System.Int32 ColumnIndex = 2;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field DatePaiement via shared members
				/// </summary>
				public sealed class Column_DatePaiement {

					/// <summary>
					/// Returns "DatePaiement"
					/// </summary>
					public const System.String ColumnName = "DatePaiement";
					/// <summary>
					/// Returns 3
					/// </summary>
					public const System.Int32 ColumnIndex = 3;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Annee via shared members
				/// </summary>
				public sealed class Column_Annee {

					/// <summary>
					/// Returns "Annee"
					/// </summary>
					public const System.String ColumnName = "Annee";
					/// <summary>
					/// Returns 4
					/// </summary>
					public const System.Int32 ColumnIndex = 4;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Periode_Debut via shared members
				/// </summary>
				public sealed class Column_Periode_Debut {

					/// <summary>
					/// Returns "Periode_Debut"
					/// </summary>
					public const System.String ColumnName = "Periode_Debut";
					/// <summary>
					/// Returns 5
					/// </summary>
					public const System.Int32 ColumnIndex = 5;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Periode_Fin via shared members
				/// </summary>
				public sealed class Column_Periode_Fin {

					/// <summary>
					/// Returns "Periode_Fin"
					/// </summary>
					public const System.String ColumnName = "Periode_Fin";
					/// <summary>
					/// Returns 6
					/// </summary>
					public const System.Int32 ColumnIndex = 6;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Date_Debut via shared members
				/// </summary>
				public sealed class Column_Date_Debut {

					/// <summary>
					/// Returns "Date_Debut"
					/// </summary>
					public const System.String ColumnName = "Date_Debut";
					/// <summary>
					/// Returns 7
					/// </summary>
					public const System.Int32 ColumnIndex = 7;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Date_Fin via shared members
				/// </summary>
				public sealed class Column_Date_Fin {

					/// <summary>
					/// Returns "Date_Fin"
					/// </summary>
					public const System.String ColumnName = "Date_Fin";
					/// <summary>
					/// Returns 8
					/// </summary>
					public const System.Int32 ColumnIndex = 8;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field TypeFacture via shared members
				/// </summary>
				public sealed class Column_TypeFacture {

					/// <summary>
					/// Returns "TypeFacture"
					/// </summary>
					public const System.String ColumnName = "TypeFacture";
					/// <summary>
					/// Returns 9
					/// </summary>
					public const System.Int32 ColumnIndex = 9;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field FournisseurID via shared members
				/// </summary>
				public sealed class Column_FournisseurID {

					/// <summary>
					/// Returns "FournisseurID"
					/// </summary>
					public const System.String ColumnName = "FournisseurID";
					/// <summary>
					/// Returns 10
					/// </summary>
					public const System.Int32 ColumnIndex = 10;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Nom via shared members
				/// </summary>
				public sealed class Column_Nom {

					/// <summary>
					/// Returns "Nom"
					/// </summary>
					public const System.String ColumnName = "Nom";
					/// <summary>
					/// Returns 11
					/// </summary>
					public const System.Int32 ColumnIndex = 11;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field AS via shared members
				/// </summary>
				public sealed class Column_AS {

					/// <summary>
					/// Returns "AS"
					/// </summary>
					public const System.String ColumnName = "AS";
					/// <summary>
					/// Returns 12
					/// </summary>
					public const System.Int32 ColumnIndex = 12;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Rue via shared members
				/// </summary>
				public sealed class Column_Rue {

					/// <summary>
					/// Returns "Rue"
					/// </summary>
					public const System.String ColumnName = "Rue";
					/// <summary>
					/// Returns 13
					/// </summary>
					public const System.Int32 ColumnIndex = 13;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Ville via shared members
				/// </summary>
				public sealed class Column_Ville {

					/// <summary>
					/// Returns "Ville"
					/// </summary>
					public const System.String ColumnName = "Ville";
					/// <summary>
					/// Returns 14
					/// </summary>
					public const System.Int32 ColumnIndex = 14;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Code_Postal via shared members
				/// </summary>
				public sealed class Column_Code_Postal {

					/// <summary>
					/// Returns "Code_Postal"
					/// </summary>
					public const System.String ColumnName = "Code_Postal";
					/// <summary>
					/// Returns 15
					/// </summary>
					public const System.Int32 ColumnIndex = 15;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Montant via shared members
				/// </summary>
				public sealed class Column_Montant {

					/// <summary>
					/// Returns "Montant"
					/// </summary>
					public const System.String ColumnName = "Montant";
					/// <summary>
					/// Returns 16
					/// </summary>
					public const System.Int32 ColumnIndex = 16;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field NumeroCheque via shared members
				/// </summary>
				public sealed class Column_NumeroCheque {

					/// <summary>
					/// Returns "NumeroCheque"
					/// </summary>
					public const System.String ColumnName = "NumeroCheque";
					/// <summary>
					/// Returns 17
					/// </summary>
					public const System.Int32 ColumnIndex = 17;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field No_TPS via shared members
				/// </summary>
				public sealed class Column_No_TPS {

					/// <summary>
					/// Returns "No_TPS"
					/// </summary>
					public const System.String ColumnName = "No_TPS";
					/// <summary>
					/// Returns 18
					/// </summary>
					public const System.Int32 ColumnIndex = 18;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field No_TVQ via shared members
				/// </summary>
				public sealed class Column_No_TVQ {

					/// <summary>
					/// Returns "No_TVQ"
					/// </summary>
					public const System.String ColumnName = "No_TVQ";
					/// <summary>
					/// Returns 19
					/// </summary>
					public const System.Int32 ColumnIndex = 19;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Syndicat_No_TPS via shared members
				/// </summary>
				public sealed class Column_Syndicat_No_TPS {

					/// <summary>
					/// Returns "Syndicat_No_TPS"
					/// </summary>
					public const System.String ColumnName = "Syndicat_No_TPS";
					/// <summary>
					/// Returns 20
					/// </summary>
					public const System.Int32 ColumnIndex = 20;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Syndicat_No_TVQ via shared members
				/// </summary>
				public sealed class Column_Syndicat_No_TVQ {

					/// <summary>
					/// Returns "Syndicat_No_TVQ"
					/// </summary>
					public const System.String ColumnName = "Syndicat_No_TVQ";
					/// <summary>
					/// Returns 21
					/// </summary>
					public const System.Int32 ColumnIndex = 21;

				}

			}
		}

		/// <summary>
		/// This class allows to easily retrieve the name or index of all the fields
		/// of the resulset #2 existing in the Dataset or the SqlDatReader returned by
		/// the Execute method of the 'jag_Facture' class.
		/// </summary>
		public sealed class Resultset2 {


			/// <summary>
			/// This collection provides the fields collection for this resultset.
			/// </summary>
			public sealed class Fields {

				/// <summary>
				/// Allows to get the Index and Name of the field TypeFactureFournisseur via shared members
				/// </summary>
				public sealed class Column_TypeFactureFournisseur {

					/// <summary>
					/// Returns "TypeFactureFournisseur"
					/// </summary>
					public const System.String ColumnName = "TypeFactureFournisseur";
					/// <summary>
					/// Returns 0
					/// </summary>
					public const System.Int32 ColumnIndex = 0;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Facture via shared members
				/// </summary>
				public sealed class Column_Facture {

					/// <summary>
					/// Returns "Facture"
					/// </summary>
					public const System.String ColumnName = "Facture";
					/// <summary>
					/// Returns 1
					/// </summary>
					public const System.Int32 ColumnIndex = 1;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field DateFacture via shared members
				/// </summary>
				public sealed class Column_DateFacture {

					/// <summary>
					/// Returns "DateFacture"
					/// </summary>
					public const System.String ColumnName = "DateFacture";
					/// <summary>
					/// Returns 2
					/// </summary>
					public const System.Int32 ColumnIndex = 2;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field DatePaiement via shared members
				/// </summary>
				public sealed class Column_DatePaiement {

					/// <summary>
					/// Returns "DatePaiement"
					/// </summary>
					public const System.String ColumnName = "DatePaiement";
					/// <summary>
					/// Returns 3
					/// </summary>
					public const System.Int32 ColumnIndex = 3;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Annee via shared members
				/// </summary>
				public sealed class Column_Annee {

					/// <summary>
					/// Returns "Annee"
					/// </summary>
					public const System.String ColumnName = "Annee";
					/// <summary>
					/// Returns 4
					/// </summary>
					public const System.Int32 ColumnIndex = 4;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Periode_Debut via shared members
				/// </summary>
				public sealed class Column_Periode_Debut {

					/// <summary>
					/// Returns "Periode_Debut"
					/// </summary>
					public const System.String ColumnName = "Periode_Debut";
					/// <summary>
					/// Returns 5
					/// </summary>
					public const System.Int32 ColumnIndex = 5;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Periode_Fin via shared members
				/// </summary>
				public sealed class Column_Periode_Fin {

					/// <summary>
					/// Returns "Periode_Fin"
					/// </summary>
					public const System.String ColumnName = "Periode_Fin";
					/// <summary>
					/// Returns 6
					/// </summary>
					public const System.Int32 ColumnIndex = 6;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Date_Debut via shared members
				/// </summary>
				public sealed class Column_Date_Debut {

					/// <summary>
					/// Returns "Date_Debut"
					/// </summary>
					public const System.String ColumnName = "Date_Debut";
					/// <summary>
					/// Returns 7
					/// </summary>
					public const System.Int32 ColumnIndex = 7;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Date_Fin via shared members
				/// </summary>
				public sealed class Column_Date_Fin {

					/// <summary>
					/// Returns "Date_Fin"
					/// </summary>
					public const System.String ColumnName = "Date_Fin";
					/// <summary>
					/// Returns 8
					/// </summary>
					public const System.Int32 ColumnIndex = 8;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field TypeFacture via shared members
				/// </summary>
				public sealed class Column_TypeFacture {

					/// <summary>
					/// Returns "TypeFacture"
					/// </summary>
					public const System.String ColumnName = "TypeFacture";
					/// <summary>
					/// Returns 9
					/// </summary>
					public const System.Int32 ColumnIndex = 9;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field FournisseurID via shared members
				/// </summary>
				public sealed class Column_FournisseurID {

					/// <summary>
					/// Returns "FournisseurID"
					/// </summary>
					public const System.String ColumnName = "FournisseurID";
					/// <summary>
					/// Returns 10
					/// </summary>
					public const System.Int32 ColumnIndex = 10;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Nom via shared members
				/// </summary>
				public sealed class Column_Nom {

					/// <summary>
					/// Returns "Nom"
					/// </summary>
					public const System.String ColumnName = "Nom";
					/// <summary>
					/// Returns 11
					/// </summary>
					public const System.Int32 ColumnIndex = 11;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field AS via shared members
				/// </summary>
				public sealed class Column_AS {

					/// <summary>
					/// Returns "AS"
					/// </summary>
					public const System.String ColumnName = "AS";
					/// <summary>
					/// Returns 12
					/// </summary>
					public const System.Int32 ColumnIndex = 12;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Rue via shared members
				/// </summary>
				public sealed class Column_Rue {

					/// <summary>
					/// Returns "Rue"
					/// </summary>
					public const System.String ColumnName = "Rue";
					/// <summary>
					/// Returns 13
					/// </summary>
					public const System.Int32 ColumnIndex = 13;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Ville via shared members
				/// </summary>
				public sealed class Column_Ville {

					/// <summary>
					/// Returns "Ville"
					/// </summary>
					public const System.String ColumnName = "Ville";
					/// <summary>
					/// Returns 14
					/// </summary>
					public const System.Int32 ColumnIndex = 14;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Code_Postal via shared members
				/// </summary>
				public sealed class Column_Code_Postal {

					/// <summary>
					/// Returns "Code_Postal"
					/// </summary>
					public const System.String ColumnName = "Code_Postal";
					/// <summary>
					/// Returns 15
					/// </summary>
					public const System.Int32 ColumnIndex = 15;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Montant via shared members
				/// </summary>
				public sealed class Column_Montant {

					/// <summary>
					/// Returns "Montant"
					/// </summary>
					public const System.String ColumnName = "Montant";
					/// <summary>
					/// Returns 16
					/// </summary>
					public const System.Int32 ColumnIndex = 16;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field NumeroCheque via shared members
				/// </summary>
				public sealed class Column_NumeroCheque {

					/// <summary>
					/// Returns "NumeroCheque"
					/// </summary>
					public const System.String ColumnName = "NumeroCheque";
					/// <summary>
					/// Returns 17
					/// </summary>
					public const System.Int32 ColumnIndex = 17;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field No_TPS via shared members
				/// </summary>
				public sealed class Column_No_TPS {

					/// <summary>
					/// Returns "No_TPS"
					/// </summary>
					public const System.String ColumnName = "No_TPS";
					/// <summary>
					/// Returns 18
					/// </summary>
					public const System.Int32 ColumnIndex = 18;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field No_TVQ via shared members
				/// </summary>
				public sealed class Column_No_TVQ {

					/// <summary>
					/// Returns "No_TVQ"
					/// </summary>
					public const System.String ColumnName = "No_TVQ";
					/// <summary>
					/// Returns 19
					/// </summary>
					public const System.Int32 ColumnIndex = 19;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Syndicat_No_TPS via shared members
				/// </summary>
				public sealed class Column_Syndicat_No_TPS {

					/// <summary>
					/// Returns "Syndicat_No_TPS"
					/// </summary>
					public const System.String ColumnName = "Syndicat_No_TPS";
					/// <summary>
					/// Returns 20
					/// </summary>
					public const System.Int32 ColumnIndex = 20;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Syndicat_No_TVQ via shared members
				/// </summary>
				public sealed class Column_Syndicat_No_TVQ {

					/// <summary>
					/// Returns "Syndicat_No_TVQ"
					/// </summary>
					public const System.String ColumnName = "Syndicat_No_TVQ";
					/// <summary>
					/// Returns 21
					/// </summary>
					public const System.Int32 ColumnIndex = 21;

				}

			}
		}

		/// <summary>
		/// This class allows to easily retrieve the name or index of all the fields
		/// of the resulset #3 existing in the Dataset or the SqlDatReader returned by
		/// the Execute method of the 'jag_Facture' class.
		/// </summary>
		public sealed class Resultset3 {


			/// <summary>
			/// This collection provides the fields collection for this resultset.
			/// </summary>
			public sealed class Fields {

				/// <summary>
				/// Allows to get the Index and Name of the field TypeFactureFournisseur via shared members
				/// </summary>
				public sealed class Column_TypeFactureFournisseur {

					/// <summary>
					/// Returns "TypeFactureFournisseur"
					/// </summary>
					public const System.String ColumnName = "TypeFactureFournisseur";
					/// <summary>
					/// Returns 0
					/// </summary>
					public const System.Int32 ColumnIndex = 0;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Facture via shared members
				/// </summary>
				public sealed class Column_Facture {

					/// <summary>
					/// Returns "Facture"
					/// </summary>
					public const System.String ColumnName = "Facture";
					/// <summary>
					/// Returns 1
					/// </summary>
					public const System.Int32 ColumnIndex = 1;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field DateFacture via shared members
				/// </summary>
				public sealed class Column_DateFacture {

					/// <summary>
					/// Returns "DateFacture"
					/// </summary>
					public const System.String ColumnName = "DateFacture";
					/// <summary>
					/// Returns 2
					/// </summary>
					public const System.Int32 ColumnIndex = 2;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field DatePaiement via shared members
				/// </summary>
				public sealed class Column_DatePaiement {

					/// <summary>
					/// Returns "DatePaiement"
					/// </summary>
					public const System.String ColumnName = "DatePaiement";
					/// <summary>
					/// Returns 3
					/// </summary>
					public const System.Int32 ColumnIndex = 3;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Annee via shared members
				/// </summary>
				public sealed class Column_Annee {

					/// <summary>
					/// Returns "Annee"
					/// </summary>
					public const System.String ColumnName = "Annee";
					/// <summary>
					/// Returns 4
					/// </summary>
					public const System.Int32 ColumnIndex = 4;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Periode_Debut via shared members
				/// </summary>
				public sealed class Column_Periode_Debut {

					/// <summary>
					/// Returns "Periode_Debut"
					/// </summary>
					public const System.String ColumnName = "Periode_Debut";
					/// <summary>
					/// Returns 5
					/// </summary>
					public const System.Int32 ColumnIndex = 5;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Periode_Fin via shared members
				/// </summary>
				public sealed class Column_Periode_Fin {

					/// <summary>
					/// Returns "Periode_Fin"
					/// </summary>
					public const System.String ColumnName = "Periode_Fin";
					/// <summary>
					/// Returns 6
					/// </summary>
					public const System.Int32 ColumnIndex = 6;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field TypeFacture via shared members
				/// </summary>
				public sealed class Column_TypeFacture {

					/// <summary>
					/// Returns "TypeFacture"
					/// </summary>
					public const System.String ColumnName = "TypeFacture";
					/// <summary>
					/// Returns 7
					/// </summary>
					public const System.Int32 ColumnIndex = 7;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field FournisseurID via shared members
				/// </summary>
				public sealed class Column_FournisseurID {

					/// <summary>
					/// Returns "FournisseurID"
					/// </summary>
					public const System.String ColumnName = "FournisseurID";
					/// <summary>
					/// Returns 8
					/// </summary>
					public const System.Int32 ColumnIndex = 8;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Nom via shared members
				/// </summary>
				public sealed class Column_Nom {

					/// <summary>
					/// Returns "Nom"
					/// </summary>
					public const System.String ColumnName = "Nom";
					/// <summary>
					/// Returns 9
					/// </summary>
					public const System.Int32 ColumnIndex = 9;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field AS via shared members
				/// </summary>
				public sealed class Column_AS {

					/// <summary>
					/// Returns "AS"
					/// </summary>
					public const System.String ColumnName = "AS";
					/// <summary>
					/// Returns 10
					/// </summary>
					public const System.Int32 ColumnIndex = 10;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Rue via shared members
				/// </summary>
				public sealed class Column_Rue {

					/// <summary>
					/// Returns "Rue"
					/// </summary>
					public const System.String ColumnName = "Rue";
					/// <summary>
					/// Returns 11
					/// </summary>
					public const System.Int32 ColumnIndex = 11;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Ville via shared members
				/// </summary>
				public sealed class Column_Ville {

					/// <summary>
					/// Returns "Ville"
					/// </summary>
					public const System.String ColumnName = "Ville";
					/// <summary>
					/// Returns 12
					/// </summary>
					public const System.Int32 ColumnIndex = 12;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Code_Postal via shared members
				/// </summary>
				public sealed class Column_Code_Postal {

					/// <summary>
					/// Returns "Code_Postal"
					/// </summary>
					public const System.String ColumnName = "Code_Postal";
					/// <summary>
					/// Returns 13
					/// </summary>
					public const System.Int32 ColumnIndex = 13;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Montant via shared members
				/// </summary>
				public sealed class Column_Montant {

					/// <summary>
					/// Returns "Montant"
					/// </summary>
					public const System.String ColumnName = "Montant";
					/// <summary>
					/// Returns 14
					/// </summary>
					public const System.Int32 ColumnIndex = 14;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field NumeroCheque via shared members
				/// </summary>
				public sealed class Column_NumeroCheque {

					/// <summary>
					/// Returns "NumeroCheque"
					/// </summary>
					public const System.String ColumnName = "NumeroCheque";
					/// <summary>
					/// Returns 15
					/// </summary>
					public const System.Int32 ColumnIndex = 15;

				}

			}
		}

		/// <summary>
		/// This class allows to easily retrieve the name or index of all the fields
		/// of the resulset #4 existing in the Dataset or the SqlDatReader returned by
		/// the Execute method of the 'jag_Facture' class.
		/// </summary>
		public sealed class Resultset4 {


			/// <summary>
			/// This collection provides the fields collection for this resultset.
			/// </summary>
			public sealed class Fields {

				/// <summary>
				/// Allows to get the Index and Name of the field TypeFactureFournisseur via shared members
				/// </summary>
				public sealed class Column_TypeFactureFournisseur {

					/// <summary>
					/// Returns "TypeFactureFournisseur"
					/// </summary>
					public const System.String ColumnName = "TypeFactureFournisseur";
					/// <summary>
					/// Returns 0
					/// </summary>
					public const System.Int32 ColumnIndex = 0;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Facture via shared members
				/// </summary>
				public sealed class Column_Facture {

					/// <summary>
					/// Returns "Facture"
					/// </summary>
					public const System.String ColumnName = "Facture";
					/// <summary>
					/// Returns 1
					/// </summary>
					public const System.Int32 ColumnIndex = 1;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field DateFacture via shared members
				/// </summary>
				public sealed class Column_DateFacture {

					/// <summary>
					/// Returns "DateFacture"
					/// </summary>
					public const System.String ColumnName = "DateFacture";
					/// <summary>
					/// Returns 2
					/// </summary>
					public const System.Int32 ColumnIndex = 2;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field DatePaiement via shared members
				/// </summary>
				public sealed class Column_DatePaiement {

					/// <summary>
					/// Returns "DatePaiement"
					/// </summary>
					public const System.String ColumnName = "DatePaiement";
					/// <summary>
					/// Returns 3
					/// </summary>
					public const System.Int32 ColumnIndex = 3;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Annee via shared members
				/// </summary>
				public sealed class Column_Annee {

					/// <summary>
					/// Returns "Annee"
					/// </summary>
					public const System.String ColumnName = "Annee";
					/// <summary>
					/// Returns 4
					/// </summary>
					public const System.Int32 ColumnIndex = 4;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Periode_Debut via shared members
				/// </summary>
				public sealed class Column_Periode_Debut {

					/// <summary>
					/// Returns "Periode_Debut"
					/// </summary>
					public const System.String ColumnName = "Periode_Debut";
					/// <summary>
					/// Returns 5
					/// </summary>
					public const System.Int32 ColumnIndex = 5;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Periode_Fin via shared members
				/// </summary>
				public sealed class Column_Periode_Fin {

					/// <summary>
					/// Returns "Periode_Fin"
					/// </summary>
					public const System.String ColumnName = "Periode_Fin";
					/// <summary>
					/// Returns 6
					/// </summary>
					public const System.Int32 ColumnIndex = 6;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field TypeFacture via shared members
				/// </summary>
				public sealed class Column_TypeFacture {

					/// <summary>
					/// Returns "TypeFacture"
					/// </summary>
					public const System.String ColumnName = "TypeFacture";
					/// <summary>
					/// Returns 7
					/// </summary>
					public const System.Int32 ColumnIndex = 7;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field FournisseurID via shared members
				/// </summary>
				public sealed class Column_FournisseurID {

					/// <summary>
					/// Returns "FournisseurID"
					/// </summary>
					public const System.String ColumnName = "FournisseurID";
					/// <summary>
					/// Returns 8
					/// </summary>
					public const System.Int32 ColumnIndex = 8;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Nom via shared members
				/// </summary>
				public sealed class Column_Nom {

					/// <summary>
					/// Returns "Nom"
					/// </summary>
					public const System.String ColumnName = "Nom";
					/// <summary>
					/// Returns 9
					/// </summary>
					public const System.Int32 ColumnIndex = 9;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field AS via shared members
				/// </summary>
				public sealed class Column_AS {

					/// <summary>
					/// Returns "AS"
					/// </summary>
					public const System.String ColumnName = "AS";
					/// <summary>
					/// Returns 10
					/// </summary>
					public const System.Int32 ColumnIndex = 10;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Rue via shared members
				/// </summary>
				public sealed class Column_Rue {

					/// <summary>
					/// Returns "Rue"
					/// </summary>
					public const System.String ColumnName = "Rue";
					/// <summary>
					/// Returns 11
					/// </summary>
					public const System.Int32 ColumnIndex = 11;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Ville via shared members
				/// </summary>
				public sealed class Column_Ville {

					/// <summary>
					/// Returns "Ville"
					/// </summary>
					public const System.String ColumnName = "Ville";
					/// <summary>
					/// Returns 12
					/// </summary>
					public const System.Int32 ColumnIndex = 12;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Code_Postal via shared members
				/// </summary>
				public sealed class Column_Code_Postal {

					/// <summary>
					/// Returns "Code_Postal"
					/// </summary>
					public const System.String ColumnName = "Code_Postal";
					/// <summary>
					/// Returns 13
					/// </summary>
					public const System.Int32 ColumnIndex = 13;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Montant via shared members
				/// </summary>
				public sealed class Column_Montant {

					/// <summary>
					/// Returns "Montant"
					/// </summary>
					public const System.String ColumnName = "Montant";
					/// <summary>
					/// Returns 14
					/// </summary>
					public const System.Int32 ColumnIndex = 14;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field NumeroCheque via shared members
				/// </summary>
				public sealed class Column_NumeroCheque {

					/// <summary>
					/// Returns "NumeroCheque"
					/// </summary>
					public const System.String ColumnName = "NumeroCheque";
					/// <summary>
					/// Returns 15
					/// </summary>
					public const System.Int32 ColumnIndex = 15;

				}

			}
		}

		/// <summary>
		/// This class allows to easily retrieve the name or index of all the fields
		/// of the resulset #5 existing in the Dataset or the SqlDatReader returned by
		/// the Execute method of the 'jag_Facture' class.
		/// </summary>
		public sealed class Resultset5 {


			/// <summary>
			/// This collection provides the fields collection for this resultset.
			/// </summary>
			public sealed class Fields {

				/// <summary>
				/// Allows to get the Index and Name of the field TypeFactureFournisseur via shared members
				/// </summary>
				public sealed class Column_TypeFactureFournisseur {

					/// <summary>
					/// Returns "TypeFactureFournisseur"
					/// </summary>
					public const System.String ColumnName = "TypeFactureFournisseur";
					/// <summary>
					/// Returns 0
					/// </summary>
					public const System.Int32 ColumnIndex = 0;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Facture via shared members
				/// </summary>
				public sealed class Column_Facture {

					/// <summary>
					/// Returns "Facture"
					/// </summary>
					public const System.String ColumnName = "Facture";
					/// <summary>
					/// Returns 1
					/// </summary>
					public const System.Int32 ColumnIndex = 1;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field DateFacture via shared members
				/// </summary>
				public sealed class Column_DateFacture {

					/// <summary>
					/// Returns "DateFacture"
					/// </summary>
					public const System.String ColumnName = "DateFacture";
					/// <summary>
					/// Returns 2
					/// </summary>
					public const System.Int32 ColumnIndex = 2;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field DatePaiement via shared members
				/// </summary>
				public sealed class Column_DatePaiement {

					/// <summary>
					/// Returns "DatePaiement"
					/// </summary>
					public const System.String ColumnName = "DatePaiement";
					/// <summary>
					/// Returns 3
					/// </summary>
					public const System.Int32 ColumnIndex = 3;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field TypeFacture via shared members
				/// </summary>
				public sealed class Column_TypeFacture {

					/// <summary>
					/// Returns "TypeFacture"
					/// </summary>
					public const System.String ColumnName = "TypeFacture";
					/// <summary>
					/// Returns 4
					/// </summary>
					public const System.Int32 ColumnIndex = 4;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field FournisseurID via shared members
				/// </summary>
				public sealed class Column_FournisseurID {

					/// <summary>
					/// Returns "FournisseurID"
					/// </summary>
					public const System.String ColumnName = "FournisseurID";
					/// <summary>
					/// Returns 5
					/// </summary>
					public const System.Int32 ColumnIndex = 5;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Nom via shared members
				/// </summary>
				public sealed class Column_Nom {

					/// <summary>
					/// Returns "Nom"
					/// </summary>
					public const System.String ColumnName = "Nom";
					/// <summary>
					/// Returns 6
					/// </summary>
					public const System.Int32 ColumnIndex = 6;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field AS via shared members
				/// </summary>
				public sealed class Column_AS {

					/// <summary>
					/// Returns "AS"
					/// </summary>
					public const System.String ColumnName = "AS";
					/// <summary>
					/// Returns 7
					/// </summary>
					public const System.Int32 ColumnIndex = 7;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Rue via shared members
				/// </summary>
				public sealed class Column_Rue {

					/// <summary>
					/// Returns "Rue"
					/// </summary>
					public const System.String ColumnName = "Rue";
					/// <summary>
					/// Returns 8
					/// </summary>
					public const System.Int32 ColumnIndex = 8;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Ville via shared members
				/// </summary>
				public sealed class Column_Ville {

					/// <summary>
					/// Returns "Ville"
					/// </summary>
					public const System.String ColumnName = "Ville";
					/// <summary>
					/// Returns 9
					/// </summary>
					public const System.Int32 ColumnIndex = 9;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Code_Postal via shared members
				/// </summary>
				public sealed class Column_Code_Postal {

					/// <summary>
					/// Returns "Code_Postal"
					/// </summary>
					public const System.String ColumnName = "Code_Postal";
					/// <summary>
					/// Returns 10
					/// </summary>
					public const System.Int32 ColumnIndex = 10;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Montant via shared members
				/// </summary>
				public sealed class Column_Montant {

					/// <summary>
					/// Returns "Montant"
					/// </summary>
					public const System.String ColumnName = "Montant";
					/// <summary>
					/// Returns 11
					/// </summary>
					public const System.Int32 ColumnIndex = 11;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field NumeroCheque via shared members
				/// </summary>
				public sealed class Column_NumeroCheque {

					/// <summary>
					/// Returns "NumeroCheque"
					/// </summary>
					public const System.String ColumnName = "NumeroCheque";
					/// <summary>
					/// Returns 12
					/// </summary>
					public const System.Int32 ColumnIndex = 12;

				}

			}
		}

		/// <summary>
		/// This class allows to easily retrieve the name or index of all the fields
		/// of the resulset #6 existing in the Dataset or the SqlDatReader returned by
		/// the Execute method of the 'jag_Facture' class.
		/// </summary>
		public sealed class Resultset6 {


			/// <summary>
			/// This collection provides the fields collection for this resultset.
			/// </summary>
			public sealed class Fields {

				/// <summary>
				/// Allows to get the Index and Name of the field Date via shared members
				/// </summary>
				public sealed class Column_Date {

					/// <summary>
					/// Returns "Date"
					/// </summary>
					public const System.String ColumnName = "Date";
					/// <summary>
					/// Returns 0
					/// </summary>
					public const System.Int32 ColumnIndex = 0;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field FactureUsine via shared members
				/// </summary>
				public sealed class Column_FactureUsine {

					/// <summary>
					/// Returns "FactureUsine"
					/// </summary>
					public const System.String ColumnName = "FactureUsine";
					/// <summary>
					/// Returns 1
					/// </summary>
					public const System.Int32 ColumnIndex = 1;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Permis via shared members
				/// </summary>
				public sealed class Column_Permis {

					/// <summary>
					/// Returns "Permis"
					/// </summary>
					public const System.String ColumnName = "Permis";
					/// <summary>
					/// Returns 2
					/// </summary>
					public const System.Int32 ColumnIndex = 2;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field UsineID via shared members
				/// </summary>
				public sealed class Column_UsineID {

					/// <summary>
					/// Returns "UsineID"
					/// </summary>
					public const System.String ColumnName = "UsineID";
					/// <summary>
					/// Returns 3
					/// </summary>
					public const System.Int32 ColumnIndex = 3;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Usine via shared members
				/// </summary>
				public sealed class Column_Usine {

					/// <summary>
					/// Returns "Usine"
					/// </summary>
					public const System.String ColumnName = "Usine";
					/// <summary>
					/// Returns 4
					/// </summary>
					public const System.Int32 ColumnIndex = 4;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Unite via shared members
				/// </summary>
				public sealed class Column_Unite {

					/// <summary>
					/// Returns "Unite"
					/// </summary>
					public const System.String ColumnName = "Unite";
					/// <summary>
					/// Returns 5
					/// </summary>
					public const System.Int32 ColumnIndex = 5;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Essence via shared members
				/// </summary>
				public sealed class Column_Essence {

					/// <summary>
					/// Returns "Essence"
					/// </summary>
					public const System.String ColumnName = "Essence";
					/// <summary>
					/// Returns 6
					/// </summary>
					public const System.Int32 ColumnIndex = 6;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Volume via shared members
				/// </summary>
				public sealed class Column_Volume {

					/// <summary>
					/// Returns "Volume"
					/// </summary>
					public const System.String ColumnName = "Volume";
					/// <summary>
					/// Returns 7
					/// </summary>
					public const System.Int32 ColumnIndex = 7;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field SubTotal via shared members
				/// </summary>
				public sealed class Column_SubTotal {

					/// <summary>
					/// Returns "SubTotal"
					/// </summary>
					public const System.String ColumnName = "SubTotal";
					/// <summary>
					/// Returns 8
					/// </summary>
					public const System.Int32 ColumnIndex = 8;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Taux_Usine via shared members
				/// </summary>
				public sealed class Column_Taux_Usine {

					/// <summary>
					/// Returns "Taux_Usine"
					/// </summary>
					public const System.String ColumnName = "Taux_Usine";
					/// <summary>
					/// Returns 9
					/// </summary>
					public const System.Int32 ColumnIndex = 9;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Montant_Usine via shared members
				/// </summary>
				public sealed class Column_Montant_Usine {

					/// <summary>
					/// Returns "Montant_Usine"
					/// </summary>
					public const System.String ColumnName = "Montant_Usine";
					/// <summary>
					/// Returns 10
					/// </summary>
					public const System.Int32 ColumnIndex = 10;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Taux_TransporteurMoyen via shared members
				/// </summary>
				public sealed class Column_Taux_TransporteurMoyen {

					/// <summary>
					/// Returns "Taux_TransporteurMoyen"
					/// </summary>
					public const System.String ColumnName = "Taux_TransporteurMoyen";
					/// <summary>
					/// Returns 11
					/// </summary>
					public const System.Int32 ColumnIndex = 11;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Montant_TransporteurMoyen via shared members
				/// </summary>
				public sealed class Column_Montant_TransporteurMoyen {

					/// <summary>
					/// Returns "Montant_TransporteurMoyen"
					/// </summary>
					public const System.String ColumnName = "Montant_TransporteurMoyen";
					/// <summary>
					/// Returns 12
					/// </summary>
					public const System.Int32 ColumnIndex = 12;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Taux_Preleve_Plan_Conjoint via shared members
				/// </summary>
				public sealed class Column_Taux_Preleve_Plan_Conjoint {

					/// <summary>
					/// Returns "Taux_Preleve_Plan_Conjoint"
					/// </summary>
					public const System.String ColumnName = "Taux_Preleve_Plan_Conjoint";
					/// <summary>
					/// Returns 13
					/// </summary>
					public const System.Int32 ColumnIndex = 13;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Montant_Preleve_Plan_Conjoint via shared members
				/// </summary>
				public sealed class Column_Montant_Preleve_Plan_Conjoint {

					/// <summary>
					/// Returns "Montant_Preleve_Plan_Conjoint"
					/// </summary>
					public const System.String ColumnName = "Montant_Preleve_Plan_Conjoint";
					/// <summary>
					/// Returns 14
					/// </summary>
					public const System.Int32 ColumnIndex = 14;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Taux_Preleve_Fond_Roulement via shared members
				/// </summary>
				public sealed class Column_Taux_Preleve_Fond_Roulement {

					/// <summary>
					/// Returns "Taux_Preleve_Fond_Roulement"
					/// </summary>
					public const System.String ColumnName = "Taux_Preleve_Fond_Roulement";
					/// <summary>
					/// Returns 15
					/// </summary>
					public const System.Int32 ColumnIndex = 15;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Montant_Preleve_Fond_Roulement via shared members
				/// </summary>
				public sealed class Column_Montant_Preleve_Fond_Roulement {

					/// <summary>
					/// Returns "Montant_Preleve_Fond_Roulement"
					/// </summary>
					public const System.String ColumnName = "Montant_Preleve_Fond_Roulement";
					/// <summary>
					/// Returns 16
					/// </summary>
					public const System.Int32 ColumnIndex = 16;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Taux_Preleve_Fond_Forestier via shared members
				/// </summary>
				public sealed class Column_Taux_Preleve_Fond_Forestier {

					/// <summary>
					/// Returns "Taux_Preleve_Fond_Forestier"
					/// </summary>
					public const System.String ColumnName = "Taux_Preleve_Fond_Forestier";
					/// <summary>
					/// Returns 17
					/// </summary>
					public const System.Int32 ColumnIndex = 17;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Montant_Preleve_Fond_Forestier via shared members
				/// </summary>
				public sealed class Column_Montant_Preleve_Fond_Forestier {

					/// <summary>
					/// Returns "Montant_Preleve_Fond_Forestier"
					/// </summary>
					public const System.String ColumnName = "Montant_Preleve_Fond_Forestier";
					/// <summary>
					/// Returns 18
					/// </summary>
					public const System.Int32 ColumnIndex = 18;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Taux_Preleve_Divers via shared members
				/// </summary>
				public sealed class Column_Taux_Preleve_Divers {

					/// <summary>
					/// Returns "Taux_Preleve_Divers"
					/// </summary>
					public const System.String ColumnName = "Taux_Preleve_Divers";
					/// <summary>
					/// Returns 19
					/// </summary>
					public const System.Int32 ColumnIndex = 19;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Montant_Preleve_Divers via shared members
				/// </summary>
				public sealed class Column_Montant_Preleve_Divers {

					/// <summary>
					/// Returns "Montant_Preleve_Divers"
					/// </summary>
					public const System.String ColumnName = "Montant_Preleve_Divers";
					/// <summary>
					/// Returns 20
					/// </summary>
					public const System.Int32 ColumnIndex = 20;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Taux_Preleve via shared members
				/// </summary>
				public sealed class Column_Taux_Preleve {

					/// <summary>
					/// Returns "Taux_Preleve"
					/// </summary>
					public const System.String ColumnName = "Taux_Preleve";
					/// <summary>
					/// Returns 21
					/// </summary>
					public const System.Int32 ColumnIndex = 21;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Montant_Preleve via shared members
				/// </summary>
				public sealed class Column_Montant_Preleve {

					/// <summary>
					/// Returns "Montant_Preleve"
					/// </summary>
					public const System.String ColumnName = "Montant_Preleve";
					/// <summary>
					/// Returns 22
					/// </summary>
					public const System.Int32 ColumnIndex = 22;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Taux_ProducteurNet via shared members
				/// </summary>
				public sealed class Column_Taux_ProducteurNet {

					/// <summary>
					/// Returns "Taux_ProducteurNet"
					/// </summary>
					public const System.String ColumnName = "Taux_ProducteurNet";
					/// <summary>
					/// Returns 23
					/// </summary>
					public const System.Int32 ColumnIndex = 23;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field UsePreleveMontant via shared members
				/// </summary>
				public sealed class Column_UsePreleveMontant {

					/// <summary>
					/// Returns "UsePreleveMontant"
					/// </summary>
					public const System.String ColumnName = "UsePreleveMontant";
					/// <summary>
					/// Returns 24
					/// </summary>
					public const System.Int32 ColumnIndex = 24;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Montant_ProducteurNet via shared members
				/// </summary>
				public sealed class Column_Montant_ProducteurNet {

					/// <summary>
					/// Returns "Montant_ProducteurNet"
					/// </summary>
					public const System.String ColumnName = "Montant_ProducteurNet";
					/// <summary>
					/// Returns 25
					/// </summary>
					public const System.Int32 ColumnIndex = 25;

				}

			}
		}

		/// <summary>
		/// This class allows to easily retrieve the name or index of all the fields
		/// of the resulset #7 existing in the Dataset or the SqlDatReader returned by
		/// the Execute method of the 'jag_Facture' class.
		/// </summary>
		public sealed class Resultset7 {


			/// <summary>
			/// This collection provides the fields collection for this resultset.
			/// </summary>
			public sealed class Fields {

				/// <summary>
				/// Allows to get the Index and Name of the field Ligne via shared members
				/// </summary>
				public sealed class Column_Ligne {

					/// <summary>
					/// Returns "Ligne"
					/// </summary>
					public const System.String ColumnName = "Ligne";
					/// <summary>
					/// Returns 0
					/// </summary>
					public const System.Int32 ColumnIndex = 0;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Montant via shared members
				/// </summary>
				public sealed class Column_Montant {

					/// <summary>
					/// Returns "Montant"
					/// </summary>
					public const System.String ColumnName = "Montant";
					/// <summary>
					/// Returns 1
					/// </summary>
					public const System.Int32 ColumnIndex = 1;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Description via shared members
				/// </summary>
				public sealed class Column_Description {

					/// <summary>
					/// Returns "Description"
					/// </summary>
					public const System.String ColumnName = "Description";
					/// <summary>
					/// Returns 2
					/// </summary>
					public const System.Int32 ColumnIndex = 2;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field No_Taxe via shared members
				/// </summary>
				public sealed class Column_No_Taxe {

					/// <summary>
					/// Returns "No_Taxe"
					/// </summary>
					public const System.String ColumnName = "No_Taxe";
					/// <summary>
					/// Returns 3
					/// </summary>
					public const System.Int32 ColumnIndex = 3;

				}

			}
		}

		/// <summary>
		/// This class allows to easily retrieve the name or index of all the fields
		/// of the resulset #8 existing in the Dataset or the SqlDatReader returned by
		/// the Execute method of the 'jag_Facture' class.
		/// </summary>
		public sealed class Resultset8 {


			/// <summary>
			/// This collection provides the fields collection for this resultset.
			/// </summary>
			public sealed class Fields {

				/// <summary>
				/// Allows to get the Index and Name of the field MontantSurcharge via shared members
				/// </summary>
				public sealed class Column_MontantSurcharge {

					/// <summary>
					/// Returns "MontantSurcharge"
					/// </summary>
					public const System.String ColumnName = "MontantSurcharge";
					/// <summary>
					/// Returns 0
					/// </summary>
					public const System.Int32 ColumnIndex = 0;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field MontantChargeur via shared members
				/// </summary>
				public sealed class Column_MontantChargeur {

					/// <summary>
					/// Returns "MontantChargeur"
					/// </summary>
					public const System.String ColumnName = "MontantChargeur";
					/// <summary>
					/// Returns 1
					/// </summary>
					public const System.Int32 ColumnIndex = 1;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field MontantCompensationDeDeplacement via shared members
				/// </summary>
				public sealed class Column_MontantCompensationDeDeplacement {

					/// <summary>
					/// Returns "MontantCompensationDeDeplacement"
					/// </summary>
					public const System.String ColumnName = "MontantCompensationDeDeplacement";
					/// <summary>
					/// Returns 2
					/// </summary>
					public const System.Int32 ColumnIndex = 2;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field MontantAutres via shared members
				/// </summary>
				public sealed class Column_MontantAutres {

					/// <summary>
					/// Returns "MontantAutres"
					/// </summary>
					public const System.String ColumnName = "MontantAutres";
					/// <summary>
					/// Returns 3
					/// </summary>
					public const System.Int32 ColumnIndex = 3;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field MontantAutresRevenus via shared members
				/// </summary>
				public sealed class Column_MontantAutresRevenus {

					/// <summary>
					/// Returns "MontantAutresRevenus"
					/// </summary>
					public const System.String ColumnName = "MontantAutresRevenus";
					/// <summary>
					/// Returns 4
					/// </summary>
					public const System.Int32 ColumnIndex = 4;

				}

			}
		}

		/// <summary>
		/// This class allows to easily retrieve the name or index of all the fields
		/// of the resulset #9 existing in the Dataset or the SqlDatReader returned by
		/// the Execute method of the 'jag_Facture' class.
		/// </summary>
		public sealed class Resultset9 {


			/// <summary>
			/// This collection provides the fields collection for this resultset.
			/// </summary>
			public sealed class Fields {

				/// <summary>
				/// Allows to get the Index and Name of the field Contingentement via shared members
				/// </summary>
				public sealed class Column_Contingentement {

					/// <summary>
					/// Returns "Contingentement"
					/// </summary>
					public const System.String ColumnName = "Contingentement";
					/// <summary>
					/// Returns 0
					/// </summary>
					public const System.Int32 ColumnIndex = 0;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field EssenceRegroupement via shared members
				/// </summary>
				public sealed class Column_EssenceRegroupement {

					/// <summary>
					/// Returns "EssenceRegroupement"
					/// </summary>
					public const System.String ColumnName = "EssenceRegroupement";
					/// <summary>
					/// Returns 1
					/// </summary>
					public const System.Int32 ColumnIndex = 1;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field VolumeRestant via shared members
				/// </summary>
				public sealed class Column_VolumeRestant {

					/// <summary>
					/// Returns "VolumeRestant"
					/// </summary>
					public const System.String ColumnName = "VolumeRestant";
					/// <summary>
					/// Returns 2
					/// </summary>
					public const System.Int32 ColumnIndex = 2;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Unite via shared members
				/// </summary>
				public sealed class Column_Unite {

					/// <summary>
					/// Returns "Unite"
					/// </summary>
					public const System.String ColumnName = "Unite";
					/// <summary>
					/// Returns 3
					/// </summary>
					public const System.Int32 ColumnIndex = 3;

				}

			}
		}

		/// <summary>
		/// This class allows to easily retrieve the name or index of all the fields
		/// of the resulset #10 existing in the Dataset or the SqlDatReader returned by
		/// the Execute method of the 'jag_Facture' class.
		/// </summary>
		public sealed class Resultset10 {


			/// <summary>
			/// This collection provides the fields collection for this resultset.
			/// </summary>
			public sealed class Fields {

				/// <summary>
				/// Allows to get the Index and Name of the field Date via shared members
				/// </summary>
				public sealed class Column_Date {

					/// <summary>
					/// Returns "Date"
					/// </summary>
					public const System.String ColumnName = "Date";
					/// <summary>
					/// Returns 0
					/// </summary>
					public const System.Int32 ColumnIndex = 0;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field FactureUsine via shared members
				/// </summary>
				public sealed class Column_FactureUsine {

					/// <summary>
					/// Returns "FactureUsine"
					/// </summary>
					public const System.String ColumnName = "FactureUsine";
					/// <summary>
					/// Returns 1
					/// </summary>
					public const System.Int32 ColumnIndex = 1;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Permis via shared members
				/// </summary>
				public sealed class Column_Permis {

					/// <summary>
					/// Returns "Permis"
					/// </summary>
					public const System.String ColumnName = "Permis";
					/// <summary>
					/// Returns 2
					/// </summary>
					public const System.Int32 ColumnIndex = 2;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field UsineID via shared members
				/// </summary>
				public sealed class Column_UsineID {

					/// <summary>
					/// Returns "UsineID"
					/// </summary>
					public const System.String ColumnName = "UsineID";
					/// <summary>
					/// Returns 3
					/// </summary>
					public const System.Int32 ColumnIndex = 3;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Usine via shared members
				/// </summary>
				public sealed class Column_Usine {

					/// <summary>
					/// Returns "Usine"
					/// </summary>
					public const System.String ColumnName = "Usine";
					/// <summary>
					/// Returns 4
					/// </summary>
					public const System.Int32 ColumnIndex = 4;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Unite via shared members
				/// </summary>
				public sealed class Column_Unite {

					/// <summary>
					/// Returns "Unite"
					/// </summary>
					public const System.String ColumnName = "Unite";
					/// <summary>
					/// Returns 5
					/// </summary>
					public const System.Int32 ColumnIndex = 5;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Essence via shared members
				/// </summary>
				public sealed class Column_Essence {

					/// <summary>
					/// Returns "Essence"
					/// </summary>
					public const System.String ColumnName = "Essence";
					/// <summary>
					/// Returns 6
					/// </summary>
					public const System.Int32 ColumnIndex = 6;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Ajustement via shared members
				/// </summary>
				public sealed class Column_Ajustement {

					/// <summary>
					/// Returns "Ajustement"
					/// </summary>
					public const System.String ColumnName = "Ajustement";
					/// <summary>
					/// Returns 7
					/// </summary>
					public const System.Int32 ColumnIndex = 7;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Volume via shared members
				/// </summary>
				public sealed class Column_Volume {

					/// <summary>
					/// Returns "Volume"
					/// </summary>
					public const System.String ColumnName = "Volume";
					/// <summary>
					/// Returns 8
					/// </summary>
					public const System.Int32 ColumnIndex = 8;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Taux via shared members
				/// </summary>
				public sealed class Column_Taux {

					/// <summary>
					/// Returns "Taux"
					/// </summary>
					public const System.String ColumnName = "Taux";
					/// <summary>
					/// Returns 9
					/// </summary>
					public const System.Int32 ColumnIndex = 9;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Montant via shared members
				/// </summary>
				public sealed class Column_Montant {

					/// <summary>
					/// Returns "Montant"
					/// </summary>
					public const System.String ColumnName = "Montant";
					/// <summary>
					/// Returns 10
					/// </summary>
					public const System.Int32 ColumnIndex = 10;

				}

			}
		}

		/// <summary>
		/// This class allows to easily retrieve the name or index of all the fields
		/// of the resulset #11 existing in the Dataset or the SqlDatReader returned by
		/// the Execute method of the 'jag_Facture' class.
		/// </summary>
		public sealed class Resultset11 {


			/// <summary>
			/// This collection provides the fields collection for this resultset.
			/// </summary>
			public sealed class Fields {

				/// <summary>
				/// Allows to get the Index and Name of the field Ligne via shared members
				/// </summary>
				public sealed class Column_Ligne {

					/// <summary>
					/// Returns "Ligne"
					/// </summary>
					public const System.String ColumnName = "Ligne";
					/// <summary>
					/// Returns 0
					/// </summary>
					public const System.Int32 ColumnIndex = 0;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Montant via shared members
				/// </summary>
				public sealed class Column_Montant {

					/// <summary>
					/// Returns "Montant"
					/// </summary>
					public const System.String ColumnName = "Montant";
					/// <summary>
					/// Returns 1
					/// </summary>
					public const System.Int32 ColumnIndex = 1;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Description via shared members
				/// </summary>
				public sealed class Column_Description {

					/// <summary>
					/// Returns "Description"
					/// </summary>
					public const System.String ColumnName = "Description";
					/// <summary>
					/// Returns 2
					/// </summary>
					public const System.Int32 ColumnIndex = 2;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field No_Taxe via shared members
				/// </summary>
				public sealed class Column_No_Taxe {

					/// <summary>
					/// Returns "No_Taxe"
					/// </summary>
					public const System.String ColumnName = "No_Taxe";
					/// <summary>
					/// Returns 3
					/// </summary>
					public const System.Int32 ColumnIndex = 3;

				}

			}
		}

		/// <summary>
		/// This class allows to easily retrieve the name or index of all the fields
		/// of the resulset #12 existing in the Dataset or the SqlDatReader returned by
		/// the Execute method of the 'jag_Facture' class.
		/// </summary>
		public sealed class Resultset12 {


			/// <summary>
			/// This collection provides the fields collection for this resultset.
			/// </summary>
			public sealed class Fields {

				/// <summary>
				/// Allows to get the Index and Name of the field UsineID via shared members
				/// </summary>
				public sealed class Column_UsineID {

					/// <summary>
					/// Returns "UsineID"
					/// </summary>
					public const System.String ColumnName = "UsineID";
					/// <summary>
					/// Returns 0
					/// </summary>
					public const System.Int32 ColumnIndex = 0;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Usine via shared members
				/// </summary>
				public sealed class Column_Usine {

					/// <summary>
					/// Returns "Usine"
					/// </summary>
					public const System.String ColumnName = "Usine";
					/// <summary>
					/// Returns 1
					/// </summary>
					public const System.Int32 ColumnIndex = 1;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Unite via shared members
				/// </summary>
				public sealed class Column_Unite {

					/// <summary>
					/// Returns "Unite"
					/// </summary>
					public const System.String ColumnName = "Unite";
					/// <summary>
					/// Returns 2
					/// </summary>
					public const System.Int32 ColumnIndex = 2;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Volume via shared members
				/// </summary>
				public sealed class Column_Volume {

					/// <summary>
					/// Returns "Volume"
					/// </summary>
					public const System.String ColumnName = "Volume";
					/// <summary>
					/// Returns 3
					/// </summary>
					public const System.Int32 ColumnIndex = 3;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Taux via shared members
				/// </summary>
				public sealed class Column_Taux {

					/// <summary>
					/// Returns "Taux"
					/// </summary>
					public const System.String ColumnName = "Taux";
					/// <summary>
					/// Returns 4
					/// </summary>
					public const System.Int32 ColumnIndex = 4;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Montant via shared members
				/// </summary>
				public sealed class Column_Montant {

					/// <summary>
					/// Returns "Montant"
					/// </summary>
					public const System.String ColumnName = "Montant";
					/// <summary>
					/// Returns 5
					/// </summary>
					public const System.Int32 ColumnIndex = 5;

				}

			}
		}

		/// <summary>
		/// This class allows to easily retrieve the name or index of all the fields
		/// of the resulset #13 existing in the Dataset or the SqlDatReader returned by
		/// the Execute method of the 'jag_Facture' class.
		/// </summary>
		public sealed class Resultset13 {


			/// <summary>
			/// This collection provides the fields collection for this resultset.
			/// </summary>
			public sealed class Fields {

				/// <summary>
				/// Allows to get the Index and Name of the field Ligne via shared members
				/// </summary>
				public sealed class Column_Ligne {

					/// <summary>
					/// Returns "Ligne"
					/// </summary>
					public const System.String ColumnName = "Ligne";
					/// <summary>
					/// Returns 0
					/// </summary>
					public const System.Int32 ColumnIndex = 0;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Montant via shared members
				/// </summary>
				public sealed class Column_Montant {

					/// <summary>
					/// Returns "Montant"
					/// </summary>
					public const System.String ColumnName = "Montant";
					/// <summary>
					/// Returns 1
					/// </summary>
					public const System.Int32 ColumnIndex = 1;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Description via shared members
				/// </summary>
				public sealed class Column_Description {

					/// <summary>
					/// Returns "Description"
					/// </summary>
					public const System.String ColumnName = "Description";
					/// <summary>
					/// Returns 2
					/// </summary>
					public const System.Int32 ColumnIndex = 2;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field No_Taxe via shared members
				/// </summary>
				public sealed class Column_No_Taxe {

					/// <summary>
					/// Returns "No_Taxe"
					/// </summary>
					public const System.String ColumnName = "No_Taxe";
					/// <summary>
					/// Returns 3
					/// </summary>
					public const System.Int32 ColumnIndex = 3;

				}

			}
		}

		/// <summary>
		/// This class allows to easily retrieve the name or index of all the fields
		/// of the resulset #14 existing in the Dataset or the SqlDatReader returned by
		/// the Execute method of the 'jag_Facture' class.
		/// </summary>
		public sealed class Resultset14 {


			/// <summary>
			/// This collection provides the fields collection for this resultset.
			/// </summary>
			public sealed class Fields {

				/// <summary>
				/// Allows to get the Index and Name of the field Date via shared members
				/// </summary>
				public sealed class Column_Date {

					/// <summary>
					/// Returns "Date"
					/// </summary>
					public const System.String ColumnName = "Date";
					/// <summary>
					/// Returns 0
					/// </summary>
					public const System.Int32 ColumnIndex = 0;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field FactureUsine via shared members
				/// </summary>
				public sealed class Column_FactureUsine {

					/// <summary>
					/// Returns "FactureUsine"
					/// </summary>
					public const System.String ColumnName = "FactureUsine";
					/// <summary>
					/// Returns 1
					/// </summary>
					public const System.Int32 ColumnIndex = 1;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Permis via shared members
				/// </summary>
				public sealed class Column_Permis {

					/// <summary>
					/// Returns "Permis"
					/// </summary>
					public const System.String ColumnName = "Permis";
					/// <summary>
					/// Returns 2
					/// </summary>
					public const System.Int32 ColumnIndex = 2;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field UsineID via shared members
				/// </summary>
				public sealed class Column_UsineID {

					/// <summary>
					/// Returns "UsineID"
					/// </summary>
					public const System.String ColumnName = "UsineID";
					/// <summary>
					/// Returns 3
					/// </summary>
					public const System.Int32 ColumnIndex = 3;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Usine via shared members
				/// </summary>
				public sealed class Column_Usine {

					/// <summary>
					/// Returns "Usine"
					/// </summary>
					public const System.String ColumnName = "Usine";
					/// <summary>
					/// Returns 4
					/// </summary>
					public const System.Int32 ColumnIndex = 4;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Unite via shared members
				/// </summary>
				public sealed class Column_Unite {

					/// <summary>
					/// Returns "Unite"
					/// </summary>
					public const System.String ColumnName = "Unite";
					/// <summary>
					/// Returns 5
					/// </summary>
					public const System.Int32 ColumnIndex = 5;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Essence via shared members
				/// </summary>
				public sealed class Column_Essence {

					/// <summary>
					/// Returns "Essence"
					/// </summary>
					public const System.String ColumnName = "Essence";
					/// <summary>
					/// Returns 6
					/// </summary>
					public const System.Int32 ColumnIndex = 6;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Indexation via shared members
				/// </summary>
				public sealed class Column_Indexation {

					/// <summary>
					/// Returns "Indexation"
					/// </summary>
					public const System.String ColumnName = "Indexation";
					/// <summary>
					/// Returns 7
					/// </summary>
					public const System.Int32 ColumnIndex = 7;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Volume via shared members
				/// </summary>
				public sealed class Column_Volume {

					/// <summary>
					/// Returns "Volume"
					/// </summary>
					public const System.String ColumnName = "Volume";
					/// <summary>
					/// Returns 8
					/// </summary>
					public const System.Int32 ColumnIndex = 8;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field MontantDejaPaye via shared members
				/// </summary>
				public sealed class Column_MontantDejaPaye {

					/// <summary>
					/// Returns "MontantDejaPaye"
					/// </summary>
					public const System.String ColumnName = "MontantDejaPaye";
					/// <summary>
					/// Returns 9
					/// </summary>
					public const System.Int32 ColumnIndex = 9;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field PourcentageDuMontant via shared members
				/// </summary>
				public sealed class Column_PourcentageDuMontant {

					/// <summary>
					/// Returns "PourcentageDuMontant"
					/// </summary>
					public const System.String ColumnName = "PourcentageDuMontant";
					/// <summary>
					/// Returns 10
					/// </summary>
					public const System.Int32 ColumnIndex = 10;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Taux via shared members
				/// </summary>
				public sealed class Column_Taux {

					/// <summary>
					/// Returns "Taux"
					/// </summary>
					public const System.String ColumnName = "Taux";
					/// <summary>
					/// Returns 11
					/// </summary>
					public const System.Int32 ColumnIndex = 11;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Montant via shared members
				/// </summary>
				public sealed class Column_Montant {

					/// <summary>
					/// Returns "Montant"
					/// </summary>
					public const System.String ColumnName = "Montant";
					/// <summary>
					/// Returns 12
					/// </summary>
					public const System.Int32 ColumnIndex = 12;

				}

			}
		}

		/// <summary>
		/// This class allows to easily retrieve the name or index of all the fields
		/// of the resulset #15 existing in the Dataset or the SqlDatReader returned by
		/// the Execute method of the 'jag_Facture' class.
		/// </summary>
		public sealed class Resultset15 {


			/// <summary>
			/// This collection provides the fields collection for this resultset.
			/// </summary>
			public sealed class Fields {

				/// <summary>
				/// Allows to get the Index and Name of the field Ligne via shared members
				/// </summary>
				public sealed class Column_Ligne {

					/// <summary>
					/// Returns "Ligne"
					/// </summary>
					public const System.String ColumnName = "Ligne";
					/// <summary>
					/// Returns 0
					/// </summary>
					public const System.Int32 ColumnIndex = 0;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Montant via shared members
				/// </summary>
				public sealed class Column_Montant {

					/// <summary>
					/// Returns "Montant"
					/// </summary>
					public const System.String ColumnName = "Montant";
					/// <summary>
					/// Returns 1
					/// </summary>
					public const System.Int32 ColumnIndex = 1;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Description via shared members
				/// </summary>
				public sealed class Column_Description {

					/// <summary>
					/// Returns "Description"
					/// </summary>
					public const System.String ColumnName = "Description";
					/// <summary>
					/// Returns 2
					/// </summary>
					public const System.Int32 ColumnIndex = 2;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field No_Taxe via shared members
				/// </summary>
				public sealed class Column_No_Taxe {

					/// <summary>
					/// Returns "No_Taxe"
					/// </summary>
					public const System.String ColumnName = "No_Taxe";
					/// <summary>
					/// Returns 3
					/// </summary>
					public const System.Int32 ColumnIndex = 3;

				}

			}
		}

		/// <summary>
		/// This class allows to easily retrieve the name or index of all the fields
		/// of the resulset #16 existing in the Dataset or the SqlDatReader returned by
		/// the Execute method of the 'jag_Facture' class.
		/// </summary>
		public sealed class Resultset16 {


			/// <summary>
			/// This collection provides the fields collection for this resultset.
			/// </summary>
			public sealed class Fields {

				/// <summary>
				/// Allows to get the Index and Name of the field Date via shared members
				/// </summary>
				public sealed class Column_Date {

					/// <summary>
					/// Returns "Date"
					/// </summary>
					public const System.String ColumnName = "Date";
					/// <summary>
					/// Returns 0
					/// </summary>
					public const System.Int32 ColumnIndex = 0;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field FactureUsine via shared members
				/// </summary>
				public sealed class Column_FactureUsine {

					/// <summary>
					/// Returns "FactureUsine"
					/// </summary>
					public const System.String ColumnName = "FactureUsine";
					/// <summary>
					/// Returns 1
					/// </summary>
					public const System.Int32 ColumnIndex = 1;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Permis via shared members
				/// </summary>
				public sealed class Column_Permis {

					/// <summary>
					/// Returns "Permis"
					/// </summary>
					public const System.String ColumnName = "Permis";
					/// <summary>
					/// Returns 2
					/// </summary>
					public const System.Int32 ColumnIndex = 2;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field UsineID via shared members
				/// </summary>
				public sealed class Column_UsineID {

					/// <summary>
					/// Returns "UsineID"
					/// </summary>
					public const System.String ColumnName = "UsineID";
					/// <summary>
					/// Returns 3
					/// </summary>
					public const System.Int32 ColumnIndex = 3;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Usine via shared members
				/// </summary>
				public sealed class Column_Usine {

					/// <summary>
					/// Returns "Usine"
					/// </summary>
					public const System.String ColumnName = "Usine";
					/// <summary>
					/// Returns 4
					/// </summary>
					public const System.Int32 ColumnIndex = 4;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Unite via shared members
				/// </summary>
				public sealed class Column_Unite {

					/// <summary>
					/// Returns "Unite"
					/// </summary>
					public const System.String ColumnName = "Unite";
					/// <summary>
					/// Returns 5
					/// </summary>
					public const System.Int32 ColumnIndex = 5;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Essence via shared members
				/// </summary>
				public sealed class Column_Essence {

					/// <summary>
					/// Returns "Essence"
					/// </summary>
					public const System.String ColumnName = "Essence";
					/// <summary>
					/// Returns 6
					/// </summary>
					public const System.Int32 ColumnIndex = 6;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field VolumeBrut via shared members
				/// </summary>
				public sealed class Column_VolumeBrut {

					/// <summary>
					/// Returns "VolumeBrut"
					/// </summary>
					public const System.String ColumnName = "VolumeBrut";
					/// <summary>
					/// Returns 7
					/// </summary>
					public const System.Int32 ColumnIndex = 7;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field VolumeSurcharge via shared members
				/// </summary>
				public sealed class Column_VolumeSurcharge {

					/// <summary>
					/// Returns "VolumeSurcharge"
					/// </summary>
					public const System.String ColumnName = "VolumeSurcharge";
					/// <summary>
					/// Returns 8
					/// </summary>
					public const System.Int32 ColumnIndex = 8;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field VolumeNet via shared members
				/// </summary>
				public sealed class Column_VolumeNet {

					/// <summary>
					/// Returns "VolumeNet"
					/// </summary>
					public const System.String ColumnName = "VolumeNet";
					/// <summary>
					/// Returns 9
					/// </summary>
					public const System.Int32 ColumnIndex = 9;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Taux_Transporteur via shared members
				/// </summary>
				public sealed class Column_Taux_Transporteur {

					/// <summary>
					/// Returns "Taux_Transporteur"
					/// </summary>
					public const System.String ColumnName = "Taux_Transporteur";
					/// <summary>
					/// Returns 10
					/// </summary>
					public const System.Int32 ColumnIndex = 10;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Montant_Transporteur via shared members
				/// </summary>
				public sealed class Column_Montant_Transporteur {

					/// <summary>
					/// Returns "Montant_Transporteur"
					/// </summary>
					public const System.String ColumnName = "Montant_Transporteur";
					/// <summary>
					/// Returns 11
					/// </summary>
					public const System.Int32 ColumnIndex = 11;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field SubTotal via shared members
				/// </summary>
				public sealed class Column_SubTotal {

					/// <summary>
					/// Returns "SubTotal"
					/// </summary>
					public const System.String ColumnName = "SubTotal";
					/// <summary>
					/// Returns 12
					/// </summary>
					public const System.Int32 ColumnIndex = 12;

				}

			}
		}

		/// <summary>
		/// This class allows to easily retrieve the name or index of all the fields
		/// of the resulset #17 existing in the Dataset or the SqlDatReader returned by
		/// the Execute method of the 'jag_Facture' class.
		/// </summary>
		public sealed class Resultset17 {


			/// <summary>
			/// This collection provides the fields collection for this resultset.
			/// </summary>
			public sealed class Fields {

				/// <summary>
				/// Allows to get the Index and Name of the field Ligne via shared members
				/// </summary>
				public sealed class Column_Ligne {

					/// <summary>
					/// Returns "Ligne"
					/// </summary>
					public const System.String ColumnName = "Ligne";
					/// <summary>
					/// Returns 0
					/// </summary>
					public const System.Int32 ColumnIndex = 0;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Montant via shared members
				/// </summary>
				public sealed class Column_Montant {

					/// <summary>
					/// Returns "Montant"
					/// </summary>
					public const System.String ColumnName = "Montant";
					/// <summary>
					/// Returns 1
					/// </summary>
					public const System.Int32 ColumnIndex = 1;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Description via shared members
				/// </summary>
				public sealed class Column_Description {

					/// <summary>
					/// Returns "Description"
					/// </summary>
					public const System.String ColumnName = "Description";
					/// <summary>
					/// Returns 2
					/// </summary>
					public const System.Int32 ColumnIndex = 2;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field No_Taxe via shared members
				/// </summary>
				public sealed class Column_No_Taxe {

					/// <summary>
					/// Returns "No_Taxe"
					/// </summary>
					public const System.String ColumnName = "No_Taxe";
					/// <summary>
					/// Returns 3
					/// </summary>
					public const System.Int32 ColumnIndex = 3;

				}

			}
		}

		/// <summary>
		/// This class allows to easily retrieve the name or index of all the fields
		/// of the resulset #18 existing in the Dataset or the SqlDatReader returned by
		/// the Execute method of the 'jag_Facture' class.
		/// </summary>
		public sealed class Resultset18 {


			/// <summary>
			/// This collection provides the fields collection for this resultset.
			/// </summary>
			public sealed class Fields {

				/// <summary>
				/// Allows to get the Index and Name of the field MontantChargeur via shared members
				/// </summary>
				public sealed class Column_MontantChargeur {

					/// <summary>
					/// Returns "MontantChargeur"
					/// </summary>
					public const System.String ColumnName = "MontantChargeur";
					/// <summary>
					/// Returns 0
					/// </summary>
					public const System.Int32 ColumnIndex = 0;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field MontantAutres via shared members
				/// </summary>
				public sealed class Column_MontantAutres {

					/// <summary>
					/// Returns "MontantAutres"
					/// </summary>
					public const System.String ColumnName = "MontantAutres";
					/// <summary>
					/// Returns 1
					/// </summary>
					public const System.Int32 ColumnIndex = 1;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field MontantCompensationDeDeplacement via shared members
				/// </summary>
				public sealed class Column_MontantCompensationDeDeplacement {

					/// <summary>
					/// Returns "MontantCompensationDeDeplacement"
					/// </summary>
					public const System.String ColumnName = "MontantCompensationDeDeplacement";
					/// <summary>
					/// Returns 2
					/// </summary>
					public const System.Int32 ColumnIndex = 2;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field MontantAutresRevenus via shared members
				/// </summary>
				public sealed class Column_MontantAutresRevenus {

					/// <summary>
					/// Returns "MontantAutresRevenus"
					/// </summary>
					public const System.String ColumnName = "MontantAutresRevenus";
					/// <summary>
					/// Returns 3
					/// </summary>
					public const System.Int32 ColumnIndex = 3;

				}

			}
		}

		/// <summary>
		/// This class allows to easily retrieve the name or index of all the fields
		/// of the resulset #19 existing in the Dataset or the SqlDatReader returned by
		/// the Execute method of the 'jag_Facture' class.
		/// </summary>
		public sealed class Resultset19 {


			/// <summary>
			/// This collection provides the fields collection for this resultset.
			/// </summary>
			public sealed class Fields {

				/// <summary>
				/// Allows to get the Index and Name of the field Date via shared members
				/// </summary>
				public sealed class Column_Date {

					/// <summary>
					/// Returns "Date"
					/// </summary>
					public const System.String ColumnName = "Date";
					/// <summary>
					/// Returns 0
					/// </summary>
					public const System.Int32 ColumnIndex = 0;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field FactureUsine via shared members
				/// </summary>
				public sealed class Column_FactureUsine {

					/// <summary>
					/// Returns "FactureUsine"
					/// </summary>
					public const System.String ColumnName = "FactureUsine";
					/// <summary>
					/// Returns 1
					/// </summary>
					public const System.Int32 ColumnIndex = 1;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Permis via shared members
				/// </summary>
				public sealed class Column_Permis {

					/// <summary>
					/// Returns "Permis"
					/// </summary>
					public const System.String ColumnName = "Permis";
					/// <summary>
					/// Returns 2
					/// </summary>
					public const System.Int32 ColumnIndex = 2;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field UsineID via shared members
				/// </summary>
				public sealed class Column_UsineID {

					/// <summary>
					/// Returns "UsineID"
					/// </summary>
					public const System.String ColumnName = "UsineID";
					/// <summary>
					/// Returns 3
					/// </summary>
					public const System.Int32 ColumnIndex = 3;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Usine via shared members
				/// </summary>
				public sealed class Column_Usine {

					/// <summary>
					/// Returns "Usine"
					/// </summary>
					public const System.String ColumnName = "Usine";
					/// <summary>
					/// Returns 4
					/// </summary>
					public const System.Int32 ColumnIndex = 4;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Unite via shared members
				/// </summary>
				public sealed class Column_Unite {

					/// <summary>
					/// Returns "Unite"
					/// </summary>
					public const System.String ColumnName = "Unite";
					/// <summary>
					/// Returns 5
					/// </summary>
					public const System.Int32 ColumnIndex = 5;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Essence via shared members
				/// </summary>
				public sealed class Column_Essence {

					/// <summary>
					/// Returns "Essence"
					/// </summary>
					public const System.String ColumnName = "Essence";
					/// <summary>
					/// Returns 6
					/// </summary>
					public const System.Int32 ColumnIndex = 6;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Ajustement via shared members
				/// </summary>
				public sealed class Column_Ajustement {

					/// <summary>
					/// Returns "Ajustement"
					/// </summary>
					public const System.String ColumnName = "Ajustement";
					/// <summary>
					/// Returns 7
					/// </summary>
					public const System.Int32 ColumnIndex = 7;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Volume via shared members
				/// </summary>
				public sealed class Column_Volume {

					/// <summary>
					/// Returns "Volume"
					/// </summary>
					public const System.String ColumnName = "Volume";
					/// <summary>
					/// Returns 8
					/// </summary>
					public const System.Int32 ColumnIndex = 8;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Taux via shared members
				/// </summary>
				public sealed class Column_Taux {

					/// <summary>
					/// Returns "Taux"
					/// </summary>
					public const System.String ColumnName = "Taux";
					/// <summary>
					/// Returns 9
					/// </summary>
					public const System.Int32 ColumnIndex = 9;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Montant via shared members
				/// </summary>
				public sealed class Column_Montant {

					/// <summary>
					/// Returns "Montant"
					/// </summary>
					public const System.String ColumnName = "Montant";
					/// <summary>
					/// Returns 10
					/// </summary>
					public const System.Int32 ColumnIndex = 10;

				}

			}
		}

		/// <summary>
		/// This class allows to easily retrieve the name or index of all the fields
		/// of the resulset #20 existing in the Dataset or the SqlDatReader returned by
		/// the Execute method of the 'jag_Facture' class.
		/// </summary>
		public sealed class Resultset20 {


			/// <summary>
			/// This collection provides the fields collection for this resultset.
			/// </summary>
			public sealed class Fields {

				/// <summary>
				/// Allows to get the Index and Name of the field Ligne via shared members
				/// </summary>
				public sealed class Column_Ligne {

					/// <summary>
					/// Returns "Ligne"
					/// </summary>
					public const System.String ColumnName = "Ligne";
					/// <summary>
					/// Returns 0
					/// </summary>
					public const System.Int32 ColumnIndex = 0;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Montant via shared members
				/// </summary>
				public sealed class Column_Montant {

					/// <summary>
					/// Returns "Montant"
					/// </summary>
					public const System.String ColumnName = "Montant";
					/// <summary>
					/// Returns 1
					/// </summary>
					public const System.Int32 ColumnIndex = 1;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Description via shared members
				/// </summary>
				public sealed class Column_Description {

					/// <summary>
					/// Returns "Description"
					/// </summary>
					public const System.String ColumnName = "Description";
					/// <summary>
					/// Returns 2
					/// </summary>
					public const System.Int32 ColumnIndex = 2;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field No_Taxe via shared members
				/// </summary>
				public sealed class Column_No_Taxe {

					/// <summary>
					/// Returns "No_Taxe"
					/// </summary>
					public const System.String ColumnName = "No_Taxe";
					/// <summary>
					/// Returns 3
					/// </summary>
					public const System.Int32 ColumnIndex = 3;

				}

			}
		}

		/// <summary>
		/// This class allows to easily retrieve the name or index of all the fields
		/// of the resulset #21 existing in the Dataset or the SqlDatReader returned by
		/// the Execute method of the 'jag_Facture' class.
		/// </summary>
		public sealed class Resultset21 {


			/// <summary>
			/// This collection provides the fields collection for this resultset.
			/// </summary>
			public sealed class Fields {

				/// <summary>
				/// Allows to get the Index and Name of the field Date via shared members
				/// </summary>
				public sealed class Column_Date {

					/// <summary>
					/// Returns "Date"
					/// </summary>
					public const System.String ColumnName = "Date";
					/// <summary>
					/// Returns 0
					/// </summary>
					public const System.Int32 ColumnIndex = 0;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field FactureUsine via shared members
				/// </summary>
				public sealed class Column_FactureUsine {

					/// <summary>
					/// Returns "FactureUsine"
					/// </summary>
					public const System.String ColumnName = "FactureUsine";
					/// <summary>
					/// Returns 1
					/// </summary>
					public const System.Int32 ColumnIndex = 1;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Permis via shared members
				/// </summary>
				public sealed class Column_Permis {

					/// <summary>
					/// Returns "Permis"
					/// </summary>
					public const System.String ColumnName = "Permis";
					/// <summary>
					/// Returns 2
					/// </summary>
					public const System.Int32 ColumnIndex = 2;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field UsineID via shared members
				/// </summary>
				public sealed class Column_UsineID {

					/// <summary>
					/// Returns "UsineID"
					/// </summary>
					public const System.String ColumnName = "UsineID";
					/// <summary>
					/// Returns 3
					/// </summary>
					public const System.Int32 ColumnIndex = 3;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Usine via shared members
				/// </summary>
				public sealed class Column_Usine {

					/// <summary>
					/// Returns "Usine"
					/// </summary>
					public const System.String ColumnName = "Usine";
					/// <summary>
					/// Returns 4
					/// </summary>
					public const System.Int32 ColumnIndex = 4;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Unite via shared members
				/// </summary>
				public sealed class Column_Unite {

					/// <summary>
					/// Returns "Unite"
					/// </summary>
					public const System.String ColumnName = "Unite";
					/// <summary>
					/// Returns 5
					/// </summary>
					public const System.Int32 ColumnIndex = 5;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Essence via shared members
				/// </summary>
				public sealed class Column_Essence {

					/// <summary>
					/// Returns "Essence"
					/// </summary>
					public const System.String ColumnName = "Essence";
					/// <summary>
					/// Returns 6
					/// </summary>
					public const System.Int32 ColumnIndex = 6;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Indexation via shared members
				/// </summary>
				public sealed class Column_Indexation {

					/// <summary>
					/// Returns "Indexation"
					/// </summary>
					public const System.String ColumnName = "Indexation";
					/// <summary>
					/// Returns 7
					/// </summary>
					public const System.Int32 ColumnIndex = 7;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field MontantDejaPaye via shared members
				/// </summary>
				public sealed class Column_MontantDejaPaye {

					/// <summary>
					/// Returns "MontantDejaPaye"
					/// </summary>
					public const System.String ColumnName = "MontantDejaPaye";
					/// <summary>
					/// Returns 8
					/// </summary>
					public const System.Int32 ColumnIndex = 8;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field PourcentageDuMontant via shared members
				/// </summary>
				public sealed class Column_PourcentageDuMontant {

					/// <summary>
					/// Returns "PourcentageDuMontant"
					/// </summary>
					public const System.String ColumnName = "PourcentageDuMontant";
					/// <summary>
					/// Returns 9
					/// </summary>
					public const System.Int32 ColumnIndex = 9;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Montant via shared members
				/// </summary>
				public sealed class Column_Montant {

					/// <summary>
					/// Returns "Montant"
					/// </summary>
					public const System.String ColumnName = "Montant";
					/// <summary>
					/// Returns 10
					/// </summary>
					public const System.Int32 ColumnIndex = 10;

				}

			}
		}

		/// <summary>
		/// This class allows to easily retrieve the name or index of all the fields
		/// of the resulset #22 existing in the Dataset or the SqlDatReader returned by
		/// the Execute method of the 'jag_Facture' class.
		/// </summary>
		public sealed class Resultset22 {


			/// <summary>
			/// This collection provides the fields collection for this resultset.
			/// </summary>
			public sealed class Fields {

				/// <summary>
				/// Allows to get the Index and Name of the field Ligne via shared members
				/// </summary>
				public sealed class Column_Ligne {

					/// <summary>
					/// Returns "Ligne"
					/// </summary>
					public const System.String ColumnName = "Ligne";
					/// <summary>
					/// Returns 0
					/// </summary>
					public const System.Int32 ColumnIndex = 0;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Montant via shared members
				/// </summary>
				public sealed class Column_Montant {

					/// <summary>
					/// Returns "Montant"
					/// </summary>
					public const System.String ColumnName = "Montant";
					/// <summary>
					/// Returns 1
					/// </summary>
					public const System.Int32 ColumnIndex = 1;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Description via shared members
				/// </summary>
				public sealed class Column_Description {

					/// <summary>
					/// Returns "Description"
					/// </summary>
					public const System.String ColumnName = "Description";
					/// <summary>
					/// Returns 2
					/// </summary>
					public const System.Int32 ColumnIndex = 2;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field No_Taxe via shared members
				/// </summary>
				public sealed class Column_No_Taxe {

					/// <summary>
					/// Returns "No_Taxe"
					/// </summary>
					public const System.String ColumnName = "No_Taxe";
					/// <summary>
					/// Returns 3
					/// </summary>
					public const System.Int32 ColumnIndex = 3;

				}

			}
		}

		/// <summary>
		/// This class allows to easily retrieve the name or index of all the fields
		/// of the resulset #23 existing in the Dataset or the SqlDatReader returned by
		/// the Execute method of the 'jag_Facture' class.
		/// </summary>
		public sealed class Resultset23 {


			/// <summary>
			/// This collection provides the fields collection for this resultset.
			/// </summary>
			public sealed class Fields {

				/// <summary>
				/// Allows to get the Index and Name of the field UsineID via shared members
				/// </summary>
				public sealed class Column_UsineID {

					/// <summary>
					/// Returns "UsineID"
					/// </summary>
					public const System.String ColumnName = "UsineID";
					/// <summary>
					/// Returns 0
					/// </summary>
					public const System.Int32 ColumnIndex = 0;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Usine via shared members
				/// </summary>
				public sealed class Column_Usine {

					/// <summary>
					/// Returns "Usine"
					/// </summary>
					public const System.String ColumnName = "Usine";
					/// <summary>
					/// Returns 1
					/// </summary>
					public const System.Int32 ColumnIndex = 1;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Unite via shared members
				/// </summary>
				public sealed class Column_Unite {

					/// <summary>
					/// Returns "Unite"
					/// </summary>
					public const System.String ColumnName = "Unite";
					/// <summary>
					/// Returns 2
					/// </summary>
					public const System.Int32 ColumnIndex = 2;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field VolumePaye via shared members
				/// </summary>
				public sealed class Column_VolumePaye {

					/// <summary>
					/// Returns "VolumePaye"
					/// </summary>
					public const System.String ColumnName = "VolumePaye";
					/// <summary>
					/// Returns 3
					/// </summary>
					public const System.Int32 ColumnIndex = 3;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field MontantDejaPaye via shared members
				/// </summary>
				public sealed class Column_MontantDejaPaye {

					/// <summary>
					/// Returns "MontantDejaPaye"
					/// </summary>
					public const System.String ColumnName = "MontantDejaPaye";
					/// <summary>
					/// Returns 4
					/// </summary>
					public const System.Int32 ColumnIndex = 4;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field PourcentageDuMontant via shared members
				/// </summary>
				public sealed class Column_PourcentageDuMontant {

					/// <summary>
					/// Returns "PourcentageDuMontant"
					/// </summary>
					public const System.String ColumnName = "PourcentageDuMontant";
					/// <summary>
					/// Returns 5
					/// </summary>
					public const System.Int32 ColumnIndex = 5;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Montant via shared members
				/// </summary>
				public sealed class Column_Montant {

					/// <summary>
					/// Returns "Montant"
					/// </summary>
					public const System.String ColumnName = "Montant";
					/// <summary>
					/// Returns 6
					/// </summary>
					public const System.Int32 ColumnIndex = 6;

				}

			}
		}

		/// <summary>
		/// This class allows to easily retrieve the name or index of all the fields
		/// of the resulset #24 existing in the Dataset or the SqlDatReader returned by
		/// the Execute method of the 'jag_Facture' class.
		/// </summary>
		public sealed class Resultset24 {


			/// <summary>
			/// This collection provides the fields collection for this resultset.
			/// </summary>
			public sealed class Fields {

				/// <summary>
				/// Allows to get the Index and Name of the field Date via shared members
				/// </summary>
				public sealed class Column_Date {

					/// <summary>
					/// Returns "Date"
					/// </summary>
					public const System.String ColumnName = "Date";
					/// <summary>
					/// Returns 0
					/// </summary>
					public const System.Int32 ColumnIndex = 0;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field FactureUsine via shared members
				/// </summary>
				public sealed class Column_FactureUsine {

					/// <summary>
					/// Returns "FactureUsine"
					/// </summary>
					public const System.String ColumnName = "FactureUsine";
					/// <summary>
					/// Returns 1
					/// </summary>
					public const System.Int32 ColumnIndex = 1;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Permis via shared members
				/// </summary>
				public sealed class Column_Permis {

					/// <summary>
					/// Returns "Permis"
					/// </summary>
					public const System.String ColumnName = "Permis";
					/// <summary>
					/// Returns 2
					/// </summary>
					public const System.Int32 ColumnIndex = 2;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field UsineID via shared members
				/// </summary>
				public sealed class Column_UsineID {

					/// <summary>
					/// Returns "UsineID"
					/// </summary>
					public const System.String ColumnName = "UsineID";
					/// <summary>
					/// Returns 3
					/// </summary>
					public const System.Int32 ColumnIndex = 3;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Usine via shared members
				/// </summary>
				public sealed class Column_Usine {

					/// <summary>
					/// Returns "Usine"
					/// </summary>
					public const System.String ColumnName = "Usine";
					/// <summary>
					/// Returns 4
					/// </summary>
					public const System.Int32 ColumnIndex = 4;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Unite via shared members
				/// </summary>
				public sealed class Column_Unite {

					/// <summary>
					/// Returns "Unite"
					/// </summary>
					public const System.String ColumnName = "Unite";
					/// <summary>
					/// Returns 5
					/// </summary>
					public const System.Int32 ColumnIndex = 5;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Essence via shared members
				/// </summary>
				public sealed class Column_Essence {

					/// <summary>
					/// Returns "Essence"
					/// </summary>
					public const System.String ColumnName = "Essence";
					/// <summary>
					/// Returns 6
					/// </summary>
					public const System.Int32 ColumnIndex = 6;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field MontantPayeParProducteur via shared members
				/// </summary>
				public sealed class Column_MontantPayeParProducteur {

					/// <summary>
					/// Returns "MontantPayeParProducteur"
					/// </summary>
					public const System.String ColumnName = "MontantPayeParProducteur";
					/// <summary>
					/// Returns 7
					/// </summary>
					public const System.Int32 ColumnIndex = 7;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field MontantPayeParTransporteur via shared members
				/// </summary>
				public sealed class Column_MontantPayeParTransporteur {

					/// <summary>
					/// Returns "MontantPayeParTransporteur"
					/// </summary>
					public const System.String ColumnName = "MontantPayeParTransporteur";
					/// <summary>
					/// Returns 8
					/// </summary>
					public const System.Int32 ColumnIndex = 8;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Montant_Chargeur via shared members
				/// </summary>
				public sealed class Column_Montant_Chargeur {

					/// <summary>
					/// Returns "Montant_Chargeur"
					/// </summary>
					public const System.String ColumnName = "Montant_Chargeur";
					/// <summary>
					/// Returns 9
					/// </summary>
					public const System.Int32 ColumnIndex = 9;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field SubTotal via shared members
				/// </summary>
				public sealed class Column_SubTotal {

					/// <summary>
					/// Returns "SubTotal"
					/// </summary>
					public const System.String ColumnName = "SubTotal";
					/// <summary>
					/// Returns 10
					/// </summary>
					public const System.Int32 ColumnIndex = 10;

				}

			}
		}

		/// <summary>
		/// This class allows to easily retrieve the name or index of all the fields
		/// of the resulset #25 existing in the Dataset or the SqlDatReader returned by
		/// the Execute method of the 'jag_Facture' class.
		/// </summary>
		public sealed class Resultset25 {


			/// <summary>
			/// This collection provides the fields collection for this resultset.
			/// </summary>
			public sealed class Fields {

				/// <summary>
				/// Allows to get the Index and Name of the field Ligne via shared members
				/// </summary>
				public sealed class Column_Ligne {

					/// <summary>
					/// Returns "Ligne"
					/// </summary>
					public const System.String ColumnName = "Ligne";
					/// <summary>
					/// Returns 0
					/// </summary>
					public const System.Int32 ColumnIndex = 0;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Montant via shared members
				/// </summary>
				public sealed class Column_Montant {

					/// <summary>
					/// Returns "Montant"
					/// </summary>
					public const System.String ColumnName = "Montant";
					/// <summary>
					/// Returns 1
					/// </summary>
					public const System.Int32 ColumnIndex = 1;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Description via shared members
				/// </summary>
				public sealed class Column_Description {

					/// <summary>
					/// Returns "Description"
					/// </summary>
					public const System.String ColumnName = "Description";
					/// <summary>
					/// Returns 2
					/// </summary>
					public const System.Int32 ColumnIndex = 2;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field No_Taxe via shared members
				/// </summary>
				public sealed class Column_No_Taxe {

					/// <summary>
					/// Returns "No_Taxe"
					/// </summary>
					public const System.String ColumnName = "No_Taxe";
					/// <summary>
					/// Returns 3
					/// </summary>
					public const System.Int32 ColumnIndex = 3;

				}

			}
		}

		/// <summary>
		/// This class allows to easily retrieve the name or index of all the fields
		/// of the resulset #26 existing in the Dataset or the SqlDatReader returned by
		/// the Execute method of the 'jag_Facture' class.
		/// </summary>
		public sealed class Resultset26 {


			/// <summary>
			/// This collection provides the fields collection for this resultset.
			/// </summary>
			public sealed class Fields {

				/// <summary>
				/// Allows to get the Index and Name of the field Compte via shared members
				/// </summary>
				public sealed class Column_Compte {

					/// <summary>
					/// Returns "Compte"
					/// </summary>
					public const System.String ColumnName = "Compte";
					/// <summary>
					/// Returns 0
					/// </summary>
					public const System.Int32 ColumnIndex = 0;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field CompteDesc via shared members
				/// </summary>
				public sealed class Column_CompteDesc {

					/// <summary>
					/// Returns "CompteDesc"
					/// </summary>
					public const System.String ColumnName = "CompteDesc";
					/// <summary>
					/// Returns 1
					/// </summary>
					public const System.Int32 ColumnIndex = 1;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Montant via shared members
				/// </summary>
				public sealed class Column_Montant {

					/// <summary>
					/// Returns "Montant"
					/// </summary>
					public const System.String ColumnName = "Montant";
					/// <summary>
					/// Returns 2
					/// </summary>
					public const System.Int32 ColumnIndex = 2;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Description via shared members
				/// </summary>
				public sealed class Column_Description {

					/// <summary>
					/// Returns "Description"
					/// </summary>
					public const System.String ColumnName = "Description";
					/// <summary>
					/// Returns 3
					/// </summary>
					public const System.Int32 ColumnIndex = 3;

				}

			}
		}

	}

}

