using System;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.BusinessComponents {

	public sealed class GestionVolume_Detail_Collection : IBusinessComponentCollection, System.Collections.IEnumerable, System.ComponentModel.IListSource {

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

		private System.Data.SqlTypes.SqlInt32 col_GestionVolumeID = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_GestionVolumeID {

			get {

				return(this.col_GestionVolumeID);
			}
			set {

				this.col_GestionVolumeID = value;
			}
		}

		internal void LoadFrom_GestionVolumeID(System.Data.SqlTypes.SqlInt32 col_GestionVolumeID, GestionVolume_Record parent) {
		
			if (col_GestionVolumeID.IsNull) {

				throw new ArgumentException("Parameter can not be null", "col_GestionVolumeID");
			}

			if (parent == null) {

				throw new ArgumentException("Parameter can not be null", "parent");
			}

			this.col_GestionVolumeID = col_GestionVolumeID;
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

		private System.Data.SqlTypes.SqlString col_UniteMesureID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_UniteMesureID {

			get {

				return(this.col_UniteMesureID);
			}
			set {

				this.col_UniteMesureID = value;
			}
		}

		internal void LoadFrom_UniteMesureID(System.Data.SqlTypes.SqlString col_UniteMesureID, Essence_Unite_Record parent) {
		
			if (col_UniteMesureID.IsNull) {

				throw new ArgumentException("Parameter can not be null", "col_UniteMesureID");
			}

			if (parent == null) {

				throw new ArgumentException("Parameter can not be null", "parent");
			}

			this.col_UniteMesureID = col_UniteMesureID;
			this.parent = parent;
		}


		public GestionVolume_Detail_Collection(string connectionString) {
			
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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'GestionVolume_Detail'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				sqlConnection.Close();

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}", "GestionVolume_Detail", CurrentRevision, OriginalRevision));
				}
			}
			}
#endif

		}

		/// <param name="col_GestionVolumeID">[To be supplied.]</param>
		/// <param name="col_EssenceID">[To be supplied.]</param>
		/// <param name="col_UniteMesureID">[To be supplied.]</param>
		public GestionVolume_Detail_Collection(string connectionString, System.Data.SqlTypes.SqlInt32 col_GestionVolumeID, System.Data.SqlTypes.SqlString col_EssenceID, System.Data.SqlTypes.SqlString col_UniteMesureID) {
			
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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'GestionVolume_Detail'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				sqlConnection.Close();

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}", "GestionVolume_Detail", CurrentRevision, OriginalRevision));
				}
			}
			}
#endif

			this.col_GestionVolumeID = col_GestionVolumeID;
			this.col_EssenceID = col_EssenceID;
			this.col_UniteMesureID = col_UniteMesureID;
		}


		public IBusinessComponentRecord Add(IBusinessComponentRecord record) {
		
			GestionVolume_Detail_Record recordToAdd = record as GestionVolume_Detail_Record;

			if (recordToAdd == null) {

				throw new ArgumentException("Invalid record type. Must be 'Gestion_Paie.BusinessComponents.GestionVolume_Detail_Record'.", "record");
			}

			Params.spI_GestionVolume_Detail Param = new Params.spI_GestionVolume_Detail();
			Param.SetUpConnection(this.connectionString);

			Param.Param_ID = recordToAdd.Col_ID;
			Param.Param_GestionVolumeID = recordToAdd.Col_GestionVolumeID;
			Param.Param_EssenceID = recordToAdd.Col_EssenceID;
			Param.Param_UniteMesureID = recordToAdd.Col_UniteMesureID;
			Param.Param_VolumeBrut = recordToAdd.Col_VolumeBrut;
			Param.Param_VolumeReduction = recordToAdd.Col_VolumeReduction;
			Param.Param_VolumeNet = recordToAdd.Col_VolumeNet;

			SPs.spI_GestionVolume_Detail Sp = new SPs.spI_GestionVolume_Detail();
			if (Sp.Execute(ref Param)) {

				GestionVolume_Detail_Record newRecord = new GestionVolume_Detail_Record(this.connectionString, Param.Param_ID);				if (internalRecords != null) {

					internalRecords.Add(newRecord);
				}

				return(newRecord);
			}
			else {

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.GestionVolume_Detail_Collection", "Add");
			}	
		}

		/// <param name="Col_ID">[To be supplied.]</param>
		public void Remove(System.Data.SqlTypes.SqlInt32 Col_ID) {
		
			Params.spD_GestionVolume_Detail Param = new Params.spD_GestionVolume_Detail(true);
			Param.SetUpConnection(this.connectionString);

			Param.Param_ID = Col_ID;


			SPs.spD_GestionVolume_Detail Sp = new SPs.spD_GestionVolume_Detail(true);

			Sp.Execute(ref Param);
		}

		public void Remove(IBusinessComponentRecord record) {
		
			GestionVolume_Detail_Record recordToDelete = record as GestionVolume_Detail_Record;

			if (recordToDelete == null) {

				throw new ArgumentException("Invalid record type. Must be 'Gestion_Paie.BusinessComponents.GestionVolume_Detail_Record'.", "record");
			}

			Params.spD_GestionVolume_Detail Param = new Params.spD_GestionVolume_Detail(true);
			Param.SetUpConnection(this.connectionString);

			Param.Param_ID = recordToDelete.Col_ID;


			SPs.spD_GestionVolume_Detail Sp = new SPs.spD_GestionVolume_Detail(true);

			Sp.Execute(ref Param);

			if (internalRecords != null) {

				internalRecords.Remove(recordToDelete);
			}
		}

		public void Refresh() {

			internalRecords = new System.Collections.ArrayList();

			Params.spS_GestionVolume_Detail_Display Param = new Params.spS_GestionVolume_Detail_Display();
			Param.SetUpConnection(this.connectionString);

			if (!this.col_GestionVolumeID.IsNull) {

				Param.Param_GestionVolumeID = this.col_GestionVolumeID;
			}

			if (!this.col_EssenceID.IsNull) {

				Param.Param_EssenceID = this.col_EssenceID;
			}

			if (!this.col_UniteMesureID.IsNull) {

				Param.Param_UniteMesureID = this.col_UniteMesureID;
			}


			System.Data.SqlClient.SqlDataReader sqlDataReader = null;
			SPs.spS_GestionVolume_Detail_Display Sp = new SPs.spS_GestionVolume_Detail_Display();
			if (Sp.Execute(ref Param, out sqlDataReader)) {

				while (sqlDataReader.Read()) {

					GestionVolume_Detail_Record record = new GestionVolume_Detail_Record(this.connectionString, sqlDataReader.GetSqlInt32(SPs.spS_GestionVolume_Detail_Display.Resultset1.Fields.Column_ID1.ColumnIndex));

					record.displayName = "spS_GestionVolume_Detail_Display";

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
				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.GestionVolume_Detail_Collection", "Refresh");
			}
		}

		public System.Collections.IEnumerator GetEnumerator() {

			if (!this.recordsAreLoaded) {

				Refresh();
			}

			return(internalRecords.GetEnumerator());
		}

		public GestionVolume_Detail_Record this[int index] {

			get {
				
				return((GestionVolume_Detail_Record)internalRecords[index]);
			}
		}

		/// <param name="col_ID">[To be supplied.]</param>
		/// <returns>[To be supplied.]</returns>
		public GestionVolume_Detail_Record this[System.Data.SqlTypes.SqlInt32 col_ID] {

			get {

				foreach(GestionVolume_Detail_Record record in internalRecords) {

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
