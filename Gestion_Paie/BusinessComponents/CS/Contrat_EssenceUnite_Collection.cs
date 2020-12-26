using System;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.BusinessComponents {

	public sealed class Contrat_EssenceUnite_Collection : IBusinessComponentCollection, System.Collections.IEnumerable, System.ComponentModel.IListSource {

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

		private System.Data.SqlTypes.SqlString col_EssenceID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_EssenceID {

			get {

				return(this.col_EssenceID);
			}
			set {

				this.col_EssenceID = value;
			}
		}

		internal void LoadFrom_EssenceID(System.Data.SqlTypes.SqlString col_EssenceID, Essence_Unite_Record parent) {
		
			if (col_EssenceID.IsNull) {

				throw new ArgumentException("Parameter can not be null", "col_EssenceID");
			}

			if (parent == null) {

				throw new ArgumentException("Parameter can not be null", "parent");
			}

			this.col_EssenceID = col_EssenceID;
			this.parent = parent;
		}

		private System.Data.SqlTypes.SqlString col_UniteID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_UniteID {

			get {

				return(this.col_UniteID);
			}
			set {

				this.col_UniteID = value;
			}
		}

		internal void LoadFrom_UniteID(System.Data.SqlTypes.SqlString col_UniteID, Essence_Unite_Record parent) {
		
			if (col_UniteID.IsNull) {

				throw new ArgumentException("Parameter can not be null", "col_UniteID");
			}

			if (parent == null) {

				throw new ArgumentException("Parameter can not be null", "parent");
			}

			this.col_UniteID = col_UniteID;
			this.parent = parent;
		}


		public Contrat_EssenceUnite_Collection(string connectionString) {
			
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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Contrat_EssenceUnite'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				sqlConnection.Close();

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}", "Contrat_EssenceUnite", CurrentRevision, OriginalRevision));
				}
			}
			}
#endif

		}


		public IBusinessComponentRecord Add(IBusinessComponentRecord record) {
		
			Contrat_EssenceUnite_Record recordToAdd = record as Contrat_EssenceUnite_Record;

			if (recordToAdd == null) {

				throw new ArgumentException("Invalid record type. Must be 'Gestion_Paie.BusinessComponents.Contrat_EssenceUnite_Record'.", "record");
			}

			Params.spI_Contrat_EssenceUnite Param = new Params.spI_Contrat_EssenceUnite();
			Param.SetUpConnection(this.connectionString);

			Param.Param_ContratID = recordToAdd.Col_ContratID;
			Param.Param_EssenceID = recordToAdd.Col_EssenceID;
			Param.Param_UniteID = recordToAdd.Col_UniteID;
			Param.Param_Code = recordToAdd.Col_Code;
			Param.Param_Quantite_prevue = recordToAdd.Col_Quantite_prevue;
			Param.Param_Taux_usine = recordToAdd.Col_Taux_usine;
			Param.Param_Taux_producteur = recordToAdd.Col_Taux_producteur;
			Param.Param_Actif = recordToAdd.Col_Actif;
			Param.Param_Description = recordToAdd.Col_Description;

			SPs.spI_Contrat_EssenceUnite Sp = new SPs.spI_Contrat_EssenceUnite();
			if (Sp.Execute(ref Param)) {

				Contrat_EssenceUnite_Record newRecord = new Contrat_EssenceUnite_Record(this.connectionString, Param.Param_ContratID, Param.Param_EssenceID, Param.Param_UniteID, Param.Param_Code);				if (internalRecords != null) {

					internalRecords.Add(newRecord);
				}

				return(newRecord);
			}
			else {

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Contrat_EssenceUnite_Collection", "Add");
			}	
		}

		/// <param name="Col_ContratID">[To be supplied.]</param>
		/// <param name="Col_EssenceID">[To be supplied.]</param>
		/// <param name="Col_UniteID">[To be supplied.]</param>
		/// <param name="Col_Code">[To be supplied.]</param>
		public void Remove(System.Data.SqlTypes.SqlString Col_ContratID, System.Data.SqlTypes.SqlString Col_EssenceID, System.Data.SqlTypes.SqlString Col_UniteID, System.Data.SqlTypes.SqlString Col_Code) {
		
			Params.spD_Contrat_EssenceUnite Param = new Params.spD_Contrat_EssenceUnite(true);
			Param.SetUpConnection(this.connectionString);

			Param.Param_ContratID = Col_ContratID;

			Param.Param_EssenceID = Col_EssenceID;

			Param.Param_UniteID = Col_UniteID;

			Param.Param_Code = Col_Code;


			SPs.spD_Contrat_EssenceUnite Sp = new SPs.spD_Contrat_EssenceUnite(true);

			Sp.Execute(ref Param);
		}

		public void Remove(IBusinessComponentRecord record) {
		
			Contrat_EssenceUnite_Record recordToDelete = record as Contrat_EssenceUnite_Record;

			if (recordToDelete == null) {

				throw new ArgumentException("Invalid record type. Must be 'Gestion_Paie.BusinessComponents.Contrat_EssenceUnite_Record'.", "record");
			}

			Params.spD_Contrat_EssenceUnite Param = new Params.spD_Contrat_EssenceUnite(true);
			Param.SetUpConnection(this.connectionString);

			Param.Param_ContratID = recordToDelete.Col_ContratID;

			Param.Param_EssenceID = recordToDelete.Col_EssenceID;

			Param.Param_UniteID = recordToDelete.Col_UniteID;

			Param.Param_Code = recordToDelete.Col_Code;


			SPs.spD_Contrat_EssenceUnite Sp = new SPs.spD_Contrat_EssenceUnite(true);

			Sp.Execute(ref Param);

			if (internalRecords != null) {

				internalRecords.Remove(recordToDelete);
			}
		}

		public void Refresh() {

			internalRecords = new System.Collections.ArrayList();

			Params.spS_Contrat_EssenceUnite_Display Param = new Params.spS_Contrat_EssenceUnite_Display();
			Param.SetUpConnection(this.connectionString);

			if (!this.col_ContratID.IsNull) {

				Param.Param_ContratID = this.col_ContratID;
			}

			if (!this.col_EssenceID.IsNull) {

				Param.Param_EssenceID = this.col_EssenceID;
			}

			if (!this.col_UniteID.IsNull) {

				Param.Param_UniteID = this.col_UniteID;
			}


			System.Data.SqlClient.SqlDataReader sqlDataReader = null;
			SPs.spS_Contrat_EssenceUnite_Display Sp = new SPs.spS_Contrat_EssenceUnite_Display();
			if (Sp.Execute(ref Param, out sqlDataReader)) {

				while (sqlDataReader.Read()) {

					Contrat_EssenceUnite_Record record = new Contrat_EssenceUnite_Record(this.connectionString, sqlDataReader.GetSqlString(SPs.spS_Contrat_EssenceUnite_Display.Resultset1.Fields.Column_ID1.ColumnIndex), sqlDataReader.GetSqlString(SPs.spS_Contrat_EssenceUnite_Display.Resultset1.Fields.Column_ID2.ColumnIndex), sqlDataReader.GetSqlString(SPs.spS_Contrat_EssenceUnite_Display.Resultset1.Fields.Column_ID3.ColumnIndex), sqlDataReader.GetSqlString(SPs.spS_Contrat_EssenceUnite_Display.Resultset1.Fields.Column_ID4.ColumnIndex));

					record.displayName = "spS_Contrat_EssenceUnite_Display";

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
				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Contrat_EssenceUnite_Collection", "Refresh");
			}
		}

		public System.Collections.IEnumerator GetEnumerator() {

			if (!this.recordsAreLoaded) {

				Refresh();
			}

			return(internalRecords.GetEnumerator());
		}

		public Contrat_EssenceUnite_Record this[int index] {

			get {
				
				return((Contrat_EssenceUnite_Record)internalRecords[index]);
			}
		}

		/// <param name="col_ContratID">[To be supplied.]</param>
		/// <param name="col_EssenceID">[To be supplied.]</param>
		/// <param name="col_UniteID">[To be supplied.]</param>
		/// <param name="col_Code">[To be supplied.]</param>
		/// <returns>[To be supplied.]</returns>
		public Contrat_EssenceUnite_Record this[System.Data.SqlTypes.SqlString col_ContratID, System.Data.SqlTypes.SqlString col_EssenceID, System.Data.SqlTypes.SqlString col_UniteID, System.Data.SqlTypes.SqlString col_Code] {

			get {

				foreach(Contrat_EssenceUnite_Record record in internalRecords) {

					bool Equality = true;

					Equality = Equality && (record.Col_ContratID == col_ContratID).Value;
					if (Equality) return(null);

					Equality = Equality && (record.Col_EssenceID == col_EssenceID).Value;
					if (Equality) return(null);

					Equality = Equality && (record.Col_UniteID == col_UniteID).Value;
					if (Equality) return(null);

					Equality = Equality && (record.Col_Code == col_Code).Value;
					if (Equality) return(null);

					return(record);
				}
				return(null);
			}
		}
	}
}
