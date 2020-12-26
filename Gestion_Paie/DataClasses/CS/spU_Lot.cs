using System;

namespace Gestion_Paie.DataClasses.Parameters {

	/// <summary>
	/// This class allows a developer to specify the parameters expected by the
	/// stored procedure 'spU_Lot'. It allows also to specify specific connection
	/// information such as the ConnectionString to be use, the command time-out and so forth.
	/// </summary>
	[Serializable()]
	public sealed class spU_Lot : MarshalByRefObject, IDisposable, IParameter {

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
		/// Initializes a new instance of the spU_Lot class. If you use this constructor version,
		/// not assigning parameter values implies using the parameter default values.
		/// </summary>
		public spU_Lot() : this(true) {

		}

		/// <summary>
		/// Initializes a new instance of the spU_Lot class.
		/// </summary>
		/// <param name="useDefaultValue">If True, this parameter indicates that "not assigning parameter values" implies "using the parameter default values". If False, this parameter indicates that "not assigning parameter values" implies "using the SQL Server Null value".</param>
		public spU_Lot(bool useDefaultValue) {

			this.useDefaultValue = useDefaultValue;

			this.internal_Param_CantonID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_CantonID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Rang_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_Rang_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Lot_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_Lot_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_MunicipaliteID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_MunicipaliteID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Superficie_total_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_Superficie_total_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Superficie_boisee_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_Superficie_boisee_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ProprietaireID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_ProprietaireID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ContingentID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_ContingentID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Contingent_Date_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_Contingent_Date_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Droit_coupeID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_Droit_coupeID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Droit_coupe_Date_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_Droit_coupe_Date_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Entente_paiementID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_Entente_paiementID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Entente_paiement_Date_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_Entente_paiement_Date_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Actif_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_Actif_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Sequence_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_Sequence_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Partie_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_Partie_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Matricule_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_Matricule_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ZoneID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_ZoneID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Secteur_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_Secteur_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Cadastre_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_Cadastre_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Reforme_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_Reforme_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_LotsComplementaires_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_LotsComplementaires_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Certifie_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_Certifie_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_NumeroCertification_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_NumeroCertification_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_OGC_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_OGC_UseDefaultValue = this.useDefaultValue;
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
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'spU_Lot'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

						throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "spU_Lot", CurrentRevision, OriginalRevision, System.Environment.NewLine));
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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'spU_Lot'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlConnection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "spU_Lot", CurrentRevision, OriginalRevision, System.Environment.NewLine));
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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'spU_Lot'";
				sqlCommand.Transaction = sqlTransaction;

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlTransaction.Connection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "spU_Lot", CurrentRevision, OriginalRevision, System.Environment.NewLine));
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
				this.internal_Param_CantonID = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_ConsiderNull_CantonID = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Rang = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_ConsiderNull_Rang = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Lot = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_ConsiderNull_Lot = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_MunicipaliteID = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_ConsiderNull_MunicipaliteID = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Superficie_total = System.Data.SqlTypes.SqlSingle.Null;
				this.internal_Param_ConsiderNull_Superficie_total = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Superficie_boisee = System.Data.SqlTypes.SqlSingle.Null;
				this.internal_Param_ConsiderNull_Superficie_boisee = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_ProprietaireID = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_ConsiderNull_ProprietaireID = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_ContingentID = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_ConsiderNull_ContingentID = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Contingent_Date = System.Data.SqlTypes.SqlDateTime.Null;
				this.internal_Param_ConsiderNull_Contingent_Date = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Droit_coupeID = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_ConsiderNull_Droit_coupeID = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Droit_coupe_Date = System.Data.SqlTypes.SqlDateTime.Null;
				this.internal_Param_ConsiderNull_Droit_coupe_Date = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Entente_paiementID = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_ConsiderNull_Entente_paiementID = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Entente_paiement_Date = System.Data.SqlTypes.SqlDateTime.Null;
				this.internal_Param_ConsiderNull_Entente_paiement_Date = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Actif = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_ConsiderNull_Actif = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_ID = System.Data.SqlTypes.SqlInt32.Null;
				this.internal_Param_Sequence = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_ConsiderNull_Sequence = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Partie = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_ConsiderNull_Partie = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Matricule = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_ConsiderNull_Matricule = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_ZoneID = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_ConsiderNull_ZoneID = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Secteur = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_ConsiderNull_Secteur = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Cadastre = System.Data.SqlTypes.SqlInt32.Null;
				this.internal_Param_ConsiderNull_Cadastre = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Reforme = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_ConsiderNull_Reforme = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_LotsComplementaires = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_ConsiderNull_LotsComplementaires = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Certifie = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_ConsiderNull_Certifie = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_NumeroCertification = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_ConsiderNull_NumeroCertification = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_OGC = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_ConsiderNull_OGC = System.Data.SqlTypes.SqlBoolean.Null;

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
		~spU_Lot() {

			Dispose(false);
		}

		/// <summary>
		/// Returns the stored procedure name for which this class was built, i.e. 'spU_Lot'.
		/// </summary>
		public string StoredProcedureName {

			get {

				return("spU_Lot");
			}
		}

		private System.Data.SqlTypes.SqlInt32 internal_Param_RETURN_VALUE;

		private System.Data.SqlTypes.SqlString internal_Param_CantonID;
		internal bool internal_Param_CantonID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_CantonID;
		internal bool internal_Param_ConsiderNull_CantonID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_Rang;
		internal bool internal_Param_Rang_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_Rang;
		internal bool internal_Param_ConsiderNull_Rang_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_Lot;
		internal bool internal_Param_Lot_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_Lot;
		internal bool internal_Param_ConsiderNull_Lot_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_MunicipaliteID;
		internal bool internal_Param_MunicipaliteID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_MunicipaliteID;
		internal bool internal_Param_ConsiderNull_MunicipaliteID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlSingle internal_Param_Superficie_total;
		internal bool internal_Param_Superficie_total_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_Superficie_total;
		internal bool internal_Param_ConsiderNull_Superficie_total_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlSingle internal_Param_Superficie_boisee;
		internal bool internal_Param_Superficie_boisee_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_Superficie_boisee;
		internal bool internal_Param_ConsiderNull_Superficie_boisee_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_ProprietaireID;
		internal bool internal_Param_ProprietaireID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_ProprietaireID;
		internal bool internal_Param_ConsiderNull_ProprietaireID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_ContingentID;
		internal bool internal_Param_ContingentID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_ContingentID;
		internal bool internal_Param_ConsiderNull_ContingentID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlDateTime internal_Param_Contingent_Date;
		internal bool internal_Param_Contingent_Date_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_Contingent_Date;
		internal bool internal_Param_ConsiderNull_Contingent_Date_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_Droit_coupeID;
		internal bool internal_Param_Droit_coupeID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_Droit_coupeID;
		internal bool internal_Param_ConsiderNull_Droit_coupeID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlDateTime internal_Param_Droit_coupe_Date;
		internal bool internal_Param_Droit_coupe_Date_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_Droit_coupe_Date;
		internal bool internal_Param_ConsiderNull_Droit_coupe_Date_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_Entente_paiementID;
		internal bool internal_Param_Entente_paiementID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_Entente_paiementID;
		internal bool internal_Param_ConsiderNull_Entente_paiementID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlDateTime internal_Param_Entente_paiement_Date;
		internal bool internal_Param_Entente_paiement_Date_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_Entente_paiement_Date;
		internal bool internal_Param_ConsiderNull_Entente_paiement_Date_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_Actif;
		internal bool internal_Param_Actif_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_Actif;
		internal bool internal_Param_ConsiderNull_Actif_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlInt32 internal_Param_ID;
		internal bool internal_Param_ID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_Sequence;
		internal bool internal_Param_Sequence_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_Sequence;
		internal bool internal_Param_ConsiderNull_Sequence_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_Partie;
		internal bool internal_Param_Partie_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_Partie;
		internal bool internal_Param_ConsiderNull_Partie_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_Matricule;
		internal bool internal_Param_Matricule_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_Matricule;
		internal bool internal_Param_ConsiderNull_Matricule_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_ZoneID;
		internal bool internal_Param_ZoneID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_ZoneID;
		internal bool internal_Param_ConsiderNull_ZoneID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_Secteur;
		internal bool internal_Param_Secteur_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_Secteur;
		internal bool internal_Param_ConsiderNull_Secteur_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlInt32 internal_Param_Cadastre;
		internal bool internal_Param_Cadastre_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_Cadastre;
		internal bool internal_Param_ConsiderNull_Cadastre_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_Reforme;
		internal bool internal_Param_Reforme_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_Reforme;
		internal bool internal_Param_ConsiderNull_Reforme_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_LotsComplementaires;
		internal bool internal_Param_LotsComplementaires_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_LotsComplementaires;
		internal bool internal_Param_ConsiderNull_LotsComplementaires_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_Certifie;
		internal bool internal_Param_Certifie_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_Certifie;
		internal bool internal_Param_ConsiderNull_Certifie_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_NumeroCertification;
		internal bool internal_Param_NumeroCertification_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_NumeroCertification;
		internal bool internal_Param_ConsiderNull_NumeroCertification_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_OGC;
		internal bool internal_Param_OGC_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_OGC;
		internal bool internal_Param_ConsiderNull_OGC_UseDefaultValue = true;


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

			this.internal_Param_CantonID = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_CantonID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_CantonID = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_CantonID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Rang = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_Rang_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_Rang = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_Rang_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Lot = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_Lot_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_Lot = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_Lot_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_MunicipaliteID = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_MunicipaliteID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_MunicipaliteID = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_MunicipaliteID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Superficie_total = System.Data.SqlTypes.SqlSingle.Null;
			this.internal_Param_Superficie_total_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_Superficie_total = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_Superficie_total_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Superficie_boisee = System.Data.SqlTypes.SqlSingle.Null;
			this.internal_Param_Superficie_boisee_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_Superficie_boisee = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_Superficie_boisee_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ProprietaireID = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_ProprietaireID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_ProprietaireID = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_ProprietaireID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ContingentID = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_ContingentID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_ContingentID = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_ContingentID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Contingent_Date = System.Data.SqlTypes.SqlDateTime.Null;
			this.internal_Param_Contingent_Date_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_Contingent_Date = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_Contingent_Date_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Droit_coupeID = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_Droit_coupeID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_Droit_coupeID = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_Droit_coupeID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Droit_coupe_Date = System.Data.SqlTypes.SqlDateTime.Null;
			this.internal_Param_Droit_coupe_Date_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_Droit_coupe_Date = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_Droit_coupe_Date_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Entente_paiementID = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_Entente_paiementID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_Entente_paiementID = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_Entente_paiementID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Entente_paiement_Date = System.Data.SqlTypes.SqlDateTime.Null;
			this.internal_Param_Entente_paiement_Date_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_Entente_paiement_Date = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_Entente_paiement_Date_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Actif = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_Actif_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_Actif = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_Actif_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ID = System.Data.SqlTypes.SqlInt32.Null;
			this.internal_Param_ID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Sequence = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_Sequence_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_Sequence = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_Sequence_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Partie = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_Partie_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_Partie = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_Partie_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Matricule = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_Matricule_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_Matricule = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_Matricule_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ZoneID = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_ZoneID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_ZoneID = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_ZoneID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Secteur = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_Secteur_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_Secteur = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_Secteur_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Cadastre = System.Data.SqlTypes.SqlInt32.Null;
			this.internal_Param_Cadastre_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_Cadastre = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_Cadastre_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Reforme = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_Reforme_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_Reforme = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_Reforme_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_LotsComplementaires = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_LotsComplementaires_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_LotsComplementaires = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_LotsComplementaires_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Certifie = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_Certifie_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_Certifie = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_Certifie_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_NumeroCertification = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_NumeroCertification_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_NumeroCertification = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_NumeroCertification_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_OGC = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_OGC_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_OGC = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_OGC_UseDefaultValue = this.useDefaultValue;

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
		/// Sets the value of the stored procedure INPUT parameter '@CantonID'.
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
		/// the parameter default value, consider calling the Param_CantonID_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_CantonID {

			get {

				if (this.internal_Param_CantonID_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_CantonID);
			}

			set {

				this.internal_Param_CantonID_UseDefaultValue = false;
				this.internal_Param_CantonID = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@CantonID' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_CantonID_UseDefaultValue() {

			this.internal_Param_CantonID_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_CantonID'.
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
		/// the parameter default value, consider calling the Param_ConsiderNull_CantonID_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_CantonID {

			get {

				if (this.internal_Param_ConsiderNull_CantonID_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_CantonID);
			}

			set {

				this.internal_Param_ConsiderNull_CantonID_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_CantonID = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_CantonID' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_CantonID_UseDefaultValue() {

			this.internal_Param_ConsiderNull_CantonID_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Rang'.
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
		/// the parameter default value, consider calling the Param_Rang_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_Rang {

			get {

				if (this.internal_Param_Rang_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Rang);
			}

			set {

				this.internal_Param_Rang_UseDefaultValue = false;
				this.internal_Param_Rang = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Rang' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Rang_UseDefaultValue() {

			this.internal_Param_Rang_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_Rang'.
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
		/// the parameter default value, consider calling the Param_ConsiderNull_Rang_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_Rang {

			get {

				if (this.internal_Param_ConsiderNull_Rang_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_Rang);
			}

			set {

				this.internal_Param_ConsiderNull_Rang_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_Rang = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_Rang' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_Rang_UseDefaultValue() {

			this.internal_Param_ConsiderNull_Rang_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Lot'.
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
		/// the parameter default value, consider calling the Param_Lot_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_Lot {

			get {

				if (this.internal_Param_Lot_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Lot);
			}

			set {

				this.internal_Param_Lot_UseDefaultValue = false;
				this.internal_Param_Lot = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Lot' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Lot_UseDefaultValue() {

			this.internal_Param_Lot_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_Lot'.
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
		/// the parameter default value, consider calling the Param_ConsiderNull_Lot_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_Lot {

			get {

				if (this.internal_Param_ConsiderNull_Lot_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_Lot);
			}

			set {

				this.internal_Param_ConsiderNull_Lot_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_Lot = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_Lot' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_Lot_UseDefaultValue() {

			this.internal_Param_ConsiderNull_Lot_UseDefaultValue = true;
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
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_MunicipaliteID'.
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
		/// the parameter default value, consider calling the Param_ConsiderNull_MunicipaliteID_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_MunicipaliteID {

			get {

				if (this.internal_Param_ConsiderNull_MunicipaliteID_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_MunicipaliteID);
			}

			set {

				this.internal_Param_ConsiderNull_MunicipaliteID_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_MunicipaliteID = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_MunicipaliteID' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_MunicipaliteID_UseDefaultValue() {

			this.internal_Param_ConsiderNull_MunicipaliteID_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Superficie_total'.
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
		/// the parameter default value, consider calling the Param_Superficie_total_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlSingle Param_Superficie_total {

			get {

				if (this.internal_Param_Superficie_total_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Superficie_total);
			}

			set {

				this.internal_Param_Superficie_total_UseDefaultValue = false;
				this.internal_Param_Superficie_total = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Superficie_total' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Superficie_total_UseDefaultValue() {

			this.internal_Param_Superficie_total_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_Superficie_total'.
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
		/// the parameter default value, consider calling the Param_ConsiderNull_Superficie_total_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_Superficie_total {

			get {

				if (this.internal_Param_ConsiderNull_Superficie_total_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_Superficie_total);
			}

			set {

				this.internal_Param_ConsiderNull_Superficie_total_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_Superficie_total = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_Superficie_total' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_Superficie_total_UseDefaultValue() {

			this.internal_Param_ConsiderNull_Superficie_total_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Superficie_boisee'.
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
		/// the parameter default value, consider calling the Param_Superficie_boisee_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlSingle Param_Superficie_boisee {

			get {

				if (this.internal_Param_Superficie_boisee_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Superficie_boisee);
			}

			set {

				this.internal_Param_Superficie_boisee_UseDefaultValue = false;
				this.internal_Param_Superficie_boisee = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Superficie_boisee' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Superficie_boisee_UseDefaultValue() {

			this.internal_Param_Superficie_boisee_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_Superficie_boisee'.
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
		/// the parameter default value, consider calling the Param_ConsiderNull_Superficie_boisee_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_Superficie_boisee {

			get {

				if (this.internal_Param_ConsiderNull_Superficie_boisee_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_Superficie_boisee);
			}

			set {

				this.internal_Param_ConsiderNull_Superficie_boisee_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_Superficie_boisee = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_Superficie_boisee' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_Superficie_boisee_UseDefaultValue() {

			this.internal_Param_ConsiderNull_Superficie_boisee_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ProprietaireID'.
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
		/// the parameter default value, consider calling the Param_ProprietaireID_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_ProprietaireID {

			get {

				if (this.internal_Param_ProprietaireID_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ProprietaireID);
			}

			set {

				this.internal_Param_ProprietaireID_UseDefaultValue = false;
				this.internal_Param_ProprietaireID = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ProprietaireID' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ProprietaireID_UseDefaultValue() {

			this.internal_Param_ProprietaireID_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_ProprietaireID'.
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
		/// the parameter default value, consider calling the Param_ConsiderNull_ProprietaireID_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_ProprietaireID {

			get {

				if (this.internal_Param_ConsiderNull_ProprietaireID_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_ProprietaireID);
			}

			set {

				this.internal_Param_ConsiderNull_ProprietaireID_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_ProprietaireID = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_ProprietaireID' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_ProprietaireID_UseDefaultValue() {

			this.internal_Param_ConsiderNull_ProprietaireID_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ContingentID'.
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
		/// the parameter default value, consider calling the Param_ContingentID_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_ContingentID {

			get {

				if (this.internal_Param_ContingentID_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ContingentID);
			}

			set {

				this.internal_Param_ContingentID_UseDefaultValue = false;
				this.internal_Param_ContingentID = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ContingentID' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ContingentID_UseDefaultValue() {

			this.internal_Param_ContingentID_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_ContingentID'.
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
		/// the parameter default value, consider calling the Param_ConsiderNull_ContingentID_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_ContingentID {

			get {

				if (this.internal_Param_ConsiderNull_ContingentID_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_ContingentID);
			}

			set {

				this.internal_Param_ConsiderNull_ContingentID_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_ContingentID = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_ContingentID' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_ContingentID_UseDefaultValue() {

			this.internal_Param_ConsiderNull_ContingentID_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Contingent_Date'.
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
		/// the parameter default value, consider calling the Param_Contingent_Date_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlDateTime Param_Contingent_Date {

			get {

				if (this.internal_Param_Contingent_Date_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Contingent_Date);
			}

			set {

				this.internal_Param_Contingent_Date_UseDefaultValue = false;
				this.internal_Param_Contingent_Date = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Contingent_Date' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Contingent_Date_UseDefaultValue() {

			this.internal_Param_Contingent_Date_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_Contingent_Date'.
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
		/// the parameter default value, consider calling the Param_ConsiderNull_Contingent_Date_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_Contingent_Date {

			get {

				if (this.internal_Param_ConsiderNull_Contingent_Date_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_Contingent_Date);
			}

			set {

				this.internal_Param_ConsiderNull_Contingent_Date_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_Contingent_Date = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_Contingent_Date' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_Contingent_Date_UseDefaultValue() {

			this.internal_Param_ConsiderNull_Contingent_Date_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Droit_coupeID'.
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
		/// the parameter default value, consider calling the Param_Droit_coupeID_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_Droit_coupeID {

			get {

				if (this.internal_Param_Droit_coupeID_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Droit_coupeID);
			}

			set {

				this.internal_Param_Droit_coupeID_UseDefaultValue = false;
				this.internal_Param_Droit_coupeID = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Droit_coupeID' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Droit_coupeID_UseDefaultValue() {

			this.internal_Param_Droit_coupeID_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_Droit_coupeID'.
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
		/// the parameter default value, consider calling the Param_ConsiderNull_Droit_coupeID_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_Droit_coupeID {

			get {

				if (this.internal_Param_ConsiderNull_Droit_coupeID_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_Droit_coupeID);
			}

			set {

				this.internal_Param_ConsiderNull_Droit_coupeID_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_Droit_coupeID = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_Droit_coupeID' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_Droit_coupeID_UseDefaultValue() {

			this.internal_Param_ConsiderNull_Droit_coupeID_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Droit_coupe_Date'.
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
		/// the parameter default value, consider calling the Param_Droit_coupe_Date_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlDateTime Param_Droit_coupe_Date {

			get {

				if (this.internal_Param_Droit_coupe_Date_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Droit_coupe_Date);
			}

			set {

				this.internal_Param_Droit_coupe_Date_UseDefaultValue = false;
				this.internal_Param_Droit_coupe_Date = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Droit_coupe_Date' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Droit_coupe_Date_UseDefaultValue() {

			this.internal_Param_Droit_coupe_Date_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_Droit_coupe_Date'.
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
		/// the parameter default value, consider calling the Param_ConsiderNull_Droit_coupe_Date_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_Droit_coupe_Date {

			get {

				if (this.internal_Param_ConsiderNull_Droit_coupe_Date_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_Droit_coupe_Date);
			}

			set {

				this.internal_Param_ConsiderNull_Droit_coupe_Date_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_Droit_coupe_Date = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_Droit_coupe_Date' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_Droit_coupe_Date_UseDefaultValue() {

			this.internal_Param_ConsiderNull_Droit_coupe_Date_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Entente_paiementID'.
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
		/// the parameter default value, consider calling the Param_Entente_paiementID_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_Entente_paiementID {

			get {

				if (this.internal_Param_Entente_paiementID_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Entente_paiementID);
			}

			set {

				this.internal_Param_Entente_paiementID_UseDefaultValue = false;
				this.internal_Param_Entente_paiementID = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Entente_paiementID' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Entente_paiementID_UseDefaultValue() {

			this.internal_Param_Entente_paiementID_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_Entente_paiementID'.
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
		/// the parameter default value, consider calling the Param_ConsiderNull_Entente_paiementID_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_Entente_paiementID {

			get {

				if (this.internal_Param_ConsiderNull_Entente_paiementID_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_Entente_paiementID);
			}

			set {

				this.internal_Param_ConsiderNull_Entente_paiementID_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_Entente_paiementID = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_Entente_paiementID' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_Entente_paiementID_UseDefaultValue() {

			this.internal_Param_ConsiderNull_Entente_paiementID_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Entente_paiement_Date'.
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
		/// the parameter default value, consider calling the Param_Entente_paiement_Date_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlDateTime Param_Entente_paiement_Date {

			get {

				if (this.internal_Param_Entente_paiement_Date_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Entente_paiement_Date);
			}

			set {

				this.internal_Param_Entente_paiement_Date_UseDefaultValue = false;
				this.internal_Param_Entente_paiement_Date = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Entente_paiement_Date' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Entente_paiement_Date_UseDefaultValue() {

			this.internal_Param_Entente_paiement_Date_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_Entente_paiement_Date'.
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
		/// the parameter default value, consider calling the Param_ConsiderNull_Entente_paiement_Date_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_Entente_paiement_Date {

			get {

				if (this.internal_Param_ConsiderNull_Entente_paiement_Date_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_Entente_paiement_Date);
			}

			set {

				this.internal_Param_ConsiderNull_Entente_paiement_Date_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_Entente_paiement_Date = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_Entente_paiement_Date' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_Entente_paiement_Date_UseDefaultValue() {

			this.internal_Param_ConsiderNull_Entente_paiement_Date_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Actif'.
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
		/// the parameter default value, consider calling the Param_Actif_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_Actif {

			get {

				if (this.internal_Param_Actif_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Actif);
			}

			set {

				this.internal_Param_Actif_UseDefaultValue = false;
				this.internal_Param_Actif = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Actif' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Actif_UseDefaultValue() {

			this.internal_Param_Actif_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_Actif'.
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
		/// the parameter default value, consider calling the Param_ConsiderNull_Actif_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_Actif {

			get {

				if (this.internal_Param_ConsiderNull_Actif_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_Actif);
			}

			set {

				this.internal_Param_ConsiderNull_Actif_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_Actif = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_Actif' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_Actif_UseDefaultValue() {

			this.internal_Param_ConsiderNull_Actif_UseDefaultValue = true;
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
		/// Sets the value of the stored procedure INPUT parameter '@Sequence'.
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
		/// the parameter default value, consider calling the Param_Sequence_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_Sequence {

			get {

				if (this.internal_Param_Sequence_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Sequence);
			}

			set {

				this.internal_Param_Sequence_UseDefaultValue = false;
				this.internal_Param_Sequence = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Sequence' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Sequence_UseDefaultValue() {

			this.internal_Param_Sequence_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_Sequence'.
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
		/// the parameter default value, consider calling the Param_ConsiderNull_Sequence_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_Sequence {

			get {

				if (this.internal_Param_ConsiderNull_Sequence_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_Sequence);
			}

			set {

				this.internal_Param_ConsiderNull_Sequence_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_Sequence = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_Sequence' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_Sequence_UseDefaultValue() {

			this.internal_Param_ConsiderNull_Sequence_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Partie'.
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
		/// the parameter default value, consider calling the Param_Partie_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_Partie {

			get {

				if (this.internal_Param_Partie_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Partie);
			}

			set {

				this.internal_Param_Partie_UseDefaultValue = false;
				this.internal_Param_Partie = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Partie' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Partie_UseDefaultValue() {

			this.internal_Param_Partie_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_Partie'.
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
		/// the parameter default value, consider calling the Param_ConsiderNull_Partie_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_Partie {

			get {

				if (this.internal_Param_ConsiderNull_Partie_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_Partie);
			}

			set {

				this.internal_Param_ConsiderNull_Partie_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_Partie = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_Partie' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_Partie_UseDefaultValue() {

			this.internal_Param_ConsiderNull_Partie_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Matricule'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [varchar](20)
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_Matricule_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_Matricule {

			get {

				if (this.internal_Param_Matricule_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Matricule);
			}

			set {

				this.internal_Param_Matricule_UseDefaultValue = false;
				this.internal_Param_Matricule = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Matricule' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Matricule_UseDefaultValue() {

			this.internal_Param_Matricule_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_Matricule'.
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
		/// the parameter default value, consider calling the Param_ConsiderNull_Matricule_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_Matricule {

			get {

				if (this.internal_Param_ConsiderNull_Matricule_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_Matricule);
			}

			set {

				this.internal_Param_ConsiderNull_Matricule_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_Matricule = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_Matricule' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_Matricule_UseDefaultValue() {

			this.internal_Param_ConsiderNull_Matricule_UseDefaultValue = true;
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
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_ZoneID'.
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
		/// the parameter default value, consider calling the Param_ConsiderNull_ZoneID_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_ZoneID {

			get {

				if (this.internal_Param_ConsiderNull_ZoneID_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_ZoneID);
			}

			set {

				this.internal_Param_ConsiderNull_ZoneID_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_ZoneID = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_ZoneID' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_ZoneID_UseDefaultValue() {

			this.internal_Param_ConsiderNull_ZoneID_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Secteur'.
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
		/// the parameter default value, consider calling the Param_Secteur_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_Secteur {

			get {

				if (this.internal_Param_Secteur_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Secteur);
			}

			set {

				this.internal_Param_Secteur_UseDefaultValue = false;
				this.internal_Param_Secteur = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Secteur' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Secteur_UseDefaultValue() {

			this.internal_Param_Secteur_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_Secteur'.
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
		/// the parameter default value, consider calling the Param_ConsiderNull_Secteur_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_Secteur {

			get {

				if (this.internal_Param_ConsiderNull_Secteur_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_Secteur);
			}

			set {

				this.internal_Param_ConsiderNull_Secteur_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_Secteur = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_Secteur' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_Secteur_UseDefaultValue() {

			this.internal_Param_ConsiderNull_Secteur_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Cadastre'.
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
		/// the parameter default value, consider calling the Param_Cadastre_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlInt32 Param_Cadastre {

			get {

				if (this.internal_Param_Cadastre_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Cadastre);
			}

			set {

				this.internal_Param_Cadastre_UseDefaultValue = false;
				this.internal_Param_Cadastre = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Cadastre' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Cadastre_UseDefaultValue() {

			this.internal_Param_Cadastre_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_Cadastre'.
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
		/// the parameter default value, consider calling the Param_ConsiderNull_Cadastre_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_Cadastre {

			get {

				if (this.internal_Param_ConsiderNull_Cadastre_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_Cadastre);
			}

			set {

				this.internal_Param_ConsiderNull_Cadastre_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_Cadastre = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_Cadastre' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_Cadastre_UseDefaultValue() {

			this.internal_Param_ConsiderNull_Cadastre_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Reforme'.
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
		/// the parameter default value, consider calling the Param_Reforme_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_Reforme {

			get {

				if (this.internal_Param_Reforme_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Reforme);
			}

			set {

				this.internal_Param_Reforme_UseDefaultValue = false;
				this.internal_Param_Reforme = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Reforme' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Reforme_UseDefaultValue() {

			this.internal_Param_Reforme_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_Reforme'.
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
		/// the parameter default value, consider calling the Param_ConsiderNull_Reforme_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_Reforme {

			get {

				if (this.internal_Param_ConsiderNull_Reforme_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_Reforme);
			}

			set {

				this.internal_Param_ConsiderNull_Reforme_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_Reforme = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_Reforme' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_Reforme_UseDefaultValue() {

			this.internal_Param_ConsiderNull_Reforme_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@LotsComplementaires'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [varchar](255)
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_LotsComplementaires_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_LotsComplementaires {

			get {

				if (this.internal_Param_LotsComplementaires_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_LotsComplementaires);
			}

			set {

				this.internal_Param_LotsComplementaires_UseDefaultValue = false;
				this.internal_Param_LotsComplementaires = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@LotsComplementaires' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_LotsComplementaires_UseDefaultValue() {

			this.internal_Param_LotsComplementaires_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_LotsComplementaires'.
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
		/// the parameter default value, consider calling the Param_ConsiderNull_LotsComplementaires_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_LotsComplementaires {

			get {

				if (this.internal_Param_ConsiderNull_LotsComplementaires_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_LotsComplementaires);
			}

			set {

				this.internal_Param_ConsiderNull_LotsComplementaires_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_LotsComplementaires = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_LotsComplementaires' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_LotsComplementaires_UseDefaultValue() {

			this.internal_Param_ConsiderNull_LotsComplementaires_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Certifie'.
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
		/// the parameter default value, consider calling the Param_Certifie_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_Certifie {

			get {

				if (this.internal_Param_Certifie_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Certifie);
			}

			set {

				this.internal_Param_Certifie_UseDefaultValue = false;
				this.internal_Param_Certifie = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Certifie' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Certifie_UseDefaultValue() {

			this.internal_Param_Certifie_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_Certifie'.
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
		/// the parameter default value, consider calling the Param_ConsiderNull_Certifie_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_Certifie {

			get {

				if (this.internal_Param_ConsiderNull_Certifie_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_Certifie);
			}

			set {

				this.internal_Param_ConsiderNull_Certifie_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_Certifie = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_Certifie' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_Certifie_UseDefaultValue() {

			this.internal_Param_ConsiderNull_Certifie_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@NumeroCertification'.
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
		/// the parameter default value, consider calling the Param_NumeroCertification_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_NumeroCertification {

			get {

				if (this.internal_Param_NumeroCertification_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_NumeroCertification);
			}

			set {

				this.internal_Param_NumeroCertification_UseDefaultValue = false;
				this.internal_Param_NumeroCertification = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@NumeroCertification' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_NumeroCertification_UseDefaultValue() {

			this.internal_Param_NumeroCertification_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_NumeroCertification'.
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
		/// the parameter default value, consider calling the Param_ConsiderNull_NumeroCertification_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_NumeroCertification {

			get {

				if (this.internal_Param_ConsiderNull_NumeroCertification_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_NumeroCertification);
			}

			set {

				this.internal_Param_ConsiderNull_NumeroCertification_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_NumeroCertification = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_NumeroCertification' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_NumeroCertification_UseDefaultValue() {

			this.internal_Param_ConsiderNull_NumeroCertification_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@OGC'.
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
		/// the parameter default value, consider calling the Param_OGC_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_OGC {

			get {

				if (this.internal_Param_OGC_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_OGC);
			}

			set {

				this.internal_Param_OGC_UseDefaultValue = false;
				this.internal_Param_OGC = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@OGC' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_OGC_UseDefaultValue() {

			this.internal_Param_OGC_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_OGC'.
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
		/// the parameter default value, consider calling the Param_ConsiderNull_OGC_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_OGC {

			get {

				if (this.internal_Param_ConsiderNull_OGC_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_OGC);
			}

			set {

				this.internal_Param_ConsiderNull_OGC_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_OGC = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_OGC' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_OGC_UseDefaultValue() {

			this.internal_Param_ConsiderNull_OGC_UseDefaultValue = true;
		}

  	}
}

namespace Gestion_Paie.DataClasses.StoredProcedures {

	/// <summary>
	/// This class allows you to execute the 'spU_Lot' stored procedure;
	/// it gives you the ability to:
	/// <list type="bullet">
	/// <item><description>Set all the necessary parameters to execute the stored procedure</description></item>
	/// <item><description>To execute the stored procedure</description></item>
	/// <item><description>To get back after the execution the return value and all the output parameters value</description></item>
	/// </list>
	/// </summary>
	public sealed class spU_Lot : MarshalByRefObject, IDisposable {


		private bool throwExceptionOnExecute = false;

		/// <summary>
		/// Initializes a new instance of the spU_Lot class.
		/// By default, no exception will be thrown when you call the Execute method. Instead, a Boolean return status will be returned.
		/// </summary>
		public spU_Lot() : this(false) {

		}

		/// <summary>
		/// Initializes a new instance of the spU_Lot class.
		/// </summary>
		/// <param name="throwExceptionOnExecute">True if an exception has to be thrown if the Execute call fails.</param>
		public spU_Lot(bool throwExceptionOnExecute) {

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
		~spU_Lot() {

			Dispose(false);
		}

		private void ResetParameter(ref Gestion_Paie.DataClasses.Parameters.spU_Lot parameters) {

			parameters.internal_Set_RETURN_VALUE (System.Data.SqlTypes.SqlInt32.Null);
		}

		private bool InitializeConnection(ref Gestion_Paie.DataClasses.Parameters.spU_Lot parameters, out System.Data.SqlClient.SqlCommand sqlCommand, ref bool connectionMustBeClosed) {

			try {

				this.sqlConnection = null;
				sqlCommand = null;
				connectionMustBeClosed = true;

				if (parameters.ConnectionType == ConnectionType.None) {

					throw new InvalidOperationException("No connection information was supplied. Consider calling the 'SetUpConnection' method of the Gestion_Paie.DataClasses.Parameters.spU_Lot object before doing this call.");
				}

				if (parameters.ConnectionType == ConnectionType.SqlConnection && parameters.SqlConnection == null) {

					throw new InvalidOperationException("No connection information was supplied (SqlConnection == null). Consider calling the 'SetUpConnection' method of the Gestion_Paie.DataClasses.Parameters.spU_Lot object before doing this call.");
				}

				if (parameters.ConnectionType == ConnectionType.SqlTransaction && parameters.SqlTransaction== null) {

					throw new InvalidOperationException("No connection information was supplied (SqlTransaction == null). Consider calling the 'SetUpConnection' method of the Gestion_Paie.DataClasses.Parameters.spU_Lot object before doing this call.");
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

							throw new System.InvalidOperationException("No connection information was supplied (ConnectionString == \"\")! (Gestion_Paie.DataClasses.Parameters.spU_Lot)");
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
				sqlCommand.CommandText = "spU_Lot";

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

		private bool DeclareParameters(ref Gestion_Paie.DataClasses.Parameters.spU_Lot parameters, ref System.Data.SqlClient.SqlCommand sqlCommand) {

			try {

				System.Data.SqlClient.SqlParameter sqlParameter;

				sqlParameter = new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4);
				sqlParameter.Direction = System.Data.ParameterDirection.ReturnValue;
				sqlParameter.IsNullable = true;
				sqlParameter.Value = System.DBNull.Value;
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@CantonID", System.Data.SqlDbType.VarChar, 6);
				sqlParameter.SourceColumn = "CantonID";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_CantonID_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_CantonID.IsNull) {

					sqlParameter.Value = parameters.Param_CantonID;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_CantonID", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_CantonID_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_CantonID.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_CantonID;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Rang", System.Data.SqlDbType.VarChar, 25);
				sqlParameter.SourceColumn = "Rang";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Rang_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Rang.IsNull) {

					sqlParameter.Value = parameters.Param_Rang;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Rang", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_Rang_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_Rang.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_Rang;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Lot", System.Data.SqlDbType.VarChar, 6);
				sqlParameter.SourceColumn = "Lot";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Lot_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Lot.IsNull) {

					sqlParameter.Value = parameters.Param_Lot;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Lot", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_Lot_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_Lot.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_Lot;
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

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_MunicipaliteID", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_MunicipaliteID_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_MunicipaliteID.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_MunicipaliteID;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Superficie_total", System.Data.SqlDbType.Real, 4);
				sqlParameter.SourceColumn = "Superficie_total";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Superficie_total_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Superficie_total.IsNull) {

					sqlParameter.Value = parameters.Param_Superficie_total;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Superficie_total", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_Superficie_total_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_Superficie_total.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_Superficie_total;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Superficie_boisee", System.Data.SqlDbType.Real, 4);
				sqlParameter.SourceColumn = "Superficie_boisee";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Superficie_boisee_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Superficie_boisee.IsNull) {

					sqlParameter.Value = parameters.Param_Superficie_boisee;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Superficie_boisee", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_Superficie_boisee_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_Superficie_boisee.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_Superficie_boisee;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ProprietaireID", System.Data.SqlDbType.VarChar, 15);
				sqlParameter.SourceColumn = "ProprietaireID";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ProprietaireID_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ProprietaireID.IsNull) {

					sqlParameter.Value = parameters.Param_ProprietaireID;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_ProprietaireID", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_ProprietaireID_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_ProprietaireID.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_ProprietaireID;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ContingentID", System.Data.SqlDbType.VarChar, 15);
				sqlParameter.SourceColumn = "ContingentID";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ContingentID_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ContingentID.IsNull) {

					sqlParameter.Value = parameters.Param_ContingentID;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_ContingentID", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_ContingentID_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_ContingentID.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_ContingentID;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Contingent_Date", System.Data.SqlDbType.SmallDateTime, 16);
				sqlParameter.SourceColumn = "Contingent_Date";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Contingent_Date_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Contingent_Date.IsNull) {

					sqlParameter.Value = parameters.Param_Contingent_Date;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Contingent_Date", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_Contingent_Date_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_Contingent_Date.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_Contingent_Date;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Droit_coupeID", System.Data.SqlDbType.VarChar, 15);
				sqlParameter.SourceColumn = "Droit_coupeID";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Droit_coupeID_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Droit_coupeID.IsNull) {

					sqlParameter.Value = parameters.Param_Droit_coupeID;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Droit_coupeID", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_Droit_coupeID_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_Droit_coupeID.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_Droit_coupeID;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Droit_coupe_Date", System.Data.SqlDbType.SmallDateTime, 16);
				sqlParameter.SourceColumn = "Droit_coupe_Date";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Droit_coupe_Date_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Droit_coupe_Date.IsNull) {

					sqlParameter.Value = parameters.Param_Droit_coupe_Date;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Droit_coupe_Date", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_Droit_coupe_Date_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_Droit_coupe_Date.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_Droit_coupe_Date;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Entente_paiementID", System.Data.SqlDbType.VarChar, 15);
				sqlParameter.SourceColumn = "Entente_paiementID";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Entente_paiementID_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Entente_paiementID.IsNull) {

					sqlParameter.Value = parameters.Param_Entente_paiementID;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Entente_paiementID", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_Entente_paiementID_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_Entente_paiementID.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_Entente_paiementID;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Entente_paiement_Date", System.Data.SqlDbType.SmallDateTime, 16);
				sqlParameter.SourceColumn = "Entente_paiement_Date";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Entente_paiement_Date_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Entente_paiement_Date.IsNull) {

					sqlParameter.Value = parameters.Param_Entente_paiement_Date;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Entente_paiement_Date", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_Entente_paiement_Date_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_Entente_paiement_Date.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_Entente_paiement_Date;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Actif", System.Data.SqlDbType.Bit, 1);
				sqlParameter.SourceColumn = "Actif";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Actif_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Actif.IsNull) {

					sqlParameter.Value = parameters.Param_Actif;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Actif", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_Actif_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_Actif.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_Actif;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
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

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Sequence", System.Data.SqlDbType.VarChar, 6);
				sqlParameter.SourceColumn = "Sequence";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Sequence_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Sequence.IsNull) {

					sqlParameter.Value = parameters.Param_Sequence;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Sequence", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_Sequence_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_Sequence.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_Sequence;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Partie", System.Data.SqlDbType.Bit, 1);
				sqlParameter.SourceColumn = "Partie";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Partie_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Partie.IsNull) {

					sqlParameter.Value = parameters.Param_Partie;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Partie", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_Partie_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_Partie.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_Partie;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Matricule", System.Data.SqlDbType.VarChar, 20);
				sqlParameter.SourceColumn = "Matricule";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Matricule_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Matricule.IsNull) {

					sqlParameter.Value = parameters.Param_Matricule;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Matricule", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_Matricule_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_Matricule.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_Matricule;
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

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_ZoneID", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_ZoneID_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_ZoneID.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_ZoneID;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Secteur", System.Data.SqlDbType.VarChar, 2);
				sqlParameter.SourceColumn = "Secteur";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Secteur_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Secteur.IsNull) {

					sqlParameter.Value = parameters.Param_Secteur;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Secteur", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_Secteur_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_Secteur.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_Secteur;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Cadastre", System.Data.SqlDbType.Int, 4);
				sqlParameter.SourceColumn = "Cadastre";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Cadastre_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Cadastre.IsNull) {

					sqlParameter.Value = parameters.Param_Cadastre;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Cadastre", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_Cadastre_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_Cadastre.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_Cadastre;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Reforme", System.Data.SqlDbType.Bit, 1);
				sqlParameter.SourceColumn = "Reforme";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Reforme_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Reforme.IsNull) {

					sqlParameter.Value = parameters.Param_Reforme;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Reforme", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_Reforme_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_Reforme.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_Reforme;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@LotsComplementaires", System.Data.SqlDbType.VarChar, 255);
				sqlParameter.SourceColumn = "LotsComplementaires";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_LotsComplementaires_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_LotsComplementaires.IsNull) {

					sqlParameter.Value = parameters.Param_LotsComplementaires;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_LotsComplementaires", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_LotsComplementaires_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_LotsComplementaires.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_LotsComplementaires;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Certifie", System.Data.SqlDbType.Bit, 1);
				sqlParameter.SourceColumn = "Certifie";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Certifie_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Certifie.IsNull) {

					sqlParameter.Value = parameters.Param_Certifie;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Certifie", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_Certifie_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_Certifie.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_Certifie;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@NumeroCertification", System.Data.SqlDbType.VarChar, 50);
				sqlParameter.SourceColumn = "NumeroCertification";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_NumeroCertification_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_NumeroCertification.IsNull) {

					sqlParameter.Value = parameters.Param_NumeroCertification;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_NumeroCertification", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_NumeroCertification_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_NumeroCertification.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_NumeroCertification;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@OGC", System.Data.SqlDbType.Bit, 1);
				sqlParameter.SourceColumn = "OGC";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_OGC_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_OGC.IsNull) {

					sqlParameter.Value = parameters.Param_OGC;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_OGC", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_OGC_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_OGC.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_OGC;
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

		private bool RetrieveParameters(ref Gestion_Paie.DataClasses.Parameters.spU_Lot parameters, ref System.Data.SqlClient.SqlCommand sqlCommand) {

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
		/// This method allows you to execute the [spU_Lot] stored procedure.
		/// </summary>
		/// <param name="parameters">
		/// Contains all the necessary information to execute correctly the stored procedure, i.e. 
		/// the database connection to use and all the necessary input parameters to be supplied
		/// for this stored procedure execution. After the execution, this object will allow you
		/// to retrieve back the stored procedure return value and all the output parameters.
		/// </param>
		/// <returns>True if the call was successful. Otherwise, it returns False.</returns>
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.spU_Lot parameters) {

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

