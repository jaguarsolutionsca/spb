﻿using System;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.BusinessComponents {

	public sealed class Ajustement_Transporteur_Collection : IBusinessComponentCollection, System.Collections.IEnumerable, System.ComponentModel.IListSource {

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

		private System.Data.SqlTypes.SqlInt32 col_AjustementID = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_AjustementID {

			get {

				return(this.col_AjustementID);
			}
			set {

				this.col_AjustementID = value;
			}
		}

		internal void LoadFrom_AjustementID(System.Data.SqlTypes.SqlInt32 col_AjustementID, Ajustement_Record parent) {
		
			if (col_AjustementID.IsNull) {

				throw new ArgumentException("Parameter can not be null", "col_AjustementID");
			}

			if (parent == null) {

				throw new ArgumentException("Parameter can not be null", "parent");
			}

			this.col_AjustementID = col_AjustementID;
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

		internal void LoadFrom_UniteID(System.Data.SqlTypes.SqlString col_UniteID, Contrat_Transporteur_Record parent) {
		
			if (col_UniteID.IsNull) {

				throw new ArgumentException("Parameter can not be null", "col_UniteID");
			}

			if (parent == null) {

				throw new ArgumentException("Parameter can not be null", "parent");
			}

			this.col_UniteID = col_UniteID;
			this.parent = parent;
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

		internal void LoadFrom_MunicipaliteID(System.Data.SqlTypes.SqlString col_MunicipaliteID, Contrat_Transporteur_Record parent) {
		
			if (col_MunicipaliteID.IsNull) {

				throw new ArgumentException("Parameter can not be null", "col_MunicipaliteID");
			}

			if (parent == null) {

				throw new ArgumentException("Parameter can not be null", "parent");
			}

			this.col_MunicipaliteID = col_MunicipaliteID;
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

		internal void LoadFrom_ContratID(System.Data.SqlTypes.SqlString col_ContratID, Contrat_Transporteur_Record parent) {
		
			if (col_ContratID.IsNull) {

				throw new ArgumentException("Parameter can not be null", "col_ContratID");
			}

			if (parent == null) {

				throw new ArgumentException("Parameter can not be null", "parent");
			}

			this.col_ContratID = col_ContratID;
			this.parent = parent;
		}

		private System.Data.SqlTypes.SqlString col_ZoneID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_ZoneID {

			get {

				return(this.col_ZoneID);
			}
			set {

				this.col_ZoneID = value;
			}
		}

		internal void LoadFrom_ZoneID(System.Data.SqlTypes.SqlString col_ZoneID, Contrat_Transporteur_Record parent) {
		
			if (col_ZoneID.IsNull) {

				throw new ArgumentException("Parameter can not be null", "col_ZoneID");
			}

			if (parent == null) {

				throw new ArgumentException("Parameter can not be null", "parent");
			}

			this.col_ZoneID = col_ZoneID;
			this.parent = parent;
		}


		public Ajustement_Transporteur_Collection(string connectionString) {
			
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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Ajustement_Transporteur'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				sqlConnection.Close();

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}", "Ajustement_Transporteur", CurrentRevision, OriginalRevision));
				}
			}
			}
#endif

		}

		/// <param name="col_ContratID">[To be supplied.]</param>
		public Ajustement_Transporteur_Collection(string connectionString, System.Data.SqlTypes.SqlString col_ContratID) {
			
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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Ajustement_Transporteur'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				sqlConnection.Close();

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}", "Ajustement_Transporteur", CurrentRevision, OriginalRevision));
				}
			}
			}
#endif

			this.col_ContratID = col_ContratID;
		}


		public IBusinessComponentRecord Add(IBusinessComponentRecord record) {
		
			Ajustement_Transporteur_Record recordToAdd = record as Ajustement_Transporteur_Record;

			if (recordToAdd == null) {

				throw new ArgumentException("Invalid record type. Must be 'Gestion_Paie.BusinessComponents.Ajustement_Transporteur_Record'.", "record");
			}

			Params.spI_Ajustement_Transporteur Param = new Params.spI_Ajustement_Transporteur();
			Param.SetUpConnection(this.connectionString);

			Param.Param_AjustementID = recordToAdd.Col_AjustementID;
			Param.Param_UniteID = recordToAdd.Col_UniteID;
			Param.Param_MunicipaliteID = recordToAdd.Col_MunicipaliteID;
			Param.Param_ContratID = recordToAdd.Col_ContratID;
			Param.Param_Taux_transporteur = recordToAdd.Col_Taux_transporteur;
			Param.Param_Date_Modification = recordToAdd.Col_Date_Modification;
			Param.Param_ZoneID = recordToAdd.Col_ZoneID;

			SPs.spI_Ajustement_Transporteur Sp = new SPs.spI_Ajustement_Transporteur();
			if (Sp.Execute(ref Param)) {

				Ajustement_Transporteur_Record newRecord = new Ajustement_Transporteur_Record(this.connectionString, Param.Param_AjustementID, Param.Param_UniteID, Param.Param_MunicipaliteID, Param.Param_ZoneID);				if (internalRecords != null) {

					internalRecords.Add(newRecord);
				}

				return(newRecord);
			}
			else {

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Ajustement_Transporteur_Collection", "Add");
			}	
		}

		/// <param name="Col_AjustementID">[To be supplied.]</param>
		/// <param name="Col_UniteID">[To be supplied.]</param>
		/// <param name="Col_MunicipaliteID">[To be supplied.]</param>
		/// <param name="Col_ZoneID">[To be supplied.]</param>
		public void Remove(System.Data.SqlTypes.SqlInt32 Col_AjustementID, System.Data.SqlTypes.SqlString Col_UniteID, System.Data.SqlTypes.SqlString Col_MunicipaliteID, System.Data.SqlTypes.SqlString Col_ZoneID) {
		
			Params.spD_Ajustement_Transporteur Param = new Params.spD_Ajustement_Transporteur(true);
			Param.SetUpConnection(this.connectionString);

			Param.Param_AjustementID = Col_AjustementID;

			Param.Param_UniteID = Col_UniteID;

			Param.Param_MunicipaliteID = Col_MunicipaliteID;

			Param.Param_ZoneID = Col_ZoneID;


			SPs.spD_Ajustement_Transporteur Sp = new SPs.spD_Ajustement_Transporteur(true);

			Sp.Execute(ref Param);
		}

		public void Remove(IBusinessComponentRecord record) {
		
			Ajustement_Transporteur_Record recordToDelete = record as Ajustement_Transporteur_Record;

			if (recordToDelete == null) {

				throw new ArgumentException("Invalid record type. Must be 'Gestion_Paie.BusinessComponents.Ajustement_Transporteur_Record'.", "record");
			}

			Params.spD_Ajustement_Transporteur Param = new Params.spD_Ajustement_Transporteur(true);
			Param.SetUpConnection(this.connectionString);

			Param.Param_AjustementID = recordToDelete.Col_AjustementID;

			Param.Param_UniteID = recordToDelete.Col_UniteID;

			Param.Param_MunicipaliteID = recordToDelete.Col_MunicipaliteID;

			Param.Param_ZoneID = recordToDelete.Col_ZoneID;


			SPs.spD_Ajustement_Transporteur Sp = new SPs.spD_Ajustement_Transporteur(true);

			Sp.Execute(ref Param);

			if (internalRecords != null) {

				internalRecords.Remove(recordToDelete);
			}
		}

		public void Refresh() {

			internalRecords = new System.Collections.ArrayList();

			Params.spS_Ajustement_Transporteur_Display Param = new Params.spS_Ajustement_Transporteur_Display();
			Param.SetUpConnection(this.connectionString);

			if (!this.col_AjustementID.IsNull) {

				Param.Param_AjustementID = this.col_AjustementID;
			}

			if (!this.col_UniteID.IsNull) {

				Param.Param_UniteID = this.col_UniteID;
			}

			if (!this.col_MunicipaliteID.IsNull) {

				Param.Param_MunicipaliteID = this.col_MunicipaliteID;
			}

			if (!this.col_ContratID.IsNull) {

				Param.Param_ContratID = this.col_ContratID;
			}

			if (!this.col_ZoneID.IsNull) {

				Param.Param_ZoneID = this.col_ZoneID;
			}


			System.Data.SqlClient.SqlDataReader sqlDataReader = null;
			SPs.spS_Ajustement_Transporteur_Display Sp = new SPs.spS_Ajustement_Transporteur_Display();
			if (Sp.Execute(ref Param, out sqlDataReader)) {

				while (sqlDataReader.Read()) {

					Ajustement_Transporteur_Record record = new Ajustement_Transporteur_Record(this.connectionString, sqlDataReader.GetSqlInt32(SPs.spS_Ajustement_Transporteur_Display.Resultset1.Fields.Column_ID1.ColumnIndex), sqlDataReader.GetSqlString(SPs.spS_Ajustement_Transporteur_Display.Resultset1.Fields.Column_ID2.ColumnIndex), sqlDataReader.GetSqlString(SPs.spS_Ajustement_Transporteur_Display.Resultset1.Fields.Column_ID3.ColumnIndex), sqlDataReader.GetSqlString(SPs.spS_Ajustement_Transporteur_Display.Resultset1.Fields.Column_ID4.ColumnIndex));

					record.displayName = "spS_Ajustement_Transporteur_Display";

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
				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Ajustement_Transporteur_Collection", "Refresh");
			}
		}

		public System.Collections.IEnumerator GetEnumerator() {

			if (!this.recordsAreLoaded) {

				Refresh();
			}

			return(internalRecords.GetEnumerator());
		}

		public Ajustement_Transporteur_Record this[int index] {

			get {
				
				return((Ajustement_Transporteur_Record)internalRecords[index]);
			}
		}

		/// <param name="col_AjustementID">[To be supplied.]</param>
		/// <param name="col_UniteID">[To be supplied.]</param>
		/// <param name="col_MunicipaliteID">[To be supplied.]</param>
		/// <param name="col_ZoneID">[To be supplied.]</param>
		/// <returns>[To be supplied.]</returns>
		public Ajustement_Transporteur_Record this[System.Data.SqlTypes.SqlInt32 col_AjustementID, System.Data.SqlTypes.SqlString col_UniteID, System.Data.SqlTypes.SqlString col_MunicipaliteID, System.Data.SqlTypes.SqlString col_ZoneID] {

			get {

				foreach(Ajustement_Transporteur_Record record in internalRecords) {

					bool Equality = true;

					Equality = Equality && (record.Col_AjustementID == col_AjustementID).Value;
					if (Equality) return(null);

					Equality = Equality && (record.Col_UniteID == col_UniteID).Value;
					if (Equality) return(null);

					Equality = Equality && (record.Col_MunicipaliteID == col_MunicipaliteID).Value;
					if (Equality) return(null);

					Equality = Equality && (record.Col_ZoneID == col_ZoneID).Value;
					if (Equality) return(null);

					return(record);
				}
				return(null);
			}
		}
	}
}
