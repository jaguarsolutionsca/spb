using System;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.BusinessComponents {

	public sealed class IndexationCalcule_Transporteur_Collection : IBusinessComponentCollection, System.Collections.IEnumerable, System.ComponentModel.IListSource {

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

		private System.Data.SqlTypes.SqlString col_TypeIndexation = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_TypeIndexation {

			get {

				return(this.col_TypeIndexation);
			}
			set {

				this.col_TypeIndexation = value;
			}
		}

		internal void LoadFrom_TypeIndexation(System.Data.SqlTypes.SqlString col_TypeIndexation, TypeIndexation_Record parent) {
		
			if (col_TypeIndexation.IsNull) {

				throw new ArgumentException("Parameter can not be null", "col_TypeIndexation");
			}

			if (parent == null) {

				throw new ArgumentException("Parameter can not be null", "parent");
			}

			this.col_TypeIndexation = col_TypeIndexation;
			this.parent = parent;
		}

		private System.Data.SqlTypes.SqlInt32 col_IndexationID = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_IndexationID {

			get {

				return(this.col_IndexationID);
			}
			set {

				this.col_IndexationID = value;
			}
		}

		internal void LoadFrom_IndexationID(System.Data.SqlTypes.SqlInt32 col_IndexationID, Indexation_Record parent) {
		
			if (col_IndexationID.IsNull) {

				throw new ArgumentException("Parameter can not be null", "col_IndexationID");
			}

			if (parent == null) {

				throw new ArgumentException("Parameter can not be null", "parent");
			}

			this.col_IndexationID = col_IndexationID;
			this.parent = parent;
		}

		private System.Data.SqlTypes.SqlInt32 col_IndexationDetailID = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_IndexationDetailID {

			get {

				return(this.col_IndexationDetailID);
			}
			set {

				this.col_IndexationDetailID = value;
			}
		}

		internal void LoadFrom_IndexationDetailID(System.Data.SqlTypes.SqlInt32 col_IndexationDetailID, Indexation_Municipalite_Record parent) {
		
			if (col_IndexationDetailID.IsNull) {

				throw new ArgumentException("Parameter can not be null", "col_IndexationDetailID");
			}

			if (parent == null) {

				throw new ArgumentException("Parameter can not be null", "parent");
			}

			this.col_IndexationDetailID = col_IndexationDetailID;
			this.parent = parent;
		}

		private System.Data.SqlTypes.SqlInt32 col_LivraisonID = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_LivraisonID {

			get {

				return(this.col_LivraisonID);
			}
			set {

				this.col_LivraisonID = value;
			}
		}

		internal void LoadFrom_LivraisonID(System.Data.SqlTypes.SqlInt32 col_LivraisonID, Livraison_Record parent) {
		
			if (col_LivraisonID.IsNull) {

				throw new ArgumentException("Parameter can not be null", "col_LivraisonID");
			}

			if (parent == null) {

				throw new ArgumentException("Parameter can not be null", "parent");
			}

			this.col_LivraisonID = col_LivraisonID;
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

		private System.Data.SqlTypes.SqlInt32 col_FactureID = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_FactureID {

			get {

				return(this.col_FactureID);
			}
			set {

				this.col_FactureID = value;
			}
		}

		internal void LoadFrom_FactureID(System.Data.SqlTypes.SqlInt32 col_FactureID, FactureFournisseur_Record parent) {
		
			if (col_FactureID.IsNull) {

				throw new ArgumentException("Parameter can not be null", "col_FactureID");
			}

			if (parent == null) {

				throw new ArgumentException("Parameter can not be null", "parent");
			}

			this.col_FactureID = col_FactureID;
			this.parent = parent;
		}


		public IndexationCalcule_Transporteur_Collection(string connectionString) {
			
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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'IndexationCalcule_Transporteur'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				sqlConnection.Close();

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}", "IndexationCalcule_Transporteur", CurrentRevision, OriginalRevision));
				}
			}
			}
#endif

		}

		/// <param name="col_TypeIndexation">[To be supplied.]</param>
		/// <param name="col_IndexationID">[To be supplied.]</param>
		/// <param name="col_IndexationDetailID">[To be supplied.]</param>
		/// <param name="col_LivraisonID">[To be supplied.]</param>
		/// <param name="col_TransporteurID">[To be supplied.]</param>
		/// <param name="col_FactureID">[To be supplied.]</param>
		public IndexationCalcule_Transporteur_Collection(string connectionString, System.Data.SqlTypes.SqlString col_TypeIndexation, System.Data.SqlTypes.SqlInt32 col_IndexationID, System.Data.SqlTypes.SqlInt32 col_IndexationDetailID, System.Data.SqlTypes.SqlInt32 col_LivraisonID, System.Data.SqlTypes.SqlString col_TransporteurID, System.Data.SqlTypes.SqlInt32 col_FactureID) {
			
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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'IndexationCalcule_Transporteur'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				sqlConnection.Close();

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}", "IndexationCalcule_Transporteur", CurrentRevision, OriginalRevision));
				}
			}
			}
#endif

			this.col_TypeIndexation = col_TypeIndexation;
			this.col_IndexationID = col_IndexationID;
			this.col_IndexationDetailID = col_IndexationDetailID;
			this.col_LivraisonID = col_LivraisonID;
			this.col_TransporteurID = col_TransporteurID;
			this.col_FactureID = col_FactureID;
		}


		public IBusinessComponentRecord Add(IBusinessComponentRecord record) {
		
			IndexationCalcule_Transporteur_Record recordToAdd = record as IndexationCalcule_Transporteur_Record;

			if (recordToAdd == null) {

				throw new ArgumentException("Invalid record type. Must be 'Gestion_Paie.BusinessComponents.IndexationCalcule_Transporteur_Record'.", "record");
			}

			Params.spI_IndexationCalcule_Transporteur Param = new Params.spI_IndexationCalcule_Transporteur();
			Param.SetUpConnection(this.connectionString);

			Param.Param_ID = recordToAdd.Col_ID;
			Param.Param_DateCalcul = recordToAdd.Col_DateCalcul;
			Param.Param_TypeIndexation = recordToAdd.Col_TypeIndexation;
			Param.Param_IndexationID = recordToAdd.Col_IndexationID;
			Param.Param_IndexationDetailID = recordToAdd.Col_IndexationDetailID;
			Param.Param_LivraisonID = recordToAdd.Col_LivraisonID;
			Param.Param_TransporteurID = recordToAdd.Col_TransporteurID;
			Param.Param_MontantDejaPaye = recordToAdd.Col_MontantDejaPaye;
			Param.Param_PourcentageDuMontant = recordToAdd.Col_PourcentageDuMontant;
			Param.Param_Montant = recordToAdd.Col_Montant;
			Param.Param_Facture = recordToAdd.Col_Facture;
			Param.Param_FactureID = recordToAdd.Col_FactureID;
			Param.Param_ErreurCalcul = recordToAdd.Col_ErreurCalcul;
			Param.Param_ErreurDescription = recordToAdd.Col_ErreurDescription;

			SPs.spI_IndexationCalcule_Transporteur Sp = new SPs.spI_IndexationCalcule_Transporteur();
			if (Sp.Execute(ref Param)) {

				IndexationCalcule_Transporteur_Record newRecord = new IndexationCalcule_Transporteur_Record(this.connectionString, Param.Param_ID);				if (internalRecords != null) {

					internalRecords.Add(newRecord);
				}

				return(newRecord);
			}
			else {

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.IndexationCalcule_Transporteur_Collection", "Add");
			}	
		}

		/// <param name="Col_ID">[To be supplied.]</param>
		public void Remove(System.Data.SqlTypes.SqlInt32 Col_ID) {
		
			Params.spD_IndexationCalcule_Transporteur Param = new Params.spD_IndexationCalcule_Transporteur(true);
			Param.SetUpConnection(this.connectionString);

			Param.Param_ID = Col_ID;


			SPs.spD_IndexationCalcule_Transporteur Sp = new SPs.spD_IndexationCalcule_Transporteur(true);

			Sp.Execute(ref Param);
		}

		public void Remove(IBusinessComponentRecord record) {
		
			IndexationCalcule_Transporteur_Record recordToDelete = record as IndexationCalcule_Transporteur_Record;

			if (recordToDelete == null) {

				throw new ArgumentException("Invalid record type. Must be 'Gestion_Paie.BusinessComponents.IndexationCalcule_Transporteur_Record'.", "record");
			}

			Params.spD_IndexationCalcule_Transporteur Param = new Params.spD_IndexationCalcule_Transporteur(true);
			Param.SetUpConnection(this.connectionString);

			Param.Param_ID = recordToDelete.Col_ID;


			SPs.spD_IndexationCalcule_Transporteur Sp = new SPs.spD_IndexationCalcule_Transporteur(true);

			Sp.Execute(ref Param);

			if (internalRecords != null) {

				internalRecords.Remove(recordToDelete);
			}
		}

		public void Refresh() {

			internalRecords = new System.Collections.ArrayList();

			Params.spS_IndexationCalcule_Transporteur_Display Param = new Params.spS_IndexationCalcule_Transporteur_Display();
			Param.SetUpConnection(this.connectionString);

			if (!this.col_TypeIndexation.IsNull) {

				Param.Param_TypeIndexation = this.col_TypeIndexation;
			}

			if (!this.col_IndexationID.IsNull) {

				Param.Param_IndexationID = this.col_IndexationID;
			}

			if (!this.col_IndexationDetailID.IsNull) {

				Param.Param_IndexationDetailID = this.col_IndexationDetailID;
			}

			if (!this.col_LivraisonID.IsNull) {

				Param.Param_LivraisonID = this.col_LivraisonID;
			}

			if (!this.col_TransporteurID.IsNull) {

				Param.Param_TransporteurID = this.col_TransporteurID;
			}

			if (!this.col_FactureID.IsNull) {

				Param.Param_FactureID = this.col_FactureID;
			}


			System.Data.SqlClient.SqlDataReader sqlDataReader = null;
			SPs.spS_IndexationCalcule_Transporteur_Display Sp = new SPs.spS_IndexationCalcule_Transporteur_Display();
			if (Sp.Execute(ref Param, out sqlDataReader)) {

				while (sqlDataReader.Read()) {

					IndexationCalcule_Transporteur_Record record = new IndexationCalcule_Transporteur_Record(this.connectionString, sqlDataReader.GetSqlInt32(SPs.spS_IndexationCalcule_Transporteur_Display.Resultset1.Fields.Column_ID1.ColumnIndex));

					record.displayName = "spS_IndexationCalcule_Transporteur_Display";

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
				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.IndexationCalcule_Transporteur_Collection", "Refresh");
			}
		}

		public System.Collections.IEnumerator GetEnumerator() {

			if (!this.recordsAreLoaded) {

				Refresh();
			}

			return(internalRecords.GetEnumerator());
		}

		public IndexationCalcule_Transporteur_Record this[int index] {

			get {
				
				return((IndexationCalcule_Transporteur_Record)internalRecords[index]);
			}
		}

		/// <param name="col_ID">[To be supplied.]</param>
		/// <returns>[To be supplied.]</returns>
		public IndexationCalcule_Transporteur_Record this[System.Data.SqlTypes.SqlInt32 col_ID] {

			get {

				foreach(IndexationCalcule_Transporteur_Record record in internalRecords) {

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
