using System;

namespace Gestion_Paie.DataClasses.Parameters {

	/// <summary>
	/// This class allows a developer to specify the parameters expected by the
	/// stored procedure 'spI_Contingentement'. It allows also to specify specific connection
	/// information such as the ConnectionString to be use, the command time-out and so forth.
	/// </summary>
	[Serializable()]
	public sealed class spI_Contingentement : MarshalByRefObject, IDisposable, IParameter {

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
		/// Initializes a new instance of the spI_Contingentement class. If you use this constructor version,
		/// not assigning parameter values implies using the parameter default values.
		/// </summary>
		public spI_Contingentement() : this(true) {

		}

		/// <summary>
		/// Initializes a new instance of the spI_Contingentement class.
		/// </summary>
		/// <param name="useDefaultValue">If True, this parameter indicates that "not assigning parameter values" implies "using the parameter default values". If False, this parameter indicates that "not assigning parameter values" implies "using the SQL Server Null value".</param>
		public spI_Contingentement(bool useDefaultValue) {

			this.useDefaultValue = useDefaultValue;

			this.internal_Param_ID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ContingentUsine_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_UsineID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_RegroupementID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Annee_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_PeriodeContingentement_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_PeriodeDebut_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_PeriodeFin_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_EssenceID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_UniteMesureID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Volume_Usine_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Facteur_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Volume_Fixe_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Date_Calcul_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_CalculAccepte_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Code_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Volume_Regroupement_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Volume_RegroupementPourcentage_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_MaxVolumeFixe_Pourcentage_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_MaxVolumeFixe_ContingentementID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_UseVolumeFixeUnique_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_MasseContingentVoyageDefaut_UseDefaultValue = this.useDefaultValue;
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
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'spI_Contingentement'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

						throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "spI_Contingentement", CurrentRevision, OriginalRevision, System.Environment.NewLine));
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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'spI_Contingentement'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlConnection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "spI_Contingentement", CurrentRevision, OriginalRevision, System.Environment.NewLine));
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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'spI_Contingentement'";
				sqlCommand.Transaction = sqlTransaction;

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlTransaction.Connection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "spI_Contingentement", CurrentRevision, OriginalRevision, System.Environment.NewLine));
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
				this.internal_Param_ContingentUsine = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_UsineID = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_RegroupementID = System.Data.SqlTypes.SqlInt32.Null;
				this.internal_Param_Annee = System.Data.SqlTypes.SqlInt32.Null;
				this.internal_Param_PeriodeContingentement = System.Data.SqlTypes.SqlInt32.Null;
				this.internal_Param_PeriodeDebut = System.Data.SqlTypes.SqlInt32.Null;
				this.internal_Param_PeriodeFin = System.Data.SqlTypes.SqlInt32.Null;
				this.internal_Param_EssenceID = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_UniteMesureID = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_Volume_Usine = System.Data.SqlTypes.SqlSingle.Null;
				this.internal_Param_Facteur = System.Data.SqlTypes.SqlSingle.Null;
				this.internal_Param_Volume_Fixe = System.Data.SqlTypes.SqlSingle.Null;
				this.internal_Param_Date_Calcul = System.Data.SqlTypes.SqlDateTime.Null;
				this.internal_Param_CalculAccepte = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Code = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_Volume_Regroupement = System.Data.SqlTypes.SqlSingle.Null;
				this.internal_Param_Volume_RegroupementPourcentage = System.Data.SqlTypes.SqlSingle.Null;
				this.internal_Param_MaxVolumeFixe_Pourcentage = System.Data.SqlTypes.SqlSingle.Null;
				this.internal_Param_MaxVolumeFixe_ContingentementID = System.Data.SqlTypes.SqlInt32.Null;
				this.internal_Param_UseVolumeFixeUnique = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_MasseContingentVoyageDefaut = System.Data.SqlTypes.SqlSingle.Null;

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
		~spI_Contingentement() {

			Dispose(false);
		}

		/// <summary>
		/// Returns the stored procedure name for which this class was built, i.e. 'spI_Contingentement'.
		/// </summary>
		public string StoredProcedureName {

			get {

				return("spI_Contingentement");
			}
		}

		private System.Data.SqlTypes.SqlInt32 internal_Param_RETURN_VALUE;

		private System.Data.SqlTypes.SqlInt32 internal_Param_ID;
		internal bool internal_Param_ID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ContingentUsine;
		internal bool internal_Param_ContingentUsine_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_UsineID;
		internal bool internal_Param_UsineID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlInt32 internal_Param_RegroupementID;
		internal bool internal_Param_RegroupementID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlInt32 internal_Param_Annee;
		internal bool internal_Param_Annee_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlInt32 internal_Param_PeriodeContingentement;
		internal bool internal_Param_PeriodeContingentement_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlInt32 internal_Param_PeriodeDebut;
		internal bool internal_Param_PeriodeDebut_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlInt32 internal_Param_PeriodeFin;
		internal bool internal_Param_PeriodeFin_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_EssenceID;
		internal bool internal_Param_EssenceID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_UniteMesureID;
		internal bool internal_Param_UniteMesureID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlSingle internal_Param_Volume_Usine;
		internal bool internal_Param_Volume_Usine_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlSingle internal_Param_Facteur;
		internal bool internal_Param_Facteur_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlSingle internal_Param_Volume_Fixe;
		internal bool internal_Param_Volume_Fixe_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlDateTime internal_Param_Date_Calcul;
		internal bool internal_Param_Date_Calcul_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_CalculAccepte;
		internal bool internal_Param_CalculAccepte_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_Code;
		internal bool internal_Param_Code_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlSingle internal_Param_Volume_Regroupement;
		internal bool internal_Param_Volume_Regroupement_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlSingle internal_Param_Volume_RegroupementPourcentage;
		internal bool internal_Param_Volume_RegroupementPourcentage_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlSingle internal_Param_MaxVolumeFixe_Pourcentage;
		internal bool internal_Param_MaxVolumeFixe_Pourcentage_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlInt32 internal_Param_MaxVolumeFixe_ContingentementID;
		internal bool internal_Param_MaxVolumeFixe_ContingentementID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_UseVolumeFixeUnique;
		internal bool internal_Param_UseVolumeFixeUnique_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlSingle internal_Param_MasseContingentVoyageDefaut;
		internal bool internal_Param_MasseContingentVoyageDefaut_UseDefaultValue = true;


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

			this.internal_Param_ContingentUsine = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ContingentUsine_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_UsineID = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_UsineID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_RegroupementID = System.Data.SqlTypes.SqlInt32.Null;
			this.internal_Param_RegroupementID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Annee = System.Data.SqlTypes.SqlInt32.Null;
			this.internal_Param_Annee_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_PeriodeContingentement = System.Data.SqlTypes.SqlInt32.Null;
			this.internal_Param_PeriodeContingentement_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_PeriodeDebut = System.Data.SqlTypes.SqlInt32.Null;
			this.internal_Param_PeriodeDebut_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_PeriodeFin = System.Data.SqlTypes.SqlInt32.Null;
			this.internal_Param_PeriodeFin_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_EssenceID = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_EssenceID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_UniteMesureID = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_UniteMesureID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Volume_Usine = System.Data.SqlTypes.SqlSingle.Null;
			this.internal_Param_Volume_Usine_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Facteur = System.Data.SqlTypes.SqlSingle.Null;
			this.internal_Param_Facteur_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Volume_Fixe = System.Data.SqlTypes.SqlSingle.Null;
			this.internal_Param_Volume_Fixe_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Date_Calcul = System.Data.SqlTypes.SqlDateTime.Null;
			this.internal_Param_Date_Calcul_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_CalculAccepte = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_CalculAccepte_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Code = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_Code_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Volume_Regroupement = System.Data.SqlTypes.SqlSingle.Null;
			this.internal_Param_Volume_Regroupement_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Volume_RegroupementPourcentage = System.Data.SqlTypes.SqlSingle.Null;
			this.internal_Param_Volume_RegroupementPourcentage_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_MaxVolumeFixe_Pourcentage = System.Data.SqlTypes.SqlSingle.Null;
			this.internal_Param_MaxVolumeFixe_Pourcentage_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_MaxVolumeFixe_ContingentementID = System.Data.SqlTypes.SqlInt32.Null;
			this.internal_Param_MaxVolumeFixe_ContingentementID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_UseVolumeFixeUnique = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_UseVolumeFixeUnique_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_MasseContingentVoyageDefaut = System.Data.SqlTypes.SqlSingle.Null;
			this.internal_Param_MasseContingentVoyageDefaut_UseDefaultValue = this.useDefaultValue;

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
		/// Sets or returns the value of the stored procedure OUTPUT parameter '@ID'.
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
		/// Sets the value of the stored procedure INPUT parameter '@ContingentUsine'.
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
		/// the parameter default value, consider calling the Param_ContingentUsine_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ContingentUsine {

			get {

				if (this.internal_Param_ContingentUsine_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ContingentUsine);
			}

			set {

				this.internal_Param_ContingentUsine_UseDefaultValue = false;
				this.internal_Param_ContingentUsine = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ContingentUsine' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ContingentUsine_UseDefaultValue() {

			this.internal_Param_ContingentUsine_UseDefaultValue = true;
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
		/// Sets the value of the stored procedure INPUT parameter '@RegroupementID'.
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
		/// the parameter default value, consider calling the Param_RegroupementID_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlInt32 Param_RegroupementID {

			get {

				if (this.internal_Param_RegroupementID_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_RegroupementID);
			}

			set {

				this.internal_Param_RegroupementID_UseDefaultValue = false;
				this.internal_Param_RegroupementID = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@RegroupementID' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_RegroupementID_UseDefaultValue() {

			this.internal_Param_RegroupementID_UseDefaultValue = true;
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
		/// Sets the value of the stored procedure INPUT parameter '@PeriodeContingentement'.
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
		/// the parameter default value, consider calling the Param_PeriodeContingentement_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlInt32 Param_PeriodeContingentement {

			get {

				if (this.internal_Param_PeriodeContingentement_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_PeriodeContingentement);
			}

			set {

				this.internal_Param_PeriodeContingentement_UseDefaultValue = false;
				this.internal_Param_PeriodeContingentement = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@PeriodeContingentement' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_PeriodeContingentement_UseDefaultValue() {

			this.internal_Param_PeriodeContingentement_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@PeriodeDebut'.
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
		/// the parameter default value, consider calling the Param_PeriodeDebut_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlInt32 Param_PeriodeDebut {

			get {

				if (this.internal_Param_PeriodeDebut_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_PeriodeDebut);
			}

			set {

				this.internal_Param_PeriodeDebut_UseDefaultValue = false;
				this.internal_Param_PeriodeDebut = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@PeriodeDebut' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_PeriodeDebut_UseDefaultValue() {

			this.internal_Param_PeriodeDebut_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@PeriodeFin'.
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
		/// the parameter default value, consider calling the Param_PeriodeFin_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlInt32 Param_PeriodeFin {

			get {

				if (this.internal_Param_PeriodeFin_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_PeriodeFin);
			}

			set {

				this.internal_Param_PeriodeFin_UseDefaultValue = false;
				this.internal_Param_PeriodeFin = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@PeriodeFin' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_PeriodeFin_UseDefaultValue() {

			this.internal_Param_PeriodeFin_UseDefaultValue = true;
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
		/// Sets the value of the stored procedure INPUT parameter '@Volume_Usine'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [real]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_Volume_Usine_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlSingle Param_Volume_Usine {

			get {

				if (this.internal_Param_Volume_Usine_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Volume_Usine);
			}

			set {

				this.internal_Param_Volume_Usine_UseDefaultValue = false;
				this.internal_Param_Volume_Usine = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Volume_Usine' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Volume_Usine_UseDefaultValue() {

			this.internal_Param_Volume_Usine_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Facteur'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [real]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_Facteur_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlSingle Param_Facteur {

			get {

				if (this.internal_Param_Facteur_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Facteur);
			}

			set {

				this.internal_Param_Facteur_UseDefaultValue = false;
				this.internal_Param_Facteur = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Facteur' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Facteur_UseDefaultValue() {

			this.internal_Param_Facteur_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Volume_Fixe'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [real]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_Volume_Fixe_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlSingle Param_Volume_Fixe {

			get {

				if (this.internal_Param_Volume_Fixe_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Volume_Fixe);
			}

			set {

				this.internal_Param_Volume_Fixe_UseDefaultValue = false;
				this.internal_Param_Volume_Fixe = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Volume_Fixe' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Volume_Fixe_UseDefaultValue() {

			this.internal_Param_Volume_Fixe_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Date_Calcul'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [datetime]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_Date_Calcul_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlDateTime Param_Date_Calcul {

			get {

				if (this.internal_Param_Date_Calcul_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Date_Calcul);
			}

			set {

				this.internal_Param_Date_Calcul_UseDefaultValue = false;
				this.internal_Param_Date_Calcul = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Date_Calcul' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Date_Calcul_UseDefaultValue() {

			this.internal_Param_Date_Calcul_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@CalculAccepte'.
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
		/// the parameter default value, consider calling the Param_CalculAccepte_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_CalculAccepte {

			get {

				if (this.internal_Param_CalculAccepte_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_CalculAccepte);
			}

			set {

				this.internal_Param_CalculAccepte_UseDefaultValue = false;
				this.internal_Param_CalculAccepte = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@CalculAccepte' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_CalculAccepte_UseDefaultValue() {

			this.internal_Param_CalculAccepte_UseDefaultValue = true;
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
		/// Sets the value of the stored procedure INPUT parameter '@Volume_Regroupement'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [real]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_Volume_Regroupement_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlSingle Param_Volume_Regroupement {

			get {

				if (this.internal_Param_Volume_Regroupement_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Volume_Regroupement);
			}

			set {

				this.internal_Param_Volume_Regroupement_UseDefaultValue = false;
				this.internal_Param_Volume_Regroupement = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Volume_Regroupement' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Volume_Regroupement_UseDefaultValue() {

			this.internal_Param_Volume_Regroupement_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Volume_RegroupementPourcentage'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [real]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_Volume_RegroupementPourcentage_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlSingle Param_Volume_RegroupementPourcentage {

			get {

				if (this.internal_Param_Volume_RegroupementPourcentage_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Volume_RegroupementPourcentage);
			}

			set {

				this.internal_Param_Volume_RegroupementPourcentage_UseDefaultValue = false;
				this.internal_Param_Volume_RegroupementPourcentage = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Volume_RegroupementPourcentage' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Volume_RegroupementPourcentage_UseDefaultValue() {

			this.internal_Param_Volume_RegroupementPourcentage_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@MaxVolumeFixe_Pourcentage'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [real]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_MaxVolumeFixe_Pourcentage_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlSingle Param_MaxVolumeFixe_Pourcentage {

			get {

				if (this.internal_Param_MaxVolumeFixe_Pourcentage_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_MaxVolumeFixe_Pourcentage);
			}

			set {

				this.internal_Param_MaxVolumeFixe_Pourcentage_UseDefaultValue = false;
				this.internal_Param_MaxVolumeFixe_Pourcentage = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@MaxVolumeFixe_Pourcentage' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_MaxVolumeFixe_Pourcentage_UseDefaultValue() {

			this.internal_Param_MaxVolumeFixe_Pourcentage_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@MaxVolumeFixe_ContingentementID'.
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
		/// the parameter default value, consider calling the Param_MaxVolumeFixe_ContingentementID_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlInt32 Param_MaxVolumeFixe_ContingentementID {

			get {

				if (this.internal_Param_MaxVolumeFixe_ContingentementID_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_MaxVolumeFixe_ContingentementID);
			}

			set {

				this.internal_Param_MaxVolumeFixe_ContingentementID_UseDefaultValue = false;
				this.internal_Param_MaxVolumeFixe_ContingentementID = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@MaxVolumeFixe_ContingentementID' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_MaxVolumeFixe_ContingentementID_UseDefaultValue() {

			this.internal_Param_MaxVolumeFixe_ContingentementID_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@UseVolumeFixeUnique'.
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
		/// the parameter default value, consider calling the Param_UseVolumeFixeUnique_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_UseVolumeFixeUnique {

			get {

				if (this.internal_Param_UseVolumeFixeUnique_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_UseVolumeFixeUnique);
			}

			set {

				this.internal_Param_UseVolumeFixeUnique_UseDefaultValue = false;
				this.internal_Param_UseVolumeFixeUnique = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@UseVolumeFixeUnique' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_UseVolumeFixeUnique_UseDefaultValue() {

			this.internal_Param_UseVolumeFixeUnique_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@MasseContingentVoyageDefaut'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [real]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_MasseContingentVoyageDefaut_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlSingle Param_MasseContingentVoyageDefaut {

			get {

				if (this.internal_Param_MasseContingentVoyageDefaut_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_MasseContingentVoyageDefaut);
			}

			set {

				this.internal_Param_MasseContingentVoyageDefaut_UseDefaultValue = false;
				this.internal_Param_MasseContingentVoyageDefaut = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@MasseContingentVoyageDefaut' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_MasseContingentVoyageDefaut_UseDefaultValue() {

			this.internal_Param_MasseContingentVoyageDefaut_UseDefaultValue = true;
		}

  	}
}

namespace Gestion_Paie.DataClasses.StoredProcedures {

	/// <summary>
	/// This class allows you to execute the 'spI_Contingentement' stored procedure;
	/// it gives you the ability to:
	/// <list type="bullet">
	/// <item><description>Set all the necessary parameters to execute the stored procedure</description></item>
	/// <item><description>To execute the stored procedure</description></item>
	/// <item><description>To get back after the execution the return value and all the output parameters value</description></item>
	/// </list>
	/// </summary>
	public sealed class spI_Contingentement : MarshalByRefObject, IDisposable {


		private bool throwExceptionOnExecute = false;

		/// <summary>
		/// Initializes a new instance of the spI_Contingentement class.
		/// By default, no exception will be thrown when you call the Execute method. Instead, a Boolean return status will be returned.
		/// </summary>
		public spI_Contingentement() : this(false) {

		}

		/// <summary>
		/// Initializes a new instance of the spI_Contingentement class.
		/// </summary>
		/// <param name="throwExceptionOnExecute">True if an exception has to be thrown if the Execute call fails.</param>
		public spI_Contingentement(bool throwExceptionOnExecute) {

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
		~spI_Contingentement() {

			Dispose(false);
		}

		private void ResetParameter(ref Gestion_Paie.DataClasses.Parameters.spI_Contingentement parameters) {

			parameters.internal_Set_RETURN_VALUE (System.Data.SqlTypes.SqlInt32.Null);
		}

		private bool InitializeConnection(ref Gestion_Paie.DataClasses.Parameters.spI_Contingentement parameters, out System.Data.SqlClient.SqlCommand sqlCommand, ref bool connectionMustBeClosed) {

			try {

				this.sqlConnection = null;
				sqlCommand = null;
				connectionMustBeClosed = true;

				if (parameters.ConnectionType == ConnectionType.None) {

					throw new InvalidOperationException("No connection information was supplied. Consider calling the 'SetUpConnection' method of the Gestion_Paie.DataClasses.Parameters.spI_Contingentement object before doing this call.");
				}

				if (parameters.ConnectionType == ConnectionType.SqlConnection && parameters.SqlConnection == null) {

					throw new InvalidOperationException("No connection information was supplied (SqlConnection == null). Consider calling the 'SetUpConnection' method of the Gestion_Paie.DataClasses.Parameters.spI_Contingentement object before doing this call.");
				}

				if (parameters.ConnectionType == ConnectionType.SqlTransaction && parameters.SqlTransaction== null) {

					throw new InvalidOperationException("No connection information was supplied (SqlTransaction == null). Consider calling the 'SetUpConnection' method of the Gestion_Paie.DataClasses.Parameters.spI_Contingentement object before doing this call.");
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

							throw new System.InvalidOperationException("No connection information was supplied (ConnectionString == \"\")! (Gestion_Paie.DataClasses.Parameters.spI_Contingentement)");
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
				sqlCommand.CommandText = "spI_Contingentement";

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

		private bool DeclareParameters(ref Gestion_Paie.DataClasses.Parameters.spI_Contingentement parameters, ref System.Data.SqlClient.SqlCommand sqlCommand) {

			try {

				System.Data.SqlClient.SqlParameter sqlParameter;

				sqlParameter = new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4);
				sqlParameter.Direction = System.Data.ParameterDirection.ReturnValue;
				sqlParameter.IsNullable = true;
				sqlParameter.Value = System.DBNull.Value;
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.Int, 4);
				sqlParameter.SourceColumn = "ID";
				sqlParameter.Direction = System.Data.ParameterDirection.InputOutput;
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

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ContingentUsine", System.Data.SqlDbType.Bit, 1);
				sqlParameter.SourceColumn = "ContingentUsine";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ContingentUsine_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ContingentUsine.IsNull) {

					sqlParameter.Value = parameters.Param_ContingentUsine;
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

				sqlParameter = new System.Data.SqlClient.SqlParameter("@RegroupementID", System.Data.SqlDbType.Int, 4);
				sqlParameter.SourceColumn = "RegroupementID";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_RegroupementID_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_RegroupementID.IsNull) {

					sqlParameter.Value = parameters.Param_RegroupementID;
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

				sqlParameter = new System.Data.SqlClient.SqlParameter("@PeriodeContingentement", System.Data.SqlDbType.Int, 4);
				sqlParameter.SourceColumn = "PeriodeContingentement";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_PeriodeContingentement_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_PeriodeContingentement.IsNull) {

					sqlParameter.Value = parameters.Param_PeriodeContingentement;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@PeriodeDebut", System.Data.SqlDbType.Int, 4);
				sqlParameter.SourceColumn = "PeriodeDebut";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_PeriodeDebut_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_PeriodeDebut.IsNull) {

					sqlParameter.Value = parameters.Param_PeriodeDebut;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@PeriodeFin", System.Data.SqlDbType.Int, 4);
				sqlParameter.SourceColumn = "PeriodeFin";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_PeriodeFin_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_PeriodeFin.IsNull) {

					sqlParameter.Value = parameters.Param_PeriodeFin;
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

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Volume_Usine", System.Data.SqlDbType.Real, 4);
				sqlParameter.SourceColumn = "Volume_Usine";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Volume_Usine_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Volume_Usine.IsNull) {

					sqlParameter.Value = parameters.Param_Volume_Usine;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Facteur", System.Data.SqlDbType.Real, 4);
				sqlParameter.SourceColumn = "Facteur";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Facteur_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Facteur.IsNull) {

					sqlParameter.Value = parameters.Param_Facteur;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Volume_Fixe", System.Data.SqlDbType.Real, 4);
				sqlParameter.SourceColumn = "Volume_Fixe";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Volume_Fixe_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Volume_Fixe.IsNull) {

					sqlParameter.Value = parameters.Param_Volume_Fixe;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Date_Calcul", System.Data.SqlDbType.DateTime, 16);
				sqlParameter.SourceColumn = "Date_Calcul";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Date_Calcul_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Date_Calcul.IsNull) {

					sqlParameter.Value = parameters.Param_Date_Calcul;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@CalculAccepte", System.Data.SqlDbType.Bit, 1);
				sqlParameter.SourceColumn = "CalculAccepte";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_CalculAccepte_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_CalculAccepte.IsNull) {

					sqlParameter.Value = parameters.Param_CalculAccepte;
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

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Volume_Regroupement", System.Data.SqlDbType.Real, 4);
				sqlParameter.SourceColumn = "Volume_Regroupement";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Volume_Regroupement_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Volume_Regroupement.IsNull) {

					sqlParameter.Value = parameters.Param_Volume_Regroupement;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Volume_RegroupementPourcentage", System.Data.SqlDbType.Real, 4);
				sqlParameter.SourceColumn = "Volume_RegroupementPourcentage";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Volume_RegroupementPourcentage_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Volume_RegroupementPourcentage.IsNull) {

					sqlParameter.Value = parameters.Param_Volume_RegroupementPourcentage;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@MaxVolumeFixe_Pourcentage", System.Data.SqlDbType.Real, 4);
				sqlParameter.SourceColumn = "MaxVolumeFixe_Pourcentage";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_MaxVolumeFixe_Pourcentage_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_MaxVolumeFixe_Pourcentage.IsNull) {

					sqlParameter.Value = parameters.Param_MaxVolumeFixe_Pourcentage;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@MaxVolumeFixe_ContingentementID", System.Data.SqlDbType.Int, 4);
				sqlParameter.SourceColumn = "MaxVolumeFixe_ContingentementID";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_MaxVolumeFixe_ContingentementID_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_MaxVolumeFixe_ContingentementID.IsNull) {

					sqlParameter.Value = parameters.Param_MaxVolumeFixe_ContingentementID;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@UseVolumeFixeUnique", System.Data.SqlDbType.Bit, 1);
				sqlParameter.SourceColumn = "UseVolumeFixeUnique";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_UseVolumeFixeUnique_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_UseVolumeFixeUnique.IsNull) {

					sqlParameter.Value = parameters.Param_UseVolumeFixeUnique;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@MasseContingentVoyageDefaut", System.Data.SqlDbType.Real, 4);
				sqlParameter.SourceColumn = "MasseContingentVoyageDefaut";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_MasseContingentVoyageDefaut_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_MasseContingentVoyageDefaut.IsNull) {

					sqlParameter.Value = parameters.Param_MasseContingentVoyageDefaut;
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

		private bool RetrieveParameters(ref Gestion_Paie.DataClasses.Parameters.spI_Contingentement parameters, ref System.Data.SqlClient.SqlCommand sqlCommand) {

			try {

				if (sqlCommand.Parameters["@RETURN_VALUE"].Value != System.DBNull.Value) {

					parameters.internal_Set_RETURN_VALUE ((System.Int32)sqlCommand.Parameters["@RETURN_VALUE"].Value);
				}
				else {

					parameters.internal_Set_RETURN_VALUE (System.Data.SqlTypes.SqlInt32.Null);
				}

				if (sqlCommand.Parameters["@ID"].Value != System.DBNull.Value) {

						try {

							parameters.Param_ID = (System.Data.SqlTypes.SqlInt32)sqlCommand.Parameters["@ID"].Value;
						}
						catch (System.InvalidCastException) {

							parameters.Param_ID = (System.Int32)sqlCommand.Parameters["@ID"].Value;
						}
				}
				else {

					parameters.Param_ID = System.Data.SqlTypes.SqlInt32.Null;
				}
				parameters.internal_Param_ID_UseDefaultValue = false;

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
		/// This method allows you to execute the [spI_Contingentement] stored procedure.
		/// </summary>
		/// <param name="parameters">
		/// Contains all the necessary information to execute correctly the stored procedure, i.e. 
		/// the database connection to use and all the necessary input parameters to be supplied
		/// for this stored procedure execution. After the execution, this object will allow you
		/// to retrieve back the stored procedure return value and all the output parameters.
		/// </param>
		/// <returns>True if the call was successful. Otherwise, it returns False.</returns>
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.spI_Contingentement parameters) {

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

