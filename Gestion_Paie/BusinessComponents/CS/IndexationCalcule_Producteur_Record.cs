﻿using System;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.BusinessComponents {

	/// <summary>
	/// This class is an abstract class that represents the [IndexationCalcule_Producteur] table. With this class
	/// you can load or update a record from the database. If you need to add or delete a record,
	/// you must use the <see cref="Gestion_Paie.BusinessComponents.IndexationCalcule_Producteur_Collection"/> class to do so.
	/// </summary>
	public sealed class IndexationCalcule_Producteur_Record : IBusinessComponentRecord {
	
		internal bool recordWasLoadedFromDB = false;
		private bool recordIsLoaded = false;

		internal string connectionString = String.Empty;
		public string ConnectionString {
		
			get {
			
				return(this.connectionString);
			}
		}
		
		/// <summary>
		/// Initializes a new instance of the IndexationCalcule_Producteur_Record class. Use this contructor to add
		/// a new record. Then call the Add method of the Gestion_Paie.BusinessComponents.IndexationCalcule_Producteur_Collection class to actually
		/// add the record in the database.
		/// </summary>
		public IndexationCalcule_Producteur_Record() {
		
			this.recordWasLoadedFromDB = false;
			this.recordIsLoaded = false;
		}
	
		/// <param name="col_ID">[To be supplied.]</param>
		public IndexationCalcule_Producteur_Record(string connectionString, System.Data.SqlTypes.SqlInt32 col_ID) {

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
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'IndexationCalcule_Producteur'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}", "IndexationCalcule_Producteur", CurrentRevision, OriginalRevision));
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

		internal bool col_TypeIndexationWasSet = false;
		private bool col_TypeIndexationWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_TypeIndexation = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_TypeIndexation {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_TypeIndexation);
			}
			set {
			
				this.col_TypeIndexationWasUpdated = true;
				this.col_TypeIndexationWasSet = true;
				this.col_TypeIndexation_Record = null;
				this.col_TypeIndexation = value;
			}
		}

		
		private TypeIndexation_Record col_TypeIndexation_Record = null;
		public TypeIndexation_Record Col_TypeIndexation_TypeIndexation_Record {
		
			get {

				if (this.col_TypeIndexation_Record == null) {
				
					this.col_TypeIndexation_Record = new TypeIndexation_Record(this.connectionString, this.col_TypeIndexation);
				}
				
				return(this.col_TypeIndexation_Record);
			}
		}

		internal bool col_IndexationIDWasSet = false;
		private bool col_IndexationIDWasUpdated = false;
		internal System.Data.SqlTypes.SqlInt32 col_IndexationID = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_IndexationID {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_IndexationID);
			}
			set {
			
				this.col_IndexationIDWasUpdated = true;
				this.col_IndexationIDWasSet = true;
				this.col_IndexationID_Record = null;
				this.col_IndexationID = value;
			}
		}

		
		private Indexation_Record col_IndexationID_Record = null;
		public Indexation_Record Col_IndexationID_Indexation_Record {
		
			get {

				if (this.col_IndexationID_Record == null) {
				
					this.col_IndexationID_Record = new Indexation_Record(this.connectionString, this.col_IndexationID);
				}
				
				return(this.col_IndexationID_Record);
			}
		}

		internal bool col_IndexationDetailIDWasSet = false;
		private bool col_IndexationDetailIDWasUpdated = false;
		internal System.Data.SqlTypes.SqlInt32 col_IndexationDetailID = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_IndexationDetailID {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_IndexationDetailID);
			}
			set {
			
				this.col_IndexationDetailIDWasUpdated = true;
				this.col_IndexationDetailIDWasSet = true;
				this.col_IndexationDetailID_Record = null;
				this.col_IndexationDetailID = value;
			}
		}

		
		private Indexation_EssenceUnite_Record col_IndexationDetailID_Record = null;
		public Indexation_EssenceUnite_Record Col_IndexationDetailID_Indexation_EssenceUnite_Record {
		
			get {

				if (this.col_IndexationDetailID_Record == null) {
				
					this.col_IndexationDetailID_Record = new Indexation_EssenceUnite_Record(this.connectionString, this.col_IndexationDetailID);
				}
				
				return(this.col_IndexationDetailID_Record);
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

		internal bool col_LivraisonDetailIDWasSet = false;
		private bool col_LivraisonDetailIDWasUpdated = false;
		internal System.Data.SqlTypes.SqlInt32 col_LivraisonDetailID = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_LivraisonDetailID {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_LivraisonDetailID);
			}
			set {
			
				this.col_LivraisonDetailIDWasUpdated = true;
				this.col_LivraisonDetailIDWasSet = true;
				this.col_LivraisonDetailID_Record = null;
				this.col_LivraisonDetailID = value;
			}
		}

		
		private Livraison_Detail_Record col_LivraisonDetailID_Record = null;
		public Livraison_Detail_Record Col_LivraisonDetailID_Livraison_Detail_Record {
		
			get {

				if (this.col_LivraisonDetailID_Record == null) {
				
					this.col_LivraisonDetailID_Record = new Livraison_Detail_Record(this.connectionString, this.col_LivraisonDetailID);
				}
				
				return(this.col_LivraisonDetailID_Record);
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

		internal bool col_UniteIDWasSet = false;
		private bool col_UniteIDWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_UniteID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_UniteID {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_UniteID);
			}
			set {
			
				this.col_UniteIDWasUpdated = true;
				this.col_UniteIDWasSet = true;
				this.col_UniteID_Record = null;
				this.col_UniteID = value;
			}
		}

		
		private Contrat_EssenceUnite_Record col_UniteID_Record = null;
		public Contrat_EssenceUnite_Record Col_UniteID_Contrat_EssenceUnite_Record {
		
			get {

				if (this.col_UniteID_Record == null) {
				
					this.col_UniteID_Record = new Contrat_EssenceUnite_Record(this.connectionString, System.Data.SqlTypes.SqlString.Null, System.Data.SqlTypes.SqlString.Null, this.col_UniteID, System.Data.SqlTypes.SqlString.Null);
				}
				
				return(this.col_UniteID_Record);
			}
		}

		internal bool col_VolumeWasSet = false;
		private bool col_VolumeWasUpdated = false;
		internal System.Data.SqlTypes.SqlDouble col_Volume = System.Data.SqlTypes.SqlDouble.Null;
		public System.Data.SqlTypes.SqlDouble Col_Volume {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Volume);
			}
			set {
			
				this.col_VolumeWasUpdated = true;
				this.col_VolumeWasSet = true;
				this.col_Volume = value;
			}
		}

		internal bool col_MontantDejaPayeWasSet = false;
		private bool col_MontantDejaPayeWasUpdated = false;
		internal System.Data.SqlTypes.SqlDouble col_MontantDejaPaye = System.Data.SqlTypes.SqlDouble.Null;
		public System.Data.SqlTypes.SqlDouble Col_MontantDejaPaye {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_MontantDejaPaye);
			}
			set {
			
				this.col_MontantDejaPayeWasUpdated = true;
				this.col_MontantDejaPayeWasSet = true;
				this.col_MontantDejaPaye = value;
			}
		}

		internal bool col_PourcentageDuMontantWasSet = false;
		private bool col_PourcentageDuMontantWasUpdated = false;
		internal System.Data.SqlTypes.SqlDouble col_PourcentageDuMontant = System.Data.SqlTypes.SqlDouble.Null;
		public System.Data.SqlTypes.SqlDouble Col_PourcentageDuMontant {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_PourcentageDuMontant);
			}
			set {
			
				this.col_PourcentageDuMontantWasUpdated = true;
				this.col_PourcentageDuMontantWasSet = true;
				this.col_PourcentageDuMontant = value;
			}
		}

		internal bool col_TauxWasSet = false;
		private bool col_TauxWasUpdated = false;
		internal System.Data.SqlTypes.SqlDouble col_Taux = System.Data.SqlTypes.SqlDouble.Null;
		public System.Data.SqlTypes.SqlDouble Col_Taux {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Taux);
			}
			set {
			
				this.col_TauxWasUpdated = true;
				this.col_TauxWasSet = true;
				this.col_Taux = value;
			}
		}

		internal bool col_MontantWasSet = false;
		private bool col_MontantWasUpdated = false;
		internal System.Data.SqlTypes.SqlDouble col_Montant = System.Data.SqlTypes.SqlDouble.Null;
		public System.Data.SqlTypes.SqlDouble Col_Montant {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Montant);
			}
			set {
			
				this.col_MontantWasUpdated = true;
				this.col_MontantWasSet = true;
				this.col_Montant = value;
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

		internal bool col_FactureIDWasSet = false;
		private bool col_FactureIDWasUpdated = false;
		internal System.Data.SqlTypes.SqlInt32 col_FactureID = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_FactureID {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_FactureID);
			}
			set {
			
				this.col_FactureIDWasUpdated = true;
				this.col_FactureIDWasSet = true;
				this.col_FactureID_Record = null;
				this.col_FactureID = value;
			}
		}

		
		private FactureFournisseur_Record col_FactureID_Record = null;
		public FactureFournisseur_Record Col_FactureID_FactureFournisseur_Record {
		
			get {

				if (this.col_FactureID_Record == null) {
				
					this.col_FactureID_Record = new FactureFournisseur_Record(this.connectionString, this.col_FactureID);
				}
				
				return(this.col_FactureID_Record);
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


		public bool Refresh() {

			this.displayName = null;

			this.col_DateCalculWasUpdated = false;
			this.col_DateCalculWasSet = false;
			this.col_DateCalcul = System.Data.SqlTypes.SqlDateTime.Null;

			this.col_TypeIndexationWasUpdated = false;
			this.col_TypeIndexationWasSet = false;
			this.col_TypeIndexation = System.Data.SqlTypes.SqlString.Null;

			this.col_IndexationIDWasUpdated = false;
			this.col_IndexationIDWasSet = false;
			this.col_IndexationID = System.Data.SqlTypes.SqlInt32.Null;

			this.col_IndexationDetailIDWasUpdated = false;
			this.col_IndexationDetailIDWasSet = false;
			this.col_IndexationDetailID = System.Data.SqlTypes.SqlInt32.Null;

			this.col_LivraisonIDWasUpdated = false;
			this.col_LivraisonIDWasSet = false;
			this.col_LivraisonID = System.Data.SqlTypes.SqlInt32.Null;

			this.col_LivraisonDetailIDWasUpdated = false;
			this.col_LivraisonDetailIDWasSet = false;
			this.col_LivraisonDetailID = System.Data.SqlTypes.SqlInt32.Null;

			this.col_ProducteurIDWasUpdated = false;
			this.col_ProducteurIDWasSet = false;
			this.col_ProducteurID = System.Data.SqlTypes.SqlString.Null;

			this.col_ContratIDWasUpdated = false;
			this.col_ContratIDWasSet = false;
			this.col_ContratID = System.Data.SqlTypes.SqlString.Null;

			this.col_EssenceIDWasUpdated = false;
			this.col_EssenceIDWasSet = false;
			this.col_EssenceID = System.Data.SqlTypes.SqlString.Null;

			this.col_CodeWasUpdated = false;
			this.col_CodeWasSet = false;
			this.col_Code = System.Data.SqlTypes.SqlString.Null;

			this.col_UniteIDWasUpdated = false;
			this.col_UniteIDWasSet = false;
			this.col_UniteID = System.Data.SqlTypes.SqlString.Null;

			this.col_VolumeWasUpdated = false;
			this.col_VolumeWasSet = false;
			this.col_Volume = System.Data.SqlTypes.SqlDouble.Null;

			this.col_MontantDejaPayeWasUpdated = false;
			this.col_MontantDejaPayeWasSet = false;
			this.col_MontantDejaPaye = System.Data.SqlTypes.SqlDouble.Null;

			this.col_PourcentageDuMontantWasUpdated = false;
			this.col_PourcentageDuMontantWasSet = false;
			this.col_PourcentageDuMontant = System.Data.SqlTypes.SqlDouble.Null;

			this.col_TauxWasUpdated = false;
			this.col_TauxWasSet = false;
			this.col_Taux = System.Data.SqlTypes.SqlDouble.Null;

			this.col_MontantWasUpdated = false;
			this.col_MontantWasSet = false;
			this.col_Montant = System.Data.SqlTypes.SqlDouble.Null;

			this.col_FactureWasUpdated = false;
			this.col_FactureWasSet = false;
			this.col_Facture = System.Data.SqlTypes.SqlBoolean.Null;

			this.col_FactureIDWasUpdated = false;
			this.col_FactureIDWasSet = false;
			this.col_FactureID = System.Data.SqlTypes.SqlInt32.Null;

			this.col_ErreurCalculWasUpdated = false;
			this.col_ErreurCalculWasSet = false;
			this.col_ErreurCalcul = System.Data.SqlTypes.SqlBoolean.Null;

			this.col_ErreurDescriptionWasUpdated = false;
			this.col_ErreurDescriptionWasSet = false;
			this.col_ErreurDescription = System.Data.SqlTypes.SqlString.Null;

			Params.spS_IndexationCalcule_Producteur Param = new Params.spS_IndexationCalcule_Producteur(true);
			Param.SetUpConnection(this.connectionString);

			if (!this.col_ID.IsNull) {

				Param.Param_ID = this.col_ID;
			}


			System.Data.SqlClient.SqlDataReader sqlDataReader = null;
			SPs.spS_IndexationCalcule_Producteur Sp = new SPs.spS_IndexationCalcule_Producteur();
			if (Sp.Execute(ref Param, out sqlDataReader)) {

				if (sqlDataReader.Read()) {

					if (!sqlDataReader.IsDBNull(SPs.spS_IndexationCalcule_Producteur.Resultset1.Fields.Column_DateCalcul.ColumnIndex)) {

						this.col_DateCalcul = sqlDataReader.GetSqlDateTime(SPs.spS_IndexationCalcule_Producteur.Resultset1.Fields.Column_DateCalcul.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_IndexationCalcule_Producteur.Resultset1.Fields.Column_TypeIndexation.ColumnIndex)) {

						this.col_TypeIndexation = sqlDataReader.GetSqlString(SPs.spS_IndexationCalcule_Producteur.Resultset1.Fields.Column_TypeIndexation.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_IndexationCalcule_Producteur.Resultset1.Fields.Column_IndexationID.ColumnIndex)) {

						this.col_IndexationID = sqlDataReader.GetSqlInt32(SPs.spS_IndexationCalcule_Producteur.Resultset1.Fields.Column_IndexationID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_IndexationCalcule_Producteur.Resultset1.Fields.Column_IndexationDetailID.ColumnIndex)) {

						this.col_IndexationDetailID = sqlDataReader.GetSqlInt32(SPs.spS_IndexationCalcule_Producteur.Resultset1.Fields.Column_IndexationDetailID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_IndexationCalcule_Producteur.Resultset1.Fields.Column_LivraisonID.ColumnIndex)) {

						this.col_LivraisonID = sqlDataReader.GetSqlInt32(SPs.spS_IndexationCalcule_Producteur.Resultset1.Fields.Column_LivraisonID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_IndexationCalcule_Producteur.Resultset1.Fields.Column_LivraisonDetailID.ColumnIndex)) {

						this.col_LivraisonDetailID = sqlDataReader.GetSqlInt32(SPs.spS_IndexationCalcule_Producteur.Resultset1.Fields.Column_LivraisonDetailID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_IndexationCalcule_Producteur.Resultset1.Fields.Column_ProducteurID.ColumnIndex)) {

						this.col_ProducteurID = sqlDataReader.GetSqlString(SPs.spS_IndexationCalcule_Producteur.Resultset1.Fields.Column_ProducteurID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_IndexationCalcule_Producteur.Resultset1.Fields.Column_ContratID.ColumnIndex)) {

						this.col_ContratID = sqlDataReader.GetSqlString(SPs.spS_IndexationCalcule_Producteur.Resultset1.Fields.Column_ContratID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_IndexationCalcule_Producteur.Resultset1.Fields.Column_EssenceID.ColumnIndex)) {

						this.col_EssenceID = sqlDataReader.GetSqlString(SPs.spS_IndexationCalcule_Producteur.Resultset1.Fields.Column_EssenceID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_IndexationCalcule_Producteur.Resultset1.Fields.Column_Code.ColumnIndex)) {

						this.col_Code = sqlDataReader.GetSqlString(SPs.spS_IndexationCalcule_Producteur.Resultset1.Fields.Column_Code.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_IndexationCalcule_Producteur.Resultset1.Fields.Column_UniteID.ColumnIndex)) {

						this.col_UniteID = sqlDataReader.GetSqlString(SPs.spS_IndexationCalcule_Producteur.Resultset1.Fields.Column_UniteID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_IndexationCalcule_Producteur.Resultset1.Fields.Column_Volume.ColumnIndex)) {

						this.col_Volume = sqlDataReader.GetSqlDouble(SPs.spS_IndexationCalcule_Producteur.Resultset1.Fields.Column_Volume.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_IndexationCalcule_Producteur.Resultset1.Fields.Column_MontantDejaPaye.ColumnIndex)) {

						this.col_MontantDejaPaye = sqlDataReader.GetSqlDouble(SPs.spS_IndexationCalcule_Producteur.Resultset1.Fields.Column_MontantDejaPaye.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_IndexationCalcule_Producteur.Resultset1.Fields.Column_PourcentageDuMontant.ColumnIndex)) {

						this.col_PourcentageDuMontant = sqlDataReader.GetSqlDouble(SPs.spS_IndexationCalcule_Producteur.Resultset1.Fields.Column_PourcentageDuMontant.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_IndexationCalcule_Producteur.Resultset1.Fields.Column_Taux.ColumnIndex)) {

						this.col_Taux = sqlDataReader.GetSqlDouble(SPs.spS_IndexationCalcule_Producteur.Resultset1.Fields.Column_Taux.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_IndexationCalcule_Producteur.Resultset1.Fields.Column_Montant.ColumnIndex)) {

						this.col_Montant = sqlDataReader.GetSqlDouble(SPs.spS_IndexationCalcule_Producteur.Resultset1.Fields.Column_Montant.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_IndexationCalcule_Producteur.Resultset1.Fields.Column_Facture.ColumnIndex)) {

						this.col_Facture = sqlDataReader.GetSqlBoolean(SPs.spS_IndexationCalcule_Producteur.Resultset1.Fields.Column_Facture.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_IndexationCalcule_Producteur.Resultset1.Fields.Column_FactureID.ColumnIndex)) {

						this.col_FactureID = sqlDataReader.GetSqlInt32(SPs.spS_IndexationCalcule_Producteur.Resultset1.Fields.Column_FactureID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_IndexationCalcule_Producteur.Resultset1.Fields.Column_ErreurCalcul.ColumnIndex)) {

						this.col_ErreurCalcul = sqlDataReader.GetSqlBoolean(SPs.spS_IndexationCalcule_Producteur.Resultset1.Fields.Column_ErreurCalcul.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_IndexationCalcule_Producteur.Resultset1.Fields.Column_ErreurDescription.ColumnIndex)) {

						this.col_ErreurDescription = sqlDataReader.GetSqlString(SPs.spS_IndexationCalcule_Producteur.Resultset1.Fields.Column_ErreurDescription.ColumnIndex);
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

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.IndexationCalcule_Producteur_Record", "Refresh");
			}
		}

		public void Update() {

			if (!this.recordWasLoadedFromDB) {

				throw new ArgumentException("No record was loaded from the database. No update is possible.");
			}

			bool ChangesHaveBeenMade = false;

			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_DateCalculWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_TypeIndexationWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_IndexationIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_IndexationDetailIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_LivraisonIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_LivraisonDetailIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_ProducteurIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_ContratIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_EssenceIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_CodeWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_UniteIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_VolumeWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_MontantDejaPayeWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_PourcentageDuMontantWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_TauxWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_MontantWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_FactureWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_FactureIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_ErreurCalculWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_ErreurDescriptionWasUpdated);

			if (!ChangesHaveBeenMade) {

				return;
			}

			Params.spU_IndexationCalcule_Producteur Param = new Params.spU_IndexationCalcule_Producteur(false);
			Param.SetUpConnection(this.connectionString);
			Param.Param_ID = this.col_ID;

			if (this.col_DateCalculWasUpdated) {

				Param.Param_DateCalcul = this.col_DateCalcul;
				Param.Param_ConsiderNull_DateCalcul = true;
			}

			if (this.col_TypeIndexationWasUpdated) {

				Param.Param_TypeIndexation = this.col_TypeIndexation;
				Param.Param_ConsiderNull_TypeIndexation = true;
			}

			if (this.col_IndexationIDWasUpdated) {

				Param.Param_IndexationID = this.col_IndexationID;
				Param.Param_ConsiderNull_IndexationID = true;
			}

			if (this.col_IndexationDetailIDWasUpdated) {

				Param.Param_IndexationDetailID = this.col_IndexationDetailID;
				Param.Param_ConsiderNull_IndexationDetailID = true;
			}

			if (this.col_LivraisonIDWasUpdated) {

				Param.Param_LivraisonID = this.col_LivraisonID;
				Param.Param_ConsiderNull_LivraisonID = true;
			}

			if (this.col_LivraisonDetailIDWasUpdated) {

				Param.Param_LivraisonDetailID = this.col_LivraisonDetailID;
				Param.Param_ConsiderNull_LivraisonDetailID = true;
			}

			if (this.col_ProducteurIDWasUpdated) {

				Param.Param_ProducteurID = this.col_ProducteurID;
				Param.Param_ConsiderNull_ProducteurID = true;
			}

			if (this.col_ContratIDWasUpdated) {

				Param.Param_ContratID = this.col_ContratID;
				Param.Param_ConsiderNull_ContratID = true;
			}

			if (this.col_EssenceIDWasUpdated) {

				Param.Param_EssenceID = this.col_EssenceID;
				Param.Param_ConsiderNull_EssenceID = true;
			}

			if (this.col_CodeWasUpdated) {

				Param.Param_Code = this.col_Code;
				Param.Param_ConsiderNull_Code = true;
			}

			if (this.col_UniteIDWasUpdated) {

				Param.Param_UniteID = this.col_UniteID;
				Param.Param_ConsiderNull_UniteID = true;
			}

			if (this.col_VolumeWasUpdated) {

				Param.Param_Volume = this.col_Volume;
				Param.Param_ConsiderNull_Volume = true;
			}

			if (this.col_MontantDejaPayeWasUpdated) {

				Param.Param_MontantDejaPaye = this.col_MontantDejaPaye;
				Param.Param_ConsiderNull_MontantDejaPaye = true;
			}

			if (this.col_PourcentageDuMontantWasUpdated) {

				Param.Param_PourcentageDuMontant = this.col_PourcentageDuMontant;
				Param.Param_ConsiderNull_PourcentageDuMontant = true;
			}

			if (this.col_TauxWasUpdated) {

				Param.Param_Taux = this.col_Taux;
				Param.Param_ConsiderNull_Taux = true;
			}

			if (this.col_MontantWasUpdated) {

				Param.Param_Montant = this.col_Montant;
				Param.Param_ConsiderNull_Montant = true;
			}

			if (this.col_FactureWasUpdated) {

				Param.Param_Facture = this.col_Facture;
				Param.Param_ConsiderNull_Facture = true;
			}

			if (this.col_FactureIDWasUpdated) {

				Param.Param_FactureID = this.col_FactureID;
				Param.Param_ConsiderNull_FactureID = true;
			}

			if (this.col_ErreurCalculWasUpdated) {

				Param.Param_ErreurCalcul = this.col_ErreurCalcul;
				Param.Param_ConsiderNull_ErreurCalcul = true;
			}

			if (this.col_ErreurDescriptionWasUpdated) {

				Param.Param_ErreurDescription = this.col_ErreurDescription;
				Param.Param_ConsiderNull_ErreurDescription = true;
			}

			SPs.spU_IndexationCalcule_Producteur Sp = new SPs.spU_IndexationCalcule_Producteur();
			if (Sp.Execute(ref Param)) {

				this.col_DateCalculWasUpdated = false;
				this.col_TypeIndexationWasUpdated = false;
				this.col_IndexationIDWasUpdated = false;
				this.col_IndexationDetailIDWasUpdated = false;
				this.col_LivraisonIDWasUpdated = false;
				this.col_LivraisonDetailIDWasUpdated = false;
				this.col_ProducteurIDWasUpdated = false;
				this.col_ContratIDWasUpdated = false;
				this.col_EssenceIDWasUpdated = false;
				this.col_CodeWasUpdated = false;
				this.col_UniteIDWasUpdated = false;
				this.col_VolumeWasUpdated = false;
				this.col_MontantDejaPayeWasUpdated = false;
				this.col_PourcentageDuMontantWasUpdated = false;
				this.col_TauxWasUpdated = false;
				this.col_MontantWasUpdated = false;
				this.col_FactureWasUpdated = false;
				this.col_FactureIDWasUpdated = false;
				this.col_ErreurCalculWasUpdated = false;
				this.col_ErreurDescriptionWasUpdated = false;
			}
			else {

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.IndexationCalcule_Producteur_Record", "Update");
			}		
		}

		internal string displayName = null;
		public override string ToString() {

			if (!this.recordWasLoadedFromDB) {

				throw new ArgumentException("No record was loaded from the database. The DisplayName is not available.");
			}
		
			if (this.displayName == null) {
			
				Params.spS_IndexationCalcule_Producteur_Display Param = new Params.spS_IndexationCalcule_Producteur_Display();
				Param.SetUpConnection(this.connectionString);

				Param.Param_ID = this.col_ID;

				System.Data.SqlClient.SqlDataReader sqlDataReader = null;
				SPs.spS_IndexationCalcule_Producteur_Display Sp = new SPs.spS_IndexationCalcule_Producteur_Display();
				if (Sp.Execute(ref Param, out sqlDataReader)) {

					if (sqlDataReader.Read()) {

						if (!sqlDataReader.IsDBNull(SPs.spS_IndexationCalcule_Producteur_Display.Resultset1.Fields.Column_Display.ColumnIndex)) {

							this.displayName = "spS_IndexationCalcule_Producteur_Display";
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

					throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.IndexationCalcule_Producteur_Record", "ToString");
				}				
			}
			
			return(this.displayName);
		}
	}
}
