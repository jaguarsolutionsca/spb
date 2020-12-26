using System;

namespace Gestion_Paie.DataClasses.Parameters {

	/// <summary>
	/// This class allows a developer to specify the parameters expected by the
	/// stored procedure 'spU_FactureUsine'. It allows also to specify specific connection
	/// information such as the ConnectionString to be use, the command time-out and so forth.
	/// </summary>
	[Serializable()]
	public sealed class spU_FactureUsine : MarshalByRefObject, IDisposable, IParameter {

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

		internal void internal_SetErrorSource(ErrorSource errorSource) {

			this.errorSource = errorSource;
		}

		private bool useDefaultValue = true;

		/// <summary>
		/// Initializes a new instance of the spU_FactureUsine class. If you use this constructor version,
		/// not assigning parameter values implies using the parameter default values.
		/// </summary>
		public spU_FactureUsine() : this(true) {

		}

		/// <summary>
		/// Initializes a new instance of the spU_FactureUsine class.
		/// </summary>
		/// <param name="useDefaultValue">If True, this parameter indicates that "not assigning parameter values" implies "using the parameter default values". If False, this parameter indicates that "not assigning parameter values" implies "using the SQL Server Null value".</param>
		public spU_FactureUsine(bool useDefaultValue) {

			this.useDefaultValue = useDefaultValue;

			this.internal_Param_ID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_DatePermis_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_DatePermis_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_DateLivraison_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_DateLivraison_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_DatePaye_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_DatePaye_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Annee_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_Annee_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Periode_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_Periode_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ContratID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_ContratID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Sciage_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_Sciage_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_EssenceSciage_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_EssenceSciage_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_NumeroFactureUsine_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_NumeroFactureUsine_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ProducteurID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_ProducteurID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Livraison_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_Livraison_UseDefaultValue = this.useDefaultValue;
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
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'spU_FactureUsine'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

						throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "spU_FactureUsine", CurrentRevision, OriginalRevision, System.Environment.NewLine));
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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'spU_FactureUsine'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlConnection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "spU_FactureUsine", CurrentRevision, OriginalRevision, System.Environment.NewLine));
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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'spU_FactureUsine'";
				sqlCommand.Transaction = sqlTransaction;

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlTransaction.Connection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "spU_FactureUsine", CurrentRevision, OriginalRevision, System.Environment.NewLine));
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
				this.internal_Param_DatePermis = System.Data.SqlTypes.SqlDateTime.Null;
				this.internal_Param_ConsiderNull_DatePermis = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_DateLivraison = System.Data.SqlTypes.SqlDateTime.Null;
				this.internal_Param_ConsiderNull_DateLivraison = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_DatePaye = System.Data.SqlTypes.SqlDateTime.Null;
				this.internal_Param_ConsiderNull_DatePaye = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Annee = System.Data.SqlTypes.SqlInt32.Null;
				this.internal_Param_ConsiderNull_Annee = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Periode = System.Data.SqlTypes.SqlInt32.Null;
				this.internal_Param_ConsiderNull_Periode = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_ContratID = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_ConsiderNull_ContratID = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Sciage = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_ConsiderNull_Sciage = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_EssenceSciage = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_ConsiderNull_EssenceSciage = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_NumeroFactureUsine = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_ConsiderNull_NumeroFactureUsine = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_ProducteurID = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_ConsiderNull_ProducteurID = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Livraison = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_ConsiderNull_Livraison = System.Data.SqlTypes.SqlBoolean.Null;

				this.sqlException = null;
				this.otherException = null;
				this.connectionString = null;
				this.sqlConnection = null;
				this.sqlTransaction = null;

			}
		}

		/// <summary>
		/// This member overrides 'Object.Finalize'.
		/// </summary>
		~spU_FactureUsine() {

			Dispose(false);
		}

		/// <summary>
		/// Returns the stored procedure name for which this class was built, i.e. 'spU_FactureUsine'.
		/// </summary>
		public string StoredProcedureName {

			get {

				return("spU_FactureUsine");
			}
		}

		private System.Data.SqlTypes.SqlInt32 internal_Param_RETURN_VALUE;

		private System.Data.SqlTypes.SqlInt32 internal_Param_ID;
		internal bool internal_Param_ID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlDateTime internal_Param_DatePermis;
		internal bool internal_Param_DatePermis_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_DatePermis;
		internal bool internal_Param_ConsiderNull_DatePermis_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlDateTime internal_Param_DateLivraison;
		internal bool internal_Param_DateLivraison_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_DateLivraison;
		internal bool internal_Param_ConsiderNull_DateLivraison_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlDateTime internal_Param_DatePaye;
		internal bool internal_Param_DatePaye_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_DatePaye;
		internal bool internal_Param_ConsiderNull_DatePaye_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlInt32 internal_Param_Annee;
		internal bool internal_Param_Annee_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_Annee;
		internal bool internal_Param_ConsiderNull_Annee_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlInt32 internal_Param_Periode;
		internal bool internal_Param_Periode_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_Periode;
		internal bool internal_Param_ConsiderNull_Periode_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_ContratID;
		internal bool internal_Param_ContratID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_ContratID;
		internal bool internal_Param_ConsiderNull_ContratID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_Sciage;
		internal bool internal_Param_Sciage_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_Sciage;
		internal bool internal_Param_ConsiderNull_Sciage_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_EssenceSciage;
		internal bool internal_Param_EssenceSciage_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_EssenceSciage;
		internal bool internal_Param_ConsiderNull_EssenceSciage_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_NumeroFactureUsine;
		internal bool internal_Param_NumeroFactureUsine_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_NumeroFactureUsine;
		internal bool internal_Param_ConsiderNull_NumeroFactureUsine_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_ProducteurID;
		internal bool internal_Param_ProducteurID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_ProducteurID;
		internal bool internal_Param_ConsiderNull_ProducteurID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_Livraison;
		internal bool internal_Param_Livraison_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_Livraison;
		internal bool internal_Param_ConsiderNull_Livraison_UseDefaultValue = true;


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


			this.internal_Param_RETURN_VALUE = System.Data.SqlTypes.SqlInt32.Null;

			this.internal_Param_ID = System.Data.SqlTypes.SqlInt32.Null;
			this.internal_Param_ID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_DatePermis = System.Data.SqlTypes.SqlDateTime.Null;
			this.internal_Param_DatePermis_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_DatePermis = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_DatePermis_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_DateLivraison = System.Data.SqlTypes.SqlDateTime.Null;
			this.internal_Param_DateLivraison_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_DateLivraison = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_DateLivraison_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_DatePaye = System.Data.SqlTypes.SqlDateTime.Null;
			this.internal_Param_DatePaye_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_DatePaye = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_DatePaye_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Annee = System.Data.SqlTypes.SqlInt32.Null;
			this.internal_Param_Annee_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_Annee = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_Annee_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Periode = System.Data.SqlTypes.SqlInt32.Null;
			this.internal_Param_Periode_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_Periode = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_Periode_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ContratID = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_ContratID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_ContratID = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_ContratID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Sciage = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_Sciage_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_Sciage = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_Sciage_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_EssenceSciage = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_EssenceSciage_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_EssenceSciage = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_EssenceSciage_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_NumeroFactureUsine = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_NumeroFactureUsine_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_NumeroFactureUsine = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_NumeroFactureUsine_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ProducteurID = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_ProducteurID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_ProducteurID = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_ProducteurID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Livraison = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_Livraison_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_Livraison = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_Livraison_UseDefaultValue = this.useDefaultValue;

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


		/// <summary>
		/// Returns the value returned back by the stored procedure execution.
		/// </summary>
		public System.Data.SqlTypes.SqlInt32 Param_RETURN_VALUE {

			get {

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
		/// Sets the value of the stored procedure INPUT parameter '@DatePermis'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [smalldatetime]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_DatePermis_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlDateTime Param_DatePermis {

			get {

				if (this.internal_Param_DatePermis_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_DatePermis);
			}

			set {

				this.internal_Param_DatePermis_UseDefaultValue = false;
				this.internal_Param_DatePermis = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@DatePermis' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_DatePermis_UseDefaultValue() {

			this.internal_Param_DatePermis_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_DatePermis'.
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
		/// the parameter default value, consider calling the Param_ConsiderNull_DatePermis_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_DatePermis {

			get {

				if (this.internal_Param_ConsiderNull_DatePermis_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_DatePermis);
			}

			set {

				this.internal_Param_ConsiderNull_DatePermis_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_DatePermis = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_DatePermis' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_DatePermis_UseDefaultValue() {

			this.internal_Param_ConsiderNull_DatePermis_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@DateLivraison'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [smalldatetime]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_DateLivraison_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlDateTime Param_DateLivraison {

			get {

				if (this.internal_Param_DateLivraison_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_DateLivraison);
			}

			set {

				this.internal_Param_DateLivraison_UseDefaultValue = false;
				this.internal_Param_DateLivraison = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@DateLivraison' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_DateLivraison_UseDefaultValue() {

			this.internal_Param_DateLivraison_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_DateLivraison'.
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
		/// the parameter default value, consider calling the Param_ConsiderNull_DateLivraison_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_DateLivraison {

			get {

				if (this.internal_Param_ConsiderNull_DateLivraison_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_DateLivraison);
			}

			set {

				this.internal_Param_ConsiderNull_DateLivraison_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_DateLivraison = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_DateLivraison' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_DateLivraison_UseDefaultValue() {

			this.internal_Param_ConsiderNull_DateLivraison_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@DatePaye'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [smalldatetime]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_DatePaye_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlDateTime Param_DatePaye {

			get {

				if (this.internal_Param_DatePaye_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_DatePaye);
			}

			set {

				this.internal_Param_DatePaye_UseDefaultValue = false;
				this.internal_Param_DatePaye = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@DatePaye' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_DatePaye_UseDefaultValue() {

			this.internal_Param_DatePaye_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_DatePaye'.
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
		/// the parameter default value, consider calling the Param_ConsiderNull_DatePaye_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_DatePaye {

			get {

				if (this.internal_Param_ConsiderNull_DatePaye_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_DatePaye);
			}

			set {

				this.internal_Param_ConsiderNull_DatePaye_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_DatePaye = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_DatePaye' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_DatePaye_UseDefaultValue() {

			this.internal_Param_ConsiderNull_DatePaye_UseDefaultValue = true;
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
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_Annee'.
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
		/// the parameter default value, consider calling the Param_ConsiderNull_Annee_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_Annee {

			get {

				if (this.internal_Param_ConsiderNull_Annee_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_Annee);
			}

			set {

				this.internal_Param_ConsiderNull_Annee_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_Annee = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_Annee' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_Annee_UseDefaultValue() {

			this.internal_Param_ConsiderNull_Annee_UseDefaultValue = true;
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
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_Periode'.
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
		/// the parameter default value, consider calling the Param_ConsiderNull_Periode_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_Periode {

			get {

				if (this.internal_Param_ConsiderNull_Periode_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_Periode);
			}

			set {

				this.internal_Param_ConsiderNull_Periode_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_Periode = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_Periode' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_Periode_UseDefaultValue() {

			this.internal_Param_ConsiderNull_Periode_UseDefaultValue = true;
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
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_ContratID'.
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
		/// the parameter default value, consider calling the Param_ConsiderNull_ContratID_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_ContratID {

			get {

				if (this.internal_Param_ConsiderNull_ContratID_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_ContratID);
			}

			set {

				this.internal_Param_ConsiderNull_ContratID_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_ContratID = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_ContratID' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_ContratID_UseDefaultValue() {

			this.internal_Param_ConsiderNull_ContratID_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Sciage'.
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
		/// the parameter default value, consider calling the Param_Sciage_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_Sciage {

			get {

				if (this.internal_Param_Sciage_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Sciage);
			}

			set {

				this.internal_Param_Sciage_UseDefaultValue = false;
				this.internal_Param_Sciage = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Sciage' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Sciage_UseDefaultValue() {

			this.internal_Param_Sciage_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_Sciage'.
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
		/// the parameter default value, consider calling the Param_ConsiderNull_Sciage_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_Sciage {

			get {

				if (this.internal_Param_ConsiderNull_Sciage_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_Sciage);
			}

			set {

				this.internal_Param_ConsiderNull_Sciage_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_Sciage = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_Sciage' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_Sciage_UseDefaultValue() {

			this.internal_Param_ConsiderNull_Sciage_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@EssenceSciage'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [varchar](25)
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_EssenceSciage_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_EssenceSciage {

			get {

				if (this.internal_Param_EssenceSciage_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_EssenceSciage);
			}

			set {

				this.internal_Param_EssenceSciage_UseDefaultValue = false;
				this.internal_Param_EssenceSciage = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@EssenceSciage' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_EssenceSciage_UseDefaultValue() {

			this.internal_Param_EssenceSciage_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_EssenceSciage'.
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
		/// the parameter default value, consider calling the Param_ConsiderNull_EssenceSciage_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_EssenceSciage {

			get {

				if (this.internal_Param_ConsiderNull_EssenceSciage_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_EssenceSciage);
			}

			set {

				this.internal_Param_ConsiderNull_EssenceSciage_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_EssenceSciage = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_EssenceSciage' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_EssenceSciage_UseDefaultValue() {

			this.internal_Param_ConsiderNull_EssenceSciage_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@NumeroFactureUsine'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [varchar](25)
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_NumeroFactureUsine_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_NumeroFactureUsine {

			get {

				if (this.internal_Param_NumeroFactureUsine_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_NumeroFactureUsine);
			}

			set {

				this.internal_Param_NumeroFactureUsine_UseDefaultValue = false;
				this.internal_Param_NumeroFactureUsine = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@NumeroFactureUsine' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_NumeroFactureUsine_UseDefaultValue() {

			this.internal_Param_NumeroFactureUsine_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_NumeroFactureUsine'.
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
		/// the parameter default value, consider calling the Param_ConsiderNull_NumeroFactureUsine_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_NumeroFactureUsine {

			get {

				if (this.internal_Param_ConsiderNull_NumeroFactureUsine_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_NumeroFactureUsine);
			}

			set {

				this.internal_Param_ConsiderNull_NumeroFactureUsine_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_NumeroFactureUsine = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_NumeroFactureUsine' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_NumeroFactureUsine_UseDefaultValue() {

			this.internal_Param_ConsiderNull_NumeroFactureUsine_UseDefaultValue = true;
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
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_ProducteurID'.
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
		/// the parameter default value, consider calling the Param_ConsiderNull_ProducteurID_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_ProducteurID {

			get {

				if (this.internal_Param_ConsiderNull_ProducteurID_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_ProducteurID);
			}

			set {

				this.internal_Param_ConsiderNull_ProducteurID_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_ProducteurID = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_ProducteurID' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_ProducteurID_UseDefaultValue() {

			this.internal_Param_ConsiderNull_ProducteurID_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Livraison'.
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
		/// the parameter default value, consider calling the Param_Livraison_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_Livraison {

			get {

				if (this.internal_Param_Livraison_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Livraison);
			}

			set {

				this.internal_Param_Livraison_UseDefaultValue = false;
				this.internal_Param_Livraison = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Livraison' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Livraison_UseDefaultValue() {

			this.internal_Param_Livraison_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_Livraison'.
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
		/// the parameter default value, consider calling the Param_ConsiderNull_Livraison_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_Livraison {

			get {

				if (this.internal_Param_ConsiderNull_Livraison_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_Livraison);
			}

			set {

				this.internal_Param_ConsiderNull_Livraison_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_Livraison = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_Livraison' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_Livraison_UseDefaultValue() {

			this.internal_Param_ConsiderNull_Livraison_UseDefaultValue = true;
		}

  	}
}

namespace Gestion_Paie.DataClasses.StoredProcedures {

	/// <summary>
	/// This class allows you to execute the 'spU_FactureUsine' stored procedure;
	/// it gives you the ability to:
	/// <list type="bullet">
	/// <item><description>Set all the necessary parameters to execute the stored procedure</description></item>
	/// <item><description>To execute the stored procedure</description></item>
	/// <item><description>To get back after the execution the return value and all the output parameters value</description></item>
	/// </list>
	/// </summary>
	public sealed class spU_FactureUsine : MarshalByRefObject, IDisposable {


		private bool throwExceptionOnExecute = false;

		/// <summary>
		/// Initializes a new instance of the spU_FactureUsine class.
		/// By default, no exception will be thrown when you call the Execute method. Instead, a Boolean return status will be returned.
		/// </summary>
		public spU_FactureUsine() : this(false) {

		}

		/// <summary>
		/// Initializes a new instance of the spU_FactureUsine class.
		/// </summary>
		/// <param name="throwExceptionOnExecute">True if an exception has to be thrown if the Execute call fails.</param>
		public spU_FactureUsine(bool throwExceptionOnExecute) {

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
		~spU_FactureUsine() {

			Dispose(false);
		}

		private void ResetParameter(ref Gestion_Paie.DataClasses.Parameters.spU_FactureUsine parameters) {

			parameters.internal_Set_RETURN_VALUE (System.Data.SqlTypes.SqlInt32.Null);
		}

		private bool InitializeConnection(ref Gestion_Paie.DataClasses.Parameters.spU_FactureUsine parameters, out System.Data.SqlClient.SqlCommand sqlCommand, ref bool connectionMustBeClosed) {

			try {

				this.sqlConnection = null;
				sqlCommand = null;
				connectionMustBeClosed = true;

				if (parameters.ConnectionType == ConnectionType.None) {

					throw new InvalidOperationException("No connection information was supplied. Consider calling the 'SetUpConnection' method of the Gestion_Paie.DataClasses.Parameters.spU_FactureUsine object before doing this call.");
				}

				if (parameters.ConnectionType == ConnectionType.SqlConnection && parameters.SqlConnection == null) {

					throw new InvalidOperationException("No connection information was supplied (SqlConnection == null). Consider calling the 'SetUpConnection' method of the Gestion_Paie.DataClasses.Parameters.spU_FactureUsine object before doing this call.");
				}

				if (parameters.ConnectionType == ConnectionType.SqlTransaction && parameters.SqlTransaction== null) {

					throw new InvalidOperationException("No connection information was supplied (SqlTransaction == null). Consider calling the 'SetUpConnection' method of the Gestion_Paie.DataClasses.Parameters.spU_FactureUsine object before doing this call.");
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

							throw new System.InvalidOperationException("No connection information was supplied (ConnectionString == \"\")! (Gestion_Paie.DataClasses.Parameters.spU_FactureUsine)");
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
				sqlCommand.CommandText = "spU_FactureUsine";

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

		private bool DeclareParameters(ref Gestion_Paie.DataClasses.Parameters.spU_FactureUsine parameters, ref System.Data.SqlClient.SqlCommand sqlCommand) {

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

				sqlParameter = new System.Data.SqlClient.SqlParameter("@DatePermis", System.Data.SqlDbType.SmallDateTime, 16);
				sqlParameter.SourceColumn = "DatePermis";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_DatePermis_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_DatePermis.IsNull) {

					sqlParameter.Value = parameters.Param_DatePermis;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_DatePermis", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_DatePermis_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_DatePermis.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_DatePermis;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@DateLivraison", System.Data.SqlDbType.SmallDateTime, 16);
				sqlParameter.SourceColumn = "DateLivraison";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_DateLivraison_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_DateLivraison.IsNull) {

					sqlParameter.Value = parameters.Param_DateLivraison;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_DateLivraison", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_DateLivraison_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_DateLivraison.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_DateLivraison;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@DatePaye", System.Data.SqlDbType.SmallDateTime, 16);
				sqlParameter.SourceColumn = "DatePaye";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_DatePaye_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_DatePaye.IsNull) {

					sqlParameter.Value = parameters.Param_DatePaye;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_DatePaye", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_DatePaye_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_DatePaye.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_DatePaye;
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

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Annee", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_Annee_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_Annee.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_Annee;
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

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Periode", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_Periode_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_Periode.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_Periode;
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

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_ContratID", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_ContratID_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_ContratID.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_ContratID;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Sciage", System.Data.SqlDbType.Bit, 1);
				sqlParameter.SourceColumn = "Sciage";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Sciage_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Sciage.IsNull) {

					sqlParameter.Value = parameters.Param_Sciage;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Sciage", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_Sciage_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_Sciage.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_Sciage;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@EssenceSciage", System.Data.SqlDbType.VarChar, 25);
				sqlParameter.SourceColumn = "EssenceSciage";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_EssenceSciage_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_EssenceSciage.IsNull) {

					sqlParameter.Value = parameters.Param_EssenceSciage;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_EssenceSciage", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_EssenceSciage_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_EssenceSciage.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_EssenceSciage;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@NumeroFactureUsine", System.Data.SqlDbType.VarChar, 25);
				sqlParameter.SourceColumn = "NumeroFactureUsine";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_NumeroFactureUsine_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_NumeroFactureUsine.IsNull) {

					sqlParameter.Value = parameters.Param_NumeroFactureUsine;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_NumeroFactureUsine", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_NumeroFactureUsine_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_NumeroFactureUsine.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_NumeroFactureUsine;
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

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_ProducteurID", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_ProducteurID_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_ProducteurID.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_ProducteurID;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Livraison", System.Data.SqlDbType.Bit, 1);
				sqlParameter.SourceColumn = "Livraison";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Livraison_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Livraison.IsNull) {

					sqlParameter.Value = parameters.Param_Livraison;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Livraison", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_Livraison_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_Livraison.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_Livraison;
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

		private bool RetrieveParameters(ref Gestion_Paie.DataClasses.Parameters.spU_FactureUsine parameters, ref System.Data.SqlClient.SqlCommand sqlCommand) {

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
		/// This method allows you to execute the [spU_FactureUsine] stored procedure.
		/// </summary>
		/// <param name="parameters">
		/// Contains all the necessary information to execute correctly the stored procedure, i.e. 
		/// the database connection to use and all the necessary input parameters to be supplied
		/// for this stored procedure execution. After the execution, this object will allow you
		/// to retrieve back the stored procedure return value and all the output parameters.
		/// </param>
		/// <returns>True if the call was successful. Otherwise, it returns False.</returns>
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.spU_FactureUsine parameters) {

			System.Data.SqlClient.SqlCommand sqlCommand = null;
			System.Boolean returnStatus = false;
			System.Boolean connectionMustBeClosed = true;

			try {
				ResetParameter(ref parameters);

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
				sqlCommand.ExecuteNonQuery();
                
				parameters.internal_SetErrorSource(ErrorSource.ParametersRetrieval);
				returnStatus = RetrieveParameters(ref parameters, ref sqlCommand);
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

	}

}

