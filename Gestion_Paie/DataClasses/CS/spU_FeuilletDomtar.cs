using System;

namespace Gestion_Paie.DataClasses.Parameters {

	/// <summary>
	/// This class allows a developer to specify the parameters expected by the
	/// stored procedure 'spU_FeuilletDomtar'. It allows also to specify specific connection
	/// information such as the ConnectionString to be use, the command time-out and so forth.
	/// </summary>
	[Serializable()]
	public sealed class spU_FeuilletDomtar : MarshalByRefObject, IDisposable, IParameter {

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
		/// Initializes a new instance of the spU_FeuilletDomtar class. If you use this constructor version,
		/// not assigning parameter values implies using the parameter default values.
		/// </summary>
		public spU_FeuilletDomtar() : this(true) {

		}

		/// <summary>
		/// Initializes a new instance of the spU_FeuilletDomtar class.
		/// </summary>
		/// <param name="useDefaultValue">If True, this parameter indicates that "not assigning parameter values" implies "using the parameter default values". If False, this parameter indicates that "not assigning parameter values" implies "using the SQL Server Null value".</param>
		public spU_FeuilletDomtar(bool useDefaultValue) {

			this.useDefaultValue = useDefaultValue;

			this.internal_Param_Transaction_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_TransactionType_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_TransactionType_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Fournisseur_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_Fournisseur_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Contrat_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_Contrat_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Produit_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_Produit_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_DateLivraison_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_DateLivraison_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Carte_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_Carte_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_License_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_License_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Transporteur_Camion_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_Transporteur_Camion_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Producteur_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_Producteur_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Municipalite_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_Municipalite_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Brut_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_Brut_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Tare_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_Tare_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Net_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_Net_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Rejets_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_Rejets_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_KgVert_Paye_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_KgVert_Paye_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Pourcent_Sec_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_Pourcent_Sec_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_KgSec_Paye_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_KgSec_Paye_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Validation_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_Validation_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Transfert_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_Transfert_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_EssenceID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_EssenceID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_UniteID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_UniteID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Code_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_Code_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_TransporteurID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_TransporteurID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_BonCommande_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_BonCommande_UseDefaultValue = this.useDefaultValue;
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
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'spU_FeuilletDomtar'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

						throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "spU_FeuilletDomtar", CurrentRevision, OriginalRevision, System.Environment.NewLine));
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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'spU_FeuilletDomtar'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlConnection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "spU_FeuilletDomtar", CurrentRevision, OriginalRevision, System.Environment.NewLine));
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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'spU_FeuilletDomtar'";
				sqlCommand.Transaction = sqlTransaction;

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlTransaction.Connection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "spU_FeuilletDomtar", CurrentRevision, OriginalRevision, System.Environment.NewLine));
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
				this.internal_Param_Transaction = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_TransactionType = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_ConsiderNull_TransactionType = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Fournisseur = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_ConsiderNull_Fournisseur = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Contrat = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_ConsiderNull_Contrat = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Produit = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_ConsiderNull_Produit = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_DateLivraison = System.Data.SqlTypes.SqlDateTime.Null;
				this.internal_Param_ConsiderNull_DateLivraison = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Carte = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_ConsiderNull_Carte = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_License = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_ConsiderNull_License = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Transporteur_Camion = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_ConsiderNull_Transporteur_Camion = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Producteur = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_ConsiderNull_Producteur = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Municipalite = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_ConsiderNull_Municipalite = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Brut = System.Data.SqlTypes.SqlInt32.Null;
				this.internal_Param_ConsiderNull_Brut = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Tare = System.Data.SqlTypes.SqlInt32.Null;
				this.internal_Param_ConsiderNull_Tare = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Net = System.Data.SqlTypes.SqlInt32.Null;
				this.internal_Param_ConsiderNull_Net = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Rejets = System.Data.SqlTypes.SqlInt32.Null;
				this.internal_Param_ConsiderNull_Rejets = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_KgVert_Paye = System.Data.SqlTypes.SqlInt32.Null;
				this.internal_Param_ConsiderNull_KgVert_Paye = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Pourcent_Sec = System.Data.SqlTypes.SqlDouble.Null;
				this.internal_Param_ConsiderNull_Pourcent_Sec = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_KgSec_Paye = System.Data.SqlTypes.SqlInt32.Null;
				this.internal_Param_ConsiderNull_KgSec_Paye = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Validation = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_ConsiderNull_Validation = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Transfert = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_ConsiderNull_Transfert = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_EssenceID = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_ConsiderNull_EssenceID = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_UniteID = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_ConsiderNull_UniteID = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Code = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_ConsiderNull_Code = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_TransporteurID = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_ConsiderNull_TransporteurID = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_BonCommande = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_ConsiderNull_BonCommande = System.Data.SqlTypes.SqlBoolean.Null;

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
		~spU_FeuilletDomtar() {

			Dispose(false);
		}

		/// <summary>
		/// Returns the stored procedure name for which this class was built, i.e. 'spU_FeuilletDomtar'.
		/// </summary>
		public string StoredProcedureName {

			get {

				return("spU_FeuilletDomtar");
			}
		}

		private System.Data.SqlTypes.SqlInt32 internal_Param_RETURN_VALUE;

		private System.Data.SqlTypes.SqlString internal_Param_Transaction;
		internal bool internal_Param_Transaction_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_TransactionType;
		internal bool internal_Param_TransactionType_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_TransactionType;
		internal bool internal_Param_ConsiderNull_TransactionType_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_Fournisseur;
		internal bool internal_Param_Fournisseur_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_Fournisseur;
		internal bool internal_Param_ConsiderNull_Fournisseur_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_Contrat;
		internal bool internal_Param_Contrat_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_Contrat;
		internal bool internal_Param_ConsiderNull_Contrat_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_Produit;
		internal bool internal_Param_Produit_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_Produit;
		internal bool internal_Param_ConsiderNull_Produit_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlDateTime internal_Param_DateLivraison;
		internal bool internal_Param_DateLivraison_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_DateLivraison;
		internal bool internal_Param_ConsiderNull_DateLivraison_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_Carte;
		internal bool internal_Param_Carte_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_Carte;
		internal bool internal_Param_ConsiderNull_Carte_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_License;
		internal bool internal_Param_License_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_License;
		internal bool internal_Param_ConsiderNull_License_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_Transporteur_Camion;
		internal bool internal_Param_Transporteur_Camion_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_Transporteur_Camion;
		internal bool internal_Param_ConsiderNull_Transporteur_Camion_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_Producteur;
		internal bool internal_Param_Producteur_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_Producteur;
		internal bool internal_Param_ConsiderNull_Producteur_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_Municipalite;
		internal bool internal_Param_Municipalite_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_Municipalite;
		internal bool internal_Param_ConsiderNull_Municipalite_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlInt32 internal_Param_Brut;
		internal bool internal_Param_Brut_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_Brut;
		internal bool internal_Param_ConsiderNull_Brut_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlInt32 internal_Param_Tare;
		internal bool internal_Param_Tare_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_Tare;
		internal bool internal_Param_ConsiderNull_Tare_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlInt32 internal_Param_Net;
		internal bool internal_Param_Net_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_Net;
		internal bool internal_Param_ConsiderNull_Net_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlInt32 internal_Param_Rejets;
		internal bool internal_Param_Rejets_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_Rejets;
		internal bool internal_Param_ConsiderNull_Rejets_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlInt32 internal_Param_KgVert_Paye;
		internal bool internal_Param_KgVert_Paye_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_KgVert_Paye;
		internal bool internal_Param_ConsiderNull_KgVert_Paye_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlDouble internal_Param_Pourcent_Sec;
		internal bool internal_Param_Pourcent_Sec_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_Pourcent_Sec;
		internal bool internal_Param_ConsiderNull_Pourcent_Sec_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlInt32 internal_Param_KgSec_Paye;
		internal bool internal_Param_KgSec_Paye_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_KgSec_Paye;
		internal bool internal_Param_ConsiderNull_KgSec_Paye_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_Validation;
		internal bool internal_Param_Validation_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_Validation;
		internal bool internal_Param_ConsiderNull_Validation_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_Transfert;
		internal bool internal_Param_Transfert_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_Transfert;
		internal bool internal_Param_ConsiderNull_Transfert_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_EssenceID;
		internal bool internal_Param_EssenceID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_EssenceID;
		internal bool internal_Param_ConsiderNull_EssenceID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_UniteID;
		internal bool internal_Param_UniteID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_UniteID;
		internal bool internal_Param_ConsiderNull_UniteID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_Code;
		internal bool internal_Param_Code_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_Code;
		internal bool internal_Param_ConsiderNull_Code_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_TransporteurID;
		internal bool internal_Param_TransporteurID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_TransporteurID;
		internal bool internal_Param_ConsiderNull_TransporteurID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_BonCommande;
		internal bool internal_Param_BonCommande_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_BonCommande;
		internal bool internal_Param_ConsiderNull_BonCommande_UseDefaultValue = true;


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

			this.internal_Param_Transaction = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_Transaction_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_TransactionType = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_TransactionType_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_TransactionType = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_TransactionType_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Fournisseur = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_Fournisseur_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_Fournisseur = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_Fournisseur_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Contrat = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_Contrat_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_Contrat = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_Contrat_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Produit = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_Produit_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_Produit = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_Produit_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_DateLivraison = System.Data.SqlTypes.SqlDateTime.Null;
			this.internal_Param_DateLivraison_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_DateLivraison = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_DateLivraison_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Carte = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_Carte_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_Carte = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_Carte_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_License = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_License_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_License = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_License_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Transporteur_Camion = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_Transporteur_Camion_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_Transporteur_Camion = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_Transporteur_Camion_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Producteur = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_Producteur_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_Producteur = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_Producteur_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Municipalite = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_Municipalite_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_Municipalite = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_Municipalite_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Brut = System.Data.SqlTypes.SqlInt32.Null;
			this.internal_Param_Brut_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_Brut = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_Brut_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Tare = System.Data.SqlTypes.SqlInt32.Null;
			this.internal_Param_Tare_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_Tare = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_Tare_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Net = System.Data.SqlTypes.SqlInt32.Null;
			this.internal_Param_Net_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_Net = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_Net_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Rejets = System.Data.SqlTypes.SqlInt32.Null;
			this.internal_Param_Rejets_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_Rejets = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_Rejets_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_KgVert_Paye = System.Data.SqlTypes.SqlInt32.Null;
			this.internal_Param_KgVert_Paye_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_KgVert_Paye = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_KgVert_Paye_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Pourcent_Sec = System.Data.SqlTypes.SqlDouble.Null;
			this.internal_Param_Pourcent_Sec_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_Pourcent_Sec = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_Pourcent_Sec_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_KgSec_Paye = System.Data.SqlTypes.SqlInt32.Null;
			this.internal_Param_KgSec_Paye_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_KgSec_Paye = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_KgSec_Paye_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Validation = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_Validation_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_Validation = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_Validation_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Transfert = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_Transfert_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_Transfert = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_Transfert_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_EssenceID = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_EssenceID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_EssenceID = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_EssenceID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_UniteID = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_UniteID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_UniteID = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_UniteID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Code = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_Code_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_Code = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_Code_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_TransporteurID = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_TransporteurID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_TransporteurID = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_TransporteurID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_BonCommande = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_BonCommande_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_BonCommande = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_BonCommande_UseDefaultValue = this.useDefaultValue;

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
		/// Sets the value of the stored procedure INPUT parameter '@Transaction'.
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
		/// the parameter default value, consider calling the Param_Transaction_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_Transaction {

			get {

				if (this.internal_Param_Transaction_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Transaction);
			}

			set {

				this.internal_Param_Transaction_UseDefaultValue = false;
				this.internal_Param_Transaction = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Transaction' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Transaction_UseDefaultValue() {

			this.internal_Param_Transaction_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@TransactionType'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [varchar](3)
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_TransactionType_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_TransactionType {

			get {

				if (this.internal_Param_TransactionType_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_TransactionType);
			}

			set {

				this.internal_Param_TransactionType_UseDefaultValue = false;
				this.internal_Param_TransactionType = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@TransactionType' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_TransactionType_UseDefaultValue() {

			this.internal_Param_TransactionType_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_TransactionType'.
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
		/// the parameter default value, consider calling the Param_ConsiderNull_TransactionType_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_TransactionType {

			get {

				if (this.internal_Param_ConsiderNull_TransactionType_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_TransactionType);
			}

			set {

				this.internal_Param_ConsiderNull_TransactionType_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_TransactionType = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_TransactionType' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_TransactionType_UseDefaultValue() {

			this.internal_Param_ConsiderNull_TransactionType_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Fournisseur'.
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
		/// the parameter default value, consider calling the Param_Fournisseur_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_Fournisseur {

			get {

				if (this.internal_Param_Fournisseur_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Fournisseur);
			}

			set {

				this.internal_Param_Fournisseur_UseDefaultValue = false;
				this.internal_Param_Fournisseur = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Fournisseur' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Fournisseur_UseDefaultValue() {

			this.internal_Param_Fournisseur_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_Fournisseur'.
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
		/// the parameter default value, consider calling the Param_ConsiderNull_Fournisseur_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_Fournisseur {

			get {

				if (this.internal_Param_ConsiderNull_Fournisseur_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_Fournisseur);
			}

			set {

				this.internal_Param_ConsiderNull_Fournisseur_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_Fournisseur = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_Fournisseur' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_Fournisseur_UseDefaultValue() {

			this.internal_Param_ConsiderNull_Fournisseur_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Contrat'.
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
		/// the parameter default value, consider calling the Param_Contrat_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_Contrat {

			get {

				if (this.internal_Param_Contrat_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Contrat);
			}

			set {

				this.internal_Param_Contrat_UseDefaultValue = false;
				this.internal_Param_Contrat = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Contrat' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Contrat_UseDefaultValue() {

			this.internal_Param_Contrat_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_Contrat'.
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
		/// the parameter default value, consider calling the Param_ConsiderNull_Contrat_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_Contrat {

			get {

				if (this.internal_Param_ConsiderNull_Contrat_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_Contrat);
			}

			set {

				this.internal_Param_ConsiderNull_Contrat_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_Contrat = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_Contrat' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_Contrat_UseDefaultValue() {

			this.internal_Param_ConsiderNull_Contrat_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Produit'.
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
		/// the parameter default value, consider calling the Param_Produit_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_Produit {

			get {

				if (this.internal_Param_Produit_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Produit);
			}

			set {

				this.internal_Param_Produit_UseDefaultValue = false;
				this.internal_Param_Produit = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Produit' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Produit_UseDefaultValue() {

			this.internal_Param_Produit_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_Produit'.
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
		/// the parameter default value, consider calling the Param_ConsiderNull_Produit_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_Produit {

			get {

				if (this.internal_Param_ConsiderNull_Produit_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_Produit);
			}

			set {

				this.internal_Param_ConsiderNull_Produit_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_Produit = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_Produit' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_Produit_UseDefaultValue() {

			this.internal_Param_ConsiderNull_Produit_UseDefaultValue = true;
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
		/// Sets the value of the stored procedure INPUT parameter '@Carte'.
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
		/// the parameter default value, consider calling the Param_Carte_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_Carte {

			get {

				if (this.internal_Param_Carte_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Carte);
			}

			set {

				this.internal_Param_Carte_UseDefaultValue = false;
				this.internal_Param_Carte = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Carte' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Carte_UseDefaultValue() {

			this.internal_Param_Carte_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_Carte'.
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
		/// the parameter default value, consider calling the Param_ConsiderNull_Carte_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_Carte {

			get {

				if (this.internal_Param_ConsiderNull_Carte_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_Carte);
			}

			set {

				this.internal_Param_ConsiderNull_Carte_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_Carte = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_Carte' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_Carte_UseDefaultValue() {

			this.internal_Param_ConsiderNull_Carte_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@License'.
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
		/// the parameter default value, consider calling the Param_License_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_License {

			get {

				if (this.internal_Param_License_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_License);
			}

			set {

				this.internal_Param_License_UseDefaultValue = false;
				this.internal_Param_License = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@License' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_License_UseDefaultValue() {

			this.internal_Param_License_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_License'.
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
		/// the parameter default value, consider calling the Param_ConsiderNull_License_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_License {

			get {

				if (this.internal_Param_ConsiderNull_License_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_License);
			}

			set {

				this.internal_Param_ConsiderNull_License_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_License = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_License' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_License_UseDefaultValue() {

			this.internal_Param_ConsiderNull_License_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Transporteur_Camion'.
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
		/// the parameter default value, consider calling the Param_Transporteur_Camion_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_Transporteur_Camion {

			get {

				if (this.internal_Param_Transporteur_Camion_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Transporteur_Camion);
			}

			set {

				this.internal_Param_Transporteur_Camion_UseDefaultValue = false;
				this.internal_Param_Transporteur_Camion = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Transporteur_Camion' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Transporteur_Camion_UseDefaultValue() {

			this.internal_Param_Transporteur_Camion_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_Transporteur_Camion'.
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
		/// the parameter default value, consider calling the Param_ConsiderNull_Transporteur_Camion_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_Transporteur_Camion {

			get {

				if (this.internal_Param_ConsiderNull_Transporteur_Camion_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_Transporteur_Camion);
			}

			set {

				this.internal_Param_ConsiderNull_Transporteur_Camion_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_Transporteur_Camion = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_Transporteur_Camion' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_Transporteur_Camion_UseDefaultValue() {

			this.internal_Param_ConsiderNull_Transporteur_Camion_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Producteur'.
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
		/// the parameter default value, consider calling the Param_Producteur_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_Producteur {

			get {

				if (this.internal_Param_Producteur_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Producteur);
			}

			set {

				this.internal_Param_Producteur_UseDefaultValue = false;
				this.internal_Param_Producteur = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Producteur' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Producteur_UseDefaultValue() {

			this.internal_Param_Producteur_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_Producteur'.
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
		/// the parameter default value, consider calling the Param_ConsiderNull_Producteur_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_Producteur {

			get {

				if (this.internal_Param_ConsiderNull_Producteur_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_Producteur);
			}

			set {

				this.internal_Param_ConsiderNull_Producteur_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_Producteur = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_Producteur' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_Producteur_UseDefaultValue() {

			this.internal_Param_ConsiderNull_Producteur_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Municipalite'.
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
		/// the parameter default value, consider calling the Param_Municipalite_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_Municipalite {

			get {

				if (this.internal_Param_Municipalite_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Municipalite);
			}

			set {

				this.internal_Param_Municipalite_UseDefaultValue = false;
				this.internal_Param_Municipalite = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Municipalite' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Municipalite_UseDefaultValue() {

			this.internal_Param_Municipalite_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_Municipalite'.
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
		/// the parameter default value, consider calling the Param_ConsiderNull_Municipalite_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_Municipalite {

			get {

				if (this.internal_Param_ConsiderNull_Municipalite_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_Municipalite);
			}

			set {

				this.internal_Param_ConsiderNull_Municipalite_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_Municipalite = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_Municipalite' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_Municipalite_UseDefaultValue() {

			this.internal_Param_ConsiderNull_Municipalite_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Brut'.
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
		/// the parameter default value, consider calling the Param_Brut_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlInt32 Param_Brut {

			get {

				if (this.internal_Param_Brut_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Brut);
			}

			set {

				this.internal_Param_Brut_UseDefaultValue = false;
				this.internal_Param_Brut = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Brut' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Brut_UseDefaultValue() {

			this.internal_Param_Brut_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_Brut'.
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
		/// the parameter default value, consider calling the Param_ConsiderNull_Brut_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_Brut {

			get {

				if (this.internal_Param_ConsiderNull_Brut_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_Brut);
			}

			set {

				this.internal_Param_ConsiderNull_Brut_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_Brut = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_Brut' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_Brut_UseDefaultValue() {

			this.internal_Param_ConsiderNull_Brut_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Tare'.
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
		/// the parameter default value, consider calling the Param_Tare_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlInt32 Param_Tare {

			get {

				if (this.internal_Param_Tare_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Tare);
			}

			set {

				this.internal_Param_Tare_UseDefaultValue = false;
				this.internal_Param_Tare = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Tare' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Tare_UseDefaultValue() {

			this.internal_Param_Tare_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_Tare'.
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
		/// the parameter default value, consider calling the Param_ConsiderNull_Tare_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_Tare {

			get {

				if (this.internal_Param_ConsiderNull_Tare_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_Tare);
			}

			set {

				this.internal_Param_ConsiderNull_Tare_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_Tare = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_Tare' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_Tare_UseDefaultValue() {

			this.internal_Param_ConsiderNull_Tare_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Net'.
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
		/// the parameter default value, consider calling the Param_Net_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlInt32 Param_Net {

			get {

				if (this.internal_Param_Net_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Net);
			}

			set {

				this.internal_Param_Net_UseDefaultValue = false;
				this.internal_Param_Net = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Net' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Net_UseDefaultValue() {

			this.internal_Param_Net_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_Net'.
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
		/// the parameter default value, consider calling the Param_ConsiderNull_Net_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_Net {

			get {

				if (this.internal_Param_ConsiderNull_Net_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_Net);
			}

			set {

				this.internal_Param_ConsiderNull_Net_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_Net = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_Net' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_Net_UseDefaultValue() {

			this.internal_Param_ConsiderNull_Net_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Rejets'.
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
		/// the parameter default value, consider calling the Param_Rejets_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlInt32 Param_Rejets {

			get {

				if (this.internal_Param_Rejets_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Rejets);
			}

			set {

				this.internal_Param_Rejets_UseDefaultValue = false;
				this.internal_Param_Rejets = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Rejets' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Rejets_UseDefaultValue() {

			this.internal_Param_Rejets_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_Rejets'.
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
		/// the parameter default value, consider calling the Param_ConsiderNull_Rejets_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_Rejets {

			get {

				if (this.internal_Param_ConsiderNull_Rejets_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_Rejets);
			}

			set {

				this.internal_Param_ConsiderNull_Rejets_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_Rejets = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_Rejets' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_Rejets_UseDefaultValue() {

			this.internal_Param_ConsiderNull_Rejets_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@KgVert_Paye'.
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
		/// the parameter default value, consider calling the Param_KgVert_Paye_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlInt32 Param_KgVert_Paye {

			get {

				if (this.internal_Param_KgVert_Paye_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_KgVert_Paye);
			}

			set {

				this.internal_Param_KgVert_Paye_UseDefaultValue = false;
				this.internal_Param_KgVert_Paye = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@KgVert_Paye' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_KgVert_Paye_UseDefaultValue() {

			this.internal_Param_KgVert_Paye_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_KgVert_Paye'.
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
		/// the parameter default value, consider calling the Param_ConsiderNull_KgVert_Paye_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_KgVert_Paye {

			get {

				if (this.internal_Param_ConsiderNull_KgVert_Paye_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_KgVert_Paye);
			}

			set {

				this.internal_Param_ConsiderNull_KgVert_Paye_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_KgVert_Paye = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_KgVert_Paye' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_KgVert_Paye_UseDefaultValue() {

			this.internal_Param_ConsiderNull_KgVert_Paye_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Pourcent_Sec'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [float]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_Pourcent_Sec_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlDouble Param_Pourcent_Sec {

			get {

				if (this.internal_Param_Pourcent_Sec_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Pourcent_Sec);
			}

			set {

				this.internal_Param_Pourcent_Sec_UseDefaultValue = false;
				this.internal_Param_Pourcent_Sec = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Pourcent_Sec' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Pourcent_Sec_UseDefaultValue() {

			this.internal_Param_Pourcent_Sec_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_Pourcent_Sec'.
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
		/// the parameter default value, consider calling the Param_ConsiderNull_Pourcent_Sec_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_Pourcent_Sec {

			get {

				if (this.internal_Param_ConsiderNull_Pourcent_Sec_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_Pourcent_Sec);
			}

			set {

				this.internal_Param_ConsiderNull_Pourcent_Sec_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_Pourcent_Sec = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_Pourcent_Sec' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_Pourcent_Sec_UseDefaultValue() {

			this.internal_Param_ConsiderNull_Pourcent_Sec_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@KgSec_Paye'.
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
		/// the parameter default value, consider calling the Param_KgSec_Paye_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlInt32 Param_KgSec_Paye {

			get {

				if (this.internal_Param_KgSec_Paye_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_KgSec_Paye);
			}

			set {

				this.internal_Param_KgSec_Paye_UseDefaultValue = false;
				this.internal_Param_KgSec_Paye = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@KgSec_Paye' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_KgSec_Paye_UseDefaultValue() {

			this.internal_Param_KgSec_Paye_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_KgSec_Paye'.
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
		/// the parameter default value, consider calling the Param_ConsiderNull_KgSec_Paye_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_KgSec_Paye {

			get {

				if (this.internal_Param_ConsiderNull_KgSec_Paye_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_KgSec_Paye);
			}

			set {

				this.internal_Param_ConsiderNull_KgSec_Paye_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_KgSec_Paye = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_KgSec_Paye' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_KgSec_Paye_UseDefaultValue() {

			this.internal_Param_ConsiderNull_KgSec_Paye_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Validation'.
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
		/// the parameter default value, consider calling the Param_Validation_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_Validation {

			get {

				if (this.internal_Param_Validation_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Validation);
			}

			set {

				this.internal_Param_Validation_UseDefaultValue = false;
				this.internal_Param_Validation = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Validation' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Validation_UseDefaultValue() {

			this.internal_Param_Validation_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_Validation'.
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
		/// the parameter default value, consider calling the Param_ConsiderNull_Validation_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_Validation {

			get {

				if (this.internal_Param_ConsiderNull_Validation_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_Validation);
			}

			set {

				this.internal_Param_ConsiderNull_Validation_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_Validation = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_Validation' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_Validation_UseDefaultValue() {

			this.internal_Param_ConsiderNull_Validation_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Transfert'.
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
		/// the parameter default value, consider calling the Param_Transfert_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_Transfert {

			get {

				if (this.internal_Param_Transfert_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Transfert);
			}

			set {

				this.internal_Param_Transfert_UseDefaultValue = false;
				this.internal_Param_Transfert = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Transfert' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Transfert_UseDefaultValue() {

			this.internal_Param_Transfert_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_Transfert'.
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
		/// the parameter default value, consider calling the Param_ConsiderNull_Transfert_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_Transfert {

			get {

				if (this.internal_Param_ConsiderNull_Transfert_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_Transfert);
			}

			set {

				this.internal_Param_ConsiderNull_Transfert_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_Transfert = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_Transfert' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_Transfert_UseDefaultValue() {

			this.internal_Param_ConsiderNull_Transfert_UseDefaultValue = true;
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
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_EssenceID'.
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
		/// the parameter default value, consider calling the Param_ConsiderNull_EssenceID_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_EssenceID {

			get {

				if (this.internal_Param_ConsiderNull_EssenceID_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_EssenceID);
			}

			set {

				this.internal_Param_ConsiderNull_EssenceID_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_EssenceID = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_EssenceID' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_EssenceID_UseDefaultValue() {

			this.internal_Param_ConsiderNull_EssenceID_UseDefaultValue = true;
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
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_UniteID'.
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
		/// the parameter default value, consider calling the Param_ConsiderNull_UniteID_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_UniteID {

			get {

				if (this.internal_Param_ConsiderNull_UniteID_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_UniteID);
			}

			set {

				this.internal_Param_ConsiderNull_UniteID_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_UniteID = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_UniteID' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_UniteID_UseDefaultValue() {

			this.internal_Param_ConsiderNull_UniteID_UseDefaultValue = true;
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
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_Code'.
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
		/// the parameter default value, consider calling the Param_ConsiderNull_Code_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_Code {

			get {

				if (this.internal_Param_ConsiderNull_Code_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_Code);
			}

			set {

				this.internal_Param_ConsiderNull_Code_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_Code = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_Code' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_Code_UseDefaultValue() {

			this.internal_Param_ConsiderNull_Code_UseDefaultValue = true;
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
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_TransporteurID'.
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
		/// the parameter default value, consider calling the Param_ConsiderNull_TransporteurID_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_TransporteurID {

			get {

				if (this.internal_Param_ConsiderNull_TransporteurID_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_TransporteurID);
			}

			set {

				this.internal_Param_ConsiderNull_TransporteurID_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_TransporteurID = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_TransporteurID' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_TransporteurID_UseDefaultValue() {

			this.internal_Param_ConsiderNull_TransporteurID_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@BonCommande'.
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
		/// the parameter default value, consider calling the Param_BonCommande_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_BonCommande {

			get {

				if (this.internal_Param_BonCommande_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_BonCommande);
			}

			set {

				this.internal_Param_BonCommande_UseDefaultValue = false;
				this.internal_Param_BonCommande = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@BonCommande' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_BonCommande_UseDefaultValue() {

			this.internal_Param_BonCommande_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_BonCommande'.
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
		/// the parameter default value, consider calling the Param_ConsiderNull_BonCommande_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_BonCommande {

			get {

				if (this.internal_Param_ConsiderNull_BonCommande_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_BonCommande);
			}

			set {

				this.internal_Param_ConsiderNull_BonCommande_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_BonCommande = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_BonCommande' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_BonCommande_UseDefaultValue() {

			this.internal_Param_ConsiderNull_BonCommande_UseDefaultValue = true;
		}

  	}
}

namespace Gestion_Paie.DataClasses.StoredProcedures {

	/// <summary>
	/// This class allows you to execute the 'spU_FeuilletDomtar' stored procedure;
	/// it gives you the ability to:
	/// <list type="bullet">
	/// <item><description>Set all the necessary parameters to execute the stored procedure</description></item>
	/// <item><description>To execute the stored procedure</description></item>
	/// <item><description>To get back after the execution the return value and all the output parameters value</description></item>
	/// </list>
	/// </summary>
	public sealed class spU_FeuilletDomtar : MarshalByRefObject, IDisposable {


		private bool throwExceptionOnExecute = false;

		/// <summary>
		/// Initializes a new instance of the spU_FeuilletDomtar class.
		/// By default, no exception will be thrown when you call the Execute method. Instead, a Boolean return status will be returned.
		/// </summary>
		public spU_FeuilletDomtar() : this(false) {

		}

		/// <summary>
		/// Initializes a new instance of the spU_FeuilletDomtar class.
		/// </summary>
		/// <param name="throwExceptionOnExecute">True if an exception has to be thrown if the Execute call fails.</param>
		public spU_FeuilletDomtar(bool throwExceptionOnExecute) {

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
		~spU_FeuilletDomtar() {

			Dispose(false);
		}

		private void ResetParameter(ref Gestion_Paie.DataClasses.Parameters.spU_FeuilletDomtar parameters) {

			parameters.internal_Set_RETURN_VALUE (System.Data.SqlTypes.SqlInt32.Null);
		}

		private bool InitializeConnection(ref Gestion_Paie.DataClasses.Parameters.spU_FeuilletDomtar parameters, out System.Data.SqlClient.SqlCommand sqlCommand, ref bool connectionMustBeClosed) {

			try {

				this.sqlConnection = null;
				sqlCommand = null;
				connectionMustBeClosed = true;

				if (parameters.ConnectionType == ConnectionType.None) {

					throw new InvalidOperationException("No connection information was supplied. Consider calling the 'SetUpConnection' method of the Gestion_Paie.DataClasses.Parameters.spU_FeuilletDomtar object before doing this call.");
				}

				if (parameters.ConnectionType == ConnectionType.SqlConnection && parameters.SqlConnection == null) {

					throw new InvalidOperationException("No connection information was supplied (SqlConnection == null). Consider calling the 'SetUpConnection' method of the Gestion_Paie.DataClasses.Parameters.spU_FeuilletDomtar object before doing this call.");
				}

				if (parameters.ConnectionType == ConnectionType.SqlTransaction && parameters.SqlTransaction== null) {

					throw new InvalidOperationException("No connection information was supplied (SqlTransaction == null). Consider calling the 'SetUpConnection' method of the Gestion_Paie.DataClasses.Parameters.spU_FeuilletDomtar object before doing this call.");
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

							throw new System.InvalidOperationException("No connection information was supplied (ConnectionString == \"\")! (Gestion_Paie.DataClasses.Parameters.spU_FeuilletDomtar)");
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
				sqlCommand.CommandText = "spU_FeuilletDomtar";

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

		private bool DeclareParameters(ref Gestion_Paie.DataClasses.Parameters.spU_FeuilletDomtar parameters, ref System.Data.SqlClient.SqlCommand sqlCommand) {

			try {

				System.Data.SqlClient.SqlParameter sqlParameter;

				sqlParameter = new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4);
				sqlParameter.Direction = System.Data.ParameterDirection.ReturnValue;
				sqlParameter.IsNullable = true;
				sqlParameter.Value = System.DBNull.Value;
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Transaction", System.Data.SqlDbType.VarChar, 15);
				sqlParameter.SourceColumn = "Transaction";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Transaction_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Transaction.IsNull) {

					sqlParameter.Value = parameters.Param_Transaction;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@TransactionType", System.Data.SqlDbType.VarChar, 3);
				sqlParameter.SourceColumn = "TransactionType";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_TransactionType_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_TransactionType.IsNull) {

					sqlParameter.Value = parameters.Param_TransactionType;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_TransactionType", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_TransactionType_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_TransactionType.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_TransactionType;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Fournisseur", System.Data.SqlDbType.VarChar, 15);
				sqlParameter.SourceColumn = "Fournisseur";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Fournisseur_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Fournisseur.IsNull) {

					sqlParameter.Value = parameters.Param_Fournisseur;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Fournisseur", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_Fournisseur_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_Fournisseur.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_Fournisseur;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Contrat", System.Data.SqlDbType.VarChar, 25);
				sqlParameter.SourceColumn = "Contrat";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Contrat_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Contrat.IsNull) {

					sqlParameter.Value = parameters.Param_Contrat;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Contrat", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_Contrat_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_Contrat.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_Contrat;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Produit", System.Data.SqlDbType.VarChar, 10);
				sqlParameter.SourceColumn = "Produit";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Produit_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Produit.IsNull) {

					sqlParameter.Value = parameters.Param_Produit;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Produit", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_Produit_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_Produit.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_Produit;
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

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Carte", System.Data.SqlDbType.VarChar, 15);
				sqlParameter.SourceColumn = "Carte";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Carte_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Carte.IsNull) {

					sqlParameter.Value = parameters.Param_Carte;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Carte", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_Carte_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_Carte.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_Carte;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@License", System.Data.SqlDbType.VarChar, 15);
				sqlParameter.SourceColumn = "License";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_License_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_License.IsNull) {

					sqlParameter.Value = parameters.Param_License;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_License", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_License_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_License.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_License;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Transporteur_Camion", System.Data.SqlDbType.VarChar, 15);
				sqlParameter.SourceColumn = "Transporteur_Camion";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Transporteur_Camion_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Transporteur_Camion.IsNull) {

					sqlParameter.Value = parameters.Param_Transporteur_Camion;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Transporteur_Camion", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_Transporteur_Camion_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_Transporteur_Camion.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_Transporteur_Camion;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Producteur", System.Data.SqlDbType.VarChar, 15);
				sqlParameter.SourceColumn = "Producteur";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Producteur_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Producteur.IsNull) {

					sqlParameter.Value = parameters.Param_Producteur;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Producteur", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_Producteur_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_Producteur.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_Producteur;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Municipalite", System.Data.SqlDbType.VarChar, 15);
				sqlParameter.SourceColumn = "Municipalite";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Municipalite_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Municipalite.IsNull) {

					sqlParameter.Value = parameters.Param_Municipalite;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Municipalite", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_Municipalite_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_Municipalite.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_Municipalite;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Brut", System.Data.SqlDbType.Int, 4);
				sqlParameter.SourceColumn = "Brut";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Brut_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Brut.IsNull) {

					sqlParameter.Value = parameters.Param_Brut;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Brut", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_Brut_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_Brut.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_Brut;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Tare", System.Data.SqlDbType.Int, 4);
				sqlParameter.SourceColumn = "Tare";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Tare_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Tare.IsNull) {

					sqlParameter.Value = parameters.Param_Tare;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Tare", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_Tare_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_Tare.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_Tare;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Net", System.Data.SqlDbType.Int, 4);
				sqlParameter.SourceColumn = "Net";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Net_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Net.IsNull) {

					sqlParameter.Value = parameters.Param_Net;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Net", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_Net_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_Net.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_Net;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Rejets", System.Data.SqlDbType.Int, 4);
				sqlParameter.SourceColumn = "Rejets";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Rejets_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Rejets.IsNull) {

					sqlParameter.Value = parameters.Param_Rejets;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Rejets", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_Rejets_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_Rejets.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_Rejets;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@KgVert_Paye", System.Data.SqlDbType.Int, 4);
				sqlParameter.SourceColumn = "KgVert_Paye";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_KgVert_Paye_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_KgVert_Paye.IsNull) {

					sqlParameter.Value = parameters.Param_KgVert_Paye;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_KgVert_Paye", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_KgVert_Paye_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_KgVert_Paye.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_KgVert_Paye;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Pourcent_Sec", System.Data.SqlDbType.Float, 8);
				sqlParameter.SourceColumn = "Pourcent_Sec";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Pourcent_Sec_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Pourcent_Sec.IsNull) {

					sqlParameter.Value = parameters.Param_Pourcent_Sec;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Pourcent_Sec", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_Pourcent_Sec_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_Pourcent_Sec.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_Pourcent_Sec;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@KgSec_Paye", System.Data.SqlDbType.Int, 4);
				sqlParameter.SourceColumn = "KgSec_Paye";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_KgSec_Paye_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_KgSec_Paye.IsNull) {

					sqlParameter.Value = parameters.Param_KgSec_Paye;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_KgSec_Paye", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_KgSec_Paye_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_KgSec_Paye.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_KgSec_Paye;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Validation", System.Data.SqlDbType.VarChar, 255);
				sqlParameter.SourceColumn = "Validation";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Validation_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Validation.IsNull) {

					sqlParameter.Value = parameters.Param_Validation;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Validation", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_Validation_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_Validation.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_Validation;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Transfert", System.Data.SqlDbType.Bit, 1);
				sqlParameter.SourceColumn = "Transfert";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Transfert_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Transfert.IsNull) {

					sqlParameter.Value = parameters.Param_Transfert;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Transfert", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_Transfert_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_Transfert.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_Transfert;
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

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_EssenceID", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_EssenceID_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_EssenceID.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_EssenceID;
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

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_UniteID", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_UniteID_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_UniteID.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_UniteID;
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

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Code", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_Code_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_Code.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_Code;
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

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_TransporteurID", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_TransporteurID_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_TransporteurID.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_TransporteurID;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@BonCommande", System.Data.SqlDbType.VarChar, 25);
				sqlParameter.SourceColumn = "BonCommande";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_BonCommande_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_BonCommande.IsNull) {

					sqlParameter.Value = parameters.Param_BonCommande;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_BonCommande", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_BonCommande_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_BonCommande.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_BonCommande;
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

		private bool RetrieveParameters(ref Gestion_Paie.DataClasses.Parameters.spU_FeuilletDomtar parameters, ref System.Data.SqlClient.SqlCommand sqlCommand) {

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
		/// This method allows you to execute the [spU_FeuilletDomtar] stored procedure.
		/// </summary>
		/// <param name="parameters">
		/// Contains all the necessary information to execute correctly the stored procedure, i.e. 
		/// the database connection to use and all the necessary input parameters to be supplied
		/// for this stored procedure execution. After the execution, this object will allow you
		/// to retrieve back the stored procedure return value and all the output parameters.
		/// </param>
		/// <returns>True if the call was successful. Otherwise, it returns False.</returns>
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.spU_FeuilletDomtar parameters) {

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

