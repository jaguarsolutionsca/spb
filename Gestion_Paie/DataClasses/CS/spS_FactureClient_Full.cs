/*
	This C# source code was automatically generated using:

		SQL Server Centric .NET Code Generator
			v 1.0.1287.20792

			Generation Date: 13/09/2006 11:57:14 AM
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
	/// stored procedure 'spS_FactureClient_Full'. It allows also to specify specific connection
	/// information such as the ConnectionString to be use, the command time-out and so forth.
	/// </summary>
	[Serializable()]
#if OLYMARS_ATTRIBUTE || OLYMARS_DEBUG
	[OlymarsInformation(DeveloperName="<Developer Name Here>", GeneratedOn="2006/09/13 15:57:14", SqlObjectDependancyName="spS_FactureClient_Full", SqlObjectDependancyRevision=0)]
#endif
	public sealed class spS_FactureClient_Full : MarshalByRefObject, IDisposable, IParameter {

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
		/// Initializes a new instance of the spS_FactureClient_Full class. If you use this constructor version,
		/// not assigning parameter values implies using the parameter default values.
		/// </summary>
		public spS_FactureClient_Full() : this(true) {

		}

		/// <summary>
		/// Initializes a new instance of the spS_FactureClient_Full class.
		/// </summary>
		/// <param name="useDefaultValue">If True, this parameter indicates that "not assigning parameter values" implies "using the parameter default values". If False, this parameter indicates that "not assigning parameter values" implies "using the SQL Server Null value".</param>
		public spS_FactureClient_Full(bool useDefaultValue) {

			this.useDefaultValue = useDefaultValue;

			this.internal_Param_ID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_TypeFacture_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_TypeInvoiceClientAcomba_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ClientID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_PayerAID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Status_UseDefaultValue = this.useDefaultValue;
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
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'spS_FactureClient_Full'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

						throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "spS_FactureClient_Full", CurrentRevision, OriginalRevision, System.Environment.NewLine));
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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'spS_FactureClient_Full'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlConnection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "spS_FactureClient_Full", CurrentRevision, OriginalRevision, System.Environment.NewLine));
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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'spS_FactureClient_Full'";
				sqlCommand.Transaction = sqlTransaction;

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlTransaction.Connection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "spS_FactureClient_Full", CurrentRevision, OriginalRevision, System.Environment.NewLine));
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
				this.internal_Param_TypeFacture = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_TypeInvoiceClientAcomba = System.Data.SqlTypes.SqlInt32.Null;
				this.internal_Param_ClientID = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_PayerAID = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_Status = System.Data.SqlTypes.SqlString.Null;
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
		~spS_FactureClient_Full() {

			Dispose(false);
		}

		/// <summary>
		/// Returns the stored procedure name for which this class was built, i.e. 'spS_FactureClient_Full'.
		/// </summary>
		public string StoredProcedureName {

			get {

				return("spS_FactureClient_Full");
			}
		}

		private System.Data.SqlTypes.SqlInt32 internal_Param_RETURN_VALUE;

		private System.Data.SqlTypes.SqlInt32 internal_Param_ID;
		internal bool internal_Param_ID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_TypeFacture;
		internal bool internal_Param_TypeFacture_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlInt32 internal_Param_TypeInvoiceClientAcomba;
		internal bool internal_Param_TypeInvoiceClientAcomba_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_ClientID;
		internal bool internal_Param_ClientID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_PayerAID;
		internal bool internal_Param_PayerAID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_Status;
		internal bool internal_Param_Status_UseDefaultValue = true;

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

			this.internal_Param_TypeFacture = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_TypeFacture_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_TypeInvoiceClientAcomba = System.Data.SqlTypes.SqlInt32.Null;
			this.internal_Param_TypeInvoiceClientAcomba_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ClientID = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_ClientID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_PayerAID = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_PayerAID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Status = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_Status_UseDefaultValue = this.useDefaultValue;

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
		/// Sets the value of the stored procedure INPUT parameter '@TypeFacture'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [char](1)
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_TypeFacture_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_TypeFacture {

			get {

				if (this.internal_Param_TypeFacture_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_TypeFacture);
			}

			set {

				this.internal_Param_TypeFacture_UseDefaultValue = false;
				this.internal_Param_TypeFacture = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@TypeFacture' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_TypeFacture_UseDefaultValue() {

			this.internal_Param_TypeFacture_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@TypeInvoiceClientAcomba'.
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
		/// the parameter default value, consider calling the Param_TypeInvoiceClientAcomba_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlInt32 Param_TypeInvoiceClientAcomba {

			get {

				if (this.internal_Param_TypeInvoiceClientAcomba_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_TypeInvoiceClientAcomba);
			}

			set {

				this.internal_Param_TypeInvoiceClientAcomba_UseDefaultValue = false;
				this.internal_Param_TypeInvoiceClientAcomba = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@TypeInvoiceClientAcomba' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_TypeInvoiceClientAcomba_UseDefaultValue() {

			this.internal_Param_TypeInvoiceClientAcomba_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ClientID'.
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
		/// the parameter default value, consider calling the Param_ClientID_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_ClientID {

			get {

				if (this.internal_Param_ClientID_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ClientID);
			}

			set {

				this.internal_Param_ClientID_UseDefaultValue = false;
				this.internal_Param_ClientID = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ClientID' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ClientID_UseDefaultValue() {

			this.internal_Param_ClientID_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@PayerAID'.
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
		/// the parameter default value, consider calling the Param_PayerAID_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_PayerAID {

			get {

				if (this.internal_Param_PayerAID_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_PayerAID);
			}

			set {

				this.internal_Param_PayerAID_UseDefaultValue = false;
				this.internal_Param_PayerAID = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@PayerAID' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_PayerAID_UseDefaultValue() {

			this.internal_Param_PayerAID_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Status'.
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
		/// the parameter default value, consider calling the Param_Status_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_Status {

			get {

				if (this.internal_Param_Status_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Status);
			}

			set {

				this.internal_Param_Status_UseDefaultValue = false;
				this.internal_Param_Status = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Status' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Status_UseDefaultValue() {

			this.internal_Param_Status_UseDefaultValue = true;
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
	/// This class allows you to execute the 'spS_FactureClient_Full' stored procedure;
	/// it gives you the ability to:
	/// <list type="bullet">
	/// <item><description>Set all the necessary parameters to execute the stored procedure</description></item>
	/// <item><description>To execute the stored procedure</description></item>
	/// <item><description>To get back after the execution the return value and all the output parameters value</description></item>
	/// </list>
	/// </summary>
#if OLYMARS_ATTRIBUTE || OLYMARS_DEBUG
	[OlymarsInformation(DeveloperName="<Developer Name Here>", GeneratedOn="2006/09/13 15:57:14", SqlObjectDependancyName="spS_FactureClient_Full", SqlObjectDependancyRevision=0)]
#endif
	public sealed class spS_FactureClient_Full : MarshalByRefObject, IDisposable {


		private bool throwExceptionOnExecute = false;

		/// <summary>
		/// Initializes a new instance of the spS_FactureClient_Full class.
		/// By default, no exception will be thrown when you call the Execute method. Instead, a Boolean return status will be returned.
		/// </summary>
		public spS_FactureClient_Full() : this(false) {

		}

		/// <summary>
		/// Initializes a new instance of the spS_FactureClient_Full class.
		/// </summary>
		/// <param name="throwExceptionOnExecute">True if an exception has to be thrown if the Execute call fails.</param>
		public spS_FactureClient_Full(bool throwExceptionOnExecute) {

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
		~spS_FactureClient_Full() {

			Dispose(false);
		}

		private void ResetParameter(ref Gestion_Paie.DataClasses.Parameters.spS_FactureClient_Full parameters) {

			parameters.internal_Set_RETURN_VALUE (System.Data.SqlTypes.SqlInt32.Null);
		}

		private bool InitializeConnection(ref Gestion_Paie.DataClasses.Parameters.spS_FactureClient_Full parameters, out System.Data.SqlClient.SqlCommand sqlCommand, ref bool connectionMustBeClosed) {

			try {

				this.sqlConnection = null;
				sqlCommand = null;
				connectionMustBeClosed = true;

				if (parameters.ConnectionType == ConnectionType.None) {

					throw new InvalidOperationException("No connection information was supplied. Consider calling the 'SetUpConnection' method of the Gestion_Paie.DataClasses.Parameters.spS_FactureClient_Full object before doing this call.");
				}

				if (parameters.ConnectionType == ConnectionType.SqlConnection && parameters.SqlConnection == null) {

					throw new InvalidOperationException("No connection information was supplied (SqlConnection == null). Consider calling the 'SetUpConnection' method of the Gestion_Paie.DataClasses.Parameters.spS_FactureClient_Full object before doing this call.");
				}

				if (parameters.ConnectionType == ConnectionType.SqlTransaction && parameters.SqlTransaction== null) {

					throw new InvalidOperationException("No connection information was supplied (SqlTransaction == null). Consider calling the 'SetUpConnection' method of the Gestion_Paie.DataClasses.Parameters.spS_FactureClient_Full object before doing this call.");
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

							throw new System.InvalidOperationException("No connection information was supplied (ConnectionString == \"\")! (Gestion_Paie.DataClasses.Parameters.spS_FactureClient_Full)");
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
				sqlCommand.CommandText = "spS_FactureClient_Full";

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

		private bool DeclareParameters(ref Gestion_Paie.DataClasses.Parameters.spS_FactureClient_Full parameters, ref System.Data.SqlClient.SqlCommand sqlCommand) {

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

				sqlParameter = new System.Data.SqlClient.SqlParameter("@TypeFacture", System.Data.SqlDbType.Char, 1);
				sqlParameter.SourceColumn = "TypeFacture";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_TypeFacture_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_TypeFacture.IsNull) {

					sqlParameter.Value = parameters.Param_TypeFacture;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@TypeInvoiceClientAcomba", System.Data.SqlDbType.Int, 4);
				sqlParameter.SourceColumn = "TypeInvoiceClientAcomba";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_TypeInvoiceClientAcomba_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_TypeInvoiceClientAcomba.IsNull) {

					sqlParameter.Value = parameters.Param_TypeInvoiceClientAcomba;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ClientID", System.Data.SqlDbType.VarChar, 6);
				sqlParameter.SourceColumn = "ClientID";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ClientID_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ClientID.IsNull) {

					sqlParameter.Value = parameters.Param_ClientID;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@PayerAID", System.Data.SqlDbType.VarChar, 6);
				sqlParameter.SourceColumn = "PayerAID";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_PayerAID_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_PayerAID.IsNull) {

					sqlParameter.Value = parameters.Param_PayerAID;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Status", System.Data.SqlDbType.VarChar, 15);
				sqlParameter.SourceColumn = "Status";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Status_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Status.IsNull) {

					sqlParameter.Value = parameters.Param_Status;
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

		private bool RetrieveParameters(ref Gestion_Paie.DataClasses.Parameters.spS_FactureClient_Full parameters, ref System.Data.SqlClient.SqlCommand sqlCommand) {

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
		/// This method allows you to execute the [spS_FactureClient_Full] stored procedure and retrieve back the data
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
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.spS_FactureClient_Full parameters, out System.Data.SqlClient.SqlDataReader sqlDataReader) {

			return(Execute(ref parameters, out sqlDataReader, System.Data.CommandBehavior.Default));
		}

		/// <summary>
		/// This method allows you to execute the [spS_FactureClient_Full] stored procedure and retrieve back the data
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
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.spS_FactureClient_Full parameters, out System.Data.SqlClient.SqlDataReader sqlDataReader, System.Data.CommandBehavior commandBehavior) {

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
		/// This method allows you to execute the [spS_FactureClient_Full] stored procedure and retrieve back the data
		/// populated in a DataSet (System.Data.DataSet).
		/// </summary>
		/// <param name="parameters">
		/// Contains all the necessary information to execute correctly the stored procedure, i.e. 
		/// the database connection to use and all the necessary input parameters to be supplied
		/// for this stored procedure execution. After the execution, this object will allow you
		/// to retrieve back the stored procedure return value and all the output parameters.
		/// </param>
		/// <param name="dataset">
		/// Will be populated with the data after execution. The table based name used will be: 'spS_FactureClient_Full'.
		/// </param>
		/// <returns>True if the call was successful. Otherwise, it returns False.</returns>
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.spS_FactureClient_Full parameters, ref System.Data.DataSet dataset) {

			return(Execute(ref parameters, ref dataset, "spS_FactureClient_Full", -1, -1));
		}

		/// <summary>
		/// This method allows you to execute the [spS_FactureClient_Full] stored procedure and retrieve back the data
		/// populated in a DataSet (System.Data.DataSet).
		/// </summary>
		/// <param name="parameters">
		/// Contains all the necessary information to execute correctly the stored procedure, i.e. 
		/// the database connection to use and all the necessary input parameters to be supplied
		/// for this stored procedure execution. After the execution, this object will allow you
		/// to retrieve back the stored procedure return value and all the output parameters.
		/// </param>
		/// <param name="dataset">
		/// Will be populated with the data after execution. The table based name used will be: 'spS_FactureClient_Full'.
		/// </param>
		/// <param name="startRecord">The zero-based record number to start with.</param>
		/// <param name="maxRecords">The maximum number of records to retrieve.</param>
		/// <returns>True if the call was successful. Otherwise, it returns False.</returns>
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.spS_FactureClient_Full parameters, ref System.Data.DataSet dataset, int startRecord, int maxRecords) {

			return(Execute(ref parameters, ref dataset, "spS_FactureClient_Full", startRecord, maxRecords));
		}

		/// <summary>
		/// This method allows you to execute the [spS_FactureClient_Full] stored procedure and retrieve back the data
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
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.spS_FactureClient_Full parameters, ref System.Data.DataSet dataset, string tableName) {

			return(Execute(ref parameters, ref dataset, tableName, -1, -1));
		}

		/// <summary>
		/// This method allows you to execute the [spS_FactureClient_Full] stored procedure and retrieve back the data
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
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.spS_FactureClient_Full parameters, ref System.Data.DataSet dataset, string tableName, int startRecord, int maxRecords) {

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
				dataset.Tables[tableName].Columns["NoFacture"].Caption = "NoFacture (update this label in the \"Olymars/ColumnLabel\" extended property of the \"NoFacture\" column)";
				dataset.Tables[tableName].Columns["DateFacture"].Caption = "DateFacture (update this label in the \"Olymars/ColumnLabel\" extended property of the \"DateFacture\" column)";
				dataset.Tables[tableName].Columns["Annee"].Caption = "Annee (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Annee\" column)";
				dataset.Tables[tableName].Columns["TypeFacture"].Caption = "TypeFacture (update this label in the \"Olymars/ColumnLabel\" extended property of the \"TypeFacture\" column)";
				dataset.Tables[tableName].Columns["TypeInvoiceClientAcomba"].Caption = "TypeInvoiceClientAcomba (update this label in the \"Olymars/ColumnLabel\" extended property of the \"TypeInvoiceClientAcomba\" column)";
				dataset.Tables[tableName].Columns["ClientID"].Caption = "ClientID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ClientID\" column)";
				dataset.Tables[tableName].Columns["PayerAID"].Caption = "PayerAID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"PayerAID\" column)";
				dataset.Tables[tableName].Columns["Montant_Total"].Caption = "Montant_Total (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Montant_Total\" column)";
				dataset.Tables[tableName].Columns["Montant_TPS"].Caption = "Montant_TPS (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Montant_TPS\" column)";
				dataset.Tables[tableName].Columns["Montant_TVQ"].Caption = "Montant_TVQ (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Montant_TVQ\" column)";
				dataset.Tables[tableName].Columns["Description"].Caption = "Description (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Description\" column)";
				dataset.Tables[tableName].Columns["Status"].Caption = "Status (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Status\" column)";
				dataset.Tables[tableName].Columns["StatusDescription"].Caption = "StatusDescription (update this label in the \"Olymars/ColumnLabel\" extended property of the \"StatusDescription\" column)";
				dataset.Tables[tableName].Columns["DateFactureAcomba"].Caption = "DateFactureAcomba (update this label in the \"Olymars/ColumnLabel\" extended property of the \"DateFactureAcomba\" column)";
				dataset.Tables[tableName].Columns["TypeFacture_ID"].Caption = "ID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ID\" column)";
				dataset.Tables[tableName].Columns["TypeFacture_Description"].Caption = "Description (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Description\" column)";
				dataset.Tables[tableName].Columns["TypeFacture_FactureDescriptionMask"].Caption = "FactureDescriptionMask (update this label in the \"Olymars/ColumnLabel\" extended property of the \"FactureDescriptionMask\" column)";
				dataset.Tables[tableName].Columns["TypeInvoiceClientAcomba_ID"].Caption = "ID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ID\" column)";
				dataset.Tables[tableName].Columns["TypeInvoiceClientAcomba_Description"].Caption = "Description (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Description\" column)";
				dataset.Tables[tableName].Columns["ClientID_ID"].Caption = "ID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ID\" column)";
				dataset.Tables[tableName].Columns["ClientID_Description"].Caption = "Description (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Description\" column)";
				dataset.Tables[tableName].Columns["ClientID_UtilisationID"].Caption = "UtilisationID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"UtilisationID\" column)";
				dataset.Tables[tableName].Columns["ClientID_Paye_producteur"].Caption = "Paye_producteur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Paye_producteur\" column)";
				dataset.Tables[tableName].Columns["ClientID_Paye_transporteur"].Caption = "Paye_transporteur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Paye_transporteur\" column)";
				dataset.Tables[tableName].Columns["ClientID_Specification"].Caption = "Specification (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Specification\" column)";
				dataset.Tables[tableName].Columns["ClientID_Compte_a_recevoir"].Caption = "Compte_a_recevoir (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Compte_a_recevoir\" column)";
				dataset.Tables[tableName].Columns["ClientID_Compte_ajustement"].Caption = "Compte_ajustement (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Compte_ajustement\" column)";
				dataset.Tables[tableName].Columns["ClientID_Compte_transporteur"].Caption = "Compte_transporteur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Compte_transporteur\" column)";
				dataset.Tables[tableName].Columns["ClientID_Compte_producteur"].Caption = "Compte_producteur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Compte_producteur\" column)";
				dataset.Tables[tableName].Columns["ClientID_Compte_preleve_plan_conjoint"].Caption = "Compte_preleve_plan_conjoint (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Compte_preleve_plan_conjoint\" column)";
				dataset.Tables[tableName].Columns["ClientID_Compte_preleve_fond_roulement"].Caption = "Compte_preleve_fond_roulement (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Compte_preleve_fond_roulement\" column)";
				dataset.Tables[tableName].Columns["ClientID_Compte_preleve_fond_forestier"].Caption = "Compte_preleve_fond_forestier (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Compte_preleve_fond_forestier\" column)";
				dataset.Tables[tableName].Columns["ClientID_Compte_preleve_divers"].Caption = "Compte_preleve_divers (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Compte_preleve_divers\" column)";
				dataset.Tables[tableName].Columns["ClientID_Compte_mise_en_commun"].Caption = "Compte_mise_en_commun (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Compte_mise_en_commun\" column)";
				dataset.Tables[tableName].Columns["ClientID_Compte_surcharge"].Caption = "Compte_surcharge (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Compte_surcharge\" column)";
				dataset.Tables[tableName].Columns["ClientID_Compte_indexation_carburant"].Caption = "Compte_indexation_carburant (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Compte_indexation_carburant\" column)";
				dataset.Tables[tableName].Columns["ClientID_Actif"].Caption = "Actif (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Actif\" column)";
				dataset.Tables[tableName].Columns["ClientID_NePaiePasTPS"].Caption = "NePaiePasTPS (update this label in the \"Olymars/ColumnLabel\" extended property of the \"NePaiePasTPS\" column)";
				dataset.Tables[tableName].Columns["ClientID_NePaiePasTVQ"].Caption = "NePaiePasTVQ (update this label in the \"Olymars/ColumnLabel\" extended property of the \"NePaiePasTVQ\" column)";
				dataset.Tables[tableName].Columns["ClientID_NoTPS"].Caption = "NoTPS (update this label in the \"Olymars/ColumnLabel\" extended property of the \"NoTPS\" column)";
				dataset.Tables[tableName].Columns["ClientID_NoTVQ"].Caption = "NoTVQ (update this label in the \"Olymars/ColumnLabel\" extended property of the \"NoTVQ\" column)";
				dataset.Tables[tableName].Columns["ClientID_Compte_chargeur"].Caption = "Compte_chargeur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Compte_chargeur\" column)";
				dataset.Tables[tableName].Columns["ClientID_UsineGestionVolume"].Caption = "UsineGestionVolume (update this label in the \"Olymars/ColumnLabel\" extended property of the \"UsineGestionVolume\" column)";
				dataset.Tables[tableName].Columns["ClientID_AuSoinsDe"].Caption = "AuSoinsDe (update this label in the \"Olymars/ColumnLabel\" extended property of the \"AuSoinsDe\" column)";
				dataset.Tables[tableName].Columns["ClientID_Rue"].Caption = "Rue (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Rue\" column)";
				dataset.Tables[tableName].Columns["ClientID_Ville"].Caption = "Ville (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Ville\" column)";
				dataset.Tables[tableName].Columns["ClientID_PaysID"].Caption = "PaysID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"PaysID\" column)";
				dataset.Tables[tableName].Columns["ClientID_Code_postal"].Caption = "Code_postal (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Code_postal\" column)";
				dataset.Tables[tableName].Columns["ClientID_Telephone"].Caption = "Telephone (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone\" column)";
				dataset.Tables[tableName].Columns["ClientID_Telephone_Poste"].Caption = "Telephone_Poste (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone_Poste\" column)";
				dataset.Tables[tableName].Columns["ClientID_Telecopieur"].Caption = "Telecopieur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telecopieur\" column)";
				dataset.Tables[tableName].Columns["ClientID_Telephone2"].Caption = "Telephone2 (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone2\" column)";
				dataset.Tables[tableName].Columns["ClientID_Telephone2_Desc"].Caption = "Telephone2_Desc (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone2_Desc\" column)";
				dataset.Tables[tableName].Columns["ClientID_Telephone2_Poste"].Caption = "Telephone2_Poste (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone2_Poste\" column)";
				dataset.Tables[tableName].Columns["ClientID_Telephone3"].Caption = "Telephone3 (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone3\" column)";
				dataset.Tables[tableName].Columns["ClientID_Telephone3_Desc"].Caption = "Telephone3_Desc (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone3_Desc\" column)";
				dataset.Tables[tableName].Columns["ClientID_Telephone3_Poste"].Caption = "Telephone3_Poste (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone3_Poste\" column)";
				dataset.Tables[tableName].Columns["ClientID_Email"].Caption = "Email (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Email\" column)";
				dataset.Tables[tableName].Columns["PayerAID_ID"].Caption = "ID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ID\" column)";
				dataset.Tables[tableName].Columns["PayerAID_Description"].Caption = "Description (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Description\" column)";
				dataset.Tables[tableName].Columns["PayerAID_UtilisationID"].Caption = "UtilisationID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"UtilisationID\" column)";
				dataset.Tables[tableName].Columns["PayerAID_Paye_producteur"].Caption = "Paye_producteur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Paye_producteur\" column)";
				dataset.Tables[tableName].Columns["PayerAID_Paye_transporteur"].Caption = "Paye_transporteur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Paye_transporteur\" column)";
				dataset.Tables[tableName].Columns["PayerAID_Specification"].Caption = "Specification (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Specification\" column)";
				dataset.Tables[tableName].Columns["PayerAID_Compte_a_recevoir"].Caption = "Compte_a_recevoir (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Compte_a_recevoir\" column)";
				dataset.Tables[tableName].Columns["PayerAID_Compte_ajustement"].Caption = "Compte_ajustement (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Compte_ajustement\" column)";
				dataset.Tables[tableName].Columns["PayerAID_Compte_transporteur"].Caption = "Compte_transporteur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Compte_transporteur\" column)";
				dataset.Tables[tableName].Columns["PayerAID_Compte_producteur"].Caption = "Compte_producteur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Compte_producteur\" column)";
				dataset.Tables[tableName].Columns["PayerAID_Compte_preleve_plan_conjoint"].Caption = "Compte_preleve_plan_conjoint (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Compte_preleve_plan_conjoint\" column)";
				dataset.Tables[tableName].Columns["PayerAID_Compte_preleve_fond_roulement"].Caption = "Compte_preleve_fond_roulement (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Compte_preleve_fond_roulement\" column)";
				dataset.Tables[tableName].Columns["PayerAID_Compte_preleve_fond_forestier"].Caption = "Compte_preleve_fond_forestier (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Compte_preleve_fond_forestier\" column)";
				dataset.Tables[tableName].Columns["PayerAID_Compte_preleve_divers"].Caption = "Compte_preleve_divers (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Compte_preleve_divers\" column)";
				dataset.Tables[tableName].Columns["PayerAID_Compte_mise_en_commun"].Caption = "Compte_mise_en_commun (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Compte_mise_en_commun\" column)";
				dataset.Tables[tableName].Columns["PayerAID_Compte_surcharge"].Caption = "Compte_surcharge (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Compte_surcharge\" column)";
				dataset.Tables[tableName].Columns["PayerAID_Compte_indexation_carburant"].Caption = "Compte_indexation_carburant (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Compte_indexation_carburant\" column)";
				dataset.Tables[tableName].Columns["PayerAID_Actif"].Caption = "Actif (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Actif\" column)";
				dataset.Tables[tableName].Columns["PayerAID_NePaiePasTPS"].Caption = "NePaiePasTPS (update this label in the \"Olymars/ColumnLabel\" extended property of the \"NePaiePasTPS\" column)";
				dataset.Tables[tableName].Columns["PayerAID_NePaiePasTVQ"].Caption = "NePaiePasTVQ (update this label in the \"Olymars/ColumnLabel\" extended property of the \"NePaiePasTVQ\" column)";
				dataset.Tables[tableName].Columns["PayerAID_NoTPS"].Caption = "NoTPS (update this label in the \"Olymars/ColumnLabel\" extended property of the \"NoTPS\" column)";
				dataset.Tables[tableName].Columns["PayerAID_NoTVQ"].Caption = "NoTVQ (update this label in the \"Olymars/ColumnLabel\" extended property of the \"NoTVQ\" column)";
				dataset.Tables[tableName].Columns["PayerAID_Compte_chargeur"].Caption = "Compte_chargeur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Compte_chargeur\" column)";
				dataset.Tables[tableName].Columns["PayerAID_UsineGestionVolume"].Caption = "UsineGestionVolume (update this label in the \"Olymars/ColumnLabel\" extended property of the \"UsineGestionVolume\" column)";
				dataset.Tables[tableName].Columns["PayerAID_AuSoinsDe"].Caption = "AuSoinsDe (update this label in the \"Olymars/ColumnLabel\" extended property of the \"AuSoinsDe\" column)";
				dataset.Tables[tableName].Columns["PayerAID_Rue"].Caption = "Rue (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Rue\" column)";
				dataset.Tables[tableName].Columns["PayerAID_Ville"].Caption = "Ville (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Ville\" column)";
				dataset.Tables[tableName].Columns["PayerAID_PaysID"].Caption = "PaysID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"PaysID\" column)";
				dataset.Tables[tableName].Columns["PayerAID_Code_postal"].Caption = "Code_postal (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Code_postal\" column)";
				dataset.Tables[tableName].Columns["PayerAID_Telephone"].Caption = "Telephone (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone\" column)";
				dataset.Tables[tableName].Columns["PayerAID_Telephone_Poste"].Caption = "Telephone_Poste (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone_Poste\" column)";
				dataset.Tables[tableName].Columns["PayerAID_Telecopieur"].Caption = "Telecopieur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telecopieur\" column)";
				dataset.Tables[tableName].Columns["PayerAID_Telephone2"].Caption = "Telephone2 (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone2\" column)";
				dataset.Tables[tableName].Columns["PayerAID_Telephone2_Desc"].Caption = "Telephone2_Desc (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone2_Desc\" column)";
				dataset.Tables[tableName].Columns["PayerAID_Telephone2_Poste"].Caption = "Telephone2_Poste (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone2_Poste\" column)";
				dataset.Tables[tableName].Columns["PayerAID_Telephone3"].Caption = "Telephone3 (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone3\" column)";
				dataset.Tables[tableName].Columns["PayerAID_Telephone3_Desc"].Caption = "Telephone3_Desc (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone3_Desc\" column)";
				dataset.Tables[tableName].Columns["PayerAID_Telephone3_Poste"].Caption = "Telephone3_Poste (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone3_Poste\" column)";
				dataset.Tables[tableName].Columns["PayerAID_Email"].Caption = "Email (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Email\" column)";
				dataset.Tables[tableName].Columns["Status_ID"].Caption = "ID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ID\" column)";

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
		/// This method allows you to execute the [spS_FactureClient_Full] stored procedure and retrieve back the data
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
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.spS_FactureClient_Full parameters, ref string xml) {

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
		/// This method allows you to execute the [spS_FactureClient_Full] stored procedure and retrieve back the data
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
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.spS_FactureClient_Full parameters, out System.Xml.XmlReader xmlReader) {

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
		/// the Execute method of the 'spS_FactureClient_Full' class.
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
				/// Allows to get the Index and Name of the field NoFacture via shared members
				/// </summary>
				public sealed class Column_NoFacture {

					/// <summary>
					/// Returns "NoFacture"
					/// </summary>
					public const System.String ColumnName = "NoFacture";
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
				/// Allows to get the Index and Name of the field Annee via shared members
				/// </summary>
				public sealed class Column_Annee {

					/// <summary>
					/// Returns "Annee"
					/// </summary>
					public const System.String ColumnName = "Annee";
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
				/// Allows to get the Index and Name of the field TypeInvoiceClientAcomba via shared members
				/// </summary>
				public sealed class Column_TypeInvoiceClientAcomba {

					/// <summary>
					/// Returns "TypeInvoiceClientAcomba"
					/// </summary>
					public const System.String ColumnName = "TypeInvoiceClientAcomba";
					/// <summary>
					/// Returns 5
					/// </summary>
					public const System.Int32 ColumnIndex = 5;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ClientID via shared members
				/// </summary>
				public sealed class Column_ClientID {

					/// <summary>
					/// Returns "ClientID"
					/// </summary>
					public const System.String ColumnName = "ClientID";
					/// <summary>
					/// Returns 6
					/// </summary>
					public const System.Int32 ColumnIndex = 6;

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
					/// Returns 7
					/// </summary>
					public const System.Int32 ColumnIndex = 7;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Montant_Total via shared members
				/// </summary>
				public sealed class Column_Montant_Total {

					/// <summary>
					/// Returns "Montant_Total"
					/// </summary>
					public const System.String ColumnName = "Montant_Total";
					/// <summary>
					/// Returns 8
					/// </summary>
					public const System.Int32 ColumnIndex = 8;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Montant_TPS via shared members
				/// </summary>
				public sealed class Column_Montant_TPS {

					/// <summary>
					/// Returns "Montant_TPS"
					/// </summary>
					public const System.String ColumnName = "Montant_TPS";
					/// <summary>
					/// Returns 9
					/// </summary>
					public const System.Int32 ColumnIndex = 9;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Montant_TVQ via shared members
				/// </summary>
				public sealed class Column_Montant_TVQ {

					/// <summary>
					/// Returns "Montant_TVQ"
					/// </summary>
					public const System.String ColumnName = "Montant_TVQ";
					/// <summary>
					/// Returns 10
					/// </summary>
					public const System.Int32 ColumnIndex = 10;

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
					/// Returns 11
					/// </summary>
					public const System.Int32 ColumnIndex = 11;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Status via shared members
				/// </summary>
				public sealed class Column_Status {

					/// <summary>
					/// Returns "Status"
					/// </summary>
					public const System.String ColumnName = "Status";
					/// <summary>
					/// Returns 12
					/// </summary>
					public const System.Int32 ColumnIndex = 12;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field StatusDescription via shared members
				/// </summary>
				public sealed class Column_StatusDescription {

					/// <summary>
					/// Returns "StatusDescription"
					/// </summary>
					public const System.String ColumnName = "StatusDescription";
					/// <summary>
					/// Returns 13
					/// </summary>
					public const System.Int32 ColumnIndex = 13;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field DateFactureAcomba via shared members
				/// </summary>
				public sealed class Column_DateFactureAcomba {

					/// <summary>
					/// Returns "DateFactureAcomba"
					/// </summary>
					public const System.String ColumnName = "DateFactureAcomba";
					/// <summary>
					/// Returns 14
					/// </summary>
					public const System.Int32 ColumnIndex = 14;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field TypeFacture_ID via shared members
				/// </summary>
				public sealed class Column_TypeFacture_ID {

					/// <summary>
					/// Returns "TypeFacture_ID"
					/// </summary>
					public const System.String ColumnName = "TypeFacture_ID";
					/// <summary>
					/// Returns 15
					/// </summary>
					public const System.Int32 ColumnIndex = 15;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field TypeFacture_Description via shared members
				/// </summary>
				public sealed class Column_TypeFacture_Description {

					/// <summary>
					/// Returns "TypeFacture_Description"
					/// </summary>
					public const System.String ColumnName = "TypeFacture_Description";
					/// <summary>
					/// Returns 16
					/// </summary>
					public const System.Int32 ColumnIndex = 16;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field TypeFacture_FactureDescriptionMask via shared members
				/// </summary>
				public sealed class Column_TypeFacture_FactureDescriptionMask {

					/// <summary>
					/// Returns "TypeFacture_FactureDescriptionMask"
					/// </summary>
					public const System.String ColumnName = "TypeFacture_FactureDescriptionMask";
					/// <summary>
					/// Returns 17
					/// </summary>
					public const System.Int32 ColumnIndex = 17;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field TypeInvoiceClientAcomba_ID via shared members
				/// </summary>
				public sealed class Column_TypeInvoiceClientAcomba_ID {

					/// <summary>
					/// Returns "TypeInvoiceClientAcomba_ID"
					/// </summary>
					public const System.String ColumnName = "TypeInvoiceClientAcomba_ID";
					/// <summary>
					/// Returns 18
					/// </summary>
					public const System.Int32 ColumnIndex = 18;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field TypeInvoiceClientAcomba_Description via shared members
				/// </summary>
				public sealed class Column_TypeInvoiceClientAcomba_Description {

					/// <summary>
					/// Returns "TypeInvoiceClientAcomba_Description"
					/// </summary>
					public const System.String ColumnName = "TypeInvoiceClientAcomba_Description";
					/// <summary>
					/// Returns 19
					/// </summary>
					public const System.Int32 ColumnIndex = 19;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ClientID_ID via shared members
				/// </summary>
				public sealed class Column_ClientID_ID {

					/// <summary>
					/// Returns "ClientID_ID"
					/// </summary>
					public const System.String ColumnName = "ClientID_ID";
					/// <summary>
					/// Returns 20
					/// </summary>
					public const System.Int32 ColumnIndex = 20;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ClientID_Description via shared members
				/// </summary>
				public sealed class Column_ClientID_Description {

					/// <summary>
					/// Returns "ClientID_Description"
					/// </summary>
					public const System.String ColumnName = "ClientID_Description";
					/// <summary>
					/// Returns 21
					/// </summary>
					public const System.Int32 ColumnIndex = 21;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ClientID_UtilisationID via shared members
				/// </summary>
				public sealed class Column_ClientID_UtilisationID {

					/// <summary>
					/// Returns "ClientID_UtilisationID"
					/// </summary>
					public const System.String ColumnName = "ClientID_UtilisationID";
					/// <summary>
					/// Returns 22
					/// </summary>
					public const System.Int32 ColumnIndex = 22;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ClientID_Paye_producteur via shared members
				/// </summary>
				public sealed class Column_ClientID_Paye_producteur {

					/// <summary>
					/// Returns "ClientID_Paye_producteur"
					/// </summary>
					public const System.String ColumnName = "ClientID_Paye_producteur";
					/// <summary>
					/// Returns 23
					/// </summary>
					public const System.Int32 ColumnIndex = 23;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ClientID_Paye_transporteur via shared members
				/// </summary>
				public sealed class Column_ClientID_Paye_transporteur {

					/// <summary>
					/// Returns "ClientID_Paye_transporteur"
					/// </summary>
					public const System.String ColumnName = "ClientID_Paye_transporteur";
					/// <summary>
					/// Returns 24
					/// </summary>
					public const System.Int32 ColumnIndex = 24;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ClientID_Specification via shared members
				/// </summary>
				public sealed class Column_ClientID_Specification {

					/// <summary>
					/// Returns "ClientID_Specification"
					/// </summary>
					public const System.String ColumnName = "ClientID_Specification";
					/// <summary>
					/// Returns 25
					/// </summary>
					public const System.Int32 ColumnIndex = 25;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ClientID_Compte_a_recevoir via shared members
				/// </summary>
				public sealed class Column_ClientID_Compte_a_recevoir {

					/// <summary>
					/// Returns "ClientID_Compte_a_recevoir"
					/// </summary>
					public const System.String ColumnName = "ClientID_Compte_a_recevoir";
					/// <summary>
					/// Returns 26
					/// </summary>
					public const System.Int32 ColumnIndex = 26;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ClientID_Compte_ajustement via shared members
				/// </summary>
				public sealed class Column_ClientID_Compte_ajustement {

					/// <summary>
					/// Returns "ClientID_Compte_ajustement"
					/// </summary>
					public const System.String ColumnName = "ClientID_Compte_ajustement";
					/// <summary>
					/// Returns 27
					/// </summary>
					public const System.Int32 ColumnIndex = 27;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ClientID_Compte_transporteur via shared members
				/// </summary>
				public sealed class Column_ClientID_Compte_transporteur {

					/// <summary>
					/// Returns "ClientID_Compte_transporteur"
					/// </summary>
					public const System.String ColumnName = "ClientID_Compte_transporteur";
					/// <summary>
					/// Returns 28
					/// </summary>
					public const System.Int32 ColumnIndex = 28;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ClientID_Compte_producteur via shared members
				/// </summary>
				public sealed class Column_ClientID_Compte_producteur {

					/// <summary>
					/// Returns "ClientID_Compte_producteur"
					/// </summary>
					public const System.String ColumnName = "ClientID_Compte_producteur";
					/// <summary>
					/// Returns 29
					/// </summary>
					public const System.Int32 ColumnIndex = 29;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ClientID_Compte_preleve_plan_conjoint via shared members
				/// </summary>
				public sealed class Column_ClientID_Compte_preleve_plan_conjoint {

					/// <summary>
					/// Returns "ClientID_Compte_preleve_plan_conjoint"
					/// </summary>
					public const System.String ColumnName = "ClientID_Compte_preleve_plan_conjoint";
					/// <summary>
					/// Returns 30
					/// </summary>
					public const System.Int32 ColumnIndex = 30;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ClientID_Compte_preleve_fond_roulement via shared members
				/// </summary>
				public sealed class Column_ClientID_Compte_preleve_fond_roulement {

					/// <summary>
					/// Returns "ClientID_Compte_preleve_fond_roulement"
					/// </summary>
					public const System.String ColumnName = "ClientID_Compte_preleve_fond_roulement";
					/// <summary>
					/// Returns 31
					/// </summary>
					public const System.Int32 ColumnIndex = 31;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ClientID_Compte_preleve_fond_forestier via shared members
				/// </summary>
				public sealed class Column_ClientID_Compte_preleve_fond_forestier {

					/// <summary>
					/// Returns "ClientID_Compte_preleve_fond_forestier"
					/// </summary>
					public const System.String ColumnName = "ClientID_Compte_preleve_fond_forestier";
					/// <summary>
					/// Returns 32
					/// </summary>
					public const System.Int32 ColumnIndex = 32;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ClientID_Compte_preleve_divers via shared members
				/// </summary>
				public sealed class Column_ClientID_Compte_preleve_divers {

					/// <summary>
					/// Returns "ClientID_Compte_preleve_divers"
					/// </summary>
					public const System.String ColumnName = "ClientID_Compte_preleve_divers";
					/// <summary>
					/// Returns 33
					/// </summary>
					public const System.Int32 ColumnIndex = 33;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ClientID_Compte_mise_en_commun via shared members
				/// </summary>
				public sealed class Column_ClientID_Compte_mise_en_commun {

					/// <summary>
					/// Returns "ClientID_Compte_mise_en_commun"
					/// </summary>
					public const System.String ColumnName = "ClientID_Compte_mise_en_commun";
					/// <summary>
					/// Returns 34
					/// </summary>
					public const System.Int32 ColumnIndex = 34;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ClientID_Compte_surcharge via shared members
				/// </summary>
				public sealed class Column_ClientID_Compte_surcharge {

					/// <summary>
					/// Returns "ClientID_Compte_surcharge"
					/// </summary>
					public const System.String ColumnName = "ClientID_Compte_surcharge";
					/// <summary>
					/// Returns 35
					/// </summary>
					public const System.Int32 ColumnIndex = 35;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ClientID_Compte_indexation_carburant via shared members
				/// </summary>
				public sealed class Column_ClientID_Compte_indexation_carburant {

					/// <summary>
					/// Returns "ClientID_Compte_indexation_carburant"
					/// </summary>
					public const System.String ColumnName = "ClientID_Compte_indexation_carburant";
					/// <summary>
					/// Returns 36
					/// </summary>
					public const System.Int32 ColumnIndex = 36;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ClientID_Actif via shared members
				/// </summary>
				public sealed class Column_ClientID_Actif {

					/// <summary>
					/// Returns "ClientID_Actif"
					/// </summary>
					public const System.String ColumnName = "ClientID_Actif";
					/// <summary>
					/// Returns 37
					/// </summary>
					public const System.Int32 ColumnIndex = 37;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ClientID_NePaiePasTPS via shared members
				/// </summary>
				public sealed class Column_ClientID_NePaiePasTPS {

					/// <summary>
					/// Returns "ClientID_NePaiePasTPS"
					/// </summary>
					public const System.String ColumnName = "ClientID_NePaiePasTPS";
					/// <summary>
					/// Returns 38
					/// </summary>
					public const System.Int32 ColumnIndex = 38;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ClientID_NePaiePasTVQ via shared members
				/// </summary>
				public sealed class Column_ClientID_NePaiePasTVQ {

					/// <summary>
					/// Returns "ClientID_NePaiePasTVQ"
					/// </summary>
					public const System.String ColumnName = "ClientID_NePaiePasTVQ";
					/// <summary>
					/// Returns 39
					/// </summary>
					public const System.Int32 ColumnIndex = 39;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ClientID_NoTPS via shared members
				/// </summary>
				public sealed class Column_ClientID_NoTPS {

					/// <summary>
					/// Returns "ClientID_NoTPS"
					/// </summary>
					public const System.String ColumnName = "ClientID_NoTPS";
					/// <summary>
					/// Returns 40
					/// </summary>
					public const System.Int32 ColumnIndex = 40;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ClientID_NoTVQ via shared members
				/// </summary>
				public sealed class Column_ClientID_NoTVQ {

					/// <summary>
					/// Returns "ClientID_NoTVQ"
					/// </summary>
					public const System.String ColumnName = "ClientID_NoTVQ";
					/// <summary>
					/// Returns 41
					/// </summary>
					public const System.Int32 ColumnIndex = 41;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ClientID_Compte_chargeur via shared members
				/// </summary>
				public sealed class Column_ClientID_Compte_chargeur {

					/// <summary>
					/// Returns "ClientID_Compte_chargeur"
					/// </summary>
					public const System.String ColumnName = "ClientID_Compte_chargeur";
					/// <summary>
					/// Returns 42
					/// </summary>
					public const System.Int32 ColumnIndex = 42;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ClientID_UsineGestionVolume via shared members
				/// </summary>
				public sealed class Column_ClientID_UsineGestionVolume {

					/// <summary>
					/// Returns "ClientID_UsineGestionVolume"
					/// </summary>
					public const System.String ColumnName = "ClientID_UsineGestionVolume";
					/// <summary>
					/// Returns 43
					/// </summary>
					public const System.Int32 ColumnIndex = 43;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ClientID_AuSoinsDe via shared members
				/// </summary>
				public sealed class Column_ClientID_AuSoinsDe {

					/// <summary>
					/// Returns "ClientID_AuSoinsDe"
					/// </summary>
					public const System.String ColumnName = "ClientID_AuSoinsDe";
					/// <summary>
					/// Returns 44
					/// </summary>
					public const System.Int32 ColumnIndex = 44;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ClientID_Rue via shared members
				/// </summary>
				public sealed class Column_ClientID_Rue {

					/// <summary>
					/// Returns "ClientID_Rue"
					/// </summary>
					public const System.String ColumnName = "ClientID_Rue";
					/// <summary>
					/// Returns 45
					/// </summary>
					public const System.Int32 ColumnIndex = 45;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ClientID_Ville via shared members
				/// </summary>
				public sealed class Column_ClientID_Ville {

					/// <summary>
					/// Returns "ClientID_Ville"
					/// </summary>
					public const System.String ColumnName = "ClientID_Ville";
					/// <summary>
					/// Returns 46
					/// </summary>
					public const System.Int32 ColumnIndex = 46;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ClientID_PaysID via shared members
				/// </summary>
				public sealed class Column_ClientID_PaysID {

					/// <summary>
					/// Returns "ClientID_PaysID"
					/// </summary>
					public const System.String ColumnName = "ClientID_PaysID";
					/// <summary>
					/// Returns 47
					/// </summary>
					public const System.Int32 ColumnIndex = 47;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ClientID_Code_postal via shared members
				/// </summary>
				public sealed class Column_ClientID_Code_postal {

					/// <summary>
					/// Returns "ClientID_Code_postal"
					/// </summary>
					public const System.String ColumnName = "ClientID_Code_postal";
					/// <summary>
					/// Returns 48
					/// </summary>
					public const System.Int32 ColumnIndex = 48;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ClientID_Telephone via shared members
				/// </summary>
				public sealed class Column_ClientID_Telephone {

					/// <summary>
					/// Returns "ClientID_Telephone"
					/// </summary>
					public const System.String ColumnName = "ClientID_Telephone";
					/// <summary>
					/// Returns 49
					/// </summary>
					public const System.Int32 ColumnIndex = 49;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ClientID_Telephone_Poste via shared members
				/// </summary>
				public sealed class Column_ClientID_Telephone_Poste {

					/// <summary>
					/// Returns "ClientID_Telephone_Poste"
					/// </summary>
					public const System.String ColumnName = "ClientID_Telephone_Poste";
					/// <summary>
					/// Returns 50
					/// </summary>
					public const System.Int32 ColumnIndex = 50;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ClientID_Telecopieur via shared members
				/// </summary>
				public sealed class Column_ClientID_Telecopieur {

					/// <summary>
					/// Returns "ClientID_Telecopieur"
					/// </summary>
					public const System.String ColumnName = "ClientID_Telecopieur";
					/// <summary>
					/// Returns 51
					/// </summary>
					public const System.Int32 ColumnIndex = 51;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ClientID_Telephone2 via shared members
				/// </summary>
				public sealed class Column_ClientID_Telephone2 {

					/// <summary>
					/// Returns "ClientID_Telephone2"
					/// </summary>
					public const System.String ColumnName = "ClientID_Telephone2";
					/// <summary>
					/// Returns 52
					/// </summary>
					public const System.Int32 ColumnIndex = 52;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ClientID_Telephone2_Desc via shared members
				/// </summary>
				public sealed class Column_ClientID_Telephone2_Desc {

					/// <summary>
					/// Returns "ClientID_Telephone2_Desc"
					/// </summary>
					public const System.String ColumnName = "ClientID_Telephone2_Desc";
					/// <summary>
					/// Returns 53
					/// </summary>
					public const System.Int32 ColumnIndex = 53;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ClientID_Telephone2_Poste via shared members
				/// </summary>
				public sealed class Column_ClientID_Telephone2_Poste {

					/// <summary>
					/// Returns "ClientID_Telephone2_Poste"
					/// </summary>
					public const System.String ColumnName = "ClientID_Telephone2_Poste";
					/// <summary>
					/// Returns 54
					/// </summary>
					public const System.Int32 ColumnIndex = 54;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ClientID_Telephone3 via shared members
				/// </summary>
				public sealed class Column_ClientID_Telephone3 {

					/// <summary>
					/// Returns "ClientID_Telephone3"
					/// </summary>
					public const System.String ColumnName = "ClientID_Telephone3";
					/// <summary>
					/// Returns 55
					/// </summary>
					public const System.Int32 ColumnIndex = 55;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ClientID_Telephone3_Desc via shared members
				/// </summary>
				public sealed class Column_ClientID_Telephone3_Desc {

					/// <summary>
					/// Returns "ClientID_Telephone3_Desc"
					/// </summary>
					public const System.String ColumnName = "ClientID_Telephone3_Desc";
					/// <summary>
					/// Returns 56
					/// </summary>
					public const System.Int32 ColumnIndex = 56;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ClientID_Telephone3_Poste via shared members
				/// </summary>
				public sealed class Column_ClientID_Telephone3_Poste {

					/// <summary>
					/// Returns "ClientID_Telephone3_Poste"
					/// </summary>
					public const System.String ColumnName = "ClientID_Telephone3_Poste";
					/// <summary>
					/// Returns 57
					/// </summary>
					public const System.Int32 ColumnIndex = 57;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field ClientID_Email via shared members
				/// </summary>
				public sealed class Column_ClientID_Email {

					/// <summary>
					/// Returns "ClientID_Email"
					/// </summary>
					public const System.String ColumnName = "ClientID_Email";
					/// <summary>
					/// Returns 58
					/// </summary>
					public const System.Int32 ColumnIndex = 58;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field PayerAID_ID via shared members
				/// </summary>
				public sealed class Column_PayerAID_ID {

					/// <summary>
					/// Returns "PayerAID_ID"
					/// </summary>
					public const System.String ColumnName = "PayerAID_ID";
					/// <summary>
					/// Returns 59
					/// </summary>
					public const System.Int32 ColumnIndex = 59;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field PayerAID_Description via shared members
				/// </summary>
				public sealed class Column_PayerAID_Description {

					/// <summary>
					/// Returns "PayerAID_Description"
					/// </summary>
					public const System.String ColumnName = "PayerAID_Description";
					/// <summary>
					/// Returns 60
					/// </summary>
					public const System.Int32 ColumnIndex = 60;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field PayerAID_UtilisationID via shared members
				/// </summary>
				public sealed class Column_PayerAID_UtilisationID {

					/// <summary>
					/// Returns "PayerAID_UtilisationID"
					/// </summary>
					public const System.String ColumnName = "PayerAID_UtilisationID";
					/// <summary>
					/// Returns 61
					/// </summary>
					public const System.Int32 ColumnIndex = 61;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field PayerAID_Paye_producteur via shared members
				/// </summary>
				public sealed class Column_PayerAID_Paye_producteur {

					/// <summary>
					/// Returns "PayerAID_Paye_producteur"
					/// </summary>
					public const System.String ColumnName = "PayerAID_Paye_producteur";
					/// <summary>
					/// Returns 62
					/// </summary>
					public const System.Int32 ColumnIndex = 62;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field PayerAID_Paye_transporteur via shared members
				/// </summary>
				public sealed class Column_PayerAID_Paye_transporteur {

					/// <summary>
					/// Returns "PayerAID_Paye_transporteur"
					/// </summary>
					public const System.String ColumnName = "PayerAID_Paye_transporteur";
					/// <summary>
					/// Returns 63
					/// </summary>
					public const System.Int32 ColumnIndex = 63;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field PayerAID_Specification via shared members
				/// </summary>
				public sealed class Column_PayerAID_Specification {

					/// <summary>
					/// Returns "PayerAID_Specification"
					/// </summary>
					public const System.String ColumnName = "PayerAID_Specification";
					/// <summary>
					/// Returns 64
					/// </summary>
					public const System.Int32 ColumnIndex = 64;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field PayerAID_Compte_a_recevoir via shared members
				/// </summary>
				public sealed class Column_PayerAID_Compte_a_recevoir {

					/// <summary>
					/// Returns "PayerAID_Compte_a_recevoir"
					/// </summary>
					public const System.String ColumnName = "PayerAID_Compte_a_recevoir";
					/// <summary>
					/// Returns 65
					/// </summary>
					public const System.Int32 ColumnIndex = 65;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field PayerAID_Compte_ajustement via shared members
				/// </summary>
				public sealed class Column_PayerAID_Compte_ajustement {

					/// <summary>
					/// Returns "PayerAID_Compte_ajustement"
					/// </summary>
					public const System.String ColumnName = "PayerAID_Compte_ajustement";
					/// <summary>
					/// Returns 66
					/// </summary>
					public const System.Int32 ColumnIndex = 66;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field PayerAID_Compte_transporteur via shared members
				/// </summary>
				public sealed class Column_PayerAID_Compte_transporteur {

					/// <summary>
					/// Returns "PayerAID_Compte_transporteur"
					/// </summary>
					public const System.String ColumnName = "PayerAID_Compte_transporteur";
					/// <summary>
					/// Returns 67
					/// </summary>
					public const System.Int32 ColumnIndex = 67;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field PayerAID_Compte_producteur via shared members
				/// </summary>
				public sealed class Column_PayerAID_Compte_producteur {

					/// <summary>
					/// Returns "PayerAID_Compte_producteur"
					/// </summary>
					public const System.String ColumnName = "PayerAID_Compte_producteur";
					/// <summary>
					/// Returns 68
					/// </summary>
					public const System.Int32 ColumnIndex = 68;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field PayerAID_Compte_preleve_plan_conjoint via shared members
				/// </summary>
				public sealed class Column_PayerAID_Compte_preleve_plan_conjoint {

					/// <summary>
					/// Returns "PayerAID_Compte_preleve_plan_conjoint"
					/// </summary>
					public const System.String ColumnName = "PayerAID_Compte_preleve_plan_conjoint";
					/// <summary>
					/// Returns 69
					/// </summary>
					public const System.Int32 ColumnIndex = 69;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field PayerAID_Compte_preleve_fond_roulement via shared members
				/// </summary>
				public sealed class Column_PayerAID_Compte_preleve_fond_roulement {

					/// <summary>
					/// Returns "PayerAID_Compte_preleve_fond_roulement"
					/// </summary>
					public const System.String ColumnName = "PayerAID_Compte_preleve_fond_roulement";
					/// <summary>
					/// Returns 70
					/// </summary>
					public const System.Int32 ColumnIndex = 70;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field PayerAID_Compte_preleve_fond_forestier via shared members
				/// </summary>
				public sealed class Column_PayerAID_Compte_preleve_fond_forestier {

					/// <summary>
					/// Returns "PayerAID_Compte_preleve_fond_forestier"
					/// </summary>
					public const System.String ColumnName = "PayerAID_Compte_preleve_fond_forestier";
					/// <summary>
					/// Returns 71
					/// </summary>
					public const System.Int32 ColumnIndex = 71;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field PayerAID_Compte_preleve_divers via shared members
				/// </summary>
				public sealed class Column_PayerAID_Compte_preleve_divers {

					/// <summary>
					/// Returns "PayerAID_Compte_preleve_divers"
					/// </summary>
					public const System.String ColumnName = "PayerAID_Compte_preleve_divers";
					/// <summary>
					/// Returns 72
					/// </summary>
					public const System.Int32 ColumnIndex = 72;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field PayerAID_Compte_mise_en_commun via shared members
				/// </summary>
				public sealed class Column_PayerAID_Compte_mise_en_commun {

					/// <summary>
					/// Returns "PayerAID_Compte_mise_en_commun"
					/// </summary>
					public const System.String ColumnName = "PayerAID_Compte_mise_en_commun";
					/// <summary>
					/// Returns 73
					/// </summary>
					public const System.Int32 ColumnIndex = 73;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field PayerAID_Compte_surcharge via shared members
				/// </summary>
				public sealed class Column_PayerAID_Compte_surcharge {

					/// <summary>
					/// Returns "PayerAID_Compte_surcharge"
					/// </summary>
					public const System.String ColumnName = "PayerAID_Compte_surcharge";
					/// <summary>
					/// Returns 74
					/// </summary>
					public const System.Int32 ColumnIndex = 74;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field PayerAID_Compte_indexation_carburant via shared members
				/// </summary>
				public sealed class Column_PayerAID_Compte_indexation_carburant {

					/// <summary>
					/// Returns "PayerAID_Compte_indexation_carburant"
					/// </summary>
					public const System.String ColumnName = "PayerAID_Compte_indexation_carburant";
					/// <summary>
					/// Returns 75
					/// </summary>
					public const System.Int32 ColumnIndex = 75;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field PayerAID_Actif via shared members
				/// </summary>
				public sealed class Column_PayerAID_Actif {

					/// <summary>
					/// Returns "PayerAID_Actif"
					/// </summary>
					public const System.String ColumnName = "PayerAID_Actif";
					/// <summary>
					/// Returns 76
					/// </summary>
					public const System.Int32 ColumnIndex = 76;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field PayerAID_NePaiePasTPS via shared members
				/// </summary>
				public sealed class Column_PayerAID_NePaiePasTPS {

					/// <summary>
					/// Returns "PayerAID_NePaiePasTPS"
					/// </summary>
					public const System.String ColumnName = "PayerAID_NePaiePasTPS";
					/// <summary>
					/// Returns 77
					/// </summary>
					public const System.Int32 ColumnIndex = 77;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field PayerAID_NePaiePasTVQ via shared members
				/// </summary>
				public sealed class Column_PayerAID_NePaiePasTVQ {

					/// <summary>
					/// Returns "PayerAID_NePaiePasTVQ"
					/// </summary>
					public const System.String ColumnName = "PayerAID_NePaiePasTVQ";
					/// <summary>
					/// Returns 78
					/// </summary>
					public const System.Int32 ColumnIndex = 78;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field PayerAID_NoTPS via shared members
				/// </summary>
				public sealed class Column_PayerAID_NoTPS {

					/// <summary>
					/// Returns "PayerAID_NoTPS"
					/// </summary>
					public const System.String ColumnName = "PayerAID_NoTPS";
					/// <summary>
					/// Returns 79
					/// </summary>
					public const System.Int32 ColumnIndex = 79;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field PayerAID_NoTVQ via shared members
				/// </summary>
				public sealed class Column_PayerAID_NoTVQ {

					/// <summary>
					/// Returns "PayerAID_NoTVQ"
					/// </summary>
					public const System.String ColumnName = "PayerAID_NoTVQ";
					/// <summary>
					/// Returns 80
					/// </summary>
					public const System.Int32 ColumnIndex = 80;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field PayerAID_Compte_chargeur via shared members
				/// </summary>
				public sealed class Column_PayerAID_Compte_chargeur {

					/// <summary>
					/// Returns "PayerAID_Compte_chargeur"
					/// </summary>
					public const System.String ColumnName = "PayerAID_Compte_chargeur";
					/// <summary>
					/// Returns 81
					/// </summary>
					public const System.Int32 ColumnIndex = 81;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field PayerAID_UsineGestionVolume via shared members
				/// </summary>
				public sealed class Column_PayerAID_UsineGestionVolume {

					/// <summary>
					/// Returns "PayerAID_UsineGestionVolume"
					/// </summary>
					public const System.String ColumnName = "PayerAID_UsineGestionVolume";
					/// <summary>
					/// Returns 82
					/// </summary>
					public const System.Int32 ColumnIndex = 82;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field PayerAID_AuSoinsDe via shared members
				/// </summary>
				public sealed class Column_PayerAID_AuSoinsDe {

					/// <summary>
					/// Returns "PayerAID_AuSoinsDe"
					/// </summary>
					public const System.String ColumnName = "PayerAID_AuSoinsDe";
					/// <summary>
					/// Returns 83
					/// </summary>
					public const System.Int32 ColumnIndex = 83;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field PayerAID_Rue via shared members
				/// </summary>
				public sealed class Column_PayerAID_Rue {

					/// <summary>
					/// Returns "PayerAID_Rue"
					/// </summary>
					public const System.String ColumnName = "PayerAID_Rue";
					/// <summary>
					/// Returns 84
					/// </summary>
					public const System.Int32 ColumnIndex = 84;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field PayerAID_Ville via shared members
				/// </summary>
				public sealed class Column_PayerAID_Ville {

					/// <summary>
					/// Returns "PayerAID_Ville"
					/// </summary>
					public const System.String ColumnName = "PayerAID_Ville";
					/// <summary>
					/// Returns 85
					/// </summary>
					public const System.Int32 ColumnIndex = 85;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field PayerAID_PaysID via shared members
				/// </summary>
				public sealed class Column_PayerAID_PaysID {

					/// <summary>
					/// Returns "PayerAID_PaysID"
					/// </summary>
					public const System.String ColumnName = "PayerAID_PaysID";
					/// <summary>
					/// Returns 86
					/// </summary>
					public const System.Int32 ColumnIndex = 86;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field PayerAID_Code_postal via shared members
				/// </summary>
				public sealed class Column_PayerAID_Code_postal {

					/// <summary>
					/// Returns "PayerAID_Code_postal"
					/// </summary>
					public const System.String ColumnName = "PayerAID_Code_postal";
					/// <summary>
					/// Returns 87
					/// </summary>
					public const System.Int32 ColumnIndex = 87;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field PayerAID_Telephone via shared members
				/// </summary>
				public sealed class Column_PayerAID_Telephone {

					/// <summary>
					/// Returns "PayerAID_Telephone"
					/// </summary>
					public const System.String ColumnName = "PayerAID_Telephone";
					/// <summary>
					/// Returns 88
					/// </summary>
					public const System.Int32 ColumnIndex = 88;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field PayerAID_Telephone_Poste via shared members
				/// </summary>
				public sealed class Column_PayerAID_Telephone_Poste {

					/// <summary>
					/// Returns "PayerAID_Telephone_Poste"
					/// </summary>
					public const System.String ColumnName = "PayerAID_Telephone_Poste";
					/// <summary>
					/// Returns 89
					/// </summary>
					public const System.Int32 ColumnIndex = 89;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field PayerAID_Telecopieur via shared members
				/// </summary>
				public sealed class Column_PayerAID_Telecopieur {

					/// <summary>
					/// Returns "PayerAID_Telecopieur"
					/// </summary>
					public const System.String ColumnName = "PayerAID_Telecopieur";
					/// <summary>
					/// Returns 90
					/// </summary>
					public const System.Int32 ColumnIndex = 90;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field PayerAID_Telephone2 via shared members
				/// </summary>
				public sealed class Column_PayerAID_Telephone2 {

					/// <summary>
					/// Returns "PayerAID_Telephone2"
					/// </summary>
					public const System.String ColumnName = "PayerAID_Telephone2";
					/// <summary>
					/// Returns 91
					/// </summary>
					public const System.Int32 ColumnIndex = 91;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field PayerAID_Telephone2_Desc via shared members
				/// </summary>
				public sealed class Column_PayerAID_Telephone2_Desc {

					/// <summary>
					/// Returns "PayerAID_Telephone2_Desc"
					/// </summary>
					public const System.String ColumnName = "PayerAID_Telephone2_Desc";
					/// <summary>
					/// Returns 92
					/// </summary>
					public const System.Int32 ColumnIndex = 92;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field PayerAID_Telephone2_Poste via shared members
				/// </summary>
				public sealed class Column_PayerAID_Telephone2_Poste {

					/// <summary>
					/// Returns "PayerAID_Telephone2_Poste"
					/// </summary>
					public const System.String ColumnName = "PayerAID_Telephone2_Poste";
					/// <summary>
					/// Returns 93
					/// </summary>
					public const System.Int32 ColumnIndex = 93;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field PayerAID_Telephone3 via shared members
				/// </summary>
				public sealed class Column_PayerAID_Telephone3 {

					/// <summary>
					/// Returns "PayerAID_Telephone3"
					/// </summary>
					public const System.String ColumnName = "PayerAID_Telephone3";
					/// <summary>
					/// Returns 94
					/// </summary>
					public const System.Int32 ColumnIndex = 94;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field PayerAID_Telephone3_Desc via shared members
				/// </summary>
				public sealed class Column_PayerAID_Telephone3_Desc {

					/// <summary>
					/// Returns "PayerAID_Telephone3_Desc"
					/// </summary>
					public const System.String ColumnName = "PayerAID_Telephone3_Desc";
					/// <summary>
					/// Returns 95
					/// </summary>
					public const System.Int32 ColumnIndex = 95;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field PayerAID_Telephone3_Poste via shared members
				/// </summary>
				public sealed class Column_PayerAID_Telephone3_Poste {

					/// <summary>
					/// Returns "PayerAID_Telephone3_Poste"
					/// </summary>
					public const System.String ColumnName = "PayerAID_Telephone3_Poste";
					/// <summary>
					/// Returns 96
					/// </summary>
					public const System.Int32 ColumnIndex = 96;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field PayerAID_Email via shared members
				/// </summary>
				public sealed class Column_PayerAID_Email {

					/// <summary>
					/// Returns "PayerAID_Email"
					/// </summary>
					public const System.String ColumnName = "PayerAID_Email";
					/// <summary>
					/// Returns 97
					/// </summary>
					public const System.Int32 ColumnIndex = 97;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Status_ID via shared members
				/// </summary>
				public sealed class Column_Status_ID {

					/// <summary>
					/// Returns "Status_ID"
					/// </summary>
					public const System.String ColumnName = "Status_ID";
					/// <summary>
					/// Returns 98
					/// </summary>
					public const System.Int32 ColumnIndex = 98;

				}

			}
		}

		/// <summary>
		/// This class allows to easily retrieve the name or index of all the fields
		/// of the resulset #2 existing in the Dataset or the SqlDatReader returned by
		/// the Execute method of the 'spS_FactureClient_Full' class.
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

