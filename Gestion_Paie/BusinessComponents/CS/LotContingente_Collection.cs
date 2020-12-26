using System;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.BusinessComponents {

	public sealed class LotContingente_Collection : IBusinessComponentCollection, System.Collections.IEnumerable, System.ComponentModel.IListSource {

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


		public LotContingente_Collection(string connectionString) {
			
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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'LotContingente'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				sqlConnection.Close();

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}", "LotContingente", CurrentRevision, OriginalRevision));
				}
			}
			}
#endif

		}


		public IBusinessComponentRecord Add(IBusinessComponentRecord record) {
		
			LotContingente_Record recordToAdd = record as LotContingente_Record;

			if (recordToAdd == null) {

				throw new ArgumentException("Invalid record type. Must be 'Gestion_Paie.BusinessComponents.LotContingente_Record'.", "record");
			}

			Params.spI_LotContingente Param = new Params.spI_LotContingente();
			Param.SetUpConnection(this.connectionString);

			Param.Param_LotID = recordToAdd.Col_LotID;
			Param.Param_Annee = recordToAdd.Col_Annee;
			Param.Param_SuperficieContingentee = recordToAdd.Col_SuperficieContingentee;
			Param.Param_Override = recordToAdd.Col_Override;
			Param.Param_FournisseurID = recordToAdd.Col_FournisseurID;

			SPs.spI_LotContingente Sp = new SPs.spI_LotContingente();
			if (Sp.Execute(ref Param)) {

				LotContingente_Record newRecord = new LotContingente_Record(this.connectionString, Param.Param_LotID, Param.Param_Annee, Param.Param_FournisseurID);				if (internalRecords != null) {

					internalRecords.Add(newRecord);
				}

				return(newRecord);
			}
			else {

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.LotContingente_Collection", "Add");
			}	
		}

		/// <param name="Col_LotID">[To be supplied.]</param>
		/// <param name="Col_Annee">[To be supplied.]</param>
		/// <param name="Col_FournisseurID">[To be supplied.]</param>
		public void Remove(System.Data.SqlTypes.SqlInt32 Col_LotID, System.Data.SqlTypes.SqlInt32 Col_Annee, System.Data.SqlTypes.SqlString Col_FournisseurID) {
		
			Params.spD_LotContingente Param = new Params.spD_LotContingente(true);
			Param.SetUpConnection(this.connectionString);

			Param.Param_LotID = Col_LotID;

			Param.Param_Annee = Col_Annee;

			Param.Param_FournisseurID = Col_FournisseurID;


			SPs.spD_LotContingente Sp = new SPs.spD_LotContingente(true);

			Sp.Execute(ref Param);
		}

		public void Remove(IBusinessComponentRecord record) {
		
			LotContingente_Record recordToDelete = record as LotContingente_Record;

			if (recordToDelete == null) {

				throw new ArgumentException("Invalid record type. Must be 'Gestion_Paie.BusinessComponents.LotContingente_Record'.", "record");
			}

			Params.spD_LotContingente Param = new Params.spD_LotContingente(true);
			Param.SetUpConnection(this.connectionString);

			Param.Param_LotID = recordToDelete.Col_LotID;

			Param.Param_Annee = recordToDelete.Col_Annee;

			Param.Param_FournisseurID = recordToDelete.Col_FournisseurID;


			SPs.spD_LotContingente Sp = new SPs.spD_LotContingente(true);

			Sp.Execute(ref Param);

			if (internalRecords != null) {

				internalRecords.Remove(recordToDelete);
			}
		}

		public void Refresh() {

			internalRecords = new System.Collections.ArrayList();

			Params.spS_LotContingente_Display Param = new Params.spS_LotContingente_Display();
			Param.SetUpConnection(this.connectionString);

			if (!this.col_LotID.IsNull) {

				Param.Param_LotID = this.col_LotID;
			}

			if (!this.col_FournisseurID.IsNull) {

				Param.Param_FournisseurID = this.col_FournisseurID;
			}


			System.Data.SqlClient.SqlDataReader sqlDataReader = null;
			SPs.spS_LotContingente_Display Sp = new SPs.spS_LotContingente_Display();
			if (Sp.Execute(ref Param, out sqlDataReader)) {

				while (sqlDataReader.Read()) {

					LotContingente_Record record = new LotContingente_Record(this.connectionString, sqlDataReader.GetSqlInt32(SPs.spS_LotContingente_Display.Resultset1.Fields.Column_ID1.ColumnIndex), sqlDataReader.GetSqlInt32(SPs.spS_LotContingente_Display.Resultset1.Fields.Column_ID2.ColumnIndex), sqlDataReader.GetSqlString(SPs.spS_LotContingente_Display.Resultset1.Fields.Column_ID3.ColumnIndex));

					record.displayName = "spS_LotContingente_Display";

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
				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.LotContingente_Collection", "Refresh");
			}
		}

		public System.Collections.IEnumerator GetEnumerator() {

			if (!this.recordsAreLoaded) {

				Refresh();
			}

			return(internalRecords.GetEnumerator());
		}

		public LotContingente_Record this[int index] {

			get {
				
				return((LotContingente_Record)internalRecords[index]);
			}
		}

		/// <param name="col_LotID">[To be supplied.]</param>
		/// <param name="col_Annee">[To be supplied.]</param>
		/// <param name="col_FournisseurID">[To be supplied.]</param>
		/// <returns>[To be supplied.]</returns>
		public LotContingente_Record this[System.Data.SqlTypes.SqlInt32 col_LotID, System.Data.SqlTypes.SqlInt32 col_Annee, System.Data.SqlTypes.SqlString col_FournisseurID] {

			get {

				foreach(LotContingente_Record record in internalRecords) {

					bool Equality = true;

					Equality = Equality && (record.Col_LotID == col_LotID).Value;
					if (Equality) return(null);

					Equality = Equality && (record.Col_Annee == col_Annee).Value;
					if (Equality) return(null);

					Equality = Equality && (record.Col_FournisseurID == col_FournisseurID).Value;
					if (Equality) return(null);

					return(record);
				}
				return(null);
			}
		}
	}
}
