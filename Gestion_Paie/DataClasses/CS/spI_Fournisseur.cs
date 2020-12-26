using System;

namespace Gestion_Paie.DataClasses.Parameters {

	/// <summary>
	/// This class allows a developer to specify the parameters expected by the
	/// stored procedure 'spI_Fournisseur'. It allows also to specify specific connection
	/// information such as the ConnectionString to be use, the command time-out and so forth.
	/// </summary>
	[Serializable()]
	public sealed class spI_Fournisseur : MarshalByRefObject, IDisposable, IParameter {

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
		/// Initializes a new instance of the spI_Fournisseur class. If you use this constructor version,
		/// not assigning parameter values implies using the parameter default values.
		/// </summary>
		public spI_Fournisseur() : this(true) {

		}

		/// <summary>
		/// Initializes a new instance of the spI_Fournisseur class.
		/// </summary>
		/// <param name="useDefaultValue">If True, this parameter indicates that "not assigning parameter values" implies "using the parameter default values". If False, this parameter indicates that "not assigning parameter values" implies "using the SQL Server Null value".</param>
		public spI_Fournisseur(bool useDefaultValue) {

			this.useDefaultValue = useDefaultValue;

			this.internal_Param_ID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_CleTri_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Nom_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_AuSoinsDe_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Rue_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Ville_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_PaysID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Code_postal_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Telephone_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Telephone_Poste_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Telecopieur_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Telephone2_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Telephone2_Desc_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Telephone2_Poste_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Telephone3_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Telephone3_Desc_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Telephone3_Poste_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_No_membre_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Resident_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Email_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_WWW_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Commentaires_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_AfficherCommentaires_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_DepotDirect_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_InstitutionBanquaireID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Banque_transit_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Banque_folio_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_No_TPS_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_No_TVQ_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_PayerA_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_PayerAID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Statut_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Rep_Nom_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Rep_Telephone_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Rep_Telephone_Poste_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Rep_Email_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_EnAnglais_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Actif_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_MRCProducteurID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_PaiementManuel_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Journal_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_RecoitTPS_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_RecoitTVQ_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ModifierTrigger_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_IsProducteur_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_IsTransporteur_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_IsChargeur_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_IsAutre_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_AfficherCommentairesSurPermit_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_PasEmissionPermis_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Generique_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Membre_OGC_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_InscritTPS_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_InscritTVQ_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_IsOGC_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Rep2_Nom_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Rep2_Telephone_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Rep2_Telephone_Poste_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Rep2_Email_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Rep2_Commentaires_UseDefaultValue = this.useDefaultValue;
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
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'spI_Fournisseur'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

						throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "spI_Fournisseur", CurrentRevision, OriginalRevision, System.Environment.NewLine));
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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'spI_Fournisseur'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlConnection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "spI_Fournisseur", CurrentRevision, OriginalRevision, System.Environment.NewLine));
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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'spI_Fournisseur'";
				sqlCommand.Transaction = sqlTransaction;

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlTransaction.Connection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "spI_Fournisseur", CurrentRevision, OriginalRevision, System.Environment.NewLine));
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
				this.internal_Param_ID = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_CleTri = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_Nom = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_AuSoinsDe = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_Rue = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_Ville = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_PaysID = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_Code_postal = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_Telephone = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_Telephone_Poste = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_Telecopieur = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_Telephone2 = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_Telephone2_Desc = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_Telephone2_Poste = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_Telephone3 = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_Telephone3_Desc = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_Telephone3_Poste = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_No_membre = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_Resident = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_Email = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_WWW = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_Commentaires = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_AfficherCommentaires = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_DepotDirect = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_InstitutionBanquaireID = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_Banque_transit = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_Banque_folio = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_No_TPS = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_No_TVQ = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_PayerA = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_PayerAID = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_Statut = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_Rep_Nom = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_Rep_Telephone = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_Rep_Telephone_Poste = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_Rep_Email = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_EnAnglais = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Actif = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_MRCProducteurID = System.Data.SqlTypes.SqlInt32.Null;
				this.internal_Param_PaiementManuel = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Journal = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_RecoitTPS = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_RecoitTVQ = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_ModifierTrigger = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_IsProducteur = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_IsTransporteur = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_IsChargeur = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_IsAutre = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_AfficherCommentairesSurPermit = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_PasEmissionPermis = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Generique = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Membre_OGC = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_InscritTPS = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_InscritTVQ = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_IsOGC = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Rep2_Nom = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_Rep2_Telephone = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_Rep2_Telephone_Poste = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_Rep2_Email = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_Rep2_Commentaires = System.Data.SqlTypes.SqlString.Null;

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
		~spI_Fournisseur() {

			Dispose(false);
		}

		/// <summary>
		/// Returns the stored procedure name for which this class was built, i.e. 'spI_Fournisseur'.
		/// </summary>
		public string StoredProcedureName {

			get {

				return("spI_Fournisseur");
			}
		}

		private System.Data.SqlTypes.SqlInt32 internal_Param_RETURN_VALUE;

		private System.Data.SqlTypes.SqlString internal_Param_ID;
		internal bool internal_Param_ID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_CleTri;
		internal bool internal_Param_CleTri_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_Nom;
		internal bool internal_Param_Nom_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_AuSoinsDe;
		internal bool internal_Param_AuSoinsDe_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_Rue;
		internal bool internal_Param_Rue_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_Ville;
		internal bool internal_Param_Ville_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_PaysID;
		internal bool internal_Param_PaysID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_Code_postal;
		internal bool internal_Param_Code_postal_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_Telephone;
		internal bool internal_Param_Telephone_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_Telephone_Poste;
		internal bool internal_Param_Telephone_Poste_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_Telecopieur;
		internal bool internal_Param_Telecopieur_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_Telephone2;
		internal bool internal_Param_Telephone2_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_Telephone2_Desc;
		internal bool internal_Param_Telephone2_Desc_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_Telephone2_Poste;
		internal bool internal_Param_Telephone2_Poste_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_Telephone3;
		internal bool internal_Param_Telephone3_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_Telephone3_Desc;
		internal bool internal_Param_Telephone3_Desc_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_Telephone3_Poste;
		internal bool internal_Param_Telephone3_Poste_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_No_membre;
		internal bool internal_Param_No_membre_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_Resident;
		internal bool internal_Param_Resident_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_Email;
		internal bool internal_Param_Email_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_WWW;
		internal bool internal_Param_WWW_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_Commentaires;
		internal bool internal_Param_Commentaires_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_AfficherCommentaires;
		internal bool internal_Param_AfficherCommentaires_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_DepotDirect;
		internal bool internal_Param_DepotDirect_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_InstitutionBanquaireID;
		internal bool internal_Param_InstitutionBanquaireID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_Banque_transit;
		internal bool internal_Param_Banque_transit_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_Banque_folio;
		internal bool internal_Param_Banque_folio_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_No_TPS;
		internal bool internal_Param_No_TPS_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_No_TVQ;
		internal bool internal_Param_No_TVQ_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_PayerA;
		internal bool internal_Param_PayerA_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_PayerAID;
		internal bool internal_Param_PayerAID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_Statut;
		internal bool internal_Param_Statut_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_Rep_Nom;
		internal bool internal_Param_Rep_Nom_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_Rep_Telephone;
		internal bool internal_Param_Rep_Telephone_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_Rep_Telephone_Poste;
		internal bool internal_Param_Rep_Telephone_Poste_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_Rep_Email;
		internal bool internal_Param_Rep_Email_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_EnAnglais;
		internal bool internal_Param_EnAnglais_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_Actif;
		internal bool internal_Param_Actif_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlInt32 internal_Param_MRCProducteurID;
		internal bool internal_Param_MRCProducteurID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_PaiementManuel;
		internal bool internal_Param_PaiementManuel_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_Journal;
		internal bool internal_Param_Journal_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_RecoitTPS;
		internal bool internal_Param_RecoitTPS_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_RecoitTVQ;
		internal bool internal_Param_RecoitTVQ_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ModifierTrigger;
		internal bool internal_Param_ModifierTrigger_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_IsProducteur;
		internal bool internal_Param_IsProducteur_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_IsTransporteur;
		internal bool internal_Param_IsTransporteur_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_IsChargeur;
		internal bool internal_Param_IsChargeur_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_IsAutre;
		internal bool internal_Param_IsAutre_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_AfficherCommentairesSurPermit;
		internal bool internal_Param_AfficherCommentairesSurPermit_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_PasEmissionPermis;
		internal bool internal_Param_PasEmissionPermis_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_Generique;
		internal bool internal_Param_Generique_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_Membre_OGC;
		internal bool internal_Param_Membre_OGC_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_InscritTPS;
		internal bool internal_Param_InscritTPS_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_InscritTVQ;
		internal bool internal_Param_InscritTVQ_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_IsOGC;
		internal bool internal_Param_IsOGC_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_Rep2_Nom;
		internal bool internal_Param_Rep2_Nom_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_Rep2_Telephone;
		internal bool internal_Param_Rep2_Telephone_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_Rep2_Telephone_Poste;
		internal bool internal_Param_Rep2_Telephone_Poste_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_Rep2_Email;
		internal bool internal_Param_Rep2_Email_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_Rep2_Commentaires;
		internal bool internal_Param_Rep2_Commentaires_UseDefaultValue = true;


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

			this.internal_Param_ID = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_ID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_CleTri = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_CleTri_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Nom = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_Nom_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_AuSoinsDe = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_AuSoinsDe_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Rue = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_Rue_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Ville = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_Ville_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_PaysID = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_PaysID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Code_postal = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_Code_postal_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Telephone = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_Telephone_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Telephone_Poste = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_Telephone_Poste_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Telecopieur = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_Telecopieur_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Telephone2 = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_Telephone2_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Telephone2_Desc = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_Telephone2_Desc_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Telephone2_Poste = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_Telephone2_Poste_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Telephone3 = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_Telephone3_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Telephone3_Desc = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_Telephone3_Desc_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Telephone3_Poste = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_Telephone3_Poste_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_No_membre = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_No_membre_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Resident = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_Resident_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Email = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_Email_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_WWW = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_WWW_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Commentaires = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_Commentaires_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_AfficherCommentaires = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_AfficherCommentaires_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_DepotDirect = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_DepotDirect_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_InstitutionBanquaireID = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_InstitutionBanquaireID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Banque_transit = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_Banque_transit_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Banque_folio = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_Banque_folio_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_No_TPS = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_No_TPS_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_No_TVQ = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_No_TVQ_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_PayerA = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_PayerA_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_PayerAID = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_PayerAID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Statut = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_Statut_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Rep_Nom = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_Rep_Nom_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Rep_Telephone = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_Rep_Telephone_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Rep_Telephone_Poste = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_Rep_Telephone_Poste_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Rep_Email = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_Rep_Email_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_EnAnglais = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_EnAnglais_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Actif = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_Actif_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_MRCProducteurID = System.Data.SqlTypes.SqlInt32.Null;
			this.internal_Param_MRCProducteurID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_PaiementManuel = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_PaiementManuel_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Journal = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_Journal_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_RecoitTPS = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_RecoitTPS_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_RecoitTVQ = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_RecoitTVQ_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ModifierTrigger = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ModifierTrigger_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_IsProducteur = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_IsProducteur_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_IsTransporteur = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_IsTransporteur_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_IsChargeur = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_IsChargeur_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_IsAutre = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_IsAutre_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_AfficherCommentairesSurPermit = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_AfficherCommentairesSurPermit_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_PasEmissionPermis = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_PasEmissionPermis_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Generique = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_Generique_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Membre_OGC = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_Membre_OGC_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_InscritTPS = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_InscritTPS_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_InscritTVQ = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_InscritTVQ_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_IsOGC = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_IsOGC_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Rep2_Nom = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_Rep2_Nom_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Rep2_Telephone = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_Rep2_Telephone_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Rep2_Telephone_Poste = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_Rep2_Telephone_Poste_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Rep2_Email = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_Rep2_Email_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Rep2_Commentaires = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_Rep2_Commentaires_UseDefaultValue = this.useDefaultValue;

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
		/// In SQL Server, this parameter is of type: [varchar](15)
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
		public System.Data.SqlTypes.SqlString Param_ID {

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
		/// Sets the value of the stored procedure INPUT parameter '@CleTri'.
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
		/// the parameter default value, consider calling the Param_CleTri_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_CleTri {

			get {

				if (this.internal_Param_CleTri_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_CleTri);
			}

			set {

				this.internal_Param_CleTri_UseDefaultValue = false;
				this.internal_Param_CleTri = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@CleTri' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_CleTri_UseDefaultValue() {

			this.internal_Param_CleTri_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Nom'.
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
		/// Sets the value of the stored procedure INPUT parameter '@AuSoinsDe'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [varchar](30)
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_AuSoinsDe_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_AuSoinsDe {

			get {

				if (this.internal_Param_AuSoinsDe_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_AuSoinsDe);
			}

			set {

				this.internal_Param_AuSoinsDe_UseDefaultValue = false;
				this.internal_Param_AuSoinsDe = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@AuSoinsDe' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_AuSoinsDe_UseDefaultValue() {

			this.internal_Param_AuSoinsDe_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Rue'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [varchar](30)
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_Rue_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_Rue {

			get {

				if (this.internal_Param_Rue_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Rue);
			}

			set {

				this.internal_Param_Rue_UseDefaultValue = false;
				this.internal_Param_Rue = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Rue' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Rue_UseDefaultValue() {

			this.internal_Param_Rue_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Ville'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [varchar](30)
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
		/// Sets the value of the stored procedure INPUT parameter '@PaysID'.
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
		/// the parameter default value, consider calling the Param_PaysID_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_PaysID {

			get {

				if (this.internal_Param_PaysID_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_PaysID);
			}

			set {

				this.internal_Param_PaysID_UseDefaultValue = false;
				this.internal_Param_PaysID = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@PaysID' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_PaysID_UseDefaultValue() {

			this.internal_Param_PaysID_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Code_postal'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [varchar](7)
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_Code_postal_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_Code_postal {

			get {

				if (this.internal_Param_Code_postal_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Code_postal);
			}

			set {

				this.internal_Param_Code_postal_UseDefaultValue = false;
				this.internal_Param_Code_postal = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Code_postal' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Code_postal_UseDefaultValue() {

			this.internal_Param_Code_postal_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Telephone'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [varchar](12)
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_Telephone_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_Telephone {

			get {

				if (this.internal_Param_Telephone_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Telephone);
			}

			set {

				this.internal_Param_Telephone_UseDefaultValue = false;
				this.internal_Param_Telephone = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Telephone' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Telephone_UseDefaultValue() {

			this.internal_Param_Telephone_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Telephone_Poste'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [varchar](4)
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_Telephone_Poste_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_Telephone_Poste {

			get {

				if (this.internal_Param_Telephone_Poste_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Telephone_Poste);
			}

			set {

				this.internal_Param_Telephone_Poste_UseDefaultValue = false;
				this.internal_Param_Telephone_Poste = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Telephone_Poste' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Telephone_Poste_UseDefaultValue() {

			this.internal_Param_Telephone_Poste_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Telecopieur'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [varchar](12)
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_Telecopieur_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_Telecopieur {

			get {

				if (this.internal_Param_Telecopieur_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Telecopieur);
			}

			set {

				this.internal_Param_Telecopieur_UseDefaultValue = false;
				this.internal_Param_Telecopieur = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Telecopieur' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Telecopieur_UseDefaultValue() {

			this.internal_Param_Telecopieur_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Telephone2'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [varchar](12)
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_Telephone2_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_Telephone2 {

			get {

				if (this.internal_Param_Telephone2_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Telephone2);
			}

			set {

				this.internal_Param_Telephone2_UseDefaultValue = false;
				this.internal_Param_Telephone2 = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Telephone2' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Telephone2_UseDefaultValue() {

			this.internal_Param_Telephone2_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Telephone2_Desc'.
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
		/// the parameter default value, consider calling the Param_Telephone2_Desc_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_Telephone2_Desc {

			get {

				if (this.internal_Param_Telephone2_Desc_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Telephone2_Desc);
			}

			set {

				this.internal_Param_Telephone2_Desc_UseDefaultValue = false;
				this.internal_Param_Telephone2_Desc = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Telephone2_Desc' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Telephone2_Desc_UseDefaultValue() {

			this.internal_Param_Telephone2_Desc_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Telephone2_Poste'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [varchar](4)
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_Telephone2_Poste_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_Telephone2_Poste {

			get {

				if (this.internal_Param_Telephone2_Poste_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Telephone2_Poste);
			}

			set {

				this.internal_Param_Telephone2_Poste_UseDefaultValue = false;
				this.internal_Param_Telephone2_Poste = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Telephone2_Poste' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Telephone2_Poste_UseDefaultValue() {

			this.internal_Param_Telephone2_Poste_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Telephone3'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [varchar](12)
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_Telephone3_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_Telephone3 {

			get {

				if (this.internal_Param_Telephone3_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Telephone3);
			}

			set {

				this.internal_Param_Telephone3_UseDefaultValue = false;
				this.internal_Param_Telephone3 = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Telephone3' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Telephone3_UseDefaultValue() {

			this.internal_Param_Telephone3_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Telephone3_Desc'.
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
		/// the parameter default value, consider calling the Param_Telephone3_Desc_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_Telephone3_Desc {

			get {

				if (this.internal_Param_Telephone3_Desc_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Telephone3_Desc);
			}

			set {

				this.internal_Param_Telephone3_Desc_UseDefaultValue = false;
				this.internal_Param_Telephone3_Desc = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Telephone3_Desc' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Telephone3_Desc_UseDefaultValue() {

			this.internal_Param_Telephone3_Desc_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Telephone3_Poste'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [varchar](4)
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_Telephone3_Poste_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_Telephone3_Poste {

			get {

				if (this.internal_Param_Telephone3_Poste_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Telephone3_Poste);
			}

			set {

				this.internal_Param_Telephone3_Poste_UseDefaultValue = false;
				this.internal_Param_Telephone3_Poste = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Telephone3_Poste' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Telephone3_Poste_UseDefaultValue() {

			this.internal_Param_Telephone3_Poste_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@No_membre'.
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
		/// the parameter default value, consider calling the Param_No_membre_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_No_membre {

			get {

				if (this.internal_Param_No_membre_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_No_membre);
			}

			set {

				this.internal_Param_No_membre_UseDefaultValue = false;
				this.internal_Param_No_membre = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@No_membre' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_No_membre_UseDefaultValue() {

			this.internal_Param_No_membre_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Resident'.
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
		/// the parameter default value, consider calling the Param_Resident_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_Resident {

			get {

				if (this.internal_Param_Resident_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Resident);
			}

			set {

				this.internal_Param_Resident_UseDefaultValue = false;
				this.internal_Param_Resident = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Resident' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Resident_UseDefaultValue() {

			this.internal_Param_Resident_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Email'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [varchar](80)
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_Email_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_Email {

			get {

				if (this.internal_Param_Email_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Email);
			}

			set {

				this.internal_Param_Email_UseDefaultValue = false;
				this.internal_Param_Email = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Email' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Email_UseDefaultValue() {

			this.internal_Param_Email_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@WWW'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [varchar](80)
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_WWW_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_WWW {

			get {

				if (this.internal_Param_WWW_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_WWW);
			}

			set {

				this.internal_Param_WWW_UseDefaultValue = false;
				this.internal_Param_WWW = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@WWW' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_WWW_UseDefaultValue() {

			this.internal_Param_WWW_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Commentaires'.
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
		/// the parameter default value, consider calling the Param_Commentaires_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_Commentaires {

			get {

				if (this.internal_Param_Commentaires_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Commentaires);
			}

			set {

				this.internal_Param_Commentaires_UseDefaultValue = false;
				this.internal_Param_Commentaires = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Commentaires' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Commentaires_UseDefaultValue() {

			this.internal_Param_Commentaires_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@AfficherCommentaires'.
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
		/// the parameter default value, consider calling the Param_AfficherCommentaires_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_AfficherCommentaires {

			get {

				if (this.internal_Param_AfficherCommentaires_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_AfficherCommentaires);
			}

			set {

				this.internal_Param_AfficherCommentaires_UseDefaultValue = false;
				this.internal_Param_AfficherCommentaires = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@AfficherCommentaires' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_AfficherCommentaires_UseDefaultValue() {

			this.internal_Param_AfficherCommentaires_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@DepotDirect'.
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
		/// the parameter default value, consider calling the Param_DepotDirect_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_DepotDirect {

			get {

				if (this.internal_Param_DepotDirect_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_DepotDirect);
			}

			set {

				this.internal_Param_DepotDirect_UseDefaultValue = false;
				this.internal_Param_DepotDirect = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@DepotDirect' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_DepotDirect_UseDefaultValue() {

			this.internal_Param_DepotDirect_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@InstitutionBanquaireID'.
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
		/// the parameter default value, consider calling the Param_InstitutionBanquaireID_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_InstitutionBanquaireID {

			get {

				if (this.internal_Param_InstitutionBanquaireID_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_InstitutionBanquaireID);
			}

			set {

				this.internal_Param_InstitutionBanquaireID_UseDefaultValue = false;
				this.internal_Param_InstitutionBanquaireID = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@InstitutionBanquaireID' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_InstitutionBanquaireID_UseDefaultValue() {

			this.internal_Param_InstitutionBanquaireID_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Banque_transit'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [varchar](5)
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_Banque_transit_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_Banque_transit {

			get {

				if (this.internal_Param_Banque_transit_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Banque_transit);
			}

			set {

				this.internal_Param_Banque_transit_UseDefaultValue = false;
				this.internal_Param_Banque_transit = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Banque_transit' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Banque_transit_UseDefaultValue() {

			this.internal_Param_Banque_transit_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Banque_folio'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [varchar](12)
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_Banque_folio_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_Banque_folio {

			get {

				if (this.internal_Param_Banque_folio_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Banque_folio);
			}

			set {

				this.internal_Param_Banque_folio_UseDefaultValue = false;
				this.internal_Param_Banque_folio = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Banque_folio' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Banque_folio_UseDefaultValue() {

			this.internal_Param_Banque_folio_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@No_TPS'.
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
		/// the parameter default value, consider calling the Param_No_TPS_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_No_TPS {

			get {

				if (this.internal_Param_No_TPS_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_No_TPS);
			}

			set {

				this.internal_Param_No_TPS_UseDefaultValue = false;
				this.internal_Param_No_TPS = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@No_TPS' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_No_TPS_UseDefaultValue() {

			this.internal_Param_No_TPS_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@No_TVQ'.
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
		/// the parameter default value, consider calling the Param_No_TVQ_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_No_TVQ {

			get {

				if (this.internal_Param_No_TVQ_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_No_TVQ);
			}

			set {

				this.internal_Param_No_TVQ_UseDefaultValue = false;
				this.internal_Param_No_TVQ = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@No_TVQ' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_No_TVQ_UseDefaultValue() {

			this.internal_Param_No_TVQ_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@PayerA'.
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
		/// the parameter default value, consider calling the Param_PayerA_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_PayerA {

			get {

				if (this.internal_Param_PayerA_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_PayerA);
			}

			set {

				this.internal_Param_PayerA_UseDefaultValue = false;
				this.internal_Param_PayerA = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@PayerA' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_PayerA_UseDefaultValue() {

			this.internal_Param_PayerA_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@PayerAID'.
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
		/// Sets the value of the stored procedure INPUT parameter '@Statut'.
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
		/// the parameter default value, consider calling the Param_Statut_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_Statut {

			get {

				if (this.internal_Param_Statut_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Statut);
			}

			set {

				this.internal_Param_Statut_UseDefaultValue = false;
				this.internal_Param_Statut = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Statut' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Statut_UseDefaultValue() {

			this.internal_Param_Statut_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Rep_Nom'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [varchar](30)
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_Rep_Nom_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_Rep_Nom {

			get {

				if (this.internal_Param_Rep_Nom_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Rep_Nom);
			}

			set {

				this.internal_Param_Rep_Nom_UseDefaultValue = false;
				this.internal_Param_Rep_Nom = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Rep_Nom' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Rep_Nom_UseDefaultValue() {

			this.internal_Param_Rep_Nom_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Rep_Telephone'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [varchar](12)
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_Rep_Telephone_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_Rep_Telephone {

			get {

				if (this.internal_Param_Rep_Telephone_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Rep_Telephone);
			}

			set {

				this.internal_Param_Rep_Telephone_UseDefaultValue = false;
				this.internal_Param_Rep_Telephone = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Rep_Telephone' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Rep_Telephone_UseDefaultValue() {

			this.internal_Param_Rep_Telephone_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Rep_Telephone_Poste'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [varchar](4)
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_Rep_Telephone_Poste_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_Rep_Telephone_Poste {

			get {

				if (this.internal_Param_Rep_Telephone_Poste_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Rep_Telephone_Poste);
			}

			set {

				this.internal_Param_Rep_Telephone_Poste_UseDefaultValue = false;
				this.internal_Param_Rep_Telephone_Poste = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Rep_Telephone_Poste' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Rep_Telephone_Poste_UseDefaultValue() {

			this.internal_Param_Rep_Telephone_Poste_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Rep_Email'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [varchar](80)
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_Rep_Email_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_Rep_Email {

			get {

				if (this.internal_Param_Rep_Email_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Rep_Email);
			}

			set {

				this.internal_Param_Rep_Email_UseDefaultValue = false;
				this.internal_Param_Rep_Email = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Rep_Email' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Rep_Email_UseDefaultValue() {

			this.internal_Param_Rep_Email_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@EnAnglais'.
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
		/// the parameter default value, consider calling the Param_EnAnglais_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_EnAnglais {

			get {

				if (this.internal_Param_EnAnglais_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_EnAnglais);
			}

			set {

				this.internal_Param_EnAnglais_UseDefaultValue = false;
				this.internal_Param_EnAnglais = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@EnAnglais' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_EnAnglais_UseDefaultValue() {

			this.internal_Param_EnAnglais_UseDefaultValue = true;
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
		/// Sets the value of the stored procedure INPUT parameter '@MRCProducteurID'.
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
		/// the parameter default value, consider calling the Param_MRCProducteurID_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlInt32 Param_MRCProducteurID {

			get {

				if (this.internal_Param_MRCProducteurID_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_MRCProducteurID);
			}

			set {

				this.internal_Param_MRCProducteurID_UseDefaultValue = false;
				this.internal_Param_MRCProducteurID = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@MRCProducteurID' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_MRCProducteurID_UseDefaultValue() {

			this.internal_Param_MRCProducteurID_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@PaiementManuel'.
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
		/// the parameter default value, consider calling the Param_PaiementManuel_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_PaiementManuel {

			get {

				if (this.internal_Param_PaiementManuel_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_PaiementManuel);
			}

			set {

				this.internal_Param_PaiementManuel_UseDefaultValue = false;
				this.internal_Param_PaiementManuel = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@PaiementManuel' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_PaiementManuel_UseDefaultValue() {

			this.internal_Param_PaiementManuel_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Journal'.
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
		/// the parameter default value, consider calling the Param_Journal_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_Journal {

			get {

				if (this.internal_Param_Journal_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Journal);
			}

			set {

				this.internal_Param_Journal_UseDefaultValue = false;
				this.internal_Param_Journal = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Journal' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Journal_UseDefaultValue() {

			this.internal_Param_Journal_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@RecoitTPS'.
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
		/// the parameter default value, consider calling the Param_RecoitTPS_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_RecoitTPS {

			get {

				if (this.internal_Param_RecoitTPS_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_RecoitTPS);
			}

			set {

				this.internal_Param_RecoitTPS_UseDefaultValue = false;
				this.internal_Param_RecoitTPS = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@RecoitTPS' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_RecoitTPS_UseDefaultValue() {

			this.internal_Param_RecoitTPS_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@RecoitTVQ'.
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
		/// the parameter default value, consider calling the Param_RecoitTVQ_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_RecoitTVQ {

			get {

				if (this.internal_Param_RecoitTVQ_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_RecoitTVQ);
			}

			set {

				this.internal_Param_RecoitTVQ_UseDefaultValue = false;
				this.internal_Param_RecoitTVQ = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@RecoitTVQ' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_RecoitTVQ_UseDefaultValue() {

			this.internal_Param_RecoitTVQ_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ModifierTrigger'.
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
		/// the parameter default value, consider calling the Param_ModifierTrigger_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ModifierTrigger {

			get {

				if (this.internal_Param_ModifierTrigger_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ModifierTrigger);
			}

			set {

				this.internal_Param_ModifierTrigger_UseDefaultValue = false;
				this.internal_Param_ModifierTrigger = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ModifierTrigger' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ModifierTrigger_UseDefaultValue() {

			this.internal_Param_ModifierTrigger_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@IsProducteur'.
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
		/// the parameter default value, consider calling the Param_IsProducteur_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_IsProducteur {

			get {

				if (this.internal_Param_IsProducteur_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_IsProducteur);
			}

			set {

				this.internal_Param_IsProducteur_UseDefaultValue = false;
				this.internal_Param_IsProducteur = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@IsProducteur' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_IsProducteur_UseDefaultValue() {

			this.internal_Param_IsProducteur_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@IsTransporteur'.
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
		/// the parameter default value, consider calling the Param_IsTransporteur_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_IsTransporteur {

			get {

				if (this.internal_Param_IsTransporteur_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_IsTransporteur);
			}

			set {

				this.internal_Param_IsTransporteur_UseDefaultValue = false;
				this.internal_Param_IsTransporteur = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@IsTransporteur' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_IsTransporteur_UseDefaultValue() {

			this.internal_Param_IsTransporteur_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@IsChargeur'.
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
		/// the parameter default value, consider calling the Param_IsChargeur_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_IsChargeur {

			get {

				if (this.internal_Param_IsChargeur_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_IsChargeur);
			}

			set {

				this.internal_Param_IsChargeur_UseDefaultValue = false;
				this.internal_Param_IsChargeur = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@IsChargeur' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_IsChargeur_UseDefaultValue() {

			this.internal_Param_IsChargeur_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@IsAutre'.
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
		/// the parameter default value, consider calling the Param_IsAutre_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_IsAutre {

			get {

				if (this.internal_Param_IsAutre_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_IsAutre);
			}

			set {

				this.internal_Param_IsAutre_UseDefaultValue = false;
				this.internal_Param_IsAutre = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@IsAutre' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_IsAutre_UseDefaultValue() {

			this.internal_Param_IsAutre_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@AfficherCommentairesSurPermit'.
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
		/// the parameter default value, consider calling the Param_AfficherCommentairesSurPermit_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_AfficherCommentairesSurPermit {

			get {

				if (this.internal_Param_AfficherCommentairesSurPermit_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_AfficherCommentairesSurPermit);
			}

			set {

				this.internal_Param_AfficherCommentairesSurPermit_UseDefaultValue = false;
				this.internal_Param_AfficherCommentairesSurPermit = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@AfficherCommentairesSurPermit' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_AfficherCommentairesSurPermit_UseDefaultValue() {

			this.internal_Param_AfficherCommentairesSurPermit_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@PasEmissionPermis'.
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
		/// the parameter default value, consider calling the Param_PasEmissionPermis_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_PasEmissionPermis {

			get {

				if (this.internal_Param_PasEmissionPermis_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_PasEmissionPermis);
			}

			set {

				this.internal_Param_PasEmissionPermis_UseDefaultValue = false;
				this.internal_Param_PasEmissionPermis = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@PasEmissionPermis' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_PasEmissionPermis_UseDefaultValue() {

			this.internal_Param_PasEmissionPermis_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Generique'.
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
		/// the parameter default value, consider calling the Param_Generique_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_Generique {

			get {

				if (this.internal_Param_Generique_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Generique);
			}

			set {

				this.internal_Param_Generique_UseDefaultValue = false;
				this.internal_Param_Generique = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Generique' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Generique_UseDefaultValue() {

			this.internal_Param_Generique_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Membre_OGC'.
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
		/// the parameter default value, consider calling the Param_Membre_OGC_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_Membre_OGC {

			get {

				if (this.internal_Param_Membre_OGC_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Membre_OGC);
			}

			set {

				this.internal_Param_Membre_OGC_UseDefaultValue = false;
				this.internal_Param_Membre_OGC = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Membre_OGC' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Membre_OGC_UseDefaultValue() {

			this.internal_Param_Membre_OGC_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@InscritTPS'.
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
		/// the parameter default value, consider calling the Param_InscritTPS_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_InscritTPS {

			get {

				if (this.internal_Param_InscritTPS_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_InscritTPS);
			}

			set {

				this.internal_Param_InscritTPS_UseDefaultValue = false;
				this.internal_Param_InscritTPS = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@InscritTPS' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_InscritTPS_UseDefaultValue() {

			this.internal_Param_InscritTPS_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@InscritTVQ'.
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
		/// the parameter default value, consider calling the Param_InscritTVQ_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_InscritTVQ {

			get {

				if (this.internal_Param_InscritTVQ_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_InscritTVQ);
			}

			set {

				this.internal_Param_InscritTVQ_UseDefaultValue = false;
				this.internal_Param_InscritTVQ = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@InscritTVQ' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_InscritTVQ_UseDefaultValue() {

			this.internal_Param_InscritTVQ_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@IsOGC'.
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
		/// the parameter default value, consider calling the Param_IsOGC_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_IsOGC {

			get {

				if (this.internal_Param_IsOGC_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_IsOGC);
			}

			set {

				this.internal_Param_IsOGC_UseDefaultValue = false;
				this.internal_Param_IsOGC = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@IsOGC' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_IsOGC_UseDefaultValue() {

			this.internal_Param_IsOGC_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Rep2_Nom'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [varchar](80)
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_Rep2_Nom_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_Rep2_Nom {

			get {

				if (this.internal_Param_Rep2_Nom_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Rep2_Nom);
			}

			set {

				this.internal_Param_Rep2_Nom_UseDefaultValue = false;
				this.internal_Param_Rep2_Nom = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Rep2_Nom' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Rep2_Nom_UseDefaultValue() {

			this.internal_Param_Rep2_Nom_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Rep2_Telephone'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [varchar](12)
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_Rep2_Telephone_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_Rep2_Telephone {

			get {

				if (this.internal_Param_Rep2_Telephone_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Rep2_Telephone);
			}

			set {

				this.internal_Param_Rep2_Telephone_UseDefaultValue = false;
				this.internal_Param_Rep2_Telephone = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Rep2_Telephone' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Rep2_Telephone_UseDefaultValue() {

			this.internal_Param_Rep2_Telephone_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Rep2_Telephone_Poste'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [varchar](4)
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_Rep2_Telephone_Poste_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_Rep2_Telephone_Poste {

			get {

				if (this.internal_Param_Rep2_Telephone_Poste_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Rep2_Telephone_Poste);
			}

			set {

				this.internal_Param_Rep2_Telephone_Poste_UseDefaultValue = false;
				this.internal_Param_Rep2_Telephone_Poste = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Rep2_Telephone_Poste' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Rep2_Telephone_Poste_UseDefaultValue() {

			this.internal_Param_Rep2_Telephone_Poste_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Rep2_Email'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [varchar](80)
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_Rep2_Email_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_Rep2_Email {

			get {

				if (this.internal_Param_Rep2_Email_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Rep2_Email);
			}

			set {

				this.internal_Param_Rep2_Email_UseDefaultValue = false;
				this.internal_Param_Rep2_Email = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Rep2_Email' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Rep2_Email_UseDefaultValue() {

			this.internal_Param_Rep2_Email_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Rep2_Commentaires'.
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
		/// the parameter default value, consider calling the Param_Rep2_Commentaires_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_Rep2_Commentaires {

			get {

				if (this.internal_Param_Rep2_Commentaires_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Rep2_Commentaires);
			}

			set {

				this.internal_Param_Rep2_Commentaires_UseDefaultValue = false;
				this.internal_Param_Rep2_Commentaires = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Rep2_Commentaires' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Rep2_Commentaires_UseDefaultValue() {

			this.internal_Param_Rep2_Commentaires_UseDefaultValue = true;
		}

  	}
}

namespace Gestion_Paie.DataClasses.StoredProcedures {

	/// <summary>
	/// This class allows you to execute the 'spI_Fournisseur' stored procedure;
	/// it gives you the ability to:
	/// <list type="bullet">
	/// <item><description>Set all the necessary parameters to execute the stored procedure</description></item>
	/// <item><description>To execute the stored procedure</description></item>
	/// <item><description>To get back after the execution the return value and all the output parameters value</description></item>
	/// </list>
	/// </summary>
	public sealed class spI_Fournisseur : MarshalByRefObject, IDisposable {


		private bool throwExceptionOnExecute = false;

		/// <summary>
		/// Initializes a new instance of the spI_Fournisseur class.
		/// By default, no exception will be thrown when you call the Execute method. Instead, a Boolean return status will be returned.
		/// </summary>
		public spI_Fournisseur() : this(false) {

		}

		/// <summary>
		/// Initializes a new instance of the spI_Fournisseur class.
		/// </summary>
		/// <param name="throwExceptionOnExecute">True if an exception has to be thrown if the Execute call fails.</param>
		public spI_Fournisseur(bool throwExceptionOnExecute) {

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
		~spI_Fournisseur() {

			Dispose(false);
		}

		private void ResetParameter(ref Gestion_Paie.DataClasses.Parameters.spI_Fournisseur parameters) {

			parameters.internal_Set_RETURN_VALUE (System.Data.SqlTypes.SqlInt32.Null);
		}

		private bool InitializeConnection(ref Gestion_Paie.DataClasses.Parameters.spI_Fournisseur parameters, out System.Data.SqlClient.SqlCommand sqlCommand, ref bool connectionMustBeClosed) {

			try {

				this.sqlConnection = null;
				sqlCommand = null;
				connectionMustBeClosed = true;

				if (parameters.ConnectionType == ConnectionType.None) {

					throw new InvalidOperationException("No connection information was supplied. Consider calling the 'SetUpConnection' method of the Gestion_Paie.DataClasses.Parameters.spI_Fournisseur object before doing this call.");
				}

				if (parameters.ConnectionType == ConnectionType.SqlConnection && parameters.SqlConnection == null) {

					throw new InvalidOperationException("No connection information was supplied (SqlConnection == null). Consider calling the 'SetUpConnection' method of the Gestion_Paie.DataClasses.Parameters.spI_Fournisseur object before doing this call.");
				}

				if (parameters.ConnectionType == ConnectionType.SqlTransaction && parameters.SqlTransaction== null) {

					throw new InvalidOperationException("No connection information was supplied (SqlTransaction == null). Consider calling the 'SetUpConnection' method of the Gestion_Paie.DataClasses.Parameters.spI_Fournisseur object before doing this call.");
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

							throw new System.InvalidOperationException("No connection information was supplied (ConnectionString == \"\")! (Gestion_Paie.DataClasses.Parameters.spI_Fournisseur)");
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
				sqlCommand.CommandText = "spI_Fournisseur";

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

		private bool DeclareParameters(ref Gestion_Paie.DataClasses.Parameters.spI_Fournisseur parameters, ref System.Data.SqlClient.SqlCommand sqlCommand) {

			try {

				System.Data.SqlClient.SqlParameter sqlParameter;

				sqlParameter = new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4);
				sqlParameter.Direction = System.Data.ParameterDirection.ReturnValue;
				sqlParameter.IsNullable = true;
				sqlParameter.Value = System.DBNull.Value;
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.VarChar, 15);
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

				sqlParameter = new System.Data.SqlClient.SqlParameter("@CleTri", System.Data.SqlDbType.VarChar, 15);
				sqlParameter.SourceColumn = "CleTri";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_CleTri_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_CleTri.IsNull) {

					sqlParameter.Value = parameters.Param_CleTri;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Nom", System.Data.SqlDbType.VarChar, 40);
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

				sqlParameter = new System.Data.SqlClient.SqlParameter("@AuSoinsDe", System.Data.SqlDbType.VarChar, 30);
				sqlParameter.SourceColumn = "AuSoinsDe";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_AuSoinsDe_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_AuSoinsDe.IsNull) {

					sqlParameter.Value = parameters.Param_AuSoinsDe;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Rue", System.Data.SqlDbType.VarChar, 30);
				sqlParameter.SourceColumn = "Rue";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Rue_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Rue.IsNull) {

					sqlParameter.Value = parameters.Param_Rue;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Ville", System.Data.SqlDbType.VarChar, 30);
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

				sqlParameter = new System.Data.SqlClient.SqlParameter("@PaysID", System.Data.SqlDbType.VarChar, 2);
				sqlParameter.SourceColumn = "PaysID";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_PaysID_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_PaysID.IsNull) {

					sqlParameter.Value = parameters.Param_PaysID;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Code_postal", System.Data.SqlDbType.VarChar, 7);
				sqlParameter.SourceColumn = "Code_postal";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Code_postal_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Code_postal.IsNull) {

					sqlParameter.Value = parameters.Param_Code_postal;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Telephone", System.Data.SqlDbType.VarChar, 12);
				sqlParameter.SourceColumn = "Telephone";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Telephone_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Telephone.IsNull) {

					sqlParameter.Value = parameters.Param_Telephone;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Telephone_Poste", System.Data.SqlDbType.VarChar, 4);
				sqlParameter.SourceColumn = "Telephone_Poste";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Telephone_Poste_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Telephone_Poste.IsNull) {

					sqlParameter.Value = parameters.Param_Telephone_Poste;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Telecopieur", System.Data.SqlDbType.VarChar, 12);
				sqlParameter.SourceColumn = "Telecopieur";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Telecopieur_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Telecopieur.IsNull) {

					sqlParameter.Value = parameters.Param_Telecopieur;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Telephone2", System.Data.SqlDbType.VarChar, 12);
				sqlParameter.SourceColumn = "Telephone2";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Telephone2_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Telephone2.IsNull) {

					sqlParameter.Value = parameters.Param_Telephone2;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Telephone2_Desc", System.Data.SqlDbType.VarChar, 20);
				sqlParameter.SourceColumn = "Telephone2_Desc";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Telephone2_Desc_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Telephone2_Desc.IsNull) {

					sqlParameter.Value = parameters.Param_Telephone2_Desc;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Telephone2_Poste", System.Data.SqlDbType.VarChar, 4);
				sqlParameter.SourceColumn = "Telephone2_Poste";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Telephone2_Poste_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Telephone2_Poste.IsNull) {

					sqlParameter.Value = parameters.Param_Telephone2_Poste;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Telephone3", System.Data.SqlDbType.VarChar, 12);
				sqlParameter.SourceColumn = "Telephone3";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Telephone3_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Telephone3.IsNull) {

					sqlParameter.Value = parameters.Param_Telephone3;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Telephone3_Desc", System.Data.SqlDbType.VarChar, 20);
				sqlParameter.SourceColumn = "Telephone3_Desc";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Telephone3_Desc_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Telephone3_Desc.IsNull) {

					sqlParameter.Value = parameters.Param_Telephone3_Desc;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Telephone3_Poste", System.Data.SqlDbType.VarChar, 4);
				sqlParameter.SourceColumn = "Telephone3_Poste";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Telephone3_Poste_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Telephone3_Poste.IsNull) {

					sqlParameter.Value = parameters.Param_Telephone3_Poste;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@No_membre", System.Data.SqlDbType.VarChar, 10);
				sqlParameter.SourceColumn = "No_membre";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_No_membre_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_No_membre.IsNull) {

					sqlParameter.Value = parameters.Param_No_membre;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Resident", System.Data.SqlDbType.Char, 1);
				sqlParameter.SourceColumn = "Resident";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Resident_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Resident.IsNull) {

					sqlParameter.Value = parameters.Param_Resident;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Email", System.Data.SqlDbType.VarChar, 80);
				sqlParameter.SourceColumn = "Email";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Email_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Email.IsNull) {

					sqlParameter.Value = parameters.Param_Email;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@WWW", System.Data.SqlDbType.VarChar, 80);
				sqlParameter.SourceColumn = "WWW";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_WWW_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_WWW.IsNull) {

					sqlParameter.Value = parameters.Param_WWW;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Commentaires", System.Data.SqlDbType.VarChar, 255);
				sqlParameter.SourceColumn = "Commentaires";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Commentaires_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Commentaires.IsNull) {

					sqlParameter.Value = parameters.Param_Commentaires;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@AfficherCommentaires", System.Data.SqlDbType.Bit, 1);
				sqlParameter.SourceColumn = "AfficherCommentaires";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_AfficherCommentaires_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_AfficherCommentaires.IsNull) {

					sqlParameter.Value = parameters.Param_AfficherCommentaires;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@DepotDirect", System.Data.SqlDbType.Bit, 1);
				sqlParameter.SourceColumn = "DepotDirect";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_DepotDirect_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_DepotDirect.IsNull) {

					sqlParameter.Value = parameters.Param_DepotDirect;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@InstitutionBanquaireID", System.Data.SqlDbType.VarChar, 3);
				sqlParameter.SourceColumn = "InstitutionBanquaireID";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_InstitutionBanquaireID_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_InstitutionBanquaireID.IsNull) {

					sqlParameter.Value = parameters.Param_InstitutionBanquaireID;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Banque_transit", System.Data.SqlDbType.VarChar, 5);
				sqlParameter.SourceColumn = "Banque_transit";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Banque_transit_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Banque_transit.IsNull) {

					sqlParameter.Value = parameters.Param_Banque_transit;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Banque_folio", System.Data.SqlDbType.VarChar, 12);
				sqlParameter.SourceColumn = "Banque_folio";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Banque_folio_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Banque_folio.IsNull) {

					sqlParameter.Value = parameters.Param_Banque_folio;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@No_TPS", System.Data.SqlDbType.VarChar, 25);
				sqlParameter.SourceColumn = "No_TPS";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_No_TPS_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_No_TPS.IsNull) {

					sqlParameter.Value = parameters.Param_No_TPS;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@No_TVQ", System.Data.SqlDbType.VarChar, 25);
				sqlParameter.SourceColumn = "No_TVQ";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_No_TVQ_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_No_TVQ.IsNull) {

					sqlParameter.Value = parameters.Param_No_TVQ;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@PayerA", System.Data.SqlDbType.Bit, 1);
				sqlParameter.SourceColumn = "PayerA";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_PayerA_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_PayerA.IsNull) {

					sqlParameter.Value = parameters.Param_PayerA;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@PayerAID", System.Data.SqlDbType.VarChar, 15);
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

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Statut", System.Data.SqlDbType.VarChar, 50);
				sqlParameter.SourceColumn = "Statut";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Statut_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Statut.IsNull) {

					sqlParameter.Value = parameters.Param_Statut;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Rep_Nom", System.Data.SqlDbType.VarChar, 30);
				sqlParameter.SourceColumn = "Rep_Nom";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Rep_Nom_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Rep_Nom.IsNull) {

					sqlParameter.Value = parameters.Param_Rep_Nom;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Rep_Telephone", System.Data.SqlDbType.VarChar, 12);
				sqlParameter.SourceColumn = "Rep_Telephone";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Rep_Telephone_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Rep_Telephone.IsNull) {

					sqlParameter.Value = parameters.Param_Rep_Telephone;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Rep_Telephone_Poste", System.Data.SqlDbType.VarChar, 4);
				sqlParameter.SourceColumn = "Rep_Telephone_Poste";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Rep_Telephone_Poste_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Rep_Telephone_Poste.IsNull) {

					sqlParameter.Value = parameters.Param_Rep_Telephone_Poste;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Rep_Email", System.Data.SqlDbType.VarChar, 80);
				sqlParameter.SourceColumn = "Rep_Email";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Rep_Email_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Rep_Email.IsNull) {

					sqlParameter.Value = parameters.Param_Rep_Email;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@EnAnglais", System.Data.SqlDbType.Bit, 1);
				sqlParameter.SourceColumn = "EnAnglais";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_EnAnglais_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_EnAnglais.IsNull) {

					sqlParameter.Value = parameters.Param_EnAnglais;
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

				sqlParameter = new System.Data.SqlClient.SqlParameter("@MRCProducteurID", System.Data.SqlDbType.Int, 4);
				sqlParameter.SourceColumn = "MRCProducteurID";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_MRCProducteurID_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_MRCProducteurID.IsNull) {

					sqlParameter.Value = parameters.Param_MRCProducteurID;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@PaiementManuel", System.Data.SqlDbType.Bit, 1);
				sqlParameter.SourceColumn = "PaiementManuel";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_PaiementManuel_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_PaiementManuel.IsNull) {

					sqlParameter.Value = parameters.Param_PaiementManuel;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Journal", System.Data.SqlDbType.Bit, 1);
				sqlParameter.SourceColumn = "Journal";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Journal_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Journal.IsNull) {

					sqlParameter.Value = parameters.Param_Journal;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@RecoitTPS", System.Data.SqlDbType.Bit, 1);
				sqlParameter.SourceColumn = "RecoitTPS";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_RecoitTPS_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_RecoitTPS.IsNull) {

					sqlParameter.Value = parameters.Param_RecoitTPS;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@RecoitTVQ", System.Data.SqlDbType.Bit, 1);
				sqlParameter.SourceColumn = "RecoitTVQ";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_RecoitTVQ_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_RecoitTVQ.IsNull) {

					sqlParameter.Value = parameters.Param_RecoitTVQ;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ModifierTrigger", System.Data.SqlDbType.Bit, 1);
				sqlParameter.SourceColumn = "ModifierTrigger";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ModifierTrigger_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ModifierTrigger.IsNull) {

					sqlParameter.Value = parameters.Param_ModifierTrigger;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@IsProducteur", System.Data.SqlDbType.Bit, 1);
				sqlParameter.SourceColumn = "IsProducteur";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_IsProducteur_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_IsProducteur.IsNull) {

					sqlParameter.Value = parameters.Param_IsProducteur;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@IsTransporteur", System.Data.SqlDbType.Bit, 1);
				sqlParameter.SourceColumn = "IsTransporteur";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_IsTransporteur_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_IsTransporteur.IsNull) {

					sqlParameter.Value = parameters.Param_IsTransporteur;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@IsChargeur", System.Data.SqlDbType.Bit, 1);
				sqlParameter.SourceColumn = "IsChargeur";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_IsChargeur_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_IsChargeur.IsNull) {

					sqlParameter.Value = parameters.Param_IsChargeur;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@IsAutre", System.Data.SqlDbType.Bit, 1);
				sqlParameter.SourceColumn = "IsAutre";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_IsAutre_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_IsAutre.IsNull) {

					sqlParameter.Value = parameters.Param_IsAutre;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@AfficherCommentairesSurPermit", System.Data.SqlDbType.Bit, 1);
				sqlParameter.SourceColumn = "AfficherCommentairesSurPermit";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_AfficherCommentairesSurPermit_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_AfficherCommentairesSurPermit.IsNull) {

					sqlParameter.Value = parameters.Param_AfficherCommentairesSurPermit;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@PasEmissionPermis", System.Data.SqlDbType.Bit, 1);
				sqlParameter.SourceColumn = "PasEmissionPermis";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_PasEmissionPermis_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_PasEmissionPermis.IsNull) {

					sqlParameter.Value = parameters.Param_PasEmissionPermis;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Generique", System.Data.SqlDbType.Bit, 1);
				sqlParameter.SourceColumn = "Generique";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Generique_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Generique.IsNull) {

					sqlParameter.Value = parameters.Param_Generique;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Membre_OGC", System.Data.SqlDbType.Bit, 1);
				sqlParameter.SourceColumn = "Membre_OGC";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Membre_OGC_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Membre_OGC.IsNull) {

					sqlParameter.Value = parameters.Param_Membre_OGC;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@InscritTPS", System.Data.SqlDbType.Bit, 1);
				sqlParameter.SourceColumn = "InscritTPS";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_InscritTPS_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_InscritTPS.IsNull) {

					sqlParameter.Value = parameters.Param_InscritTPS;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@InscritTVQ", System.Data.SqlDbType.Bit, 1);
				sqlParameter.SourceColumn = "InscritTVQ";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_InscritTVQ_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_InscritTVQ.IsNull) {

					sqlParameter.Value = parameters.Param_InscritTVQ;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@IsOGC", System.Data.SqlDbType.Bit, 1);
				sqlParameter.SourceColumn = "IsOGC";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_IsOGC_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_IsOGC.IsNull) {

					sqlParameter.Value = parameters.Param_IsOGC;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Rep2_Nom", System.Data.SqlDbType.VarChar, 80);
				sqlParameter.SourceColumn = "Rep2_Nom";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Rep2_Nom_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Rep2_Nom.IsNull) {

					sqlParameter.Value = parameters.Param_Rep2_Nom;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Rep2_Telephone", System.Data.SqlDbType.VarChar, 12);
				sqlParameter.SourceColumn = "Rep2_Telephone";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Rep2_Telephone_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Rep2_Telephone.IsNull) {

					sqlParameter.Value = parameters.Param_Rep2_Telephone;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Rep2_Telephone_Poste", System.Data.SqlDbType.VarChar, 4);
				sqlParameter.SourceColumn = "Rep2_Telephone_Poste";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Rep2_Telephone_Poste_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Rep2_Telephone_Poste.IsNull) {

					sqlParameter.Value = parameters.Param_Rep2_Telephone_Poste;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Rep2_Email", System.Data.SqlDbType.VarChar, 80);
				sqlParameter.SourceColumn = "Rep2_Email";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Rep2_Email_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Rep2_Email.IsNull) {

					sqlParameter.Value = parameters.Param_Rep2_Email;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Rep2_Commentaires", System.Data.SqlDbType.VarChar, 255);
				sqlParameter.SourceColumn = "Rep2_Commentaires";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Rep2_Commentaires_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Rep2_Commentaires.IsNull) {

					sqlParameter.Value = parameters.Param_Rep2_Commentaires;
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

		private bool RetrieveParameters(ref Gestion_Paie.DataClasses.Parameters.spI_Fournisseur parameters, ref System.Data.SqlClient.SqlCommand sqlCommand) {

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
		/// This method allows you to execute the [spI_Fournisseur] stored procedure.
		/// </summary>
		/// <param name="parameters">
		/// Contains all the necessary information to execute correctly the stored procedure, i.e. 
		/// the database connection to use and all the necessary input parameters to be supplied
		/// for this stored procedure execution. After the execution, this object will allow you
		/// to retrieve back the stored procedure return value and all the output parameters.
		/// </param>
		/// <returns>True if the call was successful. Otherwise, it returns False.</returns>
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.spI_Fournisseur parameters) {

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

