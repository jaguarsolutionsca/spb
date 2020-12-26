using System;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.BusinessComponents {

	public sealed class FactureUsine_Collection : IBusinessComponentCollection, System.Collections.IEnumerable, System.ComponentModel.IListSource {

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

		private System.Data.SqlTypes.SqlInt32 col_Annee = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_Annee {

			get {

				return(this.col_Annee);
			}
			set {

				this.col_Annee = value;
			}
		}

		internal void LoadFrom_Annee(System.Data.SqlTypes.SqlInt32 col_Annee, Periode_Record parent) {
		
			if (col_Annee.IsNull) {

				throw new ArgumentException("Parameter can not be null", "col_Annee");
			}

			if (parent == null) {

				throw new ArgumentException("Parameter can not be null", "parent");
			}

			this.col_Annee = col_Annee;
			this.parent = parent;
		}

		private System.Data.SqlTypes.SqlInt32 col_Periode = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_Periode {

			get {

				return(this.col_Periode);
			}
			set {

				this.col_Periode = value;
			}
		}

		internal void LoadFrom_Periode(System.Data.SqlTypes.SqlInt32 col_Periode, Periode_Record parent) {
		
			if (col_Periode.IsNull) {

				throw new ArgumentException("Parameter can not be null", "col_Periode");
			}

			if (parent == null) {

				throw new ArgumentException("Parameter can not be null", "parent");
			}

			this.col_Periode = col_Periode;
			this.parent = parent;
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


		public FactureUsine_Collection(string connectionString) {
			
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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'FactureUsine'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				sqlConnection.Close();

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}", "FactureUsine", CurrentRevision, OriginalRevision));
				}
			}
			}
#endif

		}

		/// <param name="col_Annee">[To be supplied.]</param>
		/// <param name="col_Periode">[To be supplied.]</param>
		/// <param name="col_ContratID">[To be supplied.]</param>
		public FactureUsine_Collection(string connectionString, System.Data.SqlTypes.SqlInt32 col_Annee, System.Data.SqlTypes.SqlInt32 col_Periode, System.Data.SqlTypes.SqlString col_ContratID) {
			
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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'FactureUsine'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				sqlConnection.Close();

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}", "FactureUsine", CurrentRevision, OriginalRevision));
				}
			}
			}
#endif

			this.col_Annee = col_Annee;
			this.col_Periode = col_Periode;
			this.col_ContratID = col_ContratID;
		}


		public IBusinessComponentRecord Add(IBusinessComponentRecord record) {
		
			FactureUsine_Record recordToAdd = record as FactureUsine_Record;

			if (recordToAdd == null) {

				throw new ArgumentException("Invalid record type. Must be 'Gestion_Paie.BusinessComponents.FactureUsine_Record'.", "record");
			}

			Params.spI_FactureUsine Param = new Params.spI_FactureUsine();
			Param.SetUpConnection(this.connectionString);

			Param.Param_ID = recordToAdd.Col_ID;
			Param.Param_DatePermis = recordToAdd.Col_DatePermis;
			Param.Param_DateLivraison = recordToAdd.Col_DateLivraison;
			Param.Param_DatePaye = recordToAdd.Col_DatePaye;
			Param.Param_Annee = recordToAdd.Col_Annee;
			Param.Param_Periode = recordToAdd.Col_Periode;
			Param.Param_ContratID = recordToAdd.Col_ContratID;
			Param.Param_Sciage = recordToAdd.Col_Sciage;
			Param.Param_EssenceSciage = recordToAdd.Col_EssenceSciage;
			Param.Param_NumeroFactureUsine = recordToAdd.Col_NumeroFactureUsine;
			Param.Param_ProducteurID = recordToAdd.Col_ProducteurID;
			Param.Param_Livraison = recordToAdd.Col_Livraison;

			SPs.spI_FactureUsine Sp = new SPs.spI_FactureUsine();
			if (Sp.Execute(ref Param)) {

				FactureUsine_Record newRecord = new FactureUsine_Record(this.connectionString, Param.Param_ID);				if (internalRecords != null) {

					internalRecords.Add(newRecord);
				}

				return(newRecord);
			}
			else {

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.FactureUsine_Collection", "Add");
			}	
		}

		/// <param name="Col_ID">[To be supplied.]</param>
		public void Remove(System.Data.SqlTypes.SqlInt32 Col_ID) {
		
			Params.spD_FactureUsine Param = new Params.spD_FactureUsine(true);
			Param.SetUpConnection(this.connectionString);

			Param.Param_ID = Col_ID;


			SPs.spD_FactureUsine Sp = new SPs.spD_FactureUsine(true);

			Sp.Execute(ref Param);
		}

		public void Remove(IBusinessComponentRecord record) {
		
			FactureUsine_Record recordToDelete = record as FactureUsine_Record;

			if (recordToDelete == null) {

				throw new ArgumentException("Invalid record type. Must be 'Gestion_Paie.BusinessComponents.FactureUsine_Record'.", "record");
			}

			Params.spD_FactureUsine Param = new Params.spD_FactureUsine(true);
			Param.SetUpConnection(this.connectionString);

			Param.Param_ID = recordToDelete.Col_ID;


			SPs.spD_FactureUsine Sp = new SPs.spD_FactureUsine(true);

			Sp.Execute(ref Param);

			if (internalRecords != null) {

				internalRecords.Remove(recordToDelete);
			}
		}

		public void Refresh() {

			internalRecords = new System.Collections.ArrayList();

			Params.spS_FactureUsine_Display Param = new Params.spS_FactureUsine_Display();
			Param.SetUpConnection(this.connectionString);

			if (!this.col_Annee.IsNull) {

				Param.Param_Annee = this.col_Annee;
			}

			if (!this.col_Periode.IsNull) {

				Param.Param_Periode = this.col_Periode;
			}

			if (!this.col_ContratID.IsNull) {

				Param.Param_ContratID = this.col_ContratID;
			}


			System.Data.SqlClient.SqlDataReader sqlDataReader = null;
			SPs.spS_FactureUsine_Display Sp = new SPs.spS_FactureUsine_Display();
			if (Sp.Execute(ref Param, out sqlDataReader)) {

				while (sqlDataReader.Read()) {

					FactureUsine_Record record = new FactureUsine_Record(this.connectionString, sqlDataReader.GetSqlInt32(SPs.spS_FactureUsine_Display.Resultset1.Fields.Column_ID1.ColumnIndex));

					record.displayName = "spS_FactureUsine_Display";

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
				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.FactureUsine_Collection", "Refresh");
			}
		}

		public System.Collections.IEnumerator GetEnumerator() {

			if (!this.recordsAreLoaded) {

				Refresh();
			}

			return(internalRecords.GetEnumerator());
		}

		public FactureUsine_Record this[int index] {

			get {
				
				return((FactureUsine_Record)internalRecords[index]);
			}
		}

		/// <param name="col_ID">[To be supplied.]</param>
		/// <returns>[To be supplied.]</returns>
		public FactureUsine_Record this[System.Data.SqlTypes.SqlInt32 col_ID] {

			get {

				foreach(FactureUsine_Record record in internalRecords) {

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
