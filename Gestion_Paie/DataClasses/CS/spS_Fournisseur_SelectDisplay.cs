using System;

namespace Gestion_Paie.DataClasses.Parameters {

	/// <summary>
	/// This class allows a developer to specify the parameters expected by the
	/// stored procedure 'spS_Fournisseur_SelectDisplay'. It allows also to specify specific connection
	/// information such as the ConnectionString to be use, the command time-out and so forth.
	/// </summary>
	[Serializable()]
	public sealed class spS_Fournisseur_SelectDisplay : MarshalByRefObject, IDisposable, IParameter {

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
		/// Initializes a new instance of the spS_Fournisseur_SelectDisplay class. If you use this constructor version,
		/// not assigning parameter values implies using the parameter default values.
		/// </summary>
		public spS_Fournisseur_SelectDisplay() : this(true) {

		}

		/// <summary>
		/// Initializes a new instance of the spS_Fournisseur_SelectDisplay class.
		/// </summary>
		/// <param name="useDefaultValue">If True, this parameter indicates that "not assigning parameter values" implies "using the parameter default values". If False, this parameter indicates that "not assigning parameter values" implies "using the SQL Server Null value".</param>
		public spS_Fournisseur_SelectDisplay(bool useDefaultValue) {

			this.useDefaultValue = useDefaultValue;

			this.internal_Param_ID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_PaysID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_InstitutionBanquaireID_UseDefaultValue = this.useDefaultValue;
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
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'spS_Fournisseur_SelectDisplay'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

						throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "spS_Fournisseur_SelectDisplay", CurrentRevision, OriginalRevision, System.Environment.NewLine));
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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'spS_Fournisseur_SelectDisplay'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlConnection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "spS_Fournisseur_SelectDisplay", CurrentRevision, OriginalRevision, System.Environment.NewLine));
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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'spS_Fournisseur_SelectDisplay'";
				sqlCommand.Transaction = sqlTransaction;

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlTransaction.Connection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "spS_Fournisseur_SelectDisplay", CurrentRevision, OriginalRevision, System.Environment.NewLine));
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
				this.internal_Param_ID = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_PaysID = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_InstitutionBanquaireID = System.Data.SqlTypes.SqlString.Null;
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
		~spS_Fournisseur_SelectDisplay() {

			Dispose(false);
		}

		/// <summary>
		/// Returns the stored procedure name for which this class was built, i.e. 'spS_Fournisseur_SelectDisplay'.
		/// </summary>
		public string StoredProcedureName {

			get {

				return("spS_Fournisseur_SelectDisplay");
			}
		}

		private System.Data.SqlTypes.SqlInt32 internal_Param_RETURN_VALUE;

		private System.Data.SqlTypes.SqlString internal_Param_ID;
		internal bool internal_Param_ID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_PaysID;
		internal bool internal_Param_PaysID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_InstitutionBanquaireID;
		internal bool internal_Param_InstitutionBanquaireID_UseDefaultValue = true;

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

			this.internal_Param_ID = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_ID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_PaysID = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_PaysID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_InstitutionBanquaireID = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_InstitutionBanquaireID_UseDefaultValue = this.useDefaultValue;

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
		/// Sets the value of the stored procedure INPUT parameter '@ID'.
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
		/// the parameter default value, consider calling the Param_ID_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_ID {

			get {

				if (this.internal_Param_ID_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ID);
			}

			set {

				this.internal_Param_ID_UseDefaultValue = false;
				this.internal_Param_ID = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ID' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ID_UseDefaultValue() {

			this.internal_Param_ID_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@PaysID'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [varchar](2)
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_PaysID_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_PaysID {

			get {

				if (this.internal_Param_PaysID_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_PaysID);
			}

			set {

				this.internal_Param_PaysID_UseDefaultValue = false;
				this.internal_Param_PaysID = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@PaysID' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_PaysID_UseDefaultValue() {

			this.internal_Param_PaysID_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@InstitutionBanquaireID'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [varchar](3)
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_InstitutionBanquaireID_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_InstitutionBanquaireID {

			get {

				if (this.internal_Param_InstitutionBanquaireID_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_InstitutionBanquaireID);
			}

			set {

				this.internal_Param_InstitutionBanquaireID_UseDefaultValue = false;
				this.internal_Param_InstitutionBanquaireID = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@InstitutionBanquaireID' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_InstitutionBanquaireID_UseDefaultValue() {

			this.internal_Param_InstitutionBanquaireID_UseDefaultValue = true;
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
	/// This class allows you to execute the 'spS_Fournisseur_SelectDisplay' stored procedure;
	/// it gives you the ability to:
	/// <list type="bullet">
	/// <item><description>Set all the necessary parameters to execute the stored procedure</description></item>
	/// <item><description>To execute the stored procedure</description></item>
	/// <item><description>To get back after the execution the return value and all the output parameters value</description></item>
	/// </list>
	/// </summary>
	public sealed class spS_Fournisseur_SelectDisplay : MarshalByRefObject, IDisposable {


		private bool throwExceptionOnExecute = false;

		/// <summary>
		/// Initializes a new instance of the spS_Fournisseur_SelectDisplay class.
		/// By default, no exception will be thrown when you call the Execute method. Instead, a Boolean return status will be returned.
		/// </summary>
		public spS_Fournisseur_SelectDisplay() : this(false) {

		}

		/// <summary>
		/// Initializes a new instance of the spS_Fournisseur_SelectDisplay class.
		/// </summary>
		/// <param name="throwExceptionOnExecute">True if an exception has to be thrown if the Execute call fails.</param>
		public spS_Fournisseur_SelectDisplay(bool throwExceptionOnExecute) {

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
		~spS_Fournisseur_SelectDisplay() {

			Dispose(false);
		}

		private void ResetParameter(ref Gestion_Paie.DataClasses.Parameters.spS_Fournisseur_SelectDisplay parameters) {

			parameters.internal_Set_RETURN_VALUE (System.Data.SqlTypes.SqlInt32.Null);
		}

		private bool InitializeConnection(ref Gestion_Paie.DataClasses.Parameters.spS_Fournisseur_SelectDisplay parameters, out System.Data.SqlClient.SqlCommand sqlCommand, ref bool connectionMustBeClosed) {

			try {

				this.sqlConnection = null;
				sqlCommand = null;
				connectionMustBeClosed = true;

				if (parameters.ConnectionType == ConnectionType.None) {

					throw new InvalidOperationException("No connection information was supplied. Consider calling the 'SetUpConnection' method of the Gestion_Paie.DataClasses.Parameters.spS_Fournisseur_SelectDisplay object before doing this call.");
				}

				if (parameters.ConnectionType == ConnectionType.SqlConnection && parameters.SqlConnection == null) {

					throw new InvalidOperationException("No connection information was supplied (SqlConnection == null). Consider calling the 'SetUpConnection' method of the Gestion_Paie.DataClasses.Parameters.spS_Fournisseur_SelectDisplay object before doing this call.");
				}

				if (parameters.ConnectionType == ConnectionType.SqlTransaction && parameters.SqlTransaction== null) {

					throw new InvalidOperationException("No connection information was supplied (SqlTransaction == null). Consider calling the 'SetUpConnection' method of the Gestion_Paie.DataClasses.Parameters.spS_Fournisseur_SelectDisplay object before doing this call.");
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

							throw new System.InvalidOperationException("No connection information was supplied (ConnectionString == \"\")! (Gestion_Paie.DataClasses.Parameters.spS_Fournisseur_SelectDisplay)");
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
				sqlCommand.CommandText = "spS_Fournisseur_SelectDisplay";

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

		private bool DeclareParameters(ref Gestion_Paie.DataClasses.Parameters.spS_Fournisseur_SelectDisplay parameters, ref System.Data.SqlClient.SqlCommand sqlCommand) {

			try {

				System.Data.SqlClient.SqlParameter sqlParameter;

				sqlParameter = new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4);
				sqlParameter.Direction = System.Data.ParameterDirection.ReturnValue;
				sqlParameter.IsNullable = true;
				sqlParameter.Value = System.DBNull.Value;
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.VarChar, 15);
				sqlParameter.SourceColumn = "ID";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ID_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ID.IsNull) {

					sqlParameter.Value = parameters.Param_ID;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@PaysID", System.Data.SqlDbType.VarChar, 2);
				sqlParameter.SourceColumn = "PaysID";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_PaysID_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_PaysID.IsNull) {

					sqlParameter.Value = parameters.Param_PaysID;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@InstitutionBanquaireID", System.Data.SqlDbType.VarChar, 3);
				sqlParameter.SourceColumn = "InstitutionBanquaireID";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_InstitutionBanquaireID_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_InstitutionBanquaireID.IsNull) {

					sqlParameter.Value = parameters.Param_InstitutionBanquaireID;
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

		private bool RetrieveParameters(ref Gestion_Paie.DataClasses.Parameters.spS_Fournisseur_SelectDisplay parameters, ref System.Data.SqlClient.SqlCommand sqlCommand) {

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
		/// This method allows you to execute the [spS_Fournisseur_SelectDisplay] stored procedure and retrieve back the data
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
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.spS_Fournisseur_SelectDisplay parameters, out System.Data.SqlClient.SqlDataReader sqlDataReader) {

			return(Execute(ref parameters, out sqlDataReader, System.Data.CommandBehavior.Default));
		}

		/// <summary>
		/// This method allows you to execute the [spS_Fournisseur_SelectDisplay] stored procedure and retrieve back the data
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
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.spS_Fournisseur_SelectDisplay parameters, out System.Data.SqlClient.SqlDataReader sqlDataReader, System.Data.CommandBehavior commandBehavior) {

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
		/// This method allows you to execute the [spS_Fournisseur_SelectDisplay] stored procedure and retrieve back the data
		/// populated in a DataSet (System.Data.DataSet).
		/// </summary>
		/// <param name="parameters">
		/// Contains all the necessary information to execute correctly the stored procedure, i.e. 
		/// the database connection to use and all the necessary input parameters to be supplied
		/// for this stored procedure execution. After the execution, this object will allow you
		/// to retrieve back the stored procedure return value and all the output parameters.
		/// </param>
		/// <param name="dataset">
		/// Will be populated with the data after execution. The table based name used will be: 'spS_Fournisseur_SelectDisplay'.
		/// </param>
		/// <returns>True if the call was successful. Otherwise, it returns False.</returns>
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.spS_Fournisseur_SelectDisplay parameters, ref System.Data.DataSet dataset) {

			return(Execute(ref parameters, ref dataset, "spS_Fournisseur_SelectDisplay", -1, -1));
		}

		/// <summary>
		/// This method allows you to execute the [spS_Fournisseur_SelectDisplay] stored procedure and retrieve back the data
		/// populated in a DataSet (System.Data.DataSet).
		/// </summary>
		/// <param name="parameters">
		/// Contains all the necessary information to execute correctly the stored procedure, i.e. 
		/// the database connection to use and all the necessary input parameters to be supplied
		/// for this stored procedure execution. After the execution, this object will allow you
		/// to retrieve back the stored procedure return value and all the output parameters.
		/// </param>
		/// <param name="dataset">
		/// Will be populated with the data after execution. The table based name used will be: 'spS_Fournisseur_SelectDisplay'.
		/// </param>
		/// <param name="startRecord">The zero-based record number to start with.</param>
		/// <param name="maxRecords">The maximum number of records to retrieve.</param>
		/// <returns>True if the call was successful. Otherwise, it returns False.</returns>
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.spS_Fournisseur_SelectDisplay parameters, ref System.Data.DataSet dataset, int startRecord, int maxRecords) {

			return(Execute(ref parameters, ref dataset, "spS_Fournisseur_SelectDisplay", startRecord, maxRecords));
		}

		/// <summary>
		/// This method allows you to execute the [spS_Fournisseur_SelectDisplay] stored procedure and retrieve back the data
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
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.spS_Fournisseur_SelectDisplay parameters, ref System.Data.DataSet dataset, string tableName) {

			return(Execute(ref parameters, ref dataset, tableName, -1, -1));
		}

		/// <summary>
		/// This method allows you to execute the [spS_Fournisseur_SelectDisplay] stored procedure and retrieve back the data
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
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.spS_Fournisseur_SelectDisplay parameters, ref System.Data.DataSet dataset, string tableName, int startRecord, int maxRecords) {

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

				dataset.Tables[tableName].Columns["ID"].Caption = "ID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ID\" column)";
				dataset.Tables[tableName].Columns["CleTri"].Caption = "CleTri (update this label in the \"Olymars/ColumnLabel\" extended property of the \"CleTri\" column)";
				dataset.Tables[tableName].Columns["Nom"].Caption = "Nom (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Nom\" column)";
				dataset.Tables[tableName].Columns["AuSoinsDe"].Caption = "AuSoinsDe (update this label in the \"Olymars/ColumnLabel\" extended property of the \"AuSoinsDe\" column)";
				dataset.Tables[tableName].Columns["Rue"].Caption = "Rue (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Rue\" column)";
				dataset.Tables[tableName].Columns["Ville"].Caption = "Ville (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Ville\" column)";
				dataset.Tables[tableName].Columns["PaysID"].Caption = "PaysID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"PaysID\" column)";
				dataset.Tables[tableName].Columns["PaysID_Display"].Caption = "Pays_Record";
				dataset.Tables[tableName].Columns["Code_postal"].Caption = "Code_postal (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Code_postal\" column)";
				dataset.Tables[tableName].Columns["Telephone"].Caption = "Telephone (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone\" column)";
				dataset.Tables[tableName].Columns["Telephone_Poste"].Caption = "Telephone_Poste (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone_Poste\" column)";
				dataset.Tables[tableName].Columns["Telecopieur"].Caption = "Telecopieur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telecopieur\" column)";
				dataset.Tables[tableName].Columns["Telephone2"].Caption = "Telephone2 (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone2\" column)";
				dataset.Tables[tableName].Columns["Telephone2_Desc"].Caption = "Telephone2_Desc (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone2_Desc\" column)";
				dataset.Tables[tableName].Columns["Telephone2_Poste"].Caption = "Telephone2_Poste (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone2_Poste\" column)";
				dataset.Tables[tableName].Columns["Telephone3"].Caption = "Telephone3 (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone3\" column)";
				dataset.Tables[tableName].Columns["Telephone3_Desc"].Caption = "Telephone3_Desc (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone3_Desc\" column)";
				dataset.Tables[tableName].Columns["Telephone3_Poste"].Caption = "Telephone3_Poste (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone3_Poste\" column)";
				dataset.Tables[tableName].Columns["No_membre"].Caption = "No_membre (update this label in the \"Olymars/ColumnLabel\" extended property of the \"No_membre\" column)";
				dataset.Tables[tableName].Columns["Resident"].Caption = "Resident (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Resident\" column)";
				dataset.Tables[tableName].Columns["Email"].Caption = "Email (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Email\" column)";
				dataset.Tables[tableName].Columns["WWW"].Caption = "WWW (update this label in the \"Olymars/ColumnLabel\" extended property of the \"WWW\" column)";
				dataset.Tables[tableName].Columns["Commentaires"].Caption = "Commentaires (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Commentaires\" column)";
				dataset.Tables[tableName].Columns["AfficherCommentaires"].Caption = "AfficherCommentaires (update this label in the \"Olymars/ColumnLabel\" extended property of the \"AfficherCommentaires\" column)";
				dataset.Tables[tableName].Columns["DepotDirect"].Caption = "DepotDirect (update this label in the \"Olymars/ColumnLabel\" extended property of the \"DepotDirect\" column)";
				dataset.Tables[tableName].Columns["InstitutionBanquaireID"].Caption = "InstitutionBanquaireID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"InstitutionBanquaireID\" column)";
				dataset.Tables[tableName].Columns["InstitutionBanquaireID_Display"].Caption = "InstitutionBanquaire_Record";
				dataset.Tables[tableName].Columns["Banque_transit"].Caption = "Banque_transit (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Banque_transit\" column)";
				dataset.Tables[tableName].Columns["Banque_folio"].Caption = "Banque_folio (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Banque_folio\" column)";
				dataset.Tables[tableName].Columns["No_TPS"].Caption = "No_TPS (update this label in the \"Olymars/ColumnLabel\" extended property of the \"No_TPS\" column)";
				dataset.Tables[tableName].Columns["No_TVQ"].Caption = "No_TVQ (update this label in the \"Olymars/ColumnLabel\" extended property of the \"No_TVQ\" column)";
				dataset.Tables[tableName].Columns["PayerA"].Caption = "PayerA (update this label in the \"Olymars/ColumnLabel\" extended property of the \"PayerA\" column)";
				dataset.Tables[tableName].Columns["PayerAID"].Caption = "PayerAID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"PayerAID\" column)";
				dataset.Tables[tableName].Columns["Statut"].Caption = "Statut (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Statut\" column)";
				dataset.Tables[tableName].Columns["Rep_Nom"].Caption = "Rep_Nom (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Rep_Nom\" column)";
				dataset.Tables[tableName].Columns["Rep_Telephone"].Caption = "Rep_Telephone (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Rep_Telephone\" column)";
				dataset.Tables[tableName].Columns["Rep_Telephone_Poste"].Caption = "Rep_Telephone_Poste (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Rep_Telephone_Poste\" column)";
				dataset.Tables[tableName].Columns["Rep_Email"].Caption = "Rep_Email (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Rep_Email\" column)";
				dataset.Tables[tableName].Columns["EnAnglais"].Caption = "EnAnglais (update this label in the \"Olymars/ColumnLabel\" extended property of the \"EnAnglais\" column)";
				dataset.Tables[tableName].Columns["Actif"].Caption = "Actif (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Actif\" column)";
				dataset.Tables[tableName].Columns["MRCProducteurID"].Caption = "MRCProducteurID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"MRCProducteurID\" column)";
				dataset.Tables[tableName].Columns["PaiementManuel"].Caption = "PaiementManuel (update this label in the \"Olymars/ColumnLabel\" extended property of the \"PaiementManuel\" column)";
				dataset.Tables[tableName].Columns["Journal"].Caption = "Journal (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Journal\" column)";
				dataset.Tables[tableName].Columns["RecoitTPS"].Caption = "RecoitTPS (update this label in the \"Olymars/ColumnLabel\" extended property of the \"RecoitTPS\" column)";
				dataset.Tables[tableName].Columns["RecoitTVQ"].Caption = "RecoitTVQ (update this label in the \"Olymars/ColumnLabel\" extended property of the \"RecoitTVQ\" column)";
				dataset.Tables[tableName].Columns["ModifierTrigger"].Caption = "ModifierTrigger (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ModifierTrigger\" column)";
				dataset.Tables[tableName].Columns["IsProducteur"].Caption = "IsProducteur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"IsProducteur\" column)";
				dataset.Tables[tableName].Columns["IsTransporteur"].Caption = "IsTransporteur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"IsTransporteur\" column)";
				dataset.Tables[tableName].Columns["IsChargeur"].Caption = "IsChargeur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"IsChargeur\" column)";
				dataset.Tables[tableName].Columns["IsAutre"].Caption = "IsAutre (update this label in the \"Olymars/ColumnLabel\" extended property of the \"IsAutre\" column)";
				dataset.Tables[tableName].Columns["AfficherCommentairesSurPermit"].Caption = "AfficherCommentairesSurPermit (update this label in the \"Olymars/ColumnLabel\" extended property of the \"AfficherCommentairesSurPermit\" column)";
				dataset.Tables[tableName].Columns["PasEmissionPermis"].Caption = "PasEmissionPermis (update this label in the \"Olymars/ColumnLabel\" extended property of the \"PasEmissionPermis\" column)";
				dataset.Tables[tableName].Columns["Generique"].Caption = "Generique (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Generique\" column)";
				dataset.Tables[tableName].Columns["Membre_OGC"].Caption = "Membre_OGC (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Membre_OGC\" column)";
				dataset.Tables[tableName].Columns["InscritTPS"].Caption = "InscritTPS (update this label in the \"Olymars/ColumnLabel\" extended property of the \"InscritTPS\" column)";
				dataset.Tables[tableName].Columns["InscritTVQ"].Caption = "InscritTVQ (update this label in the \"Olymars/ColumnLabel\" extended property of the \"InscritTVQ\" column)";
				dataset.Tables[tableName].Columns["IsOGC"].Caption = "IsOGC (update this label in the \"Olymars/ColumnLabel\" extended property of the \"IsOGC\" column)";
				dataset.Tables[tableName].Columns["Rep2_Nom"].Caption = "Rep2_Nom (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Rep2_Nom\" column)";
				dataset.Tables[tableName].Columns["Rep2_Telephone"].Caption = "Rep2_Telephone (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Rep2_Telephone\" column)";
				dataset.Tables[tableName].Columns["Rep2_Telephone_Poste"].Caption = "Rep2_Telephone_Poste (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Rep2_Telephone_Poste\" column)";
				dataset.Tables[tableName].Columns["Rep2_Email"].Caption = "Rep2_Email (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Rep2_Email\" column)";
				dataset.Tables[tableName].Columns["Rep2_Commentaires"].Caption = "Rep2_Commentaires (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Rep2_Commentaires\" column)";

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
		/// This method allows you to execute the [spS_Fournisseur_SelectDisplay] stored procedure and retrieve back the data
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
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.spS_Fournisseur_SelectDisplay parameters, ref string xml) {

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
		/// This method allows you to execute the [spS_Fournisseur_SelectDisplay] stored procedure and retrieve back the data
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
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.spS_Fournisseur_SelectDisplay parameters, out System.Xml.XmlReader xmlReader) {

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
		/// the Execute method of the 'spS_Fournisseur_SelectDisplay' class.
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
				/// Allows to get the Index and Name of the field CleTri via shared members
				/// </summary>
				public sealed class Column_CleTri {

					/// <summary>
					/// Returns "CleTri"
					/// </summary>
					public const System.String ColumnName = "CleTri";
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
				/// Allows to get the Index and Name of the field AuSoinsDe via shared members
				/// </summary>
				public sealed class Column_AuSoinsDe {

					/// <summary>
					/// Returns "AuSoinsDe"
					/// </summary>
					public const System.String ColumnName = "AuSoinsDe";
					/// <summary>
					/// Returns 3
					/// </summary>
					public const System.Int32 ColumnIndex = 3;

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
				/// Allows to get the Index and Name of the field PaysID via shared members
				/// </summary>
				public sealed class Column_PaysID {

					/// <summary>
					/// Returns "PaysID"
					/// </summary>
					public const System.String ColumnName = "PaysID";
					/// <summary>
					/// Returns 6
					/// </summary>
					public const System.Int32 ColumnIndex = 6;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field PaysID_Display via shared members
				/// </summary>
				public sealed class Column_PaysID_Display {

					/// <summary>
					/// Returns "PaysID_Display"
					/// </summary>
					public const System.String ColumnName = "PaysID_Display";
					/// <summary>
					/// Returns 7
					/// </summary>
					public const System.Int32 ColumnIndex = 7;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Code_postal via shared members
				/// </summary>
				public sealed class Column_Code_postal {

					/// <summary>
					/// Returns "Code_postal"
					/// </summary>
					public const System.String ColumnName = "Code_postal";
					/// <summary>
					/// Returns 8
					/// </summary>
					public const System.Int32 ColumnIndex = 8;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Telephone via shared members
				/// </summary>
				public sealed class Column_Telephone {

					/// <summary>
					/// Returns "Telephone"
					/// </summary>
					public const System.String ColumnName = "Telephone";
					/// <summary>
					/// Returns 9
					/// </summary>
					public const System.Int32 ColumnIndex = 9;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Telephone_Poste via shared members
				/// </summary>
				public sealed class Column_Telephone_Poste {

					/// <summary>
					/// Returns "Telephone_Poste"
					/// </summary>
					public const System.String ColumnName = "Telephone_Poste";
					/// <summary>
					/// Returns 10
					/// </summary>
					public const System.Int32 ColumnIndex = 10;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Telecopieur via shared members
				/// </summary>
				public sealed class Column_Telecopieur {

					/// <summary>
					/// Returns "Telecopieur"
					/// </summary>
					public const System.String ColumnName = "Telecopieur";
					/// <summary>
					/// Returns 11
					/// </summary>
					public const System.Int32 ColumnIndex = 11;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Telephone2 via shared members
				/// </summary>
				public sealed class Column_Telephone2 {

					/// <summary>
					/// Returns "Telephone2"
					/// </summary>
					public const System.String ColumnName = "Telephone2";
					/// <summary>
					/// Returns 12
					/// </summary>
					public const System.Int32 ColumnIndex = 12;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Telephone2_Desc via shared members
				/// </summary>
				public sealed class Column_Telephone2_Desc {

					/// <summary>
					/// Returns "Telephone2_Desc"
					/// </summary>
					public const System.String ColumnName = "Telephone2_Desc";
					/// <summary>
					/// Returns 13
					/// </summary>
					public const System.Int32 ColumnIndex = 13;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Telephone2_Poste via shared members
				/// </summary>
				public sealed class Column_Telephone2_Poste {

					/// <summary>
					/// Returns "Telephone2_Poste"
					/// </summary>
					public const System.String ColumnName = "Telephone2_Poste";
					/// <summary>
					/// Returns 14
					/// </summary>
					public const System.Int32 ColumnIndex = 14;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Telephone3 via shared members
				/// </summary>
				public sealed class Column_Telephone3 {

					/// <summary>
					/// Returns "Telephone3"
					/// </summary>
					public const System.String ColumnName = "Telephone3";
					/// <summary>
					/// Returns 15
					/// </summary>
					public const System.Int32 ColumnIndex = 15;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Telephone3_Desc via shared members
				/// </summary>
				public sealed class Column_Telephone3_Desc {

					/// <summary>
					/// Returns "Telephone3_Desc"
					/// </summary>
					public const System.String ColumnName = "Telephone3_Desc";
					/// <summary>
					/// Returns 16
					/// </summary>
					public const System.Int32 ColumnIndex = 16;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Telephone3_Poste via shared members
				/// </summary>
				public sealed class Column_Telephone3_Poste {

					/// <summary>
					/// Returns "Telephone3_Poste"
					/// </summary>
					public const System.String ColumnName = "Telephone3_Poste";
					/// <summary>
					/// Returns 17
					/// </summary>
					public const System.Int32 ColumnIndex = 17;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field No_membre via shared members
				/// </summary>
				public sealed class Column_No_membre {

					/// <summary>
					/// Returns "No_membre"
					/// </summary>
					public const System.String ColumnName = "No_membre";
					/// <summary>
					/// Returns 18
					/// </summary>
					public const System.Int32 ColumnIndex = 18;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Resident via shared members
				/// </summary>
				public sealed class Column_Resident {

					/// <summary>
					/// Returns "Resident"
					/// </summary>
					public const System.String ColumnName = "Resident";
					/// <summary>
					/// Returns 19
					/// </summary>
					public const System.Int32 ColumnIndex = 19;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Email via shared members
				/// </summary>
				public sealed class Column_Email {

					/// <summary>
					/// Returns "Email"
					/// </summary>
					public const System.String ColumnName = "Email";
					/// <summary>
					/// Returns 20
					/// </summary>
					public const System.Int32 ColumnIndex = 20;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field WWW via shared members
				/// </summary>
				public sealed class Column_WWW {

					/// <summary>
					/// Returns "WWW"
					/// </summary>
					public const System.String ColumnName = "WWW";
					/// <summary>
					/// Returns 21
					/// </summary>
					public const System.Int32 ColumnIndex = 21;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Commentaires via shared members
				/// </summary>
				public sealed class Column_Commentaires {

					/// <summary>
					/// Returns "Commentaires"
					/// </summary>
					public const System.String ColumnName = "Commentaires";
					/// <summary>
					/// Returns 22
					/// </summary>
					public const System.Int32 ColumnIndex = 22;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field AfficherCommentaires via shared members
				/// </summary>
				public sealed class Column_AfficherCommentaires {

					/// <summary>
					/// Returns "AfficherCommentaires"
					/// </summary>
					public const System.String ColumnName = "AfficherCommentaires";
					/// <summary>
					/// Returns 23
					/// </summary>
					public const System.Int32 ColumnIndex = 23;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field DepotDirect via shared members
				/// </summary>
				public sealed class Column_DepotDirect {

					/// <summary>
					/// Returns "DepotDirect"
					/// </summary>
					public const System.String ColumnName = "DepotDirect";
					/// <summary>
					/// Returns 24
					/// </summary>
					public const System.Int32 ColumnIndex = 24;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field InstitutionBanquaireID via shared members
				/// </summary>
				public sealed class Column_InstitutionBanquaireID {

					/// <summary>
					/// Returns "InstitutionBanquaireID"
					/// </summary>
					public const System.String ColumnName = "InstitutionBanquaireID";
					/// <summary>
					/// Returns 25
					/// </summary>
					public const System.Int32 ColumnIndex = 25;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field InstitutionBanquaireID_Display via shared members
				/// </summary>
				public sealed class Column_InstitutionBanquaireID_Display {

					/// <summary>
					/// Returns "InstitutionBanquaireID_Display"
					/// </summary>
					public const System.String ColumnName = "InstitutionBanquaireID_Display";
					/// <summary>
					/// Returns 26
					/// </summary>
					public const System.Int32 ColumnIndex = 26;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Banque_transit via shared members
				/// </summary>
				public sealed class Column_Banque_transit {

					/// <summary>
					/// Returns "Banque_transit"
					/// </summary>
					public const System.String ColumnName = "Banque_transit";
					/// <summary>
					/// Returns 27
					/// </summary>
					public const System.Int32 ColumnIndex = 27;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Banque_folio via shared members
				/// </summary>
				public sealed class Column_Banque_folio {

					/// <summary>
					/// Returns "Banque_folio"
					/// </summary>
					public const System.String ColumnName = "Banque_folio";
					/// <summary>
					/// Returns 28
					/// </summary>
					public const System.Int32 ColumnIndex = 28;

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
					/// Returns 29
					/// </summary>
					public const System.Int32 ColumnIndex = 29;

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
					/// Returns 30
					/// </summary>
					public const System.Int32 ColumnIndex = 30;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field PayerA via shared members
				/// </summary>
				public sealed class Column_PayerA {

					/// <summary>
					/// Returns "PayerA"
					/// </summary>
					public const System.String ColumnName = "PayerA";
					/// <summary>
					/// Returns 31
					/// </summary>
					public const System.Int32 ColumnIndex = 31;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field PayerAID via shared members
				/// </summary>
				public sealed class Column_PayerAID {

					/// <summary>
					/// Returns "PayerAID"
					/// </summary>
					public const System.String ColumnName = "PayerAID";
					/// <summary>
					/// Returns 32
					/// </summary>
					public const System.Int32 ColumnIndex = 32;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Statut via shared members
				/// </summary>
				public sealed class Column_Statut {

					/// <summary>
					/// Returns "Statut"
					/// </summary>
					public const System.String ColumnName = "Statut";
					/// <summary>
					/// Returns 33
					/// </summary>
					public const System.Int32 ColumnIndex = 33;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Rep_Nom via shared members
				/// </summary>
				public sealed class Column_Rep_Nom {

					/// <summary>
					/// Returns "Rep_Nom"
					/// </summary>
					public const System.String ColumnName = "Rep_Nom";
					/// <summary>
					/// Returns 34
					/// </summary>
					public const System.Int32 ColumnIndex = 34;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Rep_Telephone via shared members
				/// </summary>
				public sealed class Column_Rep_Telephone {

					/// <summary>
					/// Returns "Rep_Telephone"
					/// </summary>
					public const System.String ColumnName = "Rep_Telephone";
					/// <summary>
					/// Returns 35
					/// </summary>
					public const System.Int32 ColumnIndex = 35;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Rep_Telephone_Poste via shared members
				/// </summary>
				public sealed class Column_Rep_Telephone_Poste {

					/// <summary>
					/// Returns "Rep_Telephone_Poste"
					/// </summary>
					public const System.String ColumnName = "Rep_Telephone_Poste";
					/// <summary>
					/// Returns 36
					/// </summary>
					public const System.Int32 ColumnIndex = 36;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Rep_Email via shared members
				/// </summary>
				public sealed class Column_Rep_Email {

					/// <summary>
					/// Returns "Rep_Email"
					/// </summary>
					public const System.String ColumnName = "Rep_Email";
					/// <summary>
					/// Returns 37
					/// </summary>
					public const System.Int32 ColumnIndex = 37;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field EnAnglais via shared members
				/// </summary>
				public sealed class Column_EnAnglais {

					/// <summary>
					/// Returns "EnAnglais"
					/// </summary>
					public const System.String ColumnName = "EnAnglais";
					/// <summary>
					/// Returns 38
					/// </summary>
					public const System.Int32 ColumnIndex = 38;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Actif via shared members
				/// </summary>
				public sealed class Column_Actif {

					/// <summary>
					/// Returns "Actif"
					/// </summary>
					public const System.String ColumnName = "Actif";
					/// <summary>
					/// Returns 39
					/// </summary>
					public const System.Int32 ColumnIndex = 39;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field MRCProducteurID via shared members
				/// </summary>
				public sealed class Column_MRCProducteurID {

					/// <summary>
					/// Returns "MRCProducteurID"
					/// </summary>
					public const System.String ColumnName = "MRCProducteurID";
					/// <summary>
					/// Returns 40
					/// </summary>
					public const System.Int32 ColumnIndex = 40;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field PaiementManuel via shared members
				/// </summary>
				public sealed class Column_PaiementManuel {

					/// <summary>
					/// Returns "PaiementManuel"
					/// </summary>
					public const System.String ColumnName = "PaiementManuel";
					/// <summary>
					/// Returns 41
					/// </summary>
					public const System.Int32 ColumnIndex = 41;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Journal via shared members
				/// </summary>
				public sealed class Column_Journal {

					/// <summary>
					/// Returns "Journal"
					/// </summary>
					public const System.String ColumnName = "Journal";
					/// <summary>
					/// Returns 42
					/// </summary>
					public const System.Int32 ColumnIndex = 42;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field RecoitTPS via shared members
				/// </summary>
				public sealed class Column_RecoitTPS {

					/// <summary>
					/// Returns "RecoitTPS"
					/// </summary>
					public const System.String ColumnName = "RecoitTPS";
					/// <summary>
					/// Returns 43
					/// </summary>
					public const System.Int32 ColumnIndex = 43;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field RecoitTVQ via shared members
				/// </summary>
				public sealed class Column_RecoitTVQ {

					/// <summary>
					/// Returns "RecoitTVQ"
					/// </summary>
					public const System.String ColumnName = "RecoitTVQ";
					/// <summary>
					/// Returns 44
					/// </summary>
					public const System.Int32 ColumnIndex = 44;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ModifierTrigger via shared members
				/// </summary>
				public sealed class Column_ModifierTrigger {

					/// <summary>
					/// Returns "ModifierTrigger"
					/// </summary>
					public const System.String ColumnName = "ModifierTrigger";
					/// <summary>
					/// Returns 45
					/// </summary>
					public const System.Int32 ColumnIndex = 45;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field IsProducteur via shared members
				/// </summary>
				public sealed class Column_IsProducteur {

					/// <summary>
					/// Returns "IsProducteur"
					/// </summary>
					public const System.String ColumnName = "IsProducteur";
					/// <summary>
					/// Returns 46
					/// </summary>
					public const System.Int32 ColumnIndex = 46;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field IsTransporteur via shared members
				/// </summary>
				public sealed class Column_IsTransporteur {

					/// <summary>
					/// Returns "IsTransporteur"
					/// </summary>
					public const System.String ColumnName = "IsTransporteur";
					/// <summary>
					/// Returns 47
					/// </summary>
					public const System.Int32 ColumnIndex = 47;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field IsChargeur via shared members
				/// </summary>
				public sealed class Column_IsChargeur {

					/// <summary>
					/// Returns "IsChargeur"
					/// </summary>
					public const System.String ColumnName = "IsChargeur";
					/// <summary>
					/// Returns 48
					/// </summary>
					public const System.Int32 ColumnIndex = 48;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field IsAutre via shared members
				/// </summary>
				public sealed class Column_IsAutre {

					/// <summary>
					/// Returns "IsAutre"
					/// </summary>
					public const System.String ColumnName = "IsAutre";
					/// <summary>
					/// Returns 49
					/// </summary>
					public const System.Int32 ColumnIndex = 49;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field AfficherCommentairesSurPermit via shared members
				/// </summary>
				public sealed class Column_AfficherCommentairesSurPermit {

					/// <summary>
					/// Returns "AfficherCommentairesSurPermit"
					/// </summary>
					public const System.String ColumnName = "AfficherCommentairesSurPermit";
					/// <summary>
					/// Returns 50
					/// </summary>
					public const System.Int32 ColumnIndex = 50;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field PasEmissionPermis via shared members
				/// </summary>
				public sealed class Column_PasEmissionPermis {

					/// <summary>
					/// Returns "PasEmissionPermis"
					/// </summary>
					public const System.String ColumnName = "PasEmissionPermis";
					/// <summary>
					/// Returns 51
					/// </summary>
					public const System.Int32 ColumnIndex = 51;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Generique via shared members
				/// </summary>
				public sealed class Column_Generique {

					/// <summary>
					/// Returns "Generique"
					/// </summary>
					public const System.String ColumnName = "Generique";
					/// <summary>
					/// Returns 52
					/// </summary>
					public const System.Int32 ColumnIndex = 52;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Membre_OGC via shared members
				/// </summary>
				public sealed class Column_Membre_OGC {

					/// <summary>
					/// Returns "Membre_OGC"
					/// </summary>
					public const System.String ColumnName = "Membre_OGC";
					/// <summary>
					/// Returns 53
					/// </summary>
					public const System.Int32 ColumnIndex = 53;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field InscritTPS via shared members
				/// </summary>
				public sealed class Column_InscritTPS {

					/// <summary>
					/// Returns "InscritTPS"
					/// </summary>
					public const System.String ColumnName = "InscritTPS";
					/// <summary>
					/// Returns 54
					/// </summary>
					public const System.Int32 ColumnIndex = 54;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field InscritTVQ via shared members
				/// </summary>
				public sealed class Column_InscritTVQ {

					/// <summary>
					/// Returns "InscritTVQ"
					/// </summary>
					public const System.String ColumnName = "InscritTVQ";
					/// <summary>
					/// Returns 55
					/// </summary>
					public const System.Int32 ColumnIndex = 55;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field IsOGC via shared members
				/// </summary>
				public sealed class Column_IsOGC {

					/// <summary>
					/// Returns "IsOGC"
					/// </summary>
					public const System.String ColumnName = "IsOGC";
					/// <summary>
					/// Returns 56
					/// </summary>
					public const System.Int32 ColumnIndex = 56;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Rep2_Nom via shared members
				/// </summary>
				public sealed class Column_Rep2_Nom {

					/// <summary>
					/// Returns "Rep2_Nom"
					/// </summary>
					public const System.String ColumnName = "Rep2_Nom";
					/// <summary>
					/// Returns 57
					/// </summary>
					public const System.Int32 ColumnIndex = 57;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Rep2_Telephone via shared members
				/// </summary>
				public sealed class Column_Rep2_Telephone {

					/// <summary>
					/// Returns "Rep2_Telephone"
					/// </summary>
					public const System.String ColumnName = "Rep2_Telephone";
					/// <summary>
					/// Returns 58
					/// </summary>
					public const System.Int32 ColumnIndex = 58;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Rep2_Telephone_Poste via shared members
				/// </summary>
				public sealed class Column_Rep2_Telephone_Poste {

					/// <summary>
					/// Returns "Rep2_Telephone_Poste"
					/// </summary>
					public const System.String ColumnName = "Rep2_Telephone_Poste";
					/// <summary>
					/// Returns 59
					/// </summary>
					public const System.Int32 ColumnIndex = 59;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Rep2_Email via shared members
				/// </summary>
				public sealed class Column_Rep2_Email {

					/// <summary>
					/// Returns "Rep2_Email"
					/// </summary>
					public const System.String ColumnName = "Rep2_Email";
					/// <summary>
					/// Returns 60
					/// </summary>
					public const System.Int32 ColumnIndex = 60;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Rep2_Commentaires via shared members
				/// </summary>
				public sealed class Column_Rep2_Commentaires {

					/// <summary>
					/// Returns "Rep2_Commentaires"
					/// </summary>
					public const System.String ColumnName = "Rep2_Commentaires";
					/// <summary>
					/// Returns 61
					/// </summary>
					public const System.Int32 ColumnIndex = 61;

				}

			}
		}

		/// <summary>
		/// This class allows to easily retrieve the name or index of all the fields
		/// of the resulset #2 existing in the Dataset or the SqlDatReader returned by
		/// the Execute method of the 'spS_Fournisseur_SelectDisplay' class.
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

