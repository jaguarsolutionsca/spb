using System;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.BusinessComponents {

	/// <summary>
	/// This class is an abstract class that represents the [Livraison_Detail] table. With this class
	/// you can load or update a record from the database. If you need to add or delete a record,
	/// you must use the <see cref="Gestion_Paie.BusinessComponents.Livraison_Detail_Collection"/> class to do so.
	/// </summary>
	public sealed class Livraison_Detail_Record : IBusinessComponentRecord {
	
		internal bool recordWasLoadedFromDB = false;
		private bool recordIsLoaded = false;

		internal string connectionString = String.Empty;
		public string ConnectionString {
		
			get {
			
				return(this.connectionString);
			}
		}
		
		/// <summary>
		/// Initializes a new instance of the Livraison_Detail_Record class. Use this contructor to add
		/// a new record. Then call the Add method of the Gestion_Paie.BusinessComponents.Livraison_Detail_Collection class to actually
		/// add the record in the database.
		/// </summary>
		public Livraison_Detail_Record() {
		
			this.recordWasLoadedFromDB = false;
			this.recordIsLoaded = false;
		}
	
		/// <param name="col_ID">[To be supplied.]</param>
		public Livraison_Detail_Record(string connectionString, System.Data.SqlTypes.SqlInt32 col_ID) {

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
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Livraison_Detail'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}", "Livraison_Detail", CurrentRevision, OriginalRevision));
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
		
		internal bool col_LivraisonIDWasSet = false;
		private bool col_LivraisonIDWasUpdated = false;
		internal System.Data.SqlTypes.SqlInt32 col_LivraisonID = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_LivraisonID {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_LivraisonID);
			}
			set {
			
				this.col_LivraisonIDWasUpdated = true;
				this.col_LivraisonIDWasSet = true;
				this.col_LivraisonID_Record = null;
				this.col_LivraisonID = value;
			}
		}

		
		private Livraison_Record col_LivraisonID_Record = null;
		public Livraison_Record Col_LivraisonID_Livraison_Record {
		
			get {

				if (this.col_LivraisonID_Record == null) {
				
					this.col_LivraisonID_Record = new Livraison_Record(this.connectionString, this.col_LivraisonID);
				}
				
				return(this.col_LivraisonID_Record);
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

		
		private Contrat_EssenceUnite_Record col_ContratID_Record = null;
		public Contrat_EssenceUnite_Record Col_ContratID_Contrat_EssenceUnite_Record {
		
			get {

				if (this.col_ContratID_Record == null) {
				
					this.col_ContratID_Record = new Contrat_EssenceUnite_Record(this.connectionString, this.col_ContratID, System.Data.SqlTypes.SqlString.Null, System.Data.SqlTypes.SqlString.Null, System.Data.SqlTypes.SqlString.Null);
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

		
		private Contrat_EssenceUnite_Record col_EssenceID_Record = null;
		public Contrat_EssenceUnite_Record Col_EssenceID_Contrat_EssenceUnite_Record {
		
			get {

				if (this.col_EssenceID_Record == null) {
				
					this.col_EssenceID_Record = new Contrat_EssenceUnite_Record(this.connectionString, System.Data.SqlTypes.SqlString.Null, this.col_EssenceID, System.Data.SqlTypes.SqlString.Null, System.Data.SqlTypes.SqlString.Null);
				}
				
				return(this.col_EssenceID_Record);
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

		
		private Contrat_EssenceUnite_Record col_UniteMesureID_Record = null;
		public Contrat_EssenceUnite_Record Col_UniteMesureID_Contrat_EssenceUnite_Record {
		
			get {

				if (this.col_UniteMesureID_Record == null) {
				
					this.col_UniteMesureID_Record = new Contrat_EssenceUnite_Record(this.connectionString, System.Data.SqlTypes.SqlString.Null, System.Data.SqlTypes.SqlString.Null, this.col_UniteMesureID, System.Data.SqlTypes.SqlString.Null);
				}
				
				return(this.col_UniteMesureID_Record);
			}
		}

		internal bool col_ProducteurIDWasSet = false;
		private bool col_ProducteurIDWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_ProducteurID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_ProducteurID {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_ProducteurID);
			}
			set {
			
				this.col_ProducteurIDWasUpdated = true;
				this.col_ProducteurIDWasSet = true;
				this.col_ProducteurID_Record = null;
				this.col_ProducteurID = value;
			}
		}

		
		private Fournisseur_Record col_ProducteurID_Record = null;
		public Fournisseur_Record Col_ProducteurID_Fournisseur_Record {
		
			get {

				if (this.col_ProducteurID_Record == null) {
				
					this.col_ProducteurID_Record = new Fournisseur_Record(this.connectionString, this.col_ProducteurID);
				}
				
				return(this.col_ProducteurID_Record);
			}
		}

		internal bool col_Droit_CoupeWasSet = false;
		private bool col_Droit_CoupeWasUpdated = false;
		internal System.Data.SqlTypes.SqlBoolean col_Droit_Coupe = System.Data.SqlTypes.SqlBoolean.Null;
		public System.Data.SqlTypes.SqlBoolean Col_Droit_Coupe {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Droit_Coupe);
			}
			set {
			
				this.col_Droit_CoupeWasUpdated = true;
				this.col_Droit_CoupeWasSet = true;
				this.col_Droit_Coupe = value;
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

		internal bool col_VolumeReductionWasSet = false;
		private bool col_VolumeReductionWasUpdated = false;
		internal System.Data.SqlTypes.SqlDouble col_VolumeReduction = System.Data.SqlTypes.SqlDouble.Null;
		public System.Data.SqlTypes.SqlDouble Col_VolumeReduction {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_VolumeReduction);
			}
			set {
			
				this.col_VolumeReductionWasUpdated = true;
				this.col_VolumeReductionWasSet = true;
				this.col_VolumeReduction = value;
			}
		}

		internal bool col_VolumeNetWasSet = false;
		private bool col_VolumeNetWasUpdated = false;
		internal System.Data.SqlTypes.SqlDouble col_VolumeNet = System.Data.SqlTypes.SqlDouble.Null;
		public System.Data.SqlTypes.SqlDouble Col_VolumeNet {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_VolumeNet);
			}
			set {
			
				this.col_VolumeNetWasUpdated = true;
				this.col_VolumeNetWasSet = true;
				this.col_VolumeNet = value;
			}
		}

		internal bool col_VolumeContingenteWasSet = false;
		private bool col_VolumeContingenteWasUpdated = false;
		internal System.Data.SqlTypes.SqlDouble col_VolumeContingente = System.Data.SqlTypes.SqlDouble.Null;
		public System.Data.SqlTypes.SqlDouble Col_VolumeContingente {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_VolumeContingente);
			}
			set {
			
				this.col_VolumeContingenteWasUpdated = true;
				this.col_VolumeContingenteWasSet = true;
				this.col_VolumeContingente = value;
			}
		}

		internal bool col_ContingentementIDWasSet = false;
		private bool col_ContingentementIDWasUpdated = false;
		internal System.Data.SqlTypes.SqlInt32 col_ContingentementID = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_ContingentementID {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_ContingentementID);
			}
			set {
			
				this.col_ContingentementIDWasUpdated = true;
				this.col_ContingentementIDWasSet = true;
				this.col_ContingentementID_Record = null;
				this.col_ContingentementID = value;
			}
		}

		
		private Contingentement_Record col_ContingentementID_Record = null;
		public Contingentement_Record Col_ContingentementID_Contingentement_Record {
		
			get {

				if (this.col_ContingentementID_Record == null) {
				
					this.col_ContingentementID_Record = new Contingentement_Record(this.connectionString, this.col_ContingentementID);
				}
				
				return(this.col_ContingentementID_Record);
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

		internal bool col_Taux_UsineWasSet = false;
		private bool col_Taux_UsineWasUpdated = false;
		internal System.Data.SqlTypes.SqlDouble col_Taux_Usine = System.Data.SqlTypes.SqlDouble.Null;
		public System.Data.SqlTypes.SqlDouble Col_Taux_Usine {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Taux_Usine);
			}
			set {
			
				this.col_Taux_UsineWasUpdated = true;
				this.col_Taux_UsineWasSet = true;
				this.col_Taux_Usine = value;
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

		internal bool col_Taux_ProducteurWasSet = false;
		private bool col_Taux_ProducteurWasUpdated = false;
		internal System.Data.SqlTypes.SqlDouble col_Taux_Producteur = System.Data.SqlTypes.SqlDouble.Null;
		public System.Data.SqlTypes.SqlDouble Col_Taux_Producteur {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Taux_Producteur);
			}
			set {
			
				this.col_Taux_ProducteurWasUpdated = true;
				this.col_Taux_ProducteurWasSet = true;
				this.col_Taux_Producteur = value;
			}
		}

		internal bool col_Montant_ProducteurBrutWasSet = false;
		private bool col_Montant_ProducteurBrutWasUpdated = false;
		internal System.Data.SqlTypes.SqlDouble col_Montant_ProducteurBrut = System.Data.SqlTypes.SqlDouble.Null;
		public System.Data.SqlTypes.SqlDouble Col_Montant_ProducteurBrut {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Montant_ProducteurBrut);
			}
			set {
			
				this.col_Montant_ProducteurBrutWasUpdated = true;
				this.col_Montant_ProducteurBrutWasSet = true;
				this.col_Montant_ProducteurBrut = value;
			}
		}

		internal bool col_Taux_TransporteurMoyenWasSet = false;
		private bool col_Taux_TransporteurMoyenWasUpdated = false;
		internal System.Data.SqlTypes.SqlDouble col_Taux_TransporteurMoyen = System.Data.SqlTypes.SqlDouble.Null;
		public System.Data.SqlTypes.SqlDouble Col_Taux_TransporteurMoyen {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Taux_TransporteurMoyen);
			}
			set {
			
				this.col_Taux_TransporteurMoyenWasUpdated = true;
				this.col_Taux_TransporteurMoyenWasSet = true;
				this.col_Taux_TransporteurMoyen = value;
			}
		}

		internal bool col_Taux_TransporteurMoyen_OverrideWasSet = false;
		private bool col_Taux_TransporteurMoyen_OverrideWasUpdated = false;
		internal System.Data.SqlTypes.SqlBoolean col_Taux_TransporteurMoyen_Override = System.Data.SqlTypes.SqlBoolean.Null;
		public System.Data.SqlTypes.SqlBoolean Col_Taux_TransporteurMoyen_Override {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Taux_TransporteurMoyen_Override);
			}
			set {
			
				this.col_Taux_TransporteurMoyen_OverrideWasUpdated = true;
				this.col_Taux_TransporteurMoyen_OverrideWasSet = true;
				this.col_Taux_TransporteurMoyen_Override = value;
			}
		}

		internal bool col_Montant_TransporteurMoyenWasSet = false;
		private bool col_Montant_TransporteurMoyenWasUpdated = false;
		internal System.Data.SqlTypes.SqlDouble col_Montant_TransporteurMoyen = System.Data.SqlTypes.SqlDouble.Null;
		public System.Data.SqlTypes.SqlDouble Col_Montant_TransporteurMoyen {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Montant_TransporteurMoyen);
			}
			set {
			
				this.col_Montant_TransporteurMoyenWasUpdated = true;
				this.col_Montant_TransporteurMoyenWasSet = true;
				this.col_Montant_TransporteurMoyen = value;
			}
		}

		internal bool col_Taux_Preleve_Plan_ConjointWasSet = false;
		private bool col_Taux_Preleve_Plan_ConjointWasUpdated = false;
		internal System.Data.SqlTypes.SqlDouble col_Taux_Preleve_Plan_Conjoint = System.Data.SqlTypes.SqlDouble.Null;
		public System.Data.SqlTypes.SqlDouble Col_Taux_Preleve_Plan_Conjoint {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Taux_Preleve_Plan_Conjoint);
			}
			set {
			
				this.col_Taux_Preleve_Plan_ConjointWasUpdated = true;
				this.col_Taux_Preleve_Plan_ConjointWasSet = true;
				this.col_Taux_Preleve_Plan_Conjoint = value;
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

		internal bool col_Taux_Preleve_Fond_RoulementWasSet = false;
		private bool col_Taux_Preleve_Fond_RoulementWasUpdated = false;
		internal System.Data.SqlTypes.SqlDouble col_Taux_Preleve_Fond_Roulement = System.Data.SqlTypes.SqlDouble.Null;
		public System.Data.SqlTypes.SqlDouble Col_Taux_Preleve_Fond_Roulement {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Taux_Preleve_Fond_Roulement);
			}
			set {
			
				this.col_Taux_Preleve_Fond_RoulementWasUpdated = true;
				this.col_Taux_Preleve_Fond_RoulementWasSet = true;
				this.col_Taux_Preleve_Fond_Roulement = value;
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

		internal bool col_Taux_Preleve_Fond_ForestierWasSet = false;
		private bool col_Taux_Preleve_Fond_ForestierWasUpdated = false;
		internal System.Data.SqlTypes.SqlDouble col_Taux_Preleve_Fond_Forestier = System.Data.SqlTypes.SqlDouble.Null;
		public System.Data.SqlTypes.SqlDouble Col_Taux_Preleve_Fond_Forestier {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Taux_Preleve_Fond_Forestier);
			}
			set {
			
				this.col_Taux_Preleve_Fond_ForestierWasUpdated = true;
				this.col_Taux_Preleve_Fond_ForestierWasSet = true;
				this.col_Taux_Preleve_Fond_Forestier = value;
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

		internal bool col_Taux_Preleve_DiversWasSet = false;
		private bool col_Taux_Preleve_DiversWasUpdated = false;
		internal System.Data.SqlTypes.SqlDouble col_Taux_Preleve_Divers = System.Data.SqlTypes.SqlDouble.Null;
		public System.Data.SqlTypes.SqlDouble Col_Taux_Preleve_Divers {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Taux_Preleve_Divers);
			}
			set {
			
				this.col_Taux_Preleve_DiversWasUpdated = true;
				this.col_Taux_Preleve_DiversWasSet = true;
				this.col_Taux_Preleve_Divers = value;
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

		internal bool col_Montant_ProducteurNetWasSet = false;
		private bool col_Montant_ProducteurNetWasUpdated = false;
		internal System.Data.SqlTypes.SqlDouble col_Montant_ProducteurNet = System.Data.SqlTypes.SqlDouble.Null;
		public System.Data.SqlTypes.SqlDouble Col_Montant_ProducteurNet {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Montant_ProducteurNet);
			}
			set {
			
				this.col_Montant_ProducteurNetWasUpdated = true;
				this.col_Montant_ProducteurNetWasSet = true;
				this.col_Montant_ProducteurNet = value;
			}
		}

		internal bool col_Taux_Producteur_OverrideWasSet = false;
		private bool col_Taux_Producteur_OverrideWasUpdated = false;
		internal System.Data.SqlTypes.SqlBoolean col_Taux_Producteur_Override = System.Data.SqlTypes.SqlBoolean.Null;
		public System.Data.SqlTypes.SqlBoolean Col_Taux_Producteur_Override {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Taux_Producteur_Override);
			}
			set {
			
				this.col_Taux_Producteur_OverrideWasUpdated = true;
				this.col_Taux_Producteur_OverrideWasSet = true;
				this.col_Taux_Producteur_Override = value;
			}
		}

		internal bool col_Taux_Usine_OverrideWasSet = false;
		private bool col_Taux_Usine_OverrideWasUpdated = false;
		internal System.Data.SqlTypes.SqlBoolean col_Taux_Usine_Override = System.Data.SqlTypes.SqlBoolean.Null;
		public System.Data.SqlTypes.SqlBoolean Col_Taux_Usine_Override {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Taux_Usine_Override);
			}
			set {
			
				this.col_Taux_Usine_OverrideWasUpdated = true;
				this.col_Taux_Usine_OverrideWasSet = true;
				this.col_Taux_Usine_Override = value;
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
				this.col_Code_Record = null;
				this.col_Code = value;
			}
		}

		
		private Contrat_EssenceUnite_Record col_Code_Record = null;
		public Contrat_EssenceUnite_Record Col_Code_Contrat_EssenceUnite_Record {
		
			get {

				if (this.col_Code_Record == null) {
				
					this.col_Code_Record = new Contrat_EssenceUnite_Record(this.connectionString, System.Data.SqlTypes.SqlString.Null, System.Data.SqlTypes.SqlString.Null, System.Data.SqlTypes.SqlString.Null, this.col_Code);
				}
				
				return(this.col_Code_Record);
			}
		}

		internal bool col_UsePreleveMontantWasSet = false;
		private bool col_UsePreleveMontantWasUpdated = false;
		internal System.Data.SqlTypes.SqlBoolean col_UsePreleveMontant = System.Data.SqlTypes.SqlBoolean.Null;
		public System.Data.SqlTypes.SqlBoolean Col_UsePreleveMontant {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_UsePreleveMontant);
			}
			set {
			
				this.col_UsePreleveMontantWasUpdated = true;
				this.col_UsePreleveMontantWasSet = true;
				this.col_UsePreleveMontant = value;
			}
		}


		public bool Refresh() {

			this.displayName = null;

			this.col_LivraisonIDWasUpdated = false;
			this.col_LivraisonIDWasSet = false;
			this.col_LivraisonID = System.Data.SqlTypes.SqlInt32.Null;

			this.col_ContratIDWasUpdated = false;
			this.col_ContratIDWasSet = false;
			this.col_ContratID = System.Data.SqlTypes.SqlString.Null;

			this.col_EssenceIDWasUpdated = false;
			this.col_EssenceIDWasSet = false;
			this.col_EssenceID = System.Data.SqlTypes.SqlString.Null;

			this.col_UniteMesureIDWasUpdated = false;
			this.col_UniteMesureIDWasSet = false;
			this.col_UniteMesureID = System.Data.SqlTypes.SqlString.Null;

			this.col_ProducteurIDWasUpdated = false;
			this.col_ProducteurIDWasSet = false;
			this.col_ProducteurID = System.Data.SqlTypes.SqlString.Null;

			this.col_Droit_CoupeWasUpdated = false;
			this.col_Droit_CoupeWasSet = false;
			this.col_Droit_Coupe = System.Data.SqlTypes.SqlBoolean.Null;

			this.col_VolumeBrutWasUpdated = false;
			this.col_VolumeBrutWasSet = false;
			this.col_VolumeBrut = System.Data.SqlTypes.SqlDouble.Null;

			this.col_VolumeReductionWasUpdated = false;
			this.col_VolumeReductionWasSet = false;
			this.col_VolumeReduction = System.Data.SqlTypes.SqlDouble.Null;

			this.col_VolumeNetWasUpdated = false;
			this.col_VolumeNetWasSet = false;
			this.col_VolumeNet = System.Data.SqlTypes.SqlDouble.Null;

			this.col_VolumeContingenteWasUpdated = false;
			this.col_VolumeContingenteWasSet = false;
			this.col_VolumeContingente = System.Data.SqlTypes.SqlDouble.Null;

			this.col_ContingentementIDWasUpdated = false;
			this.col_ContingentementIDWasSet = false;
			this.col_ContingentementID = System.Data.SqlTypes.SqlInt32.Null;

			this.col_DateCalculWasUpdated = false;
			this.col_DateCalculWasSet = false;
			this.col_DateCalcul = System.Data.SqlTypes.SqlDateTime.Null;

			this.col_Taux_UsineWasUpdated = false;
			this.col_Taux_UsineWasSet = false;
			this.col_Taux_Usine = System.Data.SqlTypes.SqlDouble.Null;

			this.col_Montant_UsineWasUpdated = false;
			this.col_Montant_UsineWasSet = false;
			this.col_Montant_Usine = System.Data.SqlTypes.SqlDouble.Null;

			this.col_Taux_ProducteurWasUpdated = false;
			this.col_Taux_ProducteurWasSet = false;
			this.col_Taux_Producteur = System.Data.SqlTypes.SqlDouble.Null;

			this.col_Montant_ProducteurBrutWasUpdated = false;
			this.col_Montant_ProducteurBrutWasSet = false;
			this.col_Montant_ProducteurBrut = System.Data.SqlTypes.SqlDouble.Null;

			this.col_Taux_TransporteurMoyenWasUpdated = false;
			this.col_Taux_TransporteurMoyenWasSet = false;
			this.col_Taux_TransporteurMoyen = System.Data.SqlTypes.SqlDouble.Null;

			this.col_Taux_TransporteurMoyen_OverrideWasUpdated = false;
			this.col_Taux_TransporteurMoyen_OverrideWasSet = false;
			this.col_Taux_TransporteurMoyen_Override = System.Data.SqlTypes.SqlBoolean.Null;

			this.col_Montant_TransporteurMoyenWasUpdated = false;
			this.col_Montant_TransporteurMoyenWasSet = false;
			this.col_Montant_TransporteurMoyen = System.Data.SqlTypes.SqlDouble.Null;

			this.col_Taux_Preleve_Plan_ConjointWasUpdated = false;
			this.col_Taux_Preleve_Plan_ConjointWasSet = false;
			this.col_Taux_Preleve_Plan_Conjoint = System.Data.SqlTypes.SqlDouble.Null;

			this.col_Montant_Preleve_Plan_ConjointWasUpdated = false;
			this.col_Montant_Preleve_Plan_ConjointWasSet = false;
			this.col_Montant_Preleve_Plan_Conjoint = System.Data.SqlTypes.SqlDouble.Null;

			this.col_Taux_Preleve_Fond_RoulementWasUpdated = false;
			this.col_Taux_Preleve_Fond_RoulementWasSet = false;
			this.col_Taux_Preleve_Fond_Roulement = System.Data.SqlTypes.SqlDouble.Null;

			this.col_Montant_Preleve_Fond_RoulementWasUpdated = false;
			this.col_Montant_Preleve_Fond_RoulementWasSet = false;
			this.col_Montant_Preleve_Fond_Roulement = System.Data.SqlTypes.SqlDouble.Null;

			this.col_Taux_Preleve_Fond_ForestierWasUpdated = false;
			this.col_Taux_Preleve_Fond_ForestierWasSet = false;
			this.col_Taux_Preleve_Fond_Forestier = System.Data.SqlTypes.SqlDouble.Null;

			this.col_Montant_Preleve_Fond_ForestierWasUpdated = false;
			this.col_Montant_Preleve_Fond_ForestierWasSet = false;
			this.col_Montant_Preleve_Fond_Forestier = System.Data.SqlTypes.SqlDouble.Null;

			this.col_Taux_Preleve_DiversWasUpdated = false;
			this.col_Taux_Preleve_DiversWasSet = false;
			this.col_Taux_Preleve_Divers = System.Data.SqlTypes.SqlDouble.Null;

			this.col_Montant_Preleve_DiversWasUpdated = false;
			this.col_Montant_Preleve_DiversWasSet = false;
			this.col_Montant_Preleve_Divers = System.Data.SqlTypes.SqlDouble.Null;

			this.col_Montant_ProducteurNetWasUpdated = false;
			this.col_Montant_ProducteurNetWasSet = false;
			this.col_Montant_ProducteurNet = System.Data.SqlTypes.SqlDouble.Null;

			this.col_Taux_Producteur_OverrideWasUpdated = false;
			this.col_Taux_Producteur_OverrideWasSet = false;
			this.col_Taux_Producteur_Override = System.Data.SqlTypes.SqlBoolean.Null;

			this.col_Taux_Usine_OverrideWasUpdated = false;
			this.col_Taux_Usine_OverrideWasSet = false;
			this.col_Taux_Usine_Override = System.Data.SqlTypes.SqlBoolean.Null;

			this.col_CodeWasUpdated = false;
			this.col_CodeWasSet = false;
			this.col_Code = System.Data.SqlTypes.SqlString.Null;

			this.col_UsePreleveMontantWasUpdated = false;
			this.col_UsePreleveMontantWasSet = false;
			this.col_UsePreleveMontant = System.Data.SqlTypes.SqlBoolean.Null;

			Params.spS_Livraison_Detail Param = new Params.spS_Livraison_Detail(true);
			Param.SetUpConnection(this.connectionString);

			if (!this.col_ID.IsNull) {

				Param.Param_ID = this.col_ID;
			}


			System.Data.SqlClient.SqlDataReader sqlDataReader = null;
			SPs.spS_Livraison_Detail Sp = new SPs.spS_Livraison_Detail();
			if (Sp.Execute(ref Param, out sqlDataReader)) {

				if (sqlDataReader.Read()) {

					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_LivraisonID.ColumnIndex)) {

						this.col_LivraisonID = sqlDataReader.GetSqlInt32(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_LivraisonID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_ContratID.ColumnIndex)) {

						this.col_ContratID = sqlDataReader.GetSqlString(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_ContratID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_EssenceID.ColumnIndex)) {

						this.col_EssenceID = sqlDataReader.GetSqlString(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_EssenceID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_UniteMesureID.ColumnIndex)) {

						this.col_UniteMesureID = sqlDataReader.GetSqlString(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_UniteMesureID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_ProducteurID.ColumnIndex)) {

						this.col_ProducteurID = sqlDataReader.GetSqlString(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_ProducteurID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_Droit_Coupe.ColumnIndex)) {

						this.col_Droit_Coupe = sqlDataReader.GetSqlBoolean(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_Droit_Coupe.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_VolumeBrut.ColumnIndex)) {

						this.col_VolumeBrut = sqlDataReader.GetSqlDouble(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_VolumeBrut.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_VolumeReduction.ColumnIndex)) {

						this.col_VolumeReduction = sqlDataReader.GetSqlDouble(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_VolumeReduction.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_VolumeNet.ColumnIndex)) {

						this.col_VolumeNet = sqlDataReader.GetSqlDouble(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_VolumeNet.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_VolumeContingente.ColumnIndex)) {

						this.col_VolumeContingente = sqlDataReader.GetSqlDouble(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_VolumeContingente.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_ContingentementID.ColumnIndex)) {

						this.col_ContingentementID = sqlDataReader.GetSqlInt32(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_ContingentementID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_DateCalcul.ColumnIndex)) {

						this.col_DateCalcul = sqlDataReader.GetSqlDateTime(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_DateCalcul.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_Taux_Usine.ColumnIndex)) {

						this.col_Taux_Usine = sqlDataReader.GetSqlDouble(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_Taux_Usine.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_Montant_Usine.ColumnIndex)) {

						this.col_Montant_Usine = sqlDataReader.GetSqlDouble(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_Montant_Usine.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_Taux_Producteur.ColumnIndex)) {

						this.col_Taux_Producteur = sqlDataReader.GetSqlDouble(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_Taux_Producteur.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_Montant_ProducteurBrut.ColumnIndex)) {

						this.col_Montant_ProducteurBrut = sqlDataReader.GetSqlDouble(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_Montant_ProducteurBrut.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_Taux_TransporteurMoyen.ColumnIndex)) {

						this.col_Taux_TransporteurMoyen = sqlDataReader.GetSqlDouble(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_Taux_TransporteurMoyen.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_Taux_TransporteurMoyen_Override.ColumnIndex)) {

						this.col_Taux_TransporteurMoyen_Override = sqlDataReader.GetSqlBoolean(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_Taux_TransporteurMoyen_Override.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_Montant_TransporteurMoyen.ColumnIndex)) {

						this.col_Montant_TransporteurMoyen = sqlDataReader.GetSqlDouble(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_Montant_TransporteurMoyen.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_Taux_Preleve_Plan_Conjoint.ColumnIndex)) {

						this.col_Taux_Preleve_Plan_Conjoint = sqlDataReader.GetSqlDouble(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_Taux_Preleve_Plan_Conjoint.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_Montant_Preleve_Plan_Conjoint.ColumnIndex)) {

						this.col_Montant_Preleve_Plan_Conjoint = sqlDataReader.GetSqlDouble(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_Montant_Preleve_Plan_Conjoint.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_Taux_Preleve_Fond_Roulement.ColumnIndex)) {

						this.col_Taux_Preleve_Fond_Roulement = sqlDataReader.GetSqlDouble(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_Taux_Preleve_Fond_Roulement.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_Montant_Preleve_Fond_Roulement.ColumnIndex)) {

						this.col_Montant_Preleve_Fond_Roulement = sqlDataReader.GetSqlDouble(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_Montant_Preleve_Fond_Roulement.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_Taux_Preleve_Fond_Forestier.ColumnIndex)) {

						this.col_Taux_Preleve_Fond_Forestier = sqlDataReader.GetSqlDouble(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_Taux_Preleve_Fond_Forestier.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_Montant_Preleve_Fond_Forestier.ColumnIndex)) {

						this.col_Montant_Preleve_Fond_Forestier = sqlDataReader.GetSqlDouble(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_Montant_Preleve_Fond_Forestier.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_Taux_Preleve_Divers.ColumnIndex)) {

						this.col_Taux_Preleve_Divers = sqlDataReader.GetSqlDouble(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_Taux_Preleve_Divers.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_Montant_Preleve_Divers.ColumnIndex)) {

						this.col_Montant_Preleve_Divers = sqlDataReader.GetSqlDouble(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_Montant_Preleve_Divers.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_Montant_ProducteurNet.ColumnIndex)) {

						this.col_Montant_ProducteurNet = sqlDataReader.GetSqlDouble(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_Montant_ProducteurNet.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_Taux_Producteur_Override.ColumnIndex)) {

						this.col_Taux_Producteur_Override = sqlDataReader.GetSqlBoolean(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_Taux_Producteur_Override.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_Taux_Usine_Override.ColumnIndex)) {

						this.col_Taux_Usine_Override = sqlDataReader.GetSqlBoolean(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_Taux_Usine_Override.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_Code.ColumnIndex)) {

						this.col_Code = sqlDataReader.GetSqlString(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_Code.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_UsePreleveMontant.ColumnIndex)) {

						this.col_UsePreleveMontant = sqlDataReader.GetSqlBoolean(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_UsePreleveMontant.ColumnIndex);
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

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Livraison_Detail_Record", "Refresh");
			}
		}

		public void Update() {

			if (!this.recordWasLoadedFromDB) {

				throw new ArgumentException("No record was loaded from the database. No update is possible.");
			}

			bool ChangesHaveBeenMade = false;

			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_LivraisonIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_ContratIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_EssenceIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_UniteMesureIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_ProducteurIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Droit_CoupeWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_VolumeBrutWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_VolumeReductionWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_VolumeNetWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_VolumeContingenteWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_ContingentementIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_DateCalculWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Taux_UsineWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Montant_UsineWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Taux_ProducteurWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Montant_ProducteurBrutWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Taux_TransporteurMoyenWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Taux_TransporteurMoyen_OverrideWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Montant_TransporteurMoyenWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Taux_Preleve_Plan_ConjointWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Montant_Preleve_Plan_ConjointWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Taux_Preleve_Fond_RoulementWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Montant_Preleve_Fond_RoulementWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Taux_Preleve_Fond_ForestierWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Montant_Preleve_Fond_ForestierWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Taux_Preleve_DiversWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Montant_Preleve_DiversWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Montant_ProducteurNetWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Taux_Producteur_OverrideWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Taux_Usine_OverrideWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_CodeWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_UsePreleveMontantWasUpdated);

			if (!ChangesHaveBeenMade) {

				return;
			}

			Params.spU_Livraison_Detail Param = new Params.spU_Livraison_Detail(false);
			Param.SetUpConnection(this.connectionString);
			Param.Param_ID = this.col_ID;

			if (this.col_LivraisonIDWasUpdated) {

				Param.Param_LivraisonID = this.col_LivraisonID;
				Param.Param_ConsiderNull_LivraisonID = true;
			}

			if (this.col_ContratIDWasUpdated) {

				Param.Param_ContratID = this.col_ContratID;
				Param.Param_ConsiderNull_ContratID = true;
			}

			if (this.col_EssenceIDWasUpdated) {

				Param.Param_EssenceID = this.col_EssenceID;
				Param.Param_ConsiderNull_EssenceID = true;
			}

			if (this.col_UniteMesureIDWasUpdated) {

				Param.Param_UniteMesureID = this.col_UniteMesureID;
				Param.Param_ConsiderNull_UniteMesureID = true;
			}

			if (this.col_ProducteurIDWasUpdated) {

				Param.Param_ProducteurID = this.col_ProducteurID;
				Param.Param_ConsiderNull_ProducteurID = true;
			}

			if (this.col_Droit_CoupeWasUpdated) {

				Param.Param_Droit_Coupe = this.col_Droit_Coupe;
				Param.Param_ConsiderNull_Droit_Coupe = true;
			}

			if (this.col_VolumeBrutWasUpdated) {

				Param.Param_VolumeBrut = this.col_VolumeBrut;
				Param.Param_ConsiderNull_VolumeBrut = true;
			}

			if (this.col_VolumeReductionWasUpdated) {

				Param.Param_VolumeReduction = this.col_VolumeReduction;
				Param.Param_ConsiderNull_VolumeReduction = true;
			}

			if (this.col_VolumeNetWasUpdated) {

				Param.Param_VolumeNet = this.col_VolumeNet;
				Param.Param_ConsiderNull_VolumeNet = true;
			}

			if (this.col_VolumeContingenteWasUpdated) {

				Param.Param_VolumeContingente = this.col_VolumeContingente;
				Param.Param_ConsiderNull_VolumeContingente = true;
			}

			if (this.col_ContingentementIDWasUpdated) {

				Param.Param_ContingentementID = this.col_ContingentementID;
				Param.Param_ConsiderNull_ContingentementID = true;
			}

			if (this.col_DateCalculWasUpdated) {

				Param.Param_DateCalcul = this.col_DateCalcul;
				Param.Param_ConsiderNull_DateCalcul = true;
			}

			if (this.col_Taux_UsineWasUpdated) {

				Param.Param_Taux_Usine = this.col_Taux_Usine;
				Param.Param_ConsiderNull_Taux_Usine = true;
			}

			if (this.col_Montant_UsineWasUpdated) {

				Param.Param_Montant_Usine = this.col_Montant_Usine;
				Param.Param_ConsiderNull_Montant_Usine = true;
			}

			if (this.col_Taux_ProducteurWasUpdated) {

				Param.Param_Taux_Producteur = this.col_Taux_Producteur;
				Param.Param_ConsiderNull_Taux_Producteur = true;
			}

			if (this.col_Montant_ProducteurBrutWasUpdated) {

				Param.Param_Montant_ProducteurBrut = this.col_Montant_ProducteurBrut;
				Param.Param_ConsiderNull_Montant_ProducteurBrut = true;
			}

			if (this.col_Taux_TransporteurMoyenWasUpdated) {

				Param.Param_Taux_TransporteurMoyen = this.col_Taux_TransporteurMoyen;
				Param.Param_ConsiderNull_Taux_TransporteurMoyen = true;
			}

			if (this.col_Taux_TransporteurMoyen_OverrideWasUpdated) {

				Param.Param_Taux_TransporteurMoyen_Override = this.col_Taux_TransporteurMoyen_Override;
				Param.Param_ConsiderNull_Taux_TransporteurMoyen_Override = true;
			}

			if (this.col_Montant_TransporteurMoyenWasUpdated) {

				Param.Param_Montant_TransporteurMoyen = this.col_Montant_TransporteurMoyen;
				Param.Param_ConsiderNull_Montant_TransporteurMoyen = true;
			}

			if (this.col_Taux_Preleve_Plan_ConjointWasUpdated) {

				Param.Param_Taux_Preleve_Plan_Conjoint = this.col_Taux_Preleve_Plan_Conjoint;
				Param.Param_ConsiderNull_Taux_Preleve_Plan_Conjoint = true;
			}

			if (this.col_Montant_Preleve_Plan_ConjointWasUpdated) {

				Param.Param_Montant_Preleve_Plan_Conjoint = this.col_Montant_Preleve_Plan_Conjoint;
				Param.Param_ConsiderNull_Montant_Preleve_Plan_Conjoint = true;
			}

			if (this.col_Taux_Preleve_Fond_RoulementWasUpdated) {

				Param.Param_Taux_Preleve_Fond_Roulement = this.col_Taux_Preleve_Fond_Roulement;
				Param.Param_ConsiderNull_Taux_Preleve_Fond_Roulement = true;
			}

			if (this.col_Montant_Preleve_Fond_RoulementWasUpdated) {

				Param.Param_Montant_Preleve_Fond_Roulement = this.col_Montant_Preleve_Fond_Roulement;
				Param.Param_ConsiderNull_Montant_Preleve_Fond_Roulement = true;
			}

			if (this.col_Taux_Preleve_Fond_ForestierWasUpdated) {

				Param.Param_Taux_Preleve_Fond_Forestier = this.col_Taux_Preleve_Fond_Forestier;
				Param.Param_ConsiderNull_Taux_Preleve_Fond_Forestier = true;
			}

			if (this.col_Montant_Preleve_Fond_ForestierWasUpdated) {

				Param.Param_Montant_Preleve_Fond_Forestier = this.col_Montant_Preleve_Fond_Forestier;
				Param.Param_ConsiderNull_Montant_Preleve_Fond_Forestier = true;
			}

			if (this.col_Taux_Preleve_DiversWasUpdated) {

				Param.Param_Taux_Preleve_Divers = this.col_Taux_Preleve_Divers;
				Param.Param_ConsiderNull_Taux_Preleve_Divers = true;
			}

			if (this.col_Montant_Preleve_DiversWasUpdated) {

				Param.Param_Montant_Preleve_Divers = this.col_Montant_Preleve_Divers;
				Param.Param_ConsiderNull_Montant_Preleve_Divers = true;
			}

			if (this.col_Montant_ProducteurNetWasUpdated) {

				Param.Param_Montant_ProducteurNet = this.col_Montant_ProducteurNet;
				Param.Param_ConsiderNull_Montant_ProducteurNet = true;
			}

			if (this.col_Taux_Producteur_OverrideWasUpdated) {

				Param.Param_Taux_Producteur_Override = this.col_Taux_Producteur_Override;
				Param.Param_ConsiderNull_Taux_Producteur_Override = true;
			}

			if (this.col_Taux_Usine_OverrideWasUpdated) {

				Param.Param_Taux_Usine_Override = this.col_Taux_Usine_Override;
				Param.Param_ConsiderNull_Taux_Usine_Override = true;
			}

			if (this.col_CodeWasUpdated) {

				Param.Param_Code = this.col_Code;
				Param.Param_ConsiderNull_Code = true;
			}

			if (this.col_UsePreleveMontantWasUpdated) {

				Param.Param_UsePreleveMontant = this.col_UsePreleveMontant;
				Param.Param_ConsiderNull_UsePreleveMontant = true;
			}

			SPs.spU_Livraison_Detail Sp = new SPs.spU_Livraison_Detail();
			if (Sp.Execute(ref Param)) {

				this.col_LivraisonIDWasUpdated = false;
				this.col_ContratIDWasUpdated = false;
				this.col_EssenceIDWasUpdated = false;
				this.col_UniteMesureIDWasUpdated = false;
				this.col_ProducteurIDWasUpdated = false;
				this.col_Droit_CoupeWasUpdated = false;
				this.col_VolumeBrutWasUpdated = false;
				this.col_VolumeReductionWasUpdated = false;
				this.col_VolumeNetWasUpdated = false;
				this.col_VolumeContingenteWasUpdated = false;
				this.col_ContingentementIDWasUpdated = false;
				this.col_DateCalculWasUpdated = false;
				this.col_Taux_UsineWasUpdated = false;
				this.col_Montant_UsineWasUpdated = false;
				this.col_Taux_ProducteurWasUpdated = false;
				this.col_Montant_ProducteurBrutWasUpdated = false;
				this.col_Taux_TransporteurMoyenWasUpdated = false;
				this.col_Taux_TransporteurMoyen_OverrideWasUpdated = false;
				this.col_Montant_TransporteurMoyenWasUpdated = false;
				this.col_Taux_Preleve_Plan_ConjointWasUpdated = false;
				this.col_Montant_Preleve_Plan_ConjointWasUpdated = false;
				this.col_Taux_Preleve_Fond_RoulementWasUpdated = false;
				this.col_Montant_Preleve_Fond_RoulementWasUpdated = false;
				this.col_Taux_Preleve_Fond_ForestierWasUpdated = false;
				this.col_Montant_Preleve_Fond_ForestierWasUpdated = false;
				this.col_Taux_Preleve_DiversWasUpdated = false;
				this.col_Montant_Preleve_DiversWasUpdated = false;
				this.col_Montant_ProducteurNetWasUpdated = false;
				this.col_Taux_Producteur_OverrideWasUpdated = false;
				this.col_Taux_Usine_OverrideWasUpdated = false;
				this.col_CodeWasUpdated = false;
				this.col_UsePreleveMontantWasUpdated = false;
			}
			else {

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Livraison_Detail_Record", "Update");
			}		
		}

		private AjustementCalcule_Producteur_Collection internal_AjustementCalcule_Producteur_Col_LivraisonDetailID_Collection = null;
		public AjustementCalcule_Producteur_Collection AjustementCalcule_Producteur_Col_LivraisonDetailID_Collection {

			get {

				if (this.internal_AjustementCalcule_Producteur_Col_LivraisonDetailID_Collection == null) {

					this.internal_AjustementCalcule_Producteur_Col_LivraisonDetailID_Collection = new AjustementCalcule_Producteur_Collection(this.connectionString);
					this.internal_AjustementCalcule_Producteur_Col_LivraisonDetailID_Collection.LoadFrom_LivraisonDetailID(this.col_ID, this);
				}

				return(this.internal_AjustementCalcule_Producteur_Col_LivraisonDetailID_Collection);
			}
		}

		private AjustementCalcule_Usine_Collection internal_AjustementCalcule_Usine_Col_LivraisonDetailID_Collection = null;
		public AjustementCalcule_Usine_Collection AjustementCalcule_Usine_Col_LivraisonDetailID_Collection {

			get {

				if (this.internal_AjustementCalcule_Usine_Col_LivraisonDetailID_Collection == null) {

					this.internal_AjustementCalcule_Usine_Col_LivraisonDetailID_Collection = new AjustementCalcule_Usine_Collection(this.connectionString);
					this.internal_AjustementCalcule_Usine_Col_LivraisonDetailID_Collection.LoadFrom_LivraisonDetailID(this.col_ID, this);
				}

				return(this.internal_AjustementCalcule_Usine_Col_LivraisonDetailID_Collection);
			}
		}

		private IndexationCalcule_Producteur_Collection internal_IndexationCalcule_Producteur_Col_LivraisonDetailID_Collection = null;
		public IndexationCalcule_Producteur_Collection IndexationCalcule_Producteur_Col_LivraisonDetailID_Collection {

			get {

				if (this.internal_IndexationCalcule_Producteur_Col_LivraisonDetailID_Collection == null) {

					this.internal_IndexationCalcule_Producteur_Col_LivraisonDetailID_Collection = new IndexationCalcule_Producteur_Collection(this.connectionString);
					this.internal_IndexationCalcule_Producteur_Col_LivraisonDetailID_Collection.LoadFrom_LivraisonDetailID(this.col_ID, this);
				}

				return(this.internal_IndexationCalcule_Producteur_Col_LivraisonDetailID_Collection);
			}
		}

		internal string displayName = null;
		public override string ToString() {

			if (!this.recordWasLoadedFromDB) {

				throw new ArgumentException("No record was loaded from the database. The DisplayName is not available.");
			}
		
			if (this.displayName == null) {
			
				Params.spS_Livraison_Detail_Display Param = new Params.spS_Livraison_Detail_Display();
				Param.SetUpConnection(this.connectionString);

				Param.Param_ID = this.col_ID;

				System.Data.SqlClient.SqlDataReader sqlDataReader = null;
				SPs.spS_Livraison_Detail_Display Sp = new SPs.spS_Livraison_Detail_Display();
				if (Sp.Execute(ref Param, out sqlDataReader)) {

					if (sqlDataReader.Read()) {

						if (!sqlDataReader.IsDBNull(SPs.spS_Livraison_Detail_Display.Resultset1.Fields.Column_Display.ColumnIndex)) {

							this.displayName = "spS_Livraison_Detail_Display";
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

					throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Livraison_Detail_Record", "ToString");
				}				
			}
			
			return(this.displayName);
		}
	}
}
