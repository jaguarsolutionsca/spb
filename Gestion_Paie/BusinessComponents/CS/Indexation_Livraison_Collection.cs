using System;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.BusinessComponents {

	public sealed class Indexation_Livraison_Collection : IBusinessComponentCollection, System.Collections.IEnumerable, System.ComponentModel.IListSource {

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


		public Indexation_Livraison_Collection(string connectionString) {
			
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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Indexation_Livraison'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				sqlConnection.Close();

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}", "Indexation_Livraison", CurrentRevision, OriginalRevision));
				}
			}
			}
#endif

		}


		public IBusinessComponentRecord Add(IBusinessComponentRecord record) {
		
			Indexation_Livraison_Record recordToAdd = record as Indexation_Livraison_Record;

			if (recordToAdd == null) {

				throw new ArgumentException("Invalid record type. Must be 'Gestion_Paie.BusinessComponents.Indexation_Livraison_Record'.", "record");
			}

			Params.spI_Indexation_Livraison Param = new Params.spI_Indexation_Livraison();
			Param.SetUpConnection(this.connectionString);

			Param.Param_IndexationID = recordToAdd.Col_IndexationID;
			Param.Param_LivraisonID = recordToAdd.Col_LivraisonID;

			SPs.spI_Indexation_Livraison Sp = new SPs.spI_Indexation_Livraison();
			if (Sp.Execute(ref Param)) {

				Indexation_Livraison_Record newRecord = new Indexation_Livraison_Record(this.connectionString, Param.Param_IndexationID, Param.Param_LivraisonID);				if (internalRecords != null) {

					internalRecords.Add(newRecord);
				}

				return(newRecord);
			}
			else {

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Indexation_Livraison_Collection", "Add");
			}	
		}

		/// <param name="Col_IndexationID">[To be supplied.]</param>
		/// <param name="Col_LivraisonID">[To be supplied.]</param>
		public void Remove(System.Data.SqlTypes.SqlInt32 Col_IndexationID, System.Data.SqlTypes.SqlInt32 Col_LivraisonID) {
		
			Params.spD_Indexation_Livraison Param = new Params.spD_Indexation_Livraison(true);
			Param.SetUpConnection(this.connectionString);

			Param.Param_IndexationID = Col_IndexationID;

			Param.Param_LivraisonID = Col_LivraisonID;


			SPs.spD_Indexation_Livraison Sp = new SPs.spD_Indexation_Livraison(true);

			Sp.Execute(ref Param);
		}

		public void Remove(IBusinessComponentRecord record) {
		
			Indexation_Livraison_Record recordToDelete = record as Indexation_Livraison_Record;

			if (recordToDelete == null) {

				throw new ArgumentException("Invalid record type. Must be 'Gestion_Paie.BusinessComponents.Indexation_Livraison_Record'.", "record");
			}

			Params.spD_Indexation_Livraison Param = new Params.spD_Indexation_Livraison(true);
			Param.SetUpConnection(this.connectionString);

			Param.Param_IndexationID = recordToDelete.Col_IndexationID;

			Param.Param_LivraisonID = recordToDelete.Col_LivraisonID;


			SPs.spD_Indexation_Livraison Sp = new SPs.spD_Indexation_Livraison(true);

			Sp.Execute(ref Param);

			if (internalRecords != null) {

				internalRecords.Remove(recordToDelete);
			}
		}

		public void Refresh() {

			internalRecords = new System.Collections.ArrayList();

			Params.spS_Indexation_Livraison_Display Param = new Params.spS_Indexation_Livraison_Display();
			Param.SetUpConnection(this.connectionString);


			System.Data.SqlClient.SqlDataReader sqlDataReader = null;
			SPs.spS_Indexation_Livraison_Display Sp = new SPs.spS_Indexation_Livraison_Display();
			if (Sp.Execute(ref Param, out sqlDataReader)) {

				while (sqlDataReader.Read()) {

					Indexation_Livraison_Record record = new Indexation_Livraison_Record(this.connectionString, sqlDataReader.GetSqlInt32(SPs.spS_Indexation_Livraison_Display.Resultset1.Fields.Column_ID1.ColumnIndex), sqlDataReader.GetSqlInt32(SPs.spS_Indexation_Livraison_Display.Resultset1.Fields.Column_ID2.ColumnIndex));

					record.displayName = "spS_Indexation_Livraison_Display";

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
				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Indexation_Livraison_Collection", "Refresh");
			}
		}

		public System.Collections.IEnumerator GetEnumerator() {

			if (!this.recordsAreLoaded) {

				Refresh();
			}

			return(internalRecords.GetEnumerator());
		}

		public Indexation_Livraison_Record this[int index] {

			get {
				
				return((Indexation_Livraison_Record)internalRecords[index]);
			}
		}

		/// <param name="col_IndexationID">[To be supplied.]</param>
		/// <param name="col_LivraisonID">[To be supplied.]</param>
		/// <returns>[To be supplied.]</returns>
		public Indexation_Livraison_Record this[System.Data.SqlTypes.SqlInt32 col_IndexationID, System.Data.SqlTypes.SqlInt32 col_LivraisonID] {

			get {

				foreach(Indexation_Livraison_Record record in internalRecords) {

					bool Equality = true;

					Equality = Equality && (record.Col_IndexationID == col_IndexationID).Value;
					if (Equality) return(null);

					Equality = Equality && (record.Col_LivraisonID == col_LivraisonID).Value;
					if (Equality) return(null);

					return(record);
				}
				return(null);
			}
		}
	}
}
