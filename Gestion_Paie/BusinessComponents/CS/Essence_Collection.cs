using System;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.BusinessComponents {

	public sealed class Essence_Collection : IBusinessComponentCollection, System.Collections.IEnumerable, System.ComponentModel.IListSource {

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

		private System.Data.SqlTypes.SqlInt32 col_RegroupementID = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_RegroupementID {

			get {

				return(this.col_RegroupementID);
			}
			set {

				this.col_RegroupementID = value;
			}
		}

		internal void LoadFrom_RegroupementID(System.Data.SqlTypes.SqlInt32 col_RegroupementID, EssenceRegroupement_Record parent) {
		
			if (col_RegroupementID.IsNull) {

				throw new ArgumentException("Parameter can not be null", "col_RegroupementID");
			}

			if (parent == null) {

				throw new ArgumentException("Parameter can not be null", "parent");
			}

			this.col_RegroupementID = col_RegroupementID;
			this.parent = parent;
		}

		private System.Data.SqlTypes.SqlInt32 col_ContingentID = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_ContingentID {

			get {

				return(this.col_ContingentID);
			}
			set {

				this.col_ContingentID = value;
			}
		}

		internal void LoadFrom_ContingentID(System.Data.SqlTypes.SqlInt32 col_ContingentID, EssenceContingent_Record parent) {
		
			if (col_ContingentID.IsNull) {

				throw new ArgumentException("Parameter can not be null", "col_ContingentID");
			}

			if (parent == null) {

				throw new ArgumentException("Parameter can not be null", "parent");
			}

			this.col_ContingentID = col_ContingentID;
			this.parent = parent;
		}

		private System.Data.SqlTypes.SqlInt32 col_RepartitionID = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_RepartitionID {

			get {

				return(this.col_RepartitionID);
			}
			set {

				this.col_RepartitionID = value;
			}
		}

		internal void LoadFrom_RepartitionID(System.Data.SqlTypes.SqlInt32 col_RepartitionID, EssenceRepartition_Record parent) {
		
			if (col_RepartitionID.IsNull) {

				throw new ArgumentException("Parameter can not be null", "col_RepartitionID");
			}

			if (parent == null) {

				throw new ArgumentException("Parameter can not be null", "parent");
			}

			this.col_RepartitionID = col_RepartitionID;
			this.parent = parent;
		}


		public Essence_Collection(string connectionString) {
			
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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Essence'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				sqlConnection.Close();

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}", "Essence", CurrentRevision, OriginalRevision));
				}
			}
			}
#endif

		}

		/// <param name="col_RegroupementID">[To be supplied.]</param>
		/// <param name="col_ContingentID">[To be supplied.]</param>
		/// <param name="col_RepartitionID">[To be supplied.]</param>
		public Essence_Collection(string connectionString, System.Data.SqlTypes.SqlInt32 col_RegroupementID, System.Data.SqlTypes.SqlInt32 col_ContingentID, System.Data.SqlTypes.SqlInt32 col_RepartitionID) {
			
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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Essence'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				sqlConnection.Close();

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}", "Essence", CurrentRevision, OriginalRevision));
				}
			}
			}
#endif

			this.col_RegroupementID = col_RegroupementID;
			this.col_ContingentID = col_ContingentID;
			this.col_RepartitionID = col_RepartitionID;
		}


		public IBusinessComponentRecord Add(IBusinessComponentRecord record) {
		
			Essence_Record recordToAdd = record as Essence_Record;

			if (recordToAdd == null) {

				throw new ArgumentException("Invalid record type. Must be 'Gestion_Paie.BusinessComponents.Essence_Record'.", "record");
			}

			Params.spI_Essence Param = new Params.spI_Essence();
			Param.SetUpConnection(this.connectionString);

			Param.Param_ID = recordToAdd.Col_ID;
			Param.Param_Description = recordToAdd.Col_Description;
			Param.Param_RegroupementID = recordToAdd.Col_RegroupementID;
			Param.Param_ContingentID = recordToAdd.Col_ContingentID;
			Param.Param_RepartitionID = recordToAdd.Col_RepartitionID;
			Param.Param_Actif = recordToAdd.Col_Actif;

			SPs.spI_Essence Sp = new SPs.spI_Essence();
			if (Sp.Execute(ref Param)) {

				Essence_Record newRecord = new Essence_Record(this.connectionString, Param.Param_ID);				if (internalRecords != null) {

					internalRecords.Add(newRecord);
				}

				return(newRecord);
			}
			else {

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Essence_Collection", "Add");
			}	
		}

		/// <param name="Col_ID">[To be supplied.]</param>
		public void Remove(System.Data.SqlTypes.SqlString Col_ID) {
		
			Params.spD_Essence Param = new Params.spD_Essence(true);
			Param.SetUpConnection(this.connectionString);

			Param.Param_ID = Col_ID;


			SPs.spD_Essence Sp = new SPs.spD_Essence(true);

			Sp.Execute(ref Param);
		}

		public void Remove(IBusinessComponentRecord record) {
		
			Essence_Record recordToDelete = record as Essence_Record;

			if (recordToDelete == null) {

				throw new ArgumentException("Invalid record type. Must be 'Gestion_Paie.BusinessComponents.Essence_Record'.", "record");
			}

			Params.spD_Essence Param = new Params.spD_Essence(true);
			Param.SetUpConnection(this.connectionString);

			Param.Param_ID = recordToDelete.Col_ID;


			SPs.spD_Essence Sp = new SPs.spD_Essence(true);

			Sp.Execute(ref Param);

			if (internalRecords != null) {

				internalRecords.Remove(recordToDelete);
			}
		}

		public void Refresh() {

			internalRecords = new System.Collections.ArrayList();

			Params.spS_Essence_Display Param = new Params.spS_Essence_Display();
			Param.SetUpConnection(this.connectionString);

			if (!this.col_RegroupementID.IsNull) {

				Param.Param_RegroupementID = this.col_RegroupementID;
			}

			if (!this.col_ContingentID.IsNull) {

				Param.Param_ContingentID = this.col_ContingentID;
			}

			if (!this.col_RepartitionID.IsNull) {

				Param.Param_RepartitionID = this.col_RepartitionID;
			}


			System.Data.SqlClient.SqlDataReader sqlDataReader = null;
			SPs.spS_Essence_Display Sp = new SPs.spS_Essence_Display();
			if (Sp.Execute(ref Param, out sqlDataReader)) {

				while (sqlDataReader.Read()) {

					Essence_Record record = new Essence_Record(this.connectionString, sqlDataReader.GetSqlString(SPs.spS_Essence_Display.Resultset1.Fields.Column_ID1.ColumnIndex));

					record.displayName = "spS_Essence_Display";

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
				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Essence_Collection", "Refresh");
			}
		}

		public System.Collections.IEnumerator GetEnumerator() {

			if (!this.recordsAreLoaded) {

				Refresh();
			}

			return(internalRecords.GetEnumerator());
		}

		public Essence_Record this[int index] {

			get {
				
				return((Essence_Record)internalRecords[index]);
			}
		}

		/// <param name="col_ID">[To be supplied.]</param>
		/// <returns>[To be supplied.]</returns>
		public Essence_Record this[System.Data.SqlTypes.SqlString col_ID] {

			get {

				foreach(Essence_Record record in internalRecords) {

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
