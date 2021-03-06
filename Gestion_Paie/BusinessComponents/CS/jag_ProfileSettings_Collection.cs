﻿using System;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.BusinessComponents {

	public sealed class jag_ProfileSettings_Collection : IBusinessComponentCollection, System.Collections.IEnumerable, System.ComponentModel.IListSource {

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

		private System.Data.SqlTypes.SqlInt32 col_ProfileID = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_ProfileID {

			get {

				return(this.col_ProfileID);
			}
			set {

				this.col_ProfileID = value;
			}
		}

		internal void LoadFrom_ProfileID(System.Data.SqlTypes.SqlInt32 col_ProfileID, jag_Profile_Record parent) {
		
			if (col_ProfileID.IsNull) {

				throw new ArgumentException("Parameter can not be null", "col_ProfileID");
			}

			if (parent == null) {

				throw new ArgumentException("Parameter can not be null", "parent");
			}

			this.col_ProfileID = col_ProfileID;
			this.parent = parent;
		}


		public jag_ProfileSettings_Collection(string connectionString) {
			
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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'jag_ProfileSettings'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				sqlConnection.Close();

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}", "jag_ProfileSettings", CurrentRevision, OriginalRevision));
				}
			}
			}
#endif

		}


		public IBusinessComponentRecord Add(IBusinessComponentRecord record) {
		
			jag_ProfileSettings_Record recordToAdd = record as jag_ProfileSettings_Record;

			if (recordToAdd == null) {

				throw new ArgumentException("Invalid record type. Must be 'Gestion_Paie.BusinessComponents.jag_ProfileSettings_Record'.", "record");
			}

			Params.spI_jag_ProfileSettings Param = new Params.spI_jag_ProfileSettings();
			Param.SetUpConnection(this.connectionString);

			Param.Param_ProfileID = recordToAdd.Col_ProfileID;
			Param.Param_Name = recordToAdd.Col_Name;
			Param.Param_Value = recordToAdd.Col_Value;

			SPs.spI_jag_ProfileSettings Sp = new SPs.spI_jag_ProfileSettings();
			if (Sp.Execute(ref Param)) {

				jag_ProfileSettings_Record newRecord = new jag_ProfileSettings_Record(this.connectionString, Param.Param_ProfileID, Param.Param_Name);				if (internalRecords != null) {

					internalRecords.Add(newRecord);
				}

				return(newRecord);
			}
			else {

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.jag_ProfileSettings_Collection", "Add");
			}	
		}

		/// <param name="Col_ProfileID">[To be supplied.]</param>
		/// <param name="Col_Name">[To be supplied.]</param>
		public void Remove(System.Data.SqlTypes.SqlInt32 Col_ProfileID, System.Data.SqlTypes.SqlString Col_Name) {
		
			Params.spD_jag_ProfileSettings Param = new Params.spD_jag_ProfileSettings(true);
			Param.SetUpConnection(this.connectionString);

			Param.Param_ProfileID = Col_ProfileID;

			Param.Param_Name = Col_Name;


			SPs.spD_jag_ProfileSettings Sp = new SPs.spD_jag_ProfileSettings(true);

			Sp.Execute(ref Param);
		}

		public void Remove(IBusinessComponentRecord record) {
		
			jag_ProfileSettings_Record recordToDelete = record as jag_ProfileSettings_Record;

			if (recordToDelete == null) {

				throw new ArgumentException("Invalid record type. Must be 'Gestion_Paie.BusinessComponents.jag_ProfileSettings_Record'.", "record");
			}

			Params.spD_jag_ProfileSettings Param = new Params.spD_jag_ProfileSettings(true);
			Param.SetUpConnection(this.connectionString);

			Param.Param_ProfileID = recordToDelete.Col_ProfileID;

			Param.Param_Name = recordToDelete.Col_Name;


			SPs.spD_jag_ProfileSettings Sp = new SPs.spD_jag_ProfileSettings(true);

			Sp.Execute(ref Param);

			if (internalRecords != null) {

				internalRecords.Remove(recordToDelete);
			}
		}

		public void Refresh() {

			internalRecords = new System.Collections.ArrayList();

			Params.spS_jag_ProfileSettings_Display Param = new Params.spS_jag_ProfileSettings_Display();
			Param.SetUpConnection(this.connectionString);

			if (!this.col_ProfileID.IsNull) {

				Param.Param_ProfileID = this.col_ProfileID;
			}


			System.Data.SqlClient.SqlDataReader sqlDataReader = null;
			SPs.spS_jag_ProfileSettings_Display Sp = new SPs.spS_jag_ProfileSettings_Display();
			if (Sp.Execute(ref Param, out sqlDataReader)) {

				while (sqlDataReader.Read()) {

					jag_ProfileSettings_Record record = new jag_ProfileSettings_Record(this.connectionString, sqlDataReader.GetSqlInt32(SPs.spS_jag_ProfileSettings_Display.Resultset1.Fields.Column_ID1.ColumnIndex), sqlDataReader.GetSqlString(SPs.spS_jag_ProfileSettings_Display.Resultset1.Fields.Column_ID2.ColumnIndex));

					record.displayName = "spS_jag_ProfileSettings_Display";

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
				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.jag_ProfileSettings_Collection", "Refresh");
			}
		}

		public System.Collections.IEnumerator GetEnumerator() {

			if (!this.recordsAreLoaded) {

				Refresh();
			}

			return(internalRecords.GetEnumerator());
		}

		public jag_ProfileSettings_Record this[int index] {

			get {
				
				return((jag_ProfileSettings_Record)internalRecords[index]);
			}
		}

		/// <param name="col_ProfileID">[To be supplied.]</param>
		/// <param name="col_Name">[To be supplied.]</param>
		/// <returns>[To be supplied.]</returns>
		public jag_ProfileSettings_Record this[System.Data.SqlTypes.SqlInt32 col_ProfileID, System.Data.SqlTypes.SqlString col_Name] {

			get {

				foreach(jag_ProfileSettings_Record record in internalRecords) {

					bool Equality = true;

					Equality = Equality && (record.Col_ProfileID == col_ProfileID).Value;
					if (Equality) return(null);

					Equality = Equality && (record.Col_Name == col_Name).Value;
					if (Equality) return(null);

					return(record);
				}
				return(null);
			}
		}
	}
}
