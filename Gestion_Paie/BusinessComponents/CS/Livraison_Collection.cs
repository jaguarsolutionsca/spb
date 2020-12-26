using System;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.BusinessComponents {

	public sealed class Livraison_Collection : IBusinessComponentCollection, System.Collections.IEnumerable, System.ComponentModel.IListSource {

		private System.Collections.ArrayList internalRecords;
		private bool recordsAreLoaded = false;

		private IBusinessComponentRecord parent = null;
		public IBusinessComponentRecord Parent {

			get {

				return(parent);
			}
		}

		public bool ContainsListCollection {

			get {

				return(true);
			}
		}

		public System.Collections.IList GetList() {

			return(internalRecords);
		}

		public int Count {

			get {

				if (!this.recordsAreLoaded) {

					Refresh();
				}

				return(internalRecords.Count);
			}
		}

		private string connectionString = String.Empty;
		public string ConnectionString {
		
			get {
			
				return(this.connectionString);
			}
		}

		private System.Data.SqlTypes.SqlInt32 col_ID = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_ID {

			get {

				return(this.col_ID);
			}
			set {

				this.col_ID = value;
			}
		}

		internal void LoadFrom_ID(System.Data.SqlTypes.SqlInt32 col_ID, Permit_Record parent) {
		
			if (col_ID.IsNull) {

				throw new ArgumentException("Parameter can not be null", "col_ID");
			}

			if (parent == null) {

				throw new ArgumentException("Parameter can not be null", "parent");
			}

			this.col_ID = col_ID;
			this.parent = parent;
		}

		private System.Data.SqlTypes.SqlString col_ContratID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_ContratID {

			get {

				return(this.col_ContratID);
			}
			set {

				this.col_ContratID = value;
			}
		}

		internal void LoadFrom_ContratID(System.Data.SqlTypes.SqlString col_ContratID, Contrat_Record parent) {
		
			if (col_ContratID.IsNull) {

				throw new ArgumentException("Parameter can not be null", "col_ContratID");
			}

			if (parent == null) {

				throw new ArgumentException("Parameter can not be null", "parent");
			}

			this.col_ContratID = col_ContratID;
			this.parent = parent;
		}

		private System.Data.SqlTypes.SqlString col_UniteMesureID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_UniteMesureID {

			get {

				return(this.col_UniteMesureID);
			}
			set {

				this.col_UniteMesureID = value;
			}
		}

		internal void LoadFrom_UniteMesureID(System.Data.SqlTypes.SqlString col_UniteMesureID, UniteMesure_Record parent) {
		
			if (col_UniteMesureID.IsNull) {

				throw new ArgumentException("Parameter can not be null", "col_UniteMesureID");
			}

			if (parent == null) {

				throw new ArgumentException("Parameter can not be null", "parent");
			}

			this.col_UniteMesureID = col_UniteMesureID;
			this.parent = parent;
		}

		private System.Data.SqlTypes.SqlString col_EssenceID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_EssenceID {

			get {

				return(this.col_EssenceID);
			}
			set {

				this.col_EssenceID = value;
			}
		}

		internal void LoadFrom_EssenceID(System.Data.SqlTypes.SqlString col_EssenceID, Essence_Record parent) {
		
			if (col_EssenceID.IsNull) {

				throw new ArgumentException("Parameter can not be null", "col_EssenceID");
			}

			if (parent == null) {

				throw new ArgumentException("Parameter can not be null", "parent");
			}

			this.col_EssenceID = col_EssenceID;
			this.parent = parent;
		}

		private System.Data.SqlTypes.SqlString col_DroitCoupeID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_DroitCoupeID {

			get {

				return(this.col_DroitCoupeID);
			}
			set {

				this.col_DroitCoupeID = value;
			}
		}

		internal void LoadFrom_DroitCoupeID(System.Data.SqlTypes.SqlString col_DroitCoupeID, Fournisseur_Record parent) {
		
			if (col_DroitCoupeID.IsNull) {

				throw new ArgumentException("Parameter can not be null", "col_DroitCoupeID");
			}

			if (parent == null) {

				throw new ArgumentException("Parameter can not be null", "parent");
			}

			this.col_DroitCoupeID = col_DroitCoupeID;
			this.parent = parent;
		}

		private System.Data.SqlTypes.SqlString col_EntentePaiementID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_EntentePaiementID {

			get {

				return(this.col_EntentePaiementID);
			}
			set {

				this.col_EntentePaiementID = value;
			}
		}

		internal void LoadFrom_EntentePaiementID(System.Data.SqlTypes.SqlString col_EntentePaiementID, Fournisseur_Record parent) {
		
			if (col_EntentePaiementID.IsNull) {

				throw new ArgumentException("Parameter can not be null", "col_EntentePaiementID");
			}

			if (parent == null) {

				throw new ArgumentException("Parameter can not be null", "parent");
			}

			this.col_EntentePaiementID = col_EntentePaiementID;
			this.parent = parent;
		}

		private System.Data.SqlTypes.SqlString col_TransporteurID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_TransporteurID {

			get {

				return(this.col_TransporteurID);
			}
			set {

				this.col_TransporteurID = value;
			}
		}

		internal void LoadFrom_TransporteurID(System.Data.SqlTypes.SqlString col_TransporteurID, Fournisseur_Record parent) {
		
			if (col_TransporteurID.IsNull) {

				throw new ArgumentException("Parameter can not be null", "col_TransporteurID");
			}

			if (parent == null) {

				throw new ArgumentException("Parameter can not be null", "parent");
			}

			this.col_TransporteurID = col_TransporteurID;
			this.parent = parent;
		}

		private System.Data.SqlTypes.SqlInt32 col_Annee = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_Annee {

			get {

				return(this.col_Annee);
			}
			set {

				this.col_Annee = value;
			}
		}

		internal void LoadFrom_Annee(System.Data.SqlTypes.SqlInt32 col_Annee, Periode_Record parent) {
		
			if (col_Annee.IsNull) {

				throw new ArgumentException("Parameter can not be null", "col_Annee");
			}

			if (parent == null) {

				throw new ArgumentException("Parameter can not be null", "parent");
			}

			this.col_Annee = col_Annee;
			this.parent = parent;
		}

		private System.Data.SqlTypes.SqlInt32 col_Periode = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_Periode {

			get {

				return(this.col_Periode);
			}
			set {

				this.col_Periode = value;
			}
		}

		internal void LoadFrom_Periode(System.Data.SqlTypes.SqlInt32 col_Periode, Periode_Record parent) {
		
			if (col_Periode.IsNull) {

				throw new ArgumentException("Parameter can not be null", "col_Periode");
			}

			if (parent == null) {

				throw new ArgumentException("Parameter can not be null", "parent");
			}

			this.col_Periode = col_Periode;
			this.parent = parent;
		}

		private System.Data.SqlTypes.SqlInt32 col_Producteur1_FactureID = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_Producteur1_FactureID {

			get {

				return(this.col_Producteur1_FactureID);
			}
			set {

				this.col_Producteur1_FactureID = value;
			}
		}

		internal void LoadFrom_Producteur1_FactureID(System.Data.SqlTypes.SqlInt32 col_Producteur1_FactureID, FactureFournisseur_Record parent) {
		
			if (col_Producteur1_FactureID.IsNull) {

				throw new ArgumentException("Parameter can not be null", "col_Producteur1_FactureID");
			}

			if (parent == null) {

				throw new ArgumentException("Parameter can not be null", "parent");
			}

			this.col_Producteur1_FactureID = col_Producteur1_FactureID;
			this.parent = parent;
		}

		private System.Data.SqlTypes.SqlInt32 col_Producteur2_FactureID = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_Producteur2_FactureID {

			get {

				return(this.col_Producteur2_FactureID);
			}
			set {

				this.col_Producteur2_FactureID = value;
			}
		}

		internal void LoadFrom_Producteur2_FactureID(System.Data.SqlTypes.SqlInt32 col_Producteur2_FactureID, FactureFournisseur_Record parent) {
		
			if (col_Producteur2_FactureID.IsNull) {

				throw new ArgumentException("Parameter can not be null", "col_Producteur2_FactureID");
			}

			if (parent == null) {

				throw new ArgumentException("Parameter can not be null", "parent");
			}

			this.col_Producteur2_FactureID = col_Producteur2_FactureID;
			this.parent = parent;
		}

		private System.Data.SqlTypes.SqlInt32 col_Transporteur_FactureID = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_Transporteur_FactureID {

			get {

				return(this.col_Transporteur_FactureID);
			}
			set {

				this.col_Transporteur_FactureID = value;
			}
		}

		internal void LoadFrom_Transporteur_FactureID(System.Data.SqlTypes.SqlInt32 col_Transporteur_FactureID, FactureFournisseur_Record parent) {
		
			if (col_Transporteur_FactureID.IsNull) {

				throw new ArgumentException("Parameter can not be null", "col_Transporteur_FactureID");
			}

			if (parent == null) {

				throw new ArgumentException("Parameter can not be null", "parent");
			}

			this.col_Transporteur_FactureID = col_Transporteur_FactureID;
			this.parent = parent;
		}

		private System.Data.SqlTypes.SqlInt32 col_Usine_FactureID = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_Usine_FactureID {

			get {

				return(this.col_Usine_FactureID);
			}
			set {

				this.col_Usine_FactureID = value;
			}
		}

		internal void LoadFrom_Usine_FactureID(System.Data.SqlTypes.SqlInt32 col_Usine_FactureID, FactureClient_Record parent) {
		
			if (col_Usine_FactureID.IsNull) {

				throw new ArgumentException("Parameter can not be null", "col_Usine_FactureID");
			}

			if (parent == null) {

				throw new ArgumentException("Parameter can not be null", "parent");
			}

			this.col_Usine_FactureID = col_Usine_FactureID;
			this.parent = parent;
		}

		private System.Data.SqlTypes.SqlInt32 col_LotID = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_LotID {

			get {

				return(this.col_LotID);
			}
			set {

				this.col_LotID = value;
			}
		}

		internal void LoadFrom_LotID(System.Data.SqlTypes.SqlInt32 col_LotID, Lot_Record parent) {
		
			if (col_LotID.IsNull) {

				throw new ArgumentException("Parameter can not be null", "col_LotID");
			}

			if (parent == null) {

				throw new ArgumentException("Parameter can not be null", "parent");
			}

			this.col_LotID = col_LotID;
			this.parent = parent;
		}

		private System.Data.SqlTypes.SqlString col_ZoneID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_ZoneID {

			get {

				return(this.col_ZoneID);
			}
			set {

				this.col_ZoneID = value;
			}
		}

		internal void LoadFrom_ZoneID(System.Data.SqlTypes.SqlString col_ZoneID, Municipalite_Zone_Record parent) {
		
			if (col_ZoneID.IsNull) {

				throw new ArgumentException("Parameter can not be null", "col_ZoneID");
			}

			if (parent == null) {

				throw new ArgumentException("Parameter can not be null", "parent");
			}

			this.col_ZoneID = col_ZoneID;
			this.parent = parent;
		}

		private System.Data.SqlTypes.SqlString col_MunicipaliteID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_MunicipaliteID {

			get {

				return(this.col_MunicipaliteID);
			}
			set {

				this.col_MunicipaliteID = value;
			}
		}

		internal void LoadFrom_MunicipaliteID(System.Data.SqlTypes.SqlString col_MunicipaliteID, Municipalite_Zone_Record parent) {
		
			if (col_MunicipaliteID.IsNull) {

				throw new ArgumentException("Parameter can not be null", "col_MunicipaliteID");
			}

			if (parent == null) {

				throw new ArgumentException("Parameter can not be null", "parent");
			}

			this.col_MunicipaliteID = col_MunicipaliteID;
			this.parent = parent;
		}

		private System.Data.SqlTypes.SqlString col_ChargeurID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_ChargeurID {

			get {

				return(this.col_ChargeurID);
			}
			set {

				this.col_ChargeurID = value;
			}
		}

		internal void LoadFrom_ChargeurID(System.Data.SqlTypes.SqlString col_ChargeurID, Fournisseur_Record parent) {
		
			if (col_ChargeurID.IsNull) {

				throw new ArgumentException("Parameter can not be null", "col_ChargeurID");
			}

			if (parent == null) {

				throw new ArgumentException("Parameter can not be null", "parent");
			}

			this.col_ChargeurID = col_ChargeurID;
			this.parent = parent;
		}

		private System.Data.SqlTypes.SqlInt32 col_Chargeur_FactureID = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_Chargeur_FactureID {

			get {

				return(this.col_Chargeur_FactureID);
			}
			set {

				this.col_Chargeur_FactureID = value;
			}
		}

		internal void LoadFrom_Chargeur_FactureID(System.Data.SqlTypes.SqlInt32 col_Chargeur_FactureID, FactureFournisseur_Record parent) {
		
			if (col_Chargeur_FactureID.IsNull) {

				throw new ArgumentException("Parameter can not be null", "col_Chargeur_FactureID");
			}

			if (parent == null) {

				throw new ArgumentException("Parameter can not be null", "parent");
			}

			this.col_Chargeur_FactureID = col_Chargeur_FactureID;
			this.parent = parent;
		}


		public Livraison_Collection(string connectionString) {
			
			this.connectionString = connectionString;

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

		}

		/// <param name="col_ContratID">[To be supplied.]</param>
		/// <param name="col_UniteMesureID">[To be supplied.]</param>
		/// <param name="col_EssenceID">[To be supplied.]</param>
		/// <param name="col_DroitCoupeID">[To be supplied.]</param>
		/// <param name="col_EntentePaiementID">[To be supplied.]</param>
		/// <param name="col_TransporteurID">[To be supplied.]</param>
		/// <param name="col_Annee">[To be supplied.]</param>
		/// <param name="col_Periode">[To be supplied.]</param>
		/// <param name="col_Producteur1_FactureID">[To be supplied.]</param>
		/// <param name="col_Producteur2_FactureID">[To be supplied.]</param>
		/// <param name="col_Transporteur_FactureID">[To be supplied.]</param>
		/// <param name="col_Usine_FactureID">[To be supplied.]</param>
		/// <param name="col_LotID">[To be supplied.]</param>
		/// <param name="col_ZoneID">[To be supplied.]</param>
		/// <param name="col_MunicipaliteID">[To be supplied.]</param>
		/// <param name="col_ChargeurID">[To be supplied.]</param>
		/// <param name="col_Chargeur_FactureID">[To be supplied.]</param>
		public Livraison_Collection(string connectionString, System.Data.SqlTypes.SqlString col_ContratID, System.Data.SqlTypes.SqlString col_UniteMesureID, System.Data.SqlTypes.SqlString col_EssenceID, System.Data.SqlTypes.SqlString col_DroitCoupeID, System.Data.SqlTypes.SqlString col_EntentePaiementID, System.Data.SqlTypes.SqlString col_TransporteurID, System.Data.SqlTypes.SqlInt32 col_Annee, System.Data.SqlTypes.SqlInt32 col_Periode, System.Data.SqlTypes.SqlInt32 col_Producteur1_FactureID, System.Data.SqlTypes.SqlInt32 col_Producteur2_FactureID, System.Data.SqlTypes.SqlInt32 col_Transporteur_FactureID, System.Data.SqlTypes.SqlInt32 col_Usine_FactureID, System.Data.SqlTypes.SqlInt32 col_LotID, System.Data.SqlTypes.SqlString col_ZoneID, System.Data.SqlTypes.SqlString col_MunicipaliteID, System.Data.SqlTypes.SqlString col_ChargeurID, System.Data.SqlTypes.SqlInt32 col_Chargeur_FactureID) {
			
			this.connectionString = connectionString;

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

			this.col_ContratID = col_ContratID;
			this.col_UniteMesureID = col_UniteMesureID;
			this.col_EssenceID = col_EssenceID;
			this.col_DroitCoupeID = col_DroitCoupeID;
			this.col_EntentePaiementID = col_EntentePaiementID;
			this.col_TransporteurID = col_TransporteurID;
			this.col_Annee = col_Annee;
			this.col_Periode = col_Periode;
			this.col_Producteur1_FactureID = col_Producteur1_FactureID;
			this.col_Producteur2_FactureID = col_Producteur2_FactureID;
			this.col_Transporteur_FactureID = col_Transporteur_FactureID;
			this.col_Usine_FactureID = col_Usine_FactureID;
			this.col_LotID = col_LotID;
			this.col_ZoneID = col_ZoneID;
			this.col_MunicipaliteID = col_MunicipaliteID;
			this.col_ChargeurID = col_ChargeurID;
			this.col_Chargeur_FactureID = col_Chargeur_FactureID;
		}


		public IBusinessComponentRecord Add(IBusinessComponentRecord record) {
		
			Livraison_Record recordToAdd = record as Livraison_Record;

			if (recordToAdd == null) {

				throw new ArgumentException("Invalid record type. Must be 'Gestion_Paie.BusinessComponents.Livraison_Record'.", "record");
			}

			Params.spI_Livraison Param = new Params.spI_Livraison();
			Param.SetUpConnection(this.connectionString);

			Param.Param_ID = recordToAdd.Col_ID;
			Param.Param_DateLivraison = recordToAdd.Col_DateLivraison;
			Param.Param_DatePaye = recordToAdd.Col_DatePaye;
			Param.Param_ContratID = recordToAdd.Col_ContratID;
			Param.Param_UniteMesureID = recordToAdd.Col_UniteMesureID;
			Param.Param_EssenceID = recordToAdd.Col_EssenceID;
			Param.Param_Sciage = recordToAdd.Col_Sciage;
			Param.Param_NumeroFactureUsine = recordToAdd.Col_NumeroFactureUsine;
			Param.Param_DroitCoupeID = recordToAdd.Col_DroitCoupeID;
			Param.Param_EntentePaiementID = recordToAdd.Col_EntentePaiementID;
			Param.Param_TransporteurID = recordToAdd.Col_TransporteurID;
			Param.Param_VR = recordToAdd.Col_VR;
			Param.Param_MasseLimite = recordToAdd.Col_MasseLimite;
			Param.Param_VolumeBrut = recordToAdd.Col_VolumeBrut;
			Param.Param_VolumeTare = recordToAdd.Col_VolumeTare;
			Param.Param_VolumeTransporte = recordToAdd.Col_VolumeTransporte;
			Param.Param_VolumeSurcharge = recordToAdd.Col_VolumeSurcharge;
			Param.Param_VolumeAPayer = recordToAdd.Col_VolumeAPayer;
			Param.Param_Annee = recordToAdd.Col_Annee;
			Param.Param_Periode = recordToAdd.Col_Periode;
			Param.Param_DateCalcul = recordToAdd.Col_DateCalcul;
			Param.Param_Taux_Transporteur = recordToAdd.Col_Taux_Transporteur;
			Param.Param_Montant_Transporteur = recordToAdd.Col_Montant_Transporteur;
			Param.Param_Montant_Usine = recordToAdd.Col_Montant_Usine;
			Param.Param_Montant_Producteur1 = recordToAdd.Col_Montant_Producteur1;
			Param.Param_Montant_Producteur2 = recordToAdd.Col_Montant_Producteur2;
			Param.Param_Montant_Preleve_Plan_Conjoint = recordToAdd.Col_Montant_Preleve_Plan_Conjoint;
			Param.Param_Montant_Preleve_Fond_Roulement = recordToAdd.Col_Montant_Preleve_Fond_Roulement;
			Param.Param_Montant_Preleve_Fond_Forestier = recordToAdd.Col_Montant_Preleve_Fond_Forestier;
			Param.Param_Montant_Preleve_Divers = recordToAdd.Col_Montant_Preleve_Divers;
			Param.Param_Montant_Surcharge = recordToAdd.Col_Montant_Surcharge;
			Param.Param_Montant_MiseEnCommun = recordToAdd.Col_Montant_MiseEnCommun;
			Param.Param_Facture = recordToAdd.Col_Facture;
			Param.Param_Producteur1_FactureID = recordToAdd.Col_Producteur1_FactureID;
			Param.Param_Producteur2_FactureID = recordToAdd.Col_Producteur2_FactureID;
			Param.Param_Transporteur_FactureID = recordToAdd.Col_Transporteur_FactureID;
			Param.Param_Usine_FactureID = recordToAdd.Col_Usine_FactureID;
			Param.Param_ErreurCalcul = recordToAdd.Col_ErreurCalcul;
			Param.Param_ErreurDescription = recordToAdd.Col_ErreurDescription;
			Param.Param_LotID = recordToAdd.Col_LotID;
			Param.Param_Taux_Transporteur_Override = recordToAdd.Col_Taux_Transporteur_Override;
			Param.Param_PaieTransporteur = recordToAdd.Col_PaieTransporteur;
			Param.Param_VolumeSurcharge_Override = recordToAdd.Col_VolumeSurcharge_Override;
			Param.Param_SurchargeManuel = recordToAdd.Col_SurchargeManuel;
			Param.Param_Code = recordToAdd.Col_Code;
			Param.Param_NombrePermis = recordToAdd.Col_NombrePermis;
			Param.Param_ZoneID = recordToAdd.Col_ZoneID;
			Param.Param_MunicipaliteID = recordToAdd.Col_MunicipaliteID;
			Param.Param_ChargeurID = recordToAdd.Col_ChargeurID;
			Param.Param_Montant_Chargeur = recordToAdd.Col_Montant_Chargeur;
			Param.Param_Frais_ChargeurAuProducteur = recordToAdd.Col_Frais_ChargeurAuProducteur;
			Param.Param_Frais_ChargeurAuTransporteur = recordToAdd.Col_Frais_ChargeurAuTransporteur;
			Param.Param_Frais_AutresAuProducteur = recordToAdd.Col_Frais_AutresAuProducteur;
			Param.Param_Frais_AutresAuProducteurDescription = recordToAdd.Col_Frais_AutresAuProducteurDescription;
			Param.Param_Frais_AutresAuProducteurTransportSciage = recordToAdd.Col_Frais_AutresAuProducteurTransportSciage;
			Param.Param_Frais_AutresAuTransporteur = recordToAdd.Col_Frais_AutresAuTransporteur;
			Param.Param_Frais_AutresAuTransporteurDescription = recordToAdd.Col_Frais_AutresAuTransporteurDescription;
			Param.Param_Frais_CompensationDeDeplacement = recordToAdd.Col_Frais_CompensationDeDeplacement;
			Param.Param_Chargeur_FactureID = recordToAdd.Col_Chargeur_FactureID;
			Param.Param_Commentaires_Producteur = recordToAdd.Col_Commentaires_Producteur;
			Param.Param_Commentaires_Transporteur = recordToAdd.Col_Commentaires_Transporteur;
			Param.Param_Commentaires_Chargeur = recordToAdd.Col_Commentaires_Chargeur;
			Param.Param_TauxChargeurAuProducteur = recordToAdd.Col_TauxChargeurAuProducteur;
			Param.Param_TauxChargeurAuTransporteur = recordToAdd.Col_TauxChargeurAuTransporteur;
			Param.Param_Frais_AutresRevenusTransporteur = recordToAdd.Col_Frais_AutresRevenusTransporteur;
			Param.Param_Frais_AutresRevenusTransporteurDescription = recordToAdd.Col_Frais_AutresRevenusTransporteurDescription;
			Param.Param_Frais_AutresRevenusProducteur = recordToAdd.Col_Frais_AutresRevenusProducteur;
			Param.Param_Frais_AutresRevenusProducteurDescription = recordToAdd.Col_Frais_AutresRevenusProducteurDescription;
			Param.Param_Montant_SurchargeProducteur = recordToAdd.Col_Montant_SurchargeProducteur;
			Param.Param_KgVert_Brut = recordToAdd.Col_KgVert_Brut;
			Param.Param_KgVert_Tare = recordToAdd.Col_KgVert_Tare;
			Param.Param_KgVert_Net = recordToAdd.Col_KgVert_Net;
			Param.Param_KgVert_Rejets = recordToAdd.Col_KgVert_Rejets;
			Param.Param_KgVert_Paye = recordToAdd.Col_KgVert_Paye;
			Param.Param_Pourcent_Sec_Producteur = recordToAdd.Col_Pourcent_Sec_Producteur;
			Param.Param_Pourcent_Sec_Producteur_Override = recordToAdd.Col_Pourcent_Sec_Producteur_Override;
			Param.Param_TMA_Producteur = recordToAdd.Col_TMA_Producteur;
			Param.Param_Pourcent_Sec_Transport = recordToAdd.Col_Pourcent_Sec_Transport;
			Param.Param_Pourcent_Sec_Transport_Override = recordToAdd.Col_Pourcent_Sec_Transport_Override;
			Param.Param_TMA_Transport = recordToAdd.Col_TMA_Transport;
			Param.Param_IsTMA = recordToAdd.Col_IsTMA;
			Param.Param_SuspendrePaiement = recordToAdd.Col_SuspendrePaiement;
			Param.Param_BonCommande = recordToAdd.Col_BonCommande;

			SPs.spI_Livraison Sp = new SPs.spI_Livraison();
			if (Sp.Execute(ref Param)) {

				Livraison_Record newRecord = new Livraison_Record(this.connectionString, Param.Param_ID);				if (internalRecords != null) {

					internalRecords.Add(newRecord);
				}

				return(newRecord);
			}
			else {

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Livraison_Collection", "Add");
			}	
		}

		/// <param name="Col_ID">[To be supplied.]</param>
		public void Remove(System.Data.SqlTypes.SqlInt32 Col_ID) {
		
			Params.spD_Livraison Param = new Params.spD_Livraison(true);
			Param.SetUpConnection(this.connectionString);

			Param.Param_ID = Col_ID;


			SPs.spD_Livraison Sp = new SPs.spD_Livraison(true);

			Sp.Execute(ref Param);
		}

		public void Remove(IBusinessComponentRecord record) {
		
			Livraison_Record recordToDelete = record as Livraison_Record;

			if (recordToDelete == null) {

				throw new ArgumentException("Invalid record type. Must be 'Gestion_Paie.BusinessComponents.Livraison_Record'.", "record");
			}

			Params.spD_Livraison Param = new Params.spD_Livraison(true);
			Param.SetUpConnection(this.connectionString);

			Param.Param_ID = recordToDelete.Col_ID;


			SPs.spD_Livraison Sp = new SPs.spD_Livraison(true);

			Sp.Execute(ref Param);

			if (internalRecords != null) {

				internalRecords.Remove(recordToDelete);
			}
		}

		public void Refresh() {

			internalRecords = new System.Collections.ArrayList();

			Params.spS_Livraison_Display Param = new Params.spS_Livraison_Display();
			Param.SetUpConnection(this.connectionString);

			if (!this.col_ID.IsNull) {

				Param.Param_ID = this.col_ID;
			}

			if (!this.col_ContratID.IsNull) {

				Param.Param_ContratID = this.col_ContratID;
			}

			if (!this.col_UniteMesureID.IsNull) {

				Param.Param_UniteMesureID = this.col_UniteMesureID;
			}

			if (!this.col_EssenceID.IsNull) {

				Param.Param_EssenceID = this.col_EssenceID;
			}

			if (!this.col_DroitCoupeID.IsNull) {

				Param.Param_DroitCoupeID = this.col_DroitCoupeID;
			}

			if (!this.col_EntentePaiementID.IsNull) {

				Param.Param_EntentePaiementID = this.col_EntentePaiementID;
			}

			if (!this.col_TransporteurID.IsNull) {

				Param.Param_TransporteurID = this.col_TransporteurID;
			}

			if (!this.col_Annee.IsNull) {

				Param.Param_Annee = this.col_Annee;
			}

			if (!this.col_Periode.IsNull) {

				Param.Param_Periode = this.col_Periode;
			}

			if (!this.col_Producteur1_FactureID.IsNull) {

				Param.Param_Producteur1_FactureID = this.col_Producteur1_FactureID;
			}

			if (!this.col_Producteur2_FactureID.IsNull) {

				Param.Param_Producteur2_FactureID = this.col_Producteur2_FactureID;
			}

			if (!this.col_Transporteur_FactureID.IsNull) {

				Param.Param_Transporteur_FactureID = this.col_Transporteur_FactureID;
			}

			if (!this.col_Usine_FactureID.IsNull) {

				Param.Param_Usine_FactureID = this.col_Usine_FactureID;
			}

			if (!this.col_LotID.IsNull) {

				Param.Param_LotID = this.col_LotID;
			}

			if (!this.col_ZoneID.IsNull) {

				Param.Param_ZoneID = this.col_ZoneID;
			}

			if (!this.col_MunicipaliteID.IsNull) {

				Param.Param_MunicipaliteID = this.col_MunicipaliteID;
			}

			if (!this.col_ChargeurID.IsNull) {

				Param.Param_ChargeurID = this.col_ChargeurID;
			}

			if (!this.col_Chargeur_FactureID.IsNull) {

				Param.Param_Chargeur_FactureID = this.col_Chargeur_FactureID;
			}


			System.Data.SqlClient.SqlDataReader sqlDataReader = null;
			SPs.spS_Livraison_Display Sp = new SPs.spS_Livraison_Display();
			if (Sp.Execute(ref Param, out sqlDataReader)) {

				while (sqlDataReader.Read()) {

					Livraison_Record record = new Livraison_Record(this.connectionString, sqlDataReader.GetSqlInt32(SPs.spS_Livraison_Display.Resultset1.Fields.Column_ID1.ColumnIndex));

					record.displayName = "spS_Livraison_Display";

					internalRecords.Add(record);
				}

				if (sqlDataReader != null && !sqlDataReader.IsClosed) {

					sqlDataReader.Close();
				}

				if (Sp.Connection != null && Sp.Connection.State == System.Data.ConnectionState.Open) {

					Sp.Connection.Close();
					Sp.Connection.Dispose();
				}

				this.recordsAreLoaded = true;
			}
			else {

				if (sqlDataReader != null && !sqlDataReader.IsClosed) {

					sqlDataReader.Close();
				}

				if (Sp.Connection != null && Sp.Connection.State == System.Data.ConnectionState.Open) {

					Sp.Connection.Close();
					Sp.Connection.Dispose();
				}

				this.recordsAreLoaded = false;
				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Livraison_Collection", "Refresh");
			}
		}

		public System.Collections.IEnumerator GetEnumerator() {

			if (!this.recordsAreLoaded) {

				Refresh();
			}

			return(internalRecords.GetEnumerator());
		}

		public Livraison_Record this[int index] {

			get {
				
				return((Livraison_Record)internalRecords[index]);
			}
		}

		/// <param name="col_ID">[To be supplied.]</param>
		/// <returns>[To be supplied.]</returns>
		public Livraison_Record this[System.Data.SqlTypes.SqlInt32 col_ID] {

			get {

				foreach(Livraison_Record record in internalRecords) {

					bool Equality = true;

					Equality = Equality && (record.Col_ID == col_ID).Value;
					if (Equality) return(null);

					return(record);
				}
				return(null);
			}
		}
	}
}
