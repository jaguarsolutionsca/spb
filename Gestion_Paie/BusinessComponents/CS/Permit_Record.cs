using System;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.BusinessComponents {

	/// <summary>
	/// This class is an abstract class that represents the [Permit] table. With this class
	/// you can load or update a record from the database. If you need to add or delete a record,
	/// you must use the <see cref="Gestion_Paie.BusinessComponents.Permit_Collection"/> class to do so.
	/// </summary>
	public sealed class Permit_Record : IBusinessComponentRecord {
	
		internal bool recordWasLoadedFromDB = false;
		private bool recordIsLoaded = false;

		internal string connectionString = String.Empty;
		public string ConnectionString {
		
			get {
			
				return(this.connectionString);
			}
		}
		
		/// <summary>
		/// Initializes a new instance of the Permit_Record class. Use this contructor to add
		/// a new record. Then call the Add method of the Gestion_Paie.BusinessComponents.Permit_Collection class to actually
		/// add the record in the database.
		/// </summary>
		public Permit_Record() {
		
			this.recordWasLoadedFromDB = false;
			this.recordIsLoaded = false;
		}
	
		/// <param name="col_ID">[To be supplied.]</param>
		public Permit_Record(string connectionString, System.Data.SqlTypes.SqlInt32 col_ID) {

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
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Permit'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}", "Permit", CurrentRevision, OriginalRevision));
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
		
		internal bool col_DatePermitWasSet = false;
		private bool col_DatePermitWasUpdated = false;
		internal System.Data.SqlTypes.SqlDateTime col_DatePermit = System.Data.SqlTypes.SqlDateTime.Null;
		public System.Data.SqlTypes.SqlDateTime Col_DatePermit {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_DatePermit);
			}
			set {
			
				this.col_DatePermitWasUpdated = true;
				this.col_DatePermitWasSet = true;
				this.col_DatePermit = value;
			}
		}

		internal bool col_DateDebutWasSet = false;
		private bool col_DateDebutWasUpdated = false;
		internal System.Data.SqlTypes.SqlDateTime col_DateDebut = System.Data.SqlTypes.SqlDateTime.Null;
		public System.Data.SqlTypes.SqlDateTime Col_DateDebut {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_DateDebut);
			}
			set {
			
				this.col_DateDebutWasUpdated = true;
				this.col_DateDebutWasSet = true;
				this.col_DateDebut = value;
			}
		}

		internal bool col_DateFinWasSet = false;
		private bool col_DateFinWasUpdated = false;
		internal System.Data.SqlTypes.SqlDateTime col_DateFin = System.Data.SqlTypes.SqlDateTime.Null;
		public System.Data.SqlTypes.SqlDateTime Col_DateFin {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_DateFin);
			}
			set {
			
				this.col_DateFinWasUpdated = true;
				this.col_DateFinWasSet = true;
				this.col_DateFin = value;
			}
		}

		internal bool col_AnneeWasSet = false;
		private bool col_AnneeWasUpdated = false;
		internal System.Data.SqlTypes.SqlInt32 col_Annee = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_Annee {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Annee);
			}
			set {
			
				this.col_AnneeWasUpdated = true;
				this.col_AnneeWasSet = true;
				this.col_Annee = value;
			}
		}

		internal bool col_PeriodeWasSet = false;
		private bool col_PeriodeWasUpdated = false;
		internal System.Data.SqlTypes.SqlInt32 col_Periode = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_Periode {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Periode);
			}
			set {
			
				this.col_PeriodeWasUpdated = true;
				this.col_PeriodeWasSet = true;
				this.col_Periode = value;
			}
		}

		internal bool col_ContratIDWasSet = false;
		private bool col_ContratIDWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_ContratID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_ContratID {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_ContratID);
			}
			set {
			
				this.col_ContratIDWasUpdated = true;
				this.col_ContratIDWasSet = true;
				this.col_ContratID_Record = null;
				this.col_ContratID = value;
			}
		}

		
		private Contrat_Record col_ContratID_Record = null;
		public Contrat_Record Col_ContratID_Contrat_Record {
		
			get {

				if (this.col_ContratID_Record == null) {
				
					this.col_ContratID_Record = new Contrat_Record(this.connectionString, this.col_ContratID);
				}
				
				return(this.col_ContratID_Record);
			}
		}

		internal bool col_EssenceIDWasSet = false;
		private bool col_EssenceIDWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_EssenceID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_EssenceID {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_EssenceID);
			}
			set {
			
				this.col_EssenceIDWasUpdated = true;
				this.col_EssenceIDWasSet = true;
				this.col_EssenceID_Record = null;
				this.col_EssenceID = value;
			}
		}

		
		private Essence_Record col_EssenceID_Record = null;
		public Essence_Record Col_EssenceID_Essence_Record {
		
			get {

				if (this.col_EssenceID_Record == null) {
				
					this.col_EssenceID_Record = new Essence_Record(this.connectionString, this.col_EssenceID);
				}
				
				return(this.col_EssenceID_Record);
			}
		}

		internal bool col_PermitSciageWasSet = false;
		private bool col_PermitSciageWasUpdated = false;
		internal System.Data.SqlTypes.SqlBoolean col_PermitSciage = System.Data.SqlTypes.SqlBoolean.Null;
		public System.Data.SqlTypes.SqlBoolean Col_PermitSciage {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_PermitSciage);
			}
			set {
			
				this.col_PermitSciageWasUpdated = true;
				this.col_PermitSciageWasSet = true;
				this.col_PermitSciage = value;
			}
		}

		internal bool col_TransporteurIDWasSet = false;
		private bool col_TransporteurIDWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_TransporteurID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_TransporteurID {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_TransporteurID);
			}
			set {
			
				this.col_TransporteurIDWasUpdated = true;
				this.col_TransporteurIDWasSet = true;
				this.col_TransporteurID_Record = null;
				this.col_TransporteurID = value;
			}
		}

		
		private Fournisseur_Record col_TransporteurID_Record = null;
		public Fournisseur_Record Col_TransporteurID_Fournisseur_Record {
		
			get {

				if (this.col_TransporteurID_Record == null) {
				
					this.col_TransporteurID_Record = new Fournisseur_Record(this.connectionString, this.col_TransporteurID);
				}
				
				return(this.col_TransporteurID_Record);
			}
		}

		internal bool col_VRWasSet = false;
		private bool col_VRWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_VR = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_VR {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_VR);
			}
			set {
			
				this.col_VRWasUpdated = true;
				this.col_VRWasSet = true;
				this.col_VR = value;
			}
		}

		internal bool col_ProducteurDroitCoupeIDWasSet = false;
		private bool col_ProducteurDroitCoupeIDWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_ProducteurDroitCoupeID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_ProducteurDroitCoupeID {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_ProducteurDroitCoupeID);
			}
			set {
			
				this.col_ProducteurDroitCoupeIDWasUpdated = true;
				this.col_ProducteurDroitCoupeIDWasSet = true;
				this.col_ProducteurDroitCoupeID_Record = null;
				this.col_ProducteurDroitCoupeID = value;
			}
		}

		
		private Fournisseur_Record col_ProducteurDroitCoupeID_Record = null;
		public Fournisseur_Record Col_ProducteurDroitCoupeID_Fournisseur_Record {
		
			get {

				if (this.col_ProducteurDroitCoupeID_Record == null) {
				
					this.col_ProducteurDroitCoupeID_Record = new Fournisseur_Record(this.connectionString, this.col_ProducteurDroitCoupeID);
				}
				
				return(this.col_ProducteurDroitCoupeID_Record);
			}
		}

		internal bool col_ProducteurEntentePaiementIDWasSet = false;
		private bool col_ProducteurEntentePaiementIDWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_ProducteurEntentePaiementID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_ProducteurEntentePaiementID {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_ProducteurEntentePaiementID);
			}
			set {
			
				this.col_ProducteurEntentePaiementIDWasUpdated = true;
				this.col_ProducteurEntentePaiementIDWasSet = true;
				this.col_ProducteurEntentePaiementID_Record = null;
				this.col_ProducteurEntentePaiementID = value;
			}
		}

		
		private Fournisseur_Record col_ProducteurEntentePaiementID_Record = null;
		public Fournisseur_Record Col_ProducteurEntentePaiementID_Fournisseur_Record {
		
			get {

				if (this.col_ProducteurEntentePaiementID_Record == null) {
				
					this.col_ProducteurEntentePaiementID_Record = new Fournisseur_Record(this.connectionString, this.col_ProducteurEntentePaiementID);
				}
				
				return(this.col_ProducteurEntentePaiementID_Record);
			}
		}

		internal bool col_PermitLivreWasSet = false;
		private bool col_PermitLivreWasUpdated = false;
		internal System.Data.SqlTypes.SqlBoolean col_PermitLivre = System.Data.SqlTypes.SqlBoolean.Null;
		public System.Data.SqlTypes.SqlBoolean Col_PermitLivre {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_PermitLivre);
			}
			set {
			
				this.col_PermitLivreWasUpdated = true;
				this.col_PermitLivreWasSet = true;
				this.col_PermitLivre = value;
			}
		}

		internal bool col_PermitImprimeWasSet = false;
		private bool col_PermitImprimeWasUpdated = false;
		internal System.Data.SqlTypes.SqlBoolean col_PermitImprime = System.Data.SqlTypes.SqlBoolean.Null;
		public System.Data.SqlTypes.SqlBoolean Col_PermitImprime {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_PermitImprime);
			}
			set {
			
				this.col_PermitImprimeWasUpdated = true;
				this.col_PermitImprimeWasSet = true;
				this.col_PermitImprime = value;
			}
		}

		internal bool col_PermitAnnuleWasSet = false;
		private bool col_PermitAnnuleWasUpdated = false;
		internal System.Data.SqlTypes.SqlBoolean col_PermitAnnule = System.Data.SqlTypes.SqlBoolean.Null;
		public System.Data.SqlTypes.SqlBoolean Col_PermitAnnule {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_PermitAnnule);
			}
			set {
			
				this.col_PermitAnnuleWasUpdated = true;
				this.col_PermitAnnuleWasSet = true;
				this.col_PermitAnnule = value;
			}
		}

		internal bool col_LotIDWasSet = false;
		private bool col_LotIDWasUpdated = false;
		internal System.Data.SqlTypes.SqlInt32 col_LotID = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_LotID {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_LotID);
			}
			set {
			
				this.col_LotIDWasUpdated = true;
				this.col_LotIDWasSet = true;
				this.col_LotID_Record = null;
				this.col_LotID = value;
			}
		}

		
		private Lot_Record col_LotID_Record = null;
		public Lot_Record Col_LotID_Lot_Record {
		
			get {

				if (this.col_LotID_Record == null) {
				
					this.col_LotID_Record = new Lot_Record(this.connectionString, this.col_LotID);
				}
				
				return(this.col_LotID_Record);
			}
		}

		internal bool col_EssenceSciageWasSet = false;
		private bool col_EssenceSciageWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_EssenceSciage = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_EssenceSciage {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_EssenceSciage);
			}
			set {
			
				this.col_EssenceSciageWasUpdated = true;
				this.col_EssenceSciageWasSet = true;
				this.col_EssenceSciage = value;
			}
		}

		internal bool col_CodeWasSet = false;
		private bool col_CodeWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_Code = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_Code {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Code);
			}
			set {
			
				this.col_CodeWasUpdated = true;
				this.col_CodeWasSet = true;
				this.col_Code = value;
			}
		}

		internal bool col_RemarquesWasSet = false;
		private bool col_RemarquesWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_Remarques = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_Remarques {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Remarques);
			}
			set {
			
				this.col_RemarquesWasUpdated = true;
				this.col_RemarquesWasSet = true;
				this.col_Remarques = value;
			}
		}

		internal bool col_ChargeurIDWasSet = false;
		private bool col_ChargeurIDWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_ChargeurID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_ChargeurID {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_ChargeurID);
			}
			set {
			
				this.col_ChargeurIDWasUpdated = true;
				this.col_ChargeurIDWasSet = true;
				this.col_ChargeurID_Record = null;
				this.col_ChargeurID = value;
			}
		}

		
		private Fournisseur_Record col_ChargeurID_Record = null;
		public Fournisseur_Record Col_ChargeurID_Fournisseur_Record {
		
			get {

				if (this.col_ChargeurID_Record == null) {
				
					this.col_ChargeurID_Record = new Fournisseur_Record(this.connectionString, this.col_ChargeurID);
				}
				
				return(this.col_ChargeurID_Record);
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


		public bool Refresh() {

			this.displayName = null;

			this.col_DatePermitWasUpdated = false;
			this.col_DatePermitWasSet = false;
			this.col_DatePermit = System.Data.SqlTypes.SqlDateTime.Null;

			this.col_DateDebutWasUpdated = false;
			this.col_DateDebutWasSet = false;
			this.col_DateDebut = System.Data.SqlTypes.SqlDateTime.Null;

			this.col_DateFinWasUpdated = false;
			this.col_DateFinWasSet = false;
			this.col_DateFin = System.Data.SqlTypes.SqlDateTime.Null;

			this.col_AnneeWasUpdated = false;
			this.col_AnneeWasSet = false;
			this.col_Annee = System.Data.SqlTypes.SqlInt32.Null;

			this.col_PeriodeWasUpdated = false;
			this.col_PeriodeWasSet = false;
			this.col_Periode = System.Data.SqlTypes.SqlInt32.Null;

			this.col_ContratIDWasUpdated = false;
			this.col_ContratIDWasSet = false;
			this.col_ContratID = System.Data.SqlTypes.SqlString.Null;

			this.col_EssenceIDWasUpdated = false;
			this.col_EssenceIDWasSet = false;
			this.col_EssenceID = System.Data.SqlTypes.SqlString.Null;

			this.col_PermitSciageWasUpdated = false;
			this.col_PermitSciageWasSet = false;
			this.col_PermitSciage = System.Data.SqlTypes.SqlBoolean.Null;

			this.col_TransporteurIDWasUpdated = false;
			this.col_TransporteurIDWasSet = false;
			this.col_TransporteurID = System.Data.SqlTypes.SqlString.Null;

			this.col_VRWasUpdated = false;
			this.col_VRWasSet = false;
			this.col_VR = System.Data.SqlTypes.SqlString.Null;

			this.col_ProducteurDroitCoupeIDWasUpdated = false;
			this.col_ProducteurDroitCoupeIDWasSet = false;
			this.col_ProducteurDroitCoupeID = System.Data.SqlTypes.SqlString.Null;

			this.col_ProducteurEntentePaiementIDWasUpdated = false;
			this.col_ProducteurEntentePaiementIDWasSet = false;
			this.col_ProducteurEntentePaiementID = System.Data.SqlTypes.SqlString.Null;

			this.col_PermitLivreWasUpdated = false;
			this.col_PermitLivreWasSet = false;
			this.col_PermitLivre = System.Data.SqlTypes.SqlBoolean.Null;

			this.col_PermitImprimeWasUpdated = false;
			this.col_PermitImprimeWasSet = false;
			this.col_PermitImprime = System.Data.SqlTypes.SqlBoolean.Null;

			this.col_PermitAnnuleWasUpdated = false;
			this.col_PermitAnnuleWasSet = false;
			this.col_PermitAnnule = System.Data.SqlTypes.SqlBoolean.Null;

			this.col_LotIDWasUpdated = false;
			this.col_LotIDWasSet = false;
			this.col_LotID = System.Data.SqlTypes.SqlInt32.Null;

			this.col_EssenceSciageWasUpdated = false;
			this.col_EssenceSciageWasSet = false;
			this.col_EssenceSciage = System.Data.SqlTypes.SqlString.Null;

			this.col_CodeWasUpdated = false;
			this.col_CodeWasSet = false;
			this.col_Code = System.Data.SqlTypes.SqlString.Null;

			this.col_RemarquesWasUpdated = false;
			this.col_RemarquesWasSet = false;
			this.col_Remarques = System.Data.SqlTypes.SqlString.Null;

			this.col_ChargeurIDWasUpdated = false;
			this.col_ChargeurIDWasSet = false;
			this.col_ChargeurID = System.Data.SqlTypes.SqlString.Null;

			this.col_ZoneIDWasUpdated = false;
			this.col_ZoneIDWasSet = false;
			this.col_ZoneID = System.Data.SqlTypes.SqlString.Null;

			this.col_MunicipaliteIDWasUpdated = false;
			this.col_MunicipaliteIDWasSet = false;
			this.col_MunicipaliteID = System.Data.SqlTypes.SqlString.Null;

			Params.spS_Permit Param = new Params.spS_Permit(true);
			Param.SetUpConnection(this.connectionString);

			if (!this.col_ID.IsNull) {

				Param.Param_ID = this.col_ID;
			}


			System.Data.SqlClient.SqlDataReader sqlDataReader = null;
			SPs.spS_Permit Sp = new SPs.spS_Permit();
			if (Sp.Execute(ref Param, out sqlDataReader)) {

				if (sqlDataReader.Read()) {

					if (!sqlDataReader.IsDBNull(SPs.spS_Permit.Resultset1.Fields.Column_DatePermit.ColumnIndex)) {

						this.col_DatePermit = sqlDataReader.GetSqlDateTime(SPs.spS_Permit.Resultset1.Fields.Column_DatePermit.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Permit.Resultset1.Fields.Column_DateDebut.ColumnIndex)) {

						this.col_DateDebut = sqlDataReader.GetSqlDateTime(SPs.spS_Permit.Resultset1.Fields.Column_DateDebut.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Permit.Resultset1.Fields.Column_DateFin.ColumnIndex)) {

						this.col_DateFin = sqlDataReader.GetSqlDateTime(SPs.spS_Permit.Resultset1.Fields.Column_DateFin.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Permit.Resultset1.Fields.Column_Annee.ColumnIndex)) {

						this.col_Annee = sqlDataReader.GetSqlInt32(SPs.spS_Permit.Resultset1.Fields.Column_Annee.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Permit.Resultset1.Fields.Column_Periode.ColumnIndex)) {

						this.col_Periode = sqlDataReader.GetSqlInt32(SPs.spS_Permit.Resultset1.Fields.Column_Periode.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Permit.Resultset1.Fields.Column_ContratID.ColumnIndex)) {

						this.col_ContratID = sqlDataReader.GetSqlString(SPs.spS_Permit.Resultset1.Fields.Column_ContratID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Permit.Resultset1.Fields.Column_EssenceID.ColumnIndex)) {

						this.col_EssenceID = sqlDataReader.GetSqlString(SPs.spS_Permit.Resultset1.Fields.Column_EssenceID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Permit.Resultset1.Fields.Column_PermitSciage.ColumnIndex)) {

						this.col_PermitSciage = sqlDataReader.GetSqlBoolean(SPs.spS_Permit.Resultset1.Fields.Column_PermitSciage.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Permit.Resultset1.Fields.Column_TransporteurID.ColumnIndex)) {

						this.col_TransporteurID = sqlDataReader.GetSqlString(SPs.spS_Permit.Resultset1.Fields.Column_TransporteurID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Permit.Resultset1.Fields.Column_VR.ColumnIndex)) {

						this.col_VR = sqlDataReader.GetSqlString(SPs.spS_Permit.Resultset1.Fields.Column_VR.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Permit.Resultset1.Fields.Column_ProducteurDroitCoupeID.ColumnIndex)) {

						this.col_ProducteurDroitCoupeID = sqlDataReader.GetSqlString(SPs.spS_Permit.Resultset1.Fields.Column_ProducteurDroitCoupeID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Permit.Resultset1.Fields.Column_ProducteurEntentePaiementID.ColumnIndex)) {

						this.col_ProducteurEntentePaiementID = sqlDataReader.GetSqlString(SPs.spS_Permit.Resultset1.Fields.Column_ProducteurEntentePaiementID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Permit.Resultset1.Fields.Column_PermitLivre.ColumnIndex)) {

						this.col_PermitLivre = sqlDataReader.GetSqlBoolean(SPs.spS_Permit.Resultset1.Fields.Column_PermitLivre.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Permit.Resultset1.Fields.Column_PermitImprime.ColumnIndex)) {

						this.col_PermitImprime = sqlDataReader.GetSqlBoolean(SPs.spS_Permit.Resultset1.Fields.Column_PermitImprime.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Permit.Resultset1.Fields.Column_PermitAnnule.ColumnIndex)) {

						this.col_PermitAnnule = sqlDataReader.GetSqlBoolean(SPs.spS_Permit.Resultset1.Fields.Column_PermitAnnule.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Permit.Resultset1.Fields.Column_LotID.ColumnIndex)) {

						this.col_LotID = sqlDataReader.GetSqlInt32(SPs.spS_Permit.Resultset1.Fields.Column_LotID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Permit.Resultset1.Fields.Column_EssenceSciage.ColumnIndex)) {

						this.col_EssenceSciage = sqlDataReader.GetSqlString(SPs.spS_Permit.Resultset1.Fields.Column_EssenceSciage.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Permit.Resultset1.Fields.Column_Code.ColumnIndex)) {

						this.col_Code = sqlDataReader.GetSqlString(SPs.spS_Permit.Resultset1.Fields.Column_Code.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Permit.Resultset1.Fields.Column_Remarques.ColumnIndex)) {

						this.col_Remarques = sqlDataReader.GetSqlString(SPs.spS_Permit.Resultset1.Fields.Column_Remarques.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Permit.Resultset1.Fields.Column_ChargeurID.ColumnIndex)) {

						this.col_ChargeurID = sqlDataReader.GetSqlString(SPs.spS_Permit.Resultset1.Fields.Column_ChargeurID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Permit.Resultset1.Fields.Column_ZoneID.ColumnIndex)) {

						this.col_ZoneID = sqlDataReader.GetSqlString(SPs.spS_Permit.Resultset1.Fields.Column_ZoneID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Permit.Resultset1.Fields.Column_MunicipaliteID.ColumnIndex)) {

						this.col_MunicipaliteID = sqlDataReader.GetSqlString(SPs.spS_Permit.Resultset1.Fields.Column_MunicipaliteID.ColumnIndex);
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

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Permit_Record", "Refresh");
			}
		}

		public void Update() {

			if (!this.recordWasLoadedFromDB) {

				throw new ArgumentException("No record was loaded from the database. No update is possible.");
			}

			bool ChangesHaveBeenMade = false;

			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_DatePermitWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_DateDebutWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_DateFinWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_AnneeWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_PeriodeWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_ContratIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_EssenceIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_PermitSciageWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_TransporteurIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_VRWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_ProducteurDroitCoupeIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_ProducteurEntentePaiementIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_PermitLivreWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_PermitImprimeWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_PermitAnnuleWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_LotIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_EssenceSciageWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_CodeWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_RemarquesWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_ChargeurIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_ZoneIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_MunicipaliteIDWasUpdated);

			if (!ChangesHaveBeenMade) {

				return;
			}

			Params.spU_Permit Param = new Params.spU_Permit(false);
			Param.SetUpConnection(this.connectionString);
			Param.Param_ID = this.col_ID;

			if (this.col_DatePermitWasUpdated) {

				Param.Param_DatePermit = this.col_DatePermit;
				Param.Param_ConsiderNull_DatePermit = true;
			}

			if (this.col_DateDebutWasUpdated) {

				Param.Param_DateDebut = this.col_DateDebut;
				Param.Param_ConsiderNull_DateDebut = true;
			}

			if (this.col_DateFinWasUpdated) {

				Param.Param_DateFin = this.col_DateFin;
				Param.Param_ConsiderNull_DateFin = true;
			}

			if (this.col_AnneeWasUpdated) {

				Param.Param_Annee = this.col_Annee;
				Param.Param_ConsiderNull_Annee = true;
			}

			if (this.col_PeriodeWasUpdated) {

				Param.Param_Periode = this.col_Periode;
				Param.Param_ConsiderNull_Periode = true;
			}

			if (this.col_ContratIDWasUpdated) {

				Param.Param_ContratID = this.col_ContratID;
				Param.Param_ConsiderNull_ContratID = true;
			}

			if (this.col_EssenceIDWasUpdated) {

				Param.Param_EssenceID = this.col_EssenceID;
				Param.Param_ConsiderNull_EssenceID = true;
			}

			if (this.col_PermitSciageWasUpdated) {

				Param.Param_PermitSciage = this.col_PermitSciage;
				Param.Param_ConsiderNull_PermitSciage = true;
			}

			if (this.col_TransporteurIDWasUpdated) {

				Param.Param_TransporteurID = this.col_TransporteurID;
				Param.Param_ConsiderNull_TransporteurID = true;
			}

			if (this.col_VRWasUpdated) {

				Param.Param_VR = this.col_VR;
				Param.Param_ConsiderNull_VR = true;
			}

			if (this.col_ProducteurDroitCoupeIDWasUpdated) {

				Param.Param_ProducteurDroitCoupeID = this.col_ProducteurDroitCoupeID;
				Param.Param_ConsiderNull_ProducteurDroitCoupeID = true;
			}

			if (this.col_ProducteurEntentePaiementIDWasUpdated) {

				Param.Param_ProducteurEntentePaiementID = this.col_ProducteurEntentePaiementID;
				Param.Param_ConsiderNull_ProducteurEntentePaiementID = true;
			}

			if (this.col_PermitLivreWasUpdated) {

				Param.Param_PermitLivre = this.col_PermitLivre;
				Param.Param_ConsiderNull_PermitLivre = true;
			}

			if (this.col_PermitImprimeWasUpdated) {

				Param.Param_PermitImprime = this.col_PermitImprime;
				Param.Param_ConsiderNull_PermitImprime = true;
			}

			if (this.col_PermitAnnuleWasUpdated) {

				Param.Param_PermitAnnule = this.col_PermitAnnule;
				Param.Param_ConsiderNull_PermitAnnule = true;
			}

			if (this.col_LotIDWasUpdated) {

				Param.Param_LotID = this.col_LotID;
				Param.Param_ConsiderNull_LotID = true;
			}

			if (this.col_EssenceSciageWasUpdated) {

				Param.Param_EssenceSciage = this.col_EssenceSciage;
				Param.Param_ConsiderNull_EssenceSciage = true;
			}

			if (this.col_CodeWasUpdated) {

				Param.Param_Code = this.col_Code;
				Param.Param_ConsiderNull_Code = true;
			}

			if (this.col_RemarquesWasUpdated) {

				Param.Param_Remarques = this.col_Remarques;
				Param.Param_ConsiderNull_Remarques = true;
			}

			if (this.col_ChargeurIDWasUpdated) {

				Param.Param_ChargeurID = this.col_ChargeurID;
				Param.Param_ConsiderNull_ChargeurID = true;
			}

			if (this.col_ZoneIDWasUpdated) {

				Param.Param_ZoneID = this.col_ZoneID;
				Param.Param_ConsiderNull_ZoneID = true;
			}

			if (this.col_MunicipaliteIDWasUpdated) {

				Param.Param_MunicipaliteID = this.col_MunicipaliteID;
				Param.Param_ConsiderNull_MunicipaliteID = true;
			}

			SPs.spU_Permit Sp = new SPs.spU_Permit();
			if (Sp.Execute(ref Param)) {

				this.col_DatePermitWasUpdated = false;
				this.col_DateDebutWasUpdated = false;
				this.col_DateFinWasUpdated = false;
				this.col_AnneeWasUpdated = false;
				this.col_PeriodeWasUpdated = false;
				this.col_ContratIDWasUpdated = false;
				this.col_EssenceIDWasUpdated = false;
				this.col_PermitSciageWasUpdated = false;
				this.col_TransporteurIDWasUpdated = false;
				this.col_VRWasUpdated = false;
				this.col_ProducteurDroitCoupeIDWasUpdated = false;
				this.col_ProducteurEntentePaiementIDWasUpdated = false;
				this.col_PermitLivreWasUpdated = false;
				this.col_PermitImprimeWasUpdated = false;
				this.col_PermitAnnuleWasUpdated = false;
				this.col_LotIDWasUpdated = false;
				this.col_EssenceSciageWasUpdated = false;
				this.col_CodeWasUpdated = false;
				this.col_RemarquesWasUpdated = false;
				this.col_ChargeurIDWasUpdated = false;
				this.col_ZoneIDWasUpdated = false;
				this.col_MunicipaliteIDWasUpdated = false;
			}
			else {

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Permit_Record", "Update");
			}		
		}

		private Livraison_Collection internal_Livraison_Col_ID_Collection = null;
		public Livraison_Collection Livraison_Col_ID_Collection {

			get {

				if (this.internal_Livraison_Col_ID_Collection == null) {

					this.internal_Livraison_Col_ID_Collection = new Livraison_Collection(this.connectionString);
					this.internal_Livraison_Col_ID_Collection.LoadFrom_ID(this.col_ID, this);
				}

				return(this.internal_Livraison_Col_ID_Collection);
			}
		}

		private Livraison_Permis_Collection internal_Livraison_Permis_Col_PermisID_Collection = null;
		public Livraison_Permis_Collection Livraison_Permis_Col_PermisID_Collection {

			get {

				if (this.internal_Livraison_Permis_Col_PermisID_Collection == null) {

					this.internal_Livraison_Permis_Col_PermisID_Collection = new Livraison_Permis_Collection(this.connectionString);
					this.internal_Livraison_Permis_Col_PermisID_Collection.LoadFrom_PermisID(this.col_ID, this);
				}

				return(this.internal_Livraison_Permis_Col_PermisID_Collection);
			}
		}

		internal string displayName = null;
		public override string ToString() {

			if (!this.recordWasLoadedFromDB) {

				throw new ArgumentException("No record was loaded from the database. The DisplayName is not available.");
			}
		
			if (this.displayName == null) {
			
				Params.spS_Permit_Display Param = new Params.spS_Permit_Display();
				Param.SetUpConnection(this.connectionString);

				Param.Param_ID = this.col_ID;

				System.Data.SqlClient.SqlDataReader sqlDataReader = null;
				SPs.spS_Permit_Display Sp = new SPs.spS_Permit_Display();
				if (Sp.Execute(ref Param, out sqlDataReader)) {

					if (sqlDataReader.Read()) {

						if (!sqlDataReader.IsDBNull(SPs.spS_Permit_Display.Resultset1.Fields.Column_Display.ColumnIndex)) {

							this.displayName = "spS_Permit_Display";
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

					throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Permit_Record", "ToString");
				}				
			}
			
			return(this.displayName);
		}
	}
}
