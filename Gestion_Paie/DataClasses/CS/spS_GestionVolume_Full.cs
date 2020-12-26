/*
	This C# source code was automatically generated using:

		SQL Server Centric .NET Code Generator
			v 1.0.1287.20792

			Generation Date: 30/03/2007 9:55:22 AM
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
	/// stored procedure 'spS_GestionVolume_Full'. It allows also to specify specific connection
	/// information such as the ConnectionString to be use, the command time-out and so forth.
	/// </summary>
	[Serializable()]
#if OLYMARS_ATTRIBUTE || OLYMARS_DEBUG
	[OlymarsInformation(DeveloperName="<Developer Name Here>", GeneratedOn="2007/03/30 13:55:22", SqlObjectDependancyName="spS_GestionVolume_Full", SqlObjectDependancyRevision=0)]
#endif
	public sealed class spS_GestionVolume_Full : MarshalByRefObject, IDisposable, IParameter {

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
		/// Initializes a new instance of the spS_GestionVolume_Full class. If you use this constructor version,
		/// not assigning parameter values implies using the parameter default values.
		/// </summary>
		public spS_GestionVolume_Full() : this(true) {

		}

		/// <summary>
		/// Initializes a new instance of the spS_GestionVolume_Full class.
		/// </summary>
		/// <param name="useDefaultValue">If True, this parameter indicates that "not assigning parameter values" implies "using the parameter default values". If False, this parameter indicates that "not assigning parameter values" implies "using the SQL Server Null value".</param>
		public spS_GestionVolume_Full(bool useDefaultValue) {

			this.useDefaultValue = useDefaultValue;

			this.internal_Param_ID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_UsineID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_UniteMesureID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ProducteurID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_LotID_UseDefaultValue = this.useDefaultValue;
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
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'spS_GestionVolume_Full'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

						throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "spS_GestionVolume_Full", CurrentRevision, OriginalRevision, System.Environment.NewLine));
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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'spS_GestionVolume_Full'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlConnection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "spS_GestionVolume_Full", CurrentRevision, OriginalRevision, System.Environment.NewLine));
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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'spS_GestionVolume_Full'";
				sqlCommand.Transaction = sqlTransaction;

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlTransaction.Connection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "spS_GestionVolume_Full", CurrentRevision, OriginalRevision, System.Environment.NewLine));
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
				this.internal_Param_UsineID = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_UniteMesureID = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_ProducteurID = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_LotID = System.Data.SqlTypes.SqlInt32.Null;
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
		~spS_GestionVolume_Full() {

			Dispose(false);
		}

		/// <summary>
		/// Returns the stored procedure name for which this class was built, i.e. 'spS_GestionVolume_Full'.
		/// </summary>
		public string StoredProcedureName {

			get {

				return("spS_GestionVolume_Full");
			}
		}

		private System.Data.SqlTypes.SqlInt32 internal_Param_RETURN_VALUE;

		private System.Data.SqlTypes.SqlInt32 internal_Param_ID;
		internal bool internal_Param_ID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_UsineID;
		internal bool internal_Param_UsineID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_UniteMesureID;
		internal bool internal_Param_UniteMesureID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_ProducteurID;
		internal bool internal_Param_ProducteurID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlInt32 internal_Param_LotID;
		internal bool internal_Param_LotID_UseDefaultValue = true;

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

			this.internal_Param_UsineID = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_UsineID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_UniteMesureID = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_UniteMesureID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ProducteurID = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_ProducteurID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_LotID = System.Data.SqlTypes.SqlInt32.Null;
			this.internal_Param_LotID_UseDefaultValue = this.useDefaultValue;

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
		/// Sets the value of the stored procedure INPUT parameter '@UsineID'.
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
		/// the parameter default value, consider calling the Param_UsineID_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_UsineID {

			get {

				if (this.internal_Param_UsineID_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_UsineID);
			}

			set {

				this.internal_Param_UsineID_UseDefaultValue = false;
				this.internal_Param_UsineID = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@UsineID' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_UsineID_UseDefaultValue() {

			this.internal_Param_UsineID_UseDefaultValue = true;
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
		/// Sets the value of the stored procedure INPUT parameter '@ProducteurID'.
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
		/// the parameter default value, consider calling the Param_ProducteurID_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_ProducteurID {

			get {

				if (this.internal_Param_ProducteurID_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ProducteurID);
			}

			set {

				this.internal_Param_ProducteurID_UseDefaultValue = false;
				this.internal_Param_ProducteurID = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ProducteurID' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ProducteurID_UseDefaultValue() {

			this.internal_Param_ProducteurID_UseDefaultValue = true;
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
	/// This class allows you to execute the 'spS_GestionVolume_Full' stored procedure;
	/// it gives you the ability to:
	/// <list type="bullet">
	/// <item><description>Set all the necessary parameters to execute the stored procedure</description></item>
	/// <item><description>To execute the stored procedure</description></item>
	/// <item><description>To get back after the execution the return value and all the output parameters value</description></item>
	/// </list>
	/// </summary>
#if OLYMARS_ATTRIBUTE || OLYMARS_DEBUG
	[OlymarsInformation(DeveloperName="<Developer Name Here>", GeneratedOn="2007/03/30 13:55:22", SqlObjectDependancyName="spS_GestionVolume_Full", SqlObjectDependancyRevision=0)]
#endif
	public sealed class spS_GestionVolume_Full : MarshalByRefObject, IDisposable {


		private bool throwExceptionOnExecute = false;

		/// <summary>
		/// Initializes a new instance of the spS_GestionVolume_Full class.
		/// By default, no exception will be thrown when you call the Execute method. Instead, a Boolean return status will be returned.
		/// </summary>
		public spS_GestionVolume_Full() : this(false) {

		}

		/// <summary>
		/// Initializes a new instance of the spS_GestionVolume_Full class.
		/// </summary>
		/// <param name="throwExceptionOnExecute">True if an exception has to be thrown if the Execute call fails.</param>
		public spS_GestionVolume_Full(bool throwExceptionOnExecute) {

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
		~spS_GestionVolume_Full() {

			Dispose(false);
		}

		private void ResetParameter(ref Gestion_Paie.DataClasses.Parameters.spS_GestionVolume_Full parameters) {

			parameters.internal_Set_RETURN_VALUE (System.Data.SqlTypes.SqlInt32.Null);
		}

		private bool InitializeConnection(ref Gestion_Paie.DataClasses.Parameters.spS_GestionVolume_Full parameters, out System.Data.SqlClient.SqlCommand sqlCommand, ref bool connectionMustBeClosed) {

			try {

				this.sqlConnection = null;
				sqlCommand = null;
				connectionMustBeClosed = true;

				if (parameters.ConnectionType == ConnectionType.None) {

					throw new InvalidOperationException("No connection information was supplied. Consider calling the 'SetUpConnection' method of the Gestion_Paie.DataClasses.Parameters.spS_GestionVolume_Full object before doing this call.");
				}

				if (parameters.ConnectionType == ConnectionType.SqlConnection && parameters.SqlConnection == null) {

					throw new InvalidOperationException("No connection information was supplied (SqlConnection == null). Consider calling the 'SetUpConnection' method of the Gestion_Paie.DataClasses.Parameters.spS_GestionVolume_Full object before doing this call.");
				}

				if (parameters.ConnectionType == ConnectionType.SqlTransaction && parameters.SqlTransaction== null) {

					throw new InvalidOperationException("No connection information was supplied (SqlTransaction == null). Consider calling the 'SetUpConnection' method of the Gestion_Paie.DataClasses.Parameters.spS_GestionVolume_Full object before doing this call.");
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

							throw new System.InvalidOperationException("No connection information was supplied (ConnectionString == \"\")! (Gestion_Paie.DataClasses.Parameters.spS_GestionVolume_Full)");
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
				sqlCommand.CommandText = "spS_GestionVolume_Full";

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

		private bool DeclareParameters(ref Gestion_Paie.DataClasses.Parameters.spS_GestionVolume_Full parameters, ref System.Data.SqlClient.SqlCommand sqlCommand) {

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

				sqlParameter = new System.Data.SqlClient.SqlParameter("@UsineID", System.Data.SqlDbType.VarChar, 6);
				sqlParameter.SourceColumn = "UsineID";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_UsineID_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_UsineID.IsNull) {

					sqlParameter.Value = parameters.Param_UsineID;
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

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ProducteurID", System.Data.SqlDbType.VarChar, 15);
				sqlParameter.SourceColumn = "ProducteurID";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ProducteurID_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ProducteurID.IsNull) {

					sqlParameter.Value = parameters.Param_ProducteurID;
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

		private bool RetrieveParameters(ref Gestion_Paie.DataClasses.Parameters.spS_GestionVolume_Full parameters, ref System.Data.SqlClient.SqlCommand sqlCommand) {

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
		/// This method allows you to execute the [spS_GestionVolume_Full] stored procedure and retrieve back the data
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
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.spS_GestionVolume_Full parameters, out System.Data.SqlClient.SqlDataReader sqlDataReader) {

			return(Execute(ref parameters, out sqlDataReader, System.Data.CommandBehavior.Default));
		}

		/// <summary>
		/// This method allows you to execute the [spS_GestionVolume_Full] stored procedure and retrieve back the data
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
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.spS_GestionVolume_Full parameters, out System.Data.SqlClient.SqlDataReader sqlDataReader, System.Data.CommandBehavior commandBehavior) {

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
		/// This method allows you to execute the [spS_GestionVolume_Full] stored procedure and retrieve back the data
		/// populated in a DataSet (System.Data.DataSet).
		/// </summary>
		/// <param name="parameters">
		/// Contains all the necessary information to execute correctly the stored procedure, i.e. 
		/// the database connection to use and all the necessary input parameters to be supplied
		/// for this stored procedure execution. After the execution, this object will allow you
		/// to retrieve back the stored procedure return value and all the output parameters.
		/// </param>
		/// <param name="dataset">
		/// Will be populated with the data after execution. The table based name used will be: 'spS_GestionVolume_Full'.
		/// </param>
		/// <returns>True if the call was successful. Otherwise, it returns False.</returns>
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.spS_GestionVolume_Full parameters, ref System.Data.DataSet dataset) {

			return(Execute(ref parameters, ref dataset, "spS_GestionVolume_Full", -1, -1));
		}

		/// <summary>
		/// This method allows you to execute the [spS_GestionVolume_Full] stored procedure and retrieve back the data
		/// populated in a DataSet (System.Data.DataSet).
		/// </summary>
		/// <param name="parameters">
		/// Contains all the necessary information to execute correctly the stored procedure, i.e. 
		/// the database connection to use and all the necessary input parameters to be supplied
		/// for this stored procedure execution. After the execution, this object will allow you
		/// to retrieve back the stored procedure return value and all the output parameters.
		/// </param>
		/// <param name="dataset">
		/// Will be populated with the data after execution. The table based name used will be: 'spS_GestionVolume_Full'.
		/// </param>
		/// <param name="startRecord">The zero-based record number to start with.</param>
		/// <param name="maxRecords">The maximum number of records to retrieve.</param>
		/// <returns>True if the call was successful. Otherwise, it returns False.</returns>
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.spS_GestionVolume_Full parameters, ref System.Data.DataSet dataset, int startRecord, int maxRecords) {

			return(Execute(ref parameters, ref dataset, "spS_GestionVolume_Full", startRecord, maxRecords));
		}

		/// <summary>
		/// This method allows you to execute the [spS_GestionVolume_Full] stored procedure and retrieve back the data
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
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.spS_GestionVolume_Full parameters, ref System.Data.DataSet dataset, string tableName) {

			return(Execute(ref parameters, ref dataset, tableName, -1, -1));
		}

		/// <summary>
		/// This method allows you to execute the [spS_GestionVolume_Full] stored procedure and retrieve back the data
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
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.spS_GestionVolume_Full parameters, ref System.Data.DataSet dataset, string tableName, int startRecord, int maxRecords) {

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
				dataset.Tables[tableName].Columns["UsineID"].Caption = "UsineID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"UsineID\" column)";
				dataset.Tables[tableName].Columns["UniteMesureID"].Caption = "UniteMesureID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"UniteMesureID\" column)";
				dataset.Tables[tableName].Columns["ProducteurID"].Caption = "ProducteurID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ProducteurID\" column)";
				dataset.Tables[tableName].Columns["Annee"].Caption = "Annee (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Annee\" column)";
				dataset.Tables[tableName].Columns["Periode"].Caption = "Periode (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Periode\" column)";
				dataset.Tables[tableName].Columns["LotID"].Caption = "LotID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"LotID\" column)";
				dataset.Tables[tableName].Columns["DateEntree"].Caption = "DateEntree (update this label in the \"Olymars/ColumnLabel\" extended property of the \"DateEntree\" column)";
				dataset.Tables[tableName].Columns["UsineID_ID"].Caption = "ID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ID\" column)";
				dataset.Tables[tableName].Columns["UsineID_Description"].Caption = "Description (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Description\" column)";
				dataset.Tables[tableName].Columns["UsineID_UtilisationID"].Caption = "UtilisationID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"UtilisationID\" column)";
				dataset.Tables[tableName].Columns["UsineID_Paye_producteur"].Caption = "Paye_producteur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Paye_producteur\" column)";
				dataset.Tables[tableName].Columns["UsineID_Paye_transporteur"].Caption = "Paye_transporteur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Paye_transporteur\" column)";
				dataset.Tables[tableName].Columns["UsineID_Specification"].Caption = "Specification (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Specification\" column)";
				dataset.Tables[tableName].Columns["UsineID_Compte_a_recevoir"].Caption = "Compte_a_recevoir (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Compte_a_recevoir\" column)";
				dataset.Tables[tableName].Columns["UsineID_Compte_ajustement"].Caption = "Compte_ajustement (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Compte_ajustement\" column)";
				dataset.Tables[tableName].Columns["UsineID_Compte_transporteur"].Caption = "Compte_transporteur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Compte_transporteur\" column)";
				dataset.Tables[tableName].Columns["UsineID_Compte_producteur"].Caption = "Compte_producteur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Compte_producteur\" column)";
				dataset.Tables[tableName].Columns["UsineID_Compte_preleve_plan_conjoint"].Caption = "Compte_preleve_plan_conjoint (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Compte_preleve_plan_conjoint\" column)";
				dataset.Tables[tableName].Columns["UsineID_Compte_preleve_fond_roulement"].Caption = "Compte_preleve_fond_roulement (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Compte_preleve_fond_roulement\" column)";
				dataset.Tables[tableName].Columns["UsineID_Compte_preleve_fond_forestier"].Caption = "Compte_preleve_fond_forestier (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Compte_preleve_fond_forestier\" column)";
				dataset.Tables[tableName].Columns["UsineID_Compte_preleve_divers"].Caption = "Compte_preleve_divers (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Compte_preleve_divers\" column)";
				dataset.Tables[tableName].Columns["UsineID_Compte_mise_en_commun"].Caption = "Compte_mise_en_commun (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Compte_mise_en_commun\" column)";
				dataset.Tables[tableName].Columns["UsineID_Compte_surcharge"].Caption = "Compte_surcharge (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Compte_surcharge\" column)";
				dataset.Tables[tableName].Columns["UsineID_Compte_indexation_carburant"].Caption = "Compte_indexation_carburant (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Compte_indexation_carburant\" column)";
				dataset.Tables[tableName].Columns["UsineID_Actif"].Caption = "Actif (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Actif\" column)";
				dataset.Tables[tableName].Columns["UsineID_NePaiePasTPS"].Caption = "NePaiePasTPS (update this label in the \"Olymars/ColumnLabel\" extended property of the \"NePaiePasTPS\" column)";
				dataset.Tables[tableName].Columns["UsineID_NePaiePasTVQ"].Caption = "NePaiePasTVQ (update this label in the \"Olymars/ColumnLabel\" extended property of the \"NePaiePasTVQ\" column)";
				dataset.Tables[tableName].Columns["UsineID_NoTPS"].Caption = "NoTPS (update this label in the \"Olymars/ColumnLabel\" extended property of the \"NoTPS\" column)";
				dataset.Tables[tableName].Columns["UsineID_NoTVQ"].Caption = "NoTVQ (update this label in the \"Olymars/ColumnLabel\" extended property of the \"NoTVQ\" column)";
				dataset.Tables[tableName].Columns["UsineID_Compte_chargeur"].Caption = "Compte_chargeur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Compte_chargeur\" column)";
				dataset.Tables[tableName].Columns["UsineID_UsineGestionVolume"].Caption = "UsineGestionVolume (update this label in the \"Olymars/ColumnLabel\" extended property of the \"UsineGestionVolume\" column)";
				dataset.Tables[tableName].Columns["UsineID_AuSoinsDe"].Caption = "AuSoinsDe (update this label in the \"Olymars/ColumnLabel\" extended property of the \"AuSoinsDe\" column)";
				dataset.Tables[tableName].Columns["UsineID_Rue"].Caption = "Rue (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Rue\" column)";
				dataset.Tables[tableName].Columns["UsineID_Ville"].Caption = "Ville (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Ville\" column)";
				dataset.Tables[tableName].Columns["UsineID_PaysID"].Caption = "PaysID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"PaysID\" column)";
				dataset.Tables[tableName].Columns["UsineID_Code_postal"].Caption = "Code_postal (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Code_postal\" column)";
				dataset.Tables[tableName].Columns["UsineID_Telephone"].Caption = "Telephone (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone\" column)";
				dataset.Tables[tableName].Columns["UsineID_Telephone_Poste"].Caption = "Telephone_Poste (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone_Poste\" column)";
				dataset.Tables[tableName].Columns["UsineID_Telecopieur"].Caption = "Telecopieur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telecopieur\" column)";
				dataset.Tables[tableName].Columns["UsineID_Telephone2"].Caption = "Telephone2 (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone2\" column)";
				dataset.Tables[tableName].Columns["UsineID_Telephone2_Desc"].Caption = "Telephone2_Desc (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone2_Desc\" column)";
				dataset.Tables[tableName].Columns["UsineID_Telephone2_Poste"].Caption = "Telephone2_Poste (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone2_Poste\" column)";
				dataset.Tables[tableName].Columns["UsineID_Telephone3"].Caption = "Telephone3 (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone3\" column)";
				dataset.Tables[tableName].Columns["UsineID_Telephone3_Desc"].Caption = "Telephone3_Desc (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone3_Desc\" column)";
				dataset.Tables[tableName].Columns["UsineID_Telephone3_Poste"].Caption = "Telephone3_Poste (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone3_Poste\" column)";
				dataset.Tables[tableName].Columns["UsineID_Email"].Caption = "Email (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Email\" column)";
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
				dataset.Tables[tableName].Columns["ProducteurID_ID"].Caption = "ID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ID\" column)";
				dataset.Tables[tableName].Columns["ProducteurID_CleTri"].Caption = "CleTri (update this label in the \"Olymars/ColumnLabel\" extended property of the \"CleTri\" column)";
				dataset.Tables[tableName].Columns["ProducteurID_Nom"].Caption = "Nom (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Nom\" column)";
				dataset.Tables[tableName].Columns["ProducteurID_AuSoinsDe"].Caption = "AuSoinsDe (update this label in the \"Olymars/ColumnLabel\" extended property of the \"AuSoinsDe\" column)";
				dataset.Tables[tableName].Columns["ProducteurID_Rue"].Caption = "Rue (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Rue\" column)";
				dataset.Tables[tableName].Columns["ProducteurID_Ville"].Caption = "Ville (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Ville\" column)";
				dataset.Tables[tableName].Columns["ProducteurID_PaysID"].Caption = "PaysID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"PaysID\" column)";
				dataset.Tables[tableName].Columns["ProducteurID_Code_postal"].Caption = "Code_postal (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Code_postal\" column)";
				dataset.Tables[tableName].Columns["ProducteurID_Telephone"].Caption = "Telephone (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone\" column)";
				dataset.Tables[tableName].Columns["ProducteurID_Telephone_Poste"].Caption = "Telephone_Poste (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone_Poste\" column)";
				dataset.Tables[tableName].Columns["ProducteurID_Telecopieur"].Caption = "Telecopieur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telecopieur\" column)";
				dataset.Tables[tableName].Columns["ProducteurID_Telephone2"].Caption = "Telephone2 (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone2\" column)";
				dataset.Tables[tableName].Columns["ProducteurID_Telephone2_Desc"].Caption = "Telephone2_Desc (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone2_Desc\" column)";
				dataset.Tables[tableName].Columns["ProducteurID_Telephone2_Poste"].Caption = "Telephone2_Poste (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone2_Poste\" column)";
				dataset.Tables[tableName].Columns["ProducteurID_Telephone3"].Caption = "Telephone3 (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone3\" column)";
				dataset.Tables[tableName].Columns["ProducteurID_Telephone3_Desc"].Caption = "Telephone3_Desc (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone3_Desc\" column)";
				dataset.Tables[tableName].Columns["ProducteurID_Telephone3_Poste"].Caption = "Telephone3_Poste (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone3_Poste\" column)";
				dataset.Tables[tableName].Columns["ProducteurID_No_membre"].Caption = "No_membre (update this label in the \"Olymars/ColumnLabel\" extended property of the \"No_membre\" column)";
				dataset.Tables[tableName].Columns["ProducteurID_Resident"].Caption = "Resident (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Resident\" column)";
				dataset.Tables[tableName].Columns["ProducteurID_Email"].Caption = "Email (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Email\" column)";
				dataset.Tables[tableName].Columns["ProducteurID_WWW"].Caption = "WWW (update this label in the \"Olymars/ColumnLabel\" extended property of the \"WWW\" column)";
				dataset.Tables[tableName].Columns["ProducteurID_Commentaires"].Caption = "Commentaires (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Commentaires\" column)";
				dataset.Tables[tableName].Columns["ProducteurID_AfficherCommentaires"].Caption = "AfficherCommentaires (update this label in the \"Olymars/ColumnLabel\" extended property of the \"AfficherCommentaires\" column)";
				dataset.Tables[tableName].Columns["ProducteurID_DepotDirect"].Caption = "DepotDirect (update this label in the \"Olymars/ColumnLabel\" extended property of the \"DepotDirect\" column)";
				dataset.Tables[tableName].Columns["ProducteurID_InstitutionBanquaireID"].Caption = "InstitutionBanquaireID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"InstitutionBanquaireID\" column)";
				dataset.Tables[tableName].Columns["ProducteurID_Banque_transit"].Caption = "Banque_transit (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Banque_transit\" column)";
				dataset.Tables[tableName].Columns["ProducteurID_Banque_folio"].Caption = "Banque_folio (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Banque_folio\" column)";
				dataset.Tables[tableName].Columns["ProducteurID_No_TPS"].Caption = "No_TPS (update this label in the \"Olymars/ColumnLabel\" extended property of the \"No_TPS\" column)";
				dataset.Tables[tableName].Columns["ProducteurID_No_TVQ"].Caption = "No_TVQ (update this label in the \"Olymars/ColumnLabel\" extended property of the \"No_TVQ\" column)";
				dataset.Tables[tableName].Columns["ProducteurID_PayerA"].Caption = "PayerA (update this label in the \"Olymars/ColumnLabel\" extended property of the \"PayerA\" column)";
				dataset.Tables[tableName].Columns["ProducteurID_PayerAID"].Caption = "PayerAID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"PayerAID\" column)";
				dataset.Tables[tableName].Columns["ProducteurID_Statut"].Caption = "Statut (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Statut\" column)";
				dataset.Tables[tableName].Columns["ProducteurID_Rep_Nom"].Caption = "Rep_Nom (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Rep_Nom\" column)";
				dataset.Tables[tableName].Columns["ProducteurID_Rep_Telephone"].Caption = "Rep_Telephone (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Rep_Telephone\" column)";
				dataset.Tables[tableName].Columns["ProducteurID_Rep_Telephone_Poste"].Caption = "Rep_Telephone_Poste (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Rep_Telephone_Poste\" column)";
				dataset.Tables[tableName].Columns["ProducteurID_Rep_Email"].Caption = "Rep_Email (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Rep_Email\" column)";
				dataset.Tables[tableName].Columns["ProducteurID_EnAnglais"].Caption = "EnAnglais (update this label in the \"Olymars/ColumnLabel\" extended property of the \"EnAnglais\" column)";
				dataset.Tables[tableName].Columns["ProducteurID_Actif"].Caption = "Actif (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Actif\" column)";
				dataset.Tables[tableName].Columns["ProducteurID_MRCProducteurID"].Caption = "MRCProducteurID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"MRCProducteurID\" column)";
				dataset.Tables[tableName].Columns["ProducteurID_PaiementManuel"].Caption = "PaiementManuel (update this label in the \"Olymars/ColumnLabel\" extended property of the \"PaiementManuel\" column)";
				dataset.Tables[tableName].Columns["ProducteurID_Journal"].Caption = "Journal (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Journal\" column)";
				dataset.Tables[tableName].Columns["ProducteurID_RecoitTPS"].Caption = "RecoitTPS (update this label in the \"Olymars/ColumnLabel\" extended property of the \"RecoitTPS\" column)";
				dataset.Tables[tableName].Columns["ProducteurID_RecoitTVQ"].Caption = "RecoitTVQ (update this label in the \"Olymars/ColumnLabel\" extended property of the \"RecoitTVQ\" column)";
				dataset.Tables[tableName].Columns["ProducteurID_ModifierTrigger"].Caption = "ModifierTrigger (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ModifierTrigger\" column)";
				dataset.Tables[tableName].Columns["ProducteurID_IsProducteur"].Caption = "IsProducteur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"IsProducteur\" column)";
				dataset.Tables[tableName].Columns["ProducteurID_IsTransporteur"].Caption = "IsTransporteur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"IsTransporteur\" column)";
				dataset.Tables[tableName].Columns["ProducteurID_IsChargeur"].Caption = "IsChargeur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"IsChargeur\" column)";
				dataset.Tables[tableName].Columns["ProducteurID_IsAutre"].Caption = "IsAutre (update this label in the \"Olymars/ColumnLabel\" extended property of the \"IsAutre\" column)";
				dataset.Tables[tableName].Columns["ProducteurID_AfficherCommentairesSurPermit"].Caption = "AfficherCommentairesSurPermit (update this label in the \"Olymars/ColumnLabel\" extended property of the \"AfficherCommentairesSurPermit\" column)";
				dataset.Tables[tableName].Columns["ProducteurID_PasEmissionPermis"].Caption = "PasEmissionPermis (update this label in the \"Olymars/ColumnLabel\" extended property of the \"PasEmissionPermis\" column)";
				dataset.Tables[tableName].Columns["ProducteurID_Generique"].Caption = "Generique (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Generique\" column)";
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
		/// This method allows you to execute the [spS_GestionVolume_Full] stored procedure and retrieve back the data
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
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.spS_GestionVolume_Full parameters, ref string xml) {

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
		/// This method allows you to execute the [spS_GestionVolume_Full] stored procedure and retrieve back the data
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
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.spS_GestionVolume_Full parameters, out System.Xml.XmlReader xmlReader) {

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
		/// the Execute method of the 'spS_GestionVolume_Full' class.
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
				/// Allows to get the Index and Name of the field UsineID via shared members
				/// </summary>
				public sealed class Column_UsineID {

					/// <summary>
					/// Returns "UsineID"
					/// </summary>
					public const System.String ColumnName = "UsineID";
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
				/// Allows to get the Index and Name of the field Annee via shared members
				/// </summary>
				public sealed class Column_Annee {

					/// <summary>
					/// Returns "Annee"
					/// </summary>
					public const System.String ColumnName = "Annee";
					/// <summary>
					/// Returns 5
					/// </summary>
					public const System.Int32 ColumnIndex = 5;

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
					/// Returns 6
					/// </summary>
					public const System.Int32 ColumnIndex = 6;

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
					/// Returns 7
					/// </summary>
					public const System.Int32 ColumnIndex = 7;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field DateEntree via shared members
				/// </summary>
				public sealed class Column_DateEntree {

					/// <summary>
					/// Returns "DateEntree"
					/// </summary>
					public const System.String ColumnName = "DateEntree";
					/// <summary>
					/// Returns 8
					/// </summary>
					public const System.Int32 ColumnIndex = 8;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field UsineID_ID via shared members
				/// </summary>
				public sealed class Column_UsineID_ID {

					/// <summary>
					/// Returns "UsineID_ID"
					/// </summary>
					public const System.String ColumnName = "UsineID_ID";
					/// <summary>
					/// Returns 9
					/// </summary>
					public const System.Int32 ColumnIndex = 9;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field UsineID_Description via shared members
				/// </summary>
				public sealed class Column_UsineID_Description {

					/// <summary>
					/// Returns "UsineID_Description"
					/// </summary>
					public const System.String ColumnName = "UsineID_Description";
					/// <summary>
					/// Returns 10
					/// </summary>
					public const System.Int32 ColumnIndex = 10;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field UsineID_UtilisationID via shared members
				/// </summary>
				public sealed class Column_UsineID_UtilisationID {

					/// <summary>
					/// Returns "UsineID_UtilisationID"
					/// </summary>
					public const System.String ColumnName = "UsineID_UtilisationID";
					/// <summary>
					/// Returns 11
					/// </summary>
					public const System.Int32 ColumnIndex = 11;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field UsineID_Paye_producteur via shared members
				/// </summary>
				public sealed class Column_UsineID_Paye_producteur {

					/// <summary>
					/// Returns "UsineID_Paye_producteur"
					/// </summary>
					public const System.String ColumnName = "UsineID_Paye_producteur";
					/// <summary>
					/// Returns 12
					/// </summary>
					public const System.Int32 ColumnIndex = 12;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field UsineID_Paye_transporteur via shared members
				/// </summary>
				public sealed class Column_UsineID_Paye_transporteur {

					/// <summary>
					/// Returns "UsineID_Paye_transporteur"
					/// </summary>
					public const System.String ColumnName = "UsineID_Paye_transporteur";
					/// <summary>
					/// Returns 13
					/// </summary>
					public const System.Int32 ColumnIndex = 13;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field UsineID_Specification via shared members
				/// </summary>
				public sealed class Column_UsineID_Specification {

					/// <summary>
					/// Returns "UsineID_Specification"
					/// </summary>
					public const System.String ColumnName = "UsineID_Specification";
					/// <summary>
					/// Returns 14
					/// </summary>
					public const System.Int32 ColumnIndex = 14;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field UsineID_Compte_a_recevoir via shared members
				/// </summary>
				public sealed class Column_UsineID_Compte_a_recevoir {

					/// <summary>
					/// Returns "UsineID_Compte_a_recevoir"
					/// </summary>
					public const System.String ColumnName = "UsineID_Compte_a_recevoir";
					/// <summary>
					/// Returns 15
					/// </summary>
					public const System.Int32 ColumnIndex = 15;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field UsineID_Compte_ajustement via shared members
				/// </summary>
				public sealed class Column_UsineID_Compte_ajustement {

					/// <summary>
					/// Returns "UsineID_Compte_ajustement"
					/// </summary>
					public const System.String ColumnName = "UsineID_Compte_ajustement";
					/// <summary>
					/// Returns 16
					/// </summary>
					public const System.Int32 ColumnIndex = 16;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field UsineID_Compte_transporteur via shared members
				/// </summary>
				public sealed class Column_UsineID_Compte_transporteur {

					/// <summary>
					/// Returns "UsineID_Compte_transporteur"
					/// </summary>
					public const System.String ColumnName = "UsineID_Compte_transporteur";
					/// <summary>
					/// Returns 17
					/// </summary>
					public const System.Int32 ColumnIndex = 17;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field UsineID_Compte_producteur via shared members
				/// </summary>
				public sealed class Column_UsineID_Compte_producteur {

					/// <summary>
					/// Returns "UsineID_Compte_producteur"
					/// </summary>
					public const System.String ColumnName = "UsineID_Compte_producteur";
					/// <summary>
					/// Returns 18
					/// </summary>
					public const System.Int32 ColumnIndex = 18;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field UsineID_Compte_preleve_plan_conjoint via shared members
				/// </summary>
				public sealed class Column_UsineID_Compte_preleve_plan_conjoint {

					/// <summary>
					/// Returns "UsineID_Compte_preleve_plan_conjoint"
					/// </summary>
					public const System.String ColumnName = "UsineID_Compte_preleve_plan_conjoint";
					/// <summary>
					/// Returns 19
					/// </summary>
					public const System.Int32 ColumnIndex = 19;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field UsineID_Compte_preleve_fond_roulement via shared members
				/// </summary>
				public sealed class Column_UsineID_Compte_preleve_fond_roulement {

					/// <summary>
					/// Returns "UsineID_Compte_preleve_fond_roulement"
					/// </summary>
					public const System.String ColumnName = "UsineID_Compte_preleve_fond_roulement";
					/// <summary>
					/// Returns 20
					/// </summary>
					public const System.Int32 ColumnIndex = 20;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field UsineID_Compte_preleve_fond_forestier via shared members
				/// </summary>
				public sealed class Column_UsineID_Compte_preleve_fond_forestier {

					/// <summary>
					/// Returns "UsineID_Compte_preleve_fond_forestier"
					/// </summary>
					public const System.String ColumnName = "UsineID_Compte_preleve_fond_forestier";
					/// <summary>
					/// Returns 21
					/// </summary>
					public const System.Int32 ColumnIndex = 21;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field UsineID_Compte_preleve_divers via shared members
				/// </summary>
				public sealed class Column_UsineID_Compte_preleve_divers {

					/// <summary>
					/// Returns "UsineID_Compte_preleve_divers"
					/// </summary>
					public const System.String ColumnName = "UsineID_Compte_preleve_divers";
					/// <summary>
					/// Returns 22
					/// </summary>
					public const System.Int32 ColumnIndex = 22;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field UsineID_Compte_mise_en_commun via shared members
				/// </summary>
				public sealed class Column_UsineID_Compte_mise_en_commun {

					/// <summary>
					/// Returns "UsineID_Compte_mise_en_commun"
					/// </summary>
					public const System.String ColumnName = "UsineID_Compte_mise_en_commun";
					/// <summary>
					/// Returns 23
					/// </summary>
					public const System.Int32 ColumnIndex = 23;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field UsineID_Compte_surcharge via shared members
				/// </summary>
				public sealed class Column_UsineID_Compte_surcharge {

					/// <summary>
					/// Returns "UsineID_Compte_surcharge"
					/// </summary>
					public const System.String ColumnName = "UsineID_Compte_surcharge";
					/// <summary>
					/// Returns 24
					/// </summary>
					public const System.Int32 ColumnIndex = 24;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field UsineID_Compte_indexation_carburant via shared members
				/// </summary>
				public sealed class Column_UsineID_Compte_indexation_carburant {

					/// <summary>
					/// Returns "UsineID_Compte_indexation_carburant"
					/// </summary>
					public const System.String ColumnName = "UsineID_Compte_indexation_carburant";
					/// <summary>
					/// Returns 25
					/// </summary>
					public const System.Int32 ColumnIndex = 25;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field UsineID_Actif via shared members
				/// </summary>
				public sealed class Column_UsineID_Actif {

					/// <summary>
					/// Returns "UsineID_Actif"
					/// </summary>
					public const System.String ColumnName = "UsineID_Actif";
					/// <summary>
					/// Returns 26
					/// </summary>
					public const System.Int32 ColumnIndex = 26;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field UsineID_NePaiePasTPS via shared members
				/// </summary>
				public sealed class Column_UsineID_NePaiePasTPS {

					/// <summary>
					/// Returns "UsineID_NePaiePasTPS"
					/// </summary>
					public const System.String ColumnName = "UsineID_NePaiePasTPS";
					/// <summary>
					/// Returns 27
					/// </summary>
					public const System.Int32 ColumnIndex = 27;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field UsineID_NePaiePasTVQ via shared members
				/// </summary>
				public sealed class Column_UsineID_NePaiePasTVQ {

					/// <summary>
					/// Returns "UsineID_NePaiePasTVQ"
					/// </summary>
					public const System.String ColumnName = "UsineID_NePaiePasTVQ";
					/// <summary>
					/// Returns 28
					/// </summary>
					public const System.Int32 ColumnIndex = 28;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field UsineID_NoTPS via shared members
				/// </summary>
				public sealed class Column_UsineID_NoTPS {

					/// <summary>
					/// Returns "UsineID_NoTPS"
					/// </summary>
					public const System.String ColumnName = "UsineID_NoTPS";
					/// <summary>
					/// Returns 29
					/// </summary>
					public const System.Int32 ColumnIndex = 29;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field UsineID_NoTVQ via shared members
				/// </summary>
				public sealed class Column_UsineID_NoTVQ {

					/// <summary>
					/// Returns "UsineID_NoTVQ"
					/// </summary>
					public const System.String ColumnName = "UsineID_NoTVQ";
					/// <summary>
					/// Returns 30
					/// </summary>
					public const System.Int32 ColumnIndex = 30;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field UsineID_Compte_chargeur via shared members
				/// </summary>
				public sealed class Column_UsineID_Compte_chargeur {

					/// <summary>
					/// Returns "UsineID_Compte_chargeur"
					/// </summary>
					public const System.String ColumnName = "UsineID_Compte_chargeur";
					/// <summary>
					/// Returns 31
					/// </summary>
					public const System.Int32 ColumnIndex = 31;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field UsineID_UsineGestionVolume via shared members
				/// </summary>
				public sealed class Column_UsineID_UsineGestionVolume {

					/// <summary>
					/// Returns "UsineID_UsineGestionVolume"
					/// </summary>
					public const System.String ColumnName = "UsineID_UsineGestionVolume";
					/// <summary>
					/// Returns 32
					/// </summary>
					public const System.Int32 ColumnIndex = 32;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field UsineID_AuSoinsDe via shared members
				/// </summary>
				public sealed class Column_UsineID_AuSoinsDe {

					/// <summary>
					/// Returns "UsineID_AuSoinsDe"
					/// </summary>
					public const System.String ColumnName = "UsineID_AuSoinsDe";
					/// <summary>
					/// Returns 33
					/// </summary>
					public const System.Int32 ColumnIndex = 33;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field UsineID_Rue via shared members
				/// </summary>
				public sealed class Column_UsineID_Rue {

					/// <summary>
					/// Returns "UsineID_Rue"
					/// </summary>
					public const System.String ColumnName = "UsineID_Rue";
					/// <summary>
					/// Returns 34
					/// </summary>
					public const System.Int32 ColumnIndex = 34;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field UsineID_Ville via shared members
				/// </summary>
				public sealed class Column_UsineID_Ville {

					/// <summary>
					/// Returns "UsineID_Ville"
					/// </summary>
					public const System.String ColumnName = "UsineID_Ville";
					/// <summary>
					/// Returns 35
					/// </summary>
					public const System.Int32 ColumnIndex = 35;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field UsineID_PaysID via shared members
				/// </summary>
				public sealed class Column_UsineID_PaysID {

					/// <summary>
					/// Returns "UsineID_PaysID"
					/// </summary>
					public const System.String ColumnName = "UsineID_PaysID";
					/// <summary>
					/// Returns 36
					/// </summary>
					public const System.Int32 ColumnIndex = 36;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field UsineID_Code_postal via shared members
				/// </summary>
				public sealed class Column_UsineID_Code_postal {

					/// <summary>
					/// Returns "UsineID_Code_postal"
					/// </summary>
					public const System.String ColumnName = "UsineID_Code_postal";
					/// <summary>
					/// Returns 37
					/// </summary>
					public const System.Int32 ColumnIndex = 37;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field UsineID_Telephone via shared members
				/// </summary>
				public sealed class Column_UsineID_Telephone {

					/// <summary>
					/// Returns "UsineID_Telephone"
					/// </summary>
					public const System.String ColumnName = "UsineID_Telephone";
					/// <summary>
					/// Returns 38
					/// </summary>
					public const System.Int32 ColumnIndex = 38;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field UsineID_Telephone_Poste via shared members
				/// </summary>
				public sealed class Column_UsineID_Telephone_Poste {

					/// <summary>
					/// Returns "UsineID_Telephone_Poste"
					/// </summary>
					public const System.String ColumnName = "UsineID_Telephone_Poste";
					/// <summary>
					/// Returns 39
					/// </summary>
					public const System.Int32 ColumnIndex = 39;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field UsineID_Telecopieur via shared members
				/// </summary>
				public sealed class Column_UsineID_Telecopieur {

					/// <summary>
					/// Returns "UsineID_Telecopieur"
					/// </summary>
					public const System.String ColumnName = "UsineID_Telecopieur";
					/// <summary>
					/// Returns 40
					/// </summary>
					public const System.Int32 ColumnIndex = 40;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field UsineID_Telephone2 via shared members
				/// </summary>
				public sealed class Column_UsineID_Telephone2 {

					/// <summary>
					/// Returns "UsineID_Telephone2"
					/// </summary>
					public const System.String ColumnName = "UsineID_Telephone2";
					/// <summary>
					/// Returns 41
					/// </summary>
					public const System.Int32 ColumnIndex = 41;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field UsineID_Telephone2_Desc via shared members
				/// </summary>
				public sealed class Column_UsineID_Telephone2_Desc {

					/// <summary>
					/// Returns "UsineID_Telephone2_Desc"
					/// </summary>
					public const System.String ColumnName = "UsineID_Telephone2_Desc";
					/// <summary>
					/// Returns 42
					/// </summary>
					public const System.Int32 ColumnIndex = 42;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field UsineID_Telephone2_Poste via shared members
				/// </summary>
				public sealed class Column_UsineID_Telephone2_Poste {

					/// <summary>
					/// Returns "UsineID_Telephone2_Poste"
					/// </summary>
					public const System.String ColumnName = "UsineID_Telephone2_Poste";
					/// <summary>
					/// Returns 43
					/// </summary>
					public const System.Int32 ColumnIndex = 43;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field UsineID_Telephone3 via shared members
				/// </summary>
				public sealed class Column_UsineID_Telephone3 {

					/// <summary>
					/// Returns "UsineID_Telephone3"
					/// </summary>
					public const System.String ColumnName = "UsineID_Telephone3";
					/// <summary>
					/// Returns 44
					/// </summary>
					public const System.Int32 ColumnIndex = 44;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field UsineID_Telephone3_Desc via shared members
				/// </summary>
				public sealed class Column_UsineID_Telephone3_Desc {

					/// <summary>
					/// Returns "UsineID_Telephone3_Desc"
					/// </summary>
					public const System.String ColumnName = "UsineID_Telephone3_Desc";
					/// <summary>
					/// Returns 45
					/// </summary>
					public const System.Int32 ColumnIndex = 45;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field UsineID_Telephone3_Poste via shared members
				/// </summary>
				public sealed class Column_UsineID_Telephone3_Poste {

					/// <summary>
					/// Returns "UsineID_Telephone3_Poste"
					/// </summary>
					public const System.String ColumnName = "UsineID_Telephone3_Poste";
					/// <summary>
					/// Returns 46
					/// </summary>
					public const System.Int32 ColumnIndex = 46;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field UsineID_Email via shared members
				/// </summary>
				public sealed class Column_UsineID_Email {

					/// <summary>
					/// Returns "UsineID_Email"
					/// </summary>
					public const System.String ColumnName = "UsineID_Email";
					/// <summary>
					/// Returns 47
					/// </summary>
					public const System.Int32 ColumnIndex = 47;

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
					/// Returns 48
					/// </summary>
					public const System.Int32 ColumnIndex = 48;

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
					/// Returns 49
					/// </summary>
					public const System.Int32 ColumnIndex = 49;

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
					/// Returns 50
					/// </summary>
					public const System.Int32 ColumnIndex = 50;

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
					/// Returns 51
					/// </summary>
					public const System.Int32 ColumnIndex = 51;

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
					/// Returns 52
					/// </summary>
					public const System.Int32 ColumnIndex = 52;

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
					/// Returns 53
					/// </summary>
					public const System.Int32 ColumnIndex = 53;

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
					/// Returns 54
					/// </summary>
					public const System.Int32 ColumnIndex = 54;

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
					/// Returns 55
					/// </summary>
					public const System.Int32 ColumnIndex = 55;

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
					/// Returns 56
					/// </summary>
					public const System.Int32 ColumnIndex = 56;

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
					/// Returns 57
					/// </summary>
					public const System.Int32 ColumnIndex = 57;

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
					/// Returns 58
					/// </summary>
					public const System.Int32 ColumnIndex = 58;

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
					/// Returns 59
					/// </summary>
					public const System.Int32 ColumnIndex = 59;

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
					/// Returns 60
					/// </summary>
					public const System.Int32 ColumnIndex = 60;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurID_ID via shared members
				/// </summary>
				public sealed class Column_ProducteurID_ID {

					/// <summary>
					/// Returns "ProducteurID_ID"
					/// </summary>
					public const System.String ColumnName = "ProducteurID_ID";
					/// <summary>
					/// Returns 61
					/// </summary>
					public const System.Int32 ColumnIndex = 61;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurID_CleTri via shared members
				/// </summary>
				public sealed class Column_ProducteurID_CleTri {

					/// <summary>
					/// Returns "ProducteurID_CleTri"
					/// </summary>
					public const System.String ColumnName = "ProducteurID_CleTri";
					/// <summary>
					/// Returns 62
					/// </summary>
					public const System.Int32 ColumnIndex = 62;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurID_Nom via shared members
				/// </summary>
				public sealed class Column_ProducteurID_Nom {

					/// <summary>
					/// Returns "ProducteurID_Nom"
					/// </summary>
					public const System.String ColumnName = "ProducteurID_Nom";
					/// <summary>
					/// Returns 63
					/// </summary>
					public const System.Int32 ColumnIndex = 63;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurID_AuSoinsDe via shared members
				/// </summary>
				public sealed class Column_ProducteurID_AuSoinsDe {

					/// <summary>
					/// Returns "ProducteurID_AuSoinsDe"
					/// </summary>
					public const System.String ColumnName = "ProducteurID_AuSoinsDe";
					/// <summary>
					/// Returns 64
					/// </summary>
					public const System.Int32 ColumnIndex = 64;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurID_Rue via shared members
				/// </summary>
				public sealed class Column_ProducteurID_Rue {

					/// <summary>
					/// Returns "ProducteurID_Rue"
					/// </summary>
					public const System.String ColumnName = "ProducteurID_Rue";
					/// <summary>
					/// Returns 65
					/// </summary>
					public const System.Int32 ColumnIndex = 65;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurID_Ville via shared members
				/// </summary>
				public sealed class Column_ProducteurID_Ville {

					/// <summary>
					/// Returns "ProducteurID_Ville"
					/// </summary>
					public const System.String ColumnName = "ProducteurID_Ville";
					/// <summary>
					/// Returns 66
					/// </summary>
					public const System.Int32 ColumnIndex = 66;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurID_PaysID via shared members
				/// </summary>
				public sealed class Column_ProducteurID_PaysID {

					/// <summary>
					/// Returns "ProducteurID_PaysID"
					/// </summary>
					public const System.String ColumnName = "ProducteurID_PaysID";
					/// <summary>
					/// Returns 67
					/// </summary>
					public const System.Int32 ColumnIndex = 67;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurID_Code_postal via shared members
				/// </summary>
				public sealed class Column_ProducteurID_Code_postal {

					/// <summary>
					/// Returns "ProducteurID_Code_postal"
					/// </summary>
					public const System.String ColumnName = "ProducteurID_Code_postal";
					/// <summary>
					/// Returns 68
					/// </summary>
					public const System.Int32 ColumnIndex = 68;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurID_Telephone via shared members
				/// </summary>
				public sealed class Column_ProducteurID_Telephone {

					/// <summary>
					/// Returns "ProducteurID_Telephone"
					/// </summary>
					public const System.String ColumnName = "ProducteurID_Telephone";
					/// <summary>
					/// Returns 69
					/// </summary>
					public const System.Int32 ColumnIndex = 69;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurID_Telephone_Poste via shared members
				/// </summary>
				public sealed class Column_ProducteurID_Telephone_Poste {

					/// <summary>
					/// Returns "ProducteurID_Telephone_Poste"
					/// </summary>
					public const System.String ColumnName = "ProducteurID_Telephone_Poste";
					/// <summary>
					/// Returns 70
					/// </summary>
					public const System.Int32 ColumnIndex = 70;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurID_Telecopieur via shared members
				/// </summary>
				public sealed class Column_ProducteurID_Telecopieur {

					/// <summary>
					/// Returns "ProducteurID_Telecopieur"
					/// </summary>
					public const System.String ColumnName = "ProducteurID_Telecopieur";
					/// <summary>
					/// Returns 71
					/// </summary>
					public const System.Int32 ColumnIndex = 71;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurID_Telephone2 via shared members
				/// </summary>
				public sealed class Column_ProducteurID_Telephone2 {

					/// <summary>
					/// Returns "ProducteurID_Telephone2"
					/// </summary>
					public const System.String ColumnName = "ProducteurID_Telephone2";
					/// <summary>
					/// Returns 72
					/// </summary>
					public const System.Int32 ColumnIndex = 72;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurID_Telephone2_Desc via shared members
				/// </summary>
				public sealed class Column_ProducteurID_Telephone2_Desc {

					/// <summary>
					/// Returns "ProducteurID_Telephone2_Desc"
					/// </summary>
					public const System.String ColumnName = "ProducteurID_Telephone2_Desc";
					/// <summary>
					/// Returns 73
					/// </summary>
					public const System.Int32 ColumnIndex = 73;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurID_Telephone2_Poste via shared members
				/// </summary>
				public sealed class Column_ProducteurID_Telephone2_Poste {

					/// <summary>
					/// Returns "ProducteurID_Telephone2_Poste"
					/// </summary>
					public const System.String ColumnName = "ProducteurID_Telephone2_Poste";
					/// <summary>
					/// Returns 74
					/// </summary>
					public const System.Int32 ColumnIndex = 74;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurID_Telephone3 via shared members
				/// </summary>
				public sealed class Column_ProducteurID_Telephone3 {

					/// <summary>
					/// Returns "ProducteurID_Telephone3"
					/// </summary>
					public const System.String ColumnName = "ProducteurID_Telephone3";
					/// <summary>
					/// Returns 75
					/// </summary>
					public const System.Int32 ColumnIndex = 75;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurID_Telephone3_Desc via shared members
				/// </summary>
				public sealed class Column_ProducteurID_Telephone3_Desc {

					/// <summary>
					/// Returns "ProducteurID_Telephone3_Desc"
					/// </summary>
					public const System.String ColumnName = "ProducteurID_Telephone3_Desc";
					/// <summary>
					/// Returns 76
					/// </summary>
					public const System.Int32 ColumnIndex = 76;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurID_Telephone3_Poste via shared members
				/// </summary>
				public sealed class Column_ProducteurID_Telephone3_Poste {

					/// <summary>
					/// Returns "ProducteurID_Telephone3_Poste"
					/// </summary>
					public const System.String ColumnName = "ProducteurID_Telephone3_Poste";
					/// <summary>
					/// Returns 77
					/// </summary>
					public const System.Int32 ColumnIndex = 77;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurID_No_membre via shared members
				/// </summary>
				public sealed class Column_ProducteurID_No_membre {

					/// <summary>
					/// Returns "ProducteurID_No_membre"
					/// </summary>
					public const System.String ColumnName = "ProducteurID_No_membre";
					/// <summary>
					/// Returns 78
					/// </summary>
					public const System.Int32 ColumnIndex = 78;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurID_Resident via shared members
				/// </summary>
				public sealed class Column_ProducteurID_Resident {

					/// <summary>
					/// Returns "ProducteurID_Resident"
					/// </summary>
					public const System.String ColumnName = "ProducteurID_Resident";
					/// <summary>
					/// Returns 79
					/// </summary>
					public const System.Int32 ColumnIndex = 79;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurID_Email via shared members
				/// </summary>
				public sealed class Column_ProducteurID_Email {

					/// <summary>
					/// Returns "ProducteurID_Email"
					/// </summary>
					public const System.String ColumnName = "ProducteurID_Email";
					/// <summary>
					/// Returns 80
					/// </summary>
					public const System.Int32 ColumnIndex = 80;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurID_WWW via shared members
				/// </summary>
				public sealed class Column_ProducteurID_WWW {

					/// <summary>
					/// Returns "ProducteurID_WWW"
					/// </summary>
					public const System.String ColumnName = "ProducteurID_WWW";
					/// <summary>
					/// Returns 81
					/// </summary>
					public const System.Int32 ColumnIndex = 81;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurID_Commentaires via shared members
				/// </summary>
				public sealed class Column_ProducteurID_Commentaires {

					/// <summary>
					/// Returns "ProducteurID_Commentaires"
					/// </summary>
					public const System.String ColumnName = "ProducteurID_Commentaires";
					/// <summary>
					/// Returns 82
					/// </summary>
					public const System.Int32 ColumnIndex = 82;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurID_AfficherCommentaires via shared members
				/// </summary>
				public sealed class Column_ProducteurID_AfficherCommentaires {

					/// <summary>
					/// Returns "ProducteurID_AfficherCommentaires"
					/// </summary>
					public const System.String ColumnName = "ProducteurID_AfficherCommentaires";
					/// <summary>
					/// Returns 83
					/// </summary>
					public const System.Int32 ColumnIndex = 83;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurID_DepotDirect via shared members
				/// </summary>
				public sealed class Column_ProducteurID_DepotDirect {

					/// <summary>
					/// Returns "ProducteurID_DepotDirect"
					/// </summary>
					public const System.String ColumnName = "ProducteurID_DepotDirect";
					/// <summary>
					/// Returns 84
					/// </summary>
					public const System.Int32 ColumnIndex = 84;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurID_InstitutionBanquaireID via shared members
				/// </summary>
				public sealed class Column_ProducteurID_InstitutionBanquaireID {

					/// <summary>
					/// Returns "ProducteurID_InstitutionBanquaireID"
					/// </summary>
					public const System.String ColumnName = "ProducteurID_InstitutionBanquaireID";
					/// <summary>
					/// Returns 85
					/// </summary>
					public const System.Int32 ColumnIndex = 85;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurID_Banque_transit via shared members
				/// </summary>
				public sealed class Column_ProducteurID_Banque_transit {

					/// <summary>
					/// Returns "ProducteurID_Banque_transit"
					/// </summary>
					public const System.String ColumnName = "ProducteurID_Banque_transit";
					/// <summary>
					/// Returns 86
					/// </summary>
					public const System.Int32 ColumnIndex = 86;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurID_Banque_folio via shared members
				/// </summary>
				public sealed class Column_ProducteurID_Banque_folio {

					/// <summary>
					/// Returns "ProducteurID_Banque_folio"
					/// </summary>
					public const System.String ColumnName = "ProducteurID_Banque_folio";
					/// <summary>
					/// Returns 87
					/// </summary>
					public const System.Int32 ColumnIndex = 87;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurID_No_TPS via shared members
				/// </summary>
				public sealed class Column_ProducteurID_No_TPS {

					/// <summary>
					/// Returns "ProducteurID_No_TPS"
					/// </summary>
					public const System.String ColumnName = "ProducteurID_No_TPS";
					/// <summary>
					/// Returns 88
					/// </summary>
					public const System.Int32 ColumnIndex = 88;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurID_No_TVQ via shared members
				/// </summary>
				public sealed class Column_ProducteurID_No_TVQ {

					/// <summary>
					/// Returns "ProducteurID_No_TVQ"
					/// </summary>
					public const System.String ColumnName = "ProducteurID_No_TVQ";
					/// <summary>
					/// Returns 89
					/// </summary>
					public const System.Int32 ColumnIndex = 89;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurID_PayerA via shared members
				/// </summary>
				public sealed class Column_ProducteurID_PayerA {

					/// <summary>
					/// Returns "ProducteurID_PayerA"
					/// </summary>
					public const System.String ColumnName = "ProducteurID_PayerA";
					/// <summary>
					/// Returns 90
					/// </summary>
					public const System.Int32 ColumnIndex = 90;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurID_PayerAID via shared members
				/// </summary>
				public sealed class Column_ProducteurID_PayerAID {

					/// <summary>
					/// Returns "ProducteurID_PayerAID"
					/// </summary>
					public const System.String ColumnName = "ProducteurID_PayerAID";
					/// <summary>
					/// Returns 91
					/// </summary>
					public const System.Int32 ColumnIndex = 91;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurID_Statut via shared members
				/// </summary>
				public sealed class Column_ProducteurID_Statut {

					/// <summary>
					/// Returns "ProducteurID_Statut"
					/// </summary>
					public const System.String ColumnName = "ProducteurID_Statut";
					/// <summary>
					/// Returns 92
					/// </summary>
					public const System.Int32 ColumnIndex = 92;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurID_Rep_Nom via shared members
				/// </summary>
				public sealed class Column_ProducteurID_Rep_Nom {

					/// <summary>
					/// Returns "ProducteurID_Rep_Nom"
					/// </summary>
					public const System.String ColumnName = "ProducteurID_Rep_Nom";
					/// <summary>
					/// Returns 93
					/// </summary>
					public const System.Int32 ColumnIndex = 93;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurID_Rep_Telephone via shared members
				/// </summary>
				public sealed class Column_ProducteurID_Rep_Telephone {

					/// <summary>
					/// Returns "ProducteurID_Rep_Telephone"
					/// </summary>
					public const System.String ColumnName = "ProducteurID_Rep_Telephone";
					/// <summary>
					/// Returns 94
					/// </summary>
					public const System.Int32 ColumnIndex = 94;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurID_Rep_Telephone_Poste via shared members
				/// </summary>
				public sealed class Column_ProducteurID_Rep_Telephone_Poste {

					/// <summary>
					/// Returns "ProducteurID_Rep_Telephone_Poste"
					/// </summary>
					public const System.String ColumnName = "ProducteurID_Rep_Telephone_Poste";
					/// <summary>
					/// Returns 95
					/// </summary>
					public const System.Int32 ColumnIndex = 95;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurID_Rep_Email via shared members
				/// </summary>
				public sealed class Column_ProducteurID_Rep_Email {

					/// <summary>
					/// Returns "ProducteurID_Rep_Email"
					/// </summary>
					public const System.String ColumnName = "ProducteurID_Rep_Email";
					/// <summary>
					/// Returns 96
					/// </summary>
					public const System.Int32 ColumnIndex = 96;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurID_EnAnglais via shared members
				/// </summary>
				public sealed class Column_ProducteurID_EnAnglais {

					/// <summary>
					/// Returns "ProducteurID_EnAnglais"
					/// </summary>
					public const System.String ColumnName = "ProducteurID_EnAnglais";
					/// <summary>
					/// Returns 97
					/// </summary>
					public const System.Int32 ColumnIndex = 97;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurID_Actif via shared members
				/// </summary>
				public sealed class Column_ProducteurID_Actif {

					/// <summary>
					/// Returns "ProducteurID_Actif"
					/// </summary>
					public const System.String ColumnName = "ProducteurID_Actif";
					/// <summary>
					/// Returns 98
					/// </summary>
					public const System.Int32 ColumnIndex = 98;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurID_MRCProducteurID via shared members
				/// </summary>
				public sealed class Column_ProducteurID_MRCProducteurID {

					/// <summary>
					/// Returns "ProducteurID_MRCProducteurID"
					/// </summary>
					public const System.String ColumnName = "ProducteurID_MRCProducteurID";
					/// <summary>
					/// Returns 99
					/// </summary>
					public const System.Int32 ColumnIndex = 99;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurID_PaiementManuel via shared members
				/// </summary>
				public sealed class Column_ProducteurID_PaiementManuel {

					/// <summary>
					/// Returns "ProducteurID_PaiementManuel"
					/// </summary>
					public const System.String ColumnName = "ProducteurID_PaiementManuel";
					/// <summary>
					/// Returns 100
					/// </summary>
					public const System.Int32 ColumnIndex = 100;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurID_Journal via shared members
				/// </summary>
				public sealed class Column_ProducteurID_Journal {

					/// <summary>
					/// Returns "ProducteurID_Journal"
					/// </summary>
					public const System.String ColumnName = "ProducteurID_Journal";
					/// <summary>
					/// Returns 101
					/// </summary>
					public const System.Int32 ColumnIndex = 101;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurID_RecoitTPS via shared members
				/// </summary>
				public sealed class Column_ProducteurID_RecoitTPS {

					/// <summary>
					/// Returns "ProducteurID_RecoitTPS"
					/// </summary>
					public const System.String ColumnName = "ProducteurID_RecoitTPS";
					/// <summary>
					/// Returns 102
					/// </summary>
					public const System.Int32 ColumnIndex = 102;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurID_RecoitTVQ via shared members
				/// </summary>
				public sealed class Column_ProducteurID_RecoitTVQ {

					/// <summary>
					/// Returns "ProducteurID_RecoitTVQ"
					/// </summary>
					public const System.String ColumnName = "ProducteurID_RecoitTVQ";
					/// <summary>
					/// Returns 103
					/// </summary>
					public const System.Int32 ColumnIndex = 103;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurID_ModifierTrigger via shared members
				/// </summary>
				public sealed class Column_ProducteurID_ModifierTrigger {

					/// <summary>
					/// Returns "ProducteurID_ModifierTrigger"
					/// </summary>
					public const System.String ColumnName = "ProducteurID_ModifierTrigger";
					/// <summary>
					/// Returns 104
					/// </summary>
					public const System.Int32 ColumnIndex = 104;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurID_IsProducteur via shared members
				/// </summary>
				public sealed class Column_ProducteurID_IsProducteur {

					/// <summary>
					/// Returns "ProducteurID_IsProducteur"
					/// </summary>
					public const System.String ColumnName = "ProducteurID_IsProducteur";
					/// <summary>
					/// Returns 105
					/// </summary>
					public const System.Int32 ColumnIndex = 105;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurID_IsTransporteur via shared members
				/// </summary>
				public sealed class Column_ProducteurID_IsTransporteur {

					/// <summary>
					/// Returns "ProducteurID_IsTransporteur"
					/// </summary>
					public const System.String ColumnName = "ProducteurID_IsTransporteur";
					/// <summary>
					/// Returns 106
					/// </summary>
					public const System.Int32 ColumnIndex = 106;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurID_IsChargeur via shared members
				/// </summary>
				public sealed class Column_ProducteurID_IsChargeur {

					/// <summary>
					/// Returns "ProducteurID_IsChargeur"
					/// </summary>
					public const System.String ColumnName = "ProducteurID_IsChargeur";
					/// <summary>
					/// Returns 107
					/// </summary>
					public const System.Int32 ColumnIndex = 107;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurID_IsAutre via shared members
				/// </summary>
				public sealed class Column_ProducteurID_IsAutre {

					/// <summary>
					/// Returns "ProducteurID_IsAutre"
					/// </summary>
					public const System.String ColumnName = "ProducteurID_IsAutre";
					/// <summary>
					/// Returns 108
					/// </summary>
					public const System.Int32 ColumnIndex = 108;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurID_AfficherCommentairesSurPermit via shared members
				/// </summary>
				public sealed class Column_ProducteurID_AfficherCommentairesSurPermit {

					/// <summary>
					/// Returns "ProducteurID_AfficherCommentairesSurPermit"
					/// </summary>
					public const System.String ColumnName = "ProducteurID_AfficherCommentairesSurPermit";
					/// <summary>
					/// Returns 109
					/// </summary>
					public const System.Int32 ColumnIndex = 109;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurID_PasEmissionPermis via shared members
				/// </summary>
				public sealed class Column_ProducteurID_PasEmissionPermis {

					/// <summary>
					/// Returns "ProducteurID_PasEmissionPermis"
					/// </summary>
					public const System.String ColumnName = "ProducteurID_PasEmissionPermis";
					/// <summary>
					/// Returns 110
					/// </summary>
					public const System.Int32 ColumnIndex = 110;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ProducteurID_Generique via shared members
				/// </summary>
				public sealed class Column_ProducteurID_Generique {

					/// <summary>
					/// Returns "ProducteurID_Generique"
					/// </summary>
					public const System.String ColumnName = "ProducteurID_Generique";
					/// <summary>
					/// Returns 111
					/// </summary>
					public const System.Int32 ColumnIndex = 111;

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
					/// Returns 112
					/// </summary>
					public const System.Int32 ColumnIndex = 112;

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
					/// Returns 113
					/// </summary>
					public const System.Int32 ColumnIndex = 113;

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
					/// Returns 114
					/// </summary>
					public const System.Int32 ColumnIndex = 114;

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
					/// Returns 115
					/// </summary>
					public const System.Int32 ColumnIndex = 115;

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
					/// Returns 116
					/// </summary>
					public const System.Int32 ColumnIndex = 116;

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
					/// Returns 117
					/// </summary>
					public const System.Int32 ColumnIndex = 117;

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
					/// Returns 118
					/// </summary>
					public const System.Int32 ColumnIndex = 118;

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
					/// Returns 119
					/// </summary>
					public const System.Int32 ColumnIndex = 119;

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
					/// Returns 120
					/// </summary>
					public const System.Int32 ColumnIndex = 120;

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
					/// Returns 121
					/// </summary>
					public const System.Int32 ColumnIndex = 121;

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
					/// Returns 122
					/// </summary>
					public const System.Int32 ColumnIndex = 122;

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
					/// Returns 123
					/// </summary>
					public const System.Int32 ColumnIndex = 123;

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
					/// Returns 124
					/// </summary>
					public const System.Int32 ColumnIndex = 124;

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
					/// Returns 125
					/// </summary>
					public const System.Int32 ColumnIndex = 125;

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
					/// Returns 126
					/// </summary>
					public const System.Int32 ColumnIndex = 126;

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
					/// Returns 127
					/// </summary>
					public const System.Int32 ColumnIndex = 127;

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
					/// Returns 128
					/// </summary>
					public const System.Int32 ColumnIndex = 128;

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
					/// Returns 129
					/// </summary>
					public const System.Int32 ColumnIndex = 129;

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
					/// Returns 130
					/// </summary>
					public const System.Int32 ColumnIndex = 130;

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
					/// Returns 131
					/// </summary>
					public const System.Int32 ColumnIndex = 131;

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
					/// Returns 132
					/// </summary>
					public const System.Int32 ColumnIndex = 132;

				}

			}
		}

		/// <summary>
		/// This class allows to easily retrieve the name or index of all the fields
		/// of the resulset #2 existing in the Dataset or the SqlDatReader returned by
		/// the Execute method of the 'spS_GestionVolume_Full' class.
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

