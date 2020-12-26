using System;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.BusinessComponents {

	/// <summary>
	/// This class is an abstract class that represents the [Livraison] table. With this class
	/// you can load or update a record from the database. If you need to add or delete a record,
	/// you must use the <see cref="Gestion_Paie.BusinessComponents.Livraison_Collection"/> class to do so.
	/// </summary>
	public sealed class Livraison_Record : IBusinessComponentRecord {
	
		internal bool recordWasLoadedFromDB = false;
		private bool recordIsLoaded = false;

		internal string connectionString = String.Empty;
		public string ConnectionString {
		
			get {
			
				return(this.connectionString);
			}
		}
		
		/// <summary>
		/// Initializes a new instance of the Livraison_Record class. Use this contructor to add
		/// a new record. Then call the Add method of the Gestion_Paie.BusinessComponents.Livraison_Collection class to actually
		/// add the record in the database.
		/// </summary>
		public Livraison_Record() {
		
			this.recordWasLoadedFromDB = false;
			this.recordIsLoaded = false;
		}
	
		/// <param name="col_ID">[To be supplied.]</param>
		public Livraison_Record(string connectionString, System.Data.SqlTypes.SqlInt32 col_ID) {

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
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Livraison'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}", "Livraison", CurrentRevision, OriginalRevision));
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
		
		
		private Permit_Record col_ID_Record = null;
		public Permit_Record Col_ID_Permit_Record {
		
			get {

				if (this.col_ID_Record == null) {
				
					this.col_ID_Record = new Permit_Record(this.connectionString, this.col_ID);
				}
				
				return(this.col_ID_Record);
			}
		}

		internal bool col_DateLivraisonWasSet = false;
		private bool col_DateLivraisonWasUpdated = false;
		internal System.Data.SqlTypes.SqlDateTime col_DateLivraison = System.Data.SqlTypes.SqlDateTime.Null;
		public System.Data.SqlTypes.SqlDateTime Col_DateLivraison {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_DateLivraison);
			}
			set {
			
				this.col_DateLivraisonWasUpdated = true;
				this.col_DateLivraisonWasSet = true;
				this.col_DateLivraison = value;
			}
		}

		internal bool col_DatePayeWasSet = false;
		private bool col_DatePayeWasUpdated = false;
		internal System.Data.SqlTypes.SqlDateTime col_DatePaye = System.Data.SqlTypes.SqlDateTime.Null;
		public System.Data.SqlTypes.SqlDateTime Col_DatePaye {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_DatePaye);
			}
			set {
			
				this.col_DatePayeWasUpdated = true;
				this.col_DatePayeWasSet = true;
				this.col_DatePaye = value;
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

		internal bool col_UniteMesureIDWasSet = false;
		private bool col_UniteMesureIDWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_UniteMesureID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_UniteMesureID {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_UniteMesureID);
			}
			set {
			
				this.col_UniteMesureIDWasUpdated = true;
				this.col_UniteMesureIDWasSet = true;
				this.col_UniteMesureID_Record = null;
				this.col_UniteMesureID = value;
			}
		}

		
		private UniteMesure_Record col_UniteMesureID_Record = null;
		public UniteMesure_Record Col_UniteMesureID_UniteMesure_Record {
		
			get {

				if (this.col_UniteMesureID_Record == null) {
				
					this.col_UniteMesureID_Record = new UniteMesure_Record(this.connectionString, this.col_UniteMesureID);
				}
				
				return(this.col_UniteMesureID_Record);
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

		internal bool col_SciageWasSet = false;
		private bool col_SciageWasUpdated = false;
		internal System.Data.SqlTypes.SqlBoolean col_Sciage = System.Data.SqlTypes.SqlBoolean.Null;
		public System.Data.SqlTypes.SqlBoolean Col_Sciage {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Sciage);
			}
			set {
			
				this.col_SciageWasUpdated = true;
				this.col_SciageWasSet = true;
				this.col_Sciage = value;
			}
		}

		internal bool col_NumeroFactureUsineWasSet = false;
		private bool col_NumeroFactureUsineWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_NumeroFactureUsine = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_NumeroFactureUsine {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_NumeroFactureUsine);
			}
			set {
			
				this.col_NumeroFactureUsineWasUpdated = true;
				this.col_NumeroFactureUsineWasSet = true;
				this.col_NumeroFactureUsine = value;
			}
		}

		internal bool col_DroitCoupeIDWasSet = false;
		private bool col_DroitCoupeIDWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_DroitCoupeID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_DroitCoupeID {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_DroitCoupeID);
			}
			set {
			
				this.col_DroitCoupeIDWasUpdated = true;
				this.col_DroitCoupeIDWasSet = true;
				this.col_DroitCoupeID_Record = null;
				this.col_DroitCoupeID = value;
			}
		}

		
		private Fournisseur_Record col_DroitCoupeID_Record = null;
		public Fournisseur_Record Col_DroitCoupeID_Fournisseur_Record {
		
			get {

				if (this.col_DroitCoupeID_Record == null) {
				
					this.col_DroitCoupeID_Record = new Fournisseur_Record(this.connectionString, this.col_DroitCoupeID);
				}
				
				return(this.col_DroitCoupeID_Record);
			}
		}

		internal bool col_EntentePaiementIDWasSet = false;
		private bool col_EntentePaiementIDWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_EntentePaiementID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_EntentePaiementID {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_EntentePaiementID);
			}
			set {
			
				this.col_EntentePaiementIDWasUpdated = true;
				this.col_EntentePaiementIDWasSet = true;
				this.col_EntentePaiementID_Record = null;
				this.col_EntentePaiementID = value;
			}
		}

		
		private Fournisseur_Record col_EntentePaiementID_Record = null;
		public Fournisseur_Record Col_EntentePaiementID_Fournisseur_Record {
		
			get {

				if (this.col_EntentePaiementID_Record == null) {
				
					this.col_EntentePaiementID_Record = new Fournisseur_Record(this.connectionString, this.col_EntentePaiementID);
				}
				
				return(this.col_EntentePaiementID_Record);
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

		internal bool col_MasseLimiteWasSet = false;
		private bool col_MasseLimiteWasUpdated = false;
		internal System.Data.SqlTypes.SqlDouble col_MasseLimite = System.Data.SqlTypes.SqlDouble.Null;
		public System.Data.SqlTypes.SqlDouble Col_MasseLimite {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_MasseLimite);
			}
			set {
			
				this.col_MasseLimiteWasUpdated = true;
				this.col_MasseLimiteWasSet = true;
				this.col_MasseLimite = value;
			}
		}

		internal bool col_VolumeBrutWasSet = false;
		private bool col_VolumeBrutWasUpdated = false;
		internal System.Data.SqlTypes.SqlDouble col_VolumeBrut = System.Data.SqlTypes.SqlDouble.Null;
		public System.Data.SqlTypes.SqlDouble Col_VolumeBrut {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_VolumeBrut);
			}
			set {
			
				this.col_VolumeBrutWasUpdated = true;
				this.col_VolumeBrutWasSet = true;
				this.col_VolumeBrut = value;
			}
		}

		internal bool col_VolumeTareWasSet = false;
		private bool col_VolumeTareWasUpdated = false;
		internal System.Data.SqlTypes.SqlDouble col_VolumeTare = System.Data.SqlTypes.SqlDouble.Null;
		public System.Data.SqlTypes.SqlDouble Col_VolumeTare {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_VolumeTare);
			}
			set {
			
				this.col_VolumeTareWasUpdated = true;
				this.col_VolumeTareWasSet = true;
				this.col_VolumeTare = value;
			}
		}

		internal bool col_VolumeTransporteWasSet = false;
		private bool col_VolumeTransporteWasUpdated = false;
		internal System.Data.SqlTypes.SqlDouble col_VolumeTransporte = System.Data.SqlTypes.SqlDouble.Null;
		public System.Data.SqlTypes.SqlDouble Col_VolumeTransporte {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_VolumeTransporte);
			}
			set {
			
				this.col_VolumeTransporteWasUpdated = true;
				this.col_VolumeTransporteWasSet = true;
				this.col_VolumeTransporte = value;
			}
		}

		internal bool col_VolumeSurchargeWasSet = false;
		private bool col_VolumeSurchargeWasUpdated = false;
		internal System.Data.SqlTypes.SqlDouble col_VolumeSurcharge = System.Data.SqlTypes.SqlDouble.Null;
		public System.Data.SqlTypes.SqlDouble Col_VolumeSurcharge {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_VolumeSurcharge);
			}
			set {
			
				this.col_VolumeSurchargeWasUpdated = true;
				this.col_VolumeSurchargeWasSet = true;
				this.col_VolumeSurcharge = value;
			}
		}

		internal bool col_VolumeAPayerWasSet = false;
		private bool col_VolumeAPayerWasUpdated = false;
		internal System.Data.SqlTypes.SqlDouble col_VolumeAPayer = System.Data.SqlTypes.SqlDouble.Null;
		public System.Data.SqlTypes.SqlDouble Col_VolumeAPayer {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_VolumeAPayer);
			}
			set {
			
				this.col_VolumeAPayerWasUpdated = true;
				this.col_VolumeAPayerWasSet = true;
				this.col_VolumeAPayer = value;
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
				this.col_Annee_Record = null;
				this.col_Annee = value;
			}
		}

		
		private Periode_Record col_Annee_Record = null;
		public Periode_Record Col_Annee_Periode_Record {
		
			get {

				if (this.col_Annee_Record == null) {
				
					this.col_Annee_Record = new Periode_Record(this.connectionString, this.col_Annee, System.Data.SqlTypes.SqlInt32.Null);
				}
				
				return(this.col_Annee_Record);
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
				this.col_Periode_Record = null;
				this.col_Periode = value;
			}
		}

		
		private Periode_Record col_Periode_Record = null;
		public Periode_Record Col_Periode_Periode_Record {
		
			get {

				if (this.col_Periode_Record == null) {
				
					this.col_Periode_Record = new Periode_Record(this.connectionString, System.Data.SqlTypes.SqlInt32.Null, this.col_Periode);
				}
				
				return(this.col_Periode_Record);
			}
		}

		internal bool col_DateCalculWasSet = false;
		private bool col_DateCalculWasUpdated = false;
		internal System.Data.SqlTypes.SqlDateTime col_DateCalcul = System.Data.SqlTypes.SqlDateTime.Null;
		public System.Data.SqlTypes.SqlDateTime Col_DateCalcul {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_DateCalcul);
			}
			set {
			
				this.col_DateCalculWasUpdated = true;
				this.col_DateCalculWasSet = true;
				this.col_DateCalcul = value;
			}
		}

		internal bool col_Taux_TransporteurWasSet = false;
		private bool col_Taux_TransporteurWasUpdated = false;
		internal System.Data.SqlTypes.SqlDouble col_Taux_Transporteur = System.Data.SqlTypes.SqlDouble.Null;
		public System.Data.SqlTypes.SqlDouble Col_Taux_Transporteur {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Taux_Transporteur);
			}
			set {
			
				this.col_Taux_TransporteurWasUpdated = true;
				this.col_Taux_TransporteurWasSet = true;
				this.col_Taux_Transporteur = value;
			}
		}

		internal bool col_Montant_TransporteurWasSet = false;
		private bool col_Montant_TransporteurWasUpdated = false;
		internal System.Data.SqlTypes.SqlDouble col_Montant_Transporteur = System.Data.SqlTypes.SqlDouble.Null;
		public System.Data.SqlTypes.SqlDouble Col_Montant_Transporteur {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Montant_Transporteur);
			}
			set {
			
				this.col_Montant_TransporteurWasUpdated = true;
				this.col_Montant_TransporteurWasSet = true;
				this.col_Montant_Transporteur = value;
			}
		}

		internal bool col_Montant_UsineWasSet = false;
		private bool col_Montant_UsineWasUpdated = false;
		internal System.Data.SqlTypes.SqlDouble col_Montant_Usine = System.Data.SqlTypes.SqlDouble.Null;
		public System.Data.SqlTypes.SqlDouble Col_Montant_Usine {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Montant_Usine);
			}
			set {
			
				this.col_Montant_UsineWasUpdated = true;
				this.col_Montant_UsineWasSet = true;
				this.col_Montant_Usine = value;
			}
		}

		internal bool col_Montant_Producteur1WasSet = false;
		private bool col_Montant_Producteur1WasUpdated = false;
		internal System.Data.SqlTypes.SqlDouble col_Montant_Producteur1 = System.Data.SqlTypes.SqlDouble.Null;
		public System.Data.SqlTypes.SqlDouble Col_Montant_Producteur1 {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Montant_Producteur1);
			}
			set {
			
				this.col_Montant_Producteur1WasUpdated = true;
				this.col_Montant_Producteur1WasSet = true;
				this.col_Montant_Producteur1 = value;
			}
		}

		internal bool col_Montant_Producteur2WasSet = false;
		private bool col_Montant_Producteur2WasUpdated = false;
		internal System.Data.SqlTypes.SqlDouble col_Montant_Producteur2 = System.Data.SqlTypes.SqlDouble.Null;
		public System.Data.SqlTypes.SqlDouble Col_Montant_Producteur2 {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Montant_Producteur2);
			}
			set {
			
				this.col_Montant_Producteur2WasUpdated = true;
				this.col_Montant_Producteur2WasSet = true;
				this.col_Montant_Producteur2 = value;
			}
		}

		internal bool col_Montant_Preleve_Plan_ConjointWasSet = false;
		private bool col_Montant_Preleve_Plan_ConjointWasUpdated = false;
		internal System.Data.SqlTypes.SqlDouble col_Montant_Preleve_Plan_Conjoint = System.Data.SqlTypes.SqlDouble.Null;
		public System.Data.SqlTypes.SqlDouble Col_Montant_Preleve_Plan_Conjoint {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Montant_Preleve_Plan_Conjoint);
			}
			set {
			
				this.col_Montant_Preleve_Plan_ConjointWasUpdated = true;
				this.col_Montant_Preleve_Plan_ConjointWasSet = true;
				this.col_Montant_Preleve_Plan_Conjoint = value;
			}
		}

		internal bool col_Montant_Preleve_Fond_RoulementWasSet = false;
		private bool col_Montant_Preleve_Fond_RoulementWasUpdated = false;
		internal System.Data.SqlTypes.SqlDouble col_Montant_Preleve_Fond_Roulement = System.Data.SqlTypes.SqlDouble.Null;
		public System.Data.SqlTypes.SqlDouble Col_Montant_Preleve_Fond_Roulement {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Montant_Preleve_Fond_Roulement);
			}
			set {
			
				this.col_Montant_Preleve_Fond_RoulementWasUpdated = true;
				this.col_Montant_Preleve_Fond_RoulementWasSet = true;
				this.col_Montant_Preleve_Fond_Roulement = value;
			}
		}

		internal bool col_Montant_Preleve_Fond_ForestierWasSet = false;
		private bool col_Montant_Preleve_Fond_ForestierWasUpdated = false;
		internal System.Data.SqlTypes.SqlDouble col_Montant_Preleve_Fond_Forestier = System.Data.SqlTypes.SqlDouble.Null;
		public System.Data.SqlTypes.SqlDouble Col_Montant_Preleve_Fond_Forestier {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Montant_Preleve_Fond_Forestier);
			}
			set {
			
				this.col_Montant_Preleve_Fond_ForestierWasUpdated = true;
				this.col_Montant_Preleve_Fond_ForestierWasSet = true;
				this.col_Montant_Preleve_Fond_Forestier = value;
			}
		}

		internal bool col_Montant_Preleve_DiversWasSet = false;
		private bool col_Montant_Preleve_DiversWasUpdated = false;
		internal System.Data.SqlTypes.SqlDouble col_Montant_Preleve_Divers = System.Data.SqlTypes.SqlDouble.Null;
		public System.Data.SqlTypes.SqlDouble Col_Montant_Preleve_Divers {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Montant_Preleve_Divers);
			}
			set {
			
				this.col_Montant_Preleve_DiversWasUpdated = true;
				this.col_Montant_Preleve_DiversWasSet = true;
				this.col_Montant_Preleve_Divers = value;
			}
		}

		internal bool col_Montant_SurchargeWasSet = false;
		private bool col_Montant_SurchargeWasUpdated = false;
		internal System.Data.SqlTypes.SqlDouble col_Montant_Surcharge = System.Data.SqlTypes.SqlDouble.Null;
		public System.Data.SqlTypes.SqlDouble Col_Montant_Surcharge {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Montant_Surcharge);
			}
			set {
			
				this.col_Montant_SurchargeWasUpdated = true;
				this.col_Montant_SurchargeWasSet = true;
				this.col_Montant_Surcharge = value;
			}
		}

		internal bool col_Montant_MiseEnCommunWasSet = false;
		private bool col_Montant_MiseEnCommunWasUpdated = false;
		internal System.Data.SqlTypes.SqlSingle col_Montant_MiseEnCommun = System.Data.SqlTypes.SqlSingle.Null;
		public System.Data.SqlTypes.SqlSingle Col_Montant_MiseEnCommun {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Montant_MiseEnCommun);
			}
			set {
			
				this.col_Montant_MiseEnCommunWasUpdated = true;
				this.col_Montant_MiseEnCommunWasSet = true;
				this.col_Montant_MiseEnCommun = value;
			}
		}

		internal bool col_FactureWasSet = false;
		private bool col_FactureWasUpdated = false;
		internal System.Data.SqlTypes.SqlBoolean col_Facture = System.Data.SqlTypes.SqlBoolean.Null;
		public System.Data.SqlTypes.SqlBoolean Col_Facture {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Facture);
			}
			set {
			
				this.col_FactureWasUpdated = true;
				this.col_FactureWasSet = true;
				this.col_Facture = value;
			}
		}

		internal bool col_Producteur1_FactureIDWasSet = false;
		private bool col_Producteur1_FactureIDWasUpdated = false;
		internal System.Data.SqlTypes.SqlInt32 col_Producteur1_FactureID = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_Producteur1_FactureID {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Producteur1_FactureID);
			}
			set {
			
				this.col_Producteur1_FactureIDWasUpdated = true;
				this.col_Producteur1_FactureIDWasSet = true;
				this.col_Producteur1_FactureID_Record = null;
				this.col_Producteur1_FactureID = value;
			}
		}

		
		private FactureFournisseur_Record col_Producteur1_FactureID_Record = null;
		public FactureFournisseur_Record Col_Producteur1_FactureID_FactureFournisseur_Record {
		
			get {

				if (this.col_Producteur1_FactureID_Record == null) {
				
					this.col_Producteur1_FactureID_Record = new FactureFournisseur_Record(this.connectionString, this.col_Producteur1_FactureID);
				}
				
				return(this.col_Producteur1_FactureID_Record);
			}
		}

		internal bool col_Producteur2_FactureIDWasSet = false;
		private bool col_Producteur2_FactureIDWasUpdated = false;
		internal System.Data.SqlTypes.SqlInt32 col_Producteur2_FactureID = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_Producteur2_FactureID {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Producteur2_FactureID);
			}
			set {
			
				this.col_Producteur2_FactureIDWasUpdated = true;
				this.col_Producteur2_FactureIDWasSet = true;
				this.col_Producteur2_FactureID_Record = null;
				this.col_Producteur2_FactureID = value;
			}
		}

		
		private FactureFournisseur_Record col_Producteur2_FactureID_Record = null;
		public FactureFournisseur_Record Col_Producteur2_FactureID_FactureFournisseur_Record {
		
			get {

				if (this.col_Producteur2_FactureID_Record == null) {
				
					this.col_Producteur2_FactureID_Record = new FactureFournisseur_Record(this.connectionString, this.col_Producteur2_FactureID);
				}
				
				return(this.col_Producteur2_FactureID_Record);
			}
		}

		internal bool col_Transporteur_FactureIDWasSet = false;
		private bool col_Transporteur_FactureIDWasUpdated = false;
		internal System.Data.SqlTypes.SqlInt32 col_Transporteur_FactureID = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_Transporteur_FactureID {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Transporteur_FactureID);
			}
			set {
			
				this.col_Transporteur_FactureIDWasUpdated = true;
				this.col_Transporteur_FactureIDWasSet = true;
				this.col_Transporteur_FactureID_Record = null;
				this.col_Transporteur_FactureID = value;
			}
		}

		
		private FactureFournisseur_Record col_Transporteur_FactureID_Record = null;
		public FactureFournisseur_Record Col_Transporteur_FactureID_FactureFournisseur_Record {
		
			get {

				if (this.col_Transporteur_FactureID_Record == null) {
				
					this.col_Transporteur_FactureID_Record = new FactureFournisseur_Record(this.connectionString, this.col_Transporteur_FactureID);
				}
				
				return(this.col_Transporteur_FactureID_Record);
			}
		}

		internal bool col_Usine_FactureIDWasSet = false;
		private bool col_Usine_FactureIDWasUpdated = false;
		internal System.Data.SqlTypes.SqlInt32 col_Usine_FactureID = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_Usine_FactureID {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Usine_FactureID);
			}
			set {
			
				this.col_Usine_FactureIDWasUpdated = true;
				this.col_Usine_FactureIDWasSet = true;
				this.col_Usine_FactureID_Record = null;
				this.col_Usine_FactureID = value;
			}
		}

		
		private FactureClient_Record col_Usine_FactureID_Record = null;
		public FactureClient_Record Col_Usine_FactureID_FactureClient_Record {
		
			get {

				if (this.col_Usine_FactureID_Record == null) {
				
					this.col_Usine_FactureID_Record = new FactureClient_Record(this.connectionString, this.col_Usine_FactureID);
				}
				
				return(this.col_Usine_FactureID_Record);
			}
		}

		internal bool col_ErreurCalculWasSet = false;
		private bool col_ErreurCalculWasUpdated = false;
		internal System.Data.SqlTypes.SqlBoolean col_ErreurCalcul = System.Data.SqlTypes.SqlBoolean.Null;
		public System.Data.SqlTypes.SqlBoolean Col_ErreurCalcul {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_ErreurCalcul);
			}
			set {
			
				this.col_ErreurCalculWasUpdated = true;
				this.col_ErreurCalculWasSet = true;
				this.col_ErreurCalcul = value;
			}
		}

		internal bool col_ErreurDescriptionWasSet = false;
		private bool col_ErreurDescriptionWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_ErreurDescription = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_ErreurDescription {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_ErreurDescription);
			}
			set {
			
				this.col_ErreurDescriptionWasUpdated = true;
				this.col_ErreurDescriptionWasSet = true;
				this.col_ErreurDescription = value;
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

		internal bool col_Taux_Transporteur_OverrideWasSet = false;
		private bool col_Taux_Transporteur_OverrideWasUpdated = false;
		internal System.Data.SqlTypes.SqlBoolean col_Taux_Transporteur_Override = System.Data.SqlTypes.SqlBoolean.Null;
		public System.Data.SqlTypes.SqlBoolean Col_Taux_Transporteur_Override {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Taux_Transporteur_Override);
			}
			set {
			
				this.col_Taux_Transporteur_OverrideWasUpdated = true;
				this.col_Taux_Transporteur_OverrideWasSet = true;
				this.col_Taux_Transporteur_Override = value;
			}
		}

		internal bool col_PaieTransporteurWasSet = false;
		private bool col_PaieTransporteurWasUpdated = false;
		internal System.Data.SqlTypes.SqlBoolean col_PaieTransporteur = System.Data.SqlTypes.SqlBoolean.Null;
		public System.Data.SqlTypes.SqlBoolean Col_PaieTransporteur {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_PaieTransporteur);
			}
			set {
			
				this.col_PaieTransporteurWasUpdated = true;
				this.col_PaieTransporteurWasSet = true;
				this.col_PaieTransporteur = value;
			}
		}

		internal bool col_VolumeSurcharge_OverrideWasSet = false;
		private bool col_VolumeSurcharge_OverrideWasUpdated = false;
		internal System.Data.SqlTypes.SqlBoolean col_VolumeSurcharge_Override = System.Data.SqlTypes.SqlBoolean.Null;
		public System.Data.SqlTypes.SqlBoolean Col_VolumeSurcharge_Override {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_VolumeSurcharge_Override);
			}
			set {
			
				this.col_VolumeSurcharge_OverrideWasUpdated = true;
				this.col_VolumeSurcharge_OverrideWasSet = true;
				this.col_VolumeSurcharge_Override = value;
			}
		}

		internal bool col_SurchargeManuelWasSet = false;
		private bool col_SurchargeManuelWasUpdated = false;
		internal System.Data.SqlTypes.SqlBoolean col_SurchargeManuel = System.Data.SqlTypes.SqlBoolean.Null;
		public System.Data.SqlTypes.SqlBoolean Col_SurchargeManuel {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_SurchargeManuel);
			}
			set {
			
				this.col_SurchargeManuelWasUpdated = true;
				this.col_SurchargeManuelWasSet = true;
				this.col_SurchargeManuel = value;
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

		internal bool col_NombrePermisWasSet = false;
		private bool col_NombrePermisWasUpdated = false;
		internal System.Data.SqlTypes.SqlInt32 col_NombrePermis = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_NombrePermis {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_NombrePermis);
			}
			set {
			
				this.col_NombrePermisWasUpdated = true;
				this.col_NombrePermisWasSet = true;
				this.col_NombrePermis = value;
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

		internal bool col_Montant_ChargeurWasSet = false;
		private bool col_Montant_ChargeurWasUpdated = false;
		internal System.Data.SqlTypes.SqlDouble col_Montant_Chargeur = System.Data.SqlTypes.SqlDouble.Null;
		public System.Data.SqlTypes.SqlDouble Col_Montant_Chargeur {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Montant_Chargeur);
			}
			set {
			
				this.col_Montant_ChargeurWasUpdated = true;
				this.col_Montant_ChargeurWasSet = true;
				this.col_Montant_Chargeur = value;
			}
		}

		internal bool col_Frais_ChargeurAuProducteurWasSet = false;
		private bool col_Frais_ChargeurAuProducteurWasUpdated = false;
		internal System.Data.SqlTypes.SqlDouble col_Frais_ChargeurAuProducteur = System.Data.SqlTypes.SqlDouble.Null;
		public System.Data.SqlTypes.SqlDouble Col_Frais_ChargeurAuProducteur {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Frais_ChargeurAuProducteur);
			}
			set {
			
				this.col_Frais_ChargeurAuProducteurWasUpdated = true;
				this.col_Frais_ChargeurAuProducteurWasSet = true;
				this.col_Frais_ChargeurAuProducteur = value;
			}
		}

		internal bool col_Frais_ChargeurAuTransporteurWasSet = false;
		private bool col_Frais_ChargeurAuTransporteurWasUpdated = false;
		internal System.Data.SqlTypes.SqlDouble col_Frais_ChargeurAuTransporteur = System.Data.SqlTypes.SqlDouble.Null;
		public System.Data.SqlTypes.SqlDouble Col_Frais_ChargeurAuTransporteur {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Frais_ChargeurAuTransporteur);
			}
			set {
			
				this.col_Frais_ChargeurAuTransporteurWasUpdated = true;
				this.col_Frais_ChargeurAuTransporteurWasSet = true;
				this.col_Frais_ChargeurAuTransporteur = value;
			}
		}

		internal bool col_Frais_AutresAuProducteurWasSet = false;
		private bool col_Frais_AutresAuProducteurWasUpdated = false;
		internal System.Data.SqlTypes.SqlDouble col_Frais_AutresAuProducteur = System.Data.SqlTypes.SqlDouble.Null;
		public System.Data.SqlTypes.SqlDouble Col_Frais_AutresAuProducteur {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Frais_AutresAuProducteur);
			}
			set {
			
				this.col_Frais_AutresAuProducteurWasUpdated = true;
				this.col_Frais_AutresAuProducteurWasSet = true;
				this.col_Frais_AutresAuProducteur = value;
			}
		}

		internal bool col_Frais_AutresAuProducteurDescriptionWasSet = false;
		private bool col_Frais_AutresAuProducteurDescriptionWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_Frais_AutresAuProducteurDescription = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_Frais_AutresAuProducteurDescription {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Frais_AutresAuProducteurDescription);
			}
			set {
			
				this.col_Frais_AutresAuProducteurDescriptionWasUpdated = true;
				this.col_Frais_AutresAuProducteurDescriptionWasSet = true;
				this.col_Frais_AutresAuProducteurDescription = value;
			}
		}

		internal bool col_Frais_AutresAuProducteurTransportSciageWasSet = false;
		private bool col_Frais_AutresAuProducteurTransportSciageWasUpdated = false;
		internal System.Data.SqlTypes.SqlDouble col_Frais_AutresAuProducteurTransportSciage = System.Data.SqlTypes.SqlDouble.Null;
		public System.Data.SqlTypes.SqlDouble Col_Frais_AutresAuProducteurTransportSciage {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Frais_AutresAuProducteurTransportSciage);
			}
			set {
			
				this.col_Frais_AutresAuProducteurTransportSciageWasUpdated = true;
				this.col_Frais_AutresAuProducteurTransportSciageWasSet = true;
				this.col_Frais_AutresAuProducteurTransportSciage = value;
			}
		}

		internal bool col_Frais_AutresAuTransporteurWasSet = false;
		private bool col_Frais_AutresAuTransporteurWasUpdated = false;
		internal System.Data.SqlTypes.SqlDouble col_Frais_AutresAuTransporteur = System.Data.SqlTypes.SqlDouble.Null;
		public System.Data.SqlTypes.SqlDouble Col_Frais_AutresAuTransporteur {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Frais_AutresAuTransporteur);
			}
			set {
			
				this.col_Frais_AutresAuTransporteurWasUpdated = true;
				this.col_Frais_AutresAuTransporteurWasSet = true;
				this.col_Frais_AutresAuTransporteur = value;
			}
		}

		internal bool col_Frais_AutresAuTransporteurDescriptionWasSet = false;
		private bool col_Frais_AutresAuTransporteurDescriptionWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_Frais_AutresAuTransporteurDescription = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_Frais_AutresAuTransporteurDescription {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Frais_AutresAuTransporteurDescription);
			}
			set {
			
				this.col_Frais_AutresAuTransporteurDescriptionWasUpdated = true;
				this.col_Frais_AutresAuTransporteurDescriptionWasSet = true;
				this.col_Frais_AutresAuTransporteurDescription = value;
			}
		}

		internal bool col_Frais_CompensationDeDeplacementWasSet = false;
		private bool col_Frais_CompensationDeDeplacementWasUpdated = false;
		internal System.Data.SqlTypes.SqlDouble col_Frais_CompensationDeDeplacement = System.Data.SqlTypes.SqlDouble.Null;
		public System.Data.SqlTypes.SqlDouble Col_Frais_CompensationDeDeplacement {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Frais_CompensationDeDeplacement);
			}
			set {
			
				this.col_Frais_CompensationDeDeplacementWasUpdated = true;
				this.col_Frais_CompensationDeDeplacementWasSet = true;
				this.col_Frais_CompensationDeDeplacement = value;
			}
		}

		internal bool col_Chargeur_FactureIDWasSet = false;
		private bool col_Chargeur_FactureIDWasUpdated = false;
		internal System.Data.SqlTypes.SqlInt32 col_Chargeur_FactureID = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_Chargeur_FactureID {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Chargeur_FactureID);
			}
			set {
			
				this.col_Chargeur_FactureIDWasUpdated = true;
				this.col_Chargeur_FactureIDWasSet = true;
				this.col_Chargeur_FactureID_Record = null;
				this.col_Chargeur_FactureID = value;
			}
		}

		
		private FactureFournisseur_Record col_Chargeur_FactureID_Record = null;
		public FactureFournisseur_Record Col_Chargeur_FactureID_FactureFournisseur_Record {
		
			get {

				if (this.col_Chargeur_FactureID_Record == null) {
				
					this.col_Chargeur_FactureID_Record = new FactureFournisseur_Record(this.connectionString, this.col_Chargeur_FactureID);
				}
				
				return(this.col_Chargeur_FactureID_Record);
			}
		}

		internal bool col_Commentaires_ProducteurWasSet = false;
		private bool col_Commentaires_ProducteurWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_Commentaires_Producteur = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_Commentaires_Producteur {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Commentaires_Producteur);
			}
			set {
			
				this.col_Commentaires_ProducteurWasUpdated = true;
				this.col_Commentaires_ProducteurWasSet = true;
				this.col_Commentaires_Producteur = value;
			}
		}

		internal bool col_Commentaires_TransporteurWasSet = false;
		private bool col_Commentaires_TransporteurWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_Commentaires_Transporteur = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_Commentaires_Transporteur {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Commentaires_Transporteur);
			}
			set {
			
				this.col_Commentaires_TransporteurWasUpdated = true;
				this.col_Commentaires_TransporteurWasSet = true;
				this.col_Commentaires_Transporteur = value;
			}
		}

		internal bool col_Commentaires_ChargeurWasSet = false;
		private bool col_Commentaires_ChargeurWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_Commentaires_Chargeur = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_Commentaires_Chargeur {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Commentaires_Chargeur);
			}
			set {
			
				this.col_Commentaires_ChargeurWasUpdated = true;
				this.col_Commentaires_ChargeurWasSet = true;
				this.col_Commentaires_Chargeur = value;
			}
		}

		internal bool col_TauxChargeurAuProducteurWasSet = false;
		private bool col_TauxChargeurAuProducteurWasUpdated = false;
		internal System.Data.SqlTypes.SqlDouble col_TauxChargeurAuProducteur = System.Data.SqlTypes.SqlDouble.Null;
		public System.Data.SqlTypes.SqlDouble Col_TauxChargeurAuProducteur {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_TauxChargeurAuProducteur);
			}
			set {
			
				this.col_TauxChargeurAuProducteurWasUpdated = true;
				this.col_TauxChargeurAuProducteurWasSet = true;
				this.col_TauxChargeurAuProducteur = value;
			}
		}

		internal bool col_TauxChargeurAuTransporteurWasSet = false;
		private bool col_TauxChargeurAuTransporteurWasUpdated = false;
		internal System.Data.SqlTypes.SqlDouble col_TauxChargeurAuTransporteur = System.Data.SqlTypes.SqlDouble.Null;
		public System.Data.SqlTypes.SqlDouble Col_TauxChargeurAuTransporteur {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_TauxChargeurAuTransporteur);
			}
			set {
			
				this.col_TauxChargeurAuTransporteurWasUpdated = true;
				this.col_TauxChargeurAuTransporteurWasSet = true;
				this.col_TauxChargeurAuTransporteur = value;
			}
		}

		internal bool col_Frais_AutresRevenusTransporteurWasSet = false;
		private bool col_Frais_AutresRevenusTransporteurWasUpdated = false;
		internal System.Data.SqlTypes.SqlDouble col_Frais_AutresRevenusTransporteur = System.Data.SqlTypes.SqlDouble.Null;
		public System.Data.SqlTypes.SqlDouble Col_Frais_AutresRevenusTransporteur {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Frais_AutresRevenusTransporteur);
			}
			set {
			
				this.col_Frais_AutresRevenusTransporteurWasUpdated = true;
				this.col_Frais_AutresRevenusTransporteurWasSet = true;
				this.col_Frais_AutresRevenusTransporteur = value;
			}
		}

		internal bool col_Frais_AutresRevenusTransporteurDescriptionWasSet = false;
		private bool col_Frais_AutresRevenusTransporteurDescriptionWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_Frais_AutresRevenusTransporteurDescription = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_Frais_AutresRevenusTransporteurDescription {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Frais_AutresRevenusTransporteurDescription);
			}
			set {
			
				this.col_Frais_AutresRevenusTransporteurDescriptionWasUpdated = true;
				this.col_Frais_AutresRevenusTransporteurDescriptionWasSet = true;
				this.col_Frais_AutresRevenusTransporteurDescription = value;
			}
		}

		internal bool col_Frais_AutresRevenusProducteurWasSet = false;
		private bool col_Frais_AutresRevenusProducteurWasUpdated = false;
		internal System.Data.SqlTypes.SqlDouble col_Frais_AutresRevenusProducteur = System.Data.SqlTypes.SqlDouble.Null;
		public System.Data.SqlTypes.SqlDouble Col_Frais_AutresRevenusProducteur {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Frais_AutresRevenusProducteur);
			}
			set {
			
				this.col_Frais_AutresRevenusProducteurWasUpdated = true;
				this.col_Frais_AutresRevenusProducteurWasSet = true;
				this.col_Frais_AutresRevenusProducteur = value;
			}
		}

		internal bool col_Frais_AutresRevenusProducteurDescriptionWasSet = false;
		private bool col_Frais_AutresRevenusProducteurDescriptionWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_Frais_AutresRevenusProducteurDescription = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_Frais_AutresRevenusProducteurDescription {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Frais_AutresRevenusProducteurDescription);
			}
			set {
			
				this.col_Frais_AutresRevenusProducteurDescriptionWasUpdated = true;
				this.col_Frais_AutresRevenusProducteurDescriptionWasSet = true;
				this.col_Frais_AutresRevenusProducteurDescription = value;
			}
		}

		internal bool col_Montant_SurchargeProducteurWasSet = false;
		private bool col_Montant_SurchargeProducteurWasUpdated = false;
		internal System.Data.SqlTypes.SqlDouble col_Montant_SurchargeProducteur = System.Data.SqlTypes.SqlDouble.Null;
		public System.Data.SqlTypes.SqlDouble Col_Montant_SurchargeProducteur {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Montant_SurchargeProducteur);
			}
			set {
			
				this.col_Montant_SurchargeProducteurWasUpdated = true;
				this.col_Montant_SurchargeProducteurWasSet = true;
				this.col_Montant_SurchargeProducteur = value;
			}
		}

		internal bool col_KgVert_BrutWasSet = false;
		private bool col_KgVert_BrutWasUpdated = false;
		internal System.Data.SqlTypes.SqlInt32 col_KgVert_Brut = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_KgVert_Brut {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_KgVert_Brut);
			}
			set {
			
				this.col_KgVert_BrutWasUpdated = true;
				this.col_KgVert_BrutWasSet = true;
				this.col_KgVert_Brut = value;
			}
		}

		internal bool col_KgVert_TareWasSet = false;
		private bool col_KgVert_TareWasUpdated = false;
		internal System.Data.SqlTypes.SqlInt32 col_KgVert_Tare = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_KgVert_Tare {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_KgVert_Tare);
			}
			set {
			
				this.col_KgVert_TareWasUpdated = true;
				this.col_KgVert_TareWasSet = true;
				this.col_KgVert_Tare = value;
			}
		}

		internal bool col_KgVert_NetWasSet = false;
		private bool col_KgVert_NetWasUpdated = false;
		internal System.Data.SqlTypes.SqlInt32 col_KgVert_Net = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_KgVert_Net {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_KgVert_Net);
			}
			set {
			
				this.col_KgVert_NetWasUpdated = true;
				this.col_KgVert_NetWasSet = true;
				this.col_KgVert_Net = value;
			}
		}

		internal bool col_KgVert_RejetsWasSet = false;
		private bool col_KgVert_RejetsWasUpdated = false;
		internal System.Data.SqlTypes.SqlInt32 col_KgVert_Rejets = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_KgVert_Rejets {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_KgVert_Rejets);
			}
			set {
			
				this.col_KgVert_RejetsWasUpdated = true;
				this.col_KgVert_RejetsWasSet = true;
				this.col_KgVert_Rejets = value;
			}
		}

		internal bool col_KgVert_PayeWasSet = false;
		private bool col_KgVert_PayeWasUpdated = false;
		internal System.Data.SqlTypes.SqlInt32 col_KgVert_Paye = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_KgVert_Paye {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_KgVert_Paye);
			}
			set {
			
				this.col_KgVert_PayeWasUpdated = true;
				this.col_KgVert_PayeWasSet = true;
				this.col_KgVert_Paye = value;
			}
		}

		internal bool col_Pourcent_Sec_ProducteurWasSet = false;
		private bool col_Pourcent_Sec_ProducteurWasUpdated = false;
		internal System.Data.SqlTypes.SqlDouble col_Pourcent_Sec_Producteur = System.Data.SqlTypes.SqlDouble.Null;
		public System.Data.SqlTypes.SqlDouble Col_Pourcent_Sec_Producteur {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Pourcent_Sec_Producteur);
			}
			set {
			
				this.col_Pourcent_Sec_ProducteurWasUpdated = true;
				this.col_Pourcent_Sec_ProducteurWasSet = true;
				this.col_Pourcent_Sec_Producteur = value;
			}
		}

		internal bool col_Pourcent_Sec_Producteur_OverrideWasSet = false;
		private bool col_Pourcent_Sec_Producteur_OverrideWasUpdated = false;
		internal System.Data.SqlTypes.SqlBoolean col_Pourcent_Sec_Producteur_Override = System.Data.SqlTypes.SqlBoolean.Null;
		public System.Data.SqlTypes.SqlBoolean Col_Pourcent_Sec_Producteur_Override {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Pourcent_Sec_Producteur_Override);
			}
			set {
			
				this.col_Pourcent_Sec_Producteur_OverrideWasUpdated = true;
				this.col_Pourcent_Sec_Producteur_OverrideWasSet = true;
				this.col_Pourcent_Sec_Producteur_Override = value;
			}
		}

		internal bool col_TMA_ProducteurWasSet = false;
		private bool col_TMA_ProducteurWasUpdated = false;
		internal System.Data.SqlTypes.SqlDouble col_TMA_Producteur = System.Data.SqlTypes.SqlDouble.Null;
		public System.Data.SqlTypes.SqlDouble Col_TMA_Producteur {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_TMA_Producteur);
			}
			set {
			
				this.col_TMA_ProducteurWasUpdated = true;
				this.col_TMA_ProducteurWasSet = true;
				this.col_TMA_Producteur = value;
			}
		}

		internal bool col_Pourcent_Sec_TransportWasSet = false;
		private bool col_Pourcent_Sec_TransportWasUpdated = false;
		internal System.Data.SqlTypes.SqlDouble col_Pourcent_Sec_Transport = System.Data.SqlTypes.SqlDouble.Null;
		public System.Data.SqlTypes.SqlDouble Col_Pourcent_Sec_Transport {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Pourcent_Sec_Transport);
			}
			set {
			
				this.col_Pourcent_Sec_TransportWasUpdated = true;
				this.col_Pourcent_Sec_TransportWasSet = true;
				this.col_Pourcent_Sec_Transport = value;
			}
		}

		internal bool col_Pourcent_Sec_Transport_OverrideWasSet = false;
		private bool col_Pourcent_Sec_Transport_OverrideWasUpdated = false;
		internal System.Data.SqlTypes.SqlBoolean col_Pourcent_Sec_Transport_Override = System.Data.SqlTypes.SqlBoolean.Null;
		public System.Data.SqlTypes.SqlBoolean Col_Pourcent_Sec_Transport_Override {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Pourcent_Sec_Transport_Override);
			}
			set {
			
				this.col_Pourcent_Sec_Transport_OverrideWasUpdated = true;
				this.col_Pourcent_Sec_Transport_OverrideWasSet = true;
				this.col_Pourcent_Sec_Transport_Override = value;
			}
		}

		internal bool col_TMA_TransportWasSet = false;
		private bool col_TMA_TransportWasUpdated = false;
		internal System.Data.SqlTypes.SqlDouble col_TMA_Transport = System.Data.SqlTypes.SqlDouble.Null;
		public System.Data.SqlTypes.SqlDouble Col_TMA_Transport {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_TMA_Transport);
			}
			set {
			
				this.col_TMA_TransportWasUpdated = true;
				this.col_TMA_TransportWasSet = true;
				this.col_TMA_Transport = value;
			}
		}

		internal bool col_IsTMAWasSet = false;
		private bool col_IsTMAWasUpdated = false;
		internal System.Data.SqlTypes.SqlBoolean col_IsTMA = System.Data.SqlTypes.SqlBoolean.Null;
		public System.Data.SqlTypes.SqlBoolean Col_IsTMA {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_IsTMA);
			}
			set {
			
				this.col_IsTMAWasUpdated = true;
				this.col_IsTMAWasSet = true;
				this.col_IsTMA = value;
			}
		}

		internal bool col_SuspendrePaiementWasSet = false;
		private bool col_SuspendrePaiementWasUpdated = false;
		internal System.Data.SqlTypes.SqlBoolean col_SuspendrePaiement = System.Data.SqlTypes.SqlBoolean.Null;
		public System.Data.SqlTypes.SqlBoolean Col_SuspendrePaiement {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_SuspendrePaiement);
			}
			set {
			
				this.col_SuspendrePaiementWasUpdated = true;
				this.col_SuspendrePaiementWasSet = true;
				this.col_SuspendrePaiement = value;
			}
		}

		internal bool col_BonCommandeWasSet = false;
		private bool col_BonCommandeWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_BonCommande = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_BonCommande {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_BonCommande);
			}
			set {
			
				this.col_BonCommandeWasUpdated = true;
				this.col_BonCommandeWasSet = true;
				this.col_BonCommande = value;
			}
		}


		public bool Refresh() {

			this.displayName = null;

			this.col_DateLivraisonWasUpdated = false;
			this.col_DateLivraisonWasSet = false;
			this.col_DateLivraison = System.Data.SqlTypes.SqlDateTime.Null;

			this.col_DatePayeWasUpdated = false;
			this.col_DatePayeWasSet = false;
			this.col_DatePaye = System.Data.SqlTypes.SqlDateTime.Null;

			this.col_ContratIDWasUpdated = false;
			this.col_ContratIDWasSet = false;
			this.col_ContratID = System.Data.SqlTypes.SqlString.Null;

			this.col_UniteMesureIDWasUpdated = false;
			this.col_UniteMesureIDWasSet = false;
			this.col_UniteMesureID = System.Data.SqlTypes.SqlString.Null;

			this.col_EssenceIDWasUpdated = false;
			this.col_EssenceIDWasSet = false;
			this.col_EssenceID = System.Data.SqlTypes.SqlString.Null;

			this.col_SciageWasUpdated = false;
			this.col_SciageWasSet = false;
			this.col_Sciage = System.Data.SqlTypes.SqlBoolean.Null;

			this.col_NumeroFactureUsineWasUpdated = false;
			this.col_NumeroFactureUsineWasSet = false;
			this.col_NumeroFactureUsine = System.Data.SqlTypes.SqlString.Null;

			this.col_DroitCoupeIDWasUpdated = false;
			this.col_DroitCoupeIDWasSet = false;
			this.col_DroitCoupeID = System.Data.SqlTypes.SqlString.Null;

			this.col_EntentePaiementIDWasUpdated = false;
			this.col_EntentePaiementIDWasSet = false;
			this.col_EntentePaiementID = System.Data.SqlTypes.SqlString.Null;

			this.col_TransporteurIDWasUpdated = false;
			this.col_TransporteurIDWasSet = false;
			this.col_TransporteurID = System.Data.SqlTypes.SqlString.Null;

			this.col_VRWasUpdated = false;
			this.col_VRWasSet = false;
			this.col_VR = System.Data.SqlTypes.SqlString.Null;

			this.col_MasseLimiteWasUpdated = false;
			this.col_MasseLimiteWasSet = false;
			this.col_MasseLimite = System.Data.SqlTypes.SqlDouble.Null;

			this.col_VolumeBrutWasUpdated = false;
			this.col_VolumeBrutWasSet = false;
			this.col_VolumeBrut = System.Data.SqlTypes.SqlDouble.Null;

			this.col_VolumeTareWasUpdated = false;
			this.col_VolumeTareWasSet = false;
			this.col_VolumeTare = System.Data.SqlTypes.SqlDouble.Null;

			this.col_VolumeTransporteWasUpdated = false;
			this.col_VolumeTransporteWasSet = false;
			this.col_VolumeTransporte = System.Data.SqlTypes.SqlDouble.Null;

			this.col_VolumeSurchargeWasUpdated = false;
			this.col_VolumeSurchargeWasSet = false;
			this.col_VolumeSurcharge = System.Data.SqlTypes.SqlDouble.Null;

			this.col_VolumeAPayerWasUpdated = false;
			this.col_VolumeAPayerWasSet = false;
			this.col_VolumeAPayer = System.Data.SqlTypes.SqlDouble.Null;

			this.col_AnneeWasUpdated = false;
			this.col_AnneeWasSet = false;
			this.col_Annee = System.Data.SqlTypes.SqlInt32.Null;

			this.col_PeriodeWasUpdated = false;
			this.col_PeriodeWasSet = false;
			this.col_Periode = System.Data.SqlTypes.SqlInt32.Null;

			this.col_DateCalculWasUpdated = false;
			this.col_DateCalculWasSet = false;
			this.col_DateCalcul = System.Data.SqlTypes.SqlDateTime.Null;

			this.col_Taux_TransporteurWasUpdated = false;
			this.col_Taux_TransporteurWasSet = false;
			this.col_Taux_Transporteur = System.Data.SqlTypes.SqlDouble.Null;

			this.col_Montant_TransporteurWasUpdated = false;
			this.col_Montant_TransporteurWasSet = false;
			this.col_Montant_Transporteur = System.Data.SqlTypes.SqlDouble.Null;

			this.col_Montant_UsineWasUpdated = false;
			this.col_Montant_UsineWasSet = false;
			this.col_Montant_Usine = System.Data.SqlTypes.SqlDouble.Null;

			this.col_Montant_Producteur1WasUpdated = false;
			this.col_Montant_Producteur1WasSet = false;
			this.col_Montant_Producteur1 = System.Data.SqlTypes.SqlDouble.Null;

			this.col_Montant_Producteur2WasUpdated = false;
			this.col_Montant_Producteur2WasSet = false;
			this.col_Montant_Producteur2 = System.Data.SqlTypes.SqlDouble.Null;

			this.col_Montant_Preleve_Plan_ConjointWasUpdated = false;
			this.col_Montant_Preleve_Plan_ConjointWasSet = false;
			this.col_Montant_Preleve_Plan_Conjoint = System.Data.SqlTypes.SqlDouble.Null;

			this.col_Montant_Preleve_Fond_RoulementWasUpdated = false;
			this.col_Montant_Preleve_Fond_RoulementWasSet = false;
			this.col_Montant_Preleve_Fond_Roulement = System.Data.SqlTypes.SqlDouble.Null;

			this.col_Montant_Preleve_Fond_ForestierWasUpdated = false;
			this.col_Montant_Preleve_Fond_ForestierWasSet = false;
			this.col_Montant_Preleve_Fond_Forestier = System.Data.SqlTypes.SqlDouble.Null;

			this.col_Montant_Preleve_DiversWasUpdated = false;
			this.col_Montant_Preleve_DiversWasSet = false;
			this.col_Montant_Preleve_Divers = System.Data.SqlTypes.SqlDouble.Null;

			this.col_Montant_SurchargeWasUpdated = false;
			this.col_Montant_SurchargeWasSet = false;
			this.col_Montant_Surcharge = System.Data.SqlTypes.SqlDouble.Null;

			this.col_Montant_MiseEnCommunWasUpdated = false;
			this.col_Montant_MiseEnCommunWasSet = false;
			this.col_Montant_MiseEnCommun = System.Data.SqlTypes.SqlSingle.Null;

			this.col_FactureWasUpdated = false;
			this.col_FactureWasSet = false;
			this.col_Facture = System.Data.SqlTypes.SqlBoolean.Null;

			this.col_Producteur1_FactureIDWasUpdated = false;
			this.col_Producteur1_FactureIDWasSet = false;
			this.col_Producteur1_FactureID = System.Data.SqlTypes.SqlInt32.Null;

			this.col_Producteur2_FactureIDWasUpdated = false;
			this.col_Producteur2_FactureIDWasSet = false;
			this.col_Producteur2_FactureID = System.Data.SqlTypes.SqlInt32.Null;

			this.col_Transporteur_FactureIDWasUpdated = false;
			this.col_Transporteur_FactureIDWasSet = false;
			this.col_Transporteur_FactureID = System.Data.SqlTypes.SqlInt32.Null;

			this.col_Usine_FactureIDWasUpdated = false;
			this.col_Usine_FactureIDWasSet = false;
			this.col_Usine_FactureID = System.Data.SqlTypes.SqlInt32.Null;

			this.col_ErreurCalculWasUpdated = false;
			this.col_ErreurCalculWasSet = false;
			this.col_ErreurCalcul = System.Data.SqlTypes.SqlBoolean.Null;

			this.col_ErreurDescriptionWasUpdated = false;
			this.col_ErreurDescriptionWasSet = false;
			this.col_ErreurDescription = System.Data.SqlTypes.SqlString.Null;

			this.col_LotIDWasUpdated = false;
			this.col_LotIDWasSet = false;
			this.col_LotID = System.Data.SqlTypes.SqlInt32.Null;

			this.col_Taux_Transporteur_OverrideWasUpdated = false;
			this.col_Taux_Transporteur_OverrideWasSet = false;
			this.col_Taux_Transporteur_Override = System.Data.SqlTypes.SqlBoolean.Null;

			this.col_PaieTransporteurWasUpdated = false;
			this.col_PaieTransporteurWasSet = false;
			this.col_PaieTransporteur = System.Data.SqlTypes.SqlBoolean.Null;

			this.col_VolumeSurcharge_OverrideWasUpdated = false;
			this.col_VolumeSurcharge_OverrideWasSet = false;
			this.col_VolumeSurcharge_Override = System.Data.SqlTypes.SqlBoolean.Null;

			this.col_SurchargeManuelWasUpdated = false;
			this.col_SurchargeManuelWasSet = false;
			this.col_SurchargeManuel = System.Data.SqlTypes.SqlBoolean.Null;

			this.col_CodeWasUpdated = false;
			this.col_CodeWasSet = false;
			this.col_Code = System.Data.SqlTypes.SqlString.Null;

			this.col_NombrePermisWasUpdated = false;
			this.col_NombrePermisWasSet = false;
			this.col_NombrePermis = System.Data.SqlTypes.SqlInt32.Null;

			this.col_ZoneIDWasUpdated = false;
			this.col_ZoneIDWasSet = false;
			this.col_ZoneID = System.Data.SqlTypes.SqlString.Null;

			this.col_MunicipaliteIDWasUpdated = false;
			this.col_MunicipaliteIDWasSet = false;
			this.col_MunicipaliteID = System.Data.SqlTypes.SqlString.Null;

			this.col_ChargeurIDWasUpdated = false;
			this.col_ChargeurIDWasSet = false;
			this.col_ChargeurID = System.Data.SqlTypes.SqlString.Null;

			this.col_Montant_ChargeurWasUpdated = false;
			this.col_Montant_ChargeurWasSet = false;
			this.col_Montant_Chargeur = System.Data.SqlTypes.SqlDouble.Null;

			this.col_Frais_ChargeurAuProducteurWasUpdated = false;
			this.col_Frais_ChargeurAuProducteurWasSet = false;
			this.col_Frais_ChargeurAuProducteur = System.Data.SqlTypes.SqlDouble.Null;

			this.col_Frais_ChargeurAuTransporteurWasUpdated = false;
			this.col_Frais_ChargeurAuTransporteurWasSet = false;
			this.col_Frais_ChargeurAuTransporteur = System.Data.SqlTypes.SqlDouble.Null;

			this.col_Frais_AutresAuProducteurWasUpdated = false;
			this.col_Frais_AutresAuProducteurWasSet = false;
			this.col_Frais_AutresAuProducteur = System.Data.SqlTypes.SqlDouble.Null;

			this.col_Frais_AutresAuProducteurDescriptionWasUpdated = false;
			this.col_Frais_AutresAuProducteurDescriptionWasSet = false;
			this.col_Frais_AutresAuProducteurDescription = System.Data.SqlTypes.SqlString.Null;

			this.col_Frais_AutresAuProducteurTransportSciageWasUpdated = false;
			this.col_Frais_AutresAuProducteurTransportSciageWasSet = false;
			this.col_Frais_AutresAuProducteurTransportSciage = System.Data.SqlTypes.SqlDouble.Null;

			this.col_Frais_AutresAuTransporteurWasUpdated = false;
			this.col_Frais_AutresAuTransporteurWasSet = false;
			this.col_Frais_AutresAuTransporteur = System.Data.SqlTypes.SqlDouble.Null;

			this.col_Frais_AutresAuTransporteurDescriptionWasUpdated = false;
			this.col_Frais_AutresAuTransporteurDescriptionWasSet = false;
			this.col_Frais_AutresAuTransporteurDescription = System.Data.SqlTypes.SqlString.Null;

			this.col_Frais_CompensationDeDeplacementWasUpdated = false;
			this.col_Frais_CompensationDeDeplacementWasSet = false;
			this.col_Frais_CompensationDeDeplacement = System.Data.SqlTypes.SqlDouble.Null;

			this.col_Chargeur_FactureIDWasUpdated = false;
			this.col_Chargeur_FactureIDWasSet = false;
			this.col_Chargeur_FactureID = System.Data.SqlTypes.SqlInt32.Null;

			this.col_Commentaires_ProducteurWasUpdated = false;
			this.col_Commentaires_ProducteurWasSet = false;
			this.col_Commentaires_Producteur = System.Data.SqlTypes.SqlString.Null;

			this.col_Commentaires_TransporteurWasUpdated = false;
			this.col_Commentaires_TransporteurWasSet = false;
			this.col_Commentaires_Transporteur = System.Data.SqlTypes.SqlString.Null;

			this.col_Commentaires_ChargeurWasUpdated = false;
			this.col_Commentaires_ChargeurWasSet = false;
			this.col_Commentaires_Chargeur = System.Data.SqlTypes.SqlString.Null;

			this.col_TauxChargeurAuProducteurWasUpdated = false;
			this.col_TauxChargeurAuProducteurWasSet = false;
			this.col_TauxChargeurAuProducteur = System.Data.SqlTypes.SqlDouble.Null;

			this.col_TauxChargeurAuTransporteurWasUpdated = false;
			this.col_TauxChargeurAuTransporteurWasSet = false;
			this.col_TauxChargeurAuTransporteur = System.Data.SqlTypes.SqlDouble.Null;

			this.col_Frais_AutresRevenusTransporteurWasUpdated = false;
			this.col_Frais_AutresRevenusTransporteurWasSet = false;
			this.col_Frais_AutresRevenusTransporteur = System.Data.SqlTypes.SqlDouble.Null;

			this.col_Frais_AutresRevenusTransporteurDescriptionWasUpdated = false;
			this.col_Frais_AutresRevenusTransporteurDescriptionWasSet = false;
			this.col_Frais_AutresRevenusTransporteurDescription = System.Data.SqlTypes.SqlString.Null;

			this.col_Frais_AutresRevenusProducteurWasUpdated = false;
			this.col_Frais_AutresRevenusProducteurWasSet = false;
			this.col_Frais_AutresRevenusProducteur = System.Data.SqlTypes.SqlDouble.Null;

			this.col_Frais_AutresRevenusProducteurDescriptionWasUpdated = false;
			this.col_Frais_AutresRevenusProducteurDescriptionWasSet = false;
			this.col_Frais_AutresRevenusProducteurDescription = System.Data.SqlTypes.SqlString.Null;

			this.col_Montant_SurchargeProducteurWasUpdated = false;
			this.col_Montant_SurchargeProducteurWasSet = false;
			this.col_Montant_SurchargeProducteur = System.Data.SqlTypes.SqlDouble.Null;

			this.col_KgVert_BrutWasUpdated = false;
			this.col_KgVert_BrutWasSet = false;
			this.col_KgVert_Brut = System.Data.SqlTypes.SqlInt32.Null;

			this.col_KgVert_TareWasUpdated = false;
			this.col_KgVert_TareWasSet = false;
			this.col_KgVert_Tare = System.Data.SqlTypes.SqlInt32.Null;

			this.col_KgVert_NetWasUpdated = false;
			this.col_KgVert_NetWasSet = false;
			this.col_KgVert_Net = System.Data.SqlTypes.SqlInt32.Null;

			this.col_KgVert_RejetsWasUpdated = false;
			this.col_KgVert_RejetsWasSet = false;
			this.col_KgVert_Rejets = System.Data.SqlTypes.SqlInt32.Null;

			this.col_KgVert_PayeWasUpdated = false;
			this.col_KgVert_PayeWasSet = false;
			this.col_KgVert_Paye = System.Data.SqlTypes.SqlInt32.Null;

			this.col_Pourcent_Sec_ProducteurWasUpdated = false;
			this.col_Pourcent_Sec_ProducteurWasSet = false;
			this.col_Pourcent_Sec_Producteur = System.Data.SqlTypes.SqlDouble.Null;

			this.col_Pourcent_Sec_Producteur_OverrideWasUpdated = false;
			this.col_Pourcent_Sec_Producteur_OverrideWasSet = false;
			this.col_Pourcent_Sec_Producteur_Override = System.Data.SqlTypes.SqlBoolean.Null;

			this.col_TMA_ProducteurWasUpdated = false;
			this.col_TMA_ProducteurWasSet = false;
			this.col_TMA_Producteur = System.Data.SqlTypes.SqlDouble.Null;

			this.col_Pourcent_Sec_TransportWasUpdated = false;
			this.col_Pourcent_Sec_TransportWasSet = false;
			this.col_Pourcent_Sec_Transport = System.Data.SqlTypes.SqlDouble.Null;

			this.col_Pourcent_Sec_Transport_OverrideWasUpdated = false;
			this.col_Pourcent_Sec_Transport_OverrideWasSet = false;
			this.col_Pourcent_Sec_Transport_Override = System.Data.SqlTypes.SqlBoolean.Null;

			this.col_TMA_TransportWasUpdated = false;
			this.col_TMA_TransportWasSet = false;
			this.col_TMA_Transport = System.Data.SqlTypes.SqlDouble.Null;

			this.col_IsTMAWasUpdated = false;
			this.col_IsTMAWasSet = false;
			this.col_IsTMA = System.Data.SqlTypes.SqlBoolean.Null;

			this.col_SuspendrePaiementWasUpdated = false;
			this.col_SuspendrePaiementWasSet = false;
			this.col_SuspendrePaiement = System.Data.SqlTypes.SqlBoolean.Null;

			this.col_BonCommandeWasUpdated = false;
			this.col_BonCommandeWasSet = false;
			this.col_BonCommande = System.Data.SqlTypes.SqlString.Null;

			Params.spS_Livraison Param = new Params.spS_Livraison(true);
			Param.SetUpConnection(this.connectionString);

			if (!this.col_ID.IsNull) {

				Param.Param_ID = this.col_ID;
			}


			System.Data.SqlClient.SqlDataReader sqlDataReader = null;
			SPs.spS_Livraison Sp = new SPs.spS_Livraison();
			if (Sp.Execute(ref Param, out sqlDataReader)) {

				if (sqlDataReader.Read()) {

					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_DateLivraison.ColumnIndex)) {

						this.col_DateLivraison = sqlDataReader.GetSqlDateTime(SPs.spS_Livraison.Resultset1.Fields.Column_DateLivraison.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_DatePaye.ColumnIndex)) {

						this.col_DatePaye = sqlDataReader.GetSqlDateTime(SPs.spS_Livraison.Resultset1.Fields.Column_DatePaye.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_ContratID.ColumnIndex)) {

						this.col_ContratID = sqlDataReader.GetSqlString(SPs.spS_Livraison.Resultset1.Fields.Column_ContratID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_UniteMesureID.ColumnIndex)) {

						this.col_UniteMesureID = sqlDataReader.GetSqlString(SPs.spS_Livraison.Resultset1.Fields.Column_UniteMesureID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_EssenceID.ColumnIndex)) {

						this.col_EssenceID = sqlDataReader.GetSqlString(SPs.spS_Livraison.Resultset1.Fields.Column_EssenceID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_Sciage.ColumnIndex)) {

						this.col_Sciage = sqlDataReader.GetSqlBoolean(SPs.spS_Livraison.Resultset1.Fields.Column_Sciage.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_NumeroFactureUsine.ColumnIndex)) {

						this.col_NumeroFactureUsine = sqlDataReader.GetSqlString(SPs.spS_Livraison.Resultset1.Fields.Column_NumeroFactureUsine.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_DroitCoupeID.ColumnIndex)) {

						this.col_DroitCoupeID = sqlDataReader.GetSqlString(SPs.spS_Livraison.Resultset1.Fields.Column_DroitCoupeID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_EntentePaiementID.ColumnIndex)) {

						this.col_EntentePaiementID = sqlDataReader.GetSqlString(SPs.spS_Livraison.Resultset1.Fields.Column_EntentePaiementID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_TransporteurID.ColumnIndex)) {

						this.col_TransporteurID = sqlDataReader.GetSqlString(SPs.spS_Livraison.Resultset1.Fields.Column_TransporteurID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_VR.ColumnIndex)) {

						this.col_VR = sqlDataReader.GetSqlString(SPs.spS_Livraison.Resultset1.Fields.Column_VR.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_MasseLimite.ColumnIndex)) {

						this.col_MasseLimite = sqlDataReader.GetSqlDouble(SPs.spS_Livraison.Resultset1.Fields.Column_MasseLimite.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_VolumeBrut.ColumnIndex)) {

						this.col_VolumeBrut = sqlDataReader.GetSqlDouble(SPs.spS_Livraison.Resultset1.Fields.Column_VolumeBrut.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_VolumeTare.ColumnIndex)) {

						this.col_VolumeTare = sqlDataReader.GetSqlDouble(SPs.spS_Livraison.Resultset1.Fields.Column_VolumeTare.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_VolumeTransporte.ColumnIndex)) {

						this.col_VolumeTransporte = sqlDataReader.GetSqlDouble(SPs.spS_Livraison.Resultset1.Fields.Column_VolumeTransporte.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_VolumeSurcharge.ColumnIndex)) {

						this.col_VolumeSurcharge = sqlDataReader.GetSqlDouble(SPs.spS_Livraison.Resultset1.Fields.Column_VolumeSurcharge.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_VolumeAPayer.ColumnIndex)) {

						this.col_VolumeAPayer = sqlDataReader.GetSqlDouble(SPs.spS_Livraison.Resultset1.Fields.Column_VolumeAPayer.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_Annee.ColumnIndex)) {

						this.col_Annee = sqlDataReader.GetSqlInt32(SPs.spS_Livraison.Resultset1.Fields.Column_Annee.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_Periode.ColumnIndex)) {

						this.col_Periode = sqlDataReader.GetSqlInt32(SPs.spS_Livraison.Resultset1.Fields.Column_Periode.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_DateCalcul.ColumnIndex)) {

						this.col_DateCalcul = sqlDataReader.GetSqlDateTime(SPs.spS_Livraison.Resultset1.Fields.Column_DateCalcul.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_Taux_Transporteur.ColumnIndex)) {

						this.col_Taux_Transporteur = sqlDataReader.GetSqlDouble(SPs.spS_Livraison.Resultset1.Fields.Column_Taux_Transporteur.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_Montant_Transporteur.ColumnIndex)) {

						this.col_Montant_Transporteur = sqlDataReader.GetSqlDouble(SPs.spS_Livraison.Resultset1.Fields.Column_Montant_Transporteur.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_Montant_Usine.ColumnIndex)) {

						this.col_Montant_Usine = sqlDataReader.GetSqlDouble(SPs.spS_Livraison.Resultset1.Fields.Column_Montant_Usine.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_Montant_Producteur1.ColumnIndex)) {

						this.col_Montant_Producteur1 = sqlDataReader.GetSqlDouble(SPs.spS_Livraison.Resultset1.Fields.Column_Montant_Producteur1.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_Montant_Producteur2.ColumnIndex)) {

						this.col_Montant_Producteur2 = sqlDataReader.GetSqlDouble(SPs.spS_Livraison.Resultset1.Fields.Column_Montant_Producteur2.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_Montant_Preleve_Plan_Conjoint.ColumnIndex)) {

						this.col_Montant_Preleve_Plan_Conjoint = sqlDataReader.GetSqlDouble(SPs.spS_Livraison.Resultset1.Fields.Column_Montant_Preleve_Plan_Conjoint.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_Montant_Preleve_Fond_Roulement.ColumnIndex)) {

						this.col_Montant_Preleve_Fond_Roulement = sqlDataReader.GetSqlDouble(SPs.spS_Livraison.Resultset1.Fields.Column_Montant_Preleve_Fond_Roulement.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_Montant_Preleve_Fond_Forestier.ColumnIndex)) {

						this.col_Montant_Preleve_Fond_Forestier = sqlDataReader.GetSqlDouble(SPs.spS_Livraison.Resultset1.Fields.Column_Montant_Preleve_Fond_Forestier.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_Montant_Preleve_Divers.ColumnIndex)) {

						this.col_Montant_Preleve_Divers = sqlDataReader.GetSqlDouble(SPs.spS_Livraison.Resultset1.Fields.Column_Montant_Preleve_Divers.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_Montant_Surcharge.ColumnIndex)) {

						this.col_Montant_Surcharge = sqlDataReader.GetSqlDouble(SPs.spS_Livraison.Resultset1.Fields.Column_Montant_Surcharge.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_Montant_MiseEnCommun.ColumnIndex)) {

						this.col_Montant_MiseEnCommun = sqlDataReader.GetSqlSingle(SPs.spS_Livraison.Resultset1.Fields.Column_Montant_MiseEnCommun.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_Facture.ColumnIndex)) {

						this.col_Facture = sqlDataReader.GetSqlBoolean(SPs.spS_Livraison.Resultset1.Fields.Column_Facture.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_Producteur1_FactureID.ColumnIndex)) {

						this.col_Producteur1_FactureID = sqlDataReader.GetSqlInt32(SPs.spS_Livraison.Resultset1.Fields.Column_Producteur1_FactureID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_Producteur2_FactureID.ColumnIndex)) {

						this.col_Producteur2_FactureID = sqlDataReader.GetSqlInt32(SPs.spS_Livraison.Resultset1.Fields.Column_Producteur2_FactureID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_Transporteur_FactureID.ColumnIndex)) {

						this.col_Transporteur_FactureID = sqlDataReader.GetSqlInt32(SPs.spS_Livraison.Resultset1.Fields.Column_Transporteur_FactureID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_Usine_FactureID.ColumnIndex)) {

						this.col_Usine_FactureID = sqlDataReader.GetSqlInt32(SPs.spS_Livraison.Resultset1.Fields.Column_Usine_FactureID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_ErreurCalcul.ColumnIndex)) {

						this.col_ErreurCalcul = sqlDataReader.GetSqlBoolean(SPs.spS_Livraison.Resultset1.Fields.Column_ErreurCalcul.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_ErreurDescription.ColumnIndex)) {

						this.col_ErreurDescription = sqlDataReader.GetSqlString(SPs.spS_Livraison.Resultset1.Fields.Column_ErreurDescription.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_LotID.ColumnIndex)) {

						this.col_LotID = sqlDataReader.GetSqlInt32(SPs.spS_Livraison.Resultset1.Fields.Column_LotID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_Taux_Transporteur_Override.ColumnIndex)) {

						this.col_Taux_Transporteur_Override = sqlDataReader.GetSqlBoolean(SPs.spS_Livraison.Resultset1.Fields.Column_Taux_Transporteur_Override.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_PaieTransporteur.ColumnIndex)) {

						this.col_PaieTransporteur = sqlDataReader.GetSqlBoolean(SPs.spS_Livraison.Resultset1.Fields.Column_PaieTransporteur.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_VolumeSurcharge_Override.ColumnIndex)) {

						this.col_VolumeSurcharge_Override = sqlDataReader.GetSqlBoolean(SPs.spS_Livraison.Resultset1.Fields.Column_VolumeSurcharge_Override.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_SurchargeManuel.ColumnIndex)) {

						this.col_SurchargeManuel = sqlDataReader.GetSqlBoolean(SPs.spS_Livraison.Resultset1.Fields.Column_SurchargeManuel.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_Code.ColumnIndex)) {

						this.col_Code = sqlDataReader.GetSqlString(SPs.spS_Livraison.Resultset1.Fields.Column_Code.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_NombrePermis.ColumnIndex)) {

						this.col_NombrePermis = sqlDataReader.GetSqlInt32(SPs.spS_Livraison.Resultset1.Fields.Column_NombrePermis.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_ZoneID.ColumnIndex)) {

						this.col_ZoneID = sqlDataReader.GetSqlString(SPs.spS_Livraison.Resultset1.Fields.Column_ZoneID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_MunicipaliteID.ColumnIndex)) {

						this.col_MunicipaliteID = sqlDataReader.GetSqlString(SPs.spS_Livraison.Resultset1.Fields.Column_MunicipaliteID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_ChargeurID.ColumnIndex)) {

						this.col_ChargeurID = sqlDataReader.GetSqlString(SPs.spS_Livraison.Resultset1.Fields.Column_ChargeurID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_Montant_Chargeur.ColumnIndex)) {

						this.col_Montant_Chargeur = sqlDataReader.GetSqlDouble(SPs.spS_Livraison.Resultset1.Fields.Column_Montant_Chargeur.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_Frais_ChargeurAuProducteur.ColumnIndex)) {

						this.col_Frais_ChargeurAuProducteur = sqlDataReader.GetSqlDouble(SPs.spS_Livraison.Resultset1.Fields.Column_Frais_ChargeurAuProducteur.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_Frais_ChargeurAuTransporteur.ColumnIndex)) {

						this.col_Frais_ChargeurAuTransporteur = sqlDataReader.GetSqlDouble(SPs.spS_Livraison.Resultset1.Fields.Column_Frais_ChargeurAuTransporteur.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_Frais_AutresAuProducteur.ColumnIndex)) {

						this.col_Frais_AutresAuProducteur = sqlDataReader.GetSqlDouble(SPs.spS_Livraison.Resultset1.Fields.Column_Frais_AutresAuProducteur.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_Frais_AutresAuProducteurDescription.ColumnIndex)) {

						this.col_Frais_AutresAuProducteurDescription = sqlDataReader.GetSqlString(SPs.spS_Livraison.Resultset1.Fields.Column_Frais_AutresAuProducteurDescription.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_Frais_AutresAuProducteurTransportSciage.ColumnIndex)) {

						this.col_Frais_AutresAuProducteurTransportSciage = sqlDataReader.GetSqlDouble(SPs.spS_Livraison.Resultset1.Fields.Column_Frais_AutresAuProducteurTransportSciage.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_Frais_AutresAuTransporteur.ColumnIndex)) {

						this.col_Frais_AutresAuTransporteur = sqlDataReader.GetSqlDouble(SPs.spS_Livraison.Resultset1.Fields.Column_Frais_AutresAuTransporteur.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_Frais_AutresAuTransporteurDescription.ColumnIndex)) {

						this.col_Frais_AutresAuTransporteurDescription = sqlDataReader.GetSqlString(SPs.spS_Livraison.Resultset1.Fields.Column_Frais_AutresAuTransporteurDescription.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_Frais_CompensationDeDeplacement.ColumnIndex)) {

						this.col_Frais_CompensationDeDeplacement = sqlDataReader.GetSqlDouble(SPs.spS_Livraison.Resultset1.Fields.Column_Frais_CompensationDeDeplacement.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_Chargeur_FactureID.ColumnIndex)) {

						this.col_Chargeur_FactureID = sqlDataReader.GetSqlInt32(SPs.spS_Livraison.Resultset1.Fields.Column_Chargeur_FactureID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_Commentaires_Producteur.ColumnIndex)) {

						this.col_Commentaires_Producteur = sqlDataReader.GetSqlString(SPs.spS_Livraison.Resultset1.Fields.Column_Commentaires_Producteur.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_Commentaires_Transporteur.ColumnIndex)) {

						this.col_Commentaires_Transporteur = sqlDataReader.GetSqlString(SPs.spS_Livraison.Resultset1.Fields.Column_Commentaires_Transporteur.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_Commentaires_Chargeur.ColumnIndex)) {

						this.col_Commentaires_Chargeur = sqlDataReader.GetSqlString(SPs.spS_Livraison.Resultset1.Fields.Column_Commentaires_Chargeur.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_TauxChargeurAuProducteur.ColumnIndex)) {

						this.col_TauxChargeurAuProducteur = sqlDataReader.GetSqlDouble(SPs.spS_Livraison.Resultset1.Fields.Column_TauxChargeurAuProducteur.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_TauxChargeurAuTransporteur.ColumnIndex)) {

						this.col_TauxChargeurAuTransporteur = sqlDataReader.GetSqlDouble(SPs.spS_Livraison.Resultset1.Fields.Column_TauxChargeurAuTransporteur.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_Frais_AutresRevenusTransporteur.ColumnIndex)) {

						this.col_Frais_AutresRevenusTransporteur = sqlDataReader.GetSqlDouble(SPs.spS_Livraison.Resultset1.Fields.Column_Frais_AutresRevenusTransporteur.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_Frais_AutresRevenusTransporteurDescription.ColumnIndex)) {

						this.col_Frais_AutresRevenusTransporteurDescription = sqlDataReader.GetSqlString(SPs.spS_Livraison.Resultset1.Fields.Column_Frais_AutresRevenusTransporteurDescription.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_Frais_AutresRevenusProducteur.ColumnIndex)) {

						this.col_Frais_AutresRevenusProducteur = sqlDataReader.GetSqlDouble(SPs.spS_Livraison.Resultset1.Fields.Column_Frais_AutresRevenusProducteur.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_Frais_AutresRevenusProducteurDescription.ColumnIndex)) {

						this.col_Frais_AutresRevenusProducteurDescription = sqlDataReader.GetSqlString(SPs.spS_Livraison.Resultset1.Fields.Column_Frais_AutresRevenusProducteurDescription.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_Montant_SurchargeProducteur.ColumnIndex)) {

						this.col_Montant_SurchargeProducteur = sqlDataReader.GetSqlDouble(SPs.spS_Livraison.Resultset1.Fields.Column_Montant_SurchargeProducteur.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_KgVert_Brut.ColumnIndex)) {

						this.col_KgVert_Brut = sqlDataReader.GetSqlInt32(SPs.spS_Livraison.Resultset1.Fields.Column_KgVert_Brut.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_KgVert_Tare.ColumnIndex)) {

						this.col_KgVert_Tare = sqlDataReader.GetSqlInt32(SPs.spS_Livraison.Resultset1.Fields.Column_KgVert_Tare.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_KgVert_Net.ColumnIndex)) {

						this.col_KgVert_Net = sqlDataReader.GetSqlInt32(SPs.spS_Livraison.Resultset1.Fields.Column_KgVert_Net.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_KgVert_Rejets.ColumnIndex)) {

						this.col_KgVert_Rejets = sqlDataReader.GetSqlInt32(SPs.spS_Livraison.Resultset1.Fields.Column_KgVert_Rejets.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_KgVert_Paye.ColumnIndex)) {

						this.col_KgVert_Paye = sqlDataReader.GetSqlInt32(SPs.spS_Livraison.Resultset1.Fields.Column_KgVert_Paye.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_Pourcent_Sec_Producteur.ColumnIndex)) {

						this.col_Pourcent_Sec_Producteur = sqlDataReader.GetSqlDouble(SPs.spS_Livraison.Resultset1.Fields.Column_Pourcent_Sec_Producteur.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_Pourcent_Sec_Producteur_Override.ColumnIndex)) {

						this.col_Pourcent_Sec_Producteur_Override = sqlDataReader.GetSqlBoolean(SPs.spS_Livraison.Resultset1.Fields.Column_Pourcent_Sec_Producteur_Override.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_TMA_Producteur.ColumnIndex)) {

						this.col_TMA_Producteur = sqlDataReader.GetSqlDouble(SPs.spS_Livraison.Resultset1.Fields.Column_TMA_Producteur.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_Pourcent_Sec_Transport.ColumnIndex)) {

						this.col_Pourcent_Sec_Transport = sqlDataReader.GetSqlDouble(SPs.spS_Livraison.Resultset1.Fields.Column_Pourcent_Sec_Transport.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_Pourcent_Sec_Transport_Override.ColumnIndex)) {

						this.col_Pourcent_Sec_Transport_Override = sqlDataReader.GetSqlBoolean(SPs.spS_Livraison.Resultset1.Fields.Column_Pourcent_Sec_Transport_Override.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_TMA_Transport.ColumnIndex)) {

						this.col_TMA_Transport = sqlDataReader.GetSqlDouble(SPs.spS_Livraison.Resultset1.Fields.Column_TMA_Transport.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_IsTMA.ColumnIndex)) {

						this.col_IsTMA = sqlDataReader.GetSqlBoolean(SPs.spS_Livraison.Resultset1.Fields.Column_IsTMA.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_SuspendrePaiement.ColumnIndex)) {

						this.col_SuspendrePaiement = sqlDataReader.GetSqlBoolean(SPs.spS_Livraison.Resultset1.Fields.Column_SuspendrePaiement.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison.Resultset1.Fields.Column_BonCommande.ColumnIndex)) {

						this.col_BonCommande = sqlDataReader.GetSqlString(SPs.spS_Livraison.Resultset1.Fields.Column_BonCommande.ColumnIndex);
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

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Livraison_Record", "Refresh");
			}
		}

		public void Update() {

			if (!this.recordWasLoadedFromDB) {

				throw new ArgumentException("No record was loaded from the database. No update is possible.");
			}

			bool ChangesHaveBeenMade = false;

			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_DateLivraisonWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_DatePayeWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_ContratIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_UniteMesureIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_EssenceIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_SciageWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_NumeroFactureUsineWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_DroitCoupeIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_EntentePaiementIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_TransporteurIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_VRWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_MasseLimiteWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_VolumeBrutWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_VolumeTareWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_VolumeTransporteWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_VolumeSurchargeWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_VolumeAPayerWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_AnneeWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_PeriodeWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_DateCalculWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Taux_TransporteurWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Montant_TransporteurWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Montant_UsineWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Montant_Producteur1WasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Montant_Producteur2WasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Montant_Preleve_Plan_ConjointWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Montant_Preleve_Fond_RoulementWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Montant_Preleve_Fond_ForestierWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Montant_Preleve_DiversWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Montant_SurchargeWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Montant_MiseEnCommunWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_FactureWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Producteur1_FactureIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Producteur2_FactureIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Transporteur_FactureIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Usine_FactureIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_ErreurCalculWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_ErreurDescriptionWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_LotIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Taux_Transporteur_OverrideWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_PaieTransporteurWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_VolumeSurcharge_OverrideWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_SurchargeManuelWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_CodeWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_NombrePermisWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_ZoneIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_MunicipaliteIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_ChargeurIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Montant_ChargeurWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Frais_ChargeurAuProducteurWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Frais_ChargeurAuTransporteurWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Frais_AutresAuProducteurWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Frais_AutresAuProducteurDescriptionWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Frais_AutresAuProducteurTransportSciageWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Frais_AutresAuTransporteurWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Frais_AutresAuTransporteurDescriptionWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Frais_CompensationDeDeplacementWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Chargeur_FactureIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Commentaires_ProducteurWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Commentaires_TransporteurWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Commentaires_ChargeurWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_TauxChargeurAuProducteurWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_TauxChargeurAuTransporteurWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Frais_AutresRevenusTransporteurWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Frais_AutresRevenusTransporteurDescriptionWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Frais_AutresRevenusProducteurWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Frais_AutresRevenusProducteurDescriptionWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Montant_SurchargeProducteurWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_KgVert_BrutWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_KgVert_TareWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_KgVert_NetWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_KgVert_RejetsWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_KgVert_PayeWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Pourcent_Sec_ProducteurWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Pourcent_Sec_Producteur_OverrideWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_TMA_ProducteurWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Pourcent_Sec_TransportWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Pourcent_Sec_Transport_OverrideWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_TMA_TransportWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_IsTMAWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_SuspendrePaiementWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_BonCommandeWasUpdated);

			if (!ChangesHaveBeenMade) {

				return;
			}

			Params.spU_Livraison Param = new Params.spU_Livraison(false);
			Param.SetUpConnection(this.connectionString);
			Param.Param_ID = this.col_ID;

			if (this.col_DateLivraisonWasUpdated) {

				Param.Param_DateLivraison = this.col_DateLivraison;
				Param.Param_ConsiderNull_DateLivraison = true;
			}

			if (this.col_DatePayeWasUpdated) {

				Param.Param_DatePaye = this.col_DatePaye;
				Param.Param_ConsiderNull_DatePaye = true;
			}

			if (this.col_ContratIDWasUpdated) {

				Param.Param_ContratID = this.col_ContratID;
				Param.Param_ConsiderNull_ContratID = true;
			}

			if (this.col_UniteMesureIDWasUpdated) {

				Param.Param_UniteMesureID = this.col_UniteMesureID;
				Param.Param_ConsiderNull_UniteMesureID = true;
			}

			if (this.col_EssenceIDWasUpdated) {

				Param.Param_EssenceID = this.col_EssenceID;
				Param.Param_ConsiderNull_EssenceID = true;
			}

			if (this.col_SciageWasUpdated) {

				Param.Param_Sciage = this.col_Sciage;
				Param.Param_ConsiderNull_Sciage = true;
			}

			if (this.col_NumeroFactureUsineWasUpdated) {

				Param.Param_NumeroFactureUsine = this.col_NumeroFactureUsine;
				Param.Param_ConsiderNull_NumeroFactureUsine = true;
			}

			if (this.col_DroitCoupeIDWasUpdated) {

				Param.Param_DroitCoupeID = this.col_DroitCoupeID;
				Param.Param_ConsiderNull_DroitCoupeID = true;
			}

			if (this.col_EntentePaiementIDWasUpdated) {

				Param.Param_EntentePaiementID = this.col_EntentePaiementID;
				Param.Param_ConsiderNull_EntentePaiementID = true;
			}

			if (this.col_TransporteurIDWasUpdated) {

				Param.Param_TransporteurID = this.col_TransporteurID;
				Param.Param_ConsiderNull_TransporteurID = true;
			}

			if (this.col_VRWasUpdated) {

				Param.Param_VR = this.col_VR;
				Param.Param_ConsiderNull_VR = true;
			}

			if (this.col_MasseLimiteWasUpdated) {

				Param.Param_MasseLimite = this.col_MasseLimite;
				Param.Param_ConsiderNull_MasseLimite = true;
			}

			if (this.col_VolumeBrutWasUpdated) {

				Param.Param_VolumeBrut = this.col_VolumeBrut;
				Param.Param_ConsiderNull_VolumeBrut = true;
			}

			if (this.col_VolumeTareWasUpdated) {

				Param.Param_VolumeTare = this.col_VolumeTare;
				Param.Param_ConsiderNull_VolumeTare = true;
			}

			if (this.col_VolumeTransporteWasUpdated) {

				Param.Param_VolumeTransporte = this.col_VolumeTransporte;
				Param.Param_ConsiderNull_VolumeTransporte = true;
			}

			if (this.col_VolumeSurchargeWasUpdated) {

				Param.Param_VolumeSurcharge = this.col_VolumeSurcharge;
				Param.Param_ConsiderNull_VolumeSurcharge = true;
			}

			if (this.col_VolumeAPayerWasUpdated) {

				Param.Param_VolumeAPayer = this.col_VolumeAPayer;
				Param.Param_ConsiderNull_VolumeAPayer = true;
			}

			if (this.col_AnneeWasUpdated) {

				Param.Param_Annee = this.col_Annee;
				Param.Param_ConsiderNull_Annee = true;
			}

			if (this.col_PeriodeWasUpdated) {

				Param.Param_Periode = this.col_Periode;
				Param.Param_ConsiderNull_Periode = true;
			}

			if (this.col_DateCalculWasUpdated) {

				Param.Param_DateCalcul = this.col_DateCalcul;
				Param.Param_ConsiderNull_DateCalcul = true;
			}

			if (this.col_Taux_TransporteurWasUpdated) {

				Param.Param_Taux_Transporteur = this.col_Taux_Transporteur;
				Param.Param_ConsiderNull_Taux_Transporteur = true;
			}

			if (this.col_Montant_TransporteurWasUpdated) {

				Param.Param_Montant_Transporteur = this.col_Montant_Transporteur;
				Param.Param_ConsiderNull_Montant_Transporteur = true;
			}

			if (this.col_Montant_UsineWasUpdated) {

				Param.Param_Montant_Usine = this.col_Montant_Usine;
				Param.Param_ConsiderNull_Montant_Usine = true;
			}

			if (this.col_Montant_Producteur1WasUpdated) {

				Param.Param_Montant_Producteur1 = this.col_Montant_Producteur1;
				Param.Param_ConsiderNull_Montant_Producteur1 = true;
			}

			if (this.col_Montant_Producteur2WasUpdated) {

				Param.Param_Montant_Producteur2 = this.col_Montant_Producteur2;
				Param.Param_ConsiderNull_Montant_Producteur2 = true;
			}

			if (this.col_Montant_Preleve_Plan_ConjointWasUpdated) {

				Param.Param_Montant_Preleve_Plan_Conjoint = this.col_Montant_Preleve_Plan_Conjoint;
				Param.Param_ConsiderNull_Montant_Preleve_Plan_Conjoint = true;
			}

			if (this.col_Montant_Preleve_Fond_RoulementWasUpdated) {

				Param.Param_Montant_Preleve_Fond_Roulement = this.col_Montant_Preleve_Fond_Roulement;
				Param.Param_ConsiderNull_Montant_Preleve_Fond_Roulement = true;
			}

			if (this.col_Montant_Preleve_Fond_ForestierWasUpdated) {

				Param.Param_Montant_Preleve_Fond_Forestier = this.col_Montant_Preleve_Fond_Forestier;
				Param.Param_ConsiderNull_Montant_Preleve_Fond_Forestier = true;
			}

			if (this.col_Montant_Preleve_DiversWasUpdated) {

				Param.Param_Montant_Preleve_Divers = this.col_Montant_Preleve_Divers;
				Param.Param_ConsiderNull_Montant_Preleve_Divers = true;
			}

			if (this.col_Montant_SurchargeWasUpdated) {

				Param.Param_Montant_Surcharge = this.col_Montant_Surcharge;
				Param.Param_ConsiderNull_Montant_Surcharge = true;
			}

			if (this.col_Montant_MiseEnCommunWasUpdated) {

				Param.Param_Montant_MiseEnCommun = this.col_Montant_MiseEnCommun;
				Param.Param_ConsiderNull_Montant_MiseEnCommun = true;
			}

			if (this.col_FactureWasUpdated) {

				Param.Param_Facture = this.col_Facture;
				Param.Param_ConsiderNull_Facture = true;
			}

			if (this.col_Producteur1_FactureIDWasUpdated) {

				Param.Param_Producteur1_FactureID = this.col_Producteur1_FactureID;
				Param.Param_ConsiderNull_Producteur1_FactureID = true;
			}

			if (this.col_Producteur2_FactureIDWasUpdated) {

				Param.Param_Producteur2_FactureID = this.col_Producteur2_FactureID;
				Param.Param_ConsiderNull_Producteur2_FactureID = true;
			}

			if (this.col_Transporteur_FactureIDWasUpdated) {

				Param.Param_Transporteur_FactureID = this.col_Transporteur_FactureID;
				Param.Param_ConsiderNull_Transporteur_FactureID = true;
			}

			if (this.col_Usine_FactureIDWasUpdated) {

				Param.Param_Usine_FactureID = this.col_Usine_FactureID;
				Param.Param_ConsiderNull_Usine_FactureID = true;
			}

			if (this.col_ErreurCalculWasUpdated) {

				Param.Param_ErreurCalcul = this.col_ErreurCalcul;
				Param.Param_ConsiderNull_ErreurCalcul = true;
			}

			if (this.col_ErreurDescriptionWasUpdated) {

				Param.Param_ErreurDescription = this.col_ErreurDescription;
				Param.Param_ConsiderNull_ErreurDescription = true;
			}

			if (this.col_LotIDWasUpdated) {

				Param.Param_LotID = this.col_LotID;
				Param.Param_ConsiderNull_LotID = true;
			}

			if (this.col_Taux_Transporteur_OverrideWasUpdated) {

				Param.Param_Taux_Transporteur_Override = this.col_Taux_Transporteur_Override;
				Param.Param_ConsiderNull_Taux_Transporteur_Override = true;
			}

			if (this.col_PaieTransporteurWasUpdated) {

				Param.Param_PaieTransporteur = this.col_PaieTransporteur;
				Param.Param_ConsiderNull_PaieTransporteur = true;
			}

			if (this.col_VolumeSurcharge_OverrideWasUpdated) {

				Param.Param_VolumeSurcharge_Override = this.col_VolumeSurcharge_Override;
				Param.Param_ConsiderNull_VolumeSurcharge_Override = true;
			}

			if (this.col_SurchargeManuelWasUpdated) {

				Param.Param_SurchargeManuel = this.col_SurchargeManuel;
				Param.Param_ConsiderNull_SurchargeManuel = true;
			}

			if (this.col_CodeWasUpdated) {

				Param.Param_Code = this.col_Code;
				Param.Param_ConsiderNull_Code = true;
			}

			if (this.col_NombrePermisWasUpdated) {

				Param.Param_NombrePermis = this.col_NombrePermis;
				Param.Param_ConsiderNull_NombrePermis = true;
			}

			if (this.col_ZoneIDWasUpdated) {

				Param.Param_ZoneID = this.col_ZoneID;
				Param.Param_ConsiderNull_ZoneID = true;
			}

			if (this.col_MunicipaliteIDWasUpdated) {

				Param.Param_MunicipaliteID = this.col_MunicipaliteID;
				Param.Param_ConsiderNull_MunicipaliteID = true;
			}

			if (this.col_ChargeurIDWasUpdated) {

				Param.Param_ChargeurID = this.col_ChargeurID;
				Param.Param_ConsiderNull_ChargeurID = true;
			}

			if (this.col_Montant_ChargeurWasUpdated) {

				Param.Param_Montant_Chargeur = this.col_Montant_Chargeur;
				Param.Param_ConsiderNull_Montant_Chargeur = true;
			}

			if (this.col_Frais_ChargeurAuProducteurWasUpdated) {

				Param.Param_Frais_ChargeurAuProducteur = this.col_Frais_ChargeurAuProducteur;
				Param.Param_ConsiderNull_Frais_ChargeurAuProducteur = true;
			}

			if (this.col_Frais_ChargeurAuTransporteurWasUpdated) {

				Param.Param_Frais_ChargeurAuTransporteur = this.col_Frais_ChargeurAuTransporteur;
				Param.Param_ConsiderNull_Frais_ChargeurAuTransporteur = true;
			}

			if (this.col_Frais_AutresAuProducteurWasUpdated) {

				Param.Param_Frais_AutresAuProducteur = this.col_Frais_AutresAuProducteur;
				Param.Param_ConsiderNull_Frais_AutresAuProducteur = true;
			}

			if (this.col_Frais_AutresAuProducteurDescriptionWasUpdated) {

				Param.Param_Frais_AutresAuProducteurDescription = this.col_Frais_AutresAuProducteurDescription;
				Param.Param_ConsiderNull_Frais_AutresAuProducteurDescription = true;
			}

			if (this.col_Frais_AutresAuProducteurTransportSciageWasUpdated) {

				Param.Param_Frais_AutresAuProducteurTransportSciage = this.col_Frais_AutresAuProducteurTransportSciage;
				Param.Param_ConsiderNull_Frais_AutresAuProducteurTransportSciage = true;
			}

			if (this.col_Frais_AutresAuTransporteurWasUpdated) {

				Param.Param_Frais_AutresAuTransporteur = this.col_Frais_AutresAuTransporteur;
				Param.Param_ConsiderNull_Frais_AutresAuTransporteur = true;
			}

			if (this.col_Frais_AutresAuTransporteurDescriptionWasUpdated) {

				Param.Param_Frais_AutresAuTransporteurDescription = this.col_Frais_AutresAuTransporteurDescription;
				Param.Param_ConsiderNull_Frais_AutresAuTransporteurDescription = true;
			}

			if (this.col_Frais_CompensationDeDeplacementWasUpdated) {

				Param.Param_Frais_CompensationDeDeplacement = this.col_Frais_CompensationDeDeplacement;
				Param.Param_ConsiderNull_Frais_CompensationDeDeplacement = true;
			}

			if (this.col_Chargeur_FactureIDWasUpdated) {

				Param.Param_Chargeur_FactureID = this.col_Chargeur_FactureID;
				Param.Param_ConsiderNull_Chargeur_FactureID = true;
			}

			if (this.col_Commentaires_ProducteurWasUpdated) {

				Param.Param_Commentaires_Producteur = this.col_Commentaires_Producteur;
				Param.Param_ConsiderNull_Commentaires_Producteur = true;
			}

			if (this.col_Commentaires_TransporteurWasUpdated) {

				Param.Param_Commentaires_Transporteur = this.col_Commentaires_Transporteur;
				Param.Param_ConsiderNull_Commentaires_Transporteur = true;
			}

			if (this.col_Commentaires_ChargeurWasUpdated) {

				Param.Param_Commentaires_Chargeur = this.col_Commentaires_Chargeur;
				Param.Param_ConsiderNull_Commentaires_Chargeur = true;
			}

			if (this.col_TauxChargeurAuProducteurWasUpdated) {

				Param.Param_TauxChargeurAuProducteur = this.col_TauxChargeurAuProducteur;
				Param.Param_ConsiderNull_TauxChargeurAuProducteur = true;
			}

			if (this.col_TauxChargeurAuTransporteurWasUpdated) {

				Param.Param_TauxChargeurAuTransporteur = this.col_TauxChargeurAuTransporteur;
				Param.Param_ConsiderNull_TauxChargeurAuTransporteur = true;
			}

			if (this.col_Frais_AutresRevenusTransporteurWasUpdated) {

				Param.Param_Frais_AutresRevenusTransporteur = this.col_Frais_AutresRevenusTransporteur;
				Param.Param_ConsiderNull_Frais_AutresRevenusTransporteur = true;
			}

			if (this.col_Frais_AutresRevenusTransporteurDescriptionWasUpdated) {

				Param.Param_Frais_AutresRevenusTransporteurDescription = this.col_Frais_AutresRevenusTransporteurDescription;
				Param.Param_ConsiderNull_Frais_AutresRevenusTransporteurDescription = true;
			}

			if (this.col_Frais_AutresRevenusProducteurWasUpdated) {

				Param.Param_Frais_AutresRevenusProducteur = this.col_Frais_AutresRevenusProducteur;
				Param.Param_ConsiderNull_Frais_AutresRevenusProducteur = true;
			}

			if (this.col_Frais_AutresRevenusProducteurDescriptionWasUpdated) {

				Param.Param_Frais_AutresRevenusProducteurDescription = this.col_Frais_AutresRevenusProducteurDescription;
				Param.Param_ConsiderNull_Frais_AutresRevenusProducteurDescription = true;
			}

			if (this.col_Montant_SurchargeProducteurWasUpdated) {

				Param.Param_Montant_SurchargeProducteur = this.col_Montant_SurchargeProducteur;
				Param.Param_ConsiderNull_Montant_SurchargeProducteur = true;
			}

			if (this.col_KgVert_BrutWasUpdated) {

				Param.Param_KgVert_Brut = this.col_KgVert_Brut;
				Param.Param_ConsiderNull_KgVert_Brut = true;
			}

			if (this.col_KgVert_TareWasUpdated) {

				Param.Param_KgVert_Tare = this.col_KgVert_Tare;
				Param.Param_ConsiderNull_KgVert_Tare = true;
			}

			if (this.col_KgVert_NetWasUpdated) {

				Param.Param_KgVert_Net = this.col_KgVert_Net;
				Param.Param_ConsiderNull_KgVert_Net = true;
			}

			if (this.col_KgVert_RejetsWasUpdated) {

				Param.Param_KgVert_Rejets = this.col_KgVert_Rejets;
				Param.Param_ConsiderNull_KgVert_Rejets = true;
			}

			if (this.col_KgVert_PayeWasUpdated) {

				Param.Param_KgVert_Paye = this.col_KgVert_Paye;
				Param.Param_ConsiderNull_KgVert_Paye = true;
			}

			if (this.col_Pourcent_Sec_ProducteurWasUpdated) {

				Param.Param_Pourcent_Sec_Producteur = this.col_Pourcent_Sec_Producteur;
				Param.Param_ConsiderNull_Pourcent_Sec_Producteur = true;
			}

			if (this.col_Pourcent_Sec_Producteur_OverrideWasUpdated) {

				Param.Param_Pourcent_Sec_Producteur_Override = this.col_Pourcent_Sec_Producteur_Override;
				Param.Param_ConsiderNull_Pourcent_Sec_Producteur_Override = true;
			}

			if (this.col_TMA_ProducteurWasUpdated) {

				Param.Param_TMA_Producteur = this.col_TMA_Producteur;
				Param.Param_ConsiderNull_TMA_Producteur = true;
			}

			if (this.col_Pourcent_Sec_TransportWasUpdated) {

				Param.Param_Pourcent_Sec_Transport = this.col_Pourcent_Sec_Transport;
				Param.Param_ConsiderNull_Pourcent_Sec_Transport = true;
			}

			if (this.col_Pourcent_Sec_Transport_OverrideWasUpdated) {

				Param.Param_Pourcent_Sec_Transport_Override = this.col_Pourcent_Sec_Transport_Override;
				Param.Param_ConsiderNull_Pourcent_Sec_Transport_Override = true;
			}

			if (this.col_TMA_TransportWasUpdated) {

				Param.Param_TMA_Transport = this.col_TMA_Transport;
				Param.Param_ConsiderNull_TMA_Transport = true;
			}

			if (this.col_IsTMAWasUpdated) {

				Param.Param_IsTMA = this.col_IsTMA;
				Param.Param_ConsiderNull_IsTMA = true;
			}

			if (this.col_SuspendrePaiementWasUpdated) {

				Param.Param_SuspendrePaiement = this.col_SuspendrePaiement;
				Param.Param_ConsiderNull_SuspendrePaiement = true;
			}

			if (this.col_BonCommandeWasUpdated) {

				Param.Param_BonCommande = this.col_BonCommande;
				Param.Param_ConsiderNull_BonCommande = true;
			}

			SPs.spU_Livraison Sp = new SPs.spU_Livraison();
			if (Sp.Execute(ref Param)) {

				this.col_DateLivraisonWasUpdated = false;
				this.col_DatePayeWasUpdated = false;
				this.col_ContratIDWasUpdated = false;
				this.col_UniteMesureIDWasUpdated = false;
				this.col_EssenceIDWasUpdated = false;
				this.col_SciageWasUpdated = false;
				this.col_NumeroFactureUsineWasUpdated = false;
				this.col_DroitCoupeIDWasUpdated = false;
				this.col_EntentePaiementIDWasUpdated = false;
				this.col_TransporteurIDWasUpdated = false;
				this.col_VRWasUpdated = false;
				this.col_MasseLimiteWasUpdated = false;
				this.col_VolumeBrutWasUpdated = false;
				this.col_VolumeTareWasUpdated = false;
				this.col_VolumeTransporteWasUpdated = false;
				this.col_VolumeSurchargeWasUpdated = false;
				this.col_VolumeAPayerWasUpdated = false;
				this.col_AnneeWasUpdated = false;
				this.col_PeriodeWasUpdated = false;
				this.col_DateCalculWasUpdated = false;
				this.col_Taux_TransporteurWasUpdated = false;
				this.col_Montant_TransporteurWasUpdated = false;
				this.col_Montant_UsineWasUpdated = false;
				this.col_Montant_Producteur1WasUpdated = false;
				this.col_Montant_Producteur2WasUpdated = false;
				this.col_Montant_Preleve_Plan_ConjointWasUpdated = false;
				this.col_Montant_Preleve_Fond_RoulementWasUpdated = false;
				this.col_Montant_Preleve_Fond_ForestierWasUpdated = false;
				this.col_Montant_Preleve_DiversWasUpdated = false;
				this.col_Montant_SurchargeWasUpdated = false;
				this.col_Montant_MiseEnCommunWasUpdated = false;
				this.col_FactureWasUpdated = false;
				this.col_Producteur1_FactureIDWasUpdated = false;
				this.col_Producteur2_FactureIDWasUpdated = false;
				this.col_Transporteur_FactureIDWasUpdated = false;
				this.col_Usine_FactureIDWasUpdated = false;
				this.col_ErreurCalculWasUpdated = false;
				this.col_ErreurDescriptionWasUpdated = false;
				this.col_LotIDWasUpdated = false;
				this.col_Taux_Transporteur_OverrideWasUpdated = false;
				this.col_PaieTransporteurWasUpdated = false;
				this.col_VolumeSurcharge_OverrideWasUpdated = false;
				this.col_SurchargeManuelWasUpdated = false;
				this.col_CodeWasUpdated = false;
				this.col_NombrePermisWasUpdated = false;
				this.col_ZoneIDWasUpdated = false;
				this.col_MunicipaliteIDWasUpdated = false;
				this.col_ChargeurIDWasUpdated = false;
				this.col_Montant_ChargeurWasUpdated = false;
				this.col_Frais_ChargeurAuProducteurWasUpdated = false;
				this.col_Frais_ChargeurAuTransporteurWasUpdated = false;
				this.col_Frais_AutresAuProducteurWasUpdated = false;
				this.col_Frais_AutresAuProducteurDescriptionWasUpdated = false;
				this.col_Frais_AutresAuProducteurTransportSciageWasUpdated = false;
				this.col_Frais_AutresAuTransporteurWasUpdated = false;
				this.col_Frais_AutresAuTransporteurDescriptionWasUpdated = false;
				this.col_Frais_CompensationDeDeplacementWasUpdated = false;
				this.col_Chargeur_FactureIDWasUpdated = false;
				this.col_Commentaires_ProducteurWasUpdated = false;
				this.col_Commentaires_TransporteurWasUpdated = false;
				this.col_Commentaires_ChargeurWasUpdated = false;
				this.col_TauxChargeurAuProducteurWasUpdated = false;
				this.col_TauxChargeurAuTransporteurWasUpdated = false;
				this.col_Frais_AutresRevenusTransporteurWasUpdated = false;
				this.col_Frais_AutresRevenusTransporteurDescriptionWasUpdated = false;
				this.col_Frais_AutresRevenusProducteurWasUpdated = false;
				this.col_Frais_AutresRevenusProducteurDescriptionWasUpdated = false;
				this.col_Montant_SurchargeProducteurWasUpdated = false;
				this.col_KgVert_BrutWasUpdated = false;
				this.col_KgVert_TareWasUpdated = false;
				this.col_KgVert_NetWasUpdated = false;
				this.col_KgVert_RejetsWasUpdated = false;
				this.col_KgVert_PayeWasUpdated = false;
				this.col_Pourcent_Sec_ProducteurWasUpdated = false;
				this.col_Pourcent_Sec_Producteur_OverrideWasUpdated = false;
				this.col_TMA_ProducteurWasUpdated = false;
				this.col_Pourcent_Sec_TransportWasUpdated = false;
				this.col_Pourcent_Sec_Transport_OverrideWasUpdated = false;
				this.col_TMA_TransportWasUpdated = false;
				this.col_IsTMAWasUpdated = false;
				this.col_SuspendrePaiementWasUpdated = false;
				this.col_BonCommandeWasUpdated = false;
			}
			else {

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Livraison_Record", "Update");
			}		
		}

		private AjustementCalcule_Transporteur_Collection internal_AjustementCalcule_Transporteur_Col_LivraisonID_Collection = null;
		public AjustementCalcule_Transporteur_Collection AjustementCalcule_Transporteur_Col_LivraisonID_Collection {

			get {

				if (this.internal_AjustementCalcule_Transporteur_Col_LivraisonID_Collection == null) {

					this.internal_AjustementCalcule_Transporteur_Col_LivraisonID_Collection = new AjustementCalcule_Transporteur_Collection(this.connectionString);
					this.internal_AjustementCalcule_Transporteur_Col_LivraisonID_Collection.LoadFrom_LivraisonID(this.col_ID, this);
				}

				return(this.internal_AjustementCalcule_Transporteur_Col_LivraisonID_Collection);
			}
		}

		private FactureUsine_Detail_Collection internal_FactureUsine_Detail_Col_LivraisonID_Collection = null;
		public FactureUsine_Detail_Collection FactureUsine_Detail_Col_LivraisonID_Collection {

			get {

				if (this.internal_FactureUsine_Detail_Col_LivraisonID_Collection == null) {

					this.internal_FactureUsine_Detail_Col_LivraisonID_Collection = new FactureUsine_Detail_Collection(this.connectionString);
					this.internal_FactureUsine_Detail_Col_LivraisonID_Collection.LoadFrom_LivraisonID(this.col_ID, this);
				}

				return(this.internal_FactureUsine_Detail_Col_LivraisonID_Collection);
			}
		}

		private IndexationCalcule_Producteur_Collection internal_IndexationCalcule_Producteur_Col_LivraisonID_Collection = null;
		public IndexationCalcule_Producteur_Collection IndexationCalcule_Producteur_Col_LivraisonID_Collection {

			get {

				if (this.internal_IndexationCalcule_Producteur_Col_LivraisonID_Collection == null) {

					this.internal_IndexationCalcule_Producteur_Col_LivraisonID_Collection = new IndexationCalcule_Producteur_Collection(this.connectionString);
					this.internal_IndexationCalcule_Producteur_Col_LivraisonID_Collection.LoadFrom_LivraisonID(this.col_ID, this);
				}

				return(this.internal_IndexationCalcule_Producteur_Col_LivraisonID_Collection);
			}
		}

		private IndexationCalcule_Transporteur_Collection internal_IndexationCalcule_Transporteur_Col_LivraisonID_Collection = null;
		public IndexationCalcule_Transporteur_Collection IndexationCalcule_Transporteur_Col_LivraisonID_Collection {

			get {

				if (this.internal_IndexationCalcule_Transporteur_Col_LivraisonID_Collection == null) {

					this.internal_IndexationCalcule_Transporteur_Col_LivraisonID_Collection = new IndexationCalcule_Transporteur_Collection(this.connectionString);
					this.internal_IndexationCalcule_Transporteur_Col_LivraisonID_Collection.LoadFrom_LivraisonID(this.col_ID, this);
				}

				return(this.internal_IndexationCalcule_Transporteur_Col_LivraisonID_Collection);
			}
		}

		private Livraison_Detail_Collection internal_Livraison_Detail_Col_LivraisonID_Collection = null;
		public Livraison_Detail_Collection Livraison_Detail_Col_LivraisonID_Collection {

			get {

				if (this.internal_Livraison_Detail_Col_LivraisonID_Collection == null) {

					this.internal_Livraison_Detail_Col_LivraisonID_Collection = new Livraison_Detail_Collection(this.connectionString);
					this.internal_Livraison_Detail_Col_LivraisonID_Collection.LoadFrom_LivraisonID(this.col_ID, this);
				}

				return(this.internal_Livraison_Detail_Col_LivraisonID_Collection);
			}
		}

		private Livraison_Permis_Collection internal_Livraison_Permis_Col_LivraisonID_Collection = null;
		public Livraison_Permis_Collection Livraison_Permis_Col_LivraisonID_Collection {

			get {

				if (this.internal_Livraison_Permis_Col_LivraisonID_Collection == null) {

					this.internal_Livraison_Permis_Col_LivraisonID_Collection = new Livraison_Permis_Collection(this.connectionString);
					this.internal_Livraison_Permis_Col_LivraisonID_Collection.LoadFrom_LivraisonID(this.col_ID, this);
				}

				return(this.internal_Livraison_Permis_Col_LivraisonID_Collection);
			}
		}

		internal string displayName = null;
		public override string ToString() {

			if (!this.recordWasLoadedFromDB) {

				throw new ArgumentException("No record was loaded from the database. The DisplayName is not available.");
			}
		
			if (this.displayName == null) {
			
				Params.spS_Livraison_Display Param = new Params.spS_Livraison_Display();
				Param.SetUpConnection(this.connectionString);

				Param.Param_ID = this.col_ID;

				System.Data.SqlClient.SqlDataReader sqlDataReader = null;
				SPs.spS_Livraison_Display Sp = new SPs.spS_Livraison_Display();
				if (Sp.Execute(ref Param, out sqlDataReader)) {

					if (sqlDataReader.Read()) {

						if (!sqlDataReader.IsDBNull(SPs.spS_Livraison_Display.Resultset1.Fields.Column_Display.ColumnIndex)) {

							this.displayName = "spS_Livraison_Display";
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

					throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Livraison_Record", "ToString");
				}				
			}
			
			return(this.displayName);
		}
	}
}
