using System;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.BusinessComponents {

	public sealed class FactureFournisseur_Collection : IBusinessComponentCollection, System.Collections.IEnumerable, System.ComponentModel.IListSource {

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

		private System.Data.SqlTypes.SqlString col_TypeFactureFournisseur = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_TypeFactureFournisseur {

			get {

				return(this.col_TypeFactureFournisseur);
			}
			set {

				this.col_TypeFactureFournisseur = value;
			}
		}

		internal void LoadFrom_TypeFactureFournisseur(System.Data.SqlTypes.SqlString col_TypeFactureFournisseur, TypeFactureFournisseur_Record parent) {
		
			if (col_TypeFactureFournisseur.IsNull) {

				throw new ArgumentException("Parameter can not be null", "col_TypeFactureFournisseur");
			}

			if (parent == null) {

				throw new ArgumentException("Parameter can not be null", "parent");
			}

			this.col_TypeFactureFournisseur = col_TypeFactureFournisseur;
			this.parent = parent;
		}

		private System.Data.SqlTypes.SqlString col_TypeFacture = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_TypeFacture {

			get {

				return(this.col_TypeFacture);
			}
			set {

				this.col_TypeFacture = value;
			}
		}

		internal void LoadFrom_TypeFacture(System.Data.SqlTypes.SqlString col_TypeFacture, TypeFacture_Record parent) {
		
			if (col_TypeFacture.IsNull) {

				throw new ArgumentException("Parameter can not be null", "col_TypeFacture");
			}

			if (parent == null) {

				throw new ArgumentException("Parameter can not be null", "parent");
			}

			this.col_TypeFacture = col_TypeFacture;
			this.parent = parent;
		}

		private System.Data.SqlTypes.SqlInt32 col_TypeInvoiceAcomba = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_TypeInvoiceAcomba {

			get {

				return(this.col_TypeInvoiceAcomba);
			}
			set {

				this.col_TypeInvoiceAcomba = value;
			}
		}

		internal void LoadFrom_TypeInvoiceAcomba(System.Data.SqlTypes.SqlInt32 col_TypeInvoiceAcomba, TypeInvoiceAcomba_Record parent) {
		
			if (col_TypeInvoiceAcomba.IsNull) {

				throw new ArgumentException("Parameter can not be null", "col_TypeInvoiceAcomba");
			}

			if (parent == null) {

				throw new ArgumentException("Parameter can not be null", "parent");
			}

			this.col_TypeInvoiceAcomba = col_TypeInvoiceAcomba;
			this.parent = parent;
		}

		private System.Data.SqlTypes.SqlString col_FournisseurID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_FournisseurID {

			get {

				return(this.col_FournisseurID);
			}
			set {

				this.col_FournisseurID = value;
			}
		}

		internal void LoadFrom_FournisseurID(System.Data.SqlTypes.SqlString col_FournisseurID, Fournisseur_Record parent) {
		
			if (col_FournisseurID.IsNull) {

				throw new ArgumentException("Parameter can not be null", "col_FournisseurID");
			}

			if (parent == null) {

				throw new ArgumentException("Parameter can not be null", "parent");
			}

			this.col_FournisseurID = col_FournisseurID;
			this.parent = parent;
		}

		private System.Data.SqlTypes.SqlString col_PayerAID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_PayerAID {

			get {

				return(this.col_PayerAID);
			}
			set {

				this.col_PayerAID = value;
			}
		}

		internal void LoadFrom_PayerAID(System.Data.SqlTypes.SqlString col_PayerAID, Fournisseur_Record parent) {
		
			if (col_PayerAID.IsNull) {

				throw new ArgumentException("Parameter can not be null", "col_PayerAID");
			}

			if (parent == null) {

				throw new ArgumentException("Parameter can not be null", "parent");
			}

			this.col_PayerAID = col_PayerAID;
			this.parent = parent;
		}


		public FactureFournisseur_Collection(string connectionString) {
			
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

		}

		/// <param name="col_TypeFactureFournisseur">[To be supplied.]</param>
		/// <param name="col_TypeFacture">[To be supplied.]</param>
		/// <param name="col_TypeInvoiceAcomba">[To be supplied.]</param>
		/// <param name="col_FournisseurID">[To be supplied.]</param>
		/// <param name="col_PayerAID">[To be supplied.]</param>
		public FactureFournisseur_Collection(string connectionString, System.Data.SqlTypes.SqlString col_TypeFactureFournisseur, System.Data.SqlTypes.SqlString col_TypeFacture, System.Data.SqlTypes.SqlInt32 col_TypeInvoiceAcomba, System.Data.SqlTypes.SqlString col_FournisseurID, System.Data.SqlTypes.SqlString col_PayerAID) {
			
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

			this.col_TypeFactureFournisseur = col_TypeFactureFournisseur;
			this.col_TypeFacture = col_TypeFacture;
			this.col_TypeInvoiceAcomba = col_TypeInvoiceAcomba;
			this.col_FournisseurID = col_FournisseurID;
			this.col_PayerAID = col_PayerAID;
		}


		public IBusinessComponentRecord Add(IBusinessComponentRecord record) {
		
			FactureFournisseur_Record recordToAdd = record as FactureFournisseur_Record;

			if (recordToAdd == null) {

				throw new ArgumentException("Invalid record type. Must be 'Gestion_Paie.BusinessComponents.FactureFournisseur_Record'.", "record");
			}

			Params.spI_FactureFournisseur Param = new Params.spI_FactureFournisseur();
			Param.SetUpConnection(this.connectionString);

			Param.Param_ID = recordToAdd.Col_ID;
			Param.Param_NoFacture = recordToAdd.Col_NoFacture;
			Param.Param_DateFacture = recordToAdd.Col_DateFacture;
			Param.Param_Annee = recordToAdd.Col_Annee;
			Param.Param_TypeFactureFournisseur = recordToAdd.Col_TypeFactureFournisseur;
			Param.Param_TypeFacture = recordToAdd.Col_TypeFacture;
			Param.Param_TypeInvoiceAcomba = recordToAdd.Col_TypeInvoiceAcomba;
			Param.Param_FournisseurID = recordToAdd.Col_FournisseurID;
			Param.Param_PayerAID = recordToAdd.Col_PayerAID;
			Param.Param_Montant_Total = recordToAdd.Col_Montant_Total;
			Param.Param_Montant_TPS = recordToAdd.Col_Montant_TPS;
			Param.Param_Montant_TVQ = recordToAdd.Col_Montant_TVQ;
			Param.Param_Description = recordToAdd.Col_Description;
			Param.Param_Status = recordToAdd.Col_Status;
			Param.Param_StatusDescription = recordToAdd.Col_StatusDescription;
			Param.Param_NumeroCheque = recordToAdd.Col_NumeroCheque;
			Param.Param_NumeroPaiement = recordToAdd.Col_NumeroPaiement;
			Param.Param_NumeroPaiementUnique = recordToAdd.Col_NumeroPaiementUnique;
			Param.Param_DateFactureAcomba = recordToAdd.Col_DateFactureAcomba;
			Param.Param_DatePaiementAcomba = recordToAdd.Col_DatePaiementAcomba;

			SPs.spI_FactureFournisseur Sp = new SPs.spI_FactureFournisseur();
			if (Sp.Execute(ref Param)) {

				FactureFournisseur_Record newRecord = new FactureFournisseur_Record(this.connectionString, Param.Param_ID);				if (internalRecords != null) {

					internalRecords.Add(newRecord);
				}

				return(newRecord);
			}
			else {

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.FactureFournisseur_Collection", "Add");
			}	
		}

		/// <param name="Col_ID">[To be supplied.]</param>
		public void Remove(System.Data.SqlTypes.SqlInt32 Col_ID) {
		
			Params.spD_FactureFournisseur Param = new Params.spD_FactureFournisseur(true);
			Param.SetUpConnection(this.connectionString);

			Param.Param_ID = Col_ID;


			SPs.spD_FactureFournisseur Sp = new SPs.spD_FactureFournisseur(true);

			Sp.Execute(ref Param);
		}

		public void Remove(IBusinessComponentRecord record) {
		
			FactureFournisseur_Record recordToDelete = record as FactureFournisseur_Record;

			if (recordToDelete == null) {

				throw new ArgumentException("Invalid record type. Must be 'Gestion_Paie.BusinessComponents.FactureFournisseur_Record'.", "record");
			}

			Params.spD_FactureFournisseur Param = new Params.spD_FactureFournisseur(true);
			Param.SetUpConnection(this.connectionString);

			Param.Param_ID = recordToDelete.Col_ID;


			SPs.spD_FactureFournisseur Sp = new SPs.spD_FactureFournisseur(true);

			Sp.Execute(ref Param);

			if (internalRecords != null) {

				internalRecords.Remove(recordToDelete);
			}
		}

		public void Refresh() {

			internalRecords = new System.Collections.ArrayList();

			Params.spS_FactureFournisseur_Display Param = new Params.spS_FactureFournisseur_Display();
			Param.SetUpConnection(this.connectionString);

			if (!this.col_TypeFactureFournisseur.IsNull) {

				Param.Param_TypeFactureFournisseur = this.col_TypeFactureFournisseur;
			}

			if (!this.col_TypeFacture.IsNull) {

				Param.Param_TypeFacture = this.col_TypeFacture;
			}

			if (!this.col_TypeInvoiceAcomba.IsNull) {

				Param.Param_TypeInvoiceAcomba = this.col_TypeInvoiceAcomba;
			}

			if (!this.col_FournisseurID.IsNull) {

				Param.Param_FournisseurID = this.col_FournisseurID;
			}

			if (!this.col_PayerAID.IsNull) {

				Param.Param_PayerAID = this.col_PayerAID;
			}


			System.Data.SqlClient.SqlDataReader sqlDataReader = null;
			SPs.spS_FactureFournisseur_Display Sp = new SPs.spS_FactureFournisseur_Display();
			if (Sp.Execute(ref Param, out sqlDataReader)) {

				while (sqlDataReader.Read()) {

					FactureFournisseur_Record record = new FactureFournisseur_Record(this.connectionString, sqlDataReader.GetSqlInt32(SPs.spS_FactureFournisseur_Display.Resultset1.Fields.Column_ID1.ColumnIndex));

					record.displayName = "spS_FactureFournisseur_Display";

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
				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.FactureFournisseur_Collection", "Refresh");
			}
		}

		public System.Collections.IEnumerator GetEnumerator() {

			if (!this.recordsAreLoaded) {

				Refresh();
			}

			return(internalRecords.GetEnumerator());
		}

		public FactureFournisseur_Record this[int index] {

			get {
				
				return((FactureFournisseur_Record)internalRecords[index]);
			}
		}

		/// <param name="col_ID">[To be supplied.]</param>
		/// <returns>[To be supplied.]</returns>
		public FactureFournisseur_Record this[System.Data.SqlTypes.SqlInt32 col_ID] {

			get {

				foreach(FactureFournisseur_Record record in internalRecords) {

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
