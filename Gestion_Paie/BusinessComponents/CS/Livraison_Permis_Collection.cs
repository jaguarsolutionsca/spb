using System;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.BusinessComponents {

	public sealed class Livraison_Permis_Collection : IBusinessComponentCollection, System.Collections.IEnumerable, System.ComponentModel.IListSource {

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

		private System.Data.SqlTypes.SqlInt32 col_PermisID = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_PermisID {

			get {

				return(this.col_PermisID);
			}
			set {

				this.col_PermisID = value;
			}
		}

		internal void LoadFrom_PermisID(System.Data.SqlTypes.SqlInt32 col_PermisID, Permit_Record parent) {
		
			if (col_PermisID.IsNull) {

				throw new ArgumentException("Parameter can not be null", "col_PermisID");
			}

			if (parent == null) {

				throw new ArgumentException("Parameter can not be null", "parent");
			}

			this.col_PermisID = col_PermisID;
			this.parent = parent;
		}


		public Livraison_Permis_Collection(string connectionString) {
			
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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Livraison_Permis'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				sqlConnection.Close();

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}", "Livraison_Permis", CurrentRevision, OriginalRevision));
				}
			}
			}
#endif

		}


		public IBusinessComponentRecord Add(IBusinessComponentRecord record) {
		
			Livraison_Permis_Record recordToAdd = record as Livraison_Permis_Record;

			if (recordToAdd == null) {

				throw new ArgumentException("Invalid record type. Must be 'Gestion_Paie.BusinessComponents.Livraison_Permis_Record'.", "record");
			}

			Params.spI_Livraison_Permis Param = new Params.spI_Livraison_Permis();
			Param.SetUpConnection(this.connectionString);

			Param.Param_LivraisonID = recordToAdd.Col_LivraisonID;
			Param.Param_PermisID = recordToAdd.Col_PermisID;
			Param.Param_NumeroFactureUsine = recordToAdd.Col_NumeroFactureUsine;

			SPs.spI_Livraison_Permis Sp = new SPs.spI_Livraison_Permis();
			if (Sp.Execute(ref Param)) {

				Livraison_Permis_Record newRecord = new Livraison_Permis_Record(this.connectionString, Param.Param_LivraisonID, Param.Param_PermisID);				if (internalRecords != null) {

					internalRecords.Add(newRecord);
				}

				return(newRecord);
			}
			else {

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Livraison_Permis_Collection", "Add");
			}	
		}

		/// <param name="Col_LivraisonID">[To be supplied.]</param>
		/// <param name="Col_PermisID">[To be supplied.]</param>
		public void Remove(System.Data.SqlTypes.SqlInt32 Col_LivraisonID, System.Data.SqlTypes.SqlInt32 Col_PermisID) {
		
			Params.spD_Livraison_Permis Param = new Params.spD_Livraison_Permis(true);
			Param.SetUpConnection(this.connectionString);

			Param.Param_LivraisonID = Col_LivraisonID;

			Param.Param_PermisID = Col_PermisID;


			SPs.spD_Livraison_Permis Sp = new SPs.spD_Livraison_Permis(true);

			Sp.Execute(ref Param);
		}

		public void Remove(IBusinessComponentRecord record) {
		
			Livraison_Permis_Record recordToDelete = record as Livraison_Permis_Record;

			if (recordToDelete == null) {

				throw new ArgumentException("Invalid record type. Must be 'Gestion_Paie.BusinessComponents.Livraison_Permis_Record'.", "record");
			}

			Params.spD_Livraison_Permis Param = new Params.spD_Livraison_Permis(true);
			Param.SetUpConnection(this.connectionString);

			Param.Param_LivraisonID = recordToDelete.Col_LivraisonID;

			Param.Param_PermisID = recordToDelete.Col_PermisID;


			SPs.spD_Livraison_Permis Sp = new SPs.spD_Livraison_Permis(true);

			Sp.Execute(ref Param);

			if (internalRecords != null) {

				internalRecords.Remove(recordToDelete);
			}
		}

		public void Refresh() {

			internalRecords = new System.Collections.ArrayList();

			Params.spS_Livraison_Permis_Display Param = new Params.spS_Livraison_Permis_Display();
			Param.SetUpConnection(this.connectionString);

			if (!this.col_LivraisonID.IsNull) {

				Param.Param_LivraisonID = this.col_LivraisonID;
			}

			if (!this.col_PermisID.IsNull) {

				Param.Param_PermisID = this.col_PermisID;
			}


			System.Data.SqlClient.SqlDataReader sqlDataReader = null;
			SPs.spS_Livraison_Permis_Display Sp = new SPs.spS_Livraison_Permis_Display();
			if (Sp.Execute(ref Param, out sqlDataReader)) {

				while (sqlDataReader.Read()) {

					Livraison_Permis_Record record = new Livraison_Permis_Record(this.connectionString, sqlDataReader.GetSqlInt32(SPs.spS_Livraison_Permis_Display.Resultset1.Fields.Column_ID1.ColumnIndex), sqlDataReader.GetSqlInt32(SPs.spS_Livraison_Permis_Display.Resultset1.Fields.Column_ID2.ColumnIndex));

					record.displayName = "spS_Livraison_Permis_Display";

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
				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Livraison_Permis_Collection", "Refresh");
			}
		}

		public System.Collections.IEnumerator GetEnumerator() {

			if (!this.recordsAreLoaded) {

				Refresh();
			}

			return(internalRecords.GetEnumerator());
		}

		public Livraison_Permis_Record this[int index] {

			get {
				
				return((Livraison_Permis_Record)internalRecords[index]);
			}
		}

		/// <param name="col_LivraisonID">[To be supplied.]</param>
		/// <param name="col_PermisID">[To be supplied.]</param>
		/// <returns>[To be supplied.]</returns>
		public Livraison_Permis_Record this[System.Data.SqlTypes.SqlInt32 col_LivraisonID, System.Data.SqlTypes.SqlInt32 col_PermisID] {

			get {

				foreach(Livraison_Permis_Record record in internalRecords) {

					bool Equality = true;

					Equality = Equality && (record.Col_LivraisonID == col_LivraisonID).Value;
					if (Equality) return(null);

					Equality = Equality && (record.Col_PermisID == col_PermisID).Value;
					if (Equality) return(null);

					return(record);
				}
				return(null);
			}
		}
	}
}
