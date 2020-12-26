using System;
using Gestion_Paie.DataClasses;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.AbstractClasses {

	/// <summary>
	/// This class allows you to very easily retrieve a record from the [Fournisseur] table.
	/// </summary>
	[Serializable()]
	public sealed class Abstract_Fournisseur {

		Params.spS_Fournisseur Param;
		private bool CloseConnectionAfterUse = true;

		/// <summary>
		/// Create a new instance of the Abstract_Fournisseur class.
		/// </summary>
		/// <param name="connectionString">A valid connection string to the database.</param>
		public Abstract_Fournisseur(string connectionString) {

			if (connectionString == null) {

				throw new ArgumentNullException("connectionString", "connectionString can be an empty string but can not be null.");
			}

#if OLYMARS_DEBUG
			object olymarsDebugCheck = System.Configuration.ConfigurationSettings.AppSettings["OlymarsDebugCheck"];
			if (olymarsDebugCheck == null || (string)olymarsDebugCheck == "True") {

				string DebugConnectionString = connectionString;

				if (DebugConnectionString.Length == 0) {

					DebugConnectionString = Gestion_Paie.DataClasses.Information.GetConnectionStringFromConfigurationFile;
				}

				if (DebugConnectionString.Length == 0) {

					DebugConnectionString = Gestion_Paie.DataClasses.Information.GetConnectionStringFromRegistry;
				}

				if (DebugConnectionString.Length != 0) {

					System.Data.SqlClient.SqlConnection sqlConnection = new System.Data.SqlClient.SqlConnection(DebugConnectionString);

					sqlConnection.Open();

					System.Data.SqlClient.SqlCommand sqlCommand = sqlConnection.CreateCommand();

					sqlCommand.CommandType = System.Data.CommandType.Text;
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Fournisseur'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

						throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "Fournisseur", CurrentRevision, OriginalRevision, System.Environment.NewLine));
					}
				}
			}
#endif

			this.Param = new Params.spS_Fournisseur(true);
			this.Param.SetUpConnection(connectionString);
		}

		/// <summary>
		/// Create a new instance of the Abstract_Fournisseur class.
		/// </summary>
		/// <param name="sqlConnection">A valid System.Data.SqlClient.SqlConnection to the database.</param>
		public Abstract_Fournisseur(System.Data.SqlClient.SqlConnection sqlConnection) {

			if (sqlConnection == null) {

				throw new ArgumentNullException("sqlConnection", "Invalid connection!");
			}

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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Fournisseur'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlConnection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "Fournisseur", CurrentRevision, OriginalRevision, System.Environment.NewLine));
				}
			}
#endif

			this.Param = new Params.spS_Fournisseur(true);
			this.Param.SetUpConnection(sqlConnection);
			CloseConnectionAfterUse = (this.Param.SqlConnection.State != System.Data.ConnectionState.Open);
		}

		/// <summary>
		/// Create a new instance of the Abstract_Fournisseur class.
		/// </summary>
		/// <param name="sqlTransaction">A valid System.Data.SqlClient.SqlTransaction to the database.</param>
		public Abstract_Fournisseur(System.Data.SqlClient.SqlTransaction sqlTransaction) {

			if (sqlTransaction == null || sqlTransaction.Connection == null) {
				throw new ArgumentNullException("sqlTransaction", "Invalid transaction!");
			}

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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Fournisseur'";
				sqlCommand.Transaction = sqlTransaction;

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlTransaction.Connection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "Fournisseur", CurrentRevision, OriginalRevision, System.Environment.NewLine));
				}
			}
#endif

			this.Param = new Params.spS_Fournisseur(true);
			this.Param.SetUpConnection(sqlTransaction);
		}

		private System.Data.SqlTypes.SqlString col_ID;
		/// <summary>
		/// Returns the value of the ID column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;ID&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_ID {

			get {

				return (this.col_ID);
			}
		}

		private System.Data.SqlTypes.SqlString col_CleTri;
		/// <summary>
		/// Returns the value of the CleTri column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;CleTri&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_CleTri {

			get {

				return (this.col_CleTri);
			}
		}

		private System.Data.SqlTypes.SqlString col_Nom;
		/// <summary>
		/// Returns the value of the Nom column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Nom&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_Nom {

			get {

				return (this.col_Nom);
			}
		}

		private System.Data.SqlTypes.SqlString col_AuSoinsDe;
		/// <summary>
		/// Returns the value of the AuSoinsDe column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;AuSoinsDe&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_AuSoinsDe {

			get {

				return (this.col_AuSoinsDe);
			}
		}

		private System.Data.SqlTypes.SqlString col_Rue;
		/// <summary>
		/// Returns the value of the Rue column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Rue&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_Rue {

			get {

				return (this.col_Rue);
			}
		}

		private System.Data.SqlTypes.SqlString col_Ville;
		/// <summary>
		/// Returns the value of the Ville column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Ville&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_Ville {

			get {

				return (this.col_Ville);
			}
		}

		private System.Data.SqlTypes.SqlString col_PaysID;
		/// <summary>
		/// Returns the value of the PaysID column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;PaysID&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_PaysID {

			get {

				return (this.col_PaysID);
			}
		}

		private System.Data.SqlTypes.SqlString col_Code_postal;
		/// <summary>
		/// Returns the value of the Code_postal column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Code_postal&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_Code_postal {

			get {

				return (this.col_Code_postal);
			}
		}

		private System.Data.SqlTypes.SqlString col_Telephone;
		/// <summary>
		/// Returns the value of the Telephone column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Telephone&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_Telephone {

			get {

				return (this.col_Telephone);
			}
		}

		private System.Data.SqlTypes.SqlString col_Telephone_Poste;
		/// <summary>
		/// Returns the value of the Telephone_Poste column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Telephone_Poste&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_Telephone_Poste {

			get {

				return (this.col_Telephone_Poste);
			}
		}

		private System.Data.SqlTypes.SqlString col_Telecopieur;
		/// <summary>
		/// Returns the value of the Telecopieur column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Telecopieur&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_Telecopieur {

			get {

				return (this.col_Telecopieur);
			}
		}

		private System.Data.SqlTypes.SqlString col_Telephone2;
		/// <summary>
		/// Returns the value of the Telephone2 column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Telephone2&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_Telephone2 {

			get {

				return (this.col_Telephone2);
			}
		}

		private System.Data.SqlTypes.SqlString col_Telephone2_Desc;
		/// <summary>
		/// Returns the value of the Telephone2_Desc column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Telephone2_Desc&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_Telephone2_Desc {

			get {

				return (this.col_Telephone2_Desc);
			}
		}

		private System.Data.SqlTypes.SqlString col_Telephone2_Poste;
		/// <summary>
		/// Returns the value of the Telephone2_Poste column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Telephone2_Poste&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_Telephone2_Poste {

			get {

				return (this.col_Telephone2_Poste);
			}
		}

		private System.Data.SqlTypes.SqlString col_Telephone3;
		/// <summary>
		/// Returns the value of the Telephone3 column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Telephone3&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_Telephone3 {

			get {

				return (this.col_Telephone3);
			}
		}

		private System.Data.SqlTypes.SqlString col_Telephone3_Desc;
		/// <summary>
		/// Returns the value of the Telephone3_Desc column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Telephone3_Desc&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_Telephone3_Desc {

			get {

				return (this.col_Telephone3_Desc);
			}
		}

		private System.Data.SqlTypes.SqlString col_Telephone3_Poste;
		/// <summary>
		/// Returns the value of the Telephone3_Poste column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Telephone3_Poste&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_Telephone3_Poste {

			get {

				return (this.col_Telephone3_Poste);
			}
		}

		private System.Data.SqlTypes.SqlString col_No_membre;
		/// <summary>
		/// Returns the value of the No_membre column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;No_membre&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_No_membre {

			get {

				return (this.col_No_membre);
			}
		}

		private System.Data.SqlTypes.SqlString col_Resident;
		/// <summary>
		/// Returns the value of the Resident column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Resident&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_Resident {

			get {

				return (this.col_Resident);
			}
		}

		private System.Data.SqlTypes.SqlString col_Email;
		/// <summary>
		/// Returns the value of the Email column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Email&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_Email {

			get {

				return (this.col_Email);
			}
		}

		private System.Data.SqlTypes.SqlString col_WWW;
		/// <summary>
		/// Returns the value of the WWW column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;WWW&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_WWW {

			get {

				return (this.col_WWW);
			}
		}

		private System.Data.SqlTypes.SqlString col_Commentaires;
		/// <summary>
		/// Returns the value of the Commentaires column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Commentaires&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_Commentaires {

			get {

				return (this.col_Commentaires);
			}
		}

		private System.Data.SqlTypes.SqlBoolean col_AfficherCommentaires;
		/// <summary>
		/// Returns the value of the AfficherCommentaires column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;AfficherCommentaires&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlBoolean Col_AfficherCommentaires {

			get {

				return (this.col_AfficherCommentaires);
			}
		}

		private System.Data.SqlTypes.SqlBoolean col_DepotDirect;
		/// <summary>
		/// Returns the value of the DepotDirect column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;DepotDirect&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlBoolean Col_DepotDirect {

			get {

				return (this.col_DepotDirect);
			}
		}

		private System.Data.SqlTypes.SqlString col_InstitutionBanquaireID;
		/// <summary>
		/// Returns the value of the InstitutionBanquaireID column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;InstitutionBanquaireID&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_InstitutionBanquaireID {

			get {

				return (this.col_InstitutionBanquaireID);
			}
		}

		private System.Data.SqlTypes.SqlString col_Banque_transit;
		/// <summary>
		/// Returns the value of the Banque_transit column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Banque_transit&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_Banque_transit {

			get {

				return (this.col_Banque_transit);
			}
		}

		private System.Data.SqlTypes.SqlString col_Banque_folio;
		/// <summary>
		/// Returns the value of the Banque_folio column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Banque_folio&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_Banque_folio {

			get {

				return (this.col_Banque_folio);
			}
		}

		private System.Data.SqlTypes.SqlString col_No_TPS;
		/// <summary>
		/// Returns the value of the No_TPS column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;No_TPS&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_No_TPS {

			get {

				return (this.col_No_TPS);
			}
		}

		private System.Data.SqlTypes.SqlString col_No_TVQ;
		/// <summary>
		/// Returns the value of the No_TVQ column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;No_TVQ&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_No_TVQ {

			get {

				return (this.col_No_TVQ);
			}
		}

		private System.Data.SqlTypes.SqlBoolean col_PayerA;
		/// <summary>
		/// Returns the value of the PayerA column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;PayerA&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlBoolean Col_PayerA {

			get {

				return (this.col_PayerA);
			}
		}

		private System.Data.SqlTypes.SqlString col_PayerAID;
		/// <summary>
		/// Returns the value of the PayerAID column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;PayerAID&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_PayerAID {

			get {

				return (this.col_PayerAID);
			}
		}

		private System.Data.SqlTypes.SqlString col_Statut;
		/// <summary>
		/// Returns the value of the Statut column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Statut&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_Statut {

			get {

				return (this.col_Statut);
			}
		}

		private System.Data.SqlTypes.SqlString col_Rep_Nom;
		/// <summary>
		/// Returns the value of the Rep_Nom column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Rep_Nom&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_Rep_Nom {

			get {

				return (this.col_Rep_Nom);
			}
		}

		private System.Data.SqlTypes.SqlString col_Rep_Telephone;
		/// <summary>
		/// Returns the value of the Rep_Telephone column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Rep_Telephone&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_Rep_Telephone {

			get {

				return (this.col_Rep_Telephone);
			}
		}

		private System.Data.SqlTypes.SqlString col_Rep_Telephone_Poste;
		/// <summary>
		/// Returns the value of the Rep_Telephone_Poste column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Rep_Telephone_Poste&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_Rep_Telephone_Poste {

			get {

				return (this.col_Rep_Telephone_Poste);
			}
		}

		private System.Data.SqlTypes.SqlString col_Rep_Email;
		/// <summary>
		/// Returns the value of the Rep_Email column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Rep_Email&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_Rep_Email {

			get {

				return (this.col_Rep_Email);
			}
		}

		private System.Data.SqlTypes.SqlBoolean col_EnAnglais;
		/// <summary>
		/// Returns the value of the EnAnglais column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;EnAnglais&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlBoolean Col_EnAnglais {

			get {

				return (this.col_EnAnglais);
			}
		}

		private System.Data.SqlTypes.SqlBoolean col_Actif;
		/// <summary>
		/// Returns the value of the Actif column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Actif&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlBoolean Col_Actif {

			get {

				return (this.col_Actif);
			}
		}

		private System.Data.SqlTypes.SqlInt32 col_MRCProducteurID;
		/// <summary>
		/// Returns the value of the MRCProducteurID column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;MRCProducteurID&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlInt32 Col_MRCProducteurID {

			get {

				return (this.col_MRCProducteurID);
			}
		}

		private System.Data.SqlTypes.SqlBoolean col_PaiementManuel;
		/// <summary>
		/// Returns the value of the PaiementManuel column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;PaiementManuel&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlBoolean Col_PaiementManuel {

			get {

				return (this.col_PaiementManuel);
			}
		}

		private System.Data.SqlTypes.SqlBoolean col_Journal;
		/// <summary>
		/// Returns the value of the Journal column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Journal&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlBoolean Col_Journal {

			get {

				return (this.col_Journal);
			}
		}

		private System.Data.SqlTypes.SqlBoolean col_RecoitTPS;
		/// <summary>
		/// Returns the value of the RecoitTPS column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;RecoitTPS&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlBoolean Col_RecoitTPS {

			get {

				return (this.col_RecoitTPS);
			}
		}

		private System.Data.SqlTypes.SqlBoolean col_RecoitTVQ;
		/// <summary>
		/// Returns the value of the RecoitTVQ column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;RecoitTVQ&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlBoolean Col_RecoitTVQ {

			get {

				return (this.col_RecoitTVQ);
			}
		}

		private System.Data.SqlTypes.SqlBoolean col_ModifierTrigger;
		/// <summary>
		/// Returns the value of the ModifierTrigger column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;ModifierTrigger&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlBoolean Col_ModifierTrigger {

			get {

				return (this.col_ModifierTrigger);
			}
		}

		private System.Data.SqlTypes.SqlBoolean col_IsProducteur;
		/// <summary>
		/// Returns the value of the IsProducteur column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;IsProducteur&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlBoolean Col_IsProducteur {

			get {

				return (this.col_IsProducteur);
			}
		}

		private System.Data.SqlTypes.SqlBoolean col_IsTransporteur;
		/// <summary>
		/// Returns the value of the IsTransporteur column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;IsTransporteur&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlBoolean Col_IsTransporteur {

			get {

				return (this.col_IsTransporteur);
			}
		}

		private System.Data.SqlTypes.SqlBoolean col_IsChargeur;
		/// <summary>
		/// Returns the value of the IsChargeur column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;IsChargeur&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlBoolean Col_IsChargeur {

			get {

				return (this.col_IsChargeur);
			}
		}

		private System.Data.SqlTypes.SqlBoolean col_IsAutre;
		/// <summary>
		/// Returns the value of the IsAutre column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;IsAutre&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlBoolean Col_IsAutre {

			get {

				return (this.col_IsAutre);
			}
		}

		private System.Data.SqlTypes.SqlBoolean col_AfficherCommentairesSurPermit;
		/// <summary>
		/// Returns the value of the AfficherCommentairesSurPermit column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;AfficherCommentairesSurPermit&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlBoolean Col_AfficherCommentairesSurPermit {

			get {

				return (this.col_AfficherCommentairesSurPermit);
			}
		}

		private System.Data.SqlTypes.SqlBoolean col_PasEmissionPermis;
		/// <summary>
		/// Returns the value of the PasEmissionPermis column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;PasEmissionPermis&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlBoolean Col_PasEmissionPermis {

			get {

				return (this.col_PasEmissionPermis);
			}
		}

		private System.Data.SqlTypes.SqlBoolean col_Generique;
		/// <summary>
		/// Returns the value of the Generique column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Generique&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlBoolean Col_Generique {

			get {

				return (this.col_Generique);
			}
		}

		private System.Data.SqlTypes.SqlBoolean col_Membre_OGC;
		/// <summary>
		/// Returns the value of the Membre_OGC column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Membre_OGC&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlBoolean Col_Membre_OGC {

			get {

				return (this.col_Membre_OGC);
			}
		}

		private System.Data.SqlTypes.SqlBoolean col_InscritTPS;
		/// <summary>
		/// Returns the value of the InscritTPS column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;InscritTPS&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlBoolean Col_InscritTPS {

			get {

				return (this.col_InscritTPS);
			}
		}

		private System.Data.SqlTypes.SqlBoolean col_InscritTVQ;
		/// <summary>
		/// Returns the value of the InscritTVQ column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;InscritTVQ&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlBoolean Col_InscritTVQ {

			get {

				return (this.col_InscritTVQ);
			}
		}

		private System.Data.SqlTypes.SqlBoolean col_IsOGC;
		/// <summary>
		/// Returns the value of the IsOGC column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;IsOGC&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlBoolean Col_IsOGC {

			get {

				return (this.col_IsOGC);
			}
		}

		private System.Data.SqlTypes.SqlString col_Rep2_Nom;
		/// <summary>
		/// Returns the value of the Rep2_Nom column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Rep2_Nom&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_Rep2_Nom {

			get {

				return (this.col_Rep2_Nom);
			}
		}

		private System.Data.SqlTypes.SqlString col_Rep2_Telephone;
		/// <summary>
		/// Returns the value of the Rep2_Telephone column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Rep2_Telephone&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_Rep2_Telephone {

			get {

				return (this.col_Rep2_Telephone);
			}
		}

		private System.Data.SqlTypes.SqlString col_Rep2_Telephone_Poste;
		/// <summary>
		/// Returns the value of the Rep2_Telephone_Poste column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Rep2_Telephone_Poste&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_Rep2_Telephone_Poste {

			get {

				return (this.col_Rep2_Telephone_Poste);
			}
		}

		private System.Data.SqlTypes.SqlString col_Rep2_Email;
		/// <summary>
		/// Returns the value of the Rep2_Email column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Rep2_Email&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_Rep2_Email {

			get {

				return (this.col_Rep2_Email);
			}
		}

		private System.Data.SqlTypes.SqlString col_Rep2_Commentaires;
		/// <summary>
		/// Returns the value of the Rep2_Commentaires column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Rep2_Commentaires&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_Rep2_Commentaires {

			get {

				return (this.col_Rep2_Commentaires);
			}
		}

		/// <summary>
		/// This method allows to clear all the properties previously loaded by a call to the Refresh method.
		/// </summary>
		public void Reset() {

			this.col_ID = System.Data.SqlTypes.SqlString.Null;
			this.col_CleTri = System.Data.SqlTypes.SqlString.Null;
			this.col_Nom = System.Data.SqlTypes.SqlString.Null;
			this.col_AuSoinsDe = System.Data.SqlTypes.SqlString.Null;
			this.col_Rue = System.Data.SqlTypes.SqlString.Null;
			this.col_Ville = System.Data.SqlTypes.SqlString.Null;
			this.col_PaysID = System.Data.SqlTypes.SqlString.Null;
			this.col_Code_postal = System.Data.SqlTypes.SqlString.Null;
			this.col_Telephone = System.Data.SqlTypes.SqlString.Null;
			this.col_Telephone_Poste = System.Data.SqlTypes.SqlString.Null;
			this.col_Telecopieur = System.Data.SqlTypes.SqlString.Null;
			this.col_Telephone2 = System.Data.SqlTypes.SqlString.Null;
			this.col_Telephone2_Desc = System.Data.SqlTypes.SqlString.Null;
			this.col_Telephone2_Poste = System.Data.SqlTypes.SqlString.Null;
			this.col_Telephone3 = System.Data.SqlTypes.SqlString.Null;
			this.col_Telephone3_Desc = System.Data.SqlTypes.SqlString.Null;
			this.col_Telephone3_Poste = System.Data.SqlTypes.SqlString.Null;
			this.col_No_membre = System.Data.SqlTypes.SqlString.Null;
			this.col_Resident = System.Data.SqlTypes.SqlString.Null;
			this.col_Email = System.Data.SqlTypes.SqlString.Null;
			this.col_WWW = System.Data.SqlTypes.SqlString.Null;
			this.col_Commentaires = System.Data.SqlTypes.SqlString.Null;
			this.col_AfficherCommentaires = System.Data.SqlTypes.SqlBoolean.Null;
			this.col_DepotDirect = System.Data.SqlTypes.SqlBoolean.Null;
			this.col_InstitutionBanquaireID = System.Data.SqlTypes.SqlString.Null;
			this.col_Banque_transit = System.Data.SqlTypes.SqlString.Null;
			this.col_Banque_folio = System.Data.SqlTypes.SqlString.Null;
			this.col_No_TPS = System.Data.SqlTypes.SqlString.Null;
			this.col_No_TVQ = System.Data.SqlTypes.SqlString.Null;
			this.col_PayerA = System.Data.SqlTypes.SqlBoolean.Null;
			this.col_PayerAID = System.Data.SqlTypes.SqlString.Null;
			this.col_Statut = System.Data.SqlTypes.SqlString.Null;
			this.col_Rep_Nom = System.Data.SqlTypes.SqlString.Null;
			this.col_Rep_Telephone = System.Data.SqlTypes.SqlString.Null;
			this.col_Rep_Telephone_Poste = System.Data.SqlTypes.SqlString.Null;
			this.col_Rep_Email = System.Data.SqlTypes.SqlString.Null;
			this.col_EnAnglais = System.Data.SqlTypes.SqlBoolean.Null;
			this.col_Actif = System.Data.SqlTypes.SqlBoolean.Null;
			this.col_MRCProducteurID = System.Data.SqlTypes.SqlInt32.Null;
			this.col_PaiementManuel = System.Data.SqlTypes.SqlBoolean.Null;
			this.col_Journal = System.Data.SqlTypes.SqlBoolean.Null;
			this.col_RecoitTPS = System.Data.SqlTypes.SqlBoolean.Null;
			this.col_RecoitTVQ = System.Data.SqlTypes.SqlBoolean.Null;
			this.col_ModifierTrigger = System.Data.SqlTypes.SqlBoolean.Null;
			this.col_IsProducteur = System.Data.SqlTypes.SqlBoolean.Null;
			this.col_IsTransporteur = System.Data.SqlTypes.SqlBoolean.Null;
			this.col_IsChargeur = System.Data.SqlTypes.SqlBoolean.Null;
			this.col_IsAutre = System.Data.SqlTypes.SqlBoolean.Null;
			this.col_AfficherCommentairesSurPermit = System.Data.SqlTypes.SqlBoolean.Null;
			this.col_PasEmissionPermis = System.Data.SqlTypes.SqlBoolean.Null;
			this.col_Generique = System.Data.SqlTypes.SqlBoolean.Null;
			this.col_Membre_OGC = System.Data.SqlTypes.SqlBoolean.Null;
			this.col_InscritTPS = System.Data.SqlTypes.SqlBoolean.Null;
			this.col_InscritTVQ = System.Data.SqlTypes.SqlBoolean.Null;
			this.col_IsOGC = System.Data.SqlTypes.SqlBoolean.Null;
			this.col_Rep2_Nom = System.Data.SqlTypes.SqlString.Null;
			this.col_Rep2_Telephone = System.Data.SqlTypes.SqlString.Null;
			this.col_Rep2_Telephone_Poste = System.Data.SqlTypes.SqlString.Null;
			this.col_Rep2_Email = System.Data.SqlTypes.SqlString.Null;
			this.col_Rep2_Commentaires = System.Data.SqlTypes.SqlString.Null;
		}

		/// <summary>
		/// Allows you to load a specific record of the [Fournisseur] table.
		/// </summary>
		/// <param name="col_ID">Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;ID&quot; column.</param>
		public bool Refresh(System.Data.SqlTypes.SqlString col_ID) {

			bool Status;
			Reset();

			if (col_ID.IsNull) {

				throw new ArgumentNullException("col_ID" , "The primary key 'col_ID' can not have a Null value!");
			}


			this.col_ID = col_ID;

			this.Param.Reset();

			this.Param.Param_ID = this.col_ID;

			System.Data.SqlClient.SqlDataReader DR;
			SPs.spS_Fournisseur SP = new SPs.spS_Fournisseur(false);

			if (SP.Execute(ref this.Param, out DR)) {

				Status = false;
				if (DR.Read()) {

					if (!DR.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_CleTri.ColumnIndex)) {

						this.col_CleTri = DR.GetSqlString(SPs.spS_Fournisseur.Resultset1.Fields.Column_CleTri.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_Nom.ColumnIndex)) {

						this.col_Nom = DR.GetSqlString(SPs.spS_Fournisseur.Resultset1.Fields.Column_Nom.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_AuSoinsDe.ColumnIndex)) {

						this.col_AuSoinsDe = DR.GetSqlString(SPs.spS_Fournisseur.Resultset1.Fields.Column_AuSoinsDe.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_Rue.ColumnIndex)) {

						this.col_Rue = DR.GetSqlString(SPs.spS_Fournisseur.Resultset1.Fields.Column_Rue.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_Ville.ColumnIndex)) {

						this.col_Ville = DR.GetSqlString(SPs.spS_Fournisseur.Resultset1.Fields.Column_Ville.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_PaysID.ColumnIndex)) {

						this.col_PaysID = DR.GetSqlString(SPs.spS_Fournisseur.Resultset1.Fields.Column_PaysID.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_Code_postal.ColumnIndex)) {

						this.col_Code_postal = DR.GetSqlString(SPs.spS_Fournisseur.Resultset1.Fields.Column_Code_postal.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_Telephone.ColumnIndex)) {

						this.col_Telephone = DR.GetSqlString(SPs.spS_Fournisseur.Resultset1.Fields.Column_Telephone.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_Telephone_Poste.ColumnIndex)) {

						this.col_Telephone_Poste = DR.GetSqlString(SPs.spS_Fournisseur.Resultset1.Fields.Column_Telephone_Poste.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_Telecopieur.ColumnIndex)) {

						this.col_Telecopieur = DR.GetSqlString(SPs.spS_Fournisseur.Resultset1.Fields.Column_Telecopieur.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_Telephone2.ColumnIndex)) {

						this.col_Telephone2 = DR.GetSqlString(SPs.spS_Fournisseur.Resultset1.Fields.Column_Telephone2.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_Telephone2_Desc.ColumnIndex)) {

						this.col_Telephone2_Desc = DR.GetSqlString(SPs.spS_Fournisseur.Resultset1.Fields.Column_Telephone2_Desc.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_Telephone2_Poste.ColumnIndex)) {

						this.col_Telephone2_Poste = DR.GetSqlString(SPs.spS_Fournisseur.Resultset1.Fields.Column_Telephone2_Poste.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_Telephone3.ColumnIndex)) {

						this.col_Telephone3 = DR.GetSqlString(SPs.spS_Fournisseur.Resultset1.Fields.Column_Telephone3.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_Telephone3_Desc.ColumnIndex)) {

						this.col_Telephone3_Desc = DR.GetSqlString(SPs.spS_Fournisseur.Resultset1.Fields.Column_Telephone3_Desc.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_Telephone3_Poste.ColumnIndex)) {

						this.col_Telephone3_Poste = DR.GetSqlString(SPs.spS_Fournisseur.Resultset1.Fields.Column_Telephone3_Poste.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_No_membre.ColumnIndex)) {

						this.col_No_membre = DR.GetSqlString(SPs.spS_Fournisseur.Resultset1.Fields.Column_No_membre.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_Resident.ColumnIndex)) {

						this.col_Resident = DR.GetSqlString(SPs.spS_Fournisseur.Resultset1.Fields.Column_Resident.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_Email.ColumnIndex)) {

						this.col_Email = DR.GetSqlString(SPs.spS_Fournisseur.Resultset1.Fields.Column_Email.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_WWW.ColumnIndex)) {

						this.col_WWW = DR.GetSqlString(SPs.spS_Fournisseur.Resultset1.Fields.Column_WWW.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_Commentaires.ColumnIndex)) {

						this.col_Commentaires = DR.GetSqlString(SPs.spS_Fournisseur.Resultset1.Fields.Column_Commentaires.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_AfficherCommentaires.ColumnIndex)) {

						this.col_AfficherCommentaires = DR.GetSqlBoolean(SPs.spS_Fournisseur.Resultset1.Fields.Column_AfficherCommentaires.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_DepotDirect.ColumnIndex)) {

						this.col_DepotDirect = DR.GetSqlBoolean(SPs.spS_Fournisseur.Resultset1.Fields.Column_DepotDirect.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_InstitutionBanquaireID.ColumnIndex)) {

						this.col_InstitutionBanquaireID = DR.GetSqlString(SPs.spS_Fournisseur.Resultset1.Fields.Column_InstitutionBanquaireID.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_Banque_transit.ColumnIndex)) {

						this.col_Banque_transit = DR.GetSqlString(SPs.spS_Fournisseur.Resultset1.Fields.Column_Banque_transit.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_Banque_folio.ColumnIndex)) {

						this.col_Banque_folio = DR.GetSqlString(SPs.spS_Fournisseur.Resultset1.Fields.Column_Banque_folio.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_No_TPS.ColumnIndex)) {

						this.col_No_TPS = DR.GetSqlString(SPs.spS_Fournisseur.Resultset1.Fields.Column_No_TPS.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_No_TVQ.ColumnIndex)) {

						this.col_No_TVQ = DR.GetSqlString(SPs.spS_Fournisseur.Resultset1.Fields.Column_No_TVQ.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_PayerA.ColumnIndex)) {

						this.col_PayerA = DR.GetSqlBoolean(SPs.spS_Fournisseur.Resultset1.Fields.Column_PayerA.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_PayerAID.ColumnIndex)) {

						this.col_PayerAID = DR.GetSqlString(SPs.spS_Fournisseur.Resultset1.Fields.Column_PayerAID.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_Statut.ColumnIndex)) {

						this.col_Statut = DR.GetSqlString(SPs.spS_Fournisseur.Resultset1.Fields.Column_Statut.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_Rep_Nom.ColumnIndex)) {

						this.col_Rep_Nom = DR.GetSqlString(SPs.spS_Fournisseur.Resultset1.Fields.Column_Rep_Nom.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_Rep_Telephone.ColumnIndex)) {

						this.col_Rep_Telephone = DR.GetSqlString(SPs.spS_Fournisseur.Resultset1.Fields.Column_Rep_Telephone.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_Rep_Telephone_Poste.ColumnIndex)) {

						this.col_Rep_Telephone_Poste = DR.GetSqlString(SPs.spS_Fournisseur.Resultset1.Fields.Column_Rep_Telephone_Poste.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_Rep_Email.ColumnIndex)) {

						this.col_Rep_Email = DR.GetSqlString(SPs.spS_Fournisseur.Resultset1.Fields.Column_Rep_Email.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_EnAnglais.ColumnIndex)) {

						this.col_EnAnglais = DR.GetSqlBoolean(SPs.spS_Fournisseur.Resultset1.Fields.Column_EnAnglais.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_Actif.ColumnIndex)) {

						this.col_Actif = DR.GetSqlBoolean(SPs.spS_Fournisseur.Resultset1.Fields.Column_Actif.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_MRCProducteurID.ColumnIndex)) {

						this.col_MRCProducteurID = DR.GetSqlInt32(SPs.spS_Fournisseur.Resultset1.Fields.Column_MRCProducteurID.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_PaiementManuel.ColumnIndex)) {

						this.col_PaiementManuel = DR.GetSqlBoolean(SPs.spS_Fournisseur.Resultset1.Fields.Column_PaiementManuel.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_Journal.ColumnIndex)) {

						this.col_Journal = DR.GetSqlBoolean(SPs.spS_Fournisseur.Resultset1.Fields.Column_Journal.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_RecoitTPS.ColumnIndex)) {

						this.col_RecoitTPS = DR.GetSqlBoolean(SPs.spS_Fournisseur.Resultset1.Fields.Column_RecoitTPS.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_RecoitTVQ.ColumnIndex)) {

						this.col_RecoitTVQ = DR.GetSqlBoolean(SPs.spS_Fournisseur.Resultset1.Fields.Column_RecoitTVQ.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_ModifierTrigger.ColumnIndex)) {

						this.col_ModifierTrigger = DR.GetSqlBoolean(SPs.spS_Fournisseur.Resultset1.Fields.Column_ModifierTrigger.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_IsProducteur.ColumnIndex)) {

						this.col_IsProducteur = DR.GetSqlBoolean(SPs.spS_Fournisseur.Resultset1.Fields.Column_IsProducteur.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_IsTransporteur.ColumnIndex)) {

						this.col_IsTransporteur = DR.GetSqlBoolean(SPs.spS_Fournisseur.Resultset1.Fields.Column_IsTransporteur.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_IsChargeur.ColumnIndex)) {

						this.col_IsChargeur = DR.GetSqlBoolean(SPs.spS_Fournisseur.Resultset1.Fields.Column_IsChargeur.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_IsAutre.ColumnIndex)) {

						this.col_IsAutre = DR.GetSqlBoolean(SPs.spS_Fournisseur.Resultset1.Fields.Column_IsAutre.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_AfficherCommentairesSurPermit.ColumnIndex)) {

						this.col_AfficherCommentairesSurPermit = DR.GetSqlBoolean(SPs.spS_Fournisseur.Resultset1.Fields.Column_AfficherCommentairesSurPermit.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_PasEmissionPermis.ColumnIndex)) {

						this.col_PasEmissionPermis = DR.GetSqlBoolean(SPs.spS_Fournisseur.Resultset1.Fields.Column_PasEmissionPermis.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_Generique.ColumnIndex)) {

						this.col_Generique = DR.GetSqlBoolean(SPs.spS_Fournisseur.Resultset1.Fields.Column_Generique.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_Membre_OGC.ColumnIndex)) {

						this.col_Membre_OGC = DR.GetSqlBoolean(SPs.spS_Fournisseur.Resultset1.Fields.Column_Membre_OGC.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_InscritTPS.ColumnIndex)) {

						this.col_InscritTPS = DR.GetSqlBoolean(SPs.spS_Fournisseur.Resultset1.Fields.Column_InscritTPS.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_InscritTVQ.ColumnIndex)) {

						this.col_InscritTVQ = DR.GetSqlBoolean(SPs.spS_Fournisseur.Resultset1.Fields.Column_InscritTVQ.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_IsOGC.ColumnIndex)) {

						this.col_IsOGC = DR.GetSqlBoolean(SPs.spS_Fournisseur.Resultset1.Fields.Column_IsOGC.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_Rep2_Nom.ColumnIndex)) {

						this.col_Rep2_Nom = DR.GetSqlString(SPs.spS_Fournisseur.Resultset1.Fields.Column_Rep2_Nom.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_Rep2_Telephone.ColumnIndex)) {

						this.col_Rep2_Telephone = DR.GetSqlString(SPs.spS_Fournisseur.Resultset1.Fields.Column_Rep2_Telephone.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_Rep2_Telephone_Poste.ColumnIndex)) {

						this.col_Rep2_Telephone_Poste = DR.GetSqlString(SPs.spS_Fournisseur.Resultset1.Fields.Column_Rep2_Telephone_Poste.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_Rep2_Email.ColumnIndex)) {

						this.col_Rep2_Email = DR.GetSqlString(SPs.spS_Fournisseur.Resultset1.Fields.Column_Rep2_Email.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_Rep2_Commentaires.ColumnIndex)) {

						this.col_Rep2_Commentaires = DR.GetSqlString(SPs.spS_Fournisseur.Resultset1.Fields.Column_Rep2_Commentaires.ColumnIndex);
					}

					Status = true;
				}

				if (DR != null && !DR.IsClosed) {

					DR.Close();
				}

				if (CloseConnectionAfterUse && SP.Connection != null && SP.Connection.State == System.Data.ConnectionState.Open) {

					SP.Connection.Close();
					SP.Connection.Dispose();
				}

				return(Status);
			}

			else {

				if (DR != null && !DR.IsClosed) {

					DR.Close();
				}

				if (CloseConnectionAfterUse && SP.Connection != null && SP.Connection.State == System.Data.ConnectionState.Open) {

					SP.Connection.Close();
					SP.Connection.Dispose();
				}

				throw new Gestion_Paie.DataClasses.CustomException(this.Param, "Gestion_Paie.AbstractClasses.Abstract_Fournisseur", "Refresh");
			}
		}
	}
}
