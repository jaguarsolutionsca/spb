using System;

namespace Gestion_Paie.DataClasses.Parameters {

	/// <summary>
	/// This class allows a developer to specify the parameters expected by the
	/// stored procedure 'spS_Cert_Proprietaire_Full'. It allows also to specify specific connection
	/// information such as the ConnectionString to be use, the command time-out and so forth.
	/// </summary>
	[Serializable()]
	public sealed class spS_Cert_Proprietaire_Full : MarshalByRefObject, IDisposable, IParameter {

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

		private System.Xml.XmlReader xmlReader = null;
		internal void internal_Set_XmlReader(ref System.Xml.XmlReader xmlReader) {
		
			this.currentExecution = CurrentExecution.XmlReader;
			this.xmlReader = xmlReader;
		}

		internal void internal_SetErrorSource(ErrorSource errorSource) {

			this.errorSource = errorSource;
		}

		private bool useDefaultValue = true;

		/// <summary>
		/// Initializes a new instance of the spS_Cert_Proprietaire_Full class. If you use this constructor version,
		/// not assigning parameter values implies using the parameter default values.
		/// </summary>
		public spS_Cert_Proprietaire_Full() : this(true) {

		}

		/// <summary>
		/// Initializes a new instance of the spS_Cert_Proprietaire_Full class.
		/// </summary>
		/// <param name="useDefaultValue">If True, this parameter indicates that "not assigning parameter values" implies "using the parameter default values". If False, this parameter indicates that "not assigning parameter values" implies "using the SQL Server Null value".</param>
		public spS_Cert_Proprietaire_Full(bool useDefaultValue) {

			this.useDefaultValue = useDefaultValue;

			this.internal_Param_Agence_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_NO_ACT_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_FournisseurID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ReturnXML_UseDefaultValue = this.useDefaultValue;
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
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'spS_Cert_Proprietaire_Full'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

						throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "spS_Cert_Proprietaire_Full", CurrentRevision, OriginalRevision, System.Environment.NewLine));
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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'spS_Cert_Proprietaire_Full'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlConnection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "spS_Cert_Proprietaire_Full", CurrentRevision, OriginalRevision, System.Environment.NewLine));
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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'spS_Cert_Proprietaire_Full'";
				sqlCommand.Transaction = sqlTransaction;

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlTransaction.Connection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "spS_Cert_Proprietaire_Full", CurrentRevision, OriginalRevision, System.Environment.NewLine));
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
				this.internal_Param_Agence = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_NO_ACT = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_FournisseurID = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_ReturnXML = System.Data.SqlTypes.SqlBoolean.Null;

				this.sqlException = null;
				this.otherException = null;
				this.connectionString = null;
				this.sqlConnection = null;
				this.sqlTransaction = null;

				this.sqlCommand = null;
				this.sqlDataReader = null;
				this.xmlReader = null;
			}
		}

		/// <summary>
		/// This member overrides 'Object.Finalize'.
		/// </summary>
		~spS_Cert_Proprietaire_Full() {

			Dispose(false);
		}

		/// <summary>
		/// Returns the stored procedure name for which this class was built, i.e. 'spS_Cert_Proprietaire_Full'.
		/// </summary>
		public string StoredProcedureName {

			get {

				return("spS_Cert_Proprietaire_Full");
			}
		}

		private System.Data.SqlTypes.SqlInt32 internal_Param_RETURN_VALUE;

		private System.Data.SqlTypes.SqlString internal_Param_Agence;
		internal bool internal_Param_Agence_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_NO_ACT;
		internal bool internal_Param_NO_ACT_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_FournisseurID;
		internal bool internal_Param_FournisseurID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ReturnXML;
		internal bool internal_Param_ReturnXML_UseDefaultValue = true;


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
			this.xmlReader = null;

			this.internal_Param_RETURN_VALUE = System.Data.SqlTypes.SqlInt32.Null;

			this.internal_Param_Agence = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_Agence_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_NO_ACT = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_NO_ACT_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_FournisseurID = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_FournisseurID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ReturnXML = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ReturnXML_UseDefaultValue = this.useDefaultValue;

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

						case CurrentExecution.XmlReader:
							if (this.xmlReader.ReadState == System.Xml.ReadState.Closed) {

								RetrieveOutputParameters();
							}
							else {
							
								throw new System.InvalidOperationException("The stored procedure return value has not been populated. You must close the underlying XmlReader first !");
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
		/// Sets the value of the stored procedure INPUT parameter '@Agence'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [varchar](10)
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_Agence_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_Agence {

			get {

				if (this.internal_Param_Agence_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Agence);
			}

			set {

				this.internal_Param_Agence_UseDefaultValue = false;
				this.internal_Param_Agence = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Agence' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Agence_UseDefaultValue() {

			this.internal_Param_Agence_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@NO_ACT'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [varchar](10)
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_NO_ACT_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_NO_ACT {

			get {

				if (this.internal_Param_NO_ACT_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_NO_ACT);
			}

			set {

				this.internal_Param_NO_ACT_UseDefaultValue = false;
				this.internal_Param_NO_ACT = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@NO_ACT' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_NO_ACT_UseDefaultValue() {

			this.internal_Param_NO_ACT_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@FournisseurID'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [varchar](15)
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_FournisseurID_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_FournisseurID {

			get {

				if (this.internal_Param_FournisseurID_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_FournisseurID);
			}

			set {

				this.internal_Param_FournisseurID_UseDefaultValue = false;
				this.internal_Param_FournisseurID = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@FournisseurID' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_FournisseurID_UseDefaultValue() {

			this.internal_Param_FournisseurID_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ReturnXML'.
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
		/// the parameter default value, consider calling the Param_ReturnXML_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ReturnXML {

			get {

				if (this.internal_Param_ReturnXML_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ReturnXML);
			}

			set {

				this.internal_Param_ReturnXML_UseDefaultValue = false;
				this.internal_Param_ReturnXML = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ReturnXML' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ReturnXML_UseDefaultValue() {

			this.internal_Param_ReturnXML_UseDefaultValue = true;
		}

  	}
}

namespace Gestion_Paie.DataClasses.StoredProcedures {

	/// <summary>
	/// This class allows you to execute the 'spS_Cert_Proprietaire_Full' stored procedure;
	/// it gives you the ability to:
	/// <list type="bullet">
	/// <item><description>Set all the necessary parameters to execute the stored procedure</description></item>
	/// <item><description>To execute the stored procedure</description></item>
	/// <item><description>To get back after the execution the return value and all the output parameters value</description></item>
	/// </list>
	/// </summary>
	public sealed class spS_Cert_Proprietaire_Full : MarshalByRefObject, IDisposable {


		private bool throwExceptionOnExecute = false;

		/// <summary>
		/// Initializes a new instance of the spS_Cert_Proprietaire_Full class.
		/// By default, no exception will be thrown when you call the Execute method. Instead, a Boolean return status will be returned.
		/// </summary>
		public spS_Cert_Proprietaire_Full() : this(false) {

		}

		/// <summary>
		/// Initializes a new instance of the spS_Cert_Proprietaire_Full class.
		/// </summary>
		/// <param name="throwExceptionOnExecute">True if an exception has to be thrown if the Execute call fails.</param>
		public spS_Cert_Proprietaire_Full(bool throwExceptionOnExecute) {

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
		~spS_Cert_Proprietaire_Full() {

			Dispose(false);
		}

		private void ResetParameter(ref Gestion_Paie.DataClasses.Parameters.spS_Cert_Proprietaire_Full parameters) {

			parameters.internal_Set_RETURN_VALUE (System.Data.SqlTypes.SqlInt32.Null);
		}

		private bool InitializeConnection(ref Gestion_Paie.DataClasses.Parameters.spS_Cert_Proprietaire_Full parameters, out System.Data.SqlClient.SqlCommand sqlCommand, ref bool connectionMustBeClosed) {

			try {

				this.sqlConnection = null;
				sqlCommand = null;
				connectionMustBeClosed = true;

				if (parameters.ConnectionType == ConnectionType.None) {

					throw new InvalidOperationException("No connection information was supplied. Consider calling the 'SetUpConnection' method of the Gestion_Paie.DataClasses.Parameters.spS_Cert_Proprietaire_Full object before doing this call.");
				}

				if (parameters.ConnectionType == ConnectionType.SqlConnection && parameters.SqlConnection == null) {

					throw new InvalidOperationException("No connection information was supplied (SqlConnection == null). Consider calling the 'SetUpConnection' method of the Gestion_Paie.DataClasses.Parameters.spS_Cert_Proprietaire_Full object before doing this call.");
				}

				if (parameters.ConnectionType == ConnectionType.SqlTransaction && parameters.SqlTransaction== null) {

					throw new InvalidOperationException("No connection information was supplied (SqlTransaction == null). Consider calling the 'SetUpConnection' method of the Gestion_Paie.DataClasses.Parameters.spS_Cert_Proprietaire_Full object before doing this call.");
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

							throw new System.InvalidOperationException("No connection information was supplied (ConnectionString == \"\")! (Gestion_Paie.DataClasses.Parameters.spS_Cert_Proprietaire_Full)");
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
				sqlCommand.CommandText = "spS_Cert_Proprietaire_Full";

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

		private bool DeclareParameters(ref Gestion_Paie.DataClasses.Parameters.spS_Cert_Proprietaire_Full parameters, ref System.Data.SqlClient.SqlCommand sqlCommand) {

			try {

				System.Data.SqlClient.SqlParameter sqlParameter;

				sqlParameter = new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4);
				sqlParameter.Direction = System.Data.ParameterDirection.ReturnValue;
				sqlParameter.IsNullable = true;
				sqlParameter.Value = System.DBNull.Value;
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Agence", System.Data.SqlDbType.VarChar, 10);
				sqlParameter.SourceColumn = "Agence";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Agence_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Agence.IsNull) {

					sqlParameter.Value = parameters.Param_Agence;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@NO_ACT", System.Data.SqlDbType.VarChar, 10);
				sqlParameter.SourceColumn = "NO_ACT";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_NO_ACT_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_NO_ACT.IsNull) {

					sqlParameter.Value = parameters.Param_NO_ACT;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@FournisseurID", System.Data.SqlDbType.VarChar, 15);
				sqlParameter.SourceColumn = "FournisseurID";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_FournisseurID_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_FournisseurID.IsNull) {

					sqlParameter.Value = parameters.Param_FournisseurID;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ReturnXML", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ReturnXML_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ReturnXML.IsNull) {

					sqlParameter.Value = parameters.Param_ReturnXML;
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

		private bool RetrieveParameters(ref Gestion_Paie.DataClasses.Parameters.spS_Cert_Proprietaire_Full parameters, ref System.Data.SqlClient.SqlCommand sqlCommand) {

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
		/// This method allows you to execute the [spS_Cert_Proprietaire_Full] stored procedure and retrieve back the data
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
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.spS_Cert_Proprietaire_Full parameters, out System.Data.SqlClient.SqlDataReader sqlDataReader) {

			return(Execute(ref parameters, out sqlDataReader, System.Data.CommandBehavior.Default));
		}

		/// <summary>
		/// This method allows you to execute the [spS_Cert_Proprietaire_Full] stored procedure and retrieve back the data
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
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.spS_Cert_Proprietaire_Full parameters, out System.Data.SqlClient.SqlDataReader sqlDataReader, System.Data.CommandBehavior commandBehavior) {

			System.Data.SqlClient.SqlCommand sqlCommand = null;
			System.Boolean returnStatus = false;
			System.Boolean connectionMustBeClosed = true;

			try {

				sqlDataReader = null;
				ResetParameter(ref parameters);

				parameters.Param_ReturnXML = new System.Data.SqlTypes.SqlBoolean(false);

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
		/// This method allows you to execute the [spS_Cert_Proprietaire_Full] stored procedure and retrieve back the data
		/// populated in a DataSet (System.Data.DataSet).
		/// </summary>
		/// <param name="parameters">
		/// Contains all the necessary information to execute correctly the stored procedure, i.e. 
		/// the database connection to use and all the necessary input parameters to be supplied
		/// for this stored procedure execution. After the execution, this object will allow you
		/// to retrieve back the stored procedure return value and all the output parameters.
		/// </param>
		/// <param name="dataset">
		/// Will be populated with the data after execution. The table based name used will be: 'spS_Cert_Proprietaire_Full'.
		/// </param>
		/// <returns>True if the call was successful. Otherwise, it returns False.</returns>
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.spS_Cert_Proprietaire_Full parameters, ref System.Data.DataSet dataset) {

			return(Execute(ref parameters, ref dataset, "spS_Cert_Proprietaire_Full", -1, -1));
		}

		/// <summary>
		/// This method allows you to execute the [spS_Cert_Proprietaire_Full] stored procedure and retrieve back the data
		/// populated in a DataSet (System.Data.DataSet).
		/// </summary>
		/// <param name="parameters">
		/// Contains all the necessary information to execute correctly the stored procedure, i.e. 
		/// the database connection to use and all the necessary input parameters to be supplied
		/// for this stored procedure execution. After the execution, this object will allow you
		/// to retrieve back the stored procedure return value and all the output parameters.
		/// </param>
		/// <param name="dataset">
		/// Will be populated with the data after execution. The table based name used will be: 'spS_Cert_Proprietaire_Full'.
		/// </param>
		/// <param name="startRecord">The zero-based record number to start with.</param>
		/// <param name="maxRecords">The maximum number of records to retrieve.</param>
		/// <returns>True if the call was successful. Otherwise, it returns False.</returns>
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.spS_Cert_Proprietaire_Full parameters, ref System.Data.DataSet dataset, int startRecord, int maxRecords) {

			return(Execute(ref parameters, ref dataset, "spS_Cert_Proprietaire_Full", startRecord, maxRecords));
		}

		/// <summary>
		/// This method allows you to execute the [spS_Cert_Proprietaire_Full] stored procedure and retrieve back the data
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
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.spS_Cert_Proprietaire_Full parameters, ref System.Data.DataSet dataset, string tableName) {

			return(Execute(ref parameters, ref dataset, tableName, -1, -1));
		}

		/// <summary>
		/// This method allows you to execute the [spS_Cert_Proprietaire_Full] stored procedure and retrieve back the data
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
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.spS_Cert_Proprietaire_Full parameters, ref System.Data.DataSet dataset, string tableName, int startRecord, int maxRecords) {

			System.Data.SqlClient.SqlCommand sqlCommand = null;
			System.Data.SqlClient.SqlDataAdapter sqlDataAdapter = null;
			System.Boolean returnStatus = false;
			System.Boolean connectionMustBeClosed = true;

			try {

				if (dataset == null) {

					dataset = new System.Data.DataSet();
				}
				ResetParameter(ref parameters);

				parameters.Param_ReturnXML = new System.Data.SqlTypes.SqlBoolean(false);

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

				dataset.Tables[tableName].Columns["Agence"].Caption = "Agence (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Agence\" column)";
				dataset.Tables[tableName].Columns["NO_ACT"].Caption = "NO_ACT (update this label in the \"Olymars/ColumnLabel\" extended property of the \"NO_ACT\" column)";
				dataset.Tables[tableName].Columns["Nom"].Caption = "Nom (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Nom\" column)";
				dataset.Tables[tableName].Columns["Representant"].Caption = "Representant (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Representant\" column)";
				dataset.Tables[tableName].Columns["ADRESSE"].Caption = "ADRESSE (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ADRESSE\" column)";
				dataset.Tables[tableName].Columns["Ville"].Caption = "Ville (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Ville\" column)";
				dataset.Tables[tableName].Columns["CODE_POST"].Caption = "CODE_POST (update this label in the \"Olymars/ColumnLabel\" extended property of the \"CODE_POST\" column)";
				dataset.Tables[tableName].Columns["TEL_RES"].Caption = "TEL_RES (update this label in the \"Olymars/ColumnLabel\" extended property of the \"TEL_RES\" column)";
				dataset.Tables[tableName].Columns["TEL_BUR"].Caption = "TEL_BUR (update this label in the \"Olymars/ColumnLabel\" extended property of the \"TEL_BUR\" column)";
				dataset.Tables[tableName].Columns["FournisseurID"].Caption = "FournisseurID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"FournisseurID\" column)";
				dataset.Tables[tableName].Columns["FournisseurNom"].Caption = "FournisseurNom (update this label in the \"Olymars/ColumnLabel\" extended property of the \"FournisseurNom\" column)";
				dataset.Tables[tableName].Columns["Traite"].Caption = "Traite (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Traite\" column)";
				dataset.Tables[tableName].Columns["Methode"].Caption = "Methode (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Methode\" column)";
				dataset.Tables[tableName].Columns["FournisseurID_ID"].Caption = "ID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ID\" column)";
				dataset.Tables[tableName].Columns["FournisseurID_CleTri"].Caption = "CleTri (update this label in the \"Olymars/ColumnLabel\" extended property of the \"CleTri\" column)";
				dataset.Tables[tableName].Columns["FournisseurID_Nom"].Caption = "Nom (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Nom\" column)";
				dataset.Tables[tableName].Columns["FournisseurID_AuSoinsDe"].Caption = "AuSoinsDe (update this label in the \"Olymars/ColumnLabel\" extended property of the \"AuSoinsDe\" column)";
				dataset.Tables[tableName].Columns["FournisseurID_Rue"].Caption = "Rue (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Rue\" column)";
				dataset.Tables[tableName].Columns["FournisseurID_Ville"].Caption = "Ville (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Ville\" column)";
				dataset.Tables[tableName].Columns["FournisseurID_PaysID"].Caption = "PaysID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"PaysID\" column)";
				dataset.Tables[tableName].Columns["FournisseurID_Code_postal"].Caption = "Code_postal (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Code_postal\" column)";
				dataset.Tables[tableName].Columns["FournisseurID_Telephone"].Caption = "Telephone (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone\" column)";
				dataset.Tables[tableName].Columns["FournisseurID_Telephone_Poste"].Caption = "Telephone_Poste (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone_Poste\" column)";
				dataset.Tables[tableName].Columns["FournisseurID_Telecopieur"].Caption = "Telecopieur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telecopieur\" column)";
				dataset.Tables[tableName].Columns["FournisseurID_Telephone2"].Caption = "Telephone2 (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone2\" column)";
				dataset.Tables[tableName].Columns["FournisseurID_Telephone2_Desc"].Caption = "Telephone2_Desc (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone2_Desc\" column)";
				dataset.Tables[tableName].Columns["FournisseurID_Telephone2_Poste"].Caption = "Telephone2_Poste (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone2_Poste\" column)";
				dataset.Tables[tableName].Columns["FournisseurID_Telephone3"].Caption = "Telephone3 (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone3\" column)";
				dataset.Tables[tableName].Columns["FournisseurID_Telephone3_Desc"].Caption = "Telephone3_Desc (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone3_Desc\" column)";
				dataset.Tables[tableName].Columns["FournisseurID_Telephone3_Poste"].Caption = "Telephone3_Poste (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone3_Poste\" column)";
				dataset.Tables[tableName].Columns["FournisseurID_No_membre"].Caption = "No_membre (update this label in the \"Olymars/ColumnLabel\" extended property of the \"No_membre\" column)";
				dataset.Tables[tableName].Columns["FournisseurID_Resident"].Caption = "Resident (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Resident\" column)";
				dataset.Tables[tableName].Columns["FournisseurID_Email"].Caption = "Email (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Email\" column)";
				dataset.Tables[tableName].Columns["FournisseurID_WWW"].Caption = "WWW (update this label in the \"Olymars/ColumnLabel\" extended property of the \"WWW\" column)";
				dataset.Tables[tableName].Columns["FournisseurID_Commentaires"].Caption = "Commentaires (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Commentaires\" column)";
				dataset.Tables[tableName].Columns["FournisseurID_AfficherCommentaires"].Caption = "AfficherCommentaires (update this label in the \"Olymars/ColumnLabel\" extended property of the \"AfficherCommentaires\" column)";
				dataset.Tables[tableName].Columns["FournisseurID_DepotDirect"].Caption = "DepotDirect (update this label in the \"Olymars/ColumnLabel\" extended property of the \"DepotDirect\" column)";
				dataset.Tables[tableName].Columns["FournisseurID_InstitutionBanquaireID"].Caption = "InstitutionBanquaireID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"InstitutionBanquaireID\" column)";
				dataset.Tables[tableName].Columns["FournisseurID_Banque_transit"].Caption = "Banque_transit (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Banque_transit\" column)";
				dataset.Tables[tableName].Columns["FournisseurID_Banque_folio"].Caption = "Banque_folio (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Banque_folio\" column)";
				dataset.Tables[tableName].Columns["FournisseurID_No_TPS"].Caption = "No_TPS (update this label in the \"Olymars/ColumnLabel\" extended property of the \"No_TPS\" column)";
				dataset.Tables[tableName].Columns["FournisseurID_No_TVQ"].Caption = "No_TVQ (update this label in the \"Olymars/ColumnLabel\" extended property of the \"No_TVQ\" column)";
				dataset.Tables[tableName].Columns["FournisseurID_PayerA"].Caption = "PayerA (update this label in the \"Olymars/ColumnLabel\" extended property of the \"PayerA\" column)";
				dataset.Tables[tableName].Columns["FournisseurID_PayerAID"].Caption = "PayerAID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"PayerAID\" column)";
				dataset.Tables[tableName].Columns["FournisseurID_Statut"].Caption = "Statut (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Statut\" column)";
				dataset.Tables[tableName].Columns["FournisseurID_Rep_Nom"].Caption = "Rep_Nom (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Rep_Nom\" column)";
				dataset.Tables[tableName].Columns["FournisseurID_Rep_Telephone"].Caption = "Rep_Telephone (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Rep_Telephone\" column)";
				dataset.Tables[tableName].Columns["FournisseurID_Rep_Telephone_Poste"].Caption = "Rep_Telephone_Poste (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Rep_Telephone_Poste\" column)";
				dataset.Tables[tableName].Columns["FournisseurID_Rep_Email"].Caption = "Rep_Email (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Rep_Email\" column)";
				dataset.Tables[tableName].Columns["FournisseurID_EnAnglais"].Caption = "EnAnglais (update this label in the \"Olymars/ColumnLabel\" extended property of the \"EnAnglais\" column)";
				dataset.Tables[tableName].Columns["FournisseurID_Actif"].Caption = "Actif (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Actif\" column)";
				dataset.Tables[tableName].Columns["FournisseurID_MRCProducteurID"].Caption = "MRCProducteurID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"MRCProducteurID\" column)";
				dataset.Tables[tableName].Columns["FournisseurID_PaiementManuel"].Caption = "PaiementManuel (update this label in the \"Olymars/ColumnLabel\" extended property of the \"PaiementManuel\" column)";
				dataset.Tables[tableName].Columns["FournisseurID_Journal"].Caption = "Journal (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Journal\" column)";
				dataset.Tables[tableName].Columns["FournisseurID_RecoitTPS"].Caption = "RecoitTPS (update this label in the \"Olymars/ColumnLabel\" extended property of the \"RecoitTPS\" column)";
				dataset.Tables[tableName].Columns["FournisseurID_RecoitTVQ"].Caption = "RecoitTVQ (update this label in the \"Olymars/ColumnLabel\" extended property of the \"RecoitTVQ\" column)";
				dataset.Tables[tableName].Columns["FournisseurID_ModifierTrigger"].Caption = "ModifierTrigger (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ModifierTrigger\" column)";
				dataset.Tables[tableName].Columns["FournisseurID_IsProducteur"].Caption = "IsProducteur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"IsProducteur\" column)";
				dataset.Tables[tableName].Columns["FournisseurID_IsTransporteur"].Caption = "IsTransporteur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"IsTransporteur\" column)";
				dataset.Tables[tableName].Columns["FournisseurID_IsChargeur"].Caption = "IsChargeur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"IsChargeur\" column)";
				dataset.Tables[tableName].Columns["FournisseurID_IsAutre"].Caption = "IsAutre (update this label in the \"Olymars/ColumnLabel\" extended property of the \"IsAutre\" column)";
				dataset.Tables[tableName].Columns["FournisseurID_AfficherCommentairesSurPermit"].Caption = "AfficherCommentairesSurPermit (update this label in the \"Olymars/ColumnLabel\" extended property of the \"AfficherCommentairesSurPermit\" column)";
				dataset.Tables[tableName].Columns["FournisseurID_PasEmissionPermis"].Caption = "PasEmissionPermis (update this label in the \"Olymars/ColumnLabel\" extended property of the \"PasEmissionPermis\" column)";
				dataset.Tables[tableName].Columns["FournisseurID_Generique"].Caption = "Generique (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Generique\" column)";
				dataset.Tables[tableName].Columns["FournisseurID_Membre_OGC"].Caption = "Membre_OGC (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Membre_OGC\" column)";
				dataset.Tables[tableName].Columns["FournisseurID_InscritTPS"].Caption = "InscritTPS (update this label in the \"Olymars/ColumnLabel\" extended property of the \"InscritTPS\" column)";
				dataset.Tables[tableName].Columns["FournisseurID_InscritTVQ"].Caption = "InscritTVQ (update this label in the \"Olymars/ColumnLabel\" extended property of the \"InscritTVQ\" column)";
				dataset.Tables[tableName].Columns["FournisseurID_IsOGC"].Caption = "IsOGC (update this label in the \"Olymars/ColumnLabel\" extended property of the \"IsOGC\" column)";

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
		/// This method allows you to execute the [spS_Cert_Proprietaire_Full] stored procedure and retrieve back the data
		/// accessible via a string XML content.
		/// </summary>
		/// <param name="parameters">
		/// Contains all the necessary information to execute correctly the stored procedure, i.e. 
		/// the database connection to use and all the necessary input parameters to be supplied
		/// for this stored procedure execution. After the execution, this object will allow you
		/// to retrieve back the stored procedure return value and all the output parameters.
		/// </param>
		/// <param name="xml">
		/// Will contains XML content provided by SQL Server.
		/// </param>
		/// <returns>True if the call was successful. Otherwise, it returns False.</returns>
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.spS_Cert_Proprietaire_Full parameters, ref string xml) {

			System.Data.SqlClient.SqlCommand sqlCommand = null;
			System.Boolean returnStatus = false;
			System.Xml.XmlTextReader xmlTextReader = null;
			System.Boolean connectionMustBeClosed = true;

			try {

				xml = String.Empty;
				ResetParameter(ref parameters);

				parameters.Param_ReturnXML = new System.Data.SqlTypes.SqlBoolean(true);

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
				xmlTextReader = (System.Xml.XmlTextReader)sqlCommand.ExecuteXmlReader();

				if (xmlTextReader != null) {

					xmlTextReader.MoveToContent();
					System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
					while (!xmlTextReader.EOF) {
						stringBuilder.Append(xmlTextReader.ReadOuterXml());
					}
					xml = stringBuilder.ToString();
					stringBuilder = null;

					if (xmlTextReader.ReadState != System.Xml.ReadState.Closed) {

						xmlTextReader.Close();	                
					}
				}
				
				parameters.internal_SetErrorSource(ErrorSource.ParametersRetrieval);
				returnStatus = RetrieveParameters(ref parameters, ref sqlCommand);
			}

			catch (System.Data.SqlClient.SqlException sqlException) {

				parameters.internal_UpdateExceptionInformation(sqlException);
				xml = String.Empty;
				returnStatus = false;

				if (this.throwExceptionOnExecute) {

					throw sqlException;
				}
			}

			catch (System.Exception exception) {

				parameters.internal_UpdateExceptionInformation(exception);
				xml = String.Empty;
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
		/// This method allows you to execute the [spS_Cert_Proprietaire_Full] stored procedure and retrieve back the data
		/// accessible via an XmlReader (System.Xml.XmlReader).
		/// </summary>
		/// <param name="parameters">
		/// Contains all the necessary information to execute correctly the stored procedure, i.e. 
		/// the database connection to use and all the necessary input parameters to be supplied
		/// for this stored procedure execution. After the execution, this object will allow you
		/// to retrieve back the stored procedure return value and all the output parameters.
		/// </param>
		/// <param name="xmlReader">
		/// Reader a System.Xml.XmlReader.
		/// </param>
		/// <returns>True if the call was successful. Otherwise, it returns False.</returns>
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.spS_Cert_Proprietaire_Full parameters, out System.Xml.XmlReader xmlReader) {

			System.Data.SqlClient.SqlCommand sqlCommand = null;
			System.Boolean returnStatus = false;
			System.Boolean connectionMustBeClosed = true;
			xmlReader = null;

			try {

				ResetParameter(ref parameters);

				parameters.Param_ReturnXML = new System.Data.SqlTypes.SqlBoolean(true);

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
				xmlReader = sqlCommand.ExecuteXmlReader();
				
				parameters.internal_Set_ReturnValue_Available(false);

				parameters.internal_Set_XmlReader(ref xmlReader);
				parameters.internal_Set_SqlCommand(ref sqlCommand);
			}

			catch (System.Data.SqlClient.SqlException sqlException) {

				parameters.internal_UpdateExceptionInformation(sqlException);
				returnStatus = false;

				if (this.throwExceptionOnExecute) {

					throw sqlException;
				}
			}

			catch (System.Exception exception) {

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

				// We do not close the SqlConnection because the XmlReader object needs it.
				// It is the responsability of the caller to close it by calling: xmlReader.Close();

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
		/// the Execute method of the 'spS_Cert_Proprietaire_Full' class.
		/// </summary>
		public sealed class Resultset1 {


			/// <summary>
			/// This collection provides the fields collection for this resultset.
			/// </summary>
			public sealed class Fields {

				/// <summary>
				/// Allows to get the Index and Name of the field Agence via shared members
				/// </summary>
				public sealed class Column_Agence {

					/// <summary>
					/// Returns "Agence"
					/// </summary>
					public const System.String ColumnName = "Agence";
					/// <summary>
					/// Returns 0
					/// </summary>
					public const System.Int32 ColumnIndex = 0;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field NO_ACT via shared members
				/// </summary>
				public sealed class Column_NO_ACT {

					/// <summary>
					/// Returns "NO_ACT"
					/// </summary>
					public const System.String ColumnName = "NO_ACT";
					/// <summary>
					/// Returns 1
					/// </summary>
					public const System.Int32 ColumnIndex = 1;

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
					/// Returns 2
					/// </summary>
					public const System.Int32 ColumnIndex = 2;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Representant via shared members
				/// </summary>
				public sealed class Column_Representant {

					/// <summary>
					/// Returns "Representant"
					/// </summary>
					public const System.String ColumnName = "Representant";
					/// <summary>
					/// Returns 3
					/// </summary>
					public const System.Int32 ColumnIndex = 3;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ADRESSE via shared members
				/// </summary>
				public sealed class Column_ADRESSE {

					/// <summary>
					/// Returns "ADRESSE"
					/// </summary>
					public const System.String ColumnName = "ADRESSE";
					/// <summary>
					/// Returns 4
					/// </summary>
					public const System.Int32 ColumnIndex = 4;

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
					/// Returns 5
					/// </summary>
					public const System.Int32 ColumnIndex = 5;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field CODE_POST via shared members
				/// </summary>
				public sealed class Column_CODE_POST {

					/// <summary>
					/// Returns "CODE_POST"
					/// </summary>
					public const System.String ColumnName = "CODE_POST";
					/// <summary>
					/// Returns 6
					/// </summary>
					public const System.Int32 ColumnIndex = 6;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field TEL_RES via shared members
				/// </summary>
				public sealed class Column_TEL_RES {

					/// <summary>
					/// Returns "TEL_RES"
					/// </summary>
					public const System.String ColumnName = "TEL_RES";
					/// <summary>
					/// Returns 7
					/// </summary>
					public const System.Int32 ColumnIndex = 7;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field TEL_BUR via shared members
				/// </summary>
				public sealed class Column_TEL_BUR {

					/// <summary>
					/// Returns "TEL_BUR"
					/// </summary>
					public const System.String ColumnName = "TEL_BUR";
					/// <summary>
					/// Returns 8
					/// </summary>
					public const System.Int32 ColumnIndex = 8;

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
					/// Returns 9
					/// </summary>
					public const System.Int32 ColumnIndex = 9;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field FournisseurNom via shared members
				/// </summary>
				public sealed class Column_FournisseurNom {

					/// <summary>
					/// Returns "FournisseurNom"
					/// </summary>
					public const System.String ColumnName = "FournisseurNom";
					/// <summary>
					/// Returns 10
					/// </summary>
					public const System.Int32 ColumnIndex = 10;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Traite via shared members
				/// </summary>
				public sealed class Column_Traite {

					/// <summary>
					/// Returns "Traite"
					/// </summary>
					public const System.String ColumnName = "Traite";
					/// <summary>
					/// Returns 11
					/// </summary>
					public const System.Int32 ColumnIndex = 11;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Methode via shared members
				/// </summary>
				public sealed class Column_Methode {

					/// <summary>
					/// Returns "Methode"
					/// </summary>
					public const System.String ColumnName = "Methode";
					/// <summary>
					/// Returns 12
					/// </summary>
					public const System.Int32 ColumnIndex = 12;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field FournisseurID_ID via shared members
				/// </summary>
				public sealed class Column_FournisseurID_ID {

					/// <summary>
					/// Returns "FournisseurID_ID"
					/// </summary>
					public const System.String ColumnName = "FournisseurID_ID";
					/// <summary>
					/// Returns 13
					/// </summary>
					public const System.Int32 ColumnIndex = 13;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field FournisseurID_CleTri via shared members
				/// </summary>
				public sealed class Column_FournisseurID_CleTri {

					/// <summary>
					/// Returns "FournisseurID_CleTri"
					/// </summary>
					public const System.String ColumnName = "FournisseurID_CleTri";
					/// <summary>
					/// Returns 14
					/// </summary>
					public const System.Int32 ColumnIndex = 14;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field FournisseurID_Nom via shared members
				/// </summary>
				public sealed class Column_FournisseurID_Nom {

					/// <summary>
					/// Returns "FournisseurID_Nom"
					/// </summary>
					public const System.String ColumnName = "FournisseurID_Nom";
					/// <summary>
					/// Returns 15
					/// </summary>
					public const System.Int32 ColumnIndex = 15;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field FournisseurID_AuSoinsDe via shared members
				/// </summary>
				public sealed class Column_FournisseurID_AuSoinsDe {

					/// <summary>
					/// Returns "FournisseurID_AuSoinsDe"
					/// </summary>
					public const System.String ColumnName = "FournisseurID_AuSoinsDe";
					/// <summary>
					/// Returns 16
					/// </summary>
					public const System.Int32 ColumnIndex = 16;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field FournisseurID_Rue via shared members
				/// </summary>
				public sealed class Column_FournisseurID_Rue {

					/// <summary>
					/// Returns "FournisseurID_Rue"
					/// </summary>
					public const System.String ColumnName = "FournisseurID_Rue";
					/// <summary>
					/// Returns 17
					/// </summary>
					public const System.Int32 ColumnIndex = 17;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field FournisseurID_Ville via shared members
				/// </summary>
				public sealed class Column_FournisseurID_Ville {

					/// <summary>
					/// Returns "FournisseurID_Ville"
					/// </summary>
					public const System.String ColumnName = "FournisseurID_Ville";
					/// <summary>
					/// Returns 18
					/// </summary>
					public const System.Int32 ColumnIndex = 18;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field FournisseurID_PaysID via shared members
				/// </summary>
				public sealed class Column_FournisseurID_PaysID {

					/// <summary>
					/// Returns "FournisseurID_PaysID"
					/// </summary>
					public const System.String ColumnName = "FournisseurID_PaysID";
					/// <summary>
					/// Returns 19
					/// </summary>
					public const System.Int32 ColumnIndex = 19;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field FournisseurID_Code_postal via shared members
				/// </summary>
				public sealed class Column_FournisseurID_Code_postal {

					/// <summary>
					/// Returns "FournisseurID_Code_postal"
					/// </summary>
					public const System.String ColumnName = "FournisseurID_Code_postal";
					/// <summary>
					/// Returns 20
					/// </summary>
					public const System.Int32 ColumnIndex = 20;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field FournisseurID_Telephone via shared members
				/// </summary>
				public sealed class Column_FournisseurID_Telephone {

					/// <summary>
					/// Returns "FournisseurID_Telephone"
					/// </summary>
					public const System.String ColumnName = "FournisseurID_Telephone";
					/// <summary>
					/// Returns 21
					/// </summary>
					public const System.Int32 ColumnIndex = 21;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field FournisseurID_Telephone_Poste via shared members
				/// </summary>
				public sealed class Column_FournisseurID_Telephone_Poste {

					/// <summary>
					/// Returns "FournisseurID_Telephone_Poste"
					/// </summary>
					public const System.String ColumnName = "FournisseurID_Telephone_Poste";
					/// <summary>
					/// Returns 22
					/// </summary>
					public const System.Int32 ColumnIndex = 22;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field FournisseurID_Telecopieur via shared members
				/// </summary>
				public sealed class Column_FournisseurID_Telecopieur {

					/// <summary>
					/// Returns "FournisseurID_Telecopieur"
					/// </summary>
					public const System.String ColumnName = "FournisseurID_Telecopieur";
					/// <summary>
					/// Returns 23
					/// </summary>
					public const System.Int32 ColumnIndex = 23;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field FournisseurID_Telephone2 via shared members
				/// </summary>
				public sealed class Column_FournisseurID_Telephone2 {

					/// <summary>
					/// Returns "FournisseurID_Telephone2"
					/// </summary>
					public const System.String ColumnName = "FournisseurID_Telephone2";
					/// <summary>
					/// Returns 24
					/// </summary>
					public const System.Int32 ColumnIndex = 24;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field FournisseurID_Telephone2_Desc via shared members
				/// </summary>
				public sealed class Column_FournisseurID_Telephone2_Desc {

					/// <summary>
					/// Returns "FournisseurID_Telephone2_Desc"
					/// </summary>
					public const System.String ColumnName = "FournisseurID_Telephone2_Desc";
					/// <summary>
					/// Returns 25
					/// </summary>
					public const System.Int32 ColumnIndex = 25;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field FournisseurID_Telephone2_Poste via shared members
				/// </summary>
				public sealed class Column_FournisseurID_Telephone2_Poste {

					/// <summary>
					/// Returns "FournisseurID_Telephone2_Poste"
					/// </summary>
					public const System.String ColumnName = "FournisseurID_Telephone2_Poste";
					/// <summary>
					/// Returns 26
					/// </summary>
					public const System.Int32 ColumnIndex = 26;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field FournisseurID_Telephone3 via shared members
				/// </summary>
				public sealed class Column_FournisseurID_Telephone3 {

					/// <summary>
					/// Returns "FournisseurID_Telephone3"
					/// </summary>
					public const System.String ColumnName = "FournisseurID_Telephone3";
					/// <summary>
					/// Returns 27
					/// </summary>
					public const System.Int32 ColumnIndex = 27;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field FournisseurID_Telephone3_Desc via shared members
				/// </summary>
				public sealed class Column_FournisseurID_Telephone3_Desc {

					/// <summary>
					/// Returns "FournisseurID_Telephone3_Desc"
					/// </summary>
					public const System.String ColumnName = "FournisseurID_Telephone3_Desc";
					/// <summary>
					/// Returns 28
					/// </summary>
					public const System.Int32 ColumnIndex = 28;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field FournisseurID_Telephone3_Poste via shared members
				/// </summary>
				public sealed class Column_FournisseurID_Telephone3_Poste {

					/// <summary>
					/// Returns "FournisseurID_Telephone3_Poste"
					/// </summary>
					public const System.String ColumnName = "FournisseurID_Telephone3_Poste";
					/// <summary>
					/// Returns 29
					/// </summary>
					public const System.Int32 ColumnIndex = 29;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field FournisseurID_No_membre via shared members
				/// </summary>
				public sealed class Column_FournisseurID_No_membre {

					/// <summary>
					/// Returns "FournisseurID_No_membre"
					/// </summary>
					public const System.String ColumnName = "FournisseurID_No_membre";
					/// <summary>
					/// Returns 30
					/// </summary>
					public const System.Int32 ColumnIndex = 30;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field FournisseurID_Resident via shared members
				/// </summary>
				public sealed class Column_FournisseurID_Resident {

					/// <summary>
					/// Returns "FournisseurID_Resident"
					/// </summary>
					public const System.String ColumnName = "FournisseurID_Resident";
					/// <summary>
					/// Returns 31
					/// </summary>
					public const System.Int32 ColumnIndex = 31;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field FournisseurID_Email via shared members
				/// </summary>
				public sealed class Column_FournisseurID_Email {

					/// <summary>
					/// Returns "FournisseurID_Email"
					/// </summary>
					public const System.String ColumnName = "FournisseurID_Email";
					/// <summary>
					/// Returns 32
					/// </summary>
					public const System.Int32 ColumnIndex = 32;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field FournisseurID_WWW via shared members
				/// </summary>
				public sealed class Column_FournisseurID_WWW {

					/// <summary>
					/// Returns "FournisseurID_WWW"
					/// </summary>
					public const System.String ColumnName = "FournisseurID_WWW";
					/// <summary>
					/// Returns 33
					/// </summary>
					public const System.Int32 ColumnIndex = 33;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field FournisseurID_Commentaires via shared members
				/// </summary>
				public sealed class Column_FournisseurID_Commentaires {

					/// <summary>
					/// Returns "FournisseurID_Commentaires"
					/// </summary>
					public const System.String ColumnName = "FournisseurID_Commentaires";
					/// <summary>
					/// Returns 34
					/// </summary>
					public const System.Int32 ColumnIndex = 34;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field FournisseurID_AfficherCommentaires via shared members
				/// </summary>
				public sealed class Column_FournisseurID_AfficherCommentaires {

					/// <summary>
					/// Returns "FournisseurID_AfficherCommentaires"
					/// </summary>
					public const System.String ColumnName = "FournisseurID_AfficherCommentaires";
					/// <summary>
					/// Returns 35
					/// </summary>
					public const System.Int32 ColumnIndex = 35;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field FournisseurID_DepotDirect via shared members
				/// </summary>
				public sealed class Column_FournisseurID_DepotDirect {

					/// <summary>
					/// Returns "FournisseurID_DepotDirect"
					/// </summary>
					public const System.String ColumnName = "FournisseurID_DepotDirect";
					/// <summary>
					/// Returns 36
					/// </summary>
					public const System.Int32 ColumnIndex = 36;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field FournisseurID_InstitutionBanquaireID via shared members
				/// </summary>
				public sealed class Column_FournisseurID_InstitutionBanquaireID {

					/// <summary>
					/// Returns "FournisseurID_InstitutionBanquaireID"
					/// </summary>
					public const System.String ColumnName = "FournisseurID_InstitutionBanquaireID";
					/// <summary>
					/// Returns 37
					/// </summary>
					public const System.Int32 ColumnIndex = 37;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field FournisseurID_Banque_transit via shared members
				/// </summary>
				public sealed class Column_FournisseurID_Banque_transit {

					/// <summary>
					/// Returns "FournisseurID_Banque_transit"
					/// </summary>
					public const System.String ColumnName = "FournisseurID_Banque_transit";
					/// <summary>
					/// Returns 38
					/// </summary>
					public const System.Int32 ColumnIndex = 38;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field FournisseurID_Banque_folio via shared members
				/// </summary>
				public sealed class Column_FournisseurID_Banque_folio {

					/// <summary>
					/// Returns "FournisseurID_Banque_folio"
					/// </summary>
					public const System.String ColumnName = "FournisseurID_Banque_folio";
					/// <summary>
					/// Returns 39
					/// </summary>
					public const System.Int32 ColumnIndex = 39;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field FournisseurID_No_TPS via shared members
				/// </summary>
				public sealed class Column_FournisseurID_No_TPS {

					/// <summary>
					/// Returns "FournisseurID_No_TPS"
					/// </summary>
					public const System.String ColumnName = "FournisseurID_No_TPS";
					/// <summary>
					/// Returns 40
					/// </summary>
					public const System.Int32 ColumnIndex = 40;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field FournisseurID_No_TVQ via shared members
				/// </summary>
				public sealed class Column_FournisseurID_No_TVQ {

					/// <summary>
					/// Returns "FournisseurID_No_TVQ"
					/// </summary>
					public const System.String ColumnName = "FournisseurID_No_TVQ";
					/// <summary>
					/// Returns 41
					/// </summary>
					public const System.Int32 ColumnIndex = 41;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field FournisseurID_PayerA via shared members
				/// </summary>
				public sealed class Column_FournisseurID_PayerA {

					/// <summary>
					/// Returns "FournisseurID_PayerA"
					/// </summary>
					public const System.String ColumnName = "FournisseurID_PayerA";
					/// <summary>
					/// Returns 42
					/// </summary>
					public const System.Int32 ColumnIndex = 42;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field FournisseurID_PayerAID via shared members
				/// </summary>
				public sealed class Column_FournisseurID_PayerAID {

					/// <summary>
					/// Returns "FournisseurID_PayerAID"
					/// </summary>
					public const System.String ColumnName = "FournisseurID_PayerAID";
					/// <summary>
					/// Returns 43
					/// </summary>
					public const System.Int32 ColumnIndex = 43;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field FournisseurID_Statut via shared members
				/// </summary>
				public sealed class Column_FournisseurID_Statut {

					/// <summary>
					/// Returns "FournisseurID_Statut"
					/// </summary>
					public const System.String ColumnName = "FournisseurID_Statut";
					/// <summary>
					/// Returns 44
					/// </summary>
					public const System.Int32 ColumnIndex = 44;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field FournisseurID_Rep_Nom via shared members
				/// </summary>
				public sealed class Column_FournisseurID_Rep_Nom {

					/// <summary>
					/// Returns "FournisseurID_Rep_Nom"
					/// </summary>
					public const System.String ColumnName = "FournisseurID_Rep_Nom";
					/// <summary>
					/// Returns 45
					/// </summary>
					public const System.Int32 ColumnIndex = 45;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field FournisseurID_Rep_Telephone via shared members
				/// </summary>
				public sealed class Column_FournisseurID_Rep_Telephone {

					/// <summary>
					/// Returns "FournisseurID_Rep_Telephone"
					/// </summary>
					public const System.String ColumnName = "FournisseurID_Rep_Telephone";
					/// <summary>
					/// Returns 46
					/// </summary>
					public const System.Int32 ColumnIndex = 46;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field FournisseurID_Rep_Telephone_Poste via shared members
				/// </summary>
				public sealed class Column_FournisseurID_Rep_Telephone_Poste {

					/// <summary>
					/// Returns "FournisseurID_Rep_Telephone_Poste"
					/// </summary>
					public const System.String ColumnName = "FournisseurID_Rep_Telephone_Poste";
					/// <summary>
					/// Returns 47
					/// </summary>
					public const System.Int32 ColumnIndex = 47;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field FournisseurID_Rep_Email via shared members
				/// </summary>
				public sealed class Column_FournisseurID_Rep_Email {

					/// <summary>
					/// Returns "FournisseurID_Rep_Email"
					/// </summary>
					public const System.String ColumnName = "FournisseurID_Rep_Email";
					/// <summary>
					/// Returns 48
					/// </summary>
					public const System.Int32 ColumnIndex = 48;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field FournisseurID_EnAnglais via shared members
				/// </summary>
				public sealed class Column_FournisseurID_EnAnglais {

					/// <summary>
					/// Returns "FournisseurID_EnAnglais"
					/// </summary>
					public const System.String ColumnName = "FournisseurID_EnAnglais";
					/// <summary>
					/// Returns 49
					/// </summary>
					public const System.Int32 ColumnIndex = 49;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field FournisseurID_Actif via shared members
				/// </summary>
				public sealed class Column_FournisseurID_Actif {

					/// <summary>
					/// Returns "FournisseurID_Actif"
					/// </summary>
					public const System.String ColumnName = "FournisseurID_Actif";
					/// <summary>
					/// Returns 50
					/// </summary>
					public const System.Int32 ColumnIndex = 50;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field FournisseurID_MRCProducteurID via shared members
				/// </summary>
				public sealed class Column_FournisseurID_MRCProducteurID {

					/// <summary>
					/// Returns "FournisseurID_MRCProducteurID"
					/// </summary>
					public const System.String ColumnName = "FournisseurID_MRCProducteurID";
					/// <summary>
					/// Returns 51
					/// </summary>
					public const System.Int32 ColumnIndex = 51;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field FournisseurID_PaiementManuel via shared members
				/// </summary>
				public sealed class Column_FournisseurID_PaiementManuel {

					/// <summary>
					/// Returns "FournisseurID_PaiementManuel"
					/// </summary>
					public const System.String ColumnName = "FournisseurID_PaiementManuel";
					/// <summary>
					/// Returns 52
					/// </summary>
					public const System.Int32 ColumnIndex = 52;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field FournisseurID_Journal via shared members
				/// </summary>
				public sealed class Column_FournisseurID_Journal {

					/// <summary>
					/// Returns "FournisseurID_Journal"
					/// </summary>
					public const System.String ColumnName = "FournisseurID_Journal";
					/// <summary>
					/// Returns 53
					/// </summary>
					public const System.Int32 ColumnIndex = 53;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field FournisseurID_RecoitTPS via shared members
				/// </summary>
				public sealed class Column_FournisseurID_RecoitTPS {

					/// <summary>
					/// Returns "FournisseurID_RecoitTPS"
					/// </summary>
					public const System.String ColumnName = "FournisseurID_RecoitTPS";
					/// <summary>
					/// Returns 54
					/// </summary>
					public const System.Int32 ColumnIndex = 54;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field FournisseurID_RecoitTVQ via shared members
				/// </summary>
				public sealed class Column_FournisseurID_RecoitTVQ {

					/// <summary>
					/// Returns "FournisseurID_RecoitTVQ"
					/// </summary>
					public const System.String ColumnName = "FournisseurID_RecoitTVQ";
					/// <summary>
					/// Returns 55
					/// </summary>
					public const System.Int32 ColumnIndex = 55;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field FournisseurID_ModifierTrigger via shared members
				/// </summary>
				public sealed class Column_FournisseurID_ModifierTrigger {

					/// <summary>
					/// Returns "FournisseurID_ModifierTrigger"
					/// </summary>
					public const System.String ColumnName = "FournisseurID_ModifierTrigger";
					/// <summary>
					/// Returns 56
					/// </summary>
					public const System.Int32 ColumnIndex = 56;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field FournisseurID_IsProducteur via shared members
				/// </summary>
				public sealed class Column_FournisseurID_IsProducteur {

					/// <summary>
					/// Returns "FournisseurID_IsProducteur"
					/// </summary>
					public const System.String ColumnName = "FournisseurID_IsProducteur";
					/// <summary>
					/// Returns 57
					/// </summary>
					public const System.Int32 ColumnIndex = 57;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field FournisseurID_IsTransporteur via shared members
				/// </summary>
				public sealed class Column_FournisseurID_IsTransporteur {

					/// <summary>
					/// Returns "FournisseurID_IsTransporteur"
					/// </summary>
					public const System.String ColumnName = "FournisseurID_IsTransporteur";
					/// <summary>
					/// Returns 58
					/// </summary>
					public const System.Int32 ColumnIndex = 58;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field FournisseurID_IsChargeur via shared members
				/// </summary>
				public sealed class Column_FournisseurID_IsChargeur {

					/// <summary>
					/// Returns "FournisseurID_IsChargeur"
					/// </summary>
					public const System.String ColumnName = "FournisseurID_IsChargeur";
					/// <summary>
					/// Returns 59
					/// </summary>
					public const System.Int32 ColumnIndex = 59;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field FournisseurID_IsAutre via shared members
				/// </summary>
				public sealed class Column_FournisseurID_IsAutre {

					/// <summary>
					/// Returns "FournisseurID_IsAutre"
					/// </summary>
					public const System.String ColumnName = "FournisseurID_IsAutre";
					/// <summary>
					/// Returns 60
					/// </summary>
					public const System.Int32 ColumnIndex = 60;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field FournisseurID_AfficherCommentairesSurPermit via shared members
				/// </summary>
				public sealed class Column_FournisseurID_AfficherCommentairesSurPermit {

					/// <summary>
					/// Returns "FournisseurID_AfficherCommentairesSurPermit"
					/// </summary>
					public const System.String ColumnName = "FournisseurID_AfficherCommentairesSurPermit";
					/// <summary>
					/// Returns 61
					/// </summary>
					public const System.Int32 ColumnIndex = 61;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field FournisseurID_PasEmissionPermis via shared members
				/// </summary>
				public sealed class Column_FournisseurID_PasEmissionPermis {

					/// <summary>
					/// Returns "FournisseurID_PasEmissionPermis"
					/// </summary>
					public const System.String ColumnName = "FournisseurID_PasEmissionPermis";
					/// <summary>
					/// Returns 62
					/// </summary>
					public const System.Int32 ColumnIndex = 62;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field FournisseurID_Generique via shared members
				/// </summary>
				public sealed class Column_FournisseurID_Generique {

					/// <summary>
					/// Returns "FournisseurID_Generique"
					/// </summary>
					public const System.String ColumnName = "FournisseurID_Generique";
					/// <summary>
					/// Returns 63
					/// </summary>
					public const System.Int32 ColumnIndex = 63;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field FournisseurID_Membre_OGC via shared members
				/// </summary>
				public sealed class Column_FournisseurID_Membre_OGC {

					/// <summary>
					/// Returns "FournisseurID_Membre_OGC"
					/// </summary>
					public const System.String ColumnName = "FournisseurID_Membre_OGC";
					/// <summary>
					/// Returns 64
					/// </summary>
					public const System.Int32 ColumnIndex = 64;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field FournisseurID_InscritTPS via shared members
				/// </summary>
				public sealed class Column_FournisseurID_InscritTPS {

					/// <summary>
					/// Returns "FournisseurID_InscritTPS"
					/// </summary>
					public const System.String ColumnName = "FournisseurID_InscritTPS";
					/// <summary>
					/// Returns 65
					/// </summary>
					public const System.Int32 ColumnIndex = 65;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field FournisseurID_InscritTVQ via shared members
				/// </summary>
				public sealed class Column_FournisseurID_InscritTVQ {

					/// <summary>
					/// Returns "FournisseurID_InscritTVQ"
					/// </summary>
					public const System.String ColumnName = "FournisseurID_InscritTVQ";
					/// <summary>
					/// Returns 66
					/// </summary>
					public const System.Int32 ColumnIndex = 66;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field FournisseurID_IsOGC via shared members
				/// </summary>
				public sealed class Column_FournisseurID_IsOGC {

					/// <summary>
					/// Returns "FournisseurID_IsOGC"
					/// </summary>
					public const System.String ColumnName = "FournisseurID_IsOGC";
					/// <summary>
					/// Returns 67
					/// </summary>
					public const System.Int32 ColumnIndex = 67;

				}

			}
		}

		/// <summary>
		/// This class allows to easily retrieve the name or index of all the fields
		/// of the resulset #2 existing in the Dataset or the SqlDatReader returned by
		/// the Execute method of the 'spS_Cert_Proprietaire_Full' class.
		/// </summary>
		public sealed class Resultset2 {


			/// <summary>
			/// This collection provides the fields collection for this resultset.
			/// </summary>
			public sealed class Fields {

				/// <summary>
				/// Allows to get the Index and Name of the field XML_F52E2B61-18A1-11d1-B105-00805F49916B via shared members
				/// </summary>
				public sealed class Column_XML_F52E2B6118A111d1B10500805F49916B {

					/// <summary>
					/// Returns "XML_F52E2B61-18A1-11d1-B105-00805F49916B"
					/// </summary>
					public const System.String ColumnName = "XML_F52E2B61-18A1-11d1-B105-00805F49916B";
					/// <summary>
					/// Returns 0
					/// </summary>
					public const System.Int32 ColumnIndex = 0;

				}

			}
		}

	}

}

