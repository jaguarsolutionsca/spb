using System;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.BusinessComponents {

	public sealed class Contingentement_Demande_Collection : IBusinessComponentCollection, System.Collections.IEnumerable, System.ComponentModel.IListSource {

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

		private System.Data.SqlTypes.SqlString col_ProducteurID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_ProducteurID {

			get {

				return(this.col_ProducteurID);
			}
			set {

				this.col_ProducteurID = value;
			}
		}

		internal void LoadFrom_ProducteurID(System.Data.SqlTypes.SqlString col_ProducteurID, Fournisseur_Record parent) {
		
			if (col_ProducteurID.IsNull) {

				throw new ArgumentException("Parameter can not be null", "col_ProducteurID");
			}

			if (parent == null) {

				throw new ArgumentException("Parameter can not be null", "parent");
			}

			this.col_ProducteurID = col_ProducteurID;
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


		public Contingentement_Demande_Collection(string connectionString) {
			
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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Contingentement_Demande'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				sqlConnection.Close();

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}", "Contingentement_Demande", CurrentRevision, OriginalRevision));
				}
			}
			}
#endif

		}

		/// <param name="col_ProducteurID">[To be supplied.]</param>
		/// <param name="col_TransporteurID">[To be supplied.]</param>
		public Contingentement_Demande_Collection(string connectionString, System.Data.SqlTypes.SqlString col_ProducteurID, System.Data.SqlTypes.SqlString col_TransporteurID) {
			
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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Contingentement_Demande'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				sqlConnection.Close();

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}", "Contingentement_Demande", CurrentRevision, OriginalRevision));
				}
			}
			}
#endif

			this.col_ProducteurID = col_ProducteurID;
			this.col_TransporteurID = col_TransporteurID;
		}


		public IBusinessComponentRecord Add(IBusinessComponentRecord record) {
		
			Contingentement_Demande_Record recordToAdd = record as Contingentement_Demande_Record;

			if (recordToAdd == null) {

				throw new ArgumentException("Invalid record type. Must be 'Gestion_Paie.BusinessComponents.Contingentement_Demande_Record'.", "record");
			}

			Params.spI_Contingentement_Demande Param = new Params.spI_Contingentement_Demande();
			Param.SetUpConnection(this.connectionString);

			Param.Param_ID = recordToAdd.Col_ID;
			Param.Param_Annee = recordToAdd.Col_Annee;
			Param.Param_ProducteurID = recordToAdd.Col_ProducteurID;
			Param.Param_TransporteurID = recordToAdd.Col_TransporteurID;
			Param.Param_Superficie_Boisee = recordToAdd.Col_Superficie_Boisee;
			Param.Param_Remarques = recordToAdd.Col_Remarques;
			Param.Param_DateModification = recordToAdd.Col_DateModification;

			SPs.spI_Contingentement_Demande Sp = new SPs.spI_Contingentement_Demande();
			if (Sp.Execute(ref Param)) {

				Contingentement_Demande_Record newRecord = new Contingentement_Demande_Record(this.connectionString, Param.Param_ID);				if (internalRecords != null) {

					internalRecords.Add(newRecord);
				}

				return(newRecord);
			}
			else {

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Contingentement_Demande_Collection", "Add");
			}	
		}

		/// <param name="Col_ID">[To be supplied.]</param>
		public void Remove(System.Data.SqlTypes.SqlInt32 Col_ID) {
		
			Params.spD_Contingentement_Demande Param = new Params.spD_Contingentement_Demande(true);
			Param.SetUpConnection(this.connectionString);

			Param.Param_ID = Col_ID;


			SPs.spD_Contingentement_Demande Sp = new SPs.spD_Contingentement_Demande(true);

			Sp.Execute(ref Param);
		}

		public void Remove(IBusinessComponentRecord record) {
		
			Contingentement_Demande_Record recordToDelete = record as Contingentement_Demande_Record;

			if (recordToDelete == null) {

				throw new ArgumentException("Invalid record type. Must be 'Gestion_Paie.BusinessComponents.Contingentement_Demande_Record'.", "record");
			}

			Params.spD_Contingentement_Demande Param = new Params.spD_Contingentement_Demande(true);
			Param.SetUpConnection(this.connectionString);

			Param.Param_ID = recordToDelete.Col_ID;


			SPs.spD_Contingentement_Demande Sp = new SPs.spD_Contingentement_Demande(true);

			Sp.Execute(ref Param);

			if (internalRecords != null) {

				internalRecords.Remove(recordToDelete);
			}
		}

		public void Refresh() {

			internalRecords = new System.Collections.ArrayList();

			Params.spS_Contingentement_Demande_Display Param = new Params.spS_Contingentement_Demande_Display();
			Param.SetUpConnection(this.connectionString);

			if (!this.col_ProducteurID.IsNull) {

				Param.Param_ProducteurID = this.col_ProducteurID;
			}

			if (!this.col_TransporteurID.IsNull) {

				Param.Param_TransporteurID = this.col_TransporteurID;
			}


			System.Data.SqlClient.SqlDataReader sqlDataReader = null;
			SPs.spS_Contingentement_Demande_Display Sp = new SPs.spS_Contingentement_Demande_Display();
			if (Sp.Execute(ref Param, out sqlDataReader)) {

				while (sqlDataReader.Read()) {

					Contingentement_Demande_Record record = new Contingentement_Demande_Record(this.connectionString, sqlDataReader.GetSqlInt32(SPs.spS_Contingentement_Demande_Display.Resultset1.Fields.Column_ID1.ColumnIndex));

					record.displayName = "spS_Contingentement_Demande_Display";

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
				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Contingentement_Demande_Collection", "Refresh");
			}
		}

		public System.Collections.IEnumerator GetEnumerator() {

			if (!this.recordsAreLoaded) {

				Refresh();
			}

			return(internalRecords.GetEnumerator());
		}

		public Contingentement_Demande_Record this[int index] {

			get {
				
				return((Contingentement_Demande_Record)internalRecords[index]);
			}
		}

		/// <param name="col_ID">[To be supplied.]</param>
		/// <returns>[To be supplied.]</returns>
		public Contingentement_Demande_Record this[System.Data.SqlTypes.SqlInt32 col_ID] {

			get {

				foreach(Contingentement_Demande_Record record in internalRecords) {

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
