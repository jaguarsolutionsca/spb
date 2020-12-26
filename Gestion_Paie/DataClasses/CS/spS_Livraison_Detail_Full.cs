/*
	This C# source code was automatically generated using:

		SQL Server Centric .NET Code Generator
			v 1.0.1287.20792

			Generation Date: 30/03/2007 9:55:24 AM
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
	/// stored procedure 'spS_Livraison_Detail_Full'. It allows also to specify specific connection
	/// information such as the ConnectionString to be use, the command time-out and so forth.
	/// </summary>
	[Serializable()]
#if OLYMARS_ATTRIBUTE || OLYMARS_DEBUG
	[OlymarsInformation(DeveloperName="<Developer Name Here>", GeneratedOn="2007/03/30 13:55:24", SqlObjectDependancyName="spS_Livraison_Detail_Full", SqlObjectDependancyRevision=0)]
#endif
	public sealed class spS_Livraison_Detail_Full : MarshalByRefObject, IDisposable, IParameter {

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
		/// Initializes a new instance of the spS_Livraison_Detail_Full class. If you use this constructor version,
		/// not assigning parameter values implies using the parameter default values.
		/// </summary>
		public spS_Livraison_Detail_Full() : this(true) {

		}

		/// <summary>
		/// Initializes a new instance of the spS_Livraison_Detail_Full class.
		/// </summary>
		/// <param name="useDefaultValue">If True, this parameter indicates that "not assigning parameter values" implies "using the parameter default values". If False, this parameter indicates that "not assigning parameter values" implies "using the SQL Server Null value".</param>
		public spS_Livraison_Detail_Full(bool useDefaultValue) {

			this.useDefaultValue = useDefaultValue;

			this.internal_Param_ID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_LivraisonID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ContratID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_EssenceID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_UniteMesureID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ProducteurID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ContingentementID_UseDefaultValue = this.useDefaultValue;
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
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'spS_Livraison_Detail_Full'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

						throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "spS_Livraison_Detail_Full", CurrentRevision, OriginalRevision, System.Environment.NewLine));
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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'spS_Livraison_Detail_Full'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlConnection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "spS_Livraison_Detail_Full", CurrentRevision, OriginalRevision, System.Environment.NewLine));
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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'spS_Livraison_Detail_Full'";
				sqlCommand.Transaction = sqlTransaction;

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlTransaction.Connection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "spS_Livraison_Detail_Full", CurrentRevision, OriginalRevision, System.Environment.NewLine));
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
				this.internal_Param_LivraisonID = System.Data.SqlTypes.SqlInt32.Null;
				this.internal_Param_ContratID = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_EssenceID = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_UniteMesureID = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_ProducteurID = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_ContingentementID = System.Data.SqlTypes.SqlInt32.Null;
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
		~spS_Livraison_Detail_Full() {

			Dispose(false);
		}

		/// <summary>
		/// Returns the stored procedure name for which this class was built, i.e. 'spS_Livraison_Detail_Full'.
		/// </summary>
		public string StoredProcedureName {

			get {

				return("spS_Livraison_Detail_Full");
			}
		}

		private System.Data.SqlTypes.SqlInt32 internal_Param_RETURN_VALUE;

		private System.Data.SqlTypes.SqlInt32 internal_Param_ID;
		internal bool internal_Param_ID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlInt32 internal_Param_LivraisonID;
		internal bool internal_Param_LivraisonID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_ContratID;
		internal bool internal_Param_ContratID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_EssenceID;
		internal bool internal_Param_EssenceID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_UniteMesureID;
		internal bool internal_Param_UniteMesureID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_ProducteurID;
		internal bool internal_Param_ProducteurID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlInt32 internal_Param_ContingentementID;
		internal bool internal_Param_ContingentementID_UseDefaultValue = true;

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

			this.internal_Param_LivraisonID = System.Data.SqlTypes.SqlInt32.Null;
			this.internal_Param_LivraisonID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ContratID = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_ContratID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_EssenceID = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_EssenceID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_UniteMesureID = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_UniteMesureID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ProducteurID = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_ProducteurID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ContingentementID = System.Data.SqlTypes.SqlInt32.Null;
			this.internal_Param_ContingentementID_UseDefaultValue = this.useDefaultValue;

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
		/// Sets the value of the stored procedure INPUT parameter '@ContingentementID'.
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
		/// the parameter default value, consider calling the Param_ContingentementID_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlInt32 Param_ContingentementID {

			get {

				if (this.internal_Param_ContingentementID_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ContingentementID);
			}

			set {

				this.internal_Param_ContingentementID_UseDefaultValue = false;
				this.internal_Param_ContingentementID = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ContingentementID' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ContingentementID_UseDefaultValue() {

			this.internal_Param_ContingentementID_UseDefaultValue = true;
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
	/// This class allows you to execute the 'spS_Livraison_Detail_Full' stored procedure;
	/// it gives you the ability to:
	/// <list type="bullet">
	/// <item><description>Set all the necessary parameters to execute the stored procedure</description></item>
	/// <item><description>To execute the stored procedure</description></item>
	/// <item><description>To get back after the execution the return value and all the output parameters value</description></item>
	/// </list>
	/// </summary>
#if OLYMARS_ATTRIBUTE || OLYMARS_DEBUG
	[OlymarsInformation(DeveloperName="<Developer Name Here>", GeneratedOn="2007/03/30 13:55:24", SqlObjectDependancyName="spS_Livraison_Detail_Full", SqlObjectDependancyRevision=0)]
#endif
	public sealed class spS_Livraison_Detail_Full : MarshalByRefObject, IDisposable {


		private bool throwExceptionOnExecute = false;

		/// <summary>
		/// Initializes a new instance of the spS_Livraison_Detail_Full class.
		/// By default, no exception will be thrown when you call the Execute method. Instead, a Boolean return status will be returned.
		/// </summary>
		public spS_Livraison_Detail_Full() : this(false) {

		}

		/// <summary>
		/// Initializes a new instance of the spS_Livraison_Detail_Full class.
		/// </summary>
		/// <param name="throwExceptionOnExecute">True if an exception has to be thrown if the Execute call fails.</param>
		public spS_Livraison_Detail_Full(bool throwExceptionOnExecute) {

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
		~spS_Livraison_Detail_Full() {

			Dispose(false);
		}

		private void ResetParameter(ref Gestion_Paie.DataClasses.Parameters.spS_Livraison_Detail_Full parameters) {

			parameters.internal_Set_RETURN_VALUE (System.Data.SqlTypes.SqlInt32.Null);
		}

		private bool InitializeConnection(ref Gestion_Paie.DataClasses.Parameters.spS_Livraison_Detail_Full parameters, out System.Data.SqlClient.SqlCommand sqlCommand, ref bool connectionMustBeClosed) {

			try {

				this.sqlConnection = null;
				sqlCommand = null;
				connectionMustBeClosed = true;

				if (parameters.ConnectionType == ConnectionType.None) {

					throw new InvalidOperationException("No connection information was supplied. Consider calling the 'SetUpConnection' method of the Gestion_Paie.DataClasses.Parameters.spS_Livraison_Detail_Full object before doing this call.");
				}

				if (parameters.ConnectionType == ConnectionType.SqlConnection && parameters.SqlConnection == null) {

					throw new InvalidOperationException("No connection information was supplied (SqlConnection == null). Consider calling the 'SetUpConnection' method of the Gestion_Paie.DataClasses.Parameters.spS_Livraison_Detail_Full object before doing this call.");
				}

				if (parameters.ConnectionType == ConnectionType.SqlTransaction && parameters.SqlTransaction== null) {

					throw new InvalidOperationException("No connection information was supplied (SqlTransaction == null). Consider calling the 'SetUpConnection' method of the Gestion_Paie.DataClasses.Parameters.spS_Livraison_Detail_Full object before doing this call.");
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

							throw new System.InvalidOperationException("No connection information was supplied (ConnectionString == \"\")! (Gestion_Paie.DataClasses.Parameters.spS_Livraison_Detail_Full)");
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
				sqlCommand.CommandText = "spS_Livraison_Detail_Full";

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

		private bool DeclareParameters(ref Gestion_Paie.DataClasses.Parameters.spS_Livraison_Detail_Full parameters, ref System.Data.SqlClient.SqlCommand sqlCommand) {

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

				sqlParameter = new System.Data.SqlClient.SqlParameter("@LivraisonID", System.Data.SqlDbType.Int, 4);
				sqlParameter.SourceColumn = "LivraisonID";
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

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ContingentementID", System.Data.SqlDbType.Int, 4);
				sqlParameter.SourceColumn = "ContingentementID";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ContingentementID_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ContingentementID.IsNull) {

					sqlParameter.Value = parameters.Param_ContingentementID;
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

		private bool RetrieveParameters(ref Gestion_Paie.DataClasses.Parameters.spS_Livraison_Detail_Full parameters, ref System.Data.SqlClient.SqlCommand sqlCommand) {

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
		/// This method allows you to execute the [spS_Livraison_Detail_Full] stored procedure and retrieve back the data
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
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.spS_Livraison_Detail_Full parameters, out System.Data.SqlClient.SqlDataReader sqlDataReader) {

			return(Execute(ref parameters, out sqlDataReader, System.Data.CommandBehavior.Default));
		}

		/// <summary>
		/// This method allows you to execute the [spS_Livraison_Detail_Full] stored procedure and retrieve back the data
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
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.spS_Livraison_Detail_Full parameters, out System.Data.SqlClient.SqlDataReader sqlDataReader, System.Data.CommandBehavior commandBehavior) {

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
		/// This method allows you to execute the [spS_Livraison_Detail_Full] stored procedure and retrieve back the data
		/// populated in a DataSet (System.Data.DataSet).
		/// </summary>
		/// <param name="parameters">
		/// Contains all the necessary information to execute correctly the stored procedure, i.e. 
		/// the database connection to use and all the necessary input parameters to be supplied
		/// for this stored procedure execution. After the execution, this object will allow you
		/// to retrieve back the stored procedure return value and all the output parameters.
		/// </param>
		/// <param name="dataset">
		/// Will be populated with the data after execution. The table based name used will be: 'spS_Livraison_Detail_Full'.
		/// </param>
		/// <returns>True if the call was successful. Otherwise, it returns False.</returns>
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.spS_Livraison_Detail_Full parameters, ref System.Data.DataSet dataset) {

			return(Execute(ref parameters, ref dataset, "spS_Livraison_Detail_Full", -1, -1));
		}

		/// <summary>
		/// This method allows you to execute the [spS_Livraison_Detail_Full] stored procedure and retrieve back the data
		/// populated in a DataSet (System.Data.DataSet).
		/// </summary>
		/// <param name="parameters">
		/// Contains all the necessary information to execute correctly the stored procedure, i.e. 
		/// the database connection to use and all the necessary input parameters to be supplied
		/// for this stored procedure execution. After the execution, this object will allow you
		/// to retrieve back the stored procedure return value and all the output parameters.
		/// </param>
		/// <param name="dataset">
		/// Will be populated with the data after execution. The table based name used will be: 'spS_Livraison_Detail_Full'.
		/// </param>
		/// <param name="startRecord">The zero-based record number to start with.</param>
		/// <param name="maxRecords">The maximum number of records to retrieve.</param>
		/// <returns>True if the call was successful. Otherwise, it returns False.</returns>
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.spS_Livraison_Detail_Full parameters, ref System.Data.DataSet dataset, int startRecord, int maxRecords) {

			return(Execute(ref parameters, ref dataset, "spS_Livraison_Detail_Full", startRecord, maxRecords));
		}

		/// <summary>
		/// This method allows you to execute the [spS_Livraison_Detail_Full] stored procedure and retrieve back the data
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
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.spS_Livraison_Detail_Full parameters, ref System.Data.DataSet dataset, string tableName) {

			return(Execute(ref parameters, ref dataset, tableName, -1, -1));
		}

		/// <summary>
		/// This method allows you to execute the [spS_Livraison_Detail_Full] stored procedure and retrieve back the data
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
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.spS_Livraison_Detail_Full parameters, ref System.Data.DataSet dataset, string tableName, int startRecord, int maxRecords) {

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
				dataset.Tables[tableName].Columns["LivraisonID"].Caption = "LivraisonID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"LivraisonID\" column)";
				dataset.Tables[tableName].Columns["ContratID"].Caption = "ContratID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ContratID\" column)";
				dataset.Tables[tableName].Columns["EssenceID"].Caption = "EssenceID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"EssenceID\" column)";
				dataset.Tables[tableName].Columns["UniteMesureID"].Caption = "UniteMesureID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"UniteMesureID\" column)";
				dataset.Tables[tableName].Columns["ProducteurID"].Caption = "ProducteurID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ProducteurID\" column)";
				dataset.Tables[tableName].Columns["Droit_Coupe"].Caption = "Droit_Coupe (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Droit_Coupe\" column)";
				dataset.Tables[tableName].Columns["VolumeBrut"].Caption = "VolumeBrut (update this label in the \"Olymars/ColumnLabel\" extended property of the \"VolumeBrut\" column)";
				dataset.Tables[tableName].Columns["VolumeReduction"].Caption = "VolumeReduction (update this label in the \"Olymars/ColumnLabel\" extended property of the \"VolumeReduction\" column)";
				dataset.Tables[tableName].Columns["VolumeNet"].Caption = "VolumeNet (update this label in the \"Olymars/ColumnLabel\" extended property of the \"VolumeNet\" column)";
				dataset.Tables[tableName].Columns["VolumeContingente"].Caption = "VolumeContingente (update this label in the \"Olymars/ColumnLabel\" extended property of the \"VolumeContingente\" column)";
				dataset.Tables[tableName].Columns["ContingentementID"].Caption = "ContingentementID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ContingentementID\" column)";
				dataset.Tables[tableName].Columns["DateCalcul"].Caption = "DateCalcul (update this label in the \"Olymars/ColumnLabel\" extended property of the \"DateCalcul\" column)";
				dataset.Tables[tableName].Columns["Taux_Usine"].Caption = "Taux_Usine (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Taux_Usine\" column)";
				dataset.Tables[tableName].Columns["Montant_Usine"].Caption = "Montant_Usine (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Montant_Usine\" column)";
				dataset.Tables[tableName].Columns["Taux_Producteur"].Caption = "Taux_Producteur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Taux_Producteur\" column)";
				dataset.Tables[tableName].Columns["Montant_ProducteurBrut"].Caption = "Montant_ProducteurBrut (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Montant_ProducteurBrut\" column)";
				dataset.Tables[tableName].Columns["Taux_TransporteurMoyen"].Caption = "Taux_TransporteurMoyen (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Taux_TransporteurMoyen\" column)";
				dataset.Tables[tableName].Columns["Taux_TransporteurMoyen_Override"].Caption = "Taux_TransporteurMoyen_Override (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Taux_TransporteurMoyen_Override\" column)";
				dataset.Tables[tableName].Columns["Montant_TransporteurMoyen"].Caption = "Montant_TransporteurMoyen (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Montant_TransporteurMoyen\" column)";
				dataset.Tables[tableName].Columns["Taux_Preleve_Plan_Conjoint"].Caption = "Taux_Preleve_Plan_Conjoint (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Taux_Preleve_Plan_Conjoint\" column)";
				dataset.Tables[tableName].Columns["Montant_Preleve_Plan_Conjoint"].Caption = "Montant_Preleve_Plan_Conjoint (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Montant_Preleve_Plan_Conjoint\" column)";
				dataset.Tables[tableName].Columns["Taux_Preleve_Fond_Roulement"].Caption = "Taux_Preleve_Fond_Roulement (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Taux_Preleve_Fond_Roulement\" column)";
				dataset.Tables[tableName].Columns["Montant_Preleve_Fond_Roulement"].Caption = "Montant_Preleve_Fond_Roulement (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Montant_Preleve_Fond_Roulement\" column)";
				dataset.Tables[tableName].Columns["Taux_Preleve_Fond_Forestier"].Caption = "Taux_Preleve_Fond_Forestier (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Taux_Preleve_Fond_Forestier\" column)";
				dataset.Tables[tableName].Columns["Montant_Preleve_Fond_Forestier"].Caption = "Montant_Preleve_Fond_Forestier (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Montant_Preleve_Fond_Forestier\" column)";
				dataset.Tables[tableName].Columns["Taux_Preleve_Divers"].Caption = "Taux_Preleve_Divers (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Taux_Preleve_Divers\" column)";
				dataset.Tables[tableName].Columns["Montant_Preleve_Divers"].Caption = "Montant_Preleve_Divers (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Montant_Preleve_Divers\" column)";
				dataset.Tables[tableName].Columns["Montant_ProducteurNet"].Caption = "Montant_ProducteurNet (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Montant_ProducteurNet\" column)";
				dataset.Tables[tableName].Columns["Taux_Producteur_Override"].Caption = "Taux_Producteur_Override (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Taux_Producteur_Override\" column)";
				dataset.Tables[tableName].Columns["Taux_Usine_Override"].Caption = "Taux_Usine_Override (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Taux_Usine_Override\" column)";
				dataset.Tables[tableName].Columns["Code"].Caption = "Code (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Code\" column)";
				dataset.Tables[tableName].Columns["UsePreleveMontant"].Caption = "UsePreleveMontant (update this label in the \"Olymars/ColumnLabel\" extended property of the \"UsePreleveMontant\" column)";
				dataset.Tables[tableName].Columns["LivraisonID_ID"].Caption = "ID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ID\" column)";
				dataset.Tables[tableName].Columns["LivraisonID_DateLivraison"].Caption = "DateLivraison (update this label in the \"Olymars/ColumnLabel\" extended property of the \"DateLivraison\" column)";
				dataset.Tables[tableName].Columns["LivraisonID_DatePaye"].Caption = "DatePaye (update this label in the \"Olymars/ColumnLabel\" extended property of the \"DatePaye\" column)";
				dataset.Tables[tableName].Columns["LivraisonID_ContratID"].Caption = "ContratID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ContratID\" column)";
				dataset.Tables[tableName].Columns["LivraisonID_UniteMesureID"].Caption = "UniteMesureID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"UniteMesureID\" column)";
				dataset.Tables[tableName].Columns["LivraisonID_EssenceID"].Caption = "EssenceID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"EssenceID\" column)";
				dataset.Tables[tableName].Columns["LivraisonID_Sciage"].Caption = "Sciage (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Sciage\" column)";
				dataset.Tables[tableName].Columns["LivraisonID_NumeroFactureUsine"].Caption = "NumeroFactureUsine (update this label in the \"Olymars/ColumnLabel\" extended property of the \"NumeroFactureUsine\" column)";
				dataset.Tables[tableName].Columns["LivraisonID_DroitCoupeID"].Caption = "DroitCoupeID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"DroitCoupeID\" column)";
				dataset.Tables[tableName].Columns["LivraisonID_EntentePaiementID"].Caption = "EntentePaiementID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"EntentePaiementID\" column)";
				dataset.Tables[tableName].Columns["LivraisonID_TransporteurID"].Caption = "TransporteurID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"TransporteurID\" column)";
				dataset.Tables[tableName].Columns["LivraisonID_VR"].Caption = "VR (update this label in the \"Olymars/ColumnLabel\" extended property of the \"VR\" column)";
				dataset.Tables[tableName].Columns["LivraisonID_MasseLimite"].Caption = "MasseLimite (update this label in the \"Olymars/ColumnLabel\" extended property of the \"MasseLimite\" column)";
				dataset.Tables[tableName].Columns["LivraisonID_VolumeBrut"].Caption = "VolumeBrut (update this label in the \"Olymars/ColumnLabel\" extended property of the \"VolumeBrut\" column)";
				dataset.Tables[tableName].Columns["LivraisonID_VolumeTare"].Caption = "VolumeTare (update this label in the \"Olymars/ColumnLabel\" extended property of the \"VolumeTare\" column)";
				dataset.Tables[tableName].Columns["LivraisonID_VolumeTransporte"].Caption = "VolumeTransporte (update this label in the \"Olymars/ColumnLabel\" extended property of the \"VolumeTransporte\" column)";
				dataset.Tables[tableName].Columns["LivraisonID_VolumeSurcharge"].Caption = "VolumeSurcharge (update this label in the \"Olymars/ColumnLabel\" extended property of the \"VolumeSurcharge\" column)";
				dataset.Tables[tableName].Columns["LivraisonID_VolumeAPayer"].Caption = "VolumeAPayer (update this label in the \"Olymars/ColumnLabel\" extended property of the \"VolumeAPayer\" column)";
				dataset.Tables[tableName].Columns["LivraisonID_Annee"].Caption = "Annee (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Annee\" column)";
				dataset.Tables[tableName].Columns["LivraisonID_Periode"].Caption = "Periode (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Periode\" column)";
				dataset.Tables[tableName].Columns["LivraisonID_DateCalcul"].Caption = "DateCalcul (update this label in the \"Olymars/ColumnLabel\" extended property of the \"DateCalcul\" column)";
				dataset.Tables[tableName].Columns["LivraisonID_Taux_Transporteur"].Caption = "Taux_Transporteur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Taux_Transporteur\" column)";
				dataset.Tables[tableName].Columns["LivraisonID_Montant_Transporteur"].Caption = "Montant_Transporteur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Montant_Transporteur\" column)";
				dataset.Tables[tableName].Columns["LivraisonID_Montant_Usine"].Caption = "Montant_Usine (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Montant_Usine\" column)";
				dataset.Tables[tableName].Columns["LivraisonID_Montant_Producteur1"].Caption = "Montant_Producteur1 (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Montant_Producteur1\" column)";
				dataset.Tables[tableName].Columns["LivraisonID_Montant_Producteur2"].Caption = "Montant_Producteur2 (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Montant_Producteur2\" column)";
				dataset.Tables[tableName].Columns["LivraisonID_Montant_Preleve_Plan_Conjoint"].Caption = "Montant_Preleve_Plan_Conjoint (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Montant_Preleve_Plan_Conjoint\" column)";
				dataset.Tables[tableName].Columns["LivraisonID_Montant_Preleve_Fond_Roulement"].Caption = "Montant_Preleve_Fond_Roulement (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Montant_Preleve_Fond_Roulement\" column)";
				dataset.Tables[tableName].Columns["LivraisonID_Montant_Preleve_Fond_Forestier"].Caption = "Montant_Preleve_Fond_Forestier (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Montant_Preleve_Fond_Forestier\" column)";
				dataset.Tables[tableName].Columns["LivraisonID_Montant_Preleve_Divers"].Caption = "Montant_Preleve_Divers (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Montant_Preleve_Divers\" column)";
				dataset.Tables[tableName].Columns["LivraisonID_Montant_Surcharge"].Caption = "Montant_Surcharge (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Montant_Surcharge\" column)";
				dataset.Tables[tableName].Columns["LivraisonID_Montant_MiseEnCommun"].Caption = "Montant_MiseEnCommun (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Montant_MiseEnCommun\" column)";
				dataset.Tables[tableName].Columns["LivraisonID_Facture"].Caption = "Facture (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Facture\" column)";
				dataset.Tables[tableName].Columns["LivraisonID_Producteur1_FactureID"].Caption = "Producteur1_FactureID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Producteur1_FactureID\" column)";
				dataset.Tables[tableName].Columns["LivraisonID_Producteur2_FactureID"].Caption = "Producteur2_FactureID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Producteur2_FactureID\" column)";
				dataset.Tables[tableName].Columns["LivraisonID_Transporteur_FactureID"].Caption = "Transporteur_FactureID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Transporteur_FactureID\" column)";
				dataset.Tables[tableName].Columns["LivraisonID_Usine_FactureID"].Caption = "Usine_FactureID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Usine_FactureID\" column)";
				dataset.Tables[tableName].Columns["LivraisonID_ErreurCalcul"].Caption = "ErreurCalcul (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ErreurCalcul\" column)";
				dataset.Tables[tableName].Columns["LivraisonID_ErreurDescription"].Caption = "ErreurDescription (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ErreurDescription\" column)";
				dataset.Tables[tableName].Columns["LivraisonID_LotID"].Caption = "LotID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"LotID\" column)";
				dataset.Tables[tableName].Columns["LivraisonID_Taux_Transporteur_Override"].Caption = "Taux_Transporteur_Override (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Taux_Transporteur_Override\" column)";
				dataset.Tables[tableName].Columns["LivraisonID_PaieTransporteur"].Caption = "PaieTransporteur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"PaieTransporteur\" column)";
				dataset.Tables[tableName].Columns["LivraisonID_VolumeSurcharge_Override"].Caption = "VolumeSurcharge_Override (update this label in the \"Olymars/ColumnLabel\" extended property of the \"VolumeSurcharge_Override\" column)";
				dataset.Tables[tableName].Columns["LivraisonID_SurchargeManuel"].Caption = "SurchargeManuel (update this label in the \"Olymars/ColumnLabel\" extended property of the \"SurchargeManuel\" column)";
				dataset.Tables[tableName].Columns["LivraisonID_Code"].Caption = "Code (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Code\" column)";
				dataset.Tables[tableName].Columns["LivraisonID_NombrePermis"].Caption = "NombrePermis (update this label in the \"Olymars/ColumnLabel\" extended property of the \"NombrePermis\" column)";
				dataset.Tables[tableName].Columns["LivraisonID_ZoneID"].Caption = "ZoneID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ZoneID\" column)";
				dataset.Tables[tableName].Columns["LivraisonID_MunicipaliteID"].Caption = "MunicipaliteID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"MunicipaliteID\" column)";
				dataset.Tables[tableName].Columns["LivraisonID_ChargeurID"].Caption = "ChargeurID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ChargeurID\" column)";
				dataset.Tables[tableName].Columns["LivraisonID_Montant_Chargeur"].Caption = "Montant_Chargeur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Montant_Chargeur\" column)";
				dataset.Tables[tableName].Columns["LivraisonID_Frais_ChargeurAuProducteur"].Caption = "Frais_ChargeurAuProducteur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Frais_ChargeurAuProducteur\" column)";
				dataset.Tables[tableName].Columns["LivraisonID_Frais_ChargeurAuTransporteur"].Caption = "Frais_ChargeurAuTransporteur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Frais_ChargeurAuTransporteur\" column)";
				dataset.Tables[tableName].Columns["LivraisonID_Frais_AutresAuProducteur"].Caption = "Frais_AutresAuProducteur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Frais_AutresAuProducteur\" column)";
				dataset.Tables[tableName].Columns["LivraisonID_Frais_AutresAuProducteurDescription"].Caption = "Frais_AutresAuProducteurDescription (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Frais_AutresAuProducteurDescription\" column)";
				dataset.Tables[tableName].Columns["LivraisonID_Frais_AutresAuTransporteur"].Caption = "Frais_AutresAuTransporteur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Frais_AutresAuTransporteur\" column)";
				dataset.Tables[tableName].Columns["LivraisonID_Frais_AutresAuTransporteurDescription"].Caption = "Frais_AutresAuTransporteurDescription (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Frais_AutresAuTransporteurDescription\" column)";
				dataset.Tables[tableName].Columns["LivraisonID_Frais_CompensationDeDeplacement"].Caption = "Frais_CompensationDeDeplacement (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Frais_CompensationDeDeplacement\" column)";
				dataset.Tables[tableName].Columns["LivraisonID_Chargeur_FactureID"].Caption = "Chargeur_FactureID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Chargeur_FactureID\" column)";
				dataset.Tables[tableName].Columns["LivraisonID_Commentaires_Producteur"].Caption = "Commentaires_Producteur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Commentaires_Producteur\" column)";
				dataset.Tables[tableName].Columns["LivraisonID_Commentaires_Transporteur"].Caption = "Commentaires_Transporteur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Commentaires_Transporteur\" column)";
				dataset.Tables[tableName].Columns["LivraisonID_Commentaires_Chargeur"].Caption = "Commentaires_Chargeur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Commentaires_Chargeur\" column)";
				dataset.Tables[tableName].Columns["LivraisonID_TauxChargeurAuProducteur"].Caption = "TauxChargeurAuProducteur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"TauxChargeurAuProducteur\" column)";
				dataset.Tables[tableName].Columns["LivraisonID_TauxChargeurAuTransporteur"].Caption = "TauxChargeurAuTransporteur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"TauxChargeurAuTransporteur\" column)";
				dataset.Tables[tableName].Columns["LivraisonID_Frais_AutresRevenusTransporteur"].Caption = "Frais_AutresRevenusTransporteur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Frais_AutresRevenusTransporteur\" column)";
				dataset.Tables[tableName].Columns["LivraisonID_Frais_AutresRevenusTransporteurDescription"].Caption = "Frais_AutresRevenusTransporteurDescription (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Frais_AutresRevenusTransporteurDescription\" column)";
				dataset.Tables[tableName].Columns["LivraisonID_Frais_AutresRevenusProducteur"].Caption = "Frais_AutresRevenusProducteur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Frais_AutresRevenusProducteur\" column)";
				dataset.Tables[tableName].Columns["LivraisonID_Frais_AutresRevenusProducteurDescription"].Caption = "Frais_AutresRevenusProducteurDescription (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Frais_AutresRevenusProducteurDescription\" column)";
				dataset.Tables[tableName].Columns["LivraisonID_Montant_SurchargeProducteur"].Caption = "Montant_SurchargeProducteur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Montant_SurchargeProducteur\" column)";
				dataset.Tables[tableName].Columns["ContratID_ContratID"].Caption = "ContratID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ContratID\" column)";
				dataset.Tables[tableName].Columns["ContratID_EssenceID"].Caption = "EssenceID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"EssenceID\" column)";
				dataset.Tables[tableName].Columns["ContratID_UniteID"].Caption = "UniteID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"UniteID\" column)";
				dataset.Tables[tableName].Columns["ContratID_Code"].Caption = "Code (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Code\" column)";
				dataset.Tables[tableName].Columns["ContratID_Quantite_prevue"].Caption = "Quantite_prevue (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Quantite_prevue\" column)";
				dataset.Tables[tableName].Columns["ContratID_Taux_usine"].Caption = "Taux_usine (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Taux_usine\" column)";
				dataset.Tables[tableName].Columns["ContratID_Taux_producteur"].Caption = "Taux_producteur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Taux_producteur\" column)";
				dataset.Tables[tableName].Columns["ContratID_Actif"].Caption = "Actif (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Actif\" column)";
				dataset.Tables[tableName].Columns["ContratID_Description"].Caption = "Description (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Description\" column)";
				dataset.Tables[tableName].Columns["EssenceID_ContratID"].Caption = "ContratID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ContratID\" column)";
				dataset.Tables[tableName].Columns["EssenceID_EssenceID"].Caption = "EssenceID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"EssenceID\" column)";
				dataset.Tables[tableName].Columns["EssenceID_UniteID"].Caption = "UniteID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"UniteID\" column)";
				dataset.Tables[tableName].Columns["EssenceID_Code"].Caption = "Code (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Code\" column)";
				dataset.Tables[tableName].Columns["EssenceID_Quantite_prevue"].Caption = "Quantite_prevue (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Quantite_prevue\" column)";
				dataset.Tables[tableName].Columns["EssenceID_Taux_usine"].Caption = "Taux_usine (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Taux_usine\" column)";
				dataset.Tables[tableName].Columns["EssenceID_Taux_producteur"].Caption = "Taux_producteur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Taux_producteur\" column)";
				dataset.Tables[tableName].Columns["EssenceID_Actif"].Caption = "Actif (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Actif\" column)";
				dataset.Tables[tableName].Columns["EssenceID_Description"].Caption = "Description (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Description\" column)";
				dataset.Tables[tableName].Columns["UniteMesureID_ContratID"].Caption = "ContratID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ContratID\" column)";
				dataset.Tables[tableName].Columns["UniteMesureID_EssenceID"].Caption = "EssenceID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"EssenceID\" column)";
				dataset.Tables[tableName].Columns["UniteMesureID_UniteID"].Caption = "UniteID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"UniteID\" column)";
				dataset.Tables[tableName].Columns["UniteMesureID_Code"].Caption = "Code (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Code\" column)";
				dataset.Tables[tableName].Columns["UniteMesureID_Quantite_prevue"].Caption = "Quantite_prevue (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Quantite_prevue\" column)";
				dataset.Tables[tableName].Columns["UniteMesureID_Taux_usine"].Caption = "Taux_usine (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Taux_usine\" column)";
				dataset.Tables[tableName].Columns["UniteMesureID_Taux_producteur"].Caption = "Taux_producteur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Taux_producteur\" column)";
				dataset.Tables[tableName].Columns["UniteMesureID_Actif"].Caption = "Actif (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Actif\" column)";
				dataset.Tables[tableName].Columns["UniteMesureID_Description"].Caption = "Description (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Description\" column)";
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
				dataset.Tables[tableName].Columns["ContingentementID_ID"].Caption = "ID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ID\" column)";
				dataset.Tables[tableName].Columns["ContingentementID_ContingentUsine"].Caption = "ContingentUsine (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ContingentUsine\" column)";
				dataset.Tables[tableName].Columns["ContingentementID_UsineID"].Caption = "UsineID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"UsineID\" column)";
				dataset.Tables[tableName].Columns["ContingentementID_RegroupementID"].Caption = "RegroupementID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"RegroupementID\" column)";
				dataset.Tables[tableName].Columns["ContingentementID_Annee"].Caption = "Annee (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Annee\" column)";
				dataset.Tables[tableName].Columns["ContingentementID_PeriodeContingentement"].Caption = "PeriodeContingentement (update this label in the \"Olymars/ColumnLabel\" extended property of the \"PeriodeContingentement\" column)";
				dataset.Tables[tableName].Columns["ContingentementID_PeriodeDebut"].Caption = "PeriodeDebut (update this label in the \"Olymars/ColumnLabel\" extended property of the \"PeriodeDebut\" column)";
				dataset.Tables[tableName].Columns["ContingentementID_PeriodeFin"].Caption = "PeriodeFin (update this label in the \"Olymars/ColumnLabel\" extended property of the \"PeriodeFin\" column)";
				dataset.Tables[tableName].Columns["ContingentementID_EssenceID"].Caption = "EssenceID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"EssenceID\" column)";
				dataset.Tables[tableName].Columns["ContingentementID_UniteMesureID"].Caption = "UniteMesureID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"UniteMesureID\" column)";
				dataset.Tables[tableName].Columns["ContingentementID_Volume_Usine"].Caption = "Volume_Usine (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Volume_Usine\" column)";
				dataset.Tables[tableName].Columns["ContingentementID_Facteur"].Caption = "Facteur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Facteur\" column)";
				dataset.Tables[tableName].Columns["ContingentementID_Volume_Fixe"].Caption = "Volume_Fixe (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Volume_Fixe\" column)";
				dataset.Tables[tableName].Columns["ContingentementID_Date_Calcul"].Caption = "Date_Calcul (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Date_Calcul\" column)";
				dataset.Tables[tableName].Columns["ContingentementID_CalculAccepte"].Caption = "CalculAccepte (update this label in the \"Olymars/ColumnLabel\" extended property of the \"CalculAccepte\" column)";
				dataset.Tables[tableName].Columns["ContingentementID_Code"].Caption = "Code (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Code\" column)";
				dataset.Tables[tableName].Columns["Code_ContratID"].Caption = "ContratID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ContratID\" column)";
				dataset.Tables[tableName].Columns["Code_EssenceID"].Caption = "EssenceID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"EssenceID\" column)";
				dataset.Tables[tableName].Columns["Code_UniteID"].Caption = "UniteID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"UniteID\" column)";
				dataset.Tables[tableName].Columns["Code_Code"].Caption = "Code (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Code\" column)";
				dataset.Tables[tableName].Columns["Code_Quantite_prevue"].Caption = "Quantite_prevue (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Quantite_prevue\" column)";
				dataset.Tables[tableName].Columns["Code_Taux_usine"].Caption = "Taux_usine (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Taux_usine\" column)";
				dataset.Tables[tableName].Columns["Code_Taux_producteur"].Caption = "Taux_producteur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Taux_producteur\" column)";
				dataset.Tables[tableName].Columns["Code_Actif"].Caption = "Actif (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Actif\" column)";
				dataset.Tables[tableName].Columns["Code_Description"].Caption = "Description (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Description\" column)";

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
		/// This method allows you to execute the [spS_Livraison_Detail_Full] stored procedure and retrieve back the data
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
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.spS_Livraison_Detail_Full parameters, ref string xml) {

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
		/// This method allows you to execute the [spS_Livraison_Detail_Full] stored procedure and retrieve back the data
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
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.spS_Livraison_Detail_Full parameters, out System.Xml.XmlReader xmlReader) {

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
		/// the Execute method of the 'spS_Livraison_Detail_Full' class.
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
				/// Allows to get the Index and Name of the field LivraisonID via shared members
				/// </summary>
				public sealed class Column_LivraisonID {

					/// <summary>
					/// Returns "LivraisonID"
					/// </summary>
					public const System.String ColumnName = "LivraisonID";
					/// <summary>
					/// Returns 1
					/// </summary>
					public const System.Int32 ColumnIndex = 1;

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
				/// Allows to get the Index and Name of the field ProducteurID via shared members
				/// </summary>
				public sealed class Column_ProducteurID {

					/// <summary>
					/// Returns "ProducteurID"
					/// </summary>
					public const System.String ColumnName = "ProducteurID";
					/// <summary>
					/// Returns 5
					/// </summary>
					public const System.Int32 ColumnIndex = 5;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Droit_Coupe via shared members
				/// </summary>
				public sealed class Column_Droit_Coupe {

					/// <summary>
					/// Returns "Droit_Coupe"
					/// </summary>
					public const System.String ColumnName = "Droit_Coupe";
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
				/// Allows to get the Index and Name of the field VolumeReduction via shared members
				/// </summary>
				public sealed class Column_VolumeReduction {

					/// <summary>
					/// Returns "VolumeReduction"
					/// </summary>
					public const System.String ColumnName = "VolumeReduction";
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
				/// Allows to get the Index and Name of the field VolumeContingente via shared members
				/// </summary>
				public sealed class Column_VolumeContingente {

					/// <summary>
					/// Returns "VolumeContingente"
					/// </summary>
					public const System.String ColumnName = "VolumeContingente";
					/// <summary>
					/// Returns 10
					/// </summary>
					public const System.Int32 ColumnIndex = 10;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ContingentementID via shared members
				/// </summary>
				public sealed class Column_ContingentementID {

					/// <summary>
					/// Returns "ContingentementID"
					/// </summary>
					public const System.String ColumnName = "ContingentementID";
					/// <summary>
					/// Returns 11
					/// </summary>
					public const System.Int32 ColumnIndex = 11;

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
					/// Returns 12
					/// </summary>
					public const System.Int32 ColumnIndex = 12;

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
					/// Returns 13
					/// </summary>
					public const System.Int32 ColumnIndex = 13;

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
					/// Returns 14
					/// </summary>
					public const System.Int32 ColumnIndex = 14;

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
					/// Returns 15
					/// </summary>
					public const System.Int32 ColumnIndex = 15;

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
					/// Returns 16
					/// </summary>
					public const System.Int32 ColumnIndex = 16;

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
					/// Returns 17
					/// </summary>
					public const System.Int32 ColumnIndex = 17;

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
					/// Returns 18
					/// </summary>
					public const System.Int32 ColumnIndex = 18;

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
					/// Returns 19
					/// </summary>
					public const System.Int32 ColumnIndex = 19;

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
					/// Returns 20
					/// </summary>
					public const System.Int32 ColumnIndex = 20;

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
					/// Returns 21
					/// </summary>
					public const System.Int32 ColumnIndex = 21;

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
					/// Returns 22
					/// </summary>
					public const System.Int32 ColumnIndex = 22;

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
					/// Returns 23
					/// </summary>
					public const System.Int32 ColumnIndex = 23;

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
					/// Returns 24
					/// </summary>
					public const System.Int32 ColumnIndex = 24;

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
					/// Returns 25
					/// </summary>
					public const System.Int32 ColumnIndex = 25;

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
					/// Returns 26
					/// </summary>
					public const System.Int32 ColumnIndex = 26;

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
					/// Returns 27
					/// </summary>
					public const System.Int32 ColumnIndex = 27;

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
					/// Returns 28
					/// </summary>
					public const System.Int32 ColumnIndex = 28;

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
					/// Returns 29
					/// </summary>
					public const System.Int32 ColumnIndex = 29;

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
					/// Returns 30
					/// </summary>
					public const System.Int32 ColumnIndex = 30;

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
					/// Returns 31
					/// </summary>
					public const System.Int32 ColumnIndex = 31;

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
					/// Returns 32
					/// </summary>
					public const System.Int32 ColumnIndex = 32;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LivraisonID_ID via shared members
				/// </summary>
				public sealed class Column_LivraisonID_ID {

					/// <summary>
					/// Returns "LivraisonID_ID"
					/// </summary>
					public const System.String ColumnName = "LivraisonID_ID";
					/// <summary>
					/// Returns 33
					/// </summary>
					public const System.Int32 ColumnIndex = 33;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LivraisonID_DateLivraison via shared members
				/// </summary>
				public sealed class Column_LivraisonID_DateLivraison {

					/// <summary>
					/// Returns "LivraisonID_DateLivraison"
					/// </summary>
					public const System.String ColumnName = "LivraisonID_DateLivraison";
					/// <summary>
					/// Returns 34
					/// </summary>
					public const System.Int32 ColumnIndex = 34;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LivraisonID_DatePaye via shared members
				/// </summary>
				public sealed class Column_LivraisonID_DatePaye {

					/// <summary>
					/// Returns "LivraisonID_DatePaye"
					/// </summary>
					public const System.String ColumnName = "LivraisonID_DatePaye";
					/// <summary>
					/// Returns 35
					/// </summary>
					public const System.Int32 ColumnIndex = 35;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LivraisonID_ContratID via shared members
				/// </summary>
				public sealed class Column_LivraisonID_ContratID {

					/// <summary>
					/// Returns "LivraisonID_ContratID"
					/// </summary>
					public const System.String ColumnName = "LivraisonID_ContratID";
					/// <summary>
					/// Returns 36
					/// </summary>
					public const System.Int32 ColumnIndex = 36;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LivraisonID_UniteMesureID via shared members
				/// </summary>
				public sealed class Column_LivraisonID_UniteMesureID {

					/// <summary>
					/// Returns "LivraisonID_UniteMesureID"
					/// </summary>
					public const System.String ColumnName = "LivraisonID_UniteMesureID";
					/// <summary>
					/// Returns 37
					/// </summary>
					public const System.Int32 ColumnIndex = 37;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LivraisonID_EssenceID via shared members
				/// </summary>
				public sealed class Column_LivraisonID_EssenceID {

					/// <summary>
					/// Returns "LivraisonID_EssenceID"
					/// </summary>
					public const System.String ColumnName = "LivraisonID_EssenceID";
					/// <summary>
					/// Returns 38
					/// </summary>
					public const System.Int32 ColumnIndex = 38;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LivraisonID_Sciage via shared members
				/// </summary>
				public sealed class Column_LivraisonID_Sciage {

					/// <summary>
					/// Returns "LivraisonID_Sciage"
					/// </summary>
					public const System.String ColumnName = "LivraisonID_Sciage";
					/// <summary>
					/// Returns 39
					/// </summary>
					public const System.Int32 ColumnIndex = 39;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LivraisonID_NumeroFactureUsine via shared members
				/// </summary>
				public sealed class Column_LivraisonID_NumeroFactureUsine {

					/// <summary>
					/// Returns "LivraisonID_NumeroFactureUsine"
					/// </summary>
					public const System.String ColumnName = "LivraisonID_NumeroFactureUsine";
					/// <summary>
					/// Returns 40
					/// </summary>
					public const System.Int32 ColumnIndex = 40;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LivraisonID_DroitCoupeID via shared members
				/// </summary>
				public sealed class Column_LivraisonID_DroitCoupeID {

					/// <summary>
					/// Returns "LivraisonID_DroitCoupeID"
					/// </summary>
					public const System.String ColumnName = "LivraisonID_DroitCoupeID";
					/// <summary>
					/// Returns 41
					/// </summary>
					public const System.Int32 ColumnIndex = 41;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LivraisonID_EntentePaiementID via shared members
				/// </summary>
				public sealed class Column_LivraisonID_EntentePaiementID {

					/// <summary>
					/// Returns "LivraisonID_EntentePaiementID"
					/// </summary>
					public const System.String ColumnName = "LivraisonID_EntentePaiementID";
					/// <summary>
					/// Returns 42
					/// </summary>
					public const System.Int32 ColumnIndex = 42;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LivraisonID_TransporteurID via shared members
				/// </summary>
				public sealed class Column_LivraisonID_TransporteurID {

					/// <summary>
					/// Returns "LivraisonID_TransporteurID"
					/// </summary>
					public const System.String ColumnName = "LivraisonID_TransporteurID";
					/// <summary>
					/// Returns 43
					/// </summary>
					public const System.Int32 ColumnIndex = 43;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LivraisonID_VR via shared members
				/// </summary>
				public sealed class Column_LivraisonID_VR {

					/// <summary>
					/// Returns "LivraisonID_VR"
					/// </summary>
					public const System.String ColumnName = "LivraisonID_VR";
					/// <summary>
					/// Returns 44
					/// </summary>
					public const System.Int32 ColumnIndex = 44;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LivraisonID_MasseLimite via shared members
				/// </summary>
				public sealed class Column_LivraisonID_MasseLimite {

					/// <summary>
					/// Returns "LivraisonID_MasseLimite"
					/// </summary>
					public const System.String ColumnName = "LivraisonID_MasseLimite";
					/// <summary>
					/// Returns 45
					/// </summary>
					public const System.Int32 ColumnIndex = 45;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LivraisonID_VolumeBrut via shared members
				/// </summary>
				public sealed class Column_LivraisonID_VolumeBrut {

					/// <summary>
					/// Returns "LivraisonID_VolumeBrut"
					/// </summary>
					public const System.String ColumnName = "LivraisonID_VolumeBrut";
					/// <summary>
					/// Returns 46
					/// </summary>
					public const System.Int32 ColumnIndex = 46;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LivraisonID_VolumeTare via shared members
				/// </summary>
				public sealed class Column_LivraisonID_VolumeTare {

					/// <summary>
					/// Returns "LivraisonID_VolumeTare"
					/// </summary>
					public const System.String ColumnName = "LivraisonID_VolumeTare";
					/// <summary>
					/// Returns 47
					/// </summary>
					public const System.Int32 ColumnIndex = 47;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LivraisonID_VolumeTransporte via shared members
				/// </summary>
				public sealed class Column_LivraisonID_VolumeTransporte {

					/// <summary>
					/// Returns "LivraisonID_VolumeTransporte"
					/// </summary>
					public const System.String ColumnName = "LivraisonID_VolumeTransporte";
					/// <summary>
					/// Returns 48
					/// </summary>
					public const System.Int32 ColumnIndex = 48;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LivraisonID_VolumeSurcharge via shared members
				/// </summary>
				public sealed class Column_LivraisonID_VolumeSurcharge {

					/// <summary>
					/// Returns "LivraisonID_VolumeSurcharge"
					/// </summary>
					public const System.String ColumnName = "LivraisonID_VolumeSurcharge";
					/// <summary>
					/// Returns 49
					/// </summary>
					public const System.Int32 ColumnIndex = 49;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LivraisonID_VolumeAPayer via shared members
				/// </summary>
				public sealed class Column_LivraisonID_VolumeAPayer {

					/// <summary>
					/// Returns "LivraisonID_VolumeAPayer"
					/// </summary>
					public const System.String ColumnName = "LivraisonID_VolumeAPayer";
					/// <summary>
					/// Returns 50
					/// </summary>
					public const System.Int32 ColumnIndex = 50;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LivraisonID_Annee via shared members
				/// </summary>
				public sealed class Column_LivraisonID_Annee {

					/// <summary>
					/// Returns "LivraisonID_Annee"
					/// </summary>
					public const System.String ColumnName = "LivraisonID_Annee";
					/// <summary>
					/// Returns 51
					/// </summary>
					public const System.Int32 ColumnIndex = 51;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LivraisonID_Periode via shared members
				/// </summary>
				public sealed class Column_LivraisonID_Periode {

					/// <summary>
					/// Returns "LivraisonID_Periode"
					/// </summary>
					public const System.String ColumnName = "LivraisonID_Periode";
					/// <summary>
					/// Returns 52
					/// </summary>
					public const System.Int32 ColumnIndex = 52;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LivraisonID_DateCalcul via shared members
				/// </summary>
				public sealed class Column_LivraisonID_DateCalcul {

					/// <summary>
					/// Returns "LivraisonID_DateCalcul"
					/// </summary>
					public const System.String ColumnName = "LivraisonID_DateCalcul";
					/// <summary>
					/// Returns 53
					/// </summary>
					public const System.Int32 ColumnIndex = 53;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LivraisonID_Taux_Transporteur via shared members
				/// </summary>
				public sealed class Column_LivraisonID_Taux_Transporteur {

					/// <summary>
					/// Returns "LivraisonID_Taux_Transporteur"
					/// </summary>
					public const System.String ColumnName = "LivraisonID_Taux_Transporteur";
					/// <summary>
					/// Returns 54
					/// </summary>
					public const System.Int32 ColumnIndex = 54;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LivraisonID_Montant_Transporteur via shared members
				/// </summary>
				public sealed class Column_LivraisonID_Montant_Transporteur {

					/// <summary>
					/// Returns "LivraisonID_Montant_Transporteur"
					/// </summary>
					public const System.String ColumnName = "LivraisonID_Montant_Transporteur";
					/// <summary>
					/// Returns 55
					/// </summary>
					public const System.Int32 ColumnIndex = 55;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LivraisonID_Montant_Usine via shared members
				/// </summary>
				public sealed class Column_LivraisonID_Montant_Usine {

					/// <summary>
					/// Returns "LivraisonID_Montant_Usine"
					/// </summary>
					public const System.String ColumnName = "LivraisonID_Montant_Usine";
					/// <summary>
					/// Returns 56
					/// </summary>
					public const System.Int32 ColumnIndex = 56;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LivraisonID_Montant_Producteur1 via shared members
				/// </summary>
				public sealed class Column_LivraisonID_Montant_Producteur1 {

					/// <summary>
					/// Returns "LivraisonID_Montant_Producteur1"
					/// </summary>
					public const System.String ColumnName = "LivraisonID_Montant_Producteur1";
					/// <summary>
					/// Returns 57
					/// </summary>
					public const System.Int32 ColumnIndex = 57;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LivraisonID_Montant_Producteur2 via shared members
				/// </summary>
				public sealed class Column_LivraisonID_Montant_Producteur2 {

					/// <summary>
					/// Returns "LivraisonID_Montant_Producteur2"
					/// </summary>
					public const System.String ColumnName = "LivraisonID_Montant_Producteur2";
					/// <summary>
					/// Returns 58
					/// </summary>
					public const System.Int32 ColumnIndex = 58;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LivraisonID_Montant_Preleve_Plan_Conjoint via shared members
				/// </summary>
				public sealed class Column_LivraisonID_Montant_Preleve_Plan_Conjoint {

					/// <summary>
					/// Returns "LivraisonID_Montant_Preleve_Plan_Conjoint"
					/// </summary>
					public const System.String ColumnName = "LivraisonID_Montant_Preleve_Plan_Conjoint";
					/// <summary>
					/// Returns 59
					/// </summary>
					public const System.Int32 ColumnIndex = 59;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LivraisonID_Montant_Preleve_Fond_Roulement via shared members
				/// </summary>
				public sealed class Column_LivraisonID_Montant_Preleve_Fond_Roulement {

					/// <summary>
					/// Returns "LivraisonID_Montant_Preleve_Fond_Roulement"
					/// </summary>
					public const System.String ColumnName = "LivraisonID_Montant_Preleve_Fond_Roulement";
					/// <summary>
					/// Returns 60
					/// </summary>
					public const System.Int32 ColumnIndex = 60;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LivraisonID_Montant_Preleve_Fond_Forestier via shared members
				/// </summary>
				public sealed class Column_LivraisonID_Montant_Preleve_Fond_Forestier {

					/// <summary>
					/// Returns "LivraisonID_Montant_Preleve_Fond_Forestier"
					/// </summary>
					public const System.String ColumnName = "LivraisonID_Montant_Preleve_Fond_Forestier";
					/// <summary>
					/// Returns 61
					/// </summary>
					public const System.Int32 ColumnIndex = 61;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LivraisonID_Montant_Preleve_Divers via shared members
				/// </summary>
				public sealed class Column_LivraisonID_Montant_Preleve_Divers {

					/// <summary>
					/// Returns "LivraisonID_Montant_Preleve_Divers"
					/// </summary>
					public const System.String ColumnName = "LivraisonID_Montant_Preleve_Divers";
					/// <summary>
					/// Returns 62
					/// </summary>
					public const System.Int32 ColumnIndex = 62;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LivraisonID_Montant_Surcharge via shared members
				/// </summary>
				public sealed class Column_LivraisonID_Montant_Surcharge {

					/// <summary>
					/// Returns "LivraisonID_Montant_Surcharge"
					/// </summary>
					public const System.String ColumnName = "LivraisonID_Montant_Surcharge";
					/// <summary>
					/// Returns 63
					/// </summary>
					public const System.Int32 ColumnIndex = 63;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LivraisonID_Montant_MiseEnCommun via shared members
				/// </summary>
				public sealed class Column_LivraisonID_Montant_MiseEnCommun {

					/// <summary>
					/// Returns "LivraisonID_Montant_MiseEnCommun"
					/// </summary>
					public const System.String ColumnName = "LivraisonID_Montant_MiseEnCommun";
					/// <summary>
					/// Returns 64
					/// </summary>
					public const System.Int32 ColumnIndex = 64;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LivraisonID_Facture via shared members
				/// </summary>
				public sealed class Column_LivraisonID_Facture {

					/// <summary>
					/// Returns "LivraisonID_Facture"
					/// </summary>
					public const System.String ColumnName = "LivraisonID_Facture";
					/// <summary>
					/// Returns 65
					/// </summary>
					public const System.Int32 ColumnIndex = 65;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LivraisonID_Producteur1_FactureID via shared members
				/// </summary>
				public sealed class Column_LivraisonID_Producteur1_FactureID {

					/// <summary>
					/// Returns "LivraisonID_Producteur1_FactureID"
					/// </summary>
					public const System.String ColumnName = "LivraisonID_Producteur1_FactureID";
					/// <summary>
					/// Returns 66
					/// </summary>
					public const System.Int32 ColumnIndex = 66;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LivraisonID_Producteur2_FactureID via shared members
				/// </summary>
				public sealed class Column_LivraisonID_Producteur2_FactureID {

					/// <summary>
					/// Returns "LivraisonID_Producteur2_FactureID"
					/// </summary>
					public const System.String ColumnName = "LivraisonID_Producteur2_FactureID";
					/// <summary>
					/// Returns 67
					/// </summary>
					public const System.Int32 ColumnIndex = 67;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LivraisonID_Transporteur_FactureID via shared members
				/// </summary>
				public sealed class Column_LivraisonID_Transporteur_FactureID {

					/// <summary>
					/// Returns "LivraisonID_Transporteur_FactureID"
					/// </summary>
					public const System.String ColumnName = "LivraisonID_Transporteur_FactureID";
					/// <summary>
					/// Returns 68
					/// </summary>
					public const System.Int32 ColumnIndex = 68;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LivraisonID_Usine_FactureID via shared members
				/// </summary>
				public sealed class Column_LivraisonID_Usine_FactureID {

					/// <summary>
					/// Returns "LivraisonID_Usine_FactureID"
					/// </summary>
					public const System.String ColumnName = "LivraisonID_Usine_FactureID";
					/// <summary>
					/// Returns 69
					/// </summary>
					public const System.Int32 ColumnIndex = 69;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LivraisonID_ErreurCalcul via shared members
				/// </summary>
				public sealed class Column_LivraisonID_ErreurCalcul {

					/// <summary>
					/// Returns "LivraisonID_ErreurCalcul"
					/// </summary>
					public const System.String ColumnName = "LivraisonID_ErreurCalcul";
					/// <summary>
					/// Returns 70
					/// </summary>
					public const System.Int32 ColumnIndex = 70;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LivraisonID_ErreurDescription via shared members
				/// </summary>
				public sealed class Column_LivraisonID_ErreurDescription {

					/// <summary>
					/// Returns "LivraisonID_ErreurDescription"
					/// </summary>
					public const System.String ColumnName = "LivraisonID_ErreurDescription";
					/// <summary>
					/// Returns 71
					/// </summary>
					public const System.Int32 ColumnIndex = 71;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LivraisonID_LotID via shared members
				/// </summary>
				public sealed class Column_LivraisonID_LotID {

					/// <summary>
					/// Returns "LivraisonID_LotID"
					/// </summary>
					public const System.String ColumnName = "LivraisonID_LotID";
					/// <summary>
					/// Returns 72
					/// </summary>
					public const System.Int32 ColumnIndex = 72;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LivraisonID_Taux_Transporteur_Override via shared members
				/// </summary>
				public sealed class Column_LivraisonID_Taux_Transporteur_Override {

					/// <summary>
					/// Returns "LivraisonID_Taux_Transporteur_Override"
					/// </summary>
					public const System.String ColumnName = "LivraisonID_Taux_Transporteur_Override";
					/// <summary>
					/// Returns 73
					/// </summary>
					public const System.Int32 ColumnIndex = 73;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LivraisonID_PaieTransporteur via shared members
				/// </summary>
				public sealed class Column_LivraisonID_PaieTransporteur {

					/// <summary>
					/// Returns "LivraisonID_PaieTransporteur"
					/// </summary>
					public const System.String ColumnName = "LivraisonID_PaieTransporteur";
					/// <summary>
					/// Returns 74
					/// </summary>
					public const System.Int32 ColumnIndex = 74;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LivraisonID_VolumeSurcharge_Override via shared members
				/// </summary>
				public sealed class Column_LivraisonID_VolumeSurcharge_Override {

					/// <summary>
					/// Returns "LivraisonID_VolumeSurcharge_Override"
					/// </summary>
					public const System.String ColumnName = "LivraisonID_VolumeSurcharge_Override";
					/// <summary>
					/// Returns 75
					/// </summary>
					public const System.Int32 ColumnIndex = 75;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LivraisonID_SurchargeManuel via shared members
				/// </summary>
				public sealed class Column_LivraisonID_SurchargeManuel {

					/// <summary>
					/// Returns "LivraisonID_SurchargeManuel"
					/// </summary>
					public const System.String ColumnName = "LivraisonID_SurchargeManuel";
					/// <summary>
					/// Returns 76
					/// </summary>
					public const System.Int32 ColumnIndex = 76;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LivraisonID_Code via shared members
				/// </summary>
				public sealed class Column_LivraisonID_Code {

					/// <summary>
					/// Returns "LivraisonID_Code"
					/// </summary>
					public const System.String ColumnName = "LivraisonID_Code";
					/// <summary>
					/// Returns 77
					/// </summary>
					public const System.Int32 ColumnIndex = 77;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LivraisonID_NombrePermis via shared members
				/// </summary>
				public sealed class Column_LivraisonID_NombrePermis {

					/// <summary>
					/// Returns "LivraisonID_NombrePermis"
					/// </summary>
					public const System.String ColumnName = "LivraisonID_NombrePermis";
					/// <summary>
					/// Returns 78
					/// </summary>
					public const System.Int32 ColumnIndex = 78;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LivraisonID_ZoneID via shared members
				/// </summary>
				public sealed class Column_LivraisonID_ZoneID {

					/// <summary>
					/// Returns "LivraisonID_ZoneID"
					/// </summary>
					public const System.String ColumnName = "LivraisonID_ZoneID";
					/// <summary>
					/// Returns 79
					/// </summary>
					public const System.Int32 ColumnIndex = 79;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LivraisonID_MunicipaliteID via shared members
				/// </summary>
				public sealed class Column_LivraisonID_MunicipaliteID {

					/// <summary>
					/// Returns "LivraisonID_MunicipaliteID"
					/// </summary>
					public const System.String ColumnName = "LivraisonID_MunicipaliteID";
					/// <summary>
					/// Returns 80
					/// </summary>
					public const System.Int32 ColumnIndex = 80;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LivraisonID_ChargeurID via shared members
				/// </summary>
				public sealed class Column_LivraisonID_ChargeurID {

					/// <summary>
					/// Returns "LivraisonID_ChargeurID"
					/// </summary>
					public const System.String ColumnName = "LivraisonID_ChargeurID";
					/// <summary>
					/// Returns 81
					/// </summary>
					public const System.Int32 ColumnIndex = 81;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LivraisonID_Montant_Chargeur via shared members
				/// </summary>
				public sealed class Column_LivraisonID_Montant_Chargeur {

					/// <summary>
					/// Returns "LivraisonID_Montant_Chargeur"
					/// </summary>
					public const System.String ColumnName = "LivraisonID_Montant_Chargeur";
					/// <summary>
					/// Returns 82
					/// </summary>
					public const System.Int32 ColumnIndex = 82;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LivraisonID_Frais_ChargeurAuProducteur via shared members
				/// </summary>
				public sealed class Column_LivraisonID_Frais_ChargeurAuProducteur {

					/// <summary>
					/// Returns "LivraisonID_Frais_ChargeurAuProducteur"
					/// </summary>
					public const System.String ColumnName = "LivraisonID_Frais_ChargeurAuProducteur";
					/// <summary>
					/// Returns 83
					/// </summary>
					public const System.Int32 ColumnIndex = 83;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LivraisonID_Frais_ChargeurAuTransporteur via shared members
				/// </summary>
				public sealed class Column_LivraisonID_Frais_ChargeurAuTransporteur {

					/// <summary>
					/// Returns "LivraisonID_Frais_ChargeurAuTransporteur"
					/// </summary>
					public const System.String ColumnName = "LivraisonID_Frais_ChargeurAuTransporteur";
					/// <summary>
					/// Returns 84
					/// </summary>
					public const System.Int32 ColumnIndex = 84;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LivraisonID_Frais_AutresAuProducteur via shared members
				/// </summary>
				public sealed class Column_LivraisonID_Frais_AutresAuProducteur {

					/// <summary>
					/// Returns "LivraisonID_Frais_AutresAuProducteur"
					/// </summary>
					public const System.String ColumnName = "LivraisonID_Frais_AutresAuProducteur";
					/// <summary>
					/// Returns 85
					/// </summary>
					public const System.Int32 ColumnIndex = 85;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LivraisonID_Frais_AutresAuProducteurDescription via shared members
				/// </summary>
				public sealed class Column_LivraisonID_Frais_AutresAuProducteurDescription {

					/// <summary>
					/// Returns "LivraisonID_Frais_AutresAuProducteurDescription"
					/// </summary>
					public const System.String ColumnName = "LivraisonID_Frais_AutresAuProducteurDescription";
					/// <summary>
					/// Returns 86
					/// </summary>
					public const System.Int32 ColumnIndex = 86;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LivraisonID_Frais_AutresAuTransporteur via shared members
				/// </summary>
				public sealed class Column_LivraisonID_Frais_AutresAuTransporteur {

					/// <summary>
					/// Returns "LivraisonID_Frais_AutresAuTransporteur"
					/// </summary>
					public const System.String ColumnName = "LivraisonID_Frais_AutresAuTransporteur";
					/// <summary>
					/// Returns 87
					/// </summary>
					public const System.Int32 ColumnIndex = 87;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LivraisonID_Frais_AutresAuTransporteurDescription via shared members
				/// </summary>
				public sealed class Column_LivraisonID_Frais_AutresAuTransporteurDescription {

					/// <summary>
					/// Returns "LivraisonID_Frais_AutresAuTransporteurDescription"
					/// </summary>
					public const System.String ColumnName = "LivraisonID_Frais_AutresAuTransporteurDescription";
					/// <summary>
					/// Returns 88
					/// </summary>
					public const System.Int32 ColumnIndex = 88;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LivraisonID_Frais_CompensationDeDeplacement via shared members
				/// </summary>
				public sealed class Column_LivraisonID_Frais_CompensationDeDeplacement {

					/// <summary>
					/// Returns "LivraisonID_Frais_CompensationDeDeplacement"
					/// </summary>
					public const System.String ColumnName = "LivraisonID_Frais_CompensationDeDeplacement";
					/// <summary>
					/// Returns 89
					/// </summary>
					public const System.Int32 ColumnIndex = 89;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LivraisonID_Chargeur_FactureID via shared members
				/// </summary>
				public sealed class Column_LivraisonID_Chargeur_FactureID {

					/// <summary>
					/// Returns "LivraisonID_Chargeur_FactureID"
					/// </summary>
					public const System.String ColumnName = "LivraisonID_Chargeur_FactureID";
					/// <summary>
					/// Returns 90
					/// </summary>
					public const System.Int32 ColumnIndex = 90;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LivraisonID_Commentaires_Producteur via shared members
				/// </summary>
				public sealed class Column_LivraisonID_Commentaires_Producteur {

					/// <summary>
					/// Returns "LivraisonID_Commentaires_Producteur"
					/// </summary>
					public const System.String ColumnName = "LivraisonID_Commentaires_Producteur";
					/// <summary>
					/// Returns 91
					/// </summary>
					public const System.Int32 ColumnIndex = 91;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LivraisonID_Commentaires_Transporteur via shared members
				/// </summary>
				public sealed class Column_LivraisonID_Commentaires_Transporteur {

					/// <summary>
					/// Returns "LivraisonID_Commentaires_Transporteur"
					/// </summary>
					public const System.String ColumnName = "LivraisonID_Commentaires_Transporteur";
					/// <summary>
					/// Returns 92
					/// </summary>
					public const System.Int32 ColumnIndex = 92;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LivraisonID_Commentaires_Chargeur via shared members
				/// </summary>
				public sealed class Column_LivraisonID_Commentaires_Chargeur {

					/// <summary>
					/// Returns "LivraisonID_Commentaires_Chargeur"
					/// </summary>
					public const System.String ColumnName = "LivraisonID_Commentaires_Chargeur";
					/// <summary>
					/// Returns 93
					/// </summary>
					public const System.Int32 ColumnIndex = 93;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LivraisonID_TauxChargeurAuProducteur via shared members
				/// </summary>
				public sealed class Column_LivraisonID_TauxChargeurAuProducteur {

					/// <summary>
					/// Returns "LivraisonID_TauxChargeurAuProducteur"
					/// </summary>
					public const System.String ColumnName = "LivraisonID_TauxChargeurAuProducteur";
					/// <summary>
					/// Returns 94
					/// </summary>
					public const System.Int32 ColumnIndex = 94;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LivraisonID_TauxChargeurAuTransporteur via shared members
				/// </summary>
				public sealed class Column_LivraisonID_TauxChargeurAuTransporteur {

					/// <summary>
					/// Returns "LivraisonID_TauxChargeurAuTransporteur"
					/// </summary>
					public const System.String ColumnName = "LivraisonID_TauxChargeurAuTransporteur";
					/// <summary>
					/// Returns 95
					/// </summary>
					public const System.Int32 ColumnIndex = 95;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LivraisonID_Frais_AutresRevenusTransporteur via shared members
				/// </summary>
				public sealed class Column_LivraisonID_Frais_AutresRevenusTransporteur {

					/// <summary>
					/// Returns "LivraisonID_Frais_AutresRevenusTransporteur"
					/// </summary>
					public const System.String ColumnName = "LivraisonID_Frais_AutresRevenusTransporteur";
					/// <summary>
					/// Returns 96
					/// </summary>
					public const System.Int32 ColumnIndex = 96;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LivraisonID_Frais_AutresRevenusTransporteurDescription via shared members
				/// </summary>
				public sealed class Column_LivraisonID_Frais_AutresRevenusTransporteurDescription {

					/// <summary>
					/// Returns "LivraisonID_Frais_AutresRevenusTransporteurDescription"
					/// </summary>
					public const System.String ColumnName = "LivraisonID_Frais_AutresRevenusTransporteurDescription";
					/// <summary>
					/// Returns 97
					/// </summary>
					public const System.Int32 ColumnIndex = 97;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LivraisonID_Frais_AutresRevenusProducteur via shared members
				/// </summary>
				public sealed class Column_LivraisonID_Frais_AutresRevenusProducteur {

					/// <summary>
					/// Returns "LivraisonID_Frais_AutresRevenusProducteur"
					/// </summary>
					public const System.String ColumnName = "LivraisonID_Frais_AutresRevenusProducteur";
					/// <summary>
					/// Returns 98
					/// </summary>
					public const System.Int32 ColumnIndex = 98;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LivraisonID_Frais_AutresRevenusProducteurDescription via shared members
				/// </summary>
				public sealed class Column_LivraisonID_Frais_AutresRevenusProducteurDescription {

					/// <summary>
					/// Returns "LivraisonID_Frais_AutresRevenusProducteurDescription"
					/// </summary>
					public const System.String ColumnName = "LivraisonID_Frais_AutresRevenusProducteurDescription";
					/// <summary>
					/// Returns 99
					/// </summary>
					public const System.Int32 ColumnIndex = 99;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field LivraisonID_Montant_SurchargeProducteur via shared members
				/// </summary>
				public sealed class Column_LivraisonID_Montant_SurchargeProducteur {

					/// <summary>
					/// Returns "LivraisonID_Montant_SurchargeProducteur"
					/// </summary>
					public const System.String ColumnName = "LivraisonID_Montant_SurchargeProducteur";
					/// <summary>
					/// Returns 100
					/// </summary>
					public const System.Int32 ColumnIndex = 100;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ContratID_ContratID via shared members
				/// </summary>
				public sealed class Column_ContratID_ContratID {

					/// <summary>
					/// Returns "ContratID_ContratID"
					/// </summary>
					public const System.String ColumnName = "ContratID_ContratID";
					/// <summary>
					/// Returns 101
					/// </summary>
					public const System.Int32 ColumnIndex = 101;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ContratID_EssenceID via shared members
				/// </summary>
				public sealed class Column_ContratID_EssenceID {

					/// <summary>
					/// Returns "ContratID_EssenceID"
					/// </summary>
					public const System.String ColumnName = "ContratID_EssenceID";
					/// <summary>
					/// Returns 102
					/// </summary>
					public const System.Int32 ColumnIndex = 102;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ContratID_UniteID via shared members
				/// </summary>
				public sealed class Column_ContratID_UniteID {

					/// <summary>
					/// Returns "ContratID_UniteID"
					/// </summary>
					public const System.String ColumnName = "ContratID_UniteID";
					/// <summary>
					/// Returns 103
					/// </summary>
					public const System.Int32 ColumnIndex = 103;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ContratID_Code via shared members
				/// </summary>
				public sealed class Column_ContratID_Code {

					/// <summary>
					/// Returns "ContratID_Code"
					/// </summary>
					public const System.String ColumnName = "ContratID_Code";
					/// <summary>
					/// Returns 104
					/// </summary>
					public const System.Int32 ColumnIndex = 104;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ContratID_Quantite_prevue via shared members
				/// </summary>
				public sealed class Column_ContratID_Quantite_prevue {

					/// <summary>
					/// Returns "ContratID_Quantite_prevue"
					/// </summary>
					public const System.String ColumnName = "ContratID_Quantite_prevue";
					/// <summary>
					/// Returns 105
					/// </summary>
					public const System.Int32 ColumnIndex = 105;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ContratID_Taux_usine via shared members
				/// </summary>
				public sealed class Column_ContratID_Taux_usine {

					/// <summary>
					/// Returns "ContratID_Taux_usine"
					/// </summary>
					public const System.String ColumnName = "ContratID_Taux_usine";
					/// <summary>
					/// Returns 106
					/// </summary>
					public const System.Int32 ColumnIndex = 106;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ContratID_Taux_producteur via shared members
				/// </summary>
				public sealed class Column_ContratID_Taux_producteur {

					/// <summary>
					/// Returns "ContratID_Taux_producteur"
					/// </summary>
					public const System.String ColumnName = "ContratID_Taux_producteur";
					/// <summary>
					/// Returns 107
					/// </summary>
					public const System.Int32 ColumnIndex = 107;

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
					/// Returns 108
					/// </summary>
					public const System.Int32 ColumnIndex = 108;

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
					/// Returns 109
					/// </summary>
					public const System.Int32 ColumnIndex = 109;

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
					/// Returns 110
					/// </summary>
					public const System.Int32 ColumnIndex = 110;

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
					/// Returns 111
					/// </summary>
					public const System.Int32 ColumnIndex = 111;

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
					/// Returns 112
					/// </summary>
					public const System.Int32 ColumnIndex = 112;

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
					/// Returns 113
					/// </summary>
					public const System.Int32 ColumnIndex = 113;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field EssenceID_Quantite_prevue via shared members
				/// </summary>
				public sealed class Column_EssenceID_Quantite_prevue {

					/// <summary>
					/// Returns "EssenceID_Quantite_prevue"
					/// </summary>
					public const System.String ColumnName = "EssenceID_Quantite_prevue";
					/// <summary>
					/// Returns 114
					/// </summary>
					public const System.Int32 ColumnIndex = 114;

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
					/// Returns 115
					/// </summary>
					public const System.Int32 ColumnIndex = 115;

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
					/// Returns 116
					/// </summary>
					public const System.Int32 ColumnIndex = 116;

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
					/// Returns 117
					/// </summary>
					public const System.Int32 ColumnIndex = 117;

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
					/// Returns 118
					/// </summary>
					public const System.Int32 ColumnIndex = 118;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field UniteMesureID_ContratID via shared members
				/// </summary>
				public sealed class Column_UniteMesureID_ContratID {

					/// <summary>
					/// Returns "UniteMesureID_ContratID"
					/// </summary>
					public const System.String ColumnName = "UniteMesureID_ContratID";
					/// <summary>
					/// Returns 119
					/// </summary>
					public const System.Int32 ColumnIndex = 119;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field UniteMesureID_EssenceID via shared members
				/// </summary>
				public sealed class Column_UniteMesureID_EssenceID {

					/// <summary>
					/// Returns "UniteMesureID_EssenceID"
					/// </summary>
					public const System.String ColumnName = "UniteMesureID_EssenceID";
					/// <summary>
					/// Returns 120
					/// </summary>
					public const System.Int32 ColumnIndex = 120;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field UniteMesureID_UniteID via shared members
				/// </summary>
				public sealed class Column_UniteMesureID_UniteID {

					/// <summary>
					/// Returns "UniteMesureID_UniteID"
					/// </summary>
					public const System.String ColumnName = "UniteMesureID_UniteID";
					/// <summary>
					/// Returns 121
					/// </summary>
					public const System.Int32 ColumnIndex = 121;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field UniteMesureID_Code via shared members
				/// </summary>
				public sealed class Column_UniteMesureID_Code {

					/// <summary>
					/// Returns "UniteMesureID_Code"
					/// </summary>
					public const System.String ColumnName = "UniteMesureID_Code";
					/// <summary>
					/// Returns 122
					/// </summary>
					public const System.Int32 ColumnIndex = 122;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field UniteMesureID_Quantite_prevue via shared members
				/// </summary>
				public sealed class Column_UniteMesureID_Quantite_prevue {

					/// <summary>
					/// Returns "UniteMesureID_Quantite_prevue"
					/// </summary>
					public const System.String ColumnName = "UniteMesureID_Quantite_prevue";
					/// <summary>
					/// Returns 123
					/// </summary>
					public const System.Int32 ColumnIndex = 123;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field UniteMesureID_Taux_usine via shared members
				/// </summary>
				public sealed class Column_UniteMesureID_Taux_usine {

					/// <summary>
					/// Returns "UniteMesureID_Taux_usine"
					/// </summary>
					public const System.String ColumnName = "UniteMesureID_Taux_usine";
					/// <summary>
					/// Returns 124
					/// </summary>
					public const System.Int32 ColumnIndex = 124;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field UniteMesureID_Taux_producteur via shared members
				/// </summary>
				public sealed class Column_UniteMesureID_Taux_producteur {

					/// <summary>
					/// Returns "UniteMesureID_Taux_producteur"
					/// </summary>
					public const System.String ColumnName = "UniteMesureID_Taux_producteur";
					/// <summary>
					/// Returns 125
					/// </summary>
					public const System.Int32 ColumnIndex = 125;

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
					/// Returns 126
					/// </summary>
					public const System.Int32 ColumnIndex = 126;

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
					/// Returns 127
					/// </summary>
					public const System.Int32 ColumnIndex = 127;

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
					/// Returns 128
					/// </summary>
					public const System.Int32 ColumnIndex = 128;

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
					/// Returns 129
					/// </summary>
					public const System.Int32 ColumnIndex = 129;

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
					/// Returns 130
					/// </summary>
					public const System.Int32 ColumnIndex = 130;

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
					/// Returns 131
					/// </summary>
					public const System.Int32 ColumnIndex = 131;

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
					/// Returns 132
					/// </summary>
					public const System.Int32 ColumnIndex = 132;

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
					/// Returns 133
					/// </summary>
					public const System.Int32 ColumnIndex = 133;

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
					/// Returns 134
					/// </summary>
					public const System.Int32 ColumnIndex = 134;

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
					/// Returns 135
					/// </summary>
					public const System.Int32 ColumnIndex = 135;

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
					/// Returns 136
					/// </summary>
					public const System.Int32 ColumnIndex = 136;

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
					/// Returns 137
					/// </summary>
					public const System.Int32 ColumnIndex = 137;

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
					/// Returns 138
					/// </summary>
					public const System.Int32 ColumnIndex = 138;

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
					/// Returns 139
					/// </summary>
					public const System.Int32 ColumnIndex = 139;

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
					/// Returns 140
					/// </summary>
					public const System.Int32 ColumnIndex = 140;

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
					/// Returns 141
					/// </summary>
					public const System.Int32 ColumnIndex = 141;

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
					/// Returns 142
					/// </summary>
					public const System.Int32 ColumnIndex = 142;

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
					/// Returns 143
					/// </summary>
					public const System.Int32 ColumnIndex = 143;

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
					/// Returns 144
					/// </summary>
					public const System.Int32 ColumnIndex = 144;

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
					/// Returns 145
					/// </summary>
					public const System.Int32 ColumnIndex = 145;

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
					/// Returns 146
					/// </summary>
					public const System.Int32 ColumnIndex = 146;

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
					/// Returns 147
					/// </summary>
					public const System.Int32 ColumnIndex = 147;

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
					/// Returns 148
					/// </summary>
					public const System.Int32 ColumnIndex = 148;

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
					/// Returns 149
					/// </summary>
					public const System.Int32 ColumnIndex = 149;

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
					/// Returns 150
					/// </summary>
					public const System.Int32 ColumnIndex = 150;

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
					/// Returns 151
					/// </summary>
					public const System.Int32 ColumnIndex = 151;

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
					/// Returns 152
					/// </summary>
					public const System.Int32 ColumnIndex = 152;

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
					/// Returns 153
					/// </summary>
					public const System.Int32 ColumnIndex = 153;

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
					/// Returns 154
					/// </summary>
					public const System.Int32 ColumnIndex = 154;

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
					/// Returns 155
					/// </summary>
					public const System.Int32 ColumnIndex = 155;

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
					/// Returns 156
					/// </summary>
					public const System.Int32 ColumnIndex = 156;

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
					/// Returns 157
					/// </summary>
					public const System.Int32 ColumnIndex = 157;

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
					/// Returns 158
					/// </summary>
					public const System.Int32 ColumnIndex = 158;

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
					/// Returns 159
					/// </summary>
					public const System.Int32 ColumnIndex = 159;

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
					/// Returns 160
					/// </summary>
					public const System.Int32 ColumnIndex = 160;

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
					/// Returns 161
					/// </summary>
					public const System.Int32 ColumnIndex = 161;

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
					/// Returns 162
					/// </summary>
					public const System.Int32 ColumnIndex = 162;

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
					/// Returns 163
					/// </summary>
					public const System.Int32 ColumnIndex = 163;

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
					/// Returns 164
					/// </summary>
					public const System.Int32 ColumnIndex = 164;

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
					/// Returns 165
					/// </summary>
					public const System.Int32 ColumnIndex = 165;

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
					/// Returns 166
					/// </summary>
					public const System.Int32 ColumnIndex = 166;

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
					/// Returns 167
					/// </summary>
					public const System.Int32 ColumnIndex = 167;

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
					/// Returns 168
					/// </summary>
					public const System.Int32 ColumnIndex = 168;

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
					/// Returns 169
					/// </summary>
					public const System.Int32 ColumnIndex = 169;

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
					/// Returns 170
					/// </summary>
					public const System.Int32 ColumnIndex = 170;

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
					/// Returns 171
					/// </summary>
					public const System.Int32 ColumnIndex = 171;

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
					/// Returns 172
					/// </summary>
					public const System.Int32 ColumnIndex = 172;

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
					/// Returns 173
					/// </summary>
					public const System.Int32 ColumnIndex = 173;

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
					/// Returns 174
					/// </summary>
					public const System.Int32 ColumnIndex = 174;

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
					/// Returns 175
					/// </summary>
					public const System.Int32 ColumnIndex = 175;

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
					/// Returns 176
					/// </summary>
					public const System.Int32 ColumnIndex = 176;

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
					/// Returns 177
					/// </summary>
					public const System.Int32 ColumnIndex = 177;

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
					/// Returns 178
					/// </summary>
					public const System.Int32 ColumnIndex = 178;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ContingentementID_ID via shared members
				/// </summary>
				public sealed class Column_ContingentementID_ID {

					/// <summary>
					/// Returns "ContingentementID_ID"
					/// </summary>
					public const System.String ColumnName = "ContingentementID_ID";
					/// <summary>
					/// Returns 179
					/// </summary>
					public const System.Int32 ColumnIndex = 179;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ContingentementID_ContingentUsine via shared members
				/// </summary>
				public sealed class Column_ContingentementID_ContingentUsine {

					/// <summary>
					/// Returns "ContingentementID_ContingentUsine"
					/// </summary>
					public const System.String ColumnName = "ContingentementID_ContingentUsine";
					/// <summary>
					/// Returns 180
					/// </summary>
					public const System.Int32 ColumnIndex = 180;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ContingentementID_UsineID via shared members
				/// </summary>
				public sealed class Column_ContingentementID_UsineID {

					/// <summary>
					/// Returns "ContingentementID_UsineID"
					/// </summary>
					public const System.String ColumnName = "ContingentementID_UsineID";
					/// <summary>
					/// Returns 181
					/// </summary>
					public const System.Int32 ColumnIndex = 181;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ContingentementID_RegroupementID via shared members
				/// </summary>
				public sealed class Column_ContingentementID_RegroupementID {

					/// <summary>
					/// Returns "ContingentementID_RegroupementID"
					/// </summary>
					public const System.String ColumnName = "ContingentementID_RegroupementID";
					/// <summary>
					/// Returns 182
					/// </summary>
					public const System.Int32 ColumnIndex = 182;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ContingentementID_Annee via shared members
				/// </summary>
				public sealed class Column_ContingentementID_Annee {

					/// <summary>
					/// Returns "ContingentementID_Annee"
					/// </summary>
					public const System.String ColumnName = "ContingentementID_Annee";
					/// <summary>
					/// Returns 183
					/// </summary>
					public const System.Int32 ColumnIndex = 183;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ContingentementID_PeriodeContingentement via shared members
				/// </summary>
				public sealed class Column_ContingentementID_PeriodeContingentement {

					/// <summary>
					/// Returns "ContingentementID_PeriodeContingentement"
					/// </summary>
					public const System.String ColumnName = "ContingentementID_PeriodeContingentement";
					/// <summary>
					/// Returns 184
					/// </summary>
					public const System.Int32 ColumnIndex = 184;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ContingentementID_PeriodeDebut via shared members
				/// </summary>
				public sealed class Column_ContingentementID_PeriodeDebut {

					/// <summary>
					/// Returns "ContingentementID_PeriodeDebut"
					/// </summary>
					public const System.String ColumnName = "ContingentementID_PeriodeDebut";
					/// <summary>
					/// Returns 185
					/// </summary>
					public const System.Int32 ColumnIndex = 185;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ContingentementID_PeriodeFin via shared members
				/// </summary>
				public sealed class Column_ContingentementID_PeriodeFin {

					/// <summary>
					/// Returns "ContingentementID_PeriodeFin"
					/// </summary>
					public const System.String ColumnName = "ContingentementID_PeriodeFin";
					/// <summary>
					/// Returns 186
					/// </summary>
					public const System.Int32 ColumnIndex = 186;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ContingentementID_EssenceID via shared members
				/// </summary>
				public sealed class Column_ContingentementID_EssenceID {

					/// <summary>
					/// Returns "ContingentementID_EssenceID"
					/// </summary>
					public const System.String ColumnName = "ContingentementID_EssenceID";
					/// <summary>
					/// Returns 187
					/// </summary>
					public const System.Int32 ColumnIndex = 187;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ContingentementID_UniteMesureID via shared members
				/// </summary>
				public sealed class Column_ContingentementID_UniteMesureID {

					/// <summary>
					/// Returns "ContingentementID_UniteMesureID"
					/// </summary>
					public const System.String ColumnName = "ContingentementID_UniteMesureID";
					/// <summary>
					/// Returns 188
					/// </summary>
					public const System.Int32 ColumnIndex = 188;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ContingentementID_Volume_Usine via shared members
				/// </summary>
				public sealed class Column_ContingentementID_Volume_Usine {

					/// <summary>
					/// Returns "ContingentementID_Volume_Usine"
					/// </summary>
					public const System.String ColumnName = "ContingentementID_Volume_Usine";
					/// <summary>
					/// Returns 189
					/// </summary>
					public const System.Int32 ColumnIndex = 189;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ContingentementID_Facteur via shared members
				/// </summary>
				public sealed class Column_ContingentementID_Facteur {

					/// <summary>
					/// Returns "ContingentementID_Facteur"
					/// </summary>
					public const System.String ColumnName = "ContingentementID_Facteur";
					/// <summary>
					/// Returns 190
					/// </summary>
					public const System.Int32 ColumnIndex = 190;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ContingentementID_Volume_Fixe via shared members
				/// </summary>
				public sealed class Column_ContingentementID_Volume_Fixe {

					/// <summary>
					/// Returns "ContingentementID_Volume_Fixe"
					/// </summary>
					public const System.String ColumnName = "ContingentementID_Volume_Fixe";
					/// <summary>
					/// Returns 191
					/// </summary>
					public const System.Int32 ColumnIndex = 191;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ContingentementID_Date_Calcul via shared members
				/// </summary>
				public sealed class Column_ContingentementID_Date_Calcul {

					/// <summary>
					/// Returns "ContingentementID_Date_Calcul"
					/// </summary>
					public const System.String ColumnName = "ContingentementID_Date_Calcul";
					/// <summary>
					/// Returns 192
					/// </summary>
					public const System.Int32 ColumnIndex = 192;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ContingentementID_CalculAccepte via shared members
				/// </summary>
				public sealed class Column_ContingentementID_CalculAccepte {

					/// <summary>
					/// Returns "ContingentementID_CalculAccepte"
					/// </summary>
					public const System.String ColumnName = "ContingentementID_CalculAccepte";
					/// <summary>
					/// Returns 193
					/// </summary>
					public const System.Int32 ColumnIndex = 193;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ContingentementID_Code via shared members
				/// </summary>
				public sealed class Column_ContingentementID_Code {

					/// <summary>
					/// Returns "ContingentementID_Code"
					/// </summary>
					public const System.String ColumnName = "ContingentementID_Code";
					/// <summary>
					/// Returns 194
					/// </summary>
					public const System.Int32 ColumnIndex = 194;

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
					/// Returns 195
					/// </summary>
					public const System.Int32 ColumnIndex = 195;

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
					/// Returns 196
					/// </summary>
					public const System.Int32 ColumnIndex = 196;

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
					/// Returns 197
					/// </summary>
					public const System.Int32 ColumnIndex = 197;

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
					/// Returns 198
					/// </summary>
					public const System.Int32 ColumnIndex = 198;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Code_Quantite_prevue via shared members
				/// </summary>
				public sealed class Column_Code_Quantite_prevue {

					/// <summary>
					/// Returns "Code_Quantite_prevue"
					/// </summary>
					public const System.String ColumnName = "Code_Quantite_prevue";
					/// <summary>
					/// Returns 199
					/// </summary>
					public const System.Int32 ColumnIndex = 199;

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
					/// Returns 200
					/// </summary>
					public const System.Int32 ColumnIndex = 200;

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
					/// Returns 201
					/// </summary>
					public const System.Int32 ColumnIndex = 201;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Code_Actif via shared members
				/// </summary>
				public sealed class Column_Code_Actif {

					/// <summary>
					/// Returns "Code_Actif"
					/// </summary>
					public const System.String ColumnName = "Code_Actif";
					/// <summary>
					/// Returns 202
					/// </summary>
					public const System.Int32 ColumnIndex = 202;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Code_Description via shared members
				/// </summary>
				public sealed class Column_Code_Description {

					/// <summary>
					/// Returns "Code_Description"
					/// </summary>
					public const System.String ColumnName = "Code_Description";
					/// <summary>
					/// Returns 203
					/// </summary>
					public const System.Int32 ColumnIndex = 203;

				}

			}
		}

		/// <summary>
		/// This class allows to easily retrieve the name or index of all the fields
		/// of the resulset #2 existing in the Dataset or the SqlDatReader returned by
		/// the Execute method of the 'spS_Livraison_Detail_Full' class.
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

