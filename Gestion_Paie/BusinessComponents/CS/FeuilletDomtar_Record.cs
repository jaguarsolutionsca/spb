using System;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.BusinessComponents {

	/// <summary>
	/// This class is an abstract class that represents the [FeuilletDomtar] table. With this class
	/// you can load or update a record from the database. If you need to add or delete a record,
	/// you must use the <see cref="Gestion_Paie.BusinessComponents.FeuilletDomtar_Collection"/> class to do so.
	/// </summary>
	public sealed class FeuilletDomtar_Record : IBusinessComponentRecord {
	
		internal bool recordWasLoadedFromDB = false;
		private bool recordIsLoaded = false;

		internal string connectionString = String.Empty;
		public string ConnectionString {
		
			get {
			
				return(this.connectionString);
			}
		}
		
		/// <summary>
		/// Initializes a new instance of the FeuilletDomtar_Record class. Use this contructor to add
		/// a new record. Then call the Add method of the Gestion_Paie.BusinessComponents.FeuilletDomtar_Collection class to actually
		/// add the record in the database.
		/// </summary>
		public FeuilletDomtar_Record() {
		
			this.recordWasLoadedFromDB = false;
			this.recordIsLoaded = false;
		}
	
		/// <param name="col_Transaction">[To be supplied.]</param>
		public FeuilletDomtar_Record(string connectionString, System.Data.SqlTypes.SqlString col_Transaction) {

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
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'FeuilletDomtar'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}", "FeuilletDomtar", CurrentRevision, OriginalRevision));
					}
				}
			}
#endif

			this.recordWasLoadedFromDB = true;
			this.recordIsLoaded = false;
			this.connectionString = connectionString;
			this.col_Transaction = col_Transaction;
		}
		
		internal System.Data.SqlTypes.SqlString col_Transaction = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_Transaction {
		
			get {
			
				return(this.col_Transaction);
			}

			set {

				if (this.recordWasLoadedFromDB) {

					throw new System.Exception("You cannot affect this primary key since the record was loaded from the database.");
				}
				else {

					this.col_Transaction = value;
				}
			}
		}
		
		internal bool col_TransactionTypeWasSet = false;
		private bool col_TransactionTypeWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_TransactionType = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_TransactionType {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_TransactionType);
			}
			set {
			
				this.col_TransactionTypeWasUpdated = true;
				this.col_TransactionTypeWasSet = true;
				this.col_TransactionType = value;
			}
		}

		internal bool col_FournisseurWasSet = false;
		private bool col_FournisseurWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_Fournisseur = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_Fournisseur {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Fournisseur);
			}
			set {
			
				this.col_FournisseurWasUpdated = true;
				this.col_FournisseurWasSet = true;
				this.col_Fournisseur = value;
			}
		}

		internal bool col_ContratWasSet = false;
		private bool col_ContratWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_Contrat = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_Contrat {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Contrat);
			}
			set {
			
				this.col_ContratWasUpdated = true;
				this.col_ContratWasSet = true;
				this.col_Contrat = value;
			}
		}

		internal bool col_ProduitWasSet = false;
		private bool col_ProduitWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_Produit = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_Produit {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Produit);
			}
			set {
			
				this.col_ProduitWasUpdated = true;
				this.col_ProduitWasSet = true;
				this.col_Produit = value;
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

		internal bool col_CarteWasSet = false;
		private bool col_CarteWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_Carte = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_Carte {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Carte);
			}
			set {
			
				this.col_CarteWasUpdated = true;
				this.col_CarteWasSet = true;
				this.col_Carte = value;
			}
		}

		internal bool col_LicenseWasSet = false;
		private bool col_LicenseWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_License = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_License {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_License);
			}
			set {
			
				this.col_LicenseWasUpdated = true;
				this.col_LicenseWasSet = true;
				this.col_License = value;
			}
		}

		internal bool col_Transporteur_CamionWasSet = false;
		private bool col_Transporteur_CamionWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_Transporteur_Camion = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_Transporteur_Camion {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Transporteur_Camion);
			}
			set {
			
				this.col_Transporteur_CamionWasUpdated = true;
				this.col_Transporteur_CamionWasSet = true;
				this.col_Transporteur_Camion = value;
			}
		}

		internal bool col_ProducteurWasSet = false;
		private bool col_ProducteurWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_Producteur = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_Producteur {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Producteur);
			}
			set {
			
				this.col_ProducteurWasUpdated = true;
				this.col_ProducteurWasSet = true;
				this.col_Producteur = value;
			}
		}

		internal bool col_MunicipaliteWasSet = false;
		private bool col_MunicipaliteWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_Municipalite = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_Municipalite {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Municipalite);
			}
			set {
			
				this.col_MunicipaliteWasUpdated = true;
				this.col_MunicipaliteWasSet = true;
				this.col_Municipalite = value;
			}
		}

		internal bool col_BrutWasSet = false;
		private bool col_BrutWasUpdated = false;
		internal System.Data.SqlTypes.SqlInt32 col_Brut = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_Brut {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Brut);
			}
			set {
			
				this.col_BrutWasUpdated = true;
				this.col_BrutWasSet = true;
				this.col_Brut = value;
			}
		}

		internal bool col_TareWasSet = false;
		private bool col_TareWasUpdated = false;
		internal System.Data.SqlTypes.SqlInt32 col_Tare = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_Tare {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Tare);
			}
			set {
			
				this.col_TareWasUpdated = true;
				this.col_TareWasSet = true;
				this.col_Tare = value;
			}
		}

		internal bool col_NetWasSet = false;
		private bool col_NetWasUpdated = false;
		internal System.Data.SqlTypes.SqlInt32 col_Net = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_Net {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Net);
			}
			set {
			
				this.col_NetWasUpdated = true;
				this.col_NetWasSet = true;
				this.col_Net = value;
			}
		}

		internal bool col_RejetsWasSet = false;
		private bool col_RejetsWasUpdated = false;
		internal System.Data.SqlTypes.SqlInt32 col_Rejets = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_Rejets {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Rejets);
			}
			set {
			
				this.col_RejetsWasUpdated = true;
				this.col_RejetsWasSet = true;
				this.col_Rejets = value;
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

		internal bool col_Pourcent_SecWasSet = false;
		private bool col_Pourcent_SecWasUpdated = false;
		internal System.Data.SqlTypes.SqlDouble col_Pourcent_Sec = System.Data.SqlTypes.SqlDouble.Null;
		public System.Data.SqlTypes.SqlDouble Col_Pourcent_Sec {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Pourcent_Sec);
			}
			set {
			
				this.col_Pourcent_SecWasUpdated = true;
				this.col_Pourcent_SecWasSet = true;
				this.col_Pourcent_Sec = value;
			}
		}

		internal bool col_KgSec_PayeWasSet = false;
		private bool col_KgSec_PayeWasUpdated = false;
		internal System.Data.SqlTypes.SqlInt32 col_KgSec_Paye = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_KgSec_Paye {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_KgSec_Paye);
			}
			set {
			
				this.col_KgSec_PayeWasUpdated = true;
				this.col_KgSec_PayeWasSet = true;
				this.col_KgSec_Paye = value;
			}
		}

		internal bool col_ValidationWasSet = false;
		private bool col_ValidationWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_Validation = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_Validation {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Validation);
			}
			set {
			
				this.col_ValidationWasUpdated = true;
				this.col_ValidationWasSet = true;
				this.col_Validation = value;
			}
		}

		internal bool col_TransfertWasSet = false;
		private bool col_TransfertWasUpdated = false;
		internal System.Data.SqlTypes.SqlBoolean col_Transfert = System.Data.SqlTypes.SqlBoolean.Null;
		public System.Data.SqlTypes.SqlBoolean Col_Transfert {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Transfert);
			}
			set {
			
				this.col_TransfertWasUpdated = true;
				this.col_TransfertWasSet = true;
				this.col_Transfert = value;
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
				this.col_EssenceID = value;
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
				this.col_UniteID = value;
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
				this.col_TransporteurID = value;
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

			this.col_TransactionTypeWasUpdated = false;
			this.col_TransactionTypeWasSet = false;
			this.col_TransactionType = System.Data.SqlTypes.SqlString.Null;

			this.col_FournisseurWasUpdated = false;
			this.col_FournisseurWasSet = false;
			this.col_Fournisseur = System.Data.SqlTypes.SqlString.Null;

			this.col_ContratWasUpdated = false;
			this.col_ContratWasSet = false;
			this.col_Contrat = System.Data.SqlTypes.SqlString.Null;

			this.col_ProduitWasUpdated = false;
			this.col_ProduitWasSet = false;
			this.col_Produit = System.Data.SqlTypes.SqlString.Null;

			this.col_DateLivraisonWasUpdated = false;
			this.col_DateLivraisonWasSet = false;
			this.col_DateLivraison = System.Data.SqlTypes.SqlDateTime.Null;

			this.col_CarteWasUpdated = false;
			this.col_CarteWasSet = false;
			this.col_Carte = System.Data.SqlTypes.SqlString.Null;

			this.col_LicenseWasUpdated = false;
			this.col_LicenseWasSet = false;
			this.col_License = System.Data.SqlTypes.SqlString.Null;

			this.col_Transporteur_CamionWasUpdated = false;
			this.col_Transporteur_CamionWasSet = false;
			this.col_Transporteur_Camion = System.Data.SqlTypes.SqlString.Null;

			this.col_ProducteurWasUpdated = false;
			this.col_ProducteurWasSet = false;
			this.col_Producteur = System.Data.SqlTypes.SqlString.Null;

			this.col_MunicipaliteWasUpdated = false;
			this.col_MunicipaliteWasSet = false;
			this.col_Municipalite = System.Data.SqlTypes.SqlString.Null;

			this.col_BrutWasUpdated = false;
			this.col_BrutWasSet = false;
			this.col_Brut = System.Data.SqlTypes.SqlInt32.Null;

			this.col_TareWasUpdated = false;
			this.col_TareWasSet = false;
			this.col_Tare = System.Data.SqlTypes.SqlInt32.Null;

			this.col_NetWasUpdated = false;
			this.col_NetWasSet = false;
			this.col_Net = System.Data.SqlTypes.SqlInt32.Null;

			this.col_RejetsWasUpdated = false;
			this.col_RejetsWasSet = false;
			this.col_Rejets = System.Data.SqlTypes.SqlInt32.Null;

			this.col_KgVert_PayeWasUpdated = false;
			this.col_KgVert_PayeWasSet = false;
			this.col_KgVert_Paye = System.Data.SqlTypes.SqlInt32.Null;

			this.col_Pourcent_SecWasUpdated = false;
			this.col_Pourcent_SecWasSet = false;
			this.col_Pourcent_Sec = System.Data.SqlTypes.SqlDouble.Null;

			this.col_KgSec_PayeWasUpdated = false;
			this.col_KgSec_PayeWasSet = false;
			this.col_KgSec_Paye = System.Data.SqlTypes.SqlInt32.Null;

			this.col_ValidationWasUpdated = false;
			this.col_ValidationWasSet = false;
			this.col_Validation = System.Data.SqlTypes.SqlString.Null;

			this.col_TransfertWasUpdated = false;
			this.col_TransfertWasSet = false;
			this.col_Transfert = System.Data.SqlTypes.SqlBoolean.Null;

			this.col_EssenceIDWasUpdated = false;
			this.col_EssenceIDWasSet = false;
			this.col_EssenceID = System.Data.SqlTypes.SqlString.Null;

			this.col_UniteIDWasUpdated = false;
			this.col_UniteIDWasSet = false;
			this.col_UniteID = System.Data.SqlTypes.SqlString.Null;

			this.col_CodeWasUpdated = false;
			this.col_CodeWasSet = false;
			this.col_Code = System.Data.SqlTypes.SqlString.Null;

			this.col_TransporteurIDWasUpdated = false;
			this.col_TransporteurIDWasSet = false;
			this.col_TransporteurID = System.Data.SqlTypes.SqlString.Null;

			this.col_BonCommandeWasUpdated = false;
			this.col_BonCommandeWasSet = false;
			this.col_BonCommande = System.Data.SqlTypes.SqlString.Null;

			Params.spS_FeuilletDomtar Param = new Params.spS_FeuilletDomtar(true);
			Param.SetUpConnection(this.connectionString);

			if (!this.col_Transaction.IsNull) {

				Param.Param_Transaction = this.col_Transaction;
			}


			System.Data.SqlClient.SqlDataReader sqlDataReader = null;
			SPs.spS_FeuilletDomtar Sp = new SPs.spS_FeuilletDomtar();
			if (Sp.Execute(ref Param, out sqlDataReader)) {

				if (sqlDataReader.Read()) {

					if (!sqlDataReader.IsDBNull(SPs.spS_FeuilletDomtar.Resultset1.Fields.Column_TransactionType.ColumnIndex)) {

						this.col_TransactionType = sqlDataReader.GetSqlString(SPs.spS_FeuilletDomtar.Resultset1.Fields.Column_TransactionType.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_FeuilletDomtar.Resultset1.Fields.Column_Fournisseur.ColumnIndex)) {

						this.col_Fournisseur = sqlDataReader.GetSqlString(SPs.spS_FeuilletDomtar.Resultset1.Fields.Column_Fournisseur.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_FeuilletDomtar.Resultset1.Fields.Column_Contrat.ColumnIndex)) {

						this.col_Contrat = sqlDataReader.GetSqlString(SPs.spS_FeuilletDomtar.Resultset1.Fields.Column_Contrat.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_FeuilletDomtar.Resultset1.Fields.Column_Produit.ColumnIndex)) {

						this.col_Produit = sqlDataReader.GetSqlString(SPs.spS_FeuilletDomtar.Resultset1.Fields.Column_Produit.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_FeuilletDomtar.Resultset1.Fields.Column_DateLivraison.ColumnIndex)) {

						this.col_DateLivraison = sqlDataReader.GetSqlDateTime(SPs.spS_FeuilletDomtar.Resultset1.Fields.Column_DateLivraison.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_FeuilletDomtar.Resultset1.Fields.Column_Carte.ColumnIndex)) {

						this.col_Carte = sqlDataReader.GetSqlString(SPs.spS_FeuilletDomtar.Resultset1.Fields.Column_Carte.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_FeuilletDomtar.Resultset1.Fields.Column_License.ColumnIndex)) {

						this.col_License = sqlDataReader.GetSqlString(SPs.spS_FeuilletDomtar.Resultset1.Fields.Column_License.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_FeuilletDomtar.Resultset1.Fields.Column_Transporteur_Camion.ColumnIndex)) {

						this.col_Transporteur_Camion = sqlDataReader.GetSqlString(SPs.spS_FeuilletDomtar.Resultset1.Fields.Column_Transporteur_Camion.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_FeuilletDomtar.Resultset1.Fields.Column_Producteur.ColumnIndex)) {

						this.col_Producteur = sqlDataReader.GetSqlString(SPs.spS_FeuilletDomtar.Resultset1.Fields.Column_Producteur.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_FeuilletDomtar.Resultset1.Fields.Column_Municipalite.ColumnIndex)) {

						this.col_Municipalite = sqlDataReader.GetSqlString(SPs.spS_FeuilletDomtar.Resultset1.Fields.Column_Municipalite.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_FeuilletDomtar.Resultset1.Fields.Column_Brut.ColumnIndex)) {

						this.col_Brut = sqlDataReader.GetSqlInt32(SPs.spS_FeuilletDomtar.Resultset1.Fields.Column_Brut.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_FeuilletDomtar.Resultset1.Fields.Column_Tare.ColumnIndex)) {

						this.col_Tare = sqlDataReader.GetSqlInt32(SPs.spS_FeuilletDomtar.Resultset1.Fields.Column_Tare.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_FeuilletDomtar.Resultset1.Fields.Column_Net.ColumnIndex)) {

						this.col_Net = sqlDataReader.GetSqlInt32(SPs.spS_FeuilletDomtar.Resultset1.Fields.Column_Net.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_FeuilletDomtar.Resultset1.Fields.Column_Rejets.ColumnIndex)) {

						this.col_Rejets = sqlDataReader.GetSqlInt32(SPs.spS_FeuilletDomtar.Resultset1.Fields.Column_Rejets.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_FeuilletDomtar.Resultset1.Fields.Column_KgVert_Paye.ColumnIndex)) {

						this.col_KgVert_Paye = sqlDataReader.GetSqlInt32(SPs.spS_FeuilletDomtar.Resultset1.Fields.Column_KgVert_Paye.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_FeuilletDomtar.Resultset1.Fields.Column_Pourcent_Sec.ColumnIndex)) {

						this.col_Pourcent_Sec = sqlDataReader.GetSqlDouble(SPs.spS_FeuilletDomtar.Resultset1.Fields.Column_Pourcent_Sec.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_FeuilletDomtar.Resultset1.Fields.Column_KgSec_Paye.ColumnIndex)) {

						this.col_KgSec_Paye = sqlDataReader.GetSqlInt32(SPs.spS_FeuilletDomtar.Resultset1.Fields.Column_KgSec_Paye.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_FeuilletDomtar.Resultset1.Fields.Column_Validation.ColumnIndex)) {

						this.col_Validation = sqlDataReader.GetSqlString(SPs.spS_FeuilletDomtar.Resultset1.Fields.Column_Validation.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_FeuilletDomtar.Resultset1.Fields.Column_Transfert.ColumnIndex)) {

						this.col_Transfert = sqlDataReader.GetSqlBoolean(SPs.spS_FeuilletDomtar.Resultset1.Fields.Column_Transfert.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_FeuilletDomtar.Resultset1.Fields.Column_EssenceID.ColumnIndex)) {

						this.col_EssenceID = sqlDataReader.GetSqlString(SPs.spS_FeuilletDomtar.Resultset1.Fields.Column_EssenceID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_FeuilletDomtar.Resultset1.Fields.Column_UniteID.ColumnIndex)) {

						this.col_UniteID = sqlDataReader.GetSqlString(SPs.spS_FeuilletDomtar.Resultset1.Fields.Column_UniteID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_FeuilletDomtar.Resultset1.Fields.Column_Code.ColumnIndex)) {

						this.col_Code = sqlDataReader.GetSqlString(SPs.spS_FeuilletDomtar.Resultset1.Fields.Column_Code.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_FeuilletDomtar.Resultset1.Fields.Column_TransporteurID.ColumnIndex)) {

						this.col_TransporteurID = sqlDataReader.GetSqlString(SPs.spS_FeuilletDomtar.Resultset1.Fields.Column_TransporteurID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_FeuilletDomtar.Resultset1.Fields.Column_BonCommande.ColumnIndex)) {

						this.col_BonCommande = sqlDataReader.GetSqlString(SPs.spS_FeuilletDomtar.Resultset1.Fields.Column_BonCommande.ColumnIndex);
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

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.FeuilletDomtar_Record", "Refresh");
			}
		}

		public void Update() {

			if (!this.recordWasLoadedFromDB) {

				throw new ArgumentException("No record was loaded from the database. No update is possible.");
			}

			bool ChangesHaveBeenMade = false;

			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_TransactionTypeWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_FournisseurWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_ContratWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_ProduitWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_DateLivraisonWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_CarteWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_LicenseWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Transporteur_CamionWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_ProducteurWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_MunicipaliteWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_BrutWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_TareWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_NetWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_RejetsWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_KgVert_PayeWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Pourcent_SecWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_KgSec_PayeWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_ValidationWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_TransfertWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_EssenceIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_UniteIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_CodeWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_TransporteurIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_BonCommandeWasUpdated);

			if (!ChangesHaveBeenMade) {

				return;
			}

			Params.spU_FeuilletDomtar Param = new Params.spU_FeuilletDomtar(false);
			Param.SetUpConnection(this.connectionString);
			Param.Param_Transaction = this.col_Transaction;

			if (this.col_TransactionTypeWasUpdated) {

				Param.Param_TransactionType = this.col_TransactionType;
				Param.Param_ConsiderNull_TransactionType = true;
			}

			if (this.col_FournisseurWasUpdated) {

				Param.Param_Fournisseur = this.col_Fournisseur;
				Param.Param_ConsiderNull_Fournisseur = true;
			}

			if (this.col_ContratWasUpdated) {

				Param.Param_Contrat = this.col_Contrat;
				Param.Param_ConsiderNull_Contrat = true;
			}

			if (this.col_ProduitWasUpdated) {

				Param.Param_Produit = this.col_Produit;
				Param.Param_ConsiderNull_Produit = true;
			}

			if (this.col_DateLivraisonWasUpdated) {

				Param.Param_DateLivraison = this.col_DateLivraison;
				Param.Param_ConsiderNull_DateLivraison = true;
			}

			if (this.col_CarteWasUpdated) {

				Param.Param_Carte = this.col_Carte;
				Param.Param_ConsiderNull_Carte = true;
			}

			if (this.col_LicenseWasUpdated) {

				Param.Param_License = this.col_License;
				Param.Param_ConsiderNull_License = true;
			}

			if (this.col_Transporteur_CamionWasUpdated) {

				Param.Param_Transporteur_Camion = this.col_Transporteur_Camion;
				Param.Param_ConsiderNull_Transporteur_Camion = true;
			}

			if (this.col_ProducteurWasUpdated) {

				Param.Param_Producteur = this.col_Producteur;
				Param.Param_ConsiderNull_Producteur = true;
			}

			if (this.col_MunicipaliteWasUpdated) {

				Param.Param_Municipalite = this.col_Municipalite;
				Param.Param_ConsiderNull_Municipalite = true;
			}

			if (this.col_BrutWasUpdated) {

				Param.Param_Brut = this.col_Brut;
				Param.Param_ConsiderNull_Brut = true;
			}

			if (this.col_TareWasUpdated) {

				Param.Param_Tare = this.col_Tare;
				Param.Param_ConsiderNull_Tare = true;
			}

			if (this.col_NetWasUpdated) {

				Param.Param_Net = this.col_Net;
				Param.Param_ConsiderNull_Net = true;
			}

			if (this.col_RejetsWasUpdated) {

				Param.Param_Rejets = this.col_Rejets;
				Param.Param_ConsiderNull_Rejets = true;
			}

			if (this.col_KgVert_PayeWasUpdated) {

				Param.Param_KgVert_Paye = this.col_KgVert_Paye;
				Param.Param_ConsiderNull_KgVert_Paye = true;
			}

			if (this.col_Pourcent_SecWasUpdated) {

				Param.Param_Pourcent_Sec = this.col_Pourcent_Sec;
				Param.Param_ConsiderNull_Pourcent_Sec = true;
			}

			if (this.col_KgSec_PayeWasUpdated) {

				Param.Param_KgSec_Paye = this.col_KgSec_Paye;
				Param.Param_ConsiderNull_KgSec_Paye = true;
			}

			if (this.col_ValidationWasUpdated) {

				Param.Param_Validation = this.col_Validation;
				Param.Param_ConsiderNull_Validation = true;
			}

			if (this.col_TransfertWasUpdated) {

				Param.Param_Transfert = this.col_Transfert;
				Param.Param_ConsiderNull_Transfert = true;
			}

			if (this.col_EssenceIDWasUpdated) {

				Param.Param_EssenceID = this.col_EssenceID;
				Param.Param_ConsiderNull_EssenceID = true;
			}

			if (this.col_UniteIDWasUpdated) {

				Param.Param_UniteID = this.col_UniteID;
				Param.Param_ConsiderNull_UniteID = true;
			}

			if (this.col_CodeWasUpdated) {

				Param.Param_Code = this.col_Code;
				Param.Param_ConsiderNull_Code = true;
			}

			if (this.col_TransporteurIDWasUpdated) {

				Param.Param_TransporteurID = this.col_TransporteurID;
				Param.Param_ConsiderNull_TransporteurID = true;
			}

			if (this.col_BonCommandeWasUpdated) {

				Param.Param_BonCommande = this.col_BonCommande;
				Param.Param_ConsiderNull_BonCommande = true;
			}

			SPs.spU_FeuilletDomtar Sp = new SPs.spU_FeuilletDomtar();
			if (Sp.Execute(ref Param)) {

				this.col_TransactionTypeWasUpdated = false;
				this.col_FournisseurWasUpdated = false;
				this.col_ContratWasUpdated = false;
				this.col_ProduitWasUpdated = false;
				this.col_DateLivraisonWasUpdated = false;
				this.col_CarteWasUpdated = false;
				this.col_LicenseWasUpdated = false;
				this.col_Transporteur_CamionWasUpdated = false;
				this.col_ProducteurWasUpdated = false;
				this.col_MunicipaliteWasUpdated = false;
				this.col_BrutWasUpdated = false;
				this.col_TareWasUpdated = false;
				this.col_NetWasUpdated = false;
				this.col_RejetsWasUpdated = false;
				this.col_KgVert_PayeWasUpdated = false;
				this.col_Pourcent_SecWasUpdated = false;
				this.col_KgSec_PayeWasUpdated = false;
				this.col_ValidationWasUpdated = false;
				this.col_TransfertWasUpdated = false;
				this.col_EssenceIDWasUpdated = false;
				this.col_UniteIDWasUpdated = false;
				this.col_CodeWasUpdated = false;
				this.col_TransporteurIDWasUpdated = false;
				this.col_BonCommandeWasUpdated = false;
			}
			else {

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.FeuilletDomtar_Record", "Update");
			}		
		}

		internal string displayName = null;
		public override string ToString() {

			if (!this.recordWasLoadedFromDB) {

				throw new ArgumentException("No record was loaded from the database. The DisplayName is not available.");
			}
		
			if (this.displayName == null) {
			
				Params.spS_FeuilletDomtar_Display Param = new Params.spS_FeuilletDomtar_Display();
				Param.SetUpConnection(this.connectionString);

				Param.Param_Transaction = this.col_Transaction;

				System.Data.SqlClient.SqlDataReader sqlDataReader = null;
				SPs.spS_FeuilletDomtar_Display Sp = new SPs.spS_FeuilletDomtar_Display();
				if (Sp.Execute(ref Param, out sqlDataReader)) {

					if (sqlDataReader.Read()) {

						if (!sqlDataReader.IsDBNull(SPs.spS_FeuilletDomtar_Display.Resultset1.Fields.Column_Display.ColumnIndex)) {

							this.displayName = "spS_FeuilletDomtar_Display";
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

					throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.FeuilletDomtar_Record", "ToString");
				}				
			}
			
			return(this.displayName);
		}
	}
}
