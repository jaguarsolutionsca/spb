using System;

namespace Gestion_Paie.DataClasses.Parameters {

	/// <summary>
	/// This class allows a developer to specify the parameters expected by the
	/// stored procedure 'spS_Livraison_Full'. It allows also to specify specific connection
	/// information such as the ConnectionString to be use, the command time-out and so forth.
	/// </summary>
	[Serializable()]
	public sealed class spS_Livraison_Full : MarshalByRefObject, IDisposable, IParameter {

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
		/// Initializes a new instance of the spS_Livraison_Full class. If you use this constructor version,
		/// not assigning parameter values implies using the parameter default values.
		/// </summary>
		public spS_Livraison_Full() : this(true) {

		}

		/// <summary>
		/// Initializes a new instance of the spS_Livraison_Full class.
		/// </summary>
		/// <param name="useDefaultValue">If True, this parameter indicates that "not assigning parameter values" implies "using the parameter default values". If False, this parameter indicates that "not assigning parameter values" implies "using the SQL Server Null value".</param>
		public spS_Livraison_Full(bool useDefaultValue) {

			this.useDefaultValue = useDefaultValue;

			this.internal_Param_ID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ContratID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_UniteMesureID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_EssenceID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_DroitCoupeID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_EntentePaiementID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_TransporteurID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Annee_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Periode_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Producteur1_FactureID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Producteur2_FactureID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Transporteur_FactureID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Usine_FactureID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_LotID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ZoneID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_MunicipaliteID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ChargeurID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Chargeur_FactureID_UseDefaultValue = this.useDefaultValue;
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
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'spS_Livraison_Full'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

						throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "spS_Livraison_Full", CurrentRevision, OriginalRevision, System.Environment.NewLine));
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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'spS_Livraison_Full'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlConnection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "spS_Livraison_Full", CurrentRevision, OriginalRevision, System.Environment.NewLine));
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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'spS_Livraison_Full'";
				sqlCommand.Transaction = sqlTransaction;

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlTransaction.Connection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "spS_Livraison_Full", CurrentRevision, OriginalRevision, System.Environment.NewLine));
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
				this.internal_Param_ContratID = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_UniteMesureID = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_EssenceID = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_DroitCoupeID = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_EntentePaiementID = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_TransporteurID = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_Annee = System.Data.SqlTypes.SqlInt32.Null;
				this.internal_Param_Periode = System.Data.SqlTypes.SqlInt32.Null;
				this.internal_Param_Producteur1_FactureID = System.Data.SqlTypes.SqlInt32.Null;
				this.internal_Param_Producteur2_FactureID = System.Data.SqlTypes.SqlInt32.Null;
				this.internal_Param_Transporteur_FactureID = System.Data.SqlTypes.SqlInt32.Null;
				this.internal_Param_Usine_FactureID = System.Data.SqlTypes.SqlInt32.Null;
				this.internal_Param_LotID = System.Data.SqlTypes.SqlInt32.Null;
				this.internal_Param_ZoneID = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_MunicipaliteID = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_ChargeurID = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_Chargeur_FactureID = System.Data.SqlTypes.SqlInt32.Null;
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
		~spS_Livraison_Full() {

			Dispose(false);
		}

		/// <summary>
		/// Returns the stored procedure name for which this class was built, i.e. 'spS_Livraison_Full'.
		/// </summary>
		public string StoredProcedureName {

			get {

				return("spS_Livraison_Full");
			}
		}

		private System.Data.SqlTypes.SqlInt32 internal_Param_RETURN_VALUE;

		private System.Data.SqlTypes.SqlInt32 internal_Param_ID;
		internal bool internal_Param_ID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_ContratID;
		internal bool internal_Param_ContratID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_UniteMesureID;
		internal bool internal_Param_UniteMesureID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_EssenceID;
		internal bool internal_Param_EssenceID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_DroitCoupeID;
		internal bool internal_Param_DroitCoupeID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_EntentePaiementID;
		internal bool internal_Param_EntentePaiementID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_TransporteurID;
		internal bool internal_Param_TransporteurID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlInt32 internal_Param_Annee;
		internal bool internal_Param_Annee_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlInt32 internal_Param_Periode;
		internal bool internal_Param_Periode_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlInt32 internal_Param_Producteur1_FactureID;
		internal bool internal_Param_Producteur1_FactureID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlInt32 internal_Param_Producteur2_FactureID;
		internal bool internal_Param_Producteur2_FactureID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlInt32 internal_Param_Transporteur_FactureID;
		internal bool internal_Param_Transporteur_FactureID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlInt32 internal_Param_Usine_FactureID;
		internal bool internal_Param_Usine_FactureID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlInt32 internal_Param_LotID;
		internal bool internal_Param_LotID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_ZoneID;
		internal bool internal_Param_ZoneID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_MunicipaliteID;
		internal bool internal_Param_MunicipaliteID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_ChargeurID;
		internal bool internal_Param_ChargeurID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlInt32 internal_Param_Chargeur_FactureID;
		internal bool internal_Param_Chargeur_FactureID_UseDefaultValue = true;

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

			this.internal_Param_ContratID = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_ContratID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_UniteMesureID = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_UniteMesureID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_EssenceID = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_EssenceID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_DroitCoupeID = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_DroitCoupeID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_EntentePaiementID = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_EntentePaiementID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_TransporteurID = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_TransporteurID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Annee = System.Data.SqlTypes.SqlInt32.Null;
			this.internal_Param_Annee_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Periode = System.Data.SqlTypes.SqlInt32.Null;
			this.internal_Param_Periode_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Producteur1_FactureID = System.Data.SqlTypes.SqlInt32.Null;
			this.internal_Param_Producteur1_FactureID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Producteur2_FactureID = System.Data.SqlTypes.SqlInt32.Null;
			this.internal_Param_Producteur2_FactureID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Transporteur_FactureID = System.Data.SqlTypes.SqlInt32.Null;
			this.internal_Param_Transporteur_FactureID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Usine_FactureID = System.Data.SqlTypes.SqlInt32.Null;
			this.internal_Param_Usine_FactureID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_LotID = System.Data.SqlTypes.SqlInt32.Null;
			this.internal_Param_LotID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ZoneID = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_ZoneID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_MunicipaliteID = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_MunicipaliteID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ChargeurID = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_ChargeurID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Chargeur_FactureID = System.Data.SqlTypes.SqlInt32.Null;
			this.internal_Param_Chargeur_FactureID_UseDefaultValue = this.useDefaultValue;

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
		/// Sets the value of the stored procedure INPUT parameter '@ContratID'.
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
		/// the parameter default value, consider calling the Param_ContratID_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_ContratID {

			get {

				if (this.internal_Param_ContratID_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ContratID);
			}

			set {

				this.internal_Param_ContratID_UseDefaultValue = false;
				this.internal_Param_ContratID = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ContratID' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ContratID_UseDefaultValue() {

			this.internal_Param_ContratID_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@UniteMesureID'.
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
		/// the parameter default value, consider calling the Param_UniteMesureID_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_UniteMesureID {

			get {

				if (this.internal_Param_UniteMesureID_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_UniteMesureID);
			}

			set {

				this.internal_Param_UniteMesureID_UseDefaultValue = false;
				this.internal_Param_UniteMesureID = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@UniteMesureID' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_UniteMesureID_UseDefaultValue() {

			this.internal_Param_UniteMesureID_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@EssenceID'.
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
		/// the parameter default value, consider calling the Param_EssenceID_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_EssenceID {

			get {

				if (this.internal_Param_EssenceID_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_EssenceID);
			}

			set {

				this.internal_Param_EssenceID_UseDefaultValue = false;
				this.internal_Param_EssenceID = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@EssenceID' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_EssenceID_UseDefaultValue() {

			this.internal_Param_EssenceID_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@DroitCoupeID'.
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
		/// the parameter default value, consider calling the Param_DroitCoupeID_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_DroitCoupeID {

			get {

				if (this.internal_Param_DroitCoupeID_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_DroitCoupeID);
			}

			set {

				this.internal_Param_DroitCoupeID_UseDefaultValue = false;
				this.internal_Param_DroitCoupeID = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@DroitCoupeID' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_DroitCoupeID_UseDefaultValue() {

			this.internal_Param_DroitCoupeID_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@EntentePaiementID'.
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
		/// the parameter default value, consider calling the Param_EntentePaiementID_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_EntentePaiementID {

			get {

				if (this.internal_Param_EntentePaiementID_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_EntentePaiementID);
			}

			set {

				this.internal_Param_EntentePaiementID_UseDefaultValue = false;
				this.internal_Param_EntentePaiementID = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@EntentePaiementID' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_EntentePaiementID_UseDefaultValue() {

			this.internal_Param_EntentePaiementID_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@TransporteurID'.
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
		/// the parameter default value, consider calling the Param_TransporteurID_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_TransporteurID {

			get {

				if (this.internal_Param_TransporteurID_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_TransporteurID);
			}

			set {

				this.internal_Param_TransporteurID_UseDefaultValue = false;
				this.internal_Param_TransporteurID = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@TransporteurID' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_TransporteurID_UseDefaultValue() {

			this.internal_Param_TransporteurID_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Annee'.
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
		/// the parameter default value, consider calling the Param_Annee_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlInt32 Param_Annee {

			get {

				if (this.internal_Param_Annee_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Annee);
			}

			set {

				this.internal_Param_Annee_UseDefaultValue = false;
				this.internal_Param_Annee = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Annee' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Annee_UseDefaultValue() {

			this.internal_Param_Annee_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Periode'.
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
		/// the parameter default value, consider calling the Param_Periode_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlInt32 Param_Periode {

			get {

				if (this.internal_Param_Periode_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Periode);
			}

			set {

				this.internal_Param_Periode_UseDefaultValue = false;
				this.internal_Param_Periode = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Periode' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Periode_UseDefaultValue() {

			this.internal_Param_Periode_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Producteur1_FactureID'.
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
		/// the parameter default value, consider calling the Param_Producteur1_FactureID_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlInt32 Param_Producteur1_FactureID {

			get {

				if (this.internal_Param_Producteur1_FactureID_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Producteur1_FactureID);
			}

			set {

				this.internal_Param_Producteur1_FactureID_UseDefaultValue = false;
				this.internal_Param_Producteur1_FactureID = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Producteur1_FactureID' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Producteur1_FactureID_UseDefaultValue() {

			this.internal_Param_Producteur1_FactureID_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Producteur2_FactureID'.
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
		/// the parameter default value, consider calling the Param_Producteur2_FactureID_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlInt32 Param_Producteur2_FactureID {

			get {

				if (this.internal_Param_Producteur2_FactureID_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Producteur2_FactureID);
			}

			set {

				this.internal_Param_Producteur2_FactureID_UseDefaultValue = false;
				this.internal_Param_Producteur2_FactureID = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Producteur2_FactureID' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Producteur2_FactureID_UseDefaultValue() {

			this.internal_Param_Producteur2_FactureID_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Transporteur_FactureID'.
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
		/// the parameter default value, consider calling the Param_Transporteur_FactureID_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlInt32 Param_Transporteur_FactureID {

			get {

				if (this.internal_Param_Transporteur_FactureID_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Transporteur_FactureID);
			}

			set {

				this.internal_Param_Transporteur_FactureID_UseDefaultValue = false;
				this.internal_Param_Transporteur_FactureID = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Transporteur_FactureID' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Transporteur_FactureID_UseDefaultValue() {

			this.internal_Param_Transporteur_FactureID_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Usine_FactureID'.
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
		/// the parameter default value, consider calling the Param_Usine_FactureID_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlInt32 Param_Usine_FactureID {

			get {

				if (this.internal_Param_Usine_FactureID_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Usine_FactureID);
			}

			set {

				this.internal_Param_Usine_FactureID_UseDefaultValue = false;
				this.internal_Param_Usine_FactureID = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Usine_FactureID' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Usine_FactureID_UseDefaultValue() {

			this.internal_Param_Usine_FactureID_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@LotID'.
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
		/// the parameter default value, consider calling the Param_LotID_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlInt32 Param_LotID {

			get {

				if (this.internal_Param_LotID_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_LotID);
			}

			set {

				this.internal_Param_LotID_UseDefaultValue = false;
				this.internal_Param_LotID = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@LotID' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_LotID_UseDefaultValue() {

			this.internal_Param_LotID_UseDefaultValue = true;
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
		/// Sets the value of the stored procedure INPUT parameter '@ChargeurID'.
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
		/// the parameter default value, consider calling the Param_ChargeurID_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_ChargeurID {

			get {

				if (this.internal_Param_ChargeurID_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ChargeurID);
			}

			set {

				this.internal_Param_ChargeurID_UseDefaultValue = false;
				this.internal_Param_ChargeurID = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ChargeurID' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ChargeurID_UseDefaultValue() {

			this.internal_Param_ChargeurID_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Chargeur_FactureID'.
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
		/// the parameter default value, consider calling the Param_Chargeur_FactureID_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlInt32 Param_Chargeur_FactureID {

			get {

				if (this.internal_Param_Chargeur_FactureID_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Chargeur_FactureID);
			}

			set {

				this.internal_Param_Chargeur_FactureID_UseDefaultValue = false;
				this.internal_Param_Chargeur_FactureID = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Chargeur_FactureID' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Chargeur_FactureID_UseDefaultValue() {

			this.internal_Param_Chargeur_FactureID_UseDefaultValue = true;
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
	/// This class allows you to execute the 'spS_Livraison_Full' stored procedure;
	/// it gives you the ability to:
	/// <list type="bullet">
	/// <item><description>Set all the necessary parameters to execute the stored procedure</description></item>
	/// <item><description>To execute the stored procedure</description></item>
	/// <item><description>To get back after the execution the return value and all the output parameters value</description></item>
	/// </list>
	/// </summary>
	public sealed class spS_Livraison_Full : MarshalByRefObject, IDisposable {


		private bool throwExceptionOnExecute = false;

		/// <summary>
		/// Initializes a new instance of the spS_Livraison_Full class.
		/// By default, no exception will be thrown when you call the Execute method. Instead, a Boolean return status will be returned.
		/// </summary>
		public spS_Livraison_Full() : this(false) {

		}

		/// <summary>
		/// Initializes a new instance of the spS_Livraison_Full class.
		/// </summary>
		/// <param name="throwExceptionOnExecute">True if an exception has to be thrown if the Execute call fails.</param>
		public spS_Livraison_Full(bool throwExceptionOnExecute) {

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
		~spS_Livraison_Full() {

			Dispose(false);
		}

		private void ResetParameter(ref Gestion_Paie.DataClasses.Parameters.spS_Livraison_Full parameters) {

			parameters.internal_Set_RETURN_VALUE (System.Data.SqlTypes.SqlInt32.Null);
		}

		private bool InitializeConnection(ref Gestion_Paie.DataClasses.Parameters.spS_Livraison_Full parameters, out System.Data.SqlClient.SqlCommand sqlCommand, ref bool connectionMustBeClosed) {

			try {

				this.sqlConnection = null;
				sqlCommand = null;
				connectionMustBeClosed = true;

				if (parameters.ConnectionType == ConnectionType.None) {

					throw new InvalidOperationException("No connection information was supplied. Consider calling the 'SetUpConnection' method of the Gestion_Paie.DataClasses.Parameters.spS_Livraison_Full object before doing this call.");
				}

				if (parameters.ConnectionType == ConnectionType.SqlConnection && parameters.SqlConnection == null) {

					throw new InvalidOperationException("No connection information was supplied (SqlConnection == null). Consider calling the 'SetUpConnection' method of the Gestion_Paie.DataClasses.Parameters.spS_Livraison_Full object before doing this call.");
				}

				if (parameters.ConnectionType == ConnectionType.SqlTransaction && parameters.SqlTransaction== null) {

					throw new InvalidOperationException("No connection information was supplied (SqlTransaction == null). Consider calling the 'SetUpConnection' method of the Gestion_Paie.DataClasses.Parameters.spS_Livraison_Full object before doing this call.");
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

							throw new System.InvalidOperationException("No connection information was supplied (ConnectionString == \"\")! (Gestion_Paie.DataClasses.Parameters.spS_Livraison_Full)");
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
				sqlCommand.CommandText = "spS_Livraison_Full";

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

		private bool DeclareParameters(ref Gestion_Paie.DataClasses.Parameters.spS_Livraison_Full parameters, ref System.Data.SqlClient.SqlCommand sqlCommand) {

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

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ContratID", System.Data.SqlDbType.VarChar, 10);
				sqlParameter.SourceColumn = "ContratID";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ContratID_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ContratID.IsNull) {

					sqlParameter.Value = parameters.Param_ContratID;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@UniteMesureID", System.Data.SqlDbType.VarChar, 6);
				sqlParameter.SourceColumn = "UniteMesureID";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_UniteMesureID_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_UniteMesureID.IsNull) {

					sqlParameter.Value = parameters.Param_UniteMesureID;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@EssenceID", System.Data.SqlDbType.VarChar, 6);
				sqlParameter.SourceColumn = "EssenceID";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_EssenceID_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_EssenceID.IsNull) {

					sqlParameter.Value = parameters.Param_EssenceID;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@DroitCoupeID", System.Data.SqlDbType.VarChar, 15);
				sqlParameter.SourceColumn = "DroitCoupeID";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_DroitCoupeID_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_DroitCoupeID.IsNull) {

					sqlParameter.Value = parameters.Param_DroitCoupeID;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@EntentePaiementID", System.Data.SqlDbType.VarChar, 15);
				sqlParameter.SourceColumn = "EntentePaiementID";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_EntentePaiementID_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_EntentePaiementID.IsNull) {

					sqlParameter.Value = parameters.Param_EntentePaiementID;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@TransporteurID", System.Data.SqlDbType.VarChar, 15);
				sqlParameter.SourceColumn = "TransporteurID";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_TransporteurID_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_TransporteurID.IsNull) {

					sqlParameter.Value = parameters.Param_TransporteurID;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Annee", System.Data.SqlDbType.Int, 4);
				sqlParameter.SourceColumn = "Annee";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Annee_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Annee.IsNull) {

					sqlParameter.Value = parameters.Param_Annee;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Periode", System.Data.SqlDbType.Int, 4);
				sqlParameter.SourceColumn = "Periode";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Periode_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Periode.IsNull) {

					sqlParameter.Value = parameters.Param_Periode;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Producteur1_FactureID", System.Data.SqlDbType.Int, 4);
				sqlParameter.SourceColumn = "Producteur1_FactureID";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Producteur1_FactureID_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Producteur1_FactureID.IsNull) {

					sqlParameter.Value = parameters.Param_Producteur1_FactureID;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Producteur2_FactureID", System.Data.SqlDbType.Int, 4);
				sqlParameter.SourceColumn = "Producteur2_FactureID";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Producteur2_FactureID_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Producteur2_FactureID.IsNull) {

					sqlParameter.Value = parameters.Param_Producteur2_FactureID;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Transporteur_FactureID", System.Data.SqlDbType.Int, 4);
				sqlParameter.SourceColumn = "Transporteur_FactureID";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Transporteur_FactureID_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Transporteur_FactureID.IsNull) {

					sqlParameter.Value = parameters.Param_Transporteur_FactureID;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Usine_FactureID", System.Data.SqlDbType.Int, 4);
				sqlParameter.SourceColumn = "Usine_FactureID";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Usine_FactureID_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Usine_FactureID.IsNull) {

					sqlParameter.Value = parameters.Param_Usine_FactureID;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@LotID", System.Data.SqlDbType.Int, 4);
				sqlParameter.SourceColumn = "LotID";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_LotID_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_LotID.IsNull) {

					sqlParameter.Value = parameters.Param_LotID;
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

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ChargeurID", System.Data.SqlDbType.VarChar, 15);
				sqlParameter.SourceColumn = "ChargeurID";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ChargeurID_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ChargeurID.IsNull) {

					sqlParameter.Value = parameters.Param_ChargeurID;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Chargeur_FactureID", System.Data.SqlDbType.Int, 4);
				sqlParameter.SourceColumn = "Chargeur_FactureID";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Chargeur_FactureID_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Chargeur_FactureID.IsNull) {

					sqlParameter.Value = parameters.Param_Chargeur_FactureID;
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

		private bool RetrieveParameters(ref Gestion_Paie.DataClasses.Parameters.spS_Livraison_Full parameters, ref System.Data.SqlClient.SqlCommand sqlCommand) {

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
		/// This method allows you to execute the [spS_Livraison_Full] stored procedure and retrieve back the data
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
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.spS_Livraison_Full parameters, out System.Data.SqlClient.SqlDataReader sqlDataReader) {

			return(Execute(ref parameters, out sqlDataReader, System.Data.CommandBehavior.Default));
		}

		/// <summary>
		/// This method allows you to execute the [spS_Livraison_Full] stored procedure and retrieve back the data
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
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.spS_Livraison_Full parameters, out System.Data.SqlClient.SqlDataReader sqlDataReader, System.Data.CommandBehavior commandBehavior) {

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
		/// This method allows you to execute the [spS_Livraison_Full] stored procedure and retrieve back the data
		/// populated in a DataSet (System.Data.DataSet).
		/// </summary>
		/// <param name="parameters">
		/// Contains all the necessary information to execute correctly the stored procedure, i.e. 
		/// the database connection to use and all the necessary input parameters to be supplied
		/// for this stored procedure execution. After the execution, this object will allow you
		/// to retrieve back the stored procedure return value and all the output parameters.
		/// </param>
		/// <param name="dataset">
		/// Will be populated with the data after execution. The table based name used will be: 'spS_Livraison_Full'.
		/// </param>
		/// <returns>True if the call was successful. Otherwise, it returns False.</returns>
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.spS_Livraison_Full parameters, ref System.Data.DataSet dataset) {

			return(Execute(ref parameters, ref dataset, "spS_Livraison_Full", -1, -1));
		}

		/// <summary>
		/// This method allows you to execute the [spS_Livraison_Full] stored procedure and retrieve back the data
		/// populated in a DataSet (System.Data.DataSet).
		/// </summary>
		/// <param name="parameters">
		/// Contains all the necessary information to execute correctly the stored procedure, i.e. 
		/// the database connection to use and all the necessary input parameters to be supplied
		/// for this stored procedure execution. After the execution, this object will allow you
		/// to retrieve back the stored procedure return value and all the output parameters.
		/// </param>
		/// <param name="dataset">
		/// Will be populated with the data after execution. The table based name used will be: 'spS_Livraison_Full'.
		/// </param>
		/// <param name="startRecord">The zero-based record number to start with.</param>
		/// <param name="maxRecords">The maximum number of records to retrieve.</param>
		/// <returns>True if the call was successful. Otherwise, it returns False.</returns>
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.spS_Livraison_Full parameters, ref System.Data.DataSet dataset, int startRecord, int maxRecords) {

			return(Execute(ref parameters, ref dataset, "spS_Livraison_Full", startRecord, maxRecords));
		}

		/// <summary>
		/// This method allows you to execute the [spS_Livraison_Full] stored procedure and retrieve back the data
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
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.spS_Livraison_Full parameters, ref System.Data.DataSet dataset, string tableName) {

			return(Execute(ref parameters, ref dataset, tableName, -1, -1));
		}

		/// <summary>
		/// This method allows you to execute the [spS_Livraison_Full] stored procedure and retrieve back the data
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
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.spS_Livraison_Full parameters, ref System.Data.DataSet dataset, string tableName, int startRecord, int maxRecords) {

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
				dataset.Tables[tableName].Columns["DateLivraison"].Caption = "DateLivraison (update this label in the \"Olymars/ColumnLabel\" extended property of the \"DateLivraison\" column)";
				dataset.Tables[tableName].Columns["DatePaye"].Caption = "DatePaye (update this label in the \"Olymars/ColumnLabel\" extended property of the \"DatePaye\" column)";
				dataset.Tables[tableName].Columns["ContratID"].Caption = "ContratID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ContratID\" column)";
				dataset.Tables[tableName].Columns["UniteMesureID"].Caption = "UniteMesureID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"UniteMesureID\" column)";
				dataset.Tables[tableName].Columns["EssenceID"].Caption = "EssenceID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"EssenceID\" column)";
				dataset.Tables[tableName].Columns["Sciage"].Caption = "Sciage (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Sciage\" column)";
				dataset.Tables[tableName].Columns["NumeroFactureUsine"].Caption = "NumeroFactureUsine (update this label in the \"Olymars/ColumnLabel\" extended property of the \"NumeroFactureUsine\" column)";
				dataset.Tables[tableName].Columns["DroitCoupeID"].Caption = "DroitCoupeID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"DroitCoupeID\" column)";
				dataset.Tables[tableName].Columns["EntentePaiementID"].Caption = "EntentePaiementID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"EntentePaiementID\" column)";
				dataset.Tables[tableName].Columns["TransporteurID"].Caption = "TransporteurID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"TransporteurID\" column)";
				dataset.Tables[tableName].Columns["VR"].Caption = "VR (update this label in the \"Olymars/ColumnLabel\" extended property of the \"VR\" column)";
				dataset.Tables[tableName].Columns["MasseLimite"].Caption = "MasseLimite (update this label in the \"Olymars/ColumnLabel\" extended property of the \"MasseLimite\" column)";
				dataset.Tables[tableName].Columns["VolumeBrut"].Caption = "VolumeBrut (update this label in the \"Olymars/ColumnLabel\" extended property of the \"VolumeBrut\" column)";
				dataset.Tables[tableName].Columns["VolumeTare"].Caption = "VolumeTare (update this label in the \"Olymars/ColumnLabel\" extended property of the \"VolumeTare\" column)";
				dataset.Tables[tableName].Columns["VolumeTransporte"].Caption = "VolumeTransporte (update this label in the \"Olymars/ColumnLabel\" extended property of the \"VolumeTransporte\" column)";
				dataset.Tables[tableName].Columns["VolumeSurcharge"].Caption = "VolumeSurcharge (update this label in the \"Olymars/ColumnLabel\" extended property of the \"VolumeSurcharge\" column)";
				dataset.Tables[tableName].Columns["VolumeAPayer"].Caption = "VolumeAPayer (update this label in the \"Olymars/ColumnLabel\" extended property of the \"VolumeAPayer\" column)";
				dataset.Tables[tableName].Columns["Annee"].Caption = "Annee (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Annee\" column)";
				dataset.Tables[tableName].Columns["Periode"].Caption = "Periode (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Periode\" column)";
				dataset.Tables[tableName].Columns["DateCalcul"].Caption = "DateCalcul (update this label in the \"Olymars/ColumnLabel\" extended property of the \"DateCalcul\" column)";
				dataset.Tables[tableName].Columns["Taux_Transporteur"].Caption = "Taux_Transporteur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Taux_Transporteur\" column)";
				dataset.Tables[tableName].Columns["Montant_Transporteur"].Caption = "Montant_Transporteur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Montant_Transporteur\" column)";
				dataset.Tables[tableName].Columns["Montant_Usine"].Caption = "Montant_Usine (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Montant_Usine\" column)";
				dataset.Tables[tableName].Columns["Montant_Producteur1"].Caption = "Montant_Producteur1 (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Montant_Producteur1\" column)";
				dataset.Tables[tableName].Columns["Montant_Producteur2"].Caption = "Montant_Producteur2 (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Montant_Producteur2\" column)";
				dataset.Tables[tableName].Columns["Montant_Preleve_Plan_Conjoint"].Caption = "Montant_Preleve_Plan_Conjoint (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Montant_Preleve_Plan_Conjoint\" column)";
				dataset.Tables[tableName].Columns["Montant_Preleve_Fond_Roulement"].Caption = "Montant_Preleve_Fond_Roulement (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Montant_Preleve_Fond_Roulement\" column)";
				dataset.Tables[tableName].Columns["Montant_Preleve_Fond_Forestier"].Caption = "Montant_Preleve_Fond_Forestier (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Montant_Preleve_Fond_Forestier\" column)";
				dataset.Tables[tableName].Columns["Montant_Preleve_Divers"].Caption = "Montant_Preleve_Divers (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Montant_Preleve_Divers\" column)";
				dataset.Tables[tableName].Columns["Montant_Surcharge"].Caption = "Montant_Surcharge (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Montant_Surcharge\" column)";
				dataset.Tables[tableName].Columns["Montant_MiseEnCommun"].Caption = "Montant_MiseEnCommun (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Montant_MiseEnCommun\" column)";
				dataset.Tables[tableName].Columns["Facture"].Caption = "Facture (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Facture\" column)";
				dataset.Tables[tableName].Columns["Producteur1_FactureID"].Caption = "Producteur1_FactureID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Producteur1_FactureID\" column)";
				dataset.Tables[tableName].Columns["Producteur2_FactureID"].Caption = "Producteur2_FactureID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Producteur2_FactureID\" column)";
				dataset.Tables[tableName].Columns["Transporteur_FactureID"].Caption = "Transporteur_FactureID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Transporteur_FactureID\" column)";
				dataset.Tables[tableName].Columns["Usine_FactureID"].Caption = "Usine_FactureID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Usine_FactureID\" column)";
				dataset.Tables[tableName].Columns["ErreurCalcul"].Caption = "ErreurCalcul (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ErreurCalcul\" column)";
				dataset.Tables[tableName].Columns["ErreurDescription"].Caption = "ErreurDescription (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ErreurDescription\" column)";
				dataset.Tables[tableName].Columns["LotID"].Caption = "LotID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"LotID\" column)";
				dataset.Tables[tableName].Columns["Taux_Transporteur_Override"].Caption = "Taux_Transporteur_Override (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Taux_Transporteur_Override\" column)";
				dataset.Tables[tableName].Columns["PaieTransporteur"].Caption = "PaieTransporteur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"PaieTransporteur\" column)";
				dataset.Tables[tableName].Columns["VolumeSurcharge_Override"].Caption = "VolumeSurcharge_Override (update this label in the \"Olymars/ColumnLabel\" extended property of the \"VolumeSurcharge_Override\" column)";
				dataset.Tables[tableName].Columns["SurchargeManuel"].Caption = "SurchargeManuel (update this label in the \"Olymars/ColumnLabel\" extended property of the \"SurchargeManuel\" column)";
				dataset.Tables[tableName].Columns["Code"].Caption = "Code (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Code\" column)";
				dataset.Tables[tableName].Columns["NombrePermis"].Caption = "NombrePermis (update this label in the \"Olymars/ColumnLabel\" extended property of the \"NombrePermis\" column)";
				dataset.Tables[tableName].Columns["ZoneID"].Caption = "ZoneID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ZoneID\" column)";
				dataset.Tables[tableName].Columns["MunicipaliteID"].Caption = "MunicipaliteID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"MunicipaliteID\" column)";
				dataset.Tables[tableName].Columns["ChargeurID"].Caption = "ChargeurID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ChargeurID\" column)";
				dataset.Tables[tableName].Columns["Montant_Chargeur"].Caption = "Montant_Chargeur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Montant_Chargeur\" column)";
				dataset.Tables[tableName].Columns["Frais_ChargeurAuProducteur"].Caption = "Frais_ChargeurAuProducteur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Frais_ChargeurAuProducteur\" column)";
				dataset.Tables[tableName].Columns["Frais_ChargeurAuTransporteur"].Caption = "Frais_ChargeurAuTransporteur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Frais_ChargeurAuTransporteur\" column)";
				dataset.Tables[tableName].Columns["Frais_AutresAuProducteur"].Caption = "Frais_AutresAuProducteur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Frais_AutresAuProducteur\" column)";
				dataset.Tables[tableName].Columns["Frais_AutresAuProducteurDescription"].Caption = "Frais_AutresAuProducteurDescription (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Frais_AutresAuProducteurDescription\" column)";
				dataset.Tables[tableName].Columns["Frais_AutresAuProducteurTransportSciage"].Caption = "Frais_AutresAuProducteurTransportSciage (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Frais_AutresAuProducteurTransportSciage\" column)";
				dataset.Tables[tableName].Columns["Frais_AutresAuTransporteur"].Caption = "Frais_AutresAuTransporteur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Frais_AutresAuTransporteur\" column)";
				dataset.Tables[tableName].Columns["Frais_AutresAuTransporteurDescription"].Caption = "Frais_AutresAuTransporteurDescription (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Frais_AutresAuTransporteurDescription\" column)";
				dataset.Tables[tableName].Columns["Frais_CompensationDeDeplacement"].Caption = "Frais_CompensationDeDeplacement (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Frais_CompensationDeDeplacement\" column)";
				dataset.Tables[tableName].Columns["Chargeur_FactureID"].Caption = "Chargeur_FactureID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Chargeur_FactureID\" column)";
				dataset.Tables[tableName].Columns["Commentaires_Producteur"].Caption = "Commentaires_Producteur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Commentaires_Producteur\" column)";
				dataset.Tables[tableName].Columns["Commentaires_Transporteur"].Caption = "Commentaires_Transporteur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Commentaires_Transporteur\" column)";
				dataset.Tables[tableName].Columns["Commentaires_Chargeur"].Caption = "Commentaires_Chargeur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Commentaires_Chargeur\" column)";
				dataset.Tables[tableName].Columns["TauxChargeurAuProducteur"].Caption = "TauxChargeurAuProducteur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"TauxChargeurAuProducteur\" column)";
				dataset.Tables[tableName].Columns["TauxChargeurAuTransporteur"].Caption = "TauxChargeurAuTransporteur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"TauxChargeurAuTransporteur\" column)";
				dataset.Tables[tableName].Columns["Frais_AutresRevenusTransporteur"].Caption = "Frais_AutresRevenusTransporteur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Frais_AutresRevenusTransporteur\" column)";
				dataset.Tables[tableName].Columns["Frais_AutresRevenusTransporteurDescription"].Caption = "Frais_AutresRevenusTransporteurDescription (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Frais_AutresRevenusTransporteurDescription\" column)";
				dataset.Tables[tableName].Columns["Frais_AutresRevenusProducteur"].Caption = "Frais_AutresRevenusProducteur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Frais_AutresRevenusProducteur\" column)";
				dataset.Tables[tableName].Columns["Frais_AutresRevenusProducteurDescription"].Caption = "Frais_AutresRevenusProducteurDescription (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Frais_AutresRevenusProducteurDescription\" column)";
				dataset.Tables[tableName].Columns["Montant_SurchargeProducteur"].Caption = "Montant_SurchargeProducteur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Montant_SurchargeProducteur\" column)";
				dataset.Tables[tableName].Columns["KgVert_Brut"].Caption = "KgVert_Brut (update this label in the \"Olymars/ColumnLabel\" extended property of the \"KgVert_Brut\" column)";
				dataset.Tables[tableName].Columns["KgVert_Tare"].Caption = "KgVert_Tare (update this label in the \"Olymars/ColumnLabel\" extended property of the \"KgVert_Tare\" column)";
				dataset.Tables[tableName].Columns["KgVert_Net"].Caption = "KgVert_Net (update this label in the \"Olymars/ColumnLabel\" extended property of the \"KgVert_Net\" column)";
				dataset.Tables[tableName].Columns["KgVert_Rejets"].Caption = "KgVert_Rejets (update this label in the \"Olymars/ColumnLabel\" extended property of the \"KgVert_Rejets\" column)";
				dataset.Tables[tableName].Columns["KgVert_Paye"].Caption = "KgVert_Paye (update this label in the \"Olymars/ColumnLabel\" extended property of the \"KgVert_Paye\" column)";
				dataset.Tables[tableName].Columns["Pourcent_Sec_Producteur"].Caption = "Pourcent_Sec_Producteur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Pourcent_Sec_Producteur\" column)";
				dataset.Tables[tableName].Columns["Pourcent_Sec_Producteur_Override"].Caption = "Pourcent_Sec_Producteur_Override (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Pourcent_Sec_Producteur_Override\" column)";
				dataset.Tables[tableName].Columns["TMA_Producteur"].Caption = "TMA_Producteur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"TMA_Producteur\" column)";
				dataset.Tables[tableName].Columns["Pourcent_Sec_Transport"].Caption = "Pourcent_Sec_Transport (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Pourcent_Sec_Transport\" column)";
				dataset.Tables[tableName].Columns["Pourcent_Sec_Transport_Override"].Caption = "Pourcent_Sec_Transport_Override (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Pourcent_Sec_Transport_Override\" column)";
				dataset.Tables[tableName].Columns["TMA_Transport"].Caption = "TMA_Transport (update this label in the \"Olymars/ColumnLabel\" extended property of the \"TMA_Transport\" column)";
				dataset.Tables[tableName].Columns["IsTMA"].Caption = "IsTMA (update this label in the \"Olymars/ColumnLabel\" extended property of the \"IsTMA\" column)";
				dataset.Tables[tableName].Columns["SuspendrePaiement"].Caption = "SuspendrePaiement (update this label in the \"Olymars/ColumnLabel\" extended property of the \"SuspendrePaiement\" column)";
				dataset.Tables[tableName].Columns["BonCommande"].Caption = "BonCommande (update this label in the \"Olymars/ColumnLabel\" extended property of the \"BonCommande\" column)";
				dataset.Tables[tableName].Columns["ContratID_ID"].Caption = "ID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ID\" column)";
				dataset.Tables[tableName].Columns["ContratID_Description"].Caption = "Description (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Description\" column)";
				dataset.Tables[tableName].Columns["ContratID_UsineID"].Caption = "UsineID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"UsineID\" column)";
				dataset.Tables[tableName].Columns["ContratID_Annee"].Caption = "Annee (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Annee\" column)";
				dataset.Tables[tableName].Columns["ContratID_Date_debut"].Caption = "Date_debut (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Date_debut\" column)";
				dataset.Tables[tableName].Columns["ContratID_Date_fin"].Caption = "Date_fin (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Date_fin\" column)";
				dataset.Tables[tableName].Columns["ContratID_Actif"].Caption = "Actif (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Actif\" column)";
				dataset.Tables[tableName].Columns["ContratID_PaieTransporteur"].Caption = "PaieTransporteur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"PaieTransporteur\" column)";
				dataset.Tables[tableName].Columns["ContratID_Taux_Surcharge"].Caption = "Taux_Surcharge (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Taux_Surcharge\" column)";
				dataset.Tables[tableName].Columns["ContratID_SurchargeManuel"].Caption = "SurchargeManuel (update this label in the \"Olymars/ColumnLabel\" extended property of the \"SurchargeManuel\" column)";
				dataset.Tables[tableName].Columns["ContratID_TxTransSameProd"].Caption = "TxTransSameProd (update this label in the \"Olymars/ColumnLabel\" extended property of the \"TxTransSameProd\" column)";
				dataset.Tables[tableName].Columns["UniteMesureID_ID"].Caption = "ID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ID\" column)";
				dataset.Tables[tableName].Columns["UniteMesureID_Description"].Caption = "Description (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Description\" column)";
				dataset.Tables[tableName].Columns["UniteMesureID_Nb_decimale"].Caption = "Nb_decimale (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Nb_decimale\" column)";
				dataset.Tables[tableName].Columns["UniteMesureID_Actif"].Caption = "Actif (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Actif\" column)";
				dataset.Tables[tableName].Columns["UniteMesureID_UseMontant"].Caption = "UseMontant (update this label in the \"Olymars/ColumnLabel\" extended property of the \"UseMontant\" column)";
				dataset.Tables[tableName].Columns["UniteMesureID_Montant_Preleve_plan_conjoint"].Caption = "Montant_Preleve_plan_conjoint (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Montant_Preleve_plan_conjoint\" column)";
				dataset.Tables[tableName].Columns["UniteMesureID_Montant_Preleve_fond_roulement"].Caption = "Montant_Preleve_fond_roulement (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Montant_Preleve_fond_roulement\" column)";
				dataset.Tables[tableName].Columns["UniteMesureID_Montant_Preleve_fond_forestier"].Caption = "Montant_Preleve_fond_forestier (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Montant_Preleve_fond_forestier\" column)";
				dataset.Tables[tableName].Columns["UniteMesureID_Montant_Preleve_divers"].Caption = "Montant_Preleve_divers (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Montant_Preleve_divers\" column)";
				dataset.Tables[tableName].Columns["UniteMesureID_Pourc_Preleve_plan_conjoint"].Caption = "Pourc_Preleve_plan_conjoint (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Pourc_Preleve_plan_conjoint\" column)";
				dataset.Tables[tableName].Columns["UniteMesureID_Pourc_Preleve_fond_roulement"].Caption = "Pourc_Preleve_fond_roulement (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Pourc_Preleve_fond_roulement\" column)";
				dataset.Tables[tableName].Columns["UniteMesureID_Pourc_Preleve_fond_forestier"].Caption = "Pourc_Preleve_fond_forestier (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Pourc_Preleve_fond_forestier\" column)";
				dataset.Tables[tableName].Columns["UniteMesureID_Pourc_Preleve_divers"].Caption = "Pourc_Preleve_divers (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Pourc_Preleve_divers\" column)";
				dataset.Tables[tableName].Columns["EssenceID_ID"].Caption = "ID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ID\" column)";
				dataset.Tables[tableName].Columns["EssenceID_Description"].Caption = "Description (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Description\" column)";
				dataset.Tables[tableName].Columns["EssenceID_RegroupementID"].Caption = "RegroupementID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"RegroupementID\" column)";
				dataset.Tables[tableName].Columns["EssenceID_ContingentID"].Caption = "ContingentID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ContingentID\" column)";
				dataset.Tables[tableName].Columns["EssenceID_RepartitionID"].Caption = "RepartitionID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"RepartitionID\" column)";
				dataset.Tables[tableName].Columns["EssenceID_Actif"].Caption = "Actif (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Actif\" column)";
				dataset.Tables[tableName].Columns["DroitCoupeID_ID"].Caption = "ID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ID\" column)";
				dataset.Tables[tableName].Columns["DroitCoupeID_CleTri"].Caption = "CleTri (update this label in the \"Olymars/ColumnLabel\" extended property of the \"CleTri\" column)";
				dataset.Tables[tableName].Columns["DroitCoupeID_Nom"].Caption = "Nom (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Nom\" column)";
				dataset.Tables[tableName].Columns["DroitCoupeID_AuSoinsDe"].Caption = "AuSoinsDe (update this label in the \"Olymars/ColumnLabel\" extended property of the \"AuSoinsDe\" column)";
				dataset.Tables[tableName].Columns["DroitCoupeID_Rue"].Caption = "Rue (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Rue\" column)";
				dataset.Tables[tableName].Columns["DroitCoupeID_Ville"].Caption = "Ville (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Ville\" column)";
				dataset.Tables[tableName].Columns["DroitCoupeID_PaysID"].Caption = "PaysID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"PaysID\" column)";
				dataset.Tables[tableName].Columns["DroitCoupeID_Code_postal"].Caption = "Code_postal (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Code_postal\" column)";
				dataset.Tables[tableName].Columns["DroitCoupeID_Telephone"].Caption = "Telephone (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone\" column)";
				dataset.Tables[tableName].Columns["DroitCoupeID_Telephone_Poste"].Caption = "Telephone_Poste (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone_Poste\" column)";
				dataset.Tables[tableName].Columns["DroitCoupeID_Telecopieur"].Caption = "Telecopieur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telecopieur\" column)";
				dataset.Tables[tableName].Columns["DroitCoupeID_Telephone2"].Caption = "Telephone2 (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone2\" column)";
				dataset.Tables[tableName].Columns["DroitCoupeID_Telephone2_Desc"].Caption = "Telephone2_Desc (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone2_Desc\" column)";
				dataset.Tables[tableName].Columns["DroitCoupeID_Telephone2_Poste"].Caption = "Telephone2_Poste (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone2_Poste\" column)";
				dataset.Tables[tableName].Columns["DroitCoupeID_Telephone3"].Caption = "Telephone3 (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone3\" column)";
				dataset.Tables[tableName].Columns["DroitCoupeID_Telephone3_Desc"].Caption = "Telephone3_Desc (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone3_Desc\" column)";
				dataset.Tables[tableName].Columns["DroitCoupeID_Telephone3_Poste"].Caption = "Telephone3_Poste (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone3_Poste\" column)";
				dataset.Tables[tableName].Columns["DroitCoupeID_No_membre"].Caption = "No_membre (update this label in the \"Olymars/ColumnLabel\" extended property of the \"No_membre\" column)";
				dataset.Tables[tableName].Columns["DroitCoupeID_Resident"].Caption = "Resident (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Resident\" column)";
				dataset.Tables[tableName].Columns["DroitCoupeID_Email"].Caption = "Email (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Email\" column)";
				dataset.Tables[tableName].Columns["DroitCoupeID_WWW"].Caption = "WWW (update this label in the \"Olymars/ColumnLabel\" extended property of the \"WWW\" column)";
				dataset.Tables[tableName].Columns["DroitCoupeID_Commentaires"].Caption = "Commentaires (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Commentaires\" column)";
				dataset.Tables[tableName].Columns["DroitCoupeID_AfficherCommentaires"].Caption = "AfficherCommentaires (update this label in the \"Olymars/ColumnLabel\" extended property of the \"AfficherCommentaires\" column)";
				dataset.Tables[tableName].Columns["DroitCoupeID_DepotDirect"].Caption = "DepotDirect (update this label in the \"Olymars/ColumnLabel\" extended property of the \"DepotDirect\" column)";
				dataset.Tables[tableName].Columns["DroitCoupeID_InstitutionBanquaireID"].Caption = "InstitutionBanquaireID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"InstitutionBanquaireID\" column)";
				dataset.Tables[tableName].Columns["DroitCoupeID_Banque_transit"].Caption = "Banque_transit (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Banque_transit\" column)";
				dataset.Tables[tableName].Columns["DroitCoupeID_Banque_folio"].Caption = "Banque_folio (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Banque_folio\" column)";
				dataset.Tables[tableName].Columns["DroitCoupeID_No_TPS"].Caption = "No_TPS (update this label in the \"Olymars/ColumnLabel\" extended property of the \"No_TPS\" column)";
				dataset.Tables[tableName].Columns["DroitCoupeID_No_TVQ"].Caption = "No_TVQ (update this label in the \"Olymars/ColumnLabel\" extended property of the \"No_TVQ\" column)";
				dataset.Tables[tableName].Columns["DroitCoupeID_PayerA"].Caption = "PayerA (update this label in the \"Olymars/ColumnLabel\" extended property of the \"PayerA\" column)";
				dataset.Tables[tableName].Columns["DroitCoupeID_PayerAID"].Caption = "PayerAID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"PayerAID\" column)";
				dataset.Tables[tableName].Columns["DroitCoupeID_Statut"].Caption = "Statut (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Statut\" column)";
				dataset.Tables[tableName].Columns["DroitCoupeID_Rep_Nom"].Caption = "Rep_Nom (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Rep_Nom\" column)";
				dataset.Tables[tableName].Columns["DroitCoupeID_Rep_Telephone"].Caption = "Rep_Telephone (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Rep_Telephone\" column)";
				dataset.Tables[tableName].Columns["DroitCoupeID_Rep_Telephone_Poste"].Caption = "Rep_Telephone_Poste (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Rep_Telephone_Poste\" column)";
				dataset.Tables[tableName].Columns["DroitCoupeID_Rep_Email"].Caption = "Rep_Email (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Rep_Email\" column)";
				dataset.Tables[tableName].Columns["DroitCoupeID_EnAnglais"].Caption = "EnAnglais (update this label in the \"Olymars/ColumnLabel\" extended property of the \"EnAnglais\" column)";
				dataset.Tables[tableName].Columns["DroitCoupeID_Actif"].Caption = "Actif (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Actif\" column)";
				dataset.Tables[tableName].Columns["DroitCoupeID_MRCProducteurID"].Caption = "MRCProducteurID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"MRCProducteurID\" column)";
				dataset.Tables[tableName].Columns["DroitCoupeID_PaiementManuel"].Caption = "PaiementManuel (update this label in the \"Olymars/ColumnLabel\" extended property of the \"PaiementManuel\" column)";
				dataset.Tables[tableName].Columns["DroitCoupeID_Journal"].Caption = "Journal (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Journal\" column)";
				dataset.Tables[tableName].Columns["DroitCoupeID_RecoitTPS"].Caption = "RecoitTPS (update this label in the \"Olymars/ColumnLabel\" extended property of the \"RecoitTPS\" column)";
				dataset.Tables[tableName].Columns["DroitCoupeID_RecoitTVQ"].Caption = "RecoitTVQ (update this label in the \"Olymars/ColumnLabel\" extended property of the \"RecoitTVQ\" column)";
				dataset.Tables[tableName].Columns["DroitCoupeID_ModifierTrigger"].Caption = "ModifierTrigger (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ModifierTrigger\" column)";
				dataset.Tables[tableName].Columns["DroitCoupeID_IsProducteur"].Caption = "IsProducteur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"IsProducteur\" column)";
				dataset.Tables[tableName].Columns["DroitCoupeID_IsTransporteur"].Caption = "IsTransporteur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"IsTransporteur\" column)";
				dataset.Tables[tableName].Columns["DroitCoupeID_IsChargeur"].Caption = "IsChargeur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"IsChargeur\" column)";
				dataset.Tables[tableName].Columns["DroitCoupeID_IsAutre"].Caption = "IsAutre (update this label in the \"Olymars/ColumnLabel\" extended property of the \"IsAutre\" column)";
				dataset.Tables[tableName].Columns["DroitCoupeID_AfficherCommentairesSurPermit"].Caption = "AfficherCommentairesSurPermit (update this label in the \"Olymars/ColumnLabel\" extended property of the \"AfficherCommentairesSurPermit\" column)";
				dataset.Tables[tableName].Columns["DroitCoupeID_PasEmissionPermis"].Caption = "PasEmissionPermis (update this label in the \"Olymars/ColumnLabel\" extended property of the \"PasEmissionPermis\" column)";
				dataset.Tables[tableName].Columns["DroitCoupeID_Generique"].Caption = "Generique (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Generique\" column)";
				dataset.Tables[tableName].Columns["DroitCoupeID_Membre_OGC"].Caption = "Membre_OGC (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Membre_OGC\" column)";
				dataset.Tables[tableName].Columns["DroitCoupeID_InscritTPS"].Caption = "InscritTPS (update this label in the \"Olymars/ColumnLabel\" extended property of the \"InscritTPS\" column)";
				dataset.Tables[tableName].Columns["DroitCoupeID_InscritTVQ"].Caption = "InscritTVQ (update this label in the \"Olymars/ColumnLabel\" extended property of the \"InscritTVQ\" column)";
				dataset.Tables[tableName].Columns["DroitCoupeID_IsOGC"].Caption = "IsOGC (update this label in the \"Olymars/ColumnLabel\" extended property of the \"IsOGC\" column)";
				dataset.Tables[tableName].Columns["EntentePaiementID_ID"].Caption = "ID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ID\" column)";
				dataset.Tables[tableName].Columns["EntentePaiementID_CleTri"].Caption = "CleTri (update this label in the \"Olymars/ColumnLabel\" extended property of the \"CleTri\" column)";
				dataset.Tables[tableName].Columns["EntentePaiementID_Nom"].Caption = "Nom (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Nom\" column)";
				dataset.Tables[tableName].Columns["EntentePaiementID_AuSoinsDe"].Caption = "AuSoinsDe (update this label in the \"Olymars/ColumnLabel\" extended property of the \"AuSoinsDe\" column)";
				dataset.Tables[tableName].Columns["EntentePaiementID_Rue"].Caption = "Rue (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Rue\" column)";
				dataset.Tables[tableName].Columns["EntentePaiementID_Ville"].Caption = "Ville (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Ville\" column)";
				dataset.Tables[tableName].Columns["EntentePaiementID_PaysID"].Caption = "PaysID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"PaysID\" column)";
				dataset.Tables[tableName].Columns["EntentePaiementID_Code_postal"].Caption = "Code_postal (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Code_postal\" column)";
				dataset.Tables[tableName].Columns["EntentePaiementID_Telephone"].Caption = "Telephone (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone\" column)";
				dataset.Tables[tableName].Columns["EntentePaiementID_Telephone_Poste"].Caption = "Telephone_Poste (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone_Poste\" column)";
				dataset.Tables[tableName].Columns["EntentePaiementID_Telecopieur"].Caption = "Telecopieur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telecopieur\" column)";
				dataset.Tables[tableName].Columns["EntentePaiementID_Telephone2"].Caption = "Telephone2 (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone2\" column)";
				dataset.Tables[tableName].Columns["EntentePaiementID_Telephone2_Desc"].Caption = "Telephone2_Desc (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone2_Desc\" column)";
				dataset.Tables[tableName].Columns["EntentePaiementID_Telephone2_Poste"].Caption = "Telephone2_Poste (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone2_Poste\" column)";
				dataset.Tables[tableName].Columns["EntentePaiementID_Telephone3"].Caption = "Telephone3 (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone3\" column)";
				dataset.Tables[tableName].Columns["EntentePaiementID_Telephone3_Desc"].Caption = "Telephone3_Desc (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone3_Desc\" column)";
				dataset.Tables[tableName].Columns["EntentePaiementID_Telephone3_Poste"].Caption = "Telephone3_Poste (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone3_Poste\" column)";
				dataset.Tables[tableName].Columns["EntentePaiementID_No_membre"].Caption = "No_membre (update this label in the \"Olymars/ColumnLabel\" extended property of the \"No_membre\" column)";
				dataset.Tables[tableName].Columns["EntentePaiementID_Resident"].Caption = "Resident (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Resident\" column)";
				dataset.Tables[tableName].Columns["EntentePaiementID_Email"].Caption = "Email (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Email\" column)";
				dataset.Tables[tableName].Columns["EntentePaiementID_WWW"].Caption = "WWW (update this label in the \"Olymars/ColumnLabel\" extended property of the \"WWW\" column)";
				dataset.Tables[tableName].Columns["EntentePaiementID_Commentaires"].Caption = "Commentaires (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Commentaires\" column)";
				dataset.Tables[tableName].Columns["EntentePaiementID_AfficherCommentaires"].Caption = "AfficherCommentaires (update this label in the \"Olymars/ColumnLabel\" extended property of the \"AfficherCommentaires\" column)";
				dataset.Tables[tableName].Columns["EntentePaiementID_DepotDirect"].Caption = "DepotDirect (update this label in the \"Olymars/ColumnLabel\" extended property of the \"DepotDirect\" column)";
				dataset.Tables[tableName].Columns["EntentePaiementID_InstitutionBanquaireID"].Caption = "InstitutionBanquaireID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"InstitutionBanquaireID\" column)";
				dataset.Tables[tableName].Columns["EntentePaiementID_Banque_transit"].Caption = "Banque_transit (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Banque_transit\" column)";
				dataset.Tables[tableName].Columns["EntentePaiementID_Banque_folio"].Caption = "Banque_folio (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Banque_folio\" column)";
				dataset.Tables[tableName].Columns["EntentePaiementID_No_TPS"].Caption = "No_TPS (update this label in the \"Olymars/ColumnLabel\" extended property of the \"No_TPS\" column)";
				dataset.Tables[tableName].Columns["EntentePaiementID_No_TVQ"].Caption = "No_TVQ (update this label in the \"Olymars/ColumnLabel\" extended property of the \"No_TVQ\" column)";
				dataset.Tables[tableName].Columns["EntentePaiementID_PayerA"].Caption = "PayerA (update this label in the \"Olymars/ColumnLabel\" extended property of the \"PayerA\" column)";
				dataset.Tables[tableName].Columns["EntentePaiementID_PayerAID"].Caption = "PayerAID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"PayerAID\" column)";
				dataset.Tables[tableName].Columns["EntentePaiementID_Statut"].Caption = "Statut (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Statut\" column)";
				dataset.Tables[tableName].Columns["EntentePaiementID_Rep_Nom"].Caption = "Rep_Nom (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Rep_Nom\" column)";
				dataset.Tables[tableName].Columns["EntentePaiementID_Rep_Telephone"].Caption = "Rep_Telephone (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Rep_Telephone\" column)";
				dataset.Tables[tableName].Columns["EntentePaiementID_Rep_Telephone_Poste"].Caption = "Rep_Telephone_Poste (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Rep_Telephone_Poste\" column)";
				dataset.Tables[tableName].Columns["EntentePaiementID_Rep_Email"].Caption = "Rep_Email (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Rep_Email\" column)";
				dataset.Tables[tableName].Columns["EntentePaiementID_EnAnglais"].Caption = "EnAnglais (update this label in the \"Olymars/ColumnLabel\" extended property of the \"EnAnglais\" column)";
				dataset.Tables[tableName].Columns["EntentePaiementID_Actif"].Caption = "Actif (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Actif\" column)";
				dataset.Tables[tableName].Columns["EntentePaiementID_MRCProducteurID"].Caption = "MRCProducteurID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"MRCProducteurID\" column)";
				dataset.Tables[tableName].Columns["EntentePaiementID_PaiementManuel"].Caption = "PaiementManuel (update this label in the \"Olymars/ColumnLabel\" extended property of the \"PaiementManuel\" column)";
				dataset.Tables[tableName].Columns["EntentePaiementID_Journal"].Caption = "Journal (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Journal\" column)";
				dataset.Tables[tableName].Columns["EntentePaiementID_RecoitTPS"].Caption = "RecoitTPS (update this label in the \"Olymars/ColumnLabel\" extended property of the \"RecoitTPS\" column)";
				dataset.Tables[tableName].Columns["EntentePaiementID_RecoitTVQ"].Caption = "RecoitTVQ (update this label in the \"Olymars/ColumnLabel\" extended property of the \"RecoitTVQ\" column)";
				dataset.Tables[tableName].Columns["EntentePaiementID_ModifierTrigger"].Caption = "ModifierTrigger (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ModifierTrigger\" column)";
				dataset.Tables[tableName].Columns["EntentePaiementID_IsProducteur"].Caption = "IsProducteur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"IsProducteur\" column)";
				dataset.Tables[tableName].Columns["EntentePaiementID_IsTransporteur"].Caption = "IsTransporteur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"IsTransporteur\" column)";
				dataset.Tables[tableName].Columns["EntentePaiementID_IsChargeur"].Caption = "IsChargeur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"IsChargeur\" column)";
				dataset.Tables[tableName].Columns["EntentePaiementID_IsAutre"].Caption = "IsAutre (update this label in the \"Olymars/ColumnLabel\" extended property of the \"IsAutre\" column)";
				dataset.Tables[tableName].Columns["EntentePaiementID_AfficherCommentairesSurPermit"].Caption = "AfficherCommentairesSurPermit (update this label in the \"Olymars/ColumnLabel\" extended property of the \"AfficherCommentairesSurPermit\" column)";
				dataset.Tables[tableName].Columns["EntentePaiementID_PasEmissionPermis"].Caption = "PasEmissionPermis (update this label in the \"Olymars/ColumnLabel\" extended property of the \"PasEmissionPermis\" column)";
				dataset.Tables[tableName].Columns["EntentePaiementID_Generique"].Caption = "Generique (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Generique\" column)";
				dataset.Tables[tableName].Columns["EntentePaiementID_Membre_OGC"].Caption = "Membre_OGC (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Membre_OGC\" column)";
				dataset.Tables[tableName].Columns["EntentePaiementID_InscritTPS"].Caption = "InscritTPS (update this label in the \"Olymars/ColumnLabel\" extended property of the \"InscritTPS\" column)";
				dataset.Tables[tableName].Columns["EntentePaiementID_InscritTVQ"].Caption = "InscritTVQ (update this label in the \"Olymars/ColumnLabel\" extended property of the \"InscritTVQ\" column)";
				dataset.Tables[tableName].Columns["EntentePaiementID_IsOGC"].Caption = "IsOGC (update this label in the \"Olymars/ColumnLabel\" extended property of the \"IsOGC\" column)";
				dataset.Tables[tableName].Columns["TransporteurID_ID"].Caption = "ID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ID\" column)";
				dataset.Tables[tableName].Columns["TransporteurID_CleTri"].Caption = "CleTri (update this label in the \"Olymars/ColumnLabel\" extended property of the \"CleTri\" column)";
				dataset.Tables[tableName].Columns["TransporteurID_Nom"].Caption = "Nom (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Nom\" column)";
				dataset.Tables[tableName].Columns["TransporteurID_AuSoinsDe"].Caption = "AuSoinsDe (update this label in the \"Olymars/ColumnLabel\" extended property of the \"AuSoinsDe\" column)";
				dataset.Tables[tableName].Columns["TransporteurID_Rue"].Caption = "Rue (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Rue\" column)";
				dataset.Tables[tableName].Columns["TransporteurID_Ville"].Caption = "Ville (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Ville\" column)";
				dataset.Tables[tableName].Columns["TransporteurID_PaysID"].Caption = "PaysID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"PaysID\" column)";
				dataset.Tables[tableName].Columns["TransporteurID_Code_postal"].Caption = "Code_postal (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Code_postal\" column)";
				dataset.Tables[tableName].Columns["TransporteurID_Telephone"].Caption = "Telephone (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone\" column)";
				dataset.Tables[tableName].Columns["TransporteurID_Telephone_Poste"].Caption = "Telephone_Poste (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone_Poste\" column)";
				dataset.Tables[tableName].Columns["TransporteurID_Telecopieur"].Caption = "Telecopieur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telecopieur\" column)";
				dataset.Tables[tableName].Columns["TransporteurID_Telephone2"].Caption = "Telephone2 (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone2\" column)";
				dataset.Tables[tableName].Columns["TransporteurID_Telephone2_Desc"].Caption = "Telephone2_Desc (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone2_Desc\" column)";
				dataset.Tables[tableName].Columns["TransporteurID_Telephone2_Poste"].Caption = "Telephone2_Poste (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone2_Poste\" column)";
				dataset.Tables[tableName].Columns["TransporteurID_Telephone3"].Caption = "Telephone3 (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone3\" column)";
				dataset.Tables[tableName].Columns["TransporteurID_Telephone3_Desc"].Caption = "Telephone3_Desc (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone3_Desc\" column)";
				dataset.Tables[tableName].Columns["TransporteurID_Telephone3_Poste"].Caption = "Telephone3_Poste (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone3_Poste\" column)";
				dataset.Tables[tableName].Columns["TransporteurID_No_membre"].Caption = "No_membre (update this label in the \"Olymars/ColumnLabel\" extended property of the \"No_membre\" column)";
				dataset.Tables[tableName].Columns["TransporteurID_Resident"].Caption = "Resident (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Resident\" column)";
				dataset.Tables[tableName].Columns["TransporteurID_Email"].Caption = "Email (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Email\" column)";
				dataset.Tables[tableName].Columns["TransporteurID_WWW"].Caption = "WWW (update this label in the \"Olymars/ColumnLabel\" extended property of the \"WWW\" column)";
				dataset.Tables[tableName].Columns["TransporteurID_Commentaires"].Caption = "Commentaires (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Commentaires\" column)";
				dataset.Tables[tableName].Columns["TransporteurID_AfficherCommentaires"].Caption = "AfficherCommentaires (update this label in the \"Olymars/ColumnLabel\" extended property of the \"AfficherCommentaires\" column)";
				dataset.Tables[tableName].Columns["TransporteurID_DepotDirect"].Caption = "DepotDirect (update this label in the \"Olymars/ColumnLabel\" extended property of the \"DepotDirect\" column)";
				dataset.Tables[tableName].Columns["TransporteurID_InstitutionBanquaireID"].Caption = "InstitutionBanquaireID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"InstitutionBanquaireID\" column)";
				dataset.Tables[tableName].Columns["TransporteurID_Banque_transit"].Caption = "Banque_transit (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Banque_transit\" column)";
				dataset.Tables[tableName].Columns["TransporteurID_Banque_folio"].Caption = "Banque_folio (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Banque_folio\" column)";
				dataset.Tables[tableName].Columns["TransporteurID_No_TPS"].Caption = "No_TPS (update this label in the \"Olymars/ColumnLabel\" extended property of the \"No_TPS\" column)";
				dataset.Tables[tableName].Columns["TransporteurID_No_TVQ"].Caption = "No_TVQ (update this label in the \"Olymars/ColumnLabel\" extended property of the \"No_TVQ\" column)";
				dataset.Tables[tableName].Columns["TransporteurID_PayerA"].Caption = "PayerA (update this label in the \"Olymars/ColumnLabel\" extended property of the \"PayerA\" column)";
				dataset.Tables[tableName].Columns["TransporteurID_PayerAID"].Caption = "PayerAID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"PayerAID\" column)";
				dataset.Tables[tableName].Columns["TransporteurID_Statut"].Caption = "Statut (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Statut\" column)";
				dataset.Tables[tableName].Columns["TransporteurID_Rep_Nom"].Caption = "Rep_Nom (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Rep_Nom\" column)";
				dataset.Tables[tableName].Columns["TransporteurID_Rep_Telephone"].Caption = "Rep_Telephone (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Rep_Telephone\" column)";
				dataset.Tables[tableName].Columns["TransporteurID_Rep_Telephone_Poste"].Caption = "Rep_Telephone_Poste (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Rep_Telephone_Poste\" column)";
				dataset.Tables[tableName].Columns["TransporteurID_Rep_Email"].Caption = "Rep_Email (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Rep_Email\" column)";
				dataset.Tables[tableName].Columns["TransporteurID_EnAnglais"].Caption = "EnAnglais (update this label in the \"Olymars/ColumnLabel\" extended property of the \"EnAnglais\" column)";
				dataset.Tables[tableName].Columns["TransporteurID_Actif"].Caption = "Actif (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Actif\" column)";
				dataset.Tables[tableName].Columns["TransporteurID_MRCProducteurID"].Caption = "MRCProducteurID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"MRCProducteurID\" column)";
				dataset.Tables[tableName].Columns["TransporteurID_PaiementManuel"].Caption = "PaiementManuel (update this label in the \"Olymars/ColumnLabel\" extended property of the \"PaiementManuel\" column)";
				dataset.Tables[tableName].Columns["TransporteurID_Journal"].Caption = "Journal (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Journal\" column)";
				dataset.Tables[tableName].Columns["TransporteurID_RecoitTPS"].Caption = "RecoitTPS (update this label in the \"Olymars/ColumnLabel\" extended property of the \"RecoitTPS\" column)";
				dataset.Tables[tableName].Columns["TransporteurID_RecoitTVQ"].Caption = "RecoitTVQ (update this label in the \"Olymars/ColumnLabel\" extended property of the \"RecoitTVQ\" column)";
				dataset.Tables[tableName].Columns["TransporteurID_ModifierTrigger"].Caption = "ModifierTrigger (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ModifierTrigger\" column)";
				dataset.Tables[tableName].Columns["TransporteurID_IsProducteur"].Caption = "IsProducteur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"IsProducteur\" column)";
				dataset.Tables[tableName].Columns["TransporteurID_IsTransporteur"].Caption = "IsTransporteur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"IsTransporteur\" column)";
				dataset.Tables[tableName].Columns["TransporteurID_IsChargeur"].Caption = "IsChargeur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"IsChargeur\" column)";
				dataset.Tables[tableName].Columns["TransporteurID_IsAutre"].Caption = "IsAutre (update this label in the \"Olymars/ColumnLabel\" extended property of the \"IsAutre\" column)";
				dataset.Tables[tableName].Columns["TransporteurID_AfficherCommentairesSurPermit"].Caption = "AfficherCommentairesSurPermit (update this label in the \"Olymars/ColumnLabel\" extended property of the \"AfficherCommentairesSurPermit\" column)";
				dataset.Tables[tableName].Columns["TransporteurID_PasEmissionPermis"].Caption = "PasEmissionPermis (update this label in the \"Olymars/ColumnLabel\" extended property of the \"PasEmissionPermis\" column)";
				dataset.Tables[tableName].Columns["TransporteurID_Generique"].Caption = "Generique (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Generique\" column)";
				dataset.Tables[tableName].Columns["TransporteurID_Membre_OGC"].Caption = "Membre_OGC (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Membre_OGC\" column)";
				dataset.Tables[tableName].Columns["TransporteurID_InscritTPS"].Caption = "InscritTPS (update this label in the \"Olymars/ColumnLabel\" extended property of the \"InscritTPS\" column)";
				dataset.Tables[tableName].Columns["TransporteurID_InscritTVQ"].Caption = "InscritTVQ (update this label in the \"Olymars/ColumnLabel\" extended property of the \"InscritTVQ\" column)";
				dataset.Tables[tableName].Columns["TransporteurID_IsOGC"].Caption = "IsOGC (update this label in the \"Olymars/ColumnLabel\" extended property of the \"IsOGC\" column)";
				dataset.Tables[tableName].Columns["Annee_Annee"].Caption = "Annee (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Annee\" column)";
				dataset.Tables[tableName].Columns["Annee_SemaineNo"].Caption = "SemaineNo (update this label in the \"Olymars/ColumnLabel\" extended property of the \"SemaineNo\" column)";
				dataset.Tables[tableName].Columns["Annee_DateDebut"].Caption = "DateDebut (update this label in the \"Olymars/ColumnLabel\" extended property of the \"DateDebut\" column)";
				dataset.Tables[tableName].Columns["Annee_DateFin"].Caption = "DateFin (update this label in the \"Olymars/ColumnLabel\" extended property of the \"DateFin\" column)";
				dataset.Tables[tableName].Columns["Annee_PeriodeContingentement"].Caption = "PeriodeContingentement (update this label in the \"Olymars/ColumnLabel\" extended property of the \"PeriodeContingentement\" column)";
				dataset.Tables[tableName].Columns["Periode_Annee"].Caption = "Annee (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Annee\" column)";
				dataset.Tables[tableName].Columns["Periode_SemaineNo"].Caption = "SemaineNo (update this label in the \"Olymars/ColumnLabel\" extended property of the \"SemaineNo\" column)";
				dataset.Tables[tableName].Columns["Periode_DateDebut"].Caption = "DateDebut (update this label in the \"Olymars/ColumnLabel\" extended property of the \"DateDebut\" column)";
				dataset.Tables[tableName].Columns["Periode_DateFin"].Caption = "DateFin (update this label in the \"Olymars/ColumnLabel\" extended property of the \"DateFin\" column)";
				dataset.Tables[tableName].Columns["Periode_PeriodeContingentement"].Caption = "PeriodeContingentement (update this label in the \"Olymars/ColumnLabel\" extended property of the \"PeriodeContingentement\" column)";
				dataset.Tables[tableName].Columns["Producteur1_FactureID_ID"].Caption = "ID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ID\" column)";
				dataset.Tables[tableName].Columns["Producteur1_FactureID_NoFacture"].Caption = "NoFacture (update this label in the \"Olymars/ColumnLabel\" extended property of the \"NoFacture\" column)";
				dataset.Tables[tableName].Columns["Producteur1_FactureID_DateFacture"].Caption = "DateFacture (update this label in the \"Olymars/ColumnLabel\" extended property of the \"DateFacture\" column)";
				dataset.Tables[tableName].Columns["Producteur1_FactureID_Annee"].Caption = "Annee (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Annee\" column)";
				dataset.Tables[tableName].Columns["Producteur1_FactureID_TypeFactureFournisseur"].Caption = "TypeFactureFournisseur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"TypeFactureFournisseur\" column)";
				dataset.Tables[tableName].Columns["Producteur1_FactureID_TypeFacture"].Caption = "TypeFacture (update this label in the \"Olymars/ColumnLabel\" extended property of the \"TypeFacture\" column)";
				dataset.Tables[tableName].Columns["Producteur1_FactureID_TypeInvoiceAcomba"].Caption = "TypeInvoiceAcomba (update this label in the \"Olymars/ColumnLabel\" extended property of the \"TypeInvoiceAcomba\" column)";
				dataset.Tables[tableName].Columns["Producteur1_FactureID_FournisseurID"].Caption = "FournisseurID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"FournisseurID\" column)";
				dataset.Tables[tableName].Columns["Producteur1_FactureID_PayerAID"].Caption = "PayerAID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"PayerAID\" column)";
				dataset.Tables[tableName].Columns["Producteur1_FactureID_Montant_Total"].Caption = "Montant_Total (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Montant_Total\" column)";
				dataset.Tables[tableName].Columns["Producteur1_FactureID_Montant_TPS"].Caption = "Montant_TPS (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Montant_TPS\" column)";
				dataset.Tables[tableName].Columns["Producteur1_FactureID_Montant_TVQ"].Caption = "Montant_TVQ (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Montant_TVQ\" column)";
				dataset.Tables[tableName].Columns["Producteur1_FactureID_Description"].Caption = "Description (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Description\" column)";
				dataset.Tables[tableName].Columns["Producteur1_FactureID_Status"].Caption = "Status (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Status\" column)";
				dataset.Tables[tableName].Columns["Producteur1_FactureID_StatusDescription"].Caption = "StatusDescription (update this label in the \"Olymars/ColumnLabel\" extended property of the \"StatusDescription\" column)";
				dataset.Tables[tableName].Columns["Producteur1_FactureID_NumeroCheque"].Caption = "NumeroCheque (update this label in the \"Olymars/ColumnLabel\" extended property of the \"NumeroCheque\" column)";
				dataset.Tables[tableName].Columns["Producteur1_FactureID_NumeroPaiement"].Caption = "NumeroPaiement (update this label in the \"Olymars/ColumnLabel\" extended property of the \"NumeroPaiement\" column)";
				dataset.Tables[tableName].Columns["Producteur1_FactureID_NumeroPaiementUnique"].Caption = "NumeroPaiementUnique (update this label in the \"Olymars/ColumnLabel\" extended property of the \"NumeroPaiementUnique\" column)";
				dataset.Tables[tableName].Columns["Producteur1_FactureID_DateFactureAcomba"].Caption = "DateFactureAcomba (update this label in the \"Olymars/ColumnLabel\" extended property of the \"DateFactureAcomba\" column)";
				dataset.Tables[tableName].Columns["Producteur1_FactureID_DatePaiementAcomba"].Caption = "DatePaiementAcomba (update this label in the \"Olymars/ColumnLabel\" extended property of the \"DatePaiementAcomba\" column)";
				dataset.Tables[tableName].Columns["Producteur2_FactureID_ID"].Caption = "ID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ID\" column)";
				dataset.Tables[tableName].Columns["Producteur2_FactureID_NoFacture"].Caption = "NoFacture (update this label in the \"Olymars/ColumnLabel\" extended property of the \"NoFacture\" column)";
				dataset.Tables[tableName].Columns["Producteur2_FactureID_DateFacture"].Caption = "DateFacture (update this label in the \"Olymars/ColumnLabel\" extended property of the \"DateFacture\" column)";
				dataset.Tables[tableName].Columns["Producteur2_FactureID_Annee"].Caption = "Annee (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Annee\" column)";
				dataset.Tables[tableName].Columns["Producteur2_FactureID_TypeFactureFournisseur"].Caption = "TypeFactureFournisseur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"TypeFactureFournisseur\" column)";
				dataset.Tables[tableName].Columns["Producteur2_FactureID_TypeFacture"].Caption = "TypeFacture (update this label in the \"Olymars/ColumnLabel\" extended property of the \"TypeFacture\" column)";
				dataset.Tables[tableName].Columns["Producteur2_FactureID_TypeInvoiceAcomba"].Caption = "TypeInvoiceAcomba (update this label in the \"Olymars/ColumnLabel\" extended property of the \"TypeInvoiceAcomba\" column)";
				dataset.Tables[tableName].Columns["Producteur2_FactureID_FournisseurID"].Caption = "FournisseurID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"FournisseurID\" column)";
				dataset.Tables[tableName].Columns["Producteur2_FactureID_PayerAID"].Caption = "PayerAID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"PayerAID\" column)";
				dataset.Tables[tableName].Columns["Producteur2_FactureID_Montant_Total"].Caption = "Montant_Total (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Montant_Total\" column)";
				dataset.Tables[tableName].Columns["Producteur2_FactureID_Montant_TPS"].Caption = "Montant_TPS (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Montant_TPS\" column)";
				dataset.Tables[tableName].Columns["Producteur2_FactureID_Montant_TVQ"].Caption = "Montant_TVQ (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Montant_TVQ\" column)";
				dataset.Tables[tableName].Columns["Producteur2_FactureID_Description"].Caption = "Description (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Description\" column)";
				dataset.Tables[tableName].Columns["Producteur2_FactureID_Status"].Caption = "Status (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Status\" column)";
				dataset.Tables[tableName].Columns["Producteur2_FactureID_StatusDescription"].Caption = "StatusDescription (update this label in the \"Olymars/ColumnLabel\" extended property of the \"StatusDescription\" column)";
				dataset.Tables[tableName].Columns["Producteur2_FactureID_NumeroCheque"].Caption = "NumeroCheque (update this label in the \"Olymars/ColumnLabel\" extended property of the \"NumeroCheque\" column)";
				dataset.Tables[tableName].Columns["Producteur2_FactureID_NumeroPaiement"].Caption = "NumeroPaiement (update this label in the \"Olymars/ColumnLabel\" extended property of the \"NumeroPaiement\" column)";
				dataset.Tables[tableName].Columns["Producteur2_FactureID_NumeroPaiementUnique"].Caption = "NumeroPaiementUnique (update this label in the \"Olymars/ColumnLabel\" extended property of the \"NumeroPaiementUnique\" column)";
				dataset.Tables[tableName].Columns["Producteur2_FactureID_DateFactureAcomba"].Caption = "DateFactureAcomba (update this label in the \"Olymars/ColumnLabel\" extended property of the \"DateFactureAcomba\" column)";
				dataset.Tables[tableName].Columns["Producteur2_FactureID_DatePaiementAcomba"].Caption = "DatePaiementAcomba (update this label in the \"Olymars/ColumnLabel\" extended property of the \"DatePaiementAcomba\" column)";
				dataset.Tables[tableName].Columns["Transporteur_FactureID_ID"].Caption = "ID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ID\" column)";
				dataset.Tables[tableName].Columns["Transporteur_FactureID_NoFacture"].Caption = "NoFacture (update this label in the \"Olymars/ColumnLabel\" extended property of the \"NoFacture\" column)";
				dataset.Tables[tableName].Columns["Transporteur_FactureID_DateFacture"].Caption = "DateFacture (update this label in the \"Olymars/ColumnLabel\" extended property of the \"DateFacture\" column)";
				dataset.Tables[tableName].Columns["Transporteur_FactureID_Annee"].Caption = "Annee (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Annee\" column)";
				dataset.Tables[tableName].Columns["Transporteur_FactureID_TypeFactureFournisseur"].Caption = "TypeFactureFournisseur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"TypeFactureFournisseur\" column)";
				dataset.Tables[tableName].Columns["Transporteur_FactureID_TypeFacture"].Caption = "TypeFacture (update this label in the \"Olymars/ColumnLabel\" extended property of the \"TypeFacture\" column)";
				dataset.Tables[tableName].Columns["Transporteur_FactureID_TypeInvoiceAcomba"].Caption = "TypeInvoiceAcomba (update this label in the \"Olymars/ColumnLabel\" extended property of the \"TypeInvoiceAcomba\" column)";
				dataset.Tables[tableName].Columns["Transporteur_FactureID_FournisseurID"].Caption = "FournisseurID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"FournisseurID\" column)";
				dataset.Tables[tableName].Columns["Transporteur_FactureID_PayerAID"].Caption = "PayerAID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"PayerAID\" column)";
				dataset.Tables[tableName].Columns["Transporteur_FactureID_Montant_Total"].Caption = "Montant_Total (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Montant_Total\" column)";
				dataset.Tables[tableName].Columns["Transporteur_FactureID_Montant_TPS"].Caption = "Montant_TPS (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Montant_TPS\" column)";
				dataset.Tables[tableName].Columns["Transporteur_FactureID_Montant_TVQ"].Caption = "Montant_TVQ (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Montant_TVQ\" column)";
				dataset.Tables[tableName].Columns["Transporteur_FactureID_Description"].Caption = "Description (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Description\" column)";
				dataset.Tables[tableName].Columns["Transporteur_FactureID_Status"].Caption = "Status (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Status\" column)";
				dataset.Tables[tableName].Columns["Transporteur_FactureID_StatusDescription"].Caption = "StatusDescription (update this label in the \"Olymars/ColumnLabel\" extended property of the \"StatusDescription\" column)";
				dataset.Tables[tableName].Columns["Transporteur_FactureID_NumeroCheque"].Caption = "NumeroCheque (update this label in the \"Olymars/ColumnLabel\" extended property of the \"NumeroCheque\" column)";
				dataset.Tables[tableName].Columns["Transporteur_FactureID_NumeroPaiement"].Caption = "NumeroPaiement (update this label in the \"Olymars/ColumnLabel\" extended property of the \"NumeroPaiement\" column)";
				dataset.Tables[tableName].Columns["Transporteur_FactureID_NumeroPaiementUnique"].Caption = "NumeroPaiementUnique (update this label in the \"Olymars/ColumnLabel\" extended property of the \"NumeroPaiementUnique\" column)";
				dataset.Tables[tableName].Columns["Transporteur_FactureID_DateFactureAcomba"].Caption = "DateFactureAcomba (update this label in the \"Olymars/ColumnLabel\" extended property of the \"DateFactureAcomba\" column)";
				dataset.Tables[tableName].Columns["Transporteur_FactureID_DatePaiementAcomba"].Caption = "DatePaiementAcomba (update this label in the \"Olymars/ColumnLabel\" extended property of the \"DatePaiementAcomba\" column)";
				dataset.Tables[tableName].Columns["Usine_FactureID_ID"].Caption = "ID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ID\" column)";
				dataset.Tables[tableName].Columns["Usine_FactureID_NoFacture"].Caption = "NoFacture (update this label in the \"Olymars/ColumnLabel\" extended property of the \"NoFacture\" column)";
				dataset.Tables[tableName].Columns["Usine_FactureID_DateFacture"].Caption = "DateFacture (update this label in the \"Olymars/ColumnLabel\" extended property of the \"DateFacture\" column)";
				dataset.Tables[tableName].Columns["Usine_FactureID_Annee"].Caption = "Annee (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Annee\" column)";
				dataset.Tables[tableName].Columns["Usine_FactureID_TypeFacture"].Caption = "TypeFacture (update this label in the \"Olymars/ColumnLabel\" extended property of the \"TypeFacture\" column)";
				dataset.Tables[tableName].Columns["Usine_FactureID_TypeInvoiceClientAcomba"].Caption = "TypeInvoiceClientAcomba (update this label in the \"Olymars/ColumnLabel\" extended property of the \"TypeInvoiceClientAcomba\" column)";
				dataset.Tables[tableName].Columns["Usine_FactureID_ClientID"].Caption = "ClientID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ClientID\" column)";
				dataset.Tables[tableName].Columns["Usine_FactureID_PayerAID"].Caption = "PayerAID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"PayerAID\" column)";
				dataset.Tables[tableName].Columns["Usine_FactureID_Montant_Total"].Caption = "Montant_Total (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Montant_Total\" column)";
				dataset.Tables[tableName].Columns["Usine_FactureID_Montant_TPS"].Caption = "Montant_TPS (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Montant_TPS\" column)";
				dataset.Tables[tableName].Columns["Usine_FactureID_Montant_TVQ"].Caption = "Montant_TVQ (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Montant_TVQ\" column)";
				dataset.Tables[tableName].Columns["Usine_FactureID_Description"].Caption = "Description (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Description\" column)";
				dataset.Tables[tableName].Columns["Usine_FactureID_Status"].Caption = "Status (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Status\" column)";
				dataset.Tables[tableName].Columns["Usine_FactureID_StatusDescription"].Caption = "StatusDescription (update this label in the \"Olymars/ColumnLabel\" extended property of the \"StatusDescription\" column)";
				dataset.Tables[tableName].Columns["Usine_FactureID_DateFactureAcomba"].Caption = "DateFactureAcomba (update this label in the \"Olymars/ColumnLabel\" extended property of the \"DateFactureAcomba\" column)";
				dataset.Tables[tableName].Columns["LotID_CantonID"].Caption = "CantonID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"CantonID\" column)";
				dataset.Tables[tableName].Columns["LotID_Rang"].Caption = "Rang (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Rang\" column)";
				dataset.Tables[tableName].Columns["LotID_Lot"].Caption = "Lot (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Lot\" column)";
				dataset.Tables[tableName].Columns["LotID_MunicipaliteID"].Caption = "MunicipaliteID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"MunicipaliteID\" column)";
				dataset.Tables[tableName].Columns["LotID_Superficie_total"].Caption = "Superficie_total (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Superficie_total\" column)";
				dataset.Tables[tableName].Columns["LotID_Superficie_boisee"].Caption = "Superficie_boisee (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Superficie_boisee\" column)";
				dataset.Tables[tableName].Columns["LotID_ProprietaireID"].Caption = "ProprietaireID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ProprietaireID\" column)";
				dataset.Tables[tableName].Columns["LotID_ContingentID"].Caption = "ContingentID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ContingentID\" column)";
				dataset.Tables[tableName].Columns["LotID_Contingent_Date"].Caption = "Contingent_Date (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Contingent_Date\" column)";
				dataset.Tables[tableName].Columns["LotID_Droit_coupeID"].Caption = "Droit_coupeID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Droit_coupeID\" column)";
				dataset.Tables[tableName].Columns["LotID_Droit_coupe_Date"].Caption = "Droit_coupe_Date (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Droit_coupe_Date\" column)";
				dataset.Tables[tableName].Columns["LotID_Entente_paiementID"].Caption = "Entente_paiementID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Entente_paiementID\" column)";
				dataset.Tables[tableName].Columns["LotID_Entente_paiement_Date"].Caption = "Entente_paiement_Date (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Entente_paiement_Date\" column)";
				dataset.Tables[tableName].Columns["LotID_Actif"].Caption = "Actif (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Actif\" column)";
				dataset.Tables[tableName].Columns["LotID_ID"].Caption = "ID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ID\" column)";
				dataset.Tables[tableName].Columns["LotID_Sequence"].Caption = "Sequence (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Sequence\" column)";
				dataset.Tables[tableName].Columns["LotID_Partie"].Caption = "Partie (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Partie\" column)";
				dataset.Tables[tableName].Columns["LotID_Matricule"].Caption = "Matricule (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Matricule\" column)";
				dataset.Tables[tableName].Columns["LotID_ZoneID"].Caption = "ZoneID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ZoneID\" column)";
				dataset.Tables[tableName].Columns["LotID_Secteur"].Caption = "Secteur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Secteur\" column)";
				dataset.Tables[tableName].Columns["LotID_Cadastre"].Caption = "Cadastre (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Cadastre\" column)";
				dataset.Tables[tableName].Columns["LotID_Reforme"].Caption = "Reforme (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Reforme\" column)";
				dataset.Tables[tableName].Columns["LotID_LotsComplementaires"].Caption = "LotsComplementaires (update this label in the \"Olymars/ColumnLabel\" extended property of the \"LotsComplementaires\" column)";
				dataset.Tables[tableName].Columns["LotID_Certifie"].Caption = "Certifie (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Certifie\" column)";
				dataset.Tables[tableName].Columns["LotID_NumeroCertification"].Caption = "NumeroCertification (update this label in the \"Olymars/ColumnLabel\" extended property of the \"NumeroCertification\" column)";
				dataset.Tables[tableName].Columns["LotID_OGC"].Caption = "OGC (update this label in the \"Olymars/ColumnLabel\" extended property of the \"OGC\" column)";
				dataset.Tables[tableName].Columns["ZoneID_ID"].Caption = "ID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ID\" column)";
				dataset.Tables[tableName].Columns["ZoneID_MunicipaliteID"].Caption = "MunicipaliteID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"MunicipaliteID\" column)";
				dataset.Tables[tableName].Columns["ZoneID_Description"].Caption = "Description (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Description\" column)";
				dataset.Tables[tableName].Columns["ZoneID_Actif"].Caption = "Actif (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Actif\" column)";
				dataset.Tables[tableName].Columns["MunicipaliteID_ID"].Caption = "ID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ID\" column)";
				dataset.Tables[tableName].Columns["MunicipaliteID_MunicipaliteID"].Caption = "MunicipaliteID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"MunicipaliteID\" column)";
				dataset.Tables[tableName].Columns["MunicipaliteID_Description"].Caption = "Description (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Description\" column)";
				dataset.Tables[tableName].Columns["MunicipaliteID_Actif"].Caption = "Actif (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Actif\" column)";
				dataset.Tables[tableName].Columns["ChargeurID_ID"].Caption = "ID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ID\" column)";
				dataset.Tables[tableName].Columns["ChargeurID_CleTri"].Caption = "CleTri (update this label in the \"Olymars/ColumnLabel\" extended property of the \"CleTri\" column)";
				dataset.Tables[tableName].Columns["ChargeurID_Nom"].Caption = "Nom (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Nom\" column)";
				dataset.Tables[tableName].Columns["ChargeurID_AuSoinsDe"].Caption = "AuSoinsDe (update this label in the \"Olymars/ColumnLabel\" extended property of the \"AuSoinsDe\" column)";
				dataset.Tables[tableName].Columns["ChargeurID_Rue"].Caption = "Rue (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Rue\" column)";
				dataset.Tables[tableName].Columns["ChargeurID_Ville"].Caption = "Ville (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Ville\" column)";
				dataset.Tables[tableName].Columns["ChargeurID_PaysID"].Caption = "PaysID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"PaysID\" column)";
				dataset.Tables[tableName].Columns["ChargeurID_Code_postal"].Caption = "Code_postal (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Code_postal\" column)";
				dataset.Tables[tableName].Columns["ChargeurID_Telephone"].Caption = "Telephone (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone\" column)";
				dataset.Tables[tableName].Columns["ChargeurID_Telephone_Poste"].Caption = "Telephone_Poste (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone_Poste\" column)";
				dataset.Tables[tableName].Columns["ChargeurID_Telecopieur"].Caption = "Telecopieur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telecopieur\" column)";
				dataset.Tables[tableName].Columns["ChargeurID_Telephone2"].Caption = "Telephone2 (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone2\" column)";
				dataset.Tables[tableName].Columns["ChargeurID_Telephone2_Desc"].Caption = "Telephone2_Desc (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone2_Desc\" column)";
				dataset.Tables[tableName].Columns["ChargeurID_Telephone2_Poste"].Caption = "Telephone2_Poste (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone2_Poste\" column)";
				dataset.Tables[tableName].Columns["ChargeurID_Telephone3"].Caption = "Telephone3 (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone3\" column)";
				dataset.Tables[tableName].Columns["ChargeurID_Telephone3_Desc"].Caption = "Telephone3_Desc (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone3_Desc\" column)";
				dataset.Tables[tableName].Columns["ChargeurID_Telephone3_Poste"].Caption = "Telephone3_Poste (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone3_Poste\" column)";
				dataset.Tables[tableName].Columns["ChargeurID_No_membre"].Caption = "No_membre (update this label in the \"Olymars/ColumnLabel\" extended property of the \"No_membre\" column)";
				dataset.Tables[tableName].Columns["ChargeurID_Resident"].Caption = "Resident (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Resident\" column)";
				dataset.Tables[tableName].Columns["ChargeurID_Email"].Caption = "Email (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Email\" column)";
				dataset.Tables[tableName].Columns["ChargeurID_WWW"].Caption = "WWW (update this label in the \"Olymars/ColumnLabel\" extended property of the \"WWW\" column)";
				dataset.Tables[tableName].Columns["ChargeurID_Commentaires"].Caption = "Commentaires (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Commentaires\" column)";
				dataset.Tables[tableName].Columns["ChargeurID_AfficherCommentaires"].Caption = "AfficherCommentaires (update this label in the \"Olymars/ColumnLabel\" extended property of the \"AfficherCommentaires\" column)";
				dataset.Tables[tableName].Columns["ChargeurID_DepotDirect"].Caption = "DepotDirect (update this label in the \"Olymars/ColumnLabel\" extended property of the \"DepotDirect\" column)";
				dataset.Tables[tableName].Columns["ChargeurID_InstitutionBanquaireID"].Caption = "InstitutionBanquaireID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"InstitutionBanquaireID\" column)";
				dataset.Tables[tableName].Columns["ChargeurID_Banque_transit"].Caption = "Banque_transit (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Banque_transit\" column)";
				dataset.Tables[tableName].Columns["ChargeurID_Banque_folio"].Caption = "Banque_folio (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Banque_folio\" column)";
				dataset.Tables[tableName].Columns["ChargeurID_No_TPS"].Caption = "No_TPS (update this label in the \"Olymars/ColumnLabel\" extended property of the \"No_TPS\" column)";
				dataset.Tables[tableName].Columns["ChargeurID_No_TVQ"].Caption = "No_TVQ (update this label in the \"Olymars/ColumnLabel\" extended property of the \"No_TVQ\" column)";
				dataset.Tables[tableName].Columns["ChargeurID_PayerA"].Caption = "PayerA (update this label in the \"Olymars/ColumnLabel\" extended property of the \"PayerA\" column)";
				dataset.Tables[tableName].Columns["ChargeurID_PayerAID"].Caption = "PayerAID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"PayerAID\" column)";
				dataset.Tables[tableName].Columns["ChargeurID_Statut"].Caption = "Statut (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Statut\" column)";
				dataset.Tables[tableName].Columns["ChargeurID_Rep_Nom"].Caption = "Rep_Nom (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Rep_Nom\" column)";
				dataset.Tables[tableName].Columns["ChargeurID_Rep_Telephone"].Caption = "Rep_Telephone (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Rep_Telephone\" column)";
				dataset.Tables[tableName].Columns["ChargeurID_Rep_Telephone_Poste"].Caption = "Rep_Telephone_Poste (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Rep_Telephone_Poste\" column)";
				dataset.Tables[tableName].Columns["ChargeurID_Rep_Email"].Caption = "Rep_Email (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Rep_Email\" column)";
				dataset.Tables[tableName].Columns["ChargeurID_EnAnglais"].Caption = "EnAnglais (update this label in the \"Olymars/ColumnLabel\" extended property of the \"EnAnglais\" column)";
				dataset.Tables[tableName].Columns["ChargeurID_Actif"].Caption = "Actif (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Actif\" column)";
				dataset.Tables[tableName].Columns["ChargeurID_MRCProducteurID"].Caption = "MRCProducteurID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"MRCProducteurID\" column)";
				dataset.Tables[tableName].Columns["ChargeurID_PaiementManuel"].Caption = "PaiementManuel (update this label in the \"Olymars/ColumnLabel\" extended property of the \"PaiementManuel\" column)";
				dataset.Tables[tableName].Columns["ChargeurID_Journal"].Caption = "Journal (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Journal\" column)";
				dataset.Tables[tableName].Columns["ChargeurID_RecoitTPS"].Caption = "RecoitTPS (update this label in the \"Olymars/ColumnLabel\" extended property of the \"RecoitTPS\" column)";
				dataset.Tables[tableName].Columns["ChargeurID_RecoitTVQ"].Caption = "RecoitTVQ (update this label in the \"Olymars/ColumnLabel\" extended property of the \"RecoitTVQ\" column)";
				dataset.Tables[tableName].Columns["ChargeurID_ModifierTrigger"].Caption = "ModifierTrigger (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ModifierTrigger\" column)";
				dataset.Tables[tableName].Columns["ChargeurID_IsProducteur"].Caption = "IsProducteur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"IsProducteur\" column)";
				dataset.Tables[tableName].Columns["ChargeurID_IsTransporteur"].Caption = "IsTransporteur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"IsTransporteur\" column)";
				dataset.Tables[tableName].Columns["ChargeurID_IsChargeur"].Caption = "IsChargeur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"IsChargeur\" column)";
				dataset.Tables[tableName].Columns["ChargeurID_IsAutre"].Caption = "IsAutre (update this label in the \"Olymars/ColumnLabel\" extended property of the \"IsAutre\" column)";
				dataset.Tables[tableName].Columns["ChargeurID_AfficherCommentairesSurPermit"].Caption = "AfficherCommentairesSurPermit (update this label in the \"Olymars/ColumnLabel\" extended property of the \"AfficherCommentairesSurPermit\" column)";
				dataset.Tables[tableName].Columns["ChargeurID_PasEmissionPermis"].Caption = "PasEmissionPermis (update this label in the \"Olymars/ColumnLabel\" extended property of the \"PasEmissionPermis\" column)";
				dataset.Tables[tableName].Columns["ChargeurID_Generique"].Caption = "Generique (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Generique\" column)";
				dataset.Tables[tableName].Columns["ChargeurID_Membre_OGC"].Caption = "Membre_OGC (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Membre_OGC\" column)";
				dataset.Tables[tableName].Columns["ChargeurID_InscritTPS"].Caption = "InscritTPS (update this label in the \"Olymars/ColumnLabel\" extended property of the \"InscritTPS\" column)";
				dataset.Tables[tableName].Columns["ChargeurID_InscritTVQ"].Caption = "InscritTVQ (update this label in the \"Olymars/ColumnLabel\" extended property of the \"InscritTVQ\" column)";
				dataset.Tables[tableName].Columns["ChargeurID_IsOGC"].Caption = "IsOGC (update this label in the \"Olymars/ColumnLabel\" extended property of the \"IsOGC\" column)";
				dataset.Tables[tableName].Columns["Chargeur_FactureID_ID"].Caption = "ID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ID\" column)";
				dataset.Tables[tableName].Columns["Chargeur_FactureID_NoFacture"].Caption = "NoFacture (update this label in the \"Olymars/ColumnLabel\" extended property of the \"NoFacture\" column)";
				dataset.Tables[tableName].Columns["Chargeur_FactureID_DateFacture"].Caption = "DateFacture (update this label in the \"Olymars/ColumnLabel\" extended property of the \"DateFacture\" column)";
				dataset.Tables[tableName].Columns["Chargeur_FactureID_Annee"].Caption = "Annee (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Annee\" column)";
				dataset.Tables[tableName].Columns["Chargeur_FactureID_TypeFactureFournisseur"].Caption = "TypeFactureFournisseur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"TypeFactureFournisseur\" column)";
				dataset.Tables[tableName].Columns["Chargeur_FactureID_TypeFacture"].Caption = "TypeFacture (update this label in the \"Olymars/ColumnLabel\" extended property of the \"TypeFacture\" column)";
				dataset.Tables[tableName].Columns["Chargeur_FactureID_TypeInvoiceAcomba"].Caption = "TypeInvoiceAcomba (update this label in the \"Olymars/ColumnLabel\" extended property of the \"TypeInvoiceAcomba\" column)";
				dataset.Tables[tableName].Columns["Chargeur_FactureID_FournisseurID"].Caption = "FournisseurID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"FournisseurID\" column)";
				dataset.Tables[tableName].Columns["Chargeur_FactureID_PayerAID"].Caption = "PayerAID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"PayerAID\" column)";
				dataset.Tables[tableName].Columns["Chargeur_FactureID_Montant_Total"].Caption = "Montant_Total (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Montant_Total\" column)";
				dataset.Tables[tableName].Columns["Chargeur_FactureID_Montant_TPS"].Caption = "Montant_TPS (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Montant_TPS\" column)";
				dataset.Tables[tableName].Columns["Chargeur_FactureID_Montant_TVQ"].Caption = "Montant_TVQ (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Montant_TVQ\" column)";
				dataset.Tables[tableName].Columns["Chargeur_FactureID_Description"].Caption = "Description (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Description\" column)";
				dataset.Tables[tableName].Columns["Chargeur_FactureID_Status"].Caption = "Status (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Status\" column)";
				dataset.Tables[tableName].Columns["Chargeur_FactureID_StatusDescription"].Caption = "StatusDescription (update this label in the \"Olymars/ColumnLabel\" extended property of the \"StatusDescription\" column)";
				dataset.Tables[tableName].Columns["Chargeur_FactureID_NumeroCheque"].Caption = "NumeroCheque (update this label in the \"Olymars/ColumnLabel\" extended property of the \"NumeroCheque\" column)";
				dataset.Tables[tableName].Columns["Chargeur_FactureID_NumeroPaiement"].Caption = "NumeroPaiement (update this label in the \"Olymars/ColumnLabel\" extended property of the \"NumeroPaiement\" column)";
				dataset.Tables[tableName].Columns["Chargeur_FactureID_NumeroPaiementUnique"].Caption = "NumeroPaiementUnique (update this label in the \"Olymars/ColumnLabel\" extended property of the \"NumeroPaiementUnique\" column)";
				dataset.Tables[tableName].Columns["Chargeur_FactureID_DateFactureAcomba"].Caption = "DateFactureAcomba (update this label in the \"Olymars/ColumnLabel\" extended property of the \"DateFactureAcomba\" column)";
				dataset.Tables[tableName].Columns["Chargeur_FactureID_DatePaiementAcomba"].Caption = "DatePaiementAcomba (update this label in the \"Olymars/ColumnLabel\" extended property of the \"DatePaiementAcomba\" column)";

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
		/// This method allows you to execute the [spS_Livraison_Full] stored procedure and retrieve back the data
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
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.spS_Livraison_Full parameters, ref string xml) {

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
		/// This method allows you to execute the [spS_Livraison_Full] stored procedure and retrieve back the data
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
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.spS_Livraison_Full parameters, out System.Xml.XmlReader xmlReader) {

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
		/// the Execute method of the 'spS_Livraison_Full' class.
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
				/// Allows to get the Index and Name of the field DateLivraison via shared members
				/// </summary>
				public sealed class Column_DateLivraison {

					/// <summary>
					/// Returns "DateLivraison"
					/// </summary>
					public const System.String ColumnName = "DateLivraison";
					/// <summary>
					/// Returns 1
					/// </summary>
					public const System.Int32 ColumnIndex = 1;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field DatePaye via shared members
				/// </summary>
				public sealed class Column_DatePaye {

					/// <summary>
					/// Returns "DatePaye"
					/// </summary>
					public const System.String ColumnName = "DatePaye";
					/// <summary>
					/// Returns 2
					/// </summary>
					public const System.Int32 ColumnIndex = 2;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ContratID via shared members
				/// </summary>
				public sealed class Column_ContratID {

					/// <summary>
					/// Returns "ContratID"
					/// </summary>
					public const System.String ColumnName = "ContratID";
					/// <summary>
					/// Returns 3
					/// </summary>
					public const System.Int32 ColumnIndex = 3;

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
					/// Returns 4
					/// </summary>
					public const System.Int32 ColumnIndex = 4;

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
					/// Returns 5
					/// </summary>
					public const System.Int32 ColumnIndex = 5;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Sciage via shared members
				/// </summary>
				public sealed class Column_Sciage {

					/// <summary>
					/// Returns "Sciage"
					/// </summary>
					public const System.String ColumnName = "Sciage";
					/// <summary>
					/// Returns 6
					/// </summary>
					public const System.Int32 ColumnIndex = 6;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field NumeroFactureUsine via shared members
				/// </summary>
				public sealed class Column_NumeroFactureUsine {

					/// <summary>
					/// Returns "NumeroFactureUsine"
					/// </summary>
					public const System.String ColumnName = "NumeroFactureUsine";
					/// <summary>
					/// Returns 7
					/// </summary>
					public const System.Int32 ColumnIndex = 7;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field DroitCoupeID via shared members
				/// </summary>
				public sealed class Column_DroitCoupeID {

					/// <summary>
					/// Returns "DroitCoupeID"
					/// </summary>
					public const System.String ColumnName = "DroitCoupeID";
					/// <summary>
					/// Returns 8
					/// </summary>
					public const System.Int32 ColumnIndex = 8;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field EntentePaiementID via shared members
				/// </summary>
				public sealed class Column_EntentePaiementID {

					/// <summary>
					/// Returns "EntentePaiementID"
					/// </summary>
					public const System.String ColumnName = "EntentePaiementID";
					/// <summary>
					/// Returns 9
					/// </summary>
					public const System.Int32 ColumnIndex = 9;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field TransporteurID via shared members
				/// </summary>
				public sealed class Column_TransporteurID {

					/// <summary>
					/// Returns "TransporteurID"
					/// </summary>
					public const System.String ColumnName = "TransporteurID";
					/// <summary>
					/// Returns 10
					/// </summary>
					public const System.Int32 ColumnIndex = 10;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field VR via shared members
				/// </summary>
				public sealed class Column_VR {

					/// <summary>
					/// Returns "VR"
					/// </summary>
					public const System.String ColumnName = "VR";
					/// <summary>
					/// Returns 11
					/// </summary>
					public const System.Int32 ColumnIndex = 11;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field MasseLimite via shared members
				/// </summary>
				public sealed class Column_MasseLimite {

					/// <summary>
					/// Returns "MasseLimite"
					/// </summary>
					public const System.String ColumnName = "MasseLimite";
					/// <summary>
					/// Returns 12
					/// </summary>
					public const System.Int32 ColumnIndex = 12;

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
					/// Returns 13
					/// </summary>
					public const System.Int32 ColumnIndex = 13;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field VolumeTare via shared members
				/// </summary>
				public sealed class Column_VolumeTare {

					/// <summary>
					/// Returns "VolumeTare"
					/// </summary>
					public const System.String ColumnName = "VolumeTare";
					/// <summary>
					/// Returns 14
					/// </summary>
					public const System.Int32 ColumnIndex = 14;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field VolumeTransporte via shared members
				/// </summary>
				public sealed class Column_VolumeTransporte {

					/// <summary>
					/// Returns "VolumeTransporte"
					/// </summary>
					public const System.String ColumnName = "VolumeTransporte";
					/// <summary>
					/// Returns 15
					/// </summary>
					public const System.Int32 ColumnIndex = 15;

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
					/// Returns 16
					/// </summary>
					public const System.Int32 ColumnIndex = 16;

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
					/// Returns 17
					/// </summary>
					public const System.Int32 ColumnIndex = 17;

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
					/// Returns 18
					/// </summary>
					public const System.Int32 ColumnIndex = 18;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Periode via shared members
				/// </summary>
				public sealed class Column_Periode {

					/// <summary>
					/// Returns "Periode"
					/// </summary>
					public const System.String ColumnName = "Periode";
					/// <summary>
					/// Returns 19
					/// </summary>
					public const System.Int32 ColumnIndex = 19;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field DateCalcul via shared members
				/// </summary>
				public sealed class Column_DateCalcul {

					/// <summary>
					/// Returns "DateCalcul"
					/// </summary>
					public const System.String ColumnName = "DateCalcul";
					/// <summary>
					/// Returns 20
					/// </summary>
					public const System.Int32 ColumnIndex = 20;

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
					/// Returns 21
					/// </summary>
					public const System.Int32 ColumnIndex = 21;

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
					/// Returns 22
					/// </summary>
					public const System.Int32 ColumnIndex = 22;

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
					/// Returns 23
					/// </summary>
					public const System.Int32 ColumnIndex = 23;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Montant_Producteur1 via shared members
				/// </summary>
				public sealed class Column_Montant_Producteur1 {

					/// <summary>
					/// Returns "Montant_Producteur1"
					/// </summary>
					public const System.String ColumnName = "Montant_Producteur1";
					/// <summary>
					/// Returns 24
					/// </summary>
					public const System.Int32 ColumnIndex = 24;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Montant_Producteur2 via shared members
				/// </summary>
				public sealed class Column_Montant_Producteur2 {

					/// <summary>
					/// Returns "Montant_Producteur2"
					/// </summary>
					public const System.String ColumnName = "Montant_Producteur2";
					/// <summary>
					/// Returns 25
					/// </summary>
					public const System.Int32 ColumnIndex = 25;

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
					/// Returns 26
					/// </summary>
					public const System.Int32 ColumnIndex = 26;

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
					/// Returns 27
					/// </summary>
					public const System.Int32 ColumnIndex = 27;

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
					/// Returns 28
					/// </summary>
					public const System.Int32 ColumnIndex = 28;

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
					/// Returns 29
					/// </summary>
					public const System.Int32 ColumnIndex = 29;

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
					/// Returns 30
					/// </summary>
					public const System.Int32 ColumnIndex = 30;

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
					/// Returns 31
					/// </summary>
					public const System.Int32 ColumnIndex = 31;

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
					/// Returns 32
					/// </summary>
					public const System.Int32 ColumnIndex = 32;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Producteur1_FactureID via shared members
				/// </summary>
				public sealed class Column_Producteur1_FactureID {

					/// <summary>
					/// Returns "Producteur1_FactureID"
					/// </summary>
					public const System.String ColumnName = "Producteur1_FactureID";
					/// <summary>
					/// Returns 33
					/// </summary>
					public const System.Int32 ColumnIndex = 33;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Producteur2_FactureID via shared members
				/// </summary>
				public sealed class Column_Producteur2_FactureID {

					/// <summary>
					/// Returns "Producteur2_FactureID"
					/// </summary>
					public const System.String ColumnName = "Producteur2_FactureID";
					/// <summary>
					/// Returns 34
					/// </summary>
					public const System.Int32 ColumnIndex = 34;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Transporteur_FactureID via shared members
				/// </summary>
				public sealed class Column_Transporteur_FactureID {

					/// <summary>
					/// Returns "Transporteur_FactureID"
					/// </summary>
					public const System.String ColumnName = "Transporteur_FactureID";
					/// <summary>
					/// Returns 35
					/// </summary>
					public const System.Int32 ColumnIndex = 35;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Usine_FactureID via shared members
				/// </summary>
				public sealed class Column_Usine_FactureID {

					/// <summary>
					/// Returns "Usine_FactureID"
					/// </summary>
					public const System.String ColumnName = "Usine_FactureID";
					/// <summary>
					/// Returns 36
					/// </summary>
					public const System.Int32 ColumnIndex = 36;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ErreurCalcul via shared members
				/// </summary>
				public sealed class Column_ErreurCalcul {

					/// <summary>
					/// Returns "ErreurCalcul"
					/// </summary>
					public const System.String ColumnName = "ErreurCalcul";
					/// <summary>
					/// Returns 37
					/// </summary>
					public const System.Int32 ColumnIndex = 37;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ErreurDescription via shared members
				/// </summary>
				public sealed class Column_ErreurDescription {

					/// <summary>
					/// Returns "ErreurDescription"
					/// </summary>
					public const System.String ColumnName = "ErreurDescription";
					/// <summary>
					/// Returns 38
					/// </summary>
					public const System.Int32 ColumnIndex = 38;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LotID via shared members
				/// </summary>
				public sealed class Column_LotID {

					/// <summary>
					/// Returns "LotID"
					/// </summary>
					public const System.String ColumnName = "LotID";
					/// <summary>
					/// Returns 39
					/// </summary>
					public const System.Int32 ColumnIndex = 39;

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
					/// Returns 40
					/// </summary>
					public const System.Int32 ColumnIndex = 40;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field PaieTransporteur via shared members
				/// </summary>
				public sealed class Column_PaieTransporteur {

					/// <summary>
					/// Returns "PaieTransporteur"
					/// </summary>
					public const System.String ColumnName = "PaieTransporteur";
					/// <summary>
					/// Returns 41
					/// </summary>
					public const System.Int32 ColumnIndex = 41;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field VolumeSurcharge_Override via shared members
				/// </summary>
				public sealed class Column_VolumeSurcharge_Override {

					/// <summary>
					/// Returns "VolumeSurcharge_Override"
					/// </summary>
					public const System.String ColumnName = "VolumeSurcharge_Override";
					/// <summary>
					/// Returns 42
					/// </summary>
					public const System.Int32 ColumnIndex = 42;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field SurchargeManuel via shared members
				/// </summary>
				public sealed class Column_SurchargeManuel {

					/// <summary>
					/// Returns "SurchargeManuel"
					/// </summary>
					public const System.String ColumnName = "SurchargeManuel";
					/// <summary>
					/// Returns 43
					/// </summary>
					public const System.Int32 ColumnIndex = 43;

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
					/// Returns 44
					/// </summary>
					public const System.Int32 ColumnIndex = 44;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field NombrePermis via shared members
				/// </summary>
				public sealed class Column_NombrePermis {

					/// <summary>
					/// Returns "NombrePermis"
					/// </summary>
					public const System.String ColumnName = "NombrePermis";
					/// <summary>
					/// Returns 45
					/// </summary>
					public const System.Int32 ColumnIndex = 45;

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
					/// Returns 46
					/// </summary>
					public const System.Int32 ColumnIndex = 46;

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
					/// Returns 47
					/// </summary>
					public const System.Int32 ColumnIndex = 47;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ChargeurID via shared members
				/// </summary>
				public sealed class Column_ChargeurID {

					/// <summary>
					/// Returns "ChargeurID"
					/// </summary>
					public const System.String ColumnName = "ChargeurID";
					/// <summary>
					/// Returns 48
					/// </summary>
					public const System.Int32 ColumnIndex = 48;

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
					/// Returns 49
					/// </summary>
					public const System.Int32 ColumnIndex = 49;

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
					/// Returns 50
					/// </summary>
					public const System.Int32 ColumnIndex = 50;

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
					/// Returns 51
					/// </summary>
					public const System.Int32 ColumnIndex = 51;

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
					/// Returns 52
					/// </summary>
					public const System.Int32 ColumnIndex = 52;

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
					/// Returns 53
					/// </summary>
					public const System.Int32 ColumnIndex = 53;

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
					/// Returns 54
					/// </summary>
					public const System.Int32 ColumnIndex = 54;

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
					/// Returns 55
					/// </summary>
					public const System.Int32 ColumnIndex = 55;

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
					/// Returns 56
					/// </summary>
					public const System.Int32 ColumnIndex = 56;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Chargeur_FactureID via shared members
				/// </summary>
				public sealed class Column_Chargeur_FactureID {

					/// <summary>
					/// Returns "Chargeur_FactureID"
					/// </summary>
					public const System.String ColumnName = "Chargeur_FactureID";
					/// <summary>
					/// Returns 57
					/// </summary>
					public const System.Int32 ColumnIndex = 57;

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
					/// Returns 58
					/// </summary>
					public const System.Int32 ColumnIndex = 58;

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
					/// Returns 59
					/// </summary>
					public const System.Int32 ColumnIndex = 59;

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
					/// Returns 60
					/// </summary>
					public const System.Int32 ColumnIndex = 60;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field TauxChargeurAuProducteur via shared members
				/// </summary>
				public sealed class Column_TauxChargeurAuProducteur {

					/// <summary>
					/// Returns "TauxChargeurAuProducteur"
					/// </summary>
					public const System.String ColumnName = "TauxChargeurAuProducteur";
					/// <summary>
					/// Returns 61
					/// </summary>
					public const System.Int32 ColumnIndex = 61;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field TauxChargeurAuTransporteur via shared members
				/// </summary>
				public sealed class Column_TauxChargeurAuTransporteur {

					/// <summary>
					/// Returns "TauxChargeurAuTransporteur"
					/// </summary>
					public const System.String ColumnName = "TauxChargeurAuTransporteur";
					/// <summary>
					/// Returns 62
					/// </summary>
					public const System.Int32 ColumnIndex = 62;

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
					/// Returns 63
					/// </summary>
					public const System.Int32 ColumnIndex = 63;

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
					/// Returns 64
					/// </summary>
					public const System.Int32 ColumnIndex = 64;

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
					/// Returns 65
					/// </summary>
					public const System.Int32 ColumnIndex = 65;

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
					/// Returns 66
					/// </summary>
					public const System.Int32 ColumnIndex = 66;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Montant_SurchargeProducteur via shared members
				/// </summary>
				public sealed class Column_Montant_SurchargeProducteur {

					/// <summary>
					/// Returns "Montant_SurchargeProducteur"
					/// </summary>
					public const System.String ColumnName = "Montant_SurchargeProducteur";
					/// <summary>
					/// Returns 67
					/// </summary>
					public const System.Int32 ColumnIndex = 67;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field KgVert_Brut via shared members
				/// </summary>
				public sealed class Column_KgVert_Brut {

					/// <summary>
					/// Returns "KgVert_Brut"
					/// </summary>
					public const System.String ColumnName = "KgVert_Brut";
					/// <summary>
					/// Returns 68
					/// </summary>
					public const System.Int32 ColumnIndex = 68;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field KgVert_Tare via shared members
				/// </summary>
				public sealed class Column_KgVert_Tare {

					/// <summary>
					/// Returns "KgVert_Tare"
					/// </summary>
					public const System.String ColumnName = "KgVert_Tare";
					/// <summary>
					/// Returns 69
					/// </summary>
					public const System.Int32 ColumnIndex = 69;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field KgVert_Net via shared members
				/// </summary>
				public sealed class Column_KgVert_Net {

					/// <summary>
					/// Returns "KgVert_Net"
					/// </summary>
					public const System.String ColumnName = "KgVert_Net";
					/// <summary>
					/// Returns 70
					/// </summary>
					public const System.Int32 ColumnIndex = 70;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field KgVert_Rejets via shared members
				/// </summary>
				public sealed class Column_KgVert_Rejets {

					/// <summary>
					/// Returns "KgVert_Rejets"
					/// </summary>
					public const System.String ColumnName = "KgVert_Rejets";
					/// <summary>
					/// Returns 71
					/// </summary>
					public const System.Int32 ColumnIndex = 71;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field KgVert_Paye via shared members
				/// </summary>
				public sealed class Column_KgVert_Paye {

					/// <summary>
					/// Returns "KgVert_Paye"
					/// </summary>
					public const System.String ColumnName = "KgVert_Paye";
					/// <summary>
					/// Returns 72
					/// </summary>
					public const System.Int32 ColumnIndex = 72;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Pourcent_Sec_Producteur via shared members
				/// </summary>
				public sealed class Column_Pourcent_Sec_Producteur {

					/// <summary>
					/// Returns "Pourcent_Sec_Producteur"
					/// </summary>
					public const System.String ColumnName = "Pourcent_Sec_Producteur";
					/// <summary>
					/// Returns 73
					/// </summary>
					public const System.Int32 ColumnIndex = 73;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Pourcent_Sec_Producteur_Override via shared members
				/// </summary>
				public sealed class Column_Pourcent_Sec_Producteur_Override {

					/// <summary>
					/// Returns "Pourcent_Sec_Producteur_Override"
					/// </summary>
					public const System.String ColumnName = "Pourcent_Sec_Producteur_Override";
					/// <summary>
					/// Returns 74
					/// </summary>
					public const System.Int32 ColumnIndex = 74;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field TMA_Producteur via shared members
				/// </summary>
				public sealed class Column_TMA_Producteur {

					/// <summary>
					/// Returns "TMA_Producteur"
					/// </summary>
					public const System.String ColumnName = "TMA_Producteur";
					/// <summary>
					/// Returns 75
					/// </summary>
					public const System.Int32 ColumnIndex = 75;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Pourcent_Sec_Transport via shared members
				/// </summary>
				public sealed class Column_Pourcent_Sec_Transport {

					/// <summary>
					/// Returns "Pourcent_Sec_Transport"
					/// </summary>
					public const System.String ColumnName = "Pourcent_Sec_Transport";
					/// <summary>
					/// Returns 76
					/// </summary>
					public const System.Int32 ColumnIndex = 76;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Pourcent_Sec_Transport_Override via shared members
				/// </summary>
				public sealed class Column_Pourcent_Sec_Transport_Override {

					/// <summary>
					/// Returns "Pourcent_Sec_Transport_Override"
					/// </summary>
					public const System.String ColumnName = "Pourcent_Sec_Transport_Override";
					/// <summary>
					/// Returns 77
					/// </summary>
					public const System.Int32 ColumnIndex = 77;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field TMA_Transport via shared members
				/// </summary>
				public sealed class Column_TMA_Transport {

					/// <summary>
					/// Returns "TMA_Transport"
					/// </summary>
					public const System.String ColumnName = "TMA_Transport";
					/// <summary>
					/// Returns 78
					/// </summary>
					public const System.Int32 ColumnIndex = 78;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field IsTMA via shared members
				/// </summary>
				public sealed class Column_IsTMA {

					/// <summary>
					/// Returns "IsTMA"
					/// </summary>
					public const System.String ColumnName = "IsTMA";
					/// <summary>
					/// Returns 79
					/// </summary>
					public const System.Int32 ColumnIndex = 79;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field SuspendrePaiement via shared members
				/// </summary>
				public sealed class Column_SuspendrePaiement {

					/// <summary>
					/// Returns "SuspendrePaiement"
					/// </summary>
					public const System.String ColumnName = "SuspendrePaiement";
					/// <summary>
					/// Returns 80
					/// </summary>
					public const System.Int32 ColumnIndex = 80;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field BonCommande via shared members
				/// </summary>
				public sealed class Column_BonCommande {

					/// <summary>
					/// Returns "BonCommande"
					/// </summary>
					public const System.String ColumnName = "BonCommande";
					/// <summary>
					/// Returns 81
					/// </summary>
					public const System.Int32 ColumnIndex = 81;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ContratID_ID via shared members
				/// </summary>
				public sealed class Column_ContratID_ID {

					/// <summary>
					/// Returns "ContratID_ID"
					/// </summary>
					public const System.String ColumnName = "ContratID_ID";
					/// <summary>
					/// Returns 82
					/// </summary>
					public const System.Int32 ColumnIndex = 82;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ContratID_Description via shared members
				/// </summary>
				public sealed class Column_ContratID_Description {

					/// <summary>
					/// Returns "ContratID_Description"
					/// </summary>
					public const System.String ColumnName = "ContratID_Description";
					/// <summary>
					/// Returns 83
					/// </summary>
					public const System.Int32 ColumnIndex = 83;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ContratID_UsineID via shared members
				/// </summary>
				public sealed class Column_ContratID_UsineID {

					/// <summary>
					/// Returns "ContratID_UsineID"
					/// </summary>
					public const System.String ColumnName = "ContratID_UsineID";
					/// <summary>
					/// Returns 84
					/// </summary>
					public const System.Int32 ColumnIndex = 84;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ContratID_Annee via shared members
				/// </summary>
				public sealed class Column_ContratID_Annee {

					/// <summary>
					/// Returns "ContratID_Annee"
					/// </summary>
					public const System.String ColumnName = "ContratID_Annee";
					/// <summary>
					/// Returns 85
					/// </summary>
					public const System.Int32 ColumnIndex = 85;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ContratID_Date_debut via shared members
				/// </summary>
				public sealed class Column_ContratID_Date_debut {

					/// <summary>
					/// Returns "ContratID_Date_debut"
					/// </summary>
					public const System.String ColumnName = "ContratID_Date_debut";
					/// <summary>
					/// Returns 86
					/// </summary>
					public const System.Int32 ColumnIndex = 86;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ContratID_Date_fin via shared members
				/// </summary>
				public sealed class Column_ContratID_Date_fin {

					/// <summary>
					/// Returns "ContratID_Date_fin"
					/// </summary>
					public const System.String ColumnName = "ContratID_Date_fin";
					/// <summary>
					/// Returns 87
					/// </summary>
					public const System.Int32 ColumnIndex = 87;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ContratID_Actif via shared members
				/// </summary>
				public sealed class Column_ContratID_Actif {

					/// <summary>
					/// Returns "ContratID_Actif"
					/// </summary>
					public const System.String ColumnName = "ContratID_Actif";
					/// <summary>
					/// Returns 88
					/// </summary>
					public const System.Int32 ColumnIndex = 88;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ContratID_PaieTransporteur via shared members
				/// </summary>
				public sealed class Column_ContratID_PaieTransporteur {

					/// <summary>
					/// Returns "ContratID_PaieTransporteur"
					/// </summary>
					public const System.String ColumnName = "ContratID_PaieTransporteur";
					/// <summary>
					/// Returns 89
					/// </summary>
					public const System.Int32 ColumnIndex = 89;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ContratID_Taux_Surcharge via shared members
				/// </summary>
				public sealed class Column_ContratID_Taux_Surcharge {

					/// <summary>
					/// Returns "ContratID_Taux_Surcharge"
					/// </summary>
					public const System.String ColumnName = "ContratID_Taux_Surcharge";
					/// <summary>
					/// Returns 90
					/// </summary>
					public const System.Int32 ColumnIndex = 90;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ContratID_SurchargeManuel via shared members
				/// </summary>
				public sealed class Column_ContratID_SurchargeManuel {

					/// <summary>
					/// Returns "ContratID_SurchargeManuel"
					/// </summary>
					public const System.String ColumnName = "ContratID_SurchargeManuel";
					/// <summary>
					/// Returns 91
					/// </summary>
					public const System.Int32 ColumnIndex = 91;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ContratID_TxTransSameProd via shared members
				/// </summary>
				public sealed class Column_ContratID_TxTransSameProd {

					/// <summary>
					/// Returns "ContratID_TxTransSameProd"
					/// </summary>
					public const System.String ColumnName = "ContratID_TxTransSameProd";
					/// <summary>
					/// Returns 92
					/// </summary>
					public const System.Int32 ColumnIndex = 92;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field UniteMesureID_ID via shared members
				/// </summary>
				public sealed class Column_UniteMesureID_ID {

					/// <summary>
					/// Returns "UniteMesureID_ID"
					/// </summary>
					public const System.String ColumnName = "UniteMesureID_ID";
					/// <summary>
					/// Returns 93
					/// </summary>
					public const System.Int32 ColumnIndex = 93;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field UniteMesureID_Description via shared members
				/// </summary>
				public sealed class Column_UniteMesureID_Description {

					/// <summary>
					/// Returns "UniteMesureID_Description"
					/// </summary>
					public const System.String ColumnName = "UniteMesureID_Description";
					/// <summary>
					/// Returns 94
					/// </summary>
					public const System.Int32 ColumnIndex = 94;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field UniteMesureID_Nb_decimale via shared members
				/// </summary>
				public sealed class Column_UniteMesureID_Nb_decimale {

					/// <summary>
					/// Returns "UniteMesureID_Nb_decimale"
					/// </summary>
					public const System.String ColumnName = "UniteMesureID_Nb_decimale";
					/// <summary>
					/// Returns 95
					/// </summary>
					public const System.Int32 ColumnIndex = 95;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field UniteMesureID_Actif via shared members
				/// </summary>
				public sealed class Column_UniteMesureID_Actif {

					/// <summary>
					/// Returns "UniteMesureID_Actif"
					/// </summary>
					public const System.String ColumnName = "UniteMesureID_Actif";
					/// <summary>
					/// Returns 96
					/// </summary>
					public const System.Int32 ColumnIndex = 96;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field UniteMesureID_UseMontant via shared members
				/// </summary>
				public sealed class Column_UniteMesureID_UseMontant {

					/// <summary>
					/// Returns "UniteMesureID_UseMontant"
					/// </summary>
					public const System.String ColumnName = "UniteMesureID_UseMontant";
					/// <summary>
					/// Returns 97
					/// </summary>
					public const System.Int32 ColumnIndex = 97;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field UniteMesureID_Montant_Preleve_plan_conjoint via shared members
				/// </summary>
				public sealed class Column_UniteMesureID_Montant_Preleve_plan_conjoint {

					/// <summary>
					/// Returns "UniteMesureID_Montant_Preleve_plan_conjoint"
					/// </summary>
					public const System.String ColumnName = "UniteMesureID_Montant_Preleve_plan_conjoint";
					/// <summary>
					/// Returns 98
					/// </summary>
					public const System.Int32 ColumnIndex = 98;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field UniteMesureID_Montant_Preleve_fond_roulement via shared members
				/// </summary>
				public sealed class Column_UniteMesureID_Montant_Preleve_fond_roulement {

					/// <summary>
					/// Returns "UniteMesureID_Montant_Preleve_fond_roulement"
					/// </summary>
					public const System.String ColumnName = "UniteMesureID_Montant_Preleve_fond_roulement";
					/// <summary>
					/// Returns 99
					/// </summary>
					public const System.Int32 ColumnIndex = 99;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field UniteMesureID_Montant_Preleve_fond_forestier via shared members
				/// </summary>
				public sealed class Column_UniteMesureID_Montant_Preleve_fond_forestier {

					/// <summary>
					/// Returns "UniteMesureID_Montant_Preleve_fond_forestier"
					/// </summary>
					public const System.String ColumnName = "UniteMesureID_Montant_Preleve_fond_forestier";
					/// <summary>
					/// Returns 100
					/// </summary>
					public const System.Int32 ColumnIndex = 100;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field UniteMesureID_Montant_Preleve_divers via shared members
				/// </summary>
				public sealed class Column_UniteMesureID_Montant_Preleve_divers {

					/// <summary>
					/// Returns "UniteMesureID_Montant_Preleve_divers"
					/// </summary>
					public const System.String ColumnName = "UniteMesureID_Montant_Preleve_divers";
					/// <summary>
					/// Returns 101
					/// </summary>
					public const System.Int32 ColumnIndex = 101;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field UniteMesureID_Pourc_Preleve_plan_conjoint via shared members
				/// </summary>
				public sealed class Column_UniteMesureID_Pourc_Preleve_plan_conjoint {

					/// <summary>
					/// Returns "UniteMesureID_Pourc_Preleve_plan_conjoint"
					/// </summary>
					public const System.String ColumnName = "UniteMesureID_Pourc_Preleve_plan_conjoint";
					/// <summary>
					/// Returns 102
					/// </summary>
					public const System.Int32 ColumnIndex = 102;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field UniteMesureID_Pourc_Preleve_fond_roulement via shared members
				/// </summary>
				public sealed class Column_UniteMesureID_Pourc_Preleve_fond_roulement {

					/// <summary>
					/// Returns "UniteMesureID_Pourc_Preleve_fond_roulement"
					/// </summary>
					public const System.String ColumnName = "UniteMesureID_Pourc_Preleve_fond_roulement";
					/// <summary>
					/// Returns 103
					/// </summary>
					public const System.Int32 ColumnIndex = 103;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field UniteMesureID_Pourc_Preleve_fond_forestier via shared members
				/// </summary>
				public sealed class Column_UniteMesureID_Pourc_Preleve_fond_forestier {

					/// <summary>
					/// Returns "UniteMesureID_Pourc_Preleve_fond_forestier"
					/// </summary>
					public const System.String ColumnName = "UniteMesureID_Pourc_Preleve_fond_forestier";
					/// <summary>
					/// Returns 104
					/// </summary>
					public const System.Int32 ColumnIndex = 104;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field UniteMesureID_Pourc_Preleve_divers via shared members
				/// </summary>
				public sealed class Column_UniteMesureID_Pourc_Preleve_divers {

					/// <summary>
					/// Returns "UniteMesureID_Pourc_Preleve_divers"
					/// </summary>
					public const System.String ColumnName = "UniteMesureID_Pourc_Preleve_divers";
					/// <summary>
					/// Returns 105
					/// </summary>
					public const System.Int32 ColumnIndex = 105;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field EssenceID_ID via shared members
				/// </summary>
				public sealed class Column_EssenceID_ID {

					/// <summary>
					/// Returns "EssenceID_ID"
					/// </summary>
					public const System.String ColumnName = "EssenceID_ID";
					/// <summary>
					/// Returns 106
					/// </summary>
					public const System.Int32 ColumnIndex = 106;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field EssenceID_Description via shared members
				/// </summary>
				public sealed class Column_EssenceID_Description {

					/// <summary>
					/// Returns "EssenceID_Description"
					/// </summary>
					public const System.String ColumnName = "EssenceID_Description";
					/// <summary>
					/// Returns 107
					/// </summary>
					public const System.Int32 ColumnIndex = 107;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field EssenceID_RegroupementID via shared members
				/// </summary>
				public sealed class Column_EssenceID_RegroupementID {

					/// <summary>
					/// Returns "EssenceID_RegroupementID"
					/// </summary>
					public const System.String ColumnName = "EssenceID_RegroupementID";
					/// <summary>
					/// Returns 108
					/// </summary>
					public const System.Int32 ColumnIndex = 108;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field EssenceID_ContingentID via shared members
				/// </summary>
				public sealed class Column_EssenceID_ContingentID {

					/// <summary>
					/// Returns "EssenceID_ContingentID"
					/// </summary>
					public const System.String ColumnName = "EssenceID_ContingentID";
					/// <summary>
					/// Returns 109
					/// </summary>
					public const System.Int32 ColumnIndex = 109;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field EssenceID_RepartitionID via shared members
				/// </summary>
				public sealed class Column_EssenceID_RepartitionID {

					/// <summary>
					/// Returns "EssenceID_RepartitionID"
					/// </summary>
					public const System.String ColumnName = "EssenceID_RepartitionID";
					/// <summary>
					/// Returns 110
					/// </summary>
					public const System.Int32 ColumnIndex = 110;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field EssenceID_Actif via shared members
				/// </summary>
				public sealed class Column_EssenceID_Actif {

					/// <summary>
					/// Returns "EssenceID_Actif"
					/// </summary>
					public const System.String ColumnName = "EssenceID_Actif";
					/// <summary>
					/// Returns 111
					/// </summary>
					public const System.Int32 ColumnIndex = 111;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field DroitCoupeID_ID via shared members
				/// </summary>
				public sealed class Column_DroitCoupeID_ID {

					/// <summary>
					/// Returns "DroitCoupeID_ID"
					/// </summary>
					public const System.String ColumnName = "DroitCoupeID_ID";
					/// <summary>
					/// Returns 112
					/// </summary>
					public const System.Int32 ColumnIndex = 112;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field DroitCoupeID_CleTri via shared members
				/// </summary>
				public sealed class Column_DroitCoupeID_CleTri {

					/// <summary>
					/// Returns "DroitCoupeID_CleTri"
					/// </summary>
					public const System.String ColumnName = "DroitCoupeID_CleTri";
					/// <summary>
					/// Returns 113
					/// </summary>
					public const System.Int32 ColumnIndex = 113;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field DroitCoupeID_Nom via shared members
				/// </summary>
				public sealed class Column_DroitCoupeID_Nom {

					/// <summary>
					/// Returns "DroitCoupeID_Nom"
					/// </summary>
					public const System.String ColumnName = "DroitCoupeID_Nom";
					/// <summary>
					/// Returns 114
					/// </summary>
					public const System.Int32 ColumnIndex = 114;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field DroitCoupeID_AuSoinsDe via shared members
				/// </summary>
				public sealed class Column_DroitCoupeID_AuSoinsDe {

					/// <summary>
					/// Returns "DroitCoupeID_AuSoinsDe"
					/// </summary>
					public const System.String ColumnName = "DroitCoupeID_AuSoinsDe";
					/// <summary>
					/// Returns 115
					/// </summary>
					public const System.Int32 ColumnIndex = 115;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field DroitCoupeID_Rue via shared members
				/// </summary>
				public sealed class Column_DroitCoupeID_Rue {

					/// <summary>
					/// Returns "DroitCoupeID_Rue"
					/// </summary>
					public const System.String ColumnName = "DroitCoupeID_Rue";
					/// <summary>
					/// Returns 116
					/// </summary>
					public const System.Int32 ColumnIndex = 116;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field DroitCoupeID_Ville via shared members
				/// </summary>
				public sealed class Column_DroitCoupeID_Ville {

					/// <summary>
					/// Returns "DroitCoupeID_Ville"
					/// </summary>
					public const System.String ColumnName = "DroitCoupeID_Ville";
					/// <summary>
					/// Returns 117
					/// </summary>
					public const System.Int32 ColumnIndex = 117;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field DroitCoupeID_PaysID via shared members
				/// </summary>
				public sealed class Column_DroitCoupeID_PaysID {

					/// <summary>
					/// Returns "DroitCoupeID_PaysID"
					/// </summary>
					public const System.String ColumnName = "DroitCoupeID_PaysID";
					/// <summary>
					/// Returns 118
					/// </summary>
					public const System.Int32 ColumnIndex = 118;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field DroitCoupeID_Code_postal via shared members
				/// </summary>
				public sealed class Column_DroitCoupeID_Code_postal {

					/// <summary>
					/// Returns "DroitCoupeID_Code_postal"
					/// </summary>
					public const System.String ColumnName = "DroitCoupeID_Code_postal";
					/// <summary>
					/// Returns 119
					/// </summary>
					public const System.Int32 ColumnIndex = 119;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field DroitCoupeID_Telephone via shared members
				/// </summary>
				public sealed class Column_DroitCoupeID_Telephone {

					/// <summary>
					/// Returns "DroitCoupeID_Telephone"
					/// </summary>
					public const System.String ColumnName = "DroitCoupeID_Telephone";
					/// <summary>
					/// Returns 120
					/// </summary>
					public const System.Int32 ColumnIndex = 120;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field DroitCoupeID_Telephone_Poste via shared members
				/// </summary>
				public sealed class Column_DroitCoupeID_Telephone_Poste {

					/// <summary>
					/// Returns "DroitCoupeID_Telephone_Poste"
					/// </summary>
					public const System.String ColumnName = "DroitCoupeID_Telephone_Poste";
					/// <summary>
					/// Returns 121
					/// </summary>
					public const System.Int32 ColumnIndex = 121;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field DroitCoupeID_Telecopieur via shared members
				/// </summary>
				public sealed class Column_DroitCoupeID_Telecopieur {

					/// <summary>
					/// Returns "DroitCoupeID_Telecopieur"
					/// </summary>
					public const System.String ColumnName = "DroitCoupeID_Telecopieur";
					/// <summary>
					/// Returns 122
					/// </summary>
					public const System.Int32 ColumnIndex = 122;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field DroitCoupeID_Telephone2 via shared members
				/// </summary>
				public sealed class Column_DroitCoupeID_Telephone2 {

					/// <summary>
					/// Returns "DroitCoupeID_Telephone2"
					/// </summary>
					public const System.String ColumnName = "DroitCoupeID_Telephone2";
					/// <summary>
					/// Returns 123
					/// </summary>
					public const System.Int32 ColumnIndex = 123;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field DroitCoupeID_Telephone2_Desc via shared members
				/// </summary>
				public sealed class Column_DroitCoupeID_Telephone2_Desc {

					/// <summary>
					/// Returns "DroitCoupeID_Telephone2_Desc"
					/// </summary>
					public const System.String ColumnName = "DroitCoupeID_Telephone2_Desc";
					/// <summary>
					/// Returns 124
					/// </summary>
					public const System.Int32 ColumnIndex = 124;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field DroitCoupeID_Telephone2_Poste via shared members
				/// </summary>
				public sealed class Column_DroitCoupeID_Telephone2_Poste {

					/// <summary>
					/// Returns "DroitCoupeID_Telephone2_Poste"
					/// </summary>
					public const System.String ColumnName = "DroitCoupeID_Telephone2_Poste";
					/// <summary>
					/// Returns 125
					/// </summary>
					public const System.Int32 ColumnIndex = 125;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field DroitCoupeID_Telephone3 via shared members
				/// </summary>
				public sealed class Column_DroitCoupeID_Telephone3 {

					/// <summary>
					/// Returns "DroitCoupeID_Telephone3"
					/// </summary>
					public const System.String ColumnName = "DroitCoupeID_Telephone3";
					/// <summary>
					/// Returns 126
					/// </summary>
					public const System.Int32 ColumnIndex = 126;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field DroitCoupeID_Telephone3_Desc via shared members
				/// </summary>
				public sealed class Column_DroitCoupeID_Telephone3_Desc {

					/// <summary>
					/// Returns "DroitCoupeID_Telephone3_Desc"
					/// </summary>
					public const System.String ColumnName = "DroitCoupeID_Telephone3_Desc";
					/// <summary>
					/// Returns 127
					/// </summary>
					public const System.Int32 ColumnIndex = 127;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field DroitCoupeID_Telephone3_Poste via shared members
				/// </summary>
				public sealed class Column_DroitCoupeID_Telephone3_Poste {

					/// <summary>
					/// Returns "DroitCoupeID_Telephone3_Poste"
					/// </summary>
					public const System.String ColumnName = "DroitCoupeID_Telephone3_Poste";
					/// <summary>
					/// Returns 128
					/// </summary>
					public const System.Int32 ColumnIndex = 128;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field DroitCoupeID_No_membre via shared members
				/// </summary>
				public sealed class Column_DroitCoupeID_No_membre {

					/// <summary>
					/// Returns "DroitCoupeID_No_membre"
					/// </summary>
					public const System.String ColumnName = "DroitCoupeID_No_membre";
					/// <summary>
					/// Returns 129
					/// </summary>
					public const System.Int32 ColumnIndex = 129;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field DroitCoupeID_Resident via shared members
				/// </summary>
				public sealed class Column_DroitCoupeID_Resident {

					/// <summary>
					/// Returns "DroitCoupeID_Resident"
					/// </summary>
					public const System.String ColumnName = "DroitCoupeID_Resident";
					/// <summary>
					/// Returns 130
					/// </summary>
					public const System.Int32 ColumnIndex = 130;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field DroitCoupeID_Email via shared members
				/// </summary>
				public sealed class Column_DroitCoupeID_Email {

					/// <summary>
					/// Returns "DroitCoupeID_Email"
					/// </summary>
					public const System.String ColumnName = "DroitCoupeID_Email";
					/// <summary>
					/// Returns 131
					/// </summary>
					public const System.Int32 ColumnIndex = 131;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field DroitCoupeID_WWW via shared members
				/// </summary>
				public sealed class Column_DroitCoupeID_WWW {

					/// <summary>
					/// Returns "DroitCoupeID_WWW"
					/// </summary>
					public const System.String ColumnName = "DroitCoupeID_WWW";
					/// <summary>
					/// Returns 132
					/// </summary>
					public const System.Int32 ColumnIndex = 132;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field DroitCoupeID_Commentaires via shared members
				/// </summary>
				public sealed class Column_DroitCoupeID_Commentaires {

					/// <summary>
					/// Returns "DroitCoupeID_Commentaires"
					/// </summary>
					public const System.String ColumnName = "DroitCoupeID_Commentaires";
					/// <summary>
					/// Returns 133
					/// </summary>
					public const System.Int32 ColumnIndex = 133;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field DroitCoupeID_AfficherCommentaires via shared members
				/// </summary>
				public sealed class Column_DroitCoupeID_AfficherCommentaires {

					/// <summary>
					/// Returns "DroitCoupeID_AfficherCommentaires"
					/// </summary>
					public const System.String ColumnName = "DroitCoupeID_AfficherCommentaires";
					/// <summary>
					/// Returns 134
					/// </summary>
					public const System.Int32 ColumnIndex = 134;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field DroitCoupeID_DepotDirect via shared members
				/// </summary>
				public sealed class Column_DroitCoupeID_DepotDirect {

					/// <summary>
					/// Returns "DroitCoupeID_DepotDirect"
					/// </summary>
					public const System.String ColumnName = "DroitCoupeID_DepotDirect";
					/// <summary>
					/// Returns 135
					/// </summary>
					public const System.Int32 ColumnIndex = 135;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field DroitCoupeID_InstitutionBanquaireID via shared members
				/// </summary>
				public sealed class Column_DroitCoupeID_InstitutionBanquaireID {

					/// <summary>
					/// Returns "DroitCoupeID_InstitutionBanquaireID"
					/// </summary>
					public const System.String ColumnName = "DroitCoupeID_InstitutionBanquaireID";
					/// <summary>
					/// Returns 136
					/// </summary>
					public const System.Int32 ColumnIndex = 136;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field DroitCoupeID_Banque_transit via shared members
				/// </summary>
				public sealed class Column_DroitCoupeID_Banque_transit {

					/// <summary>
					/// Returns "DroitCoupeID_Banque_transit"
					/// </summary>
					public const System.String ColumnName = "DroitCoupeID_Banque_transit";
					/// <summary>
					/// Returns 137
					/// </summary>
					public const System.Int32 ColumnIndex = 137;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field DroitCoupeID_Banque_folio via shared members
				/// </summary>
				public sealed class Column_DroitCoupeID_Banque_folio {

					/// <summary>
					/// Returns "DroitCoupeID_Banque_folio"
					/// </summary>
					public const System.String ColumnName = "DroitCoupeID_Banque_folio";
					/// <summary>
					/// Returns 138
					/// </summary>
					public const System.Int32 ColumnIndex = 138;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field DroitCoupeID_No_TPS via shared members
				/// </summary>
				public sealed class Column_DroitCoupeID_No_TPS {

					/// <summary>
					/// Returns "DroitCoupeID_No_TPS"
					/// </summary>
					public const System.String ColumnName = "DroitCoupeID_No_TPS";
					/// <summary>
					/// Returns 139
					/// </summary>
					public const System.Int32 ColumnIndex = 139;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field DroitCoupeID_No_TVQ via shared members
				/// </summary>
				public sealed class Column_DroitCoupeID_No_TVQ {

					/// <summary>
					/// Returns "DroitCoupeID_No_TVQ"
					/// </summary>
					public const System.String ColumnName = "DroitCoupeID_No_TVQ";
					/// <summary>
					/// Returns 140
					/// </summary>
					public const System.Int32 ColumnIndex = 140;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field DroitCoupeID_PayerA via shared members
				/// </summary>
				public sealed class Column_DroitCoupeID_PayerA {

					/// <summary>
					/// Returns "DroitCoupeID_PayerA"
					/// </summary>
					public const System.String ColumnName = "DroitCoupeID_PayerA";
					/// <summary>
					/// Returns 141
					/// </summary>
					public const System.Int32 ColumnIndex = 141;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field DroitCoupeID_PayerAID via shared members
				/// </summary>
				public sealed class Column_DroitCoupeID_PayerAID {

					/// <summary>
					/// Returns "DroitCoupeID_PayerAID"
					/// </summary>
					public const System.String ColumnName = "DroitCoupeID_PayerAID";
					/// <summary>
					/// Returns 142
					/// </summary>
					public const System.Int32 ColumnIndex = 142;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field DroitCoupeID_Statut via shared members
				/// </summary>
				public sealed class Column_DroitCoupeID_Statut {

					/// <summary>
					/// Returns "DroitCoupeID_Statut"
					/// </summary>
					public const System.String ColumnName = "DroitCoupeID_Statut";
					/// <summary>
					/// Returns 143
					/// </summary>
					public const System.Int32 ColumnIndex = 143;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field DroitCoupeID_Rep_Nom via shared members
				/// </summary>
				public sealed class Column_DroitCoupeID_Rep_Nom {

					/// <summary>
					/// Returns "DroitCoupeID_Rep_Nom"
					/// </summary>
					public const System.String ColumnName = "DroitCoupeID_Rep_Nom";
					/// <summary>
					/// Returns 144
					/// </summary>
					public const System.Int32 ColumnIndex = 144;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field DroitCoupeID_Rep_Telephone via shared members
				/// </summary>
				public sealed class Column_DroitCoupeID_Rep_Telephone {

					/// <summary>
					/// Returns "DroitCoupeID_Rep_Telephone"
					/// </summary>
					public const System.String ColumnName = "DroitCoupeID_Rep_Telephone";
					/// <summary>
					/// Returns 145
					/// </summary>
					public const System.Int32 ColumnIndex = 145;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field DroitCoupeID_Rep_Telephone_Poste via shared members
				/// </summary>
				public sealed class Column_DroitCoupeID_Rep_Telephone_Poste {

					/// <summary>
					/// Returns "DroitCoupeID_Rep_Telephone_Poste"
					/// </summary>
					public const System.String ColumnName = "DroitCoupeID_Rep_Telephone_Poste";
					/// <summary>
					/// Returns 146
					/// </summary>
					public const System.Int32 ColumnIndex = 146;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field DroitCoupeID_Rep_Email via shared members
				/// </summary>
				public sealed class Column_DroitCoupeID_Rep_Email {

					/// <summary>
					/// Returns "DroitCoupeID_Rep_Email"
					/// </summary>
					public const System.String ColumnName = "DroitCoupeID_Rep_Email";
					/// <summary>
					/// Returns 147
					/// </summary>
					public const System.Int32 ColumnIndex = 147;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field DroitCoupeID_EnAnglais via shared members
				/// </summary>
				public sealed class Column_DroitCoupeID_EnAnglais {

					/// <summary>
					/// Returns "DroitCoupeID_EnAnglais"
					/// </summary>
					public const System.String ColumnName = "DroitCoupeID_EnAnglais";
					/// <summary>
					/// Returns 148
					/// </summary>
					public const System.Int32 ColumnIndex = 148;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field DroitCoupeID_Actif via shared members
				/// </summary>
				public sealed class Column_DroitCoupeID_Actif {

					/// <summary>
					/// Returns "DroitCoupeID_Actif"
					/// </summary>
					public const System.String ColumnName = "DroitCoupeID_Actif";
					/// <summary>
					/// Returns 149
					/// </summary>
					public const System.Int32 ColumnIndex = 149;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field DroitCoupeID_MRCProducteurID via shared members
				/// </summary>
				public sealed class Column_DroitCoupeID_MRCProducteurID {

					/// <summary>
					/// Returns "DroitCoupeID_MRCProducteurID"
					/// </summary>
					public const System.String ColumnName = "DroitCoupeID_MRCProducteurID";
					/// <summary>
					/// Returns 150
					/// </summary>
					public const System.Int32 ColumnIndex = 150;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field DroitCoupeID_PaiementManuel via shared members
				/// </summary>
				public sealed class Column_DroitCoupeID_PaiementManuel {

					/// <summary>
					/// Returns "DroitCoupeID_PaiementManuel"
					/// </summary>
					public const System.String ColumnName = "DroitCoupeID_PaiementManuel";
					/// <summary>
					/// Returns 151
					/// </summary>
					public const System.Int32 ColumnIndex = 151;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field DroitCoupeID_Journal via shared members
				/// </summary>
				public sealed class Column_DroitCoupeID_Journal {

					/// <summary>
					/// Returns "DroitCoupeID_Journal"
					/// </summary>
					public const System.String ColumnName = "DroitCoupeID_Journal";
					/// <summary>
					/// Returns 152
					/// </summary>
					public const System.Int32 ColumnIndex = 152;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field DroitCoupeID_RecoitTPS via shared members
				/// </summary>
				public sealed class Column_DroitCoupeID_RecoitTPS {

					/// <summary>
					/// Returns "DroitCoupeID_RecoitTPS"
					/// </summary>
					public const System.String ColumnName = "DroitCoupeID_RecoitTPS";
					/// <summary>
					/// Returns 153
					/// </summary>
					public const System.Int32 ColumnIndex = 153;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field DroitCoupeID_RecoitTVQ via shared members
				/// </summary>
				public sealed class Column_DroitCoupeID_RecoitTVQ {

					/// <summary>
					/// Returns "DroitCoupeID_RecoitTVQ"
					/// </summary>
					public const System.String ColumnName = "DroitCoupeID_RecoitTVQ";
					/// <summary>
					/// Returns 154
					/// </summary>
					public const System.Int32 ColumnIndex = 154;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field DroitCoupeID_ModifierTrigger via shared members
				/// </summary>
				public sealed class Column_DroitCoupeID_ModifierTrigger {

					/// <summary>
					/// Returns "DroitCoupeID_ModifierTrigger"
					/// </summary>
					public const System.String ColumnName = "DroitCoupeID_ModifierTrigger";
					/// <summary>
					/// Returns 155
					/// </summary>
					public const System.Int32 ColumnIndex = 155;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field DroitCoupeID_IsProducteur via shared members
				/// </summary>
				public sealed class Column_DroitCoupeID_IsProducteur {

					/// <summary>
					/// Returns "DroitCoupeID_IsProducteur"
					/// </summary>
					public const System.String ColumnName = "DroitCoupeID_IsProducteur";
					/// <summary>
					/// Returns 156
					/// </summary>
					public const System.Int32 ColumnIndex = 156;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field DroitCoupeID_IsTransporteur via shared members
				/// </summary>
				public sealed class Column_DroitCoupeID_IsTransporteur {

					/// <summary>
					/// Returns "DroitCoupeID_IsTransporteur"
					/// </summary>
					public const System.String ColumnName = "DroitCoupeID_IsTransporteur";
					/// <summary>
					/// Returns 157
					/// </summary>
					public const System.Int32 ColumnIndex = 157;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field DroitCoupeID_IsChargeur via shared members
				/// </summary>
				public sealed class Column_DroitCoupeID_IsChargeur {

					/// <summary>
					/// Returns "DroitCoupeID_IsChargeur"
					/// </summary>
					public const System.String ColumnName = "DroitCoupeID_IsChargeur";
					/// <summary>
					/// Returns 158
					/// </summary>
					public const System.Int32 ColumnIndex = 158;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field DroitCoupeID_IsAutre via shared members
				/// </summary>
				public sealed class Column_DroitCoupeID_IsAutre {

					/// <summary>
					/// Returns "DroitCoupeID_IsAutre"
					/// </summary>
					public const System.String ColumnName = "DroitCoupeID_IsAutre";
					/// <summary>
					/// Returns 159
					/// </summary>
					public const System.Int32 ColumnIndex = 159;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field DroitCoupeID_AfficherCommentairesSurPermit via shared members
				/// </summary>
				public sealed class Column_DroitCoupeID_AfficherCommentairesSurPermit {

					/// <summary>
					/// Returns "DroitCoupeID_AfficherCommentairesSurPermit"
					/// </summary>
					public const System.String ColumnName = "DroitCoupeID_AfficherCommentairesSurPermit";
					/// <summary>
					/// Returns 160
					/// </summary>
					public const System.Int32 ColumnIndex = 160;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field DroitCoupeID_PasEmissionPermis via shared members
				/// </summary>
				public sealed class Column_DroitCoupeID_PasEmissionPermis {

					/// <summary>
					/// Returns "DroitCoupeID_PasEmissionPermis"
					/// </summary>
					public const System.String ColumnName = "DroitCoupeID_PasEmissionPermis";
					/// <summary>
					/// Returns 161
					/// </summary>
					public const System.Int32 ColumnIndex = 161;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field DroitCoupeID_Generique via shared members
				/// </summary>
				public sealed class Column_DroitCoupeID_Generique {

					/// <summary>
					/// Returns "DroitCoupeID_Generique"
					/// </summary>
					public const System.String ColumnName = "DroitCoupeID_Generique";
					/// <summary>
					/// Returns 162
					/// </summary>
					public const System.Int32 ColumnIndex = 162;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field DroitCoupeID_Membre_OGC via shared members
				/// </summary>
				public sealed class Column_DroitCoupeID_Membre_OGC {

					/// <summary>
					/// Returns "DroitCoupeID_Membre_OGC"
					/// </summary>
					public const System.String ColumnName = "DroitCoupeID_Membre_OGC";
					/// <summary>
					/// Returns 163
					/// </summary>
					public const System.Int32 ColumnIndex = 163;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field DroitCoupeID_InscritTPS via shared members
				/// </summary>
				public sealed class Column_DroitCoupeID_InscritTPS {

					/// <summary>
					/// Returns "DroitCoupeID_InscritTPS"
					/// </summary>
					public const System.String ColumnName = "DroitCoupeID_InscritTPS";
					/// <summary>
					/// Returns 164
					/// </summary>
					public const System.Int32 ColumnIndex = 164;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field DroitCoupeID_InscritTVQ via shared members
				/// </summary>
				public sealed class Column_DroitCoupeID_InscritTVQ {

					/// <summary>
					/// Returns "DroitCoupeID_InscritTVQ"
					/// </summary>
					public const System.String ColumnName = "DroitCoupeID_InscritTVQ";
					/// <summary>
					/// Returns 165
					/// </summary>
					public const System.Int32 ColumnIndex = 165;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field DroitCoupeID_IsOGC via shared members
				/// </summary>
				public sealed class Column_DroitCoupeID_IsOGC {

					/// <summary>
					/// Returns "DroitCoupeID_IsOGC"
					/// </summary>
					public const System.String ColumnName = "DroitCoupeID_IsOGC";
					/// <summary>
					/// Returns 166
					/// </summary>
					public const System.Int32 ColumnIndex = 166;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field EntentePaiementID_ID via shared members
				/// </summary>
				public sealed class Column_EntentePaiementID_ID {

					/// <summary>
					/// Returns "EntentePaiementID_ID"
					/// </summary>
					public const System.String ColumnName = "EntentePaiementID_ID";
					/// <summary>
					/// Returns 167
					/// </summary>
					public const System.Int32 ColumnIndex = 167;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field EntentePaiementID_CleTri via shared members
				/// </summary>
				public sealed class Column_EntentePaiementID_CleTri {

					/// <summary>
					/// Returns "EntentePaiementID_CleTri"
					/// </summary>
					public const System.String ColumnName = "EntentePaiementID_CleTri";
					/// <summary>
					/// Returns 168
					/// </summary>
					public const System.Int32 ColumnIndex = 168;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field EntentePaiementID_Nom via shared members
				/// </summary>
				public sealed class Column_EntentePaiementID_Nom {

					/// <summary>
					/// Returns "EntentePaiementID_Nom"
					/// </summary>
					public const System.String ColumnName = "EntentePaiementID_Nom";
					/// <summary>
					/// Returns 169
					/// </summary>
					public const System.Int32 ColumnIndex = 169;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field EntentePaiementID_AuSoinsDe via shared members
				/// </summary>
				public sealed class Column_EntentePaiementID_AuSoinsDe {

					/// <summary>
					/// Returns "EntentePaiementID_AuSoinsDe"
					/// </summary>
					public const System.String ColumnName = "EntentePaiementID_AuSoinsDe";
					/// <summary>
					/// Returns 170
					/// </summary>
					public const System.Int32 ColumnIndex = 170;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field EntentePaiementID_Rue via shared members
				/// </summary>
				public sealed class Column_EntentePaiementID_Rue {

					/// <summary>
					/// Returns "EntentePaiementID_Rue"
					/// </summary>
					public const System.String ColumnName = "EntentePaiementID_Rue";
					/// <summary>
					/// Returns 171
					/// </summary>
					public const System.Int32 ColumnIndex = 171;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field EntentePaiementID_Ville via shared members
				/// </summary>
				public sealed class Column_EntentePaiementID_Ville {

					/// <summary>
					/// Returns "EntentePaiementID_Ville"
					/// </summary>
					public const System.String ColumnName = "EntentePaiementID_Ville";
					/// <summary>
					/// Returns 172
					/// </summary>
					public const System.Int32 ColumnIndex = 172;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field EntentePaiementID_PaysID via shared members
				/// </summary>
				public sealed class Column_EntentePaiementID_PaysID {

					/// <summary>
					/// Returns "EntentePaiementID_PaysID"
					/// </summary>
					public const System.String ColumnName = "EntentePaiementID_PaysID";
					/// <summary>
					/// Returns 173
					/// </summary>
					public const System.Int32 ColumnIndex = 173;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field EntentePaiementID_Code_postal via shared members
				/// </summary>
				public sealed class Column_EntentePaiementID_Code_postal {

					/// <summary>
					/// Returns "EntentePaiementID_Code_postal"
					/// </summary>
					public const System.String ColumnName = "EntentePaiementID_Code_postal";
					/// <summary>
					/// Returns 174
					/// </summary>
					public const System.Int32 ColumnIndex = 174;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field EntentePaiementID_Telephone via shared members
				/// </summary>
				public sealed class Column_EntentePaiementID_Telephone {

					/// <summary>
					/// Returns "EntentePaiementID_Telephone"
					/// </summary>
					public const System.String ColumnName = "EntentePaiementID_Telephone";
					/// <summary>
					/// Returns 175
					/// </summary>
					public const System.Int32 ColumnIndex = 175;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field EntentePaiementID_Telephone_Poste via shared members
				/// </summary>
				public sealed class Column_EntentePaiementID_Telephone_Poste {

					/// <summary>
					/// Returns "EntentePaiementID_Telephone_Poste"
					/// </summary>
					public const System.String ColumnName = "EntentePaiementID_Telephone_Poste";
					/// <summary>
					/// Returns 176
					/// </summary>
					public const System.Int32 ColumnIndex = 176;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field EntentePaiementID_Telecopieur via shared members
				/// </summary>
				public sealed class Column_EntentePaiementID_Telecopieur {

					/// <summary>
					/// Returns "EntentePaiementID_Telecopieur"
					/// </summary>
					public const System.String ColumnName = "EntentePaiementID_Telecopieur";
					/// <summary>
					/// Returns 177
					/// </summary>
					public const System.Int32 ColumnIndex = 177;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field EntentePaiementID_Telephone2 via shared members
				/// </summary>
				public sealed class Column_EntentePaiementID_Telephone2 {

					/// <summary>
					/// Returns "EntentePaiementID_Telephone2"
					/// </summary>
					public const System.String ColumnName = "EntentePaiementID_Telephone2";
					/// <summary>
					/// Returns 178
					/// </summary>
					public const System.Int32 ColumnIndex = 178;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field EntentePaiementID_Telephone2_Desc via shared members
				/// </summary>
				public sealed class Column_EntentePaiementID_Telephone2_Desc {

					/// <summary>
					/// Returns "EntentePaiementID_Telephone2_Desc"
					/// </summary>
					public const System.String ColumnName = "EntentePaiementID_Telephone2_Desc";
					/// <summary>
					/// Returns 179
					/// </summary>
					public const System.Int32 ColumnIndex = 179;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field EntentePaiementID_Telephone2_Poste via shared members
				/// </summary>
				public sealed class Column_EntentePaiementID_Telephone2_Poste {

					/// <summary>
					/// Returns "EntentePaiementID_Telephone2_Poste"
					/// </summary>
					public const System.String ColumnName = "EntentePaiementID_Telephone2_Poste";
					/// <summary>
					/// Returns 180
					/// </summary>
					public const System.Int32 ColumnIndex = 180;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field EntentePaiementID_Telephone3 via shared members
				/// </summary>
				public sealed class Column_EntentePaiementID_Telephone3 {

					/// <summary>
					/// Returns "EntentePaiementID_Telephone3"
					/// </summary>
					public const System.String ColumnName = "EntentePaiementID_Telephone3";
					/// <summary>
					/// Returns 181
					/// </summary>
					public const System.Int32 ColumnIndex = 181;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field EntentePaiementID_Telephone3_Desc via shared members
				/// </summary>
				public sealed class Column_EntentePaiementID_Telephone3_Desc {

					/// <summary>
					/// Returns "EntentePaiementID_Telephone3_Desc"
					/// </summary>
					public const System.String ColumnName = "EntentePaiementID_Telephone3_Desc";
					/// <summary>
					/// Returns 182
					/// </summary>
					public const System.Int32 ColumnIndex = 182;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field EntentePaiementID_Telephone3_Poste via shared members
				/// </summary>
				public sealed class Column_EntentePaiementID_Telephone3_Poste {

					/// <summary>
					/// Returns "EntentePaiementID_Telephone3_Poste"
					/// </summary>
					public const System.String ColumnName = "EntentePaiementID_Telephone3_Poste";
					/// <summary>
					/// Returns 183
					/// </summary>
					public const System.Int32 ColumnIndex = 183;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field EntentePaiementID_No_membre via shared members
				/// </summary>
				public sealed class Column_EntentePaiementID_No_membre {

					/// <summary>
					/// Returns "EntentePaiementID_No_membre"
					/// </summary>
					public const System.String ColumnName = "EntentePaiementID_No_membre";
					/// <summary>
					/// Returns 184
					/// </summary>
					public const System.Int32 ColumnIndex = 184;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field EntentePaiementID_Resident via shared members
				/// </summary>
				public sealed class Column_EntentePaiementID_Resident {

					/// <summary>
					/// Returns "EntentePaiementID_Resident"
					/// </summary>
					public const System.String ColumnName = "EntentePaiementID_Resident";
					/// <summary>
					/// Returns 185
					/// </summary>
					public const System.Int32 ColumnIndex = 185;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field EntentePaiementID_Email via shared members
				/// </summary>
				public sealed class Column_EntentePaiementID_Email {

					/// <summary>
					/// Returns "EntentePaiementID_Email"
					/// </summary>
					public const System.String ColumnName = "EntentePaiementID_Email";
					/// <summary>
					/// Returns 186
					/// </summary>
					public const System.Int32 ColumnIndex = 186;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field EntentePaiementID_WWW via shared members
				/// </summary>
				public sealed class Column_EntentePaiementID_WWW {

					/// <summary>
					/// Returns "EntentePaiementID_WWW"
					/// </summary>
					public const System.String ColumnName = "EntentePaiementID_WWW";
					/// <summary>
					/// Returns 187
					/// </summary>
					public const System.Int32 ColumnIndex = 187;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field EntentePaiementID_Commentaires via shared members
				/// </summary>
				public sealed class Column_EntentePaiementID_Commentaires {

					/// <summary>
					/// Returns "EntentePaiementID_Commentaires"
					/// </summary>
					public const System.String ColumnName = "EntentePaiementID_Commentaires";
					/// <summary>
					/// Returns 188
					/// </summary>
					public const System.Int32 ColumnIndex = 188;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field EntentePaiementID_AfficherCommentaires via shared members
				/// </summary>
				public sealed class Column_EntentePaiementID_AfficherCommentaires {

					/// <summary>
					/// Returns "EntentePaiementID_AfficherCommentaires"
					/// </summary>
					public const System.String ColumnName = "EntentePaiementID_AfficherCommentaires";
					/// <summary>
					/// Returns 189
					/// </summary>
					public const System.Int32 ColumnIndex = 189;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field EntentePaiementID_DepotDirect via shared members
				/// </summary>
				public sealed class Column_EntentePaiementID_DepotDirect {

					/// <summary>
					/// Returns "EntentePaiementID_DepotDirect"
					/// </summary>
					public const System.String ColumnName = "EntentePaiementID_DepotDirect";
					/// <summary>
					/// Returns 190
					/// </summary>
					public const System.Int32 ColumnIndex = 190;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field EntentePaiementID_InstitutionBanquaireID via shared members
				/// </summary>
				public sealed class Column_EntentePaiementID_InstitutionBanquaireID {

					/// <summary>
					/// Returns "EntentePaiementID_InstitutionBanquaireID"
					/// </summary>
					public const System.String ColumnName = "EntentePaiementID_InstitutionBanquaireID";
					/// <summary>
					/// Returns 191
					/// </summary>
					public const System.Int32 ColumnIndex = 191;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field EntentePaiementID_Banque_transit via shared members
				/// </summary>
				public sealed class Column_EntentePaiementID_Banque_transit {

					/// <summary>
					/// Returns "EntentePaiementID_Banque_transit"
					/// </summary>
					public const System.String ColumnName = "EntentePaiementID_Banque_transit";
					/// <summary>
					/// Returns 192
					/// </summary>
					public const System.Int32 ColumnIndex = 192;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field EntentePaiementID_Banque_folio via shared members
				/// </summary>
				public sealed class Column_EntentePaiementID_Banque_folio {

					/// <summary>
					/// Returns "EntentePaiementID_Banque_folio"
					/// </summary>
					public const System.String ColumnName = "EntentePaiementID_Banque_folio";
					/// <summary>
					/// Returns 193
					/// </summary>
					public const System.Int32 ColumnIndex = 193;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field EntentePaiementID_No_TPS via shared members
				/// </summary>
				public sealed class Column_EntentePaiementID_No_TPS {

					/// <summary>
					/// Returns "EntentePaiementID_No_TPS"
					/// </summary>
					public const System.String ColumnName = "EntentePaiementID_No_TPS";
					/// <summary>
					/// Returns 194
					/// </summary>
					public const System.Int32 ColumnIndex = 194;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field EntentePaiementID_No_TVQ via shared members
				/// </summary>
				public sealed class Column_EntentePaiementID_No_TVQ {

					/// <summary>
					/// Returns "EntentePaiementID_No_TVQ"
					/// </summary>
					public const System.String ColumnName = "EntentePaiementID_No_TVQ";
					/// <summary>
					/// Returns 195
					/// </summary>
					public const System.Int32 ColumnIndex = 195;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field EntentePaiementID_PayerA via shared members
				/// </summary>
				public sealed class Column_EntentePaiementID_PayerA {

					/// <summary>
					/// Returns "EntentePaiementID_PayerA"
					/// </summary>
					public const System.String ColumnName = "EntentePaiementID_PayerA";
					/// <summary>
					/// Returns 196
					/// </summary>
					public const System.Int32 ColumnIndex = 196;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field EntentePaiementID_PayerAID via shared members
				/// </summary>
				public sealed class Column_EntentePaiementID_PayerAID {

					/// <summary>
					/// Returns "EntentePaiementID_PayerAID"
					/// </summary>
					public const System.String ColumnName = "EntentePaiementID_PayerAID";
					/// <summary>
					/// Returns 197
					/// </summary>
					public const System.Int32 ColumnIndex = 197;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field EntentePaiementID_Statut via shared members
				/// </summary>
				public sealed class Column_EntentePaiementID_Statut {

					/// <summary>
					/// Returns "EntentePaiementID_Statut"
					/// </summary>
					public const System.String ColumnName = "EntentePaiementID_Statut";
					/// <summary>
					/// Returns 198
					/// </summary>
					public const System.Int32 ColumnIndex = 198;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field EntentePaiementID_Rep_Nom via shared members
				/// </summary>
				public sealed class Column_EntentePaiementID_Rep_Nom {

					/// <summary>
					/// Returns "EntentePaiementID_Rep_Nom"
					/// </summary>
					public const System.String ColumnName = "EntentePaiementID_Rep_Nom";
					/// <summary>
					/// Returns 199
					/// </summary>
					public const System.Int32 ColumnIndex = 199;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field EntentePaiementID_Rep_Telephone via shared members
				/// </summary>
				public sealed class Column_EntentePaiementID_Rep_Telephone {

					/// <summary>
					/// Returns "EntentePaiementID_Rep_Telephone"
					/// </summary>
					public const System.String ColumnName = "EntentePaiementID_Rep_Telephone";
					/// <summary>
					/// Returns 200
					/// </summary>
					public const System.Int32 ColumnIndex = 200;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field EntentePaiementID_Rep_Telephone_Poste via shared members
				/// </summary>
				public sealed class Column_EntentePaiementID_Rep_Telephone_Poste {

					/// <summary>
					/// Returns "EntentePaiementID_Rep_Telephone_Poste"
					/// </summary>
					public const System.String ColumnName = "EntentePaiementID_Rep_Telephone_Poste";
					/// <summary>
					/// Returns 201
					/// </summary>
					public const System.Int32 ColumnIndex = 201;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field EntentePaiementID_Rep_Email via shared members
				/// </summary>
				public sealed class Column_EntentePaiementID_Rep_Email {

					/// <summary>
					/// Returns "EntentePaiementID_Rep_Email"
					/// </summary>
					public const System.String ColumnName = "EntentePaiementID_Rep_Email";
					/// <summary>
					/// Returns 202
					/// </summary>
					public const System.Int32 ColumnIndex = 202;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field EntentePaiementID_EnAnglais via shared members
				/// </summary>
				public sealed class Column_EntentePaiementID_EnAnglais {

					/// <summary>
					/// Returns "EntentePaiementID_EnAnglais"
					/// </summary>
					public const System.String ColumnName = "EntentePaiementID_EnAnglais";
					/// <summary>
					/// Returns 203
					/// </summary>
					public const System.Int32 ColumnIndex = 203;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field EntentePaiementID_Actif via shared members
				/// </summary>
				public sealed class Column_EntentePaiementID_Actif {

					/// <summary>
					/// Returns "EntentePaiementID_Actif"
					/// </summary>
					public const System.String ColumnName = "EntentePaiementID_Actif";
					/// <summary>
					/// Returns 204
					/// </summary>
					public const System.Int32 ColumnIndex = 204;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field EntentePaiementID_MRCProducteurID via shared members
				/// </summary>
				public sealed class Column_EntentePaiementID_MRCProducteurID {

					/// <summary>
					/// Returns "EntentePaiementID_MRCProducteurID"
					/// </summary>
					public const System.String ColumnName = "EntentePaiementID_MRCProducteurID";
					/// <summary>
					/// Returns 205
					/// </summary>
					public const System.Int32 ColumnIndex = 205;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field EntentePaiementID_PaiementManuel via shared members
				/// </summary>
				public sealed class Column_EntentePaiementID_PaiementManuel {

					/// <summary>
					/// Returns "EntentePaiementID_PaiementManuel"
					/// </summary>
					public const System.String ColumnName = "EntentePaiementID_PaiementManuel";
					/// <summary>
					/// Returns 206
					/// </summary>
					public const System.Int32 ColumnIndex = 206;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field EntentePaiementID_Journal via shared members
				/// </summary>
				public sealed class Column_EntentePaiementID_Journal {

					/// <summary>
					/// Returns "EntentePaiementID_Journal"
					/// </summary>
					public const System.String ColumnName = "EntentePaiementID_Journal";
					/// <summary>
					/// Returns 207
					/// </summary>
					public const System.Int32 ColumnIndex = 207;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field EntentePaiementID_RecoitTPS via shared members
				/// </summary>
				public sealed class Column_EntentePaiementID_RecoitTPS {

					/// <summary>
					/// Returns "EntentePaiementID_RecoitTPS"
					/// </summary>
					public const System.String ColumnName = "EntentePaiementID_RecoitTPS";
					/// <summary>
					/// Returns 208
					/// </summary>
					public const System.Int32 ColumnIndex = 208;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field EntentePaiementID_RecoitTVQ via shared members
				/// </summary>
				public sealed class Column_EntentePaiementID_RecoitTVQ {

					/// <summary>
					/// Returns "EntentePaiementID_RecoitTVQ"
					/// </summary>
					public const System.String ColumnName = "EntentePaiementID_RecoitTVQ";
					/// <summary>
					/// Returns 209
					/// </summary>
					public const System.Int32 ColumnIndex = 209;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field EntentePaiementID_ModifierTrigger via shared members
				/// </summary>
				public sealed class Column_EntentePaiementID_ModifierTrigger {

					/// <summary>
					/// Returns "EntentePaiementID_ModifierTrigger"
					/// </summary>
					public const System.String ColumnName = "EntentePaiementID_ModifierTrigger";
					/// <summary>
					/// Returns 210
					/// </summary>
					public const System.Int32 ColumnIndex = 210;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field EntentePaiementID_IsProducteur via shared members
				/// </summary>
				public sealed class Column_EntentePaiementID_IsProducteur {

					/// <summary>
					/// Returns "EntentePaiementID_IsProducteur"
					/// </summary>
					public const System.String ColumnName = "EntentePaiementID_IsProducteur";
					/// <summary>
					/// Returns 211
					/// </summary>
					public const System.Int32 ColumnIndex = 211;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field EntentePaiementID_IsTransporteur via shared members
				/// </summary>
				public sealed class Column_EntentePaiementID_IsTransporteur {

					/// <summary>
					/// Returns "EntentePaiementID_IsTransporteur"
					/// </summary>
					public const System.String ColumnName = "EntentePaiementID_IsTransporteur";
					/// <summary>
					/// Returns 212
					/// </summary>
					public const System.Int32 ColumnIndex = 212;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field EntentePaiementID_IsChargeur via shared members
				/// </summary>
				public sealed class Column_EntentePaiementID_IsChargeur {

					/// <summary>
					/// Returns "EntentePaiementID_IsChargeur"
					/// </summary>
					public const System.String ColumnName = "EntentePaiementID_IsChargeur";
					/// <summary>
					/// Returns 213
					/// </summary>
					public const System.Int32 ColumnIndex = 213;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field EntentePaiementID_IsAutre via shared members
				/// </summary>
				public sealed class Column_EntentePaiementID_IsAutre {

					/// <summary>
					/// Returns "EntentePaiementID_IsAutre"
					/// </summary>
					public const System.String ColumnName = "EntentePaiementID_IsAutre";
					/// <summary>
					/// Returns 214
					/// </summary>
					public const System.Int32 ColumnIndex = 214;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field EntentePaiementID_AfficherCommentairesSurPermit via shared members
				/// </summary>
				public sealed class Column_EntentePaiementID_AfficherCommentairesSurPermit {

					/// <summary>
					/// Returns "EntentePaiementID_AfficherCommentairesSurPermit"
					/// </summary>
					public const System.String ColumnName = "EntentePaiementID_AfficherCommentairesSurPermit";
					/// <summary>
					/// Returns 215
					/// </summary>
					public const System.Int32 ColumnIndex = 215;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field EntentePaiementID_PasEmissionPermis via shared members
				/// </summary>
				public sealed class Column_EntentePaiementID_PasEmissionPermis {

					/// <summary>
					/// Returns "EntentePaiementID_PasEmissionPermis"
					/// </summary>
					public const System.String ColumnName = "EntentePaiementID_PasEmissionPermis";
					/// <summary>
					/// Returns 216
					/// </summary>
					public const System.Int32 ColumnIndex = 216;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field EntentePaiementID_Generique via shared members
				/// </summary>
				public sealed class Column_EntentePaiementID_Generique {

					/// <summary>
					/// Returns "EntentePaiementID_Generique"
					/// </summary>
					public const System.String ColumnName = "EntentePaiementID_Generique";
					/// <summary>
					/// Returns 217
					/// </summary>
					public const System.Int32 ColumnIndex = 217;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field EntentePaiementID_Membre_OGC via shared members
				/// </summary>
				public sealed class Column_EntentePaiementID_Membre_OGC {

					/// <summary>
					/// Returns "EntentePaiementID_Membre_OGC"
					/// </summary>
					public const System.String ColumnName = "EntentePaiementID_Membre_OGC";
					/// <summary>
					/// Returns 218
					/// </summary>
					public const System.Int32 ColumnIndex = 218;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field EntentePaiementID_InscritTPS via shared members
				/// </summary>
				public sealed class Column_EntentePaiementID_InscritTPS {

					/// <summary>
					/// Returns "EntentePaiementID_InscritTPS"
					/// </summary>
					public const System.String ColumnName = "EntentePaiementID_InscritTPS";
					/// <summary>
					/// Returns 219
					/// </summary>
					public const System.Int32 ColumnIndex = 219;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field EntentePaiementID_InscritTVQ via shared members
				/// </summary>
				public sealed class Column_EntentePaiementID_InscritTVQ {

					/// <summary>
					/// Returns "EntentePaiementID_InscritTVQ"
					/// </summary>
					public const System.String ColumnName = "EntentePaiementID_InscritTVQ";
					/// <summary>
					/// Returns 220
					/// </summary>
					public const System.Int32 ColumnIndex = 220;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field EntentePaiementID_IsOGC via shared members
				/// </summary>
				public sealed class Column_EntentePaiementID_IsOGC {

					/// <summary>
					/// Returns "EntentePaiementID_IsOGC"
					/// </summary>
					public const System.String ColumnName = "EntentePaiementID_IsOGC";
					/// <summary>
					/// Returns 221
					/// </summary>
					public const System.Int32 ColumnIndex = 221;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field TransporteurID_ID via shared members
				/// </summary>
				public sealed class Column_TransporteurID_ID {

					/// <summary>
					/// Returns "TransporteurID_ID"
					/// </summary>
					public const System.String ColumnName = "TransporteurID_ID";
					/// <summary>
					/// Returns 222
					/// </summary>
					public const System.Int32 ColumnIndex = 222;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field TransporteurID_CleTri via shared members
				/// </summary>
				public sealed class Column_TransporteurID_CleTri {

					/// <summary>
					/// Returns "TransporteurID_CleTri"
					/// </summary>
					public const System.String ColumnName = "TransporteurID_CleTri";
					/// <summary>
					/// Returns 223
					/// </summary>
					public const System.Int32 ColumnIndex = 223;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field TransporteurID_Nom via shared members
				/// </summary>
				public sealed class Column_TransporteurID_Nom {

					/// <summary>
					/// Returns "TransporteurID_Nom"
					/// </summary>
					public const System.String ColumnName = "TransporteurID_Nom";
					/// <summary>
					/// Returns 224
					/// </summary>
					public const System.Int32 ColumnIndex = 224;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field TransporteurID_AuSoinsDe via shared members
				/// </summary>
				public sealed class Column_TransporteurID_AuSoinsDe {

					/// <summary>
					/// Returns "TransporteurID_AuSoinsDe"
					/// </summary>
					public const System.String ColumnName = "TransporteurID_AuSoinsDe";
					/// <summary>
					/// Returns 225
					/// </summary>
					public const System.Int32 ColumnIndex = 225;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field TransporteurID_Rue via shared members
				/// </summary>
				public sealed class Column_TransporteurID_Rue {

					/// <summary>
					/// Returns "TransporteurID_Rue"
					/// </summary>
					public const System.String ColumnName = "TransporteurID_Rue";
					/// <summary>
					/// Returns 226
					/// </summary>
					public const System.Int32 ColumnIndex = 226;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field TransporteurID_Ville via shared members
				/// </summary>
				public sealed class Column_TransporteurID_Ville {

					/// <summary>
					/// Returns "TransporteurID_Ville"
					/// </summary>
					public const System.String ColumnName = "TransporteurID_Ville";
					/// <summary>
					/// Returns 227
					/// </summary>
					public const System.Int32 ColumnIndex = 227;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field TransporteurID_PaysID via shared members
				/// </summary>
				public sealed class Column_TransporteurID_PaysID {

					/// <summary>
					/// Returns "TransporteurID_PaysID"
					/// </summary>
					public const System.String ColumnName = "TransporteurID_PaysID";
					/// <summary>
					/// Returns 228
					/// </summary>
					public const System.Int32 ColumnIndex = 228;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field TransporteurID_Code_postal via shared members
				/// </summary>
				public sealed class Column_TransporteurID_Code_postal {

					/// <summary>
					/// Returns "TransporteurID_Code_postal"
					/// </summary>
					public const System.String ColumnName = "TransporteurID_Code_postal";
					/// <summary>
					/// Returns 229
					/// </summary>
					public const System.Int32 ColumnIndex = 229;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field TransporteurID_Telephone via shared members
				/// </summary>
				public sealed class Column_TransporteurID_Telephone {

					/// <summary>
					/// Returns "TransporteurID_Telephone"
					/// </summary>
					public const System.String ColumnName = "TransporteurID_Telephone";
					/// <summary>
					/// Returns 230
					/// </summary>
					public const System.Int32 ColumnIndex = 230;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field TransporteurID_Telephone_Poste via shared members
				/// </summary>
				public sealed class Column_TransporteurID_Telephone_Poste {

					/// <summary>
					/// Returns "TransporteurID_Telephone_Poste"
					/// </summary>
					public const System.String ColumnName = "TransporteurID_Telephone_Poste";
					/// <summary>
					/// Returns 231
					/// </summary>
					public const System.Int32 ColumnIndex = 231;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field TransporteurID_Telecopieur via shared members
				/// </summary>
				public sealed class Column_TransporteurID_Telecopieur {

					/// <summary>
					/// Returns "TransporteurID_Telecopieur"
					/// </summary>
					public const System.String ColumnName = "TransporteurID_Telecopieur";
					/// <summary>
					/// Returns 232
					/// </summary>
					public const System.Int32 ColumnIndex = 232;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field TransporteurID_Telephone2 via shared members
				/// </summary>
				public sealed class Column_TransporteurID_Telephone2 {

					/// <summary>
					/// Returns "TransporteurID_Telephone2"
					/// </summary>
					public const System.String ColumnName = "TransporteurID_Telephone2";
					/// <summary>
					/// Returns 233
					/// </summary>
					public const System.Int32 ColumnIndex = 233;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field TransporteurID_Telephone2_Desc via shared members
				/// </summary>
				public sealed class Column_TransporteurID_Telephone2_Desc {

					/// <summary>
					/// Returns "TransporteurID_Telephone2_Desc"
					/// </summary>
					public const System.String ColumnName = "TransporteurID_Telephone2_Desc";
					/// <summary>
					/// Returns 234
					/// </summary>
					public const System.Int32 ColumnIndex = 234;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field TransporteurID_Telephone2_Poste via shared members
				/// </summary>
				public sealed class Column_TransporteurID_Telephone2_Poste {

					/// <summary>
					/// Returns "TransporteurID_Telephone2_Poste"
					/// </summary>
					public const System.String ColumnName = "TransporteurID_Telephone2_Poste";
					/// <summary>
					/// Returns 235
					/// </summary>
					public const System.Int32 ColumnIndex = 235;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field TransporteurID_Telephone3 via shared members
				/// </summary>
				public sealed class Column_TransporteurID_Telephone3 {

					/// <summary>
					/// Returns "TransporteurID_Telephone3"
					/// </summary>
					public const System.String ColumnName = "TransporteurID_Telephone3";
					/// <summary>
					/// Returns 236
					/// </summary>
					public const System.Int32 ColumnIndex = 236;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field TransporteurID_Telephone3_Desc via shared members
				/// </summary>
				public sealed class Column_TransporteurID_Telephone3_Desc {

					/// <summary>
					/// Returns "TransporteurID_Telephone3_Desc"
					/// </summary>
					public const System.String ColumnName = "TransporteurID_Telephone3_Desc";
					/// <summary>
					/// Returns 237
					/// </summary>
					public const System.Int32 ColumnIndex = 237;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field TransporteurID_Telephone3_Poste via shared members
				/// </summary>
				public sealed class Column_TransporteurID_Telephone3_Poste {

					/// <summary>
					/// Returns "TransporteurID_Telephone3_Poste"
					/// </summary>
					public const System.String ColumnName = "TransporteurID_Telephone3_Poste";
					/// <summary>
					/// Returns 238
					/// </summary>
					public const System.Int32 ColumnIndex = 238;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field TransporteurID_No_membre via shared members
				/// </summary>
				public sealed class Column_TransporteurID_No_membre {

					/// <summary>
					/// Returns "TransporteurID_No_membre"
					/// </summary>
					public const System.String ColumnName = "TransporteurID_No_membre";
					/// <summary>
					/// Returns 239
					/// </summary>
					public const System.Int32 ColumnIndex = 239;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field TransporteurID_Resident via shared members
				/// </summary>
				public sealed class Column_TransporteurID_Resident {

					/// <summary>
					/// Returns "TransporteurID_Resident"
					/// </summary>
					public const System.String ColumnName = "TransporteurID_Resident";
					/// <summary>
					/// Returns 240
					/// </summary>
					public const System.Int32 ColumnIndex = 240;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field TransporteurID_Email via shared members
				/// </summary>
				public sealed class Column_TransporteurID_Email {

					/// <summary>
					/// Returns "TransporteurID_Email"
					/// </summary>
					public const System.String ColumnName = "TransporteurID_Email";
					/// <summary>
					/// Returns 241
					/// </summary>
					public const System.Int32 ColumnIndex = 241;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field TransporteurID_WWW via shared members
				/// </summary>
				public sealed class Column_TransporteurID_WWW {

					/// <summary>
					/// Returns "TransporteurID_WWW"
					/// </summary>
					public const System.String ColumnName = "TransporteurID_WWW";
					/// <summary>
					/// Returns 242
					/// </summary>
					public const System.Int32 ColumnIndex = 242;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field TransporteurID_Commentaires via shared members
				/// </summary>
				public sealed class Column_TransporteurID_Commentaires {

					/// <summary>
					/// Returns "TransporteurID_Commentaires"
					/// </summary>
					public const System.String ColumnName = "TransporteurID_Commentaires";
					/// <summary>
					/// Returns 243
					/// </summary>
					public const System.Int32 ColumnIndex = 243;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field TransporteurID_AfficherCommentaires via shared members
				/// </summary>
				public sealed class Column_TransporteurID_AfficherCommentaires {

					/// <summary>
					/// Returns "TransporteurID_AfficherCommentaires"
					/// </summary>
					public const System.String ColumnName = "TransporteurID_AfficherCommentaires";
					/// <summary>
					/// Returns 244
					/// </summary>
					public const System.Int32 ColumnIndex = 244;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field TransporteurID_DepotDirect via shared members
				/// </summary>
				public sealed class Column_TransporteurID_DepotDirect {

					/// <summary>
					/// Returns "TransporteurID_DepotDirect"
					/// </summary>
					public const System.String ColumnName = "TransporteurID_DepotDirect";
					/// <summary>
					/// Returns 245
					/// </summary>
					public const System.Int32 ColumnIndex = 245;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field TransporteurID_InstitutionBanquaireID via shared members
				/// </summary>
				public sealed class Column_TransporteurID_InstitutionBanquaireID {

					/// <summary>
					/// Returns "TransporteurID_InstitutionBanquaireID"
					/// </summary>
					public const System.String ColumnName = "TransporteurID_InstitutionBanquaireID";
					/// <summary>
					/// Returns 246
					/// </summary>
					public const System.Int32 ColumnIndex = 246;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field TransporteurID_Banque_transit via shared members
				/// </summary>
				public sealed class Column_TransporteurID_Banque_transit {

					/// <summary>
					/// Returns "TransporteurID_Banque_transit"
					/// </summary>
					public const System.String ColumnName = "TransporteurID_Banque_transit";
					/// <summary>
					/// Returns 247
					/// </summary>
					public const System.Int32 ColumnIndex = 247;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field TransporteurID_Banque_folio via shared members
				/// </summary>
				public sealed class Column_TransporteurID_Banque_folio {

					/// <summary>
					/// Returns "TransporteurID_Banque_folio"
					/// </summary>
					public const System.String ColumnName = "TransporteurID_Banque_folio";
					/// <summary>
					/// Returns 248
					/// </summary>
					public const System.Int32 ColumnIndex = 248;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field TransporteurID_No_TPS via shared members
				/// </summary>
				public sealed class Column_TransporteurID_No_TPS {

					/// <summary>
					/// Returns "TransporteurID_No_TPS"
					/// </summary>
					public const System.String ColumnName = "TransporteurID_No_TPS";
					/// <summary>
					/// Returns 249
					/// </summary>
					public const System.Int32 ColumnIndex = 249;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field TransporteurID_No_TVQ via shared members
				/// </summary>
				public sealed class Column_TransporteurID_No_TVQ {

					/// <summary>
					/// Returns "TransporteurID_No_TVQ"
					/// </summary>
					public const System.String ColumnName = "TransporteurID_No_TVQ";
					/// <summary>
					/// Returns 250
					/// </summary>
					public const System.Int32 ColumnIndex = 250;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field TransporteurID_PayerA via shared members
				/// </summary>
				public sealed class Column_TransporteurID_PayerA {

					/// <summary>
					/// Returns "TransporteurID_PayerA"
					/// </summary>
					public const System.String ColumnName = "TransporteurID_PayerA";
					/// <summary>
					/// Returns 251
					/// </summary>
					public const System.Int32 ColumnIndex = 251;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field TransporteurID_PayerAID via shared members
				/// </summary>
				public sealed class Column_TransporteurID_PayerAID {

					/// <summary>
					/// Returns "TransporteurID_PayerAID"
					/// </summary>
					public const System.String ColumnName = "TransporteurID_PayerAID";
					/// <summary>
					/// Returns 252
					/// </summary>
					public const System.Int32 ColumnIndex = 252;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field TransporteurID_Statut via shared members
				/// </summary>
				public sealed class Column_TransporteurID_Statut {

					/// <summary>
					/// Returns "TransporteurID_Statut"
					/// </summary>
					public const System.String ColumnName = "TransporteurID_Statut";
					/// <summary>
					/// Returns 253
					/// </summary>
					public const System.Int32 ColumnIndex = 253;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field TransporteurID_Rep_Nom via shared members
				/// </summary>
				public sealed class Column_TransporteurID_Rep_Nom {

					/// <summary>
					/// Returns "TransporteurID_Rep_Nom"
					/// </summary>
					public const System.String ColumnName = "TransporteurID_Rep_Nom";
					/// <summary>
					/// Returns 254
					/// </summary>
					public const System.Int32 ColumnIndex = 254;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field TransporteurID_Rep_Telephone via shared members
				/// </summary>
				public sealed class Column_TransporteurID_Rep_Telephone {

					/// <summary>
					/// Returns "TransporteurID_Rep_Telephone"
					/// </summary>
					public const System.String ColumnName = "TransporteurID_Rep_Telephone";
					/// <summary>
					/// Returns 255
					/// </summary>
					public const System.Int32 ColumnIndex = 255;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field TransporteurID_Rep_Telephone_Poste via shared members
				/// </summary>
				public sealed class Column_TransporteurID_Rep_Telephone_Poste {

					/// <summary>
					/// Returns "TransporteurID_Rep_Telephone_Poste"
					/// </summary>
					public const System.String ColumnName = "TransporteurID_Rep_Telephone_Poste";
					/// <summary>
					/// Returns 256
					/// </summary>
					public const System.Int32 ColumnIndex = 256;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field TransporteurID_Rep_Email via shared members
				/// </summary>
				public sealed class Column_TransporteurID_Rep_Email {

					/// <summary>
					/// Returns "TransporteurID_Rep_Email"
					/// </summary>
					public const System.String ColumnName = "TransporteurID_Rep_Email";
					/// <summary>
					/// Returns 257
					/// </summary>
					public const System.Int32 ColumnIndex = 257;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field TransporteurID_EnAnglais via shared members
				/// </summary>
				public sealed class Column_TransporteurID_EnAnglais {

					/// <summary>
					/// Returns "TransporteurID_EnAnglais"
					/// </summary>
					public const System.String ColumnName = "TransporteurID_EnAnglais";
					/// <summary>
					/// Returns 258
					/// </summary>
					public const System.Int32 ColumnIndex = 258;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field TransporteurID_Actif via shared members
				/// </summary>
				public sealed class Column_TransporteurID_Actif {

					/// <summary>
					/// Returns "TransporteurID_Actif"
					/// </summary>
					public const System.String ColumnName = "TransporteurID_Actif";
					/// <summary>
					/// Returns 259
					/// </summary>
					public const System.Int32 ColumnIndex = 259;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field TransporteurID_MRCProducteurID via shared members
				/// </summary>
				public sealed class Column_TransporteurID_MRCProducteurID {

					/// <summary>
					/// Returns "TransporteurID_MRCProducteurID"
					/// </summary>
					public const System.String ColumnName = "TransporteurID_MRCProducteurID";
					/// <summary>
					/// Returns 260
					/// </summary>
					public const System.Int32 ColumnIndex = 260;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field TransporteurID_PaiementManuel via shared members
				/// </summary>
				public sealed class Column_TransporteurID_PaiementManuel {

					/// <summary>
					/// Returns "TransporteurID_PaiementManuel"
					/// </summary>
					public const System.String ColumnName = "TransporteurID_PaiementManuel";
					/// <summary>
					/// Returns 261
					/// </summary>
					public const System.Int32 ColumnIndex = 261;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field TransporteurID_Journal via shared members
				/// </summary>
				public sealed class Column_TransporteurID_Journal {

					/// <summary>
					/// Returns "TransporteurID_Journal"
					/// </summary>
					public const System.String ColumnName = "TransporteurID_Journal";
					/// <summary>
					/// Returns 262
					/// </summary>
					public const System.Int32 ColumnIndex = 262;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field TransporteurID_RecoitTPS via shared members
				/// </summary>
				public sealed class Column_TransporteurID_RecoitTPS {

					/// <summary>
					/// Returns "TransporteurID_RecoitTPS"
					/// </summary>
					public const System.String ColumnName = "TransporteurID_RecoitTPS";
					/// <summary>
					/// Returns 263
					/// </summary>
					public const System.Int32 ColumnIndex = 263;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field TransporteurID_RecoitTVQ via shared members
				/// </summary>
				public sealed class Column_TransporteurID_RecoitTVQ {

					/// <summary>
					/// Returns "TransporteurID_RecoitTVQ"
					/// </summary>
					public const System.String ColumnName = "TransporteurID_RecoitTVQ";
					/// <summary>
					/// Returns 264
					/// </summary>
					public const System.Int32 ColumnIndex = 264;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field TransporteurID_ModifierTrigger via shared members
				/// </summary>
				public sealed class Column_TransporteurID_ModifierTrigger {

					/// <summary>
					/// Returns "TransporteurID_ModifierTrigger"
					/// </summary>
					public const System.String ColumnName = "TransporteurID_ModifierTrigger";
					/// <summary>
					/// Returns 265
					/// </summary>
					public const System.Int32 ColumnIndex = 265;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field TransporteurID_IsProducteur via shared members
				/// </summary>
				public sealed class Column_TransporteurID_IsProducteur {

					/// <summary>
					/// Returns "TransporteurID_IsProducteur"
					/// </summary>
					public const System.String ColumnName = "TransporteurID_IsProducteur";
					/// <summary>
					/// Returns 266
					/// </summary>
					public const System.Int32 ColumnIndex = 266;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field TransporteurID_IsTransporteur via shared members
				/// </summary>
				public sealed class Column_TransporteurID_IsTransporteur {

					/// <summary>
					/// Returns "TransporteurID_IsTransporteur"
					/// </summary>
					public const System.String ColumnName = "TransporteurID_IsTransporteur";
					/// <summary>
					/// Returns 267
					/// </summary>
					public const System.Int32 ColumnIndex = 267;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field TransporteurID_IsChargeur via shared members
				/// </summary>
				public sealed class Column_TransporteurID_IsChargeur {

					/// <summary>
					/// Returns "TransporteurID_IsChargeur"
					/// </summary>
					public const System.String ColumnName = "TransporteurID_IsChargeur";
					/// <summary>
					/// Returns 268
					/// </summary>
					public const System.Int32 ColumnIndex = 268;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field TransporteurID_IsAutre via shared members
				/// </summary>
				public sealed class Column_TransporteurID_IsAutre {

					/// <summary>
					/// Returns "TransporteurID_IsAutre"
					/// </summary>
					public const System.String ColumnName = "TransporteurID_IsAutre";
					/// <summary>
					/// Returns 269
					/// </summary>
					public const System.Int32 ColumnIndex = 269;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field TransporteurID_AfficherCommentairesSurPermit via shared members
				/// </summary>
				public sealed class Column_TransporteurID_AfficherCommentairesSurPermit {

					/// <summary>
					/// Returns "TransporteurID_AfficherCommentairesSurPermit"
					/// </summary>
					public const System.String ColumnName = "TransporteurID_AfficherCommentairesSurPermit";
					/// <summary>
					/// Returns 270
					/// </summary>
					public const System.Int32 ColumnIndex = 270;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field TransporteurID_PasEmissionPermis via shared members
				/// </summary>
				public sealed class Column_TransporteurID_PasEmissionPermis {

					/// <summary>
					/// Returns "TransporteurID_PasEmissionPermis"
					/// </summary>
					public const System.String ColumnName = "TransporteurID_PasEmissionPermis";
					/// <summary>
					/// Returns 271
					/// </summary>
					public const System.Int32 ColumnIndex = 271;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field TransporteurID_Generique via shared members
				/// </summary>
				public sealed class Column_TransporteurID_Generique {

					/// <summary>
					/// Returns "TransporteurID_Generique"
					/// </summary>
					public const System.String ColumnName = "TransporteurID_Generique";
					/// <summary>
					/// Returns 272
					/// </summary>
					public const System.Int32 ColumnIndex = 272;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field TransporteurID_Membre_OGC via shared members
				/// </summary>
				public sealed class Column_TransporteurID_Membre_OGC {

					/// <summary>
					/// Returns "TransporteurID_Membre_OGC"
					/// </summary>
					public const System.String ColumnName = "TransporteurID_Membre_OGC";
					/// <summary>
					/// Returns 273
					/// </summary>
					public const System.Int32 ColumnIndex = 273;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field TransporteurID_InscritTPS via shared members
				/// </summary>
				public sealed class Column_TransporteurID_InscritTPS {

					/// <summary>
					/// Returns "TransporteurID_InscritTPS"
					/// </summary>
					public const System.String ColumnName = "TransporteurID_InscritTPS";
					/// <summary>
					/// Returns 274
					/// </summary>
					public const System.Int32 ColumnIndex = 274;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field TransporteurID_InscritTVQ via shared members
				/// </summary>
				public sealed class Column_TransporteurID_InscritTVQ {

					/// <summary>
					/// Returns "TransporteurID_InscritTVQ"
					/// </summary>
					public const System.String ColumnName = "TransporteurID_InscritTVQ";
					/// <summary>
					/// Returns 275
					/// </summary>
					public const System.Int32 ColumnIndex = 275;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field TransporteurID_IsOGC via shared members
				/// </summary>
				public sealed class Column_TransporteurID_IsOGC {

					/// <summary>
					/// Returns "TransporteurID_IsOGC"
					/// </summary>
					public const System.String ColumnName = "TransporteurID_IsOGC";
					/// <summary>
					/// Returns 276
					/// </summary>
					public const System.Int32 ColumnIndex = 276;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Annee_Annee via shared members
				/// </summary>
				public sealed class Column_Annee_Annee {

					/// <summary>
					/// Returns "Annee_Annee"
					/// </summary>
					public const System.String ColumnName = "Annee_Annee";
					/// <summary>
					/// Returns 277
					/// </summary>
					public const System.Int32 ColumnIndex = 277;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Annee_SemaineNo via shared members
				/// </summary>
				public sealed class Column_Annee_SemaineNo {

					/// <summary>
					/// Returns "Annee_SemaineNo"
					/// </summary>
					public const System.String ColumnName = "Annee_SemaineNo";
					/// <summary>
					/// Returns 278
					/// </summary>
					public const System.Int32 ColumnIndex = 278;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Annee_DateDebut via shared members
				/// </summary>
				public sealed class Column_Annee_DateDebut {

					/// <summary>
					/// Returns "Annee_DateDebut"
					/// </summary>
					public const System.String ColumnName = "Annee_DateDebut";
					/// <summary>
					/// Returns 279
					/// </summary>
					public const System.Int32 ColumnIndex = 279;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Annee_DateFin via shared members
				/// </summary>
				public sealed class Column_Annee_DateFin {

					/// <summary>
					/// Returns "Annee_DateFin"
					/// </summary>
					public const System.String ColumnName = "Annee_DateFin";
					/// <summary>
					/// Returns 280
					/// </summary>
					public const System.Int32 ColumnIndex = 280;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Annee_PeriodeContingentement via shared members
				/// </summary>
				public sealed class Column_Annee_PeriodeContingentement {

					/// <summary>
					/// Returns "Annee_PeriodeContingentement"
					/// </summary>
					public const System.String ColumnName = "Annee_PeriodeContingentement";
					/// <summary>
					/// Returns 281
					/// </summary>
					public const System.Int32 ColumnIndex = 281;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Periode_Annee via shared members
				/// </summary>
				public sealed class Column_Periode_Annee {

					/// <summary>
					/// Returns "Periode_Annee"
					/// </summary>
					public const System.String ColumnName = "Periode_Annee";
					/// <summary>
					/// Returns 282
					/// </summary>
					public const System.Int32 ColumnIndex = 282;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Periode_SemaineNo via shared members
				/// </summary>
				public sealed class Column_Periode_SemaineNo {

					/// <summary>
					/// Returns "Periode_SemaineNo"
					/// </summary>
					public const System.String ColumnName = "Periode_SemaineNo";
					/// <summary>
					/// Returns 283
					/// </summary>
					public const System.Int32 ColumnIndex = 283;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Periode_DateDebut via shared members
				/// </summary>
				public sealed class Column_Periode_DateDebut {

					/// <summary>
					/// Returns "Periode_DateDebut"
					/// </summary>
					public const System.String ColumnName = "Periode_DateDebut";
					/// <summary>
					/// Returns 284
					/// </summary>
					public const System.Int32 ColumnIndex = 284;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Periode_DateFin via shared members
				/// </summary>
				public sealed class Column_Periode_DateFin {

					/// <summary>
					/// Returns "Periode_DateFin"
					/// </summary>
					public const System.String ColumnName = "Periode_DateFin";
					/// <summary>
					/// Returns 285
					/// </summary>
					public const System.Int32 ColumnIndex = 285;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Periode_PeriodeContingentement via shared members
				/// </summary>
				public sealed class Column_Periode_PeriodeContingentement {

					/// <summary>
					/// Returns "Periode_PeriodeContingentement"
					/// </summary>
					public const System.String ColumnName = "Periode_PeriodeContingentement";
					/// <summary>
					/// Returns 286
					/// </summary>
					public const System.Int32 ColumnIndex = 286;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Producteur1_FactureID_ID via shared members
				/// </summary>
				public sealed class Column_Producteur1_FactureID_ID {

					/// <summary>
					/// Returns "Producteur1_FactureID_ID"
					/// </summary>
					public const System.String ColumnName = "Producteur1_FactureID_ID";
					/// <summary>
					/// Returns 287
					/// </summary>
					public const System.Int32 ColumnIndex = 287;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Producteur1_FactureID_NoFacture via shared members
				/// </summary>
				public sealed class Column_Producteur1_FactureID_NoFacture {

					/// <summary>
					/// Returns "Producteur1_FactureID_NoFacture"
					/// </summary>
					public const System.String ColumnName = "Producteur1_FactureID_NoFacture";
					/// <summary>
					/// Returns 288
					/// </summary>
					public const System.Int32 ColumnIndex = 288;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Producteur1_FactureID_DateFacture via shared members
				/// </summary>
				public sealed class Column_Producteur1_FactureID_DateFacture {

					/// <summary>
					/// Returns "Producteur1_FactureID_DateFacture"
					/// </summary>
					public const System.String ColumnName = "Producteur1_FactureID_DateFacture";
					/// <summary>
					/// Returns 289
					/// </summary>
					public const System.Int32 ColumnIndex = 289;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Producteur1_FactureID_Annee via shared members
				/// </summary>
				public sealed class Column_Producteur1_FactureID_Annee {

					/// <summary>
					/// Returns "Producteur1_FactureID_Annee"
					/// </summary>
					public const System.String ColumnName = "Producteur1_FactureID_Annee";
					/// <summary>
					/// Returns 290
					/// </summary>
					public const System.Int32 ColumnIndex = 290;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Producteur1_FactureID_TypeFactureFournisseur via shared members
				/// </summary>
				public sealed class Column_Producteur1_FactureID_TypeFactureFournisseur {

					/// <summary>
					/// Returns "Producteur1_FactureID_TypeFactureFournisseur"
					/// </summary>
					public const System.String ColumnName = "Producteur1_FactureID_TypeFactureFournisseur";
					/// <summary>
					/// Returns 291
					/// </summary>
					public const System.Int32 ColumnIndex = 291;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Producteur1_FactureID_TypeFacture via shared members
				/// </summary>
				public sealed class Column_Producteur1_FactureID_TypeFacture {

					/// <summary>
					/// Returns "Producteur1_FactureID_TypeFacture"
					/// </summary>
					public const System.String ColumnName = "Producteur1_FactureID_TypeFacture";
					/// <summary>
					/// Returns 292
					/// </summary>
					public const System.Int32 ColumnIndex = 292;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Producteur1_FactureID_TypeInvoiceAcomba via shared members
				/// </summary>
				public sealed class Column_Producteur1_FactureID_TypeInvoiceAcomba {

					/// <summary>
					/// Returns "Producteur1_FactureID_TypeInvoiceAcomba"
					/// </summary>
					public const System.String ColumnName = "Producteur1_FactureID_TypeInvoiceAcomba";
					/// <summary>
					/// Returns 293
					/// </summary>
					public const System.Int32 ColumnIndex = 293;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Producteur1_FactureID_FournisseurID via shared members
				/// </summary>
				public sealed class Column_Producteur1_FactureID_FournisseurID {

					/// <summary>
					/// Returns "Producteur1_FactureID_FournisseurID"
					/// </summary>
					public const System.String ColumnName = "Producteur1_FactureID_FournisseurID";
					/// <summary>
					/// Returns 294
					/// </summary>
					public const System.Int32 ColumnIndex = 294;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Producteur1_FactureID_PayerAID via shared members
				/// </summary>
				public sealed class Column_Producteur1_FactureID_PayerAID {

					/// <summary>
					/// Returns "Producteur1_FactureID_PayerAID"
					/// </summary>
					public const System.String ColumnName = "Producteur1_FactureID_PayerAID";
					/// <summary>
					/// Returns 295
					/// </summary>
					public const System.Int32 ColumnIndex = 295;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Producteur1_FactureID_Montant_Total via shared members
				/// </summary>
				public sealed class Column_Producteur1_FactureID_Montant_Total {

					/// <summary>
					/// Returns "Producteur1_FactureID_Montant_Total"
					/// </summary>
					public const System.String ColumnName = "Producteur1_FactureID_Montant_Total";
					/// <summary>
					/// Returns 296
					/// </summary>
					public const System.Int32 ColumnIndex = 296;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Producteur1_FactureID_Montant_TPS via shared members
				/// </summary>
				public sealed class Column_Producteur1_FactureID_Montant_TPS {

					/// <summary>
					/// Returns "Producteur1_FactureID_Montant_TPS"
					/// </summary>
					public const System.String ColumnName = "Producteur1_FactureID_Montant_TPS";
					/// <summary>
					/// Returns 297
					/// </summary>
					public const System.Int32 ColumnIndex = 297;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Producteur1_FactureID_Montant_TVQ via shared members
				/// </summary>
				public sealed class Column_Producteur1_FactureID_Montant_TVQ {

					/// <summary>
					/// Returns "Producteur1_FactureID_Montant_TVQ"
					/// </summary>
					public const System.String ColumnName = "Producteur1_FactureID_Montant_TVQ";
					/// <summary>
					/// Returns 298
					/// </summary>
					public const System.Int32 ColumnIndex = 298;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Producteur1_FactureID_Description via shared members
				/// </summary>
				public sealed class Column_Producteur1_FactureID_Description {

					/// <summary>
					/// Returns "Producteur1_FactureID_Description"
					/// </summary>
					public const System.String ColumnName = "Producteur1_FactureID_Description";
					/// <summary>
					/// Returns 299
					/// </summary>
					public const System.Int32 ColumnIndex = 299;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Producteur1_FactureID_Status via shared members
				/// </summary>
				public sealed class Column_Producteur1_FactureID_Status {

					/// <summary>
					/// Returns "Producteur1_FactureID_Status"
					/// </summary>
					public const System.String ColumnName = "Producteur1_FactureID_Status";
					/// <summary>
					/// Returns 300
					/// </summary>
					public const System.Int32 ColumnIndex = 300;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Producteur1_FactureID_StatusDescription via shared members
				/// </summary>
				public sealed class Column_Producteur1_FactureID_StatusDescription {

					/// <summary>
					/// Returns "Producteur1_FactureID_StatusDescription"
					/// </summary>
					public const System.String ColumnName = "Producteur1_FactureID_StatusDescription";
					/// <summary>
					/// Returns 301
					/// </summary>
					public const System.Int32 ColumnIndex = 301;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Producteur1_FactureID_NumeroCheque via shared members
				/// </summary>
				public sealed class Column_Producteur1_FactureID_NumeroCheque {

					/// <summary>
					/// Returns "Producteur1_FactureID_NumeroCheque"
					/// </summary>
					public const System.String ColumnName = "Producteur1_FactureID_NumeroCheque";
					/// <summary>
					/// Returns 302
					/// </summary>
					public const System.Int32 ColumnIndex = 302;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Producteur1_FactureID_NumeroPaiement via shared members
				/// </summary>
				public sealed class Column_Producteur1_FactureID_NumeroPaiement {

					/// <summary>
					/// Returns "Producteur1_FactureID_NumeroPaiement"
					/// </summary>
					public const System.String ColumnName = "Producteur1_FactureID_NumeroPaiement";
					/// <summary>
					/// Returns 303
					/// </summary>
					public const System.Int32 ColumnIndex = 303;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Producteur1_FactureID_NumeroPaiementUnique via shared members
				/// </summary>
				public sealed class Column_Producteur1_FactureID_NumeroPaiementUnique {

					/// <summary>
					/// Returns "Producteur1_FactureID_NumeroPaiementUnique"
					/// </summary>
					public const System.String ColumnName = "Producteur1_FactureID_NumeroPaiementUnique";
					/// <summary>
					/// Returns 304
					/// </summary>
					public const System.Int32 ColumnIndex = 304;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Producteur1_FactureID_DateFactureAcomba via shared members
				/// </summary>
				public sealed class Column_Producteur1_FactureID_DateFactureAcomba {

					/// <summary>
					/// Returns "Producteur1_FactureID_DateFactureAcomba"
					/// </summary>
					public const System.String ColumnName = "Producteur1_FactureID_DateFactureAcomba";
					/// <summary>
					/// Returns 305
					/// </summary>
					public const System.Int32 ColumnIndex = 305;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Producteur1_FactureID_DatePaiementAcomba via shared members
				/// </summary>
				public sealed class Column_Producteur1_FactureID_DatePaiementAcomba {

					/// <summary>
					/// Returns "Producteur1_FactureID_DatePaiementAcomba"
					/// </summary>
					public const System.String ColumnName = "Producteur1_FactureID_DatePaiementAcomba";
					/// <summary>
					/// Returns 306
					/// </summary>
					public const System.Int32 ColumnIndex = 306;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Producteur2_FactureID_ID via shared members
				/// </summary>
				public sealed class Column_Producteur2_FactureID_ID {

					/// <summary>
					/// Returns "Producteur2_FactureID_ID"
					/// </summary>
					public const System.String ColumnName = "Producteur2_FactureID_ID";
					/// <summary>
					/// Returns 307
					/// </summary>
					public const System.Int32 ColumnIndex = 307;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Producteur2_FactureID_NoFacture via shared members
				/// </summary>
				public sealed class Column_Producteur2_FactureID_NoFacture {

					/// <summary>
					/// Returns "Producteur2_FactureID_NoFacture"
					/// </summary>
					public const System.String ColumnName = "Producteur2_FactureID_NoFacture";
					/// <summary>
					/// Returns 308
					/// </summary>
					public const System.Int32 ColumnIndex = 308;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Producteur2_FactureID_DateFacture via shared members
				/// </summary>
				public sealed class Column_Producteur2_FactureID_DateFacture {

					/// <summary>
					/// Returns "Producteur2_FactureID_DateFacture"
					/// </summary>
					public const System.String ColumnName = "Producteur2_FactureID_DateFacture";
					/// <summary>
					/// Returns 309
					/// </summary>
					public const System.Int32 ColumnIndex = 309;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Producteur2_FactureID_Annee via shared members
				/// </summary>
				public sealed class Column_Producteur2_FactureID_Annee {

					/// <summary>
					/// Returns "Producteur2_FactureID_Annee"
					/// </summary>
					public const System.String ColumnName = "Producteur2_FactureID_Annee";
					/// <summary>
					/// Returns 310
					/// </summary>
					public const System.Int32 ColumnIndex = 310;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Producteur2_FactureID_TypeFactureFournisseur via shared members
				/// </summary>
				public sealed class Column_Producteur2_FactureID_TypeFactureFournisseur {

					/// <summary>
					/// Returns "Producteur2_FactureID_TypeFactureFournisseur"
					/// </summary>
					public const System.String ColumnName = "Producteur2_FactureID_TypeFactureFournisseur";
					/// <summary>
					/// Returns 311
					/// </summary>
					public const System.Int32 ColumnIndex = 311;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Producteur2_FactureID_TypeFacture via shared members
				/// </summary>
				public sealed class Column_Producteur2_FactureID_TypeFacture {

					/// <summary>
					/// Returns "Producteur2_FactureID_TypeFacture"
					/// </summary>
					public const System.String ColumnName = "Producteur2_FactureID_TypeFacture";
					/// <summary>
					/// Returns 312
					/// </summary>
					public const System.Int32 ColumnIndex = 312;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Producteur2_FactureID_TypeInvoiceAcomba via shared members
				/// </summary>
				public sealed class Column_Producteur2_FactureID_TypeInvoiceAcomba {

					/// <summary>
					/// Returns "Producteur2_FactureID_TypeInvoiceAcomba"
					/// </summary>
					public const System.String ColumnName = "Producteur2_FactureID_TypeInvoiceAcomba";
					/// <summary>
					/// Returns 313
					/// </summary>
					public const System.Int32 ColumnIndex = 313;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Producteur2_FactureID_FournisseurID via shared members
				/// </summary>
				public sealed class Column_Producteur2_FactureID_FournisseurID {

					/// <summary>
					/// Returns "Producteur2_FactureID_FournisseurID"
					/// </summary>
					public const System.String ColumnName = "Producteur2_FactureID_FournisseurID";
					/// <summary>
					/// Returns 314
					/// </summary>
					public const System.Int32 ColumnIndex = 314;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Producteur2_FactureID_PayerAID via shared members
				/// </summary>
				public sealed class Column_Producteur2_FactureID_PayerAID {

					/// <summary>
					/// Returns "Producteur2_FactureID_PayerAID"
					/// </summary>
					public const System.String ColumnName = "Producteur2_FactureID_PayerAID";
					/// <summary>
					/// Returns 315
					/// </summary>
					public const System.Int32 ColumnIndex = 315;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Producteur2_FactureID_Montant_Total via shared members
				/// </summary>
				public sealed class Column_Producteur2_FactureID_Montant_Total {

					/// <summary>
					/// Returns "Producteur2_FactureID_Montant_Total"
					/// </summary>
					public const System.String ColumnName = "Producteur2_FactureID_Montant_Total";
					/// <summary>
					/// Returns 316
					/// </summary>
					public const System.Int32 ColumnIndex = 316;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Producteur2_FactureID_Montant_TPS via shared members
				/// </summary>
				public sealed class Column_Producteur2_FactureID_Montant_TPS {

					/// <summary>
					/// Returns "Producteur2_FactureID_Montant_TPS"
					/// </summary>
					public const System.String ColumnName = "Producteur2_FactureID_Montant_TPS";
					/// <summary>
					/// Returns 317
					/// </summary>
					public const System.Int32 ColumnIndex = 317;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Producteur2_FactureID_Montant_TVQ via shared members
				/// </summary>
				public sealed class Column_Producteur2_FactureID_Montant_TVQ {

					/// <summary>
					/// Returns "Producteur2_FactureID_Montant_TVQ"
					/// </summary>
					public const System.String ColumnName = "Producteur2_FactureID_Montant_TVQ";
					/// <summary>
					/// Returns 318
					/// </summary>
					public const System.Int32 ColumnIndex = 318;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Producteur2_FactureID_Description via shared members
				/// </summary>
				public sealed class Column_Producteur2_FactureID_Description {

					/// <summary>
					/// Returns "Producteur2_FactureID_Description"
					/// </summary>
					public const System.String ColumnName = "Producteur2_FactureID_Description";
					/// <summary>
					/// Returns 319
					/// </summary>
					public const System.Int32 ColumnIndex = 319;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Producteur2_FactureID_Status via shared members
				/// </summary>
				public sealed class Column_Producteur2_FactureID_Status {

					/// <summary>
					/// Returns "Producteur2_FactureID_Status"
					/// </summary>
					public const System.String ColumnName = "Producteur2_FactureID_Status";
					/// <summary>
					/// Returns 320
					/// </summary>
					public const System.Int32 ColumnIndex = 320;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Producteur2_FactureID_StatusDescription via shared members
				/// </summary>
				public sealed class Column_Producteur2_FactureID_StatusDescription {

					/// <summary>
					/// Returns "Producteur2_FactureID_StatusDescription"
					/// </summary>
					public const System.String ColumnName = "Producteur2_FactureID_StatusDescription";
					/// <summary>
					/// Returns 321
					/// </summary>
					public const System.Int32 ColumnIndex = 321;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Producteur2_FactureID_NumeroCheque via shared members
				/// </summary>
				public sealed class Column_Producteur2_FactureID_NumeroCheque {

					/// <summary>
					/// Returns "Producteur2_FactureID_NumeroCheque"
					/// </summary>
					public const System.String ColumnName = "Producteur2_FactureID_NumeroCheque";
					/// <summary>
					/// Returns 322
					/// </summary>
					public const System.Int32 ColumnIndex = 322;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Producteur2_FactureID_NumeroPaiement via shared members
				/// </summary>
				public sealed class Column_Producteur2_FactureID_NumeroPaiement {

					/// <summary>
					/// Returns "Producteur2_FactureID_NumeroPaiement"
					/// </summary>
					public const System.String ColumnName = "Producteur2_FactureID_NumeroPaiement";
					/// <summary>
					/// Returns 323
					/// </summary>
					public const System.Int32 ColumnIndex = 323;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Producteur2_FactureID_NumeroPaiementUnique via shared members
				/// </summary>
				public sealed class Column_Producteur2_FactureID_NumeroPaiementUnique {

					/// <summary>
					/// Returns "Producteur2_FactureID_NumeroPaiementUnique"
					/// </summary>
					public const System.String ColumnName = "Producteur2_FactureID_NumeroPaiementUnique";
					/// <summary>
					/// Returns 324
					/// </summary>
					public const System.Int32 ColumnIndex = 324;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Producteur2_FactureID_DateFactureAcomba via shared members
				/// </summary>
				public sealed class Column_Producteur2_FactureID_DateFactureAcomba {

					/// <summary>
					/// Returns "Producteur2_FactureID_DateFactureAcomba"
					/// </summary>
					public const System.String ColumnName = "Producteur2_FactureID_DateFactureAcomba";
					/// <summary>
					/// Returns 325
					/// </summary>
					public const System.Int32 ColumnIndex = 325;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Producteur2_FactureID_DatePaiementAcomba via shared members
				/// </summary>
				public sealed class Column_Producteur2_FactureID_DatePaiementAcomba {

					/// <summary>
					/// Returns "Producteur2_FactureID_DatePaiementAcomba"
					/// </summary>
					public const System.String ColumnName = "Producteur2_FactureID_DatePaiementAcomba";
					/// <summary>
					/// Returns 326
					/// </summary>
					public const System.Int32 ColumnIndex = 326;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Transporteur_FactureID_ID via shared members
				/// </summary>
				public sealed class Column_Transporteur_FactureID_ID {

					/// <summary>
					/// Returns "Transporteur_FactureID_ID"
					/// </summary>
					public const System.String ColumnName = "Transporteur_FactureID_ID";
					/// <summary>
					/// Returns 327
					/// </summary>
					public const System.Int32 ColumnIndex = 327;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Transporteur_FactureID_NoFacture via shared members
				/// </summary>
				public sealed class Column_Transporteur_FactureID_NoFacture {

					/// <summary>
					/// Returns "Transporteur_FactureID_NoFacture"
					/// </summary>
					public const System.String ColumnName = "Transporteur_FactureID_NoFacture";
					/// <summary>
					/// Returns 328
					/// </summary>
					public const System.Int32 ColumnIndex = 328;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Transporteur_FactureID_DateFacture via shared members
				/// </summary>
				public sealed class Column_Transporteur_FactureID_DateFacture {

					/// <summary>
					/// Returns "Transporteur_FactureID_DateFacture"
					/// </summary>
					public const System.String ColumnName = "Transporteur_FactureID_DateFacture";
					/// <summary>
					/// Returns 329
					/// </summary>
					public const System.Int32 ColumnIndex = 329;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Transporteur_FactureID_Annee via shared members
				/// </summary>
				public sealed class Column_Transporteur_FactureID_Annee {

					/// <summary>
					/// Returns "Transporteur_FactureID_Annee"
					/// </summary>
					public const System.String ColumnName = "Transporteur_FactureID_Annee";
					/// <summary>
					/// Returns 330
					/// </summary>
					public const System.Int32 ColumnIndex = 330;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Transporteur_FactureID_TypeFactureFournisseur via shared members
				/// </summary>
				public sealed class Column_Transporteur_FactureID_TypeFactureFournisseur {

					/// <summary>
					/// Returns "Transporteur_FactureID_TypeFactureFournisseur"
					/// </summary>
					public const System.String ColumnName = "Transporteur_FactureID_TypeFactureFournisseur";
					/// <summary>
					/// Returns 331
					/// </summary>
					public const System.Int32 ColumnIndex = 331;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Transporteur_FactureID_TypeFacture via shared members
				/// </summary>
				public sealed class Column_Transporteur_FactureID_TypeFacture {

					/// <summary>
					/// Returns "Transporteur_FactureID_TypeFacture"
					/// </summary>
					public const System.String ColumnName = "Transporteur_FactureID_TypeFacture";
					/// <summary>
					/// Returns 332
					/// </summary>
					public const System.Int32 ColumnIndex = 332;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Transporteur_FactureID_TypeInvoiceAcomba via shared members
				/// </summary>
				public sealed class Column_Transporteur_FactureID_TypeInvoiceAcomba {

					/// <summary>
					/// Returns "Transporteur_FactureID_TypeInvoiceAcomba"
					/// </summary>
					public const System.String ColumnName = "Transporteur_FactureID_TypeInvoiceAcomba";
					/// <summary>
					/// Returns 333
					/// </summary>
					public const System.Int32 ColumnIndex = 333;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Transporteur_FactureID_FournisseurID via shared members
				/// </summary>
				public sealed class Column_Transporteur_FactureID_FournisseurID {

					/// <summary>
					/// Returns "Transporteur_FactureID_FournisseurID"
					/// </summary>
					public const System.String ColumnName = "Transporteur_FactureID_FournisseurID";
					/// <summary>
					/// Returns 334
					/// </summary>
					public const System.Int32 ColumnIndex = 334;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Transporteur_FactureID_PayerAID via shared members
				/// </summary>
				public sealed class Column_Transporteur_FactureID_PayerAID {

					/// <summary>
					/// Returns "Transporteur_FactureID_PayerAID"
					/// </summary>
					public const System.String ColumnName = "Transporteur_FactureID_PayerAID";
					/// <summary>
					/// Returns 335
					/// </summary>
					public const System.Int32 ColumnIndex = 335;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Transporteur_FactureID_Montant_Total via shared members
				/// </summary>
				public sealed class Column_Transporteur_FactureID_Montant_Total {

					/// <summary>
					/// Returns "Transporteur_FactureID_Montant_Total"
					/// </summary>
					public const System.String ColumnName = "Transporteur_FactureID_Montant_Total";
					/// <summary>
					/// Returns 336
					/// </summary>
					public const System.Int32 ColumnIndex = 336;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Transporteur_FactureID_Montant_TPS via shared members
				/// </summary>
				public sealed class Column_Transporteur_FactureID_Montant_TPS {

					/// <summary>
					/// Returns "Transporteur_FactureID_Montant_TPS"
					/// </summary>
					public const System.String ColumnName = "Transporteur_FactureID_Montant_TPS";
					/// <summary>
					/// Returns 337
					/// </summary>
					public const System.Int32 ColumnIndex = 337;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Transporteur_FactureID_Montant_TVQ via shared members
				/// </summary>
				public sealed class Column_Transporteur_FactureID_Montant_TVQ {

					/// <summary>
					/// Returns "Transporteur_FactureID_Montant_TVQ"
					/// </summary>
					public const System.String ColumnName = "Transporteur_FactureID_Montant_TVQ";
					/// <summary>
					/// Returns 338
					/// </summary>
					public const System.Int32 ColumnIndex = 338;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Transporteur_FactureID_Description via shared members
				/// </summary>
				public sealed class Column_Transporteur_FactureID_Description {

					/// <summary>
					/// Returns "Transporteur_FactureID_Description"
					/// </summary>
					public const System.String ColumnName = "Transporteur_FactureID_Description";
					/// <summary>
					/// Returns 339
					/// </summary>
					public const System.Int32 ColumnIndex = 339;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Transporteur_FactureID_Status via shared members
				/// </summary>
				public sealed class Column_Transporteur_FactureID_Status {

					/// <summary>
					/// Returns "Transporteur_FactureID_Status"
					/// </summary>
					public const System.String ColumnName = "Transporteur_FactureID_Status";
					/// <summary>
					/// Returns 340
					/// </summary>
					public const System.Int32 ColumnIndex = 340;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Transporteur_FactureID_StatusDescription via shared members
				/// </summary>
				public sealed class Column_Transporteur_FactureID_StatusDescription {

					/// <summary>
					/// Returns "Transporteur_FactureID_StatusDescription"
					/// </summary>
					public const System.String ColumnName = "Transporteur_FactureID_StatusDescription";
					/// <summary>
					/// Returns 341
					/// </summary>
					public const System.Int32 ColumnIndex = 341;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Transporteur_FactureID_NumeroCheque via shared members
				/// </summary>
				public sealed class Column_Transporteur_FactureID_NumeroCheque {

					/// <summary>
					/// Returns "Transporteur_FactureID_NumeroCheque"
					/// </summary>
					public const System.String ColumnName = "Transporteur_FactureID_NumeroCheque";
					/// <summary>
					/// Returns 342
					/// </summary>
					public const System.Int32 ColumnIndex = 342;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Transporteur_FactureID_NumeroPaiement via shared members
				/// </summary>
				public sealed class Column_Transporteur_FactureID_NumeroPaiement {

					/// <summary>
					/// Returns "Transporteur_FactureID_NumeroPaiement"
					/// </summary>
					public const System.String ColumnName = "Transporteur_FactureID_NumeroPaiement";
					/// <summary>
					/// Returns 343
					/// </summary>
					public const System.Int32 ColumnIndex = 343;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Transporteur_FactureID_NumeroPaiementUnique via shared members
				/// </summary>
				public sealed class Column_Transporteur_FactureID_NumeroPaiementUnique {

					/// <summary>
					/// Returns "Transporteur_FactureID_NumeroPaiementUnique"
					/// </summary>
					public const System.String ColumnName = "Transporteur_FactureID_NumeroPaiementUnique";
					/// <summary>
					/// Returns 344
					/// </summary>
					public const System.Int32 ColumnIndex = 344;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Transporteur_FactureID_DateFactureAcomba via shared members
				/// </summary>
				public sealed class Column_Transporteur_FactureID_DateFactureAcomba {

					/// <summary>
					/// Returns "Transporteur_FactureID_DateFactureAcomba"
					/// </summary>
					public const System.String ColumnName = "Transporteur_FactureID_DateFactureAcomba";
					/// <summary>
					/// Returns 345
					/// </summary>
					public const System.Int32 ColumnIndex = 345;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Transporteur_FactureID_DatePaiementAcomba via shared members
				/// </summary>
				public sealed class Column_Transporteur_FactureID_DatePaiementAcomba {

					/// <summary>
					/// Returns "Transporteur_FactureID_DatePaiementAcomba"
					/// </summary>
					public const System.String ColumnName = "Transporteur_FactureID_DatePaiementAcomba";
					/// <summary>
					/// Returns 346
					/// </summary>
					public const System.Int32 ColumnIndex = 346;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Usine_FactureID_ID via shared members
				/// </summary>
				public sealed class Column_Usine_FactureID_ID {

					/// <summary>
					/// Returns "Usine_FactureID_ID"
					/// </summary>
					public const System.String ColumnName = "Usine_FactureID_ID";
					/// <summary>
					/// Returns 347
					/// </summary>
					public const System.Int32 ColumnIndex = 347;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Usine_FactureID_NoFacture via shared members
				/// </summary>
				public sealed class Column_Usine_FactureID_NoFacture {

					/// <summary>
					/// Returns "Usine_FactureID_NoFacture"
					/// </summary>
					public const System.String ColumnName = "Usine_FactureID_NoFacture";
					/// <summary>
					/// Returns 348
					/// </summary>
					public const System.Int32 ColumnIndex = 348;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Usine_FactureID_DateFacture via shared members
				/// </summary>
				public sealed class Column_Usine_FactureID_DateFacture {

					/// <summary>
					/// Returns "Usine_FactureID_DateFacture"
					/// </summary>
					public const System.String ColumnName = "Usine_FactureID_DateFacture";
					/// <summary>
					/// Returns 349
					/// </summary>
					public const System.Int32 ColumnIndex = 349;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Usine_FactureID_Annee via shared members
				/// </summary>
				public sealed class Column_Usine_FactureID_Annee {

					/// <summary>
					/// Returns "Usine_FactureID_Annee"
					/// </summary>
					public const System.String ColumnName = "Usine_FactureID_Annee";
					/// <summary>
					/// Returns 350
					/// </summary>
					public const System.Int32 ColumnIndex = 350;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Usine_FactureID_TypeFacture via shared members
				/// </summary>
				public sealed class Column_Usine_FactureID_TypeFacture {

					/// <summary>
					/// Returns "Usine_FactureID_TypeFacture"
					/// </summary>
					public const System.String ColumnName = "Usine_FactureID_TypeFacture";
					/// <summary>
					/// Returns 351
					/// </summary>
					public const System.Int32 ColumnIndex = 351;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Usine_FactureID_TypeInvoiceClientAcomba via shared members
				/// </summary>
				public sealed class Column_Usine_FactureID_TypeInvoiceClientAcomba {

					/// <summary>
					/// Returns "Usine_FactureID_TypeInvoiceClientAcomba"
					/// </summary>
					public const System.String ColumnName = "Usine_FactureID_TypeInvoiceClientAcomba";
					/// <summary>
					/// Returns 352
					/// </summary>
					public const System.Int32 ColumnIndex = 352;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Usine_FactureID_ClientID via shared members
				/// </summary>
				public sealed class Column_Usine_FactureID_ClientID {

					/// <summary>
					/// Returns "Usine_FactureID_ClientID"
					/// </summary>
					public const System.String ColumnName = "Usine_FactureID_ClientID";
					/// <summary>
					/// Returns 353
					/// </summary>
					public const System.Int32 ColumnIndex = 353;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Usine_FactureID_PayerAID via shared members
				/// </summary>
				public sealed class Column_Usine_FactureID_PayerAID {

					/// <summary>
					/// Returns "Usine_FactureID_PayerAID"
					/// </summary>
					public const System.String ColumnName = "Usine_FactureID_PayerAID";
					/// <summary>
					/// Returns 354
					/// </summary>
					public const System.Int32 ColumnIndex = 354;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Usine_FactureID_Montant_Total via shared members
				/// </summary>
				public sealed class Column_Usine_FactureID_Montant_Total {

					/// <summary>
					/// Returns "Usine_FactureID_Montant_Total"
					/// </summary>
					public const System.String ColumnName = "Usine_FactureID_Montant_Total";
					/// <summary>
					/// Returns 355
					/// </summary>
					public const System.Int32 ColumnIndex = 355;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Usine_FactureID_Montant_TPS via shared members
				/// </summary>
				public sealed class Column_Usine_FactureID_Montant_TPS {

					/// <summary>
					/// Returns "Usine_FactureID_Montant_TPS"
					/// </summary>
					public const System.String ColumnName = "Usine_FactureID_Montant_TPS";
					/// <summary>
					/// Returns 356
					/// </summary>
					public const System.Int32 ColumnIndex = 356;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Usine_FactureID_Montant_TVQ via shared members
				/// </summary>
				public sealed class Column_Usine_FactureID_Montant_TVQ {

					/// <summary>
					/// Returns "Usine_FactureID_Montant_TVQ"
					/// </summary>
					public const System.String ColumnName = "Usine_FactureID_Montant_TVQ";
					/// <summary>
					/// Returns 357
					/// </summary>
					public const System.Int32 ColumnIndex = 357;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Usine_FactureID_Description via shared members
				/// </summary>
				public sealed class Column_Usine_FactureID_Description {

					/// <summary>
					/// Returns "Usine_FactureID_Description"
					/// </summary>
					public const System.String ColumnName = "Usine_FactureID_Description";
					/// <summary>
					/// Returns 358
					/// </summary>
					public const System.Int32 ColumnIndex = 358;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Usine_FactureID_Status via shared members
				/// </summary>
				public sealed class Column_Usine_FactureID_Status {

					/// <summary>
					/// Returns "Usine_FactureID_Status"
					/// </summary>
					public const System.String ColumnName = "Usine_FactureID_Status";
					/// <summary>
					/// Returns 359
					/// </summary>
					public const System.Int32 ColumnIndex = 359;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Usine_FactureID_StatusDescription via shared members
				/// </summary>
				public sealed class Column_Usine_FactureID_StatusDescription {

					/// <summary>
					/// Returns "Usine_FactureID_StatusDescription"
					/// </summary>
					public const System.String ColumnName = "Usine_FactureID_StatusDescription";
					/// <summary>
					/// Returns 360
					/// </summary>
					public const System.Int32 ColumnIndex = 360;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Usine_FactureID_DateFactureAcomba via shared members
				/// </summary>
				public sealed class Column_Usine_FactureID_DateFactureAcomba {

					/// <summary>
					/// Returns "Usine_FactureID_DateFactureAcomba"
					/// </summary>
					public const System.String ColumnName = "Usine_FactureID_DateFactureAcomba";
					/// <summary>
					/// Returns 361
					/// </summary>
					public const System.Int32 ColumnIndex = 361;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LotID_CantonID via shared members
				/// </summary>
				public sealed class Column_LotID_CantonID {

					/// <summary>
					/// Returns "LotID_CantonID"
					/// </summary>
					public const System.String ColumnName = "LotID_CantonID";
					/// <summary>
					/// Returns 362
					/// </summary>
					public const System.Int32 ColumnIndex = 362;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LotID_Rang via shared members
				/// </summary>
				public sealed class Column_LotID_Rang {

					/// <summary>
					/// Returns "LotID_Rang"
					/// </summary>
					public const System.String ColumnName = "LotID_Rang";
					/// <summary>
					/// Returns 363
					/// </summary>
					public const System.Int32 ColumnIndex = 363;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LotID_Lot via shared members
				/// </summary>
				public sealed class Column_LotID_Lot {

					/// <summary>
					/// Returns "LotID_Lot"
					/// </summary>
					public const System.String ColumnName = "LotID_Lot";
					/// <summary>
					/// Returns 364
					/// </summary>
					public const System.Int32 ColumnIndex = 364;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LotID_MunicipaliteID via shared members
				/// </summary>
				public sealed class Column_LotID_MunicipaliteID {

					/// <summary>
					/// Returns "LotID_MunicipaliteID"
					/// </summary>
					public const System.String ColumnName = "LotID_MunicipaliteID";
					/// <summary>
					/// Returns 365
					/// </summary>
					public const System.Int32 ColumnIndex = 365;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LotID_Superficie_total via shared members
				/// </summary>
				public sealed class Column_LotID_Superficie_total {

					/// <summary>
					/// Returns "LotID_Superficie_total"
					/// </summary>
					public const System.String ColumnName = "LotID_Superficie_total";
					/// <summary>
					/// Returns 366
					/// </summary>
					public const System.Int32 ColumnIndex = 366;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LotID_Superficie_boisee via shared members
				/// </summary>
				public sealed class Column_LotID_Superficie_boisee {

					/// <summary>
					/// Returns "LotID_Superficie_boisee"
					/// </summary>
					public const System.String ColumnName = "LotID_Superficie_boisee";
					/// <summary>
					/// Returns 367
					/// </summary>
					public const System.Int32 ColumnIndex = 367;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LotID_ProprietaireID via shared members
				/// </summary>
				public sealed class Column_LotID_ProprietaireID {

					/// <summary>
					/// Returns "LotID_ProprietaireID"
					/// </summary>
					public const System.String ColumnName = "LotID_ProprietaireID";
					/// <summary>
					/// Returns 368
					/// </summary>
					public const System.Int32 ColumnIndex = 368;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LotID_ContingentID via shared members
				/// </summary>
				public sealed class Column_LotID_ContingentID {

					/// <summary>
					/// Returns "LotID_ContingentID"
					/// </summary>
					public const System.String ColumnName = "LotID_ContingentID";
					/// <summary>
					/// Returns 369
					/// </summary>
					public const System.Int32 ColumnIndex = 369;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LotID_Contingent_Date via shared members
				/// </summary>
				public sealed class Column_LotID_Contingent_Date {

					/// <summary>
					/// Returns "LotID_Contingent_Date"
					/// </summary>
					public const System.String ColumnName = "LotID_Contingent_Date";
					/// <summary>
					/// Returns 370
					/// </summary>
					public const System.Int32 ColumnIndex = 370;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LotID_Droit_coupeID via shared members
				/// </summary>
				public sealed class Column_LotID_Droit_coupeID {

					/// <summary>
					/// Returns "LotID_Droit_coupeID"
					/// </summary>
					public const System.String ColumnName = "LotID_Droit_coupeID";
					/// <summary>
					/// Returns 371
					/// </summary>
					public const System.Int32 ColumnIndex = 371;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LotID_Droit_coupe_Date via shared members
				/// </summary>
				public sealed class Column_LotID_Droit_coupe_Date {

					/// <summary>
					/// Returns "LotID_Droit_coupe_Date"
					/// </summary>
					public const System.String ColumnName = "LotID_Droit_coupe_Date";
					/// <summary>
					/// Returns 372
					/// </summary>
					public const System.Int32 ColumnIndex = 372;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LotID_Entente_paiementID via shared members
				/// </summary>
				public sealed class Column_LotID_Entente_paiementID {

					/// <summary>
					/// Returns "LotID_Entente_paiementID"
					/// </summary>
					public const System.String ColumnName = "LotID_Entente_paiementID";
					/// <summary>
					/// Returns 373
					/// </summary>
					public const System.Int32 ColumnIndex = 373;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LotID_Entente_paiement_Date via shared members
				/// </summary>
				public sealed class Column_LotID_Entente_paiement_Date {

					/// <summary>
					/// Returns "LotID_Entente_paiement_Date"
					/// </summary>
					public const System.String ColumnName = "LotID_Entente_paiement_Date";
					/// <summary>
					/// Returns 374
					/// </summary>
					public const System.Int32 ColumnIndex = 374;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LotID_Actif via shared members
				/// </summary>
				public sealed class Column_LotID_Actif {

					/// <summary>
					/// Returns "LotID_Actif"
					/// </summary>
					public const System.String ColumnName = "LotID_Actif";
					/// <summary>
					/// Returns 375
					/// </summary>
					public const System.Int32 ColumnIndex = 375;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LotID_ID via shared members
				/// </summary>
				public sealed class Column_LotID_ID {

					/// <summary>
					/// Returns "LotID_ID"
					/// </summary>
					public const System.String ColumnName = "LotID_ID";
					/// <summary>
					/// Returns 376
					/// </summary>
					public const System.Int32 ColumnIndex = 376;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LotID_Sequence via shared members
				/// </summary>
				public sealed class Column_LotID_Sequence {

					/// <summary>
					/// Returns "LotID_Sequence"
					/// </summary>
					public const System.String ColumnName = "LotID_Sequence";
					/// <summary>
					/// Returns 377
					/// </summary>
					public const System.Int32 ColumnIndex = 377;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LotID_Partie via shared members
				/// </summary>
				public sealed class Column_LotID_Partie {

					/// <summary>
					/// Returns "LotID_Partie"
					/// </summary>
					public const System.String ColumnName = "LotID_Partie";
					/// <summary>
					/// Returns 378
					/// </summary>
					public const System.Int32 ColumnIndex = 378;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LotID_Matricule via shared members
				/// </summary>
				public sealed class Column_LotID_Matricule {

					/// <summary>
					/// Returns "LotID_Matricule"
					/// </summary>
					public const System.String ColumnName = "LotID_Matricule";
					/// <summary>
					/// Returns 379
					/// </summary>
					public const System.Int32 ColumnIndex = 379;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LotID_ZoneID via shared members
				/// </summary>
				public sealed class Column_LotID_ZoneID {

					/// <summary>
					/// Returns "LotID_ZoneID"
					/// </summary>
					public const System.String ColumnName = "LotID_ZoneID";
					/// <summary>
					/// Returns 380
					/// </summary>
					public const System.Int32 ColumnIndex = 380;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LotID_Secteur via shared members
				/// </summary>
				public sealed class Column_LotID_Secteur {

					/// <summary>
					/// Returns "LotID_Secteur"
					/// </summary>
					public const System.String ColumnName = "LotID_Secteur";
					/// <summary>
					/// Returns 381
					/// </summary>
					public const System.Int32 ColumnIndex = 381;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LotID_Cadastre via shared members
				/// </summary>
				public sealed class Column_LotID_Cadastre {

					/// <summary>
					/// Returns "LotID_Cadastre"
					/// </summary>
					public const System.String ColumnName = "LotID_Cadastre";
					/// <summary>
					/// Returns 382
					/// </summary>
					public const System.Int32 ColumnIndex = 382;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LotID_Reforme via shared members
				/// </summary>
				public sealed class Column_LotID_Reforme {

					/// <summary>
					/// Returns "LotID_Reforme"
					/// </summary>
					public const System.String ColumnName = "LotID_Reforme";
					/// <summary>
					/// Returns 383
					/// </summary>
					public const System.Int32 ColumnIndex = 383;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LotID_LotsComplementaires via shared members
				/// </summary>
				public sealed class Column_LotID_LotsComplementaires {

					/// <summary>
					/// Returns "LotID_LotsComplementaires"
					/// </summary>
					public const System.String ColumnName = "LotID_LotsComplementaires";
					/// <summary>
					/// Returns 384
					/// </summary>
					public const System.Int32 ColumnIndex = 384;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LotID_Certifie via shared members
				/// </summary>
				public sealed class Column_LotID_Certifie {

					/// <summary>
					/// Returns "LotID_Certifie"
					/// </summary>
					public const System.String ColumnName = "LotID_Certifie";
					/// <summary>
					/// Returns 385
					/// </summary>
					public const System.Int32 ColumnIndex = 385;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LotID_NumeroCertification via shared members
				/// </summary>
				public sealed class Column_LotID_NumeroCertification {

					/// <summary>
					/// Returns "LotID_NumeroCertification"
					/// </summary>
					public const System.String ColumnName = "LotID_NumeroCertification";
					/// <summary>
					/// Returns 386
					/// </summary>
					public const System.Int32 ColumnIndex = 386;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LotID_OGC via shared members
				/// </summary>
				public sealed class Column_LotID_OGC {

					/// <summary>
					/// Returns "LotID_OGC"
					/// </summary>
					public const System.String ColumnName = "LotID_OGC";
					/// <summary>
					/// Returns 387
					/// </summary>
					public const System.Int32 ColumnIndex = 387;

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
					/// Returns 388
					/// </summary>
					public const System.Int32 ColumnIndex = 388;

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
					/// Returns 389
					/// </summary>
					public const System.Int32 ColumnIndex = 389;

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
					/// Returns 390
					/// </summary>
					public const System.Int32 ColumnIndex = 390;

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
					/// Returns 391
					/// </summary>
					public const System.Int32 ColumnIndex = 391;

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
					/// Returns 392
					/// </summary>
					public const System.Int32 ColumnIndex = 392;

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
					/// Returns 393
					/// </summary>
					public const System.Int32 ColumnIndex = 393;

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
					/// Returns 394
					/// </summary>
					public const System.Int32 ColumnIndex = 394;

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
					/// Returns 395
					/// </summary>
					public const System.Int32 ColumnIndex = 395;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ChargeurID_ID via shared members
				/// </summary>
				public sealed class Column_ChargeurID_ID {

					/// <summary>
					/// Returns "ChargeurID_ID"
					/// </summary>
					public const System.String ColumnName = "ChargeurID_ID";
					/// <summary>
					/// Returns 396
					/// </summary>
					public const System.Int32 ColumnIndex = 396;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ChargeurID_CleTri via shared members
				/// </summary>
				public sealed class Column_ChargeurID_CleTri {

					/// <summary>
					/// Returns "ChargeurID_CleTri"
					/// </summary>
					public const System.String ColumnName = "ChargeurID_CleTri";
					/// <summary>
					/// Returns 397
					/// </summary>
					public const System.Int32 ColumnIndex = 397;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ChargeurID_Nom via shared members
				/// </summary>
				public sealed class Column_ChargeurID_Nom {

					/// <summary>
					/// Returns "ChargeurID_Nom"
					/// </summary>
					public const System.String ColumnName = "ChargeurID_Nom";
					/// <summary>
					/// Returns 398
					/// </summary>
					public const System.Int32 ColumnIndex = 398;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ChargeurID_AuSoinsDe via shared members
				/// </summary>
				public sealed class Column_ChargeurID_AuSoinsDe {

					/// <summary>
					/// Returns "ChargeurID_AuSoinsDe"
					/// </summary>
					public const System.String ColumnName = "ChargeurID_AuSoinsDe";
					/// <summary>
					/// Returns 399
					/// </summary>
					public const System.Int32 ColumnIndex = 399;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ChargeurID_Rue via shared members
				/// </summary>
				public sealed class Column_ChargeurID_Rue {

					/// <summary>
					/// Returns "ChargeurID_Rue"
					/// </summary>
					public const System.String ColumnName = "ChargeurID_Rue";
					/// <summary>
					/// Returns 400
					/// </summary>
					public const System.Int32 ColumnIndex = 400;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ChargeurID_Ville via shared members
				/// </summary>
				public sealed class Column_ChargeurID_Ville {

					/// <summary>
					/// Returns "ChargeurID_Ville"
					/// </summary>
					public const System.String ColumnName = "ChargeurID_Ville";
					/// <summary>
					/// Returns 401
					/// </summary>
					public const System.Int32 ColumnIndex = 401;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ChargeurID_PaysID via shared members
				/// </summary>
				public sealed class Column_ChargeurID_PaysID {

					/// <summary>
					/// Returns "ChargeurID_PaysID"
					/// </summary>
					public const System.String ColumnName = "ChargeurID_PaysID";
					/// <summary>
					/// Returns 402
					/// </summary>
					public const System.Int32 ColumnIndex = 402;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ChargeurID_Code_postal via shared members
				/// </summary>
				public sealed class Column_ChargeurID_Code_postal {

					/// <summary>
					/// Returns "ChargeurID_Code_postal"
					/// </summary>
					public const System.String ColumnName = "ChargeurID_Code_postal";
					/// <summary>
					/// Returns 403
					/// </summary>
					public const System.Int32 ColumnIndex = 403;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ChargeurID_Telephone via shared members
				/// </summary>
				public sealed class Column_ChargeurID_Telephone {

					/// <summary>
					/// Returns "ChargeurID_Telephone"
					/// </summary>
					public const System.String ColumnName = "ChargeurID_Telephone";
					/// <summary>
					/// Returns 404
					/// </summary>
					public const System.Int32 ColumnIndex = 404;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ChargeurID_Telephone_Poste via shared members
				/// </summary>
				public sealed class Column_ChargeurID_Telephone_Poste {

					/// <summary>
					/// Returns "ChargeurID_Telephone_Poste"
					/// </summary>
					public const System.String ColumnName = "ChargeurID_Telephone_Poste";
					/// <summary>
					/// Returns 405
					/// </summary>
					public const System.Int32 ColumnIndex = 405;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ChargeurID_Telecopieur via shared members
				/// </summary>
				public sealed class Column_ChargeurID_Telecopieur {

					/// <summary>
					/// Returns "ChargeurID_Telecopieur"
					/// </summary>
					public const System.String ColumnName = "ChargeurID_Telecopieur";
					/// <summary>
					/// Returns 406
					/// </summary>
					public const System.Int32 ColumnIndex = 406;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ChargeurID_Telephone2 via shared members
				/// </summary>
				public sealed class Column_ChargeurID_Telephone2 {

					/// <summary>
					/// Returns "ChargeurID_Telephone2"
					/// </summary>
					public const System.String ColumnName = "ChargeurID_Telephone2";
					/// <summary>
					/// Returns 407
					/// </summary>
					public const System.Int32 ColumnIndex = 407;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ChargeurID_Telephone2_Desc via shared members
				/// </summary>
				public sealed class Column_ChargeurID_Telephone2_Desc {

					/// <summary>
					/// Returns "ChargeurID_Telephone2_Desc"
					/// </summary>
					public const System.String ColumnName = "ChargeurID_Telephone2_Desc";
					/// <summary>
					/// Returns 408
					/// </summary>
					public const System.Int32 ColumnIndex = 408;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ChargeurID_Telephone2_Poste via shared members
				/// </summary>
				public sealed class Column_ChargeurID_Telephone2_Poste {

					/// <summary>
					/// Returns "ChargeurID_Telephone2_Poste"
					/// </summary>
					public const System.String ColumnName = "ChargeurID_Telephone2_Poste";
					/// <summary>
					/// Returns 409
					/// </summary>
					public const System.Int32 ColumnIndex = 409;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ChargeurID_Telephone3 via shared members
				/// </summary>
				public sealed class Column_ChargeurID_Telephone3 {

					/// <summary>
					/// Returns "ChargeurID_Telephone3"
					/// </summary>
					public const System.String ColumnName = "ChargeurID_Telephone3";
					/// <summary>
					/// Returns 410
					/// </summary>
					public const System.Int32 ColumnIndex = 410;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ChargeurID_Telephone3_Desc via shared members
				/// </summary>
				public sealed class Column_ChargeurID_Telephone3_Desc {

					/// <summary>
					/// Returns "ChargeurID_Telephone3_Desc"
					/// </summary>
					public const System.String ColumnName = "ChargeurID_Telephone3_Desc";
					/// <summary>
					/// Returns 411
					/// </summary>
					public const System.Int32 ColumnIndex = 411;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ChargeurID_Telephone3_Poste via shared members
				/// </summary>
				public sealed class Column_ChargeurID_Telephone3_Poste {

					/// <summary>
					/// Returns "ChargeurID_Telephone3_Poste"
					/// </summary>
					public const System.String ColumnName = "ChargeurID_Telephone3_Poste";
					/// <summary>
					/// Returns 412
					/// </summary>
					public const System.Int32 ColumnIndex = 412;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ChargeurID_No_membre via shared members
				/// </summary>
				public sealed class Column_ChargeurID_No_membre {

					/// <summary>
					/// Returns "ChargeurID_No_membre"
					/// </summary>
					public const System.String ColumnName = "ChargeurID_No_membre";
					/// <summary>
					/// Returns 413
					/// </summary>
					public const System.Int32 ColumnIndex = 413;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ChargeurID_Resident via shared members
				/// </summary>
				public sealed class Column_ChargeurID_Resident {

					/// <summary>
					/// Returns "ChargeurID_Resident"
					/// </summary>
					public const System.String ColumnName = "ChargeurID_Resident";
					/// <summary>
					/// Returns 414
					/// </summary>
					public const System.Int32 ColumnIndex = 414;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ChargeurID_Email via shared members
				/// </summary>
				public sealed class Column_ChargeurID_Email {

					/// <summary>
					/// Returns "ChargeurID_Email"
					/// </summary>
					public const System.String ColumnName = "ChargeurID_Email";
					/// <summary>
					/// Returns 415
					/// </summary>
					public const System.Int32 ColumnIndex = 415;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ChargeurID_WWW via shared members
				/// </summary>
				public sealed class Column_ChargeurID_WWW {

					/// <summary>
					/// Returns "ChargeurID_WWW"
					/// </summary>
					public const System.String ColumnName = "ChargeurID_WWW";
					/// <summary>
					/// Returns 416
					/// </summary>
					public const System.Int32 ColumnIndex = 416;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ChargeurID_Commentaires via shared members
				/// </summary>
				public sealed class Column_ChargeurID_Commentaires {

					/// <summary>
					/// Returns "ChargeurID_Commentaires"
					/// </summary>
					public const System.String ColumnName = "ChargeurID_Commentaires";
					/// <summary>
					/// Returns 417
					/// </summary>
					public const System.Int32 ColumnIndex = 417;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ChargeurID_AfficherCommentaires via shared members
				/// </summary>
				public sealed class Column_ChargeurID_AfficherCommentaires {

					/// <summary>
					/// Returns "ChargeurID_AfficherCommentaires"
					/// </summary>
					public const System.String ColumnName = "ChargeurID_AfficherCommentaires";
					/// <summary>
					/// Returns 418
					/// </summary>
					public const System.Int32 ColumnIndex = 418;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ChargeurID_DepotDirect via shared members
				/// </summary>
				public sealed class Column_ChargeurID_DepotDirect {

					/// <summary>
					/// Returns "ChargeurID_DepotDirect"
					/// </summary>
					public const System.String ColumnName = "ChargeurID_DepotDirect";
					/// <summary>
					/// Returns 419
					/// </summary>
					public const System.Int32 ColumnIndex = 419;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ChargeurID_InstitutionBanquaireID via shared members
				/// </summary>
				public sealed class Column_ChargeurID_InstitutionBanquaireID {

					/// <summary>
					/// Returns "ChargeurID_InstitutionBanquaireID"
					/// </summary>
					public const System.String ColumnName = "ChargeurID_InstitutionBanquaireID";
					/// <summary>
					/// Returns 420
					/// </summary>
					public const System.Int32 ColumnIndex = 420;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ChargeurID_Banque_transit via shared members
				/// </summary>
				public sealed class Column_ChargeurID_Banque_transit {

					/// <summary>
					/// Returns "ChargeurID_Banque_transit"
					/// </summary>
					public const System.String ColumnName = "ChargeurID_Banque_transit";
					/// <summary>
					/// Returns 421
					/// </summary>
					public const System.Int32 ColumnIndex = 421;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ChargeurID_Banque_folio via shared members
				/// </summary>
				public sealed class Column_ChargeurID_Banque_folio {

					/// <summary>
					/// Returns "ChargeurID_Banque_folio"
					/// </summary>
					public const System.String ColumnName = "ChargeurID_Banque_folio";
					/// <summary>
					/// Returns 422
					/// </summary>
					public const System.Int32 ColumnIndex = 422;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ChargeurID_No_TPS via shared members
				/// </summary>
				public sealed class Column_ChargeurID_No_TPS {

					/// <summary>
					/// Returns "ChargeurID_No_TPS"
					/// </summary>
					public const System.String ColumnName = "ChargeurID_No_TPS";
					/// <summary>
					/// Returns 423
					/// </summary>
					public const System.Int32 ColumnIndex = 423;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ChargeurID_No_TVQ via shared members
				/// </summary>
				public sealed class Column_ChargeurID_No_TVQ {

					/// <summary>
					/// Returns "ChargeurID_No_TVQ"
					/// </summary>
					public const System.String ColumnName = "ChargeurID_No_TVQ";
					/// <summary>
					/// Returns 424
					/// </summary>
					public const System.Int32 ColumnIndex = 424;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ChargeurID_PayerA via shared members
				/// </summary>
				public sealed class Column_ChargeurID_PayerA {

					/// <summary>
					/// Returns "ChargeurID_PayerA"
					/// </summary>
					public const System.String ColumnName = "ChargeurID_PayerA";
					/// <summary>
					/// Returns 425
					/// </summary>
					public const System.Int32 ColumnIndex = 425;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ChargeurID_PayerAID via shared members
				/// </summary>
				public sealed class Column_ChargeurID_PayerAID {

					/// <summary>
					/// Returns "ChargeurID_PayerAID"
					/// </summary>
					public const System.String ColumnName = "ChargeurID_PayerAID";
					/// <summary>
					/// Returns 426
					/// </summary>
					public const System.Int32 ColumnIndex = 426;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ChargeurID_Statut via shared members
				/// </summary>
				public sealed class Column_ChargeurID_Statut {

					/// <summary>
					/// Returns "ChargeurID_Statut"
					/// </summary>
					public const System.String ColumnName = "ChargeurID_Statut";
					/// <summary>
					/// Returns 427
					/// </summary>
					public const System.Int32 ColumnIndex = 427;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ChargeurID_Rep_Nom via shared members
				/// </summary>
				public sealed class Column_ChargeurID_Rep_Nom {

					/// <summary>
					/// Returns "ChargeurID_Rep_Nom"
					/// </summary>
					public const System.String ColumnName = "ChargeurID_Rep_Nom";
					/// <summary>
					/// Returns 428
					/// </summary>
					public const System.Int32 ColumnIndex = 428;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ChargeurID_Rep_Telephone via shared members
				/// </summary>
				public sealed class Column_ChargeurID_Rep_Telephone {

					/// <summary>
					/// Returns "ChargeurID_Rep_Telephone"
					/// </summary>
					public const System.String ColumnName = "ChargeurID_Rep_Telephone";
					/// <summary>
					/// Returns 429
					/// </summary>
					public const System.Int32 ColumnIndex = 429;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ChargeurID_Rep_Telephone_Poste via shared members
				/// </summary>
				public sealed class Column_ChargeurID_Rep_Telephone_Poste {

					/// <summary>
					/// Returns "ChargeurID_Rep_Telephone_Poste"
					/// </summary>
					public const System.String ColumnName = "ChargeurID_Rep_Telephone_Poste";
					/// <summary>
					/// Returns 430
					/// </summary>
					public const System.Int32 ColumnIndex = 430;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ChargeurID_Rep_Email via shared members
				/// </summary>
				public sealed class Column_ChargeurID_Rep_Email {

					/// <summary>
					/// Returns "ChargeurID_Rep_Email"
					/// </summary>
					public const System.String ColumnName = "ChargeurID_Rep_Email";
					/// <summary>
					/// Returns 431
					/// </summary>
					public const System.Int32 ColumnIndex = 431;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ChargeurID_EnAnglais via shared members
				/// </summary>
				public sealed class Column_ChargeurID_EnAnglais {

					/// <summary>
					/// Returns "ChargeurID_EnAnglais"
					/// </summary>
					public const System.String ColumnName = "ChargeurID_EnAnglais";
					/// <summary>
					/// Returns 432
					/// </summary>
					public const System.Int32 ColumnIndex = 432;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ChargeurID_Actif via shared members
				/// </summary>
				public sealed class Column_ChargeurID_Actif {

					/// <summary>
					/// Returns "ChargeurID_Actif"
					/// </summary>
					public const System.String ColumnName = "ChargeurID_Actif";
					/// <summary>
					/// Returns 433
					/// </summary>
					public const System.Int32 ColumnIndex = 433;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ChargeurID_MRCProducteurID via shared members
				/// </summary>
				public sealed class Column_ChargeurID_MRCProducteurID {

					/// <summary>
					/// Returns "ChargeurID_MRCProducteurID"
					/// </summary>
					public const System.String ColumnName = "ChargeurID_MRCProducteurID";
					/// <summary>
					/// Returns 434
					/// </summary>
					public const System.Int32 ColumnIndex = 434;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ChargeurID_PaiementManuel via shared members
				/// </summary>
				public sealed class Column_ChargeurID_PaiementManuel {

					/// <summary>
					/// Returns "ChargeurID_PaiementManuel"
					/// </summary>
					public const System.String ColumnName = "ChargeurID_PaiementManuel";
					/// <summary>
					/// Returns 435
					/// </summary>
					public const System.Int32 ColumnIndex = 435;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ChargeurID_Journal via shared members
				/// </summary>
				public sealed class Column_ChargeurID_Journal {

					/// <summary>
					/// Returns "ChargeurID_Journal"
					/// </summary>
					public const System.String ColumnName = "ChargeurID_Journal";
					/// <summary>
					/// Returns 436
					/// </summary>
					public const System.Int32 ColumnIndex = 436;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ChargeurID_RecoitTPS via shared members
				/// </summary>
				public sealed class Column_ChargeurID_RecoitTPS {

					/// <summary>
					/// Returns "ChargeurID_RecoitTPS"
					/// </summary>
					public const System.String ColumnName = "ChargeurID_RecoitTPS";
					/// <summary>
					/// Returns 437
					/// </summary>
					public const System.Int32 ColumnIndex = 437;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ChargeurID_RecoitTVQ via shared members
				/// </summary>
				public sealed class Column_ChargeurID_RecoitTVQ {

					/// <summary>
					/// Returns "ChargeurID_RecoitTVQ"
					/// </summary>
					public const System.String ColumnName = "ChargeurID_RecoitTVQ";
					/// <summary>
					/// Returns 438
					/// </summary>
					public const System.Int32 ColumnIndex = 438;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ChargeurID_ModifierTrigger via shared members
				/// </summary>
				public sealed class Column_ChargeurID_ModifierTrigger {

					/// <summary>
					/// Returns "ChargeurID_ModifierTrigger"
					/// </summary>
					public const System.String ColumnName = "ChargeurID_ModifierTrigger";
					/// <summary>
					/// Returns 439
					/// </summary>
					public const System.Int32 ColumnIndex = 439;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ChargeurID_IsProducteur via shared members
				/// </summary>
				public sealed class Column_ChargeurID_IsProducteur {

					/// <summary>
					/// Returns "ChargeurID_IsProducteur"
					/// </summary>
					public const System.String ColumnName = "ChargeurID_IsProducteur";
					/// <summary>
					/// Returns 440
					/// </summary>
					public const System.Int32 ColumnIndex = 440;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ChargeurID_IsTransporteur via shared members
				/// </summary>
				public sealed class Column_ChargeurID_IsTransporteur {

					/// <summary>
					/// Returns "ChargeurID_IsTransporteur"
					/// </summary>
					public const System.String ColumnName = "ChargeurID_IsTransporteur";
					/// <summary>
					/// Returns 441
					/// </summary>
					public const System.Int32 ColumnIndex = 441;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ChargeurID_IsChargeur via shared members
				/// </summary>
				public sealed class Column_ChargeurID_IsChargeur {

					/// <summary>
					/// Returns "ChargeurID_IsChargeur"
					/// </summary>
					public const System.String ColumnName = "ChargeurID_IsChargeur";
					/// <summary>
					/// Returns 442
					/// </summary>
					public const System.Int32 ColumnIndex = 442;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ChargeurID_IsAutre via shared members
				/// </summary>
				public sealed class Column_ChargeurID_IsAutre {

					/// <summary>
					/// Returns "ChargeurID_IsAutre"
					/// </summary>
					public const System.String ColumnName = "ChargeurID_IsAutre";
					/// <summary>
					/// Returns 443
					/// </summary>
					public const System.Int32 ColumnIndex = 443;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ChargeurID_AfficherCommentairesSurPermit via shared members
				/// </summary>
				public sealed class Column_ChargeurID_AfficherCommentairesSurPermit {

					/// <summary>
					/// Returns "ChargeurID_AfficherCommentairesSurPermit"
					/// </summary>
					public const System.String ColumnName = "ChargeurID_AfficherCommentairesSurPermit";
					/// <summary>
					/// Returns 444
					/// </summary>
					public const System.Int32 ColumnIndex = 444;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ChargeurID_PasEmissionPermis via shared members
				/// </summary>
				public sealed class Column_ChargeurID_PasEmissionPermis {

					/// <summary>
					/// Returns "ChargeurID_PasEmissionPermis"
					/// </summary>
					public const System.String ColumnName = "ChargeurID_PasEmissionPermis";
					/// <summary>
					/// Returns 445
					/// </summary>
					public const System.Int32 ColumnIndex = 445;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ChargeurID_Generique via shared members
				/// </summary>
				public sealed class Column_ChargeurID_Generique {

					/// <summary>
					/// Returns "ChargeurID_Generique"
					/// </summary>
					public const System.String ColumnName = "ChargeurID_Generique";
					/// <summary>
					/// Returns 446
					/// </summary>
					public const System.Int32 ColumnIndex = 446;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ChargeurID_Membre_OGC via shared members
				/// </summary>
				public sealed class Column_ChargeurID_Membre_OGC {

					/// <summary>
					/// Returns "ChargeurID_Membre_OGC"
					/// </summary>
					public const System.String ColumnName = "ChargeurID_Membre_OGC";
					/// <summary>
					/// Returns 447
					/// </summary>
					public const System.Int32 ColumnIndex = 447;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ChargeurID_InscritTPS via shared members
				/// </summary>
				public sealed class Column_ChargeurID_InscritTPS {

					/// <summary>
					/// Returns "ChargeurID_InscritTPS"
					/// </summary>
					public const System.String ColumnName = "ChargeurID_InscritTPS";
					/// <summary>
					/// Returns 448
					/// </summary>
					public const System.Int32 ColumnIndex = 448;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ChargeurID_InscritTVQ via shared members
				/// </summary>
				public sealed class Column_ChargeurID_InscritTVQ {

					/// <summary>
					/// Returns "ChargeurID_InscritTVQ"
					/// </summary>
					public const System.String ColumnName = "ChargeurID_InscritTVQ";
					/// <summary>
					/// Returns 449
					/// </summary>
					public const System.Int32 ColumnIndex = 449;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ChargeurID_IsOGC via shared members
				/// </summary>
				public sealed class Column_ChargeurID_IsOGC {

					/// <summary>
					/// Returns "ChargeurID_IsOGC"
					/// </summary>
					public const System.String ColumnName = "ChargeurID_IsOGC";
					/// <summary>
					/// Returns 450
					/// </summary>
					public const System.Int32 ColumnIndex = 450;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Chargeur_FactureID_ID via shared members
				/// </summary>
				public sealed class Column_Chargeur_FactureID_ID {

					/// <summary>
					/// Returns "Chargeur_FactureID_ID"
					/// </summary>
					public const System.String ColumnName = "Chargeur_FactureID_ID";
					/// <summary>
					/// Returns 451
					/// </summary>
					public const System.Int32 ColumnIndex = 451;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Chargeur_FactureID_NoFacture via shared members
				/// </summary>
				public sealed class Column_Chargeur_FactureID_NoFacture {

					/// <summary>
					/// Returns "Chargeur_FactureID_NoFacture"
					/// </summary>
					public const System.String ColumnName = "Chargeur_FactureID_NoFacture";
					/// <summary>
					/// Returns 452
					/// </summary>
					public const System.Int32 ColumnIndex = 452;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Chargeur_FactureID_DateFacture via shared members
				/// </summary>
				public sealed class Column_Chargeur_FactureID_DateFacture {

					/// <summary>
					/// Returns "Chargeur_FactureID_DateFacture"
					/// </summary>
					public const System.String ColumnName = "Chargeur_FactureID_DateFacture";
					/// <summary>
					/// Returns 453
					/// </summary>
					public const System.Int32 ColumnIndex = 453;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Chargeur_FactureID_Annee via shared members
				/// </summary>
				public sealed class Column_Chargeur_FactureID_Annee {

					/// <summary>
					/// Returns "Chargeur_FactureID_Annee"
					/// </summary>
					public const System.String ColumnName = "Chargeur_FactureID_Annee";
					/// <summary>
					/// Returns 454
					/// </summary>
					public const System.Int32 ColumnIndex = 454;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Chargeur_FactureID_TypeFactureFournisseur via shared members
				/// </summary>
				public sealed class Column_Chargeur_FactureID_TypeFactureFournisseur {

					/// <summary>
					/// Returns "Chargeur_FactureID_TypeFactureFournisseur"
					/// </summary>
					public const System.String ColumnName = "Chargeur_FactureID_TypeFactureFournisseur";
					/// <summary>
					/// Returns 455
					/// </summary>
					public const System.Int32 ColumnIndex = 455;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Chargeur_FactureID_TypeFacture via shared members
				/// </summary>
				public sealed class Column_Chargeur_FactureID_TypeFacture {

					/// <summary>
					/// Returns "Chargeur_FactureID_TypeFacture"
					/// </summary>
					public const System.String ColumnName = "Chargeur_FactureID_TypeFacture";
					/// <summary>
					/// Returns 456
					/// </summary>
					public const System.Int32 ColumnIndex = 456;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Chargeur_FactureID_TypeInvoiceAcomba via shared members
				/// </summary>
				public sealed class Column_Chargeur_FactureID_TypeInvoiceAcomba {

					/// <summary>
					/// Returns "Chargeur_FactureID_TypeInvoiceAcomba"
					/// </summary>
					public const System.String ColumnName = "Chargeur_FactureID_TypeInvoiceAcomba";
					/// <summary>
					/// Returns 457
					/// </summary>
					public const System.Int32 ColumnIndex = 457;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Chargeur_FactureID_FournisseurID via shared members
				/// </summary>
				public sealed class Column_Chargeur_FactureID_FournisseurID {

					/// <summary>
					/// Returns "Chargeur_FactureID_FournisseurID"
					/// </summary>
					public const System.String ColumnName = "Chargeur_FactureID_FournisseurID";
					/// <summary>
					/// Returns 458
					/// </summary>
					public const System.Int32 ColumnIndex = 458;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Chargeur_FactureID_PayerAID via shared members
				/// </summary>
				public sealed class Column_Chargeur_FactureID_PayerAID {

					/// <summary>
					/// Returns "Chargeur_FactureID_PayerAID"
					/// </summary>
					public const System.String ColumnName = "Chargeur_FactureID_PayerAID";
					/// <summary>
					/// Returns 459
					/// </summary>
					public const System.Int32 ColumnIndex = 459;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Chargeur_FactureID_Montant_Total via shared members
				/// </summary>
				public sealed class Column_Chargeur_FactureID_Montant_Total {

					/// <summary>
					/// Returns "Chargeur_FactureID_Montant_Total"
					/// </summary>
					public const System.String ColumnName = "Chargeur_FactureID_Montant_Total";
					/// <summary>
					/// Returns 460
					/// </summary>
					public const System.Int32 ColumnIndex = 460;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Chargeur_FactureID_Montant_TPS via shared members
				/// </summary>
				public sealed class Column_Chargeur_FactureID_Montant_TPS {

					/// <summary>
					/// Returns "Chargeur_FactureID_Montant_TPS"
					/// </summary>
					public const System.String ColumnName = "Chargeur_FactureID_Montant_TPS";
					/// <summary>
					/// Returns 461
					/// </summary>
					public const System.Int32 ColumnIndex = 461;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Chargeur_FactureID_Montant_TVQ via shared members
				/// </summary>
				public sealed class Column_Chargeur_FactureID_Montant_TVQ {

					/// <summary>
					/// Returns "Chargeur_FactureID_Montant_TVQ"
					/// </summary>
					public const System.String ColumnName = "Chargeur_FactureID_Montant_TVQ";
					/// <summary>
					/// Returns 462
					/// </summary>
					public const System.Int32 ColumnIndex = 462;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Chargeur_FactureID_Description via shared members
				/// </summary>
				public sealed class Column_Chargeur_FactureID_Description {

					/// <summary>
					/// Returns "Chargeur_FactureID_Description"
					/// </summary>
					public const System.String ColumnName = "Chargeur_FactureID_Description";
					/// <summary>
					/// Returns 463
					/// </summary>
					public const System.Int32 ColumnIndex = 463;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Chargeur_FactureID_Status via shared members
				/// </summary>
				public sealed class Column_Chargeur_FactureID_Status {

					/// <summary>
					/// Returns "Chargeur_FactureID_Status"
					/// </summary>
					public const System.String ColumnName = "Chargeur_FactureID_Status";
					/// <summary>
					/// Returns 464
					/// </summary>
					public const System.Int32 ColumnIndex = 464;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Chargeur_FactureID_StatusDescription via shared members
				/// </summary>
				public sealed class Column_Chargeur_FactureID_StatusDescription {

					/// <summary>
					/// Returns "Chargeur_FactureID_StatusDescription"
					/// </summary>
					public const System.String ColumnName = "Chargeur_FactureID_StatusDescription";
					/// <summary>
					/// Returns 465
					/// </summary>
					public const System.Int32 ColumnIndex = 465;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Chargeur_FactureID_NumeroCheque via shared members
				/// </summary>
				public sealed class Column_Chargeur_FactureID_NumeroCheque {

					/// <summary>
					/// Returns "Chargeur_FactureID_NumeroCheque"
					/// </summary>
					public const System.String ColumnName = "Chargeur_FactureID_NumeroCheque";
					/// <summary>
					/// Returns 466
					/// </summary>
					public const System.Int32 ColumnIndex = 466;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Chargeur_FactureID_NumeroPaiement via shared members
				/// </summary>
				public sealed class Column_Chargeur_FactureID_NumeroPaiement {

					/// <summary>
					/// Returns "Chargeur_FactureID_NumeroPaiement"
					/// </summary>
					public const System.String ColumnName = "Chargeur_FactureID_NumeroPaiement";
					/// <summary>
					/// Returns 467
					/// </summary>
					public const System.Int32 ColumnIndex = 467;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Chargeur_FactureID_NumeroPaiementUnique via shared members
				/// </summary>
				public sealed class Column_Chargeur_FactureID_NumeroPaiementUnique {

					/// <summary>
					/// Returns "Chargeur_FactureID_NumeroPaiementUnique"
					/// </summary>
					public const System.String ColumnName = "Chargeur_FactureID_NumeroPaiementUnique";
					/// <summary>
					/// Returns 468
					/// </summary>
					public const System.Int32 ColumnIndex = 468;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Chargeur_FactureID_DateFactureAcomba via shared members
				/// </summary>
				public sealed class Column_Chargeur_FactureID_DateFactureAcomba {

					/// <summary>
					/// Returns "Chargeur_FactureID_DateFactureAcomba"
					/// </summary>
					public const System.String ColumnName = "Chargeur_FactureID_DateFactureAcomba";
					/// <summary>
					/// Returns 469
					/// </summary>
					public const System.Int32 ColumnIndex = 469;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Chargeur_FactureID_DatePaiementAcomba via shared members
				/// </summary>
				public sealed class Column_Chargeur_FactureID_DatePaiementAcomba {

					/// <summary>
					/// Returns "Chargeur_FactureID_DatePaiementAcomba"
					/// </summary>
					public const System.String ColumnName = "Chargeur_FactureID_DatePaiementAcomba";
					/// <summary>
					/// Returns 470
					/// </summary>
					public const System.Int32 ColumnIndex = 470;

				}

			}
		}

		/// <summary>
		/// This class allows to easily retrieve the name or index of all the fields
		/// of the resulset #2 existing in the Dataset or the SqlDatReader returned by
		/// the Execute method of the 'spS_Livraison_Full' class.
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

