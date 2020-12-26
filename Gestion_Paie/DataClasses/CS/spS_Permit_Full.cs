/*
	This C# source code was automatically generated using:

		SQL Server Centric .NET Code Generator
			v 1.0.1287.20792

			Generation Date: 30/03/2007 9:55:27 AM
			Generator name: <Developer Name Here>
			Template last update: 24/06/2002 1:53:57 AM
			Template revision: 15083637

			SQL Server version: 08.00.0760
			Server: CALIN\francais
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
	/// stored procedure 'spS_Permit_Full'. It allows also to specify specific connection
	/// information such as the ConnectionString to be use, the command time-out and so forth.
	/// </summary>
	[Serializable()]
#if OLYMARS_ATTRIBUTE || OLYMARS_DEBUG
	[OlymarsInformation(DeveloperName="<Developer Name Here>", GeneratedOn="2007/03/30 13:55:27", SqlObjectDependancyName="spS_Permit_Full", SqlObjectDependancyRevision=0)]
#endif
	public sealed class spS_Permit_Full : MarshalByRefObject, IDisposable, IParameter {

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
		/// Initializes a new instance of the spS_Permit_Full class. If you use this constructor version,
		/// not assigning parameter values implies using the parameter default values.
		/// </summary>
		public spS_Permit_Full() : this(true) {

		}

		/// <summary>
		/// Initializes a new instance of the spS_Permit_Full class.
		/// </summary>
		/// <param name="useDefaultValue">If True, this parameter indicates that "not assigning parameter values" implies "using the parameter default values". If False, this parameter indicates that "not assigning parameter values" implies "using the SQL Server Null value".</param>
		public spS_Permit_Full(bool useDefaultValue) {

			this.useDefaultValue = useDefaultValue;

			this.internal_Param_ID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ContratID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_EssenceID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_TransporteurID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ProducteurDroitCoupeID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ProducteurEntentePaiementID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_LotID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ChargeurID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ZoneID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_MunicipaliteID_UseDefaultValue = this.useDefaultValue;
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
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'spS_Permit_Full'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

						throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "spS_Permit_Full", CurrentRevision, OriginalRevision, System.Environment.NewLine));
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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'spS_Permit_Full'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlConnection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "spS_Permit_Full", CurrentRevision, OriginalRevision, System.Environment.NewLine));
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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'spS_Permit_Full'";
				sqlCommand.Transaction = sqlTransaction;

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlTransaction.Connection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "spS_Permit_Full", CurrentRevision, OriginalRevision, System.Environment.NewLine));
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
				this.internal_Param_EssenceID = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_TransporteurID = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_ProducteurDroitCoupeID = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_ProducteurEntentePaiementID = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_LotID = System.Data.SqlTypes.SqlInt32.Null;
				this.internal_Param_ChargeurID = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_ZoneID = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_MunicipaliteID = System.Data.SqlTypes.SqlString.Null;
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
		~spS_Permit_Full() {

			Dispose(false);
		}

		/// <summary>
		/// Returns the stored procedure name for which this class was built, i.e. 'spS_Permit_Full'.
		/// </summary>
		public string StoredProcedureName {

			get {

				return("spS_Permit_Full");
			}
		}

		private System.Data.SqlTypes.SqlInt32 internal_Param_RETURN_VALUE;

		private System.Data.SqlTypes.SqlInt32 internal_Param_ID;
		internal bool internal_Param_ID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_ContratID;
		internal bool internal_Param_ContratID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_EssenceID;
		internal bool internal_Param_EssenceID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_TransporteurID;
		internal bool internal_Param_TransporteurID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_ProducteurDroitCoupeID;
		internal bool internal_Param_ProducteurDroitCoupeID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_ProducteurEntentePaiementID;
		internal bool internal_Param_ProducteurEntentePaiementID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlInt32 internal_Param_LotID;
		internal bool internal_Param_LotID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_ChargeurID;
		internal bool internal_Param_ChargeurID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_ZoneID;
		internal bool internal_Param_ZoneID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_MunicipaliteID;
		internal bool internal_Param_MunicipaliteID_UseDefaultValue = true;

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

			this.internal_Param_EssenceID = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_EssenceID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_TransporteurID = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_TransporteurID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ProducteurDroitCoupeID = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_ProducteurDroitCoupeID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ProducteurEntentePaiementID = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_ProducteurEntentePaiementID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_LotID = System.Data.SqlTypes.SqlInt32.Null;
			this.internal_Param_LotID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ChargeurID = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_ChargeurID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ZoneID = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_ZoneID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_MunicipaliteID = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_MunicipaliteID_UseDefaultValue = this.useDefaultValue;

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
		/// Sets the value of the stored procedure INPUT parameter '@ProducteurDroitCoupeID'.
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
		/// the parameter default value, consider calling the Param_ProducteurDroitCoupeID_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_ProducteurDroitCoupeID {

			get {

				if (this.internal_Param_ProducteurDroitCoupeID_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ProducteurDroitCoupeID);
			}

			set {

				this.internal_Param_ProducteurDroitCoupeID_UseDefaultValue = false;
				this.internal_Param_ProducteurDroitCoupeID = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ProducteurDroitCoupeID' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ProducteurDroitCoupeID_UseDefaultValue() {

			this.internal_Param_ProducteurDroitCoupeID_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ProducteurEntentePaiementID'.
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
		/// the parameter default value, consider calling the Param_ProducteurEntentePaiementID_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_ProducteurEntentePaiementID {

			get {

				if (this.internal_Param_ProducteurEntentePaiementID_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ProducteurEntentePaiementID);
			}

			set {

				this.internal_Param_ProducteurEntentePaiementID_UseDefaultValue = false;
				this.internal_Param_ProducteurEntentePaiementID = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ProducteurEntentePaiementID' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ProducteurEntentePaiementID_UseDefaultValue() {

			this.internal_Param_ProducteurEntentePaiementID_UseDefaultValue = true;
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
	/// This class allows you to execute the 'spS_Permit_Full' stored procedure;
	/// it gives you the ability to:
	/// <list type="bullet">
	/// <item><description>Set all the necessary parameters to execute the stored procedure</description></item>
	/// <item><description>To execute the stored procedure</description></item>
	/// <item><description>To get back after the execution the return value and all the output parameters value</description></item>
	/// </list>
	/// </summary>
#if OLYMARS_ATTRIBUTE || OLYMARS_DEBUG
	[OlymarsInformation(DeveloperName="<Developer Name Here>", GeneratedOn="2007/03/30 13:55:27", SqlObjectDependancyName="spS_Permit_Full", SqlObjectDependancyRevision=0)]
#endif
	public sealed class spS_Permit_Full : MarshalByRefObject, IDisposable {


		private bool throwExceptionOnExecute = false;

		/// <summary>
		/// Initializes a new instance of the spS_Permit_Full class.
		/// By default, no exception will be thrown when you call the Execute method. Instead, a Boolean return status will be returned.
		/// </summary>
		public spS_Permit_Full() : this(false) {

		}

		/// <summary>
		/// Initializes a new instance of the spS_Permit_Full class.
		/// </summary>
		/// <param name="throwExceptionOnExecute">True if an exception has to be thrown if the Execute call fails.</param>
		public spS_Permit_Full(bool throwExceptionOnExecute) {

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
		~spS_Permit_Full() {

			Dispose(false);
		}

		private void ResetParameter(ref Gestion_Paie.DataClasses.Parameters.spS_Permit_Full parameters) {

			parameters.internal_Set_RETURN_VALUE (System.Data.SqlTypes.SqlInt32.Null);
		}

		private bool InitializeConnection(ref Gestion_Paie.DataClasses.Parameters.spS_Permit_Full parameters, out System.Data.SqlClient.SqlCommand sqlCommand, ref bool connectionMustBeClosed) {

			try {

				this.sqlConnection = null;
				sqlCommand = null;
				connectionMustBeClosed = true;

				if (parameters.ConnectionType == ConnectionType.None) {

					throw new InvalidOperationException("No connection information was supplied. Consider calling the 'SetUpConnection' method of the Gestion_Paie.DataClasses.Parameters.spS_Permit_Full object before doing this call.");
				}

				if (parameters.ConnectionType == ConnectionType.SqlConnection && parameters.SqlConnection == null) {

					throw new InvalidOperationException("No connection information was supplied (SqlConnection == null). Consider calling the 'SetUpConnection' method of the Gestion_Paie.DataClasses.Parameters.spS_Permit_Full object before doing this call.");
				}

				if (parameters.ConnectionType == ConnectionType.SqlTransaction && parameters.SqlTransaction== null) {

					throw new InvalidOperationException("No connection information was supplied (SqlTransaction == null). Consider calling the 'SetUpConnection' method of the Gestion_Paie.DataClasses.Parameters.spS_Permit_Full object before doing this call.");
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

							throw new System.InvalidOperationException("No connection information was supplied (ConnectionString == \"\")! (Gestion_Paie.DataClasses.Parameters.spS_Permit_Full)");
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
				sqlCommand.CommandText = "spS_Permit_Full";

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

		private bool DeclareParameters(ref Gestion_Paie.DataClasses.Parameters.spS_Permit_Full parameters, ref System.Data.SqlClient.SqlCommand sqlCommand) {

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

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ProducteurDroitCoupeID", System.Data.SqlDbType.VarChar, 15);
				sqlParameter.SourceColumn = "ProducteurDroitCoupeID";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ProducteurDroitCoupeID_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ProducteurDroitCoupeID.IsNull) {

					sqlParameter.Value = parameters.Param_ProducteurDroitCoupeID;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ProducteurEntentePaiementID", System.Data.SqlDbType.VarChar, 15);
				sqlParameter.SourceColumn = "ProducteurEntentePaiementID";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ProducteurEntentePaiementID_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ProducteurEntentePaiementID.IsNull) {

					sqlParameter.Value = parameters.Param_ProducteurEntentePaiementID;
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

		private bool RetrieveParameters(ref Gestion_Paie.DataClasses.Parameters.spS_Permit_Full parameters, ref System.Data.SqlClient.SqlCommand sqlCommand) {

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
		/// This method allows you to execute the [spS_Permit_Full] stored procedure and retrieve back the data
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
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.spS_Permit_Full parameters, out System.Data.SqlClient.SqlDataReader sqlDataReader) {

			return(Execute(ref parameters, out sqlDataReader, System.Data.CommandBehavior.Default));
		}

		/// <summary>
		/// This method allows you to execute the [spS_Permit_Full] stored procedure and retrieve back the data
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
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.spS_Permit_Full parameters, out System.Data.SqlClient.SqlDataReader sqlDataReader, System.Data.CommandBehavior commandBehavior) {

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
		/// This method allows you to execute the [spS_Permit_Full] stored procedure and retrieve back the data
		/// populated in a DataSet (System.Data.DataSet).
		/// </summary>
		/// <param name="parameters">
		/// Contains all the necessary information to execute correctly the stored procedure, i.e. 
		/// the database connection to use and all the necessary input parameters to be supplied
		/// for this stored procedure execution. After the execution, this object will allow you
		/// to retrieve back the stored procedure return value and all the output parameters.
		/// </param>
		/// <param name="dataset">
		/// Will be populated with the data after execution. The table based name used will be: 'spS_Permit_Full'.
		/// </param>
		/// <returns>True if the call was successful. Otherwise, it returns False.</returns>
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.spS_Permit_Full parameters, ref System.Data.DataSet dataset) {

			return(Execute(ref parameters, ref dataset, "spS_Permit_Full", -1, -1));
		}

		/// <summary>
		/// This method allows you to execute the [spS_Permit_Full] stored procedure and retrieve back the data
		/// populated in a DataSet (System.Data.DataSet).
		/// </summary>
		/// <param name="parameters">
		/// Contains all the necessary information to execute correctly the stored procedure, i.e. 
		/// the database connection to use and all the necessary input parameters to be supplied
		/// for this stored procedure execution. After the execution, this object will allow you
		/// to retrieve back the stored procedure return value and all the output parameters.
		/// </param>
		/// <param name="dataset">
		/// Will be populated with the data after execution. The table based name used will be: 'spS_Permit_Full'.
		/// </param>
		/// <param name="startRecord">The zero-based record number to start with.</param>
		/// <param name="maxRecords">The maximum number of records to retrieve.</param>
		/// <returns>True if the call was successful. Otherwise, it returns False.</returns>
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.spS_Permit_Full parameters, ref System.Data.DataSet dataset, int startRecord, int maxRecords) {

			return(Execute(ref parameters, ref dataset, "spS_Permit_Full", startRecord, maxRecords));
		}

		/// <summary>
		/// This method allows you to execute the [spS_Permit_Full] stored procedure and retrieve back the data
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
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.spS_Permit_Full parameters, ref System.Data.DataSet dataset, string tableName) {

			return(Execute(ref parameters, ref dataset, tableName, -1, -1));
		}

		/// <summary>
		/// This method allows you to execute the [spS_Permit_Full] stored procedure and retrieve back the data
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
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.spS_Permit_Full parameters, ref System.Data.DataSet dataset, string tableName, int startRecord, int maxRecords) {

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
				dataset.Tables[tableName].Columns["DatePermit"].Caption = "DatePermit (update this label in the \"Olymars/ColumnLabel\" extended property of the \"DatePermit\" column)";
				dataset.Tables[tableName].Columns["DateDebut"].Caption = "DateDebut (update this label in the \"Olymars/ColumnLabel\" extended property of the \"DateDebut\" column)";
				dataset.Tables[tableName].Columns["DateFin"].Caption = "DateFin (update this label in the \"Olymars/ColumnLabel\" extended property of the \"DateFin\" column)";
				dataset.Tables[tableName].Columns["Annee"].Caption = "Annee (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Annee\" column)";
				dataset.Tables[tableName].Columns["Periode"].Caption = "Periode (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Periode\" column)";
				dataset.Tables[tableName].Columns["ContratID"].Caption = "ContratID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ContratID\" column)";
				dataset.Tables[tableName].Columns["EssenceID"].Caption = "EssenceID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"EssenceID\" column)";
				dataset.Tables[tableName].Columns["PermitSciage"].Caption = "PermitSciage (update this label in the \"Olymars/ColumnLabel\" extended property of the \"PermitSciage\" column)";
				dataset.Tables[tableName].Columns["TransporteurID"].Caption = "TransporteurID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"TransporteurID\" column)";
				dataset.Tables[tableName].Columns["VR"].Caption = "VR (update this label in the \"Olymars/ColumnLabel\" extended property of the \"VR\" column)";
				dataset.Tables[tableName].Columns["ProducteurDroitCoupeID"].Caption = "ProducteurDroitCoupeID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ProducteurDroitCoupeID\" column)";
				dataset.Tables[tableName].Columns["ProducteurEntentePaiementID"].Caption = "ProducteurEntentePaiementID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ProducteurEntentePaiementID\" column)";
				dataset.Tables[tableName].Columns["PermitLivre"].Caption = "PermitLivre (update this label in the \"Olymars/ColumnLabel\" extended property of the \"PermitLivre\" column)";
				dataset.Tables[tableName].Columns["PermitImprime"].Caption = "PermitImprime (update this label in the \"Olymars/ColumnLabel\" extended property of the \"PermitImprime\" column)";
				dataset.Tables[tableName].Columns["PermitAnnule"].Caption = "PermitAnnule (update this label in the \"Olymars/ColumnLabel\" extended property of the \"PermitAnnule\" column)";
				dataset.Tables[tableName].Columns["LotID"].Caption = "LotID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"LotID\" column)";
				dataset.Tables[tableName].Columns["EssenceSciage"].Caption = "EssenceSciage (update this label in the \"Olymars/ColumnLabel\" extended property of the \"EssenceSciage\" column)";
				dataset.Tables[tableName].Columns["Code"].Caption = "Code (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Code\" column)";
				dataset.Tables[tableName].Columns["Remarques"].Caption = "Remarques (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Remarques\" column)";
				dataset.Tables[tableName].Columns["ChargeurID"].Caption = "ChargeurID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ChargeurID\" column)";
				dataset.Tables[tableName].Columns["ZoneID"].Caption = "ZoneID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ZoneID\" column)";
				dataset.Tables[tableName].Columns["MunicipaliteID"].Caption = "MunicipaliteID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"MunicipaliteID\" column)";
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
				dataset.Tables[tableName].Columns["EssenceID_ID"].Caption = "ID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ID\" column)";
				dataset.Tables[tableName].Columns["EssenceID_Description"].Caption = "Description (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Description\" column)";
				dataset.Tables[tableName].Columns["EssenceID_RegroupementID"].Caption = "RegroupementID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"RegroupementID\" column)";
				dataset.Tables[tableName].Columns["EssenceID_ContingentID"].Caption = "ContingentID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ContingentID\" column)";
				dataset.Tables[tableName].Columns["EssenceID_RepartitionID"].Caption = "RepartitionID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"RepartitionID\" column)";
				dataset.Tables[tableName].Columns["EssenceID_Actif"].Caption = "Actif (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Actif\" column)";
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
				dataset.Tables[tableName].Columns["ProducteurDroitCoupeID_ID"].Caption = "ID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ID\" column)";
				dataset.Tables[tableName].Columns["ProducteurDroitCoupeID_CleTri"].Caption = "CleTri (update this label in the \"Olymars/ColumnLabel\" extended property of the \"CleTri\" column)";
				dataset.Tables[tableName].Columns["ProducteurDroitCoupeID_Nom"].Caption = "Nom (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Nom\" column)";
				dataset.Tables[tableName].Columns["ProducteurDroitCoupeID_AuSoinsDe"].Caption = "AuSoinsDe (update this label in the \"Olymars/ColumnLabel\" extended property of the \"AuSoinsDe\" column)";
				dataset.Tables[tableName].Columns["ProducteurDroitCoupeID_Rue"].Caption = "Rue (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Rue\" column)";
				dataset.Tables[tableName].Columns["ProducteurDroitCoupeID_Ville"].Caption = "Ville (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Ville\" column)";
				dataset.Tables[tableName].Columns["ProducteurDroitCoupeID_PaysID"].Caption = "PaysID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"PaysID\" column)";
				dataset.Tables[tableName].Columns["ProducteurDroitCoupeID_Code_postal"].Caption = "Code_postal (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Code_postal\" column)";
				dataset.Tables[tableName].Columns["ProducteurDroitCoupeID_Telephone"].Caption = "Telephone (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone\" column)";
				dataset.Tables[tableName].Columns["ProducteurDroitCoupeID_Telephone_Poste"].Caption = "Telephone_Poste (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone_Poste\" column)";
				dataset.Tables[tableName].Columns["ProducteurDroitCoupeID_Telecopieur"].Caption = "Telecopieur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telecopieur\" column)";
				dataset.Tables[tableName].Columns["ProducteurDroitCoupeID_Telephone2"].Caption = "Telephone2 (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone2\" column)";
				dataset.Tables[tableName].Columns["ProducteurDroitCoupeID_Telephone2_Desc"].Caption = "Telephone2_Desc (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone2_Desc\" column)";
				dataset.Tables[tableName].Columns["ProducteurDroitCoupeID_Telephone2_Poste"].Caption = "Telephone2_Poste (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone2_Poste\" column)";
				dataset.Tables[tableName].Columns["ProducteurDroitCoupeID_Telephone3"].Caption = "Telephone3 (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone3\" column)";
				dataset.Tables[tableName].Columns["ProducteurDroitCoupeID_Telephone3_Desc"].Caption = "Telephone3_Desc (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone3_Desc\" column)";
				dataset.Tables[tableName].Columns["ProducteurDroitCoupeID_Telephone3_Poste"].Caption = "Telephone3_Poste (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone3_Poste\" column)";
				dataset.Tables[tableName].Columns["ProducteurDroitCoupeID_No_membre"].Caption = "No_membre (update this label in the \"Olymars/ColumnLabel\" extended property of the \"No_membre\" column)";
				dataset.Tables[tableName].Columns["ProducteurDroitCoupeID_Resident"].Caption = "Resident (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Resident\" column)";
				dataset.Tables[tableName].Columns["ProducteurDroitCoupeID_Email"].Caption = "Email (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Email\" column)";
				dataset.Tables[tableName].Columns["ProducteurDroitCoupeID_WWW"].Caption = "WWW (update this label in the \"Olymars/ColumnLabel\" extended property of the \"WWW\" column)";
				dataset.Tables[tableName].Columns["ProducteurDroitCoupeID_Commentaires"].Caption = "Commentaires (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Commentaires\" column)";
				dataset.Tables[tableName].Columns["ProducteurDroitCoupeID_AfficherCommentaires"].Caption = "AfficherCommentaires (update this label in the \"Olymars/ColumnLabel\" extended property of the \"AfficherCommentaires\" column)";
				dataset.Tables[tableName].Columns["ProducteurDroitCoupeID_DepotDirect"].Caption = "DepotDirect (update this label in the \"Olymars/ColumnLabel\" extended property of the \"DepotDirect\" column)";
				dataset.Tables[tableName].Columns["ProducteurDroitCoupeID_InstitutionBanquaireID"].Caption = "InstitutionBanquaireID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"InstitutionBanquaireID\" column)";
				dataset.Tables[tableName].Columns["ProducteurDroitCoupeID_Banque_transit"].Caption = "Banque_transit (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Banque_transit\" column)";
				dataset.Tables[tableName].Columns["ProducteurDroitCoupeID_Banque_folio"].Caption = "Banque_folio (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Banque_folio\" column)";
				dataset.Tables[tableName].Columns["ProducteurDroitCoupeID_No_TPS"].Caption = "No_TPS (update this label in the \"Olymars/ColumnLabel\" extended property of the \"No_TPS\" column)";
				dataset.Tables[tableName].Columns["ProducteurDroitCoupeID_No_TVQ"].Caption = "No_TVQ (update this label in the \"Olymars/ColumnLabel\" extended property of the \"No_TVQ\" column)";
				dataset.Tables[tableName].Columns["ProducteurDroitCoupeID_PayerA"].Caption = "PayerA (update this label in the \"Olymars/ColumnLabel\" extended property of the \"PayerA\" column)";
				dataset.Tables[tableName].Columns["ProducteurDroitCoupeID_PayerAID"].Caption = "PayerAID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"PayerAID\" column)";
				dataset.Tables[tableName].Columns["ProducteurDroitCoupeID_Statut"].Caption = "Statut (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Statut\" column)";
				dataset.Tables[tableName].Columns["ProducteurDroitCoupeID_Rep_Nom"].Caption = "Rep_Nom (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Rep_Nom\" column)";
				dataset.Tables[tableName].Columns["ProducteurDroitCoupeID_Rep_Telephone"].Caption = "Rep_Telephone (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Rep_Telephone\" column)";
				dataset.Tables[tableName].Columns["ProducteurDroitCoupeID_Rep_Telephone_Poste"].Caption = "Rep_Telephone_Poste (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Rep_Telephone_Poste\" column)";
				dataset.Tables[tableName].Columns["ProducteurDroitCoupeID_Rep_Email"].Caption = "Rep_Email (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Rep_Email\" column)";
				dataset.Tables[tableName].Columns["ProducteurDroitCoupeID_EnAnglais"].Caption = "EnAnglais (update this label in the \"Olymars/ColumnLabel\" extended property of the \"EnAnglais\" column)";
				dataset.Tables[tableName].Columns["ProducteurDroitCoupeID_Actif"].Caption = "Actif (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Actif\" column)";
				dataset.Tables[tableName].Columns["ProducteurDroitCoupeID_MRCProducteurID"].Caption = "MRCProducteurID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"MRCProducteurID\" column)";
				dataset.Tables[tableName].Columns["ProducteurDroitCoupeID_PaiementManuel"].Caption = "PaiementManuel (update this label in the \"Olymars/ColumnLabel\" extended property of the \"PaiementManuel\" column)";
				dataset.Tables[tableName].Columns["ProducteurDroitCoupeID_Journal"].Caption = "Journal (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Journal\" column)";
				dataset.Tables[tableName].Columns["ProducteurDroitCoupeID_RecoitTPS"].Caption = "RecoitTPS (update this label in the \"Olymars/ColumnLabel\" extended property of the \"RecoitTPS\" column)";
				dataset.Tables[tableName].Columns["ProducteurDroitCoupeID_RecoitTVQ"].Caption = "RecoitTVQ (update this label in the \"Olymars/ColumnLabel\" extended property of the \"RecoitTVQ\" column)";
				dataset.Tables[tableName].Columns["ProducteurDroitCoupeID_ModifierTrigger"].Caption = "ModifierTrigger (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ModifierTrigger\" column)";
				dataset.Tables[tableName].Columns["ProducteurDroitCoupeID_IsProducteur"].Caption = "IsProducteur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"IsProducteur\" column)";
				dataset.Tables[tableName].Columns["ProducteurDroitCoupeID_IsTransporteur"].Caption = "IsTransporteur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"IsTransporteur\" column)";
				dataset.Tables[tableName].Columns["ProducteurDroitCoupeID_IsChargeur"].Caption = "IsChargeur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"IsChargeur\" column)";
				dataset.Tables[tableName].Columns["ProducteurDroitCoupeID_IsAutre"].Caption = "IsAutre (update this label in the \"Olymars/ColumnLabel\" extended property of the \"IsAutre\" column)";
				dataset.Tables[tableName].Columns["ProducteurDroitCoupeID_AfficherCommentairesSurPermit"].Caption = "AfficherCommentairesSurPermit (update this label in the \"Olymars/ColumnLabel\" extended property of the \"AfficherCommentairesSurPermit\" column)";
				dataset.Tables[tableName].Columns["ProducteurDroitCoupeID_PasEmissionPermis"].Caption = "PasEmissionPermis (update this label in the \"Olymars/ColumnLabel\" extended property of the \"PasEmissionPermis\" column)";
				dataset.Tables[tableName].Columns["ProducteurDroitCoupeID_Generique"].Caption = "Generique (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Generique\" column)";
				dataset.Tables[tableName].Columns["ProducteurEntentePaiementID_ID"].Caption = "ID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ID\" column)";
				dataset.Tables[tableName].Columns["ProducteurEntentePaiementID_CleTri"].Caption = "CleTri (update this label in the \"Olymars/ColumnLabel\" extended property of the \"CleTri\" column)";
				dataset.Tables[tableName].Columns["ProducteurEntentePaiementID_Nom"].Caption = "Nom (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Nom\" column)";
				dataset.Tables[tableName].Columns["ProducteurEntentePaiementID_AuSoinsDe"].Caption = "AuSoinsDe (update this label in the \"Olymars/ColumnLabel\" extended property of the \"AuSoinsDe\" column)";
				dataset.Tables[tableName].Columns["ProducteurEntentePaiementID_Rue"].Caption = "Rue (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Rue\" column)";
				dataset.Tables[tableName].Columns["ProducteurEntentePaiementID_Ville"].Caption = "Ville (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Ville\" column)";
				dataset.Tables[tableName].Columns["ProducteurEntentePaiementID_PaysID"].Caption = "PaysID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"PaysID\" column)";
				dataset.Tables[tableName].Columns["ProducteurEntentePaiementID_Code_postal"].Caption = "Code_postal (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Code_postal\" column)";
				dataset.Tables[tableName].Columns["ProducteurEntentePaiementID_Telephone"].Caption = "Telephone (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone\" column)";
				dataset.Tables[tableName].Columns["ProducteurEntentePaiementID_Telephone_Poste"].Caption = "Telephone_Poste (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone_Poste\" column)";
				dataset.Tables[tableName].Columns["ProducteurEntentePaiementID_Telecopieur"].Caption = "Telecopieur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telecopieur\" column)";
				dataset.Tables[tableName].Columns["ProducteurEntentePaiementID_Telephone2"].Caption = "Telephone2 (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone2\" column)";
				dataset.Tables[tableName].Columns["ProducteurEntentePaiementID_Telephone2_Desc"].Caption = "Telephone2_Desc (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone2_Desc\" column)";
				dataset.Tables[tableName].Columns["ProducteurEntentePaiementID_Telephone2_Poste"].Caption = "Telephone2_Poste (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone2_Poste\" column)";
				dataset.Tables[tableName].Columns["ProducteurEntentePaiementID_Telephone3"].Caption = "Telephone3 (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone3\" column)";
				dataset.Tables[tableName].Columns["ProducteurEntentePaiementID_Telephone3_Desc"].Caption = "Telephone3_Desc (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone3_Desc\" column)";
				dataset.Tables[tableName].Columns["ProducteurEntentePaiementID_Telephone3_Poste"].Caption = "Telephone3_Poste (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone3_Poste\" column)";
				dataset.Tables[tableName].Columns["ProducteurEntentePaiementID_No_membre"].Caption = "No_membre (update this label in the \"Olymars/ColumnLabel\" extended property of the \"No_membre\" column)";
				dataset.Tables[tableName].Columns["ProducteurEntentePaiementID_Resident"].Caption = "Resident (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Resident\" column)";
				dataset.Tables[tableName].Columns["ProducteurEntentePaiementID_Email"].Caption = "Email (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Email\" column)";
				dataset.Tables[tableName].Columns["ProducteurEntentePaiementID_WWW"].Caption = "WWW (update this label in the \"Olymars/ColumnLabel\" extended property of the \"WWW\" column)";
				dataset.Tables[tableName].Columns["ProducteurEntentePaiementID_Commentaires"].Caption = "Commentaires (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Commentaires\" column)";
				dataset.Tables[tableName].Columns["ProducteurEntentePaiementID_AfficherCommentaires"].Caption = "AfficherCommentaires (update this label in the \"Olymars/ColumnLabel\" extended property of the \"AfficherCommentaires\" column)";
				dataset.Tables[tableName].Columns["ProducteurEntentePaiementID_DepotDirect"].Caption = "DepotDirect (update this label in the \"Olymars/ColumnLabel\" extended property of the \"DepotDirect\" column)";
				dataset.Tables[tableName].Columns["ProducteurEntentePaiementID_InstitutionBanquaireID"].Caption = "InstitutionBanquaireID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"InstitutionBanquaireID\" column)";
				dataset.Tables[tableName].Columns["ProducteurEntentePaiementID_Banque_transit"].Caption = "Banque_transit (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Banque_transit\" column)";
				dataset.Tables[tableName].Columns["ProducteurEntentePaiementID_Banque_folio"].Caption = "Banque_folio (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Banque_folio\" column)";
				dataset.Tables[tableName].Columns["ProducteurEntentePaiementID_No_TPS"].Caption = "No_TPS (update this label in the \"Olymars/ColumnLabel\" extended property of the \"No_TPS\" column)";
				dataset.Tables[tableName].Columns["ProducteurEntentePaiementID_No_TVQ"].Caption = "No_TVQ (update this label in the \"Olymars/ColumnLabel\" extended property of the \"No_TVQ\" column)";
				dataset.Tables[tableName].Columns["ProducteurEntentePaiementID_PayerA"].Caption = "PayerA (update this label in the \"Olymars/ColumnLabel\" extended property of the \"PayerA\" column)";
				dataset.Tables[tableName].Columns["ProducteurEntentePaiementID_PayerAID"].Caption = "PayerAID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"PayerAID\" column)";
				dataset.Tables[tableName].Columns["ProducteurEntentePaiementID_Statut"].Caption = "Statut (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Statut\" column)";
				dataset.Tables[tableName].Columns["ProducteurEntentePaiementID_Rep_Nom"].Caption = "Rep_Nom (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Rep_Nom\" column)";
				dataset.Tables[tableName].Columns["ProducteurEntentePaiementID_Rep_Telephone"].Caption = "Rep_Telephone (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Rep_Telephone\" column)";
				dataset.Tables[tableName].Columns["ProducteurEntentePaiementID_Rep_Telephone_Poste"].Caption = "Rep_Telephone_Poste (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Rep_Telephone_Poste\" column)";
				dataset.Tables[tableName].Columns["ProducteurEntentePaiementID_Rep_Email"].Caption = "Rep_Email (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Rep_Email\" column)";
				dataset.Tables[tableName].Columns["ProducteurEntentePaiementID_EnAnglais"].Caption = "EnAnglais (update this label in the \"Olymars/ColumnLabel\" extended property of the \"EnAnglais\" column)";
				dataset.Tables[tableName].Columns["ProducteurEntentePaiementID_Actif"].Caption = "Actif (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Actif\" column)";
				dataset.Tables[tableName].Columns["ProducteurEntentePaiementID_MRCProducteurID"].Caption = "MRCProducteurID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"MRCProducteurID\" column)";
				dataset.Tables[tableName].Columns["ProducteurEntentePaiementID_PaiementManuel"].Caption = "PaiementManuel (update this label in the \"Olymars/ColumnLabel\" extended property of the \"PaiementManuel\" column)";
				dataset.Tables[tableName].Columns["ProducteurEntentePaiementID_Journal"].Caption = "Journal (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Journal\" column)";
				dataset.Tables[tableName].Columns["ProducteurEntentePaiementID_RecoitTPS"].Caption = "RecoitTPS (update this label in the \"Olymars/ColumnLabel\" extended property of the \"RecoitTPS\" column)";
				dataset.Tables[tableName].Columns["ProducteurEntentePaiementID_RecoitTVQ"].Caption = "RecoitTVQ (update this label in the \"Olymars/ColumnLabel\" extended property of the \"RecoitTVQ\" column)";
				dataset.Tables[tableName].Columns["ProducteurEntentePaiementID_ModifierTrigger"].Caption = "ModifierTrigger (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ModifierTrigger\" column)";
				dataset.Tables[tableName].Columns["ProducteurEntentePaiementID_IsProducteur"].Caption = "IsProducteur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"IsProducteur\" column)";
				dataset.Tables[tableName].Columns["ProducteurEntentePaiementID_IsTransporteur"].Caption = "IsTransporteur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"IsTransporteur\" column)";
				dataset.Tables[tableName].Columns["ProducteurEntentePaiementID_IsChargeur"].Caption = "IsChargeur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"IsChargeur\" column)";
				dataset.Tables[tableName].Columns["ProducteurEntentePaiementID_IsAutre"].Caption = "IsAutre (update this label in the \"Olymars/ColumnLabel\" extended property of the \"IsAutre\" column)";
				dataset.Tables[tableName].Columns["ProducteurEntentePaiementID_AfficherCommentairesSurPermit"].Caption = "AfficherCommentairesSurPermit (update this label in the \"Olymars/ColumnLabel\" extended property of the \"AfficherCommentairesSurPermit\" column)";
				dataset.Tables[tableName].Columns["ProducteurEntentePaiementID_PasEmissionPermis"].Caption = "PasEmissionPermis (update this label in the \"Olymars/ColumnLabel\" extended property of the \"PasEmissionPermis\" column)";
				dataset.Tables[tableName].Columns["ProducteurEntentePaiementID_Generique"].Caption = "Generique (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Generique\" column)";
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
				dataset.Tables[tableName].Columns["ZoneID_ID"].Caption = "ID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ID\" column)";
				dataset.Tables[tableName].Columns["ZoneID_MunicipaliteID"].Caption = "MunicipaliteID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"MunicipaliteID\" column)";
				dataset.Tables[tableName].Columns["ZoneID_Description"].Caption = "Description (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Description\" column)";
				dataset.Tables[tableName].Columns["ZoneID_Actif"].Caption = "Actif (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Actif\" column)";
				dataset.Tables[tableName].Columns["MunicipaliteID_ID"].Caption = "ID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ID\" column)";
				dataset.Tables[tableName].Columns["MunicipaliteID_MunicipaliteID"].Caption = "MunicipaliteID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"MunicipaliteID\" column)";
				dataset.Tables[tableName].Columns["MunicipaliteID_Description"].Caption = "Description (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Description\" column)";
				dataset.Tables[tableName].Columns["MunicipaliteID_Actif"].Caption = "Actif (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Actif\" column)";

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
		/// This method allows you to execute the [spS_Permit_Full] stored procedure and retrieve back the data
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
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.spS_Permit_Full parameters, ref string xml) {

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
		/// This method allows you to execute the [spS_Permit_Full] stored procedure and retrieve back the data
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
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.spS_Permit_Full parameters, out System.Xml.XmlReader xmlReader) {

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
		/// the Execute method of the 'spS_Permit_Full' class.
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
				/// Allows to get the Index and Name of the field DatePermit via shared members
				/// </summary>
				public sealed class Column_DatePermit {

					/// <summary>
					/// Returns "DatePermit"
					/// </summary>
					public const System.String ColumnName = "DatePermit";
					/// <summary>
					/// Returns 1
					/// </summary>
					public const System.Int32 ColumnIndex = 1;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field DateDebut via shared members
				/// </summary>
				public sealed class Column_DateDebut {

					/// <summary>
					/// Returns "DateDebut"
					/// </summary>
					public const System.String ColumnName = "DateDebut";
					/// <summary>
					/// Returns 2
					/// </summary>
					public const System.Int32 ColumnIndex = 2;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field DateFin via shared members
				/// </summary>
				public sealed class Column_DateFin {

					/// <summary>
					/// Returns "DateFin"
					/// </summary>
					public const System.String ColumnName = "DateFin";
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
				/// Allows to get the Index and Name of the field Periode via shared members
				/// </summary>
				public sealed class Column_Periode {

					/// <summary>
					/// Returns "Periode"
					/// </summary>
					public const System.String ColumnName = "Periode";
					/// <summary>
					/// Returns 5
					/// </summary>
					public const System.Int32 ColumnIndex = 5;

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
					/// Returns 6
					/// </summary>
					public const System.Int32 ColumnIndex = 6;

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
					/// Returns 7
					/// </summary>
					public const System.Int32 ColumnIndex = 7;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field PermitSciage via shared members
				/// </summary>
				public sealed class Column_PermitSciage {

					/// <summary>
					/// Returns "PermitSciage"
					/// </summary>
					public const System.String ColumnName = "PermitSciage";
					/// <summary>
					/// Returns 8
					/// </summary>
					public const System.Int32 ColumnIndex = 8;

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
					/// Returns 9
					/// </summary>
					public const System.Int32 ColumnIndex = 9;

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
					/// Returns 10
					/// </summary>
					public const System.Int32 ColumnIndex = 10;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurDroitCoupeID via shared members
				/// </summary>
				public sealed class Column_ProducteurDroitCoupeID {

					/// <summary>
					/// Returns "ProducteurDroitCoupeID"
					/// </summary>
					public const System.String ColumnName = "ProducteurDroitCoupeID";
					/// <summary>
					/// Returns 11
					/// </summary>
					public const System.Int32 ColumnIndex = 11;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurEntentePaiementID via shared members
				/// </summary>
				public sealed class Column_ProducteurEntentePaiementID {

					/// <summary>
					/// Returns "ProducteurEntentePaiementID"
					/// </summary>
					public const System.String ColumnName = "ProducteurEntentePaiementID";
					/// <summary>
					/// Returns 12
					/// </summary>
					public const System.Int32 ColumnIndex = 12;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field PermitLivre via shared members
				/// </summary>
				public sealed class Column_PermitLivre {

					/// <summary>
					/// Returns "PermitLivre"
					/// </summary>
					public const System.String ColumnName = "PermitLivre";
					/// <summary>
					/// Returns 13
					/// </summary>
					public const System.Int32 ColumnIndex = 13;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field PermitImprime via shared members
				/// </summary>
				public sealed class Column_PermitImprime {

					/// <summary>
					/// Returns "PermitImprime"
					/// </summary>
					public const System.String ColumnName = "PermitImprime";
					/// <summary>
					/// Returns 14
					/// </summary>
					public const System.Int32 ColumnIndex = 14;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field PermitAnnule via shared members
				/// </summary>
				public sealed class Column_PermitAnnule {

					/// <summary>
					/// Returns "PermitAnnule"
					/// </summary>
					public const System.String ColumnName = "PermitAnnule";
					/// <summary>
					/// Returns 15
					/// </summary>
					public const System.Int32 ColumnIndex = 15;

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
					/// Returns 16
					/// </summary>
					public const System.Int32 ColumnIndex = 16;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field EssenceSciage via shared members
				/// </summary>
				public sealed class Column_EssenceSciage {

					/// <summary>
					/// Returns "EssenceSciage"
					/// </summary>
					public const System.String ColumnName = "EssenceSciage";
					/// <summary>
					/// Returns 17
					/// </summary>
					public const System.Int32 ColumnIndex = 17;

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
					/// Returns 18
					/// </summary>
					public const System.Int32 ColumnIndex = 18;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Remarques via shared members
				/// </summary>
				public sealed class Column_Remarques {

					/// <summary>
					/// Returns "Remarques"
					/// </summary>
					public const System.String ColumnName = "Remarques";
					/// <summary>
					/// Returns 19
					/// </summary>
					public const System.Int32 ColumnIndex = 19;

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
					/// Returns 20
					/// </summary>
					public const System.Int32 ColumnIndex = 20;

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
					/// Returns 21
					/// </summary>
					public const System.Int32 ColumnIndex = 21;

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
					/// Returns 22
					/// </summary>
					public const System.Int32 ColumnIndex = 22;

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
					/// Returns 23
					/// </summary>
					public const System.Int32 ColumnIndex = 23;

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
					/// Returns 24
					/// </summary>
					public const System.Int32 ColumnIndex = 24;

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
					/// Returns 25
					/// </summary>
					public const System.Int32 ColumnIndex = 25;

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
					/// Returns 26
					/// </summary>
					public const System.Int32 ColumnIndex = 26;

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
					/// Returns 27
					/// </summary>
					public const System.Int32 ColumnIndex = 27;

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
					/// Returns 28
					/// </summary>
					public const System.Int32 ColumnIndex = 28;

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
					/// Returns 29
					/// </summary>
					public const System.Int32 ColumnIndex = 29;

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
					/// Returns 30
					/// </summary>
					public const System.Int32 ColumnIndex = 30;

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
					/// Returns 31
					/// </summary>
					public const System.Int32 ColumnIndex = 31;

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
					/// Returns 32
					/// </summary>
					public const System.Int32 ColumnIndex = 32;

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
					/// Returns 33
					/// </summary>
					public const System.Int32 ColumnIndex = 33;

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
					/// Returns 34
					/// </summary>
					public const System.Int32 ColumnIndex = 34;

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
					/// Returns 35
					/// </summary>
					public const System.Int32 ColumnIndex = 35;

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
					/// Returns 36
					/// </summary>
					public const System.Int32 ColumnIndex = 36;

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
					/// Returns 37
					/// </summary>
					public const System.Int32 ColumnIndex = 37;

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
					/// Returns 38
					/// </summary>
					public const System.Int32 ColumnIndex = 38;

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
					/// Returns 39
					/// </summary>
					public const System.Int32 ColumnIndex = 39;

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
					/// Returns 40
					/// </summary>
					public const System.Int32 ColumnIndex = 40;

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
					/// Returns 41
					/// </summary>
					public const System.Int32 ColumnIndex = 41;

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
					/// Returns 42
					/// </summary>
					public const System.Int32 ColumnIndex = 42;

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
					/// Returns 43
					/// </summary>
					public const System.Int32 ColumnIndex = 43;

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
					/// Returns 44
					/// </summary>
					public const System.Int32 ColumnIndex = 44;

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
					/// Returns 45
					/// </summary>
					public const System.Int32 ColumnIndex = 45;

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
					/// Returns 46
					/// </summary>
					public const System.Int32 ColumnIndex = 46;

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
					/// Returns 47
					/// </summary>
					public const System.Int32 ColumnIndex = 47;

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
					/// Returns 48
					/// </summary>
					public const System.Int32 ColumnIndex = 48;

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
					/// Returns 49
					/// </summary>
					public const System.Int32 ColumnIndex = 49;

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
					/// Returns 50
					/// </summary>
					public const System.Int32 ColumnIndex = 50;

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
					/// Returns 51
					/// </summary>
					public const System.Int32 ColumnIndex = 51;

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
					/// Returns 52
					/// </summary>
					public const System.Int32 ColumnIndex = 52;

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
					/// Returns 53
					/// </summary>
					public const System.Int32 ColumnIndex = 53;

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
					/// Returns 54
					/// </summary>
					public const System.Int32 ColumnIndex = 54;

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
					/// Returns 55
					/// </summary>
					public const System.Int32 ColumnIndex = 55;

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
					/// Returns 56
					/// </summary>
					public const System.Int32 ColumnIndex = 56;

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
					/// Returns 57
					/// </summary>
					public const System.Int32 ColumnIndex = 57;

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
					/// Returns 58
					/// </summary>
					public const System.Int32 ColumnIndex = 58;

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
					/// Returns 59
					/// </summary>
					public const System.Int32 ColumnIndex = 59;

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
					/// Returns 60
					/// </summary>
					public const System.Int32 ColumnIndex = 60;

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
					/// Returns 61
					/// </summary>
					public const System.Int32 ColumnIndex = 61;

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
					/// Returns 62
					/// </summary>
					public const System.Int32 ColumnIndex = 62;

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
					/// Returns 63
					/// </summary>
					public const System.Int32 ColumnIndex = 63;

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
					/// Returns 64
					/// </summary>
					public const System.Int32 ColumnIndex = 64;

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
					/// Returns 65
					/// </summary>
					public const System.Int32 ColumnIndex = 65;

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
					/// Returns 66
					/// </summary>
					public const System.Int32 ColumnIndex = 66;

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
					/// Returns 67
					/// </summary>
					public const System.Int32 ColumnIndex = 67;

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
					/// Returns 68
					/// </summary>
					public const System.Int32 ColumnIndex = 68;

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
					/// Returns 69
					/// </summary>
					public const System.Int32 ColumnIndex = 69;

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
					/// Returns 70
					/// </summary>
					public const System.Int32 ColumnIndex = 70;

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
					/// Returns 71
					/// </summary>
					public const System.Int32 ColumnIndex = 71;

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
					/// Returns 72
					/// </summary>
					public const System.Int32 ColumnIndex = 72;

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
					/// Returns 73
					/// </summary>
					public const System.Int32 ColumnIndex = 73;

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
					/// Returns 74
					/// </summary>
					public const System.Int32 ColumnIndex = 74;

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
					/// Returns 75
					/// </summary>
					public const System.Int32 ColumnIndex = 75;

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
					/// Returns 76
					/// </summary>
					public const System.Int32 ColumnIndex = 76;

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
					/// Returns 77
					/// </summary>
					public const System.Int32 ColumnIndex = 77;

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
					/// Returns 78
					/// </summary>
					public const System.Int32 ColumnIndex = 78;

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
					/// Returns 79
					/// </summary>
					public const System.Int32 ColumnIndex = 79;

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
					/// Returns 80
					/// </summary>
					public const System.Int32 ColumnIndex = 80;

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
					/// Returns 81
					/// </summary>
					public const System.Int32 ColumnIndex = 81;

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
					/// Returns 82
					/// </summary>
					public const System.Int32 ColumnIndex = 82;

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
					/// Returns 83
					/// </summary>
					public const System.Int32 ColumnIndex = 83;

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
					/// Returns 84
					/// </summary>
					public const System.Int32 ColumnIndex = 84;

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
					/// Returns 85
					/// </summary>
					public const System.Int32 ColumnIndex = 85;

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
					/// Returns 86
					/// </summary>
					public const System.Int32 ColumnIndex = 86;

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
					/// Returns 87
					/// </summary>
					public const System.Int32 ColumnIndex = 87;

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
					/// Returns 88
					/// </summary>
					public const System.Int32 ColumnIndex = 88;

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
					/// Returns 89
					/// </summary>
					public const System.Int32 ColumnIndex = 89;

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
					/// Returns 90
					/// </summary>
					public const System.Int32 ColumnIndex = 90;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurDroitCoupeID_ID via shared members
				/// </summary>
				public sealed class Column_ProducteurDroitCoupeID_ID {

					/// <summary>
					/// Returns "ProducteurDroitCoupeID_ID"
					/// </summary>
					public const System.String ColumnName = "ProducteurDroitCoupeID_ID";
					/// <summary>
					/// Returns 91
					/// </summary>
					public const System.Int32 ColumnIndex = 91;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurDroitCoupeID_CleTri via shared members
				/// </summary>
				public sealed class Column_ProducteurDroitCoupeID_CleTri {

					/// <summary>
					/// Returns "ProducteurDroitCoupeID_CleTri"
					/// </summary>
					public const System.String ColumnName = "ProducteurDroitCoupeID_CleTri";
					/// <summary>
					/// Returns 92
					/// </summary>
					public const System.Int32 ColumnIndex = 92;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurDroitCoupeID_Nom via shared members
				/// </summary>
				public sealed class Column_ProducteurDroitCoupeID_Nom {

					/// <summary>
					/// Returns "ProducteurDroitCoupeID_Nom"
					/// </summary>
					public const System.String ColumnName = "ProducteurDroitCoupeID_Nom";
					/// <summary>
					/// Returns 93
					/// </summary>
					public const System.Int32 ColumnIndex = 93;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurDroitCoupeID_AuSoinsDe via shared members
				/// </summary>
				public sealed class Column_ProducteurDroitCoupeID_AuSoinsDe {

					/// <summary>
					/// Returns "ProducteurDroitCoupeID_AuSoinsDe"
					/// </summary>
					public const System.String ColumnName = "ProducteurDroitCoupeID_AuSoinsDe";
					/// <summary>
					/// Returns 94
					/// </summary>
					public const System.Int32 ColumnIndex = 94;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurDroitCoupeID_Rue via shared members
				/// </summary>
				public sealed class Column_ProducteurDroitCoupeID_Rue {

					/// <summary>
					/// Returns "ProducteurDroitCoupeID_Rue"
					/// </summary>
					public const System.String ColumnName = "ProducteurDroitCoupeID_Rue";
					/// <summary>
					/// Returns 95
					/// </summary>
					public const System.Int32 ColumnIndex = 95;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurDroitCoupeID_Ville via shared members
				/// </summary>
				public sealed class Column_ProducteurDroitCoupeID_Ville {

					/// <summary>
					/// Returns "ProducteurDroitCoupeID_Ville"
					/// </summary>
					public const System.String ColumnName = "ProducteurDroitCoupeID_Ville";
					/// <summary>
					/// Returns 96
					/// </summary>
					public const System.Int32 ColumnIndex = 96;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurDroitCoupeID_PaysID via shared members
				/// </summary>
				public sealed class Column_ProducteurDroitCoupeID_PaysID {

					/// <summary>
					/// Returns "ProducteurDroitCoupeID_PaysID"
					/// </summary>
					public const System.String ColumnName = "ProducteurDroitCoupeID_PaysID";
					/// <summary>
					/// Returns 97
					/// </summary>
					public const System.Int32 ColumnIndex = 97;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurDroitCoupeID_Code_postal via shared members
				/// </summary>
				public sealed class Column_ProducteurDroitCoupeID_Code_postal {

					/// <summary>
					/// Returns "ProducteurDroitCoupeID_Code_postal"
					/// </summary>
					public const System.String ColumnName = "ProducteurDroitCoupeID_Code_postal";
					/// <summary>
					/// Returns 98
					/// </summary>
					public const System.Int32 ColumnIndex = 98;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurDroitCoupeID_Telephone via shared members
				/// </summary>
				public sealed class Column_ProducteurDroitCoupeID_Telephone {

					/// <summary>
					/// Returns "ProducteurDroitCoupeID_Telephone"
					/// </summary>
					public const System.String ColumnName = "ProducteurDroitCoupeID_Telephone";
					/// <summary>
					/// Returns 99
					/// </summary>
					public const System.Int32 ColumnIndex = 99;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurDroitCoupeID_Telephone_Poste via shared members
				/// </summary>
				public sealed class Column_ProducteurDroitCoupeID_Telephone_Poste {

					/// <summary>
					/// Returns "ProducteurDroitCoupeID_Telephone_Poste"
					/// </summary>
					public const System.String ColumnName = "ProducteurDroitCoupeID_Telephone_Poste";
					/// <summary>
					/// Returns 100
					/// </summary>
					public const System.Int32 ColumnIndex = 100;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurDroitCoupeID_Telecopieur via shared members
				/// </summary>
				public sealed class Column_ProducteurDroitCoupeID_Telecopieur {

					/// <summary>
					/// Returns "ProducteurDroitCoupeID_Telecopieur"
					/// </summary>
					public const System.String ColumnName = "ProducteurDroitCoupeID_Telecopieur";
					/// <summary>
					/// Returns 101
					/// </summary>
					public const System.Int32 ColumnIndex = 101;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurDroitCoupeID_Telephone2 via shared members
				/// </summary>
				public sealed class Column_ProducteurDroitCoupeID_Telephone2 {

					/// <summary>
					/// Returns "ProducteurDroitCoupeID_Telephone2"
					/// </summary>
					public const System.String ColumnName = "ProducteurDroitCoupeID_Telephone2";
					/// <summary>
					/// Returns 102
					/// </summary>
					public const System.Int32 ColumnIndex = 102;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurDroitCoupeID_Telephone2_Desc via shared members
				/// </summary>
				public sealed class Column_ProducteurDroitCoupeID_Telephone2_Desc {

					/// <summary>
					/// Returns "ProducteurDroitCoupeID_Telephone2_Desc"
					/// </summary>
					public const System.String ColumnName = "ProducteurDroitCoupeID_Telephone2_Desc";
					/// <summary>
					/// Returns 103
					/// </summary>
					public const System.Int32 ColumnIndex = 103;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurDroitCoupeID_Telephone2_Poste via shared members
				/// </summary>
				public sealed class Column_ProducteurDroitCoupeID_Telephone2_Poste {

					/// <summary>
					/// Returns "ProducteurDroitCoupeID_Telephone2_Poste"
					/// </summary>
					public const System.String ColumnName = "ProducteurDroitCoupeID_Telephone2_Poste";
					/// <summary>
					/// Returns 104
					/// </summary>
					public const System.Int32 ColumnIndex = 104;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurDroitCoupeID_Telephone3 via shared members
				/// </summary>
				public sealed class Column_ProducteurDroitCoupeID_Telephone3 {

					/// <summary>
					/// Returns "ProducteurDroitCoupeID_Telephone3"
					/// </summary>
					public const System.String ColumnName = "ProducteurDroitCoupeID_Telephone3";
					/// <summary>
					/// Returns 105
					/// </summary>
					public const System.Int32 ColumnIndex = 105;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurDroitCoupeID_Telephone3_Desc via shared members
				/// </summary>
				public sealed class Column_ProducteurDroitCoupeID_Telephone3_Desc {

					/// <summary>
					/// Returns "ProducteurDroitCoupeID_Telephone3_Desc"
					/// </summary>
					public const System.String ColumnName = "ProducteurDroitCoupeID_Telephone3_Desc";
					/// <summary>
					/// Returns 106
					/// </summary>
					public const System.Int32 ColumnIndex = 106;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurDroitCoupeID_Telephone3_Poste via shared members
				/// </summary>
				public sealed class Column_ProducteurDroitCoupeID_Telephone3_Poste {

					/// <summary>
					/// Returns "ProducteurDroitCoupeID_Telephone3_Poste"
					/// </summary>
					public const System.String ColumnName = "ProducteurDroitCoupeID_Telephone3_Poste";
					/// <summary>
					/// Returns 107
					/// </summary>
					public const System.Int32 ColumnIndex = 107;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurDroitCoupeID_No_membre via shared members
				/// </summary>
				public sealed class Column_ProducteurDroitCoupeID_No_membre {

					/// <summary>
					/// Returns "ProducteurDroitCoupeID_No_membre"
					/// </summary>
					public const System.String ColumnName = "ProducteurDroitCoupeID_No_membre";
					/// <summary>
					/// Returns 108
					/// </summary>
					public const System.Int32 ColumnIndex = 108;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurDroitCoupeID_Resident via shared members
				/// </summary>
				public sealed class Column_ProducteurDroitCoupeID_Resident {

					/// <summary>
					/// Returns "ProducteurDroitCoupeID_Resident"
					/// </summary>
					public const System.String ColumnName = "ProducteurDroitCoupeID_Resident";
					/// <summary>
					/// Returns 109
					/// </summary>
					public const System.Int32 ColumnIndex = 109;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurDroitCoupeID_Email via shared members
				/// </summary>
				public sealed class Column_ProducteurDroitCoupeID_Email {

					/// <summary>
					/// Returns "ProducteurDroitCoupeID_Email"
					/// </summary>
					public const System.String ColumnName = "ProducteurDroitCoupeID_Email";
					/// <summary>
					/// Returns 110
					/// </summary>
					public const System.Int32 ColumnIndex = 110;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurDroitCoupeID_WWW via shared members
				/// </summary>
				public sealed class Column_ProducteurDroitCoupeID_WWW {

					/// <summary>
					/// Returns "ProducteurDroitCoupeID_WWW"
					/// </summary>
					public const System.String ColumnName = "ProducteurDroitCoupeID_WWW";
					/// <summary>
					/// Returns 111
					/// </summary>
					public const System.Int32 ColumnIndex = 111;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurDroitCoupeID_Commentaires via shared members
				/// </summary>
				public sealed class Column_ProducteurDroitCoupeID_Commentaires {

					/// <summary>
					/// Returns "ProducteurDroitCoupeID_Commentaires"
					/// </summary>
					public const System.String ColumnName = "ProducteurDroitCoupeID_Commentaires";
					/// <summary>
					/// Returns 112
					/// </summary>
					public const System.Int32 ColumnIndex = 112;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurDroitCoupeID_AfficherCommentaires via shared members
				/// </summary>
				public sealed class Column_ProducteurDroitCoupeID_AfficherCommentaires {

					/// <summary>
					/// Returns "ProducteurDroitCoupeID_AfficherCommentaires"
					/// </summary>
					public const System.String ColumnName = "ProducteurDroitCoupeID_AfficherCommentaires";
					/// <summary>
					/// Returns 113
					/// </summary>
					public const System.Int32 ColumnIndex = 113;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurDroitCoupeID_DepotDirect via shared members
				/// </summary>
				public sealed class Column_ProducteurDroitCoupeID_DepotDirect {

					/// <summary>
					/// Returns "ProducteurDroitCoupeID_DepotDirect"
					/// </summary>
					public const System.String ColumnName = "ProducteurDroitCoupeID_DepotDirect";
					/// <summary>
					/// Returns 114
					/// </summary>
					public const System.Int32 ColumnIndex = 114;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurDroitCoupeID_InstitutionBanquaireID via shared members
				/// </summary>
				public sealed class Column_ProducteurDroitCoupeID_InstitutionBanquaireID {

					/// <summary>
					/// Returns "ProducteurDroitCoupeID_InstitutionBanquaireID"
					/// </summary>
					public const System.String ColumnName = "ProducteurDroitCoupeID_InstitutionBanquaireID";
					/// <summary>
					/// Returns 115
					/// </summary>
					public const System.Int32 ColumnIndex = 115;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurDroitCoupeID_Banque_transit via shared members
				/// </summary>
				public sealed class Column_ProducteurDroitCoupeID_Banque_transit {

					/// <summary>
					/// Returns "ProducteurDroitCoupeID_Banque_transit"
					/// </summary>
					public const System.String ColumnName = "ProducteurDroitCoupeID_Banque_transit";
					/// <summary>
					/// Returns 116
					/// </summary>
					public const System.Int32 ColumnIndex = 116;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurDroitCoupeID_Banque_folio via shared members
				/// </summary>
				public sealed class Column_ProducteurDroitCoupeID_Banque_folio {

					/// <summary>
					/// Returns "ProducteurDroitCoupeID_Banque_folio"
					/// </summary>
					public const System.String ColumnName = "ProducteurDroitCoupeID_Banque_folio";
					/// <summary>
					/// Returns 117
					/// </summary>
					public const System.Int32 ColumnIndex = 117;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurDroitCoupeID_No_TPS via shared members
				/// </summary>
				public sealed class Column_ProducteurDroitCoupeID_No_TPS {

					/// <summary>
					/// Returns "ProducteurDroitCoupeID_No_TPS"
					/// </summary>
					public const System.String ColumnName = "ProducteurDroitCoupeID_No_TPS";
					/// <summary>
					/// Returns 118
					/// </summary>
					public const System.Int32 ColumnIndex = 118;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurDroitCoupeID_No_TVQ via shared members
				/// </summary>
				public sealed class Column_ProducteurDroitCoupeID_No_TVQ {

					/// <summary>
					/// Returns "ProducteurDroitCoupeID_No_TVQ"
					/// </summary>
					public const System.String ColumnName = "ProducteurDroitCoupeID_No_TVQ";
					/// <summary>
					/// Returns 119
					/// </summary>
					public const System.Int32 ColumnIndex = 119;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurDroitCoupeID_PayerA via shared members
				/// </summary>
				public sealed class Column_ProducteurDroitCoupeID_PayerA {

					/// <summary>
					/// Returns "ProducteurDroitCoupeID_PayerA"
					/// </summary>
					public const System.String ColumnName = "ProducteurDroitCoupeID_PayerA";
					/// <summary>
					/// Returns 120
					/// </summary>
					public const System.Int32 ColumnIndex = 120;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurDroitCoupeID_PayerAID via shared members
				/// </summary>
				public sealed class Column_ProducteurDroitCoupeID_PayerAID {

					/// <summary>
					/// Returns "ProducteurDroitCoupeID_PayerAID"
					/// </summary>
					public const System.String ColumnName = "ProducteurDroitCoupeID_PayerAID";
					/// <summary>
					/// Returns 121
					/// </summary>
					public const System.Int32 ColumnIndex = 121;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurDroitCoupeID_Statut via shared members
				/// </summary>
				public sealed class Column_ProducteurDroitCoupeID_Statut {

					/// <summary>
					/// Returns "ProducteurDroitCoupeID_Statut"
					/// </summary>
					public const System.String ColumnName = "ProducteurDroitCoupeID_Statut";
					/// <summary>
					/// Returns 122
					/// </summary>
					public const System.Int32 ColumnIndex = 122;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurDroitCoupeID_Rep_Nom via shared members
				/// </summary>
				public sealed class Column_ProducteurDroitCoupeID_Rep_Nom {

					/// <summary>
					/// Returns "ProducteurDroitCoupeID_Rep_Nom"
					/// </summary>
					public const System.String ColumnName = "ProducteurDroitCoupeID_Rep_Nom";
					/// <summary>
					/// Returns 123
					/// </summary>
					public const System.Int32 ColumnIndex = 123;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurDroitCoupeID_Rep_Telephone via shared members
				/// </summary>
				public sealed class Column_ProducteurDroitCoupeID_Rep_Telephone {

					/// <summary>
					/// Returns "ProducteurDroitCoupeID_Rep_Telephone"
					/// </summary>
					public const System.String ColumnName = "ProducteurDroitCoupeID_Rep_Telephone";
					/// <summary>
					/// Returns 124
					/// </summary>
					public const System.Int32 ColumnIndex = 124;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurDroitCoupeID_Rep_Telephone_Poste via shared members
				/// </summary>
				public sealed class Column_ProducteurDroitCoupeID_Rep_Telephone_Poste {

					/// <summary>
					/// Returns "ProducteurDroitCoupeID_Rep_Telephone_Poste"
					/// </summary>
					public const System.String ColumnName = "ProducteurDroitCoupeID_Rep_Telephone_Poste";
					/// <summary>
					/// Returns 125
					/// </summary>
					public const System.Int32 ColumnIndex = 125;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurDroitCoupeID_Rep_Email via shared members
				/// </summary>
				public sealed class Column_ProducteurDroitCoupeID_Rep_Email {

					/// <summary>
					/// Returns "ProducteurDroitCoupeID_Rep_Email"
					/// </summary>
					public const System.String ColumnName = "ProducteurDroitCoupeID_Rep_Email";
					/// <summary>
					/// Returns 126
					/// </summary>
					public const System.Int32 ColumnIndex = 126;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurDroitCoupeID_EnAnglais via shared members
				/// </summary>
				public sealed class Column_ProducteurDroitCoupeID_EnAnglais {

					/// <summary>
					/// Returns "ProducteurDroitCoupeID_EnAnglais"
					/// </summary>
					public const System.String ColumnName = "ProducteurDroitCoupeID_EnAnglais";
					/// <summary>
					/// Returns 127
					/// </summary>
					public const System.Int32 ColumnIndex = 127;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurDroitCoupeID_Actif via shared members
				/// </summary>
				public sealed class Column_ProducteurDroitCoupeID_Actif {

					/// <summary>
					/// Returns "ProducteurDroitCoupeID_Actif"
					/// </summary>
					public const System.String ColumnName = "ProducteurDroitCoupeID_Actif";
					/// <summary>
					/// Returns 128
					/// </summary>
					public const System.Int32 ColumnIndex = 128;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurDroitCoupeID_MRCProducteurID via shared members
				/// </summary>
				public sealed class Column_ProducteurDroitCoupeID_MRCProducteurID {

					/// <summary>
					/// Returns "ProducteurDroitCoupeID_MRCProducteurID"
					/// </summary>
					public const System.String ColumnName = "ProducteurDroitCoupeID_MRCProducteurID";
					/// <summary>
					/// Returns 129
					/// </summary>
					public const System.Int32 ColumnIndex = 129;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurDroitCoupeID_PaiementManuel via shared members
				/// </summary>
				public sealed class Column_ProducteurDroitCoupeID_PaiementManuel {

					/// <summary>
					/// Returns "ProducteurDroitCoupeID_PaiementManuel"
					/// </summary>
					public const System.String ColumnName = "ProducteurDroitCoupeID_PaiementManuel";
					/// <summary>
					/// Returns 130
					/// </summary>
					public const System.Int32 ColumnIndex = 130;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurDroitCoupeID_Journal via shared members
				/// </summary>
				public sealed class Column_ProducteurDroitCoupeID_Journal {

					/// <summary>
					/// Returns "ProducteurDroitCoupeID_Journal"
					/// </summary>
					public const System.String ColumnName = "ProducteurDroitCoupeID_Journal";
					/// <summary>
					/// Returns 131
					/// </summary>
					public const System.Int32 ColumnIndex = 131;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurDroitCoupeID_RecoitTPS via shared members
				/// </summary>
				public sealed class Column_ProducteurDroitCoupeID_RecoitTPS {

					/// <summary>
					/// Returns "ProducteurDroitCoupeID_RecoitTPS"
					/// </summary>
					public const System.String ColumnName = "ProducteurDroitCoupeID_RecoitTPS";
					/// <summary>
					/// Returns 132
					/// </summary>
					public const System.Int32 ColumnIndex = 132;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurDroitCoupeID_RecoitTVQ via shared members
				/// </summary>
				public sealed class Column_ProducteurDroitCoupeID_RecoitTVQ {

					/// <summary>
					/// Returns "ProducteurDroitCoupeID_RecoitTVQ"
					/// </summary>
					public const System.String ColumnName = "ProducteurDroitCoupeID_RecoitTVQ";
					/// <summary>
					/// Returns 133
					/// </summary>
					public const System.Int32 ColumnIndex = 133;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurDroitCoupeID_ModifierTrigger via shared members
				/// </summary>
				public sealed class Column_ProducteurDroitCoupeID_ModifierTrigger {

					/// <summary>
					/// Returns "ProducteurDroitCoupeID_ModifierTrigger"
					/// </summary>
					public const System.String ColumnName = "ProducteurDroitCoupeID_ModifierTrigger";
					/// <summary>
					/// Returns 134
					/// </summary>
					public const System.Int32 ColumnIndex = 134;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurDroitCoupeID_IsProducteur via shared members
				/// </summary>
				public sealed class Column_ProducteurDroitCoupeID_IsProducteur {

					/// <summary>
					/// Returns "ProducteurDroitCoupeID_IsProducteur"
					/// </summary>
					public const System.String ColumnName = "ProducteurDroitCoupeID_IsProducteur";
					/// <summary>
					/// Returns 135
					/// </summary>
					public const System.Int32 ColumnIndex = 135;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurDroitCoupeID_IsTransporteur via shared members
				/// </summary>
				public sealed class Column_ProducteurDroitCoupeID_IsTransporteur {

					/// <summary>
					/// Returns "ProducteurDroitCoupeID_IsTransporteur"
					/// </summary>
					public const System.String ColumnName = "ProducteurDroitCoupeID_IsTransporteur";
					/// <summary>
					/// Returns 136
					/// </summary>
					public const System.Int32 ColumnIndex = 136;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurDroitCoupeID_IsChargeur via shared members
				/// </summary>
				public sealed class Column_ProducteurDroitCoupeID_IsChargeur {

					/// <summary>
					/// Returns "ProducteurDroitCoupeID_IsChargeur"
					/// </summary>
					public const System.String ColumnName = "ProducteurDroitCoupeID_IsChargeur";
					/// <summary>
					/// Returns 137
					/// </summary>
					public const System.Int32 ColumnIndex = 137;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurDroitCoupeID_IsAutre via shared members
				/// </summary>
				public sealed class Column_ProducteurDroitCoupeID_IsAutre {

					/// <summary>
					/// Returns "ProducteurDroitCoupeID_IsAutre"
					/// </summary>
					public const System.String ColumnName = "ProducteurDroitCoupeID_IsAutre";
					/// <summary>
					/// Returns 138
					/// </summary>
					public const System.Int32 ColumnIndex = 138;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurDroitCoupeID_AfficherCommentairesSurPermit via shared members
				/// </summary>
				public sealed class Column_ProducteurDroitCoupeID_AfficherCommentairesSurPermit {

					/// <summary>
					/// Returns "ProducteurDroitCoupeID_AfficherCommentairesSurPermit"
					/// </summary>
					public const System.String ColumnName = "ProducteurDroitCoupeID_AfficherCommentairesSurPermit";
					/// <summary>
					/// Returns 139
					/// </summary>
					public const System.Int32 ColumnIndex = 139;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurDroitCoupeID_PasEmissionPermis via shared members
				/// </summary>
				public sealed class Column_ProducteurDroitCoupeID_PasEmissionPermis {

					/// <summary>
					/// Returns "ProducteurDroitCoupeID_PasEmissionPermis"
					/// </summary>
					public const System.String ColumnName = "ProducteurDroitCoupeID_PasEmissionPermis";
					/// <summary>
					/// Returns 140
					/// </summary>
					public const System.Int32 ColumnIndex = 140;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurDroitCoupeID_Generique via shared members
				/// </summary>
				public sealed class Column_ProducteurDroitCoupeID_Generique {

					/// <summary>
					/// Returns "ProducteurDroitCoupeID_Generique"
					/// </summary>
					public const System.String ColumnName = "ProducteurDroitCoupeID_Generique";
					/// <summary>
					/// Returns 141
					/// </summary>
					public const System.Int32 ColumnIndex = 141;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurEntentePaiementID_ID via shared members
				/// </summary>
				public sealed class Column_ProducteurEntentePaiementID_ID {

					/// <summary>
					/// Returns "ProducteurEntentePaiementID_ID"
					/// </summary>
					public const System.String ColumnName = "ProducteurEntentePaiementID_ID";
					/// <summary>
					/// Returns 142
					/// </summary>
					public const System.Int32 ColumnIndex = 142;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurEntentePaiementID_CleTri via shared members
				/// </summary>
				public sealed class Column_ProducteurEntentePaiementID_CleTri {

					/// <summary>
					/// Returns "ProducteurEntentePaiementID_CleTri"
					/// </summary>
					public const System.String ColumnName = "ProducteurEntentePaiementID_CleTri";
					/// <summary>
					/// Returns 143
					/// </summary>
					public const System.Int32 ColumnIndex = 143;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurEntentePaiementID_Nom via shared members
				/// </summary>
				public sealed class Column_ProducteurEntentePaiementID_Nom {

					/// <summary>
					/// Returns "ProducteurEntentePaiementID_Nom"
					/// </summary>
					public const System.String ColumnName = "ProducteurEntentePaiementID_Nom";
					/// <summary>
					/// Returns 144
					/// </summary>
					public const System.Int32 ColumnIndex = 144;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurEntentePaiementID_AuSoinsDe via shared members
				/// </summary>
				public sealed class Column_ProducteurEntentePaiementID_AuSoinsDe {

					/// <summary>
					/// Returns "ProducteurEntentePaiementID_AuSoinsDe"
					/// </summary>
					public const System.String ColumnName = "ProducteurEntentePaiementID_AuSoinsDe";
					/// <summary>
					/// Returns 145
					/// </summary>
					public const System.Int32 ColumnIndex = 145;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurEntentePaiementID_Rue via shared members
				/// </summary>
				public sealed class Column_ProducteurEntentePaiementID_Rue {

					/// <summary>
					/// Returns "ProducteurEntentePaiementID_Rue"
					/// </summary>
					public const System.String ColumnName = "ProducteurEntentePaiementID_Rue";
					/// <summary>
					/// Returns 146
					/// </summary>
					public const System.Int32 ColumnIndex = 146;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurEntentePaiementID_Ville via shared members
				/// </summary>
				public sealed class Column_ProducteurEntentePaiementID_Ville {

					/// <summary>
					/// Returns "ProducteurEntentePaiementID_Ville"
					/// </summary>
					public const System.String ColumnName = "ProducteurEntentePaiementID_Ville";
					/// <summary>
					/// Returns 147
					/// </summary>
					public const System.Int32 ColumnIndex = 147;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurEntentePaiementID_PaysID via shared members
				/// </summary>
				public sealed class Column_ProducteurEntentePaiementID_PaysID {

					/// <summary>
					/// Returns "ProducteurEntentePaiementID_PaysID"
					/// </summary>
					public const System.String ColumnName = "ProducteurEntentePaiementID_PaysID";
					/// <summary>
					/// Returns 148
					/// </summary>
					public const System.Int32 ColumnIndex = 148;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurEntentePaiementID_Code_postal via shared members
				/// </summary>
				public sealed class Column_ProducteurEntentePaiementID_Code_postal {

					/// <summary>
					/// Returns "ProducteurEntentePaiementID_Code_postal"
					/// </summary>
					public const System.String ColumnName = "ProducteurEntentePaiementID_Code_postal";
					/// <summary>
					/// Returns 149
					/// </summary>
					public const System.Int32 ColumnIndex = 149;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurEntentePaiementID_Telephone via shared members
				/// </summary>
				public sealed class Column_ProducteurEntentePaiementID_Telephone {

					/// <summary>
					/// Returns "ProducteurEntentePaiementID_Telephone"
					/// </summary>
					public const System.String ColumnName = "ProducteurEntentePaiementID_Telephone";
					/// <summary>
					/// Returns 150
					/// </summary>
					public const System.Int32 ColumnIndex = 150;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurEntentePaiementID_Telephone_Poste via shared members
				/// </summary>
				public sealed class Column_ProducteurEntentePaiementID_Telephone_Poste {

					/// <summary>
					/// Returns "ProducteurEntentePaiementID_Telephone_Poste"
					/// </summary>
					public const System.String ColumnName = "ProducteurEntentePaiementID_Telephone_Poste";
					/// <summary>
					/// Returns 151
					/// </summary>
					public const System.Int32 ColumnIndex = 151;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurEntentePaiementID_Telecopieur via shared members
				/// </summary>
				public sealed class Column_ProducteurEntentePaiementID_Telecopieur {

					/// <summary>
					/// Returns "ProducteurEntentePaiementID_Telecopieur"
					/// </summary>
					public const System.String ColumnName = "ProducteurEntentePaiementID_Telecopieur";
					/// <summary>
					/// Returns 152
					/// </summary>
					public const System.Int32 ColumnIndex = 152;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurEntentePaiementID_Telephone2 via shared members
				/// </summary>
				public sealed class Column_ProducteurEntentePaiementID_Telephone2 {

					/// <summary>
					/// Returns "ProducteurEntentePaiementID_Telephone2"
					/// </summary>
					public const System.String ColumnName = "ProducteurEntentePaiementID_Telephone2";
					/// <summary>
					/// Returns 153
					/// </summary>
					public const System.Int32 ColumnIndex = 153;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurEntentePaiementID_Telephone2_Desc via shared members
				/// </summary>
				public sealed class Column_ProducteurEntentePaiementID_Telephone2_Desc {

					/// <summary>
					/// Returns "ProducteurEntentePaiementID_Telephone2_Desc"
					/// </summary>
					public const System.String ColumnName = "ProducteurEntentePaiementID_Telephone2_Desc";
					/// <summary>
					/// Returns 154
					/// </summary>
					public const System.Int32 ColumnIndex = 154;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurEntentePaiementID_Telephone2_Poste via shared members
				/// </summary>
				public sealed class Column_ProducteurEntentePaiementID_Telephone2_Poste {

					/// <summary>
					/// Returns "ProducteurEntentePaiementID_Telephone2_Poste"
					/// </summary>
					public const System.String ColumnName = "ProducteurEntentePaiementID_Telephone2_Poste";
					/// <summary>
					/// Returns 155
					/// </summary>
					public const System.Int32 ColumnIndex = 155;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurEntentePaiementID_Telephone3 via shared members
				/// </summary>
				public sealed class Column_ProducteurEntentePaiementID_Telephone3 {

					/// <summary>
					/// Returns "ProducteurEntentePaiementID_Telephone3"
					/// </summary>
					public const System.String ColumnName = "ProducteurEntentePaiementID_Telephone3";
					/// <summary>
					/// Returns 156
					/// </summary>
					public const System.Int32 ColumnIndex = 156;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurEntentePaiementID_Telephone3_Desc via shared members
				/// </summary>
				public sealed class Column_ProducteurEntentePaiementID_Telephone3_Desc {

					/// <summary>
					/// Returns "ProducteurEntentePaiementID_Telephone3_Desc"
					/// </summary>
					public const System.String ColumnName = "ProducteurEntentePaiementID_Telephone3_Desc";
					/// <summary>
					/// Returns 157
					/// </summary>
					public const System.Int32 ColumnIndex = 157;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurEntentePaiementID_Telephone3_Poste via shared members
				/// </summary>
				public sealed class Column_ProducteurEntentePaiementID_Telephone3_Poste {

					/// <summary>
					/// Returns "ProducteurEntentePaiementID_Telephone3_Poste"
					/// </summary>
					public const System.String ColumnName = "ProducteurEntentePaiementID_Telephone3_Poste";
					/// <summary>
					/// Returns 158
					/// </summary>
					public const System.Int32 ColumnIndex = 158;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurEntentePaiementID_No_membre via shared members
				/// </summary>
				public sealed class Column_ProducteurEntentePaiementID_No_membre {

					/// <summary>
					/// Returns "ProducteurEntentePaiementID_No_membre"
					/// </summary>
					public const System.String ColumnName = "ProducteurEntentePaiementID_No_membre";
					/// <summary>
					/// Returns 159
					/// </summary>
					public const System.Int32 ColumnIndex = 159;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurEntentePaiementID_Resident via shared members
				/// </summary>
				public sealed class Column_ProducteurEntentePaiementID_Resident {

					/// <summary>
					/// Returns "ProducteurEntentePaiementID_Resident"
					/// </summary>
					public const System.String ColumnName = "ProducteurEntentePaiementID_Resident";
					/// <summary>
					/// Returns 160
					/// </summary>
					public const System.Int32 ColumnIndex = 160;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurEntentePaiementID_Email via shared members
				/// </summary>
				public sealed class Column_ProducteurEntentePaiementID_Email {

					/// <summary>
					/// Returns "ProducteurEntentePaiementID_Email"
					/// </summary>
					public const System.String ColumnName = "ProducteurEntentePaiementID_Email";
					/// <summary>
					/// Returns 161
					/// </summary>
					public const System.Int32 ColumnIndex = 161;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurEntentePaiementID_WWW via shared members
				/// </summary>
				public sealed class Column_ProducteurEntentePaiementID_WWW {

					/// <summary>
					/// Returns "ProducteurEntentePaiementID_WWW"
					/// </summary>
					public const System.String ColumnName = "ProducteurEntentePaiementID_WWW";
					/// <summary>
					/// Returns 162
					/// </summary>
					public const System.Int32 ColumnIndex = 162;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurEntentePaiementID_Commentaires via shared members
				/// </summary>
				public sealed class Column_ProducteurEntentePaiementID_Commentaires {

					/// <summary>
					/// Returns "ProducteurEntentePaiementID_Commentaires"
					/// </summary>
					public const System.String ColumnName = "ProducteurEntentePaiementID_Commentaires";
					/// <summary>
					/// Returns 163
					/// </summary>
					public const System.Int32 ColumnIndex = 163;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurEntentePaiementID_AfficherCommentaires via shared members
				/// </summary>
				public sealed class Column_ProducteurEntentePaiementID_AfficherCommentaires {

					/// <summary>
					/// Returns "ProducteurEntentePaiementID_AfficherCommentaires"
					/// </summary>
					public const System.String ColumnName = "ProducteurEntentePaiementID_AfficherCommentaires";
					/// <summary>
					/// Returns 164
					/// </summary>
					public const System.Int32 ColumnIndex = 164;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurEntentePaiementID_DepotDirect via shared members
				/// </summary>
				public sealed class Column_ProducteurEntentePaiementID_DepotDirect {

					/// <summary>
					/// Returns "ProducteurEntentePaiementID_DepotDirect"
					/// </summary>
					public const System.String ColumnName = "ProducteurEntentePaiementID_DepotDirect";
					/// <summary>
					/// Returns 165
					/// </summary>
					public const System.Int32 ColumnIndex = 165;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurEntentePaiementID_InstitutionBanquaireID via shared members
				/// </summary>
				public sealed class Column_ProducteurEntentePaiementID_InstitutionBanquaireID {

					/// <summary>
					/// Returns "ProducteurEntentePaiementID_InstitutionBanquaireID"
					/// </summary>
					public const System.String ColumnName = "ProducteurEntentePaiementID_InstitutionBanquaireID";
					/// <summary>
					/// Returns 166
					/// </summary>
					public const System.Int32 ColumnIndex = 166;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurEntentePaiementID_Banque_transit via shared members
				/// </summary>
				public sealed class Column_ProducteurEntentePaiementID_Banque_transit {

					/// <summary>
					/// Returns "ProducteurEntentePaiementID_Banque_transit"
					/// </summary>
					public const System.String ColumnName = "ProducteurEntentePaiementID_Banque_transit";
					/// <summary>
					/// Returns 167
					/// </summary>
					public const System.Int32 ColumnIndex = 167;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurEntentePaiementID_Banque_folio via shared members
				/// </summary>
				public sealed class Column_ProducteurEntentePaiementID_Banque_folio {

					/// <summary>
					/// Returns "ProducteurEntentePaiementID_Banque_folio"
					/// </summary>
					public const System.String ColumnName = "ProducteurEntentePaiementID_Banque_folio";
					/// <summary>
					/// Returns 168
					/// </summary>
					public const System.Int32 ColumnIndex = 168;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurEntentePaiementID_No_TPS via shared members
				/// </summary>
				public sealed class Column_ProducteurEntentePaiementID_No_TPS {

					/// <summary>
					/// Returns "ProducteurEntentePaiementID_No_TPS"
					/// </summary>
					public const System.String ColumnName = "ProducteurEntentePaiementID_No_TPS";
					/// <summary>
					/// Returns 169
					/// </summary>
					public const System.Int32 ColumnIndex = 169;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurEntentePaiementID_No_TVQ via shared members
				/// </summary>
				public sealed class Column_ProducteurEntentePaiementID_No_TVQ {

					/// <summary>
					/// Returns "ProducteurEntentePaiementID_No_TVQ"
					/// </summary>
					public const System.String ColumnName = "ProducteurEntentePaiementID_No_TVQ";
					/// <summary>
					/// Returns 170
					/// </summary>
					public const System.Int32 ColumnIndex = 170;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurEntentePaiementID_PayerA via shared members
				/// </summary>
				public sealed class Column_ProducteurEntentePaiementID_PayerA {

					/// <summary>
					/// Returns "ProducteurEntentePaiementID_PayerA"
					/// </summary>
					public const System.String ColumnName = "ProducteurEntentePaiementID_PayerA";
					/// <summary>
					/// Returns 171
					/// </summary>
					public const System.Int32 ColumnIndex = 171;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurEntentePaiementID_PayerAID via shared members
				/// </summary>
				public sealed class Column_ProducteurEntentePaiementID_PayerAID {

					/// <summary>
					/// Returns "ProducteurEntentePaiementID_PayerAID"
					/// </summary>
					public const System.String ColumnName = "ProducteurEntentePaiementID_PayerAID";
					/// <summary>
					/// Returns 172
					/// </summary>
					public const System.Int32 ColumnIndex = 172;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurEntentePaiementID_Statut via shared members
				/// </summary>
				public sealed class Column_ProducteurEntentePaiementID_Statut {

					/// <summary>
					/// Returns "ProducteurEntentePaiementID_Statut"
					/// </summary>
					public const System.String ColumnName = "ProducteurEntentePaiementID_Statut";
					/// <summary>
					/// Returns 173
					/// </summary>
					public const System.Int32 ColumnIndex = 173;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurEntentePaiementID_Rep_Nom via shared members
				/// </summary>
				public sealed class Column_ProducteurEntentePaiementID_Rep_Nom {

					/// <summary>
					/// Returns "ProducteurEntentePaiementID_Rep_Nom"
					/// </summary>
					public const System.String ColumnName = "ProducteurEntentePaiementID_Rep_Nom";
					/// <summary>
					/// Returns 174
					/// </summary>
					public const System.Int32 ColumnIndex = 174;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurEntentePaiementID_Rep_Telephone via shared members
				/// </summary>
				public sealed class Column_ProducteurEntentePaiementID_Rep_Telephone {

					/// <summary>
					/// Returns "ProducteurEntentePaiementID_Rep_Telephone"
					/// </summary>
					public const System.String ColumnName = "ProducteurEntentePaiementID_Rep_Telephone";
					/// <summary>
					/// Returns 175
					/// </summary>
					public const System.Int32 ColumnIndex = 175;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurEntentePaiementID_Rep_Telephone_Poste via shared members
				/// </summary>
				public sealed class Column_ProducteurEntentePaiementID_Rep_Telephone_Poste {

					/// <summary>
					/// Returns "ProducteurEntentePaiementID_Rep_Telephone_Poste"
					/// </summary>
					public const System.String ColumnName = "ProducteurEntentePaiementID_Rep_Telephone_Poste";
					/// <summary>
					/// Returns 176
					/// </summary>
					public const System.Int32 ColumnIndex = 176;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurEntentePaiementID_Rep_Email via shared members
				/// </summary>
				public sealed class Column_ProducteurEntentePaiementID_Rep_Email {

					/// <summary>
					/// Returns "ProducteurEntentePaiementID_Rep_Email"
					/// </summary>
					public const System.String ColumnName = "ProducteurEntentePaiementID_Rep_Email";
					/// <summary>
					/// Returns 177
					/// </summary>
					public const System.Int32 ColumnIndex = 177;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurEntentePaiementID_EnAnglais via shared members
				/// </summary>
				public sealed class Column_ProducteurEntentePaiementID_EnAnglais {

					/// <summary>
					/// Returns "ProducteurEntentePaiementID_EnAnglais"
					/// </summary>
					public const System.String ColumnName = "ProducteurEntentePaiementID_EnAnglais";
					/// <summary>
					/// Returns 178
					/// </summary>
					public const System.Int32 ColumnIndex = 178;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurEntentePaiementID_Actif via shared members
				/// </summary>
				public sealed class Column_ProducteurEntentePaiementID_Actif {

					/// <summary>
					/// Returns "ProducteurEntentePaiementID_Actif"
					/// </summary>
					public const System.String ColumnName = "ProducteurEntentePaiementID_Actif";
					/// <summary>
					/// Returns 179
					/// </summary>
					public const System.Int32 ColumnIndex = 179;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurEntentePaiementID_MRCProducteurID via shared members
				/// </summary>
				public sealed class Column_ProducteurEntentePaiementID_MRCProducteurID {

					/// <summary>
					/// Returns "ProducteurEntentePaiementID_MRCProducteurID"
					/// </summary>
					public const System.String ColumnName = "ProducteurEntentePaiementID_MRCProducteurID";
					/// <summary>
					/// Returns 180
					/// </summary>
					public const System.Int32 ColumnIndex = 180;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurEntentePaiementID_PaiementManuel via shared members
				/// </summary>
				public sealed class Column_ProducteurEntentePaiementID_PaiementManuel {

					/// <summary>
					/// Returns "ProducteurEntentePaiementID_PaiementManuel"
					/// </summary>
					public const System.String ColumnName = "ProducteurEntentePaiementID_PaiementManuel";
					/// <summary>
					/// Returns 181
					/// </summary>
					public const System.Int32 ColumnIndex = 181;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurEntentePaiementID_Journal via shared members
				/// </summary>
				public sealed class Column_ProducteurEntentePaiementID_Journal {

					/// <summary>
					/// Returns "ProducteurEntentePaiementID_Journal"
					/// </summary>
					public const System.String ColumnName = "ProducteurEntentePaiementID_Journal";
					/// <summary>
					/// Returns 182
					/// </summary>
					public const System.Int32 ColumnIndex = 182;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurEntentePaiementID_RecoitTPS via shared members
				/// </summary>
				public sealed class Column_ProducteurEntentePaiementID_RecoitTPS {

					/// <summary>
					/// Returns "ProducteurEntentePaiementID_RecoitTPS"
					/// </summary>
					public const System.String ColumnName = "ProducteurEntentePaiementID_RecoitTPS";
					/// <summary>
					/// Returns 183
					/// </summary>
					public const System.Int32 ColumnIndex = 183;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurEntentePaiementID_RecoitTVQ via shared members
				/// </summary>
				public sealed class Column_ProducteurEntentePaiementID_RecoitTVQ {

					/// <summary>
					/// Returns "ProducteurEntentePaiementID_RecoitTVQ"
					/// </summary>
					public const System.String ColumnName = "ProducteurEntentePaiementID_RecoitTVQ";
					/// <summary>
					/// Returns 184
					/// </summary>
					public const System.Int32 ColumnIndex = 184;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurEntentePaiementID_ModifierTrigger via shared members
				/// </summary>
				public sealed class Column_ProducteurEntentePaiementID_ModifierTrigger {

					/// <summary>
					/// Returns "ProducteurEntentePaiementID_ModifierTrigger"
					/// </summary>
					public const System.String ColumnName = "ProducteurEntentePaiementID_ModifierTrigger";
					/// <summary>
					/// Returns 185
					/// </summary>
					public const System.Int32 ColumnIndex = 185;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurEntentePaiementID_IsProducteur via shared members
				/// </summary>
				public sealed class Column_ProducteurEntentePaiementID_IsProducteur {

					/// <summary>
					/// Returns "ProducteurEntentePaiementID_IsProducteur"
					/// </summary>
					public const System.String ColumnName = "ProducteurEntentePaiementID_IsProducteur";
					/// <summary>
					/// Returns 186
					/// </summary>
					public const System.Int32 ColumnIndex = 186;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurEntentePaiementID_IsTransporteur via shared members
				/// </summary>
				public sealed class Column_ProducteurEntentePaiementID_IsTransporteur {

					/// <summary>
					/// Returns "ProducteurEntentePaiementID_IsTransporteur"
					/// </summary>
					public const System.String ColumnName = "ProducteurEntentePaiementID_IsTransporteur";
					/// <summary>
					/// Returns 187
					/// </summary>
					public const System.Int32 ColumnIndex = 187;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurEntentePaiementID_IsChargeur via shared members
				/// </summary>
				public sealed class Column_ProducteurEntentePaiementID_IsChargeur {

					/// <summary>
					/// Returns "ProducteurEntentePaiementID_IsChargeur"
					/// </summary>
					public const System.String ColumnName = "ProducteurEntentePaiementID_IsChargeur";
					/// <summary>
					/// Returns 188
					/// </summary>
					public const System.Int32 ColumnIndex = 188;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurEntentePaiementID_IsAutre via shared members
				/// </summary>
				public sealed class Column_ProducteurEntentePaiementID_IsAutre {

					/// <summary>
					/// Returns "ProducteurEntentePaiementID_IsAutre"
					/// </summary>
					public const System.String ColumnName = "ProducteurEntentePaiementID_IsAutre";
					/// <summary>
					/// Returns 189
					/// </summary>
					public const System.Int32 ColumnIndex = 189;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurEntentePaiementID_AfficherCommentairesSurPermit via shared members
				/// </summary>
				public sealed class Column_ProducteurEntentePaiementID_AfficherCommentairesSurPermit {

					/// <summary>
					/// Returns "ProducteurEntentePaiementID_AfficherCommentairesSurPermit"
					/// </summary>
					public const System.String ColumnName = "ProducteurEntentePaiementID_AfficherCommentairesSurPermit";
					/// <summary>
					/// Returns 190
					/// </summary>
					public const System.Int32 ColumnIndex = 190;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurEntentePaiementID_PasEmissionPermis via shared members
				/// </summary>
				public sealed class Column_ProducteurEntentePaiementID_PasEmissionPermis {

					/// <summary>
					/// Returns "ProducteurEntentePaiementID_PasEmissionPermis"
					/// </summary>
					public const System.String ColumnName = "ProducteurEntentePaiementID_PasEmissionPermis";
					/// <summary>
					/// Returns 191
					/// </summary>
					public const System.Int32 ColumnIndex = 191;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurEntentePaiementID_Generique via shared members
				/// </summary>
				public sealed class Column_ProducteurEntentePaiementID_Generique {

					/// <summary>
					/// Returns "ProducteurEntentePaiementID_Generique"
					/// </summary>
					public const System.String ColumnName = "ProducteurEntentePaiementID_Generique";
					/// <summary>
					/// Returns 192
					/// </summary>
					public const System.Int32 ColumnIndex = 192;

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
					/// Returns 193
					/// </summary>
					public const System.Int32 ColumnIndex = 193;

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
					/// Returns 194
					/// </summary>
					public const System.Int32 ColumnIndex = 194;

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
					/// Returns 195
					/// </summary>
					public const System.Int32 ColumnIndex = 195;

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
					/// Returns 196
					/// </summary>
					public const System.Int32 ColumnIndex = 196;

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
					/// Returns 197
					/// </summary>
					public const System.Int32 ColumnIndex = 197;

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
					/// Returns 198
					/// </summary>
					public const System.Int32 ColumnIndex = 198;

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
					/// Returns 199
					/// </summary>
					public const System.Int32 ColumnIndex = 199;

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
					/// Returns 200
					/// </summary>
					public const System.Int32 ColumnIndex = 200;

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
					/// Returns 201
					/// </summary>
					public const System.Int32 ColumnIndex = 201;

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
					/// Returns 202
					/// </summary>
					public const System.Int32 ColumnIndex = 202;

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
					/// Returns 203
					/// </summary>
					public const System.Int32 ColumnIndex = 203;

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
					/// Returns 204
					/// </summary>
					public const System.Int32 ColumnIndex = 204;

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
					/// Returns 205
					/// </summary>
					public const System.Int32 ColumnIndex = 205;

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
					/// Returns 206
					/// </summary>
					public const System.Int32 ColumnIndex = 206;

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
					/// Returns 207
					/// </summary>
					public const System.Int32 ColumnIndex = 207;

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
					/// Returns 208
					/// </summary>
					public const System.Int32 ColumnIndex = 208;

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
					/// Returns 209
					/// </summary>
					public const System.Int32 ColumnIndex = 209;

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
					/// Returns 210
					/// </summary>
					public const System.Int32 ColumnIndex = 210;

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
					/// Returns 211
					/// </summary>
					public const System.Int32 ColumnIndex = 211;

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
					/// Returns 212
					/// </summary>
					public const System.Int32 ColumnIndex = 212;

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
					/// Returns 213
					/// </summary>
					public const System.Int32 ColumnIndex = 213;

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
					/// Returns 214
					/// </summary>
					public const System.Int32 ColumnIndex = 214;

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
					/// Returns 215
					/// </summary>
					public const System.Int32 ColumnIndex = 215;

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
					/// Returns 216
					/// </summary>
					public const System.Int32 ColumnIndex = 216;

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
					/// Returns 217
					/// </summary>
					public const System.Int32 ColumnIndex = 217;

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
					/// Returns 218
					/// </summary>
					public const System.Int32 ColumnIndex = 218;

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
					/// Returns 219
					/// </summary>
					public const System.Int32 ColumnIndex = 219;

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
					/// Returns 220
					/// </summary>
					public const System.Int32 ColumnIndex = 220;

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
					/// Returns 221
					/// </summary>
					public const System.Int32 ColumnIndex = 221;

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
					/// Returns 222
					/// </summary>
					public const System.Int32 ColumnIndex = 222;

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
					/// Returns 223
					/// </summary>
					public const System.Int32 ColumnIndex = 223;

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
					/// Returns 224
					/// </summary>
					public const System.Int32 ColumnIndex = 224;

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
					/// Returns 225
					/// </summary>
					public const System.Int32 ColumnIndex = 225;

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
					/// Returns 226
					/// </summary>
					public const System.Int32 ColumnIndex = 226;

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
					/// Returns 227
					/// </summary>
					public const System.Int32 ColumnIndex = 227;

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
					/// Returns 228
					/// </summary>
					public const System.Int32 ColumnIndex = 228;

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
					/// Returns 229
					/// </summary>
					public const System.Int32 ColumnIndex = 229;

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
					/// Returns 230
					/// </summary>
					public const System.Int32 ColumnIndex = 230;

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
					/// Returns 231
					/// </summary>
					public const System.Int32 ColumnIndex = 231;

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
					/// Returns 232
					/// </summary>
					public const System.Int32 ColumnIndex = 232;

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
					/// Returns 233
					/// </summary>
					public const System.Int32 ColumnIndex = 233;

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
					/// Returns 234
					/// </summary>
					public const System.Int32 ColumnIndex = 234;

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
					/// Returns 235
					/// </summary>
					public const System.Int32 ColumnIndex = 235;

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
					/// Returns 236
					/// </summary>
					public const System.Int32 ColumnIndex = 236;

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
					/// Returns 237
					/// </summary>
					public const System.Int32 ColumnIndex = 237;

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
					/// Returns 238
					/// </summary>
					public const System.Int32 ColumnIndex = 238;

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
					/// Returns 239
					/// </summary>
					public const System.Int32 ColumnIndex = 239;

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
					/// Returns 240
					/// </summary>
					public const System.Int32 ColumnIndex = 240;

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
					/// Returns 241
					/// </summary>
					public const System.Int32 ColumnIndex = 241;

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
					/// Returns 242
					/// </summary>
					public const System.Int32 ColumnIndex = 242;

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
					/// Returns 243
					/// </summary>
					public const System.Int32 ColumnIndex = 243;

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
					/// Returns 244
					/// </summary>
					public const System.Int32 ColumnIndex = 244;

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
					/// Returns 245
					/// </summary>
					public const System.Int32 ColumnIndex = 245;

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
					/// Returns 246
					/// </summary>
					public const System.Int32 ColumnIndex = 246;

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
					/// Returns 247
					/// </summary>
					public const System.Int32 ColumnIndex = 247;

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
					/// Returns 248
					/// </summary>
					public const System.Int32 ColumnIndex = 248;

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
					/// Returns 249
					/// </summary>
					public const System.Int32 ColumnIndex = 249;

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
					/// Returns 250
					/// </summary>
					public const System.Int32 ColumnIndex = 250;

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
					/// Returns 251
					/// </summary>
					public const System.Int32 ColumnIndex = 251;

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
					/// Returns 252
					/// </summary>
					public const System.Int32 ColumnIndex = 252;

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
					/// Returns 253
					/// </summary>
					public const System.Int32 ColumnIndex = 253;

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
					/// Returns 254
					/// </summary>
					public const System.Int32 ColumnIndex = 254;

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
					/// Returns 255
					/// </summary>
					public const System.Int32 ColumnIndex = 255;

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
					/// Returns 256
					/// </summary>
					public const System.Int32 ColumnIndex = 256;

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
					/// Returns 257
					/// </summary>
					public const System.Int32 ColumnIndex = 257;

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
					/// Returns 258
					/// </summary>
					public const System.Int32 ColumnIndex = 258;

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
					/// Returns 259
					/// </summary>
					public const System.Int32 ColumnIndex = 259;

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
					/// Returns 260
					/// </summary>
					public const System.Int32 ColumnIndex = 260;

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
					/// Returns 261
					/// </summary>
					public const System.Int32 ColumnIndex = 261;

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
					/// Returns 262
					/// </summary>
					public const System.Int32 ColumnIndex = 262;

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
					/// Returns 263
					/// </summary>
					public const System.Int32 ColumnIndex = 263;

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
					/// Returns 264
					/// </summary>
					public const System.Int32 ColumnIndex = 264;

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
					/// Returns 265
					/// </summary>
					public const System.Int32 ColumnIndex = 265;

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
					/// Returns 266
					/// </summary>
					public const System.Int32 ColumnIndex = 266;

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
					/// Returns 267
					/// </summary>
					public const System.Int32 ColumnIndex = 267;

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
					/// Returns 268
					/// </summary>
					public const System.Int32 ColumnIndex = 268;

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
					/// Returns 269
					/// </summary>
					public const System.Int32 ColumnIndex = 269;

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
					/// Returns 270
					/// </summary>
					public const System.Int32 ColumnIndex = 270;

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
					/// Returns 271
					/// </summary>
					public const System.Int32 ColumnIndex = 271;

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
					/// Returns 272
					/// </summary>
					public const System.Int32 ColumnIndex = 272;

				}

			}
		}

		/// <summary>
		/// This class allows to easily retrieve the name or index of all the fields
		/// of the resulset #2 existing in the Dataset or the SqlDatReader returned by
		/// the Execute method of the 'spS_Permit_Full' class.
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

