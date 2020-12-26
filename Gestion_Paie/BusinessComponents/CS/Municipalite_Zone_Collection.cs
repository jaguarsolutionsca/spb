using System;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.BusinessComponents {

	public sealed class Municipalite_Zone_Collection : IBusinessComponentCollection, System.Collections.IEnumerable, System.ComponentModel.IListSource {

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

		private System.Data.SqlTypes.SqlString col_MunicipaliteID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_MunicipaliteID {

			get {

				return(this.col_MunicipaliteID);
			}
			set {

				this.col_MunicipaliteID = value;
			}
		}

		internal void LoadFrom_MunicipaliteID(System.Data.SqlTypes.SqlString col_MunicipaliteID, Municipalite_Record parent) {
		
			if (col_MunicipaliteID.IsNull) {

				throw new ArgumentException("Parameter can not be null", "col_MunicipaliteID");
			}

			if (parent == null) {

				throw new ArgumentException("Parameter can not be null", "parent");
			}

			this.col_MunicipaliteID = col_MunicipaliteID;
			this.parent = parent;
		}


		public Municipalite_Zone_Collection(string connectionString) {
			
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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Municipalite_Zone'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				sqlConnection.Close();

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}", "Municipalite_Zone", CurrentRevision, OriginalRevision));
				}
			}
			}
#endif

		}


		public IBusinessComponentRecord Add(IBusinessComponentRecord record) {
		
			Municipalite_Zone_Record recordToAdd = record as Municipalite_Zone_Record;

			if (recordToAdd == null) {

				throw new ArgumentException("Invalid record type. Must be 'Gestion_Paie.BusinessComponents.Municipalite_Zone_Record'.", "record");
			}

			Params.spI_Municipalite_Zone Param = new Params.spI_Municipalite_Zone();
			Param.SetUpConnection(this.connectionString);

			Param.Param_ID = recordToAdd.Col_ID;
			Param.Param_MunicipaliteID = recordToAdd.Col_MunicipaliteID;
			Param.Param_Description = recordToAdd.Col_Description;
			Param.Param_Actif = recordToAdd.Col_Actif;

			SPs.spI_Municipalite_Zone Sp = new SPs.spI_Municipalite_Zone();
			if (Sp.Execute(ref Param)) {

				Municipalite_Zone_Record newRecord = new Municipalite_Zone_Record(this.connectionString, Param.Param_ID, Param.Param_MunicipaliteID);				if (internalRecords != null) {

					internalRecords.Add(newRecord);
				}

				return(newRecord);
			}
			else {

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Municipalite_Zone_Collection", "Add");
			}	
		}

		/// <param name="Col_ID">[To be supplied.]</param>
		/// <param name="Col_MunicipaliteID">[To be supplied.]</param>
		public void Remove(System.Data.SqlTypes.SqlString Col_ID, System.Data.SqlTypes.SqlString Col_MunicipaliteID) {
		
			Params.spD_Municipalite_Zone Param = new Params.spD_Municipalite_Zone(true);
			Param.SetUpConnection(this.connectionString);

			Param.Param_ID = Col_ID;

			Param.Param_MunicipaliteID = Col_MunicipaliteID;


			SPs.spD_Municipalite_Zone Sp = new SPs.spD_Municipalite_Zone(true);

			Sp.Execute(ref Param);
		}

		public void Remove(IBusinessComponentRecord record) {
		
			Municipalite_Zone_Record recordToDelete = record as Municipalite_Zone_Record;

			if (recordToDelete == null) {

				throw new ArgumentException("Invalid record type. Must be 'Gestion_Paie.BusinessComponents.Municipalite_Zone_Record'.", "record");
			}

			Params.spD_Municipalite_Zone Param = new Params.spD_Municipalite_Zone(true);
			Param.SetUpConnection(this.connectionString);

			Param.Param_ID = recordToDelete.Col_ID;

			Param.Param_MunicipaliteID = recordToDelete.Col_MunicipaliteID;


			SPs.spD_Municipalite_Zone Sp = new SPs.spD_Municipalite_Zone(true);

			Sp.Execute(ref Param);

			if (internalRecords != null) {

				internalRecords.Remove(recordToDelete);
			}
		}

		public void Refresh() {

			internalRecords = new System.Collections.ArrayList();

			Params.spS_Municipalite_Zone_Display Param = new Params.spS_Municipalite_Zone_Display();
			Param.SetUpConnection(this.connectionString);

			if (!this.col_MunicipaliteID.IsNull) {

				Param.Param_MunicipaliteID = this.col_MunicipaliteID;
			}


			System.Data.SqlClient.SqlDataReader sqlDataReader = null;
			SPs.spS_Municipalite_Zone_Display Sp = new SPs.spS_Municipalite_Zone_Display();
			if (Sp.Execute(ref Param, out sqlDataReader)) {

				while (sqlDataReader.Read()) {

					Municipalite_Zone_Record record = new Municipalite_Zone_Record(this.connectionString, sqlDataReader.GetSqlString(SPs.spS_Municipalite_Zone_Display.Resultset1.Fields.Column_ID1.ColumnIndex), sqlDataReader.GetSqlString(SPs.spS_Municipalite_Zone_Display.Resultset1.Fields.Column_ID2.ColumnIndex));

					record.displayName = "spS_Municipalite_Zone_Display";

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
				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Municipalite_Zone_Collection", "Refresh");
			}
		}

		public System.Collections.IEnumerator GetEnumerator() {

			if (!this.recordsAreLoaded) {

				Refresh();
			}

			return(internalRecords.GetEnumerator());
		}

		public Municipalite_Zone_Record this[int index] {

			get {
				
				return((Municipalite_Zone_Record)internalRecords[index]);
			}
		}

		/// <param name="col_ID">[To be supplied.]</param>
		/// <param name="col_MunicipaliteID">[To be supplied.]</param>
		/// <returns>[To be supplied.]</returns>
		public Municipalite_Zone_Record this[System.Data.SqlTypes.SqlString col_ID, System.Data.SqlTypes.SqlString col_MunicipaliteID] {

			get {

				foreach(Municipalite_Zone_Record record in internalRecords) {

					bool Equality = true;

					Equality = Equality && (record.Col_ID == col_ID).Value;
					if (Equality) return(null);

					Equality = Equality && (record.Col_MunicipaliteID == col_MunicipaliteID).Value;
					if (Equality) return(null);

					return(record);
				}
				return(null);
			}
		}
	}
}
