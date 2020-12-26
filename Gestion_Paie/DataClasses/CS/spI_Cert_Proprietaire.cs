using System;

namespace Gestion_Paie.DataClasses.Parameters {

	/// <summary>
	/// This class allows a developer to specify the parameters expected by the
	/// stored procedure 'spI_Cert_Proprietaire'. It allows also to specify specific connection
	/// information such as the ConnectionString to be use, the command time-out and so forth.
	/// </summary>
	[Serializable()]
	public sealed class spI_Cert_Proprietaire : MarshalByRefObject, IDisposable, IParameter {

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
		/// Initializes a new instance of the spI_Cert_Proprietaire class. If you use this constructor version,
		/// not assigning parameter values implies using the parameter default values.
		/// </summary>
		public spI_Cert_Proprietaire() : this(true) {

		}

		/// <summary>
		/// Initializes a new instance of the spI_Cert_Proprietaire class.
		/// </summary>
		/// <param name="useDefaultValue">If True, this parameter indicates that "not assigning parameter values" implies "using the parameter default values". If False, this parameter indicates that "not assigning parameter values" implies "using the SQL Server Null value".</param>
		public spI_Cert_Proprietaire(bool useDefaultValue) {

			this.useDefaultValue = useDefaultValue;

			this.internal_Param_Agence_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_NO_ACT_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Nom_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Representant_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ADRESSE_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Ville_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_CODE_POST_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_TEL_RES_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_TEL_BUR_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_FournisseurID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_FournisseurNom_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Traite_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Methode_UseDefaultValue = this.useDefaultValue;
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
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'spI_Cert_Proprietaire'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

						throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "spI_Cert_Proprietaire", CurrentRevision, OriginalRevision, System.Environment.NewLine));
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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'spI_Cert_Proprietaire'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlConnection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "spI_Cert_Proprietaire", CurrentRevision, OriginalRevision, System.Environment.NewLine));
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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'spI_Cert_Proprietaire'";
				sqlCommand.Transaction = sqlTransaction;

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlTransaction.Connection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "spI_Cert_Proprietaire", CurrentRevision, OriginalRevision, System.Environment.NewLine));
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
				this.internal_Param_Agence = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_NO_ACT = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_Nom = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_Representant = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_ADRESSE = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_Ville = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_CODE_POST = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_TEL_RES = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_TEL_BUR = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_FournisseurID = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_FournisseurNom = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_Traite = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Methode = System.Data.SqlTypes.SqlString.Null;

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
		~spI_Cert_Proprietaire() {

			Dispose(false);
		}

		/// <summary>
		/// Returns the stored procedure name for which this class was built, i.e. 'spI_Cert_Proprietaire'.
		/// </summary>
		public string StoredProcedureName {

			get {

				return("spI_Cert_Proprietaire");
			}
		}

		private System.Data.SqlTypes.SqlInt32 internal_Param_RETURN_VALUE;

		private System.Data.SqlTypes.SqlString internal_Param_Agence;
		internal bool internal_Param_Agence_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_NO_ACT;
		internal bool internal_Param_NO_ACT_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_Nom;
		internal bool internal_Param_Nom_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_Representant;
		internal bool internal_Param_Representant_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_ADRESSE;
		internal bool internal_Param_ADRESSE_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_Ville;
		internal bool internal_Param_Ville_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_CODE_POST;
		internal bool internal_Param_CODE_POST_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_TEL_RES;
		internal bool internal_Param_TEL_RES_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_TEL_BUR;
		internal bool internal_Param_TEL_BUR_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_FournisseurID;
		internal bool internal_Param_FournisseurID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_FournisseurNom;
		internal bool internal_Param_FournisseurNom_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_Traite;
		internal bool internal_Param_Traite_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_Methode;
		internal bool internal_Param_Methode_UseDefaultValue = true;


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

			this.internal_Param_Agence = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_Agence_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_NO_ACT = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_NO_ACT_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Nom = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_Nom_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Representant = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_Representant_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ADRESSE = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_ADRESSE_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Ville = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_Ville_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_CODE_POST = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_CODE_POST_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_TEL_RES = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_TEL_RES_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_TEL_BUR = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_TEL_BUR_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_FournisseurID = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_FournisseurID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_FournisseurNom = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_FournisseurNom_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Traite = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_Traite_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Methode = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_Methode_UseDefaultValue = this.useDefaultValue;

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
		/// Sets the value of the stored procedure INPUT parameter '@Agence'.
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
		/// the parameter default value, consider calling the Param_Agence_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_Agence {

			get {

				if (this.internal_Param_Agence_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Agence);
			}

			set {

				this.internal_Param_Agence_UseDefaultValue = false;
				this.internal_Param_Agence = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Agence' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Agence_UseDefaultValue() {

			this.internal_Param_Agence_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@NO_ACT'.
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
		/// the parameter default value, consider calling the Param_NO_ACT_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_NO_ACT {

			get {

				if (this.internal_Param_NO_ACT_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_NO_ACT);
			}

			set {

				this.internal_Param_NO_ACT_UseDefaultValue = false;
				this.internal_Param_NO_ACT = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@NO_ACT' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_NO_ACT_UseDefaultValue() {

			this.internal_Param_NO_ACT_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Nom'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [varchar](50)
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_Nom_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_Nom {

			get {

				if (this.internal_Param_Nom_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Nom);
			}

			set {

				this.internal_Param_Nom_UseDefaultValue = false;
				this.internal_Param_Nom = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Nom' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Nom_UseDefaultValue() {

			this.internal_Param_Nom_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Representant'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [varchar](35)
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_Representant_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_Representant {

			get {

				if (this.internal_Param_Representant_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Representant);
			}

			set {

				this.internal_Param_Representant_UseDefaultValue = false;
				this.internal_Param_Representant = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Representant' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Representant_UseDefaultValue() {

			this.internal_Param_Representant_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ADRESSE'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [varchar](50)
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_ADRESSE_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_ADRESSE {

			get {

				if (this.internal_Param_ADRESSE_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ADRESSE);
			}

			set {

				this.internal_Param_ADRESSE_UseDefaultValue = false;
				this.internal_Param_ADRESSE = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ADRESSE' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ADRESSE_UseDefaultValue() {

			this.internal_Param_ADRESSE_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Ville'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [varchar](50)
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_Ville_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_Ville {

			get {

				if (this.internal_Param_Ville_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Ville);
			}

			set {

				this.internal_Param_Ville_UseDefaultValue = false;
				this.internal_Param_Ville = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Ville' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Ville_UseDefaultValue() {

			this.internal_Param_Ville_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@CODE_POST'.
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
		/// the parameter default value, consider calling the Param_CODE_POST_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_CODE_POST {

			get {

				if (this.internal_Param_CODE_POST_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_CODE_POST);
			}

			set {

				this.internal_Param_CODE_POST_UseDefaultValue = false;
				this.internal_Param_CODE_POST = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@CODE_POST' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_CODE_POST_UseDefaultValue() {

			this.internal_Param_CODE_POST_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@TEL_RES'.
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
		/// the parameter default value, consider calling the Param_TEL_RES_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_TEL_RES {

			get {

				if (this.internal_Param_TEL_RES_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_TEL_RES);
			}

			set {

				this.internal_Param_TEL_RES_UseDefaultValue = false;
				this.internal_Param_TEL_RES = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@TEL_RES' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_TEL_RES_UseDefaultValue() {

			this.internal_Param_TEL_RES_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@TEL_BUR'.
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
		/// the parameter default value, consider calling the Param_TEL_BUR_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_TEL_BUR {

			get {

				if (this.internal_Param_TEL_BUR_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_TEL_BUR);
			}

			set {

				this.internal_Param_TEL_BUR_UseDefaultValue = false;
				this.internal_Param_TEL_BUR = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@TEL_BUR' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_TEL_BUR_UseDefaultValue() {

			this.internal_Param_TEL_BUR_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@FournisseurID'.
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
		/// the parameter default value, consider calling the Param_FournisseurID_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_FournisseurID {

			get {

				if (this.internal_Param_FournisseurID_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_FournisseurID);
			}

			set {

				this.internal_Param_FournisseurID_UseDefaultValue = false;
				this.internal_Param_FournisseurID = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@FournisseurID' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_FournisseurID_UseDefaultValue() {

			this.internal_Param_FournisseurID_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@FournisseurNom'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [varchar](40)
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_FournisseurNom_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_FournisseurNom {

			get {

				if (this.internal_Param_FournisseurNom_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_FournisseurNom);
			}

			set {

				this.internal_Param_FournisseurNom_UseDefaultValue = false;
				this.internal_Param_FournisseurNom = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@FournisseurNom' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_FournisseurNom_UseDefaultValue() {

			this.internal_Param_FournisseurNom_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Traite'.
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
		/// the parameter default value, consider calling the Param_Traite_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_Traite {

			get {

				if (this.internal_Param_Traite_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Traite);
			}

			set {

				this.internal_Param_Traite_UseDefaultValue = false;
				this.internal_Param_Traite = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Traite' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Traite_UseDefaultValue() {

			this.internal_Param_Traite_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Methode'.
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
		/// the parameter default value, consider calling the Param_Methode_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_Methode {

			get {

				if (this.internal_Param_Methode_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Methode);
			}

			set {

				this.internal_Param_Methode_UseDefaultValue = false;
				this.internal_Param_Methode = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Methode' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Methode_UseDefaultValue() {

			this.internal_Param_Methode_UseDefaultValue = true;
		}

  	}
}

namespace Gestion_Paie.DataClasses.StoredProcedures {

	/// <summary>
	/// This class allows you to execute the 'spI_Cert_Proprietaire' stored procedure;
	/// it gives you the ability to:
	/// <list type="bullet">
	/// <item><description>Set all the necessary parameters to execute the stored procedure</description></item>
	/// <item><description>To execute the stored procedure</description></item>
	/// <item><description>To get back after the execution the return value and all the output parameters value</description></item>
	/// </list>
	/// </summary>
	public sealed class spI_Cert_Proprietaire : MarshalByRefObject, IDisposable {


		private bool throwExceptionOnExecute = false;

		/// <summary>
		/// Initializes a new instance of the spI_Cert_Proprietaire class.
		/// By default, no exception will be thrown when you call the Execute method. Instead, a Boolean return status will be returned.
		/// </summary>
		public spI_Cert_Proprietaire() : this(false) {

		}

		/// <summary>
		/// Initializes a new instance of the spI_Cert_Proprietaire class.
		/// </summary>
		/// <param name="throwExceptionOnExecute">True if an exception has to be thrown if the Execute call fails.</param>
		public spI_Cert_Proprietaire(bool throwExceptionOnExecute) {

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
		~spI_Cert_Proprietaire() {

			Dispose(false);
		}

		private void ResetParameter(ref Gestion_Paie.DataClasses.Parameters.spI_Cert_Proprietaire parameters) {

			parameters.internal_Set_RETURN_VALUE (System.Data.SqlTypes.SqlInt32.Null);
		}

		private bool InitializeConnection(ref Gestion_Paie.DataClasses.Parameters.spI_Cert_Proprietaire parameters, out System.Data.SqlClient.SqlCommand sqlCommand, ref bool connectionMustBeClosed) {

			try {

				this.sqlConnection = null;
				sqlCommand = null;
				connectionMustBeClosed = true;

				if (parameters.ConnectionType == ConnectionType.None) {

					throw new InvalidOperationException("No connection information was supplied. Consider calling the 'SetUpConnection' method of the Gestion_Paie.DataClasses.Parameters.spI_Cert_Proprietaire object before doing this call.");
				}

				if (parameters.ConnectionType == ConnectionType.SqlConnection && parameters.SqlConnection == null) {

					throw new InvalidOperationException("No connection information was supplied (SqlConnection == null). Consider calling the 'SetUpConnection' method of the Gestion_Paie.DataClasses.Parameters.spI_Cert_Proprietaire object before doing this call.");
				}

				if (parameters.ConnectionType == ConnectionType.SqlTransaction && parameters.SqlTransaction== null) {

					throw new InvalidOperationException("No connection information was supplied (SqlTransaction == null). Consider calling the 'SetUpConnection' method of the Gestion_Paie.DataClasses.Parameters.spI_Cert_Proprietaire object before doing this call.");
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

							throw new System.InvalidOperationException("No connection information was supplied (ConnectionString == \"\")! (Gestion_Paie.DataClasses.Parameters.spI_Cert_Proprietaire)");
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
				sqlCommand.CommandText = "spI_Cert_Proprietaire";

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

		private bool DeclareParameters(ref Gestion_Paie.DataClasses.Parameters.spI_Cert_Proprietaire parameters, ref System.Data.SqlClient.SqlCommand sqlCommand) {

			try {

				System.Data.SqlClient.SqlParameter sqlParameter;

				sqlParameter = new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4);
				sqlParameter.Direction = System.Data.ParameterDirection.ReturnValue;
				sqlParameter.IsNullable = true;
				sqlParameter.Value = System.DBNull.Value;
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Agence", System.Data.SqlDbType.VarChar, 10);
				sqlParameter.SourceColumn = "Agence";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Agence_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Agence.IsNull) {

					sqlParameter.Value = parameters.Param_Agence;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@NO_ACT", System.Data.SqlDbType.VarChar, 10);
				sqlParameter.SourceColumn = "NO_ACT";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_NO_ACT_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_NO_ACT.IsNull) {

					sqlParameter.Value = parameters.Param_NO_ACT;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Nom", System.Data.SqlDbType.VarChar, 50);
				sqlParameter.SourceColumn = "Nom";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Nom_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Nom.IsNull) {

					sqlParameter.Value = parameters.Param_Nom;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Representant", System.Data.SqlDbType.VarChar, 35);
				sqlParameter.SourceColumn = "Representant";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Representant_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Representant.IsNull) {

					sqlParameter.Value = parameters.Param_Representant;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ADRESSE", System.Data.SqlDbType.VarChar, 50);
				sqlParameter.SourceColumn = "ADRESSE";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ADRESSE_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ADRESSE.IsNull) {

					sqlParameter.Value = parameters.Param_ADRESSE;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Ville", System.Data.SqlDbType.VarChar, 50);
				sqlParameter.SourceColumn = "Ville";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Ville_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Ville.IsNull) {

					sqlParameter.Value = parameters.Param_Ville;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@CODE_POST", System.Data.SqlDbType.VarChar, 25);
				sqlParameter.SourceColumn = "CODE_POST";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_CODE_POST_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_CODE_POST.IsNull) {

					sqlParameter.Value = parameters.Param_CODE_POST;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@TEL_RES", System.Data.SqlDbType.VarChar, 25);
				sqlParameter.SourceColumn = "TEL_RES";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_TEL_RES_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_TEL_RES.IsNull) {

					sqlParameter.Value = parameters.Param_TEL_RES;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@TEL_BUR", System.Data.SqlDbType.VarChar, 25);
				sqlParameter.SourceColumn = "TEL_BUR";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_TEL_BUR_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_TEL_BUR.IsNull) {

					sqlParameter.Value = parameters.Param_TEL_BUR;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@FournisseurID", System.Data.SqlDbType.VarChar, 15);
				sqlParameter.SourceColumn = "FournisseurID";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_FournisseurID_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_FournisseurID.IsNull) {

					sqlParameter.Value = parameters.Param_FournisseurID;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@FournisseurNom", System.Data.SqlDbType.VarChar, 40);
				sqlParameter.SourceColumn = "FournisseurNom";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_FournisseurNom_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_FournisseurNom.IsNull) {

					sqlParameter.Value = parameters.Param_FournisseurNom;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Traite", System.Data.SqlDbType.Bit, 1);
				sqlParameter.SourceColumn = "Traite";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Traite_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Traite.IsNull) {

					sqlParameter.Value = parameters.Param_Traite;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Methode", System.Data.SqlDbType.VarChar, 25);
				sqlParameter.SourceColumn = "Methode";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Methode_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Methode.IsNull) {

					sqlParameter.Value = parameters.Param_Methode;
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

		private bool RetrieveParameters(ref Gestion_Paie.DataClasses.Parameters.spI_Cert_Proprietaire parameters, ref System.Data.SqlClient.SqlCommand sqlCommand) {

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
		/// This method allows you to execute the [spI_Cert_Proprietaire] stored procedure.
		/// </summary>
		/// <param name="parameters">
		/// Contains all the necessary information to execute correctly the stored procedure, i.e. 
		/// the database connection to use and all the necessary input parameters to be supplied
		/// for this stored procedure execution. After the execution, this object will allow you
		/// to retrieve back the stored procedure return value and all the output parameters.
		/// </param>
		/// <returns>True if the call was successful. Otherwise, it returns False.</returns>
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.spI_Cert_Proprietaire parameters) {

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

