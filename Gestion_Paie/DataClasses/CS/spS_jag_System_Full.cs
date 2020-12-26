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
	/// stored procedure 'spS_jag_System_Full'. It allows also to specify specific connection
	/// information such as the ConnectionString to be use, the command time-out and so forth.
	/// </summary>
	[Serializable()]
#if OLYMARS_ATTRIBUTE || OLYMARS_DEBUG
	[OlymarsInformation(DeveloperName="<Developer Name Here>", GeneratedOn="2007/03/30 13:55:24", SqlObjectDependancyName="spS_jag_System_Full", SqlObjectDependancyRevision=0)]
#endif
	public sealed class spS_jag_System_Full : MarshalByRefObject, IDisposable, IParameter {

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
		/// Initializes a new instance of the spS_jag_System_Full class. If you use this constructor version,
		/// not assigning parameter values implies using the parameter default values.
		/// </summary>
		public spS_jag_System_Full() : this(true) {

		}

		/// <summary>
		/// Initializes a new instance of the spS_jag_System_Full class.
		/// </summary>
		/// <param name="useDefaultValue">If True, this parameter indicates that "not assigning parameter values" implies "using the parameter default values". If False, this parameter indicates that "not assigning parameter values" implies "using the SQL Server Null value".</param>
		public spS_jag_System_Full(bool useDefaultValue) {

			this.useDefaultValue = useDefaultValue;

			this.internal_Param_Fournisseur_PlanConjoint_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Fournisseur_Surcharge_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Compte_Paiements_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Compte_ARecevoir_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Compte_APayer_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Compte_DuAuxProducteurs_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Compte_TPSpercues_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Compte_TPSpayees_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Compte_TVQpercues_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Compte_TVQpayees_UseDefaultValue = this.useDefaultValue;
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
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'spS_jag_System_Full'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

						throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "spS_jag_System_Full", CurrentRevision, OriginalRevision, System.Environment.NewLine));
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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'spS_jag_System_Full'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlConnection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "spS_jag_System_Full", CurrentRevision, OriginalRevision, System.Environment.NewLine));
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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'spS_jag_System_Full'";
				sqlCommand.Transaction = sqlTransaction;

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlTransaction.Connection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "spS_jag_System_Full", CurrentRevision, OriginalRevision, System.Environment.NewLine));
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
				this.internal_Param_Fournisseur_PlanConjoint = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_Fournisseur_Surcharge = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_Compte_Paiements = System.Data.SqlTypes.SqlInt32.Null;
				this.internal_Param_Compte_ARecevoir = System.Data.SqlTypes.SqlInt32.Null;
				this.internal_Param_Compte_APayer = System.Data.SqlTypes.SqlInt32.Null;
				this.internal_Param_Compte_DuAuxProducteurs = System.Data.SqlTypes.SqlInt32.Null;
				this.internal_Param_Compte_TPSpercues = System.Data.SqlTypes.SqlInt32.Null;
				this.internal_Param_Compte_TPSpayees = System.Data.SqlTypes.SqlInt32.Null;
				this.internal_Param_Compte_TVQpercues = System.Data.SqlTypes.SqlInt32.Null;
				this.internal_Param_Compte_TVQpayees = System.Data.SqlTypes.SqlInt32.Null;
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
		~spS_jag_System_Full() {

			Dispose(false);
		}

		/// <summary>
		/// Returns the stored procedure name for which this class was built, i.e. 'spS_jag_System_Full'.
		/// </summary>
		public string StoredProcedureName {

			get {

				return("spS_jag_System_Full");
			}
		}

		private System.Data.SqlTypes.SqlInt32 internal_Param_RETURN_VALUE;

		private System.Data.SqlTypes.SqlString internal_Param_Fournisseur_PlanConjoint;
		internal bool internal_Param_Fournisseur_PlanConjoint_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_Fournisseur_Surcharge;
		internal bool internal_Param_Fournisseur_Surcharge_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlInt32 internal_Param_Compte_Paiements;
		internal bool internal_Param_Compte_Paiements_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlInt32 internal_Param_Compte_ARecevoir;
		internal bool internal_Param_Compte_ARecevoir_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlInt32 internal_Param_Compte_APayer;
		internal bool internal_Param_Compte_APayer_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlInt32 internal_Param_Compte_DuAuxProducteurs;
		internal bool internal_Param_Compte_DuAuxProducteurs_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlInt32 internal_Param_Compte_TPSpercues;
		internal bool internal_Param_Compte_TPSpercues_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlInt32 internal_Param_Compte_TPSpayees;
		internal bool internal_Param_Compte_TPSpayees_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlInt32 internal_Param_Compte_TVQpercues;
		internal bool internal_Param_Compte_TVQpercues_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlInt32 internal_Param_Compte_TVQpayees;
		internal bool internal_Param_Compte_TVQpayees_UseDefaultValue = true;

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

			this.internal_Param_Fournisseur_PlanConjoint = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_Fournisseur_PlanConjoint_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Fournisseur_Surcharge = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_Fournisseur_Surcharge_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Compte_Paiements = System.Data.SqlTypes.SqlInt32.Null;
			this.internal_Param_Compte_Paiements_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Compte_ARecevoir = System.Data.SqlTypes.SqlInt32.Null;
			this.internal_Param_Compte_ARecevoir_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Compte_APayer = System.Data.SqlTypes.SqlInt32.Null;
			this.internal_Param_Compte_APayer_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Compte_DuAuxProducteurs = System.Data.SqlTypes.SqlInt32.Null;
			this.internal_Param_Compte_DuAuxProducteurs_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Compte_TPSpercues = System.Data.SqlTypes.SqlInt32.Null;
			this.internal_Param_Compte_TPSpercues_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Compte_TPSpayees = System.Data.SqlTypes.SqlInt32.Null;
			this.internal_Param_Compte_TPSpayees_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Compte_TVQpercues = System.Data.SqlTypes.SqlInt32.Null;
			this.internal_Param_Compte_TVQpercues_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Compte_TVQpayees = System.Data.SqlTypes.SqlInt32.Null;
			this.internal_Param_Compte_TVQpayees_UseDefaultValue = this.useDefaultValue;

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
		/// Sets the value of the stored procedure INPUT parameter '@Fournisseur_PlanConjoint'.
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
		/// the parameter default value, consider calling the Param_Fournisseur_PlanConjoint_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_Fournisseur_PlanConjoint {

			get {

				if (this.internal_Param_Fournisseur_PlanConjoint_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Fournisseur_PlanConjoint);
			}

			set {

				this.internal_Param_Fournisseur_PlanConjoint_UseDefaultValue = false;
				this.internal_Param_Fournisseur_PlanConjoint = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Fournisseur_PlanConjoint' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Fournisseur_PlanConjoint_UseDefaultValue() {

			this.internal_Param_Fournisseur_PlanConjoint_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Fournisseur_Surcharge'.
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
		/// the parameter default value, consider calling the Param_Fournisseur_Surcharge_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_Fournisseur_Surcharge {

			get {

				if (this.internal_Param_Fournisseur_Surcharge_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Fournisseur_Surcharge);
			}

			set {

				this.internal_Param_Fournisseur_Surcharge_UseDefaultValue = false;
				this.internal_Param_Fournisseur_Surcharge = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Fournisseur_Surcharge' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Fournisseur_Surcharge_UseDefaultValue() {

			this.internal_Param_Fournisseur_Surcharge_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Compte_Paiements'.
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
		/// the parameter default value, consider calling the Param_Compte_Paiements_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlInt32 Param_Compte_Paiements {

			get {

				if (this.internal_Param_Compte_Paiements_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Compte_Paiements);
			}

			set {

				this.internal_Param_Compte_Paiements_UseDefaultValue = false;
				this.internal_Param_Compte_Paiements = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Compte_Paiements' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Compte_Paiements_UseDefaultValue() {

			this.internal_Param_Compte_Paiements_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Compte_ARecevoir'.
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
		/// the parameter default value, consider calling the Param_Compte_ARecevoir_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlInt32 Param_Compte_ARecevoir {

			get {

				if (this.internal_Param_Compte_ARecevoir_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Compte_ARecevoir);
			}

			set {

				this.internal_Param_Compte_ARecevoir_UseDefaultValue = false;
				this.internal_Param_Compte_ARecevoir = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Compte_ARecevoir' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Compte_ARecevoir_UseDefaultValue() {

			this.internal_Param_Compte_ARecevoir_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Compte_APayer'.
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
		/// the parameter default value, consider calling the Param_Compte_APayer_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlInt32 Param_Compte_APayer {

			get {

				if (this.internal_Param_Compte_APayer_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Compte_APayer);
			}

			set {

				this.internal_Param_Compte_APayer_UseDefaultValue = false;
				this.internal_Param_Compte_APayer = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Compte_APayer' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Compte_APayer_UseDefaultValue() {

			this.internal_Param_Compte_APayer_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Compte_DuAuxProducteurs'.
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
		/// the parameter default value, consider calling the Param_Compte_DuAuxProducteurs_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlInt32 Param_Compte_DuAuxProducteurs {

			get {

				if (this.internal_Param_Compte_DuAuxProducteurs_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Compte_DuAuxProducteurs);
			}

			set {

				this.internal_Param_Compte_DuAuxProducteurs_UseDefaultValue = false;
				this.internal_Param_Compte_DuAuxProducteurs = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Compte_DuAuxProducteurs' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Compte_DuAuxProducteurs_UseDefaultValue() {

			this.internal_Param_Compte_DuAuxProducteurs_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Compte_TPSpercues'.
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
		/// the parameter default value, consider calling the Param_Compte_TPSpercues_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlInt32 Param_Compte_TPSpercues {

			get {

				if (this.internal_Param_Compte_TPSpercues_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Compte_TPSpercues);
			}

			set {

				this.internal_Param_Compte_TPSpercues_UseDefaultValue = false;
				this.internal_Param_Compte_TPSpercues = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Compte_TPSpercues' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Compte_TPSpercues_UseDefaultValue() {

			this.internal_Param_Compte_TPSpercues_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Compte_TPSpayees'.
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
		/// the parameter default value, consider calling the Param_Compte_TPSpayees_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlInt32 Param_Compte_TPSpayees {

			get {

				if (this.internal_Param_Compte_TPSpayees_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Compte_TPSpayees);
			}

			set {

				this.internal_Param_Compte_TPSpayees_UseDefaultValue = false;
				this.internal_Param_Compte_TPSpayees = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Compte_TPSpayees' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Compte_TPSpayees_UseDefaultValue() {

			this.internal_Param_Compte_TPSpayees_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Compte_TVQpercues'.
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
		/// the parameter default value, consider calling the Param_Compte_TVQpercues_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlInt32 Param_Compte_TVQpercues {

			get {

				if (this.internal_Param_Compte_TVQpercues_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Compte_TVQpercues);
			}

			set {

				this.internal_Param_Compte_TVQpercues_UseDefaultValue = false;
				this.internal_Param_Compte_TVQpercues = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Compte_TVQpercues' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Compte_TVQpercues_UseDefaultValue() {

			this.internal_Param_Compte_TVQpercues_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Compte_TVQpayees'.
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
		/// the parameter default value, consider calling the Param_Compte_TVQpayees_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlInt32 Param_Compte_TVQpayees {

			get {

				if (this.internal_Param_Compte_TVQpayees_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Compte_TVQpayees);
			}

			set {

				this.internal_Param_Compte_TVQpayees_UseDefaultValue = false;
				this.internal_Param_Compte_TVQpayees = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Compte_TVQpayees' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Compte_TVQpayees_UseDefaultValue() {

			this.internal_Param_Compte_TVQpayees_UseDefaultValue = true;
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
	/// This class allows you to execute the 'spS_jag_System_Full' stored procedure;
	/// it gives you the ability to:
	/// <list type="bullet">
	/// <item><description>Set all the necessary parameters to execute the stored procedure</description></item>
	/// <item><description>To execute the stored procedure</description></item>
	/// <item><description>To get back after the execution the return value and all the output parameters value</description></item>
	/// </list>
	/// </summary>
#if OLYMARS_ATTRIBUTE || OLYMARS_DEBUG
	[OlymarsInformation(DeveloperName="<Developer Name Here>", GeneratedOn="2007/03/30 13:55:24", SqlObjectDependancyName="spS_jag_System_Full", SqlObjectDependancyRevision=0)]
#endif
	public sealed class spS_jag_System_Full : MarshalByRefObject, IDisposable {


		private bool throwExceptionOnExecute = false;

		/// <summary>
		/// Initializes a new instance of the spS_jag_System_Full class.
		/// By default, no exception will be thrown when you call the Execute method. Instead, a Boolean return status will be returned.
		/// </summary>
		public spS_jag_System_Full() : this(false) {

		}

		/// <summary>
		/// Initializes a new instance of the spS_jag_System_Full class.
		/// </summary>
		/// <param name="throwExceptionOnExecute">True if an exception has to be thrown if the Execute call fails.</param>
		public spS_jag_System_Full(bool throwExceptionOnExecute) {

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
		~spS_jag_System_Full() {

			Dispose(false);
		}

		private void ResetParameter(ref Gestion_Paie.DataClasses.Parameters.spS_jag_System_Full parameters) {

			parameters.internal_Set_RETURN_VALUE (System.Data.SqlTypes.SqlInt32.Null);
		}

		private bool InitializeConnection(ref Gestion_Paie.DataClasses.Parameters.spS_jag_System_Full parameters, out System.Data.SqlClient.SqlCommand sqlCommand, ref bool connectionMustBeClosed) {

			try {

				this.sqlConnection = null;
				sqlCommand = null;
				connectionMustBeClosed = true;

				if (parameters.ConnectionType == ConnectionType.None) {

					throw new InvalidOperationException("No connection information was supplied. Consider calling the 'SetUpConnection' method of the Gestion_Paie.DataClasses.Parameters.spS_jag_System_Full object before doing this call.");
				}

				if (parameters.ConnectionType == ConnectionType.SqlConnection && parameters.SqlConnection == null) {

					throw new InvalidOperationException("No connection information was supplied (SqlConnection == null). Consider calling the 'SetUpConnection' method of the Gestion_Paie.DataClasses.Parameters.spS_jag_System_Full object before doing this call.");
				}

				if (parameters.ConnectionType == ConnectionType.SqlTransaction && parameters.SqlTransaction== null) {

					throw new InvalidOperationException("No connection information was supplied (SqlTransaction == null). Consider calling the 'SetUpConnection' method of the Gestion_Paie.DataClasses.Parameters.spS_jag_System_Full object before doing this call.");
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

							throw new System.InvalidOperationException("No connection information was supplied (ConnectionString == \"\")! (Gestion_Paie.DataClasses.Parameters.spS_jag_System_Full)");
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
				sqlCommand.CommandText = "spS_jag_System_Full";

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

		private bool DeclareParameters(ref Gestion_Paie.DataClasses.Parameters.spS_jag_System_Full parameters, ref System.Data.SqlClient.SqlCommand sqlCommand) {

			try {

				System.Data.SqlClient.SqlParameter sqlParameter;

				sqlParameter = new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4);
				sqlParameter.Direction = System.Data.ParameterDirection.ReturnValue;
				sqlParameter.IsNullable = true;
				sqlParameter.Value = System.DBNull.Value;
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Fournisseur_PlanConjoint", System.Data.SqlDbType.VarChar, 15);
				sqlParameter.SourceColumn = "Fournisseur_PlanConjoint";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Fournisseur_PlanConjoint_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Fournisseur_PlanConjoint.IsNull) {

					sqlParameter.Value = parameters.Param_Fournisseur_PlanConjoint;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Fournisseur_Surcharge", System.Data.SqlDbType.VarChar, 15);
				sqlParameter.SourceColumn = "Fournisseur_Surcharge";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Fournisseur_Surcharge_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Fournisseur_Surcharge.IsNull) {

					sqlParameter.Value = parameters.Param_Fournisseur_Surcharge;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Compte_Paiements", System.Data.SqlDbType.Int, 4);
				sqlParameter.SourceColumn = "Compte_Paiements";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Compte_Paiements_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Compte_Paiements.IsNull) {

					sqlParameter.Value = parameters.Param_Compte_Paiements;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Compte_ARecevoir", System.Data.SqlDbType.Int, 4);
				sqlParameter.SourceColumn = "Compte_ARecevoir";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Compte_ARecevoir_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Compte_ARecevoir.IsNull) {

					sqlParameter.Value = parameters.Param_Compte_ARecevoir;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Compte_APayer", System.Data.SqlDbType.Int, 4);
				sqlParameter.SourceColumn = "Compte_APayer";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Compte_APayer_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Compte_APayer.IsNull) {

					sqlParameter.Value = parameters.Param_Compte_APayer;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Compte_DuAuxProducteurs", System.Data.SqlDbType.Int, 4);
				sqlParameter.SourceColumn = "Compte_DuAuxProducteurs";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Compte_DuAuxProducteurs_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Compte_DuAuxProducteurs.IsNull) {

					sqlParameter.Value = parameters.Param_Compte_DuAuxProducteurs;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Compte_TPSpercues", System.Data.SqlDbType.Int, 4);
				sqlParameter.SourceColumn = "Compte_TPSpercues";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Compte_TPSpercues_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Compte_TPSpercues.IsNull) {

					sqlParameter.Value = parameters.Param_Compte_TPSpercues;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Compte_TPSpayees", System.Data.SqlDbType.Int, 4);
				sqlParameter.SourceColumn = "Compte_TPSpayees";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Compte_TPSpayees_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Compte_TPSpayees.IsNull) {

					sqlParameter.Value = parameters.Param_Compte_TPSpayees;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Compte_TVQpercues", System.Data.SqlDbType.Int, 4);
				sqlParameter.SourceColumn = "Compte_TVQpercues";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Compte_TVQpercues_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Compte_TVQpercues.IsNull) {

					sqlParameter.Value = parameters.Param_Compte_TVQpercues;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Compte_TVQpayees", System.Data.SqlDbType.Int, 4);
				sqlParameter.SourceColumn = "Compte_TVQpayees";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Compte_TVQpayees_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Compte_TVQpayees.IsNull) {

					sqlParameter.Value = parameters.Param_Compte_TVQpayees;
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

		private bool RetrieveParameters(ref Gestion_Paie.DataClasses.Parameters.spS_jag_System_Full parameters, ref System.Data.SqlClient.SqlCommand sqlCommand) {

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
		/// This method allows you to execute the [spS_jag_System_Full] stored procedure and retrieve back the data
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
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.spS_jag_System_Full parameters, out System.Data.SqlClient.SqlDataReader sqlDataReader) {

			return(Execute(ref parameters, out sqlDataReader, System.Data.CommandBehavior.Default));
		}

		/// <summary>
		/// This method allows you to execute the [spS_jag_System_Full] stored procedure and retrieve back the data
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
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.spS_jag_System_Full parameters, out System.Data.SqlClient.SqlDataReader sqlDataReader, System.Data.CommandBehavior commandBehavior) {

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
		/// This method allows you to execute the [spS_jag_System_Full] stored procedure and retrieve back the data
		/// populated in a DataSet (System.Data.DataSet).
		/// </summary>
		/// <param name="parameters">
		/// Contains all the necessary information to execute correctly the stored procedure, i.e. 
		/// the database connection to use and all the necessary input parameters to be supplied
		/// for this stored procedure execution. After the execution, this object will allow you
		/// to retrieve back the stored procedure return value and all the output parameters.
		/// </param>
		/// <param name="dataset">
		/// Will be populated with the data after execution. The table based name used will be: 'spS_jag_System_Full'.
		/// </param>
		/// <returns>True if the call was successful. Otherwise, it returns False.</returns>
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.spS_jag_System_Full parameters, ref System.Data.DataSet dataset) {

			return(Execute(ref parameters, ref dataset, "spS_jag_System_Full", -1, -1));
		}

		/// <summary>
		/// This method allows you to execute the [spS_jag_System_Full] stored procedure and retrieve back the data
		/// populated in a DataSet (System.Data.DataSet).
		/// </summary>
		/// <param name="parameters">
		/// Contains all the necessary information to execute correctly the stored procedure, i.e. 
		/// the database connection to use and all the necessary input parameters to be supplied
		/// for this stored procedure execution. After the execution, this object will allow you
		/// to retrieve back the stored procedure return value and all the output parameters.
		/// </param>
		/// <param name="dataset">
		/// Will be populated with the data after execution. The table based name used will be: 'spS_jag_System_Full'.
		/// </param>
		/// <param name="startRecord">The zero-based record number to start with.</param>
		/// <param name="maxRecords">The maximum number of records to retrieve.</param>
		/// <returns>True if the call was successful. Otherwise, it returns False.</returns>
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.spS_jag_System_Full parameters, ref System.Data.DataSet dataset, int startRecord, int maxRecords) {

			return(Execute(ref parameters, ref dataset, "spS_jag_System_Full", startRecord, maxRecords));
		}

		/// <summary>
		/// This method allows you to execute the [spS_jag_System_Full] stored procedure and retrieve back the data
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
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.spS_jag_System_Full parameters, ref System.Data.DataSet dataset, string tableName) {

			return(Execute(ref parameters, ref dataset, tableName, -1, -1));
		}

		/// <summary>
		/// This method allows you to execute the [spS_jag_System_Full] stored procedure and retrieve back the data
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
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.spS_jag_System_Full parameters, ref System.Data.DataSet dataset, string tableName, int startRecord, int maxRecords) {

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

				dataset.Tables[tableName].Columns["Fournisseur_PlanConjoint"].Caption = "Fournisseur_PlanConjoint (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Fournisseur_PlanConjoint\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_Surcharge"].Caption = "Fournisseur_Surcharge (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Fournisseur_Surcharge\" column)";
				dataset.Tables[tableName].Columns["Compte_Paiements"].Caption = "Compte_Paiements (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Compte_Paiements\" column)";
				dataset.Tables[tableName].Columns["Compte_ARecevoir"].Caption = "Compte_ARecevoir (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Compte_ARecevoir\" column)";
				dataset.Tables[tableName].Columns["Compte_APayer"].Caption = "Compte_APayer (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Compte_APayer\" column)";
				dataset.Tables[tableName].Columns["Compte_DuAuxProducteurs"].Caption = "Compte_DuAuxProducteurs (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Compte_DuAuxProducteurs\" column)";
				dataset.Tables[tableName].Columns["Compte_TPSpercues"].Caption = "Compte_TPSpercues (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Compte_TPSpercues\" column)";
				dataset.Tables[tableName].Columns["Compte_TPSpayees"].Caption = "Compte_TPSpayees (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Compte_TPSpayees\" column)";
				dataset.Tables[tableName].Columns["Compte_TVQpercues"].Caption = "Compte_TVQpercues (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Compte_TVQpercues\" column)";
				dataset.Tables[tableName].Columns["Compte_TVQpayees"].Caption = "Compte_TVQpayees (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Compte_TVQpayees\" column)";
				dataset.Tables[tableName].Columns["Taux_TPS"].Caption = "Taux_TPS (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Taux_TPS\" column)";
				dataset.Tables[tableName].Columns["Taux_TVQ"].Caption = "Taux_TVQ (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Taux_TVQ\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_Fond_Roulement"].Caption = "Fournisseur_Fond_Roulement (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Fournisseur_Fond_Roulement\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_Fond_Forestier"].Caption = "Fournisseur_Fond_Forestier (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Fournisseur_Fond_Forestier\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_Preleve_Divers"].Caption = "Fournisseur_Preleve_Divers (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Fournisseur_Preleve_Divers\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_PlanConjoint_ID"].Caption = "ID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ID\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_PlanConjoint_CleTri"].Caption = "CleTri (update this label in the \"Olymars/ColumnLabel\" extended property of the \"CleTri\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_PlanConjoint_Nom"].Caption = "Nom (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Nom\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_PlanConjoint_AuSoinsDe"].Caption = "AuSoinsDe (update this label in the \"Olymars/ColumnLabel\" extended property of the \"AuSoinsDe\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_PlanConjoint_Rue"].Caption = "Rue (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Rue\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_PlanConjoint_Ville"].Caption = "Ville (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Ville\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_PlanConjoint_PaysID"].Caption = "PaysID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"PaysID\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_PlanConjoint_Code_postal"].Caption = "Code_postal (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Code_postal\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_PlanConjoint_Telephone"].Caption = "Telephone (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_PlanConjoint_Telephone_Poste"].Caption = "Telephone_Poste (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone_Poste\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_PlanConjoint_Telecopieur"].Caption = "Telecopieur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telecopieur\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_PlanConjoint_Telephone2"].Caption = "Telephone2 (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone2\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_PlanConjoint_Telephone2_Desc"].Caption = "Telephone2_Desc (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone2_Desc\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_PlanConjoint_Telephone2_Poste"].Caption = "Telephone2_Poste (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone2_Poste\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_PlanConjoint_Telephone3"].Caption = "Telephone3 (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone3\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_PlanConjoint_Telephone3_Desc"].Caption = "Telephone3_Desc (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone3_Desc\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_PlanConjoint_Telephone3_Poste"].Caption = "Telephone3_Poste (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone3_Poste\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_PlanConjoint_No_membre"].Caption = "No_membre (update this label in the \"Olymars/ColumnLabel\" extended property of the \"No_membre\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_PlanConjoint_Resident"].Caption = "Resident (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Resident\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_PlanConjoint_Email"].Caption = "Email (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Email\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_PlanConjoint_WWW"].Caption = "WWW (update this label in the \"Olymars/ColumnLabel\" extended property of the \"WWW\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_PlanConjoint_Commentaires"].Caption = "Commentaires (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Commentaires\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_PlanConjoint_AfficherCommentaires"].Caption = "AfficherCommentaires (update this label in the \"Olymars/ColumnLabel\" extended property of the \"AfficherCommentaires\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_PlanConjoint_DepotDirect"].Caption = "DepotDirect (update this label in the \"Olymars/ColumnLabel\" extended property of the \"DepotDirect\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_PlanConjoint_InstitutionBanquaireID"].Caption = "InstitutionBanquaireID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"InstitutionBanquaireID\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_PlanConjoint_Banque_transit"].Caption = "Banque_transit (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Banque_transit\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_PlanConjoint_Banque_folio"].Caption = "Banque_folio (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Banque_folio\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_PlanConjoint_No_TPS"].Caption = "No_TPS (update this label in the \"Olymars/ColumnLabel\" extended property of the \"No_TPS\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_PlanConjoint_No_TVQ"].Caption = "No_TVQ (update this label in the \"Olymars/ColumnLabel\" extended property of the \"No_TVQ\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_PlanConjoint_PayerA"].Caption = "PayerA (update this label in the \"Olymars/ColumnLabel\" extended property of the \"PayerA\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_PlanConjoint_PayerAID"].Caption = "PayerAID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"PayerAID\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_PlanConjoint_Statut"].Caption = "Statut (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Statut\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_PlanConjoint_Rep_Nom"].Caption = "Rep_Nom (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Rep_Nom\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_PlanConjoint_Rep_Telephone"].Caption = "Rep_Telephone (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Rep_Telephone\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_PlanConjoint_Rep_Telephone_Poste"].Caption = "Rep_Telephone_Poste (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Rep_Telephone_Poste\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_PlanConjoint_Rep_Email"].Caption = "Rep_Email (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Rep_Email\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_PlanConjoint_EnAnglais"].Caption = "EnAnglais (update this label in the \"Olymars/ColumnLabel\" extended property of the \"EnAnglais\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_PlanConjoint_Actif"].Caption = "Actif (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Actif\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_PlanConjoint_MRCProducteurID"].Caption = "MRCProducteurID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"MRCProducteurID\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_PlanConjoint_PaiementManuel"].Caption = "PaiementManuel (update this label in the \"Olymars/ColumnLabel\" extended property of the \"PaiementManuel\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_PlanConjoint_Journal"].Caption = "Journal (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Journal\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_PlanConjoint_RecoitTPS"].Caption = "RecoitTPS (update this label in the \"Olymars/ColumnLabel\" extended property of the \"RecoitTPS\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_PlanConjoint_RecoitTVQ"].Caption = "RecoitTVQ (update this label in the \"Olymars/ColumnLabel\" extended property of the \"RecoitTVQ\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_PlanConjoint_ModifierTrigger"].Caption = "ModifierTrigger (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ModifierTrigger\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_PlanConjoint_IsProducteur"].Caption = "IsProducteur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"IsProducteur\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_PlanConjoint_IsTransporteur"].Caption = "IsTransporteur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"IsTransporteur\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_PlanConjoint_IsChargeur"].Caption = "IsChargeur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"IsChargeur\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_PlanConjoint_IsAutre"].Caption = "IsAutre (update this label in the \"Olymars/ColumnLabel\" extended property of the \"IsAutre\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_PlanConjoint_AfficherCommentairesSurPermit"].Caption = "AfficherCommentairesSurPermit (update this label in the \"Olymars/ColumnLabel\" extended property of the \"AfficherCommentairesSurPermit\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_PlanConjoint_PasEmissionPermis"].Caption = "PasEmissionPermis (update this label in the \"Olymars/ColumnLabel\" extended property of the \"PasEmissionPermis\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_PlanConjoint_Generique"].Caption = "Generique (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Generique\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_Surcharge_ID"].Caption = "ID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ID\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_Surcharge_CleTri"].Caption = "CleTri (update this label in the \"Olymars/ColumnLabel\" extended property of the \"CleTri\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_Surcharge_Nom"].Caption = "Nom (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Nom\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_Surcharge_AuSoinsDe"].Caption = "AuSoinsDe (update this label in the \"Olymars/ColumnLabel\" extended property of the \"AuSoinsDe\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_Surcharge_Rue"].Caption = "Rue (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Rue\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_Surcharge_Ville"].Caption = "Ville (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Ville\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_Surcharge_PaysID"].Caption = "PaysID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"PaysID\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_Surcharge_Code_postal"].Caption = "Code_postal (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Code_postal\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_Surcharge_Telephone"].Caption = "Telephone (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_Surcharge_Telephone_Poste"].Caption = "Telephone_Poste (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone_Poste\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_Surcharge_Telecopieur"].Caption = "Telecopieur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telecopieur\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_Surcharge_Telephone2"].Caption = "Telephone2 (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone2\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_Surcharge_Telephone2_Desc"].Caption = "Telephone2_Desc (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone2_Desc\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_Surcharge_Telephone2_Poste"].Caption = "Telephone2_Poste (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone2_Poste\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_Surcharge_Telephone3"].Caption = "Telephone3 (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone3\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_Surcharge_Telephone3_Desc"].Caption = "Telephone3_Desc (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone3_Desc\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_Surcharge_Telephone3_Poste"].Caption = "Telephone3_Poste (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Telephone3_Poste\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_Surcharge_No_membre"].Caption = "No_membre (update this label in the \"Olymars/ColumnLabel\" extended property of the \"No_membre\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_Surcharge_Resident"].Caption = "Resident (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Resident\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_Surcharge_Email"].Caption = "Email (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Email\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_Surcharge_WWW"].Caption = "WWW (update this label in the \"Olymars/ColumnLabel\" extended property of the \"WWW\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_Surcharge_Commentaires"].Caption = "Commentaires (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Commentaires\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_Surcharge_AfficherCommentaires"].Caption = "AfficherCommentaires (update this label in the \"Olymars/ColumnLabel\" extended property of the \"AfficherCommentaires\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_Surcharge_DepotDirect"].Caption = "DepotDirect (update this label in the \"Olymars/ColumnLabel\" extended property of the \"DepotDirect\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_Surcharge_InstitutionBanquaireID"].Caption = "InstitutionBanquaireID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"InstitutionBanquaireID\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_Surcharge_Banque_transit"].Caption = "Banque_transit (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Banque_transit\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_Surcharge_Banque_folio"].Caption = "Banque_folio (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Banque_folio\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_Surcharge_No_TPS"].Caption = "No_TPS (update this label in the \"Olymars/ColumnLabel\" extended property of the \"No_TPS\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_Surcharge_No_TVQ"].Caption = "No_TVQ (update this label in the \"Olymars/ColumnLabel\" extended property of the \"No_TVQ\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_Surcharge_PayerA"].Caption = "PayerA (update this label in the \"Olymars/ColumnLabel\" extended property of the \"PayerA\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_Surcharge_PayerAID"].Caption = "PayerAID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"PayerAID\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_Surcharge_Statut"].Caption = "Statut (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Statut\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_Surcharge_Rep_Nom"].Caption = "Rep_Nom (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Rep_Nom\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_Surcharge_Rep_Telephone"].Caption = "Rep_Telephone (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Rep_Telephone\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_Surcharge_Rep_Telephone_Poste"].Caption = "Rep_Telephone_Poste (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Rep_Telephone_Poste\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_Surcharge_Rep_Email"].Caption = "Rep_Email (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Rep_Email\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_Surcharge_EnAnglais"].Caption = "EnAnglais (update this label in the \"Olymars/ColumnLabel\" extended property of the \"EnAnglais\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_Surcharge_Actif"].Caption = "Actif (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Actif\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_Surcharge_MRCProducteurID"].Caption = "MRCProducteurID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"MRCProducteurID\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_Surcharge_PaiementManuel"].Caption = "PaiementManuel (update this label in the \"Olymars/ColumnLabel\" extended property of the \"PaiementManuel\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_Surcharge_Journal"].Caption = "Journal (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Journal\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_Surcharge_RecoitTPS"].Caption = "RecoitTPS (update this label in the \"Olymars/ColumnLabel\" extended property of the \"RecoitTPS\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_Surcharge_RecoitTVQ"].Caption = "RecoitTVQ (update this label in the \"Olymars/ColumnLabel\" extended property of the \"RecoitTVQ\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_Surcharge_ModifierTrigger"].Caption = "ModifierTrigger (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ModifierTrigger\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_Surcharge_IsProducteur"].Caption = "IsProducteur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"IsProducteur\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_Surcharge_IsTransporteur"].Caption = "IsTransporteur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"IsTransporteur\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_Surcharge_IsChargeur"].Caption = "IsChargeur (update this label in the \"Olymars/ColumnLabel\" extended property of the \"IsChargeur\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_Surcharge_IsAutre"].Caption = "IsAutre (update this label in the \"Olymars/ColumnLabel\" extended property of the \"IsAutre\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_Surcharge_AfficherCommentairesSurPermit"].Caption = "AfficherCommentairesSurPermit (update this label in the \"Olymars/ColumnLabel\" extended property of the \"AfficherCommentairesSurPermit\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_Surcharge_PasEmissionPermis"].Caption = "PasEmissionPermis (update this label in the \"Olymars/ColumnLabel\" extended property of the \"PasEmissionPermis\" column)";
				dataset.Tables[tableName].Columns["Fournisseur_Surcharge_Generique"].Caption = "Generique (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Generique\" column)";
				dataset.Tables[tableName].Columns["Compte_Paiements_ID"].Caption = "ID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ID\" column)";
				dataset.Tables[tableName].Columns["Compte_Paiements_Description"].Caption = "Description (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Description\" column)";
				dataset.Tables[tableName].Columns["Compte_Paiements_CategoryID"].Caption = "CategoryID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"CategoryID\" column)";
				dataset.Tables[tableName].Columns["Compte_Paiements_isTaxe"].Caption = "isTaxe (update this label in the \"Olymars/ColumnLabel\" extended property of the \"isTaxe\" column)";
				dataset.Tables[tableName].Columns["Compte_Paiements_Actif"].Caption = "Actif (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Actif\" column)";
				dataset.Tables[tableName].Columns["Compte_ARecevoir_ID"].Caption = "ID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ID\" column)";
				dataset.Tables[tableName].Columns["Compte_ARecevoir_Description"].Caption = "Description (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Description\" column)";
				dataset.Tables[tableName].Columns["Compte_ARecevoir_CategoryID"].Caption = "CategoryID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"CategoryID\" column)";
				dataset.Tables[tableName].Columns["Compte_ARecevoir_isTaxe"].Caption = "isTaxe (update this label in the \"Olymars/ColumnLabel\" extended property of the \"isTaxe\" column)";
				dataset.Tables[tableName].Columns["Compte_ARecevoir_Actif"].Caption = "Actif (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Actif\" column)";
				dataset.Tables[tableName].Columns["Compte_APayer_ID"].Caption = "ID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ID\" column)";
				dataset.Tables[tableName].Columns["Compte_APayer_Description"].Caption = "Description (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Description\" column)";
				dataset.Tables[tableName].Columns["Compte_APayer_CategoryID"].Caption = "CategoryID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"CategoryID\" column)";
				dataset.Tables[tableName].Columns["Compte_APayer_isTaxe"].Caption = "isTaxe (update this label in the \"Olymars/ColumnLabel\" extended property of the \"isTaxe\" column)";
				dataset.Tables[tableName].Columns["Compte_APayer_Actif"].Caption = "Actif (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Actif\" column)";
				dataset.Tables[tableName].Columns["Compte_DuAuxProducteurs_ID"].Caption = "ID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ID\" column)";
				dataset.Tables[tableName].Columns["Compte_DuAuxProducteurs_Description"].Caption = "Description (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Description\" column)";
				dataset.Tables[tableName].Columns["Compte_DuAuxProducteurs_CategoryID"].Caption = "CategoryID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"CategoryID\" column)";
				dataset.Tables[tableName].Columns["Compte_DuAuxProducteurs_isTaxe"].Caption = "isTaxe (update this label in the \"Olymars/ColumnLabel\" extended property of the \"isTaxe\" column)";
				dataset.Tables[tableName].Columns["Compte_DuAuxProducteurs_Actif"].Caption = "Actif (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Actif\" column)";
				dataset.Tables[tableName].Columns["Compte_TPSpercues_ID"].Caption = "ID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ID\" column)";
				dataset.Tables[tableName].Columns["Compte_TPSpercues_Description"].Caption = "Description (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Description\" column)";
				dataset.Tables[tableName].Columns["Compte_TPSpercues_CategoryID"].Caption = "CategoryID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"CategoryID\" column)";
				dataset.Tables[tableName].Columns["Compte_TPSpercues_isTaxe"].Caption = "isTaxe (update this label in the \"Olymars/ColumnLabel\" extended property of the \"isTaxe\" column)";
				dataset.Tables[tableName].Columns["Compte_TPSpercues_Actif"].Caption = "Actif (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Actif\" column)";
				dataset.Tables[tableName].Columns["Compte_TPSpayees_ID"].Caption = "ID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ID\" column)";
				dataset.Tables[tableName].Columns["Compte_TPSpayees_Description"].Caption = "Description (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Description\" column)";
				dataset.Tables[tableName].Columns["Compte_TPSpayees_CategoryID"].Caption = "CategoryID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"CategoryID\" column)";
				dataset.Tables[tableName].Columns["Compte_TPSpayees_isTaxe"].Caption = "isTaxe (update this label in the \"Olymars/ColumnLabel\" extended property of the \"isTaxe\" column)";
				dataset.Tables[tableName].Columns["Compte_TPSpayees_Actif"].Caption = "Actif (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Actif\" column)";
				dataset.Tables[tableName].Columns["Compte_TVQpercues_ID"].Caption = "ID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ID\" column)";
				dataset.Tables[tableName].Columns["Compte_TVQpercues_Description"].Caption = "Description (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Description\" column)";
				dataset.Tables[tableName].Columns["Compte_TVQpercues_CategoryID"].Caption = "CategoryID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"CategoryID\" column)";
				dataset.Tables[tableName].Columns["Compte_TVQpercues_isTaxe"].Caption = "isTaxe (update this label in the \"Olymars/ColumnLabel\" extended property of the \"isTaxe\" column)";
				dataset.Tables[tableName].Columns["Compte_TVQpercues_Actif"].Caption = "Actif (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Actif\" column)";
				dataset.Tables[tableName].Columns["Compte_TVQpayees_ID"].Caption = "ID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"ID\" column)";
				dataset.Tables[tableName].Columns["Compte_TVQpayees_Description"].Caption = "Description (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Description\" column)";
				dataset.Tables[tableName].Columns["Compte_TVQpayees_CategoryID"].Caption = "CategoryID (update this label in the \"Olymars/ColumnLabel\" extended property of the \"CategoryID\" column)";
				dataset.Tables[tableName].Columns["Compte_TVQpayees_isTaxe"].Caption = "isTaxe (update this label in the \"Olymars/ColumnLabel\" extended property of the \"isTaxe\" column)";
				dataset.Tables[tableName].Columns["Compte_TVQpayees_Actif"].Caption = "Actif (update this label in the \"Olymars/ColumnLabel\" extended property of the \"Actif\" column)";

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
		/// This method allows you to execute the [spS_jag_System_Full] stored procedure and retrieve back the data
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
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.spS_jag_System_Full parameters, ref string xml) {

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
		/// This method allows you to execute the [spS_jag_System_Full] stored procedure and retrieve back the data
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
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.spS_jag_System_Full parameters, out System.Xml.XmlReader xmlReader) {

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
		/// the Execute method of the 'spS_jag_System_Full' class.
		/// </summary>
		public sealed class Resultset1 {


			/// <summary>
			/// This collection provides the fields collection for this resultset.
			/// </summary>
			public sealed class Fields {

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_PlanConjoint via shared members
				/// </summary>
				public sealed class Column_Fournisseur_PlanConjoint {

					/// <summary>
					/// Returns "Fournisseur_PlanConjoint"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_PlanConjoint";
					/// <summary>
					/// Returns 0
					/// </summary>
					public const System.Int32 ColumnIndex = 0;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_Surcharge via shared members
				/// </summary>
				public sealed class Column_Fournisseur_Surcharge {

					/// <summary>
					/// Returns "Fournisseur_Surcharge"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_Surcharge";
					/// <summary>
					/// Returns 1
					/// </summary>
					public const System.Int32 ColumnIndex = 1;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Compte_Paiements via shared members
				/// </summary>
				public sealed class Column_Compte_Paiements {

					/// <summary>
					/// Returns "Compte_Paiements"
					/// </summary>
					public const System.String ColumnName = "Compte_Paiements";
					/// <summary>
					/// Returns 2
					/// </summary>
					public const System.Int32 ColumnIndex = 2;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Compte_ARecevoir via shared members
				/// </summary>
				public sealed class Column_Compte_ARecevoir {

					/// <summary>
					/// Returns "Compte_ARecevoir"
					/// </summary>
					public const System.String ColumnName = "Compte_ARecevoir";
					/// <summary>
					/// Returns 3
					/// </summary>
					public const System.Int32 ColumnIndex = 3;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Compte_APayer via shared members
				/// </summary>
				public sealed class Column_Compte_APayer {

					/// <summary>
					/// Returns "Compte_APayer"
					/// </summary>
					public const System.String ColumnName = "Compte_APayer";
					/// <summary>
					/// Returns 4
					/// </summary>
					public const System.Int32 ColumnIndex = 4;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Compte_DuAuxProducteurs via shared members
				/// </summary>
				public sealed class Column_Compte_DuAuxProducteurs {

					/// <summary>
					/// Returns "Compte_DuAuxProducteurs"
					/// </summary>
					public const System.String ColumnName = "Compte_DuAuxProducteurs";
					/// <summary>
					/// Returns 5
					/// </summary>
					public const System.Int32 ColumnIndex = 5;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Compte_TPSpercues via shared members
				/// </summary>
				public sealed class Column_Compte_TPSpercues {

					/// <summary>
					/// Returns "Compte_TPSpercues"
					/// </summary>
					public const System.String ColumnName = "Compte_TPSpercues";
					/// <summary>
					/// Returns 6
					/// </summary>
					public const System.Int32 ColumnIndex = 6;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Compte_TPSpayees via shared members
				/// </summary>
				public sealed class Column_Compte_TPSpayees {

					/// <summary>
					/// Returns "Compte_TPSpayees"
					/// </summary>
					public const System.String ColumnName = "Compte_TPSpayees";
					/// <summary>
					/// Returns 7
					/// </summary>
					public const System.Int32 ColumnIndex = 7;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Compte_TVQpercues via shared members
				/// </summary>
				public sealed class Column_Compte_TVQpercues {

					/// <summary>
					/// Returns "Compte_TVQpercues"
					/// </summary>
					public const System.String ColumnName = "Compte_TVQpercues";
					/// <summary>
					/// Returns 8
					/// </summary>
					public const System.Int32 ColumnIndex = 8;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Compte_TVQpayees via shared members
				/// </summary>
				public sealed class Column_Compte_TVQpayees {

					/// <summary>
					/// Returns "Compte_TVQpayees"
					/// </summary>
					public const System.String ColumnName = "Compte_TVQpayees";
					/// <summary>
					/// Returns 9
					/// </summary>
					public const System.Int32 ColumnIndex = 9;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Taux_TPS via shared members
				/// </summary>
				public sealed class Column_Taux_TPS {

					/// <summary>
					/// Returns "Taux_TPS"
					/// </summary>
					public const System.String ColumnName = "Taux_TPS";
					/// <summary>
					/// Returns 10
					/// </summary>
					public const System.Int32 ColumnIndex = 10;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Taux_TVQ via shared members
				/// </summary>
				public sealed class Column_Taux_TVQ {

					/// <summary>
					/// Returns "Taux_TVQ"
					/// </summary>
					public const System.String ColumnName = "Taux_TVQ";
					/// <summary>
					/// Returns 11
					/// </summary>
					public const System.Int32 ColumnIndex = 11;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_Fond_Roulement via shared members
				/// </summary>
				public sealed class Column_Fournisseur_Fond_Roulement {

					/// <summary>
					/// Returns "Fournisseur_Fond_Roulement"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_Fond_Roulement";
					/// <summary>
					/// Returns 12
					/// </summary>
					public const System.Int32 ColumnIndex = 12;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_Fond_Forestier via shared members
				/// </summary>
				public sealed class Column_Fournisseur_Fond_Forestier {

					/// <summary>
					/// Returns "Fournisseur_Fond_Forestier"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_Fond_Forestier";
					/// <summary>
					/// Returns 13
					/// </summary>
					public const System.Int32 ColumnIndex = 13;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_Preleve_Divers via shared members
				/// </summary>
				public sealed class Column_Fournisseur_Preleve_Divers {

					/// <summary>
					/// Returns "Fournisseur_Preleve_Divers"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_Preleve_Divers";
					/// <summary>
					/// Returns 14
					/// </summary>
					public const System.Int32 ColumnIndex = 14;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_PlanConjoint_ID via shared members
				/// </summary>
				public sealed class Column_Fournisseur_PlanConjoint_ID {

					/// <summary>
					/// Returns "Fournisseur_PlanConjoint_ID"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_PlanConjoint_ID";
					/// <summary>
					/// Returns 15
					/// </summary>
					public const System.Int32 ColumnIndex = 15;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_PlanConjoint_CleTri via shared members
				/// </summary>
				public sealed class Column_Fournisseur_PlanConjoint_CleTri {

					/// <summary>
					/// Returns "Fournisseur_PlanConjoint_CleTri"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_PlanConjoint_CleTri";
					/// <summary>
					/// Returns 16
					/// </summary>
					public const System.Int32 ColumnIndex = 16;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_PlanConjoint_Nom via shared members
				/// </summary>
				public sealed class Column_Fournisseur_PlanConjoint_Nom {

					/// <summary>
					/// Returns "Fournisseur_PlanConjoint_Nom"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_PlanConjoint_Nom";
					/// <summary>
					/// Returns 17
					/// </summary>
					public const System.Int32 ColumnIndex = 17;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_PlanConjoint_AuSoinsDe via shared members
				/// </summary>
				public sealed class Column_Fournisseur_PlanConjoint_AuSoinsDe {

					/// <summary>
					/// Returns "Fournisseur_PlanConjoint_AuSoinsDe"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_PlanConjoint_AuSoinsDe";
					/// <summary>
					/// Returns 18
					/// </summary>
					public const System.Int32 ColumnIndex = 18;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_PlanConjoint_Rue via shared members
				/// </summary>
				public sealed class Column_Fournisseur_PlanConjoint_Rue {

					/// <summary>
					/// Returns "Fournisseur_PlanConjoint_Rue"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_PlanConjoint_Rue";
					/// <summary>
					/// Returns 19
					/// </summary>
					public const System.Int32 ColumnIndex = 19;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_PlanConjoint_Ville via shared members
				/// </summary>
				public sealed class Column_Fournisseur_PlanConjoint_Ville {

					/// <summary>
					/// Returns "Fournisseur_PlanConjoint_Ville"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_PlanConjoint_Ville";
					/// <summary>
					/// Returns 20
					/// </summary>
					public const System.Int32 ColumnIndex = 20;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_PlanConjoint_PaysID via shared members
				/// </summary>
				public sealed class Column_Fournisseur_PlanConjoint_PaysID {

					/// <summary>
					/// Returns "Fournisseur_PlanConjoint_PaysID"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_PlanConjoint_PaysID";
					/// <summary>
					/// Returns 21
					/// </summary>
					public const System.Int32 ColumnIndex = 21;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_PlanConjoint_Code_postal via shared members
				/// </summary>
				public sealed class Column_Fournisseur_PlanConjoint_Code_postal {

					/// <summary>
					/// Returns "Fournisseur_PlanConjoint_Code_postal"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_PlanConjoint_Code_postal";
					/// <summary>
					/// Returns 22
					/// </summary>
					public const System.Int32 ColumnIndex = 22;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_PlanConjoint_Telephone via shared members
				/// </summary>
				public sealed class Column_Fournisseur_PlanConjoint_Telephone {

					/// <summary>
					/// Returns "Fournisseur_PlanConjoint_Telephone"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_PlanConjoint_Telephone";
					/// <summary>
					/// Returns 23
					/// </summary>
					public const System.Int32 ColumnIndex = 23;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_PlanConjoint_Telephone_Poste via shared members
				/// </summary>
				public sealed class Column_Fournisseur_PlanConjoint_Telephone_Poste {

					/// <summary>
					/// Returns "Fournisseur_PlanConjoint_Telephone_Poste"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_PlanConjoint_Telephone_Poste";
					/// <summary>
					/// Returns 24
					/// </summary>
					public const System.Int32 ColumnIndex = 24;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_PlanConjoint_Telecopieur via shared members
				/// </summary>
				public sealed class Column_Fournisseur_PlanConjoint_Telecopieur {

					/// <summary>
					/// Returns "Fournisseur_PlanConjoint_Telecopieur"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_PlanConjoint_Telecopieur";
					/// <summary>
					/// Returns 25
					/// </summary>
					public const System.Int32 ColumnIndex = 25;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_PlanConjoint_Telephone2 via shared members
				/// </summary>
				public sealed class Column_Fournisseur_PlanConjoint_Telephone2 {

					/// <summary>
					/// Returns "Fournisseur_PlanConjoint_Telephone2"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_PlanConjoint_Telephone2";
					/// <summary>
					/// Returns 26
					/// </summary>
					public const System.Int32 ColumnIndex = 26;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_PlanConjoint_Telephone2_Desc via shared members
				/// </summary>
				public sealed class Column_Fournisseur_PlanConjoint_Telephone2_Desc {

					/// <summary>
					/// Returns "Fournisseur_PlanConjoint_Telephone2_Desc"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_PlanConjoint_Telephone2_Desc";
					/// <summary>
					/// Returns 27
					/// </summary>
					public const System.Int32 ColumnIndex = 27;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_PlanConjoint_Telephone2_Poste via shared members
				/// </summary>
				public sealed class Column_Fournisseur_PlanConjoint_Telephone2_Poste {

					/// <summary>
					/// Returns "Fournisseur_PlanConjoint_Telephone2_Poste"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_PlanConjoint_Telephone2_Poste";
					/// <summary>
					/// Returns 28
					/// </summary>
					public const System.Int32 ColumnIndex = 28;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_PlanConjoint_Telephone3 via shared members
				/// </summary>
				public sealed class Column_Fournisseur_PlanConjoint_Telephone3 {

					/// <summary>
					/// Returns "Fournisseur_PlanConjoint_Telephone3"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_PlanConjoint_Telephone3";
					/// <summary>
					/// Returns 29
					/// </summary>
					public const System.Int32 ColumnIndex = 29;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_PlanConjoint_Telephone3_Desc via shared members
				/// </summary>
				public sealed class Column_Fournisseur_PlanConjoint_Telephone3_Desc {

					/// <summary>
					/// Returns "Fournisseur_PlanConjoint_Telephone3_Desc"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_PlanConjoint_Telephone3_Desc";
					/// <summary>
					/// Returns 30
					/// </summary>
					public const System.Int32 ColumnIndex = 30;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_PlanConjoint_Telephone3_Poste via shared members
				/// </summary>
				public sealed class Column_Fournisseur_PlanConjoint_Telephone3_Poste {

					/// <summary>
					/// Returns "Fournisseur_PlanConjoint_Telephone3_Poste"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_PlanConjoint_Telephone3_Poste";
					/// <summary>
					/// Returns 31
					/// </summary>
					public const System.Int32 ColumnIndex = 31;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_PlanConjoint_No_membre via shared members
				/// </summary>
				public sealed class Column_Fournisseur_PlanConjoint_No_membre {

					/// <summary>
					/// Returns "Fournisseur_PlanConjoint_No_membre"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_PlanConjoint_No_membre";
					/// <summary>
					/// Returns 32
					/// </summary>
					public const System.Int32 ColumnIndex = 32;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_PlanConjoint_Resident via shared members
				/// </summary>
				public sealed class Column_Fournisseur_PlanConjoint_Resident {

					/// <summary>
					/// Returns "Fournisseur_PlanConjoint_Resident"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_PlanConjoint_Resident";
					/// <summary>
					/// Returns 33
					/// </summary>
					public const System.Int32 ColumnIndex = 33;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_PlanConjoint_Email via shared members
				/// </summary>
				public sealed class Column_Fournisseur_PlanConjoint_Email {

					/// <summary>
					/// Returns "Fournisseur_PlanConjoint_Email"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_PlanConjoint_Email";
					/// <summary>
					/// Returns 34
					/// </summary>
					public const System.Int32 ColumnIndex = 34;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_PlanConjoint_WWW via shared members
				/// </summary>
				public sealed class Column_Fournisseur_PlanConjoint_WWW {

					/// <summary>
					/// Returns "Fournisseur_PlanConjoint_WWW"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_PlanConjoint_WWW";
					/// <summary>
					/// Returns 35
					/// </summary>
					public const System.Int32 ColumnIndex = 35;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_PlanConjoint_Commentaires via shared members
				/// </summary>
				public sealed class Column_Fournisseur_PlanConjoint_Commentaires {

					/// <summary>
					/// Returns "Fournisseur_PlanConjoint_Commentaires"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_PlanConjoint_Commentaires";
					/// <summary>
					/// Returns 36
					/// </summary>
					public const System.Int32 ColumnIndex = 36;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_PlanConjoint_AfficherCommentaires via shared members
				/// </summary>
				public sealed class Column_Fournisseur_PlanConjoint_AfficherCommentaires {

					/// <summary>
					/// Returns "Fournisseur_PlanConjoint_AfficherCommentaires"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_PlanConjoint_AfficherCommentaires";
					/// <summary>
					/// Returns 37
					/// </summary>
					public const System.Int32 ColumnIndex = 37;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_PlanConjoint_DepotDirect via shared members
				/// </summary>
				public sealed class Column_Fournisseur_PlanConjoint_DepotDirect {

					/// <summary>
					/// Returns "Fournisseur_PlanConjoint_DepotDirect"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_PlanConjoint_DepotDirect";
					/// <summary>
					/// Returns 38
					/// </summary>
					public const System.Int32 ColumnIndex = 38;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_PlanConjoint_InstitutionBanquaireID via shared members
				/// </summary>
				public sealed class Column_Fournisseur_PlanConjoint_InstitutionBanquaireID {

					/// <summary>
					/// Returns "Fournisseur_PlanConjoint_InstitutionBanquaireID"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_PlanConjoint_InstitutionBanquaireID";
					/// <summary>
					/// Returns 39
					/// </summary>
					public const System.Int32 ColumnIndex = 39;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_PlanConjoint_Banque_transit via shared members
				/// </summary>
				public sealed class Column_Fournisseur_PlanConjoint_Banque_transit {

					/// <summary>
					/// Returns "Fournisseur_PlanConjoint_Banque_transit"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_PlanConjoint_Banque_transit";
					/// <summary>
					/// Returns 40
					/// </summary>
					public const System.Int32 ColumnIndex = 40;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_PlanConjoint_Banque_folio via shared members
				/// </summary>
				public sealed class Column_Fournisseur_PlanConjoint_Banque_folio {

					/// <summary>
					/// Returns "Fournisseur_PlanConjoint_Banque_folio"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_PlanConjoint_Banque_folio";
					/// <summary>
					/// Returns 41
					/// </summary>
					public const System.Int32 ColumnIndex = 41;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_PlanConjoint_No_TPS via shared members
				/// </summary>
				public sealed class Column_Fournisseur_PlanConjoint_No_TPS {

					/// <summary>
					/// Returns "Fournisseur_PlanConjoint_No_TPS"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_PlanConjoint_No_TPS";
					/// <summary>
					/// Returns 42
					/// </summary>
					public const System.Int32 ColumnIndex = 42;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_PlanConjoint_No_TVQ via shared members
				/// </summary>
				public sealed class Column_Fournisseur_PlanConjoint_No_TVQ {

					/// <summary>
					/// Returns "Fournisseur_PlanConjoint_No_TVQ"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_PlanConjoint_No_TVQ";
					/// <summary>
					/// Returns 43
					/// </summary>
					public const System.Int32 ColumnIndex = 43;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_PlanConjoint_PayerA via shared members
				/// </summary>
				public sealed class Column_Fournisseur_PlanConjoint_PayerA {

					/// <summary>
					/// Returns "Fournisseur_PlanConjoint_PayerA"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_PlanConjoint_PayerA";
					/// <summary>
					/// Returns 44
					/// </summary>
					public const System.Int32 ColumnIndex = 44;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_PlanConjoint_PayerAID via shared members
				/// </summary>
				public sealed class Column_Fournisseur_PlanConjoint_PayerAID {

					/// <summary>
					/// Returns "Fournisseur_PlanConjoint_PayerAID"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_PlanConjoint_PayerAID";
					/// <summary>
					/// Returns 45
					/// </summary>
					public const System.Int32 ColumnIndex = 45;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_PlanConjoint_Statut via shared members
				/// </summary>
				public sealed class Column_Fournisseur_PlanConjoint_Statut {

					/// <summary>
					/// Returns "Fournisseur_PlanConjoint_Statut"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_PlanConjoint_Statut";
					/// <summary>
					/// Returns 46
					/// </summary>
					public const System.Int32 ColumnIndex = 46;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_PlanConjoint_Rep_Nom via shared members
				/// </summary>
				public sealed class Column_Fournisseur_PlanConjoint_Rep_Nom {

					/// <summary>
					/// Returns "Fournisseur_PlanConjoint_Rep_Nom"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_PlanConjoint_Rep_Nom";
					/// <summary>
					/// Returns 47
					/// </summary>
					public const System.Int32 ColumnIndex = 47;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_PlanConjoint_Rep_Telephone via shared members
				/// </summary>
				public sealed class Column_Fournisseur_PlanConjoint_Rep_Telephone {

					/// <summary>
					/// Returns "Fournisseur_PlanConjoint_Rep_Telephone"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_PlanConjoint_Rep_Telephone";
					/// <summary>
					/// Returns 48
					/// </summary>
					public const System.Int32 ColumnIndex = 48;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_PlanConjoint_Rep_Telephone_Poste via shared members
				/// </summary>
				public sealed class Column_Fournisseur_PlanConjoint_Rep_Telephone_Poste {

					/// <summary>
					/// Returns "Fournisseur_PlanConjoint_Rep_Telephone_Poste"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_PlanConjoint_Rep_Telephone_Poste";
					/// <summary>
					/// Returns 49
					/// </summary>
					public const System.Int32 ColumnIndex = 49;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_PlanConjoint_Rep_Email via shared members
				/// </summary>
				public sealed class Column_Fournisseur_PlanConjoint_Rep_Email {

					/// <summary>
					/// Returns "Fournisseur_PlanConjoint_Rep_Email"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_PlanConjoint_Rep_Email";
					/// <summary>
					/// Returns 50
					/// </summary>
					public const System.Int32 ColumnIndex = 50;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_PlanConjoint_EnAnglais via shared members
				/// </summary>
				public sealed class Column_Fournisseur_PlanConjoint_EnAnglais {

					/// <summary>
					/// Returns "Fournisseur_PlanConjoint_EnAnglais"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_PlanConjoint_EnAnglais";
					/// <summary>
					/// Returns 51
					/// </summary>
					public const System.Int32 ColumnIndex = 51;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_PlanConjoint_Actif via shared members
				/// </summary>
				public sealed class Column_Fournisseur_PlanConjoint_Actif {

					/// <summary>
					/// Returns "Fournisseur_PlanConjoint_Actif"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_PlanConjoint_Actif";
					/// <summary>
					/// Returns 52
					/// </summary>
					public const System.Int32 ColumnIndex = 52;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_PlanConjoint_MRCProducteurID via shared members
				/// </summary>
				public sealed class Column_Fournisseur_PlanConjoint_MRCProducteurID {

					/// <summary>
					/// Returns "Fournisseur_PlanConjoint_MRCProducteurID"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_PlanConjoint_MRCProducteurID";
					/// <summary>
					/// Returns 53
					/// </summary>
					public const System.Int32 ColumnIndex = 53;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_PlanConjoint_PaiementManuel via shared members
				/// </summary>
				public sealed class Column_Fournisseur_PlanConjoint_PaiementManuel {

					/// <summary>
					/// Returns "Fournisseur_PlanConjoint_PaiementManuel"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_PlanConjoint_PaiementManuel";
					/// <summary>
					/// Returns 54
					/// </summary>
					public const System.Int32 ColumnIndex = 54;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_PlanConjoint_Journal via shared members
				/// </summary>
				public sealed class Column_Fournisseur_PlanConjoint_Journal {

					/// <summary>
					/// Returns "Fournisseur_PlanConjoint_Journal"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_PlanConjoint_Journal";
					/// <summary>
					/// Returns 55
					/// </summary>
					public const System.Int32 ColumnIndex = 55;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_PlanConjoint_RecoitTPS via shared members
				/// </summary>
				public sealed class Column_Fournisseur_PlanConjoint_RecoitTPS {

					/// <summary>
					/// Returns "Fournisseur_PlanConjoint_RecoitTPS"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_PlanConjoint_RecoitTPS";
					/// <summary>
					/// Returns 56
					/// </summary>
					public const System.Int32 ColumnIndex = 56;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_PlanConjoint_RecoitTVQ via shared members
				/// </summary>
				public sealed class Column_Fournisseur_PlanConjoint_RecoitTVQ {

					/// <summary>
					/// Returns "Fournisseur_PlanConjoint_RecoitTVQ"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_PlanConjoint_RecoitTVQ";
					/// <summary>
					/// Returns 57
					/// </summary>
					public const System.Int32 ColumnIndex = 57;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_PlanConjoint_ModifierTrigger via shared members
				/// </summary>
				public sealed class Column_Fournisseur_PlanConjoint_ModifierTrigger {

					/// <summary>
					/// Returns "Fournisseur_PlanConjoint_ModifierTrigger"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_PlanConjoint_ModifierTrigger";
					/// <summary>
					/// Returns 58
					/// </summary>
					public const System.Int32 ColumnIndex = 58;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_PlanConjoint_IsProducteur via shared members
				/// </summary>
				public sealed class Column_Fournisseur_PlanConjoint_IsProducteur {

					/// <summary>
					/// Returns "Fournisseur_PlanConjoint_IsProducteur"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_PlanConjoint_IsProducteur";
					/// <summary>
					/// Returns 59
					/// </summary>
					public const System.Int32 ColumnIndex = 59;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_PlanConjoint_IsTransporteur via shared members
				/// </summary>
				public sealed class Column_Fournisseur_PlanConjoint_IsTransporteur {

					/// <summary>
					/// Returns "Fournisseur_PlanConjoint_IsTransporteur"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_PlanConjoint_IsTransporteur";
					/// <summary>
					/// Returns 60
					/// </summary>
					public const System.Int32 ColumnIndex = 60;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_PlanConjoint_IsChargeur via shared members
				/// </summary>
				public sealed class Column_Fournisseur_PlanConjoint_IsChargeur {

					/// <summary>
					/// Returns "Fournisseur_PlanConjoint_IsChargeur"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_PlanConjoint_IsChargeur";
					/// <summary>
					/// Returns 61
					/// </summary>
					public const System.Int32 ColumnIndex = 61;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_PlanConjoint_IsAutre via shared members
				/// </summary>
				public sealed class Column_Fournisseur_PlanConjoint_IsAutre {

					/// <summary>
					/// Returns "Fournisseur_PlanConjoint_IsAutre"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_PlanConjoint_IsAutre";
					/// <summary>
					/// Returns 62
					/// </summary>
					public const System.Int32 ColumnIndex = 62;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_PlanConjoint_AfficherCommentairesSurPermit via shared members
				/// </summary>
				public sealed class Column_Fournisseur_PlanConjoint_AfficherCommentairesSurPermit {

					/// <summary>
					/// Returns "Fournisseur_PlanConjoint_AfficherCommentairesSurPermit"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_PlanConjoint_AfficherCommentairesSurPermit";
					/// <summary>
					/// Returns 63
					/// </summary>
					public const System.Int32 ColumnIndex = 63;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_PlanConjoint_PasEmissionPermis via shared members
				/// </summary>
				public sealed class Column_Fournisseur_PlanConjoint_PasEmissionPermis {

					/// <summary>
					/// Returns "Fournisseur_PlanConjoint_PasEmissionPermis"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_PlanConjoint_PasEmissionPermis";
					/// <summary>
					/// Returns 64
					/// </summary>
					public const System.Int32 ColumnIndex = 64;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_PlanConjoint_Generique via shared members
				/// </summary>
				public sealed class Column_Fournisseur_PlanConjoint_Generique {

					/// <summary>
					/// Returns "Fournisseur_PlanConjoint_Generique"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_PlanConjoint_Generique";
					/// <summary>
					/// Returns 65
					/// </summary>
					public const System.Int32 ColumnIndex = 65;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_Surcharge_ID via shared members
				/// </summary>
				public sealed class Column_Fournisseur_Surcharge_ID {

					/// <summary>
					/// Returns "Fournisseur_Surcharge_ID"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_Surcharge_ID";
					/// <summary>
					/// Returns 66
					/// </summary>
					public const System.Int32 ColumnIndex = 66;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_Surcharge_CleTri via shared members
				/// </summary>
				public sealed class Column_Fournisseur_Surcharge_CleTri {

					/// <summary>
					/// Returns "Fournisseur_Surcharge_CleTri"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_Surcharge_CleTri";
					/// <summary>
					/// Returns 67
					/// </summary>
					public const System.Int32 ColumnIndex = 67;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_Surcharge_Nom via shared members
				/// </summary>
				public sealed class Column_Fournisseur_Surcharge_Nom {

					/// <summary>
					/// Returns "Fournisseur_Surcharge_Nom"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_Surcharge_Nom";
					/// <summary>
					/// Returns 68
					/// </summary>
					public const System.Int32 ColumnIndex = 68;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_Surcharge_AuSoinsDe via shared members
				/// </summary>
				public sealed class Column_Fournisseur_Surcharge_AuSoinsDe {

					/// <summary>
					/// Returns "Fournisseur_Surcharge_AuSoinsDe"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_Surcharge_AuSoinsDe";
					/// <summary>
					/// Returns 69
					/// </summary>
					public const System.Int32 ColumnIndex = 69;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_Surcharge_Rue via shared members
				/// </summary>
				public sealed class Column_Fournisseur_Surcharge_Rue {

					/// <summary>
					/// Returns "Fournisseur_Surcharge_Rue"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_Surcharge_Rue";
					/// <summary>
					/// Returns 70
					/// </summary>
					public const System.Int32 ColumnIndex = 70;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_Surcharge_Ville via shared members
				/// </summary>
				public sealed class Column_Fournisseur_Surcharge_Ville {

					/// <summary>
					/// Returns "Fournisseur_Surcharge_Ville"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_Surcharge_Ville";
					/// <summary>
					/// Returns 71
					/// </summary>
					public const System.Int32 ColumnIndex = 71;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_Surcharge_PaysID via shared members
				/// </summary>
				public sealed class Column_Fournisseur_Surcharge_PaysID {

					/// <summary>
					/// Returns "Fournisseur_Surcharge_PaysID"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_Surcharge_PaysID";
					/// <summary>
					/// Returns 72
					/// </summary>
					public const System.Int32 ColumnIndex = 72;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_Surcharge_Code_postal via shared members
				/// </summary>
				public sealed class Column_Fournisseur_Surcharge_Code_postal {

					/// <summary>
					/// Returns "Fournisseur_Surcharge_Code_postal"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_Surcharge_Code_postal";
					/// <summary>
					/// Returns 73
					/// </summary>
					public const System.Int32 ColumnIndex = 73;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_Surcharge_Telephone via shared members
				/// </summary>
				public sealed class Column_Fournisseur_Surcharge_Telephone {

					/// <summary>
					/// Returns "Fournisseur_Surcharge_Telephone"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_Surcharge_Telephone";
					/// <summary>
					/// Returns 74
					/// </summary>
					public const System.Int32 ColumnIndex = 74;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_Surcharge_Telephone_Poste via shared members
				/// </summary>
				public sealed class Column_Fournisseur_Surcharge_Telephone_Poste {

					/// <summary>
					/// Returns "Fournisseur_Surcharge_Telephone_Poste"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_Surcharge_Telephone_Poste";
					/// <summary>
					/// Returns 75
					/// </summary>
					public const System.Int32 ColumnIndex = 75;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_Surcharge_Telecopieur via shared members
				/// </summary>
				public sealed class Column_Fournisseur_Surcharge_Telecopieur {

					/// <summary>
					/// Returns "Fournisseur_Surcharge_Telecopieur"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_Surcharge_Telecopieur";
					/// <summary>
					/// Returns 76
					/// </summary>
					public const System.Int32 ColumnIndex = 76;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_Surcharge_Telephone2 via shared members
				/// </summary>
				public sealed class Column_Fournisseur_Surcharge_Telephone2 {

					/// <summary>
					/// Returns "Fournisseur_Surcharge_Telephone2"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_Surcharge_Telephone2";
					/// <summary>
					/// Returns 77
					/// </summary>
					public const System.Int32 ColumnIndex = 77;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_Surcharge_Telephone2_Desc via shared members
				/// </summary>
				public sealed class Column_Fournisseur_Surcharge_Telephone2_Desc {

					/// <summary>
					/// Returns "Fournisseur_Surcharge_Telephone2_Desc"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_Surcharge_Telephone2_Desc";
					/// <summary>
					/// Returns 78
					/// </summary>
					public const System.Int32 ColumnIndex = 78;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_Surcharge_Telephone2_Poste via shared members
				/// </summary>
				public sealed class Column_Fournisseur_Surcharge_Telephone2_Poste {

					/// <summary>
					/// Returns "Fournisseur_Surcharge_Telephone2_Poste"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_Surcharge_Telephone2_Poste";
					/// <summary>
					/// Returns 79
					/// </summary>
					public const System.Int32 ColumnIndex = 79;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_Surcharge_Telephone3 via shared members
				/// </summary>
				public sealed class Column_Fournisseur_Surcharge_Telephone3 {

					/// <summary>
					/// Returns "Fournisseur_Surcharge_Telephone3"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_Surcharge_Telephone3";
					/// <summary>
					/// Returns 80
					/// </summary>
					public const System.Int32 ColumnIndex = 80;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_Surcharge_Telephone3_Desc via shared members
				/// </summary>
				public sealed class Column_Fournisseur_Surcharge_Telephone3_Desc {

					/// <summary>
					/// Returns "Fournisseur_Surcharge_Telephone3_Desc"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_Surcharge_Telephone3_Desc";
					/// <summary>
					/// Returns 81
					/// </summary>
					public const System.Int32 ColumnIndex = 81;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_Surcharge_Telephone3_Poste via shared members
				/// </summary>
				public sealed class Column_Fournisseur_Surcharge_Telephone3_Poste {

					/// <summary>
					/// Returns "Fournisseur_Surcharge_Telephone3_Poste"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_Surcharge_Telephone3_Poste";
					/// <summary>
					/// Returns 82
					/// </summary>
					public const System.Int32 ColumnIndex = 82;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_Surcharge_No_membre via shared members
				/// </summary>
				public sealed class Column_Fournisseur_Surcharge_No_membre {

					/// <summary>
					/// Returns "Fournisseur_Surcharge_No_membre"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_Surcharge_No_membre";
					/// <summary>
					/// Returns 83
					/// </summary>
					public const System.Int32 ColumnIndex = 83;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_Surcharge_Resident via shared members
				/// </summary>
				public sealed class Column_Fournisseur_Surcharge_Resident {

					/// <summary>
					/// Returns "Fournisseur_Surcharge_Resident"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_Surcharge_Resident";
					/// <summary>
					/// Returns 84
					/// </summary>
					public const System.Int32 ColumnIndex = 84;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_Surcharge_Email via shared members
				/// </summary>
				public sealed class Column_Fournisseur_Surcharge_Email {

					/// <summary>
					/// Returns "Fournisseur_Surcharge_Email"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_Surcharge_Email";
					/// <summary>
					/// Returns 85
					/// </summary>
					public const System.Int32 ColumnIndex = 85;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_Surcharge_WWW via shared members
				/// </summary>
				public sealed class Column_Fournisseur_Surcharge_WWW {

					/// <summary>
					/// Returns "Fournisseur_Surcharge_WWW"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_Surcharge_WWW";
					/// <summary>
					/// Returns 86
					/// </summary>
					public const System.Int32 ColumnIndex = 86;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_Surcharge_Commentaires via shared members
				/// </summary>
				public sealed class Column_Fournisseur_Surcharge_Commentaires {

					/// <summary>
					/// Returns "Fournisseur_Surcharge_Commentaires"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_Surcharge_Commentaires";
					/// <summary>
					/// Returns 87
					/// </summary>
					public const System.Int32 ColumnIndex = 87;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_Surcharge_AfficherCommentaires via shared members
				/// </summary>
				public sealed class Column_Fournisseur_Surcharge_AfficherCommentaires {

					/// <summary>
					/// Returns "Fournisseur_Surcharge_AfficherCommentaires"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_Surcharge_AfficherCommentaires";
					/// <summary>
					/// Returns 88
					/// </summary>
					public const System.Int32 ColumnIndex = 88;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_Surcharge_DepotDirect via shared members
				/// </summary>
				public sealed class Column_Fournisseur_Surcharge_DepotDirect {

					/// <summary>
					/// Returns "Fournisseur_Surcharge_DepotDirect"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_Surcharge_DepotDirect";
					/// <summary>
					/// Returns 89
					/// </summary>
					public const System.Int32 ColumnIndex = 89;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_Surcharge_InstitutionBanquaireID via shared members
				/// </summary>
				public sealed class Column_Fournisseur_Surcharge_InstitutionBanquaireID {

					/// <summary>
					/// Returns "Fournisseur_Surcharge_InstitutionBanquaireID"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_Surcharge_InstitutionBanquaireID";
					/// <summary>
					/// Returns 90
					/// </summary>
					public const System.Int32 ColumnIndex = 90;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_Surcharge_Banque_transit via shared members
				/// </summary>
				public sealed class Column_Fournisseur_Surcharge_Banque_transit {

					/// <summary>
					/// Returns "Fournisseur_Surcharge_Banque_transit"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_Surcharge_Banque_transit";
					/// <summary>
					/// Returns 91
					/// </summary>
					public const System.Int32 ColumnIndex = 91;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_Surcharge_Banque_folio via shared members
				/// </summary>
				public sealed class Column_Fournisseur_Surcharge_Banque_folio {

					/// <summary>
					/// Returns "Fournisseur_Surcharge_Banque_folio"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_Surcharge_Banque_folio";
					/// <summary>
					/// Returns 92
					/// </summary>
					public const System.Int32 ColumnIndex = 92;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_Surcharge_No_TPS via shared members
				/// </summary>
				public sealed class Column_Fournisseur_Surcharge_No_TPS {

					/// <summary>
					/// Returns "Fournisseur_Surcharge_No_TPS"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_Surcharge_No_TPS";
					/// <summary>
					/// Returns 93
					/// </summary>
					public const System.Int32 ColumnIndex = 93;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_Surcharge_No_TVQ via shared members
				/// </summary>
				public sealed class Column_Fournisseur_Surcharge_No_TVQ {

					/// <summary>
					/// Returns "Fournisseur_Surcharge_No_TVQ"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_Surcharge_No_TVQ";
					/// <summary>
					/// Returns 94
					/// </summary>
					public const System.Int32 ColumnIndex = 94;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_Surcharge_PayerA via shared members
				/// </summary>
				public sealed class Column_Fournisseur_Surcharge_PayerA {

					/// <summary>
					/// Returns "Fournisseur_Surcharge_PayerA"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_Surcharge_PayerA";
					/// <summary>
					/// Returns 95
					/// </summary>
					public const System.Int32 ColumnIndex = 95;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_Surcharge_PayerAID via shared members
				/// </summary>
				public sealed class Column_Fournisseur_Surcharge_PayerAID {

					/// <summary>
					/// Returns "Fournisseur_Surcharge_PayerAID"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_Surcharge_PayerAID";
					/// <summary>
					/// Returns 96
					/// </summary>
					public const System.Int32 ColumnIndex = 96;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_Surcharge_Statut via shared members
				/// </summary>
				public sealed class Column_Fournisseur_Surcharge_Statut {

					/// <summary>
					/// Returns "Fournisseur_Surcharge_Statut"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_Surcharge_Statut";
					/// <summary>
					/// Returns 97
					/// </summary>
					public const System.Int32 ColumnIndex = 97;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_Surcharge_Rep_Nom via shared members
				/// </summary>
				public sealed class Column_Fournisseur_Surcharge_Rep_Nom {

					/// <summary>
					/// Returns "Fournisseur_Surcharge_Rep_Nom"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_Surcharge_Rep_Nom";
					/// <summary>
					/// Returns 98
					/// </summary>
					public const System.Int32 ColumnIndex = 98;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_Surcharge_Rep_Telephone via shared members
				/// </summary>
				public sealed class Column_Fournisseur_Surcharge_Rep_Telephone {

					/// <summary>
					/// Returns "Fournisseur_Surcharge_Rep_Telephone"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_Surcharge_Rep_Telephone";
					/// <summary>
					/// Returns 99
					/// </summary>
					public const System.Int32 ColumnIndex = 99;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_Surcharge_Rep_Telephone_Poste via shared members
				/// </summary>
				public sealed class Column_Fournisseur_Surcharge_Rep_Telephone_Poste {

					/// <summary>
					/// Returns "Fournisseur_Surcharge_Rep_Telephone_Poste"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_Surcharge_Rep_Telephone_Poste";
					/// <summary>
					/// Returns 100
					/// </summary>
					public const System.Int32 ColumnIndex = 100;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_Surcharge_Rep_Email via shared members
				/// </summary>
				public sealed class Column_Fournisseur_Surcharge_Rep_Email {

					/// <summary>
					/// Returns "Fournisseur_Surcharge_Rep_Email"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_Surcharge_Rep_Email";
					/// <summary>
					/// Returns 101
					/// </summary>
					public const System.Int32 ColumnIndex = 101;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_Surcharge_EnAnglais via shared members
				/// </summary>
				public sealed class Column_Fournisseur_Surcharge_EnAnglais {

					/// <summary>
					/// Returns "Fournisseur_Surcharge_EnAnglais"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_Surcharge_EnAnglais";
					/// <summary>
					/// Returns 102
					/// </summary>
					public const System.Int32 ColumnIndex = 102;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_Surcharge_Actif via shared members
				/// </summary>
				public sealed class Column_Fournisseur_Surcharge_Actif {

					/// <summary>
					/// Returns "Fournisseur_Surcharge_Actif"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_Surcharge_Actif";
					/// <summary>
					/// Returns 103
					/// </summary>
					public const System.Int32 ColumnIndex = 103;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_Surcharge_MRCProducteurID via shared members
				/// </summary>
				public sealed class Column_Fournisseur_Surcharge_MRCProducteurID {

					/// <summary>
					/// Returns "Fournisseur_Surcharge_MRCProducteurID"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_Surcharge_MRCProducteurID";
					/// <summary>
					/// Returns 104
					/// </summary>
					public const System.Int32 ColumnIndex = 104;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_Surcharge_PaiementManuel via shared members
				/// </summary>
				public sealed class Column_Fournisseur_Surcharge_PaiementManuel {

					/// <summary>
					/// Returns "Fournisseur_Surcharge_PaiementManuel"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_Surcharge_PaiementManuel";
					/// <summary>
					/// Returns 105
					/// </summary>
					public const System.Int32 ColumnIndex = 105;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_Surcharge_Journal via shared members
				/// </summary>
				public sealed class Column_Fournisseur_Surcharge_Journal {

					/// <summary>
					/// Returns "Fournisseur_Surcharge_Journal"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_Surcharge_Journal";
					/// <summary>
					/// Returns 106
					/// </summary>
					public const System.Int32 ColumnIndex = 106;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_Surcharge_RecoitTPS via shared members
				/// </summary>
				public sealed class Column_Fournisseur_Surcharge_RecoitTPS {

					/// <summary>
					/// Returns "Fournisseur_Surcharge_RecoitTPS"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_Surcharge_RecoitTPS";
					/// <summary>
					/// Returns 107
					/// </summary>
					public const System.Int32 ColumnIndex = 107;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_Surcharge_RecoitTVQ via shared members
				/// </summary>
				public sealed class Column_Fournisseur_Surcharge_RecoitTVQ {

					/// <summary>
					/// Returns "Fournisseur_Surcharge_RecoitTVQ"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_Surcharge_RecoitTVQ";
					/// <summary>
					/// Returns 108
					/// </summary>
					public const System.Int32 ColumnIndex = 108;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_Surcharge_ModifierTrigger via shared members
				/// </summary>
				public sealed class Column_Fournisseur_Surcharge_ModifierTrigger {

					/// <summary>
					/// Returns "Fournisseur_Surcharge_ModifierTrigger"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_Surcharge_ModifierTrigger";
					/// <summary>
					/// Returns 109
					/// </summary>
					public const System.Int32 ColumnIndex = 109;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_Surcharge_IsProducteur via shared members
				/// </summary>
				public sealed class Column_Fournisseur_Surcharge_IsProducteur {

					/// <summary>
					/// Returns "Fournisseur_Surcharge_IsProducteur"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_Surcharge_IsProducteur";
					/// <summary>
					/// Returns 110
					/// </summary>
					public const System.Int32 ColumnIndex = 110;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_Surcharge_IsTransporteur via shared members
				/// </summary>
				public sealed class Column_Fournisseur_Surcharge_IsTransporteur {

					/// <summary>
					/// Returns "Fournisseur_Surcharge_IsTransporteur"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_Surcharge_IsTransporteur";
					/// <summary>
					/// Returns 111
					/// </summary>
					public const System.Int32 ColumnIndex = 111;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_Surcharge_IsChargeur via shared members
				/// </summary>
				public sealed class Column_Fournisseur_Surcharge_IsChargeur {

					/// <summary>
					/// Returns "Fournisseur_Surcharge_IsChargeur"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_Surcharge_IsChargeur";
					/// <summary>
					/// Returns 112
					/// </summary>
					public const System.Int32 ColumnIndex = 112;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_Surcharge_IsAutre via shared members
				/// </summary>
				public sealed class Column_Fournisseur_Surcharge_IsAutre {

					/// <summary>
					/// Returns "Fournisseur_Surcharge_IsAutre"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_Surcharge_IsAutre";
					/// <summary>
					/// Returns 113
					/// </summary>
					public const System.Int32 ColumnIndex = 113;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_Surcharge_AfficherCommentairesSurPermit via shared members
				/// </summary>
				public sealed class Column_Fournisseur_Surcharge_AfficherCommentairesSurPermit {

					/// <summary>
					/// Returns "Fournisseur_Surcharge_AfficherCommentairesSurPermit"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_Surcharge_AfficherCommentairesSurPermit";
					/// <summary>
					/// Returns 114
					/// </summary>
					public const System.Int32 ColumnIndex = 114;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_Surcharge_PasEmissionPermis via shared members
				/// </summary>
				public sealed class Column_Fournisseur_Surcharge_PasEmissionPermis {

					/// <summary>
					/// Returns "Fournisseur_Surcharge_PasEmissionPermis"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_Surcharge_PasEmissionPermis";
					/// <summary>
					/// Returns 115
					/// </summary>
					public const System.Int32 ColumnIndex = 115;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Fournisseur_Surcharge_Generique via shared members
				/// </summary>
				public sealed class Column_Fournisseur_Surcharge_Generique {

					/// <summary>
					/// Returns "Fournisseur_Surcharge_Generique"
					/// </summary>
					public const System.String ColumnName = "Fournisseur_Surcharge_Generique";
					/// <summary>
					/// Returns 116
					/// </summary>
					public const System.Int32 ColumnIndex = 116;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Compte_Paiements_ID via shared members
				/// </summary>
				public sealed class Column_Compte_Paiements_ID {

					/// <summary>
					/// Returns "Compte_Paiements_ID"
					/// </summary>
					public const System.String ColumnName = "Compte_Paiements_ID";
					/// <summary>
					/// Returns 117
					/// </summary>
					public const System.Int32 ColumnIndex = 117;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Compte_Paiements_Description via shared members
				/// </summary>
				public sealed class Column_Compte_Paiements_Description {

					/// <summary>
					/// Returns "Compte_Paiements_Description"
					/// </summary>
					public const System.String ColumnName = "Compte_Paiements_Description";
					/// <summary>
					/// Returns 118
					/// </summary>
					public const System.Int32 ColumnIndex = 118;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Compte_Paiements_CategoryID via shared members
				/// </summary>
				public sealed class Column_Compte_Paiements_CategoryID {

					/// <summary>
					/// Returns "Compte_Paiements_CategoryID"
					/// </summary>
					public const System.String ColumnName = "Compte_Paiements_CategoryID";
					/// <summary>
					/// Returns 119
					/// </summary>
					public const System.Int32 ColumnIndex = 119;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Compte_Paiements_isTaxe via shared members
				/// </summary>
				public sealed class Column_Compte_Paiements_isTaxe {

					/// <summary>
					/// Returns "Compte_Paiements_isTaxe"
					/// </summary>
					public const System.String ColumnName = "Compte_Paiements_isTaxe";
					/// <summary>
					/// Returns 120
					/// </summary>
					public const System.Int32 ColumnIndex = 120;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Compte_Paiements_Actif via shared members
				/// </summary>
				public sealed class Column_Compte_Paiements_Actif {

					/// <summary>
					/// Returns "Compte_Paiements_Actif"
					/// </summary>
					public const System.String ColumnName = "Compte_Paiements_Actif";
					/// <summary>
					/// Returns 121
					/// </summary>
					public const System.Int32 ColumnIndex = 121;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Compte_ARecevoir_ID via shared members
				/// </summary>
				public sealed class Column_Compte_ARecevoir_ID {

					/// <summary>
					/// Returns "Compte_ARecevoir_ID"
					/// </summary>
					public const System.String ColumnName = "Compte_ARecevoir_ID";
					/// <summary>
					/// Returns 122
					/// </summary>
					public const System.Int32 ColumnIndex = 122;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Compte_ARecevoir_Description via shared members
				/// </summary>
				public sealed class Column_Compte_ARecevoir_Description {

					/// <summary>
					/// Returns "Compte_ARecevoir_Description"
					/// </summary>
					public const System.String ColumnName = "Compte_ARecevoir_Description";
					/// <summary>
					/// Returns 123
					/// </summary>
					public const System.Int32 ColumnIndex = 123;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Compte_ARecevoir_CategoryID via shared members
				/// </summary>
				public sealed class Column_Compte_ARecevoir_CategoryID {

					/// <summary>
					/// Returns "Compte_ARecevoir_CategoryID"
					/// </summary>
					public const System.String ColumnName = "Compte_ARecevoir_CategoryID";
					/// <summary>
					/// Returns 124
					/// </summary>
					public const System.Int32 ColumnIndex = 124;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Compte_ARecevoir_isTaxe via shared members
				/// </summary>
				public sealed class Column_Compte_ARecevoir_isTaxe {

					/// <summary>
					/// Returns "Compte_ARecevoir_isTaxe"
					/// </summary>
					public const System.String ColumnName = "Compte_ARecevoir_isTaxe";
					/// <summary>
					/// Returns 125
					/// </summary>
					public const System.Int32 ColumnIndex = 125;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Compte_ARecevoir_Actif via shared members
				/// </summary>
				public sealed class Column_Compte_ARecevoir_Actif {

					/// <summary>
					/// Returns "Compte_ARecevoir_Actif"
					/// </summary>
					public const System.String ColumnName = "Compte_ARecevoir_Actif";
					/// <summary>
					/// Returns 126
					/// </summary>
					public const System.Int32 ColumnIndex = 126;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Compte_APayer_ID via shared members
				/// </summary>
				public sealed class Column_Compte_APayer_ID {

					/// <summary>
					/// Returns "Compte_APayer_ID"
					/// </summary>
					public const System.String ColumnName = "Compte_APayer_ID";
					/// <summary>
					/// Returns 127
					/// </summary>
					public const System.Int32 ColumnIndex = 127;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Compte_APayer_Description via shared members
				/// </summary>
				public sealed class Column_Compte_APayer_Description {

					/// <summary>
					/// Returns "Compte_APayer_Description"
					/// </summary>
					public const System.String ColumnName = "Compte_APayer_Description";
					/// <summary>
					/// Returns 128
					/// </summary>
					public const System.Int32 ColumnIndex = 128;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Compte_APayer_CategoryID via shared members
				/// </summary>
				public sealed class Column_Compte_APayer_CategoryID {

					/// <summary>
					/// Returns "Compte_APayer_CategoryID"
					/// </summary>
					public const System.String ColumnName = "Compte_APayer_CategoryID";
					/// <summary>
					/// Returns 129
					/// </summary>
					public const System.Int32 ColumnIndex = 129;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Compte_APayer_isTaxe via shared members
				/// </summary>
				public sealed class Column_Compte_APayer_isTaxe {

					/// <summary>
					/// Returns "Compte_APayer_isTaxe"
					/// </summary>
					public const System.String ColumnName = "Compte_APayer_isTaxe";
					/// <summary>
					/// Returns 130
					/// </summary>
					public const System.Int32 ColumnIndex = 130;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Compte_APayer_Actif via shared members
				/// </summary>
				public sealed class Column_Compte_APayer_Actif {

					/// <summary>
					/// Returns "Compte_APayer_Actif"
					/// </summary>
					public const System.String ColumnName = "Compte_APayer_Actif";
					/// <summary>
					/// Returns 131
					/// </summary>
					public const System.Int32 ColumnIndex = 131;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Compte_DuAuxProducteurs_ID via shared members
				/// </summary>
				public sealed class Column_Compte_DuAuxProducteurs_ID {

					/// <summary>
					/// Returns "Compte_DuAuxProducteurs_ID"
					/// </summary>
					public const System.String ColumnName = "Compte_DuAuxProducteurs_ID";
					/// <summary>
					/// Returns 132
					/// </summary>
					public const System.Int32 ColumnIndex = 132;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Compte_DuAuxProducteurs_Description via shared members
				/// </summary>
				public sealed class Column_Compte_DuAuxProducteurs_Description {

					/// <summary>
					/// Returns "Compte_DuAuxProducteurs_Description"
					/// </summary>
					public const System.String ColumnName = "Compte_DuAuxProducteurs_Description";
					/// <summary>
					/// Returns 133
					/// </summary>
					public const System.Int32 ColumnIndex = 133;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Compte_DuAuxProducteurs_CategoryID via shared members
				/// </summary>
				public sealed class Column_Compte_DuAuxProducteurs_CategoryID {

					/// <summary>
					/// Returns "Compte_DuAuxProducteurs_CategoryID"
					/// </summary>
					public const System.String ColumnName = "Compte_DuAuxProducteurs_CategoryID";
					/// <summary>
					/// Returns 134
					/// </summary>
					public const System.Int32 ColumnIndex = 134;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Compte_DuAuxProducteurs_isTaxe via shared members
				/// </summary>
				public sealed class Column_Compte_DuAuxProducteurs_isTaxe {

					/// <summary>
					/// Returns "Compte_DuAuxProducteurs_isTaxe"
					/// </summary>
					public const System.String ColumnName = "Compte_DuAuxProducteurs_isTaxe";
					/// <summary>
					/// Returns 135
					/// </summary>
					public const System.Int32 ColumnIndex = 135;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Compte_DuAuxProducteurs_Actif via shared members
				/// </summary>
				public sealed class Column_Compte_DuAuxProducteurs_Actif {

					/// <summary>
					/// Returns "Compte_DuAuxProducteurs_Actif"
					/// </summary>
					public const System.String ColumnName = "Compte_DuAuxProducteurs_Actif";
					/// <summary>
					/// Returns 136
					/// </summary>
					public const System.Int32 ColumnIndex = 136;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Compte_TPSpercues_ID via shared members
				/// </summary>
				public sealed class Column_Compte_TPSpercues_ID {

					/// <summary>
					/// Returns "Compte_TPSpercues_ID"
					/// </summary>
					public const System.String ColumnName = "Compte_TPSpercues_ID";
					/// <summary>
					/// Returns 137
					/// </summary>
					public const System.Int32 ColumnIndex = 137;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Compte_TPSpercues_Description via shared members
				/// </summary>
				public sealed class Column_Compte_TPSpercues_Description {

					/// <summary>
					/// Returns "Compte_TPSpercues_Description"
					/// </summary>
					public const System.String ColumnName = "Compte_TPSpercues_Description";
					/// <summary>
					/// Returns 138
					/// </summary>
					public const System.Int32 ColumnIndex = 138;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Compte_TPSpercues_CategoryID via shared members
				/// </summary>
				public sealed class Column_Compte_TPSpercues_CategoryID {

					/// <summary>
					/// Returns "Compte_TPSpercues_CategoryID"
					/// </summary>
					public const System.String ColumnName = "Compte_TPSpercues_CategoryID";
					/// <summary>
					/// Returns 139
					/// </summary>
					public const System.Int32 ColumnIndex = 139;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Compte_TPSpercues_isTaxe via shared members
				/// </summary>
				public sealed class Column_Compte_TPSpercues_isTaxe {

					/// <summary>
					/// Returns "Compte_TPSpercues_isTaxe"
					/// </summary>
					public const System.String ColumnName = "Compte_TPSpercues_isTaxe";
					/// <summary>
					/// Returns 140
					/// </summary>
					public const System.Int32 ColumnIndex = 140;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Compte_TPSpercues_Actif via shared members
				/// </summary>
				public sealed class Column_Compte_TPSpercues_Actif {

					/// <summary>
					/// Returns "Compte_TPSpercues_Actif"
					/// </summary>
					public const System.String ColumnName = "Compte_TPSpercues_Actif";
					/// <summary>
					/// Returns 141
					/// </summary>
					public const System.Int32 ColumnIndex = 141;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Compte_TPSpayees_ID via shared members
				/// </summary>
				public sealed class Column_Compte_TPSpayees_ID {

					/// <summary>
					/// Returns "Compte_TPSpayees_ID"
					/// </summary>
					public const System.String ColumnName = "Compte_TPSpayees_ID";
					/// <summary>
					/// Returns 142
					/// </summary>
					public const System.Int32 ColumnIndex = 142;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Compte_TPSpayees_Description via shared members
				/// </summary>
				public sealed class Column_Compte_TPSpayees_Description {

					/// <summary>
					/// Returns "Compte_TPSpayees_Description"
					/// </summary>
					public const System.String ColumnName = "Compte_TPSpayees_Description";
					/// <summary>
					/// Returns 143
					/// </summary>
					public const System.Int32 ColumnIndex = 143;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Compte_TPSpayees_CategoryID via shared members
				/// </summary>
				public sealed class Column_Compte_TPSpayees_CategoryID {

					/// <summary>
					/// Returns "Compte_TPSpayees_CategoryID"
					/// </summary>
					public const System.String ColumnName = "Compte_TPSpayees_CategoryID";
					/// <summary>
					/// Returns 144
					/// </summary>
					public const System.Int32 ColumnIndex = 144;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Compte_TPSpayees_isTaxe via shared members
				/// </summary>
				public sealed class Column_Compte_TPSpayees_isTaxe {

					/// <summary>
					/// Returns "Compte_TPSpayees_isTaxe"
					/// </summary>
					public const System.String ColumnName = "Compte_TPSpayees_isTaxe";
					/// <summary>
					/// Returns 145
					/// </summary>
					public const System.Int32 ColumnIndex = 145;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Compte_TPSpayees_Actif via shared members
				/// </summary>
				public sealed class Column_Compte_TPSpayees_Actif {

					/// <summary>
					/// Returns "Compte_TPSpayees_Actif"
					/// </summary>
					public const System.String ColumnName = "Compte_TPSpayees_Actif";
					/// <summary>
					/// Returns 146
					/// </summary>
					public const System.Int32 ColumnIndex = 146;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Compte_TVQpercues_ID via shared members
				/// </summary>
				public sealed class Column_Compte_TVQpercues_ID {

					/// <summary>
					/// Returns "Compte_TVQpercues_ID"
					/// </summary>
					public const System.String ColumnName = "Compte_TVQpercues_ID";
					/// <summary>
					/// Returns 147
					/// </summary>
					public const System.Int32 ColumnIndex = 147;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Compte_TVQpercues_Description via shared members
				/// </summary>
				public sealed class Column_Compte_TVQpercues_Description {

					/// <summary>
					/// Returns "Compte_TVQpercues_Description"
					/// </summary>
					public const System.String ColumnName = "Compte_TVQpercues_Description";
					/// <summary>
					/// Returns 148
					/// </summary>
					public const System.Int32 ColumnIndex = 148;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Compte_TVQpercues_CategoryID via shared members
				/// </summary>
				public sealed class Column_Compte_TVQpercues_CategoryID {

					/// <summary>
					/// Returns "Compte_TVQpercues_CategoryID"
					/// </summary>
					public const System.String ColumnName = "Compte_TVQpercues_CategoryID";
					/// <summary>
					/// Returns 149
					/// </summary>
					public const System.Int32 ColumnIndex = 149;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Compte_TVQpercues_isTaxe via shared members
				/// </summary>
				public sealed class Column_Compte_TVQpercues_isTaxe {

					/// <summary>
					/// Returns "Compte_TVQpercues_isTaxe"
					/// </summary>
					public const System.String ColumnName = "Compte_TVQpercues_isTaxe";
					/// <summary>
					/// Returns 150
					/// </summary>
					public const System.Int32 ColumnIndex = 150;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Compte_TVQpercues_Actif via shared members
				/// </summary>
				public sealed class Column_Compte_TVQpercues_Actif {

					/// <summary>
					/// Returns "Compte_TVQpercues_Actif"
					/// </summary>
					public const System.String ColumnName = "Compte_TVQpercues_Actif";
					/// <summary>
					/// Returns 151
					/// </summary>
					public const System.Int32 ColumnIndex = 151;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Compte_TVQpayees_ID via shared members
				/// </summary>
				public sealed class Column_Compte_TVQpayees_ID {

					/// <summary>
					/// Returns "Compte_TVQpayees_ID"
					/// </summary>
					public const System.String ColumnName = "Compte_TVQpayees_ID";
					/// <summary>
					/// Returns 152
					/// </summary>
					public const System.Int32 ColumnIndex = 152;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Compte_TVQpayees_Description via shared members
				/// </summary>
				public sealed class Column_Compte_TVQpayees_Description {

					/// <summary>
					/// Returns "Compte_TVQpayees_Description"
					/// </summary>
					public const System.String ColumnName = "Compte_TVQpayees_Description";
					/// <summary>
					/// Returns 153
					/// </summary>
					public const System.Int32 ColumnIndex = 153;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Compte_TVQpayees_CategoryID via shared members
				/// </summary>
				public sealed class Column_Compte_TVQpayees_CategoryID {

					/// <summary>
					/// Returns "Compte_TVQpayees_CategoryID"
					/// </summary>
					public const System.String ColumnName = "Compte_TVQpayees_CategoryID";
					/// <summary>
					/// Returns 154
					/// </summary>
					public const System.Int32 ColumnIndex = 154;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Compte_TVQpayees_isTaxe via shared members
				/// </summary>
				public sealed class Column_Compte_TVQpayees_isTaxe {

					/// <summary>
					/// Returns "Compte_TVQpayees_isTaxe"
					/// </summary>
					public const System.String ColumnName = "Compte_TVQpayees_isTaxe";
					/// <summary>
					/// Returns 155
					/// </summary>
					public const System.Int32 ColumnIndex = 155;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Compte_TVQpayees_Actif via shared members
				/// </summary>
				public sealed class Column_Compte_TVQpayees_Actif {

					/// <summary>
					/// Returns "Compte_TVQpayees_Actif"
					/// </summary>
					public const System.String ColumnName = "Compte_TVQpayees_Actif";
					/// <summary>
					/// Returns 156
					/// </summary>
					public const System.Int32 ColumnIndex = 156;

				}

			}
		}

		/// <summary>
		/// This class allows to easily retrieve the name or index of all the fields
		/// of the resulset #2 existing in the Dataset or the SqlDatReader returned by
		/// the Execute method of the 'spS_jag_System_Full' class.
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

