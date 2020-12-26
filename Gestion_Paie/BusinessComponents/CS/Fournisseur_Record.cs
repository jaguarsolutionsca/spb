using System;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.BusinessComponents {

	/// <summary>
	/// This class is an abstract class that represents the [Fournisseur] table. With this class
	/// you can load or update a record from the database. If you need to add or delete a record,
	/// you must use the <see cref="Gestion_Paie.BusinessComponents.Fournisseur_Collection"/> class to do so.
	/// </summary>
	public sealed class Fournisseur_Record : IBusinessComponentRecord {
	
		internal bool recordWasLoadedFromDB = false;
		private bool recordIsLoaded = false;

		internal string connectionString = String.Empty;
		public string ConnectionString {
		
			get {
			
				return(this.connectionString);
			}
		}
		
		/// <summary>
		/// Initializes a new instance of the Fournisseur_Record class. Use this contructor to add
		/// a new record. Then call the Add method of the Gestion_Paie.BusinessComponents.Fournisseur_Collection class to actually
		/// add the record in the database.
		/// </summary>
		public Fournisseur_Record() {
		
			this.recordWasLoadedFromDB = false;
			this.recordIsLoaded = false;
		}
	
		/// <param name="col_ID">[To be supplied.]</param>
		public Fournisseur_Record(string connectionString, System.Data.SqlTypes.SqlString col_ID) {

#if OLYMARS_DEBUG
			object olymarsDebugCheck = System.Configuration.ConfigurationSettings.AppSettings["OlymarsDebugCheck"];
			if (olymarsDebugCheck == null || (string)olymarsDebugCheck == "True") {

				string DebugConnectionString = connectionString;

				if (DebugConnectionString == System.String.Empty) {

					DebugConnectionString = Gestion_Paie.DataClasses.Information.GetConnectionStringFromConfigurationFile;
				}

				if (DebugConnectionString == System.String.Empty) {

					DebugConnectionString = Gestion_Paie.DataClasses.Information.GetConnectionStringFromRegistry;
				}

				if (DebugConnectionString != String.Empty) {

					System.Data.SqlClient.SqlConnection sqlConnection = new System.Data.SqlClient.SqlConnection(DebugConnectionString);

					sqlConnection.Open();

					System.Data.SqlClient.SqlCommand sqlCommand = sqlConnection.CreateCommand();

					sqlCommand.CommandType = System.Data.CommandType.Text;
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Fournisseur'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}", "Fournisseur", CurrentRevision, OriginalRevision));
					}
				}
			}
#endif

			this.recordWasLoadedFromDB = true;
			this.recordIsLoaded = false;
			this.connectionString = connectionString;
			this.col_ID = col_ID;
		}
		
		internal System.Data.SqlTypes.SqlString col_ID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_ID {
		
			get {
			
				return(this.col_ID);
			}

			set {

				if (this.recordWasLoadedFromDB) {

					throw new System.Exception("You cannot affect this primary key since the record was loaded from the database.");
				}
				else {

					this.col_ID = value;
				}
			}
		}
		
		internal bool col_CleTriWasSet = false;
		private bool col_CleTriWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_CleTri = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_CleTri {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_CleTri);
			}
			set {
			
				this.col_CleTriWasUpdated = true;
				this.col_CleTriWasSet = true;
				this.col_CleTri = value;
			}
		}

		internal bool col_NomWasSet = false;
		private bool col_NomWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_Nom = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_Nom {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Nom);
			}
			set {
			
				this.col_NomWasUpdated = true;
				this.col_NomWasSet = true;
				this.col_Nom = value;
			}
		}

		internal bool col_AuSoinsDeWasSet = false;
		private bool col_AuSoinsDeWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_AuSoinsDe = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_AuSoinsDe {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_AuSoinsDe);
			}
			set {
			
				this.col_AuSoinsDeWasUpdated = true;
				this.col_AuSoinsDeWasSet = true;
				this.col_AuSoinsDe = value;
			}
		}

		internal bool col_RueWasSet = false;
		private bool col_RueWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_Rue = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_Rue {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Rue);
			}
			set {
			
				this.col_RueWasUpdated = true;
				this.col_RueWasSet = true;
				this.col_Rue = value;
			}
		}

		internal bool col_VilleWasSet = false;
		private bool col_VilleWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_Ville = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_Ville {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Ville);
			}
			set {
			
				this.col_VilleWasUpdated = true;
				this.col_VilleWasSet = true;
				this.col_Ville = value;
			}
		}

		internal bool col_PaysIDWasSet = false;
		private bool col_PaysIDWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_PaysID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_PaysID {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_PaysID);
			}
			set {
			
				this.col_PaysIDWasUpdated = true;
				this.col_PaysIDWasSet = true;
				this.col_PaysID_Record = null;
				this.col_PaysID = value;
			}
		}

		
		private Pays_Record col_PaysID_Record = null;
		public Pays_Record Col_PaysID_Pays_Record {
		
			get {

				if (this.col_PaysID_Record == null) {
				
					this.col_PaysID_Record = new Pays_Record(this.connectionString, this.col_PaysID);
				}
				
				return(this.col_PaysID_Record);
			}
		}

		internal bool col_Code_postalWasSet = false;
		private bool col_Code_postalWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_Code_postal = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_Code_postal {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Code_postal);
			}
			set {
			
				this.col_Code_postalWasUpdated = true;
				this.col_Code_postalWasSet = true;
				this.col_Code_postal = value;
			}
		}

		internal bool col_TelephoneWasSet = false;
		private bool col_TelephoneWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_Telephone = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_Telephone {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Telephone);
			}
			set {
			
				this.col_TelephoneWasUpdated = true;
				this.col_TelephoneWasSet = true;
				this.col_Telephone = value;
			}
		}

		internal bool col_Telephone_PosteWasSet = false;
		private bool col_Telephone_PosteWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_Telephone_Poste = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_Telephone_Poste {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Telephone_Poste);
			}
			set {
			
				this.col_Telephone_PosteWasUpdated = true;
				this.col_Telephone_PosteWasSet = true;
				this.col_Telephone_Poste = value;
			}
		}

		internal bool col_TelecopieurWasSet = false;
		private bool col_TelecopieurWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_Telecopieur = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_Telecopieur {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Telecopieur);
			}
			set {
			
				this.col_TelecopieurWasUpdated = true;
				this.col_TelecopieurWasSet = true;
				this.col_Telecopieur = value;
			}
		}

		internal bool col_Telephone2WasSet = false;
		private bool col_Telephone2WasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_Telephone2 = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_Telephone2 {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Telephone2);
			}
			set {
			
				this.col_Telephone2WasUpdated = true;
				this.col_Telephone2WasSet = true;
				this.col_Telephone2 = value;
			}
		}

		internal bool col_Telephone2_DescWasSet = false;
		private bool col_Telephone2_DescWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_Telephone2_Desc = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_Telephone2_Desc {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Telephone2_Desc);
			}
			set {
			
				this.col_Telephone2_DescWasUpdated = true;
				this.col_Telephone2_DescWasSet = true;
				this.col_Telephone2_Desc = value;
			}
		}

		internal bool col_Telephone2_PosteWasSet = false;
		private bool col_Telephone2_PosteWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_Telephone2_Poste = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_Telephone2_Poste {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Telephone2_Poste);
			}
			set {
			
				this.col_Telephone2_PosteWasUpdated = true;
				this.col_Telephone2_PosteWasSet = true;
				this.col_Telephone2_Poste = value;
			}
		}

		internal bool col_Telephone3WasSet = false;
		private bool col_Telephone3WasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_Telephone3 = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_Telephone3 {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Telephone3);
			}
			set {
			
				this.col_Telephone3WasUpdated = true;
				this.col_Telephone3WasSet = true;
				this.col_Telephone3 = value;
			}
		}

		internal bool col_Telephone3_DescWasSet = false;
		private bool col_Telephone3_DescWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_Telephone3_Desc = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_Telephone3_Desc {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Telephone3_Desc);
			}
			set {
			
				this.col_Telephone3_DescWasUpdated = true;
				this.col_Telephone3_DescWasSet = true;
				this.col_Telephone3_Desc = value;
			}
		}

		internal bool col_Telephone3_PosteWasSet = false;
		private bool col_Telephone3_PosteWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_Telephone3_Poste = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_Telephone3_Poste {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Telephone3_Poste);
			}
			set {
			
				this.col_Telephone3_PosteWasUpdated = true;
				this.col_Telephone3_PosteWasSet = true;
				this.col_Telephone3_Poste = value;
			}
		}

		internal bool col_No_membreWasSet = false;
		private bool col_No_membreWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_No_membre = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_No_membre {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_No_membre);
			}
			set {
			
				this.col_No_membreWasUpdated = true;
				this.col_No_membreWasSet = true;
				this.col_No_membre = value;
			}
		}

		internal bool col_ResidentWasSet = false;
		private bool col_ResidentWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_Resident = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_Resident {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Resident);
			}
			set {
			
				this.col_ResidentWasUpdated = true;
				this.col_ResidentWasSet = true;
				this.col_Resident = value;
			}
		}

		internal bool col_EmailWasSet = false;
		private bool col_EmailWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_Email = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_Email {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Email);
			}
			set {
			
				this.col_EmailWasUpdated = true;
				this.col_EmailWasSet = true;
				this.col_Email = value;
			}
		}

		internal bool col_WWWWasSet = false;
		private bool col_WWWWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_WWW = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_WWW {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_WWW);
			}
			set {
			
				this.col_WWWWasUpdated = true;
				this.col_WWWWasSet = true;
				this.col_WWW = value;
			}
		}

		internal bool col_CommentairesWasSet = false;
		private bool col_CommentairesWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_Commentaires = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_Commentaires {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Commentaires);
			}
			set {
			
				this.col_CommentairesWasUpdated = true;
				this.col_CommentairesWasSet = true;
				this.col_Commentaires = value;
			}
		}

		internal bool col_AfficherCommentairesWasSet = false;
		private bool col_AfficherCommentairesWasUpdated = false;
		internal System.Data.SqlTypes.SqlBoolean col_AfficherCommentaires = System.Data.SqlTypes.SqlBoolean.Null;
		public System.Data.SqlTypes.SqlBoolean Col_AfficherCommentaires {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_AfficherCommentaires);
			}
			set {
			
				this.col_AfficherCommentairesWasUpdated = true;
				this.col_AfficherCommentairesWasSet = true;
				this.col_AfficherCommentaires = value;
			}
		}

		internal bool col_DepotDirectWasSet = false;
		private bool col_DepotDirectWasUpdated = false;
		internal System.Data.SqlTypes.SqlBoolean col_DepotDirect = System.Data.SqlTypes.SqlBoolean.Null;
		public System.Data.SqlTypes.SqlBoolean Col_DepotDirect {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_DepotDirect);
			}
			set {
			
				this.col_DepotDirectWasUpdated = true;
				this.col_DepotDirectWasSet = true;
				this.col_DepotDirect = value;
			}
		}

		internal bool col_InstitutionBanquaireIDWasSet = false;
		private bool col_InstitutionBanquaireIDWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_InstitutionBanquaireID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_InstitutionBanquaireID {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_InstitutionBanquaireID);
			}
			set {
			
				this.col_InstitutionBanquaireIDWasUpdated = true;
				this.col_InstitutionBanquaireIDWasSet = true;
				this.col_InstitutionBanquaireID_Record = null;
				this.col_InstitutionBanquaireID = value;
			}
		}

		
		private InstitutionBanquaire_Record col_InstitutionBanquaireID_Record = null;
		public InstitutionBanquaire_Record Col_InstitutionBanquaireID_InstitutionBanquaire_Record {
		
			get {

				if (this.col_InstitutionBanquaireID_Record == null) {
				
					this.col_InstitutionBanquaireID_Record = new InstitutionBanquaire_Record(this.connectionString, this.col_InstitutionBanquaireID);
				}
				
				return(this.col_InstitutionBanquaireID_Record);
			}
		}

		internal bool col_Banque_transitWasSet = false;
		private bool col_Banque_transitWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_Banque_transit = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_Banque_transit {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Banque_transit);
			}
			set {
			
				this.col_Banque_transitWasUpdated = true;
				this.col_Banque_transitWasSet = true;
				this.col_Banque_transit = value;
			}
		}

		internal bool col_Banque_folioWasSet = false;
		private bool col_Banque_folioWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_Banque_folio = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_Banque_folio {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Banque_folio);
			}
			set {
			
				this.col_Banque_folioWasUpdated = true;
				this.col_Banque_folioWasSet = true;
				this.col_Banque_folio = value;
			}
		}

		internal bool col_No_TPSWasSet = false;
		private bool col_No_TPSWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_No_TPS = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_No_TPS {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_No_TPS);
			}
			set {
			
				this.col_No_TPSWasUpdated = true;
				this.col_No_TPSWasSet = true;
				this.col_No_TPS = value;
			}
		}

		internal bool col_No_TVQWasSet = false;
		private bool col_No_TVQWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_No_TVQ = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_No_TVQ {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_No_TVQ);
			}
			set {
			
				this.col_No_TVQWasUpdated = true;
				this.col_No_TVQWasSet = true;
				this.col_No_TVQ = value;
			}
		}

		internal bool col_PayerAWasSet = false;
		private bool col_PayerAWasUpdated = false;
		internal System.Data.SqlTypes.SqlBoolean col_PayerA = System.Data.SqlTypes.SqlBoolean.Null;
		public System.Data.SqlTypes.SqlBoolean Col_PayerA {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_PayerA);
			}
			set {
			
				this.col_PayerAWasUpdated = true;
				this.col_PayerAWasSet = true;
				this.col_PayerA = value;
			}
		}

		internal bool col_PayerAIDWasSet = false;
		private bool col_PayerAIDWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_PayerAID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_PayerAID {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_PayerAID);
			}
			set {
			
				this.col_PayerAIDWasUpdated = true;
				this.col_PayerAIDWasSet = true;
				this.col_PayerAID = value;
			}
		}

		internal bool col_StatutWasSet = false;
		private bool col_StatutWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_Statut = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_Statut {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Statut);
			}
			set {
			
				this.col_StatutWasUpdated = true;
				this.col_StatutWasSet = true;
				this.col_Statut = value;
			}
		}

		internal bool col_Rep_NomWasSet = false;
		private bool col_Rep_NomWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_Rep_Nom = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_Rep_Nom {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Rep_Nom);
			}
			set {
			
				this.col_Rep_NomWasUpdated = true;
				this.col_Rep_NomWasSet = true;
				this.col_Rep_Nom = value;
			}
		}

		internal bool col_Rep_TelephoneWasSet = false;
		private bool col_Rep_TelephoneWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_Rep_Telephone = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_Rep_Telephone {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Rep_Telephone);
			}
			set {
			
				this.col_Rep_TelephoneWasUpdated = true;
				this.col_Rep_TelephoneWasSet = true;
				this.col_Rep_Telephone = value;
			}
		}

		internal bool col_Rep_Telephone_PosteWasSet = false;
		private bool col_Rep_Telephone_PosteWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_Rep_Telephone_Poste = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_Rep_Telephone_Poste {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Rep_Telephone_Poste);
			}
			set {
			
				this.col_Rep_Telephone_PosteWasUpdated = true;
				this.col_Rep_Telephone_PosteWasSet = true;
				this.col_Rep_Telephone_Poste = value;
			}
		}

		internal bool col_Rep_EmailWasSet = false;
		private bool col_Rep_EmailWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_Rep_Email = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_Rep_Email {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Rep_Email);
			}
			set {
			
				this.col_Rep_EmailWasUpdated = true;
				this.col_Rep_EmailWasSet = true;
				this.col_Rep_Email = value;
			}
		}

		internal bool col_EnAnglaisWasSet = false;
		private bool col_EnAnglaisWasUpdated = false;
		internal System.Data.SqlTypes.SqlBoolean col_EnAnglais = System.Data.SqlTypes.SqlBoolean.Null;
		public System.Data.SqlTypes.SqlBoolean Col_EnAnglais {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_EnAnglais);
			}
			set {
			
				this.col_EnAnglaisWasUpdated = true;
				this.col_EnAnglaisWasSet = true;
				this.col_EnAnglais = value;
			}
		}

		internal bool col_ActifWasSet = false;
		private bool col_ActifWasUpdated = false;
		internal System.Data.SqlTypes.SqlBoolean col_Actif = System.Data.SqlTypes.SqlBoolean.Null;
		public System.Data.SqlTypes.SqlBoolean Col_Actif {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Actif);
			}
			set {
			
				this.col_ActifWasUpdated = true;
				this.col_ActifWasSet = true;
				this.col_Actif = value;
			}
		}

		internal bool col_MRCProducteurIDWasSet = false;
		private bool col_MRCProducteurIDWasUpdated = false;
		internal System.Data.SqlTypes.SqlInt32 col_MRCProducteurID = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_MRCProducteurID {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_MRCProducteurID);
			}
			set {
			
				this.col_MRCProducteurIDWasUpdated = true;
				this.col_MRCProducteurIDWasSet = true;
				this.col_MRCProducteurID = value;
			}
		}

		internal bool col_PaiementManuelWasSet = false;
		private bool col_PaiementManuelWasUpdated = false;
		internal System.Data.SqlTypes.SqlBoolean col_PaiementManuel = System.Data.SqlTypes.SqlBoolean.Null;
		public System.Data.SqlTypes.SqlBoolean Col_PaiementManuel {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_PaiementManuel);
			}
			set {
			
				this.col_PaiementManuelWasUpdated = true;
				this.col_PaiementManuelWasSet = true;
				this.col_PaiementManuel = value;
			}
		}

		internal bool col_JournalWasSet = false;
		private bool col_JournalWasUpdated = false;
		internal System.Data.SqlTypes.SqlBoolean col_Journal = System.Data.SqlTypes.SqlBoolean.Null;
		public System.Data.SqlTypes.SqlBoolean Col_Journal {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Journal);
			}
			set {
			
				this.col_JournalWasUpdated = true;
				this.col_JournalWasSet = true;
				this.col_Journal = value;
			}
		}

		internal bool col_RecoitTPSWasSet = false;
		private bool col_RecoitTPSWasUpdated = false;
		internal System.Data.SqlTypes.SqlBoolean col_RecoitTPS = System.Data.SqlTypes.SqlBoolean.Null;
		public System.Data.SqlTypes.SqlBoolean Col_RecoitTPS {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_RecoitTPS);
			}
			set {
			
				this.col_RecoitTPSWasUpdated = true;
				this.col_RecoitTPSWasSet = true;
				this.col_RecoitTPS = value;
			}
		}

		internal bool col_RecoitTVQWasSet = false;
		private bool col_RecoitTVQWasUpdated = false;
		internal System.Data.SqlTypes.SqlBoolean col_RecoitTVQ = System.Data.SqlTypes.SqlBoolean.Null;
		public System.Data.SqlTypes.SqlBoolean Col_RecoitTVQ {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_RecoitTVQ);
			}
			set {
			
				this.col_RecoitTVQWasUpdated = true;
				this.col_RecoitTVQWasSet = true;
				this.col_RecoitTVQ = value;
			}
		}

		internal bool col_ModifierTriggerWasSet = false;
		private bool col_ModifierTriggerWasUpdated = false;
		internal System.Data.SqlTypes.SqlBoolean col_ModifierTrigger = System.Data.SqlTypes.SqlBoolean.Null;
		public System.Data.SqlTypes.SqlBoolean Col_ModifierTrigger {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_ModifierTrigger);
			}
			set {
			
				this.col_ModifierTriggerWasUpdated = true;
				this.col_ModifierTriggerWasSet = true;
				this.col_ModifierTrigger = value;
			}
		}

		internal bool col_IsProducteurWasSet = false;
		private bool col_IsProducteurWasUpdated = false;
		internal System.Data.SqlTypes.SqlBoolean col_IsProducteur = System.Data.SqlTypes.SqlBoolean.Null;
		public System.Data.SqlTypes.SqlBoolean Col_IsProducteur {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_IsProducteur);
			}
			set {
			
				this.col_IsProducteurWasUpdated = true;
				this.col_IsProducteurWasSet = true;
				this.col_IsProducteur = value;
			}
		}

		internal bool col_IsTransporteurWasSet = false;
		private bool col_IsTransporteurWasUpdated = false;
		internal System.Data.SqlTypes.SqlBoolean col_IsTransporteur = System.Data.SqlTypes.SqlBoolean.Null;
		public System.Data.SqlTypes.SqlBoolean Col_IsTransporteur {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_IsTransporteur);
			}
			set {
			
				this.col_IsTransporteurWasUpdated = true;
				this.col_IsTransporteurWasSet = true;
				this.col_IsTransporteur = value;
			}
		}

		internal bool col_IsChargeurWasSet = false;
		private bool col_IsChargeurWasUpdated = false;
		internal System.Data.SqlTypes.SqlBoolean col_IsChargeur = System.Data.SqlTypes.SqlBoolean.Null;
		public System.Data.SqlTypes.SqlBoolean Col_IsChargeur {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_IsChargeur);
			}
			set {
			
				this.col_IsChargeurWasUpdated = true;
				this.col_IsChargeurWasSet = true;
				this.col_IsChargeur = value;
			}
		}

		internal bool col_IsAutreWasSet = false;
		private bool col_IsAutreWasUpdated = false;
		internal System.Data.SqlTypes.SqlBoolean col_IsAutre = System.Data.SqlTypes.SqlBoolean.Null;
		public System.Data.SqlTypes.SqlBoolean Col_IsAutre {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_IsAutre);
			}
			set {
			
				this.col_IsAutreWasUpdated = true;
				this.col_IsAutreWasSet = true;
				this.col_IsAutre = value;
			}
		}

		internal bool col_AfficherCommentairesSurPermitWasSet = false;
		private bool col_AfficherCommentairesSurPermitWasUpdated = false;
		internal System.Data.SqlTypes.SqlBoolean col_AfficherCommentairesSurPermit = System.Data.SqlTypes.SqlBoolean.Null;
		public System.Data.SqlTypes.SqlBoolean Col_AfficherCommentairesSurPermit {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_AfficherCommentairesSurPermit);
			}
			set {
			
				this.col_AfficherCommentairesSurPermitWasUpdated = true;
				this.col_AfficherCommentairesSurPermitWasSet = true;
				this.col_AfficherCommentairesSurPermit = value;
			}
		}

		internal bool col_PasEmissionPermisWasSet = false;
		private bool col_PasEmissionPermisWasUpdated = false;
		internal System.Data.SqlTypes.SqlBoolean col_PasEmissionPermis = System.Data.SqlTypes.SqlBoolean.Null;
		public System.Data.SqlTypes.SqlBoolean Col_PasEmissionPermis {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_PasEmissionPermis);
			}
			set {
			
				this.col_PasEmissionPermisWasUpdated = true;
				this.col_PasEmissionPermisWasSet = true;
				this.col_PasEmissionPermis = value;
			}
		}

		internal bool col_GeneriqueWasSet = false;
		private bool col_GeneriqueWasUpdated = false;
		internal System.Data.SqlTypes.SqlBoolean col_Generique = System.Data.SqlTypes.SqlBoolean.Null;
		public System.Data.SqlTypes.SqlBoolean Col_Generique {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Generique);
			}
			set {
			
				this.col_GeneriqueWasUpdated = true;
				this.col_GeneriqueWasSet = true;
				this.col_Generique = value;
			}
		}

		internal bool col_Membre_OGCWasSet = false;
		private bool col_Membre_OGCWasUpdated = false;
		internal System.Data.SqlTypes.SqlBoolean col_Membre_OGC = System.Data.SqlTypes.SqlBoolean.Null;
		public System.Data.SqlTypes.SqlBoolean Col_Membre_OGC {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Membre_OGC);
			}
			set {
			
				this.col_Membre_OGCWasUpdated = true;
				this.col_Membre_OGCWasSet = true;
				this.col_Membre_OGC = value;
			}
		}

		internal bool col_InscritTPSWasSet = false;
		private bool col_InscritTPSWasUpdated = false;
		internal System.Data.SqlTypes.SqlBoolean col_InscritTPS = System.Data.SqlTypes.SqlBoolean.Null;
		public System.Data.SqlTypes.SqlBoolean Col_InscritTPS {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_InscritTPS);
			}
			set {
			
				this.col_InscritTPSWasUpdated = true;
				this.col_InscritTPSWasSet = true;
				this.col_InscritTPS = value;
			}
		}

		internal bool col_InscritTVQWasSet = false;
		private bool col_InscritTVQWasUpdated = false;
		internal System.Data.SqlTypes.SqlBoolean col_InscritTVQ = System.Data.SqlTypes.SqlBoolean.Null;
		public System.Data.SqlTypes.SqlBoolean Col_InscritTVQ {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_InscritTVQ);
			}
			set {
			
				this.col_InscritTVQWasUpdated = true;
				this.col_InscritTVQWasSet = true;
				this.col_InscritTVQ = value;
			}
		}

		internal bool col_IsOGCWasSet = false;
		private bool col_IsOGCWasUpdated = false;
		internal System.Data.SqlTypes.SqlBoolean col_IsOGC = System.Data.SqlTypes.SqlBoolean.Null;
		public System.Data.SqlTypes.SqlBoolean Col_IsOGC {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_IsOGC);
			}
			set {
			
				this.col_IsOGCWasUpdated = true;
				this.col_IsOGCWasSet = true;
				this.col_IsOGC = value;
			}
		}

		internal bool col_Rep2_NomWasSet = false;
		private bool col_Rep2_NomWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_Rep2_Nom = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_Rep2_Nom {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Rep2_Nom);
			}
			set {
			
				this.col_Rep2_NomWasUpdated = true;
				this.col_Rep2_NomWasSet = true;
				this.col_Rep2_Nom = value;
			}
		}

		internal bool col_Rep2_TelephoneWasSet = false;
		private bool col_Rep2_TelephoneWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_Rep2_Telephone = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_Rep2_Telephone {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Rep2_Telephone);
			}
			set {
			
				this.col_Rep2_TelephoneWasUpdated = true;
				this.col_Rep2_TelephoneWasSet = true;
				this.col_Rep2_Telephone = value;
			}
		}

		internal bool col_Rep2_Telephone_PosteWasSet = false;
		private bool col_Rep2_Telephone_PosteWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_Rep2_Telephone_Poste = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_Rep2_Telephone_Poste {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Rep2_Telephone_Poste);
			}
			set {
			
				this.col_Rep2_Telephone_PosteWasUpdated = true;
				this.col_Rep2_Telephone_PosteWasSet = true;
				this.col_Rep2_Telephone_Poste = value;
			}
		}

		internal bool col_Rep2_EmailWasSet = false;
		private bool col_Rep2_EmailWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_Rep2_Email = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_Rep2_Email {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Rep2_Email);
			}
			set {
			
				this.col_Rep2_EmailWasUpdated = true;
				this.col_Rep2_EmailWasSet = true;
				this.col_Rep2_Email = value;
			}
		}

		internal bool col_Rep2_CommentairesWasSet = false;
		private bool col_Rep2_CommentairesWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_Rep2_Commentaires = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_Rep2_Commentaires {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Rep2_Commentaires);
			}
			set {
			
				this.col_Rep2_CommentairesWasUpdated = true;
				this.col_Rep2_CommentairesWasSet = true;
				this.col_Rep2_Commentaires = value;
			}
		}


		public bool Refresh() {

			this.displayName = null;

			this.col_CleTriWasUpdated = false;
			this.col_CleTriWasSet = false;
			this.col_CleTri = System.Data.SqlTypes.SqlString.Null;

			this.col_NomWasUpdated = false;
			this.col_NomWasSet = false;
			this.col_Nom = System.Data.SqlTypes.SqlString.Null;

			this.col_AuSoinsDeWasUpdated = false;
			this.col_AuSoinsDeWasSet = false;
			this.col_AuSoinsDe = System.Data.SqlTypes.SqlString.Null;

			this.col_RueWasUpdated = false;
			this.col_RueWasSet = false;
			this.col_Rue = System.Data.SqlTypes.SqlString.Null;

			this.col_VilleWasUpdated = false;
			this.col_VilleWasSet = false;
			this.col_Ville = System.Data.SqlTypes.SqlString.Null;

			this.col_PaysIDWasUpdated = false;
			this.col_PaysIDWasSet = false;
			this.col_PaysID = System.Data.SqlTypes.SqlString.Null;

			this.col_Code_postalWasUpdated = false;
			this.col_Code_postalWasSet = false;
			this.col_Code_postal = System.Data.SqlTypes.SqlString.Null;

			this.col_TelephoneWasUpdated = false;
			this.col_TelephoneWasSet = false;
			this.col_Telephone = System.Data.SqlTypes.SqlString.Null;

			this.col_Telephone_PosteWasUpdated = false;
			this.col_Telephone_PosteWasSet = false;
			this.col_Telephone_Poste = System.Data.SqlTypes.SqlString.Null;

			this.col_TelecopieurWasUpdated = false;
			this.col_TelecopieurWasSet = false;
			this.col_Telecopieur = System.Data.SqlTypes.SqlString.Null;

			this.col_Telephone2WasUpdated = false;
			this.col_Telephone2WasSet = false;
			this.col_Telephone2 = System.Data.SqlTypes.SqlString.Null;

			this.col_Telephone2_DescWasUpdated = false;
			this.col_Telephone2_DescWasSet = false;
			this.col_Telephone2_Desc = System.Data.SqlTypes.SqlString.Null;

			this.col_Telephone2_PosteWasUpdated = false;
			this.col_Telephone2_PosteWasSet = false;
			this.col_Telephone2_Poste = System.Data.SqlTypes.SqlString.Null;

			this.col_Telephone3WasUpdated = false;
			this.col_Telephone3WasSet = false;
			this.col_Telephone3 = System.Data.SqlTypes.SqlString.Null;

			this.col_Telephone3_DescWasUpdated = false;
			this.col_Telephone3_DescWasSet = false;
			this.col_Telephone3_Desc = System.Data.SqlTypes.SqlString.Null;

			this.col_Telephone3_PosteWasUpdated = false;
			this.col_Telephone3_PosteWasSet = false;
			this.col_Telephone3_Poste = System.Data.SqlTypes.SqlString.Null;

			this.col_No_membreWasUpdated = false;
			this.col_No_membreWasSet = false;
			this.col_No_membre = System.Data.SqlTypes.SqlString.Null;

			this.col_ResidentWasUpdated = false;
			this.col_ResidentWasSet = false;
			this.col_Resident = System.Data.SqlTypes.SqlString.Null;

			this.col_EmailWasUpdated = false;
			this.col_EmailWasSet = false;
			this.col_Email = System.Data.SqlTypes.SqlString.Null;

			this.col_WWWWasUpdated = false;
			this.col_WWWWasSet = false;
			this.col_WWW = System.Data.SqlTypes.SqlString.Null;

			this.col_CommentairesWasUpdated = false;
			this.col_CommentairesWasSet = false;
			this.col_Commentaires = System.Data.SqlTypes.SqlString.Null;

			this.col_AfficherCommentairesWasUpdated = false;
			this.col_AfficherCommentairesWasSet = false;
			this.col_AfficherCommentaires = System.Data.SqlTypes.SqlBoolean.Null;

			this.col_DepotDirectWasUpdated = false;
			this.col_DepotDirectWasSet = false;
			this.col_DepotDirect = System.Data.SqlTypes.SqlBoolean.Null;

			this.col_InstitutionBanquaireIDWasUpdated = false;
			this.col_InstitutionBanquaireIDWasSet = false;
			this.col_InstitutionBanquaireID = System.Data.SqlTypes.SqlString.Null;

			this.col_Banque_transitWasUpdated = false;
			this.col_Banque_transitWasSet = false;
			this.col_Banque_transit = System.Data.SqlTypes.SqlString.Null;

			this.col_Banque_folioWasUpdated = false;
			this.col_Banque_folioWasSet = false;
			this.col_Banque_folio = System.Data.SqlTypes.SqlString.Null;

			this.col_No_TPSWasUpdated = false;
			this.col_No_TPSWasSet = false;
			this.col_No_TPS = System.Data.SqlTypes.SqlString.Null;

			this.col_No_TVQWasUpdated = false;
			this.col_No_TVQWasSet = false;
			this.col_No_TVQ = System.Data.SqlTypes.SqlString.Null;

			this.col_PayerAWasUpdated = false;
			this.col_PayerAWasSet = false;
			this.col_PayerA = System.Data.SqlTypes.SqlBoolean.Null;

			this.col_PayerAIDWasUpdated = false;
			this.col_PayerAIDWasSet = false;
			this.col_PayerAID = System.Data.SqlTypes.SqlString.Null;

			this.col_StatutWasUpdated = false;
			this.col_StatutWasSet = false;
			this.col_Statut = System.Data.SqlTypes.SqlString.Null;

			this.col_Rep_NomWasUpdated = false;
			this.col_Rep_NomWasSet = false;
			this.col_Rep_Nom = System.Data.SqlTypes.SqlString.Null;

			this.col_Rep_TelephoneWasUpdated = false;
			this.col_Rep_TelephoneWasSet = false;
			this.col_Rep_Telephone = System.Data.SqlTypes.SqlString.Null;

			this.col_Rep_Telephone_PosteWasUpdated = false;
			this.col_Rep_Telephone_PosteWasSet = false;
			this.col_Rep_Telephone_Poste = System.Data.SqlTypes.SqlString.Null;

			this.col_Rep_EmailWasUpdated = false;
			this.col_Rep_EmailWasSet = false;
			this.col_Rep_Email = System.Data.SqlTypes.SqlString.Null;

			this.col_EnAnglaisWasUpdated = false;
			this.col_EnAnglaisWasSet = false;
			this.col_EnAnglais = System.Data.SqlTypes.SqlBoolean.Null;

			this.col_ActifWasUpdated = false;
			this.col_ActifWasSet = false;
			this.col_Actif = System.Data.SqlTypes.SqlBoolean.Null;

			this.col_MRCProducteurIDWasUpdated = false;
			this.col_MRCProducteurIDWasSet = false;
			this.col_MRCProducteurID = System.Data.SqlTypes.SqlInt32.Null;

			this.col_PaiementManuelWasUpdated = false;
			this.col_PaiementManuelWasSet = false;
			this.col_PaiementManuel = System.Data.SqlTypes.SqlBoolean.Null;

			this.col_JournalWasUpdated = false;
			this.col_JournalWasSet = false;
			this.col_Journal = System.Data.SqlTypes.SqlBoolean.Null;

			this.col_RecoitTPSWasUpdated = false;
			this.col_RecoitTPSWasSet = false;
			this.col_RecoitTPS = System.Data.SqlTypes.SqlBoolean.Null;

			this.col_RecoitTVQWasUpdated = false;
			this.col_RecoitTVQWasSet = false;
			this.col_RecoitTVQ = System.Data.SqlTypes.SqlBoolean.Null;

			this.col_ModifierTriggerWasUpdated = false;
			this.col_ModifierTriggerWasSet = false;
			this.col_ModifierTrigger = System.Data.SqlTypes.SqlBoolean.Null;

			this.col_IsProducteurWasUpdated = false;
			this.col_IsProducteurWasSet = false;
			this.col_IsProducteur = System.Data.SqlTypes.SqlBoolean.Null;

			this.col_IsTransporteurWasUpdated = false;
			this.col_IsTransporteurWasSet = false;
			this.col_IsTransporteur = System.Data.SqlTypes.SqlBoolean.Null;

			this.col_IsChargeurWasUpdated = false;
			this.col_IsChargeurWasSet = false;
			this.col_IsChargeur = System.Data.SqlTypes.SqlBoolean.Null;

			this.col_IsAutreWasUpdated = false;
			this.col_IsAutreWasSet = false;
			this.col_IsAutre = System.Data.SqlTypes.SqlBoolean.Null;

			this.col_AfficherCommentairesSurPermitWasUpdated = false;
			this.col_AfficherCommentairesSurPermitWasSet = false;
			this.col_AfficherCommentairesSurPermit = System.Data.SqlTypes.SqlBoolean.Null;

			this.col_PasEmissionPermisWasUpdated = false;
			this.col_PasEmissionPermisWasSet = false;
			this.col_PasEmissionPermis = System.Data.SqlTypes.SqlBoolean.Null;

			this.col_GeneriqueWasUpdated = false;
			this.col_GeneriqueWasSet = false;
			this.col_Generique = System.Data.SqlTypes.SqlBoolean.Null;

			this.col_Membre_OGCWasUpdated = false;
			this.col_Membre_OGCWasSet = false;
			this.col_Membre_OGC = System.Data.SqlTypes.SqlBoolean.Null;

			this.col_InscritTPSWasUpdated = false;
			this.col_InscritTPSWasSet = false;
			this.col_InscritTPS = System.Data.SqlTypes.SqlBoolean.Null;

			this.col_InscritTVQWasUpdated = false;
			this.col_InscritTVQWasSet = false;
			this.col_InscritTVQ = System.Data.SqlTypes.SqlBoolean.Null;

			this.col_IsOGCWasUpdated = false;
			this.col_IsOGCWasSet = false;
			this.col_IsOGC = System.Data.SqlTypes.SqlBoolean.Null;

			this.col_Rep2_NomWasUpdated = false;
			this.col_Rep2_NomWasSet = false;
			this.col_Rep2_Nom = System.Data.SqlTypes.SqlString.Null;

			this.col_Rep2_TelephoneWasUpdated = false;
			this.col_Rep2_TelephoneWasSet = false;
			this.col_Rep2_Telephone = System.Data.SqlTypes.SqlString.Null;

			this.col_Rep2_Telephone_PosteWasUpdated = false;
			this.col_Rep2_Telephone_PosteWasSet = false;
			this.col_Rep2_Telephone_Poste = System.Data.SqlTypes.SqlString.Null;

			this.col_Rep2_EmailWasUpdated = false;
			this.col_Rep2_EmailWasSet = false;
			this.col_Rep2_Email = System.Data.SqlTypes.SqlString.Null;

			this.col_Rep2_CommentairesWasUpdated = false;
			this.col_Rep2_CommentairesWasSet = false;
			this.col_Rep2_Commentaires = System.Data.SqlTypes.SqlString.Null;

			Params.spS_Fournisseur Param = new Params.spS_Fournisseur(true);
			Param.SetUpConnection(this.connectionString);

			if (!this.col_ID.IsNull) {

				Param.Param_ID = this.col_ID;
			}


			System.Data.SqlClient.SqlDataReader sqlDataReader = null;
			SPs.spS_Fournisseur Sp = new SPs.spS_Fournisseur();
			if (Sp.Execute(ref Param, out sqlDataReader)) {

				if (sqlDataReader.Read()) {

					if (!sqlDataReader.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_CleTri.ColumnIndex)) {

						this.col_CleTri = sqlDataReader.GetSqlString(SPs.spS_Fournisseur.Resultset1.Fields.Column_CleTri.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_Nom.ColumnIndex)) {

						this.col_Nom = sqlDataReader.GetSqlString(SPs.spS_Fournisseur.Resultset1.Fields.Column_Nom.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_AuSoinsDe.ColumnIndex)) {

						this.col_AuSoinsDe = sqlDataReader.GetSqlString(SPs.spS_Fournisseur.Resultset1.Fields.Column_AuSoinsDe.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_Rue.ColumnIndex)) {

						this.col_Rue = sqlDataReader.GetSqlString(SPs.spS_Fournisseur.Resultset1.Fields.Column_Rue.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_Ville.ColumnIndex)) {

						this.col_Ville = sqlDataReader.GetSqlString(SPs.spS_Fournisseur.Resultset1.Fields.Column_Ville.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_PaysID.ColumnIndex)) {

						this.col_PaysID = sqlDataReader.GetSqlString(SPs.spS_Fournisseur.Resultset1.Fields.Column_PaysID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_Code_postal.ColumnIndex)) {

						this.col_Code_postal = sqlDataReader.GetSqlString(SPs.spS_Fournisseur.Resultset1.Fields.Column_Code_postal.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_Telephone.ColumnIndex)) {

						this.col_Telephone = sqlDataReader.GetSqlString(SPs.spS_Fournisseur.Resultset1.Fields.Column_Telephone.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_Telephone_Poste.ColumnIndex)) {

						this.col_Telephone_Poste = sqlDataReader.GetSqlString(SPs.spS_Fournisseur.Resultset1.Fields.Column_Telephone_Poste.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_Telecopieur.ColumnIndex)) {

						this.col_Telecopieur = sqlDataReader.GetSqlString(SPs.spS_Fournisseur.Resultset1.Fields.Column_Telecopieur.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_Telephone2.ColumnIndex)) {

						this.col_Telephone2 = sqlDataReader.GetSqlString(SPs.spS_Fournisseur.Resultset1.Fields.Column_Telephone2.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_Telephone2_Desc.ColumnIndex)) {

						this.col_Telephone2_Desc = sqlDataReader.GetSqlString(SPs.spS_Fournisseur.Resultset1.Fields.Column_Telephone2_Desc.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_Telephone2_Poste.ColumnIndex)) {

						this.col_Telephone2_Poste = sqlDataReader.GetSqlString(SPs.spS_Fournisseur.Resultset1.Fields.Column_Telephone2_Poste.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_Telephone3.ColumnIndex)) {

						this.col_Telephone3 = sqlDataReader.GetSqlString(SPs.spS_Fournisseur.Resultset1.Fields.Column_Telephone3.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_Telephone3_Desc.ColumnIndex)) {

						this.col_Telephone3_Desc = sqlDataReader.GetSqlString(SPs.spS_Fournisseur.Resultset1.Fields.Column_Telephone3_Desc.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_Telephone3_Poste.ColumnIndex)) {

						this.col_Telephone3_Poste = sqlDataReader.GetSqlString(SPs.spS_Fournisseur.Resultset1.Fields.Column_Telephone3_Poste.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_No_membre.ColumnIndex)) {

						this.col_No_membre = sqlDataReader.GetSqlString(SPs.spS_Fournisseur.Resultset1.Fields.Column_No_membre.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_Resident.ColumnIndex)) {

						this.col_Resident = sqlDataReader.GetSqlString(SPs.spS_Fournisseur.Resultset1.Fields.Column_Resident.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_Email.ColumnIndex)) {

						this.col_Email = sqlDataReader.GetSqlString(SPs.spS_Fournisseur.Resultset1.Fields.Column_Email.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_WWW.ColumnIndex)) {

						this.col_WWW = sqlDataReader.GetSqlString(SPs.spS_Fournisseur.Resultset1.Fields.Column_WWW.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_Commentaires.ColumnIndex)) {

						this.col_Commentaires = sqlDataReader.GetSqlString(SPs.spS_Fournisseur.Resultset1.Fields.Column_Commentaires.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_AfficherCommentaires.ColumnIndex)) {

						this.col_AfficherCommentaires = sqlDataReader.GetSqlBoolean(SPs.spS_Fournisseur.Resultset1.Fields.Column_AfficherCommentaires.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_DepotDirect.ColumnIndex)) {

						this.col_DepotDirect = sqlDataReader.GetSqlBoolean(SPs.spS_Fournisseur.Resultset1.Fields.Column_DepotDirect.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_InstitutionBanquaireID.ColumnIndex)) {

						this.col_InstitutionBanquaireID = sqlDataReader.GetSqlString(SPs.spS_Fournisseur.Resultset1.Fields.Column_InstitutionBanquaireID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_Banque_transit.ColumnIndex)) {

						this.col_Banque_transit = sqlDataReader.GetSqlString(SPs.spS_Fournisseur.Resultset1.Fields.Column_Banque_transit.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_Banque_folio.ColumnIndex)) {

						this.col_Banque_folio = sqlDataReader.GetSqlString(SPs.spS_Fournisseur.Resultset1.Fields.Column_Banque_folio.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_No_TPS.ColumnIndex)) {

						this.col_No_TPS = sqlDataReader.GetSqlString(SPs.spS_Fournisseur.Resultset1.Fields.Column_No_TPS.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_No_TVQ.ColumnIndex)) {

						this.col_No_TVQ = sqlDataReader.GetSqlString(SPs.spS_Fournisseur.Resultset1.Fields.Column_No_TVQ.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_PayerA.ColumnIndex)) {

						this.col_PayerA = sqlDataReader.GetSqlBoolean(SPs.spS_Fournisseur.Resultset1.Fields.Column_PayerA.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_PayerAID.ColumnIndex)) {

						this.col_PayerAID = sqlDataReader.GetSqlString(SPs.spS_Fournisseur.Resultset1.Fields.Column_PayerAID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_Statut.ColumnIndex)) {

						this.col_Statut = sqlDataReader.GetSqlString(SPs.spS_Fournisseur.Resultset1.Fields.Column_Statut.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_Rep_Nom.ColumnIndex)) {

						this.col_Rep_Nom = sqlDataReader.GetSqlString(SPs.spS_Fournisseur.Resultset1.Fields.Column_Rep_Nom.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_Rep_Telephone.ColumnIndex)) {

						this.col_Rep_Telephone = sqlDataReader.GetSqlString(SPs.spS_Fournisseur.Resultset1.Fields.Column_Rep_Telephone.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_Rep_Telephone_Poste.ColumnIndex)) {

						this.col_Rep_Telephone_Poste = sqlDataReader.GetSqlString(SPs.spS_Fournisseur.Resultset1.Fields.Column_Rep_Telephone_Poste.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_Rep_Email.ColumnIndex)) {

						this.col_Rep_Email = sqlDataReader.GetSqlString(SPs.spS_Fournisseur.Resultset1.Fields.Column_Rep_Email.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_EnAnglais.ColumnIndex)) {

						this.col_EnAnglais = sqlDataReader.GetSqlBoolean(SPs.spS_Fournisseur.Resultset1.Fields.Column_EnAnglais.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_Actif.ColumnIndex)) {

						this.col_Actif = sqlDataReader.GetSqlBoolean(SPs.spS_Fournisseur.Resultset1.Fields.Column_Actif.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_MRCProducteurID.ColumnIndex)) {

						this.col_MRCProducteurID = sqlDataReader.GetSqlInt32(SPs.spS_Fournisseur.Resultset1.Fields.Column_MRCProducteurID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_PaiementManuel.ColumnIndex)) {

						this.col_PaiementManuel = sqlDataReader.GetSqlBoolean(SPs.spS_Fournisseur.Resultset1.Fields.Column_PaiementManuel.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_Journal.ColumnIndex)) {

						this.col_Journal = sqlDataReader.GetSqlBoolean(SPs.spS_Fournisseur.Resultset1.Fields.Column_Journal.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_RecoitTPS.ColumnIndex)) {

						this.col_RecoitTPS = sqlDataReader.GetSqlBoolean(SPs.spS_Fournisseur.Resultset1.Fields.Column_RecoitTPS.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_RecoitTVQ.ColumnIndex)) {

						this.col_RecoitTVQ = sqlDataReader.GetSqlBoolean(SPs.spS_Fournisseur.Resultset1.Fields.Column_RecoitTVQ.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_ModifierTrigger.ColumnIndex)) {

						this.col_ModifierTrigger = sqlDataReader.GetSqlBoolean(SPs.spS_Fournisseur.Resultset1.Fields.Column_ModifierTrigger.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_IsProducteur.ColumnIndex)) {

						this.col_IsProducteur = sqlDataReader.GetSqlBoolean(SPs.spS_Fournisseur.Resultset1.Fields.Column_IsProducteur.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_IsTransporteur.ColumnIndex)) {

						this.col_IsTransporteur = sqlDataReader.GetSqlBoolean(SPs.spS_Fournisseur.Resultset1.Fields.Column_IsTransporteur.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_IsChargeur.ColumnIndex)) {

						this.col_IsChargeur = sqlDataReader.GetSqlBoolean(SPs.spS_Fournisseur.Resultset1.Fields.Column_IsChargeur.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_IsAutre.ColumnIndex)) {

						this.col_IsAutre = sqlDataReader.GetSqlBoolean(SPs.spS_Fournisseur.Resultset1.Fields.Column_IsAutre.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_AfficherCommentairesSurPermit.ColumnIndex)) {

						this.col_AfficherCommentairesSurPermit = sqlDataReader.GetSqlBoolean(SPs.spS_Fournisseur.Resultset1.Fields.Column_AfficherCommentairesSurPermit.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_PasEmissionPermis.ColumnIndex)) {

						this.col_PasEmissionPermis = sqlDataReader.GetSqlBoolean(SPs.spS_Fournisseur.Resultset1.Fields.Column_PasEmissionPermis.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_Generique.ColumnIndex)) {

						this.col_Generique = sqlDataReader.GetSqlBoolean(SPs.spS_Fournisseur.Resultset1.Fields.Column_Generique.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_Membre_OGC.ColumnIndex)) {

						this.col_Membre_OGC = sqlDataReader.GetSqlBoolean(SPs.spS_Fournisseur.Resultset1.Fields.Column_Membre_OGC.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_InscritTPS.ColumnIndex)) {

						this.col_InscritTPS = sqlDataReader.GetSqlBoolean(SPs.spS_Fournisseur.Resultset1.Fields.Column_InscritTPS.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_InscritTVQ.ColumnIndex)) {

						this.col_InscritTVQ = sqlDataReader.GetSqlBoolean(SPs.spS_Fournisseur.Resultset1.Fields.Column_InscritTVQ.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_IsOGC.ColumnIndex)) {

						this.col_IsOGC = sqlDataReader.GetSqlBoolean(SPs.spS_Fournisseur.Resultset1.Fields.Column_IsOGC.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_Rep2_Nom.ColumnIndex)) {

						this.col_Rep2_Nom = sqlDataReader.GetSqlString(SPs.spS_Fournisseur.Resultset1.Fields.Column_Rep2_Nom.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_Rep2_Telephone.ColumnIndex)) {

						this.col_Rep2_Telephone = sqlDataReader.GetSqlString(SPs.spS_Fournisseur.Resultset1.Fields.Column_Rep2_Telephone.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_Rep2_Telephone_Poste.ColumnIndex)) {

						this.col_Rep2_Telephone_Poste = sqlDataReader.GetSqlString(SPs.spS_Fournisseur.Resultset1.Fields.Column_Rep2_Telephone_Poste.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_Rep2_Email.ColumnIndex)) {

						this.col_Rep2_Email = sqlDataReader.GetSqlString(SPs.spS_Fournisseur.Resultset1.Fields.Column_Rep2_Email.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Fournisseur.Resultset1.Fields.Column_Rep2_Commentaires.ColumnIndex)) {

						this.col_Rep2_Commentaires = sqlDataReader.GetSqlString(SPs.spS_Fournisseur.Resultset1.Fields.Column_Rep2_Commentaires.ColumnIndex);
					}

					if (sqlDataReader != null && !sqlDataReader.IsClosed) {

						sqlDataReader.Close();
					}

					if (Sp.Connection != null && Sp.Connection.State == System.Data.ConnectionState.Open) {

						Sp.Connection.Close();
						Sp.Connection.Dispose();
					}

					this.recordIsLoaded = true;

					return(true);
				}
				else {

					if (sqlDataReader != null && !sqlDataReader.IsClosed) {

						sqlDataReader.Close();
					}

					if (Sp.Connection != null && Sp.Connection.State == System.Data.ConnectionState.Open) {

						Sp.Connection.Close();
						Sp.Connection.Dispose();
					}

					this.recordIsLoaded = false;

					return(false);
				}
			}
			else {

				if (sqlDataReader != null && !sqlDataReader.IsClosed) {

					sqlDataReader.Close();
				}

				if (Sp.Connection != null && Sp.Connection.State == System.Data.ConnectionState.Open) {

					Sp.Connection.Close();
					Sp.Connection.Dispose();
				}

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Fournisseur_Record", "Refresh");
			}
		}

		public void Update() {

			if (!this.recordWasLoadedFromDB) {

				throw new ArgumentException("No record was loaded from the database. No update is possible.");
			}

			bool ChangesHaveBeenMade = false;

			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_CleTriWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_NomWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_AuSoinsDeWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_RueWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_VilleWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_PaysIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Code_postalWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_TelephoneWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Telephone_PosteWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_TelecopieurWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Telephone2WasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Telephone2_DescWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Telephone2_PosteWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Telephone3WasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Telephone3_DescWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Telephone3_PosteWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_No_membreWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_ResidentWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_EmailWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_WWWWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_CommentairesWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_AfficherCommentairesWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_DepotDirectWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_InstitutionBanquaireIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Banque_transitWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Banque_folioWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_No_TPSWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_No_TVQWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_PayerAWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_PayerAIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_StatutWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Rep_NomWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Rep_TelephoneWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Rep_Telephone_PosteWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Rep_EmailWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_EnAnglaisWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_ActifWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_MRCProducteurIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_PaiementManuelWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_JournalWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_RecoitTPSWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_RecoitTVQWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_ModifierTriggerWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_IsProducteurWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_IsTransporteurWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_IsChargeurWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_IsAutreWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_AfficherCommentairesSurPermitWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_PasEmissionPermisWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_GeneriqueWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Membre_OGCWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_InscritTPSWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_InscritTVQWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_IsOGCWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Rep2_NomWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Rep2_TelephoneWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Rep2_Telephone_PosteWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Rep2_EmailWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Rep2_CommentairesWasUpdated);

			if (!ChangesHaveBeenMade) {

				return;
			}

			Params.spU_Fournisseur Param = new Params.spU_Fournisseur(false);
			Param.SetUpConnection(this.connectionString);
			Param.Param_ID = this.col_ID;

			if (this.col_CleTriWasUpdated) {

				Param.Param_CleTri = this.col_CleTri;
				Param.Param_ConsiderNull_CleTri = true;
			}

			if (this.col_NomWasUpdated) {

				Param.Param_Nom = this.col_Nom;
				Param.Param_ConsiderNull_Nom = true;
			}

			if (this.col_AuSoinsDeWasUpdated) {

				Param.Param_AuSoinsDe = this.col_AuSoinsDe;
				Param.Param_ConsiderNull_AuSoinsDe = true;
			}

			if (this.col_RueWasUpdated) {

				Param.Param_Rue = this.col_Rue;
				Param.Param_ConsiderNull_Rue = true;
			}

			if (this.col_VilleWasUpdated) {

				Param.Param_Ville = this.col_Ville;
				Param.Param_ConsiderNull_Ville = true;
			}

			if (this.col_PaysIDWasUpdated) {

				Param.Param_PaysID = this.col_PaysID;
				Param.Param_ConsiderNull_PaysID = true;
			}

			if (this.col_Code_postalWasUpdated) {

				Param.Param_Code_postal = this.col_Code_postal;
				Param.Param_ConsiderNull_Code_postal = true;
			}

			if (this.col_TelephoneWasUpdated) {

				Param.Param_Telephone = this.col_Telephone;
				Param.Param_ConsiderNull_Telephone = true;
			}

			if (this.col_Telephone_PosteWasUpdated) {

				Param.Param_Telephone_Poste = this.col_Telephone_Poste;
				Param.Param_ConsiderNull_Telephone_Poste = true;
			}

			if (this.col_TelecopieurWasUpdated) {

				Param.Param_Telecopieur = this.col_Telecopieur;
				Param.Param_ConsiderNull_Telecopieur = true;
			}

			if (this.col_Telephone2WasUpdated) {

				Param.Param_Telephone2 = this.col_Telephone2;
				Param.Param_ConsiderNull_Telephone2 = true;
			}

			if (this.col_Telephone2_DescWasUpdated) {

				Param.Param_Telephone2_Desc = this.col_Telephone2_Desc;
				Param.Param_ConsiderNull_Telephone2_Desc = true;
			}

			if (this.col_Telephone2_PosteWasUpdated) {

				Param.Param_Telephone2_Poste = this.col_Telephone2_Poste;
				Param.Param_ConsiderNull_Telephone2_Poste = true;
			}

			if (this.col_Telephone3WasUpdated) {

				Param.Param_Telephone3 = this.col_Telephone3;
				Param.Param_ConsiderNull_Telephone3 = true;
			}

			if (this.col_Telephone3_DescWasUpdated) {

				Param.Param_Telephone3_Desc = this.col_Telephone3_Desc;
				Param.Param_ConsiderNull_Telephone3_Desc = true;
			}

			if (this.col_Telephone3_PosteWasUpdated) {

				Param.Param_Telephone3_Poste = this.col_Telephone3_Poste;
				Param.Param_ConsiderNull_Telephone3_Poste = true;
			}

			if (this.col_No_membreWasUpdated) {

				Param.Param_No_membre = this.col_No_membre;
				Param.Param_ConsiderNull_No_membre = true;
			}

			if (this.col_ResidentWasUpdated) {

				Param.Param_Resident = this.col_Resident;
				Param.Param_ConsiderNull_Resident = true;
			}

			if (this.col_EmailWasUpdated) {

				Param.Param_Email = this.col_Email;
				Param.Param_ConsiderNull_Email = true;
			}

			if (this.col_WWWWasUpdated) {

				Param.Param_WWW = this.col_WWW;
				Param.Param_ConsiderNull_WWW = true;
			}

			if (this.col_CommentairesWasUpdated) {

				Param.Param_Commentaires = this.col_Commentaires;
				Param.Param_ConsiderNull_Commentaires = true;
			}

			if (this.col_AfficherCommentairesWasUpdated) {

				Param.Param_AfficherCommentaires = this.col_AfficherCommentaires;
				Param.Param_ConsiderNull_AfficherCommentaires = true;
			}

			if (this.col_DepotDirectWasUpdated) {

				Param.Param_DepotDirect = this.col_DepotDirect;
				Param.Param_ConsiderNull_DepotDirect = true;
			}

			if (this.col_InstitutionBanquaireIDWasUpdated) {

				Param.Param_InstitutionBanquaireID = this.col_InstitutionBanquaireID;
				Param.Param_ConsiderNull_InstitutionBanquaireID = true;
			}

			if (this.col_Banque_transitWasUpdated) {

				Param.Param_Banque_transit = this.col_Banque_transit;
				Param.Param_ConsiderNull_Banque_transit = true;
			}

			if (this.col_Banque_folioWasUpdated) {

				Param.Param_Banque_folio = this.col_Banque_folio;
				Param.Param_ConsiderNull_Banque_folio = true;
			}

			if (this.col_No_TPSWasUpdated) {

				Param.Param_No_TPS = this.col_No_TPS;
				Param.Param_ConsiderNull_No_TPS = true;
			}

			if (this.col_No_TVQWasUpdated) {

				Param.Param_No_TVQ = this.col_No_TVQ;
				Param.Param_ConsiderNull_No_TVQ = true;
			}

			if (this.col_PayerAWasUpdated) {

				Param.Param_PayerA = this.col_PayerA;
				Param.Param_ConsiderNull_PayerA = true;
			}

			if (this.col_PayerAIDWasUpdated) {

				Param.Param_PayerAID = this.col_PayerAID;
				Param.Param_ConsiderNull_PayerAID = true;
			}

			if (this.col_StatutWasUpdated) {

				Param.Param_Statut = this.col_Statut;
				Param.Param_ConsiderNull_Statut = true;
			}

			if (this.col_Rep_NomWasUpdated) {

				Param.Param_Rep_Nom = this.col_Rep_Nom;
				Param.Param_ConsiderNull_Rep_Nom = true;
			}

			if (this.col_Rep_TelephoneWasUpdated) {

				Param.Param_Rep_Telephone = this.col_Rep_Telephone;
				Param.Param_ConsiderNull_Rep_Telephone = true;
			}

			if (this.col_Rep_Telephone_PosteWasUpdated) {

				Param.Param_Rep_Telephone_Poste = this.col_Rep_Telephone_Poste;
				Param.Param_ConsiderNull_Rep_Telephone_Poste = true;
			}

			if (this.col_Rep_EmailWasUpdated) {

				Param.Param_Rep_Email = this.col_Rep_Email;
				Param.Param_ConsiderNull_Rep_Email = true;
			}

			if (this.col_EnAnglaisWasUpdated) {

				Param.Param_EnAnglais = this.col_EnAnglais;
				Param.Param_ConsiderNull_EnAnglais = true;
			}

			if (this.col_ActifWasUpdated) {

				Param.Param_Actif = this.col_Actif;
				Param.Param_ConsiderNull_Actif = true;
			}

			if (this.col_MRCProducteurIDWasUpdated) {

				Param.Param_MRCProducteurID = this.col_MRCProducteurID;
				Param.Param_ConsiderNull_MRCProducteurID = true;
			}

			if (this.col_PaiementManuelWasUpdated) {

				Param.Param_PaiementManuel = this.col_PaiementManuel;
				Param.Param_ConsiderNull_PaiementManuel = true;
			}

			if (this.col_JournalWasUpdated) {

				Param.Param_Journal = this.col_Journal;
				Param.Param_ConsiderNull_Journal = true;
			}

			if (this.col_RecoitTPSWasUpdated) {

				Param.Param_RecoitTPS = this.col_RecoitTPS;
				Param.Param_ConsiderNull_RecoitTPS = true;
			}

			if (this.col_RecoitTVQWasUpdated) {

				Param.Param_RecoitTVQ = this.col_RecoitTVQ;
				Param.Param_ConsiderNull_RecoitTVQ = true;
			}

			if (this.col_ModifierTriggerWasUpdated) {

				Param.Param_ModifierTrigger = this.col_ModifierTrigger;
				Param.Param_ConsiderNull_ModifierTrigger = true;
			}

			if (this.col_IsProducteurWasUpdated) {

				Param.Param_IsProducteur = this.col_IsProducteur;
				Param.Param_ConsiderNull_IsProducteur = true;
			}

			if (this.col_IsTransporteurWasUpdated) {

				Param.Param_IsTransporteur = this.col_IsTransporteur;
				Param.Param_ConsiderNull_IsTransporteur = true;
			}

			if (this.col_IsChargeurWasUpdated) {

				Param.Param_IsChargeur = this.col_IsChargeur;
				Param.Param_ConsiderNull_IsChargeur = true;
			}

			if (this.col_IsAutreWasUpdated) {

				Param.Param_IsAutre = this.col_IsAutre;
				Param.Param_ConsiderNull_IsAutre = true;
			}

			if (this.col_AfficherCommentairesSurPermitWasUpdated) {

				Param.Param_AfficherCommentairesSurPermit = this.col_AfficherCommentairesSurPermit;
				Param.Param_ConsiderNull_AfficherCommentairesSurPermit = true;
			}

			if (this.col_PasEmissionPermisWasUpdated) {

				Param.Param_PasEmissionPermis = this.col_PasEmissionPermis;
				Param.Param_ConsiderNull_PasEmissionPermis = true;
			}

			if (this.col_GeneriqueWasUpdated) {

				Param.Param_Generique = this.col_Generique;
				Param.Param_ConsiderNull_Generique = true;
			}

			if (this.col_Membre_OGCWasUpdated) {

				Param.Param_Membre_OGC = this.col_Membre_OGC;
				Param.Param_ConsiderNull_Membre_OGC = true;
			}

			if (this.col_InscritTPSWasUpdated) {

				Param.Param_InscritTPS = this.col_InscritTPS;
				Param.Param_ConsiderNull_InscritTPS = true;
			}

			if (this.col_InscritTVQWasUpdated) {

				Param.Param_InscritTVQ = this.col_InscritTVQ;
				Param.Param_ConsiderNull_InscritTVQ = true;
			}

			if (this.col_IsOGCWasUpdated) {

				Param.Param_IsOGC = this.col_IsOGC;
				Param.Param_ConsiderNull_IsOGC = true;
			}

			if (this.col_Rep2_NomWasUpdated) {

				Param.Param_Rep2_Nom = this.col_Rep2_Nom;
				Param.Param_ConsiderNull_Rep2_Nom = true;
			}

			if (this.col_Rep2_TelephoneWasUpdated) {

				Param.Param_Rep2_Telephone = this.col_Rep2_Telephone;
				Param.Param_ConsiderNull_Rep2_Telephone = true;
			}

			if (this.col_Rep2_Telephone_PosteWasUpdated) {

				Param.Param_Rep2_Telephone_Poste = this.col_Rep2_Telephone_Poste;
				Param.Param_ConsiderNull_Rep2_Telephone_Poste = true;
			}

			if (this.col_Rep2_EmailWasUpdated) {

				Param.Param_Rep2_Email = this.col_Rep2_Email;
				Param.Param_ConsiderNull_Rep2_Email = true;
			}

			if (this.col_Rep2_CommentairesWasUpdated) {

				Param.Param_Rep2_Commentaires = this.col_Rep2_Commentaires;
				Param.Param_ConsiderNull_Rep2_Commentaires = true;
			}

			SPs.spU_Fournisseur Sp = new SPs.spU_Fournisseur();
			if (Sp.Execute(ref Param)) {

				this.col_CleTriWasUpdated = false;
				this.col_NomWasUpdated = false;
				this.col_AuSoinsDeWasUpdated = false;
				this.col_RueWasUpdated = false;
				this.col_VilleWasUpdated = false;
				this.col_PaysIDWasUpdated = false;
				this.col_Code_postalWasUpdated = false;
				this.col_TelephoneWasUpdated = false;
				this.col_Telephone_PosteWasUpdated = false;
				this.col_TelecopieurWasUpdated = false;
				this.col_Telephone2WasUpdated = false;
				this.col_Telephone2_DescWasUpdated = false;
				this.col_Telephone2_PosteWasUpdated = false;
				this.col_Telephone3WasUpdated = false;
				this.col_Telephone3_DescWasUpdated = false;
				this.col_Telephone3_PosteWasUpdated = false;
				this.col_No_membreWasUpdated = false;
				this.col_ResidentWasUpdated = false;
				this.col_EmailWasUpdated = false;
				this.col_WWWWasUpdated = false;
				this.col_CommentairesWasUpdated = false;
				this.col_AfficherCommentairesWasUpdated = false;
				this.col_DepotDirectWasUpdated = false;
				this.col_InstitutionBanquaireIDWasUpdated = false;
				this.col_Banque_transitWasUpdated = false;
				this.col_Banque_folioWasUpdated = false;
				this.col_No_TPSWasUpdated = false;
				this.col_No_TVQWasUpdated = false;
				this.col_PayerAWasUpdated = false;
				this.col_PayerAIDWasUpdated = false;
				this.col_StatutWasUpdated = false;
				this.col_Rep_NomWasUpdated = false;
				this.col_Rep_TelephoneWasUpdated = false;
				this.col_Rep_Telephone_PosteWasUpdated = false;
				this.col_Rep_EmailWasUpdated = false;
				this.col_EnAnglaisWasUpdated = false;
				this.col_ActifWasUpdated = false;
				this.col_MRCProducteurIDWasUpdated = false;
				this.col_PaiementManuelWasUpdated = false;
				this.col_JournalWasUpdated = false;
				this.col_RecoitTPSWasUpdated = false;
				this.col_RecoitTVQWasUpdated = false;
				this.col_ModifierTriggerWasUpdated = false;
				this.col_IsProducteurWasUpdated = false;
				this.col_IsTransporteurWasUpdated = false;
				this.col_IsChargeurWasUpdated = false;
				this.col_IsAutreWasUpdated = false;
				this.col_AfficherCommentairesSurPermitWasUpdated = false;
				this.col_PasEmissionPermisWasUpdated = false;
				this.col_GeneriqueWasUpdated = false;
				this.col_Membre_OGCWasUpdated = false;
				this.col_InscritTPSWasUpdated = false;
				this.col_InscritTVQWasUpdated = false;
				this.col_IsOGCWasUpdated = false;
				this.col_Rep2_NomWasUpdated = false;
				this.col_Rep2_TelephoneWasUpdated = false;
				this.col_Rep2_Telephone_PosteWasUpdated = false;
				this.col_Rep2_EmailWasUpdated = false;
				this.col_Rep2_CommentairesWasUpdated = false;
			}
			else {

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Fournisseur_Record", "Update");
			}		
		}

		private AjustementCalcule_Producteur_Collection internal_AjustementCalcule_Producteur_Col_ProducteurID_Collection = null;
		public AjustementCalcule_Producteur_Collection AjustementCalcule_Producteur_Col_ProducteurID_Collection {

			get {

				if (this.internal_AjustementCalcule_Producteur_Col_ProducteurID_Collection == null) {

					this.internal_AjustementCalcule_Producteur_Col_ProducteurID_Collection = new AjustementCalcule_Producteur_Collection(this.connectionString);
					this.internal_AjustementCalcule_Producteur_Col_ProducteurID_Collection.LoadFrom_ProducteurID(this.col_ID, this);
				}

				return(this.internal_AjustementCalcule_Producteur_Col_ProducteurID_Collection);
			}
		}

		private AjustementCalcule_Transporteur_Collection internal_AjustementCalcule_Transporteur_Col_TransporteurID_Collection = null;
		public AjustementCalcule_Transporteur_Collection AjustementCalcule_Transporteur_Col_TransporteurID_Collection {

			get {

				if (this.internal_AjustementCalcule_Transporteur_Col_TransporteurID_Collection == null) {

					this.internal_AjustementCalcule_Transporteur_Col_TransporteurID_Collection = new AjustementCalcule_Transporteur_Collection(this.connectionString);
					this.internal_AjustementCalcule_Transporteur_Col_TransporteurID_Collection.LoadFrom_TransporteurID(this.col_ID, this);
				}

				return(this.internal_AjustementCalcule_Transporteur_Col_TransporteurID_Collection);
			}
		}

		private Cert_Proprietaire_Collection internal_Cert_Proprietaire_Col_FournisseurID_Collection = null;
		public Cert_Proprietaire_Collection Cert_Proprietaire_Col_FournisseurID_Collection {

			get {

				if (this.internal_Cert_Proprietaire_Col_FournisseurID_Collection == null) {

					this.internal_Cert_Proprietaire_Col_FournisseurID_Collection = new Cert_Proprietaire_Collection(this.connectionString);
					this.internal_Cert_Proprietaire_Col_FournisseurID_Collection.LoadFrom_FournisseurID(this.col_ID, this);
				}

				return(this.internal_Cert_Proprietaire_Col_FournisseurID_Collection);
			}
		}

		private Contingentement_Demande_Collection internal_Contingentement_Demande_Col_ProducteurID_Collection = null;
		public Contingentement_Demande_Collection Contingentement_Demande_Col_ProducteurID_Collection {

			get {

				if (this.internal_Contingentement_Demande_Col_ProducteurID_Collection == null) {

					this.internal_Contingentement_Demande_Col_ProducteurID_Collection = new Contingentement_Demande_Collection(this.connectionString);
					this.internal_Contingentement_Demande_Col_ProducteurID_Collection.LoadFrom_ProducteurID(this.col_ID, this);
				}

				return(this.internal_Contingentement_Demande_Col_ProducteurID_Collection);
			}
		}

		private Contingentement_Demande_Collection internal_Contingentement_Demande_Col_TransporteurID_Collection = null;
		public Contingentement_Demande_Collection Contingentement_Demande_Col_TransporteurID_Collection {

			get {

				if (this.internal_Contingentement_Demande_Col_TransporteurID_Collection == null) {

					this.internal_Contingentement_Demande_Col_TransporteurID_Collection = new Contingentement_Demande_Collection(this.connectionString);
					this.internal_Contingentement_Demande_Col_TransporteurID_Collection.LoadFrom_TransporteurID(this.col_ID, this);
				}

				return(this.internal_Contingentement_Demande_Col_TransporteurID_Collection);
			}
		}

		private Contingentement_Producteur_Collection internal_Contingentement_Producteur_Col_ProducteurID_Collection = null;
		public Contingentement_Producteur_Collection Contingentement_Producteur_Col_ProducteurID_Collection {

			get {

				if (this.internal_Contingentement_Producteur_Col_ProducteurID_Collection == null) {

					this.internal_Contingentement_Producteur_Col_ProducteurID_Collection = new Contingentement_Producteur_Collection(this.connectionString);
					this.internal_Contingentement_Producteur_Col_ProducteurID_Collection.LoadFrom_ProducteurID(this.col_ID, this);
				}

				return(this.internal_Contingentement_Producteur_Col_ProducteurID_Collection);
			}
		}

		private FactureFournisseur_Collection internal_FactureFournisseur_Col_FournisseurID_Collection = null;
		public FactureFournisseur_Collection FactureFournisseur_Col_FournisseurID_Collection {

			get {

				if (this.internal_FactureFournisseur_Col_FournisseurID_Collection == null) {

					this.internal_FactureFournisseur_Col_FournisseurID_Collection = new FactureFournisseur_Collection(this.connectionString);
					this.internal_FactureFournisseur_Col_FournisseurID_Collection.LoadFrom_FournisseurID(this.col_ID, this);
				}

				return(this.internal_FactureFournisseur_Col_FournisseurID_Collection);
			}
		}

		private FactureFournisseur_Collection internal_FactureFournisseur_Col_PayerAID_Collection = null;
		public FactureFournisseur_Collection FactureFournisseur_Col_PayerAID_Collection {

			get {

				if (this.internal_FactureFournisseur_Col_PayerAID_Collection == null) {

					this.internal_FactureFournisseur_Col_PayerAID_Collection = new FactureFournisseur_Collection(this.connectionString);
					this.internal_FactureFournisseur_Col_PayerAID_Collection.LoadFrom_PayerAID(this.col_ID, this);
				}

				return(this.internal_FactureFournisseur_Col_PayerAID_Collection);
			}
		}

		private FactureUsine_Detail_Collection internal_FactureUsine_Detail_Col_ProducteurID_Collection = null;
		public FactureUsine_Detail_Collection FactureUsine_Detail_Col_ProducteurID_Collection {

			get {

				if (this.internal_FactureUsine_Detail_Col_ProducteurID_Collection == null) {

					this.internal_FactureUsine_Detail_Col_ProducteurID_Collection = new FactureUsine_Detail_Collection(this.connectionString);
					this.internal_FactureUsine_Detail_Col_ProducteurID_Collection.LoadFrom_ProducteurID(this.col_ID, this);
				}

				return(this.internal_FactureUsine_Detail_Col_ProducteurID_Collection);
			}
		}

		private FactureUsine_Detail_Collection internal_FactureUsine_Detail_Col_ProducteurEntentePaiementID_Collection = null;
		public FactureUsine_Detail_Collection FactureUsine_Detail_Col_ProducteurEntentePaiementID_Collection {

			get {

				if (this.internal_FactureUsine_Detail_Col_ProducteurEntentePaiementID_Collection == null) {

					this.internal_FactureUsine_Detail_Col_ProducteurEntentePaiementID_Collection = new FactureUsine_Detail_Collection(this.connectionString);
					this.internal_FactureUsine_Detail_Col_ProducteurEntentePaiementID_Collection.LoadFrom_ProducteurEntentePaiementID(this.col_ID, this);
				}

				return(this.internal_FactureUsine_Detail_Col_ProducteurEntentePaiementID_Collection);
			}
		}

		private Fournisseur_Camion_Collection internal_Fournisseur_Camion_Col_FournisseurID_Collection = null;
		public Fournisseur_Camion_Collection Fournisseur_Camion_Col_FournisseurID_Collection {

			get {

				if (this.internal_Fournisseur_Camion_Col_FournisseurID_Collection == null) {

					this.internal_Fournisseur_Camion_Col_FournisseurID_Collection = new Fournisseur_Camion_Collection(this.connectionString);
					this.internal_Fournisseur_Camion_Col_FournisseurID_Collection.LoadFrom_FournisseurID(this.col_ID, this);
				}

				return(this.internal_Fournisseur_Camion_Col_FournisseurID_Collection);
			}
		}

		private GestionVolume_Collection internal_GestionVolume_Col_ProducteurID_Collection = null;
		public GestionVolume_Collection GestionVolume_Col_ProducteurID_Collection {

			get {

				if (this.internal_GestionVolume_Col_ProducteurID_Collection == null) {

					this.internal_GestionVolume_Col_ProducteurID_Collection = new GestionVolume_Collection(this.connectionString);
					this.internal_GestionVolume_Col_ProducteurID_Collection.LoadFrom_ProducteurID(this.col_ID, this);
				}

				return(this.internal_GestionVolume_Col_ProducteurID_Collection);
			}
		}

		private IndexationCalcule_Producteur_Collection internal_IndexationCalcule_Producteur_Col_ProducteurID_Collection = null;
		public IndexationCalcule_Producteur_Collection IndexationCalcule_Producteur_Col_ProducteurID_Collection {

			get {

				if (this.internal_IndexationCalcule_Producteur_Col_ProducteurID_Collection == null) {

					this.internal_IndexationCalcule_Producteur_Col_ProducteurID_Collection = new IndexationCalcule_Producteur_Collection(this.connectionString);
					this.internal_IndexationCalcule_Producteur_Col_ProducteurID_Collection.LoadFrom_ProducteurID(this.col_ID, this);
				}

				return(this.internal_IndexationCalcule_Producteur_Col_ProducteurID_Collection);
			}
		}

		private IndexationCalcule_Transporteur_Collection internal_IndexationCalcule_Transporteur_Col_TransporteurID_Collection = null;
		public IndexationCalcule_Transporteur_Collection IndexationCalcule_Transporteur_Col_TransporteurID_Collection {

			get {

				if (this.internal_IndexationCalcule_Transporteur_Col_TransporteurID_Collection == null) {

					this.internal_IndexationCalcule_Transporteur_Col_TransporteurID_Collection = new IndexationCalcule_Transporteur_Collection(this.connectionString);
					this.internal_IndexationCalcule_Transporteur_Col_TransporteurID_Collection.LoadFrom_TransporteurID(this.col_ID, this);
				}

				return(this.internal_IndexationCalcule_Transporteur_Col_TransporteurID_Collection);
			}
		}

		private Livraison_Collection internal_Livraison_Col_DroitCoupeID_Collection = null;
		public Livraison_Collection Livraison_Col_DroitCoupeID_Collection {

			get {

				if (this.internal_Livraison_Col_DroitCoupeID_Collection == null) {

					this.internal_Livraison_Col_DroitCoupeID_Collection = new Livraison_Collection(this.connectionString);
					this.internal_Livraison_Col_DroitCoupeID_Collection.LoadFrom_DroitCoupeID(this.col_ID, this);
				}

				return(this.internal_Livraison_Col_DroitCoupeID_Collection);
			}
		}

		private Livraison_Collection internal_Livraison_Col_EntentePaiementID_Collection = null;
		public Livraison_Collection Livraison_Col_EntentePaiementID_Collection {

			get {

				if (this.internal_Livraison_Col_EntentePaiementID_Collection == null) {

					this.internal_Livraison_Col_EntentePaiementID_Collection = new Livraison_Collection(this.connectionString);
					this.internal_Livraison_Col_EntentePaiementID_Collection.LoadFrom_EntentePaiementID(this.col_ID, this);
				}

				return(this.internal_Livraison_Col_EntentePaiementID_Collection);
			}
		}

		private Livraison_Collection internal_Livraison_Col_TransporteurID_Collection = null;
		public Livraison_Collection Livraison_Col_TransporteurID_Collection {

			get {

				if (this.internal_Livraison_Col_TransporteurID_Collection == null) {

					this.internal_Livraison_Col_TransporteurID_Collection = new Livraison_Collection(this.connectionString);
					this.internal_Livraison_Col_TransporteurID_Collection.LoadFrom_TransporteurID(this.col_ID, this);
				}

				return(this.internal_Livraison_Col_TransporteurID_Collection);
			}
		}

		private Livraison_Collection internal_Livraison_Col_ChargeurID_Collection = null;
		public Livraison_Collection Livraison_Col_ChargeurID_Collection {

			get {

				if (this.internal_Livraison_Col_ChargeurID_Collection == null) {

					this.internal_Livraison_Col_ChargeurID_Collection = new Livraison_Collection(this.connectionString);
					this.internal_Livraison_Col_ChargeurID_Collection.LoadFrom_ChargeurID(this.col_ID, this);
				}

				return(this.internal_Livraison_Col_ChargeurID_Collection);
			}
		}

		private Livraison_Detail_Collection internal_Livraison_Detail_Col_ProducteurID_Collection = null;
		public Livraison_Detail_Collection Livraison_Detail_Col_ProducteurID_Collection {

			get {

				if (this.internal_Livraison_Detail_Col_ProducteurID_Collection == null) {

					this.internal_Livraison_Detail_Col_ProducteurID_Collection = new Livraison_Detail_Collection(this.connectionString);
					this.internal_Livraison_Detail_Col_ProducteurID_Collection.LoadFrom_ProducteurID(this.col_ID, this);
				}

				return(this.internal_Livraison_Detail_Col_ProducteurID_Collection);
			}
		}

		private Lot_Collection internal_Lot_Col_ProprietaireID_Collection = null;
		public Lot_Collection Lot_Col_ProprietaireID_Collection {

			get {

				if (this.internal_Lot_Col_ProprietaireID_Collection == null) {

					this.internal_Lot_Col_ProprietaireID_Collection = new Lot_Collection(this.connectionString);
					this.internal_Lot_Col_ProprietaireID_Collection.LoadFrom_ProprietaireID(this.col_ID, this);
				}

				return(this.internal_Lot_Col_ProprietaireID_Collection);
			}
		}

		private Lot_Collection internal_Lot_Col_ContingentID_Collection = null;
		public Lot_Collection Lot_Col_ContingentID_Collection {

			get {

				if (this.internal_Lot_Col_ContingentID_Collection == null) {

					this.internal_Lot_Col_ContingentID_Collection = new Lot_Collection(this.connectionString);
					this.internal_Lot_Col_ContingentID_Collection.LoadFrom_ContingentID(this.col_ID, this);
				}

				return(this.internal_Lot_Col_ContingentID_Collection);
			}
		}

		private Lot_Collection internal_Lot_Col_Droit_coupeID_Collection = null;
		public Lot_Collection Lot_Col_Droit_coupeID_Collection {

			get {

				if (this.internal_Lot_Col_Droit_coupeID_Collection == null) {

					this.internal_Lot_Col_Droit_coupeID_Collection = new Lot_Collection(this.connectionString);
					this.internal_Lot_Col_Droit_coupeID_Collection.LoadFrom_Droit_coupeID(this.col_ID, this);
				}

				return(this.internal_Lot_Col_Droit_coupeID_Collection);
			}
		}

		private Lot_Collection internal_Lot_Col_Entente_paiementID_Collection = null;
		public Lot_Collection Lot_Col_Entente_paiementID_Collection {

			get {

				if (this.internal_Lot_Col_Entente_paiementID_Collection == null) {

					this.internal_Lot_Col_Entente_paiementID_Collection = new Lot_Collection(this.connectionString);
					this.internal_Lot_Col_Entente_paiementID_Collection.LoadFrom_Entente_paiementID(this.col_ID, this);
				}

				return(this.internal_Lot_Col_Entente_paiementID_Collection);
			}
		}

		private Lot_Proprietaire_Collection internal_Lot_Proprietaire_Col_ProprietaireID_Collection = null;
		public Lot_Proprietaire_Collection Lot_Proprietaire_Col_ProprietaireID_Collection {

			get {

				if (this.internal_Lot_Proprietaire_Col_ProprietaireID_Collection == null) {

					this.internal_Lot_Proprietaire_Col_ProprietaireID_Collection = new Lot_Proprietaire_Collection(this.connectionString);
					this.internal_Lot_Proprietaire_Col_ProprietaireID_Collection.LoadFrom_ProprietaireID(this.col_ID, this);
				}

				return(this.internal_Lot_Proprietaire_Col_ProprietaireID_Collection);
			}
		}

		private LotContingente_Collection internal_LotContingente_Col_FournisseurID_Collection = null;
		public LotContingente_Collection LotContingente_Col_FournisseurID_Collection {

			get {

				if (this.internal_LotContingente_Col_FournisseurID_Collection == null) {

					this.internal_LotContingente_Col_FournisseurID_Collection = new LotContingente_Collection(this.connectionString);
					this.internal_LotContingente_Col_FournisseurID_Collection.LoadFrom_FournisseurID(this.col_ID, this);
				}

				return(this.internal_LotContingente_Col_FournisseurID_Collection);
			}
		}

		private Permit_Collection internal_Permit_Col_TransporteurID_Collection = null;
		public Permit_Collection Permit_Col_TransporteurID_Collection {

			get {

				if (this.internal_Permit_Col_TransporteurID_Collection == null) {

					this.internal_Permit_Col_TransporteurID_Collection = new Permit_Collection(this.connectionString);
					this.internal_Permit_Col_TransporteurID_Collection.LoadFrom_TransporteurID(this.col_ID, this);
				}

				return(this.internal_Permit_Col_TransporteurID_Collection);
			}
		}

		private Permit_Collection internal_Permit_Col_ProducteurDroitCoupeID_Collection = null;
		public Permit_Collection Permit_Col_ProducteurDroitCoupeID_Collection {

			get {

				if (this.internal_Permit_Col_ProducteurDroitCoupeID_Collection == null) {

					this.internal_Permit_Col_ProducteurDroitCoupeID_Collection = new Permit_Collection(this.connectionString);
					this.internal_Permit_Col_ProducteurDroitCoupeID_Collection.LoadFrom_ProducteurDroitCoupeID(this.col_ID, this);
				}

				return(this.internal_Permit_Col_ProducteurDroitCoupeID_Collection);
			}
		}

		private Permit_Collection internal_Permit_Col_ProducteurEntentePaiementID_Collection = null;
		public Permit_Collection Permit_Col_ProducteurEntentePaiementID_Collection {

			get {

				if (this.internal_Permit_Col_ProducteurEntentePaiementID_Collection == null) {

					this.internal_Permit_Col_ProducteurEntentePaiementID_Collection = new Permit_Collection(this.connectionString);
					this.internal_Permit_Col_ProducteurEntentePaiementID_Collection.LoadFrom_ProducteurEntentePaiementID(this.col_ID, this);
				}

				return(this.internal_Permit_Col_ProducteurEntentePaiementID_Collection);
			}
		}

		private Permit_Collection internal_Permit_Col_ChargeurID_Collection = null;
		public Permit_Collection Permit_Col_ChargeurID_Collection {

			get {

				if (this.internal_Permit_Col_ChargeurID_Collection == null) {

					this.internal_Permit_Col_ChargeurID_Collection = new Permit_Collection(this.connectionString);
					this.internal_Permit_Col_ChargeurID_Collection.LoadFrom_ChargeurID(this.col_ID, this);
				}

				return(this.internal_Permit_Col_ChargeurID_Collection);
			}
		}

		internal string displayName = null;
		public override string ToString() {

			if (!this.recordWasLoadedFromDB) {

				throw new ArgumentException("No record was loaded from the database. The DisplayName is not available.");
			}
		
			if (this.displayName == null) {
			
				Params.spS_Fournisseur_Display Param = new Params.spS_Fournisseur_Display();
				Param.SetUpConnection(this.connectionString);

				Param.Param_ID = this.col_ID;

				System.Data.SqlClient.SqlDataReader sqlDataReader = null;
				SPs.spS_Fournisseur_Display Sp = new SPs.spS_Fournisseur_Display();
				if (Sp.Execute(ref Param, out sqlDataReader)) {

					if (sqlDataReader.Read()) {

						if (!sqlDataReader.IsDBNull(SPs.spS_Fournisseur_Display.Resultset1.Fields.Column_Display.ColumnIndex)) {

							this.displayName = "spS_Fournisseur_Display";
						}
					}

					if (sqlDataReader != null && !sqlDataReader.IsClosed) {

						sqlDataReader.Close();
					}

					if (Sp.Connection != null && Sp.Connection.State == System.Data.ConnectionState.Open) {

						Sp.Connection.Close();
						Sp.Connection.Dispose();
					}

				}
				else {

					if (sqlDataReader != null && !sqlDataReader.IsClosed) {

						sqlDataReader.Close();
					}

					if (Sp.Connection != null && Sp.Connection.State == System.Data.ConnectionState.Open) {

						Sp.Connection.Close();
						Sp.Connection.Dispose();
					}

					throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Fournisseur_Record", "ToString");
				}				
			}
			
			return(this.displayName);
		}
	}
}
