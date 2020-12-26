using System;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.BusinessComponents {

	public sealed class Fournisseur_Camion_Collection : IBusinessComponentCollection, System.Collections.IEnumerable, System.ComponentModel.IListSource {

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


		public Fournisseur_Camion_Collection(string connectionString) {
			
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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Fournisseur_Camion'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				sqlConnection.Close();

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}", "Fournisseur_Camion", CurrentRevision, OriginalRevision));
				}
			}
			}
#endif

		}


		public IBusinessComponentRecord Add(IBusinessComponentRecord record) {
		
			Fournisseur_Camion_Record recordToAdd = record as Fournisseur_Camion_Record;

			if (recordToAdd == null) {

				throw new ArgumentException("Invalid record type. Must be 'Gestion_Paie.BusinessComponents.Fournisseur_Camion_Record'.", "record");
			}

			Params.spI_Fournisseur_Camion Param = new Params.spI_Fournisseur_Camion();
			Param.SetUpConnection(this.connectionString);

			Param.Param_FournisseurID = recordToAdd.Col_FournisseurID;
			Param.Param_VR = recordToAdd.Col_VR;
			Param.Param_MasseLimite = recordToAdd.Col_MasseLimite;
			Param.Param_Actif = recordToAdd.Col_Actif;

			SPs.spI_Fournisseur_Camion Sp = new SPs.spI_Fournisseur_Camion();
			if (Sp.Execute(ref Param)) {

				Fournisseur_Camion_Record newRecord = new Fournisseur_Camion_Record(this.connectionString, Param.Param_FournisseurID, Param.Param_VR);				if (internalRecords != null) {

					internalRecords.Add(newRecord);
				}

				return(newRecord);
			}
			else {

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Fournisseur_Camion_Collection", "Add");
			}	
		}

		/// <param name="Col_FournisseurID">[To be supplied.]</param>
		/// <param name="Col_VR">[To be supplied.]</param>
		public void Remove(System.Data.SqlTypes.SqlString Col_FournisseurID, System.Data.SqlTypes.SqlString Col_VR) {
		
			Params.spD_Fournisseur_Camion Param = new Params.spD_Fournisseur_Camion(true);
			Param.SetUpConnection(this.connectionString);

			Param.Param_FournisseurID = Col_FournisseurID;

			Param.Param_VR = Col_VR;


			SPs.spD_Fournisseur_Camion Sp = new SPs.spD_Fournisseur_Camion(true);

			Sp.Execute(ref Param);
		}

		public void Remove(IBusinessComponentRecord record) {
		
			Fournisseur_Camion_Record recordToDelete = record as Fournisseur_Camion_Record;

			if (recordToDelete == null) {

				throw new ArgumentException("Invalid record type. Must be 'Gestion_Paie.BusinessComponents.Fournisseur_Camion_Record'.", "record");
			}

			Params.spD_Fournisseur_Camion Param = new Params.spD_Fournisseur_Camion(true);
			Param.SetUpConnection(this.connectionString);

			Param.Param_FournisseurID = recordToDelete.Col_FournisseurID;

			Param.Param_VR = recordToDelete.Col_VR;


			SPs.spD_Fournisseur_Camion Sp = new SPs.spD_Fournisseur_Camion(true);

			Sp.Execute(ref Param);

			if (internalRecords != null) {

				internalRecords.Remove(recordToDelete);
			}
		}

		public void Refresh() {

			internalRecords = new System.Collections.ArrayList();

			Params.spS_Fournisseur_Camion_Display Param = new Params.spS_Fournisseur_Camion_Display();
			Param.SetUpConnection(this.connectionString);

			if (!this.col_FournisseurID.IsNull) {

				Param.Param_FournisseurID = this.col_FournisseurID;
			}


			System.Data.SqlClient.SqlDataReader sqlDataReader = null;
			SPs.spS_Fournisseur_Camion_Display Sp = new SPs.spS_Fournisseur_Camion_Display();
			if (Sp.Execute(ref Param, out sqlDataReader)) {

				while (sqlDataReader.Read()) {

					Fournisseur_Camion_Record record = new Fournisseur_Camion_Record(this.connectionString, sqlDataReader.GetSqlString(SPs.spS_Fournisseur_Camion_Display.Resultset1.Fields.Column_ID1.ColumnIndex), sqlDataReader.GetSqlString(SPs.spS_Fournisseur_Camion_Display.Resultset1.Fields.Column_ID2.ColumnIndex));

					record.displayName = "spS_Fournisseur_Camion_Display";

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
				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Fournisseur_Camion_Collection", "Refresh");
			}
		}

		public System.Collections.IEnumerator GetEnumerator() {

			if (!this.recordsAreLoaded) {

				Refresh();
			}

			return(internalRecords.GetEnumerator());
		}

		public Fournisseur_Camion_Record this[int index] {

			get {
				
				return((Fournisseur_Camion_Record)internalRecords[index]);
			}
		}

		/// <param name="col_FournisseurID">[To be supplied.]</param>
		/// <param name="col_VR">[To be supplied.]</param>
		/// <returns>[To be supplied.]</returns>
		public Fournisseur_Camion_Record this[System.Data.SqlTypes.SqlString col_FournisseurID, System.Data.SqlTypes.SqlString col_VR] {

			get {

				foreach(Fournisseur_Camion_Record record in internalRecords) {

					bool Equality = true;

					Equality = Equality && (record.Col_FournisseurID == col_FournisseurID).Value;
					if (Equality) return(null);

					Equality = Equality && (record.Col_VR == col_VR).Value;
					if (Equality) return(null);

					return(record);
				}
				return(null);
			}
		}
	}
}
