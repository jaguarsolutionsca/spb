using System;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.BusinessComponents {

	/// <summary>
	/// This class is an abstract class that represents the [Lot] table. With this class
	/// you can load or update a record from the database. If you need to add or delete a record,
	/// you must use the <see cref="Gestion_Paie.BusinessComponents.Lot_Collection"/> class to do so.
	/// </summary>
	public sealed class Lot_Record : IBusinessComponentRecord {
	
		internal bool recordWasLoadedFromDB = false;
		private bool recordIsLoaded = false;

		internal string connectionString = String.Empty;
		public string ConnectionString {
		
			get {
			
				return(this.connectionString);
			}
		}
		
		/// <summary>
		/// Initializes a new instance of the Lot_Record class. Use this contructor to add
		/// a new record. Then call the Add method of the Gestion_Paie.BusinessComponents.Lot_Collection class to actually
		/// add the record in the database.
		/// </summary>
		public Lot_Record() {
		
			this.recordWasLoadedFromDB = false;
			this.recordIsLoaded = false;
		}
	
		/// <param name="col_ID">[To be supplied.]</param>
		public Lot_Record(string connectionString, System.Data.SqlTypes.SqlInt32 col_ID) {

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
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Lot'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}", "Lot", CurrentRevision, OriginalRevision));
					}
				}
			}
#endif

			this.recordWasLoadedFromDB = true;
			this.recordIsLoaded = false;
			this.connectionString = connectionString;
			this.col_ID = col_ID;
		}
		
		internal System.Data.SqlTypes.SqlInt32 col_ID = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_ID {
		
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
		
		internal bool col_CantonIDWasSet = false;
		private bool col_CantonIDWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_CantonID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_CantonID {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_CantonID);
			}
			set {
			
				this.col_CantonIDWasUpdated = true;
				this.col_CantonIDWasSet = true;
				this.col_CantonID_Record = null;
				this.col_CantonID = value;
			}
		}

		
		private Canton_Record col_CantonID_Record = null;
		public Canton_Record Col_CantonID_Canton_Record {
		
			get {

				if (this.col_CantonID_Record == null) {
				
					this.col_CantonID_Record = new Canton_Record(this.connectionString, this.col_CantonID);
				}
				
				return(this.col_CantonID_Record);
			}
		}

		internal bool col_RangWasSet = false;
		private bool col_RangWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_Rang = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_Rang {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Rang);
			}
			set {
			
				this.col_RangWasUpdated = true;
				this.col_RangWasSet = true;
				this.col_Rang = value;
			}
		}

		internal bool col_LotWasSet = false;
		private bool col_LotWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_Lot = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_Lot {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Lot);
			}
			set {
			
				this.col_LotWasUpdated = true;
				this.col_LotWasSet = true;
				this.col_Lot = value;
			}
		}

		internal bool col_MunicipaliteIDWasSet = false;
		private bool col_MunicipaliteIDWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_MunicipaliteID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_MunicipaliteID {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_MunicipaliteID);
			}
			set {
			
				this.col_MunicipaliteIDWasUpdated = true;
				this.col_MunicipaliteIDWasSet = true;
				this.col_MunicipaliteID_Record = null;
				this.col_MunicipaliteID = value;
			}
		}

		
		private Municipalite_Zone_Record col_MunicipaliteID_Record = null;
		public Municipalite_Zone_Record Col_MunicipaliteID_Municipalite_Zone_Record {
		
			get {

				if (this.col_MunicipaliteID_Record == null) {
				
					this.col_MunicipaliteID_Record = new Municipalite_Zone_Record(this.connectionString, System.Data.SqlTypes.SqlString.Null, this.col_MunicipaliteID);
				}
				
				return(this.col_MunicipaliteID_Record);
			}
		}

		internal bool col_Superficie_totalWasSet = false;
		private bool col_Superficie_totalWasUpdated = false;
		internal System.Data.SqlTypes.SqlSingle col_Superficie_total = System.Data.SqlTypes.SqlSingle.Null;
		public System.Data.SqlTypes.SqlSingle Col_Superficie_total {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Superficie_total);
			}
			set {
			
				this.col_Superficie_totalWasUpdated = true;
				this.col_Superficie_totalWasSet = true;
				this.col_Superficie_total = value;
			}
		}

		internal bool col_Superficie_boiseeWasSet = false;
		private bool col_Superficie_boiseeWasUpdated = false;
		internal System.Data.SqlTypes.SqlSingle col_Superficie_boisee = System.Data.SqlTypes.SqlSingle.Null;
		public System.Data.SqlTypes.SqlSingle Col_Superficie_boisee {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Superficie_boisee);
			}
			set {
			
				this.col_Superficie_boiseeWasUpdated = true;
				this.col_Superficie_boiseeWasSet = true;
				this.col_Superficie_boisee = value;
			}
		}

		internal bool col_ProprietaireIDWasSet = false;
		private bool col_ProprietaireIDWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_ProprietaireID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_ProprietaireID {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_ProprietaireID);
			}
			set {
			
				this.col_ProprietaireIDWasUpdated = true;
				this.col_ProprietaireIDWasSet = true;
				this.col_ProprietaireID_Record = null;
				this.col_ProprietaireID = value;
			}
		}

		
		private Fournisseur_Record col_ProprietaireID_Record = null;
		public Fournisseur_Record Col_ProprietaireID_Fournisseur_Record {
		
			get {

				if (this.col_ProprietaireID_Record == null) {
				
					this.col_ProprietaireID_Record = new Fournisseur_Record(this.connectionString, this.col_ProprietaireID);
				}
				
				return(this.col_ProprietaireID_Record);
			}
		}

		internal bool col_ContingentIDWasSet = false;
		private bool col_ContingentIDWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_ContingentID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_ContingentID {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_ContingentID);
			}
			set {
			
				this.col_ContingentIDWasUpdated = true;
				this.col_ContingentIDWasSet = true;
				this.col_ContingentID_Record = null;
				this.col_ContingentID = value;
			}
		}

		
		private Fournisseur_Record col_ContingentID_Record = null;
		public Fournisseur_Record Col_ContingentID_Fournisseur_Record {
		
			get {

				if (this.col_ContingentID_Record == null) {
				
					this.col_ContingentID_Record = new Fournisseur_Record(this.connectionString, this.col_ContingentID);
				}
				
				return(this.col_ContingentID_Record);
			}
		}

		internal bool col_Contingent_DateWasSet = false;
		private bool col_Contingent_DateWasUpdated = false;
		internal System.Data.SqlTypes.SqlDateTime col_Contingent_Date = System.Data.SqlTypes.SqlDateTime.Null;
		public System.Data.SqlTypes.SqlDateTime Col_Contingent_Date {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Contingent_Date);
			}
			set {
			
				this.col_Contingent_DateWasUpdated = true;
				this.col_Contingent_DateWasSet = true;
				this.col_Contingent_Date = value;
			}
		}

		internal bool col_Droit_coupeIDWasSet = false;
		private bool col_Droit_coupeIDWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_Droit_coupeID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_Droit_coupeID {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Droit_coupeID);
			}
			set {
			
				this.col_Droit_coupeIDWasUpdated = true;
				this.col_Droit_coupeIDWasSet = true;
				this.col_Droit_coupeID_Record = null;
				this.col_Droit_coupeID = value;
			}
		}

		
		private Fournisseur_Record col_Droit_coupeID_Record = null;
		public Fournisseur_Record Col_Droit_coupeID_Fournisseur_Record {
		
			get {

				if (this.col_Droit_coupeID_Record == null) {
				
					this.col_Droit_coupeID_Record = new Fournisseur_Record(this.connectionString, this.col_Droit_coupeID);
				}
				
				return(this.col_Droit_coupeID_Record);
			}
		}

		internal bool col_Droit_coupe_DateWasSet = false;
		private bool col_Droit_coupe_DateWasUpdated = false;
		internal System.Data.SqlTypes.SqlDateTime col_Droit_coupe_Date = System.Data.SqlTypes.SqlDateTime.Null;
		public System.Data.SqlTypes.SqlDateTime Col_Droit_coupe_Date {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Droit_coupe_Date);
			}
			set {
			
				this.col_Droit_coupe_DateWasUpdated = true;
				this.col_Droit_coupe_DateWasSet = true;
				this.col_Droit_coupe_Date = value;
			}
		}

		internal bool col_Entente_paiementIDWasSet = false;
		private bool col_Entente_paiementIDWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_Entente_paiementID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_Entente_paiementID {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Entente_paiementID);
			}
			set {
			
				this.col_Entente_paiementIDWasUpdated = true;
				this.col_Entente_paiementIDWasSet = true;
				this.col_Entente_paiementID_Record = null;
				this.col_Entente_paiementID = value;
			}
		}

		
		private Fournisseur_Record col_Entente_paiementID_Record = null;
		public Fournisseur_Record Col_Entente_paiementID_Fournisseur_Record {
		
			get {

				if (this.col_Entente_paiementID_Record == null) {
				
					this.col_Entente_paiementID_Record = new Fournisseur_Record(this.connectionString, this.col_Entente_paiementID);
				}
				
				return(this.col_Entente_paiementID_Record);
			}
		}

		internal bool col_Entente_paiement_DateWasSet = false;
		private bool col_Entente_paiement_DateWasUpdated = false;
		internal System.Data.SqlTypes.SqlDateTime col_Entente_paiement_Date = System.Data.SqlTypes.SqlDateTime.Null;
		public System.Data.SqlTypes.SqlDateTime Col_Entente_paiement_Date {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Entente_paiement_Date);
			}
			set {
			
				this.col_Entente_paiement_DateWasUpdated = true;
				this.col_Entente_paiement_DateWasSet = true;
				this.col_Entente_paiement_Date = value;
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

		internal bool col_SequenceWasSet = false;
		private bool col_SequenceWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_Sequence = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_Sequence {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Sequence);
			}
			set {
			
				this.col_SequenceWasUpdated = true;
				this.col_SequenceWasSet = true;
				this.col_Sequence = value;
			}
		}

		internal bool col_PartieWasSet = false;
		private bool col_PartieWasUpdated = false;
		internal System.Data.SqlTypes.SqlBoolean col_Partie = System.Data.SqlTypes.SqlBoolean.Null;
		public System.Data.SqlTypes.SqlBoolean Col_Partie {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Partie);
			}
			set {
			
				this.col_PartieWasUpdated = true;
				this.col_PartieWasSet = true;
				this.col_Partie = value;
			}
		}

		internal bool col_MatriculeWasSet = false;
		private bool col_MatriculeWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_Matricule = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_Matricule {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Matricule);
			}
			set {
			
				this.col_MatriculeWasUpdated = true;
				this.col_MatriculeWasSet = true;
				this.col_Matricule = value;
			}
		}

		internal bool col_ZoneIDWasSet = false;
		private bool col_ZoneIDWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_ZoneID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_ZoneID {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_ZoneID);
			}
			set {
			
				this.col_ZoneIDWasUpdated = true;
				this.col_ZoneIDWasSet = true;
				this.col_ZoneID_Record = null;
				this.col_ZoneID = value;
			}
		}

		
		private Municipalite_Zone_Record col_ZoneID_Record = null;
		public Municipalite_Zone_Record Col_ZoneID_Municipalite_Zone_Record {
		
			get {

				if (this.col_ZoneID_Record == null) {
				
					this.col_ZoneID_Record = new Municipalite_Zone_Record(this.connectionString, this.col_ZoneID, System.Data.SqlTypes.SqlString.Null);
				}
				
				return(this.col_ZoneID_Record);
			}
		}

		internal bool col_SecteurWasSet = false;
		private bool col_SecteurWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_Secteur = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_Secteur {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Secteur);
			}
			set {
			
				this.col_SecteurWasUpdated = true;
				this.col_SecteurWasSet = true;
				this.col_Secteur = value;
			}
		}

		internal bool col_CadastreWasSet = false;
		private bool col_CadastreWasUpdated = false;
		internal System.Data.SqlTypes.SqlInt32 col_Cadastre = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_Cadastre {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Cadastre);
			}
			set {
			
				this.col_CadastreWasUpdated = true;
				this.col_CadastreWasSet = true;
				this.col_Cadastre = value;
			}
		}

		internal bool col_ReformeWasSet = false;
		private bool col_ReformeWasUpdated = false;
		internal System.Data.SqlTypes.SqlBoolean col_Reforme = System.Data.SqlTypes.SqlBoolean.Null;
		public System.Data.SqlTypes.SqlBoolean Col_Reforme {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Reforme);
			}
			set {
			
				this.col_ReformeWasUpdated = true;
				this.col_ReformeWasSet = true;
				this.col_Reforme = value;
			}
		}

		internal bool col_LotsComplementairesWasSet = false;
		private bool col_LotsComplementairesWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_LotsComplementaires = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_LotsComplementaires {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_LotsComplementaires);
			}
			set {
			
				this.col_LotsComplementairesWasUpdated = true;
				this.col_LotsComplementairesWasSet = true;
				this.col_LotsComplementaires = value;
			}
		}

		internal bool col_CertifieWasSet = false;
		private bool col_CertifieWasUpdated = false;
		internal System.Data.SqlTypes.SqlBoolean col_Certifie = System.Data.SqlTypes.SqlBoolean.Null;
		public System.Data.SqlTypes.SqlBoolean Col_Certifie {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Certifie);
			}
			set {
			
				this.col_CertifieWasUpdated = true;
				this.col_CertifieWasSet = true;
				this.col_Certifie = value;
			}
		}

		internal bool col_NumeroCertificationWasSet = false;
		private bool col_NumeroCertificationWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_NumeroCertification = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_NumeroCertification {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_NumeroCertification);
			}
			set {
			
				this.col_NumeroCertificationWasUpdated = true;
				this.col_NumeroCertificationWasSet = true;
				this.col_NumeroCertification = value;
			}
		}

		internal bool col_OGCWasSet = false;
		private bool col_OGCWasUpdated = false;
		internal System.Data.SqlTypes.SqlBoolean col_OGC = System.Data.SqlTypes.SqlBoolean.Null;
		public System.Data.SqlTypes.SqlBoolean Col_OGC {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_OGC);
			}
			set {
			
				this.col_OGCWasUpdated = true;
				this.col_OGCWasSet = true;
				this.col_OGC = value;
			}
		}


		public bool Refresh() {

			this.displayName = null;
			this.col_CantonIDWasUpdated = false;
			this.col_CantonIDWasSet = false;
			this.col_CantonID = System.Data.SqlTypes.SqlString.Null;

			this.col_RangWasUpdated = false;
			this.col_RangWasSet = false;
			this.col_Rang = System.Data.SqlTypes.SqlString.Null;

			this.col_LotWasUpdated = false;
			this.col_LotWasSet = false;
			this.col_Lot = System.Data.SqlTypes.SqlString.Null;

			this.col_MunicipaliteIDWasUpdated = false;
			this.col_MunicipaliteIDWasSet = false;
			this.col_MunicipaliteID = System.Data.SqlTypes.SqlString.Null;

			this.col_Superficie_totalWasUpdated = false;
			this.col_Superficie_totalWasSet = false;
			this.col_Superficie_total = System.Data.SqlTypes.SqlSingle.Null;

			this.col_Superficie_boiseeWasUpdated = false;
			this.col_Superficie_boiseeWasSet = false;
			this.col_Superficie_boisee = System.Data.SqlTypes.SqlSingle.Null;

			this.col_ProprietaireIDWasUpdated = false;
			this.col_ProprietaireIDWasSet = false;
			this.col_ProprietaireID = System.Data.SqlTypes.SqlString.Null;

			this.col_ContingentIDWasUpdated = false;
			this.col_ContingentIDWasSet = false;
			this.col_ContingentID = System.Data.SqlTypes.SqlString.Null;

			this.col_Contingent_DateWasUpdated = false;
			this.col_Contingent_DateWasSet = false;
			this.col_Contingent_Date = System.Data.SqlTypes.SqlDateTime.Null;

			this.col_Droit_coupeIDWasUpdated = false;
			this.col_Droit_coupeIDWasSet = false;
			this.col_Droit_coupeID = System.Data.SqlTypes.SqlString.Null;

			this.col_Droit_coupe_DateWasUpdated = false;
			this.col_Droit_coupe_DateWasSet = false;
			this.col_Droit_coupe_Date = System.Data.SqlTypes.SqlDateTime.Null;

			this.col_Entente_paiementIDWasUpdated = false;
			this.col_Entente_paiementIDWasSet = false;
			this.col_Entente_paiementID = System.Data.SqlTypes.SqlString.Null;

			this.col_Entente_paiement_DateWasUpdated = false;
			this.col_Entente_paiement_DateWasSet = false;
			this.col_Entente_paiement_Date = System.Data.SqlTypes.SqlDateTime.Null;

			this.col_ActifWasUpdated = false;
			this.col_ActifWasSet = false;
			this.col_Actif = System.Data.SqlTypes.SqlBoolean.Null;


			this.col_SequenceWasUpdated = false;
			this.col_SequenceWasSet = false;
			this.col_Sequence = System.Data.SqlTypes.SqlString.Null;

			this.col_PartieWasUpdated = false;
			this.col_PartieWasSet = false;
			this.col_Partie = System.Data.SqlTypes.SqlBoolean.Null;

			this.col_MatriculeWasUpdated = false;
			this.col_MatriculeWasSet = false;
			this.col_Matricule = System.Data.SqlTypes.SqlString.Null;

			this.col_ZoneIDWasUpdated = false;
			this.col_ZoneIDWasSet = false;
			this.col_ZoneID = System.Data.SqlTypes.SqlString.Null;

			this.col_SecteurWasUpdated = false;
			this.col_SecteurWasSet = false;
			this.col_Secteur = System.Data.SqlTypes.SqlString.Null;

			this.col_CadastreWasUpdated = false;
			this.col_CadastreWasSet = false;
			this.col_Cadastre = System.Data.SqlTypes.SqlInt32.Null;

			this.col_ReformeWasUpdated = false;
			this.col_ReformeWasSet = false;
			this.col_Reforme = System.Data.SqlTypes.SqlBoolean.Null;

			this.col_LotsComplementairesWasUpdated = false;
			this.col_LotsComplementairesWasSet = false;
			this.col_LotsComplementaires = System.Data.SqlTypes.SqlString.Null;

			this.col_CertifieWasUpdated = false;
			this.col_CertifieWasSet = false;
			this.col_Certifie = System.Data.SqlTypes.SqlBoolean.Null;

			this.col_NumeroCertificationWasUpdated = false;
			this.col_NumeroCertificationWasSet = false;
			this.col_NumeroCertification = System.Data.SqlTypes.SqlString.Null;

			this.col_OGCWasUpdated = false;
			this.col_OGCWasSet = false;
			this.col_OGC = System.Data.SqlTypes.SqlBoolean.Null;

			Params.spS_Lot Param = new Params.spS_Lot(true);
			Param.SetUpConnection(this.connectionString);

			if (!this.col_ID.IsNull) {

				Param.Param_ID = this.col_ID;
			}


			System.Data.SqlClient.SqlDataReader sqlDataReader = null;
			SPs.spS_Lot Sp = new SPs.spS_Lot();
			if (Sp.Execute(ref Param, out sqlDataReader)) {

				if (sqlDataReader.Read()) {

					if (!sqlDataReader.IsDBNull(SPs.spS_Lot.Resultset1.Fields.Column_CantonID.ColumnIndex)) {

						this.col_CantonID = sqlDataReader.GetSqlString(SPs.spS_Lot.Resultset1.Fields.Column_CantonID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Lot.Resultset1.Fields.Column_Rang.ColumnIndex)) {

						this.col_Rang = sqlDataReader.GetSqlString(SPs.spS_Lot.Resultset1.Fields.Column_Rang.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Lot.Resultset1.Fields.Column_Lot.ColumnIndex)) {

						this.col_Lot = sqlDataReader.GetSqlString(SPs.spS_Lot.Resultset1.Fields.Column_Lot.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Lot.Resultset1.Fields.Column_MunicipaliteID.ColumnIndex)) {

						this.col_MunicipaliteID = sqlDataReader.GetSqlString(SPs.spS_Lot.Resultset1.Fields.Column_MunicipaliteID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Lot.Resultset1.Fields.Column_Superficie_total.ColumnIndex)) {

						this.col_Superficie_total = sqlDataReader.GetSqlSingle(SPs.spS_Lot.Resultset1.Fields.Column_Superficie_total.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Lot.Resultset1.Fields.Column_Superficie_boisee.ColumnIndex)) {

						this.col_Superficie_boisee = sqlDataReader.GetSqlSingle(SPs.spS_Lot.Resultset1.Fields.Column_Superficie_boisee.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Lot.Resultset1.Fields.Column_ProprietaireID.ColumnIndex)) {

						this.col_ProprietaireID = sqlDataReader.GetSqlString(SPs.spS_Lot.Resultset1.Fields.Column_ProprietaireID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Lot.Resultset1.Fields.Column_ContingentID.ColumnIndex)) {

						this.col_ContingentID = sqlDataReader.GetSqlString(SPs.spS_Lot.Resultset1.Fields.Column_ContingentID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Lot.Resultset1.Fields.Column_Contingent_Date.ColumnIndex)) {

						this.col_Contingent_Date = sqlDataReader.GetSqlDateTime(SPs.spS_Lot.Resultset1.Fields.Column_Contingent_Date.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Lot.Resultset1.Fields.Column_Droit_coupeID.ColumnIndex)) {

						this.col_Droit_coupeID = sqlDataReader.GetSqlString(SPs.spS_Lot.Resultset1.Fields.Column_Droit_coupeID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Lot.Resultset1.Fields.Column_Droit_coupe_Date.ColumnIndex)) {

						this.col_Droit_coupe_Date = sqlDataReader.GetSqlDateTime(SPs.spS_Lot.Resultset1.Fields.Column_Droit_coupe_Date.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Lot.Resultset1.Fields.Column_Entente_paiementID.ColumnIndex)) {

						this.col_Entente_paiementID = sqlDataReader.GetSqlString(SPs.spS_Lot.Resultset1.Fields.Column_Entente_paiementID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Lot.Resultset1.Fields.Column_Entente_paiement_Date.ColumnIndex)) {

						this.col_Entente_paiement_Date = sqlDataReader.GetSqlDateTime(SPs.spS_Lot.Resultset1.Fields.Column_Entente_paiement_Date.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Lot.Resultset1.Fields.Column_Actif.ColumnIndex)) {

						this.col_Actif = sqlDataReader.GetSqlBoolean(SPs.spS_Lot.Resultset1.Fields.Column_Actif.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Lot.Resultset1.Fields.Column_Sequence.ColumnIndex)) {

						this.col_Sequence = sqlDataReader.GetSqlString(SPs.spS_Lot.Resultset1.Fields.Column_Sequence.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Lot.Resultset1.Fields.Column_Partie.ColumnIndex)) {

						this.col_Partie = sqlDataReader.GetSqlBoolean(SPs.spS_Lot.Resultset1.Fields.Column_Partie.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Lot.Resultset1.Fields.Column_Matricule.ColumnIndex)) {

						this.col_Matricule = sqlDataReader.GetSqlString(SPs.spS_Lot.Resultset1.Fields.Column_Matricule.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Lot.Resultset1.Fields.Column_ZoneID.ColumnIndex)) {

						this.col_ZoneID = sqlDataReader.GetSqlString(SPs.spS_Lot.Resultset1.Fields.Column_ZoneID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Lot.Resultset1.Fields.Column_Secteur.ColumnIndex)) {

						this.col_Secteur = sqlDataReader.GetSqlString(SPs.spS_Lot.Resultset1.Fields.Column_Secteur.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Lot.Resultset1.Fields.Column_Cadastre.ColumnIndex)) {

						this.col_Cadastre = sqlDataReader.GetSqlInt32(SPs.spS_Lot.Resultset1.Fields.Column_Cadastre.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Lot.Resultset1.Fields.Column_Reforme.ColumnIndex)) {

						this.col_Reforme = sqlDataReader.GetSqlBoolean(SPs.spS_Lot.Resultset1.Fields.Column_Reforme.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Lot.Resultset1.Fields.Column_LotsComplementaires.ColumnIndex)) {

						this.col_LotsComplementaires = sqlDataReader.GetSqlString(SPs.spS_Lot.Resultset1.Fields.Column_LotsComplementaires.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Lot.Resultset1.Fields.Column_Certifie.ColumnIndex)) {

						this.col_Certifie = sqlDataReader.GetSqlBoolean(SPs.spS_Lot.Resultset1.Fields.Column_Certifie.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Lot.Resultset1.Fields.Column_NumeroCertification.ColumnIndex)) {

						this.col_NumeroCertification = sqlDataReader.GetSqlString(SPs.spS_Lot.Resultset1.Fields.Column_NumeroCertification.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Lot.Resultset1.Fields.Column_OGC.ColumnIndex)) {

						this.col_OGC = sqlDataReader.GetSqlBoolean(SPs.spS_Lot.Resultset1.Fields.Column_OGC.ColumnIndex);
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

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Lot_Record", "Refresh");
			}
		}

		public void Update() {

			if (!this.recordWasLoadedFromDB) {

				throw new ArgumentException("No record was loaded from the database. No update is possible.");
			}

			bool ChangesHaveBeenMade = false;

			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_CantonIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_RangWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_LotWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_MunicipaliteIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Superficie_totalWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Superficie_boiseeWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_ProprietaireIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_ContingentIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Contingent_DateWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Droit_coupeIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Droit_coupe_DateWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Entente_paiementIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Entente_paiement_DateWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_ActifWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_SequenceWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_PartieWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_MatriculeWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_ZoneIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_SecteurWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_CadastreWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_ReformeWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_LotsComplementairesWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_CertifieWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_NumeroCertificationWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_OGCWasUpdated);

			if (!ChangesHaveBeenMade) {

				return;
			}

			Params.spU_Lot Param = new Params.spU_Lot(false);
			Param.SetUpConnection(this.connectionString);
			Param.Param_ID = this.col_ID;

			if (this.col_CantonIDWasUpdated) {

				Param.Param_CantonID = this.col_CantonID;
				Param.Param_ConsiderNull_CantonID = true;
			}

			if (this.col_RangWasUpdated) {

				Param.Param_Rang = this.col_Rang;
				Param.Param_ConsiderNull_Rang = true;
			}

			if (this.col_LotWasUpdated) {

				Param.Param_Lot = this.col_Lot;
				Param.Param_ConsiderNull_Lot = true;
			}

			if (this.col_MunicipaliteIDWasUpdated) {

				Param.Param_MunicipaliteID = this.col_MunicipaliteID;
				Param.Param_ConsiderNull_MunicipaliteID = true;
			}

			if (this.col_Superficie_totalWasUpdated) {

				Param.Param_Superficie_total = this.col_Superficie_total;
				Param.Param_ConsiderNull_Superficie_total = true;
			}

			if (this.col_Superficie_boiseeWasUpdated) {

				Param.Param_Superficie_boisee = this.col_Superficie_boisee;
				Param.Param_ConsiderNull_Superficie_boisee = true;
			}

			if (this.col_ProprietaireIDWasUpdated) {

				Param.Param_ProprietaireID = this.col_ProprietaireID;
				Param.Param_ConsiderNull_ProprietaireID = true;
			}

			if (this.col_ContingentIDWasUpdated) {

				Param.Param_ContingentID = this.col_ContingentID;
				Param.Param_ConsiderNull_ContingentID = true;
			}

			if (this.col_Contingent_DateWasUpdated) {

				Param.Param_Contingent_Date = this.col_Contingent_Date;
				Param.Param_ConsiderNull_Contingent_Date = true;
			}

			if (this.col_Droit_coupeIDWasUpdated) {

				Param.Param_Droit_coupeID = this.col_Droit_coupeID;
				Param.Param_ConsiderNull_Droit_coupeID = true;
			}

			if (this.col_Droit_coupe_DateWasUpdated) {

				Param.Param_Droit_coupe_Date = this.col_Droit_coupe_Date;
				Param.Param_ConsiderNull_Droit_coupe_Date = true;
			}

			if (this.col_Entente_paiementIDWasUpdated) {

				Param.Param_Entente_paiementID = this.col_Entente_paiementID;
				Param.Param_ConsiderNull_Entente_paiementID = true;
			}

			if (this.col_Entente_paiement_DateWasUpdated) {

				Param.Param_Entente_paiement_Date = this.col_Entente_paiement_Date;
				Param.Param_ConsiderNull_Entente_paiement_Date = true;
			}

			if (this.col_ActifWasUpdated) {

				Param.Param_Actif = this.col_Actif;
				Param.Param_ConsiderNull_Actif = true;
			}

			if (this.col_SequenceWasUpdated) {

				Param.Param_Sequence = this.col_Sequence;
				Param.Param_ConsiderNull_Sequence = true;
			}

			if (this.col_PartieWasUpdated) {

				Param.Param_Partie = this.col_Partie;
				Param.Param_ConsiderNull_Partie = true;
			}

			if (this.col_MatriculeWasUpdated) {

				Param.Param_Matricule = this.col_Matricule;
				Param.Param_ConsiderNull_Matricule = true;
			}

			if (this.col_ZoneIDWasUpdated) {

				Param.Param_ZoneID = this.col_ZoneID;
				Param.Param_ConsiderNull_ZoneID = true;
			}

			if (this.col_SecteurWasUpdated) {

				Param.Param_Secteur = this.col_Secteur;
				Param.Param_ConsiderNull_Secteur = true;
			}

			if (this.col_CadastreWasUpdated) {

				Param.Param_Cadastre = this.col_Cadastre;
				Param.Param_ConsiderNull_Cadastre = true;
			}

			if (this.col_ReformeWasUpdated) {

				Param.Param_Reforme = this.col_Reforme;
				Param.Param_ConsiderNull_Reforme = true;
			}

			if (this.col_LotsComplementairesWasUpdated) {

				Param.Param_LotsComplementaires = this.col_LotsComplementaires;
				Param.Param_ConsiderNull_LotsComplementaires = true;
			}

			if (this.col_CertifieWasUpdated) {

				Param.Param_Certifie = this.col_Certifie;
				Param.Param_ConsiderNull_Certifie = true;
			}

			if (this.col_NumeroCertificationWasUpdated) {

				Param.Param_NumeroCertification = this.col_NumeroCertification;
				Param.Param_ConsiderNull_NumeroCertification = true;
			}

			if (this.col_OGCWasUpdated) {

				Param.Param_OGC = this.col_OGC;
				Param.Param_ConsiderNull_OGC = true;
			}

			SPs.spU_Lot Sp = new SPs.spU_Lot();
			if (Sp.Execute(ref Param)) {

				this.col_CantonIDWasUpdated = false;
				this.col_RangWasUpdated = false;
				this.col_LotWasUpdated = false;
				this.col_MunicipaliteIDWasUpdated = false;
				this.col_Superficie_totalWasUpdated = false;
				this.col_Superficie_boiseeWasUpdated = false;
				this.col_ProprietaireIDWasUpdated = false;
				this.col_ContingentIDWasUpdated = false;
				this.col_Contingent_DateWasUpdated = false;
				this.col_Droit_coupeIDWasUpdated = false;
				this.col_Droit_coupe_DateWasUpdated = false;
				this.col_Entente_paiementIDWasUpdated = false;
				this.col_Entente_paiement_DateWasUpdated = false;
				this.col_ActifWasUpdated = false;
				this.col_SequenceWasUpdated = false;
				this.col_PartieWasUpdated = false;
				this.col_MatriculeWasUpdated = false;
				this.col_ZoneIDWasUpdated = false;
				this.col_SecteurWasUpdated = false;
				this.col_CadastreWasUpdated = false;
				this.col_ReformeWasUpdated = false;
				this.col_LotsComplementairesWasUpdated = false;
				this.col_CertifieWasUpdated = false;
				this.col_NumeroCertificationWasUpdated = false;
				this.col_OGCWasUpdated = false;
			}
			else {

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Lot_Record", "Update");
			}		
		}

		private GestionVolume_Collection internal_GestionVolume_Col_LotID_Collection = null;
		public GestionVolume_Collection GestionVolume_Col_LotID_Collection {

			get {

				if (this.internal_GestionVolume_Col_LotID_Collection == null) {

					this.internal_GestionVolume_Col_LotID_Collection = new GestionVolume_Collection(this.connectionString);
					this.internal_GestionVolume_Col_LotID_Collection.LoadFrom_LotID(this.col_ID, this);
				}

				return(this.internal_GestionVolume_Col_LotID_Collection);
			}
		}

		private Livraison_Collection internal_Livraison_Col_LotID_Collection = null;
		public Livraison_Collection Livraison_Col_LotID_Collection {

			get {

				if (this.internal_Livraison_Col_LotID_Collection == null) {

					this.internal_Livraison_Col_LotID_Collection = new Livraison_Collection(this.connectionString);
					this.internal_Livraison_Col_LotID_Collection.LoadFrom_LotID(this.col_ID, this);
				}

				return(this.internal_Livraison_Col_LotID_Collection);
			}
		}

		private Lot_Proprietaire_Collection internal_Lot_Proprietaire_Col_LotID_Collection = null;
		public Lot_Proprietaire_Collection Lot_Proprietaire_Col_LotID_Collection {

			get {

				if (this.internal_Lot_Proprietaire_Col_LotID_Collection == null) {

					this.internal_Lot_Proprietaire_Col_LotID_Collection = new Lot_Proprietaire_Collection(this.connectionString);
					this.internal_Lot_Proprietaire_Col_LotID_Collection.LoadFrom_LotID(this.col_ID, this);
				}

				return(this.internal_Lot_Proprietaire_Col_LotID_Collection);
			}
		}

		private Lot_SuperficieBoisee_Collection internal_Lot_SuperficieBoisee_Col_LotID_Collection = null;
		public Lot_SuperficieBoisee_Collection Lot_SuperficieBoisee_Col_LotID_Collection {

			get {

				if (this.internal_Lot_SuperficieBoisee_Col_LotID_Collection == null) {

					this.internal_Lot_SuperficieBoisee_Col_LotID_Collection = new Lot_SuperficieBoisee_Collection(this.connectionString);
					this.internal_Lot_SuperficieBoisee_Col_LotID_Collection.LoadFrom_LotID(this.col_ID, this);
				}

				return(this.internal_Lot_SuperficieBoisee_Col_LotID_Collection);
			}
		}

		private LotContingente_Collection internal_LotContingente_Col_LotID_Collection = null;
		public LotContingente_Collection LotContingente_Col_LotID_Collection {

			get {

				if (this.internal_LotContingente_Col_LotID_Collection == null) {

					this.internal_LotContingente_Col_LotID_Collection = new LotContingente_Collection(this.connectionString);
					this.internal_LotContingente_Col_LotID_Collection.LoadFrom_LotID(this.col_ID, this);
				}

				return(this.internal_LotContingente_Col_LotID_Collection);
			}
		}

		private Permit_Collection internal_Permit_Col_LotID_Collection = null;
		public Permit_Collection Permit_Col_LotID_Collection {

			get {

				if (this.internal_Permit_Col_LotID_Collection == null) {

					this.internal_Permit_Col_LotID_Collection = new Permit_Collection(this.connectionString);
					this.internal_Permit_Col_LotID_Collection.LoadFrom_LotID(this.col_ID, this);
				}

				return(this.internal_Permit_Col_LotID_Collection);
			}
		}

		internal string displayName = null;
		public override string ToString() {

			if (!this.recordWasLoadedFromDB) {

				throw new ArgumentException("No record was loaded from the database. The DisplayName is not available.");
			}
		
			if (this.displayName == null) {
			
				Params.spS_Lot_Display Param = new Params.spS_Lot_Display();
				Param.SetUpConnection(this.connectionString);

				Param.Param_ID = this.col_ID;

				System.Data.SqlClient.SqlDataReader sqlDataReader = null;
				SPs.spS_Lot_Display Sp = new SPs.spS_Lot_Display();
				if (Sp.Execute(ref Param, out sqlDataReader)) {

					if (sqlDataReader.Read()) {

						if (!sqlDataReader.IsDBNull(SPs.spS_Lot_Display.Resultset1.Fields.Column_Display.ColumnIndex)) {

							this.displayName = "spS_Lot_Display";
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

					throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Lot_Record", "ToString");
				}				
			}
			
			return(this.displayName);
		}
	}
}
