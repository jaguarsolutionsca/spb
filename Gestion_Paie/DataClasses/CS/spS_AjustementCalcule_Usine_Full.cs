/*
	This C# source code was automatically generated using:

		SQL Server Centric .NET Code Generator
			v 1.0.1287.20792

			Generation Date: 30/03/2007 9:55:20 AM
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
	/// stored procedure 'spS_AjustementCalcule_Usine_Full'. It allows also to specify specific connection
	/// information such as the ConnectionString to be use, the command time-out and so forth.
	/// </summary>
	[Serializable()]
#if OLYMARS_ATTRIBUTE || OLYMARS_DEBUG
	[OlymarsInformation(DeveloperName="<Developer Name Here>", GeneratedOn="2007/03/30 13:55:20", SqlObjectDependancyName="spS_AjustementCalcule_Usine_Full", SqlObjectDependancyRevision=0)]
#endif
	public sealed class spS_AjustementCalcule_Usine_Full : MarshalByRefObject, IDisposable, IParameter {

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
		/// Initializes a new instance of the spS_AjustementCalcule_Usine_Full class. If you use this constructor version,
		/// not assigning parameter values implies using the parameter default values.
		/// </summary>
		public spS_AjustementCalcule_Usine_Full() : this(true) {

		}

		/// <summary>
		/// Initializes a new instance of the spS_AjustementCalcule_Usine_Full class.
		/// </summary>
		/// <param name="useDefaultValue">If True, this parameter indicates that "not assigning parameter values" implies "using the parameter default values". If False, this parameter indicates that "not assigning parameter values" implies "using the SQL Server Null value".</param>
		public spS_AjustementCalcule_Usine_Full(bool useDefaultValue) {

			this.useDefaultValue = useDefaultValue;

			this.internal_Param_ID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_AjustementID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_EssenceID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_UniteID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_LivraisonDetailID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_UsineID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_FactureID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Code_UseDefaultValue = this.useDefaultValue;
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
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'spS_AjustementCalcule_Usine_Full'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

						throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "spS_AjustementCalcule_Usine_Full", CurrentRevision, OriginalRevision, System.Environment.NewLine));
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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'spS_AjustementCalcule_Usine_Full'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlConnection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "spS_AjustementCalcule_Usine_Full", CurrentRevision, OriginalRevision, System.Environment.NewLine));
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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'spS_AjustementCalcule_Usine_Full'";
				sqlCommand.Transaction = sqlTransaction;

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlTransaction.Connection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "spS_AjustementCalcule_Usine_Full", CurrentRevision, OriginalRevision, System.Environment.NewLine));
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
				this.internal_Param_AjustementID = System.Data.SqlTypes.SqlInt32.Null;
				this.internal_Param_EssenceID = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_UniteID = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_LivraisonDetailID = System.Data.SqlTypes.SqlInt32.Null;
				this.internal_Param_UsineID = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_FactureID = System.Data.SqlTypes.SqlInt32.Null;
				this.internal_Param_Code = System.Data.SqlTypes.SqlString.Null;
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
		~spS_AjustementCalcule_Usine_Full() {

			Dispose(false);
		}

		/// <summary>
		/// Returns the stored procedure name for which this class was built, i.e. 'spS_AjustementCalcule_Usine_Full'.
		/// </summary>
		public string StoredProcedureName {

			get {

				return("spS_AjustementCalcule_Usine_Full");
			}
		}

		private System.Data.SqlTypes.SqlInt32 internal_Param_RETURN_VALUE;

		private System.Data.SqlTypes.SqlInt32 internal_Param_ID;
		internal bool internal_Param_ID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlInt32 internal_Param_AjustementID;
		internal bool internal_Param_AjustementID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_EssenceID;
		internal bool internal_Param_EssenceID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_UniteID;
		internal bool internal_Param_UniteID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlInt32 internal_Param_LivraisonDetailID;
		internal bool internal_Param_LivraisonDetailID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_UsineID;
		internal bool internal_Param_UsineID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlInt32 internal_Param_FactureID;
		internal bool internal_Param_FactureID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_Code;
		internal bool internal_Param_Code_UseDefaultValue = true;

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

			this.internal_Param_AjustementID = System.Data.SqlTypes.SqlInt32.Null;
			this.internal_Param_AjustementID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_EssenceID = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_EssenceID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_UniteID = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_UniteID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_LivraisonDetailID = System.Data.SqlTypes.SqlInt32.Null;
			this.internal_Param_LivraisonDetailID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_UsineID = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_UsineID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_FactureID = System.Data.SqlTypes.SqlInt32.Null;
			this.internal_Param_FactureID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Code = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_Code_UseDefaultValue = this.useDefaultValue;

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
		/// Sets the value of the stored procedure INPUT parameter '@AjustementID'.
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
		/// the parameter default value, consider calling the Param_AjustementID_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlInt32 Param_AjustementID {

			get {

				if (this.internal_Param_AjustementID_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_AjustementID);
			}

			set {

				this.internal_Param_AjustementID_UseDefaultValue = false;
				this.internal_Param_AjustementID = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@AjustementID' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_AjustementID_UseDefaultValue() {

			this.internal_Param_AjustementID_UseDefaultValue = true;
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
		/// Sets the value of the stored procedure INPUT parameter '@UniteID'.
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
		/// the parameter default value, consider calling the Param_UniteID_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_UniteID {

			get {

				if (this.internal_Param_UniteID_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_UniteID);
			}

			set {

				this.internal_Param_UniteID_UseDefaultValue = false;
				this.internal_Param_UniteID = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@UniteID' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_UniteID_UseDefaultValue() {

			this.internal_Param_UniteID_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@LivraisonDetailID'.
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
		/// the parameter default value, consider calling the Param_LivraisonDetailID_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlInt32 Param_LivraisonDetailID {

			get {

				if (this.internal_Param_LivraisonDetailID_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_LivraisonDetailID);
			}

			set {

				this.internal_Param_LivraisonDetailID_UseDefaultValue = false;
				this.internal_Param_LivraisonDetailID = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@LivraisonDetailID' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_LivraisonDetailID_UseDefaultValue() {

			this.internal_Param_LivraisonDetailID_UseDefaultValue = true;
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
		/// Sets the value of the stored procedure INPUT parameter '@Code'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [char](4)
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_Code_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_Code {

			get {

				if (this.internal_Param_Code_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Code);
			}

			set {

				this.internal_Param_Code_UseDefaultValue = false;
				this.internal_Param_Code = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Code' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Code_UseDefaultValue() {

			this.internal_Param_Code_UseDefaultValue = true;
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
	/// This class allows you to execute the 'spS_AjustementCalcule_Usine_Full' stored procedure;
	/// it gives you the ability to:
	/// <list type="bullet">
	/// <item><description>Set all the necessary parameters to execute the stored procedure</description></item>
	/// <item><description>To execute the stored procedure</description></item>
	/// <item><description>To get back after the execution the return value and all the output parameters value</description></item>
	/// </list>
	/// </summary>
#if OLYMARS_ATTRIBUTE || OLYMARS_DEBUG
	[OlymarsInformation(DeveloperName="<Developer Name Here>", GeneratedOn="2007/03/30 13:55:20", SqlObjectDependancyName="spS_AjustementCalcule_Usine_Full", SqlObjectDependancyRevision=0)]
#endif
	public sealed class spS_AjustementCalcule_Usine_Full : MarshalByRefObject, IDisposable {


		private bool throwExceptionOnExecute = false;

		/// <summary>
		/// Initializes a new instance of the spS_AjustementCalcule_Usine_Full class.
		/// By default, no exception will be thrown when you call the Execute method. Instead, a Boolean return status will be returned.
		/// </summary>
		public spS_AjustementCalcule_Usine_Full() : this(false) {

		}

		/// <summary>
		/// Initializes a new instance of the spS_AjustementCalcule_Usine_Full class.
		/// </summary>
		/// <param name="throwExceptionOnExecute">True if an exception has to be thrown if the Execute call fails.</param>
		public spS_AjustementCalcule_Usine_Full(bool throwExceptionOnExecute) {

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
		~spS_AjustementCalcule_Usine_Full() {

			Dispose(false);
		}

		private void ResetParameter(ref Gestion_Paie.DataClasses.Parameters.spS_AjustementCalcule_Usine_Full parameters) {

			parameters.internal_Set_RETURN_VALUE (System.Data.SqlTypes.SqlInt32.Null);
		}

		private bool InitializeConnection(ref Gestion_Paie.DataClasses.Parameters.spS_AjustementCalcule_Usine_Full parameters, out System.Data.SqlClient.SqlCommand sqlCommand, ref bool connectionMustBeClosed) {

			try {

				this.sqlConnection = null;
				sqlCommand = null;
				connectionMustBeClosed = true;

				if (parameters.ConnectionType == ConnectionType.None) {

					throw new InvalidOperationException("No connection information was supplied. Consider calling the 'SetUpConnection' method of the Gestion_Paie.DataClasses.Parameters.spS_AjustementCalcule_Usine_Full object before doing this call.");
				}

				if (parameters.ConnectionType == ConnectionType.SqlConnection && parameters.SqlConnection == null) {

					throw new InvalidOperationException("No connection information was supplied (SqlConnection == null). Consider calling the 'SetUpConnection' method of the Gestion_Paie.DataClasses.Parameters.spS_AjustementCalcule_Usine_Full object before doing this call.");
				}

				if (parameters.ConnectionType == ConnectionType.SqlTransaction && parameters.SqlTransaction== null) {

					throw new InvalidOperationException("No connection information was supplied (SqlTransaction == null). Consider calling the 'SetUpConnection' method of the Gestion_Paie.DataClasses.Parameters.spS_AjustementCalcule_Usine_Full object before doing this call.");
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

							throw new System.InvalidOperationException("No connection information was supplied (ConnectionString == \"\")! (Gestion_Paie.DataClasses.Parameters.spS_AjustementCalcule_Usine_Full)");
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
				sqlCommand.CommandText = "spS_AjustementCalcule_Usine_Full";

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

		private bool DeclareParameters(ref Gestion_Paie.DataClasses.Parameters.spS_AjustementCalcule_Usine_Full parameters, ref System.Data.SqlClient.SqlCommand sqlCommand) {

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

				sqlParameter = new System.Data.SqlClient.SqlParameter("@AjustementID", System.Data.SqlDbType.Int, 4);
				sqlParameter.SourceColumn = "AjustementID";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_AjustementID_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_AjustementID.IsNull) {

					sqlParameter.Value = parameters.Param_AjustementID;
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

				sqlParameter = new System.Data.SqlClient.SqlParameter("@UniteID", System.Data.SqlDbType.VarChar, 6);
				sqlParameter.SourceColumn = "UniteID";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_UniteID_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_UniteID.IsNull) {

					sqlParameter.Value = parameters.Param_UniteID;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@LivraisonDetailID", System.Data.SqlDbType.Int, 4);
				sqlParameter.SourceColumn = "LivraisonDetailID";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_LivraisonDetailID_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_LivraisonDetailID.IsNull) {

					sqlParameter.Value = parameters.Param_LivraisonDetailID;
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

				sqlParameter = new System.Data.SqlClient.SqlParameter("@FactureID", System.Data.SqlDbType.Int, 4);
				sqlParameter.SourceColumn = "FactureID";
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

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Code", System.Data.SqlDbType.Char, 4);
				sqlParameter.SourceColumn = "Code";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Code_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Code.IsNull) {

					sqlParameter.Value = parameters.Param_Code;
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

		private bool RetrieveParameters(ref Gestion_Paie.DataClasses.Parameters.spS_AjustementCalcule_Usine_Full parameters, ref System.Data.SqlClient.SqlCommand sqlCommand) {

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
		/// This method allows you to execute the [spS_AjustementCalcule_Usine_Full] stored procedure and retrieve back the data
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
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.spS_AjustementCalcule_Usine_Full parameters, out System.Data.SqlClient.SqlDataReader sqlDataReader) {

			return(Execute(ref parameters, out sqlDataReader, System.Data.CommandBehavior.Default));
		}

		/// <summary>
		/// This method allows you to execute the [spS_AjustementCalcule_Usine_Full] stored procedure and retrieve back the data
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
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.spS_AjustementCalcule_Usine_Full parameters, out System.Data.SqlClient.SqlDataReader sqlDataReader, System.Data.CommandBehavior commandBehavior) {

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
		/// This method allows you to execute the [spS_AjustementCalcule_Usine_Full] stored procedure and retrieve back the data
		/// populated in a DataSet (System.Data.DataSet).
		/// </summary>
		/// <param name="parameters">
		/// Contains all the necessary information to execute correctly the stored procedure, i.e. 
		/// the database connection to use and all the necessary input parameters to be supplied
		/// for this stored procedure execution. After the execution, this object will allow you
		/// to retrieve back the stored procedure return value and all the output parameters.
		/// </param>
		/// <param name="dataset">
		/// Will be populated with the data after execution. The table based name used will be: 'spS_AjustementCalcule_Usine_Full'.
		/// </param>
		/// <returns>True if the call was successful. Otherwise, it returns False.</returns>
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.spS_AjustementCalcule_Usine_Full parameters, ref System.Data.DataSet dataset) {

			return(Execute(ref parameters, ref dataset, "spS_AjustementCalcule_Usine_Full", -1, -1));
		}

		/// <summary>
		/// This method allows you to execute the [spS_AjustementCalcule_Usine_Full] stored procedure and retrieve back the data
		/// populated in a DataSet (System.Data.DataSet).
		/// </summary>
		/// <param name="parameters">
		/// Contains all the necessary information to execute correctly the stored procedure, i.e. 
		/// the database connection to use and all the necessary input parameters to be supplied
		/// for this stored procedure execution. After the execution, this object will allow you
		/// to retrieve back the stored procedure return value and all the output parameters.
		/// </param>
		/// <param name="dataset">
		/// Will be populated with the data after execution. The table based name used will be: 'spS_AjustementCalcule_Usine_Full'.
		/// </param>
		/// <param name="startRecord">The zero-based record number to start with.</param>
		/// <param name="maxRecords">The maximum number of records to retrieve.</param>
		/// <returns>True if the call was successful. Otherwise, it returns False.</returns>
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.spS_AjustementCalcule_Usine_Full parameters, ref System.Data.DataSet dataset, int startRecord, int maxRecords) {

			return(Execute(ref parameters, ref dataset, "spS_AjustementCalcule_Usine_Full", startRecord, maxRecords));
		}

		/// <summary>
		/// This method allows you to execute the [spS_AjustementCalcule_Usine_Full] stored procedure and retrieve back the data
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
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.spS_AjustementCalcule_Usine_Full parameters, ref System.Data.DataSet dataset, string tableName) {

			return(Execute(ref parameters, ref dataset, tableName, -1, -1));
		}

		/// <summary>
		/// This method allows you to execute the [spS_AjustementCalcule_Usine_Full] stored procedure and retrieve back the data
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
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.spS_AjustementCalcule_Usine_Full parameters, ref System.Data.DataSet dataset, string tableName, int startRecord, int maxRecords) {

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
				dataset.Tables[tableName].Columns["DateCalcul"].Caption = "DateCalcul (update this label in the \"Olymars/ColumnLabel\" extended property of the \"DateCalcul\" column)";
				dataset.Tables[tableName].Columns["AjustementID"].Caption = "AjustementID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"AjustementID\" column)";
				dataset.Tables[tableName].Columns["EssenceID"].Caption = "EssenceID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"EssenceID\" column)";
				dataset.Tables[tableName].Columns["UniteID"].Caption = "UniteID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"UniteID\" column)";
				dataset.Tables[tableName].Columns["LivraisonDetailID"].Caption = "LivraisonDetailID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"LivraisonDetailID\" column)";
				dataset.Tables[tableName].Columns["UsineID"].Caption = "UsineID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"UsineID\" column)";
				dataset.Tables[tableName].Columns["Volume"].Caption = "Volume (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Volume\" column)";
				dataset.Tables[tableName].Columns["Taux"].Caption = "Taux (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Taux\" column)";
				dataset.Tables[tableName].Columns["Montant"].Caption = "Montant (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Montant\" column)";
				dataset.Tables[tableName].Columns["Facture"].Caption = "Facture (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Facture\" column)";
				dataset.Tables[tableName].Columns["FactureID"].Caption = "FactureID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"FactureID\" column)";
				dataset.Tables[tableName].Columns["ErreurCalcul"].Caption = "ErreurCalcul (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ErreurCalcul\" column)";
				dataset.Tables[tableName].Columns["ErreurDescription"].Caption = "ErreurDescription (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ErreurDescription\" column)";
				dataset.Tables[tableName].Columns["Code"].Caption = "Code (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Code\" column)";
				dataset.Tables[tableName].Columns["AjustementID_AjustementID"].Caption = "AjustementID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"AjustementID\" column)";
				dataset.Tables[tableName].Columns["AjustementID_EssenceID"].Caption = "EssenceID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"EssenceID\" column)";
				dataset.Tables[tableName].Columns["AjustementID_UniteID"].Caption = "UniteID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"UniteID\" column)";
				dataset.Tables[tableName].Columns["AjustementID_ContratID"].Caption = "ContratID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ContratID\" column)";
				dataset.Tables[tableName].Columns["AjustementID_Taux_usine"].Caption = "Taux_usine (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Taux_usine\" column)";
				dataset.Tables[tableName].Columns["AjustementID_Taux_producteur"].Caption = "Taux_producteur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Taux_producteur\" column)";
				dataset.Tables[tableName].Columns["AjustementID_Date_Modification"].Caption = "Date_Modification (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Date_Modification\" column)";
				dataset.Tables[tableName].Columns["AjustementID_Code"].Caption = "Code (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Code\" column)";
				dataset.Tables[tableName].Columns["EssenceID_AjustementID"].Caption = "AjustementID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"AjustementID\" column)";
				dataset.Tables[tableName].Columns["EssenceID_EssenceID"].Caption = "EssenceID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"EssenceID\" column)";
				dataset.Tables[tableName].Columns["EssenceID_UniteID"].Caption = "UniteID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"UniteID\" column)";
				dataset.Tables[tableName].Columns["EssenceID_ContratID"].Caption = "ContratID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ContratID\" column)";
				dataset.Tables[tableName].Columns["EssenceID_Taux_usine"].Caption = "Taux_usine (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Taux_usine\" column)";
				dataset.Tables[tableName].Columns["EssenceID_Taux_producteur"].Caption = "Taux_producteur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Taux_producteur\" column)";
				dataset.Tables[tableName].Columns["EssenceID_Date_Modification"].Caption = "Date_Modification (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Date_Modification\" column)";
				dataset.Tables[tableName].Columns["EssenceID_Code"].Caption = "Code (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Code\" column)";
				dataset.Tables[tableName].Columns["UniteID_AjustementID"].Caption = "AjustementID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"AjustementID\" column)";
				dataset.Tables[tableName].Columns["UniteID_EssenceID"].Caption = "EssenceID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"EssenceID\" column)";
				dataset.Tables[tableName].Columns["UniteID_UniteID"].Caption = "UniteID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"UniteID\" column)";
				dataset.Tables[tableName].Columns["UniteID_ContratID"].Caption = "ContratID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ContratID\" column)";
				dataset.Tables[tableName].Columns["UniteID_Taux_usine"].Caption = "Taux_usine (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Taux_usine\" column)";
				dataset.Tables[tableName].Columns["UniteID_Taux_producteur"].Caption = "Taux_producteur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Taux_producteur\" column)";
				dataset.Tables[tableName].Columns["UniteID_Date_Modification"].Caption = "Date_Modification (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Date_Modification\" column)";
				dataset.Tables[tableName].Columns["UniteID_Code"].Caption = "Code (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Code\" column)";
				dataset.Tables[tableName].Columns["LivraisonDetailID_ID"].Caption = "ID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ID\" column)";
				dataset.Tables[tableName].Columns["LivraisonDetailID_LivraisonID"].Caption = "LivraisonID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"LivraisonID\" column)";
				dataset.Tables[tableName].Columns["LivraisonDetailID_ContratID"].Caption = "ContratID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ContratID\" column)";
				dataset.Tables[tableName].Columns["LivraisonDetailID_EssenceID"].Caption = "EssenceID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"EssenceID\" column)";
				dataset.Tables[tableName].Columns["LivraisonDetailID_UniteMesureID"].Caption = "UniteMesureID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"UniteMesureID\" column)";
				dataset.Tables[tableName].Columns["LivraisonDetailID_ProducteurID"].Caption = "ProducteurID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ProducteurID\" column)";
				dataset.Tables[tableName].Columns["LivraisonDetailID_Droit_Coupe"].Caption = "Droit_Coupe (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Droit_Coupe\" column)";
				dataset.Tables[tableName].Columns["LivraisonDetailID_VolumeBrut"].Caption = "VolumeBrut (update this label in the \"Olymars/ColumnLabel\" extended property of the \"VolumeBrut\" column)";
				dataset.Tables[tableName].Columns["LivraisonDetailID_VolumeReduction"].Caption = "VolumeReduction (update this label in the \"Olymars/ColumnLabel\" extended property of the \"VolumeReduction\" column)";
				dataset.Tables[tableName].Columns["LivraisonDetailID_VolumeNet"].Caption = "VolumeNet (update this label in the \"Olymars/ColumnLabel\" extended property of the \"VolumeNet\" column)";
				dataset.Tables[tableName].Columns["LivraisonDetailID_VolumeContingente"].Caption = "VolumeContingente (update this label in the \"Olymars/ColumnLabel\" extended property of the \"VolumeContingente\" column)";
				dataset.Tables[tableName].Columns["LivraisonDetailID_ContingentementID"].Caption = "ContingentementID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ContingentementID\" column)";
				dataset.Tables[tableName].Columns["LivraisonDetailID_DateCalcul"].Caption = "DateCalcul (update this label in the \"Olymars/ColumnLabel\" extended property of the \"DateCalcul\" column)";
				dataset.Tables[tableName].Columns["LivraisonDetailID_Taux_Usine"].Caption = "Taux_Usine (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Taux_Usine\" column)";
				dataset.Tables[tableName].Columns["LivraisonDetailID_Montant_Usine"].Caption = "Montant_Usine (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Montant_Usine\" column)";
				dataset.Tables[tableName].Columns["LivraisonDetailID_Taux_Producteur"].Caption = "Taux_Producteur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Taux_Producteur\" column)";
				dataset.Tables[tableName].Columns["LivraisonDetailID_Montant_ProducteurBrut"].Caption = "Montant_ProducteurBrut (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Montant_ProducteurBrut\" column)";
				dataset.Tables[tableName].Columns["LivraisonDetailID_Taux_TransporteurMoyen"].Caption = "Taux_TransporteurMoyen (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Taux_TransporteurMoyen\" column)";
				dataset.Tables[tableName].Columns["LivraisonDetailID_Taux_TransporteurMoyen_Override"].Caption = "Taux_TransporteurMoyen_Override (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Taux_TransporteurMoyen_Override\" column)";
				dataset.Tables[tableName].Columns["LivraisonDetailID_Montant_TransporteurMoyen"].Caption = "Montant_TransporteurMoyen (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Montant_TransporteurMoyen\" column)";
				dataset.Tables[tableName].Columns["LivraisonDetailID_Taux_Preleve_Plan_Conjoint"].Caption = "Taux_Preleve_Plan_Conjoint (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Taux_Preleve_Plan_Conjoint\" column)";
				dataset.Tables[tableName].Columns["LivraisonDetailID_Montant_Preleve_Plan_Conjoint"].Caption = "Montant_Preleve_Plan_Conjoint (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Montant_Preleve_Plan_Conjoint\" column)";
				dataset.Tables[tableName].Columns["LivraisonDetailID_Taux_Preleve_Fond_Roulement"].Caption = "Taux_Preleve_Fond_Roulement (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Taux_Preleve_Fond_Roulement\" column)";
				dataset.Tables[tableName].Columns["LivraisonDetailID_Montant_Preleve_Fond_Roulement"].Caption = "Montant_Preleve_Fond_Roulement (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Montant_Preleve_Fond_Roulement\" column)";
				dataset.Tables[tableName].Columns["LivraisonDetailID_Taux_Preleve_Fond_Forestier"].Caption = "Taux_Preleve_Fond_Forestier (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Taux_Preleve_Fond_Forestier\" column)";
				dataset.Tables[tableName].Columns["LivraisonDetailID_Montant_Preleve_Fond_Forestier"].Caption = "Montant_Preleve_Fond_Forestier (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Montant_Preleve_Fond_Forestier\" column)";
				dataset.Tables[tableName].Columns["LivraisonDetailID_Taux_Preleve_Divers"].Caption = "Taux_Preleve_Divers (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Taux_Preleve_Divers\" column)";
				dataset.Tables[tableName].Columns["LivraisonDetailID_Montant_Preleve_Divers"].Caption = "Montant_Preleve_Divers (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Montant_Preleve_Divers\" column)";
				dataset.Tables[tableName].Columns["LivraisonDetailID_Montant_ProducteurNet"].Caption = "Montant_ProducteurNet (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Montant_ProducteurNet\" column)";
				dataset.Tables[tableName].Columns["LivraisonDetailID_Taux_Producteur_Override"].Caption = "Taux_Producteur_Override (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Taux_Producteur_Override\" column)";
				dataset.Tables[tableName].Columns["LivraisonDetailID_Taux_Usine_Override"].Caption = "Taux_Usine_Override (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Taux_Usine_Override\" column)";
				dataset.Tables[tableName].Columns["LivraisonDetailID_Code"].Caption = "Code (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Code\" column)";
				dataset.Tables[tableName].Columns["LivraisonDetailID_UsePreleveMontant"].Caption = "UsePreleveMontant (update this label in the \"Olymars/ColumnLabel\" extended property of the \"UsePreleveMontant\" column)";
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
				dataset.Tables[tableName].Columns["FactureID_ID"].Caption = "ID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ID\" column)";
				dataset.Tables[tableName].Columns["FactureID_NoFacture"].Caption = "NoFacture (update this label in the \"Olymars/ColumnLabel\" extended property of the \"NoFacture\" column)";
				dataset.Tables[tableName].Columns["FactureID_DateFacture"].Caption = "DateFacture (update this label in the \"Olymars/ColumnLabel\" extended property of the \"DateFacture\" column)";
				dataset.Tables[tableName].Columns["FactureID_Annee"].Caption = "Annee (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Annee\" column)";
				dataset.Tables[tableName].Columns["FactureID_TypeFacture"].Caption = "TypeFacture (update this label in the \"Olymars/ColumnLabel\" extended property of the \"TypeFacture\" column)";
				dataset.Tables[tableName].Columns["FactureID_TypeInvoiceClientAcomba"].Caption = "TypeInvoiceClientAcomba (update this label in the \"Olymars/ColumnLabel\" extended property of the \"TypeInvoiceClientAcomba\" column)";
				dataset.Tables[tableName].Columns["FactureID_ClientID"].Caption = "ClientID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ClientID\" column)";
				dataset.Tables[tableName].Columns["FactureID_PayerAID"].Caption = "PayerAID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"PayerAID\" column)";
				dataset.Tables[tableName].Columns["FactureID_Montant_Total"].Caption = "Montant_Total (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Montant_Total\" column)";
				dataset.Tables[tableName].Columns["FactureID_Montant_TPS"].Caption = "Montant_TPS (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Montant_TPS\" column)";
				dataset.Tables[tableName].Columns["FactureID_Montant_TVQ"].Caption = "Montant_TVQ (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Montant_TVQ\" column)";
				dataset.Tables[tableName].Columns["FactureID_Description"].Caption = "Description (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Description\" column)";
				dataset.Tables[tableName].Columns["FactureID_Status"].Caption = "Status (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Status\" column)";
				dataset.Tables[tableName].Columns["FactureID_StatusDescription"].Caption = "StatusDescription (update this label in the \"Olymars/ColumnLabel\" extended property of the \"StatusDescription\" column)";
				dataset.Tables[tableName].Columns["FactureID_DateFactureAcomba"].Caption = "DateFactureAcomba (update this label in the \"Olymars/ColumnLabel\" extended property of the \"DateFactureAcomba\" column)";
				dataset.Tables[tableName].Columns["Code_AjustementID"].Caption = "AjustementID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"AjustementID\" column)";
				dataset.Tables[tableName].Columns["Code_EssenceID"].Caption = "EssenceID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"EssenceID\" column)";
				dataset.Tables[tableName].Columns["Code_UniteID"].Caption = "UniteID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"UniteID\" column)";
				dataset.Tables[tableName].Columns["Code_ContratID"].Caption = "ContratID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ContratID\" column)";
				dataset.Tables[tableName].Columns["Code_Taux_usine"].Caption = "Taux_usine (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Taux_usine\" column)";
				dataset.Tables[tableName].Columns["Code_Taux_producteur"].Caption = "Taux_producteur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Taux_producteur\" column)";
				dataset.Tables[tableName].Columns["Code_Date_Modification"].Caption = "Date_Modification (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Date_Modification\" column)";
				dataset.Tables[tableName].Columns["Code_Code"].Caption = "Code (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Code\" column)";

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
		/// This method allows you to execute the [spS_AjustementCalcule_Usine_Full] stored procedure and retrieve back the data
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
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.spS_AjustementCalcule_Usine_Full parameters, ref string xml) {

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
		/// This method allows you to execute the [spS_AjustementCalcule_Usine_Full] stored procedure and retrieve back the data
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
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.spS_AjustementCalcule_Usine_Full parameters, out System.Xml.XmlReader xmlReader) {

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
		/// the Execute method of the 'spS_AjustementCalcule_Usine_Full' class.
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
				/// Allows to get the Index and Name of the field DateCalcul via shared members
				/// </summary>
				public sealed class Column_DateCalcul {

					/// <summary>
					/// Returns "DateCalcul"
					/// </summary>
					public const System.String ColumnName = "DateCalcul";
					/// <summary>
					/// Returns 1
					/// </summary>
					public const System.Int32 ColumnIndex = 1;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field AjustementID via shared members
				/// </summary>
				public sealed class Column_AjustementID {

					/// <summary>
					/// Returns "AjustementID"
					/// </summary>
					public const System.String ColumnName = "AjustementID";
					/// <summary>
					/// Returns 2
					/// </summary>
					public const System.Int32 ColumnIndex = 2;

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
					/// Returns 3
					/// </summary>
					public const System.Int32 ColumnIndex = 3;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field UniteID via shared members
				/// </summary>
				public sealed class Column_UniteID {

					/// <summary>
					/// Returns "UniteID"
					/// </summary>
					public const System.String ColumnName = "UniteID";
					/// <summary>
					/// Returns 4
					/// </summary>
					public const System.Int32 ColumnIndex = 4;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LivraisonDetailID via shared members
				/// </summary>
				public sealed class Column_LivraisonDetailID {

					/// <summary>
					/// Returns "LivraisonDetailID"
					/// </summary>
					public const System.String ColumnName = "LivraisonDetailID";
					/// <summary>
					/// Returns 5
					/// </summary>
					public const System.Int32 ColumnIndex = 5;

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
				/// Allows to get the Index and Name of the field Taux via shared members
				/// </summary>
				public sealed class Column_Taux {

					/// <summary>
					/// Returns "Taux"
					/// </summary>
					public const System.String ColumnName = "Taux";
					/// <summary>
					/// Returns 8
					/// </summary>
					public const System.Int32 ColumnIndex = 8;

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
					/// Returns 9
					/// </summary>
					public const System.Int32 ColumnIndex = 9;

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
					/// Returns 10
					/// </summary>
					public const System.Int32 ColumnIndex = 10;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field FactureID via shared members
				/// </summary>
				public sealed class Column_FactureID {

					/// <summary>
					/// Returns "FactureID"
					/// </summary>
					public const System.String ColumnName = "FactureID";
					/// <summary>
					/// Returns 11
					/// </summary>
					public const System.Int32 ColumnIndex = 11;

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
					/// Returns 12
					/// </summary>
					public const System.Int32 ColumnIndex = 12;

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
					/// Returns 13
					/// </summary>
					public const System.Int32 ColumnIndex = 13;

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
					/// Returns 14
					/// </summary>
					public const System.Int32 ColumnIndex = 14;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field AjustementID_AjustementID via shared members
				/// </summary>
				public sealed class Column_AjustementID_AjustementID {

					/// <summary>
					/// Returns "AjustementID_AjustementID"
					/// </summary>
					public const System.String ColumnName = "AjustementID_AjustementID";
					/// <summary>
					/// Returns 15
					/// </summary>
					public const System.Int32 ColumnIndex = 15;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field AjustementID_EssenceID via shared members
				/// </summary>
				public sealed class Column_AjustementID_EssenceID {

					/// <summary>
					/// Returns "AjustementID_EssenceID"
					/// </summary>
					public const System.String ColumnName = "AjustementID_EssenceID";
					/// <summary>
					/// Returns 16
					/// </summary>
					public const System.Int32 ColumnIndex = 16;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field AjustementID_UniteID via shared members
				/// </summary>
				public sealed class Column_AjustementID_UniteID {

					/// <summary>
					/// Returns "AjustementID_UniteID"
					/// </summary>
					public const System.String ColumnName = "AjustementID_UniteID";
					/// <summary>
					/// Returns 17
					/// </summary>
					public const System.Int32 ColumnIndex = 17;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field AjustementID_ContratID via shared members
				/// </summary>
				public sealed class Column_AjustementID_ContratID {

					/// <summary>
					/// Returns "AjustementID_ContratID"
					/// </summary>
					public const System.String ColumnName = "AjustementID_ContratID";
					/// <summary>
					/// Returns 18
					/// </summary>
					public const System.Int32 ColumnIndex = 18;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field AjustementID_Taux_usine via shared members
				/// </summary>
				public sealed class Column_AjustementID_Taux_usine {

					/// <summary>
					/// Returns "AjustementID_Taux_usine"
					/// </summary>
					public const System.String ColumnName = "AjustementID_Taux_usine";
					/// <summary>
					/// Returns 19
					/// </summary>
					public const System.Int32 ColumnIndex = 19;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field AjustementID_Taux_producteur via shared members
				/// </summary>
				public sealed class Column_AjustementID_Taux_producteur {

					/// <summary>
					/// Returns "AjustementID_Taux_producteur"
					/// </summary>
					public const System.String ColumnName = "AjustementID_Taux_producteur";
					/// <summary>
					/// Returns 20
					/// </summary>
					public const System.Int32 ColumnIndex = 20;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field AjustementID_Date_Modification via shared members
				/// </summary>
				public sealed class Column_AjustementID_Date_Modification {

					/// <summary>
					/// Returns "AjustementID_Date_Modification"
					/// </summary>
					public const System.String ColumnName = "AjustementID_Date_Modification";
					/// <summary>
					/// Returns 21
					/// </summary>
					public const System.Int32 ColumnIndex = 21;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field AjustementID_Code via shared members
				/// </summary>
				public sealed class Column_AjustementID_Code {

					/// <summary>
					/// Returns "AjustementID_Code"
					/// </summary>
					public const System.String ColumnName = "AjustementID_Code";
					/// <summary>
					/// Returns 22
					/// </summary>
					public const System.Int32 ColumnIndex = 22;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field EssenceID_AjustementID via shared members
				/// </summary>
				public sealed class Column_EssenceID_AjustementID {

					/// <summary>
					/// Returns "EssenceID_AjustementID"
					/// </summary>
					public const System.String ColumnName = "EssenceID_AjustementID";
					/// <summary>
					/// Returns 23
					/// </summary>
					public const System.Int32 ColumnIndex = 23;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field EssenceID_EssenceID via shared members
				/// </summary>
				public sealed class Column_EssenceID_EssenceID {

					/// <summary>
					/// Returns "EssenceID_EssenceID"
					/// </summary>
					public const System.String ColumnName = "EssenceID_EssenceID";
					/// <summary>
					/// Returns 24
					/// </summary>
					public const System.Int32 ColumnIndex = 24;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field EssenceID_UniteID via shared members
				/// </summary>
				public sealed class Column_EssenceID_UniteID {

					/// <summary>
					/// Returns "EssenceID_UniteID"
					/// </summary>
					public const System.String ColumnName = "EssenceID_UniteID";
					/// <summary>
					/// Returns 25
					/// </summary>
					public const System.Int32 ColumnIndex = 25;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field EssenceID_ContratID via shared members
				/// </summary>
				public sealed class Column_EssenceID_ContratID {

					/// <summary>
					/// Returns "EssenceID_ContratID"
					/// </summary>
					public const System.String ColumnName = "EssenceID_ContratID";
					/// <summary>
					/// Returns 26
					/// </summary>
					public const System.Int32 ColumnIndex = 26;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field EssenceID_Taux_usine via shared members
				/// </summary>
				public sealed class Column_EssenceID_Taux_usine {

					/// <summary>
					/// Returns "EssenceID_Taux_usine"
					/// </summary>
					public const System.String ColumnName = "EssenceID_Taux_usine";
					/// <summary>
					/// Returns 27
					/// </summary>
					public const System.Int32 ColumnIndex = 27;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field EssenceID_Taux_producteur via shared members
				/// </summary>
				public sealed class Column_EssenceID_Taux_producteur {

					/// <summary>
					/// Returns "EssenceID_Taux_producteur"
					/// </summary>
					public const System.String ColumnName = "EssenceID_Taux_producteur";
					/// <summary>
					/// Returns 28
					/// </summary>
					public const System.Int32 ColumnIndex = 28;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field EssenceID_Date_Modification via shared members
				/// </summary>
				public sealed class Column_EssenceID_Date_Modification {

					/// <summary>
					/// Returns "EssenceID_Date_Modification"
					/// </summary>
					public const System.String ColumnName = "EssenceID_Date_Modification";
					/// <summary>
					/// Returns 29
					/// </summary>
					public const System.Int32 ColumnIndex = 29;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field EssenceID_Code via shared members
				/// </summary>
				public sealed class Column_EssenceID_Code {

					/// <summary>
					/// Returns "EssenceID_Code"
					/// </summary>
					public const System.String ColumnName = "EssenceID_Code";
					/// <summary>
					/// Returns 30
					/// </summary>
					public const System.Int32 ColumnIndex = 30;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field UniteID_AjustementID via shared members
				/// </summary>
				public sealed class Column_UniteID_AjustementID {

					/// <summary>
					/// Returns "UniteID_AjustementID"
					/// </summary>
					public const System.String ColumnName = "UniteID_AjustementID";
					/// <summary>
					/// Returns 31
					/// </summary>
					public const System.Int32 ColumnIndex = 31;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field UniteID_EssenceID via shared members
				/// </summary>
				public sealed class Column_UniteID_EssenceID {

					/// <summary>
					/// Returns "UniteID_EssenceID"
					/// </summary>
					public const System.String ColumnName = "UniteID_EssenceID";
					/// <summary>
					/// Returns 32
					/// </summary>
					public const System.Int32 ColumnIndex = 32;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field UniteID_UniteID via shared members
				/// </summary>
				public sealed class Column_UniteID_UniteID {

					/// <summary>
					/// Returns "UniteID_UniteID"
					/// </summary>
					public const System.String ColumnName = "UniteID_UniteID";
					/// <summary>
					/// Returns 33
					/// </summary>
					public const System.Int32 ColumnIndex = 33;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field UniteID_ContratID via shared members
				/// </summary>
				public sealed class Column_UniteID_ContratID {

					/// <summary>
					/// Returns "UniteID_ContratID"
					/// </summary>
					public const System.String ColumnName = "UniteID_ContratID";
					/// <summary>
					/// Returns 34
					/// </summary>
					public const System.Int32 ColumnIndex = 34;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field UniteID_Taux_usine via shared members
				/// </summary>
				public sealed class Column_UniteID_Taux_usine {

					/// <summary>
					/// Returns "UniteID_Taux_usine"
					/// </summary>
					public const System.String ColumnName = "UniteID_Taux_usine";
					/// <summary>
					/// Returns 35
					/// </summary>
					public const System.Int32 ColumnIndex = 35;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field UniteID_Taux_producteur via shared members
				/// </summary>
				public sealed class Column_UniteID_Taux_producteur {

					/// <summary>
					/// Returns "UniteID_Taux_producteur"
					/// </summary>
					public const System.String ColumnName = "UniteID_Taux_producteur";
					/// <summary>
					/// Returns 36
					/// </summary>
					public const System.Int32 ColumnIndex = 36;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field UniteID_Date_Modification via shared members
				/// </summary>
				public sealed class Column_UniteID_Date_Modification {

					/// <summary>
					/// Returns "UniteID_Date_Modification"
					/// </summary>
					public const System.String ColumnName = "UniteID_Date_Modification";
					/// <summary>
					/// Returns 37
					/// </summary>
					public const System.Int32 ColumnIndex = 37;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field UniteID_Code via shared members
				/// </summary>
				public sealed class Column_UniteID_Code {

					/// <summary>
					/// Returns "UniteID_Code"
					/// </summary>
					public const System.String ColumnName = "UniteID_Code";
					/// <summary>
					/// Returns 38
					/// </summary>
					public const System.Int32 ColumnIndex = 38;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LivraisonDetailID_ID via shared members
				/// </summary>
				public sealed class Column_LivraisonDetailID_ID {

					/// <summary>
					/// Returns "LivraisonDetailID_ID"
					/// </summary>
					public const System.String ColumnName = "LivraisonDetailID_ID";
					/// <summary>
					/// Returns 39
					/// </summary>
					public const System.Int32 ColumnIndex = 39;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LivraisonDetailID_LivraisonID via shared members
				/// </summary>
				public sealed class Column_LivraisonDetailID_LivraisonID {

					/// <summary>
					/// Returns "LivraisonDetailID_LivraisonID"
					/// </summary>
					public const System.String ColumnName = "LivraisonDetailID_LivraisonID";
					/// <summary>
					/// Returns 40
					/// </summary>
					public const System.Int32 ColumnIndex = 40;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LivraisonDetailID_ContratID via shared members
				/// </summary>
				public sealed class Column_LivraisonDetailID_ContratID {

					/// <summary>
					/// Returns "LivraisonDetailID_ContratID"
					/// </summary>
					public const System.String ColumnName = "LivraisonDetailID_ContratID";
					/// <summary>
					/// Returns 41
					/// </summary>
					public const System.Int32 ColumnIndex = 41;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LivraisonDetailID_EssenceID via shared members
				/// </summary>
				public sealed class Column_LivraisonDetailID_EssenceID {

					/// <summary>
					/// Returns "LivraisonDetailID_EssenceID"
					/// </summary>
					public const System.String ColumnName = "LivraisonDetailID_EssenceID";
					/// <summary>
					/// Returns 42
					/// </summary>
					public const System.Int32 ColumnIndex = 42;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LivraisonDetailID_UniteMesureID via shared members
				/// </summary>
				public sealed class Column_LivraisonDetailID_UniteMesureID {

					/// <summary>
					/// Returns "LivraisonDetailID_UniteMesureID"
					/// </summary>
					public const System.String ColumnName = "LivraisonDetailID_UniteMesureID";
					/// <summary>
					/// Returns 43
					/// </summary>
					public const System.Int32 ColumnIndex = 43;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LivraisonDetailID_ProducteurID via shared members
				/// </summary>
				public sealed class Column_LivraisonDetailID_ProducteurID {

					/// <summary>
					/// Returns "LivraisonDetailID_ProducteurID"
					/// </summary>
					public const System.String ColumnName = "LivraisonDetailID_ProducteurID";
					/// <summary>
					/// Returns 44
					/// </summary>
					public const System.Int32 ColumnIndex = 44;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LivraisonDetailID_Droit_Coupe via shared members
				/// </summary>
				public sealed class Column_LivraisonDetailID_Droit_Coupe {

					/// <summary>
					/// Returns "LivraisonDetailID_Droit_Coupe"
					/// </summary>
					public const System.String ColumnName = "LivraisonDetailID_Droit_Coupe";
					/// <summary>
					/// Returns 45
					/// </summary>
					public const System.Int32 ColumnIndex = 45;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LivraisonDetailID_VolumeBrut via shared members
				/// </summary>
				public sealed class Column_LivraisonDetailID_VolumeBrut {

					/// <summary>
					/// Returns "LivraisonDetailID_VolumeBrut"
					/// </summary>
					public const System.String ColumnName = "LivraisonDetailID_VolumeBrut";
					/// <summary>
					/// Returns 46
					/// </summary>
					public const System.Int32 ColumnIndex = 46;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LivraisonDetailID_VolumeReduction via shared members
				/// </summary>
				public sealed class Column_LivraisonDetailID_VolumeReduction {

					/// <summary>
					/// Returns "LivraisonDetailID_VolumeReduction"
					/// </summary>
					public const System.String ColumnName = "LivraisonDetailID_VolumeReduction";
					/// <summary>
					/// Returns 47
					/// </summary>
					public const System.Int32 ColumnIndex = 47;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LivraisonDetailID_VolumeNet via shared members
				/// </summary>
				public sealed class Column_LivraisonDetailID_VolumeNet {

					/// <summary>
					/// Returns "LivraisonDetailID_VolumeNet"
					/// </summary>
					public const System.String ColumnName = "LivraisonDetailID_VolumeNet";
					/// <summary>
					/// Returns 48
					/// </summary>
					public const System.Int32 ColumnIndex = 48;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LivraisonDetailID_VolumeContingente via shared members
				/// </summary>
				public sealed class Column_LivraisonDetailID_VolumeContingente {

					/// <summary>
					/// Returns "LivraisonDetailID_VolumeContingente"
					/// </summary>
					public const System.String ColumnName = "LivraisonDetailID_VolumeContingente";
					/// <summary>
					/// Returns 49
					/// </summary>
					public const System.Int32 ColumnIndex = 49;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LivraisonDetailID_ContingentementID via shared members
				/// </summary>
				public sealed class Column_LivraisonDetailID_ContingentementID {

					/// <summary>
					/// Returns "LivraisonDetailID_ContingentementID"
					/// </summary>
					public const System.String ColumnName = "LivraisonDetailID_ContingentementID";
					/// <summary>
					/// Returns 50
					/// </summary>
					public const System.Int32 ColumnIndex = 50;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LivraisonDetailID_DateCalcul via shared members
				/// </summary>
				public sealed class Column_LivraisonDetailID_DateCalcul {

					/// <summary>
					/// Returns "LivraisonDetailID_DateCalcul"
					/// </summary>
					public const System.String ColumnName = "LivraisonDetailID_DateCalcul";
					/// <summary>
					/// Returns 51
					/// </summary>
					public const System.Int32 ColumnIndex = 51;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LivraisonDetailID_Taux_Usine via shared members
				/// </summary>
				public sealed class Column_LivraisonDetailID_Taux_Usine {

					/// <summary>
					/// Returns "LivraisonDetailID_Taux_Usine"
					/// </summary>
					public const System.String ColumnName = "LivraisonDetailID_Taux_Usine";
					/// <summary>
					/// Returns 52
					/// </summary>
					public const System.Int32 ColumnIndex = 52;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LivraisonDetailID_Montant_Usine via shared members
				/// </summary>
				public sealed class Column_LivraisonDetailID_Montant_Usine {

					/// <summary>
					/// Returns "LivraisonDetailID_Montant_Usine"
					/// </summary>
					public const System.String ColumnName = "LivraisonDetailID_Montant_Usine";
					/// <summary>
					/// Returns 53
					/// </summary>
					public const System.Int32 ColumnIndex = 53;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LivraisonDetailID_Taux_Producteur via shared members
				/// </summary>
				public sealed class Column_LivraisonDetailID_Taux_Producteur {

					/// <summary>
					/// Returns "LivraisonDetailID_Taux_Producteur"
					/// </summary>
					public const System.String ColumnName = "LivraisonDetailID_Taux_Producteur";
					/// <summary>
					/// Returns 54
					/// </summary>
					public const System.Int32 ColumnIndex = 54;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LivraisonDetailID_Montant_ProducteurBrut via shared members
				/// </summary>
				public sealed class Column_LivraisonDetailID_Montant_ProducteurBrut {

					/// <summary>
					/// Returns "LivraisonDetailID_Montant_ProducteurBrut"
					/// </summary>
					public const System.String ColumnName = "LivraisonDetailID_Montant_ProducteurBrut";
					/// <summary>
					/// Returns 55
					/// </summary>
					public const System.Int32 ColumnIndex = 55;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LivraisonDetailID_Taux_TransporteurMoyen via shared members
				/// </summary>
				public sealed class Column_LivraisonDetailID_Taux_TransporteurMoyen {

					/// <summary>
					/// Returns "LivraisonDetailID_Taux_TransporteurMoyen"
					/// </summary>
					public const System.String ColumnName = "LivraisonDetailID_Taux_TransporteurMoyen";
					/// <summary>
					/// Returns 56
					/// </summary>
					public const System.Int32 ColumnIndex = 56;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LivraisonDetailID_Taux_TransporteurMoyen_Override via shared members
				/// </summary>
				public sealed class Column_LivraisonDetailID_Taux_TransporteurMoyen_Override {

					/// <summary>
					/// Returns "LivraisonDetailID_Taux_TransporteurMoyen_Override"
					/// </summary>
					public const System.String ColumnName = "LivraisonDetailID_Taux_TransporteurMoyen_Override";
					/// <summary>
					/// Returns 57
					/// </summary>
					public const System.Int32 ColumnIndex = 57;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LivraisonDetailID_Montant_TransporteurMoyen via shared members
				/// </summary>
				public sealed class Column_LivraisonDetailID_Montant_TransporteurMoyen {

					/// <summary>
					/// Returns "LivraisonDetailID_Montant_TransporteurMoyen"
					/// </summary>
					public const System.String ColumnName = "LivraisonDetailID_Montant_TransporteurMoyen";
					/// <summary>
					/// Returns 58
					/// </summary>
					public const System.Int32 ColumnIndex = 58;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LivraisonDetailID_Taux_Preleve_Plan_Conjoint via shared members
				/// </summary>
				public sealed class Column_LivraisonDetailID_Taux_Preleve_Plan_Conjoint {

					/// <summary>
					/// Returns "LivraisonDetailID_Taux_Preleve_Plan_Conjoint"
					/// </summary>
					public const System.String ColumnName = "LivraisonDetailID_Taux_Preleve_Plan_Conjoint";
					/// <summary>
					/// Returns 59
					/// </summary>
					public const System.Int32 ColumnIndex = 59;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LivraisonDetailID_Montant_Preleve_Plan_Conjoint via shared members
				/// </summary>
				public sealed class Column_LivraisonDetailID_Montant_Preleve_Plan_Conjoint {

					/// <summary>
					/// Returns "LivraisonDetailID_Montant_Preleve_Plan_Conjoint"
					/// </summary>
					public const System.String ColumnName = "LivraisonDetailID_Montant_Preleve_Plan_Conjoint";
					/// <summary>
					/// Returns 60
					/// </summary>
					public const System.Int32 ColumnIndex = 60;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LivraisonDetailID_Taux_Preleve_Fond_Roulement via shared members
				/// </summary>
				public sealed class Column_LivraisonDetailID_Taux_Preleve_Fond_Roulement {

					/// <summary>
					/// Returns "LivraisonDetailID_Taux_Preleve_Fond_Roulement"
					/// </summary>
					public const System.String ColumnName = "LivraisonDetailID_Taux_Preleve_Fond_Roulement";
					/// <summary>
					/// Returns 61
					/// </summary>
					public const System.Int32 ColumnIndex = 61;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LivraisonDetailID_Montant_Preleve_Fond_Roulement via shared members
				/// </summary>
				public sealed class Column_LivraisonDetailID_Montant_Preleve_Fond_Roulement {

					/// <summary>
					/// Returns "LivraisonDetailID_Montant_Preleve_Fond_Roulement"
					/// </summary>
					public const System.String ColumnName = "LivraisonDetailID_Montant_Preleve_Fond_Roulement";
					/// <summary>
					/// Returns 62
					/// </summary>
					public const System.Int32 ColumnIndex = 62;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LivraisonDetailID_Taux_Preleve_Fond_Forestier via shared members
				/// </summary>
				public sealed class Column_LivraisonDetailID_Taux_Preleve_Fond_Forestier {

					/// <summary>
					/// Returns "LivraisonDetailID_Taux_Preleve_Fond_Forestier"
					/// </summary>
					public const System.String ColumnName = "LivraisonDetailID_Taux_Preleve_Fond_Forestier";
					/// <summary>
					/// Returns 63
					/// </summary>
					public const System.Int32 ColumnIndex = 63;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LivraisonDetailID_Montant_Preleve_Fond_Forestier via shared members
				/// </summary>
				public sealed class Column_LivraisonDetailID_Montant_Preleve_Fond_Forestier {

					/// <summary>
					/// Returns "LivraisonDetailID_Montant_Preleve_Fond_Forestier"
					/// </summary>
					public const System.String ColumnName = "LivraisonDetailID_Montant_Preleve_Fond_Forestier";
					/// <summary>
					/// Returns 64
					/// </summary>
					public const System.Int32 ColumnIndex = 64;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LivraisonDetailID_Taux_Preleve_Divers via shared members
				/// </summary>
				public sealed class Column_LivraisonDetailID_Taux_Preleve_Divers {

					/// <summary>
					/// Returns "LivraisonDetailID_Taux_Preleve_Divers"
					/// </summary>
					public const System.String ColumnName = "LivraisonDetailID_Taux_Preleve_Divers";
					/// <summary>
					/// Returns 65
					/// </summary>
					public const System.Int32 ColumnIndex = 65;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LivraisonDetailID_Montant_Preleve_Divers via shared members
				/// </summary>
				public sealed class Column_LivraisonDetailID_Montant_Preleve_Divers {

					/// <summary>
					/// Returns "LivraisonDetailID_Montant_Preleve_Divers"
					/// </summary>
					public const System.String ColumnName = "LivraisonDetailID_Montant_Preleve_Divers";
					/// <summary>
					/// Returns 66
					/// </summary>
					public const System.Int32 ColumnIndex = 66;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LivraisonDetailID_Montant_ProducteurNet via shared members
				/// </summary>
				public sealed class Column_LivraisonDetailID_Montant_ProducteurNet {

					/// <summary>
					/// Returns "LivraisonDetailID_Montant_ProducteurNet"
					/// </summary>
					public const System.String ColumnName = "LivraisonDetailID_Montant_ProducteurNet";
					/// <summary>
					/// Returns 67
					/// </summary>
					public const System.Int32 ColumnIndex = 67;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LivraisonDetailID_Taux_Producteur_Override via shared members
				/// </summary>
				public sealed class Column_LivraisonDetailID_Taux_Producteur_Override {

					/// <summary>
					/// Returns "LivraisonDetailID_Taux_Producteur_Override"
					/// </summary>
					public const System.String ColumnName = "LivraisonDetailID_Taux_Producteur_Override";
					/// <summary>
					/// Returns 68
					/// </summary>
					public const System.Int32 ColumnIndex = 68;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LivraisonDetailID_Taux_Usine_Override via shared members
				/// </summary>
				public sealed class Column_LivraisonDetailID_Taux_Usine_Override {

					/// <summary>
					/// Returns "LivraisonDetailID_Taux_Usine_Override"
					/// </summary>
					public const System.String ColumnName = "LivraisonDetailID_Taux_Usine_Override";
					/// <summary>
					/// Returns 69
					/// </summary>
					public const System.Int32 ColumnIndex = 69;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LivraisonDetailID_Code via shared members
				/// </summary>
				public sealed class Column_LivraisonDetailID_Code {

					/// <summary>
					/// Returns "LivraisonDetailID_Code"
					/// </summary>
					public const System.String ColumnName = "LivraisonDetailID_Code";
					/// <summary>
					/// Returns 70
					/// </summary>
					public const System.Int32 ColumnIndex = 70;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LivraisonDetailID_UsePreleveMontant via shared members
				/// </summary>
				public sealed class Column_LivraisonDetailID_UsePreleveMontant {

					/// <summary>
					/// Returns "LivraisonDetailID_UsePreleveMontant"
					/// </summary>
					public const System.String ColumnName = "LivraisonDetailID_UsePreleveMontant";
					/// <summary>
					/// Returns 71
					/// </summary>
					public const System.Int32 ColumnIndex = 71;

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
					/// Returns 72
					/// </summary>
					public const System.Int32 ColumnIndex = 72;

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
					/// Returns 73
					/// </summary>
					public const System.Int32 ColumnIndex = 73;

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
					/// Returns 74
					/// </summary>
					public const System.Int32 ColumnIndex = 74;

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
					/// Returns 75
					/// </summary>
					public const System.Int32 ColumnIndex = 75;

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
					/// Returns 76
					/// </summary>
					public const System.Int32 ColumnIndex = 76;

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
					/// Returns 77
					/// </summary>
					public const System.Int32 ColumnIndex = 77;

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
					/// Returns 78
					/// </summary>
					public const System.Int32 ColumnIndex = 78;

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
					/// Returns 79
					/// </summary>
					public const System.Int32 ColumnIndex = 79;

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
					/// Returns 80
					/// </summary>
					public const System.Int32 ColumnIndex = 80;

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
					/// Returns 81
					/// </summary>
					public const System.Int32 ColumnIndex = 81;

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
					/// Returns 82
					/// </summary>
					public const System.Int32 ColumnIndex = 82;

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
					/// Returns 83
					/// </summary>
					public const System.Int32 ColumnIndex = 83;

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
					/// Returns 84
					/// </summary>
					public const System.Int32 ColumnIndex = 84;

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
					/// Returns 85
					/// </summary>
					public const System.Int32 ColumnIndex = 85;

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
					/// Returns 86
					/// </summary>
					public const System.Int32 ColumnIndex = 86;

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
					/// Returns 87
					/// </summary>
					public const System.Int32 ColumnIndex = 87;

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
					/// Returns 88
					/// </summary>
					public const System.Int32 ColumnIndex = 88;

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
					/// Returns 89
					/// </summary>
					public const System.Int32 ColumnIndex = 89;

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
					/// Returns 90
					/// </summary>
					public const System.Int32 ColumnIndex = 90;

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
					/// Returns 91
					/// </summary>
					public const System.Int32 ColumnIndex = 91;

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
					/// Returns 92
					/// </summary>
					public const System.Int32 ColumnIndex = 92;

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
					/// Returns 93
					/// </summary>
					public const System.Int32 ColumnIndex = 93;

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
					/// Returns 94
					/// </summary>
					public const System.Int32 ColumnIndex = 94;

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
					/// Returns 95
					/// </summary>
					public const System.Int32 ColumnIndex = 95;

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
					/// Returns 96
					/// </summary>
					public const System.Int32 ColumnIndex = 96;

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
					/// Returns 97
					/// </summary>
					public const System.Int32 ColumnIndex = 97;

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
					/// Returns 98
					/// </summary>
					public const System.Int32 ColumnIndex = 98;

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
					/// Returns 99
					/// </summary>
					public const System.Int32 ColumnIndex = 99;

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
					/// Returns 100
					/// </summary>
					public const System.Int32 ColumnIndex = 100;

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
					/// Returns 101
					/// </summary>
					public const System.Int32 ColumnIndex = 101;

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
					/// Returns 102
					/// </summary>
					public const System.Int32 ColumnIndex = 102;

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
					/// Returns 103
					/// </summary>
					public const System.Int32 ColumnIndex = 103;

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
					/// Returns 104
					/// </summary>
					public const System.Int32 ColumnIndex = 104;

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
					/// Returns 105
					/// </summary>
					public const System.Int32 ColumnIndex = 105;

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
					/// Returns 106
					/// </summary>
					public const System.Int32 ColumnIndex = 106;

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
					/// Returns 107
					/// </summary>
					public const System.Int32 ColumnIndex = 107;

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
					/// Returns 108
					/// </summary>
					public const System.Int32 ColumnIndex = 108;

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
					/// Returns 109
					/// </summary>
					public const System.Int32 ColumnIndex = 109;

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
					/// Returns 110
					/// </summary>
					public const System.Int32 ColumnIndex = 110;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field FactureID_ID via shared members
				/// </summary>
				public sealed class Column_FactureID_ID {

					/// <summary>
					/// Returns "FactureID_ID"
					/// </summary>
					public const System.String ColumnName = "FactureID_ID";
					/// <summary>
					/// Returns 111
					/// </summary>
					public const System.Int32 ColumnIndex = 111;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field FactureID_NoFacture via shared members
				/// </summary>
				public sealed class Column_FactureID_NoFacture {

					/// <summary>
					/// Returns "FactureID_NoFacture"
					/// </summary>
					public const System.String ColumnName = "FactureID_NoFacture";
					/// <summary>
					/// Returns 112
					/// </summary>
					public const System.Int32 ColumnIndex = 112;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field FactureID_DateFacture via shared members
				/// </summary>
				public sealed class Column_FactureID_DateFacture {

					/// <summary>
					/// Returns "FactureID_DateFacture"
					/// </summary>
					public const System.String ColumnName = "FactureID_DateFacture";
					/// <summary>
					/// Returns 113
					/// </summary>
					public const System.Int32 ColumnIndex = 113;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field FactureID_Annee via shared members
				/// </summary>
				public sealed class Column_FactureID_Annee {

					/// <summary>
					/// Returns "FactureID_Annee"
					/// </summary>
					public const System.String ColumnName = "FactureID_Annee";
					/// <summary>
					/// Returns 114
					/// </summary>
					public const System.Int32 ColumnIndex = 114;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field FactureID_TypeFacture via shared members
				/// </summary>
				public sealed class Column_FactureID_TypeFacture {

					/// <summary>
					/// Returns "FactureID_TypeFacture"
					/// </summary>
					public const System.String ColumnName = "FactureID_TypeFacture";
					/// <summary>
					/// Returns 115
					/// </summary>
					public const System.Int32 ColumnIndex = 115;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field FactureID_TypeInvoiceClientAcomba via shared members
				/// </summary>
				public sealed class Column_FactureID_TypeInvoiceClientAcomba {

					/// <summary>
					/// Returns "FactureID_TypeInvoiceClientAcomba"
					/// </summary>
					public const System.String ColumnName = "FactureID_TypeInvoiceClientAcomba";
					/// <summary>
					/// Returns 116
					/// </summary>
					public const System.Int32 ColumnIndex = 116;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field FactureID_ClientID via shared members
				/// </summary>
				public sealed class Column_FactureID_ClientID {

					/// <summary>
					/// Returns "FactureID_ClientID"
					/// </summary>
					public const System.String ColumnName = "FactureID_ClientID";
					/// <summary>
					/// Returns 117
					/// </summary>
					public const System.Int32 ColumnIndex = 117;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field FactureID_PayerAID via shared members
				/// </summary>
				public sealed class Column_FactureID_PayerAID {

					/// <summary>
					/// Returns "FactureID_PayerAID"
					/// </summary>
					public const System.String ColumnName = "FactureID_PayerAID";
					/// <summary>
					/// Returns 118
					/// </summary>
					public const System.Int32 ColumnIndex = 118;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field FactureID_Montant_Total via shared members
				/// </summary>
				public sealed class Column_FactureID_Montant_Total {

					/// <summary>
					/// Returns "FactureID_Montant_Total"
					/// </summary>
					public const System.String ColumnName = "FactureID_Montant_Total";
					/// <summary>
					/// Returns 119
					/// </summary>
					public const System.Int32 ColumnIndex = 119;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field FactureID_Montant_TPS via shared members
				/// </summary>
				public sealed class Column_FactureID_Montant_TPS {

					/// <summary>
					/// Returns "FactureID_Montant_TPS"
					/// </summary>
					public const System.String ColumnName = "FactureID_Montant_TPS";
					/// <summary>
					/// Returns 120
					/// </summary>
					public const System.Int32 ColumnIndex = 120;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field FactureID_Montant_TVQ via shared members
				/// </summary>
				public sealed class Column_FactureID_Montant_TVQ {

					/// <summary>
					/// Returns "FactureID_Montant_TVQ"
					/// </summary>
					public const System.String ColumnName = "FactureID_Montant_TVQ";
					/// <summary>
					/// Returns 121
					/// </summary>
					public const System.Int32 ColumnIndex = 121;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field FactureID_Description via shared members
				/// </summary>
				public sealed class Column_FactureID_Description {

					/// <summary>
					/// Returns "FactureID_Description"
					/// </summary>
					public const System.String ColumnName = "FactureID_Description";
					/// <summary>
					/// Returns 122
					/// </summary>
					public const System.Int32 ColumnIndex = 122;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field FactureID_Status via shared members
				/// </summary>
				public sealed class Column_FactureID_Status {

					/// <summary>
					/// Returns "FactureID_Status"
					/// </summary>
					public const System.String ColumnName = "FactureID_Status";
					/// <summary>
					/// Returns 123
					/// </summary>
					public const System.Int32 ColumnIndex = 123;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field FactureID_StatusDescription via shared members
				/// </summary>
				public sealed class Column_FactureID_StatusDescription {

					/// <summary>
					/// Returns "FactureID_StatusDescription"
					/// </summary>
					public const System.String ColumnName = "FactureID_StatusDescription";
					/// <summary>
					/// Returns 124
					/// </summary>
					public const System.Int32 ColumnIndex = 124;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field FactureID_DateFactureAcomba via shared members
				/// </summary>
				public sealed class Column_FactureID_DateFactureAcomba {

					/// <summary>
					/// Returns "FactureID_DateFactureAcomba"
					/// </summary>
					public const System.String ColumnName = "FactureID_DateFactureAcomba";
					/// <summary>
					/// Returns 125
					/// </summary>
					public const System.Int32 ColumnIndex = 125;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Code_AjustementID via shared members
				/// </summary>
				public sealed class Column_Code_AjustementID {

					/// <summary>
					/// Returns "Code_AjustementID"
					/// </summary>
					public const System.String ColumnName = "Code_AjustementID";
					/// <summary>
					/// Returns 126
					/// </summary>
					public const System.Int32 ColumnIndex = 126;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Code_EssenceID via shared members
				/// </summary>
				public sealed class Column_Code_EssenceID {

					/// <summary>
					/// Returns "Code_EssenceID"
					/// </summary>
					public const System.String ColumnName = "Code_EssenceID";
					/// <summary>
					/// Returns 127
					/// </summary>
					public const System.Int32 ColumnIndex = 127;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Code_UniteID via shared members
				/// </summary>
				public sealed class Column_Code_UniteID {

					/// <summary>
					/// Returns "Code_UniteID"
					/// </summary>
					public const System.String ColumnName = "Code_UniteID";
					/// <summary>
					/// Returns 128
					/// </summary>
					public const System.Int32 ColumnIndex = 128;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Code_ContratID via shared members
				/// </summary>
				public sealed class Column_Code_ContratID {

					/// <summary>
					/// Returns "Code_ContratID"
					/// </summary>
					public const System.String ColumnName = "Code_ContratID";
					/// <summary>
					/// Returns 129
					/// </summary>
					public const System.Int32 ColumnIndex = 129;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Code_Taux_usine via shared members
				/// </summary>
				public sealed class Column_Code_Taux_usine {

					/// <summary>
					/// Returns "Code_Taux_usine"
					/// </summary>
					public const System.String ColumnName = "Code_Taux_usine";
					/// <summary>
					/// Returns 130
					/// </summary>
					public const System.Int32 ColumnIndex = 130;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Code_Taux_producteur via shared members
				/// </summary>
				public sealed class Column_Code_Taux_producteur {

					/// <summary>
					/// Returns "Code_Taux_producteur"
					/// </summary>
					public const System.String ColumnName = "Code_Taux_producteur";
					/// <summary>
					/// Returns 131
					/// </summary>
					public const System.Int32 ColumnIndex = 131;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Code_Date_Modification via shared members
				/// </summary>
				public sealed class Column_Code_Date_Modification {

					/// <summary>
					/// Returns "Code_Date_Modification"
					/// </summary>
					public const System.String ColumnName = "Code_Date_Modification";
					/// <summary>
					/// Returns 132
					/// </summary>
					public const System.Int32 ColumnIndex = 132;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Code_Code via shared members
				/// </summary>
				public sealed class Column_Code_Code {

					/// <summary>
					/// Returns "Code_Code"
					/// </summary>
					public const System.String ColumnName = "Code_Code";
					/// <summary>
					/// Returns 133
					/// </summary>
					public const System.Int32 ColumnIndex = 133;

				}

			}
		}

		/// <summary>
		/// This class allows to easily retrieve the name or index of all the fields
		/// of the resulset #2 existing in the Dataset or the SqlDatReader returned by
		/// the Execute method of the 'spS_AjustementCalcule_Usine_Full' class.
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

