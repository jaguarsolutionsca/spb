using System;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.BusinessComponents {

	/// <summary>
	/// This class is an abstract class that represents the [FactureFournisseur] table. With this class
	/// you can load or update a record from the database. If you need to add or delete a record,
	/// you must use the <see cref="Gestion_Paie.BusinessComponents.FactureFournisseur_Collection"/> class to do so.
	/// </summary>
	public sealed class FactureFournisseur_Record : IBusinessComponentRecord {
	
		internal bool recordWasLoadedFromDB = false;
		private bool recordIsLoaded = false;

		internal string connectionString = String.Empty;
		public string ConnectionString {
		
			get {
			
				return(this.connectionString);
			}
		}
		
		/// <summary>
		/// Initializes a new instance of the FactureFournisseur_Record class. Use this contructor to add
		/// a new record. Then call the Add method of the Gestion_Paie.BusinessComponents.FactureFournisseur_Collection class to actually
		/// add the record in the database.
		/// </summary>
		public FactureFournisseur_Record() {
		
			this.recordWasLoadedFromDB = false;
			this.recordIsLoaded = false;
		}
	
		/// <param name="col_ID">[To be supplied.]</param>
		public FactureFournisseur_Record(string connectionString, System.Data.SqlTypes.SqlInt32 col_ID) {

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
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'FactureFournisseur'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}", "FactureFournisseur", CurrentRevision, OriginalRevision));
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
		
		internal bool col_NoFactureWasSet = false;
		private bool col_NoFactureWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_NoFacture = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_NoFacture {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_NoFacture);
			}
			set {
			
				this.col_NoFactureWasUpdated = true;
				this.col_NoFactureWasSet = true;
				this.col_NoFacture = value;
			}
		}

		internal bool col_DateFactureWasSet = false;
		private bool col_DateFactureWasUpdated = false;
		internal System.Data.SqlTypes.SqlDateTime col_DateFacture = System.Data.SqlTypes.SqlDateTime.Null;
		public System.Data.SqlTypes.SqlDateTime Col_DateFacture {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_DateFacture);
			}
			set {
			
				this.col_DateFactureWasUpdated = true;
				this.col_DateFactureWasSet = true;
				this.col_DateFacture = value;
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

		internal bool col_TypeFactureFournisseurWasSet = false;
		private bool col_TypeFactureFournisseurWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_TypeFactureFournisseur = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_TypeFactureFournisseur {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_TypeFactureFournisseur);
			}
			set {
			
				this.col_TypeFactureFournisseurWasUpdated = true;
				this.col_TypeFactureFournisseurWasSet = true;
				this.col_TypeFactureFournisseur_Record = null;
				this.col_TypeFactureFournisseur = value;
			}
		}

		
		private TypeFactureFournisseur_Record col_TypeFactureFournisseur_Record = null;
		public TypeFactureFournisseur_Record Col_TypeFactureFournisseur_TypeFactureFournisseur_Record {
		
			get {

				if (this.col_TypeFactureFournisseur_Record == null) {
				
					this.col_TypeFactureFournisseur_Record = new TypeFactureFournisseur_Record(this.connectionString, this.col_TypeFactureFournisseur);
				}
				
				return(this.col_TypeFactureFournisseur_Record);
			}
		}

		internal bool col_TypeFactureWasSet = false;
		private bool col_TypeFactureWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_TypeFacture = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_TypeFacture {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_TypeFacture);
			}
			set {
			
				this.col_TypeFactureWasUpdated = true;
				this.col_TypeFactureWasSet = true;
				this.col_TypeFacture_Record = null;
				this.col_TypeFacture = value;
			}
		}

		
		private TypeFacture_Record col_TypeFacture_Record = null;
		public TypeFacture_Record Col_TypeFacture_TypeFacture_Record {
		
			get {

				if (this.col_TypeFacture_Record == null) {
				
					this.col_TypeFacture_Record = new TypeFacture_Record(this.connectionString, this.col_TypeFacture);
				}
				
				return(this.col_TypeFacture_Record);
			}
		}

		internal bool col_TypeInvoiceAcombaWasSet = false;
		private bool col_TypeInvoiceAcombaWasUpdated = false;
		internal System.Data.SqlTypes.SqlInt32 col_TypeInvoiceAcomba = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_TypeInvoiceAcomba {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_TypeInvoiceAcomba);
			}
			set {
			
				this.col_TypeInvoiceAcombaWasUpdated = true;
				this.col_TypeInvoiceAcombaWasSet = true;
				this.col_TypeInvoiceAcomba_Record = null;
				this.col_TypeInvoiceAcomba = value;
			}
		}

		
		private TypeInvoiceAcomba_Record col_TypeInvoiceAcomba_Record = null;
		public TypeInvoiceAcomba_Record Col_TypeInvoiceAcomba_TypeInvoiceAcomba_Record {
		
			get {

				if (this.col_TypeInvoiceAcomba_Record == null) {
				
					this.col_TypeInvoiceAcomba_Record = new TypeInvoiceAcomba_Record(this.connectionString, this.col_TypeInvoiceAcomba);
				}
				
				return(this.col_TypeInvoiceAcomba_Record);
			}
		}

		internal bool col_FournisseurIDWasSet = false;
		private bool col_FournisseurIDWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_FournisseurID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_FournisseurID {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_FournisseurID);
			}
			set {
			
				this.col_FournisseurIDWasUpdated = true;
				this.col_FournisseurIDWasSet = true;
				this.col_FournisseurID_Record = null;
				this.col_FournisseurID = value;
			}
		}

		
		private Fournisseur_Record col_FournisseurID_Record = null;
		public Fournisseur_Record Col_FournisseurID_Fournisseur_Record {
		
			get {

				if (this.col_FournisseurID_Record == null) {
				
					this.col_FournisseurID_Record = new Fournisseur_Record(this.connectionString, this.col_FournisseurID);
				}
				
				return(this.col_FournisseurID_Record);
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
				this.col_PayerAID_Record = null;
				this.col_PayerAID = value;
			}
		}

		
		private Fournisseur_Record col_PayerAID_Record = null;
		public Fournisseur_Record Col_PayerAID_Fournisseur_Record {
		
			get {

				if (this.col_PayerAID_Record == null) {
				
					this.col_PayerAID_Record = new Fournisseur_Record(this.connectionString, this.col_PayerAID);
				}
				
				return(this.col_PayerAID_Record);
			}
		}

		internal bool col_Montant_TotalWasSet = false;
		private bool col_Montant_TotalWasUpdated = false;
		internal System.Data.SqlTypes.SqlDouble col_Montant_Total = System.Data.SqlTypes.SqlDouble.Null;
		public System.Data.SqlTypes.SqlDouble Col_Montant_Total {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Montant_Total);
			}
			set {
			
				this.col_Montant_TotalWasUpdated = true;
				this.col_Montant_TotalWasSet = true;
				this.col_Montant_Total = value;
			}
		}

		internal bool col_Montant_TPSWasSet = false;
		private bool col_Montant_TPSWasUpdated = false;
		internal System.Data.SqlTypes.SqlDouble col_Montant_TPS = System.Data.SqlTypes.SqlDouble.Null;
		public System.Data.SqlTypes.SqlDouble Col_Montant_TPS {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Montant_TPS);
			}
			set {
			
				this.col_Montant_TPSWasUpdated = true;
				this.col_Montant_TPSWasSet = true;
				this.col_Montant_TPS = value;
			}
		}

		internal bool col_Montant_TVQWasSet = false;
		private bool col_Montant_TVQWasUpdated = false;
		internal System.Data.SqlTypes.SqlDouble col_Montant_TVQ = System.Data.SqlTypes.SqlDouble.Null;
		public System.Data.SqlTypes.SqlDouble Col_Montant_TVQ {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Montant_TVQ);
			}
			set {
			
				this.col_Montant_TVQWasUpdated = true;
				this.col_Montant_TVQWasSet = true;
				this.col_Montant_TVQ = value;
			}
		}

		internal bool col_DescriptionWasSet = false;
		private bool col_DescriptionWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_Description = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_Description {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Description);
			}
			set {
			
				this.col_DescriptionWasUpdated = true;
				this.col_DescriptionWasSet = true;
				this.col_Description = value;
			}
		}

		internal bool col_StatusWasSet = false;
		private bool col_StatusWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_Status = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_Status {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Status);
			}
			set {
			
				this.col_StatusWasUpdated = true;
				this.col_StatusWasSet = true;
				this.col_Status = value;
			}
		}

		internal bool col_StatusDescriptionWasSet = false;
		private bool col_StatusDescriptionWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_StatusDescription = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_StatusDescription {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_StatusDescription);
			}
			set {
			
				this.col_StatusDescriptionWasUpdated = true;
				this.col_StatusDescriptionWasSet = true;
				this.col_StatusDescription = value;
			}
		}

		internal bool col_NumeroChequeWasSet = false;
		private bool col_NumeroChequeWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_NumeroCheque = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_NumeroCheque {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_NumeroCheque);
			}
			set {
			
				this.col_NumeroChequeWasUpdated = true;
				this.col_NumeroChequeWasSet = true;
				this.col_NumeroCheque = value;
			}
		}

		internal bool col_NumeroPaiementWasSet = false;
		private bool col_NumeroPaiementWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_NumeroPaiement = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_NumeroPaiement {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_NumeroPaiement);
			}
			set {
			
				this.col_NumeroPaiementWasUpdated = true;
				this.col_NumeroPaiementWasSet = true;
				this.col_NumeroPaiement = value;
			}
		}

		internal bool col_NumeroPaiementUniqueWasSet = false;
		private bool col_NumeroPaiementUniqueWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_NumeroPaiementUnique = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_NumeroPaiementUnique {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_NumeroPaiementUnique);
			}
			set {
			
				this.col_NumeroPaiementUniqueWasUpdated = true;
				this.col_NumeroPaiementUniqueWasSet = true;
				this.col_NumeroPaiementUnique = value;
			}
		}

		internal bool col_DateFactureAcombaWasSet = false;
		private bool col_DateFactureAcombaWasUpdated = false;
		internal System.Data.SqlTypes.SqlDateTime col_DateFactureAcomba = System.Data.SqlTypes.SqlDateTime.Null;
		public System.Data.SqlTypes.SqlDateTime Col_DateFactureAcomba {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_DateFactureAcomba);
			}
			set {
			
				this.col_DateFactureAcombaWasUpdated = true;
				this.col_DateFactureAcombaWasSet = true;
				this.col_DateFactureAcomba = value;
			}
		}

		internal bool col_DatePaiementAcombaWasSet = false;
		private bool col_DatePaiementAcombaWasUpdated = false;
		internal System.Data.SqlTypes.SqlDateTime col_DatePaiementAcomba = System.Data.SqlTypes.SqlDateTime.Null;
		public System.Data.SqlTypes.SqlDateTime Col_DatePaiementAcomba {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_DatePaiementAcomba);
			}
			set {
			
				this.col_DatePaiementAcombaWasUpdated = true;
				this.col_DatePaiementAcombaWasSet = true;
				this.col_DatePaiementAcomba = value;
			}
		}


		public bool Refresh() {

			this.displayName = null;

			this.col_NoFactureWasUpdated = false;
			this.col_NoFactureWasSet = false;
			this.col_NoFacture = System.Data.SqlTypes.SqlString.Null;

			this.col_DateFactureWasUpdated = false;
			this.col_DateFactureWasSet = false;
			this.col_DateFacture = System.Data.SqlTypes.SqlDateTime.Null;

			this.col_AnneeWasUpdated = false;
			this.col_AnneeWasSet = false;
			this.col_Annee = System.Data.SqlTypes.SqlInt32.Null;

			this.col_TypeFactureFournisseurWasUpdated = false;
			this.col_TypeFactureFournisseurWasSet = false;
			this.col_TypeFactureFournisseur = System.Data.SqlTypes.SqlString.Null;

			this.col_TypeFactureWasUpdated = false;
			this.col_TypeFactureWasSet = false;
			this.col_TypeFacture = System.Data.SqlTypes.SqlString.Null;

			this.col_TypeInvoiceAcombaWasUpdated = false;
			this.col_TypeInvoiceAcombaWasSet = false;
			this.col_TypeInvoiceAcomba = System.Data.SqlTypes.SqlInt32.Null;

			this.col_FournisseurIDWasUpdated = false;
			this.col_FournisseurIDWasSet = false;
			this.col_FournisseurID = System.Data.SqlTypes.SqlString.Null;

			this.col_PayerAIDWasUpdated = false;
			this.col_PayerAIDWasSet = false;
			this.col_PayerAID = System.Data.SqlTypes.SqlString.Null;

			this.col_Montant_TotalWasUpdated = false;
			this.col_Montant_TotalWasSet = false;
			this.col_Montant_Total = System.Data.SqlTypes.SqlDouble.Null;

			this.col_Montant_TPSWasUpdated = false;
			this.col_Montant_TPSWasSet = false;
			this.col_Montant_TPS = System.Data.SqlTypes.SqlDouble.Null;

			this.col_Montant_TVQWasUpdated = false;
			this.col_Montant_TVQWasSet = false;
			this.col_Montant_TVQ = System.Data.SqlTypes.SqlDouble.Null;

			this.col_DescriptionWasUpdated = false;
			this.col_DescriptionWasSet = false;
			this.col_Description = System.Data.SqlTypes.SqlString.Null;

			this.col_StatusWasUpdated = false;
			this.col_StatusWasSet = false;
			this.col_Status = System.Data.SqlTypes.SqlString.Null;

			this.col_StatusDescriptionWasUpdated = false;
			this.col_StatusDescriptionWasSet = false;
			this.col_StatusDescription = System.Data.SqlTypes.SqlString.Null;

			this.col_NumeroChequeWasUpdated = false;
			this.col_NumeroChequeWasSet = false;
			this.col_NumeroCheque = System.Data.SqlTypes.SqlString.Null;

			this.col_NumeroPaiementWasUpdated = false;
			this.col_NumeroPaiementWasSet = false;
			this.col_NumeroPaiement = System.Data.SqlTypes.SqlString.Null;

			this.col_NumeroPaiementUniqueWasUpdated = false;
			this.col_NumeroPaiementUniqueWasSet = false;
			this.col_NumeroPaiementUnique = System.Data.SqlTypes.SqlString.Null;

			this.col_DateFactureAcombaWasUpdated = false;
			this.col_DateFactureAcombaWasSet = false;
			this.col_DateFactureAcomba = System.Data.SqlTypes.SqlDateTime.Null;

			this.col_DatePaiementAcombaWasUpdated = false;
			this.col_DatePaiementAcombaWasSet = false;
			this.col_DatePaiementAcomba = System.Data.SqlTypes.SqlDateTime.Null;

			Params.spS_FactureFournisseur Param = new Params.spS_FactureFournisseur(true);
			Param.SetUpConnection(this.connectionString);

			if (!this.col_ID.IsNull) {

				Param.Param_ID = this.col_ID;
			}


			System.Data.SqlClient.SqlDataReader sqlDataReader = null;
			SPs.spS_FactureFournisseur Sp = new SPs.spS_FactureFournisseur();
			if (Sp.Execute(ref Param, out sqlDataReader)) {

				if (sqlDataReader.Read()) {

					if (!sqlDataReader.IsDBNull(SPs.spS_FactureFournisseur.Resultset1.Fields.Column_NoFacture.ColumnIndex)) {

						this.col_NoFacture = sqlDataReader.GetSqlString(SPs.spS_FactureFournisseur.Resultset1.Fields.Column_NoFacture.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_FactureFournisseur.Resultset1.Fields.Column_DateFacture.ColumnIndex)) {

						this.col_DateFacture = sqlDataReader.GetSqlDateTime(SPs.spS_FactureFournisseur.Resultset1.Fields.Column_DateFacture.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_FactureFournisseur.Resultset1.Fields.Column_Annee.ColumnIndex)) {

						this.col_Annee = sqlDataReader.GetSqlInt32(SPs.spS_FactureFournisseur.Resultset1.Fields.Column_Annee.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_FactureFournisseur.Resultset1.Fields.Column_TypeFactureFournisseur.ColumnIndex)) {

						this.col_TypeFactureFournisseur = sqlDataReader.GetSqlString(SPs.spS_FactureFournisseur.Resultset1.Fields.Column_TypeFactureFournisseur.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_FactureFournisseur.Resultset1.Fields.Column_TypeFacture.ColumnIndex)) {

						this.col_TypeFacture = sqlDataReader.GetSqlString(SPs.spS_FactureFournisseur.Resultset1.Fields.Column_TypeFacture.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_FactureFournisseur.Resultset1.Fields.Column_TypeInvoiceAcomba.ColumnIndex)) {

						this.col_TypeInvoiceAcomba = sqlDataReader.GetSqlInt32(SPs.spS_FactureFournisseur.Resultset1.Fields.Column_TypeInvoiceAcomba.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_FactureFournisseur.Resultset1.Fields.Column_FournisseurID.ColumnIndex)) {

						this.col_FournisseurID = sqlDataReader.GetSqlString(SPs.spS_FactureFournisseur.Resultset1.Fields.Column_FournisseurID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_FactureFournisseur.Resultset1.Fields.Column_PayerAID.ColumnIndex)) {

						this.col_PayerAID = sqlDataReader.GetSqlString(SPs.spS_FactureFournisseur.Resultset1.Fields.Column_PayerAID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_FactureFournisseur.Resultset1.Fields.Column_Montant_Total.ColumnIndex)) {

						this.col_Montant_Total = sqlDataReader.GetSqlDouble(SPs.spS_FactureFournisseur.Resultset1.Fields.Column_Montant_Total.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_FactureFournisseur.Resultset1.Fields.Column_Montant_TPS.ColumnIndex)) {

						this.col_Montant_TPS = sqlDataReader.GetSqlDouble(SPs.spS_FactureFournisseur.Resultset1.Fields.Column_Montant_TPS.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_FactureFournisseur.Resultset1.Fields.Column_Montant_TVQ.ColumnIndex)) {

						this.col_Montant_TVQ = sqlDataReader.GetSqlDouble(SPs.spS_FactureFournisseur.Resultset1.Fields.Column_Montant_TVQ.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_FactureFournisseur.Resultset1.Fields.Column_Description.ColumnIndex)) {

						this.col_Description = sqlDataReader.GetSqlString(SPs.spS_FactureFournisseur.Resultset1.Fields.Column_Description.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_FactureFournisseur.Resultset1.Fields.Column_Status.ColumnIndex)) {

						this.col_Status = sqlDataReader.GetSqlString(SPs.spS_FactureFournisseur.Resultset1.Fields.Column_Status.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_FactureFournisseur.Resultset1.Fields.Column_StatusDescription.ColumnIndex)) {

						this.col_StatusDescription = sqlDataReader.GetSqlString(SPs.spS_FactureFournisseur.Resultset1.Fields.Column_StatusDescription.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_FactureFournisseur.Resultset1.Fields.Column_NumeroCheque.ColumnIndex)) {

						this.col_NumeroCheque = sqlDataReader.GetSqlString(SPs.spS_FactureFournisseur.Resultset1.Fields.Column_NumeroCheque.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_FactureFournisseur.Resultset1.Fields.Column_NumeroPaiement.ColumnIndex)) {

						this.col_NumeroPaiement = sqlDataReader.GetSqlString(SPs.spS_FactureFournisseur.Resultset1.Fields.Column_NumeroPaiement.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_FactureFournisseur.Resultset1.Fields.Column_NumeroPaiementUnique.ColumnIndex)) {

						this.col_NumeroPaiementUnique = sqlDataReader.GetSqlString(SPs.spS_FactureFournisseur.Resultset1.Fields.Column_NumeroPaiementUnique.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_FactureFournisseur.Resultset1.Fields.Column_DateFactureAcomba.ColumnIndex)) {

						this.col_DateFactureAcomba = sqlDataReader.GetSqlDateTime(SPs.spS_FactureFournisseur.Resultset1.Fields.Column_DateFactureAcomba.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_FactureFournisseur.Resultset1.Fields.Column_DatePaiementAcomba.ColumnIndex)) {

						this.col_DatePaiementAcomba = sqlDataReader.GetSqlDateTime(SPs.spS_FactureFournisseur.Resultset1.Fields.Column_DatePaiementAcomba.ColumnIndex);
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

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.FactureFournisseur_Record", "Refresh");
			}
		}

		public void Update() {

			if (!this.recordWasLoadedFromDB) {

				throw new ArgumentException("No record was loaded from the database. No update is possible.");
			}

			bool ChangesHaveBeenMade = false;

			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_NoFactureWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_DateFactureWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_AnneeWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_TypeFactureFournisseurWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_TypeFactureWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_TypeInvoiceAcombaWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_FournisseurIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_PayerAIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Montant_TotalWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Montant_TPSWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Montant_TVQWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_DescriptionWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_StatusWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_StatusDescriptionWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_NumeroChequeWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_NumeroPaiementWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_NumeroPaiementUniqueWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_DateFactureAcombaWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_DatePaiementAcombaWasUpdated);

			if (!ChangesHaveBeenMade) {

				return;
			}

			Params.spU_FactureFournisseur Param = new Params.spU_FactureFournisseur(false);
			Param.SetUpConnection(this.connectionString);
			Param.Param_ID = this.col_ID;

			if (this.col_NoFactureWasUpdated) {

				Param.Param_NoFacture = this.col_NoFacture;
				Param.Param_ConsiderNull_NoFacture = true;
			}

			if (this.col_DateFactureWasUpdated) {

				Param.Param_DateFacture = this.col_DateFacture;
				Param.Param_ConsiderNull_DateFacture = true;
			}

			if (this.col_AnneeWasUpdated) {

				Param.Param_Annee = this.col_Annee;
				Param.Param_ConsiderNull_Annee = true;
			}

			if (this.col_TypeFactureFournisseurWasUpdated) {

				Param.Param_TypeFactureFournisseur = this.col_TypeFactureFournisseur;
				Param.Param_ConsiderNull_TypeFactureFournisseur = true;
			}

			if (this.col_TypeFactureWasUpdated) {

				Param.Param_TypeFacture = this.col_TypeFacture;
				Param.Param_ConsiderNull_TypeFacture = true;
			}

			if (this.col_TypeInvoiceAcombaWasUpdated) {

				Param.Param_TypeInvoiceAcomba = this.col_TypeInvoiceAcomba;
				Param.Param_ConsiderNull_TypeInvoiceAcomba = true;
			}

			if (this.col_FournisseurIDWasUpdated) {

				Param.Param_FournisseurID = this.col_FournisseurID;
				Param.Param_ConsiderNull_FournisseurID = true;
			}

			if (this.col_PayerAIDWasUpdated) {

				Param.Param_PayerAID = this.col_PayerAID;
				Param.Param_ConsiderNull_PayerAID = true;
			}

			if (this.col_Montant_TotalWasUpdated) {

				Param.Param_Montant_Total = this.col_Montant_Total;
				Param.Param_ConsiderNull_Montant_Total = true;
			}

			if (this.col_Montant_TPSWasUpdated) {

				Param.Param_Montant_TPS = this.col_Montant_TPS;
				Param.Param_ConsiderNull_Montant_TPS = true;
			}

			if (this.col_Montant_TVQWasUpdated) {

				Param.Param_Montant_TVQ = this.col_Montant_TVQ;
				Param.Param_ConsiderNull_Montant_TVQ = true;
			}

			if (this.col_DescriptionWasUpdated) {

				Param.Param_Description = this.col_Description;
				Param.Param_ConsiderNull_Description = true;
			}

			if (this.col_StatusWasUpdated) {

				Param.Param_Status = this.col_Status;
				Param.Param_ConsiderNull_Status = true;
			}

			if (this.col_StatusDescriptionWasUpdated) {

				Param.Param_StatusDescription = this.col_StatusDescription;
				Param.Param_ConsiderNull_StatusDescription = true;
			}

			if (this.col_NumeroChequeWasUpdated) {

				Param.Param_NumeroCheque = this.col_NumeroCheque;
				Param.Param_ConsiderNull_NumeroCheque = true;
			}

			if (this.col_NumeroPaiementWasUpdated) {

				Param.Param_NumeroPaiement = this.col_NumeroPaiement;
				Param.Param_ConsiderNull_NumeroPaiement = true;
			}

			if (this.col_NumeroPaiementUniqueWasUpdated) {

				Param.Param_NumeroPaiementUnique = this.col_NumeroPaiementUnique;
				Param.Param_ConsiderNull_NumeroPaiementUnique = true;
			}

			if (this.col_DateFactureAcombaWasUpdated) {

				Param.Param_DateFactureAcomba = this.col_DateFactureAcomba;
				Param.Param_ConsiderNull_DateFactureAcomba = true;
			}

			if (this.col_DatePaiementAcombaWasUpdated) {

				Param.Param_DatePaiementAcomba = this.col_DatePaiementAcomba;
				Param.Param_ConsiderNull_DatePaiementAcomba = true;
			}

			SPs.spU_FactureFournisseur Sp = new SPs.spU_FactureFournisseur();
			if (Sp.Execute(ref Param)) {

				this.col_NoFactureWasUpdated = false;
				this.col_DateFactureWasUpdated = false;
				this.col_AnneeWasUpdated = false;
				this.col_TypeFactureFournisseurWasUpdated = false;
				this.col_TypeFactureWasUpdated = false;
				this.col_TypeInvoiceAcombaWasUpdated = false;
				this.col_FournisseurIDWasUpdated = false;
				this.col_PayerAIDWasUpdated = false;
				this.col_Montant_TotalWasUpdated = false;
				this.col_Montant_TPSWasUpdated = false;
				this.col_Montant_TVQWasUpdated = false;
				this.col_DescriptionWasUpdated = false;
				this.col_StatusWasUpdated = false;
				this.col_StatusDescriptionWasUpdated = false;
				this.col_NumeroChequeWasUpdated = false;
				this.col_NumeroPaiementWasUpdated = false;
				this.col_NumeroPaiementUniqueWasUpdated = false;
				this.col_DateFactureAcombaWasUpdated = false;
				this.col_DatePaiementAcombaWasUpdated = false;
			}
			else {

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.FactureFournisseur_Record", "Update");
			}		
		}

		private AjustementCalcule_Producteur_Collection internal_AjustementCalcule_Producteur_Col_FactureID_Collection = null;
		public AjustementCalcule_Producteur_Collection AjustementCalcule_Producteur_Col_FactureID_Collection {

			get {

				if (this.internal_AjustementCalcule_Producteur_Col_FactureID_Collection == null) {

					this.internal_AjustementCalcule_Producteur_Col_FactureID_Collection = new AjustementCalcule_Producteur_Collection(this.connectionString);
					this.internal_AjustementCalcule_Producteur_Col_FactureID_Collection.LoadFrom_FactureID(this.col_ID, this);
				}

				return(this.internal_AjustementCalcule_Producteur_Col_FactureID_Collection);
			}
		}

		private AjustementCalcule_Transporteur_Collection internal_AjustementCalcule_Transporteur_Col_FactureID_Collection = null;
		public AjustementCalcule_Transporteur_Collection AjustementCalcule_Transporteur_Col_FactureID_Collection {

			get {

				if (this.internal_AjustementCalcule_Transporteur_Col_FactureID_Collection == null) {

					this.internal_AjustementCalcule_Transporteur_Col_FactureID_Collection = new AjustementCalcule_Transporteur_Collection(this.connectionString);
					this.internal_AjustementCalcule_Transporteur_Col_FactureID_Collection.LoadFrom_FactureID(this.col_ID, this);
				}

				return(this.internal_AjustementCalcule_Transporteur_Col_FactureID_Collection);
			}
		}

		private FactureFournisseur_Details_Collection internal_FactureFournisseur_Details_Col_FactureID_Collection = null;
		public FactureFournisseur_Details_Collection FactureFournisseur_Details_Col_FactureID_Collection {

			get {

				if (this.internal_FactureFournisseur_Details_Col_FactureID_Collection == null) {

					this.internal_FactureFournisseur_Details_Col_FactureID_Collection = new FactureFournisseur_Details_Collection(this.connectionString);
					this.internal_FactureFournisseur_Details_Col_FactureID_Collection.LoadFrom_FactureID(this.col_ID, this);
				}

				return(this.internal_FactureFournisseur_Details_Col_FactureID_Collection);
			}
		}

		private FactureFournisseur_Sommaire_Collection internal_FactureFournisseur_Sommaire_Col_FactureID_Collection = null;
		public FactureFournisseur_Sommaire_Collection FactureFournisseur_Sommaire_Col_FactureID_Collection {

			get {

				if (this.internal_FactureFournisseur_Sommaire_Col_FactureID_Collection == null) {

					this.internal_FactureFournisseur_Sommaire_Col_FactureID_Collection = new FactureFournisseur_Sommaire_Collection(this.connectionString);
					this.internal_FactureFournisseur_Sommaire_Col_FactureID_Collection.LoadFrom_FactureID(this.col_ID, this);
				}

				return(this.internal_FactureFournisseur_Sommaire_Col_FactureID_Collection);
			}
		}

		private IndexationCalcule_Producteur_Collection internal_IndexationCalcule_Producteur_Col_FactureID_Collection = null;
		public IndexationCalcule_Producteur_Collection IndexationCalcule_Producteur_Col_FactureID_Collection {

			get {

				if (this.internal_IndexationCalcule_Producteur_Col_FactureID_Collection == null) {

					this.internal_IndexationCalcule_Producteur_Col_FactureID_Collection = new IndexationCalcule_Producteur_Collection(this.connectionString);
					this.internal_IndexationCalcule_Producteur_Col_FactureID_Collection.LoadFrom_FactureID(this.col_ID, this);
				}

				return(this.internal_IndexationCalcule_Producteur_Col_FactureID_Collection);
			}
		}

		private IndexationCalcule_Transporteur_Collection internal_IndexationCalcule_Transporteur_Col_FactureID_Collection = null;
		public IndexationCalcule_Transporteur_Collection IndexationCalcule_Transporteur_Col_FactureID_Collection {

			get {

				if (this.internal_IndexationCalcule_Transporteur_Col_FactureID_Collection == null) {

					this.internal_IndexationCalcule_Transporteur_Col_FactureID_Collection = new IndexationCalcule_Transporteur_Collection(this.connectionString);
					this.internal_IndexationCalcule_Transporteur_Col_FactureID_Collection.LoadFrom_FactureID(this.col_ID, this);
				}

				return(this.internal_IndexationCalcule_Transporteur_Col_FactureID_Collection);
			}
		}

		private Livraison_Collection internal_Livraison_Col_Producteur1_FactureID_Collection = null;
		public Livraison_Collection Livraison_Col_Producteur1_FactureID_Collection {

			get {

				if (this.internal_Livraison_Col_Producteur1_FactureID_Collection == null) {

					this.internal_Livraison_Col_Producteur1_FactureID_Collection = new Livraison_Collection(this.connectionString);
					this.internal_Livraison_Col_Producteur1_FactureID_Collection.LoadFrom_Producteur1_FactureID(this.col_ID, this);
				}

				return(this.internal_Livraison_Col_Producteur1_FactureID_Collection);
			}
		}

		private Livraison_Collection internal_Livraison_Col_Producteur2_FactureID_Collection = null;
		public Livraison_Collection Livraison_Col_Producteur2_FactureID_Collection {

			get {

				if (this.internal_Livraison_Col_Producteur2_FactureID_Collection == null) {

					this.internal_Livraison_Col_Producteur2_FactureID_Collection = new Livraison_Collection(this.connectionString);
					this.internal_Livraison_Col_Producteur2_FactureID_Collection.LoadFrom_Producteur2_FactureID(this.col_ID, this);
				}

				return(this.internal_Livraison_Col_Producteur2_FactureID_Collection);
			}
		}

		private Livraison_Collection internal_Livraison_Col_Transporteur_FactureID_Collection = null;
		public Livraison_Collection Livraison_Col_Transporteur_FactureID_Collection {

			get {

				if (this.internal_Livraison_Col_Transporteur_FactureID_Collection == null) {

					this.internal_Livraison_Col_Transporteur_FactureID_Collection = new Livraison_Collection(this.connectionString);
					this.internal_Livraison_Col_Transporteur_FactureID_Collection.LoadFrom_Transporteur_FactureID(this.col_ID, this);
				}

				return(this.internal_Livraison_Col_Transporteur_FactureID_Collection);
			}
		}

		private Livraison_Collection internal_Livraison_Col_Chargeur_FactureID_Collection = null;
		public Livraison_Collection Livraison_Col_Chargeur_FactureID_Collection {

			get {

				if (this.internal_Livraison_Col_Chargeur_FactureID_Collection == null) {

					this.internal_Livraison_Col_Chargeur_FactureID_Collection = new Livraison_Collection(this.connectionString);
					this.internal_Livraison_Col_Chargeur_FactureID_Collection.LoadFrom_Chargeur_FactureID(this.col_ID, this);
				}

				return(this.internal_Livraison_Col_Chargeur_FactureID_Collection);
			}
		}

		internal string displayName = null;
		public override string ToString() {

			if (!this.recordWasLoadedFromDB) {

				throw new ArgumentException("No record was loaded from the database. The DisplayName is not available.");
			}
		
			if (this.displayName == null) {
			
				Params.spS_FactureFournisseur_Display Param = new Params.spS_FactureFournisseur_Display();
				Param.SetUpConnection(this.connectionString);

				Param.Param_ID = this.col_ID;

				System.Data.SqlClient.SqlDataReader sqlDataReader = null;
				SPs.spS_FactureFournisseur_Display Sp = new SPs.spS_FactureFournisseur_Display();
				if (Sp.Execute(ref Param, out sqlDataReader)) {

					if (sqlDataReader.Read()) {

						if (!sqlDataReader.IsDBNull(SPs.spS_FactureFournisseur_Display.Resultset1.Fields.Column_Display.ColumnIndex)) {

							this.displayName = "spS_FactureFournisseur_Display";
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

					throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.FactureFournisseur_Record", "ToString");
				}				
			}
			
			return(this.displayName);
		}
	}
}
