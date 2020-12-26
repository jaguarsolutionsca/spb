/*
	This C# source code was automatically generated using:

		SQL Server Centric .NET Code Generator
			v 1.0.1287.20792

			Generation Date: 13/09/2006 11:56:52 AM
			Generator name: <Developer Name Here>
			Template last update: 24/06/2002 1:53:57 AM
			Template revision: 15083637

			SQL Server version: 08.00.0194
			Server: andre
			Database: [Gestion_Paie]

	WARNING: This source is provided "AS IS" without warranty of any kind.
	The author disclaims all warranties, either express or implied, including
	the warranties of merchantability and fitness for a particular purpose.
	In no event shall the author or its suppliers be liable for any damages
	whatsoever including direct, indirect, incidental, consequential, loss of
	business profits or special damages, even if the author or its suppliers
	have been advised of the possibility of such damages.
*/

using System;

namespace Gestion_Paie.DataClasses.Parameters {

	/// <summary>
	/// This class allows a developer to specify the parameters expected by the
	/// stored procedure 'jag_GetCalculs_Livraison'. It allows also to specify specific connection
	/// information such as the ConnectionString to be use, the command time-out and so forth.
	/// </summary>
	[Serializable()]
#if OLYMARS_ATTRIBUTE || OLYMARS_DEBUG
	[OlymarsInformation(DeveloperName="<Developer Name Here>", GeneratedOn="2006/09/13 15:56:52", SqlObjectDependancyName="jag_GetCalculs_Livraison", SqlObjectDependancyRevision=2528)]
#endif
	public sealed class jag_GetCalculs_Livraison : MarshalByRefObject, IDisposable, IParameter {

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
		/// Initializes a new instance of the jag_GetCalculs_Livraison class. If you use this constructor version,
		/// not assigning parameter values implies using the parameter default values.
		/// </summary>
		public jag_GetCalculs_Livraison() : this(true) {

		}

		/// <summary>
		/// Initializes a new instance of the jag_GetCalculs_Livraison class.
		/// </summary>
		/// <param name="useDefaultValue">If True, this parameter indicates that "not assigning parameter values" implies "using the parameter default values". If False, this parameter indicates that "not assigning parameter values" implies "using the SQL Server Null value".</param>
		public jag_GetCalculs_Livraison(bool useDefaultValue) {

			this.useDefaultValue = useDefaultValue;

			this.internal_Param_LivraisonID_UseDefaultValue = this.useDefaultValue;
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
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'jag_GetCalculs_Livraison'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

						throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "jag_GetCalculs_Livraison", CurrentRevision, OriginalRevision, System.Environment.NewLine));
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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'jag_GetCalculs_Livraison'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlConnection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "jag_GetCalculs_Livraison", CurrentRevision, OriginalRevision, System.Environment.NewLine));
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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'jag_GetCalculs_Livraison'";
				sqlCommand.Transaction = sqlTransaction;

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlTransaction.Connection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "jag_GetCalculs_Livraison", CurrentRevision, OriginalRevision, System.Environment.NewLine));
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
				this.internal_Param_LivraisonID = System.Data.SqlTypes.SqlInt32.Null;

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
		~jag_GetCalculs_Livraison() {

			Dispose(false);
		}

		/// <summary>
		/// Returns the stored procedure name for which this class was built, i.e. 'jag_GetCalculs_Livraison'.
		/// </summary>
		public string StoredProcedureName {

			get {

				return("jag_GetCalculs_Livraison");
			}
		}

		private System.Data.SqlTypes.SqlInt32 internal_Param_RETURN_VALUE;

		private System.Data.SqlTypes.SqlInt32 internal_Param_LivraisonID;
		internal bool internal_Param_LivraisonID_UseDefaultValue = true;


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

			this.internal_Param_LivraisonID = System.Data.SqlTypes.SqlInt32.Null;
			this.internal_Param_LivraisonID_UseDefaultValue = this.useDefaultValue;

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
		/// Sets the value of the stored procedure INPUT parameter '@LivraisonID'.
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
		/// the parameter default value, consider calling the Param_LivraisonID_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlInt32 Param_LivraisonID {

			get {

				if (this.internal_Param_LivraisonID_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_LivraisonID);
			}

			set {

				this.internal_Param_LivraisonID_UseDefaultValue = false;
				this.internal_Param_LivraisonID = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@LivraisonID' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_LivraisonID_UseDefaultValue() {

			this.internal_Param_LivraisonID_UseDefaultValue = true;
		}

  	}
}

namespace Gestion_Paie.DataClasses.StoredProcedures {

	/// <summary>
	/// This class allows you to execute the 'jag_GetCalculs_Livraison' stored procedure;
	/// it gives you the ability to:
	/// <list type="bullet">
	/// <item><description>Set all the necessary parameters to execute the stored procedure</description></item>
	/// <item><description>To execute the stored procedure</description></item>
	/// <item><description>To get back after the execution the return value and all the output parameters value</description></item>
	/// </list>
	/// </summary>
#if OLYMARS_ATTRIBUTE || OLYMARS_DEBUG
	[OlymarsInformation(DeveloperName="<Developer Name Here>", GeneratedOn="2006/09/13 15:56:52", SqlObjectDependancyName="jag_GetCalculs_Livraison", SqlObjectDependancyRevision=2528)]
#endif
	public sealed class jag_GetCalculs_Livraison : MarshalByRefObject, IDisposable {


		private bool throwExceptionOnExecute = false;

		/// <summary>
		/// Initializes a new instance of the jag_GetCalculs_Livraison class.
		/// By default, no exception will be thrown when you call the Execute method. Instead, a Boolean return status will be returned.
		/// </summary>
		public jag_GetCalculs_Livraison() : this(false) {

		}

		/// <summary>
		/// Initializes a new instance of the jag_GetCalculs_Livraison class.
		/// </summary>
		/// <param name="throwExceptionOnExecute">True if an exception has to be thrown if the Execute call fails.</param>
		public jag_GetCalculs_Livraison(bool throwExceptionOnExecute) {

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
		~jag_GetCalculs_Livraison() {

			Dispose(false);
		}

		private void ResetParameter(ref Gestion_Paie.DataClasses.Parameters.jag_GetCalculs_Livraison parameters) {

			parameters.internal_Set_RETURN_VALUE (System.Data.SqlTypes.SqlInt32.Null);
		}

		private bool InitializeConnection(ref Gestion_Paie.DataClasses.Parameters.jag_GetCalculs_Livraison parameters, out System.Data.SqlClient.SqlCommand sqlCommand, ref bool connectionMustBeClosed) {

			try {

				this.sqlConnection = null;
				sqlCommand = null;
				connectionMustBeClosed = true;

				if (parameters.ConnectionType == ConnectionType.None) {

					throw new InvalidOperationException("No connection information was supplied. Consider calling the 'SetUpConnection' method of the Gestion_Paie.DataClasses.Parameters.jag_GetCalculs_Livraison object before doing this call.");
				}

				if (parameters.ConnectionType == ConnectionType.SqlConnection && parameters.SqlConnection == null) {

					throw new InvalidOperationException("No connection information was supplied (SqlConnection == null). Consider calling the 'SetUpConnection' method of the Gestion_Paie.DataClasses.Parameters.jag_GetCalculs_Livraison object before doing this call.");
				}

				if (parameters.ConnectionType == ConnectionType.SqlTransaction && parameters.SqlTransaction== null) {

					throw new InvalidOperationException("No connection information was supplied (SqlTransaction == null). Consider calling the 'SetUpConnection' method of the Gestion_Paie.DataClasses.Parameters.jag_GetCalculs_Livraison object before doing this call.");
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

							throw new System.InvalidOperationException("No connection information was supplied (ConnectionString == \"\")! (Gestion_Paie.DataClasses.Parameters.jag_GetCalculs_Livraison)");
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
				sqlCommand.CommandText = "jag_GetCalculs_Livraison";

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

		private bool DeclareParameters(ref Gestion_Paie.DataClasses.Parameters.jag_GetCalculs_Livraison parameters, ref System.Data.SqlClient.SqlCommand sqlCommand) {

			try {

				System.Data.SqlClient.SqlParameter sqlParameter;

				sqlParameter = new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4);
				sqlParameter.Direction = System.Data.ParameterDirection.ReturnValue;
				sqlParameter.IsNullable = true;
				sqlParameter.Value = System.DBNull.Value;
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@LivraisonID", System.Data.SqlDbType.Int, 4);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_LivraisonID_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_LivraisonID.IsNull) {

					sqlParameter.Value = parameters.Param_LivraisonID;
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

		private bool RetrieveParameters(ref Gestion_Paie.DataClasses.Parameters.jag_GetCalculs_Livraison parameters, ref System.Data.SqlClient.SqlCommand sqlCommand) {

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
		/// This method allows you to execute the [jag_GetCalculs_Livraison] stored procedure and retrieve back the data
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
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.jag_GetCalculs_Livraison parameters, out System.Data.SqlClient.SqlDataReader sqlDataReader) {

			return(Execute(ref parameters, out sqlDataReader, System.Data.CommandBehavior.Default));
		}

		/// <summary>
		/// This method allows you to execute the [jag_GetCalculs_Livraison] stored procedure and retrieve back the data
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
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.jag_GetCalculs_Livraison parameters, out System.Data.SqlClient.SqlDataReader sqlDataReader, System.Data.CommandBehavior commandBehavior) {

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
		/// This method allows you to execute the [jag_GetCalculs_Livraison] stored procedure and retrieve back the data
		/// populated in a DataSet (System.Data.DataSet).
		/// </summary>
		/// <param name="parameters">
		/// Contains all the necessary information to execute correctly the stored procedure, i.e. 
		/// the database connection to use and all the necessary input parameters to be supplied
		/// for this stored procedure execution. After the execution, this object will allow you
		/// to retrieve back the stored procedure return value and all the output parameters.
		/// </param>
		/// <param name="dataset">
		/// Will be populated with the data after execution. The table based name used will be: 'jag_GetCalculs_Livraison'.
		/// </param>
		/// <returns>True if the call was successful. Otherwise, it returns False.</returns>
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.jag_GetCalculs_Livraison parameters, ref System.Data.DataSet dataset) {

			return(Execute(ref parameters, ref dataset, "jag_GetCalculs_Livraison", -1, -1));
		}

		/// <summary>
		/// This method allows you to execute the [jag_GetCalculs_Livraison] stored procedure and retrieve back the data
		/// populated in a DataSet (System.Data.DataSet).
		/// </summary>
		/// <param name="parameters">
		/// Contains all the necessary information to execute correctly the stored procedure, i.e. 
		/// the database connection to use and all the necessary input parameters to be supplied
		/// for this stored procedure execution. After the execution, this object will allow you
		/// to retrieve back the stored procedure return value and all the output parameters.
		/// </param>
		/// <param name="dataset">
		/// Will be populated with the data after execution. The table based name used will be: 'jag_GetCalculs_Livraison'.
		/// </param>
		/// <param name="startRecord">The zero-based record number to start with.</param>
		/// <param name="maxRecords">The maximum number of records to retrieve.</param>
		/// <returns>True if the call was successful. Otherwise, it returns False.</returns>
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.jag_GetCalculs_Livraison parameters, ref System.Data.DataSet dataset, int startRecord, int maxRecords) {

			return(Execute(ref parameters, ref dataset, "jag_GetCalculs_Livraison", startRecord, maxRecords));
		}

		/// <summary>
		/// This method allows you to execute the [jag_GetCalculs_Livraison] stored procedure and retrieve back the data
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
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.jag_GetCalculs_Livraison parameters, ref System.Data.DataSet dataset, string tableName) {

			return(Execute(ref parameters, ref dataset, tableName, -1, -1));
		}

		/// <summary>
		/// This method allows you to execute the [jag_GetCalculs_Livraison] stored procedure and retrieve back the data
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
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.jag_GetCalculs_Livraison parameters, ref System.Data.DataSet dataset, string tableName, int startRecord, int maxRecords) {

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
		/// the Execute method of the 'jag_GetCalculs_Livraison' class.
		/// </summary>
		public sealed class Resultset1 {


			/// <summary>
			/// This collection provides the fields collection for this resultset.
			/// </summary>
			public sealed class Fields {

				/// <summary>
				/// Allows to get the Index and Name of the field ID via shared members
				/// </summary>
				public sealed class Column_ID {

					/// <summary>
					/// Returns "ID"
					/// </summary>
					public const System.String ColumnName = "ID";
					/// <summary>
					/// Returns 0
					/// </summary>
					public const System.Int32 ColumnIndex = 0;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field EssenceID via shared members
				/// </summary>
				public sealed class Column_EssenceID {

					/// <summary>
					/// Returns "EssenceID"
					/// </summary>
					public const System.String ColumnName = "EssenceID";
					/// <summary>
					/// Returns 1
					/// </summary>
					public const System.Int32 ColumnIndex = 1;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Code via shared members
				/// </summary>
				public sealed class Column_Code {

					/// <summary>
					/// Returns "Code"
					/// </summary>
					public const System.String ColumnName = "Code";
					/// <summary>
					/// Returns 2
					/// </summary>
					public const System.Int32 ColumnIndex = 2;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field UniteMesureID via shared members
				/// </summary>
				public sealed class Column_UniteMesureID {

					/// <summary>
					/// Returns "UniteMesureID"
					/// </summary>
					public const System.String ColumnName = "UniteMesureID";
					/// <summary>
					/// Returns 3
					/// </summary>
					public const System.Int32 ColumnIndex = 3;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurID via shared members
				/// </summary>
				public sealed class Column_ProducteurID {

					/// <summary>
					/// Returns "ProducteurID"
					/// </summary>
					public const System.String ColumnName = "ProducteurID";
					/// <summary>
					/// Returns 4
					/// </summary>
					public const System.Int32 ColumnIndex = 4;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Producteur via shared members
				/// </summary>
				public sealed class Column_Producteur {

					/// <summary>
					/// Returns "Producteur"
					/// </summary>
					public const System.String ColumnName = "Producteur";
					/// <summary>
					/// Returns 5
					/// </summary>
					public const System.Int32 ColumnIndex = 5;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field MunicipaliteID via shared members
				/// </summary>
				public sealed class Column_MunicipaliteID {

					/// <summary>
					/// Returns "MunicipaliteID"
					/// </summary>
					public const System.String ColumnName = "MunicipaliteID";
					/// <summary>
					/// Returns 6
					/// </summary>
					public const System.Int32 ColumnIndex = 6;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Municipalite via shared members
				/// </summary>
				public sealed class Column_Municipalite {

					/// <summary>
					/// Returns "Municipalite"
					/// </summary>
					public const System.String ColumnName = "Municipalite";
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
				/// Allows to get the Index and Name of the field Taux_Usine_Override via shared members
				/// </summary>
				public sealed class Column_Taux_Usine_Override {

					/// <summary>
					/// Returns "Taux_Usine_Override"
					/// </summary>
					public const System.String ColumnName = "Taux_Usine_Override";
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

			}
		}

		/// <summary>
		/// This class allows to easily retrieve the name or index of all the fields
		/// of the resulset #2 existing in the Dataset or the SqlDatReader returned by
		/// the Execute method of the 'jag_GetCalculs_Livraison' class.
		/// </summary>
		public sealed class Resultset2 {


			/// <summary>
			/// This collection provides the fields collection for this resultset.
			/// </summary>
			public sealed class Fields {

				/// <summary>
				/// Allows to get the Index and Name of the field ID via shared members
				/// </summary>
				public sealed class Column_ID {

					/// <summary>
					/// Returns "ID"
					/// </summary>
					public const System.String ColumnName = "ID";
					/// <summary>
					/// Returns 0
					/// </summary>
					public const System.Int32 ColumnIndex = 0;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field EssenceID via shared members
				/// </summary>
				public sealed class Column_EssenceID {

					/// <summary>
					/// Returns "EssenceID"
					/// </summary>
					public const System.String ColumnName = "EssenceID";
					/// <summary>
					/// Returns 1
					/// </summary>
					public const System.Int32 ColumnIndex = 1;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Code via shared members
				/// </summary>
				public sealed class Column_Code {

					/// <summary>
					/// Returns "Code"
					/// </summary>
					public const System.String ColumnName = "Code";
					/// <summary>
					/// Returns 2
					/// </summary>
					public const System.Int32 ColumnIndex = 2;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field UniteMesureID via shared members
				/// </summary>
				public sealed class Column_UniteMesureID {

					/// <summary>
					/// Returns "UniteMesureID"
					/// </summary>
					public const System.String ColumnName = "UniteMesureID";
					/// <summary>
					/// Returns 3
					/// </summary>
					public const System.Int32 ColumnIndex = 3;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurID via shared members
				/// </summary>
				public sealed class Column_ProducteurID {

					/// <summary>
					/// Returns "ProducteurID"
					/// </summary>
					public const System.String ColumnName = "ProducteurID";
					/// <summary>
					/// Returns 4
					/// </summary>
					public const System.Int32 ColumnIndex = 4;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Producteur via shared members
				/// </summary>
				public sealed class Column_Producteur {

					/// <summary>
					/// Returns "Producteur"
					/// </summary>
					public const System.String ColumnName = "Producteur";
					/// <summary>
					/// Returns 5
					/// </summary>
					public const System.Int32 ColumnIndex = 5;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field MunicipaliteID via shared members
				/// </summary>
				public sealed class Column_MunicipaliteID {

					/// <summary>
					/// Returns "MunicipaliteID"
					/// </summary>
					public const System.String ColumnName = "MunicipaliteID";
					/// <summary>
					/// Returns 6
					/// </summary>
					public const System.Int32 ColumnIndex = 6;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Municipalite via shared members
				/// </summary>
				public sealed class Column_Municipalite {

					/// <summary>
					/// Returns "Municipalite"
					/// </summary>
					public const System.String ColumnName = "Municipalite";
					/// <summary>
					/// Returns 7
					/// </summary>
					public const System.Int32 ColumnIndex = 7;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ZoneID via shared members
				/// </summary>
				public sealed class Column_ZoneID {

					/// <summary>
					/// Returns "ZoneID"
					/// </summary>
					public const System.String ColumnName = "ZoneID";
					/// <summary>
					/// Returns 8
					/// </summary>
					public const System.Int32 ColumnIndex = 8;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Zone via shared members
				/// </summary>
				public sealed class Column_Zone {

					/// <summary>
					/// Returns "Zone"
					/// </summary>
					public const System.String ColumnName = "Zone";
					/// <summary>
					/// Returns 9
					/// </summary>
					public const System.Int32 ColumnIndex = 9;

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
					/// Returns 10
					/// </summary>
					public const System.Int32 ColumnIndex = 10;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Taux_Producteur via shared members
				/// </summary>
				public sealed class Column_Taux_Producteur {

					/// <summary>
					/// Returns "Taux_Producteur"
					/// </summary>
					public const System.String ColumnName = "Taux_Producteur";
					/// <summary>
					/// Returns 11
					/// </summary>
					public const System.Int32 ColumnIndex = 11;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Taux_Producteur_Override via shared members
				/// </summary>
				public sealed class Column_Taux_Producteur_Override {

					/// <summary>
					/// Returns "Taux_Producteur_Override"
					/// </summary>
					public const System.String ColumnName = "Taux_Producteur_Override";
					/// <summary>
					/// Returns 12
					/// </summary>
					public const System.Int32 ColumnIndex = 12;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Montant_ProducteurBrut via shared members
				/// </summary>
				public sealed class Column_Montant_ProducteurBrut {

					/// <summary>
					/// Returns "Montant_ProducteurBrut"
					/// </summary>
					public const System.String ColumnName = "Montant_ProducteurBrut";
					/// <summary>
					/// Returns 13
					/// </summary>
					public const System.Int32 ColumnIndex = 13;

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
					/// Returns 14
					/// </summary>
					public const System.Int32 ColumnIndex = 14;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Taux_TransporteurMoyen_Override via shared members
				/// </summary>
				public sealed class Column_Taux_TransporteurMoyen_Override {

					/// <summary>
					/// Returns "Taux_TransporteurMoyen_Override"
					/// </summary>
					public const System.String ColumnName = "Taux_TransporteurMoyen_Override";
					/// <summary>
					/// Returns 15
					/// </summary>
					public const System.Int32 ColumnIndex = 15;

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
					/// Returns 16
					/// </summary>
					public const System.Int32 ColumnIndex = 16;

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
					/// Returns 17
					/// </summary>
					public const System.Int32 ColumnIndex = 17;

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
					/// Returns 18
					/// </summary>
					public const System.Int32 ColumnIndex = 18;

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
					/// Returns 19
					/// </summary>
					public const System.Int32 ColumnIndex = 19;

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
					/// Returns 20
					/// </summary>
					public const System.Int32 ColumnIndex = 20;

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
					/// Returns 21
					/// </summary>
					public const System.Int32 ColumnIndex = 21;

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
					/// Returns 22
					/// </summary>
					public const System.Int32 ColumnIndex = 22;

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
					/// Returns 23
					/// </summary>
					public const System.Int32 ColumnIndex = 23;

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
					/// Returns 24
					/// </summary>
					public const System.Int32 ColumnIndex = 24;

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
					/// Returns 25
					/// </summary>
					public const System.Int32 ColumnIndex = 25;

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
					/// Returns 26
					/// </summary>
					public const System.Int32 ColumnIndex = 26;

				}

			}
		}

		/// <summary>
		/// This class allows to easily retrieve the name or index of all the fields
		/// of the resulset #3 existing in the Dataset or the SqlDatReader returned by
		/// the Execute method of the 'jag_GetCalculs_Livraison' class.
		/// </summary>
		public sealed class Resultset3 {


			/// <summary>
			/// This collection provides the fields collection for this resultset.
			/// </summary>
			public sealed class Fields {

				/// <summary>
				/// Allows to get the Index and Name of the field TransporteurID via shared members
				/// </summary>
				public sealed class Column_TransporteurID {

					/// <summary>
					/// Returns "TransporteurID"
					/// </summary>
					public const System.String ColumnName = "TransporteurID";
					/// <summary>
					/// Returns 0
					/// </summary>
					public const System.Int32 ColumnIndex = 0;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Transporteur via shared members
				/// </summary>
				public sealed class Column_Transporteur {

					/// <summary>
					/// Returns "Transporteur"
					/// </summary>
					public const System.String ColumnName = "Transporteur";
					/// <summary>
					/// Returns 1
					/// </summary>
					public const System.Int32 ColumnIndex = 1;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field UniteMesureID via shared members
				/// </summary>
				public sealed class Column_UniteMesureID {

					/// <summary>
					/// Returns "UniteMesureID"
					/// </summary>
					public const System.String ColumnName = "UniteMesureID";
					/// <summary>
					/// Returns 2
					/// </summary>
					public const System.Int32 ColumnIndex = 2;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field MunicipaliteID via shared members
				/// </summary>
				public sealed class Column_MunicipaliteID {

					/// <summary>
					/// Returns "MunicipaliteID"
					/// </summary>
					public const System.String ColumnName = "MunicipaliteID";
					/// <summary>
					/// Returns 3
					/// </summary>
					public const System.Int32 ColumnIndex = 3;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Municipalite via shared members
				/// </summary>
				public sealed class Column_Municipalite {

					/// <summary>
					/// Returns "Municipalite"
					/// </summary>
					public const System.String ColumnName = "Municipalite";
					/// <summary>
					/// Returns 4
					/// </summary>
					public const System.Int32 ColumnIndex = 4;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field VolumeAPayer via shared members
				/// </summary>
				public sealed class Column_VolumeAPayer {

					/// <summary>
					/// Returns "VolumeAPayer"
					/// </summary>
					public const System.String ColumnName = "VolumeAPayer";
					/// <summary>
					/// Returns 5
					/// </summary>
					public const System.Int32 ColumnIndex = 5;

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
					/// Returns 6
					/// </summary>
					public const System.Int32 ColumnIndex = 6;

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
					/// Returns 7
					/// </summary>
					public const System.Int32 ColumnIndex = 7;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Taux_Transporteur_Override via shared members
				/// </summary>
				public sealed class Column_Taux_Transporteur_Override {

					/// <summary>
					/// Returns "Taux_Transporteur_Override"
					/// </summary>
					public const System.String ColumnName = "Taux_Transporteur_Override";
					/// <summary>
					/// Returns 8
					/// </summary>
					public const System.Int32 ColumnIndex = 8;

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
					/// Returns 9
					/// </summary>
					public const System.Int32 ColumnIndex = 9;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Montant_Surcharge via shared members
				/// </summary>
				public sealed class Column_Montant_Surcharge {

					/// <summary>
					/// Returns "Montant_Surcharge"
					/// </summary>
					public const System.String ColumnName = "Montant_Surcharge";
					/// <summary>
					/// Returns 10
					/// </summary>
					public const System.Int32 ColumnIndex = 10;

				}

			}
		}

		/// <summary>
		/// This class allows to easily retrieve the name or index of all the fields
		/// of the resulset #4 existing in the Dataset or the SqlDatReader returned by
		/// the Execute method of the 'jag_GetCalculs_Livraison' class.
		/// </summary>
		public sealed class Resultset4 {


			/// <summary>
			/// This collection provides the fields collection for this resultset.
			/// </summary>
			public sealed class Fields {

				/// <summary>
				/// Allows to get the Index and Name of the field Montant_Usine via shared members
				/// </summary>
				public sealed class Column_Montant_Usine {

					/// <summary>
					/// Returns "Montant_Usine"
					/// </summary>
					public const System.String ColumnName = "Montant_Usine";
					/// <summary>
					/// Returns 0
					/// </summary>
					public const System.Int32 ColumnIndex = 0;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Montant_Producteur via shared members
				/// </summary>
				public sealed class Column_Montant_Producteur {

					/// <summary>
					/// Returns "Montant_Producteur"
					/// </summary>
					public const System.String ColumnName = "Montant_Producteur";
					/// <summary>
					/// Returns 1
					/// </summary>
					public const System.Int32 ColumnIndex = 1;

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
					/// Returns 2
					/// </summary>
					public const System.Int32 ColumnIndex = 2;

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
					/// Returns 3
					/// </summary>
					public const System.Int32 ColumnIndex = 3;

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
					/// Returns 4
					/// </summary>
					public const System.Int32 ColumnIndex = 4;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Montant_Surcharge via shared members
				/// </summary>
				public sealed class Column_Montant_Surcharge {

					/// <summary>
					/// Returns "Montant_Surcharge"
					/// </summary>
					public const System.String ColumnName = "Montant_Surcharge";
					/// <summary>
					/// Returns 5
					/// </summary>
					public const System.Int32 ColumnIndex = 5;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Montant_MiseEnCommun via shared members
				/// </summary>
				public sealed class Column_Montant_MiseEnCommun {

					/// <summary>
					/// Returns "Montant_MiseEnCommun"
					/// </summary>
					public const System.String ColumnName = "Montant_MiseEnCommun";
					/// <summary>
					/// Returns 6
					/// </summary>
					public const System.Int32 ColumnIndex = 6;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Frais_ChargeurAuProducteur via shared members
				/// </summary>
				public sealed class Column_Frais_ChargeurAuProducteur {

					/// <summary>
					/// Returns "Frais_ChargeurAuProducteur"
					/// </summary>
					public const System.String ColumnName = "Frais_ChargeurAuProducteur";
					/// <summary>
					/// Returns 7
					/// </summary>
					public const System.Int32 ColumnIndex = 7;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Taux_ChargeurAuProducteur via shared members
				/// </summary>
				public sealed class Column_Taux_ChargeurAuProducteur {

					/// <summary>
					/// Returns "Taux_ChargeurAuProducteur"
					/// </summary>
					public const System.String ColumnName = "Taux_ChargeurAuProducteur";
					/// <summary>
					/// Returns 8
					/// </summary>
					public const System.Int32 ColumnIndex = 8;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Frais_ChargeurAuTransporteur via shared members
				/// </summary>
				public sealed class Column_Frais_ChargeurAuTransporteur {

					/// <summary>
					/// Returns "Frais_ChargeurAuTransporteur"
					/// </summary>
					public const System.String ColumnName = "Frais_ChargeurAuTransporteur";
					/// <summary>
					/// Returns 9
					/// </summary>
					public const System.Int32 ColumnIndex = 9;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Taux_ChargeurAuTransporteur via shared members
				/// </summary>
				public sealed class Column_Taux_ChargeurAuTransporteur {

					/// <summary>
					/// Returns "Taux_ChargeurAuTransporteur"
					/// </summary>
					public const System.String ColumnName = "Taux_ChargeurAuTransporteur";
					/// <summary>
					/// Returns 10
					/// </summary>
					public const System.Int32 ColumnIndex = 10;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Frais_AutresAuProducteur via shared members
				/// </summary>
				public sealed class Column_Frais_AutresAuProducteur {

					/// <summary>
					/// Returns "Frais_AutresAuProducteur"
					/// </summary>
					public const System.String ColumnName = "Frais_AutresAuProducteur";
					/// <summary>
					/// Returns 11
					/// </summary>
					public const System.Int32 ColumnIndex = 11;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Frais_AutresAuProducteurDescription via shared members
				/// </summary>
				public sealed class Column_Frais_AutresAuProducteurDescription {

					/// <summary>
					/// Returns "Frais_AutresAuProducteurDescription"
					/// </summary>
					public const System.String ColumnName = "Frais_AutresAuProducteurDescription";
					/// <summary>
					/// Returns 12
					/// </summary>
					public const System.Int32 ColumnIndex = 12;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Frais_AutresAuTransporteur via shared members
				/// </summary>
				public sealed class Column_Frais_AutresAuTransporteur {

					/// <summary>
					/// Returns "Frais_AutresAuTransporteur"
					/// </summary>
					public const System.String ColumnName = "Frais_AutresAuTransporteur";
					/// <summary>
					/// Returns 13
					/// </summary>
					public const System.Int32 ColumnIndex = 13;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Frais_AutresAuTransporteurDescription via shared members
				/// </summary>
				public sealed class Column_Frais_AutresAuTransporteurDescription {

					/// <summary>
					/// Returns "Frais_AutresAuTransporteurDescription"
					/// </summary>
					public const System.String ColumnName = "Frais_AutresAuTransporteurDescription";
					/// <summary>
					/// Returns 14
					/// </summary>
					public const System.Int32 ColumnIndex = 14;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Frais_CompensationDeDeplacement via shared members
				/// </summary>
				public sealed class Column_Frais_CompensationDeDeplacement {

					/// <summary>
					/// Returns "Frais_CompensationDeDeplacement"
					/// </summary>
					public const System.String ColumnName = "Frais_CompensationDeDeplacement";
					/// <summary>
					/// Returns 15
					/// </summary>
					public const System.Int32 ColumnIndex = 15;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Frais_AutresRevenusProducteur via shared members
				/// </summary>
				public sealed class Column_Frais_AutresRevenusProducteur {

					/// <summary>
					/// Returns "Frais_AutresRevenusProducteur"
					/// </summary>
					public const System.String ColumnName = "Frais_AutresRevenusProducteur";
					/// <summary>
					/// Returns 16
					/// </summary>
					public const System.Int32 ColumnIndex = 16;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Frais_AutresRevenusProducteurDescription via shared members
				/// </summary>
				public sealed class Column_Frais_AutresRevenusProducteurDescription {

					/// <summary>
					/// Returns "Frais_AutresRevenusProducteurDescription"
					/// </summary>
					public const System.String ColumnName = "Frais_AutresRevenusProducteurDescription";
					/// <summary>
					/// Returns 17
					/// </summary>
					public const System.Int32 ColumnIndex = 17;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Frais_AutresRevenusTransporteur via shared members
				/// </summary>
				public sealed class Column_Frais_AutresRevenusTransporteur {

					/// <summary>
					/// Returns "Frais_AutresRevenusTransporteur"
					/// </summary>
					public const System.String ColumnName = "Frais_AutresRevenusTransporteur";
					/// <summary>
					/// Returns 18
					/// </summary>
					public const System.Int32 ColumnIndex = 18;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Frais_AutresRevenusTransporteurDescription via shared members
				/// </summary>
				public sealed class Column_Frais_AutresRevenusTransporteurDescription {

					/// <summary>
					/// Returns "Frais_AutresRevenusTransporteurDescription"
					/// </summary>
					public const System.String ColumnName = "Frais_AutresRevenusTransporteurDescription";
					/// <summary>
					/// Returns 19
					/// </summary>
					public const System.Int32 ColumnIndex = 19;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Commentaires_Producteur via shared members
				/// </summary>
				public sealed class Column_Commentaires_Producteur {

					/// <summary>
					/// Returns "Commentaires_Producteur"
					/// </summary>
					public const System.String ColumnName = "Commentaires_Producteur";
					/// <summary>
					/// Returns 20
					/// </summary>
					public const System.Int32 ColumnIndex = 20;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Commentaires_Transporteur via shared members
				/// </summary>
				public sealed class Column_Commentaires_Transporteur {

					/// <summary>
					/// Returns "Commentaires_Transporteur"
					/// </summary>
					public const System.String ColumnName = "Commentaires_Transporteur";
					/// <summary>
					/// Returns 21
					/// </summary>
					public const System.Int32 ColumnIndex = 21;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Commentaires_Chargeur via shared members
				/// </summary>
				public sealed class Column_Commentaires_Chargeur {

					/// <summary>
					/// Returns "Commentaires_Chargeur"
					/// </summary>
					public const System.String ColumnName = "Commentaires_Chargeur";
					/// <summary>
					/// Returns 22
					/// </summary>
					public const System.Int32 ColumnIndex = 22;

				}

			}
		}

	}

}

