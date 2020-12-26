using System;

namespace Gestion_Paie.DataClasses.Parameters {

	/// <summary>
	/// This class allows a developer to specify the parameters expected by the
	/// stored procedure 'spS_Lot_Full'. It allows also to specify specific connection
	/// information such as the ConnectionString to be use, the command time-out and so forth.
	/// </summary>
	[Serializable()]
	public sealed class spS_Lot_Full : MarshalByRefObject, IDisposable, IParameter {

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
		/// Initializes a new instance of the spS_Lot_Full class. If you use this constructor version,
		/// not assigning parameter values implies using the parameter default values.
		/// </summary>
		public spS_Lot_Full() : this(true) {

		}

		/// <summary>
		/// Initializes a new instance of the spS_Lot_Full class.
		/// </summary>
		/// <param name="useDefaultValue">If True, this parameter indicates that "not assigning parameter values" implies "using the parameter default values". If False, this parameter indicates that "not assigning parameter values" implies "using the SQL Server Null value".</param>
		public spS_Lot_Full(bool useDefaultValue) {

			this.useDefaultValue = useDefaultValue;

			this.internal_Param_ID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_CantonID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_MunicipaliteID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ProprietaireID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ContingentID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Droit_coupeID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Entente_paiementID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ZoneID_UseDefaultValue = this.useDefaultValue;
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
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'spS_Lot_Full'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

						throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "spS_Lot_Full", CurrentRevision, OriginalRevision, System.Environment.NewLine));
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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'spS_Lot_Full'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlConnection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "spS_Lot_Full", CurrentRevision, OriginalRevision, System.Environment.NewLine));
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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'spS_Lot_Full'";
				sqlCommand.Transaction = sqlTransaction;

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlTransaction.Connection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "spS_Lot_Full", CurrentRevision, OriginalRevision, System.Environment.NewLine));
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
				this.internal_Param_ID = System.Data.SqlTypes.SqlInt32.Null;
				this.internal_Param_CantonID = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_MunicipaliteID = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_ProprietaireID = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_ContingentID = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_Droit_coupeID = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_Entente_paiementID = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_ZoneID = System.Data.SqlTypes.SqlString.Null;
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
		~spS_Lot_Full() {

			Dispose(false);
		}

		/// <summary>
		/// Returns the stored procedure name for which this class was built, i.e. 'spS_Lot_Full'.
		/// </summary>
		public string StoredProcedureName {

			get {

				return("spS_Lot_Full");
			}
		}

		private System.Data.SqlTypes.SqlInt32 internal_Param_RETURN_VALUE;

		private System.Data.SqlTypes.SqlInt32 internal_Param_ID;
		internal bool internal_Param_ID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_CantonID;
		internal bool internal_Param_CantonID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_MunicipaliteID;
		internal bool internal_Param_MunicipaliteID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_ProprietaireID;
		internal bool internal_Param_ProprietaireID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_ContingentID;
		internal bool internal_Param_ContingentID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_Droit_coupeID;
		internal bool internal_Param_Droit_coupeID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_Entente_paiementID;
		internal bool internal_Param_Entente_paiementID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_ZoneID;
		internal bool internal_Param_ZoneID_UseDefaultValue = true;

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

			this.internal_Param_ID = System.Data.SqlTypes.SqlInt32.Null;
			this.internal_Param_ID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_CantonID = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_CantonID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_MunicipaliteID = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_MunicipaliteID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ProprietaireID = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_ProprietaireID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ContingentID = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_ContingentID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Droit_coupeID = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_Droit_coupeID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Entente_paiementID = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_Entente_paiementID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ZoneID = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_ZoneID_UseDefaultValue = this.useDefaultValue;

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
		/// In SQL Server, this parameter is of type: [int]
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
		public System.Data.SqlTypes.SqlInt32 Param_ID {

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
		/// Sets the value of the stored procedure INPUT parameter '@CantonID'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [varchar](6)
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_CantonID_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_CantonID {

			get {

				if (this.internal_Param_CantonID_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_CantonID);
			}

			set {

				this.internal_Param_CantonID_UseDefaultValue = false;
				this.internal_Param_CantonID = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@CantonID' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_CantonID_UseDefaultValue() {

			this.internal_Param_CantonID_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@MunicipaliteID'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [varchar](6)
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_MunicipaliteID_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_MunicipaliteID {

			get {

				if (this.internal_Param_MunicipaliteID_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_MunicipaliteID);
			}

			set {

				this.internal_Param_MunicipaliteID_UseDefaultValue = false;
				this.internal_Param_MunicipaliteID = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@MunicipaliteID' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_MunicipaliteID_UseDefaultValue() {

			this.internal_Param_MunicipaliteID_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ProprietaireID'.
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
		/// the parameter default value, consider calling the Param_ProprietaireID_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_ProprietaireID {

			get {

				if (this.internal_Param_ProprietaireID_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ProprietaireID);
			}

			set {

				this.internal_Param_ProprietaireID_UseDefaultValue = false;
				this.internal_Param_ProprietaireID = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ProprietaireID' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ProprietaireID_UseDefaultValue() {

			this.internal_Param_ProprietaireID_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ContingentID'.
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
		/// the parameter default value, consider calling the Param_ContingentID_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_ContingentID {

			get {

				if (this.internal_Param_ContingentID_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ContingentID);
			}

			set {

				this.internal_Param_ContingentID_UseDefaultValue = false;
				this.internal_Param_ContingentID = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ContingentID' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ContingentID_UseDefaultValue() {

			this.internal_Param_ContingentID_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Droit_coupeID'.
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
		/// the parameter default value, consider calling the Param_Droit_coupeID_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_Droit_coupeID {

			get {

				if (this.internal_Param_Droit_coupeID_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Droit_coupeID);
			}

			set {

				this.internal_Param_Droit_coupeID_UseDefaultValue = false;
				this.internal_Param_Droit_coupeID = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Droit_coupeID' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Droit_coupeID_UseDefaultValue() {

			this.internal_Param_Droit_coupeID_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Entente_paiementID'.
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
		/// the parameter default value, consider calling the Param_Entente_paiementID_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_Entente_paiementID {

			get {

				if (this.internal_Param_Entente_paiementID_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Entente_paiementID);
			}

			set {

				this.internal_Param_Entente_paiementID_UseDefaultValue = false;
				this.internal_Param_Entente_paiementID = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Entente_paiementID' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Entente_paiementID_UseDefaultValue() {

			this.internal_Param_Entente_paiementID_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ZoneID'.
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
		/// the parameter default value, consider calling the Param_ZoneID_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_ZoneID {

			get {

				if (this.internal_Param_ZoneID_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ZoneID);
			}

			set {

				this.internal_Param_ZoneID_UseDefaultValue = false;
				this.internal_Param_ZoneID = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ZoneID' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ZoneID_UseDefaultValue() {

			this.internal_Param_ZoneID_UseDefaultValue = true;
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
	/// This class allows you to execute the 'spS_Lot_Full' stored procedure;
	/// it gives you the ability to:
	/// <list type="bullet">
	/// <item><description>Set all the necessary parameters to execute the stored procedure</description></item>
	/// <item><description>To execute the stored procedure</description></item>
	/// <item><description>To get back after the execution the return value and all the output parameters value</description></item>
	/// </list>
	/// </summary>
	public sealed class spS_Lot_Full : MarshalByRefObject, IDisposable {


		private bool throwExceptionOnExecute = false;

		/// <summary>
		/// Initializes a new instance of the spS_Lot_Full class.
		/// By default, no exception will be thrown when you call the Execute method. Instead, a Boolean return status will be returned.
		/// </summary>
		public spS_Lot_Full() : this(false) {

		}

		/// <summary>
		/// Initializes a new instance of the spS_Lot_Full class.
		/// </summary>
		/// <param name="throwExceptionOnExecute">True if an exception has to be thrown if the Execute call fails.</param>
		public spS_Lot_Full(bool throwExceptionOnExecute) {

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
		~spS_Lot_Full() {

			Dispose(false);
		}

		private void ResetParameter(ref Gestion_Paie.DataClasses.Parameters.spS_Lot_Full parameters) {

			parameters.internal_Set_RETURN_VALUE (System.Data.SqlTypes.SqlInt32.Null);
		}

		private bool InitializeConnection(ref Gestion_Paie.DataClasses.Parameters.spS_Lot_Full parameters, out System.Data.SqlClient.SqlCommand sqlCommand, ref bool connectionMustBeClosed) {

			try {

				this.sqlConnection = null;
				sqlCommand = null;
				connectionMustBeClosed = true;

				if (parameters.ConnectionType == ConnectionType.None) {

					throw new InvalidOperationException("No connection information was supplied. Consider calling the 'SetUpConnection' method of the Gestion_Paie.DataClasses.Parameters.spS_Lot_Full object before doing this call.");
				}

				if (parameters.ConnectionType == ConnectionType.SqlConnection && parameters.SqlConnection == null) {

					throw new InvalidOperationException("No connection information was supplied (SqlConnection == null). Consider calling the 'SetUpConnection' method of the Gestion_Paie.DataClasses.Parameters.spS_Lot_Full object before doing this call.");
				}

				if (parameters.ConnectionType == ConnectionType.SqlTransaction && parameters.SqlTransaction== null) {

					throw new InvalidOperationException("No connection information was supplied (SqlTransaction == null). Consider calling the 'SetUpConnection' method of the Gestion_Paie.DataClasses.Parameters.spS_Lot_Full object before doing this call.");
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

							throw new System.InvalidOperationException("No connection information was supplied (ConnectionString == \"\")! (Gestion_Paie.DataClasses.Parameters.spS_Lot_Full)");
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
				sqlCommand.CommandText = "spS_Lot_Full";

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

		private bool DeclareParameters(ref Gestion_Paie.DataClasses.Parameters.spS_Lot_Full parameters, ref System.Data.SqlClient.SqlCommand sqlCommand) {

			try {

				System.Data.SqlClient.SqlParameter sqlParameter;

				sqlParameter = new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4);
				sqlParameter.Direction = System.Data.ParameterDirection.ReturnValue;
				sqlParameter.IsNullable = true;
				sqlParameter.Value = System.DBNull.Value;
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.Int, 4);
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

				sqlParameter = new System.Data.SqlClient.SqlParameter("@CantonID", System.Data.SqlDbType.VarChar, 6);
				sqlParameter.SourceColumn = "CantonID";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_CantonID_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_CantonID.IsNull) {

					sqlParameter.Value = parameters.Param_CantonID;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@MunicipaliteID", System.Data.SqlDbType.VarChar, 6);
				sqlParameter.SourceColumn = "MunicipaliteID";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_MunicipaliteID_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_MunicipaliteID.IsNull) {

					sqlParameter.Value = parameters.Param_MunicipaliteID;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ProprietaireID", System.Data.SqlDbType.VarChar, 15);
				sqlParameter.SourceColumn = "ProprietaireID";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ProprietaireID_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ProprietaireID.IsNull) {

					sqlParameter.Value = parameters.Param_ProprietaireID;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ContingentID", System.Data.SqlDbType.VarChar, 15);
				sqlParameter.SourceColumn = "ContingentID";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ContingentID_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ContingentID.IsNull) {

					sqlParameter.Value = parameters.Param_ContingentID;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Droit_coupeID", System.Data.SqlDbType.VarChar, 15);
				sqlParameter.SourceColumn = "Droit_coupeID";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Droit_coupeID_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Droit_coupeID.IsNull) {

					sqlParameter.Value = parameters.Param_Droit_coupeID;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Entente_paiementID", System.Data.SqlDbType.VarChar, 15);
				sqlParameter.SourceColumn = "Entente_paiementID";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Entente_paiementID_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Entente_paiementID.IsNull) {

					sqlParameter.Value = parameters.Param_Entente_paiementID;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ZoneID", System.Data.SqlDbType.VarChar, 2);
				sqlParameter.SourceColumn = "ZoneID";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ZoneID_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ZoneID.IsNull) {

					sqlParameter.Value = parameters.Param_ZoneID;
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

		private bool RetrieveParameters(ref Gestion_Paie.DataClasses.Parameters.spS_Lot_Full parameters, ref System.Data.SqlClient.SqlCommand sqlCommand) {

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
		/// This method allows you to execute the [spS_Lot_Full] stored procedure and retrieve back the data
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
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.spS_Lot_Full parameters, out System.Data.SqlClient.SqlDataReader sqlDataReader) {

			return(Execute(ref parameters, out sqlDataReader, System.Data.CommandBehavior.Default));
		}

		/// <summary>
		/// This method allows you to execute the [spS_Lot_Full] stored procedure and retrieve back the data
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
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.spS_Lot_Full parameters, out System.Data.SqlClient.SqlDataReader sqlDataReader, System.Data.CommandBehavior commandBehavior) {

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
		/// This method allows you to execute the [spS_Lot_Full] stored procedure and retrieve back the data
		/// populated in a DataSet (System.Data.DataSet).
		/// </summary>
		/// <param name="parameters">
		/// Contains all the necessary information to execute correctly the stored procedure, i.e. 
		/// the database connection to use and all the necessary input parameters to be supplied
		/// for this stored procedure execution. After the execution, this object will allow you
		/// to retrieve back the stored procedure return value and all the output parameters.
		/// </param>
		/// <param name="dataset">
		/// Will be populated with the data after execution. The table based name used will be: 'spS_Lot_Full'.
		/// </param>
		/// <returns>True if the call was successful. Otherwise, it returns False.</returns>
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.spS_Lot_Full parameters, ref System.Data.DataSet dataset) {

			return(Execute(ref parameters, ref dataset, "spS_Lot_Full", -1, -1));
		}

		/// <summary>
		/// This method allows you to execute the [spS_Lot_Full] stored procedure and retrieve back the data
		/// populated in a DataSet (System.Data.DataSet).
		/// </summary>
		/// <param name="parameters">
		/// Contains all the necessary information to execute correctly the stored procedure, i.e. 
		/// the database connection to use and all the necessary input parameters to be supplied
		/// for this stored procedure execution. After the execution, this object will allow you
		/// to retrieve back the stored procedure return value and all the output parameters.
		/// </param>
		/// <param name="dataset">
		/// Will be populated with the data after execution. The table based name used will be: 'spS_Lot_Full'.
		/// </param>
		/// <param name="startRecord">The zero-based record number to start with.</param>
		/// <param name="maxRecords">The maximum number of records to retrieve.</param>
		/// <returns>True if the call was successful. Otherwise, it returns False.</returns>
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.spS_Lot_Full parameters, ref System.Data.DataSet dataset, int startRecord, int maxRecords) {

			return(Execute(ref parameters, ref dataset, "spS_Lot_Full", startRecord, maxRecords));
		}

		/// <summary>
		/// This method allows you to execute the [spS_Lot_Full] stored procedure and retrieve back the data
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
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.spS_Lot_Full parameters, ref System.Data.DataSet dataset, string tableName) {

			return(Execute(ref parameters, ref dataset, tableName, -1, -1));
		}

		/// <summary>
		/// This method allows you to execute the [spS_Lot_Full] stored procedure and retrieve back the data
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
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.spS_Lot_Full parameters, ref System.Data.DataSet dataset, string tableName, int startRecord, int maxRecords) {

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

				dataset.Tables[tableName].Columns["CantonID"].Caption = "CantonID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"CantonID\" column)";
				dataset.Tables[tableName].Columns["Rang"].Caption = "Rang (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Rang\" column)";
				dataset.Tables[tableName].Columns["Lot"].Caption = "Lot (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Lot\" column)";
				dataset.Tables[tableName].Columns["MunicipaliteID"].Caption = "MunicipaliteID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"MunicipaliteID\" column)";
				dataset.Tables[tableName].Columns["Superficie_total"].Caption = "Superficie_total (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Superficie_total\" column)";
				dataset.Tables[tableName].Columns["Superficie_boisee"].Caption = "Superficie_boisee (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Superficie_boisee\" column)";
				dataset.Tables[tableName].Columns["ProprietaireID"].Caption = "ProprietaireID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ProprietaireID\" column)";
				dataset.Tables[tableName].Columns["ContingentID"].Caption = "ContingentID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ContingentID\" column)";
				dataset.Tables[tableName].Columns["Contingent_Date"].Caption = "Contingent_Date (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Contingent_Date\" column)";
				dataset.Tables[tableName].Columns["Droit_coupeID"].Caption = "Droit_coupeID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Droit_coupeID\" column)";
				dataset.Tables[tableName].Columns["Droit_coupe_Date"].Caption = "Droit_coupe_Date (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Droit_coupe_Date\" column)";
				dataset.Tables[tableName].Columns["Entente_paiementID"].Caption = "Entente_paiementID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Entente_paiementID\" column)";
				dataset.Tables[tableName].Columns["Entente_paiement_Date"].Caption = "Entente_paiement_Date (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Entente_paiement_Date\" column)";
				dataset.Tables[tableName].Columns["Actif"].Caption = "Actif (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Actif\" column)";
				dataset.Tables[tableName].Columns["ID"].Caption = "ID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ID\" column)";
				dataset.Tables[tableName].Columns["Sequence"].Caption = "Sequence (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Sequence\" column)";
				dataset.Tables[tableName].Columns["Partie"].Caption = "Partie (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Partie\" column)";
				dataset.Tables[tableName].Columns["Matricule"].Caption = "Matricule (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Matricule\" column)";
				dataset.Tables[tableName].Columns["ZoneID"].Caption = "ZoneID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ZoneID\" column)";
				dataset.Tables[tableName].Columns["Secteur"].Caption = "Secteur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Secteur\" column)";
				dataset.Tables[tableName].Columns["Cadastre"].Caption = "Cadastre (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Cadastre\" column)";
				dataset.Tables[tableName].Columns["Reforme"].Caption = "Reforme (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Reforme\" column)";
				dataset.Tables[tableName].Columns["LotsComplementaires"].Caption = "LotsComplementaires (update this label in the \"Olymars/ColumnLabel\" extended property of the \"LotsComplementaires\" column)";
				dataset.Tables[tableName].Columns["Certifie"].Caption = "Certifie (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Certifie\" column)";
				dataset.Tables[tableName].Columns["NumeroCertification"].Caption = "NumeroCertification (update this label in the \"Olymars/ColumnLabel\" extended property of the \"NumeroCertification\" column)";
				dataset.Tables[tableName].Columns["OGC"].Caption = "OGC (update this label in the \"Olymars/ColumnLabel\" extended property of the \"OGC\" column)";
				dataset.Tables[tableName].Columns["CantonID_ID"].Caption = "ID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ID\" column)";
				dataset.Tables[tableName].Columns["CantonID_Description"].Caption = "Description (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Description\" column)";
				dataset.Tables[tableName].Columns["CantonID_Actif"].Caption = "Actif (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Actif\" column)";
				dataset.Tables[tableName].Columns["MunicipaliteID_ID"].Caption = "ID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ID\" column)";
				dataset.Tables[tableName].Columns["MunicipaliteID_MunicipaliteID"].Caption = "MunicipaliteID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"MunicipaliteID\" column)";
				dataset.Tables[tableName].Columns["MunicipaliteID_Description"].Caption = "Description (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Description\" column)";
				dataset.Tables[tableName].Columns["MunicipaliteID_Actif"].Caption = "Actif (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Actif\" column)";
				dataset.Tables[tableName].Columns["ProprietaireID_ID"].Caption = "ID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ID\" column)";
				dataset.Tables[tableName].Columns["ProprietaireID_CleTri"].Caption = "CleTri (update this label in the \"Olymars/ColumnLabel\" extended property of the \"CleTri\" column)";
				dataset.Tables[tableName].Columns["ProprietaireID_Nom"].Caption = "Nom (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Nom\" column)";
				dataset.Tables[tableName].Columns["ProprietaireID_AuSoinsDe"].Caption = "AuSoinsDe (update this label in the \"Olymars/ColumnLabel\" extended property of the \"AuSoinsDe\" column)";
				dataset.Tables[tableName].Columns["ProprietaireID_Rue"].Caption = "Rue (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Rue\" column)";
				dataset.Tables[tableName].Columns["ProprietaireID_Ville"].Caption = "Ville (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Ville\" column)";
				dataset.Tables[tableName].Columns["ProprietaireID_PaysID"].Caption = "PaysID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"PaysID\" column)";
				dataset.Tables[tableName].Columns["ProprietaireID_Code_postal"].Caption = "Code_postal (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Code_postal\" column)";
				dataset.Tables[tableName].Columns["ProprietaireID_Telephone"].Caption = "Telephone (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone\" column)";
				dataset.Tables[tableName].Columns["ProprietaireID_Telephone_Poste"].Caption = "Telephone_Poste (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone_Poste\" column)";
				dataset.Tables[tableName].Columns["ProprietaireID_Telecopieur"].Caption = "Telecopieur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telecopieur\" column)";
				dataset.Tables[tableName].Columns["ProprietaireID_Telephone2"].Caption = "Telephone2 (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone2\" column)";
				dataset.Tables[tableName].Columns["ProprietaireID_Telephone2_Desc"].Caption = "Telephone2_Desc (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone2_Desc\" column)";
				dataset.Tables[tableName].Columns["ProprietaireID_Telephone2_Poste"].Caption = "Telephone2_Poste (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone2_Poste\" column)";
				dataset.Tables[tableName].Columns["ProprietaireID_Telephone3"].Caption = "Telephone3 (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone3\" column)";
				dataset.Tables[tableName].Columns["ProprietaireID_Telephone3_Desc"].Caption = "Telephone3_Desc (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone3_Desc\" column)";
				dataset.Tables[tableName].Columns["ProprietaireID_Telephone3_Poste"].Caption = "Telephone3_Poste (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone3_Poste\" column)";
				dataset.Tables[tableName].Columns["ProprietaireID_No_membre"].Caption = "No_membre (update this label in the \"Olymars/ColumnLabel\" extended property of the \"No_membre\" column)";
				dataset.Tables[tableName].Columns["ProprietaireID_Resident"].Caption = "Resident (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Resident\" column)";
				dataset.Tables[tableName].Columns["ProprietaireID_Email"].Caption = "Email (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Email\" column)";
				dataset.Tables[tableName].Columns["ProprietaireID_WWW"].Caption = "WWW (update this label in the \"Olymars/ColumnLabel\" extended property of the \"WWW\" column)";
				dataset.Tables[tableName].Columns["ProprietaireID_Commentaires"].Caption = "Commentaires (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Commentaires\" column)";
				dataset.Tables[tableName].Columns["ProprietaireID_AfficherCommentaires"].Caption = "AfficherCommentaires (update this label in the \"Olymars/ColumnLabel\" extended property of the \"AfficherCommentaires\" column)";
				dataset.Tables[tableName].Columns["ProprietaireID_DepotDirect"].Caption = "DepotDirect (update this label in the \"Olymars/ColumnLabel\" extended property of the \"DepotDirect\" column)";
				dataset.Tables[tableName].Columns["ProprietaireID_InstitutionBanquaireID"].Caption = "InstitutionBanquaireID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"InstitutionBanquaireID\" column)";
				dataset.Tables[tableName].Columns["ProprietaireID_Banque_transit"].Caption = "Banque_transit (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Banque_transit\" column)";
				dataset.Tables[tableName].Columns["ProprietaireID_Banque_folio"].Caption = "Banque_folio (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Banque_folio\" column)";
				dataset.Tables[tableName].Columns["ProprietaireID_No_TPS"].Caption = "No_TPS (update this label in the \"Olymars/ColumnLabel\" extended property of the \"No_TPS\" column)";
				dataset.Tables[tableName].Columns["ProprietaireID_No_TVQ"].Caption = "No_TVQ (update this label in the \"Olymars/ColumnLabel\" extended property of the \"No_TVQ\" column)";
				dataset.Tables[tableName].Columns["ProprietaireID_PayerA"].Caption = "PayerA (update this label in the \"Olymars/ColumnLabel\" extended property of the \"PayerA\" column)";
				dataset.Tables[tableName].Columns["ProprietaireID_PayerAID"].Caption = "PayerAID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"PayerAID\" column)";
				dataset.Tables[tableName].Columns["ProprietaireID_Statut"].Caption = "Statut (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Statut\" column)";
				dataset.Tables[tableName].Columns["ProprietaireID_Rep_Nom"].Caption = "Rep_Nom (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Rep_Nom\" column)";
				dataset.Tables[tableName].Columns["ProprietaireID_Rep_Telephone"].Caption = "Rep_Telephone (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Rep_Telephone\" column)";
				dataset.Tables[tableName].Columns["ProprietaireID_Rep_Telephone_Poste"].Caption = "Rep_Telephone_Poste (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Rep_Telephone_Poste\" column)";
				dataset.Tables[tableName].Columns["ProprietaireID_Rep_Email"].Caption = "Rep_Email (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Rep_Email\" column)";
				dataset.Tables[tableName].Columns["ProprietaireID_EnAnglais"].Caption = "EnAnglais (update this label in the \"Olymars/ColumnLabel\" extended property of the \"EnAnglais\" column)";
				dataset.Tables[tableName].Columns["ProprietaireID_Actif"].Caption = "Actif (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Actif\" column)";
				dataset.Tables[tableName].Columns["ProprietaireID_MRCProducteurID"].Caption = "MRCProducteurID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"MRCProducteurID\" column)";
				dataset.Tables[tableName].Columns["ProprietaireID_PaiementManuel"].Caption = "PaiementManuel (update this label in the \"Olymars/ColumnLabel\" extended property of the \"PaiementManuel\" column)";
				dataset.Tables[tableName].Columns["ProprietaireID_Journal"].Caption = "Journal (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Journal\" column)";
				dataset.Tables[tableName].Columns["ProprietaireID_RecoitTPS"].Caption = "RecoitTPS (update this label in the \"Olymars/ColumnLabel\" extended property of the \"RecoitTPS\" column)";
				dataset.Tables[tableName].Columns["ProprietaireID_RecoitTVQ"].Caption = "RecoitTVQ (update this label in the \"Olymars/ColumnLabel\" extended property of the \"RecoitTVQ\" column)";
				dataset.Tables[tableName].Columns["ProprietaireID_ModifierTrigger"].Caption = "ModifierTrigger (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ModifierTrigger\" column)";
				dataset.Tables[tableName].Columns["ProprietaireID_IsProducteur"].Caption = "IsProducteur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"IsProducteur\" column)";
				dataset.Tables[tableName].Columns["ProprietaireID_IsTransporteur"].Caption = "IsTransporteur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"IsTransporteur\" column)";
				dataset.Tables[tableName].Columns["ProprietaireID_IsChargeur"].Caption = "IsChargeur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"IsChargeur\" column)";
				dataset.Tables[tableName].Columns["ProprietaireID_IsAutre"].Caption = "IsAutre (update this label in the \"Olymars/ColumnLabel\" extended property of the \"IsAutre\" column)";
				dataset.Tables[tableName].Columns["ProprietaireID_AfficherCommentairesSurPermit"].Caption = "AfficherCommentairesSurPermit (update this label in the \"Olymars/ColumnLabel\" extended property of the \"AfficherCommentairesSurPermit\" column)";
				dataset.Tables[tableName].Columns["ProprietaireID_PasEmissionPermis"].Caption = "PasEmissionPermis (update this label in the \"Olymars/ColumnLabel\" extended property of the \"PasEmissionPermis\" column)";
				dataset.Tables[tableName].Columns["ProprietaireID_Generique"].Caption = "Generique (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Generique\" column)";
				dataset.Tables[tableName].Columns["ProprietaireID_Membre_OGC"].Caption = "Membre_OGC (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Membre_OGC\" column)";
				dataset.Tables[tableName].Columns["ProprietaireID_InscritTPS"].Caption = "InscritTPS (update this label in the \"Olymars/ColumnLabel\" extended property of the \"InscritTPS\" column)";
				dataset.Tables[tableName].Columns["ProprietaireID_InscritTVQ"].Caption = "InscritTVQ (update this label in the \"Olymars/ColumnLabel\" extended property of the \"InscritTVQ\" column)";
				dataset.Tables[tableName].Columns["ContingentID_ID"].Caption = "ID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ID\" column)";
				dataset.Tables[tableName].Columns["ContingentID_CleTri"].Caption = "CleTri (update this label in the \"Olymars/ColumnLabel\" extended property of the \"CleTri\" column)";
				dataset.Tables[tableName].Columns["ContingentID_Nom"].Caption = "Nom (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Nom\" column)";
				dataset.Tables[tableName].Columns["ContingentID_AuSoinsDe"].Caption = "AuSoinsDe (update this label in the \"Olymars/ColumnLabel\" extended property of the \"AuSoinsDe\" column)";
				dataset.Tables[tableName].Columns["ContingentID_Rue"].Caption = "Rue (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Rue\" column)";
				dataset.Tables[tableName].Columns["ContingentID_Ville"].Caption = "Ville (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Ville\" column)";
				dataset.Tables[tableName].Columns["ContingentID_PaysID"].Caption = "PaysID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"PaysID\" column)";
				dataset.Tables[tableName].Columns["ContingentID_Code_postal"].Caption = "Code_postal (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Code_postal\" column)";
				dataset.Tables[tableName].Columns["ContingentID_Telephone"].Caption = "Telephone (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone\" column)";
				dataset.Tables[tableName].Columns["ContingentID_Telephone_Poste"].Caption = "Telephone_Poste (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone_Poste\" column)";
				dataset.Tables[tableName].Columns["ContingentID_Telecopieur"].Caption = "Telecopieur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telecopieur\" column)";
				dataset.Tables[tableName].Columns["ContingentID_Telephone2"].Caption = "Telephone2 (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone2\" column)";
				dataset.Tables[tableName].Columns["ContingentID_Telephone2_Desc"].Caption = "Telephone2_Desc (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone2_Desc\" column)";
				dataset.Tables[tableName].Columns["ContingentID_Telephone2_Poste"].Caption = "Telephone2_Poste (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone2_Poste\" column)";
				dataset.Tables[tableName].Columns["ContingentID_Telephone3"].Caption = "Telephone3 (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone3\" column)";
				dataset.Tables[tableName].Columns["ContingentID_Telephone3_Desc"].Caption = "Telephone3_Desc (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone3_Desc\" column)";
				dataset.Tables[tableName].Columns["ContingentID_Telephone3_Poste"].Caption = "Telephone3_Poste (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone3_Poste\" column)";
				dataset.Tables[tableName].Columns["ContingentID_No_membre"].Caption = "No_membre (update this label in the \"Olymars/ColumnLabel\" extended property of the \"No_membre\" column)";
				dataset.Tables[tableName].Columns["ContingentID_Resident"].Caption = "Resident (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Resident\" column)";
				dataset.Tables[tableName].Columns["ContingentID_Email"].Caption = "Email (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Email\" column)";
				dataset.Tables[tableName].Columns["ContingentID_WWW"].Caption = "WWW (update this label in the \"Olymars/ColumnLabel\" extended property of the \"WWW\" column)";
				dataset.Tables[tableName].Columns["ContingentID_Commentaires"].Caption = "Commentaires (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Commentaires\" column)";
				dataset.Tables[tableName].Columns["ContingentID_AfficherCommentaires"].Caption = "AfficherCommentaires (update this label in the \"Olymars/ColumnLabel\" extended property of the \"AfficherCommentaires\" column)";
				dataset.Tables[tableName].Columns["ContingentID_DepotDirect"].Caption = "DepotDirect (update this label in the \"Olymars/ColumnLabel\" extended property of the \"DepotDirect\" column)";
				dataset.Tables[tableName].Columns["ContingentID_InstitutionBanquaireID"].Caption = "InstitutionBanquaireID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"InstitutionBanquaireID\" column)";
				dataset.Tables[tableName].Columns["ContingentID_Banque_transit"].Caption = "Banque_transit (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Banque_transit\" column)";
				dataset.Tables[tableName].Columns["ContingentID_Banque_folio"].Caption = "Banque_folio (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Banque_folio\" column)";
				dataset.Tables[tableName].Columns["ContingentID_No_TPS"].Caption = "No_TPS (update this label in the \"Olymars/ColumnLabel\" extended property of the \"No_TPS\" column)";
				dataset.Tables[tableName].Columns["ContingentID_No_TVQ"].Caption = "No_TVQ (update this label in the \"Olymars/ColumnLabel\" extended property of the \"No_TVQ\" column)";
				dataset.Tables[tableName].Columns["ContingentID_PayerA"].Caption = "PayerA (update this label in the \"Olymars/ColumnLabel\" extended property of the \"PayerA\" column)";
				dataset.Tables[tableName].Columns["ContingentID_PayerAID"].Caption = "PayerAID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"PayerAID\" column)";
				dataset.Tables[tableName].Columns["ContingentID_Statut"].Caption = "Statut (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Statut\" column)";
				dataset.Tables[tableName].Columns["ContingentID_Rep_Nom"].Caption = "Rep_Nom (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Rep_Nom\" column)";
				dataset.Tables[tableName].Columns["ContingentID_Rep_Telephone"].Caption = "Rep_Telephone (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Rep_Telephone\" column)";
				dataset.Tables[tableName].Columns["ContingentID_Rep_Telephone_Poste"].Caption = "Rep_Telephone_Poste (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Rep_Telephone_Poste\" column)";
				dataset.Tables[tableName].Columns["ContingentID_Rep_Email"].Caption = "Rep_Email (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Rep_Email\" column)";
				dataset.Tables[tableName].Columns["ContingentID_EnAnglais"].Caption = "EnAnglais (update this label in the \"Olymars/ColumnLabel\" extended property of the \"EnAnglais\" column)";
				dataset.Tables[tableName].Columns["ContingentID_Actif"].Caption = "Actif (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Actif\" column)";
				dataset.Tables[tableName].Columns["ContingentID_MRCProducteurID"].Caption = "MRCProducteurID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"MRCProducteurID\" column)";
				dataset.Tables[tableName].Columns["ContingentID_PaiementManuel"].Caption = "PaiementManuel (update this label in the \"Olymars/ColumnLabel\" extended property of the \"PaiementManuel\" column)";
				dataset.Tables[tableName].Columns["ContingentID_Journal"].Caption = "Journal (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Journal\" column)";
				dataset.Tables[tableName].Columns["ContingentID_RecoitTPS"].Caption = "RecoitTPS (update this label in the \"Olymars/ColumnLabel\" extended property of the \"RecoitTPS\" column)";
				dataset.Tables[tableName].Columns["ContingentID_RecoitTVQ"].Caption = "RecoitTVQ (update this label in the \"Olymars/ColumnLabel\" extended property of the \"RecoitTVQ\" column)";
				dataset.Tables[tableName].Columns["ContingentID_ModifierTrigger"].Caption = "ModifierTrigger (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ModifierTrigger\" column)";
				dataset.Tables[tableName].Columns["ContingentID_IsProducteur"].Caption = "IsProducteur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"IsProducteur\" column)";
				dataset.Tables[tableName].Columns["ContingentID_IsTransporteur"].Caption = "IsTransporteur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"IsTransporteur\" column)";
				dataset.Tables[tableName].Columns["ContingentID_IsChargeur"].Caption = "IsChargeur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"IsChargeur\" column)";
				dataset.Tables[tableName].Columns["ContingentID_IsAutre"].Caption = "IsAutre (update this label in the \"Olymars/ColumnLabel\" extended property of the \"IsAutre\" column)";
				dataset.Tables[tableName].Columns["ContingentID_AfficherCommentairesSurPermit"].Caption = "AfficherCommentairesSurPermit (update this label in the \"Olymars/ColumnLabel\" extended property of the \"AfficherCommentairesSurPermit\" column)";
				dataset.Tables[tableName].Columns["ContingentID_PasEmissionPermis"].Caption = "PasEmissionPermis (update this label in the \"Olymars/ColumnLabel\" extended property of the \"PasEmissionPermis\" column)";
				dataset.Tables[tableName].Columns["ContingentID_Generique"].Caption = "Generique (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Generique\" column)";
				dataset.Tables[tableName].Columns["ContingentID_Membre_OGC"].Caption = "Membre_OGC (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Membre_OGC\" column)";
				dataset.Tables[tableName].Columns["ContingentID_InscritTPS"].Caption = "InscritTPS (update this label in the \"Olymars/ColumnLabel\" extended property of the \"InscritTPS\" column)";
				dataset.Tables[tableName].Columns["ContingentID_InscritTVQ"].Caption = "InscritTVQ (update this label in the \"Olymars/ColumnLabel\" extended property of the \"InscritTVQ\" column)";
				dataset.Tables[tableName].Columns["Droit_coupeID_ID"].Caption = "ID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ID\" column)";
				dataset.Tables[tableName].Columns["Droit_coupeID_CleTri"].Caption = "CleTri (update this label in the \"Olymars/ColumnLabel\" extended property of the \"CleTri\" column)";
				dataset.Tables[tableName].Columns["Droit_coupeID_Nom"].Caption = "Nom (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Nom\" column)";
				dataset.Tables[tableName].Columns["Droit_coupeID_AuSoinsDe"].Caption = "AuSoinsDe (update this label in the \"Olymars/ColumnLabel\" extended property of the \"AuSoinsDe\" column)";
				dataset.Tables[tableName].Columns["Droit_coupeID_Rue"].Caption = "Rue (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Rue\" column)";
				dataset.Tables[tableName].Columns["Droit_coupeID_Ville"].Caption = "Ville (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Ville\" column)";
				dataset.Tables[tableName].Columns["Droit_coupeID_PaysID"].Caption = "PaysID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"PaysID\" column)";
				dataset.Tables[tableName].Columns["Droit_coupeID_Code_postal"].Caption = "Code_postal (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Code_postal\" column)";
				dataset.Tables[tableName].Columns["Droit_coupeID_Telephone"].Caption = "Telephone (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone\" column)";
				dataset.Tables[tableName].Columns["Droit_coupeID_Telephone_Poste"].Caption = "Telephone_Poste (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone_Poste\" column)";
				dataset.Tables[tableName].Columns["Droit_coupeID_Telecopieur"].Caption = "Telecopieur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telecopieur\" column)";
				dataset.Tables[tableName].Columns["Droit_coupeID_Telephone2"].Caption = "Telephone2 (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone2\" column)";
				dataset.Tables[tableName].Columns["Droit_coupeID_Telephone2_Desc"].Caption = "Telephone2_Desc (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone2_Desc\" column)";
				dataset.Tables[tableName].Columns["Droit_coupeID_Telephone2_Poste"].Caption = "Telephone2_Poste (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone2_Poste\" column)";
				dataset.Tables[tableName].Columns["Droit_coupeID_Telephone3"].Caption = "Telephone3 (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone3\" column)";
				dataset.Tables[tableName].Columns["Droit_coupeID_Telephone3_Desc"].Caption = "Telephone3_Desc (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone3_Desc\" column)";
				dataset.Tables[tableName].Columns["Droit_coupeID_Telephone3_Poste"].Caption = "Telephone3_Poste (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone3_Poste\" column)";
				dataset.Tables[tableName].Columns["Droit_coupeID_No_membre"].Caption = "No_membre (update this label in the \"Olymars/ColumnLabel\" extended property of the \"No_membre\" column)";
				dataset.Tables[tableName].Columns["Droit_coupeID_Resident"].Caption = "Resident (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Resident\" column)";
				dataset.Tables[tableName].Columns["Droit_coupeID_Email"].Caption = "Email (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Email\" column)";
				dataset.Tables[tableName].Columns["Droit_coupeID_WWW"].Caption = "WWW (update this label in the \"Olymars/ColumnLabel\" extended property of the \"WWW\" column)";
				dataset.Tables[tableName].Columns["Droit_coupeID_Commentaires"].Caption = "Commentaires (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Commentaires\" column)";
				dataset.Tables[tableName].Columns["Droit_coupeID_AfficherCommentaires"].Caption = "AfficherCommentaires (update this label in the \"Olymars/ColumnLabel\" extended property of the \"AfficherCommentaires\" column)";
				dataset.Tables[tableName].Columns["Droit_coupeID_DepotDirect"].Caption = "DepotDirect (update this label in the \"Olymars/ColumnLabel\" extended property of the \"DepotDirect\" column)";
				dataset.Tables[tableName].Columns["Droit_coupeID_InstitutionBanquaireID"].Caption = "InstitutionBanquaireID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"InstitutionBanquaireID\" column)";
				dataset.Tables[tableName].Columns["Droit_coupeID_Banque_transit"].Caption = "Banque_transit (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Banque_transit\" column)";
				dataset.Tables[tableName].Columns["Droit_coupeID_Banque_folio"].Caption = "Banque_folio (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Banque_folio\" column)";
				dataset.Tables[tableName].Columns["Droit_coupeID_No_TPS"].Caption = "No_TPS (update this label in the \"Olymars/ColumnLabel\" extended property of the \"No_TPS\" column)";
				dataset.Tables[tableName].Columns["Droit_coupeID_No_TVQ"].Caption = "No_TVQ (update this label in the \"Olymars/ColumnLabel\" extended property of the \"No_TVQ\" column)";
				dataset.Tables[tableName].Columns["Droit_coupeID_PayerA"].Caption = "PayerA (update this label in the \"Olymars/ColumnLabel\" extended property of the \"PayerA\" column)";
				dataset.Tables[tableName].Columns["Droit_coupeID_PayerAID"].Caption = "PayerAID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"PayerAID\" column)";
				dataset.Tables[tableName].Columns["Droit_coupeID_Statut"].Caption = "Statut (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Statut\" column)";
				dataset.Tables[tableName].Columns["Droit_coupeID_Rep_Nom"].Caption = "Rep_Nom (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Rep_Nom\" column)";
				dataset.Tables[tableName].Columns["Droit_coupeID_Rep_Telephone"].Caption = "Rep_Telephone (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Rep_Telephone\" column)";
				dataset.Tables[tableName].Columns["Droit_coupeID_Rep_Telephone_Poste"].Caption = "Rep_Telephone_Poste (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Rep_Telephone_Poste\" column)";
				dataset.Tables[tableName].Columns["Droit_coupeID_Rep_Email"].Caption = "Rep_Email (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Rep_Email\" column)";
				dataset.Tables[tableName].Columns["Droit_coupeID_EnAnglais"].Caption = "EnAnglais (update this label in the \"Olymars/ColumnLabel\" extended property of the \"EnAnglais\" column)";
				dataset.Tables[tableName].Columns["Droit_coupeID_Actif"].Caption = "Actif (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Actif\" column)";
				dataset.Tables[tableName].Columns["Droit_coupeID_MRCProducteurID"].Caption = "MRCProducteurID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"MRCProducteurID\" column)";
				dataset.Tables[tableName].Columns["Droit_coupeID_PaiementManuel"].Caption = "PaiementManuel (update this label in the \"Olymars/ColumnLabel\" extended property of the \"PaiementManuel\" column)";
				dataset.Tables[tableName].Columns["Droit_coupeID_Journal"].Caption = "Journal (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Journal\" column)";
				dataset.Tables[tableName].Columns["Droit_coupeID_RecoitTPS"].Caption = "RecoitTPS (update this label in the \"Olymars/ColumnLabel\" extended property of the \"RecoitTPS\" column)";
				dataset.Tables[tableName].Columns["Droit_coupeID_RecoitTVQ"].Caption = "RecoitTVQ (update this label in the \"Olymars/ColumnLabel\" extended property of the \"RecoitTVQ\" column)";
				dataset.Tables[tableName].Columns["Droit_coupeID_ModifierTrigger"].Caption = "ModifierTrigger (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ModifierTrigger\" column)";
				dataset.Tables[tableName].Columns["Droit_coupeID_IsProducteur"].Caption = "IsProducteur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"IsProducteur\" column)";
				dataset.Tables[tableName].Columns["Droit_coupeID_IsTransporteur"].Caption = "IsTransporteur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"IsTransporteur\" column)";
				dataset.Tables[tableName].Columns["Droit_coupeID_IsChargeur"].Caption = "IsChargeur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"IsChargeur\" column)";
				dataset.Tables[tableName].Columns["Droit_coupeID_IsAutre"].Caption = "IsAutre (update this label in the \"Olymars/ColumnLabel\" extended property of the \"IsAutre\" column)";
				dataset.Tables[tableName].Columns["Droit_coupeID_AfficherCommentairesSurPermit"].Caption = "AfficherCommentairesSurPermit (update this label in the \"Olymars/ColumnLabel\" extended property of the \"AfficherCommentairesSurPermit\" column)";
				dataset.Tables[tableName].Columns["Droit_coupeID_PasEmissionPermis"].Caption = "PasEmissionPermis (update this label in the \"Olymars/ColumnLabel\" extended property of the \"PasEmissionPermis\" column)";
				dataset.Tables[tableName].Columns["Droit_coupeID_Generique"].Caption = "Generique (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Generique\" column)";
				dataset.Tables[tableName].Columns["Droit_coupeID_Membre_OGC"].Caption = "Membre_OGC (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Membre_OGC\" column)";
				dataset.Tables[tableName].Columns["Droit_coupeID_InscritTPS"].Caption = "InscritTPS (update this label in the \"Olymars/ColumnLabel\" extended property of the \"InscritTPS\" column)";
				dataset.Tables[tableName].Columns["Droit_coupeID_InscritTVQ"].Caption = "InscritTVQ (update this label in the \"Olymars/ColumnLabel\" extended property of the \"InscritTVQ\" column)";
				dataset.Tables[tableName].Columns["Entente_paiementID_ID"].Caption = "ID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ID\" column)";
				dataset.Tables[tableName].Columns["Entente_paiementID_CleTri"].Caption = "CleTri (update this label in the \"Olymars/ColumnLabel\" extended property of the \"CleTri\" column)";
				dataset.Tables[tableName].Columns["Entente_paiementID_Nom"].Caption = "Nom (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Nom\" column)";
				dataset.Tables[tableName].Columns["Entente_paiementID_AuSoinsDe"].Caption = "AuSoinsDe (update this label in the \"Olymars/ColumnLabel\" extended property of the \"AuSoinsDe\" column)";
				dataset.Tables[tableName].Columns["Entente_paiementID_Rue"].Caption = "Rue (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Rue\" column)";
				dataset.Tables[tableName].Columns["Entente_paiementID_Ville"].Caption = "Ville (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Ville\" column)";
				dataset.Tables[tableName].Columns["Entente_paiementID_PaysID"].Caption = "PaysID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"PaysID\" column)";
				dataset.Tables[tableName].Columns["Entente_paiementID_Code_postal"].Caption = "Code_postal (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Code_postal\" column)";
				dataset.Tables[tableName].Columns["Entente_paiementID_Telephone"].Caption = "Telephone (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone\" column)";
				dataset.Tables[tableName].Columns["Entente_paiementID_Telephone_Poste"].Caption = "Telephone_Poste (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone_Poste\" column)";
				dataset.Tables[tableName].Columns["Entente_paiementID_Telecopieur"].Caption = "Telecopieur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telecopieur\" column)";
				dataset.Tables[tableName].Columns["Entente_paiementID_Telephone2"].Caption = "Telephone2 (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone2\" column)";
				dataset.Tables[tableName].Columns["Entente_paiementID_Telephone2_Desc"].Caption = "Telephone2_Desc (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone2_Desc\" column)";
				dataset.Tables[tableName].Columns["Entente_paiementID_Telephone2_Poste"].Caption = "Telephone2_Poste (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone2_Poste\" column)";
				dataset.Tables[tableName].Columns["Entente_paiementID_Telephone3"].Caption = "Telephone3 (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone3\" column)";
				dataset.Tables[tableName].Columns["Entente_paiementID_Telephone3_Desc"].Caption = "Telephone3_Desc (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone3_Desc\" column)";
				dataset.Tables[tableName].Columns["Entente_paiementID_Telephone3_Poste"].Caption = "Telephone3_Poste (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone3_Poste\" column)";
				dataset.Tables[tableName].Columns["Entente_paiementID_No_membre"].Caption = "No_membre (update this label in the \"Olymars/ColumnLabel\" extended property of the \"No_membre\" column)";
				dataset.Tables[tableName].Columns["Entente_paiementID_Resident"].Caption = "Resident (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Resident\" column)";
				dataset.Tables[tableName].Columns["Entente_paiementID_Email"].Caption = "Email (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Email\" column)";
				dataset.Tables[tableName].Columns["Entente_paiementID_WWW"].Caption = "WWW (update this label in the \"Olymars/ColumnLabel\" extended property of the \"WWW\" column)";
				dataset.Tables[tableName].Columns["Entente_paiementID_Commentaires"].Caption = "Commentaires (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Commentaires\" column)";
				dataset.Tables[tableName].Columns["Entente_paiementID_AfficherCommentaires"].Caption = "AfficherCommentaires (update this label in the \"Olymars/ColumnLabel\" extended property of the \"AfficherCommentaires\" column)";
				dataset.Tables[tableName].Columns["Entente_paiementID_DepotDirect"].Caption = "DepotDirect (update this label in the \"Olymars/ColumnLabel\" extended property of the \"DepotDirect\" column)";
				dataset.Tables[tableName].Columns["Entente_paiementID_InstitutionBanquaireID"].Caption = "InstitutionBanquaireID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"InstitutionBanquaireID\" column)";
				dataset.Tables[tableName].Columns["Entente_paiementID_Banque_transit"].Caption = "Banque_transit (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Banque_transit\" column)";
				dataset.Tables[tableName].Columns["Entente_paiementID_Banque_folio"].Caption = "Banque_folio (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Banque_folio\" column)";
				dataset.Tables[tableName].Columns["Entente_paiementID_No_TPS"].Caption = "No_TPS (update this label in the \"Olymars/ColumnLabel\" extended property of the \"No_TPS\" column)";
				dataset.Tables[tableName].Columns["Entente_paiementID_No_TVQ"].Caption = "No_TVQ (update this label in the \"Olymars/ColumnLabel\" extended property of the \"No_TVQ\" column)";
				dataset.Tables[tableName].Columns["Entente_paiementID_PayerA"].Caption = "PayerA (update this label in the \"Olymars/ColumnLabel\" extended property of the \"PayerA\" column)";
				dataset.Tables[tableName].Columns["Entente_paiementID_PayerAID"].Caption = "PayerAID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"PayerAID\" column)";
				dataset.Tables[tableName].Columns["Entente_paiementID_Statut"].Caption = "Statut (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Statut\" column)";
				dataset.Tables[tableName].Columns["Entente_paiementID_Rep_Nom"].Caption = "Rep_Nom (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Rep_Nom\" column)";
				dataset.Tables[tableName].Columns["Entente_paiementID_Rep_Telephone"].Caption = "Rep_Telephone (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Rep_Telephone\" column)";
				dataset.Tables[tableName].Columns["Entente_paiementID_Rep_Telephone_Poste"].Caption = "Rep_Telephone_Poste (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Rep_Telephone_Poste\" column)";
				dataset.Tables[tableName].Columns["Entente_paiementID_Rep_Email"].Caption = "Rep_Email (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Rep_Email\" column)";
				dataset.Tables[tableName].Columns["Entente_paiementID_EnAnglais"].Caption = "EnAnglais (update this label in the \"Olymars/ColumnLabel\" extended property of the \"EnAnglais\" column)";
				dataset.Tables[tableName].Columns["Entente_paiementID_Actif"].Caption = "Actif (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Actif\" column)";
				dataset.Tables[tableName].Columns["Entente_paiementID_MRCProducteurID"].Caption = "MRCProducteurID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"MRCProducteurID\" column)";
				dataset.Tables[tableName].Columns["Entente_paiementID_PaiementManuel"].Caption = "PaiementManuel (update this label in the \"Olymars/ColumnLabel\" extended property of the \"PaiementManuel\" column)";
				dataset.Tables[tableName].Columns["Entente_paiementID_Journal"].Caption = "Journal (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Journal\" column)";
				dataset.Tables[tableName].Columns["Entente_paiementID_RecoitTPS"].Caption = "RecoitTPS (update this label in the \"Olymars/ColumnLabel\" extended property of the \"RecoitTPS\" column)";
				dataset.Tables[tableName].Columns["Entente_paiementID_RecoitTVQ"].Caption = "RecoitTVQ (update this label in the \"Olymars/ColumnLabel\" extended property of the \"RecoitTVQ\" column)";
				dataset.Tables[tableName].Columns["Entente_paiementID_ModifierTrigger"].Caption = "ModifierTrigger (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ModifierTrigger\" column)";
				dataset.Tables[tableName].Columns["Entente_paiementID_IsProducteur"].Caption = "IsProducteur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"IsProducteur\" column)";
				dataset.Tables[tableName].Columns["Entente_paiementID_IsTransporteur"].Caption = "IsTransporteur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"IsTransporteur\" column)";
				dataset.Tables[tableName].Columns["Entente_paiementID_IsChargeur"].Caption = "IsChargeur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"IsChargeur\" column)";
				dataset.Tables[tableName].Columns["Entente_paiementID_IsAutre"].Caption = "IsAutre (update this label in the \"Olymars/ColumnLabel\" extended property of the \"IsAutre\" column)";
				dataset.Tables[tableName].Columns["Entente_paiementID_AfficherCommentairesSurPermit"].Caption = "AfficherCommentairesSurPermit (update this label in the \"Olymars/ColumnLabel\" extended property of the \"AfficherCommentairesSurPermit\" column)";
				dataset.Tables[tableName].Columns["Entente_paiementID_PasEmissionPermis"].Caption = "PasEmissionPermis (update this label in the \"Olymars/ColumnLabel\" extended property of the \"PasEmissionPermis\" column)";
				dataset.Tables[tableName].Columns["Entente_paiementID_Generique"].Caption = "Generique (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Generique\" column)";
				dataset.Tables[tableName].Columns["Entente_paiementID_Membre_OGC"].Caption = "Membre_OGC (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Membre_OGC\" column)";
				dataset.Tables[tableName].Columns["Entente_paiementID_InscritTPS"].Caption = "InscritTPS (update this label in the \"Olymars/ColumnLabel\" extended property of the \"InscritTPS\" column)";
				dataset.Tables[tableName].Columns["Entente_paiementID_InscritTVQ"].Caption = "InscritTVQ (update this label in the \"Olymars/ColumnLabel\" extended property of the \"InscritTVQ\" column)";
				dataset.Tables[tableName].Columns["ZoneID_ID"].Caption = "ID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ID\" column)";
				dataset.Tables[tableName].Columns["ZoneID_MunicipaliteID"].Caption = "MunicipaliteID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"MunicipaliteID\" column)";
				dataset.Tables[tableName].Columns["ZoneID_Description"].Caption = "Description (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Description\" column)";
				dataset.Tables[tableName].Columns["ZoneID_Actif"].Caption = "Actif (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Actif\" column)";

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
		/// This method allows you to execute the [spS_Lot_Full] stored procedure and retrieve back the data
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
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.spS_Lot_Full parameters, ref string xml) {

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
		/// This method allows you to execute the [spS_Lot_Full] stored procedure and retrieve back the data
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
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.spS_Lot_Full parameters, out System.Xml.XmlReader xmlReader) {

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
		/// the Execute method of the 'spS_Lot_Full' class.
		/// </summary>
		public sealed class Resultset1 {


			/// <summary>
			/// This collection provides the fields collection for this resultset.
			/// </summary>
			public sealed class Fields {

				/// <summary>
				/// Allows to get the Index and Name of the field CantonID via shared members
				/// </summary>
				public sealed class Column_CantonID {

					/// <summary>
					/// Returns "CantonID"
					/// </summary>
					public const System.String ColumnName = "CantonID";
					/// <summary>
					/// Returns 0
					/// </summary>
					public const System.Int32 ColumnIndex = 0;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Rang via shared members
				/// </summary>
				public sealed class Column_Rang {

					/// <summary>
					/// Returns "Rang"
					/// </summary>
					public const System.String ColumnName = "Rang";
					/// <summary>
					/// Returns 1
					/// </summary>
					public const System.Int32 ColumnIndex = 1;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Lot via shared members
				/// </summary>
				public sealed class Column_Lot {

					/// <summary>
					/// Returns "Lot"
					/// </summary>
					public const System.String ColumnName = "Lot";
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
				/// Allows to get the Index and Name of the field Superficie_total via shared members
				/// </summary>
				public sealed class Column_Superficie_total {

					/// <summary>
					/// Returns "Superficie_total"
					/// </summary>
					public const System.String ColumnName = "Superficie_total";
					/// <summary>
					/// Returns 4
					/// </summary>
					public const System.Int32 ColumnIndex = 4;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Superficie_boisee via shared members
				/// </summary>
				public sealed class Column_Superficie_boisee {

					/// <summary>
					/// Returns "Superficie_boisee"
					/// </summary>
					public const System.String ColumnName = "Superficie_boisee";
					/// <summary>
					/// Returns 5
					/// </summary>
					public const System.Int32 ColumnIndex = 5;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProprietaireID via shared members
				/// </summary>
				public sealed class Column_ProprietaireID {

					/// <summary>
					/// Returns "ProprietaireID"
					/// </summary>
					public const System.String ColumnName = "ProprietaireID";
					/// <summary>
					/// Returns 6
					/// </summary>
					public const System.Int32 ColumnIndex = 6;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ContingentID via shared members
				/// </summary>
				public sealed class Column_ContingentID {

					/// <summary>
					/// Returns "ContingentID"
					/// </summary>
					public const System.String ColumnName = "ContingentID";
					/// <summary>
					/// Returns 7
					/// </summary>
					public const System.Int32 ColumnIndex = 7;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Contingent_Date via shared members
				/// </summary>
				public sealed class Column_Contingent_Date {

					/// <summary>
					/// Returns "Contingent_Date"
					/// </summary>
					public const System.String ColumnName = "Contingent_Date";
					/// <summary>
					/// Returns 8
					/// </summary>
					public const System.Int32 ColumnIndex = 8;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Droit_coupeID via shared members
				/// </summary>
				public sealed class Column_Droit_coupeID {

					/// <summary>
					/// Returns "Droit_coupeID"
					/// </summary>
					public const System.String ColumnName = "Droit_coupeID";
					/// <summary>
					/// Returns 9
					/// </summary>
					public const System.Int32 ColumnIndex = 9;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Droit_coupe_Date via shared members
				/// </summary>
				public sealed class Column_Droit_coupe_Date {

					/// <summary>
					/// Returns "Droit_coupe_Date"
					/// </summary>
					public const System.String ColumnName = "Droit_coupe_Date";
					/// <summary>
					/// Returns 10
					/// </summary>
					public const System.Int32 ColumnIndex = 10;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Entente_paiementID via shared members
				/// </summary>
				public sealed class Column_Entente_paiementID {

					/// <summary>
					/// Returns "Entente_paiementID"
					/// </summary>
					public const System.String ColumnName = "Entente_paiementID";
					/// <summary>
					/// Returns 11
					/// </summary>
					public const System.Int32 ColumnIndex = 11;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Entente_paiement_Date via shared members
				/// </summary>
				public sealed class Column_Entente_paiement_Date {

					/// <summary>
					/// Returns "Entente_paiement_Date"
					/// </summary>
					public const System.String ColumnName = "Entente_paiement_Date";
					/// <summary>
					/// Returns 12
					/// </summary>
					public const System.Int32 ColumnIndex = 12;

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
					/// Returns 13
					/// </summary>
					public const System.Int32 ColumnIndex = 13;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ID via shared members
				/// </summary>
				public sealed class Column_ID {

					/// <summary>
					/// Returns "ID"
					/// </summary>
					public const System.String ColumnName = "ID";
					/// <summary>
					/// Returns 14
					/// </summary>
					public const System.Int32 ColumnIndex = 14;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Sequence via shared members
				/// </summary>
				public sealed class Column_Sequence {

					/// <summary>
					/// Returns "Sequence"
					/// </summary>
					public const System.String ColumnName = "Sequence";
					/// <summary>
					/// Returns 15
					/// </summary>
					public const System.Int32 ColumnIndex = 15;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Partie via shared members
				/// </summary>
				public sealed class Column_Partie {

					/// <summary>
					/// Returns "Partie"
					/// </summary>
					public const System.String ColumnName = "Partie";
					/// <summary>
					/// Returns 16
					/// </summary>
					public const System.Int32 ColumnIndex = 16;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Matricule via shared members
				/// </summary>
				public sealed class Column_Matricule {

					/// <summary>
					/// Returns "Matricule"
					/// </summary>
					public const System.String ColumnName = "Matricule";
					/// <summary>
					/// Returns 17
					/// </summary>
					public const System.Int32 ColumnIndex = 17;

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
					/// Returns 18
					/// </summary>
					public const System.Int32 ColumnIndex = 18;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Secteur via shared members
				/// </summary>
				public sealed class Column_Secteur {

					/// <summary>
					/// Returns "Secteur"
					/// </summary>
					public const System.String ColumnName = "Secteur";
					/// <summary>
					/// Returns 19
					/// </summary>
					public const System.Int32 ColumnIndex = 19;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Cadastre via shared members
				/// </summary>
				public sealed class Column_Cadastre {

					/// <summary>
					/// Returns "Cadastre"
					/// </summary>
					public const System.String ColumnName = "Cadastre";
					/// <summary>
					/// Returns 20
					/// </summary>
					public const System.Int32 ColumnIndex = 20;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Reforme via shared members
				/// </summary>
				public sealed class Column_Reforme {

					/// <summary>
					/// Returns "Reforme"
					/// </summary>
					public const System.String ColumnName = "Reforme";
					/// <summary>
					/// Returns 21
					/// </summary>
					public const System.Int32 ColumnIndex = 21;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LotsComplementaires via shared members
				/// </summary>
				public sealed class Column_LotsComplementaires {

					/// <summary>
					/// Returns "LotsComplementaires"
					/// </summary>
					public const System.String ColumnName = "LotsComplementaires";
					/// <summary>
					/// Returns 22
					/// </summary>
					public const System.Int32 ColumnIndex = 22;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Certifie via shared members
				/// </summary>
				public sealed class Column_Certifie {

					/// <summary>
					/// Returns "Certifie"
					/// </summary>
					public const System.String ColumnName = "Certifie";
					/// <summary>
					/// Returns 23
					/// </summary>
					public const System.Int32 ColumnIndex = 23;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field NumeroCertification via shared members
				/// </summary>
				public sealed class Column_NumeroCertification {

					/// <summary>
					/// Returns "NumeroCertification"
					/// </summary>
					public const System.String ColumnName = "NumeroCertification";
					/// <summary>
					/// Returns 24
					/// </summary>
					public const System.Int32 ColumnIndex = 24;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field OGC via shared members
				/// </summary>
				public sealed class Column_OGC {

					/// <summary>
					/// Returns "OGC"
					/// </summary>
					public const System.String ColumnName = "OGC";
					/// <summary>
					/// Returns 25
					/// </summary>
					public const System.Int32 ColumnIndex = 25;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field CantonID_ID via shared members
				/// </summary>
				public sealed class Column_CantonID_ID {

					/// <summary>
					/// Returns "CantonID_ID"
					/// </summary>
					public const System.String ColumnName = "CantonID_ID";
					/// <summary>
					/// Returns 26
					/// </summary>
					public const System.Int32 ColumnIndex = 26;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field CantonID_Description via shared members
				/// </summary>
				public sealed class Column_CantonID_Description {

					/// <summary>
					/// Returns "CantonID_Description"
					/// </summary>
					public const System.String ColumnName = "CantonID_Description";
					/// <summary>
					/// Returns 27
					/// </summary>
					public const System.Int32 ColumnIndex = 27;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field CantonID_Actif via shared members
				/// </summary>
				public sealed class Column_CantonID_Actif {

					/// <summary>
					/// Returns "CantonID_Actif"
					/// </summary>
					public const System.String ColumnName = "CantonID_Actif";
					/// <summary>
					/// Returns 28
					/// </summary>
					public const System.Int32 ColumnIndex = 28;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field MunicipaliteID_ID via shared members
				/// </summary>
				public sealed class Column_MunicipaliteID_ID {

					/// <summary>
					/// Returns "MunicipaliteID_ID"
					/// </summary>
					public const System.String ColumnName = "MunicipaliteID_ID";
					/// <summary>
					/// Returns 29
					/// </summary>
					public const System.Int32 ColumnIndex = 29;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field MunicipaliteID_MunicipaliteID via shared members
				/// </summary>
				public sealed class Column_MunicipaliteID_MunicipaliteID {

					/// <summary>
					/// Returns "MunicipaliteID_MunicipaliteID"
					/// </summary>
					public const System.String ColumnName = "MunicipaliteID_MunicipaliteID";
					/// <summary>
					/// Returns 30
					/// </summary>
					public const System.Int32 ColumnIndex = 30;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field MunicipaliteID_Description via shared members
				/// </summary>
				public sealed class Column_MunicipaliteID_Description {

					/// <summary>
					/// Returns "MunicipaliteID_Description"
					/// </summary>
					public const System.String ColumnName = "MunicipaliteID_Description";
					/// <summary>
					/// Returns 31
					/// </summary>
					public const System.Int32 ColumnIndex = 31;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field MunicipaliteID_Actif via shared members
				/// </summary>
				public sealed class Column_MunicipaliteID_Actif {

					/// <summary>
					/// Returns "MunicipaliteID_Actif"
					/// </summary>
					public const System.String ColumnName = "MunicipaliteID_Actif";
					/// <summary>
					/// Returns 32
					/// </summary>
					public const System.Int32 ColumnIndex = 32;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProprietaireID_ID via shared members
				/// </summary>
				public sealed class Column_ProprietaireID_ID {

					/// <summary>
					/// Returns "ProprietaireID_ID"
					/// </summary>
					public const System.String ColumnName = "ProprietaireID_ID";
					/// <summary>
					/// Returns 33
					/// </summary>
					public const System.Int32 ColumnIndex = 33;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProprietaireID_CleTri via shared members
				/// </summary>
				public sealed class Column_ProprietaireID_CleTri {

					/// <summary>
					/// Returns "ProprietaireID_CleTri"
					/// </summary>
					public const System.String ColumnName = "ProprietaireID_CleTri";
					/// <summary>
					/// Returns 34
					/// </summary>
					public const System.Int32 ColumnIndex = 34;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProprietaireID_Nom via shared members
				/// </summary>
				public sealed class Column_ProprietaireID_Nom {

					/// <summary>
					/// Returns "ProprietaireID_Nom"
					/// </summary>
					public const System.String ColumnName = "ProprietaireID_Nom";
					/// <summary>
					/// Returns 35
					/// </summary>
					public const System.Int32 ColumnIndex = 35;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProprietaireID_AuSoinsDe via shared members
				/// </summary>
				public sealed class Column_ProprietaireID_AuSoinsDe {

					/// <summary>
					/// Returns "ProprietaireID_AuSoinsDe"
					/// </summary>
					public const System.String ColumnName = "ProprietaireID_AuSoinsDe";
					/// <summary>
					/// Returns 36
					/// </summary>
					public const System.Int32 ColumnIndex = 36;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProprietaireID_Rue via shared members
				/// </summary>
				public sealed class Column_ProprietaireID_Rue {

					/// <summary>
					/// Returns "ProprietaireID_Rue"
					/// </summary>
					public const System.String ColumnName = "ProprietaireID_Rue";
					/// <summary>
					/// Returns 37
					/// </summary>
					public const System.Int32 ColumnIndex = 37;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProprietaireID_Ville via shared members
				/// </summary>
				public sealed class Column_ProprietaireID_Ville {

					/// <summary>
					/// Returns "ProprietaireID_Ville"
					/// </summary>
					public const System.String ColumnName = "ProprietaireID_Ville";
					/// <summary>
					/// Returns 38
					/// </summary>
					public const System.Int32 ColumnIndex = 38;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProprietaireID_PaysID via shared members
				/// </summary>
				public sealed class Column_ProprietaireID_PaysID {

					/// <summary>
					/// Returns "ProprietaireID_PaysID"
					/// </summary>
					public const System.String ColumnName = "ProprietaireID_PaysID";
					/// <summary>
					/// Returns 39
					/// </summary>
					public const System.Int32 ColumnIndex = 39;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProprietaireID_Code_postal via shared members
				/// </summary>
				public sealed class Column_ProprietaireID_Code_postal {

					/// <summary>
					/// Returns "ProprietaireID_Code_postal"
					/// </summary>
					public const System.String ColumnName = "ProprietaireID_Code_postal";
					/// <summary>
					/// Returns 40
					/// </summary>
					public const System.Int32 ColumnIndex = 40;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProprietaireID_Telephone via shared members
				/// </summary>
				public sealed class Column_ProprietaireID_Telephone {

					/// <summary>
					/// Returns "ProprietaireID_Telephone"
					/// </summary>
					public const System.String ColumnName = "ProprietaireID_Telephone";
					/// <summary>
					/// Returns 41
					/// </summary>
					public const System.Int32 ColumnIndex = 41;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProprietaireID_Telephone_Poste via shared members
				/// </summary>
				public sealed class Column_ProprietaireID_Telephone_Poste {

					/// <summary>
					/// Returns "ProprietaireID_Telephone_Poste"
					/// </summary>
					public const System.String ColumnName = "ProprietaireID_Telephone_Poste";
					/// <summary>
					/// Returns 42
					/// </summary>
					public const System.Int32 ColumnIndex = 42;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProprietaireID_Telecopieur via shared members
				/// </summary>
				public sealed class Column_ProprietaireID_Telecopieur {

					/// <summary>
					/// Returns "ProprietaireID_Telecopieur"
					/// </summary>
					public const System.String ColumnName = "ProprietaireID_Telecopieur";
					/// <summary>
					/// Returns 43
					/// </summary>
					public const System.Int32 ColumnIndex = 43;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProprietaireID_Telephone2 via shared members
				/// </summary>
				public sealed class Column_ProprietaireID_Telephone2 {

					/// <summary>
					/// Returns "ProprietaireID_Telephone2"
					/// </summary>
					public const System.String ColumnName = "ProprietaireID_Telephone2";
					/// <summary>
					/// Returns 44
					/// </summary>
					public const System.Int32 ColumnIndex = 44;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProprietaireID_Telephone2_Desc via shared members
				/// </summary>
				public sealed class Column_ProprietaireID_Telephone2_Desc {

					/// <summary>
					/// Returns "ProprietaireID_Telephone2_Desc"
					/// </summary>
					public const System.String ColumnName = "ProprietaireID_Telephone2_Desc";
					/// <summary>
					/// Returns 45
					/// </summary>
					public const System.Int32 ColumnIndex = 45;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProprietaireID_Telephone2_Poste via shared members
				/// </summary>
				public sealed class Column_ProprietaireID_Telephone2_Poste {

					/// <summary>
					/// Returns "ProprietaireID_Telephone2_Poste"
					/// </summary>
					public const System.String ColumnName = "ProprietaireID_Telephone2_Poste";
					/// <summary>
					/// Returns 46
					/// </summary>
					public const System.Int32 ColumnIndex = 46;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProprietaireID_Telephone3 via shared members
				/// </summary>
				public sealed class Column_ProprietaireID_Telephone3 {

					/// <summary>
					/// Returns "ProprietaireID_Telephone3"
					/// </summary>
					public const System.String ColumnName = "ProprietaireID_Telephone3";
					/// <summary>
					/// Returns 47
					/// </summary>
					public const System.Int32 ColumnIndex = 47;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProprietaireID_Telephone3_Desc via shared members
				/// </summary>
				public sealed class Column_ProprietaireID_Telephone3_Desc {

					/// <summary>
					/// Returns "ProprietaireID_Telephone3_Desc"
					/// </summary>
					public const System.String ColumnName = "ProprietaireID_Telephone3_Desc";
					/// <summary>
					/// Returns 48
					/// </summary>
					public const System.Int32 ColumnIndex = 48;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProprietaireID_Telephone3_Poste via shared members
				/// </summary>
				public sealed class Column_ProprietaireID_Telephone3_Poste {

					/// <summary>
					/// Returns "ProprietaireID_Telephone3_Poste"
					/// </summary>
					public const System.String ColumnName = "ProprietaireID_Telephone3_Poste";
					/// <summary>
					/// Returns 49
					/// </summary>
					public const System.Int32 ColumnIndex = 49;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProprietaireID_No_membre via shared members
				/// </summary>
				public sealed class Column_ProprietaireID_No_membre {

					/// <summary>
					/// Returns "ProprietaireID_No_membre"
					/// </summary>
					public const System.String ColumnName = "ProprietaireID_No_membre";
					/// <summary>
					/// Returns 50
					/// </summary>
					public const System.Int32 ColumnIndex = 50;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProprietaireID_Resident via shared members
				/// </summary>
				public sealed class Column_ProprietaireID_Resident {

					/// <summary>
					/// Returns "ProprietaireID_Resident"
					/// </summary>
					public const System.String ColumnName = "ProprietaireID_Resident";
					/// <summary>
					/// Returns 51
					/// </summary>
					public const System.Int32 ColumnIndex = 51;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProprietaireID_Email via shared members
				/// </summary>
				public sealed class Column_ProprietaireID_Email {

					/// <summary>
					/// Returns "ProprietaireID_Email"
					/// </summary>
					public const System.String ColumnName = "ProprietaireID_Email";
					/// <summary>
					/// Returns 52
					/// </summary>
					public const System.Int32 ColumnIndex = 52;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProprietaireID_WWW via shared members
				/// </summary>
				public sealed class Column_ProprietaireID_WWW {

					/// <summary>
					/// Returns "ProprietaireID_WWW"
					/// </summary>
					public const System.String ColumnName = "ProprietaireID_WWW";
					/// <summary>
					/// Returns 53
					/// </summary>
					public const System.Int32 ColumnIndex = 53;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProprietaireID_Commentaires via shared members
				/// </summary>
				public sealed class Column_ProprietaireID_Commentaires {

					/// <summary>
					/// Returns "ProprietaireID_Commentaires"
					/// </summary>
					public const System.String ColumnName = "ProprietaireID_Commentaires";
					/// <summary>
					/// Returns 54
					/// </summary>
					public const System.Int32 ColumnIndex = 54;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProprietaireID_AfficherCommentaires via shared members
				/// </summary>
				public sealed class Column_ProprietaireID_AfficherCommentaires {

					/// <summary>
					/// Returns "ProprietaireID_AfficherCommentaires"
					/// </summary>
					public const System.String ColumnName = "ProprietaireID_AfficherCommentaires";
					/// <summary>
					/// Returns 55
					/// </summary>
					public const System.Int32 ColumnIndex = 55;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProprietaireID_DepotDirect via shared members
				/// </summary>
				public sealed class Column_ProprietaireID_DepotDirect {

					/// <summary>
					/// Returns "ProprietaireID_DepotDirect"
					/// </summary>
					public const System.String ColumnName = "ProprietaireID_DepotDirect";
					/// <summary>
					/// Returns 56
					/// </summary>
					public const System.Int32 ColumnIndex = 56;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProprietaireID_InstitutionBanquaireID via shared members
				/// </summary>
				public sealed class Column_ProprietaireID_InstitutionBanquaireID {

					/// <summary>
					/// Returns "ProprietaireID_InstitutionBanquaireID"
					/// </summary>
					public const System.String ColumnName = "ProprietaireID_InstitutionBanquaireID";
					/// <summary>
					/// Returns 57
					/// </summary>
					public const System.Int32 ColumnIndex = 57;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProprietaireID_Banque_transit via shared members
				/// </summary>
				public sealed class Column_ProprietaireID_Banque_transit {

					/// <summary>
					/// Returns "ProprietaireID_Banque_transit"
					/// </summary>
					public const System.String ColumnName = "ProprietaireID_Banque_transit";
					/// <summary>
					/// Returns 58
					/// </summary>
					public const System.Int32 ColumnIndex = 58;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProprietaireID_Banque_folio via shared members
				/// </summary>
				public sealed class Column_ProprietaireID_Banque_folio {

					/// <summary>
					/// Returns "ProprietaireID_Banque_folio"
					/// </summary>
					public const System.String ColumnName = "ProprietaireID_Banque_folio";
					/// <summary>
					/// Returns 59
					/// </summary>
					public const System.Int32 ColumnIndex = 59;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProprietaireID_No_TPS via shared members
				/// </summary>
				public sealed class Column_ProprietaireID_No_TPS {

					/// <summary>
					/// Returns "ProprietaireID_No_TPS"
					/// </summary>
					public const System.String ColumnName = "ProprietaireID_No_TPS";
					/// <summary>
					/// Returns 60
					/// </summary>
					public const System.Int32 ColumnIndex = 60;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProprietaireID_No_TVQ via shared members
				/// </summary>
				public sealed class Column_ProprietaireID_No_TVQ {

					/// <summary>
					/// Returns "ProprietaireID_No_TVQ"
					/// </summary>
					public const System.String ColumnName = "ProprietaireID_No_TVQ";
					/// <summary>
					/// Returns 61
					/// </summary>
					public const System.Int32 ColumnIndex = 61;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProprietaireID_PayerA via shared members
				/// </summary>
				public sealed class Column_ProprietaireID_PayerA {

					/// <summary>
					/// Returns "ProprietaireID_PayerA"
					/// </summary>
					public const System.String ColumnName = "ProprietaireID_PayerA";
					/// <summary>
					/// Returns 62
					/// </summary>
					public const System.Int32 ColumnIndex = 62;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProprietaireID_PayerAID via shared members
				/// </summary>
				public sealed class Column_ProprietaireID_PayerAID {

					/// <summary>
					/// Returns "ProprietaireID_PayerAID"
					/// </summary>
					public const System.String ColumnName = "ProprietaireID_PayerAID";
					/// <summary>
					/// Returns 63
					/// </summary>
					public const System.Int32 ColumnIndex = 63;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProprietaireID_Statut via shared members
				/// </summary>
				public sealed class Column_ProprietaireID_Statut {

					/// <summary>
					/// Returns "ProprietaireID_Statut"
					/// </summary>
					public const System.String ColumnName = "ProprietaireID_Statut";
					/// <summary>
					/// Returns 64
					/// </summary>
					public const System.Int32 ColumnIndex = 64;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProprietaireID_Rep_Nom via shared members
				/// </summary>
				public sealed class Column_ProprietaireID_Rep_Nom {

					/// <summary>
					/// Returns "ProprietaireID_Rep_Nom"
					/// </summary>
					public const System.String ColumnName = "ProprietaireID_Rep_Nom";
					/// <summary>
					/// Returns 65
					/// </summary>
					public const System.Int32 ColumnIndex = 65;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProprietaireID_Rep_Telephone via shared members
				/// </summary>
				public sealed class Column_ProprietaireID_Rep_Telephone {

					/// <summary>
					/// Returns "ProprietaireID_Rep_Telephone"
					/// </summary>
					public const System.String ColumnName = "ProprietaireID_Rep_Telephone";
					/// <summary>
					/// Returns 66
					/// </summary>
					public const System.Int32 ColumnIndex = 66;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProprietaireID_Rep_Telephone_Poste via shared members
				/// </summary>
				public sealed class Column_ProprietaireID_Rep_Telephone_Poste {

					/// <summary>
					/// Returns "ProprietaireID_Rep_Telephone_Poste"
					/// </summary>
					public const System.String ColumnName = "ProprietaireID_Rep_Telephone_Poste";
					/// <summary>
					/// Returns 67
					/// </summary>
					public const System.Int32 ColumnIndex = 67;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProprietaireID_Rep_Email via shared members
				/// </summary>
				public sealed class Column_ProprietaireID_Rep_Email {

					/// <summary>
					/// Returns "ProprietaireID_Rep_Email"
					/// </summary>
					public const System.String ColumnName = "ProprietaireID_Rep_Email";
					/// <summary>
					/// Returns 68
					/// </summary>
					public const System.Int32 ColumnIndex = 68;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProprietaireID_EnAnglais via shared members
				/// </summary>
				public sealed class Column_ProprietaireID_EnAnglais {

					/// <summary>
					/// Returns "ProprietaireID_EnAnglais"
					/// </summary>
					public const System.String ColumnName = "ProprietaireID_EnAnglais";
					/// <summary>
					/// Returns 69
					/// </summary>
					public const System.Int32 ColumnIndex = 69;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProprietaireID_Actif via shared members
				/// </summary>
				public sealed class Column_ProprietaireID_Actif {

					/// <summary>
					/// Returns "ProprietaireID_Actif"
					/// </summary>
					public const System.String ColumnName = "ProprietaireID_Actif";
					/// <summary>
					/// Returns 70
					/// </summary>
					public const System.Int32 ColumnIndex = 70;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProprietaireID_MRCProducteurID via shared members
				/// </summary>
				public sealed class Column_ProprietaireID_MRCProducteurID {

					/// <summary>
					/// Returns "ProprietaireID_MRCProducteurID"
					/// </summary>
					public const System.String ColumnName = "ProprietaireID_MRCProducteurID";
					/// <summary>
					/// Returns 71
					/// </summary>
					public const System.Int32 ColumnIndex = 71;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProprietaireID_PaiementManuel via shared members
				/// </summary>
				public sealed class Column_ProprietaireID_PaiementManuel {

					/// <summary>
					/// Returns "ProprietaireID_PaiementManuel"
					/// </summary>
					public const System.String ColumnName = "ProprietaireID_PaiementManuel";
					/// <summary>
					/// Returns 72
					/// </summary>
					public const System.Int32 ColumnIndex = 72;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProprietaireID_Journal via shared members
				/// </summary>
				public sealed class Column_ProprietaireID_Journal {

					/// <summary>
					/// Returns "ProprietaireID_Journal"
					/// </summary>
					public const System.String ColumnName = "ProprietaireID_Journal";
					/// <summary>
					/// Returns 73
					/// </summary>
					public const System.Int32 ColumnIndex = 73;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProprietaireID_RecoitTPS via shared members
				/// </summary>
				public sealed class Column_ProprietaireID_RecoitTPS {

					/// <summary>
					/// Returns "ProprietaireID_RecoitTPS"
					/// </summary>
					public const System.String ColumnName = "ProprietaireID_RecoitTPS";
					/// <summary>
					/// Returns 74
					/// </summary>
					public const System.Int32 ColumnIndex = 74;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProprietaireID_RecoitTVQ via shared members
				/// </summary>
				public sealed class Column_ProprietaireID_RecoitTVQ {

					/// <summary>
					/// Returns "ProprietaireID_RecoitTVQ"
					/// </summary>
					public const System.String ColumnName = "ProprietaireID_RecoitTVQ";
					/// <summary>
					/// Returns 75
					/// </summary>
					public const System.Int32 ColumnIndex = 75;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProprietaireID_ModifierTrigger via shared members
				/// </summary>
				public sealed class Column_ProprietaireID_ModifierTrigger {

					/// <summary>
					/// Returns "ProprietaireID_ModifierTrigger"
					/// </summary>
					public const System.String ColumnName = "ProprietaireID_ModifierTrigger";
					/// <summary>
					/// Returns 76
					/// </summary>
					public const System.Int32 ColumnIndex = 76;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProprietaireID_IsProducteur via shared members
				/// </summary>
				public sealed class Column_ProprietaireID_IsProducteur {

					/// <summary>
					/// Returns "ProprietaireID_IsProducteur"
					/// </summary>
					public const System.String ColumnName = "ProprietaireID_IsProducteur";
					/// <summary>
					/// Returns 77
					/// </summary>
					public const System.Int32 ColumnIndex = 77;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProprietaireID_IsTransporteur via shared members
				/// </summary>
				public sealed class Column_ProprietaireID_IsTransporteur {

					/// <summary>
					/// Returns "ProprietaireID_IsTransporteur"
					/// </summary>
					public const System.String ColumnName = "ProprietaireID_IsTransporteur";
					/// <summary>
					/// Returns 78
					/// </summary>
					public const System.Int32 ColumnIndex = 78;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProprietaireID_IsChargeur via shared members
				/// </summary>
				public sealed class Column_ProprietaireID_IsChargeur {

					/// <summary>
					/// Returns "ProprietaireID_IsChargeur"
					/// </summary>
					public const System.String ColumnName = "ProprietaireID_IsChargeur";
					/// <summary>
					/// Returns 79
					/// </summary>
					public const System.Int32 ColumnIndex = 79;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProprietaireID_IsAutre via shared members
				/// </summary>
				public sealed class Column_ProprietaireID_IsAutre {

					/// <summary>
					/// Returns "ProprietaireID_IsAutre"
					/// </summary>
					public const System.String ColumnName = "ProprietaireID_IsAutre";
					/// <summary>
					/// Returns 80
					/// </summary>
					public const System.Int32 ColumnIndex = 80;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProprietaireID_AfficherCommentairesSurPermit via shared members
				/// </summary>
				public sealed class Column_ProprietaireID_AfficherCommentairesSurPermit {

					/// <summary>
					/// Returns "ProprietaireID_AfficherCommentairesSurPermit"
					/// </summary>
					public const System.String ColumnName = "ProprietaireID_AfficherCommentairesSurPermit";
					/// <summary>
					/// Returns 81
					/// </summary>
					public const System.Int32 ColumnIndex = 81;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProprietaireID_PasEmissionPermis via shared members
				/// </summary>
				public sealed class Column_ProprietaireID_PasEmissionPermis {

					/// <summary>
					/// Returns "ProprietaireID_PasEmissionPermis"
					/// </summary>
					public const System.String ColumnName = "ProprietaireID_PasEmissionPermis";
					/// <summary>
					/// Returns 82
					/// </summary>
					public const System.Int32 ColumnIndex = 82;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProprietaireID_Generique via shared members
				/// </summary>
				public sealed class Column_ProprietaireID_Generique {

					/// <summary>
					/// Returns "ProprietaireID_Generique"
					/// </summary>
					public const System.String ColumnName = "ProprietaireID_Generique";
					/// <summary>
					/// Returns 83
					/// </summary>
					public const System.Int32 ColumnIndex = 83;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProprietaireID_Membre_OGC via shared members
				/// </summary>
				public sealed class Column_ProprietaireID_Membre_OGC {

					/// <summary>
					/// Returns "ProprietaireID_Membre_OGC"
					/// </summary>
					public const System.String ColumnName = "ProprietaireID_Membre_OGC";
					/// <summary>
					/// Returns 84
					/// </summary>
					public const System.Int32 ColumnIndex = 84;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProprietaireID_InscritTPS via shared members
				/// </summary>
				public sealed class Column_ProprietaireID_InscritTPS {

					/// <summary>
					/// Returns "ProprietaireID_InscritTPS"
					/// </summary>
					public const System.String ColumnName = "ProprietaireID_InscritTPS";
					/// <summary>
					/// Returns 85
					/// </summary>
					public const System.Int32 ColumnIndex = 85;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProprietaireID_InscritTVQ via shared members
				/// </summary>
				public sealed class Column_ProprietaireID_InscritTVQ {

					/// <summary>
					/// Returns "ProprietaireID_InscritTVQ"
					/// </summary>
					public const System.String ColumnName = "ProprietaireID_InscritTVQ";
					/// <summary>
					/// Returns 86
					/// </summary>
					public const System.Int32 ColumnIndex = 86;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ContingentID_ID via shared members
				/// </summary>
				public sealed class Column_ContingentID_ID {

					/// <summary>
					/// Returns "ContingentID_ID"
					/// </summary>
					public const System.String ColumnName = "ContingentID_ID";
					/// <summary>
					/// Returns 87
					/// </summary>
					public const System.Int32 ColumnIndex = 87;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ContingentID_CleTri via shared members
				/// </summary>
				public sealed class Column_ContingentID_CleTri {

					/// <summary>
					/// Returns "ContingentID_CleTri"
					/// </summary>
					public const System.String ColumnName = "ContingentID_CleTri";
					/// <summary>
					/// Returns 88
					/// </summary>
					public const System.Int32 ColumnIndex = 88;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ContingentID_Nom via shared members
				/// </summary>
				public sealed class Column_ContingentID_Nom {

					/// <summary>
					/// Returns "ContingentID_Nom"
					/// </summary>
					public const System.String ColumnName = "ContingentID_Nom";
					/// <summary>
					/// Returns 89
					/// </summary>
					public const System.Int32 ColumnIndex = 89;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ContingentID_AuSoinsDe via shared members
				/// </summary>
				public sealed class Column_ContingentID_AuSoinsDe {

					/// <summary>
					/// Returns "ContingentID_AuSoinsDe"
					/// </summary>
					public const System.String ColumnName = "ContingentID_AuSoinsDe";
					/// <summary>
					/// Returns 90
					/// </summary>
					public const System.Int32 ColumnIndex = 90;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ContingentID_Rue via shared members
				/// </summary>
				public sealed class Column_ContingentID_Rue {

					/// <summary>
					/// Returns "ContingentID_Rue"
					/// </summary>
					public const System.String ColumnName = "ContingentID_Rue";
					/// <summary>
					/// Returns 91
					/// </summary>
					public const System.Int32 ColumnIndex = 91;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ContingentID_Ville via shared members
				/// </summary>
				public sealed class Column_ContingentID_Ville {

					/// <summary>
					/// Returns "ContingentID_Ville"
					/// </summary>
					public const System.String ColumnName = "ContingentID_Ville";
					/// <summary>
					/// Returns 92
					/// </summary>
					public const System.Int32 ColumnIndex = 92;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ContingentID_PaysID via shared members
				/// </summary>
				public sealed class Column_ContingentID_PaysID {

					/// <summary>
					/// Returns "ContingentID_PaysID"
					/// </summary>
					public const System.String ColumnName = "ContingentID_PaysID";
					/// <summary>
					/// Returns 93
					/// </summary>
					public const System.Int32 ColumnIndex = 93;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ContingentID_Code_postal via shared members
				/// </summary>
				public sealed class Column_ContingentID_Code_postal {

					/// <summary>
					/// Returns "ContingentID_Code_postal"
					/// </summary>
					public const System.String ColumnName = "ContingentID_Code_postal";
					/// <summary>
					/// Returns 94
					/// </summary>
					public const System.Int32 ColumnIndex = 94;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ContingentID_Telephone via shared members
				/// </summary>
				public sealed class Column_ContingentID_Telephone {

					/// <summary>
					/// Returns "ContingentID_Telephone"
					/// </summary>
					public const System.String ColumnName = "ContingentID_Telephone";
					/// <summary>
					/// Returns 95
					/// </summary>
					public const System.Int32 ColumnIndex = 95;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ContingentID_Telephone_Poste via shared members
				/// </summary>
				public sealed class Column_ContingentID_Telephone_Poste {

					/// <summary>
					/// Returns "ContingentID_Telephone_Poste"
					/// </summary>
					public const System.String ColumnName = "ContingentID_Telephone_Poste";
					/// <summary>
					/// Returns 96
					/// </summary>
					public const System.Int32 ColumnIndex = 96;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ContingentID_Telecopieur via shared members
				/// </summary>
				public sealed class Column_ContingentID_Telecopieur {

					/// <summary>
					/// Returns "ContingentID_Telecopieur"
					/// </summary>
					public const System.String ColumnName = "ContingentID_Telecopieur";
					/// <summary>
					/// Returns 97
					/// </summary>
					public const System.Int32 ColumnIndex = 97;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ContingentID_Telephone2 via shared members
				/// </summary>
				public sealed class Column_ContingentID_Telephone2 {

					/// <summary>
					/// Returns "ContingentID_Telephone2"
					/// </summary>
					public const System.String ColumnName = "ContingentID_Telephone2";
					/// <summary>
					/// Returns 98
					/// </summary>
					public const System.Int32 ColumnIndex = 98;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ContingentID_Telephone2_Desc via shared members
				/// </summary>
				public sealed class Column_ContingentID_Telephone2_Desc {

					/// <summary>
					/// Returns "ContingentID_Telephone2_Desc"
					/// </summary>
					public const System.String ColumnName = "ContingentID_Telephone2_Desc";
					/// <summary>
					/// Returns 99
					/// </summary>
					public const System.Int32 ColumnIndex = 99;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ContingentID_Telephone2_Poste via shared members
				/// </summary>
				public sealed class Column_ContingentID_Telephone2_Poste {

					/// <summary>
					/// Returns "ContingentID_Telephone2_Poste"
					/// </summary>
					public const System.String ColumnName = "ContingentID_Telephone2_Poste";
					/// <summary>
					/// Returns 100
					/// </summary>
					public const System.Int32 ColumnIndex = 100;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ContingentID_Telephone3 via shared members
				/// </summary>
				public sealed class Column_ContingentID_Telephone3 {

					/// <summary>
					/// Returns "ContingentID_Telephone3"
					/// </summary>
					public const System.String ColumnName = "ContingentID_Telephone3";
					/// <summary>
					/// Returns 101
					/// </summary>
					public const System.Int32 ColumnIndex = 101;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ContingentID_Telephone3_Desc via shared members
				/// </summary>
				public sealed class Column_ContingentID_Telephone3_Desc {

					/// <summary>
					/// Returns "ContingentID_Telephone3_Desc"
					/// </summary>
					public const System.String ColumnName = "ContingentID_Telephone3_Desc";
					/// <summary>
					/// Returns 102
					/// </summary>
					public const System.Int32 ColumnIndex = 102;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ContingentID_Telephone3_Poste via shared members
				/// </summary>
				public sealed class Column_ContingentID_Telephone3_Poste {

					/// <summary>
					/// Returns "ContingentID_Telephone3_Poste"
					/// </summary>
					public const System.String ColumnName = "ContingentID_Telephone3_Poste";
					/// <summary>
					/// Returns 103
					/// </summary>
					public const System.Int32 ColumnIndex = 103;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ContingentID_No_membre via shared members
				/// </summary>
				public sealed class Column_ContingentID_No_membre {

					/// <summary>
					/// Returns "ContingentID_No_membre"
					/// </summary>
					public const System.String ColumnName = "ContingentID_No_membre";
					/// <summary>
					/// Returns 104
					/// </summary>
					public const System.Int32 ColumnIndex = 104;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ContingentID_Resident via shared members
				/// </summary>
				public sealed class Column_ContingentID_Resident {

					/// <summary>
					/// Returns "ContingentID_Resident"
					/// </summary>
					public const System.String ColumnName = "ContingentID_Resident";
					/// <summary>
					/// Returns 105
					/// </summary>
					public const System.Int32 ColumnIndex = 105;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ContingentID_Email via shared members
				/// </summary>
				public sealed class Column_ContingentID_Email {

					/// <summary>
					/// Returns "ContingentID_Email"
					/// </summary>
					public const System.String ColumnName = "ContingentID_Email";
					/// <summary>
					/// Returns 106
					/// </summary>
					public const System.Int32 ColumnIndex = 106;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ContingentID_WWW via shared members
				/// </summary>
				public sealed class Column_ContingentID_WWW {

					/// <summary>
					/// Returns "ContingentID_WWW"
					/// </summary>
					public const System.String ColumnName = "ContingentID_WWW";
					/// <summary>
					/// Returns 107
					/// </summary>
					public const System.Int32 ColumnIndex = 107;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ContingentID_Commentaires via shared members
				/// </summary>
				public sealed class Column_ContingentID_Commentaires {

					/// <summary>
					/// Returns "ContingentID_Commentaires"
					/// </summary>
					public const System.String ColumnName = "ContingentID_Commentaires";
					/// <summary>
					/// Returns 108
					/// </summary>
					public const System.Int32 ColumnIndex = 108;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ContingentID_AfficherCommentaires via shared members
				/// </summary>
				public sealed class Column_ContingentID_AfficherCommentaires {

					/// <summary>
					/// Returns "ContingentID_AfficherCommentaires"
					/// </summary>
					public const System.String ColumnName = "ContingentID_AfficherCommentaires";
					/// <summary>
					/// Returns 109
					/// </summary>
					public const System.Int32 ColumnIndex = 109;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ContingentID_DepotDirect via shared members
				/// </summary>
				public sealed class Column_ContingentID_DepotDirect {

					/// <summary>
					/// Returns "ContingentID_DepotDirect"
					/// </summary>
					public const System.String ColumnName = "ContingentID_DepotDirect";
					/// <summary>
					/// Returns 110
					/// </summary>
					public const System.Int32 ColumnIndex = 110;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ContingentID_InstitutionBanquaireID via shared members
				/// </summary>
				public sealed class Column_ContingentID_InstitutionBanquaireID {

					/// <summary>
					/// Returns "ContingentID_InstitutionBanquaireID"
					/// </summary>
					public const System.String ColumnName = "ContingentID_InstitutionBanquaireID";
					/// <summary>
					/// Returns 111
					/// </summary>
					public const System.Int32 ColumnIndex = 111;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ContingentID_Banque_transit via shared members
				/// </summary>
				public sealed class Column_ContingentID_Banque_transit {

					/// <summary>
					/// Returns "ContingentID_Banque_transit"
					/// </summary>
					public const System.String ColumnName = "ContingentID_Banque_transit";
					/// <summary>
					/// Returns 112
					/// </summary>
					public const System.Int32 ColumnIndex = 112;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ContingentID_Banque_folio via shared members
				/// </summary>
				public sealed class Column_ContingentID_Banque_folio {

					/// <summary>
					/// Returns "ContingentID_Banque_folio"
					/// </summary>
					public const System.String ColumnName = "ContingentID_Banque_folio";
					/// <summary>
					/// Returns 113
					/// </summary>
					public const System.Int32 ColumnIndex = 113;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ContingentID_No_TPS via shared members
				/// </summary>
				public sealed class Column_ContingentID_No_TPS {

					/// <summary>
					/// Returns "ContingentID_No_TPS"
					/// </summary>
					public const System.String ColumnName = "ContingentID_No_TPS";
					/// <summary>
					/// Returns 114
					/// </summary>
					public const System.Int32 ColumnIndex = 114;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ContingentID_No_TVQ via shared members
				/// </summary>
				public sealed class Column_ContingentID_No_TVQ {

					/// <summary>
					/// Returns "ContingentID_No_TVQ"
					/// </summary>
					public const System.String ColumnName = "ContingentID_No_TVQ";
					/// <summary>
					/// Returns 115
					/// </summary>
					public const System.Int32 ColumnIndex = 115;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ContingentID_PayerA via shared members
				/// </summary>
				public sealed class Column_ContingentID_PayerA {

					/// <summary>
					/// Returns "ContingentID_PayerA"
					/// </summary>
					public const System.String ColumnName = "ContingentID_PayerA";
					/// <summary>
					/// Returns 116
					/// </summary>
					public const System.Int32 ColumnIndex = 116;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ContingentID_PayerAID via shared members
				/// </summary>
				public sealed class Column_ContingentID_PayerAID {

					/// <summary>
					/// Returns "ContingentID_PayerAID"
					/// </summary>
					public const System.String ColumnName = "ContingentID_PayerAID";
					/// <summary>
					/// Returns 117
					/// </summary>
					public const System.Int32 ColumnIndex = 117;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ContingentID_Statut via shared members
				/// </summary>
				public sealed class Column_ContingentID_Statut {

					/// <summary>
					/// Returns "ContingentID_Statut"
					/// </summary>
					public const System.String ColumnName = "ContingentID_Statut";
					/// <summary>
					/// Returns 118
					/// </summary>
					public const System.Int32 ColumnIndex = 118;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ContingentID_Rep_Nom via shared members
				/// </summary>
				public sealed class Column_ContingentID_Rep_Nom {

					/// <summary>
					/// Returns "ContingentID_Rep_Nom"
					/// </summary>
					public const System.String ColumnName = "ContingentID_Rep_Nom";
					/// <summary>
					/// Returns 119
					/// </summary>
					public const System.Int32 ColumnIndex = 119;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ContingentID_Rep_Telephone via shared members
				/// </summary>
				public sealed class Column_ContingentID_Rep_Telephone {

					/// <summary>
					/// Returns "ContingentID_Rep_Telephone"
					/// </summary>
					public const System.String ColumnName = "ContingentID_Rep_Telephone";
					/// <summary>
					/// Returns 120
					/// </summary>
					public const System.Int32 ColumnIndex = 120;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ContingentID_Rep_Telephone_Poste via shared members
				/// </summary>
				public sealed class Column_ContingentID_Rep_Telephone_Poste {

					/// <summary>
					/// Returns "ContingentID_Rep_Telephone_Poste"
					/// </summary>
					public const System.String ColumnName = "ContingentID_Rep_Telephone_Poste";
					/// <summary>
					/// Returns 121
					/// </summary>
					public const System.Int32 ColumnIndex = 121;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ContingentID_Rep_Email via shared members
				/// </summary>
				public sealed class Column_ContingentID_Rep_Email {

					/// <summary>
					/// Returns "ContingentID_Rep_Email"
					/// </summary>
					public const System.String ColumnName = "ContingentID_Rep_Email";
					/// <summary>
					/// Returns 122
					/// </summary>
					public const System.Int32 ColumnIndex = 122;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ContingentID_EnAnglais via shared members
				/// </summary>
				public sealed class Column_ContingentID_EnAnglais {

					/// <summary>
					/// Returns "ContingentID_EnAnglais"
					/// </summary>
					public const System.String ColumnName = "ContingentID_EnAnglais";
					/// <summary>
					/// Returns 123
					/// </summary>
					public const System.Int32 ColumnIndex = 123;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ContingentID_Actif via shared members
				/// </summary>
				public sealed class Column_ContingentID_Actif {

					/// <summary>
					/// Returns "ContingentID_Actif"
					/// </summary>
					public const System.String ColumnName = "ContingentID_Actif";
					/// <summary>
					/// Returns 124
					/// </summary>
					public const System.Int32 ColumnIndex = 124;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ContingentID_MRCProducteurID via shared members
				/// </summary>
				public sealed class Column_ContingentID_MRCProducteurID {

					/// <summary>
					/// Returns "ContingentID_MRCProducteurID"
					/// </summary>
					public const System.String ColumnName = "ContingentID_MRCProducteurID";
					/// <summary>
					/// Returns 125
					/// </summary>
					public const System.Int32 ColumnIndex = 125;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ContingentID_PaiementManuel via shared members
				/// </summary>
				public sealed class Column_ContingentID_PaiementManuel {

					/// <summary>
					/// Returns "ContingentID_PaiementManuel"
					/// </summary>
					public const System.String ColumnName = "ContingentID_PaiementManuel";
					/// <summary>
					/// Returns 126
					/// </summary>
					public const System.Int32 ColumnIndex = 126;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ContingentID_Journal via shared members
				/// </summary>
				public sealed class Column_ContingentID_Journal {

					/// <summary>
					/// Returns "ContingentID_Journal"
					/// </summary>
					public const System.String ColumnName = "ContingentID_Journal";
					/// <summary>
					/// Returns 127
					/// </summary>
					public const System.Int32 ColumnIndex = 127;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ContingentID_RecoitTPS via shared members
				/// </summary>
				public sealed class Column_ContingentID_RecoitTPS {

					/// <summary>
					/// Returns "ContingentID_RecoitTPS"
					/// </summary>
					public const System.String ColumnName = "ContingentID_RecoitTPS";
					/// <summary>
					/// Returns 128
					/// </summary>
					public const System.Int32 ColumnIndex = 128;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ContingentID_RecoitTVQ via shared members
				/// </summary>
				public sealed class Column_ContingentID_RecoitTVQ {

					/// <summary>
					/// Returns "ContingentID_RecoitTVQ"
					/// </summary>
					public const System.String ColumnName = "ContingentID_RecoitTVQ";
					/// <summary>
					/// Returns 129
					/// </summary>
					public const System.Int32 ColumnIndex = 129;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ContingentID_ModifierTrigger via shared members
				/// </summary>
				public sealed class Column_ContingentID_ModifierTrigger {

					/// <summary>
					/// Returns "ContingentID_ModifierTrigger"
					/// </summary>
					public const System.String ColumnName = "ContingentID_ModifierTrigger";
					/// <summary>
					/// Returns 130
					/// </summary>
					public const System.Int32 ColumnIndex = 130;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ContingentID_IsProducteur via shared members
				/// </summary>
				public sealed class Column_ContingentID_IsProducteur {

					/// <summary>
					/// Returns "ContingentID_IsProducteur"
					/// </summary>
					public const System.String ColumnName = "ContingentID_IsProducteur";
					/// <summary>
					/// Returns 131
					/// </summary>
					public const System.Int32 ColumnIndex = 131;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ContingentID_IsTransporteur via shared members
				/// </summary>
				public sealed class Column_ContingentID_IsTransporteur {

					/// <summary>
					/// Returns "ContingentID_IsTransporteur"
					/// </summary>
					public const System.String ColumnName = "ContingentID_IsTransporteur";
					/// <summary>
					/// Returns 132
					/// </summary>
					public const System.Int32 ColumnIndex = 132;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ContingentID_IsChargeur via shared members
				/// </summary>
				public sealed class Column_ContingentID_IsChargeur {

					/// <summary>
					/// Returns "ContingentID_IsChargeur"
					/// </summary>
					public const System.String ColumnName = "ContingentID_IsChargeur";
					/// <summary>
					/// Returns 133
					/// </summary>
					public const System.Int32 ColumnIndex = 133;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ContingentID_IsAutre via shared members
				/// </summary>
				public sealed class Column_ContingentID_IsAutre {

					/// <summary>
					/// Returns "ContingentID_IsAutre"
					/// </summary>
					public const System.String ColumnName = "ContingentID_IsAutre";
					/// <summary>
					/// Returns 134
					/// </summary>
					public const System.Int32 ColumnIndex = 134;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ContingentID_AfficherCommentairesSurPermit via shared members
				/// </summary>
				public sealed class Column_ContingentID_AfficherCommentairesSurPermit {

					/// <summary>
					/// Returns "ContingentID_AfficherCommentairesSurPermit"
					/// </summary>
					public const System.String ColumnName = "ContingentID_AfficherCommentairesSurPermit";
					/// <summary>
					/// Returns 135
					/// </summary>
					public const System.Int32 ColumnIndex = 135;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ContingentID_PasEmissionPermis via shared members
				/// </summary>
				public sealed class Column_ContingentID_PasEmissionPermis {

					/// <summary>
					/// Returns "ContingentID_PasEmissionPermis"
					/// </summary>
					public const System.String ColumnName = "ContingentID_PasEmissionPermis";
					/// <summary>
					/// Returns 136
					/// </summary>
					public const System.Int32 ColumnIndex = 136;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ContingentID_Generique via shared members
				/// </summary>
				public sealed class Column_ContingentID_Generique {

					/// <summary>
					/// Returns "ContingentID_Generique"
					/// </summary>
					public const System.String ColumnName = "ContingentID_Generique";
					/// <summary>
					/// Returns 137
					/// </summary>
					public const System.Int32 ColumnIndex = 137;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ContingentID_Membre_OGC via shared members
				/// </summary>
				public sealed class Column_ContingentID_Membre_OGC {

					/// <summary>
					/// Returns "ContingentID_Membre_OGC"
					/// </summary>
					public const System.String ColumnName = "ContingentID_Membre_OGC";
					/// <summary>
					/// Returns 138
					/// </summary>
					public const System.Int32 ColumnIndex = 138;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ContingentID_InscritTPS via shared members
				/// </summary>
				public sealed class Column_ContingentID_InscritTPS {

					/// <summary>
					/// Returns "ContingentID_InscritTPS"
					/// </summary>
					public const System.String ColumnName = "ContingentID_InscritTPS";
					/// <summary>
					/// Returns 139
					/// </summary>
					public const System.Int32 ColumnIndex = 139;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ContingentID_InscritTVQ via shared members
				/// </summary>
				public sealed class Column_ContingentID_InscritTVQ {

					/// <summary>
					/// Returns "ContingentID_InscritTVQ"
					/// </summary>
					public const System.String ColumnName = "ContingentID_InscritTVQ";
					/// <summary>
					/// Returns 140
					/// </summary>
					public const System.Int32 ColumnIndex = 140;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Droit_coupeID_ID via shared members
				/// </summary>
				public sealed class Column_Droit_coupeID_ID {

					/// <summary>
					/// Returns "Droit_coupeID_ID"
					/// </summary>
					public const System.String ColumnName = "Droit_coupeID_ID";
					/// <summary>
					/// Returns 141
					/// </summary>
					public const System.Int32 ColumnIndex = 141;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Droit_coupeID_CleTri via shared members
				/// </summary>
				public sealed class Column_Droit_coupeID_CleTri {

					/// <summary>
					/// Returns "Droit_coupeID_CleTri"
					/// </summary>
					public const System.String ColumnName = "Droit_coupeID_CleTri";
					/// <summary>
					/// Returns 142
					/// </summary>
					public const System.Int32 ColumnIndex = 142;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Droit_coupeID_Nom via shared members
				/// </summary>
				public sealed class Column_Droit_coupeID_Nom {

					/// <summary>
					/// Returns "Droit_coupeID_Nom"
					/// </summary>
					public const System.String ColumnName = "Droit_coupeID_Nom";
					/// <summary>
					/// Returns 143
					/// </summary>
					public const System.Int32 ColumnIndex = 143;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Droit_coupeID_AuSoinsDe via shared members
				/// </summary>
				public sealed class Column_Droit_coupeID_AuSoinsDe {

					/// <summary>
					/// Returns "Droit_coupeID_AuSoinsDe"
					/// </summary>
					public const System.String ColumnName = "Droit_coupeID_AuSoinsDe";
					/// <summary>
					/// Returns 144
					/// </summary>
					public const System.Int32 ColumnIndex = 144;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Droit_coupeID_Rue via shared members
				/// </summary>
				public sealed class Column_Droit_coupeID_Rue {

					/// <summary>
					/// Returns "Droit_coupeID_Rue"
					/// </summary>
					public const System.String ColumnName = "Droit_coupeID_Rue";
					/// <summary>
					/// Returns 145
					/// </summary>
					public const System.Int32 ColumnIndex = 145;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Droit_coupeID_Ville via shared members
				/// </summary>
				public sealed class Column_Droit_coupeID_Ville {

					/// <summary>
					/// Returns "Droit_coupeID_Ville"
					/// </summary>
					public const System.String ColumnName = "Droit_coupeID_Ville";
					/// <summary>
					/// Returns 146
					/// </summary>
					public const System.Int32 ColumnIndex = 146;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Droit_coupeID_PaysID via shared members
				/// </summary>
				public sealed class Column_Droit_coupeID_PaysID {

					/// <summary>
					/// Returns "Droit_coupeID_PaysID"
					/// </summary>
					public const System.String ColumnName = "Droit_coupeID_PaysID";
					/// <summary>
					/// Returns 147
					/// </summary>
					public const System.Int32 ColumnIndex = 147;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Droit_coupeID_Code_postal via shared members
				/// </summary>
				public sealed class Column_Droit_coupeID_Code_postal {

					/// <summary>
					/// Returns "Droit_coupeID_Code_postal"
					/// </summary>
					public const System.String ColumnName = "Droit_coupeID_Code_postal";
					/// <summary>
					/// Returns 148
					/// </summary>
					public const System.Int32 ColumnIndex = 148;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Droit_coupeID_Telephone via shared members
				/// </summary>
				public sealed class Column_Droit_coupeID_Telephone {

					/// <summary>
					/// Returns "Droit_coupeID_Telephone"
					/// </summary>
					public const System.String ColumnName = "Droit_coupeID_Telephone";
					/// <summary>
					/// Returns 149
					/// </summary>
					public const System.Int32 ColumnIndex = 149;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Droit_coupeID_Telephone_Poste via shared members
				/// </summary>
				public sealed class Column_Droit_coupeID_Telephone_Poste {

					/// <summary>
					/// Returns "Droit_coupeID_Telephone_Poste"
					/// </summary>
					public const System.String ColumnName = "Droit_coupeID_Telephone_Poste";
					/// <summary>
					/// Returns 150
					/// </summary>
					public const System.Int32 ColumnIndex = 150;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Droit_coupeID_Telecopieur via shared members
				/// </summary>
				public sealed class Column_Droit_coupeID_Telecopieur {

					/// <summary>
					/// Returns "Droit_coupeID_Telecopieur"
					/// </summary>
					public const System.String ColumnName = "Droit_coupeID_Telecopieur";
					/// <summary>
					/// Returns 151
					/// </summary>
					public const System.Int32 ColumnIndex = 151;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Droit_coupeID_Telephone2 via shared members
				/// </summary>
				public sealed class Column_Droit_coupeID_Telephone2 {

					/// <summary>
					/// Returns "Droit_coupeID_Telephone2"
					/// </summary>
					public const System.String ColumnName = "Droit_coupeID_Telephone2";
					/// <summary>
					/// Returns 152
					/// </summary>
					public const System.Int32 ColumnIndex = 152;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Droit_coupeID_Telephone2_Desc via shared members
				/// </summary>
				public sealed class Column_Droit_coupeID_Telephone2_Desc {

					/// <summary>
					/// Returns "Droit_coupeID_Telephone2_Desc"
					/// </summary>
					public const System.String ColumnName = "Droit_coupeID_Telephone2_Desc";
					/// <summary>
					/// Returns 153
					/// </summary>
					public const System.Int32 ColumnIndex = 153;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Droit_coupeID_Telephone2_Poste via shared members
				/// </summary>
				public sealed class Column_Droit_coupeID_Telephone2_Poste {

					/// <summary>
					/// Returns "Droit_coupeID_Telephone2_Poste"
					/// </summary>
					public const System.String ColumnName = "Droit_coupeID_Telephone2_Poste";
					/// <summary>
					/// Returns 154
					/// </summary>
					public const System.Int32 ColumnIndex = 154;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Droit_coupeID_Telephone3 via shared members
				/// </summary>
				public sealed class Column_Droit_coupeID_Telephone3 {

					/// <summary>
					/// Returns "Droit_coupeID_Telephone3"
					/// </summary>
					public const System.String ColumnName = "Droit_coupeID_Telephone3";
					/// <summary>
					/// Returns 155
					/// </summary>
					public const System.Int32 ColumnIndex = 155;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Droit_coupeID_Telephone3_Desc via shared members
				/// </summary>
				public sealed class Column_Droit_coupeID_Telephone3_Desc {

					/// <summary>
					/// Returns "Droit_coupeID_Telephone3_Desc"
					/// </summary>
					public const System.String ColumnName = "Droit_coupeID_Telephone3_Desc";
					/// <summary>
					/// Returns 156
					/// </summary>
					public const System.Int32 ColumnIndex = 156;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Droit_coupeID_Telephone3_Poste via shared members
				/// </summary>
				public sealed class Column_Droit_coupeID_Telephone3_Poste {

					/// <summary>
					/// Returns "Droit_coupeID_Telephone3_Poste"
					/// </summary>
					public const System.String ColumnName = "Droit_coupeID_Telephone3_Poste";
					/// <summary>
					/// Returns 157
					/// </summary>
					public const System.Int32 ColumnIndex = 157;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Droit_coupeID_No_membre via shared members
				/// </summary>
				public sealed class Column_Droit_coupeID_No_membre {

					/// <summary>
					/// Returns "Droit_coupeID_No_membre"
					/// </summary>
					public const System.String ColumnName = "Droit_coupeID_No_membre";
					/// <summary>
					/// Returns 158
					/// </summary>
					public const System.Int32 ColumnIndex = 158;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Droit_coupeID_Resident via shared members
				/// </summary>
				public sealed class Column_Droit_coupeID_Resident {

					/// <summary>
					/// Returns "Droit_coupeID_Resident"
					/// </summary>
					public const System.String ColumnName = "Droit_coupeID_Resident";
					/// <summary>
					/// Returns 159
					/// </summary>
					public const System.Int32 ColumnIndex = 159;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Droit_coupeID_Email via shared members
				/// </summary>
				public sealed class Column_Droit_coupeID_Email {

					/// <summary>
					/// Returns "Droit_coupeID_Email"
					/// </summary>
					public const System.String ColumnName = "Droit_coupeID_Email";
					/// <summary>
					/// Returns 160
					/// </summary>
					public const System.Int32 ColumnIndex = 160;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Droit_coupeID_WWW via shared members
				/// </summary>
				public sealed class Column_Droit_coupeID_WWW {

					/// <summary>
					/// Returns "Droit_coupeID_WWW"
					/// </summary>
					public const System.String ColumnName = "Droit_coupeID_WWW";
					/// <summary>
					/// Returns 161
					/// </summary>
					public const System.Int32 ColumnIndex = 161;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Droit_coupeID_Commentaires via shared members
				/// </summary>
				public sealed class Column_Droit_coupeID_Commentaires {

					/// <summary>
					/// Returns "Droit_coupeID_Commentaires"
					/// </summary>
					public const System.String ColumnName = "Droit_coupeID_Commentaires";
					/// <summary>
					/// Returns 162
					/// </summary>
					public const System.Int32 ColumnIndex = 162;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Droit_coupeID_AfficherCommentaires via shared members
				/// </summary>
				public sealed class Column_Droit_coupeID_AfficherCommentaires {

					/// <summary>
					/// Returns "Droit_coupeID_AfficherCommentaires"
					/// </summary>
					public const System.String ColumnName = "Droit_coupeID_AfficherCommentaires";
					/// <summary>
					/// Returns 163
					/// </summary>
					public const System.Int32 ColumnIndex = 163;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Droit_coupeID_DepotDirect via shared members
				/// </summary>
				public sealed class Column_Droit_coupeID_DepotDirect {

					/// <summary>
					/// Returns "Droit_coupeID_DepotDirect"
					/// </summary>
					public const System.String ColumnName = "Droit_coupeID_DepotDirect";
					/// <summary>
					/// Returns 164
					/// </summary>
					public const System.Int32 ColumnIndex = 164;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Droit_coupeID_InstitutionBanquaireID via shared members
				/// </summary>
				public sealed class Column_Droit_coupeID_InstitutionBanquaireID {

					/// <summary>
					/// Returns "Droit_coupeID_InstitutionBanquaireID"
					/// </summary>
					public const System.String ColumnName = "Droit_coupeID_InstitutionBanquaireID";
					/// <summary>
					/// Returns 165
					/// </summary>
					public const System.Int32 ColumnIndex = 165;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Droit_coupeID_Banque_transit via shared members
				/// </summary>
				public sealed class Column_Droit_coupeID_Banque_transit {

					/// <summary>
					/// Returns "Droit_coupeID_Banque_transit"
					/// </summary>
					public const System.String ColumnName = "Droit_coupeID_Banque_transit";
					/// <summary>
					/// Returns 166
					/// </summary>
					public const System.Int32 ColumnIndex = 166;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Droit_coupeID_Banque_folio via shared members
				/// </summary>
				public sealed class Column_Droit_coupeID_Banque_folio {

					/// <summary>
					/// Returns "Droit_coupeID_Banque_folio"
					/// </summary>
					public const System.String ColumnName = "Droit_coupeID_Banque_folio";
					/// <summary>
					/// Returns 167
					/// </summary>
					public const System.Int32 ColumnIndex = 167;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Droit_coupeID_No_TPS via shared members
				/// </summary>
				public sealed class Column_Droit_coupeID_No_TPS {

					/// <summary>
					/// Returns "Droit_coupeID_No_TPS"
					/// </summary>
					public const System.String ColumnName = "Droit_coupeID_No_TPS";
					/// <summary>
					/// Returns 168
					/// </summary>
					public const System.Int32 ColumnIndex = 168;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Droit_coupeID_No_TVQ via shared members
				/// </summary>
				public sealed class Column_Droit_coupeID_No_TVQ {

					/// <summary>
					/// Returns "Droit_coupeID_No_TVQ"
					/// </summary>
					public const System.String ColumnName = "Droit_coupeID_No_TVQ";
					/// <summary>
					/// Returns 169
					/// </summary>
					public const System.Int32 ColumnIndex = 169;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Droit_coupeID_PayerA via shared members
				/// </summary>
				public sealed class Column_Droit_coupeID_PayerA {

					/// <summary>
					/// Returns "Droit_coupeID_PayerA"
					/// </summary>
					public const System.String ColumnName = "Droit_coupeID_PayerA";
					/// <summary>
					/// Returns 170
					/// </summary>
					public const System.Int32 ColumnIndex = 170;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Droit_coupeID_PayerAID via shared members
				/// </summary>
				public sealed class Column_Droit_coupeID_PayerAID {

					/// <summary>
					/// Returns "Droit_coupeID_PayerAID"
					/// </summary>
					public const System.String ColumnName = "Droit_coupeID_PayerAID";
					/// <summary>
					/// Returns 171
					/// </summary>
					public const System.Int32 ColumnIndex = 171;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Droit_coupeID_Statut via shared members
				/// </summary>
				public sealed class Column_Droit_coupeID_Statut {

					/// <summary>
					/// Returns "Droit_coupeID_Statut"
					/// </summary>
					public const System.String ColumnName = "Droit_coupeID_Statut";
					/// <summary>
					/// Returns 172
					/// </summary>
					public const System.Int32 ColumnIndex = 172;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Droit_coupeID_Rep_Nom via shared members
				/// </summary>
				public sealed class Column_Droit_coupeID_Rep_Nom {

					/// <summary>
					/// Returns "Droit_coupeID_Rep_Nom"
					/// </summary>
					public const System.String ColumnName = "Droit_coupeID_Rep_Nom";
					/// <summary>
					/// Returns 173
					/// </summary>
					public const System.Int32 ColumnIndex = 173;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Droit_coupeID_Rep_Telephone via shared members
				/// </summary>
				public sealed class Column_Droit_coupeID_Rep_Telephone {

					/// <summary>
					/// Returns "Droit_coupeID_Rep_Telephone"
					/// </summary>
					public const System.String ColumnName = "Droit_coupeID_Rep_Telephone";
					/// <summary>
					/// Returns 174
					/// </summary>
					public const System.Int32 ColumnIndex = 174;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Droit_coupeID_Rep_Telephone_Poste via shared members
				/// </summary>
				public sealed class Column_Droit_coupeID_Rep_Telephone_Poste {

					/// <summary>
					/// Returns "Droit_coupeID_Rep_Telephone_Poste"
					/// </summary>
					public const System.String ColumnName = "Droit_coupeID_Rep_Telephone_Poste";
					/// <summary>
					/// Returns 175
					/// </summary>
					public const System.Int32 ColumnIndex = 175;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Droit_coupeID_Rep_Email via shared members
				/// </summary>
				public sealed class Column_Droit_coupeID_Rep_Email {

					/// <summary>
					/// Returns "Droit_coupeID_Rep_Email"
					/// </summary>
					public const System.String ColumnName = "Droit_coupeID_Rep_Email";
					/// <summary>
					/// Returns 176
					/// </summary>
					public const System.Int32 ColumnIndex = 176;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Droit_coupeID_EnAnglais via shared members
				/// </summary>
				public sealed class Column_Droit_coupeID_EnAnglais {

					/// <summary>
					/// Returns "Droit_coupeID_EnAnglais"
					/// </summary>
					public const System.String ColumnName = "Droit_coupeID_EnAnglais";
					/// <summary>
					/// Returns 177
					/// </summary>
					public const System.Int32 ColumnIndex = 177;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Droit_coupeID_Actif via shared members
				/// </summary>
				public sealed class Column_Droit_coupeID_Actif {

					/// <summary>
					/// Returns "Droit_coupeID_Actif"
					/// </summary>
					public const System.String ColumnName = "Droit_coupeID_Actif";
					/// <summary>
					/// Returns 178
					/// </summary>
					public const System.Int32 ColumnIndex = 178;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Droit_coupeID_MRCProducteurID via shared members
				/// </summary>
				public sealed class Column_Droit_coupeID_MRCProducteurID {

					/// <summary>
					/// Returns "Droit_coupeID_MRCProducteurID"
					/// </summary>
					public const System.String ColumnName = "Droit_coupeID_MRCProducteurID";
					/// <summary>
					/// Returns 179
					/// </summary>
					public const System.Int32 ColumnIndex = 179;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Droit_coupeID_PaiementManuel via shared members
				/// </summary>
				public sealed class Column_Droit_coupeID_PaiementManuel {

					/// <summary>
					/// Returns "Droit_coupeID_PaiementManuel"
					/// </summary>
					public const System.String ColumnName = "Droit_coupeID_PaiementManuel";
					/// <summary>
					/// Returns 180
					/// </summary>
					public const System.Int32 ColumnIndex = 180;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Droit_coupeID_Journal via shared members
				/// </summary>
				public sealed class Column_Droit_coupeID_Journal {

					/// <summary>
					/// Returns "Droit_coupeID_Journal"
					/// </summary>
					public const System.String ColumnName = "Droit_coupeID_Journal";
					/// <summary>
					/// Returns 181
					/// </summary>
					public const System.Int32 ColumnIndex = 181;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Droit_coupeID_RecoitTPS via shared members
				/// </summary>
				public sealed class Column_Droit_coupeID_RecoitTPS {

					/// <summary>
					/// Returns "Droit_coupeID_RecoitTPS"
					/// </summary>
					public const System.String ColumnName = "Droit_coupeID_RecoitTPS";
					/// <summary>
					/// Returns 182
					/// </summary>
					public const System.Int32 ColumnIndex = 182;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Droit_coupeID_RecoitTVQ via shared members
				/// </summary>
				public sealed class Column_Droit_coupeID_RecoitTVQ {

					/// <summary>
					/// Returns "Droit_coupeID_RecoitTVQ"
					/// </summary>
					public const System.String ColumnName = "Droit_coupeID_RecoitTVQ";
					/// <summary>
					/// Returns 183
					/// </summary>
					public const System.Int32 ColumnIndex = 183;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Droit_coupeID_ModifierTrigger via shared members
				/// </summary>
				public sealed class Column_Droit_coupeID_ModifierTrigger {

					/// <summary>
					/// Returns "Droit_coupeID_ModifierTrigger"
					/// </summary>
					public const System.String ColumnName = "Droit_coupeID_ModifierTrigger";
					/// <summary>
					/// Returns 184
					/// </summary>
					public const System.Int32 ColumnIndex = 184;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Droit_coupeID_IsProducteur via shared members
				/// </summary>
				public sealed class Column_Droit_coupeID_IsProducteur {

					/// <summary>
					/// Returns "Droit_coupeID_IsProducteur"
					/// </summary>
					public const System.String ColumnName = "Droit_coupeID_IsProducteur";
					/// <summary>
					/// Returns 185
					/// </summary>
					public const System.Int32 ColumnIndex = 185;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Droit_coupeID_IsTransporteur via shared members
				/// </summary>
				public sealed class Column_Droit_coupeID_IsTransporteur {

					/// <summary>
					/// Returns "Droit_coupeID_IsTransporteur"
					/// </summary>
					public const System.String ColumnName = "Droit_coupeID_IsTransporteur";
					/// <summary>
					/// Returns 186
					/// </summary>
					public const System.Int32 ColumnIndex = 186;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Droit_coupeID_IsChargeur via shared members
				/// </summary>
				public sealed class Column_Droit_coupeID_IsChargeur {

					/// <summary>
					/// Returns "Droit_coupeID_IsChargeur"
					/// </summary>
					public const System.String ColumnName = "Droit_coupeID_IsChargeur";
					/// <summary>
					/// Returns 187
					/// </summary>
					public const System.Int32 ColumnIndex = 187;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Droit_coupeID_IsAutre via shared members
				/// </summary>
				public sealed class Column_Droit_coupeID_IsAutre {

					/// <summary>
					/// Returns "Droit_coupeID_IsAutre"
					/// </summary>
					public const System.String ColumnName = "Droit_coupeID_IsAutre";
					/// <summary>
					/// Returns 188
					/// </summary>
					public const System.Int32 ColumnIndex = 188;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Droit_coupeID_AfficherCommentairesSurPermit via shared members
				/// </summary>
				public sealed class Column_Droit_coupeID_AfficherCommentairesSurPermit {

					/// <summary>
					/// Returns "Droit_coupeID_AfficherCommentairesSurPermit"
					/// </summary>
					public const System.String ColumnName = "Droit_coupeID_AfficherCommentairesSurPermit";
					/// <summary>
					/// Returns 189
					/// </summary>
					public const System.Int32 ColumnIndex = 189;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Droit_coupeID_PasEmissionPermis via shared members
				/// </summary>
				public sealed class Column_Droit_coupeID_PasEmissionPermis {

					/// <summary>
					/// Returns "Droit_coupeID_PasEmissionPermis"
					/// </summary>
					public const System.String ColumnName = "Droit_coupeID_PasEmissionPermis";
					/// <summary>
					/// Returns 190
					/// </summary>
					public const System.Int32 ColumnIndex = 190;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Droit_coupeID_Generique via shared members
				/// </summary>
				public sealed class Column_Droit_coupeID_Generique {

					/// <summary>
					/// Returns "Droit_coupeID_Generique"
					/// </summary>
					public const System.String ColumnName = "Droit_coupeID_Generique";
					/// <summary>
					/// Returns 191
					/// </summary>
					public const System.Int32 ColumnIndex = 191;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Droit_coupeID_Membre_OGC via shared members
				/// </summary>
				public sealed class Column_Droit_coupeID_Membre_OGC {

					/// <summary>
					/// Returns "Droit_coupeID_Membre_OGC"
					/// </summary>
					public const System.String ColumnName = "Droit_coupeID_Membre_OGC";
					/// <summary>
					/// Returns 192
					/// </summary>
					public const System.Int32 ColumnIndex = 192;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Droit_coupeID_InscritTPS via shared members
				/// </summary>
				public sealed class Column_Droit_coupeID_InscritTPS {

					/// <summary>
					/// Returns "Droit_coupeID_InscritTPS"
					/// </summary>
					public const System.String ColumnName = "Droit_coupeID_InscritTPS";
					/// <summary>
					/// Returns 193
					/// </summary>
					public const System.Int32 ColumnIndex = 193;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Droit_coupeID_InscritTVQ via shared members
				/// </summary>
				public sealed class Column_Droit_coupeID_InscritTVQ {

					/// <summary>
					/// Returns "Droit_coupeID_InscritTVQ"
					/// </summary>
					public const System.String ColumnName = "Droit_coupeID_InscritTVQ";
					/// <summary>
					/// Returns 194
					/// </summary>
					public const System.Int32 ColumnIndex = 194;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Entente_paiementID_ID via shared members
				/// </summary>
				public sealed class Column_Entente_paiementID_ID {

					/// <summary>
					/// Returns "Entente_paiementID_ID"
					/// </summary>
					public const System.String ColumnName = "Entente_paiementID_ID";
					/// <summary>
					/// Returns 195
					/// </summary>
					public const System.Int32 ColumnIndex = 195;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Entente_paiementID_CleTri via shared members
				/// </summary>
				public sealed class Column_Entente_paiementID_CleTri {

					/// <summary>
					/// Returns "Entente_paiementID_CleTri"
					/// </summary>
					public const System.String ColumnName = "Entente_paiementID_CleTri";
					/// <summary>
					/// Returns 196
					/// </summary>
					public const System.Int32 ColumnIndex = 196;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Entente_paiementID_Nom via shared members
				/// </summary>
				public sealed class Column_Entente_paiementID_Nom {

					/// <summary>
					/// Returns "Entente_paiementID_Nom"
					/// </summary>
					public const System.String ColumnName = "Entente_paiementID_Nom";
					/// <summary>
					/// Returns 197
					/// </summary>
					public const System.Int32 ColumnIndex = 197;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Entente_paiementID_AuSoinsDe via shared members
				/// </summary>
				public sealed class Column_Entente_paiementID_AuSoinsDe {

					/// <summary>
					/// Returns "Entente_paiementID_AuSoinsDe"
					/// </summary>
					public const System.String ColumnName = "Entente_paiementID_AuSoinsDe";
					/// <summary>
					/// Returns 198
					/// </summary>
					public const System.Int32 ColumnIndex = 198;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Entente_paiementID_Rue via shared members
				/// </summary>
				public sealed class Column_Entente_paiementID_Rue {

					/// <summary>
					/// Returns "Entente_paiementID_Rue"
					/// </summary>
					public const System.String ColumnName = "Entente_paiementID_Rue";
					/// <summary>
					/// Returns 199
					/// </summary>
					public const System.Int32 ColumnIndex = 199;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Entente_paiementID_Ville via shared members
				/// </summary>
				public sealed class Column_Entente_paiementID_Ville {

					/// <summary>
					/// Returns "Entente_paiementID_Ville"
					/// </summary>
					public const System.String ColumnName = "Entente_paiementID_Ville";
					/// <summary>
					/// Returns 200
					/// </summary>
					public const System.Int32 ColumnIndex = 200;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Entente_paiementID_PaysID via shared members
				/// </summary>
				public sealed class Column_Entente_paiementID_PaysID {

					/// <summary>
					/// Returns "Entente_paiementID_PaysID"
					/// </summary>
					public const System.String ColumnName = "Entente_paiementID_PaysID";
					/// <summary>
					/// Returns 201
					/// </summary>
					public const System.Int32 ColumnIndex = 201;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Entente_paiementID_Code_postal via shared members
				/// </summary>
				public sealed class Column_Entente_paiementID_Code_postal {

					/// <summary>
					/// Returns "Entente_paiementID_Code_postal"
					/// </summary>
					public const System.String ColumnName = "Entente_paiementID_Code_postal";
					/// <summary>
					/// Returns 202
					/// </summary>
					public const System.Int32 ColumnIndex = 202;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Entente_paiementID_Telephone via shared members
				/// </summary>
				public sealed class Column_Entente_paiementID_Telephone {

					/// <summary>
					/// Returns "Entente_paiementID_Telephone"
					/// </summary>
					public const System.String ColumnName = "Entente_paiementID_Telephone";
					/// <summary>
					/// Returns 203
					/// </summary>
					public const System.Int32 ColumnIndex = 203;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Entente_paiementID_Telephone_Poste via shared members
				/// </summary>
				public sealed class Column_Entente_paiementID_Telephone_Poste {

					/// <summary>
					/// Returns "Entente_paiementID_Telephone_Poste"
					/// </summary>
					public const System.String ColumnName = "Entente_paiementID_Telephone_Poste";
					/// <summary>
					/// Returns 204
					/// </summary>
					public const System.Int32 ColumnIndex = 204;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Entente_paiementID_Telecopieur via shared members
				/// </summary>
				public sealed class Column_Entente_paiementID_Telecopieur {

					/// <summary>
					/// Returns "Entente_paiementID_Telecopieur"
					/// </summary>
					public const System.String ColumnName = "Entente_paiementID_Telecopieur";
					/// <summary>
					/// Returns 205
					/// </summary>
					public const System.Int32 ColumnIndex = 205;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Entente_paiementID_Telephone2 via shared members
				/// </summary>
				public sealed class Column_Entente_paiementID_Telephone2 {

					/// <summary>
					/// Returns "Entente_paiementID_Telephone2"
					/// </summary>
					public const System.String ColumnName = "Entente_paiementID_Telephone2";
					/// <summary>
					/// Returns 206
					/// </summary>
					public const System.Int32 ColumnIndex = 206;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Entente_paiementID_Telephone2_Desc via shared members
				/// </summary>
				public sealed class Column_Entente_paiementID_Telephone2_Desc {

					/// <summary>
					/// Returns "Entente_paiementID_Telephone2_Desc"
					/// </summary>
					public const System.String ColumnName = "Entente_paiementID_Telephone2_Desc";
					/// <summary>
					/// Returns 207
					/// </summary>
					public const System.Int32 ColumnIndex = 207;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Entente_paiementID_Telephone2_Poste via shared members
				/// </summary>
				public sealed class Column_Entente_paiementID_Telephone2_Poste {

					/// <summary>
					/// Returns "Entente_paiementID_Telephone2_Poste"
					/// </summary>
					public const System.String ColumnName = "Entente_paiementID_Telephone2_Poste";
					/// <summary>
					/// Returns 208
					/// </summary>
					public const System.Int32 ColumnIndex = 208;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Entente_paiementID_Telephone3 via shared members
				/// </summary>
				public sealed class Column_Entente_paiementID_Telephone3 {

					/// <summary>
					/// Returns "Entente_paiementID_Telephone3"
					/// </summary>
					public const System.String ColumnName = "Entente_paiementID_Telephone3";
					/// <summary>
					/// Returns 209
					/// </summary>
					public const System.Int32 ColumnIndex = 209;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Entente_paiementID_Telephone3_Desc via shared members
				/// </summary>
				public sealed class Column_Entente_paiementID_Telephone3_Desc {

					/// <summary>
					/// Returns "Entente_paiementID_Telephone3_Desc"
					/// </summary>
					public const System.String ColumnName = "Entente_paiementID_Telephone3_Desc";
					/// <summary>
					/// Returns 210
					/// </summary>
					public const System.Int32 ColumnIndex = 210;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Entente_paiementID_Telephone3_Poste via shared members
				/// </summary>
				public sealed class Column_Entente_paiementID_Telephone3_Poste {

					/// <summary>
					/// Returns "Entente_paiementID_Telephone3_Poste"
					/// </summary>
					public const System.String ColumnName = "Entente_paiementID_Telephone3_Poste";
					/// <summary>
					/// Returns 211
					/// </summary>
					public const System.Int32 ColumnIndex = 211;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Entente_paiementID_No_membre via shared members
				/// </summary>
				public sealed class Column_Entente_paiementID_No_membre {

					/// <summary>
					/// Returns "Entente_paiementID_No_membre"
					/// </summary>
					public const System.String ColumnName = "Entente_paiementID_No_membre";
					/// <summary>
					/// Returns 212
					/// </summary>
					public const System.Int32 ColumnIndex = 212;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Entente_paiementID_Resident via shared members
				/// </summary>
				public sealed class Column_Entente_paiementID_Resident {

					/// <summary>
					/// Returns "Entente_paiementID_Resident"
					/// </summary>
					public const System.String ColumnName = "Entente_paiementID_Resident";
					/// <summary>
					/// Returns 213
					/// </summary>
					public const System.Int32 ColumnIndex = 213;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Entente_paiementID_Email via shared members
				/// </summary>
				public sealed class Column_Entente_paiementID_Email {

					/// <summary>
					/// Returns "Entente_paiementID_Email"
					/// </summary>
					public const System.String ColumnName = "Entente_paiementID_Email";
					/// <summary>
					/// Returns 214
					/// </summary>
					public const System.Int32 ColumnIndex = 214;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Entente_paiementID_WWW via shared members
				/// </summary>
				public sealed class Column_Entente_paiementID_WWW {

					/// <summary>
					/// Returns "Entente_paiementID_WWW"
					/// </summary>
					public const System.String ColumnName = "Entente_paiementID_WWW";
					/// <summary>
					/// Returns 215
					/// </summary>
					public const System.Int32 ColumnIndex = 215;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Entente_paiementID_Commentaires via shared members
				/// </summary>
				public sealed class Column_Entente_paiementID_Commentaires {

					/// <summary>
					/// Returns "Entente_paiementID_Commentaires"
					/// </summary>
					public const System.String ColumnName = "Entente_paiementID_Commentaires";
					/// <summary>
					/// Returns 216
					/// </summary>
					public const System.Int32 ColumnIndex = 216;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Entente_paiementID_AfficherCommentaires via shared members
				/// </summary>
				public sealed class Column_Entente_paiementID_AfficherCommentaires {

					/// <summary>
					/// Returns "Entente_paiementID_AfficherCommentaires"
					/// </summary>
					public const System.String ColumnName = "Entente_paiementID_AfficherCommentaires";
					/// <summary>
					/// Returns 217
					/// </summary>
					public const System.Int32 ColumnIndex = 217;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Entente_paiementID_DepotDirect via shared members
				/// </summary>
				public sealed class Column_Entente_paiementID_DepotDirect {

					/// <summary>
					/// Returns "Entente_paiementID_DepotDirect"
					/// </summary>
					public const System.String ColumnName = "Entente_paiementID_DepotDirect";
					/// <summary>
					/// Returns 218
					/// </summary>
					public const System.Int32 ColumnIndex = 218;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Entente_paiementID_InstitutionBanquaireID via shared members
				/// </summary>
				public sealed class Column_Entente_paiementID_InstitutionBanquaireID {

					/// <summary>
					/// Returns "Entente_paiementID_InstitutionBanquaireID"
					/// </summary>
					public const System.String ColumnName = "Entente_paiementID_InstitutionBanquaireID";
					/// <summary>
					/// Returns 219
					/// </summary>
					public const System.Int32 ColumnIndex = 219;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Entente_paiementID_Banque_transit via shared members
				/// </summary>
				public sealed class Column_Entente_paiementID_Banque_transit {

					/// <summary>
					/// Returns "Entente_paiementID_Banque_transit"
					/// </summary>
					public const System.String ColumnName = "Entente_paiementID_Banque_transit";
					/// <summary>
					/// Returns 220
					/// </summary>
					public const System.Int32 ColumnIndex = 220;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Entente_paiementID_Banque_folio via shared members
				/// </summary>
				public sealed class Column_Entente_paiementID_Banque_folio {

					/// <summary>
					/// Returns "Entente_paiementID_Banque_folio"
					/// </summary>
					public const System.String ColumnName = "Entente_paiementID_Banque_folio";
					/// <summary>
					/// Returns 221
					/// </summary>
					public const System.Int32 ColumnIndex = 221;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Entente_paiementID_No_TPS via shared members
				/// </summary>
				public sealed class Column_Entente_paiementID_No_TPS {

					/// <summary>
					/// Returns "Entente_paiementID_No_TPS"
					/// </summary>
					public const System.String ColumnName = "Entente_paiementID_No_TPS";
					/// <summary>
					/// Returns 222
					/// </summary>
					public const System.Int32 ColumnIndex = 222;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Entente_paiementID_No_TVQ via shared members
				/// </summary>
				public sealed class Column_Entente_paiementID_No_TVQ {

					/// <summary>
					/// Returns "Entente_paiementID_No_TVQ"
					/// </summary>
					public const System.String ColumnName = "Entente_paiementID_No_TVQ";
					/// <summary>
					/// Returns 223
					/// </summary>
					public const System.Int32 ColumnIndex = 223;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Entente_paiementID_PayerA via shared members
				/// </summary>
				public sealed class Column_Entente_paiementID_PayerA {

					/// <summary>
					/// Returns "Entente_paiementID_PayerA"
					/// </summary>
					public const System.String ColumnName = "Entente_paiementID_PayerA";
					/// <summary>
					/// Returns 224
					/// </summary>
					public const System.Int32 ColumnIndex = 224;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Entente_paiementID_PayerAID via shared members
				/// </summary>
				public sealed class Column_Entente_paiementID_PayerAID {

					/// <summary>
					/// Returns "Entente_paiementID_PayerAID"
					/// </summary>
					public const System.String ColumnName = "Entente_paiementID_PayerAID";
					/// <summary>
					/// Returns 225
					/// </summary>
					public const System.Int32 ColumnIndex = 225;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Entente_paiementID_Statut via shared members
				/// </summary>
				public sealed class Column_Entente_paiementID_Statut {

					/// <summary>
					/// Returns "Entente_paiementID_Statut"
					/// </summary>
					public const System.String ColumnName = "Entente_paiementID_Statut";
					/// <summary>
					/// Returns 226
					/// </summary>
					public const System.Int32 ColumnIndex = 226;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Entente_paiementID_Rep_Nom via shared members
				/// </summary>
				public sealed class Column_Entente_paiementID_Rep_Nom {

					/// <summary>
					/// Returns "Entente_paiementID_Rep_Nom"
					/// </summary>
					public const System.String ColumnName = "Entente_paiementID_Rep_Nom";
					/// <summary>
					/// Returns 227
					/// </summary>
					public const System.Int32 ColumnIndex = 227;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Entente_paiementID_Rep_Telephone via shared members
				/// </summary>
				public sealed class Column_Entente_paiementID_Rep_Telephone {

					/// <summary>
					/// Returns "Entente_paiementID_Rep_Telephone"
					/// </summary>
					public const System.String ColumnName = "Entente_paiementID_Rep_Telephone";
					/// <summary>
					/// Returns 228
					/// </summary>
					public const System.Int32 ColumnIndex = 228;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Entente_paiementID_Rep_Telephone_Poste via shared members
				/// </summary>
				public sealed class Column_Entente_paiementID_Rep_Telephone_Poste {

					/// <summary>
					/// Returns "Entente_paiementID_Rep_Telephone_Poste"
					/// </summary>
					public const System.String ColumnName = "Entente_paiementID_Rep_Telephone_Poste";
					/// <summary>
					/// Returns 229
					/// </summary>
					public const System.Int32 ColumnIndex = 229;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Entente_paiementID_Rep_Email via shared members
				/// </summary>
				public sealed class Column_Entente_paiementID_Rep_Email {

					/// <summary>
					/// Returns "Entente_paiementID_Rep_Email"
					/// </summary>
					public const System.String ColumnName = "Entente_paiementID_Rep_Email";
					/// <summary>
					/// Returns 230
					/// </summary>
					public const System.Int32 ColumnIndex = 230;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Entente_paiementID_EnAnglais via shared members
				/// </summary>
				public sealed class Column_Entente_paiementID_EnAnglais {

					/// <summary>
					/// Returns "Entente_paiementID_EnAnglais"
					/// </summary>
					public const System.String ColumnName = "Entente_paiementID_EnAnglais";
					/// <summary>
					/// Returns 231
					/// </summary>
					public const System.Int32 ColumnIndex = 231;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Entente_paiementID_Actif via shared members
				/// </summary>
				public sealed class Column_Entente_paiementID_Actif {

					/// <summary>
					/// Returns "Entente_paiementID_Actif"
					/// </summary>
					public const System.String ColumnName = "Entente_paiementID_Actif";
					/// <summary>
					/// Returns 232
					/// </summary>
					public const System.Int32 ColumnIndex = 232;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Entente_paiementID_MRCProducteurID via shared members
				/// </summary>
				public sealed class Column_Entente_paiementID_MRCProducteurID {

					/// <summary>
					/// Returns "Entente_paiementID_MRCProducteurID"
					/// </summary>
					public const System.String ColumnName = "Entente_paiementID_MRCProducteurID";
					/// <summary>
					/// Returns 233
					/// </summary>
					public const System.Int32 ColumnIndex = 233;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Entente_paiementID_PaiementManuel via shared members
				/// </summary>
				public sealed class Column_Entente_paiementID_PaiementManuel {

					/// <summary>
					/// Returns "Entente_paiementID_PaiementManuel"
					/// </summary>
					public const System.String ColumnName = "Entente_paiementID_PaiementManuel";
					/// <summary>
					/// Returns 234
					/// </summary>
					public const System.Int32 ColumnIndex = 234;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Entente_paiementID_Journal via shared members
				/// </summary>
				public sealed class Column_Entente_paiementID_Journal {

					/// <summary>
					/// Returns "Entente_paiementID_Journal"
					/// </summary>
					public const System.String ColumnName = "Entente_paiementID_Journal";
					/// <summary>
					/// Returns 235
					/// </summary>
					public const System.Int32 ColumnIndex = 235;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Entente_paiementID_RecoitTPS via shared members
				/// </summary>
				public sealed class Column_Entente_paiementID_RecoitTPS {

					/// <summary>
					/// Returns "Entente_paiementID_RecoitTPS"
					/// </summary>
					public const System.String ColumnName = "Entente_paiementID_RecoitTPS";
					/// <summary>
					/// Returns 236
					/// </summary>
					public const System.Int32 ColumnIndex = 236;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Entente_paiementID_RecoitTVQ via shared members
				/// </summary>
				public sealed class Column_Entente_paiementID_RecoitTVQ {

					/// <summary>
					/// Returns "Entente_paiementID_RecoitTVQ"
					/// </summary>
					public const System.String ColumnName = "Entente_paiementID_RecoitTVQ";
					/// <summary>
					/// Returns 237
					/// </summary>
					public const System.Int32 ColumnIndex = 237;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Entente_paiementID_ModifierTrigger via shared members
				/// </summary>
				public sealed class Column_Entente_paiementID_ModifierTrigger {

					/// <summary>
					/// Returns "Entente_paiementID_ModifierTrigger"
					/// </summary>
					public const System.String ColumnName = "Entente_paiementID_ModifierTrigger";
					/// <summary>
					/// Returns 238
					/// </summary>
					public const System.Int32 ColumnIndex = 238;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Entente_paiementID_IsProducteur via shared members
				/// </summary>
				public sealed class Column_Entente_paiementID_IsProducteur {

					/// <summary>
					/// Returns "Entente_paiementID_IsProducteur"
					/// </summary>
					public const System.String ColumnName = "Entente_paiementID_IsProducteur";
					/// <summary>
					/// Returns 239
					/// </summary>
					public const System.Int32 ColumnIndex = 239;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Entente_paiementID_IsTransporteur via shared members
				/// </summary>
				public sealed class Column_Entente_paiementID_IsTransporteur {

					/// <summary>
					/// Returns "Entente_paiementID_IsTransporteur"
					/// </summary>
					public const System.String ColumnName = "Entente_paiementID_IsTransporteur";
					/// <summary>
					/// Returns 240
					/// </summary>
					public const System.Int32 ColumnIndex = 240;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Entente_paiementID_IsChargeur via shared members
				/// </summary>
				public sealed class Column_Entente_paiementID_IsChargeur {

					/// <summary>
					/// Returns "Entente_paiementID_IsChargeur"
					/// </summary>
					public const System.String ColumnName = "Entente_paiementID_IsChargeur";
					/// <summary>
					/// Returns 241
					/// </summary>
					public const System.Int32 ColumnIndex = 241;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Entente_paiementID_IsAutre via shared members
				/// </summary>
				public sealed class Column_Entente_paiementID_IsAutre {

					/// <summary>
					/// Returns "Entente_paiementID_IsAutre"
					/// </summary>
					public const System.String ColumnName = "Entente_paiementID_IsAutre";
					/// <summary>
					/// Returns 242
					/// </summary>
					public const System.Int32 ColumnIndex = 242;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Entente_paiementID_AfficherCommentairesSurPermit via shared members
				/// </summary>
				public sealed class Column_Entente_paiementID_AfficherCommentairesSurPermit {

					/// <summary>
					/// Returns "Entente_paiementID_AfficherCommentairesSurPermit"
					/// </summary>
					public const System.String ColumnName = "Entente_paiementID_AfficherCommentairesSurPermit";
					/// <summary>
					/// Returns 243
					/// </summary>
					public const System.Int32 ColumnIndex = 243;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Entente_paiementID_PasEmissionPermis via shared members
				/// </summary>
				public sealed class Column_Entente_paiementID_PasEmissionPermis {

					/// <summary>
					/// Returns "Entente_paiementID_PasEmissionPermis"
					/// </summary>
					public const System.String ColumnName = "Entente_paiementID_PasEmissionPermis";
					/// <summary>
					/// Returns 244
					/// </summary>
					public const System.Int32 ColumnIndex = 244;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Entente_paiementID_Generique via shared members
				/// </summary>
				public sealed class Column_Entente_paiementID_Generique {

					/// <summary>
					/// Returns "Entente_paiementID_Generique"
					/// </summary>
					public const System.String ColumnName = "Entente_paiementID_Generique";
					/// <summary>
					/// Returns 245
					/// </summary>
					public const System.Int32 ColumnIndex = 245;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Entente_paiementID_Membre_OGC via shared members
				/// </summary>
				public sealed class Column_Entente_paiementID_Membre_OGC {

					/// <summary>
					/// Returns "Entente_paiementID_Membre_OGC"
					/// </summary>
					public const System.String ColumnName = "Entente_paiementID_Membre_OGC";
					/// <summary>
					/// Returns 246
					/// </summary>
					public const System.Int32 ColumnIndex = 246;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Entente_paiementID_InscritTPS via shared members
				/// </summary>
				public sealed class Column_Entente_paiementID_InscritTPS {

					/// <summary>
					/// Returns "Entente_paiementID_InscritTPS"
					/// </summary>
					public const System.String ColumnName = "Entente_paiementID_InscritTPS";
					/// <summary>
					/// Returns 247
					/// </summary>
					public const System.Int32 ColumnIndex = 247;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Entente_paiementID_InscritTVQ via shared members
				/// </summary>
				public sealed class Column_Entente_paiementID_InscritTVQ {

					/// <summary>
					/// Returns "Entente_paiementID_InscritTVQ"
					/// </summary>
					public const System.String ColumnName = "Entente_paiementID_InscritTVQ";
					/// <summary>
					/// Returns 248
					/// </summary>
					public const System.Int32 ColumnIndex = 248;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ZoneID_ID via shared members
				/// </summary>
				public sealed class Column_ZoneID_ID {

					/// <summary>
					/// Returns "ZoneID_ID"
					/// </summary>
					public const System.String ColumnName = "ZoneID_ID";
					/// <summary>
					/// Returns 249
					/// </summary>
					public const System.Int32 ColumnIndex = 249;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ZoneID_MunicipaliteID via shared members
				/// </summary>
				public sealed class Column_ZoneID_MunicipaliteID {

					/// <summary>
					/// Returns "ZoneID_MunicipaliteID"
					/// </summary>
					public const System.String ColumnName = "ZoneID_MunicipaliteID";
					/// <summary>
					/// Returns 250
					/// </summary>
					public const System.Int32 ColumnIndex = 250;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ZoneID_Description via shared members
				/// </summary>
				public sealed class Column_ZoneID_Description {

					/// <summary>
					/// Returns "ZoneID_Description"
					/// </summary>
					public const System.String ColumnName = "ZoneID_Description";
					/// <summary>
					/// Returns 251
					/// </summary>
					public const System.Int32 ColumnIndex = 251;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ZoneID_Actif via shared members
				/// </summary>
				public sealed class Column_ZoneID_Actif {

					/// <summary>
					/// Returns "ZoneID_Actif"
					/// </summary>
					public const System.String ColumnName = "ZoneID_Actif";
					/// <summary>
					/// Returns 252
					/// </summary>
					public const System.Int32 ColumnIndex = 252;

				}

			}
		}

		/// <summary>
		/// This class allows to easily retrieve the name or index of all the fields
		/// of the resulset #2 existing in the Dataset or the SqlDatReader returned by
		/// the Execute method of the 'spS_Lot_Full' class.
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

